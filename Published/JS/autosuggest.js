/* Auto-suggest control, version 2.3, August 18th 2009.
*
* (c) 2007-2009 Dmitriy Khudorozhkov (dmitrykhudorozhkov@yahoo.com)
*
* Latest version download and documentation:
* http://www.codeproject.com/KB/scripting/AutoSuggestControl.aspx
*
* Based on "Auto-complete Control" by zichun:
* http://www.codeproject.com/KB/scripting/jsactb.aspx
*
* This software is provided "as-is", without any express or implied warranty.
* In no event will the author be held liable for any damages arising from the
* use of this software.
*
* Permission is granted to anyone to use this software for any purpose,
* including commercial applications, and to alter it and redistribute it
* freely, subject to the following restrictions:
*
* 1. The origin of this software must not be misrepresented; you must not
*    claim that you wrote the original software. If you use this software
*    in a product, an acknowledgment in the product documentation would be
*    appreciated but is not required.
*
* 2. Altered source versions must be plainly marked as such, and must not be
*    misrepresented as being the original software.
*
* 3. This notice may not be removed or altered from any source distribution.
*/

var autosuggest_url = ""; // Global link to the server-side script, that gives you the suggestion list.
// Used for controls that do not define their own server script urls.

function autosuggest(id, array, url, onSelect) {
    // "Public" variables:

    this.parameters = new Array();  // Added by Jason 8/25/2009. Stores parameters to send with the ajax query string.
    // Added by Jason 9/5/2009.
    this.use_dropdown_button = false;
    this.filter_suggestions = true;  // Indicates whether the suggestions are filtered based on the value input.
    this.read_only = false;
    this.fill_visible = true;   // Indicates whether the suggestion div is to be visible while building.
    // End of addition.

    this.time_out = 0; 	// autocomplete timeout, in milliseconds (0: autocomplete never times out)
    this.response_time = 500; // time, in milliseconds, between the last char typed and the actual query
    this.entry_limit = 10; // number of entries autocomplete will show at a time

    this.limit_start = false; // should the auto complete be limited to the beginning of keyword?
    this.match_first = false; // if previous is false, should the exact matches be displayed first?
    this.restrict_typing = false; // restrict to existing members of array
    this.full_refresh = false; // should the script re-send the AJAX request after each typed character?

    this.use_iframe = true; // should the control use an IFrame element to fix suggestion list positioning (MS IE only)?
    this.use_scroll = true; // should the control use a scroll bar (true) or a up/down arrow-buttons (false)?
    this.use_mouse = true; // enable mouse support
    this.no_default = true; // should the control omit selecting the 1st item in a suggestion list?
    this.start_check = 0; 	// show widget only after this number of characters is typed in (effective if >1)

    this.text_delimiter = [";", ","]; // delimiter for multiple autocomplete entries. Set it to empty array ( [] ) for single autocomplete.
    this.ajax_delimiter = "|"; 			// character that delimits entries in the string returned by AJAX call
    this.item_delimiter = ","; 			// character that delimits key and value for the suggestion item in the string returned by AJAX call

    this.selectedIndex = -1; // index (zero-based) of the entry last selected

    // Styles:

    this.bg_color = "#FFFFF0"; // background color for the suggestion list
    this.ar_color = "#656291"; // background color for the "arrow" rows (used if use_scroll is false)
    this.text_color = "#000"; 	// text color for the non-selected suggestions
    this.htext_color = "#F00"; 	// text color for the selected suggestion
    this.hcolor = "#D6D7E7"; // background color for the selected suggestion
    this.font = "verdana,arial,helvetica"; // font(s) of suggestion items
    this.font_size = "10px"; 	// font size of suggestion items

    // "Private" variables:

    this.suggest_url = url || (array ? "" : autosuggest_url); // URL the server-side script that gives you the suggestion list
    this.msie = (document.all && !window.opera);

    this.displayed = false;

    this.delim_words = [];
    this.current_word = 0;
    this.delim_char = [];

    this.current = 0;
    this.total = 0;
    this.range_up = 0;
    this.range_down = 0;

    this.previous = 0;
    this.timer = 0;
    this.rebuild = false;
    this.evsetup = false;

    this.bool = [];
    this.rows = [];

    this.onSelect = onSelect || null;

    this.cur_x = 0;
    this.cur_y = 0;
    this.cur_w = 0;
    this.cur_h = 0;

    this.mouse_x = 0;
    this.mouse_y = 0;

    this.mouse_on_list = 0;
    this.caret_moved = false;

    this.field_id = id;
    this.field = document.getElementById(id);
    this.lastterm = this.field.value;

    this.keywords = [], this.keywords_init = [];
    this.values = [], this.values_init = [];
    // Changed by Jason 9/7/2009: Added drop-down button images.
    this.image = ["arrow-down.gif", "arrow-down-d.gif", "arrow-up.gif", "arrow-up-d.gif", "drop-down.png", "drop-down_h.png", "drop-down_p.png"];
    // End of change.
    return this.construct(array || []);
};

autosuggest.prototype = {

    construct: function(array) {
        function callLater(func, obj, param1, param2) { return function() { func.call(obj, param1 || null, param2 || null) }; }

        this.field.autosuggest = this;

        // Precache arrows: Changed by Jason 9/7/2009: Also precaching drop-down button.
        if (!this.use_scroll) {
            for (var i = 0; i < 7; i++) // 
            {
                var img = new Image;
                img.src = this.image[i];
            }
        }

        // Initialize the control from JS array, if any:

        this.bindArray(array);

        // Create event handlers:

        this.funcClick = this.mouseClick;
        this.funcCheck = this.checkKey;
        this.funcPress = this.keyPress;

        this.funcHighlight = this.highlightTable;

        this.funcClear = callLater(this.clearEvents, this);

        this.funcUp = callLater(this.scroll, this, true, 1);
        this.funcDown = callLater(this.scroll, this, false, 1);

        this.funcFocus = callLater(this.focusTable, this);
        this.funcUnfocus = callLater(this.unfocusTable, this);

        this.addEvent(this.field, "focus", callLater(this.setupEvents, this));
        this.addEvent(window, "resize", callLater(this.reposition, this));

        // Added by Jason 9/5/2009:
        var that = this;
        setTimeout(function() {
            if (that.use_dropdown_button)
                that.addDropDownButton();   // Display drop-down button.	
            if (that.read_only) {
                that.field.setAttribute("readonly", "readonly");    // Set read-only.
                that.field.style.cursor = "default";
                that.field.onclick = function() { that.show(false); };
                that.fillAndSelect();
                that.parameterChangeFill();
            }
        }, 50);
        // End of Addition

        return this;
    },

    // Added by Jason 8/25/2009. Returns the parameter string to send as querystring for ajax call.
    getParameterString: function() {
        var parameterString = "";
        var name = "";
        var value = "";
        for (var index = 0; index < this.parameters.length; index++) {
            name = this.parameters[index][0];
            value = this.parameters[index][1];
            if (name.substring(0, 1) == "@") {
                var el = document.getElementById(name.substring(1, name.length));
                name = value;
                if (el)
                    value = el.value;
            }
            if (parameterString.length > 0)
                parameterString = parameterString + "&" + name + "=" + value;
            else
                parameterString = parameterString + name + "=" + value;
        }
        return parameterString;
    },

    // Added by Jason 9/4/2009: Display drop-down button.
    addDropDownButton: function() {
        var originalWidth = this.field.style.width.replace("px", "");
        var newWidth = originalWidth - 18;
        var dropDownButton = document.createElement("img");
        dropDownButton.setAttribute("src", this.image[4]);
        dropDownButton.style.position = "absolute";
        var left = this.browserAdjustLeft(this.curPos(this.field, "Left") + this.field.offsetWidth - 20);
        var top = this.browserAdjustTop(this.curPos(this.field, "Top") + 2);
        dropDownButton.setAttribute("style", "position: absolute; top: " + top + "px; left: " + left + "px;");
        this.field.parentNode.insertBefore(dropDownButton, this.field.nextSibling);
        dropDownButton.autosuggest = this;
        var that = this;
        dropDownButton.onclick = function() { that.show(false); };
        dropDownButton.onmousedown = function() { dropDownButton.setAttribute("src", that.image[6]); };
        dropDownButton.onmouseup = function() { dropDownButton.setAttribute("src", that.image[4]); };
        dropDownButton.onmouseover = function() { dropDownButton.setAttribute("src", that.image[5]); };
        dropDownButton.onmouseout = function() { dropDownButton.setAttribute("src", that.image[4]); };
    },

    show: function(hidden) {
        this.field.focus();
        this.timer = 1;
        this.preSuggest(-1, hidden);
        var that = this;
    },

    fillAndSelect: function() {
        this.show(true);
    },

    select: function() {
        if (this.field.value == "" && this.keywords.length) {
            this.field.value = this.trim(this.keywords[0]);
            return;
        }
        else {
            var containsValue = false;
            for (var keywordIndex = 0; keywordIndex < this.keywords.length; keywordIndex++) {
                if (this.trim(this.keywords[keywordIndex]) == this.field.value) {
                    containsValue = true;
                    this.selectIndex(keywordIndex, false);
                    break;
                }
            }
            if (!containsValue) {
                this.selectIndex(0, true);
            }
        }
        if (this.field.onchange) this.field.onchange();
    },

    // Added by Jason 9/7/2009: Assigning values to server control's hidden
    // fields and optionally setting the field value.
    selectIndex: function(index, setFieldValue) {
        var selectedValueField = document.getElementsByName(this.field.name + "$SelectedValue");
        var selectedTextField = document.getElementsByName(this.field.name + "$SelectedText");
        var selectedIndexField = document.getElementsByName(this.field.name + "$SelectedIndex");
        if (index >= this.keywords.length)
            index = this.keywords.length - 1;
        this.selectedIndex = index;
        this.current = index;
        if (setFieldValue) {
            if (index >= 0)
                this.field.value = this.trim(this.keywords[index]);
            else
                this.field.value = "";
        }
        if (selectedValueField) {
            if (selectedValueField[0] != null) {
                if (index >= 0)
                    selectedValueField[0].value = this.trim(this.values[index]);
                else
                    selectedValueField[0].value = "";
            }
        }
        if (selectedTextField) {

            if (selectedTextField[0] != null) {
                if (index >= 0)
                    selectedTextField[0].value = this.trim(this.keywords[index]);
                else
                    selectedTextField[0].value = "";
            }
        }
        if (selectedIndexField) {
            if (selectedTextField[0] != null) {
                if (index >= 0)
                    selectedIndexField[0].value = index;
                else
                    selectedIndexField[0].value = -1;
            }
        }
    },

    selectKeyCode: function(code, setFieldValue) {
        var curWord = this.trim(this.keywords[this.selectedIndex]).toLowerCase();
        var curCharacter = curWord.substring(0, 1);
        var character = String.fromCharCode(code).toLowerCase();
        var selectedIndex = -1;

        if (curCharacter != character) {
            for (var index = 0; index < this.keywords.length; index++) {
                if (this.trim(this.keywords[index]).toLowerCase().substring(0, 1) == character) {
                    selectedIndex = index;
                    break;
                }
            }
        }
        else {
            var selected = false;
            for (var index = this.selectedIndex + 1; index < this.keywords.length; index++) {
                if (this.trim(this.keywords[index]).toLowerCase().substring(0, 1) == character) {
                    selectedIndex = index;
                    selected = true;
                    break;
                }
            }
            if (!selected) {
                for (var index = 0; index < this.selectedIndex; index++) {
                    if (this.trim(this.keywords[index]).toLowerCase().substring(0, 1) == character) {
                        selectedIndex = index;
                        break;
                    }
                }
            }
        }
        if (selectedIndex != -1) {
            if (this.displayed) {
                document.getElementById("suggest_table_" + this.field_id).scrollTop = 0;
                this.scroll(false, selectedIndex - this.current);
            }
            this.selectIndex(selectedIndex, true);
        }
    },

    parameterChangeFill: function() {
        if (this.parameters.length) {
            var that = this;
            for (var parameterIndex = 0; parameterIndex < this.parameters.length; parameterIndex++) {
                var name = this.parameters[parameterIndex][0];
                if (name.substring(0, 1) == "@") {
                    var el = document.getElementById(name.substring(1, name.length));
                    if (el)
                        el.onchange = function() { that.fillAndSelect(); };
                }
            }
        }

    },

    // Added by Jason 9/5/2009: Typing restriction for AJAX.
    ajaxRestrict: function(hidden) {
        var text = this.trim(this.field.value);
        var newValue = "";
        var containsNewValue = false;
        for (var charIndex = 0; charIndex < text.length; charIndex++) {
            for (var wordIndex = 0; wordIndex < this.keywords.length; wordIndex++) {
                if (this.trim(this.keywords[wordIndex]).toLowerCase().indexOf(text.substring(0, charIndex + 1).toLowerCase(), 0) > -1) {
                    newValue = text.substring(0, charIndex + 1);
                    containsNewValue = true;
                    break;
                }
                else
                    containsNewValue = false;
            }
            if (!containsNewValue)
                break;
        }
        if (!containsNewValue) {
            this.field.value = newValue;
            this.show(hidden);
        }
    },

    browserAdjustLeft: function(left) {
        switch (BrowserName()) {
            case "Firefox":
            case "Opera":
            case "Chrome":
            case "Safari":
                left = left + 1;
                break;
        }
        return left;
    },

    browserAdjustTop: function(top) {
        switch (BrowserName()) {
            case "Chrome":
            case "Safari":
                top = top + 1;
                break;
        }
        return top;
    },

    bindArray: function(array) {
        if (!array || !array.length) return;

        this.suggest_url = "";

        this.keywords = [], this.keywords_init = [];
        this.values = [], this.values_init = [];

        for (var i = 0, cl = array.length; i < cl; i++) {
            var item = array[i];

            if (item.constructor == Array) {
                this.keywords[i] = this.keywords_init[i] = item[0];
                this.values[i] = this.values_init[i] = item[1];
            }
            else {
                this.keywords[i] = this.keywords_init[i] = item;
                this.values[i] = this.values_init[i] = "";
            }
        }
    },

    bindURL: function(url) {
        if (!url)
            url = autosuggest_url;

        this.suggest_url = url;
    },

    setupEvents: function() {
        if (!this.evsetup) {
            this.evsetup = true;

            this.addEvent(document, "keydown", this.funcCheck);
            this.addEvent(this.field, "blur", this.funcClear);
            this.addEvent(document, "keypress", this.funcPress);
        }
    },

    clearEvents: function() {
        // Removes an event handler:
        function removeEvent(obj, event_name, func_ref) {
            if (obj.removeEventListener && !window.opera) {
                obj.removeEventListener(event_name, func_ref, true);
            }
            else if (obj.detachEvent) {
                obj.detachEvent("on" + event_name, func_ref);
            }
            else {
                obj["on" + event_name] = null;
            }
        }

        var event = window.event;

        if (event && this.cur_h) {
            var elem = event.srcElement || event.target;

            var x = this.mouse_x + (document.body.scrollLeft || 0);
            var y = this.mouse_y + (document.body.scrollTop || 0);

            if ((elem.id == this.field_id) && (x > this.cur_x && x < (this.cur_x + this.cur_w)) && (y > this.cur_y && y < (this.cur_y + this.cur_h))) {
                this.field.focus();
                return;
            }
        }

        removeEvent(document, "keydown", this.funcCheck);
        removeEvent(this.field, "blur", this.funcClear);
        removeEvent(document, "keypress", this.funcPress);

        this.hide();
        this.evsetup = false;
    },

    parse: function(n, plen, re) {
        if (!n || !n.length) return "";
        if (!plen) return n;

        var tobuild = [], c = 0, p = n.search(re);

        tobuild[c++] = n.substr(0, p);
        if (this.filter_suggestions)
            tobuild[c++] = "<u><font face=\"";
        else
            tobuild[c++] = "<font face=\"";
        tobuild[c++] = this.font;
        tobuild[c++] = "\">";
        tobuild[c++] = n.substring(p, plen + p);
        if (this.filter_suggestions)
            tobuild[c++] = "</font></u>";
        else
            tobuild[c++] = "</font>";

        tobuild[c++] = n.substring(plen + p, n.length);

        return tobuild.join("");
    },

    build: function() {
        if (this.total == 0) {
            this.displayed = false;
            return;
        }

        this.rows = [];
        this.current = this.no_default ? -1 : 0;

        var that = this;

        this.addEvent(document, "mousemove", function(event) {
            event = event || window.event;

            that.mouse_x = event.x;
            that.mouse_y = event.y;
        });

        var body = document.getElementById("suggest_table_" + this.field_id);
        if (body) {
            this.displayed = false;
            document.body.removeChild(body);

            var helper = document.getElementById("suggest_helper_" + this.field_id);
            if (helper)
                document.body.removeChild(helper);
        }

        var bb = document.createElement("div");
        bb.id = "suggest_table_" + this.field_id;
        bb.style.position = "absolute";
        bb.style.border = "#000000 solid 1px";
        bb.style.zIndex = 100;

        this.cur_y = this.curPos(this.field, "Top") + this.field.offsetHeight;
        bb.style.top = this.browserAdjustTop(this.cur_y - 2) + "px"; // Changed by Jason 9/5/2009: Adjusted placement to mimic select drop-down.

        this.cur_x = this.curPos(this.field, "Left");
        bb.style.left = this.browserAdjustLeft(this.cur_x + 2) + "px"; // Changed by Jason 9/5/2009: Adjusted placement to mimic select drop-down.

        this.cur_w = this.field.offsetWidth - (this.msie ? 2 : 6);
        bb.style.width = this.cur_w - 5 + "px"; // Changed by Jason 9/5/2009: Adjusted placement to mimic select drop-down.

        this.cur_h = 1;
        bb.style.height = "1px";

        var cc = null;
        if (this.msie && this.use_iframe) {
            var cc = document.createElement("iframe");
            cc.id = "suggest_helper_" + this.field_id;

            cc.src = "javascript:\"<html></html>\";";
            cc.scrolling = "no";
            cc.frameBorder = "no";

            cc.style.display = "block";
            cc.style.position = "absolute";

            cc.style.zIndex = 99;
            cc.style.filter = "progid:DXImageTransform.Microsoft.Alpha(opacity=0)";
        }

        var that = this;
        var showFull = (this.total > this.entry_limit);

        if (this.use_scroll && showFull) {
            this.cur_h = Math.ceil(this.entry_limit * parseInt(this.font_size));
            bb.style.height = this.cur_h + "px";

            bb.style.overflow = "auto";
            bb.style.overflowX = "hidden";
        }

        if (cc) {
            document.body.appendChild(cc);

            cc.style.top = this.cur_y + "px";
            cc.style.left = this.cur_x + "px";

            cc.style.width = bb.offsetWidth + 2;
        }

        document.body.appendChild(bb);

        var first = true, dispCount = showFull ? this.entry_limit : this.total;
        var str = [], cn = 0;

        str[cn++] = "<table cellspacing=\"1px\" cellpadding=\"2px\" style=\"width:100%;background-color:";
        str[cn++] = this.bg_color;
        str[cn++] = "\" id=\"suggest_table2_";
        str[cn++] = this.field_id;
        str[cn++] = "\">";

        bb.innerHTML = str.join("");
        var table = bb.firstChild;

        if (this.use_mouse) {
            table.onmouseout = this.funcUnfocus;
            table.onmouseover = this.funcFocus;
        }

        var real_height = 0, real_width = 0;

        function createArrowRow(_img) {
            var row = table.insertRow(-1), rs = row.style;
            rs.backgroundColor = that.ar_color;

            var cell = row.insertCell(0), cs = cell.style;
            cs.cursor = "default";
            cs.textAlign = "center";

            var img = cell.appendChild(document.createElement("img"));
            img.src = that.image[_img];

            real_height += row.offsetHeight + 1;
            return cell;
        }

        if (!this.use_scroll && showFull)
            createArrowRow(3);

        var kl = this.keywords.length, counter = 0, j = 0;

        // For "parse" call:
        var t, plen;
        if (this.text_delimiter.length > 0) {
            var word = this.delim_words[this.current_word];

            t = this.trim(this.addSlashes(word));
            plen = this.trim(word).length;
        }
        else {
            var word = this.field.value;

            t = this.addSlashes(word);
            plen = word.length;
        }

        var re = new RegExp((this.limit_start ? "^" : "") + t, "i");

        // Added by Jason 9/6/2009: Declaring variables for selecting field value match.
        var selectedFound = false;
        var offsetIndex = 0;
        // End of additon.
        function addSuggestion(index, _first) {
            var row = that.rows[j] = table.insertRow(-1);
            row.style.backgroundColor = (_first || (that.previous == index)) ? that.hcolor : that.bg_color;

            var cell = row.insertCell(0), cs = cell.style;
            cs.color = (_first || (that.previous == index)) ? that.htext_color : that.text_color;
            cs.fontFamily = that.font;
            cs.fontSize = that.font_size;
            cs.whiteSpace = "nowrap";

            cell.innerHTML = that.parse(that.keywords[index], plen, re);

            // Added by Jason 9/6/2009: Selecting field value match.
            if (that.trim(that.keywords[index]) == that.trim(that.field.value)) {
                selectedFound = true;
                row.style.backgroundColor = that.hcolor;
                cs.color = that.htext_color;
                that.previous = index;
                that.current = index;
                that.selectIndex(index, false);
            }
            if (selectedFound) {
                offsetIndex++;
                if (offsetIndex == that.entry_limit || index == that.keywords.length - 1) {
                    bb.scrollTop = cell.offsetTop;
                    selectedFound = false;
                }
            }
            // End of additon.

            cell.setAttribute("pos", j++);
            cell.autosuggest = that;

            if (that.use_mouse) {
                cs.cursor = this.msie ? "hand" : "pointer";
                that.addEvent(cell, "click", that.funcClick);
                cell.onmouseover = that.funcHighlight;
            }

            if (index != that.keywords.length - 1 && !that.fill_visible)
                bb.style.visibility = "hidden";
            else
                bb.style.visibility = "visible";

            return [row.offsetWidth, row.offsetHeight];
        }
        for (var i = 0; i < kl; i++) {
            if (this.bool[i]) {
                var dim = addSuggestion(i, (first && !this.no_default && !this.rebuild));
                first = false;

                if (counter <= this.entry_limit)
                    real_height += dim[1] + 1;

                if (real_width < dim[0])
                    real_width = dim[0];

                if (++counter == this.entry_limit) {
                    ++i;
                    break;
                }
            }
        }

        var last = i;

        if (!this.use_scroll && showFull) {
            var cell = createArrowRow(0);

            if (this.use_mouse) {
                cell.style.cursor = this.msie ? "hand" : "pointer";
                this.addEvent(cell, "click", this.funcDown);
            }
        }

        this.cur_h = real_height + 1;
        bb.style.height = this.cur_h + "px";

        this.cur_w = ((real_width > bb.offsetWidth) ? real_width : bb.offsetWidth) + (this.msie ? -2 : 2);
        bb.style.width = this.cur_w + "px";

        if (cc) {
            cc.style.height = this.cur_h + "px";
            cc.style.width = this.cur_w + "px";
        }

        this.range_up = 0;
        this.range_down = j - 1;
        this.displayed = true;

        if (this.use_scroll) {
            setTimeout(function() {
                counter = 0;

                for (var i = last; i < kl; i++) {
                    if (!that.displayed) return;

                    if (that.bool[i]) {
                        addSuggestion(i);

                        if (++counter == that.entry_limit) {
                            ++i;
                            break;
                        }
                    }
                }

                last = i;

                if (j < that.total) setTimeout(arguments.callee, 1);
            },
			1);
        }
    },

    remake: function() {
        this.rows = [];

        var a = document.getElementById("suggest_table2_" + this.field_id);
        var k = 0, first = true;

        function adjustArrow(obj, img, cond, handler) {
            var hand = obj.msie ? "hand" : "pointer";

            var r = a.rows[k++];
            r.style.backgroundColor = obj.ar_color;

            var c = r.firstChild;
            c.style.cursor = "default";
            c.style.textAlign = "center";

            c.firstChild.src = obj.image[img];

            if (cond && handler && obj.use_mouse) {
                obj.addEvent(c, "click", handler);
                c.style.cursor = hand;
            }
        }

        if (this.total > this.entry_limit) {
            var b = (this.range_up > 0);
            adjustArrow(this, b ? 2 : 3, b, this.funcUp);
        }

        // For "parse" call:
        var t, plen;
        if (this.text_delimiter.length > 0) {
            var word = this.delim_words[this.current_word];

            t = this.trim(this.addSlashes(word));
            plen = this.trim(word).length;
        }
        else {
            var word = this.field.value;

            t = this.addSlashes(word);
            plen = word.length;
        }

        var re = new RegExp((this.limit_start ? "^" : "") + t, "i");
        var kl = this.keywords.length, j = 0;

        for (var i = 0; i < kl; i++) {
            if (this.bool[i]) {
                if ((j >= this.range_up) && (j <= this.range_down)) {
                    var r = this.rows[j] = a.rows[k++];
                    r.style.backgroundColor = this.bg_color;

                    var c = r.firstChild;
                    c.style.color = this.text_color;
                    c.style.fontFamily = this.font;
                    c.style.fontSize = this.font_size;
                    c.innerHTML = this.parse(this.keywords[i], plen, re);
                    c.setAttribute("pos", j);
                }

                if (++j > this.range_down) break;
            }
        }

        if (kl > this.entry_limit) {
            var b = (j < this.total);
            adjustArrow(this, b ? 0 : 1, b, this.funcDown);
        }

        if (this.msie) {
            var helper = document.getElementById("suggest_helper_" + this.field_id);
            if (helper) helper.style.width = a.parentNode.offsetWidth + 2;
        }
    },

    reposition: function() {
        if (this.displayed) {
            this.cur_y = this.curPos(this.field, "Top") + this.field.offsetHeight;
            this.cur_x = this.curPos(this.field, "Left");

            var control = document.getElementById("suggest_table_" + this.field_id);
            control.style.top = this.cur_y + "px";
            control.style.left = this.cur_x + "px";
        }
    },

    startTimer: function(on_list) {
        if (this.time_out > 0)
            this.timer = setTimeout(function() { this.mouse_on_list = on_list; this.hide(); }, this.time_out);
    },

    stopTimer: function() {
        if (this.timer) {
            clearTimeout(this.timer);
            this.timer = 0;
        }
    },

    getRow: function(index) {
        if (typeof (index) == "undefined") index = this.current;

        return (this.rows[index] || null);
    },

    fixArrows: function(base) {
        if (this.total <= this.entry_limit) return;

        var table = base.firstChild, at_start = (this.current == 0), at_end = (this.current == (this.total - 1));
        var hand = (this.msie ? "hand" : "pointer");

        var cell = table.rows[0].firstChild;
        cell.firstChild.src = this.image[at_start ? 3 : 2];
        cell.style.cursor = at_start ? "default" : hand;

        cell = table.rows[this.entry_limit + 1].firstChild;
        cell.firstChild.src = this.image[at_end ? 1 : 0];
        cell.style.cursor = at_end ? "default" : hand;
    },

    scroll: function(direction, times) {
        if (!this.displayed) return;

        this.field.focus();
        if (this.current == (direction ? 0 : (this.total - 1))) return;

        if (!direction && (this.current < 0)) {
            this.current = -1;
        }
        else {
            var t = this.getRow();

            if (t && t.style) {
                t.style.backgroundColor = this.bg_color;
                t.firstChild.style.color = this.text_color;
            }
        }

        this.current += times * (direction ? -1 : 1);
        if (direction) {
            if (this.current < 0)
                this.current = 0;
        }
        else {
            if (this.current >= this.total)
                this.current = this.total - 1;

            if (this.use_scroll && (this.current >= this.rows.length))
                this.current = this.rows.length - 1;
        }

        var t = this.getRow(), base = document.getElementById("suggest_table_" + this.field_id);

        if (this.use_scroll) {
            if (direction) {
                if (t.offsetTop < base.scrollTop)
                    base.scrollTop = t.offsetTop;
            }
            else {
                if ((t.offsetTop + t.offsetHeight) > (base.scrollTop + base.offsetHeight)) {
                    var ndx = this.current - this.entry_limit + 1;
                    if (ndx > 0)
                        base.scrollTop = this.getRow(ndx).offsetTop;
                }
            }
        }
        else {
            if (direction) {
                if (this.current < this.range_up) {
                    this.range_up -= times;
                    if (this.range_up < 0) this.range_up = 0;

                    this.range_down = this.range_up + this.entry_limit - 1;

                    this.remake();
                }
                else this.fixArrows(base);
            }
            else {
                if (this.current > this.range_down) {
                    this.range_down += times;
                    if (this.range_down > (this.total - 1)) this.range_down = this.total - 1;

                    this.range_up = this.range_down - this.entry_limit + 1;

                    this.remake();
                }
                else this.fixArrows(base);
            }

            t = this.getRow();
        }

        if (t && t.style) {
            t.style.backgroundColor = this.hcolor;
            t.firstChild.style.color = this.htext_color;
        }

        this.stopTimer();
        this.startTimer(1);

        this.field.focus();
    },

    mouseClick: function(event) {
        event = event || window.event;
        var elem = event.srcElement || event.target;

        if (!elem.id) elem = elem.parentNode;

        var obj = elem.autosuggest;

        if (!obj) {
            var tag = elem.tagName.toLowerCase();
            elem = (tag == "tr") ? elem.firstChild : elem.parentNode;

            obj = elem.autosuggest;
        }

        if (!obj || !obj.displayed) return;

        obj.mouse_on_list = 0;
        obj.current = parseInt(elem.getAttribute("pos"), 10);
        obj.choose();
    },

    focusTable: function() {
        this.mouse_on_list = 1;
    },

    unfocusTable: function() {
        this.mouse_on_list = 0;

        this.stopTimer();
        this.startTimer(0)
    },

    highlightTable: function(event) {
        event = event || window.event;
        var elem = event.srcElement || event.target;

        var obj = elem.autosuggest;
        if (!obj) return;

        obj.mouse_on_list = 1;

        var row = obj.getRow();
        if (row && row.style) {
            row.style.backgroundColor = obj.bg_color;
            row.firstChild.style.color = obj.text_color;
        }
        // Added by Jason 9/6/2009: Unhighlighting selected.
        row = obj.getRow(obj.previous);
        if (row && row.style) {
            row.style.backgroundColor = obj.bg_color;
            row.firstChild.style.color = obj.text_color;
        }
        // End of addittion.

        obj.current = parseInt(elem.getAttribute("pos"), 10);

        row = obj.getRow();
        if (row && row.style) {
            row.style.backgroundColor = obj.hcolor;
            row.firstChild.style.color = obj.htext_color;
        }

        obj.stopTimer();
        obj.startTimer(0);
    },

    choose: function() {
        if (!this.displayed) return;
        if (this.current < 0) return;

        this.displayed = false;

        var kl = this.keywords.length;

        for (var i = 0, c = 0; i < kl; i++) {
            if (this.bool[i] && (c++ == this.current)) {
                break;
            }
        }

        this.selectedIndex = i;
        this.insertWord(this.keywords[i]);

        // Added by Jason 9/7/2009: Assigning values to server control's hidden fields.
        this.selectIndex(i, false);
        if (this.field.onchange) this.field.onchange();
        // End of addition.

        if (this.onSelect)
            this.onSelect(i, this);
    },

    insertWord: function(a) {
        a = this.trim(a);   // Added by Jason 9/7/2009: Chrome has issues.
        // Sets the caret position to l in the object
        function setCaretPos(obj, l) {
            obj.focus();

            if (obj.setSelectionRange) {
                obj.setSelectionRange(l, l);
            }
            else if (obj.createTextRange) {
                var m = obj.createTextRange();
                m.moveStart("character", l);
                m.collapse();
                m.select();
            }
        }

        if (this.text_delimiter.length > 0) {
            var str = "", word = this.delim_words[this.current_word], wl = word.length, l = 0;

            for (var i = 0; i < this.delim_words.length; i++) {
                if (this.current_word == i) {
                    var prespace = "", postspace = "", gotbreak = false;

                    for (var j = 0; j < wl; ++j) {
                        if (word.charAt(j) != " ") {
                            gotbreak = true;
                            break;
                        }

                        prespace += " ";
                    }

                    for (j = wl - 1; j >= 0; --j) {
                        if (word.charAt(j) != " ")
                            break;

                        postspace += " ";
                    }

                    str += prespace;
                    str += a;
                    l = str.length;

                    if (gotbreak) str += postspace;
                }
                else {
                    str += this.delim_words[i];
                }

                if (i != this.delim_words.length - 1)
                    str += this.delim_char[i];
            }

            this.field.value = str;
            setCaretPos(this.field, l);
        }
        else {
            this.field.value = a;
        }

        this.mouse_on_list = 0;
        this.hide();
    },

    hide: function() {
        if (this.mouse_on_list == 0) {
            this.displayed = false;

            var base = document.getElementById("suggest_table_" + this.field_id);
            if (base) {
                var helper = document.getElementById("suggest_helper_" + this.field_id);
                if (helper)
                    document.body.removeChild(helper);

                document.body.removeChild(base);
            }

            this.stopTimer();

            this.cur_x = 0;
            this.cur_y = 0;
            this.cur_w = 0;
            this.cur_h = 0;

            this.rows = [];
        }
    },

    keyPress: function(event) {
        // On firefox there is no way to distingish pressing shift-8 (asterix)
        // from pressing 8 during the keyDown event, so we do restrict_typing
        // whilest handling the keyPress event

        event = event || window.event;

        var code = window.event ? event.keyCode : event.charCode;
        var obj = event.srcElement || event.target;

        obj = obj.autosuggest;

        if (obj.restrict_typing && !obj.suggest_url.length && (code >= 32)) {
            var caret_pos = obj.getCaretEnd(obj.field);
            var new_term = obj.field.value.substr(0, caret_pos).toLowerCase();
            var isDelimiter = false;

            if (obj.text_delimiter.length > 0) {
                // check whether the pressed key is a delimiter key
                var delim_split = "";
                for (var j = 0; j < obj.text_delimiter.length; j++) {
                    delim_split += obj.text_delimiter[j];

                    if (obj.text_delimiter[j] == String.fromCharCode(code))
                        isDelimiter = true;
                }

                // only consider part of term after last delimiter
                delim_split = obj.addSlashes(delim_split);

                var lastterm_rx = new RegExp(".*([" + delim_split + "])");
                new_term = new_term.replace(lastterm_rx, '');
            }

            var keyw_len = obj.keywords.length;
            var i = 0;

            if (isDelimiter) {
                // pressed key is a delimiter: allow if current term is complete
                for (i = 0; i < keyw_len; i++)
                    if (obj.keywords[i].toLowerCase() == new_term)
                    break;
            }
            else {
                new_term += String.fromCharCode(code).toLowerCase();
                for (i = 0; i < keyw_len; i++)
                    if (obj.keywords[i].toLowerCase().indexOf(new_term) != -1)
                    break;
            }

            if (i == keyw_len) {
                obj.stopEvent(event);
                return false;
            }
        }

        if (obj.caret_moved) obj.stopEvent(event);
        return !obj.caret_moved;
    },

    checkKey: function(event) {
        event = event || window.event;

        var code = event.keyCode;
        var obj = event.srcElement || event.target;

        obj = obj.autosuggest;
        obj.caret_moved = 0;

        var term = "";

        obj.stopTimer();

        switch (code) {
            // Up arrow:    
            case 38:
                // Changed by Jason 9/8/2009: Navigate without displaying list
                // if read_only and not displayed.
                if (!obj.displayed) {
                    if (obj.read_only) {
                        if (obj.selectedIndex - 1 >= 0)
                            obj.selectIndex(obj.selectedIndex - 1, true);
                    }
                    return false;
                }
                else {
                    if (obj.current <= 0) {
                        obj.stopEvent(event);
                        obj.hide();
                    }
                    else {
                        obj.scroll(true, 1);
                        obj.caret_moved = 1;
                        obj.stopEvent(event);
                    }
                    return false;
                }
                // End of change.

                // Down arrow:
            case 40:
                // Changed by Jason 9/8/2009: Navigate without displaying list
                // if read_only and not displayed.
                if (!obj.displayed) {
                    if (obj.read_only) {
                        if (obj.selectedIndex < obj.keywords.length)
                            obj.selectIndex(obj.selectedIndex + 1, true);
                    }
                    else {
                        obj.timer = setTimeout(function() {
                            obj.preSuggest(-1);
                        },
					    25);
                    }
                }
                else {
                    obj.scroll(false, 1);
                    obj.caret_moved = 1;
                }
                // End of change.
                return false;

                // Page up:
            case 33:
                // Changed by Jason 9/8/2009: Navigate without displaying list
                // if read_only and not displayed.
                if (!obj.displayed) {
                    if (obj.read_only) {
                        var newIndex = obj.selectedIndex - obj.entry_limit;
                        if (newIndex < 0)
                            newIndex = 0;
                        obj.selectIndex(newIndex, true);
                    }
                }
                else {
                    if (obj.current == 0) {
                        obj.caret_moved = 0;
                        return false;
                    }

                    obj.scroll(true, (obj.use_scroll || (obj.getRow() == obj.rows[obj.range_up])) ? obj.entry_limit : (obj.current - obj.range_up));
                    obj.caret_moved = 1;
                }
                // End of change.
                break;

            // Page down:    
            case 34:
                // Changed by Jason 9/8/2009: Navigate without displaying list
                // if read_only and not displayed.
                if (!obj.displayed) {
                    if (obj.read_only) {
                        var newIndex = obj.selectedIndex + obj.entry_limit;
                        if (newIndex >= obj.keywords.length)
                            newIndex = obj.keywords.length - 1;
                        obj.selectIndex(newIndex, true);
                    }
                }
                else {
                    if (obj.current == (obj.total - 1)) {
                        obj.caret_moved = 0;
                        return false;
                    }

                    obj.scroll(false, (obj.use_scroll || (obj.getRow() == obj.rows[obj.range_down])) ? obj.entry_limit : (obj.range_down - obj.current));
                    obj.caret_moved = 1;
                }
                // End of change.
                break;

            // Home    
            case 36:
                // Changed by Jason 9/8/2009: Navigate without displaying list
                // if read_only and not displayed.
                if (!obj.displayed) {
                    if (obj.read_only)
                        obj.selectIndex(0, true);
                }
                else {
                    if (obj.current == 0) {
                        obj.caret_moved = 0;
                        return false;
                    }

                    obj.scroll(true, obj.total);
                    obj.caret_moved = 1;
                }
                // End of change.
                break;

            // End    
            case 35:
                // Changed by Jason 9/8/2009: Navigate without displaying list
                // if read_only and not displayed.
                if (!obj.displayed) {
                    if (obj.read_only)
                        obj.selectIndex(obj.keywords.length - 1, true);
                }
                else {
                    if (obj.current == (obj.total - 1)) {
                        obj.caret_moved = 0;
                        return false;
                    }

                    obj.scroll(false, obj.total);
                    obj.caret_moved = 1;
                }
                // End of change.
                break;

            // Esc:    
            case 27:
                term = obj.field.value;

                obj.mouse_on_list = 0;
                obj.hide();
                break;

            // Enter:    
            case 13:
                if (obj.displayed) {
                    obj.caret_moved = 1;
                    obj.choose();
                    return false;
                }
                break;

            // Tab:    
            case 9:
                if ((obj.displayed && (obj.current >= 0)) || obj.timer) {
                    obj.caret_moved = 1;
                    obj.choose();

                    setTimeout(function() { obj.field.focus(); }, 25);
                    return false;
                }
                break;

            case 16: //shift
                break;

            default:
                // Changed by Jason 9/8/2009: Navigate without displaying list
                // if read_only and not displayed or navigate while displaying
                // list if read_only.
                if (obj.read_only)
                    obj.selectKeyCode(code, true);
                else {
                    obj.caret_moved = 0;
                    obj.timer = setTimeout(function() {
                        obj.preSuggest(code);
                    },
				    (obj.response_time < 10 ? 10 : obj.response_time));
                }
                // End of change.
        }

        if (term.length) setTimeout(function() { obj.field.value = term; }, 25);
        return true;
    },
    // Changed by Jason 9/7/2009: Allow filling the keywords without displaying
    // by sending true for the hidden parameter.
    preSuggest: function(kc, hidden) {
        if (!this.timer)
            return;

        this.stopTimer();

        if (this.displayed && (this.lastterm == this.field.value))
            return;
        this.lastterm = this.field.value;

        if (kc == 38 || kc == 40 || kc == 13) return;

        var c = 0;
        if (this.displayed && (this.current >= 0)) {
            for (var i = 0; i < this.keywords.length; i++) {
                if (this.bool[i]) ++c;

                if (c == this.current) {
                    this.previous = i;
                    break;
                }
            }
        }
        else {
            this.previous = -1;
        }

        if (!this.field.value.length && (kc != -1)) {
            this.mouse_on_list = 0;
            this.hide();
        }

        var ot, t;

        if (this.text_delimiter.length > 0) {
            var caret_pos = this.getCaretEnd(this.field);

            var delim_split = "";
            for (var i = 0; i < this.text_delimiter.length; i++)
                delim_split += this.text_delimiter[i];

            delim_split = this.addSlashes(delim_split);
            var delim_split_rx = new RegExp("([" + delim_split + "])");
            c = 0;
            this.delim_words = [];
            this.delim_words[0] = "";

            for (var i = 0, j = this.field.value.length; i < this.field.value.length; i++, j--) {
                if (this.field.value.substr(i, j).search(delim_split_rx) == 0) {
                    var ma = this.field.value.substr(i, j).match(delim_split_rx);
                    this.delim_char[c++] = ma[1];
                    this.delim_words[c] = "";
                }
                else {
                    this.delim_words[c] += this.field.value.charAt(i);
                }
            }

            var l = 0;
            this.current_word = -1;

            for (i = 0; i < this.delim_words.length; i++) {
                if ((caret_pos >= l) && (caret_pos <= (l + this.delim_words[i].length)))
                    this.current_word = i;

                l += this.delim_words[i].length + 1;
            }

            ot = this.trim(this.delim_words[this.current_word]);
            t = this.trim(this.addSlashes(this.delim_words[this.current_word]));
        }
        else {
            ot = this.field.value;
            t = this.addSlashes(ot);
        }

        if (ot.length == 0 && (kc != -1)) {
            this.mouse_on_list = 0;
            this.hide();
        }
        else if ((ot.length == 1) || this.full_refresh || this.read_only ||
		       ((ot.length > 1) && !this.keywords.length) ||
		       ((ot.length > 1) && (this.keywords[0].charAt(0).toLowerCase() != ot.charAt(0).toLowerCase()))) {
            var ot_ = ((ot.length > 1) && !this.full_refresh) ? ot.charAt(0) : ot;

            if (this.suggest_url.length && (!this.ajaxCalled || this.full_refresh)) // Changed by Jason 9/6/2009: Preventing unnecessary AJAX calls.
            {

                // create xmlhttprequest object:
                var http = null;
                if (typeof (XMLHttpRequest) != "undefined") {
                    try {
                        http = new XMLHttpRequest();
                    }
                    catch (e) { http = null; }
                }
                else {
                    try {
                        http = new ActiveXObject("Msxml2.XMLHTTP");
                    }
                    catch (e) {
                        try {
                            http = new ActiveXObject("Microsoft.XMLHTTP");
                        }
                        catch (e) { http = null; }
                    }
                }

                if (http) {
                    // Uncomment for local debugging in Mozilla/Firefox:
                    // try { netscape.security.PrivilegeManager.enablePrivilege("UniversalBrowserRead"); } catch (e) { }

                    if (http.overrideMimeType)
                        http.overrideMimeType("text/xml");

                    // Changed by Jason 8/25/2009: Changed to send the parameters with the querystring.
                    if (this.parameters.length == 0)
                        http.open("GET", this.suggest_url + ot_, true);
                    else
                        http.open("GET", this.suggest_url + this.getParameterString(), true);
                    // End of change.

                    var that = this;
                    http.onreadystatechange = function(n) {
                        if (http.readyState == 4) {
                            if ((http.status == 200) || (http.status == 0)) {
                                var text = http.responseText;

                                var index1 = text.indexOf("<listdata>");
                                var index2 = (index1 == -1) ? text.length : text.indexOf("</listdata", index1 + 10);

                                index1 += (index1 != -1) ? 10 : 1;

                                var tmpinfo = text.substring(index1, index2);

                                if (tmpinfo) {
                                    that.keywords = tmpinfo.split(that.ajax_delimiter);

                                    if (that.item_delimiter && that.item_delimiter.length) {
                                        var keyword_number = that.keywords.length;
                                        // Added by Jason 9/7/2009: Assigning values to server control's hidden fields.
                                        var matchingAdded = false;
                                        // End of addition.
                                        for (var i = 0; i < keyword_number; i++) {
                                            var ca = that.keywords[i], comma = ca.indexOf(that.item_delimiter);

                                            if (comma != -1) {
                                                var ci = ca.split(that.item_delimiter);

                                                that.keywords[i] = that.keywords_init[i] = ci[0];
                                                that.values[i] = that.values_init[i] = ci[1];
                                            }
                                            else {
                                                that.keywords[i] = that.keywords_init[i] = ca;
                                                that.values[i] = that.values_init[i] = "";
                                            }
                                            // Added by Jason 9/7/2009: Assigning values to server control's hidden fields.
                                            if (that.trim(that.keywords[i]) == that.trim(that.field.value)) {
                                                matchingAdded = true;
                                                that.selectIndex(i, false);
                                            }
                                            // End of addition.
                                        }
                                        // Added by Jason 9/7/2009: Assigning values to server control's hidden fields.
                                        if (!matchingAdded) {
                                            that.selectIndex(-1, false);
                                        }
                                        // End of addition.
                                    }
                                    if (that.restrict_typing) that.ajaxRestrict(hidden);    // Added by Jason 9/5/2009: Typing restriction for AJAX.
                                    if (!hidden) that.suggest(ot_, t); else that.select(); // Changed by Jason 9/7/2009: Do not show if specified.
                                }
                            }
                        }
                    }

                    http.send(null);
                }
                that.ajaxCalled = true;
            }
            else if (!hidden) this.suggest(ot, t); else this.select();  // Changed by Jason 9/7/2009: Do not show if specified.
        }
        else if (!hidden) this.suggest(ot, t); else this.select();  // Changed by Jason 9/7/2009: Do not show if specified.
    },

    suggest: function(ot, t) {
        if (ot.length < this.start_check) return;

        var al = this.keywords.length;
        this.total = 0, this.rebuild = false;

        for (var i = 0; i < al; i++) {
            this.keywords[i] = this.keywords_init[i];
            this.values[i] = this.values_init[i];
            this.bool[i] = true;
        }

        if (!this.field.value.length && !this.filter_suggestions) {
            this.total = al;
        }
        else {
            var re1 = new RegExp(((!this.limit_start && !this.match_first) ? "" : "^") + t, "i");
            var re2 = new RegExp(t, "i");

            var after = (!this.limit_start && this.match_first);

            var matchArray = [], matchVArray = [];
            var afterArray = [], afterVArray = [];
            var otherArray = [], otherVArray = [];

            for (var i = 0; i < al; i++) {
                var key = this.keywords[i];
                var value = this.values[i];

                if (re1.test(key) || !this.filter_suggestions) {
                    ++this.total;

                    matchArray[matchArray.length] = key;
                    matchVArray[matchVArray.length] = value;
                }
                else if (after && re2.test(key)) {
                    ++this.total;

                    afterArray[afterArray.length] = key;
                    afterVArray[afterVArray.length] = value;
                }
                else {
                    otherArray[otherArray.length] = key;
                    otherVArray[otherVArray.length] = value;
                }
            }

            this.keywords = matchArray.concat(afterArray).concat(otherArray);
            this.values = matchVArray.concat(afterVArray).concat(otherVArray);

            for (i = 0; i < al; i++)
                this.bool[i] = (i < this.total);
        }

        if (this.previous != -1)
            this.rebuild = true;

        if (this.total) {
            this.startTimer(0);
            this.build();
        }
        else this.hide();
    },

    // Utility methods:

    // Setup an event handler for the given event and DOM element
    // event_name refers to the event trigger, without the "on", like click or mouseover
    // func_name refers to the function callback that is invoked when event is triggered
    addEvent: function(obj, event_name, func_ref) {
        if (obj.addEventListener && !window.opera) {
            obj.addEventListener(event_name, func_ref, true);
        }
        else if (obj.attachEvent) {
            obj.attachEvent("on" + event_name, func_ref)
        }
        else {
            obj["on" + event_name] = func_ref;
        }
    },

    // Stop an event from bubbling up the event DOM
    stopEvent: function(event) {
        event = event || window.event;

        if (event) {
            if (event.stopPropagation) event.stopPropagation();
            if (event.preventDefault) event.preventDefault();

            if (typeof (event.cancelBubble) != "undefined") {
                event.cancelBubble = true;
                event.returnValue = false;
            }
        }

        return false;
    },

    // Get the end position of the caret in the object. Note that the obj needs to be in focus first.
    getCaretEnd: function(obj) {
        if (typeof (obj.selectionEnd) != "undefined") {
            return obj.selectionEnd;
        }
        else if (document.selection && document.selection.createRange) {
            var M = document.selection.createRange(), Lp;

            try {
                Lp = M.duplicate();
                Lp.moveToElementText(obj);
            }
            catch (e) {
                Lp = obj.createTextRange();
            }

            Lp.setEndPoint("EndToEnd", M);
            var rb = Lp.text.length;

            if (rb > obj.value.length)
                return -1;

            return rb;
        }

        return -1;
    },

    // Get offset position from the top/left of the screen:
    curPos: function(obj, what) {
        var coord = 0;
        while (obj) {
            coord += obj["offset" + what];
            obj = obj.offsetParent;
        }

        return coord;
    },

    // String functions:

    addSlashes: function(str) { return str.replace(/(["\\\.\|\[\]\^\*\+\?\$\(\)])/g, "\\$1"); },

    trim: function(str) { return str.replace(/^\s*(\S*(\s+\S+)*)\s*$/, "$1"); }
};

/// <summary>
/// Returns the name of the browser the page is being viewed in.
/// </summary>
/// <returns>
/// IE, Chrome, Opera, Safari, Firefox or Unknown.
/// </returns>
/// <remarks>
/// Tested this function in IE 7.0, Firefox 2.0, Chrome 1.0, Safari 4.0
/// and Opera 9.64.
/// </remarks>
function BrowserName() {
    if (navigator.appName.indexOf("Microsoft Internet Explorer") > -1)
        return "IE";
    if (navigator.appVersion.indexOf("Chrome") > -1)
        return "Chrome";
    if (navigator.appName == "Opera")
        return "Opera";
    if (navigator.appVersion.indexOf("Safari") > -1)
        return "Safari";
    if (navigator.appVersion.lastIndexOf(";") == navigator.appVersion.lastIndexOf(";"))
        return "Firefox";
    return "Unknown";
}

if (typeof (Sys) != "undefined" && typeof (Sys.Application) != "undefined")
    Sys.Application.notifyScriptLoaded();
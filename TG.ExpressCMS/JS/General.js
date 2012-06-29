function ConfirmDelete() {
    var boolChkBox = false;
    var boolfoo = false;
    var elem;
    for (i = 0; i <= document.forms[0].length; i++) {
        elem = document.forms[0].elements[i];
        if (elem != null)
            if ((elem.type == 'checkbox')) {

                if (elem.checked) {
                    boolChkBox = true;
                    break;
                }
            }
    }
    if (boolChkBox) {
        return confirm('Are you sure to delete this item(s)?');
    }
    else {
        alert('Please select at least one record.');
        return false;
    }

}
function ConfirmPublish() {
    var boolChkBox = false;
    var boolfoo = false;
    var elem;
    for (i = 0; i <= document.forms[0].length; i++) {
        elem = document.forms[0].elements[i];
        if (elem != null)
            if ((elem.type == 'checkbox')) {

                if (elem.checked) {
                    boolChkBox = true;
                    break;
                }
            }
    }
    if (boolChkBox) {
        return confirm('Are you sure to publish this item(s)?');
    }
    else {
        alert('Please select at least one record.');
        return false;
    }

}
function ConfirmDelete2(gvname) {
    var boolChkBox = false;
    var boolfoo = false;
    var elem;
    for (i = 0; i <= document.forms[0].length; i++) {
        elem = document.forms[0].elements[i];
        if (elem != null)
            if ((elem.type == 'checkbox')) {
                if (elem.name.indexOf(gvname) > -1)
                    if (elem.checked) {
                        boolChkBox = true;
                        break;
                    }
            }
    }
    if (boolChkBox) {
        return confirm('Are you sure to delete this item(s)?');
    }
    else {
        alert('Please select at least one record.');
        return false;
    }

}


function SelectAll(CheckBoxControl, RepeaterName) {

    if (CheckBoxControl.checked == true) {
        var i;
        for (i = 0; i < document.forms[0].elements.length; i++) {
            if ((document.forms[0].elements[i].type == 'checkbox') &&
			           (document.forms[0].elements[i].name.indexOf(RepeaterName) > -1)) {
                document.forms[0].elements[i].checked = true;
            }
        }
        CheckBoxControl.checked = true;
    }
    else {
        var i;
        for (i = 0; i < document.forms[0].elements.length; i++) {
            if ((document.forms[0].elements[i].type == 'checkbox') &&
			          (document.forms[0].elements[i].name.indexOf(RepeaterName) > -1)) {
                document.forms[0].elements[i].checked = false;
            }
            CheckBoxControl.checked = false;
        }
    }
}

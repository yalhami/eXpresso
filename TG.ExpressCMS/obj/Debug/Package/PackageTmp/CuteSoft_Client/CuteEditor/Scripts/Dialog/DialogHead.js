var OxO2f23=["ua","userAgent","isOpera","opera","isSafari","safari","isGecko","gecko","isWinIE","msie","isMac","Mac","compatMode","document","CSS1Compat","XMLHttpRequest","","caller","(","\x0A","attachEvent","on","\x0D\x0A","closeeditordialog","close","top","returnValue","_dialog_returnvalue","opener","_dialog_arguments","dialogArguments","length","element \x27","\x27 not found","all","childNodes","nodeType","UNSELECTABLE","tabIndex","-1","//TODO: event not found? throw error ?","preventDefault","event","arguments","parent","frames","srcElement","target","//TODO: srcElement not found? throw error ?","fromElement","relatedTarget","toElement","keyCode","which","clientX","clientY","offsetX","offsetY","button","ctrlKey","altKey","shiftKey","cancelBubble","stopPropagation","buttonInitialized","oncontextmenu","onmouseout","onmousedown","onmouseup","isover","className","CuteEditorButtonOver","CuteEditorButton","CuteEditorButtonDown","CuteEditorDown","border","style","solid 1px #0A246A","backgroundColor","#b6bdd2","padding","1px","solid 1px #f5f5f4","inset 1px","IsCommandDisabled","CuteEditorButtonDisabled","IsCommandActive","CuteEditorButtonActive","onerror","\x0D\x0A\x0D\x0A","href","location","view-source:","?\x26view-source=","_blank","ondblclick","onkeydown","//duplicated?\x0D\x0A","var ","=Window_GetElement(window,\x22","\x22,true);","Text","clipboardData","addEventListener","isdir","path","url","text","return this.getAttribute(\x27","\x27);","prototype","attributes","\x3C","tagName","specified"," ","name","=\x22","value","\x22","\x3E","innerHTML","\x3C/","AREA","BASE","BASEFONT","COL","FRAME","HR","IMG","BR","INPUT","ISINDEX","LINK","META","PARAM","00","0123456789ABCDEF","#","object","undefined","Microsoft.XMLHTTP","head","script","language","javascript","type","text/javascript","src","id","_cpinstalled","1","ResourceDir","/Load.ashx?type=script\x26verfix=1004\x26file=ColorPicker.js","CuteEditorColorPickerInitialize","GET","onreadystatechange","readyState","responseText"," \x0D\x0A window.CuteEditorColorPickerInitialize=CuteEditorColorPickerInitialize","colorScript","oncolorselect","FireUIChanged","onclick","popupColorPicker"];var _Browser_TypeInfo=null;function Browser__InitType(){if(_Browser_TypeInfo!=null){return ;} ;var Ox4={};Ox4[OxO2f23[0]]=navigator[OxO2f23[1]].toLowerCase();Ox4[OxO2f23[2]]=(Ox4[OxO2f23[0]].indexOf(OxO2f23[3])>-1);Ox4[OxO2f23[4]]=(Ox4[OxO2f23[0]].indexOf(OxO2f23[5])>-1);Ox4[OxO2f23[6]]=(!Ox4[OxO2f23[2]]&&Ox4[OxO2f23[0]].indexOf(OxO2f23[7])>-1);Ox4[OxO2f23[8]]=(!Ox4[OxO2f23[2]]&&Ox4[OxO2f23[0]].indexOf(OxO2f23[9])>-1);Ox4[OxO2f23[10]]=navigator[OxO2f23[1]].indexOf(OxO2f23[11])!=-1;_Browser_TypeInfo=Ox4;} ;Browser__InitType();function Browser_IsWinIE(){return _Browser_TypeInfo[OxO2f23[8]];} ;function Browser_IsGecko(){return _Browser_TypeInfo[OxO2f23[6]];} ;function Browser_IsOpera(){return _Browser_TypeInfo[OxO2f23[2]];} ;function Browser_IsSafari(){return _Browser_TypeInfo[OxO2f23[4]];} ;function Browser_UseIESelection(){return _Browser_TypeInfo[OxO2f23[8]];} ;function Browser_IsCSS1Compat(){return window[OxO2f23[13]][OxO2f23[12]]==OxO2f23[14];} ;function Browser_IsIE7(){return _Browser_TypeInfo[OxO2f23[8]]&&window[OxO2f23[15]];} ;function GetStackTrace(){var Ox11f=OxO2f23[16];for(var Ox22e=GetStackTrace[OxO2f23[17]];Ox22e!=null;Ox22e=Ox22e[OxO2f23[17]]){var Ox22f=Ox22e+OxO2f23[16];Ox22f=Ox22f.substr(0,Ox22f.indexOf(OxO2f23[18]));Ox11f+=Ox22f+OxO2f23[19];} ;return Ox11f;} ;function Event_Attach(obj,name,Ox231){if(obj[OxO2f23[20]]){if(name.substr(0,2)!=OxO2f23[21]){name=OxO2f23[21]+name;} ;obj.attachEvent(name,Ox231);} else {if(name.substr(0,2)==OxO2f23[21]){name=name.substring(2);} ;obj.addEventListener(name,Ox231,false);} ;} ;var __ISDEBUG=false;function Debug_Todo(msg){if(!__ISDEBUG){return ;} ;throw ( new Error(msg+OxO2f23[22]+Debug_Todo[OxO2f23[17]]));} ;function Window_CloseDialog(Ox236){(top[OxO2f23[23]]||top[OxO2f23[24]])();} ;function Window_SetDialogReturnValue(Ox1a7,Ox4f){var Ox238=Ox1a7[OxO2f23[25]];Ox238[OxO2f23[26]]=Ox4f;Ox238[OxO2f23[13]][OxO2f23[27]]=Ox4f;var Ox239=Ox238[OxO2f23[28]];if(Ox239==null){return ;} ;try{Ox239[OxO2f23[13]][OxO2f23[27]]=Ox4f;} catch(x){} ;} ;function Window_GetDialogArguments(Ox1a7){var Ox238=Ox1a7[OxO2f23[25]];try{var Ox239=Ox238[OxO2f23[28]];if(Ox239&&Ox239[OxO2f23[13]][OxO2f23[29]]){return Ox239[OxO2f23[13]][OxO2f23[29]];} ;} catch(x){} ;if(Ox238[OxO2f23[13]][OxO2f23[29]]){return Ox238[OxO2f23[13]][OxO2f23[29]];} ;if(Ox238[OxO2f23[30]]){return Ox238[OxO2f23[30]];} ;return Ox238[OxO2f23[13]][OxO2f23[29]];} ;function Window_GetElement(Ox1a7,Ox99,Ox23c){var Ox29=Ox1a7[OxO2f23[13]].getElementById(Ox99);if(Ox29){return Ox29;} ;var Ox31=Ox1a7[OxO2f23[13]].getElementsByName(Ox99);if(Ox31[OxO2f23[31]]>0){return Ox31.item(0);} ;if(Ox23c){if(__ISDEBUG){alert(OxO2f23[32]+Ox99+OxO2f23[33]);} ;throw ( new Error(OxO2f23[32]+Ox99+OxO2f23[33]));} ;return null;} ;function Element_GetAllElements(p){var arr=[];if(Browser_IsWinIE()){for(var i=0;i<p[OxO2f23[34]][OxO2f23[31]];i++){arr.push(p[OxO2f23[34]].item(i));} ;return arr;} ;Ox23e(p);function Ox23e(Ox29){var Ox23f=Ox29[OxO2f23[35]];var Ox11=Ox23f[OxO2f23[31]];for(var i=0;i<Ox11;i++){var Ox27=Ox23f.item(i);if(Ox27[OxO2f23[36]]!=1){continue ;} ;arr.push(Ox27);Ox23e(Ox27);} ;} ;return arr;} ;function Element_SetUnselectable(element){element.setAttribute(OxO2f23[37],OxO2f23[21]);element.setAttribute(OxO2f23[38],OxO2f23[39]);var arr=Element_GetAllElements(element);var len=arr[OxO2f23[31]];if(!len){return ;} ;for(var i=0;i<len;i++){arr[i].setAttribute(OxO2f23[37],OxO2f23[21]);arr[i].setAttribute(OxO2f23[38],OxO2f23[39]);} ;} ;function Event_GetEvent(Ox242){Ox242=Event_FindEvent(Ox242);if(Ox242==null){Debug_Todo(OxO2f23[40]);} ;return Ox242;} ;function Array_IndexOf(arr,Ox244){for(var i=0;i<arr[OxO2f23[31]];i++){if(arr[i]==Ox244){return i;} ;} ;return -1;} ;function Array_Contains(arr,Ox244){return Array_IndexOf(arr,Ox244)!=-1;} ;function clearArray(Ox247){for(var i=0;i<Ox247[OxO2f23[31]];i++){Ox247[i]=null;} ;} ;function Event_FindEvent(Ox242){if(Ox242&&Ox242[OxO2f23[41]]){return Ox242;} ;if(Browser_IsGecko()){return Event_FindEvent_FindEventFromCallers();} else {if(window[OxO2f23[42]]){return window[OxO2f23[42]];} ;return Event_FindEvent_FindEventFromWindows();} ;return null;} ;function Event_FindEvent_FindEventFromCallers(){var Ox18e=Event_GetEvent[OxO2f23[17]];for(var i=0;i<100;i++){if(!Ox18e){break ;} ;var Ox242=Ox18e[OxO2f23[43]][0];if(Ox242&&Ox242[OxO2f23[41]]){return Ox242;} ;Ox18e=Ox18e[OxO2f23[17]];} ;} ;function Event_FindEvent_FindEventFromWindows(){var arr=[];return Ox24b(window);function Ox24b(Ox1a7){if(Ox1a7==null){return null;} ;if(Ox1a7[OxO2f23[42]]){return Ox1a7[OxO2f23[42]];} ;if(Array_Contains(arr,Ox1a7)){return null;} ;arr.push(Ox1a7);var Ox24c=[];if(Ox1a7[OxO2f23[44]]!=Ox1a7){Ox24c.push(Ox1a7.parent);} ;if(Ox1a7[OxO2f23[25]]!=Ox1a7[OxO2f23[44]]){Ox24c.push(Ox1a7.top);} ;if(Ox1a7[OxO2f23[28]]){Ox24c.push(Ox1a7.opener);} ;for(var i=0;i<Ox1a7[OxO2f23[45]][OxO2f23[31]];i++){Ox24c.push(Ox1a7[OxO2f23[45]][i]);} ;for(var i=0;i<Ox24c[OxO2f23[31]];i++){try{var Ox242=Ox24b(Ox24c[i]);if(Ox242){return Ox242;} ;} catch(x){} ;} ;return null;} ;} ;function Event_GetSrcElement(Ox242){Ox242=Event_GetEvent(Ox242);if(Ox242[OxO2f23[46]]){return Ox242[OxO2f23[46]];} ;if(Ox242[OxO2f23[47]]){return Ox242[OxO2f23[47]];} ;Debug_Todo(OxO2f23[48]);return null;} ;function Event_GetFromElement(Ox242){Ox242=Event_GetEvent(Ox242);if(Ox242[OxO2f23[49]]){return Ox242[OxO2f23[49]];} ;if(Ox242[OxO2f23[50]]){return Ox242[OxO2f23[50]];} ;return null;} ;function Event_GetToElement(Ox242){Ox242=Event_GetEvent(Ox242);if(Ox242[OxO2f23[51]]){return Ox242[OxO2f23[51]];} ;if(Ox242[OxO2f23[50]]){return Ox242[OxO2f23[50]];} ;return null;} ;function Event_GetKeyCode(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO2f23[52]]||Ox242[OxO2f23[53]];} ;function Event_GetClientX(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO2f23[54]];} ;function Event_GetClientY(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO2f23[55]];} ;function Event_GetOffsetX(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO2f23[56]];} ;function Event_GetOffsetY(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO2f23[57]];} ;function Event_IsLeftButton(Ox242){Ox242=Event_GetEvent(Ox242);if(Browser_IsWinIE()){return Ox242[OxO2f23[58]]==1;} ;if(Browser_IsGecko()){return Ox242[OxO2f23[58]]==0;} ;return Ox242[OxO2f23[58]]==0;} ;function Event_IsCtrlKey(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO2f23[59]];} ;function Event_IsAltKey(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO2f23[60]];} ;function Event_IsShiftKey(Ox242){Ox242=Event_GetEvent(Ox242);return Ox242[OxO2f23[61]];} ;function Event_PreventDefault(Ox242){Ox242=Event_GetEvent(Ox242);Ox242[OxO2f23[26]]=false;if(Ox242[OxO2f23[41]]){Ox242.preventDefault();} ;} ;function Event_CancelBubble(Ox242){Ox242=Event_GetEvent(Ox242);Ox242[OxO2f23[62]]=true;if(Ox242[OxO2f23[63]]){Ox242.stopPropagation();} ;return false;} ;function Event_CancelEvent(Ox242){Ox242=Event_GetEvent(Ox242);Event_PreventDefault(Ox242);return Event_CancelBubble(Ox242);} ;function CuteEditor_ButtonOver(element){if(!element[OxO2f23[64]]){element[OxO2f23[65]]=Event_CancelEvent;element[OxO2f23[66]]=CuteEditor_ButtonOut;element[OxO2f23[67]]=CuteEditor_ButtonDown;element[OxO2f23[68]]=CuteEditor_ButtonUp;Element_SetUnselectable(element);element[OxO2f23[64]]=true;} ;element[OxO2f23[69]]=true;element[OxO2f23[70]]=OxO2f23[71];} ;function CuteEditor_ButtonOut(){var element=this;element[OxO2f23[70]]=OxO2f23[72];element[OxO2f23[69]]=false;} ;function CuteEditor_ButtonDown(){if(!Event_IsLeftButton()){return ;} ;var element=this;element[OxO2f23[70]]=OxO2f23[73];} ;function CuteEditor_ButtonUp(){if(!Event_IsLeftButton()){return ;} ;var element=this;if(element[OxO2f23[69]]){element[OxO2f23[70]]=OxO2f23[71];} else {element[OxO2f23[70]]=OxO2f23[74];} ;} ;function CuteEditor_ColorPicker_ButtonOver(element){if(!element[OxO2f23[64]]){element[OxO2f23[65]]=Event_CancelEvent;element[OxO2f23[66]]=CuteEditor_ColorPicker_ButtonOut;element[OxO2f23[67]]=CuteEditor_ColorPicker_ButtonDown;Element_SetUnselectable(element);element[OxO2f23[64]]=true;} ;element[OxO2f23[69]]=true;element[OxO2f23[76]][OxO2f23[75]]=OxO2f23[77];element[OxO2f23[76]][OxO2f23[78]]=OxO2f23[79];element[OxO2f23[76]][OxO2f23[80]]=OxO2f23[81];} ;function CuteEditor_ColorPicker_ButtonOut(){var element=this;element[OxO2f23[69]]=false;element[OxO2f23[76]][OxO2f23[75]]=OxO2f23[82];element[OxO2f23[76]][OxO2f23[78]]=OxO2f23[16];element[OxO2f23[76]][OxO2f23[80]]=OxO2f23[81];} ;function CuteEditor_ColorPicker_ButtonDown(){var element=this;element[OxO2f23[76]][OxO2f23[75]]=OxO2f23[83];element[OxO2f23[76]][OxO2f23[78]]=OxO2f23[16];element[OxO2f23[76]][OxO2f23[80]]=OxO2f23[81];} ;function CuteEditor_ButtonCommandOver(element){element[OxO2f23[69]]=true;if(element[OxO2f23[84]]){element[OxO2f23[70]]=OxO2f23[85];} else {element[OxO2f23[70]]=OxO2f23[71];} ;} ;function CuteEditor_ButtonCommandOut(element){element[OxO2f23[69]]=false;if(element[OxO2f23[86]]){element[OxO2f23[70]]=OxO2f23[87];} else {if(element[OxO2f23[84]]){element[OxO2f23[70]]=OxO2f23[85];} else {element[OxO2f23[70]]=OxO2f23[72];} ;} ;} ;function CuteEditor_ButtonCommandDown(element){if(!Event_IsLeftButton()){return ;} ;element[OxO2f23[70]]=OxO2f23[73];} ;function CuteEditor_ButtonCommandUp(element){if(!Event_IsLeftButton()){return ;} ;if(element[OxO2f23[84]]){element[OxO2f23[70]]=OxO2f23[85];return ;} ;if(element[OxO2f23[69]]){element[OxO2f23[70]]=OxO2f23[71];} else {if(element[OxO2f23[86]]){element[OxO2f23[70]]=OxO2f23[87];} else {element[OxO2f23[70]]=OxO2f23[72];} ;} ;} [CuteEditor_ButtonOver,CuteEditor_ColorPicker_ButtonOver];[Window_GetDialogArguments,Window_SetDialogReturnValue,Window_CloseDialog,Window_GetElement];function CancelEventIfNotDigit(){var Ox268=Event_GetKeyCode();if(Browser_IsWinIE()){if((Ox268>=48)&&(Ox268<=57)){return true;} ;} else {if((Ox268<48||Ox268>57)&&Ox268!=8&&(Ox268<35||Ox268>37)&&Ox268!=39&&Ox268!=46){} else {return true;} ;} ;return Event_CancelEvent();} ;window[OxO2f23[88]]=function window_onerror(Oxed,b,Ox23f){if(!__ISDEBUG){return false;} ;alert(Oxed+OxO2f23[22]+b+OxO2f23[22]+Ox23f+OxO2f23[89]+GetStackTrace());return true;} ;function DialogHandleDblClick(){if(Event_IsCtrlKey()){window[OxO2f23[91]][OxO2f23[90]]=OxO2f23[92]+window[OxO2f23[91]][OxO2f23[90]]+OxO2f23[93]+ new Date().getTime();} ;if(Event_IsShiftKey()){window.open(window[OxO2f23[91]].href,OxO2f23[94]);} ;} ;function DialogHandleKeyDown(){var Ox26c=Event_GetKeyCode();if(Ox26c==116){window[OxO2f23[91]].reload();} ;if(Ox26c==27){Window_SetDialogReturnValue(window,false);Window_CloseDialog(window);} ;} ;Event_Attach(document,OxO2f23[95],DialogHandleDblClick);Event_Attach(document,OxO2f23[96],DialogHandleKeyDown);function Debug_ReportElements(Ox26e){var Ox26f={};var Ox270=[];function Ox271(Ox99){if(!Ox99){return ;} ;if(Ox26f[Ox99]){Ox270.push(OxO2f23[97]);} ;Ox26f[Ox99]=true;Ox270.push(OxO2f23[98]);Ox270.push(Ox99);Ox270.push(OxO2f23[99]);Ox270.push(Ox99);Ox270.push(OxO2f23[100]);Ox270.push(OxO2f23[22]);} ;var arr=Element_GetAllElements(Ox26e);for(var i=0;i<arr[OxO2f23[31]];i++){var Ox43=arr[i];Ox271(Ox43.id);} ;var Ox200=Ox270.join(OxO2f23[16]);window[OxO2f23[102]].setData(OxO2f23[101],Ox200);} ;if(document[OxO2f23[103]]){var rowprops=[OxO2f23[104],OxO2f23[105],OxO2f23[106],OxO2f23[107]];for(var rowpropi=0;rowpropi<rowprops[OxO2f23[31]];rowpropi++){try{HTMLElement[OxO2f23[110]].__defineGetter__(rowprops[rowpropi], new Function(OxO2f23[108]+rowprops[rowpropi]+OxO2f23[109]));} catch(x){} ;} ;} ;function outerHTML(element){var attr;var Ox276=element[OxO2f23[111]];var Ox24=OxO2f23[112]+element[OxO2f23[113]];for(var i=0;i<Ox276[OxO2f23[31]];i++){attr=Ox276[i];if(attr[OxO2f23[114]]){Ox24+=OxO2f23[115]+attr[OxO2f23[116]]+OxO2f23[117]+attr[OxO2f23[118]]+OxO2f23[119];} ;} ;if(!canHaveChildren(element)){return Ox24+OxO2f23[120];} ;return Ox24+OxO2f23[120]+element[OxO2f23[121]]+OxO2f23[122]+element[OxO2f23[113]]+OxO2f23[120];} ;function canHaveChildren(element){switch(element[OxO2f23[113]]){case OxO2f23[123]:;case OxO2f23[124]:;case OxO2f23[125]:;case OxO2f23[126]:;case OxO2f23[127]:;case OxO2f23[128]:;case OxO2f23[129]:;case OxO2f23[130]:;case OxO2f23[131]:;case OxO2f23[132]:;case OxO2f23[133]:;case OxO2f23[134]:;case OxO2f23[135]:return false;;} ;return true;} ;function RGBtoHex(Ox279,Ox27a,Ox27b){return toHex(Ox279)+toHex(Ox27a)+toHex(Ox27b);} ;function toHex(Ox27d){if(Ox27d==null){return OxO2f23[136];} ;Ox27d=parseInt(Ox27d);if(Ox27d==0||isNaN(Ox27d)){return OxO2f23[136];} ;Ox27d=Math.max(0,Ox27d);Ox27d=Math.min(Ox27d,255);Ox27d=Math.round(Ox27d);return OxO2f23[137].charAt((Ox27d-Ox27d%16)/16)+OxO2f23[137].charAt(Ox27d%16);} ;var dec_pattern=/rgb\((\d{1,3})[,]\s*(\d{1,3})[,]\s*(\d{1,3})\)/gi;function revertColor(Ox280){if(Ox280.match(dec_pattern)){var Ox281=Ox280.replace(dec_pattern,function (Ox24,p1,Ox71,Ox282){return (OxO2f23[138]+RGBtoHex(p1,Ox71,Ox282)).toLowerCase();} );return Ox281;} ;return Ox280;} ;function isNull(Oxed){return  typeof Oxed==OxO2f23[139]&&!Oxed;} ;function CreateXMLHttpRequest(){try{if( typeof (XMLHttpRequest)!=OxO2f23[140]){return  new XMLHttpRequest();} ;if( typeof (ActiveXObject)!=OxO2f23[140]){return  new ActiveXObject(OxO2f23[141]);} ;} catch(x){return null;} ;} ;function include(Oxc8,Ox286){var Ox287=document.getElementsByTagName(OxO2f23[142]).item(0);var Ox288=document.getElementById(Oxc8);if(Ox288){Ox287.removeChild(Ox288);} ;var Ox289=document.createElement(OxO2f23[143]);Ox289.setAttribute(OxO2f23[144],OxO2f23[145]);Ox289.setAttribute(OxO2f23[146],OxO2f23[147]);Ox289.setAttribute(OxO2f23[148],Ox286);Ox289.setAttribute(OxO2f23[149],Oxc8);Ox287.appendChild(Ox289);} ;function SelectColor(Ox28b,Ox28c){if(Ox28b.getAttribute(OxO2f23[150])==OxO2f23[151]){return ;} ;var Ox28d=editor.GetScriptProperty(OxO2f23[152])+OxO2f23[153];if(!window[OxO2f23[154]]){var Ox28e=CreateXMLHttpRequest();if(Ox28e){Ox28e.open(OxO2f23[155],Ox28d,true,null,null);Ox28e[OxO2f23[156]]=function (){if(Ox28e[OxO2f23[157]]<4){return ;} ;var Ox268=Ox28e[OxO2f23[158]];Ox28e=null;eval(Ox268+OxO2f23[159]);Ox28f();} ;Ox28e.send(OxO2f23[16]);} else {include(OxO2f23[160],Ox28d);setTimeout(Ox28f,100);} ;} else {Ox28f();} ;function Ox28f(){Ox28b.setAttribute(OxO2f23[150],OxO2f23[151]);Ox28b[OxO2f23[118]]=OxO2f23[16];window.CuteEditorColorPickerInitialize(Ox28b,window.editor);Ox28b[OxO2f23[161]]=function (Oxdb){if(Oxdb!=null&&Oxdb!==false){Ox28b[OxO2f23[118]]=Oxdb.toUpperCase();Ox28b[OxO2f23[76]][OxO2f23[78]]=Oxdb;if(Ox28c){Ox28c[OxO2f23[76]][OxO2f23[78]]=Oxdb;} ;if(window[OxO2f23[162]]){window.FireUIChanged();} ;} ;} ;Ox28b[OxO2f23[163]]=Ox28b[OxO2f23[164]];if(Ox28c){Ox28c[OxO2f23[163]]=function (){setTimeout(Ox28b.popupColorPicker,100);} ;} ;setTimeout(Ox28b.popupColorPicker,100);} ;} ;function row_click(src){} ;function do_Close(){Window_SetDialogReturnValue(window,null);Window_CloseDialog(window);} ;var isDemoMode=false;
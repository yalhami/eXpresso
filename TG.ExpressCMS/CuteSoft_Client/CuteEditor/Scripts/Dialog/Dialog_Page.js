var OxO4044=["inp_title","inp_doctype","inp_description","inp_keywords","PageLanguage","HTMLEncoding","bgcolor","bgcolor_Preview","fontcolor","fontcolor_Preview","Backgroundimage","btnbrowse","TopMargin","BottomMargin","LeftMargin","RightMargin","MarginWidth","MarginHeight","btnok","btncc","editor","window","document","body","head","title","value","innerHTML","DOCTYPE","meta","length","name","keywords","content","description","httpEquiv","content-type","content-language","background","color","style","backgroundColor","bgColor","topMargin","bottomMargin","leftMargin","rightMargin","marginWidth","marginHeight","","[[ValidNumber]]","Please enter a valid color number.","text","childNodes","parentNode","http-equiv","Content-Type","Content-Language","META","onclick"];var inp_title=Window_GetElement(window,OxO4044[0],true);var inp_doctype=Window_GetElement(window,OxO4044[1],true);var inp_description=Window_GetElement(window,OxO4044[2],true);var inp_keywords=Window_GetElement(window,OxO4044[3],true);var PageLanguage=Window_GetElement(window,OxO4044[4],true);var HTMLEncoding=Window_GetElement(window,OxO4044[5],true);var bgcolor=Window_GetElement(window,OxO4044[6],true);var bgcolor_Preview=Window_GetElement(window,OxO4044[7],true);var fontcolor=Window_GetElement(window,OxO4044[8],true);var fontcolor_Preview=Window_GetElement(window,OxO4044[9],true);var Backgroundimage=Window_GetElement(window,OxO4044[10],true);var btnbrowse=Window_GetElement(window,OxO4044[11],true);var TopMargin=Window_GetElement(window,OxO4044[12],true);var BottomMargin=Window_GetElement(window,OxO4044[13],true);var LeftMargin=Window_GetElement(window,OxO4044[14],true);var RightMargin=Window_GetElement(window,OxO4044[15],true);var MarginWidth=Window_GetElement(window,OxO4044[16],true);var MarginHeight=Window_GetElement(window,OxO4044[17],true);var btnok=Window_GetElement(window,OxO4044[18],true);var btncc=Window_GetElement(window,OxO4044[19],true);var obj=Window_GetDialogArguments(window);var editor=obj[OxO4044[20]];var editwin=obj[OxO4044[21]];var editdoc=obj[OxO4044[22]];var body=editdoc[OxO4044[23]];var head=obj[OxO4044[24]];var title=head.getElementsByTagName(OxO4044[25])[0];if(title){inp_title[OxO4044[26]]=title[OxO4044[27]];} ;inp_doctype[OxO4044[26]]=obj[OxO4044[28]];var metas=head.getElementsByTagName(OxO4044[29]);for(var m=0;m<metas[OxO4044[30]];m++){if(metas[m][OxO4044[31]].toLowerCase()==OxO4044[32]){inp_keywords[OxO4044[26]]=metas[m][OxO4044[33]];} ;if(metas[m][OxO4044[31]].toLowerCase()==OxO4044[34]){inp_description[OxO4044[26]]=metas[m][OxO4044[33]];} ;if(metas[m][OxO4044[35]].toLowerCase()==OxO4044[36]){HTMLEncoding[OxO4044[26]]=metas[m][OxO4044[33]];} ;if(metas[m][OxO4044[35]].toLowerCase()==OxO4044[37]){PageLanguage[OxO4044[26]]=metas[m][OxO4044[33]];} ;} ;if(editdoc[OxO4044[23]][OxO4044[38]]){Backgroundimage[OxO4044[26]]=editdoc[OxO4044[23]][OxO4044[38]];} ;if(editdoc[OxO4044[23]][OxO4044[40]][OxO4044[39]]){fontcolor[OxO4044[26]]=editdoc[OxO4044[23]][OxO4044[40]][OxO4044[39]];fontcolor[OxO4044[40]][OxO4044[41]]=fontcolor[OxO4044[26]];fontcolor_Preview[OxO4044[40]][OxO4044[41]]=fontcolor[OxO4044[26]];} ;var body_bgcolor=editdoc[OxO4044[23]][OxO4044[40]][OxO4044[41]]||editdoc[OxO4044[23]][OxO4044[42]];if(body_bgcolor){bgcolor[OxO4044[26]]=body_bgcolor;bgcolor[OxO4044[40]][OxO4044[41]]=body_bgcolor;bgcolor_Preview[OxO4044[40]][OxO4044[41]]=body_bgcolor;} ;if(Browser_IsWinIE()){if(body[OxO4044[43]]){TopMargin[OxO4044[26]]=body[OxO4044[43]];} ;if(body[OxO4044[44]]){BottomMargin[OxO4044[26]]=body[OxO4044[44]];} ;if(body[OxO4044[45]]){LeftMargin[OxO4044[26]]=body[OxO4044[45]];} ;if(body[OxO4044[46]]){RightMargin[OxO4044[26]]=body[OxO4044[46]];} ;if(body[OxO4044[47]]){MarginWidth[OxO4044[26]]=body[OxO4044[47]];} ;if(body[OxO4044[48]]){MarginHeight[OxO4044[26]]=body[OxO4044[48]];} ;} else {if(body.getAttribute(OxO4044[43])){TopMargin[OxO4044[26]]=body.getAttribute(OxO4044[43]);} ;if(body.getAttribute(OxO4044[44])){BottomMargin[OxO4044[26]]=body.getAttribute(OxO4044[44]);} ;if(body.getAttribute(OxO4044[45])){LeftMargin[OxO4044[26]]=body.getAttribute(OxO4044[45]);} ;if(body.getAttribute(OxO4044[46])){RightMargin[OxO4044[26]]=body.getAttribute(OxO4044[46]);} ;if(body.getAttribute(OxO4044[16])){MarginWidth[OxO4044[26]]=body.getAttribute(OxO4044[47]);} ;if(body.getAttribute(OxO4044[48])){MarginHeight[OxO4044[26]]=body.getAttribute(OxO4044[48]);} ;} ;function do_insert(){try{if(Browser_IsWinIE()){body[OxO4044[43]]=TopMargin[OxO4044[26]];body[OxO4044[44]]=BottomMargin[OxO4044[26]];body[OxO4044[45]]=LeftMargin[OxO4044[26]];body[OxO4044[46]]=RightMargin[OxO4044[26]];if(MarginWidth[OxO4044[26]]){body[OxO4044[47]]=MarginWidth[OxO4044[26]];} ;if(MarginHeight[OxO4044[26]]){body[OxO4044[48]]=MarginHeight[OxO4044[26]];} ;} else {body.setAttribute(OxO4044[43],TopMargin.value);body.setAttribute(OxO4044[44],BottomMargin.value);body.setAttribute(OxO4044[45],LeftMargin.value);body.setAttribute(OxO4044[46],RightMargin.value);body.setAttribute(OxO4044[47],MarginWidth.value);body.setAttribute(OxO4044[48],MarginHeight.value);if(body.getAttribute(OxO4044[43])==OxO4044[49]){body.removeAttribute(OxO4044[43]);} ;if(body.getAttribute(OxO4044[44])==OxO4044[49]){body.removeAttribute(OxO4044[44]);} ;if(body.getAttribute(OxO4044[45])==OxO4044[49]){body.removeAttribute(OxO4044[45]);} ;if(body.getAttribute(OxO4044[46])==OxO4044[49]){body.removeAttribute(OxO4044[46]);} ;if(body.getAttribute(OxO4044[47])==OxO4044[49]){body.removeAttribute(OxO4044[47]);} ;if(body.getAttribute(OxO4044[48])==OxO4044[49]){body.removeAttribute(OxO4044[48]);} ;} ;} catch(er){alert(OxO4044[50]);return ;} ;try{editdoc[OxO4044[23]][OxO4044[40]][OxO4044[41]]=bgcolor[OxO4044[26]];editdoc[OxO4044[23]][OxO4044[40]][OxO4044[39]]=fontcolor[OxO4044[26]];if(Backgroundimage[OxO4044[26]]){editdoc[OxO4044[23]][OxO4044[38]]=Backgroundimage[OxO4044[26]];} else {body.removeAttribute(OxO4044[38]);} ;} catch(er){alert(OxO4044[51]);return ;} ;if(!title){title=document.createElement(OxO4044[25]);head.appendChild(title);} ;if(Browser_IsWinIE()){title[OxO4044[52]]=inp_title[OxO4044[26]];} else {var Ox45f=document.createTextNode(inp_title.value);try{title.removeChild(title[OxO4044[53]].item(0));} catch(x){} ;title.appendChild(Ox45f);} ;for(var m=0;m<metas[OxO4044[30]];m++){var Oxb6=metas[m];if(Oxb6){if(Oxb6[OxO4044[31]].toLowerCase()==OxO4044[32]||Oxb6[OxO4044[31]].toLowerCase()==OxO4044[34]||Oxb6[OxO4044[31]].toLowerCase()==OxO4044[36]||Oxb6[OxO4044[31]].toLowerCase()==OxO4044[37]){Oxb6[OxO4044[54]].removeChild(Oxb6);Oxb6=null;} ;} ;} ;try{Ox460(OxO4044[31],OxO4044[32],inp_keywords.value);Ox460(OxO4044[31],OxO4044[34],inp_description.value);Ox460(OxO4044[55],OxO4044[56],HTMLEncoding.value);Ox460(OxO4044[55],OxO4044[57],PageLanguage.value);} catch(x){} ;function Ox460(Ox461,name,Oxcd){var metas=head.getElementsByTagName(OxO4044[29]);for(var m=0;m<metas[OxO4044[30]];m++){if(metas[m][OxO4044[31]].toLowerCase()==name.toLowerCase()){metas[m][OxO4044[54]].removeChild(metas[m]);} ;} ;if(Oxcd!=OxO4044[49]&&Oxcd!=null){var Ox462=editdoc.createElement(OxO4044[58]);Ox462.setAttribute(Ox461,name);Ox462.setAttribute(OxO4044[33],Oxcd);head.appendChild(Ox462);} ;} ;Window_SetDialogReturnValue(window,inp_doctype[OxO4044[26]]+OxO4044[49]);Window_CloseDialog(window);} ;btnbrowse[OxO4044[59]]=function btnbrowse_onclick(){function Ox35b(Ox13d){if(Ox13d){Backgroundimage[OxO4044[26]]=Ox13d;} ;} ;editor.SetNextDialogWindow(window);if(Browser_IsSafari()){editor.ShowSelectImageDialog(Ox35b,Backgroundimage.value,Backgroundimage);} else {editor.ShowSelectImageDialog(Ox35b,Backgroundimage.value);} ;} ;function do_Close(){Window_CloseDialog(window);} ;fontcolor[OxO4044[59]]=fontcolor_Preview[OxO4044[59]]=function fontcolor_onclick(){SelectColor(fontcolor,fontcolor_Preview);} ;bgcolor[OxO4044[59]]=bgcolor_Preview[OxO4044[59]]=function bgcolor_onclick(){SelectColor(bgcolor,bgcolor_Preview);} ;
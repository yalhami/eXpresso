var OxOc30b=["inp_width","inp_height","sel_align","sel_valign","inp_bgColor","inp_borderColor","inp_borderColorLight","inp_borderColorDark","inp_class","inp_id","inp_tooltip","sel_noWrap","sel_CellScope","value","bgColor","backgroundColor","style","id","borderColor","borderColorLight","borderColorDark","className","width","height","align","vAlign","title","noWrap","scope","[[ValidNumber]]","[[ValidID]]","","class","valign","onclick"];var inp_width=Window_GetElement(window,OxOc30b[0],true);var inp_height=Window_GetElement(window,OxOc30b[1],true);var sel_align=Window_GetElement(window,OxOc30b[2],true);var sel_valign=Window_GetElement(window,OxOc30b[3],true);var inp_bgColor=Window_GetElement(window,OxOc30b[4],true);var inp_borderColor=Window_GetElement(window,OxOc30b[5],true);var inp_borderColorLight=Window_GetElement(window,OxOc30b[6],true);var inp_borderColorDark=Window_GetElement(window,OxOc30b[7],true);var inp_class=Window_GetElement(window,OxOc30b[8],true);var inp_id=Window_GetElement(window,OxOc30b[9],true);var inp_tooltip=Window_GetElement(window,OxOc30b[10],true);var sel_noWrap=Window_GetElement(window,OxOc30b[11],true);var sel_CellScope=Window_GetElement(window,OxOc30b[12],true);SyncToView=function SyncToView_Td(){inp_bgColor[OxOc30b[13]]=element.getAttribute(OxOc30b[14])||element[OxOc30b[16]][OxOc30b[15]];inp_id[OxOc30b[13]]=element.getAttribute(OxOc30b[17]);inp_bgColor[OxOc30b[16]][OxOc30b[15]]=inp_bgColor[OxOc30b[13]];inp_borderColor[OxOc30b[13]]=element.getAttribute(OxOc30b[18]);inp_borderColor[OxOc30b[16]][OxOc30b[15]]=inp_borderColor[OxOc30b[13]];inp_borderColorLight[OxOc30b[13]]=element.getAttribute(OxOc30b[19]);inp_borderColorLight[OxOc30b[16]][OxOc30b[15]]=inp_borderColorLight[OxOc30b[13]];inp_borderColorDark[OxOc30b[13]]=element.getAttribute(OxOc30b[20]);inp_borderColorDark[OxOc30b[16]][OxOc30b[15]]=inp_borderColorDark[OxOc30b[13]];inp_class[OxOc30b[13]]=element[OxOc30b[21]];inp_width[OxOc30b[13]]=element.getAttribute(OxOc30b[22])||element[OxOc30b[16]][OxOc30b[22]];inp_height[OxOc30b[13]]=element.getAttribute(OxOc30b[23])||element[OxOc30b[16]][OxOc30b[23]];sel_align[OxOc30b[13]]=element.getAttribute(OxOc30b[24]);sel_valign[OxOc30b[13]]=element.getAttribute(OxOc30b[25]);inp_tooltip[OxOc30b[13]]=element.getAttribute(OxOc30b[26]);sel_noWrap[OxOc30b[13]]=element.getAttribute(OxOc30b[27]);sel_CellScope[OxOc30b[13]]=element.getAttribute(OxOc30b[28]);} ;SyncTo=function SyncTo_Td(element){if(inp_bgColor[OxOc30b[13]]){if(element[OxOc30b[16]][OxOc30b[15]]){element[OxOc30b[16]][OxOc30b[15]]=inp_bgColor[OxOc30b[13]];} else {element[OxOc30b[14]]=inp_bgColor[OxOc30b[13]];} ;} else {element.removeAttribute(OxOc30b[14]);} ;element[OxOc30b[18]]=inp_borderColor[OxOc30b[13]];element[OxOc30b[19]]=inp_borderColorLight[OxOc30b[13]];element[OxOc30b[20]]=inp_borderColorDark[OxOc30b[13]];element[OxOc30b[21]]=inp_class[OxOc30b[13]];if(element[OxOc30b[16]][OxOc30b[22]]||element[OxOc30b[16]][OxOc30b[23]]){try{element[OxOc30b[16]][OxOc30b[22]]=inp_width[OxOc30b[13]];element[OxOc30b[16]][OxOc30b[23]]=inp_height[OxOc30b[13]];} catch(er){alert(OxOc30b[29]);} ;} else {try{element[OxOc30b[22]]=inp_width[OxOc30b[13]];element[OxOc30b[23]]=inp_height[OxOc30b[13]];} catch(er){alert(OxOc30b[29]);} ;} ;var Ox374=/[^a-z\d]/i;if(Ox374.test(inp_id.value)){alert(OxOc30b[30]);return ;} ;element[OxOc30b[24]]=sel_align[OxOc30b[13]];element[OxOc30b[17]]=inp_id[OxOc30b[13]];element[OxOc30b[25]]=sel_valign[OxOc30b[13]];element[OxOc30b[27]]=sel_noWrap[OxOc30b[13]];element[OxOc30b[26]]=inp_tooltip[OxOc30b[13]];element[OxOc30b[28]]=sel_CellScope[OxOc30b[13]];if(element[OxOc30b[17]]==OxOc30b[31]){element.removeAttribute(OxOc30b[17]);} ;if(element[OxOc30b[28]]==OxOc30b[31]){element.removeAttribute(OxOc30b[28]);} ;if(element[OxOc30b[27]]==OxOc30b[31]){element.removeAttribute(OxOc30b[27]);} ;if(element[OxOc30b[14]]==OxOc30b[31]){element.removeAttribute(OxOc30b[14]);} ;if(element[OxOc30b[18]]==OxOc30b[31]){element.removeAttribute(OxOc30b[18]);} ;if(element[OxOc30b[19]]==OxOc30b[31]){element.removeAttribute(OxOc30b[19]);} ;if(element[OxOc30b[7]]==OxOc30b[31]){element.removeAttribute(OxOc30b[7]);} ;if(element[OxOc30b[21]]==OxOc30b[31]){element.removeAttribute(OxOc30b[21]);} ;if(element[OxOc30b[21]]==OxOc30b[31]){element.removeAttribute(OxOc30b[32]);} ;if(element[OxOc30b[24]]==OxOc30b[31]){element.removeAttribute(OxOc30b[24]);} ;if(element[OxOc30b[25]]==OxOc30b[31]){element.removeAttribute(OxOc30b[33]);} ;if(element[OxOc30b[26]]==OxOc30b[31]){element.removeAttribute(OxOc30b[26]);} ;if(element[OxOc30b[22]]==OxOc30b[31]){element.removeAttribute(OxOc30b[22]);} ;if(element[OxOc30b[23]]==OxOc30b[31]){element.removeAttribute(OxOc30b[23]);} ;} ;inp_borderColor[OxOc30b[34]]=function inp_borderColor_onclick(){SelectColor(inp_borderColor);} ;inp_bgColor[OxOc30b[34]]=function inp_bgColor_onclick(){SelectColor(inp_bgColor);} ;inp_borderColorLight[OxOc30b[34]]=function inp_borderColorLight_onclick(){SelectColor(inp_borderColorLight);} ;inp_borderColorDark[OxOc30b[34]]=function inp_borderColorDark_onclick(){SelectColor(inp_borderColorDark);} ;
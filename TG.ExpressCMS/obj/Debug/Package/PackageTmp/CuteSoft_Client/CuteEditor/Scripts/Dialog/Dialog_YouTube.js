var OxO3e49=["idSource","TargetUrl","value","","$4","$5","\x26","wmode=\x22transparent\x22","allowfullscreen=\x22true\x22","\x3Cembed src=\x22","\x22 width=\x22","\x22 height=\x22","\x22 "," "," type=\x22application/x-shockwave-flash\x22 pluginspage=\x22http://www.macromedia.com/go/getflashplayer\x22 \x3E\x3C/embed\x3E\x0A","\x3Cobject xcodebase=","\x22http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab\x22"," height=\x22","\x22 classid=","\x22clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\x22 \x3E"," \x3Cparam name=\x22Movie\x22 value=\x22","\x22 /\x3E","\x3Cparam name=\x22wmode\x22 value=\x22transparent\x22/\x3E","\x3Cparam name=\x22allowFullScreen\x22 value=\x22true\x22/\x3E","\x3C/object\x3E"];var idSource=Window_GetElement(window,OxO3e49[0],true);var TargetUrl=Window_GetElement(window,OxO3e49[1],true);var editor=Window_GetDialogArguments(window);var oldWidth,OldHeight;function do_preview(){var Ox11f=GetEmbed();if(Ox11f){if(idSource[OxO3e49[2]]!=Ox11f&&idSource[OxO3e49[2]]!=null){idSource[OxO3e49[2]]=Ox11f;} ;} ;} ;function do_insert(){var Ox11f=GetEmbed();if(Ox11f){editor.PasteHTML(Ox11f);} ;Window_CloseDialog(window);} ;function do_Close(){Window_CloseDialog(window);} ;function GetEmbed(){if(idSource[OxO3e49[2]]==OxO3e49[3]||idSource[OxO3e49[2]]==null){return ;} ;var Ox647=OxO3e49[3];Ox647=idSource[OxO3e49[2]];var Ox648=/(<iframe[^\>]*?)(\ssrc=\s*)\s*("|')(.+?)\3([^>]*)(.*<\/iframe>)/gi;var Ox649=/(<object[^\>]*>[\s|\S]*?)(<embed[^\>]*?)(\ssrc=\s*)\s*("|')(.+?)\4([^>]*)(.*<\/embed>)[\s|\S]*?<\/object>/gi;if(Ox647.match(Ox648)){Ox647=Ox647.replace(Ox648,OxO3e49[4]);TargetUrl[OxO3e49[2]]=Ox647;return idSource[OxO3e49[2]];} else {if(Ox647.match(Ox649)){oldWidth=Ox647.replace(/(<object[^\>]*>[\s|\S]*?)(<embed[^\>]*?)(\swidth=\s*)\s*("|')(.+?)\4([^>]*)(.*<\/embed>)[\s|\S]*?<\/object>/gi,OxO3e49[5]);oldHeight=Ox647.replace(/(<object[^\>]*>[\s|\S]*?)(<embed[^\>]*?)(\sheight=\s*)\s*("|')(.+?)\4([^>]*)(.*<\/embed>)[\s|\S]*?<\/object>/gi,OxO3e49[5]);Ox647=Ox647.replace(Ox649,OxO3e49[5]);if(Ox647.indexOf(OxO3e49[6])!=-1){TargetUrl[OxO3e49[2]]=Ox647.substring(0,Ox647.indexOf(OxO3e49[6]));} ;var Ox64a=OxO3e49[3];var Oxe0=425;var Ox2d=344;var Ox3e2,Ox3e3;oldWidth=parseInt(oldWidth);if(oldWidth){Oxe0=oldWidth;} ;oldHeight=parseInt(oldHeight);if(oldHeight){Ox2d=oldHeight;} ;Ox3e2=true;if(Ox647==OxO3e49[3]){return ;} ;var Ox3e6,Ox3e8;Ox3e8=OxO3e49[3];Ox3e6=true?OxO3e49[7]:OxO3e49[3];Ox3e8=true?OxO3e49[8]:OxO3e49[3];var Ox3ee=OxO3e49[9]+Ox647+OxO3e49[10]+Oxe0+OxO3e49[11]+Ox2d+OxO3e49[12]+Ox3e8+OxO3e49[13]+Ox3e6+OxO3e49[14];var Ox3ef=OxO3e49[15]+OxO3e49[16]+OxO3e49[17]+Ox2d+OxO3e49[10]+Oxe0+OxO3e49[18]+OxO3e49[19]+OxO3e49[20]+Ox647+OxO3e49[21];if(true){Ox3ef=Ox3ef+OxO3e49[22];} ;if(true){Ox3ef=Ox3ef+OxO3e49[23];} ;Ox3ef=Ox3ef+Ox3ee+OxO3e49[24];return Ox3ef;} ;} ;} ;
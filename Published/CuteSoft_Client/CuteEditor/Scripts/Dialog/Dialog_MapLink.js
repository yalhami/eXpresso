var OxOe4f1=["inp_src","inp_title","inp_target","sel_protocol","btnbrowse","editor","","href","value","title","target","onclick","length","options","://",":","others","selectedIndex"];var inp_src=Window_GetElement(window,OxOe4f1[0],true);var inp_title=Window_GetElement(window,OxOe4f1[1],true);var inp_target=Window_GetElement(window,OxOe4f1[2],true);var sel_protocol=Window_GetElement(window,OxOe4f1[3],true);var btnbrowse=Window_GetElement(window,OxOe4f1[4],true);var obj=Window_GetDialogArguments(window);var editor=obj[OxOe4f1[5]];SyncToView();function SyncToView(){var src=obj[OxOe4f1[7]].replace(/$\s*/,OxOe4f1[6]);Update_sel_protocol(src);inp_src[OxOe4f1[8]]=src;if(obj[OxOe4f1[9]]){inp_title[OxOe4f1[8]]=obj[OxOe4f1[9]];} ;if(obj[OxOe4f1[10]]){inp_target[OxOe4f1[8]]=obj[OxOe4f1[10]];} ;} ;btnbrowse[OxOe4f1[11]]=function btnbrowse_onclick(){function Ox35b(Ox13d){if(Ox13d){inp_src[OxOe4f1[8]]=Ox13d;} ;} ;editor.SetNextDialogWindow(window);if(Browser_IsSafari()){editor.ShowSelectFileDialog(Ox35b,inp_src.value,inp_src);} else {editor.ShowSelectFileDialog(Ox35b,inp_src.value);} ;} ;function sel_protocol_change(){var src=inp_src[OxOe4f1[8]].replace(/$\s*/,OxOe4f1[6]);for(var i=0;i<sel_protocol[OxOe4f1[13]][OxOe4f1[12]];i++){var Ox141=sel_protocol[OxOe4f1[13]][i][OxOe4f1[8]];if(src.substr(0,Ox141.length).toLowerCase()==Ox141){src=src.substr(Ox141.length,src[OxOe4f1[12]]-Ox141[OxOe4f1[12]]);break ;} ;} ;var Ox446=src.indexOf(OxOe4f1[14]);if(Ox446!=-1){src=src.substr(Ox446+3,src[OxOe4f1[12]]-3-Ox446);} ;var Ox446=src.indexOf(OxOe4f1[15]);if(Ox446!=-1){src=src.substr(Ox446+1,src[OxOe4f1[12]]-1-Ox446);} ;var Ox447=sel_protocol[OxOe4f1[8]];if(Ox447==OxOe4f1[16]){Ox447=OxOe4f1[6];} ;inp_src[OxOe4f1[8]]=Ox447+src;} ;function Update_sel_protocol(src){var Ox449=false;for(var i=0;i<sel_protocol[OxOe4f1[13]][OxOe4f1[12]];i++){var Ox141=sel_protocol[OxOe4f1[13]][i][OxOe4f1[8]];if(src.substr(0,Ox141.length).toLowerCase()==Ox141){if(sel_protocol[OxOe4f1[17]]!=i){sel_protocol[OxOe4f1[17]]=i;} ;Ox449=true;break ;} ;} ;if(!Ox449){sel_protocol[OxOe4f1[17]]=sel_protocol[OxOe4f1[13]][OxOe4f1[12]]-1;} ;} ;function insert_link(){var arr= new Array();arr[0]=inp_src[OxOe4f1[8]];if(inp_target[OxOe4f1[8]]){arr[1]=inp_target[OxOe4f1[8]];} ;if(inp_title[OxOe4f1[8]]){arr[2]=inp_title[OxOe4f1[8]];} ;Window_SetDialogReturnValue(window,arr);Window_CloseDialog(window);} ;
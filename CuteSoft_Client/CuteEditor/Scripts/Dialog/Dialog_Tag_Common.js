var OxOe8a5=["inp_class","inp_width","inp_height","sel_align","sel_textalign","sel_float","inp_forecolor","img_forecolor","inp_backcolor","img_backcolor","inp_tooltip","value","className","width","style","height","align","styleFloat","cssFloat","textAlign","title","backgroundColor","color","","class","onclick"];var inp_class=Window_GetElement(window,OxOe8a5[0],true);var inp_width=Window_GetElement(window,OxOe8a5[1],true);var inp_height=Window_GetElement(window,OxOe8a5[2],true);var sel_align=Window_GetElement(window,OxOe8a5[3],true);var sel_textalign=Window_GetElement(window,OxOe8a5[4],true);var sel_float=Window_GetElement(window,OxOe8a5[5],true);var inp_forecolor=Window_GetElement(window,OxOe8a5[6],true);var img_forecolor=Window_GetElement(window,OxOe8a5[7],true);var inp_backcolor=Window_GetElement(window,OxOe8a5[8],true);var img_backcolor=Window_GetElement(window,OxOe8a5[9],true);var inp_tooltip=Window_GetElement(window,OxOe8a5[10],true);UpdateState=function UpdateState_Common(){} ;SyncToView=function SyncToView_Common(){inp_class[OxOe8a5[11]]=element[OxOe8a5[12]];inp_width[OxOe8a5[11]]=element[OxOe8a5[14]][OxOe8a5[13]];inp_height[OxOe8a5[11]]=element[OxOe8a5[14]][OxOe8a5[15]];sel_align[OxOe8a5[11]]=element[OxOe8a5[16]];if(Browser_IsWinIE()){sel_float[OxOe8a5[11]]=element[OxOe8a5[14]][OxOe8a5[17]];} else {sel_float[OxOe8a5[11]]=element[OxOe8a5[14]][OxOe8a5[18]];} ;sel_textalign[OxOe8a5[11]]=element[OxOe8a5[14]][OxOe8a5[19]];inp_tooltip[OxOe8a5[11]]=element[OxOe8a5[20]];inp_forecolor[OxOe8a5[11]]=revertColor(element[OxOe8a5[14]].color);inp_forecolor[OxOe8a5[14]][OxOe8a5[21]]=inp_forecolor[OxOe8a5[11]];img_forecolor[OxOe8a5[14]][OxOe8a5[21]]=inp_forecolor[OxOe8a5[11]];inp_backcolor[OxOe8a5[11]]=revertColor(element[OxOe8a5[14]].backgroundColor);inp_backcolor[OxOe8a5[14]][OxOe8a5[21]]=inp_backcolor[OxOe8a5[11]];img_backcolor[OxOe8a5[14]][OxOe8a5[21]]=inp_backcolor[OxOe8a5[11]];} ;SyncTo=function SyncTo_Common(element){element[OxOe8a5[12]]=inp_class[OxOe8a5[11]];try{element[OxOe8a5[14]][OxOe8a5[13]]=inp_width[OxOe8a5[11]];element[OxOe8a5[14]][OxOe8a5[15]]=inp_height[OxOe8a5[11]];} catch(x){} ;element[OxOe8a5[16]]=sel_align[OxOe8a5[11]];if(Browser_IsWinIE()){element[OxOe8a5[14]][OxOe8a5[17]]=sel_float[OxOe8a5[11]];} else {element[OxOe8a5[14]][OxOe8a5[18]]=sel_float[OxOe8a5[11]];} ;element[OxOe8a5[14]][OxOe8a5[19]]=sel_textalign[OxOe8a5[11]];element[OxOe8a5[20]]=inp_tooltip[OxOe8a5[11]];element[OxOe8a5[14]][OxOe8a5[22]]=inp_forecolor[OxOe8a5[11]];element[OxOe8a5[14]][OxOe8a5[21]]=inp_backcolor[OxOe8a5[11]];if(element[OxOe8a5[12]]==OxOe8a5[23]){element.removeAttribute(OxOe8a5[12]);} ;if(element[OxOe8a5[12]]==OxOe8a5[23]){element.removeAttribute(OxOe8a5[24]);} ;if(element[OxOe8a5[20]]==OxOe8a5[23]){element.removeAttribute(OxOe8a5[20]);} ;if(element[OxOe8a5[16]]==OxOe8a5[23]){element.removeAttribute(OxOe8a5[16]);} ;} ;img_forecolor[OxOe8a5[25]]=inp_forecolor[OxOe8a5[25]]=function inp_forecolor_onclick(){SelectColor(inp_forecolor,img_forecolor);} ;img_backcolor[OxOe8a5[25]]=inp_backcolor[OxOe8a5[25]]=function inp_backcolor_onclick(){SelectColor(inp_backcolor,img_backcolor);} ;
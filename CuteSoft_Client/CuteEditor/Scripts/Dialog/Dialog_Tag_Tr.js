var OxO73e0=["inp_width","inp_height","sel_align","sel_valign","inp_bgColor","inp_borderColor","inp_borderColorLight","inp_borderColorDark","inp_class","inp_id","inp_tooltip","value","bgColor","backgroundColor","style","id","borderColor","borderColorLight","borderColorDark","className","width","height","align","vAlign","title","[[ValidNumber]]","[[ValidID]]","","class","valign","onclick"];var inp_width=Window_GetElement(window,OxO73e0[0],true);var inp_height=Window_GetElement(window,OxO73e0[1],true);var sel_align=Window_GetElement(window,OxO73e0[2],true);var sel_valign=Window_GetElement(window,OxO73e0[3],true);var inp_bgColor=Window_GetElement(window,OxO73e0[4],true);var inp_borderColor=Window_GetElement(window,OxO73e0[5],true);var inp_borderColorLight=Window_GetElement(window,OxO73e0[6],true);var inp_borderColorDark=Window_GetElement(window,OxO73e0[7],true);var inp_class=Window_GetElement(window,OxO73e0[8],true);var inp_id=Window_GetElement(window,OxO73e0[9],true);var inp_tooltip=Window_GetElement(window,OxO73e0[10],true);SyncToView=function SyncToView_Tr(){inp_bgColor[OxO73e0[11]]=element.getAttribute(OxO73e0[12])||element[OxO73e0[14]][OxO73e0[13]];inp_id[OxO73e0[11]]=element.getAttribute(OxO73e0[15]);inp_bgColor[OxO73e0[14]][OxO73e0[13]]=inp_bgColor[OxO73e0[11]];inp_borderColor[OxO73e0[11]]=element.getAttribute(OxO73e0[16]);inp_borderColor[OxO73e0[14]][OxO73e0[13]]=inp_borderColor[OxO73e0[11]];inp_borderColorLight[OxO73e0[11]]=element.getAttribute(OxO73e0[17]);inp_borderColorLight[OxO73e0[14]][OxO73e0[13]]=inp_borderColorLight[OxO73e0[11]];inp_borderColorDark[OxO73e0[11]]=element.getAttribute(OxO73e0[18]);inp_borderColorDark[OxO73e0[14]][OxO73e0[13]]=inp_borderColorDark[OxO73e0[11]];inp_class[OxO73e0[11]]=element[OxO73e0[19]];inp_width[OxO73e0[11]]=element.getAttribute(OxO73e0[20])||element[OxO73e0[14]][OxO73e0[20]];inp_height[OxO73e0[11]]=element.getAttribute(OxO73e0[21])||element[OxO73e0[14]][OxO73e0[21]];sel_align[OxO73e0[11]]=element.getAttribute(OxO73e0[22]);sel_valign[OxO73e0[11]]=element.getAttribute(OxO73e0[23]);inp_tooltip[OxO73e0[11]]=element.getAttribute(OxO73e0[24]);} ;SyncTo=function SyncTo_Tr(element){if(inp_bgColor[OxO73e0[11]]){if(element[OxO73e0[14]][OxO73e0[13]]){element[OxO73e0[14]][OxO73e0[13]]=inp_bgColor[OxO73e0[11]];} else {element[OxO73e0[12]]=inp_bgColor[OxO73e0[11]];} ;} else {element.removeAttribute(OxO73e0[12]);} ;element[OxO73e0[16]]=inp_borderColor[OxO73e0[11]];element[OxO73e0[17]]=inp_borderColorLight[OxO73e0[11]];element[OxO73e0[18]]=inp_borderColorDark[OxO73e0[11]];element[OxO73e0[19]]=inp_class[OxO73e0[11]];if(element[OxO73e0[14]][OxO73e0[20]]||element[OxO73e0[14]][OxO73e0[21]]){try{element[OxO73e0[14]][OxO73e0[20]]=inp_width[OxO73e0[11]];element[OxO73e0[14]][OxO73e0[21]]=inp_height[OxO73e0[11]];} catch(er){alert(OxO73e0[25]);} ;} else {try{element[OxO73e0[20]]=inp_width[OxO73e0[11]];element[OxO73e0[21]]=inp_height[OxO73e0[11]];} catch(er){alert(OxO73e0[25]);} ;} ;var Ox373=/[^a-z\d]/i;if(Ox373.test(inp_id.value)){alert(OxO73e0[26]);return ;} ;element[OxO73e0[22]]=sel_align[OxO73e0[11]];element[OxO73e0[15]]=inp_id[OxO73e0[11]];element[OxO73e0[23]]=sel_valign[OxO73e0[11]];element[OxO73e0[24]]=inp_tooltip[OxO73e0[11]];if(element[OxO73e0[15]]==OxO73e0[27]){element.removeAttribute(OxO73e0[15]);} ;if(element[OxO73e0[12]]==OxO73e0[27]){element.removeAttribute(OxO73e0[12]);} ;if(element[OxO73e0[16]]==OxO73e0[27]){element.removeAttribute(OxO73e0[16]);} ;if(element[OxO73e0[17]]==OxO73e0[27]){element.removeAttribute(OxO73e0[17]);} ;if(element[OxO73e0[7]]==OxO73e0[27]){element.removeAttribute(OxO73e0[7]);} ;if(element[OxO73e0[19]]==OxO73e0[27]){element.removeAttribute(OxO73e0[19]);} ;if(element[OxO73e0[19]]==OxO73e0[27]){element.removeAttribute(OxO73e0[28]);} ;if(element[OxO73e0[22]]==OxO73e0[27]){element.removeAttribute(OxO73e0[22]);} ;if(element[OxO73e0[23]]==OxO73e0[27]){element.removeAttribute(OxO73e0[29]);} ;if(element[OxO73e0[24]]==OxO73e0[27]){element.removeAttribute(OxO73e0[24]);} ;if(element[OxO73e0[20]]==OxO73e0[27]){element.removeAttribute(OxO73e0[20]);} ;if(element[OxO73e0[21]]==OxO73e0[27]){element.removeAttribute(OxO73e0[21]);} ;} ;inp_borderColor[OxO73e0[30]]=function inp_borderColor_onclick(){SelectColor(inp_borderColor);} ;inp_bgColor[OxO73e0[30]]=function inp_bgColor_onclick(){SelectColor(inp_bgColor);} ;inp_borderColorLight[OxO73e0[30]]=function inp_borderColorLight_onclick(){SelectColor(inp_borderColorLight);} ;inp_borderColorDark[OxO73e0[30]]=function inp_borderColorDark_onclick(){SelectColor(inp_borderColorDark);} ;
var OxO237f=["INPUT","TEXTAREA","DIV","SPAN","","contentWindow","innerHTML","body","document","length","type","text","id","isContentEditable","showModalDialog","MSIE","userAgent","?","?Modal=true","\x26Modal=true","dialogHeight:340px; dialogWidth:395px; edge:Raised; center:Yes; help:No; resizable:Yes; status:No; scroll:No","left=","availWidth",",top=","availHeight",",height=300,width=400,scrollbars=no,resizable=no,toolbars=no,status=no,menubar=no,location=no","ElementIndex","dialogArguments","window","opener","value","SpellMode","start","suggest","end","SpellingForm","checkElements","innerText","StatusText","Spell Checking Text ...","CurrentText","WordIndex","Spell Check Complete","closeeditordialog","close","selectedIndex","ReplacementWord","form","options"];var showCompleteAlert=true;var tagGroup= new Array(OxO237f[0],OxO237f[1],OxO237f[2],OxO237f[3]);var checkElements= new Array();function getText(Ox1fb){var Ox1fc=document.getElementById(checkElements[Ox1fb]);var Ox1fd=OxO237f[4];var Ox1fe=document.getElementById(Ox1fc.id);if(Ox1fe[OxO237f[5]]){Ox1fd=Ox1fe[OxO237f[5]][OxO237f[8]][OxO237f[7]][OxO237f[6]];} else {Ox1fd=Ox1fe[OxO237f[8]][OxO237f[7]][OxO237f[6]];} ;return Ox1fd;} ;function setText(Ox1fb,Ox200){var Ox1fc=document.getElementById(checkElements[Ox1fb]);var Ox1fe=document.getElementById(Ox1fc.id);if(Ox1fe[OxO237f[5]]){Ox1fe[OxO237f[5]][OxO237f[8]][OxO237f[7]][OxO237f[6]]=Ox200;} else {Ox1fe[OxO237f[8]][OxO237f[7]][OxO237f[6]]=Ox200;} ;} ;function checkSpelling(){checkElements= new Array();for(var i=0;i<tagGroup[OxO237f[9]];i++){var Ox202=tagGroup[i];var Ox203=document.getElementsByTagName(Ox202);for(var x=0;x<Ox203[OxO237f[9]];x++){if((Ox202==OxO237f[0]&&Ox203[x][OxO237f[10]]==OxO237f[11])||Ox202==OxO237f[1]){checkElements[checkElements[OxO237f[9]]]=Ox203[x][OxO237f[12]];} else {if((Ox202==OxO237f[2]||Ox202==OxO237f[3])&&Ox203[x][OxO237f[13]]){checkElements[checkElements[OxO237f[9]]]=Ox203[x][OxO237f[12]];} ;} ;} ;} ;openSpellChecker();} ;function checkSpellingById(Ox99,Ox205){checkElements= new Array();checkElements[checkElements[OxO237f[9]]]=Ox99;openSpellChecker(Ox205);} ;function checkElementSpelling(Ox1fc){checkElements= new Array();checkElements[checkElements[OxO237f[9]]]=Ox1fc[OxO237f[12]];openSpellChecker();} ;function openSpellChecker(Ox205){if(window[OxO237f[14]]&&navigator[OxO237f[16]].indexOf(OxO237f[15])!=-1){var Ox208;if(Ox205.indexOf(OxO237f[17])==-1){Ox208=OxO237f[18];} else {Ox208=OxO237f[19];} ;var Ox209=window.showModalDialog(Ox205+Ox208,window,OxO237f[20]);} else {var Ox20a=window.open(Ox205,null,OxO237f[21]+(screen[OxO237f[22]]-400)/2+OxO237f[23]+(screen[OxO237f[24]]-400)/2+OxO237f[25]);} ;} ;var iElementIndex=-1;var parentWindow;function initialize(){iElementIndex=parseInt(document.getElementById(OxO237f[26]).value);if(parent[OxO237f[28]][OxO237f[27]]){parentWindow=parent[OxO237f[28]][OxO237f[27]];} else {if(top[OxO237f[29]]){parentWindow=top[OxO237f[29]];} ;} ;var Ox20e=document.getElementById(OxO237f[31])[OxO237f[30]];switch(Ox20e){case OxO237f[32]:break ;;case OxO237f[33]:updateText();break ;;case OxO237f[34]:updateText();;default:if(loadText()){document.getElementById(OxO237f[35]).submit();} else {endCheck();} ;break ;;} ;} ;function loadText(){if(!parentWindow[OxO237f[8]]){return false;} ;for(++iElementIndex;iElementIndex<parentWindow[OxO237f[36]][OxO237f[9]];iElementIndex++){var Ox210=parentWindow.getText(iElementIndex);if(Ox210[OxO237f[9]]>0){updateSettings(Ox210,0,iElementIndex,OxO237f[32]);document.getElementById(OxO237f[38])[OxO237f[37]]=OxO237f[39];return true;} ;} ;return false;} ;function updateSettings(Ox212,Ox213,Ox214,Ox215){document.getElementById(OxO237f[40])[OxO237f[30]]=Ox212;document.getElementById(OxO237f[41])[OxO237f[30]]=Ox213;document.getElementById(OxO237f[26])[OxO237f[30]]=Ox214;document.getElementById(OxO237f[31])[OxO237f[30]]=Ox215;} ;function updateText(){if(!parentWindow[OxO237f[8]]){return false;} ;var Ox210=document.getElementById(OxO237f[40])[OxO237f[30]];parentWindow.setText(iElementIndex,Ox210);} ;function endCheck(){if(showCompleteAlert){alert(OxO237f[42]);} ;closeWindow();} ;function closeWindow(){(top[OxO237f[43]]||top[OxO237f[44]])();} ;function changeWord(Ox1fc){var Ox21a=Ox1fc[OxO237f[45]];Ox1fc[OxO237f[47]][OxO237f[46]][OxO237f[30]]=Ox1fc[OxO237f[48]][Ox21a][OxO237f[30]];} ;
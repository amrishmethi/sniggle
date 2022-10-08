<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<script runat="server">
string GetDialogQueryString;
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{	
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="colorpicker_basic.aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[MoreColors]]",FrameSrc);
		Context.Response.End();
	}
	}
	string s="";
	if(Context.Request.QueryString["Dialog"]=="Standard")	
		s="&Dialog=Standard";
	
	GetDialogQueryString="Theme="+Context.Request.QueryString["Theme"]+s;	
	base.OnInit(args);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1003&file=DialogHead.js"></script>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1003&file=Dialog_ColorPicker.js"></script>
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css"
			rel="stylesheet" />
		<style type="text/css">
			.colorcell
			{
				width:16px;
				height:17px;
				cursor:hand;
			}
			.colordiv,.customdiv
			{
				border:solid 1px #808080;
				width:16px;
				height:17px;
				font-size:1px;
			}
			#ajaxdiv{padding:10px;margin:0;text-align:center; background:#eeeeee;}
		</style>
		<title>[[NamedColors]]</title>
		<script>
								
		var OxOa400=["Green","#008000","Lime","#00FF00","Teal","#008080","Aqua","#00FFFF","Navy","#000080","Blue","#0000FF","Purple","#800080","Fuchsia","#FF00FF","Maroon","#800000","Red","#FF0000","Olive","#808000","Yellow","#FFFF00","White","#FFFFFF","Silver","#C0C0C0","Gray","#808080","Black","#000000","DarkOliveGreen","#556B2F","DarkGreen","#006400","DarkSlateGray","#2F4F4F","SlateGray","#708090","DarkBlue","#00008B","MidnightBlue","#191970","Indigo","#4B0082","DarkMagenta","#8B008B","Brown","#A52A2A","DarkRed","#8B0000","Sienna","#A0522D","SaddleBrown","#8B4513","DarkGoldenrod","#B8860B","Beige","#F5F5DC","HoneyDew","#F0FFF0","DimGray","#696969","OliveDrab","#6B8E23","ForestGreen","#228B22","DarkCyan","#008B8B","LightSlateGray","#778899","MediumBlue","#0000CD","DarkSlateBlue","#483D8B","DarkViolet","#9400D3","MediumVioletRed","#C71585","IndianRed","#CD5C5C","Firebrick","#B22222","Chocolate","#D2691E","Peru","#CD853F","Goldenrod","#DAA520","LightGoldenrodYellow","#FAFAD2","MintCream","#F5FFFA","DarkGray","#A9A9A9","YellowGreen","#9ACD32","SeaGreen","#2E8B57","CadetBlue","#5F9EA0","SteelBlue","#4682B4","RoyalBlue","#4169E1","BlueViolet","#8A2BE2","DarkOrchid","#9932CC","DeepPink","#FF1493","RosyBrown","#BC8F8F","Crimson","#DC143C","DarkOrange","#FF8C00","BurlyWood","#DEB887","DarkKhaki","#BDB76B","LightYellow","#FFFFE0","Azure","#F0FFFF","LightGray","#D3D3D3","LawnGreen","#7CFC00","MediumSeaGreen","#3CB371","LightSeaGreen","#20B2AA","DeepSkyBlue","#00BFFF","DodgerBlue","#1E90FF","SlateBlue","#6A5ACD","MediumOrchid","#BA55D3","PaleVioletRed","#DB7093","Salmon","#FA8072","OrangeRed","#FF4500","SandyBrown","#F4A460","Tan","#D2B48C","Gold","#FFD700","Ivory","#FFFFF0","GhostWhite","#F8F8FF","Gainsboro","#DCDCDC","Chartreuse","#7FFF00","LimeGreen","#32CD32","MediumAquamarine","#66CDAA","DarkTurquoise","#00CED1","CornflowerBlue","#6495ED","MediumSlateBlue","#7B68EE","Orchid","#DA70D6","HotPink","#FF69B4","LightCoral","#F08080","Tomato","#FF6347","Orange","#FFA500","Bisque","#FFE4C4","Khaki","#F0E68C","Cornsilk","#FFF8DC","Linen","#FAF0E6","WhiteSmoke","#F5F5F5","GreenYellow","#ADFF2F","DarkSeaGreen","#8FBC8B","Turquoise","#40E0D0","MediumTurquoise","#48D1CC","SkyBlue","#87CEEB","MediumPurple","#9370DB","Violet","#EE82EE","LightPink","#FFB6C1","DarkSalmon","#E9967A","Coral","#FF7F50","NavajoWhite","#FFDEAD","BlanchedAlmond","#FFEBCD","PaleGoldenrod","#EEE8AA","Oldlace","#FDF5E6","Seashell","#FFF5EE","PaleGreen","#98FB98","SpringGreen","#00FF7F","Aquamarine","#7FFFD4","PowderBlue","#B0E0E6","LightSkyBlue","#87CEFA","LightSteelBlue","#B0C4DE","Plum","#DDA0DD","Pink","#FFC0CB","LightSalmon","#FFA07A","Wheat","#F5DEB3","Moccasin","#FFE4B5","AntiqueWhite","#FAEBD7","LemonChiffon","#FFFACD","FloralWhite","#FFFAF0","Snow","#FFFAFA","AliceBlue","#F0F8FF","LightGreen","#90EE90","MediumSpringGreen","#00FA9A","PaleTurquoise","#AFEEEE","LightCyan","#E0FFFF","LightBlue","#ADD8E6","Lavender","#E6E6FA","Thistle","#D8BFD8","MistyRose","#FFE4E1","Peachpuff","#FFDAB9","PapayaWhip","#FFEFD5"];var colorlist=[{n:OxOa400[0],h:OxOa400[1]},{n:OxOa400[2],h:OxOa400[3]},{n:OxOa400[4],h:OxOa400[5]},{n:OxOa400[6],h:OxOa400[7]},{n:OxOa400[8],h:OxOa400[9]},{n:OxOa400[10],h:OxOa400[11]},{n:OxOa400[12],h:OxOa400[13]},{n:OxOa400[14],h:OxOa400[15]},{n:OxOa400[16],h:OxOa400[17]},{n:OxOa400[18],h:OxOa400[19]},{n:OxOa400[20],h:OxOa400[21]},{n:OxOa400[22],h:OxOa400[23]},{n:OxOa400[24],h:OxOa400[25]},{n:OxOa400[26],h:OxOa400[27]},{n:OxOa400[28],h:OxOa400[29]},{n:OxOa400[30],h:OxOa400[31]}];var colormore=[{n:OxOa400[32],h:OxOa400[33]},{n:OxOa400[34],h:OxOa400[35]},{n:OxOa400[36],h:OxOa400[37]},{n:OxOa400[38],h:OxOa400[39]},{n:OxOa400[40],h:OxOa400[41]},{n:OxOa400[42],h:OxOa400[43]},{n:OxOa400[44],h:OxOa400[45]},{n:OxOa400[46],h:OxOa400[47]},{n:OxOa400[48],h:OxOa400[49]},{n:OxOa400[50],h:OxOa400[51]},{n:OxOa400[52],h:OxOa400[53]},{n:OxOa400[54],h:OxOa400[55]},{n:OxOa400[56],h:OxOa400[57]},{n:OxOa400[58],h:OxOa400[59]},{n:OxOa400[60],h:OxOa400[61]},{n:OxOa400[62],h:OxOa400[63]},{n:OxOa400[64],h:OxOa400[65]},{n:OxOa400[66],h:OxOa400[67]},{n:OxOa400[68],h:OxOa400[69]},{n:OxOa400[70],h:OxOa400[71]},{n:OxOa400[72],h:OxOa400[73]},{n:OxOa400[74],h:OxOa400[75]},{n:OxOa400[76],h:OxOa400[77]},{n:OxOa400[78],h:OxOa400[79]},{n:OxOa400[80],h:OxOa400[81]},{n:OxOa400[82],h:OxOa400[83]},{n:OxOa400[84],h:OxOa400[85]},{n:OxOa400[86],h:OxOa400[87]},{n:OxOa400[88],h:OxOa400[89]},{n:OxOa400[90],h:OxOa400[91]},{n:OxOa400[92],h:OxOa400[93]},{n:OxOa400[94],h:OxOa400[95]},{n:OxOa400[96],h:OxOa400[97]},{n:OxOa400[98],h:OxOa400[99]},{n:OxOa400[100],h:OxOa400[101]},{n:OxOa400[102],h:OxOa400[103]},{n:OxOa400[104],h:OxOa400[105]},{n:OxOa400[106],h:OxOa400[107]},{n:OxOa400[108],h:OxOa400[109]},{n:OxOa400[110],h:OxOa400[111]},{n:OxOa400[112],h:OxOa400[113]},{n:OxOa400[114],h:OxOa400[115]},{n:OxOa400[116],h:OxOa400[117]},{n:OxOa400[118],h:OxOa400[119]},{n:OxOa400[120],h:OxOa400[121]},{n:OxOa400[122],h:OxOa400[123]},{n:OxOa400[124],h:OxOa400[125]},{n:OxOa400[126],h:OxOa400[127]},{n:OxOa400[128],h:OxOa400[129]},{n:OxOa400[130],h:OxOa400[131]},{n:OxOa400[132],h:OxOa400[133]},{n:OxOa400[134],h:OxOa400[135]},{n:OxOa400[136],h:OxOa400[137]},{n:OxOa400[138],h:OxOa400[139]},{n:OxOa400[140],h:OxOa400[141]},{n:OxOa400[142],h:OxOa400[143]},{n:OxOa400[144],h:OxOa400[145]},{n:OxOa400[146],h:OxOa400[147]},{n:OxOa400[148],h:OxOa400[149]},{n:OxOa400[150],h:OxOa400[151]},{n:OxOa400[152],h:OxOa400[153]},{n:OxOa400[154],h:OxOa400[155]},{n:OxOa400[156],h:OxOa400[157]},{n:OxOa400[158],h:OxOa400[159]},{n:OxOa400[160],h:OxOa400[161]},{n:OxOa400[162],h:OxOa400[163]},{n:OxOa400[164],h:OxOa400[165]},{n:OxOa400[166],h:OxOa400[167]},{n:OxOa400[168],h:OxOa400[169]},{n:OxOa400[170],h:OxOa400[171]},{n:OxOa400[172],h:OxOa400[173]},{n:OxOa400[174],h:OxOa400[175]},{n:OxOa400[176],h:OxOa400[177]},{n:OxOa400[178],h:OxOa400[179]},{n:OxOa400[180],h:OxOa400[181]},{n:OxOa400[182],h:OxOa400[183]},{n:OxOa400[184],h:OxOa400[185]},{n:OxOa400[186],h:OxOa400[187]},{n:OxOa400[188],h:OxOa400[189]},{n:OxOa400[190],h:OxOa400[191]},{n:OxOa400[192],h:OxOa400[193]},{n:OxOa400[194],h:OxOa400[195]},{n:OxOa400[196],h:OxOa400[197]},{n:OxOa400[198],h:OxOa400[199]},{n:OxOa400[200],h:OxOa400[201]},{n:OxOa400[202],h:OxOa400[203]},{n:OxOa400[204],h:OxOa400[205]},{n:OxOa400[206],h:OxOa400[207]},{n:OxOa400[208],h:OxOa400[209]},{n:OxOa400[210],h:OxOa400[211]},{n:OxOa400[212],h:OxOa400[213]},{n:OxOa400[214],h:OxOa400[215]},{n:OxOa400[216],h:OxOa400[217]},{n:OxOa400[218],h:OxOa400[219]},{n:OxOa400[220],h:OxOa400[221]},{n:OxOa400[156],h:OxOa400[157]},{n:OxOa400[222],h:OxOa400[223]},{n:OxOa400[224],h:OxOa400[225]},{n:OxOa400[226],h:OxOa400[227]},{n:OxOa400[228],h:OxOa400[229]},{n:OxOa400[230],h:OxOa400[231]},{n:OxOa400[232],h:OxOa400[233]},{n:OxOa400[234],h:OxOa400[235]},{n:OxOa400[236],h:OxOa400[237]},{n:OxOa400[238],h:OxOa400[239]},{n:OxOa400[240],h:OxOa400[241]},{n:OxOa400[242],h:OxOa400[243]},{n:OxOa400[244],h:OxOa400[245]},{n:OxOa400[246],h:OxOa400[247]},{n:OxOa400[248],h:OxOa400[249]},{n:OxOa400[250],h:OxOa400[251]},{n:OxOa400[252],h:OxOa400[253]},{n:OxOa400[254],h:OxOa400[255]},{n:OxOa400[256],h:OxOa400[257]},{n:OxOa400[258],h:OxOa400[259]},{n:OxOa400[260],h:OxOa400[261]},{n:OxOa400[262],h:OxOa400[263]},{n:OxOa400[264],h:OxOa400[265]},{n:OxOa400[266],h:OxOa400[267]},{n:OxOa400[268],h:OxOa400[269]},{n:OxOa400[270],h:OxOa400[271]},{n:OxOa400[272],h:OxOa400[273]}];
		
		</script>
	</head>
	<body>
		<div id="ajaxdiv">
			<div class="tab-pane-control tab-pane" id="tabPane1">
				<div class="tab-row">
					<h2 class="tab">
						<a tabindex="-1" href='colorpicker.aspx?<%=GetDialogQueryString%>'>
							<span style="white-space:nowrap;">
								[[WebPalette]]
							</span>
						</a>
					</h2>
					<h2 class="tab selected">
							<a tabindex="-1" href='colorpicker_basic.aspx?<%=GetDialogQueryString%>'>
								<span style="white-space:nowrap;">
									[[NamedColors]]
								</span>
							</a>
					</h2>
					<h2 class="tab">
							<a tabindex="-1" href='colorpicker_more.aspx?<%=GetDialogQueryString%>'>
								<span style="white-space:nowrap;">
									[[CustomColor]]
								</span>
							</a>
					</h2>
				</div>
				<div class="tab-page">			
					<table class="colortable" align="center">
						<tr>
							<td colspan="16" height="16"><p align="left">Basic:
								</p>
							</td>
						</tr>
						<tr>
							<script>
								var OxO211a=["length","\x3Ctd class=\x27colorcell\x27\x3E\x3Cdiv class=\x27colordiv\x27 style=\x27background-color:","\x27 title=\x27"," ","\x27 cname=\x27","\x27 cvalue=\x27","\x27\x3E\x3C/div\x3E\x3C/td\x3E",""];var arr=[];for(var i=0;i<colorlist[OxO211a[0]];i++){arr.push(OxO211a[1]);arr.push(colorlist[i].n);arr.push(OxO211a[2]);arr.push(colorlist[i].n);arr.push(OxO211a[3]);arr.push(colorlist[i].h);arr.push(OxO211a[4]);arr.push(colorlist[i].n);arr.push(OxO211a[5]);arr.push(colorlist[i].h);arr.push(OxO211a[6]);} ;document.write(arr.join(OxO211a[7]));
							</script>
						</tr>
						<tr>
							<td colspan="16" height="12"><p align="left"></p>
							</td>
						</tr>
						<tr>
							<td colspan="16"><p align="left">Additional:
								</p>
							</td>
						</tr>
						<script>
							var OxO57a3=["length","\x3Ctr\x3E","\x3Ctd class=\x27colorcell\x27\x3E\x3Cdiv class=\x27colordiv\x27 style=\x27background-color:","\x27 title=\x27"," ","\x27 cname=\x27","\x27 cvalue=\x27","\x27\x3E\x3C/div\x3E\x3C/td\x3E","\x3C/tr\x3E",""];var arr=[];for(var i=0;i<colormore[OxO57a3[0]];i++){if(i%16==0){arr.push(OxO57a3[1]);} ;arr.push(OxO57a3[2]);arr.push(colormore[i].n);arr.push(OxO57a3[3]);arr.push(colormore[i].n);arr.push(OxO57a3[4]);arr.push(colormore[i].h);arr.push(OxO57a3[5]);arr.push(colormore[i].n);arr.push(OxO57a3[6]);arr.push(colormore[i].h);arr.push(OxO57a3[7]);if(i%16==15){arr.push(OxO57a3[8]);} ;} ;if(colormore%16>0){arr.push(OxO57a3[8]);} ;document.write(arr.join(OxO57a3[9]));
						</script>
						<tr>
							<td colspan="16" height="8">
							</td>
						</tr>
						<tr>
							<td colspan="16" height="12">
								<input checked id="CheckboxColorNames" style="width: 16px; height: 20px" type="checkbox">
								<span style="width: 118px;">Use color names</span>
							</td>
						</tr>
						<tr>
							<td colspan="16" height="12">
							</td>
						</tr>
						<tr>
							<td colspan="16" valign="middle" height="24">
							<span style="height:24px;width:50px;vertical-align:middle;">Color : </span>&nbsp;
							<input type="text" id="divpreview" size="7" maxlength="7" style="width:180px;height:24px;border:#a0a0a0 1px solid; Padding:4;"/>
					
							</td>
						</tr>
				</table>
			</div>
		</div>
		<div id="container-bottom">
			<input type="button" id="buttonok" value="[[OK]]" class="formbutton" style="width:70px"	onclick="do_insert();" /> 
			&nbsp;&nbsp;&nbsp;&nbsp; 
			<input type="button" id="buttoncancel" value="[[Cancel]]" class="formbutton" style="width:70px"	onclick="do_Close();" />	
		</div>
	</div>
	</body>
</html>


<%@ Control Language="c#" AutoEventWireup="false" Codebehind="LoginHeader.ascx.cs" Inherits="Constituent_Services.controls.LoginHeader" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Topeka.org | City Council</TITLE>
	</HEAD>
	<link href="http://www.topeka.org/css/css.css" type="text/css" rel="stylesheet">
	<script language="javascript" type="text/javascript">
	function popupWindow(win,winWidth,winHeight,place,winName){
	
	leftPos = 0; topPos = 0; 

		if (screen){ 
		   
    		if (winWidth>screen.width){
    		   winWidth = screen.width;
    		}
    		
    		if (winHeight>screen.height){
    		   winHeight = screen.height - 55;
    		}
    		
    		if (winWidth <= 0){
    		   winWidth = screen.width;
    		}
    		
    		if (winHeight <= 0){
    		   winHeight = screen.height - 55;
    		}
    		
			if (place == 'topleft'){ 
			leftPos = 0;
			topPos = 0;
			}
			
			if (place == 'centre'){ // centres window
			leftPos = screen.width/2 - winWidth/2;
			topPos = screen.height/2 - winHeight/2;
			}
			
			if (place == 'topright'){ // positions window in top right corner
			leftPos = screen.width - winWidth;
			topPos = 0;
			}
			
			if (place == 'botleft'){ // positions window in bottom left corner
			leftPos = 0;
			topPos = screen.height - (winHeight + 55); // add 55 to prevent bottom of window being obscured by taskbar
			}
			
			if (place == 'botright'){ 
			leftPos = screen.width - winWidth;
			topPos = screen.height - (winHeight+55); 
			}
					
		}
		
		newWindow = window.open(win,winName,'menubar=no,toolbar=yes,location=no,scrollbars=yes,resizable=yes,width='+winWidth+',height='+winHeight+',left='+leftPos+',top='+topPos+'');
		newWindow.focus();
	}
	// -->
	</script>
	<script language="JavaScript1.2">
function high(which2){
theobject=which2
highlighting=setInterval("highlightit(theobject)",1)
}
function low(which2){
clearInterval(highlighting)
if (which2.style.MozOpacity)
which2.style.MozOpacity=0.3
else if (which2.filters)
which2.filters.alpha.opacity=30
}

function highlightit(cur2){
if (cur2.style.MozOpacity<1)
cur2.style.MozOpacity=parseFloat(cur2.style.MozOpacity)+0.1
else if (cur2.filters&&cur2.filters.alpha.opacity<100)
cur2.filters.alpha.opacity+=10
else if (window.highlighting)
clearInterval(highlighting)
}

	</script>
	<style type="text/css"> UL { LIST-STYLE-IMAGE: url(../../images/arrow.gif) }
	BODY { MARGIN: 0px }
	</style>
	<div id="object1" onmouseover="overdiv=1;" style="BORDER-TOP-WIDTH: 20px; BORDER-LEFT-WIDTH: 20px; Z-INDEX: 1; BORDER-LEFT-COLOR: black; LEFT: 25px; BORDER-BOTTOM-WIDTH: 20px; BORDER-BOTTOM-COLOR: black; COLOR: black; BORDER-TOP-COLOR: black; POSITION: absolute; TOP: -50px; BACKGROUND-COLOR: #ffffdd; BORDER-RIGHT-WIDTH: 20px; BORDER-RIGHT-COLOR: black"
		onmouseout="overdiv=0; setTimeout('hideLayer()',100)">pop up description layer
	</div>
	<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="789" align="center"
		border="0">
		<TBODY>
			<tr>
				<td class="smallText" vAlign="top" bgColor="#e9e9e9">
					<div align="right">
						<table id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TBODY>
								<tr>
									<td class="smallText" bgColor="#e9e9e9">
										<div align="center"><img height="88" src="http://www.topeka.org/images/lgo_inside.gif" width="775" border="0"></div>
										<table id="Table3" cellSpacing="0" cellPadding="0" width="775" align="center" border="0">
											<TBODY>
												<tr>
													<td class="smallText">
														<div align="center"><img height="185" src="http://www.topeka.org/images/capdome.jpg" width="775"></div>
													</td>
												</tr>
												<tr>
													<td style="HEIGHT: 4px">
														<div align="center"><IMG height="9" src="http://www.topeka.org/images/cellbg_bttm.gif" width="775"></div>
													</td>
												</tr>
												<tr>
													<td bgColor="#f4f4f4">
														<table id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
															<tr>
																<td vAlign="top" bgColor="#f4f4f4">
																	<div align="center">
																		<table id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																			<tr>
																				<td style="HEIGHT: 5px" background="http://www.topeka.org/images/nav_dotted.gif"><IMG height="3" src="http://www.topeka.org/images/spacer.gif" width="1"></td>
																			</tr>
																		</table>
																	</div>
																</td>
															</tr>
															<tr>
																<td vAlign="top" bgColor="#f4f4f4">
																	<table id="Table6" cellSpacing="0" cellPadding="0" width="97%" align="center" border="0">
																		<tr class="smallText">
																			<td style="HEIGHT: 27px" width="15">
																				<div align="center"><IMG height="15" src="http://www.topeka.org/images/upper_left.gif" width="15"></div>
																			</td>
																			<td class="regtext" align="center" width="100%" bgColor="#ffffff"></td>
																			<td style="HEIGHT: 27px" width="15">
																				<div align="center"><IMG height="15" src="http://www.topeka.org/images/upper_right.gif" width="15"></div>
																			</td>
																		</tr>
																		<tr>
																			<td bgColor="#ffffff" colSpan="3"><table id="Table7" cellSpacing="1" cellPadding="2" width="97%" align="center" border="0">
																					<tr>
																						<td class="regtext">

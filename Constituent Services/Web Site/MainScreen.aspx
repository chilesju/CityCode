<%@ Page language="c#" Codebehind="MainScreen.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.MainScreen" %>

<%@ Register Src="controls/adminHeader.ascx" TagName="adminHeader" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="ViewPlaceHolder" Src="Incident Views/ViewPlaceHolder.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="controls/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Constituent Services - Main Screen</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema /">
		<link href="http://www.topeka.org/css/css.css" type="text/css" rel="stylesheet"/>
        <link href="http://www.topeka.org/css/css.css" rel="stylesheet" type="text/css" />
	</head>
	<body topmargin="0">
		<form id="Form1" method="post" runat="server">
			<div id="object1" onmouseover="overdiv=1;" style="BORDER-TOP-WIDTH: 20px; BORDER-LEFT-WIDTH: 20px; Z-INDEX: 1; BORDER-LEFT-COLOR: black; LEFT: 25px; BORDER-BOTTOM-WIDTH: 20px; BORDER-BOTTOM-COLOR: black; COLOR: black; BORDER-TOP-COLOR: black; POSITION: absolute; TOP: -50px; BACKGROUND-COLOR: #ffffdd; BORDER-RIGHT-WIDTH: 20px; BORDER-RIGHT-COLOR: black"
				onmouseout="overdiv=0; setTimeout('hideLayer()',100)">pop up description layer</div>
			<table id="LayoutOutside" bordercolor="#e9e9e9" height="100%" cellspacing="0" cellpadding="0" width="780" align="center" bgcolor="#f4f4f4" border="2" rules="none" frame="vSides">
				<tr>
					<td class="regtext" align="center">
                        <uc2:adminHeader ID="AdminHeader1" runat="server" />
                    </td>
				</tr>
				<tr align="center" width="100%">
					<td align="center" width="100%">
						<table id="LayoutContentBorder" cellpadding="0" cellspacing="0" border="0" width="753" bgcolor="white" style="show: empty;">
							<tr>
								<td align="center" width="750">
									<table id="LayoutContent" cellpadding="0" cellspacing="0" border="0" width="700" align="center">
										<tr><td height="6"></td></tr>
										<tr><td background="http://www.topeka.org/images/nav_dotted.gif" height="5"><IMG height="3" src="../../images/spacer.gif" width="20"></td></tr>
										<tr><td height="6"></td></tr>
										<tr align="center">
											<td align="left" height="39" style="height: 39px;" valign="top"><asp:Label id="lblWelcome" runat="server" CssClass="smalltext"></asp:Label></td>
										</tr><tr>
											<td class="regtext" align="center"><uc1:viewplaceholder id="ViewPlaceHolder1" runat="server"></uc1:viewplaceholder></td>
										</tr><tr>
											<td class="regtext" align="center"><uc1:footer id="Footer1" runat="server"></uc1:footer></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>

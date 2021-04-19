<%@ Page language="c#" Codebehind="Reports.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.Reports" %>
<%@ Register TagPrefix="uc1" TagName="adminHeader" Src="controls/adminHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="controls/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<head>
		<title>Constituent Services - Reports</title>
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
                        <uc1:adminHeader ID="AdminHeader1" runat="server" />
                    </td>
				</tr>
			<tr class="regtext" align="center">
			<td>
			<table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0"  valign="top">
				<tr>
					<td colspan="2">
						<table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="http://www.topeka.org/images/nav_dotted.gif"><IMG height="3" src="../../images/spacer.gif" width="20"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="Reports/allopencalls.pdf">All Open Cases</asp:HyperLink></TD>
				</tr>
				<tr>
					<td>
						<asp:HyperLink id="HyperLink2" runat="server" NavigateUrl="Reports/allopencalls.pdf">Over Due Cases</asp:HyperLink></TD>
				</tr>
							<tr>
				<td class="regtext" align="center"><uc1:footer id="Footer1" runat="server"></uc1:footer></td>
			</tr>
			</table>
			</td>
			</tr>

			</table>
		</form>
	</body>
</HTML>


<%@ Register TagPrefix="uc1" TagName="adminHeader" Src="controls/adminHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SearchTabsPlaceHolder" Src="controls/SearchTabsPlaceHolder.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="controls/footer.ascx" %>
<%@ Page language="c#" Codebehind="Search.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.Search" %>
<%@ Register TagPrefix="uc1" TagName="SearchAssignment" Src="controls/SearchAssignment.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Constituent Services - Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		<div id="object1" onmouseover="overdiv=1;" style="BORDER-TOP-WIDTH: 20px; BORDER-LEFT-WIDTH: 20px; Z-INDEX: 1; BORDER-LEFT-COLOR: black; LEFT: 25px; BORDER-BOTTOM-WIDTH: 20px; BORDER-BOTTOM-COLOR: black; COLOR: black; BORDER-TOP-COLOR: black; POSITION: absolute; TOP: -50px; BACKGROUND-COLOR: #ffffdd; BORDER-RIGHT-WIDTH: 20px; BORDER-RIGHT-COLOR: black"
				onmouseout="overdiv=0; setTimeout('hideLayer()',100)">pop up description layer</div>
			<table id="LayoutOutside" bordercolor="#e9e9e9" height="100%" cellspacing="0" cellpadding="0" width="780" align="center" bgcolor="#f4f4f4" border="2" rules="none" frame="vSides">
		    <tr>
				<td class="regtext" align="center" style="height: 300px">
                    <uc1:adminheader ID="AdminHeader1" runat="server" />
                </td>
		    </tr>
		<tr align="center" width="100%">
		    <td align="center" width="100%">
			<table id="Table1" style="HEIGHT: 1px" cellspacing="1" cellpadding="1" width="100%" border="0">
				<tr>
					<td colspan="2">
						<table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="http://www.topeka.org/images/nav_dotted.gif" style="height: 5px"><img height="3" src="http://www.topeka.org/images/spacer.gif" width="20"/></td>
							</tr>
						</table>
					</td>
				</tr>
					<tr><td>
						<uc1:SearchTabsPlaceHolder id="SearchTabsPlaceHolder1" runat="server"></uc1:SearchTabsPlaceHolder></td></tr>
		        <tr>
		        <td>
				    <uc1:footer id="Footer1" runat="server"></uc1:footer>
				</td>
				</tr>
			</table>
			</td>
			</tr>
			</table>
			</form>
	</body>
</HTML>

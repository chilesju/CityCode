<%@ Page language="c#" Codebehind="Administration.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.Administration" %>
<%@ Register TagPrefix="uc1" TagName="adminHeader" Src="controls/adminHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="controls/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Constituent Services - Administration</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:adminHeader id="AdminHeader1" runat="server"></uc1:adminHeader>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<tr>
					<td colSpan="2">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="http://www.topeka.org/images/nav_dotted.gif"><IMG height="3" src="../../images/spacer.gif" width="20"></td>
							</tr>
						</table>
						<asp:Label id="lblRole" runat="server" CssClass="regtext" Font-Bold="True"></asp:Label>
					</td>
				</tr>
				<TR>
					<TD>
						<asp:DataGrid id="dgUserList" runat="server" CssClass="regtext" Width="100%"></asp:DataGrid></TD>
				</TR>
				<tr>
					<td colSpan="2">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="http://www.topeka.org/images/nav_dotted.gif"><IMG height="3" src="../../images/spacer.gif" width="20"></td>
							</tr>
						</table>
						<asp:Label id="Label1" runat="server" CssClass="regtext"></asp:Label>
					</td>
				</tr>
				<TR>
					<TD>
						<asp:Label id="lblCatagories" runat="server" CssClass="regtext" Font-Bold="True"></asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:DataGrid id="dgCatagories" runat="server" CssClass="regtext" Width="100%"></asp:DataGrid></TD>
				</TR>
			</TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>

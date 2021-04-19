<%@ Page language="c#" Codebehind="FindCouncilDistrict.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.FindCouncilDistrict" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Constituent Services - Search for Council District</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="http://www.topeka.org/css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript">

		function CloseWindow()
		{
			self.close();
		}
		</script>
		<script language="javascript" src="JScript.js" type="text/javascript"></script>
	</HEAD>
	<body style="background-color: white">
		<form id="SearchAddress" method="post" runat="server">
			<TABLE id="Table1" style="cellSpacing: '1'" cellPadding="1" width="500" border="0">
				<TR>
					<TD><asp:label id="Label1" runat="server" CssClass="regtext">Type in any part of the address and click Search</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:textbox id="txtAddress" runat="server" CssClass="textbox" Width="200px"></asp:textbox><asp:button id="btnSearch" runat="server" CssClass="regtext" Text="Search"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px"><asp:listbox id="addressList" runat="server" CssClass="regtext"></asp:listbox></TD>
				</TR>
				<TR>
					<TD>
						<asp:button id="btnClose" runat="server" Text="Close"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

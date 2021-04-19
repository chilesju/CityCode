<%@ Page language="c#" Codebehind="SearchAddress.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.SearchAddress" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Constituent Services - Search Address</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<link href="http://www.topeka.org/css/css.css" type="text/css" rel="stylesheet" />
		<script language="javascript">

		function CloseWindow()
		{
			self.close();
		}
		</script>
		<script language="javascript" src="JScript.js" type="text/javascript"></script>
	</head>
	<body style="background-color: white">
		<form id="SearchAddress" method="post" runat="server">
			<table id="Table1" style="HEIGHT: 233px; background-color: white;" cellspacing="1" cellpadding="1" width="500" border="0">
				<tr>
					<td><asp:label id="Label1" runat="server" CssClass="regtext">Type in any part of the address and click Search</asp:label></td>
				</tr>
				<tr>
					<td><asp:textbox id="txtAddress" runat="server" CssClass="textbox" Width="200px"></asp:textbox><asp:button id="btnSearch" runat="server" CssClass="regtext" Text="Search"></asp:button></td>
				</tr>
				<tr>
					<td style="HEIGHT: 18px"><asp:listbox id="addressList" runat="server" CssClass="regtext"></asp:listbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server" CssClass="regtext">Address Choosen:</asp:label>&nbsp;
						<asp:TextBox id="txtChosenAddress" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:button id="btnOk" runat="server" Text="OK"></asp:button>&nbsp;
						<asp:button id="btnClose" runat="server" Text="Close"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</html>

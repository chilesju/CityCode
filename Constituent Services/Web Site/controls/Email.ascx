<%@ implements interface="Constituent_Services.controls.IHistoryTab" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Email.ascx.cs" Inherits="Constituent_Services.controls.Email" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
	<TR>
		<TD><asp:label id="Label1" CssClass="regtext" runat="server" Font-Underline="True" Font-Bold="True">Users</asp:label></TD>
		<TD><asp:label id="lblEmailHistory" CssClass="regtext" runat="server" Font-Underline="True" Font-Bold="True">Email History</asp:label></TD>
	</TR>
	<TR>
		<TD>
			<div style="OVERFLOW:auto; WIDTH:100%; HEIGHT:300px">
				<asp:checkboxlist id="emailList" runat="server" CssClass="regtext"></asp:checkboxlist>
			</div>
		</TD>
		<TD vAlign="top" align="left">
			<asp:DataGrid id="emailHistoryList" CssClass="regtext" runat="server"></asp:DataGrid></TD>
	</TR>
	<TR>
		<TD>
			<asp:button id="btnSendEmail" CssClass="regtext" runat="server" Text="Email Users"></asp:button></TD>
	</TR>
</TABLE>

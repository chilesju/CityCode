<%@ implements interface="Constituent_Services.controls.IHistoryTab" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdditionalUsers.ascx.cs" Inherits="Constituent_Services.controls.AdditionalUsers" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD>
			<asp:Label id="lblAdditionalUsers" runat="server" CssClass="regtext" Font-Bold="True" Font-Underline="True">Additional Users</asp:Label></TD>
	</TR>
	<TR>
		<TD>
			<asp:label id="Label5" runat="server" CssClass="regtext" Font-Bold="True"> Does this call need to be assigned to additional users?</asp:label></TD>
	</TR>
	<TR>
		<TD>
			<asp:label id="lblAssignAdditionalUsers" runat="server" CssClass="regtext" Font-Bold="True">Additional Users: </asp:label>
			<asp:DropDownList id="AssignToAdditionalList" runat="server" Width="480px"></asp:DropDownList></TD>
	</TR>
	<TR>
		<TD>
			<asp:Button id="btnAssignToUser" runat="server" Text="Assign to User"></asp:Button></TD>
	</TR>
	<TR>
		<TD>
			<asp:DataGrid id="DataGrid1" runat="server" CssClass="regtext"></asp:DataGrid></TD>
	</TR>
	<TR>
		<TD></TD>
	</TR>
</TABLE>

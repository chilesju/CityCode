<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminTabsPlaceHolder.ascx.cs" Inherits="Constituent_Services.controls.AdminTabsPlaceHolder" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" style="HEIGHT: 56px" cellSpacing="1" cellPadding="1" width="100%">
	<TR>
		<TD class="regtext" style="HEIGHT: 25px"><asp:linkbutton id="lkbtnAssignment1" CssClass="reglinks" runat="server">Assignment</asp:linkbutton>&nbsp;|&nbsp;
			<asp:linkbutton id="lkbtnHistory" CssClass="reglinks" runat="server">History</asp:linkbutton>&nbsp;
			<asp:linkbutton id="AdditionalUsersLinkbutton" runat="server" CssClass="reglinks" Enabled="False"
				Visible="False">Additional Users</asp:linkbutton></TD>
	</TR>
	<TR>
		<TD><asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder></TD>
	</TR>
</TABLE>

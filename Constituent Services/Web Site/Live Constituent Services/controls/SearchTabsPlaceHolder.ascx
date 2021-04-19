<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SearchTabsPlaceHolder.ascx.cs" Inherits="Constituent_Services.controls.SearchTabsPlaceHolder" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD style="HEIGHT: 22px" align="center">
			<asp:linkbutton id="lkbtnSearchIncident" runat="server" CssClass="reglinks">Search Incident</asp:linkbutton>&nbsp;|
			<asp:linkbutton id="lkbtnSearchAssignment" runat="server" CssClass="reglinks">Search Assignment</asp:linkbutton></TD>
	</TR>
	<TR>
		<TD>
			<asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder></TD>
	</TR>
</TABLE>

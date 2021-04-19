<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ViewPlaceHolder.ascx.cs" Inherits="Constituent_Services.Incident_Views.ViewPlaceHolder" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%">
	<TR>
		<TD style="HEIGHT: 21px; TEXT-ALIGN: center" class="regtext">
			<asp:linkbutton id="lkbtnOpenIncidents" runat="server" CssClass="reglinks">Open Incidents</asp:linkbutton>&nbsp;|&nbsp;
			<asp:linkbutton id="lkbtnPendingIncidents" runat="server" CssClass="reglinks">Pending Incidents</asp:linkbutton>&nbsp;| 
			&nbsp;
			<asp:linkbutton id="lkbtnClosedIncidents" runat="server" CssClass="reglinks">Closed Incidents</asp:linkbutton>&nbsp;|
			<asp:linkbutton id="lkbtnOverDue" CssClass="reglinks" runat="server">Over Due Incidents</asp:linkbutton>|
			<asp:linkbutton id="lkbtnRequestingClosure" CssClass="reglinks" runat="server">Requesting Closure</asp:linkbutton></TD>
	</TR>
	<TR>
		<TD>
			<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder></TD>
	</TR>
</TABLE>

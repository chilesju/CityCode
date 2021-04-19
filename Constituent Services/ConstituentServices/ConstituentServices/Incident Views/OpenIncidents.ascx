<%@ Control Language="c#" AutoEventWireup="false" Codebehind="OpenIncidents.ascx.cs" Inherits="Constituent_Services.Incident_Views.OpenIncidents" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%">
	<TR>
		<TD class="regtext">Open Incidents: Incidents that are Open and do not have a 
			Pending Date or a Court Date.
		</TD>
	</TR>
	<TR>
		<TD>
			<P><asp:datagrid id="DataGrid1" ShowFooter="True" CssClass="regtext" Width="100%" PageSize="25" AutoGenerateColumns="False"
					runat="server">
					<FooterStyle Font-Bold="True"></FooterStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="Incident Number">
							<ItemTemplate>
								<asp:LinkButton id=lblIncidentNumber runat="server" CssClass="reglinks" CommandArgument="IncidentNumber" CommandName="Edit" Text='<%#(DataBinder.Eval(Container, "DataItem.Incident Number")) %>'>
								</asp:LinkButton>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Problem Desciption">
							<ItemTemplate>
								<asp:Label id=lblProblemDescription runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.Problem Disc")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Catagory/Question">
							<ItemTemplate>
								<asp:Label id=lblCatagory runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.Catagory/Question")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Open Date">
							<ItemTemplate>
								<asp:Label id="lblOpenDate" runat="server" Text='<%# String.Format("{0:d}",(DataBinder.Eval(Container, "DataItem.Open Date"))) %>' > >
										</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Address">
							<ItemTemplate>
								<asp:Label id=lblCitizen runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.Address")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid></P>
		</TD>
	</TR>
</TABLE>

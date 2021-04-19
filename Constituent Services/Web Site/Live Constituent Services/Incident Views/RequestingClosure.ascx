<%@ Control Language="c#" AutoEventWireup="false" Codebehind="RequestingClosure.ascx.cs" Inherits="Constituent_Services.Incident_Views.RequestingClosure" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD class="regtext">Over Due Incidents: Incidents that are Open and either have not 
			been updated in one week or the Pending Date has passed or the Court Date has 
			passed.</TD>
	</TR>
	<TR>
		<TD noWrap>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" PageSize="100" Width="100%"
				CssClass="regtext" ShowFooter="True">
				<FooterStyle Font-Bold="True"></FooterStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="Incident Number">
						<ItemTemplate>
							<asp:LinkButton id=lblIncidentNumber CssClass="reglinks" runat="server" CommandArgument="IncidentNumber" CommandName="Edit" Text='<%#(DataBinder.Eval(Container, "DataItem.Incident Number")) %>'>
							</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Problem Desciption">
						<ItemTemplate>
							<asp:Label id=lblProblemDescription runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.Problem Disc")) %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Category/Question">
						<ItemTemplate>
							<asp:Label id=lblCatagory runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.Catagory/Question")) %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Open Date">
						<ItemTemplate>
							<asp:Label id="lblOpenDate" runat="server" Text='<%# String.Format("{0:d}",(DataBinder.Eval(Container, "DataItem.Open Date"))) %>'> >
										</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Address">
						<ItemTemplate>
							<asp:Label id="lblCitizen" runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.Address")) %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></TD>
	</TR>
</TABLE>

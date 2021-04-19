<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Closed.ascx.cs" Inherits="Constituent_Services.Incident_Views.Closed" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD class="regtext">
			Returns the last60 closed Incidents. To View more use the Search option.
		</TD>
	</TR>
	<TR>
		<TD>
			<asp:datagrid id="DataGrid1" CssClass="regtext" Width="100%" PageSize="25" AutoGenerateColumns="False"
				runat="server" ShowFooter="True">
				<FooterStyle Font-Bold="True"></FooterStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="Incident Number">
						<ItemTemplate>
							<asp:LinkButton id=lblIncidentNumber runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.Incident Number")) %>' CommandArgument="IncidentNumber" CommandName="Edit">
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
							<asp:Label id="lblOpenDate" runat="server" Text='<%# String.Format("{0:d}",(DataBinder.Eval(Container, "DataItem.Open Date"))) %>' >
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Name">
						<ItemTemplate>
							<asp:Label id="lblCitizen" runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.Address")) %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></TD>
	</TR>
</TABLE>

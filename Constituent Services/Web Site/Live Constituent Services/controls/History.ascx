<%@ implements interface="Constituent_Services.controls.IHistoryTab" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="History.ascx.cs" Inherits="Constituent_Services.controls.History" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD><asp:datagrid id="DataGrid1" CssClass="regtext" Width="100%" AutoGenerateColumns="False" runat="server">
				<Columns>
					<asp:TemplateColumn HeaderText="Assignment ID">
						<ItemTemplate>
							<asp:Label id="lblHistoryId" runat="server" CssClass="regtext" Text='<%#DataBinder.Eval(Container, "DataItem.HistoryId") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Command">
						<ItemTemplate>
							<asp:Label id="lblCommand" runat="server" CssClass="regtext" Text='<%#DataBinder.Eval(Container, "DataItem.Command")%>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="User">
						<ItemTemplate>
							<asp:Label id="lblUser" runat="server" CssClass="regtext" Text='<%#DataBinder.Eval(Container, "DataItem.User")%>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Date">
						<ItemTemplate>
							<asp:Label id="lblDate" runat="server" CssClass="regtext" Text='<%#DataBinder.Eval(Container, "DataItem.Date")%>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></TD>
	</TR>
</TABLE>

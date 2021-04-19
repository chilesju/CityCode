<%@ implements interface="Constituent_Services.controls.ISearchTab" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SearchIncident.ascx.cs" Inherits="Constituent_Services.controls.SearchIncident" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD>
			<asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD>
	</TR>
	<TR>
		<TD style="height: 26px"><asp:label id="lblIncidentNumber" runat="server" CssClass="regtext">Incident Number:</asp:label>&nbsp;<asp:textbox id="txIncidentNumber" runat="server"></asp:textbox>
			<asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="Invalid Incident Number" MaximumValue="10000"
				MinimumValue="1" ControlToValidate="txIncidentNumber" Type="Integer">*</asp:RangeValidator></TD>
	</TR>
	<TR>
		<TD><asp:label id="lblLastName" runat="server" CssClass="regtext">Citizen First Name:</asp:label>&nbsp;<asp:textbox id="txtFirstName" runat="server" tabIndex="1"></asp:textbox></TD>
	</TR>
	<TR>
		<TD><asp:label id="Label1" runat="server" CssClass="regtext">Citizen Last Name:</asp:label>&nbsp;<asp:textbox id="txtLastName" runat="server" tabIndex="2"></asp:textbox></TD>
	</TR>
	<TR>
		<TD><asp:label id="Label6" runat="server" CssClass="regtext">Incident Address:</asp:label>&nbsp;<asp:textbox id="txtAddress" runat="server" Width="296px" tabIndex="3"></asp:textbox></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 14px"><asp:label id="lblFirstName" runat="server" CssClass="regtext">Council Dist:</asp:label>&nbsp;<asp:dropdownlist id="councilList" runat="server" CssClass="regtext" tabIndex="4"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 5px"><asp:label id="Label8" runat="server" CssClass="regtext">Type of Incidents:</asp:label>&nbsp;<asp:dropdownlist id="incidentTypeList" runat="server" CssClass="regtext" tabIndex="5"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 27px"><asp:label id="Label2" runat="server" CssClass="regtext">Description:</asp:label>&nbsp;<asp:textbox id="txtDescription" runat="server" CssClass="regtext" Width="296px" tabIndex="6"></asp:textbox></TD>
	</TR>
	<TR>
		<TD class="regtext"><asp:label id="Label7" runat="server" CssClass="regtext">Open Date:</asp:label>&nbsp;
			<asp:textbox id="txtOpenDateMin" runat="server" CssClass="regtext" tabIndex="7"></asp:textbox>&nbsp;
			<asp:RangeValidator id="RangeValidator2" runat="server" ErrorMessage="Invalid Incident Number" MaximumValue="12/12/2900"
				MinimumValue="1/1/1900" ControlToValidate="txtOpenDateMin" Type="Date">*</asp:RangeValidator>to
			<asp:textbox id="txtOpenDateMax" runat="server" CssClass="regtext" tabIndex="8"></asp:textbox>
			<asp:RangeValidator id="RangeValidator3" runat="server" ErrorMessage="Invalid Incident Number" MaximumValue="12/12/2900"
				MinimumValue="1/1/1900" ControlToValidate="txtOpenDateMax" Type="Date">*</asp:RangeValidator></TD>
	</TR>
	<TR>
		<TD class="regtext" style="HEIGHT: 24px"><asp:label id="Label3" runat="server" CssClass="regtext">Status:</asp:label>&nbsp;
			<asp:dropdownlist id="statusList" CssClass="regtext" runat="server" tabIndex="9">
				<asp:ListItem Value="0">--Select One--</asp:ListItem>
				<asp:ListItem Value="O">Open</asp:ListItem>
				<asp:ListItem Value="C">Closed</asp:ListItem>
				<asp:ListItem Value="P">Pending</asp:ListItem>
			</asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD><asp:button id="btnSearch" runat="server" Text="Search" tabIndex="10" OnClick="btnSearch_Click"></asp:button>&nbsp;
			<asp:button id="btnRest" runat="server" Text="Reset" tabIndex="11"></asp:button></TD>
	</TR>
	<TR>
		<TD align="center">
			<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
				<tr>
					<td background="http://www.topeka.org/images/nav_dotted.gif"><IMG height="3" src="../../images/spacer.gif" width="20"></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
	<TR>
		<TD colSpan="2"><asp:datagrid id="DataGrid1" runat="server" CssClass="regtext" Width="100%" ShowFooter="True"
				AllowSorting="True" AutoGenerateColumns="False" tabIndex="12">
				<FooterStyle Font-Bold="True" BackColor="#FEFEFE"></FooterStyle>
				<Columns>
					<asp:TemplateColumn SortExpression="Incident_Number" HeaderText="Incident #">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:LinkButton id=lkbtnPermitNumber runat="server" CssClass="reglinksbold" Text='<%# DataBinder.Eval(Container, "DataItem.[Incident Number]") %>' Font-Bold="True" CommandName="Edit">
							</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn SortExpression="Address" HeaderText="Address">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id=lbldgAddress runat="server" Text='<%#String.Format("{0:d}", DataBinder.Eval(Container, "DataItem.Address")) %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn SortExpression="Date_Sent" HeaderText="Open Date">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id=lbldgOpenDate runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.[Open Date]")) %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Catagory">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id=lbldgCatagory runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.[Catagory/Question]") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Status">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id=lbldgStatus runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OpenClose") %>'>
							</asp:Label>
						</ItemTemplate>
						<FooterStyle HorizontalAlign="Center"></FooterStyle>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></TD>
	</TR>
</TABLE>

<%@ implements interface="Constituent_Services.controls.ISearchTab" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SearchAssignment.ascx.cs" Inherits="Constituent_Services.controls.SearchAssignment" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD style="HEIGHT: 16px"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="regtext"></asp:validationsummary></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 16px"><asp:label id="lblIncidentNumber" runat="server" CssClass="regtext">Incident Number:</asp:label>&nbsp;<asp:textbox id="txtIncidentNumber" tabIndex="1" runat="server" CssClass="regtext"></asp:textbox>
			<asp:rangevalidator id="RangeValidator1" runat="server" CssClass="regtext" ErrorMessage="Invalid  Incident Number"
				Type="Integer" MaximumValue="10000" ControlToValidate="txtIncidentNumber" MinimumValue="1">*</asp:rangevalidator></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 21px"><asp:label id="Label3" runat="server" CssClass="regtext">Department:</asp:label>&nbsp;<asp:dropdownlist id="departmentList" runat="server" CssClass="regtext" tabIndex="2" AutoPostBack="True" OnSelectedIndexChanged="departmentList_SelectedIndexChanged1"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD><asp:label id="lblStreetNumber" runat="server" CssClass="regtext">Division:</asp:label>&nbsp;<asp:dropdownlist id="divisionList" runat="server" CssClass="regtext" tabIndex="3">
				<asp:ListItem Value="0">--Select a Department--</asp:ListItem>
			</asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD class="regtext"><asp:label id="Label2" runat="server" CssClass="regtext">Assignment Last Updated:</asp:label>&nbsp;<asp:textbox id="txtMinAssignmentDate" runat="server" CssClass="regtext" tabIndex="6"></asp:textbox>
			<asp:rangevalidator id="RangeValidator4" runat="server" CssClass="regtext" ErrorMessage="Invalid Min Assignment Date"
				Type="Date" MaximumValue="12/12/2900" MinimumValue="1/1/1900" ControlToValidate="txtMinAssignmentDate">*</asp:rangevalidator>&nbsp;to 
			&nbsp;
			<asp:textbox id="txtMaxAssignmentDate" runat="server" CssClass="regtext" tabIndex="7"></asp:textbox><asp:rangevalidator id="RangeValidator5" runat="server" CssClass="regtext" ErrorMessage="Invalid Max Assignment Date"
				Type="Date" MaximumValue="12/12/2900" MinimumValue="1/1/1900" ControlToValidate="txtMaxAssignmentDate">*</asp:rangevalidator></TD>
	</TR>
	<TR>
		<TD><asp:label id="Label5" runat="server" CssClass="regtext">Resolution Description:</asp:label>&nbsp;<asp:textbox id="txtResolutionDescription" runat="server" CssClass="regtext" Width="440px" tabIndex="8"></asp:textbox></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 8px"><asp:button id="btnSearch" runat="server" CssClass="regtext" Text="Search" tabIndex="10" OnClick="btnSearch_Click2"></asp:button>&nbsp;
			<asp:button id="btnRest" runat="server" CssClass="regtext" Text="Reset" tabIndex="11"></asp:button></TD>
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
		<TD colSpan="2">
			<asp:datagrid id="Datagrid2" CssClass="regtext" runat="server" Width="100%" AutoGenerateColumns="False"
				AllowSorting="True" ShowFooter="True" tabIndex="12" AllowPaging="True" OnPageIndexChanged="Datagrid2_PageIndexChanged" PageSize="50">
				<FooterStyle Font-Bold="True" BackColor="#FEFEFE"></FooterStyle>
				<ItemStyle Wrap="False"></ItemStyle>
				<Columns>
					<asp:TemplateColumn SortExpression="Incident_Number" HeaderText="Incident #">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:LinkButton id=lkbtnPermitNumber CssClass="reglinksbold" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IncidentNumber") %>' Font-Bold="True" CommandName="Edit">
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
					<asp:TemplateColumn HeaderText="Catagory">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id=lbldgCatagory runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.[Catagory/Question]") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Open Date">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lbldgOpenDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.[Open Date]") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Department">
						<ItemTemplate>
							<asp:Label id="lbldgDepartment" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Department") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Division">
						<ItemTemplate>
							<asp:Label id="lbldgDivision" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Division") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
                <PagerStyle Mode="NumericPages" />
			</asp:datagrid></TD>
	</TR>
</TABLE>

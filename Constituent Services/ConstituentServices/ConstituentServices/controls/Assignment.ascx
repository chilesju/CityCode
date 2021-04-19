<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Assignment.ascx.cs" Inherits="Constituent_Services.controls.Assignment" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ implements interface="Constituent_Services.controls.IIncidentTab" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<script language="javascript" src="JScript.js" type="text/javascript"></script>
	<TR>
		<TD><asp:label id="lblDateResponded" CssClass="regtext" runat="server">Assignment Last Updated:</asp:label></TD>
	</TR>
	<TR>
		<TD><asp:label id="Label11" CssClass="regtext" runat="server">Department</asp:label><asp:dropdownlist id="departmentList1" CssClass="regtext" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;<asp:label id="Label15" CssClass="regtext" runat="server">Division</asp:label><asp:dropdownlist id="divisionList" CssClass="regtext" runat="server"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD><asp:button id="btnReassign" runat="server" Text="Reassign Call"></asp:button></TD>
	</TR>
	<TR>
		<TD><asp:label id="lblAssignmentMessage" CssClass="regtext" runat="server" Visible="False" ForeColor="Red"> --No assignments--</asp:label></TD>
	</TR>
	<TR>
		<TD>
			<asp:label id="lblCodeCase" runat="server" CssClass="regtext" Visible="False" Font-Bold="True">Case number that is associated with this Incident: </asp:label>
			<asp:textbox id="txtCaseNumber" runat="server" CssClass="regtext" Visible="False"></asp:textbox>&nbsp;</TD>
	</TR>
	<TR>
		<TD>
			<asp:button id="btnAddCase" runat="server" CssClass="regtext" Text="Add Case to Incident" Visible="False"></asp:button>&nbsp;
			<asp:button id="btnRemove" runat="server" CssClass="regtext" Text="Remove Case From Incident"
				Visible="False" Enabled="False"></asp:button></TD>
	</TR>
	<TR>
		<TD>
			<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder></TD>
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
		<TD><asp:label id="Label18" CssClass="regtext" runat="server">New Comments (Note: Limit your comments to under 7000 characters)</asp:label></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 36px"><asp:textbox id="txtComment" CssClass="regtext" runat="server" Height="51px" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
	</TR>
	<TR>
		<TD><asp:button id="btnNewComment" runat="server" Text="Add a new comment to resolution"></asp:button><SPAN style="FONT-SIZE: 12pt; FONT-FAMILY: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"></SPAN></TD>
	</TR>
	<TR>
		<TD><asp:label id="Label2" CssClass="regtext" runat="server">Resolution History:</asp:label>
			<asp:Label id="lblErrorMessage" CssClass="regtext" runat="server" ForeColor="Red"></asp:Label></TD>
	</TR>
	<TR>
		<TD><asp:datagrid id="dgComments" CssClass="regtext" runat="server" AutoGenerateColumns="False">
				<Columns>
					<asp:TemplateColumn HeaderText="ID">
						<ItemTemplate>
							<asp:Label id=lblCommentId runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.ID")) %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Comment">
						<HeaderStyle Wrap="False"></HeaderStyle>
						<ItemTemplate>
							<asp:LinkButton id=lblComment runat="server" Text='<%#FormatString((DataBinder.Eval(Container, "DataItem.Comment"))) %>' CommandName="Edit">
							</asp:LinkButton>
						</ItemTemplate>
						<FooterStyle Wrap="False"></FooterStyle>
						<EditItemTemplate>
							<asp:TextBox id=txtEditCommet runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.Comment")) %>' Height="105px" Width="492px" TextMode="MultiLine">
							</asp:TextBox>
							<asp:Button id="btnModify" runat="server" Text="Modify" CommandName="Update"></asp:Button>
							<asp:Button id="btnCancel" runat="server" Text="Cancel" CommandName="Cancel"></asp:Button>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Date Entered">
						<ItemStyle Wrap="False"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblDateEntered" runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.Date Entered")) %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="User">
						<ItemTemplate>
							<asp:Label id="lblUser" runat="server" Text='<%#(DataBinder.Eval(Container, "DataItem.User")) %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></TD>
	</TR>
</TABLE>

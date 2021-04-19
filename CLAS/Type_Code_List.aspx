<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page language="c#" Codebehind="Type_Code_List.aspx.cs" AutoEventWireup="false" Inherits="CLAS.Type_Code_List" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<title>CLAS- License Type Listing</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<style type="text/css">.style1 { FONT-SIZE: 12px }
	</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<table cellSpacing="1" cellPadding="1" width="760" align="center" border="0">
					<tr>
						<td height="23"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td>
							<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
								<tr>
									<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td bgColor="#f5f5f5" colSpan="1" height="42" rowSpan="1">
							<div align="center"><FONT class="regtext"><B>The Type Code Listing</B> page allows for 
									viewing of a list of all the license type codes currently entered in the 
									system. From the list to the right, users are able to view type codes to make 
									modifications or add new type codes.</FONT></div>
						</td>
					</tr>
					<tr>
						<td>
							<div align="center"><IMG height="40" src="images\type_code_listing.gif" width="392"></div>
						</td>
					</tr>
					<tr>
						<td height="549">
							<div align="center"><asp:datagrid id="DataGrid1" runat="server" PageSize="20" AllowPaging="True" AutoGenerateColumns="False"
									AllowSorting="True" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None"
									BorderColor="#999999" Width="435px" CssClass="regtext">
									<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
									<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#4D96B0"></HeaderStyle>
									<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
									<Columns>
										<asp:TemplateColumn HeaderText="Edit">
											<ItemTemplate>
												<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="images\icon-pencil.gif" CommandName="Edit"></asp:ImageButton>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="License Name">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:Label id=lblLicenseType runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LicenseName") %>'>
												</asp:Label>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
								</asp:datagrid></div>
						</td>
					</tr>
					<TR>
						<TD height="9"><asp:button id="btnAddNewType" runat="server" Text="Add New Type Code" CssClass="regtext"></asp:button></TD>
					</TR>
					<tr>
						<td>
							<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
								<tr>
									<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td><uc1:footer id="Footer1" runat="server"></uc1:footer>&nbsp;</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>

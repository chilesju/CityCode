<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page language="c#" Codebehind="License Search.aspx.cs" AutoEventWireup="false" Inherits="CLAS.License_Search" %>
<HTML>
	<HEAD>
		<title>License Search</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	</HEAD>
	<BODY bgColor="white">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="1" cellPadding="2" width="760" align="center" bgColor="#ffffff"
				border="0">
				<TR bgColor="#ffffff">
					<TD colSpan="4" height="15"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="white" colSpan="4" height="10">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffff" colSpan="4" height="18"><asp:label id="Label2" runat="server" Font-Size="Smaller" Font-Bold="True" CssClass="regtext">Easy Search</asp:label></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffff" colSpan="4" height="26"><asp:textbox id="txtEasySearch" runat="server" Width="216px" CssClass="Textbox"></asp:textbox>&nbsp;
						<asp:button id="btnEasySearch" runat="server" Text="Easy Search" CssClass="regtext"></asp:button></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="white" colSpan="4" height="10">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD height="29" noWrap>
						<asp:label id="lblLicNum" runat="server" CssClass="regtext">License #</asp:label></TD>
					<TD bgColor="#ffffff" height="29">
						<asp:textbox id="txtLicNo" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD bgColor="#ffffff" height="29" noWrap>
						<asp:label id="lblType" runat="server" CssClass="regtext">Type:</asp:label></TD>
					<TD bgColor="white" height="29">
						<asp:dropdownlist id="licenseTypeList" runat="server" Font-Size="Smaller" CssClass="regtext" Width="200px"></asp:dropdownlist>
					</TD>
				</TR>
				<TR>
					<TD height="17">
						<asp:label id="lblLicSt" runat="server" CssClass="regtext">Status:</asp:label></TD>
					<TD bgColor="#ffffff" height="17">
						<asp:dropdownlist id="statusList" runat="server" CssClass="regtext">
							<asp:ListItem Value="None">--Do Not Use--</asp:ListItem>
							<asp:ListItem Value="ACTIVE">ACTIVE</asp:ListItem>
							<asp:ListItem Value="SURRENDER">SURRENDER</asp:ListItem>
							<asp:ListItem Value="REVOKED">REVOKED</asp:ListItem>
							<asp:ListItem Value="EXPIRED">EXPIRED</asp:ListItem>
							<asp:ListItem Value="PENDING">PENDING</asp:ListItem>
							<asp:ListItem Value="DELETED">DELETED</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD bgColor="#ffffff" height="17" noWrap>
						<asp:label id="lblChNum" runat="server" CssClass="regtext">Check Number:</asp:label></TD>
					<TD bgColor="#ffffff" height="17">
						<asp:textbox id="txtCheckNu" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD height="29">
						<asp:label id="lblAppaName" runat="server" CssClass="regtext">Applicants Name:</asp:label></TD>
					<TD bgColor="#ffffff" height="29">
						<asp:textbox id="txtAppName" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
					<TD bgColor="#ffffff" height="29">
						<asp:label id="lblLicName" runat="server" CssClass="regtext">Licensee Name:</asp:label>
					</TD>
					<TD bgColor="#ffffff" height="29">
						<asp:textbox id="txtLicName" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD height="25">
						<asp:label id="lblOwName" runat="server" CssClass="regtext">Owner Name:</asp:label></TD>
					<TD bgColor="#ffffff" height="25">
						<asp:textbox id="txtOwName" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
					<TD bgColor="#ffffff" height="25">
						<asp:label id="lblBusName" runat="server" CssClass="regtext">Business Name:</asp:label>
					</TD>
					<TD bgColor="#ffffff" height="25">
						<asp:textbox id="txtBusName" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD height="28" noWrap>
						<asp:label id="lblOwAdd" runat="server" CssClass="regtext">Owner Address:</asp:label></TD>
					<TD bgColor="#ffffff" height="28" noWrap>
						<asp:textbox id="txtOwAdd" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
					<TD bgColor="#ffffff" height="28" noWrap>
						<asp:label id="lblBusAdd" runat="server" CssClass="regtext">Business Address:</asp:label>
					</TD>
					<TD bgColor="#ffffff" height="28">
						<asp:textbox id="txtBusAdd" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD height="6">
						<asp:label id="lblIsuDate" runat="server" CssClass="regtext">Issue Date Range:</asp:label></TD>
					<TD bgColor="#ffffff" height="6" noWrap>
						<asp:textbox id="txtIsuDateOne" runat="server" Width="88px" Height="20px"></asp:textbox>
						<asp:label id="Label11" runat="server" CssClass="smalltext" Height="15px">thru</asp:label>
						<asp:textbox id="txtIsuDateTwo" runat="server" CssClass="regtext" Width="88px"></asp:textbox>
						<A onclick="window.open('','window','height=425,width=420')" href="Calendar.aspx" target="window">
						</A>
					</TD>
					<TD bgColor="#ffffff" height="6" noWrap>
						<asp:label id="lblSsn" runat="server" CssClass="regtext" Visible="False" Enabled="False">SSN:</asp:label>
					</TD>
					<TD bgColor="#ffffff" height="6">
						<asp:textbox id="txtSsn" runat="server" CssClass="regtext" Visible="False" Enabled="False"></asp:textbox>
						<A onclick="window.open('','window','height=425,width=420')" href="Calendar.aspx" target="window">
						</A>
					</TD>
				</TR>
				<TR>
					<TD height="23" noWrap>
						<asp:label id="lblPaidDt" runat="server" CssClass="regtext">Paid Date Range:</asp:label></TD>
					<TD bgColor="#ffffff" height="23" noWrap>
						<asp:textbox id="txtPaidDateOne" runat="server" Width="88px"></asp:textbox>
						<asp:label id="Label12" runat="server" CssClass="smalltext">thru</asp:label>
						<asp:textbox id="txtPaidDateTwo" runat="server" CssClass="regtext" Width="88px"></asp:textbox>
						<A onclick="window.open('','window','height=425,width=420')" href="Calendar.aspx" target="window">
						</A>
					</TD>
					<TD bgColor="#ffffff" height="23" noWrap>
						<asp:label id="lblPayType" runat="server" CssClass="regtext">Payment Type:</asp:label>
					</TD>
					<TD bgColor="#ffffff" height="23">
						<asp:dropdownlist id="paymentList" runat="server" CssClass="regtext">
							<asp:ListItem Value="None">--Do Not Use--</asp:ListItem>
							<asp:ListItem Value="Cash">Cash</asp:ListItem>
							<asp:ListItem Value="Check">Check</asp:ListItem>
						</asp:dropdownlist>
						<A onclick="window.open('','window','height=425,width=420')" href="Calendar.aspx" target="window">
						</A>
					</TD>
				</TR>
				<TR>
					<TD height="26" noWrap>
						<asp:label id="lblStDate" runat="server" CssClass="regtext">Status Date range:</asp:label></TD>
					<TD bgColor="#ffffff" height="26">
						<asp:textbox id="txtStDateOne" runat="server" CssClass="regtext" Width="88px"></asp:textbox>
						<asp:label id="Label17" runat="server" CssClass="smalltext">thru</asp:label>
						<asp:textbox id="txtStDateTwo" runat="server" CssClass="regtext" Width="88px"></asp:textbox>
						<A onclick="window.open('','window','height=425,width=420')" href="Calendar.aspx" target="window">
						</A>
					</TD>
					<TD bgColor="#ffffff" height="26">
						<asp:label id="lblAcctNum" runat="server" CssClass="regtext">Account Number:</asp:label>
					</TD>
					<TD bgColor="#ffffff" height="26">
						<asp:textbox id="txtAcctNum" runat="server" CssClass="regtext"></asp:textbox>
						<A onclick="window.open('','window','height=425,width=420')" href="Calendar.aspx" target="window">
						</A>
					</TD>
				</TR>
				<TR>
					<TD height="6" noWrap>
						<asp:label id="lblExpDate" runat="server" CssClass="regtext">Expire Date Range:</asp:label></TD>
					<TD bgColor="#ffffff" height="6" noWrap>
						<asp:textbox id="txtExpDateOne" runat="server" Width="88px" CssClass="regtext"></asp:textbox>
						<asp:label id="Label5" runat="server" CssClass="smalltext">thru</asp:label>
						<asp:textbox id="txtExpDateTwo" runat="server" Width="88px" CssClass="regtext"></asp:textbox>
						<A onclick="window.open('','window','height=425,width=420')" href="Calendar.aspx" target="window">
						</A>
					</TD>
					<TD bgColor="#ffffff" height="6" noWrap>
						<asp:label id="lblDrLic" runat="server" CssClass="regtext" Enabled="False" Visible="False">Driver License:</asp:label>
					</TD>
					<TD bgColor="#ffffff" height="6">
						<asp:textbox id="txtDriLic" runat="server" CssClass="regtext" Visible="False" Enabled="False"></asp:textbox>
						<A onclick="window.open('','window','height=425,width=420')" href="Calendar.aspx" target="window">
						</A>
					</TD>
				</TR>
				<TR>
					<TD height="29">
						<asp:label id="lblLiqLic" runat="server" CssClass="regtext">Liquor License:</asp:label></TD>
					<TD bgColor="#ffffff" height="29" noWrap>
						<asp:textbox id="txtLiqLic" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
					<TD bgColor="#ffffff" height="29" noWrap>
						<asp:label id="lblSalexTax" runat="server" CssClass="regtext">Sales Tax #:</asp:label>
					</TD>
					<TD bgColor="#ffffff" height="29">
						<asp:textbox id="txtSalesTax" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD height="27">
						<asp:label id="lblVin" runat="server" CssClass="regtext">VIN:</asp:label>
					</TD>
					<TD bgColor="#ffffff" height="27" noWrap>
						<asp:textbox id="txtVin" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
					<TD bgColor="#ffffff" height="27" noWrap>
						<asp:label id="lblLegalId" runat="server" CssClass="regtext">Legal ID:</asp:label>
					</TD>
					<TD bgColor="#ffffff" height="27">
						<asp:textbox id="txtLegalId" runat="server" CssClass="regtext"></asp:textbox>
					</TD>
				</TR>
				<TR bgColor="#ffffff">
					<TD colSpan="4" height="24">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD background="images/nav_dotted.gif"><IMG height="6" src="images/vert_spacer.gif" width="20"></TD>
							</TR>
						</TABLE>
						<asp:label id="sortLable" runat="server" Visible="False"></asp:label>
						<asp:label id="SortOrder" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4" height="18">
						<asp:label id="Label4" runat="server" Width="306px" CssClass="regtext"></asp:label>
					</TD>
				</TR>
				<TR bgColor="#ffffff">
					<TD align="center" colSpan="4" height="28">
						<asp:button id="btnSearch" runat="server" Width="96px" Text="Search" CssClass="regtext"></asp:button>&nbsp;&nbsp;
						<asp:button id="btnMailMerge" runat="server" Width="96px" Text="Mail Merge" CssClass="regtext"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnReport" runat="server" Width="96px" Text="Create Report" CssClass="regtext"></asp:button>
					</TD>
				</TR>
				<TR bgColor="#ffffff">
					<TD colSpan="4"></TD>
				</TR>
				<TR bgColor="#ffffff">
					<TD align="center" colSpan="4">
						<asp:datagrid id="DataGrid2" runat="server" Width="728px" CssClass="regtext" AutoGenerateColumns="False"
							AllowSorting="True" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" BackColor="White"
							CellPadding="3" AllowPaging="True" CellSpacing="1" GridLines="None" PageSize="50">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#FBFFDD"></AlternatingItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#E7E7FF" BackColor="#4D96B0"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
							<Columns>
								<asp:TemplateColumn SortExpression="License_Number" HeaderText="License Number">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id=lblLicenseNumber runat="server" Font-Bold="True" Text='<%# DataBinder.Eval(Container, "DataItem.License_Number") %>' CommandName="Edit">
										</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="License Type">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label id=lblTypeCode runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.License_Type") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Applicants_Name" HeaderText="Applicants  Name">
									<ItemTemplate>
										<asp:Label id=Label31 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Applicants_Name") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Issue_Date" HeaderText="Issue Date">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label id=Label3 runat="server" Text='<%# String.Format("{0:d}", DataBinder.Eval(Container, "DataItem.Issue_Date")) %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Experation_Date" HeaderText="Experation Date">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label id=Label30 runat="server" Text='<%# String.Format("{0:d}", DataBinder.Eval(Container, "DataItem.Experation_Date")) %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Status">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										&nbsp;
										<asp:Label id="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Status") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle NextPageText="Next -&gt;" PrevPageText=" &lt;- Previous" HorizontalAlign="Right"
								ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR bgColor="#ffffff">
					<TD colSpan="4">
						<uc1:footer id="Footer1" runat="server"></uc1:footer></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>

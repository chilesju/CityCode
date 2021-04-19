<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page language="c#" Codebehind="View_Document.aspx.cs" AutoEventWireup="false" Inherits="CLAS.ViewDocument" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML xmlns:o>
	<HEAD>
		<title>Reports</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="1" cellPadding="2" width="740" align="center" border="0">
				<tr>
					<td>
						<div align="left"><uc1:header id="Header1" runat="server"></uc1:header></div>
					</td>
				</tr>
				<TR>
					<TD style="HEIGHT: 15px" align="center" colSpan="4">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
					</TD>
				<TR>
					<TD style="HEIGHT: 23px" align="center" colSpan="4"><asp:label id="Label1" runat="server" CssClass="regtext">License Line 1:</asp:label><asp:dropdownlist id="listLicenseLine1" runat="server" CssClass="regtext"></asp:dropdownlist>&nbsp;<asp:label id="Label29" runat="server" CssClass="regtext">Small Certify:</asp:label><asp:dropdownlist id="listSmallCertify" runat="server" CssClass="regtext"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" align="center" colSpan="4"><asp:label id="Label2" runat="server" CssClass="regtext">License Line 2:</asp:label><asp:dropdownlist id="listLicenseLine2" runat="server" CssClass="regtext"></asp:dropdownlist>&nbsp;<asp:label id="Label33" runat="server" CssClass="regtext">Recived From:</asp:label><asp:dropdownlist id="listRecivedFrom" runat="server" CssClass="regtext"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="center" colSpan="4"><asp:label id="Label12" runat="server" CssClass="regtext">Licnese Line 3:</asp:label><asp:dropdownlist id="listLicenseLine3" runat="server" CssClass="regtext"></asp:dropdownlist>&nbsp;<asp:label id="Label30" runat="server" CssClass="regtext">Mail Address Name:</asp:label><asp:dropdownlist id="listMailAddressName" runat="server" CssClass="regtext"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="center" colSpan="4"><asp:label id="Label13" runat="server" CssClass="regtext">Legal Requirements:</asp:label><asp:textbox id="txtLegalReq" runat="server" CssClass="regtext"></asp:textbox>&nbsp;<asp:label id="Label31" runat="server" CssClass="regtext">Mail Address Street:</asp:label><asp:dropdownlist id="listMailAddressStreet" runat="server" CssClass="regtext"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" align="center" colSpan="4"><asp:label id="Label14" runat="server" CssClass="regtext">Authorized:</asp:label><asp:textbox id="txtAuthorized" runat="server" CssClass="regtext"></asp:textbox>&nbsp;<asp:label id="Label32" runat="server" CssClass="regtext">Mail Adress City/St/Zip:</asp:label><asp:dropdownlist id="listMailCityStZip" runat="server" CssClass="regtext"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" align="center">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="560" border="0">
							<TR>
								<TD style="WIDTH: 245px"><A href="/CLAS/Type_Code_List.aspx">
										<DIV ms_positioning="FlowLayout" class="reglinks">..Back to License Type..</DIV>
									</A>
								</TD>
								<TD style="WIDTH: 118px"><asp:button id="btnUpdate" runat="server" Width="104px" Text="Update" CssClass="regtext"></asp:button></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" align="center" colSpan="4">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
						<asp:label id="lblType" runat="server" CssClass="largetext"></asp:label></TD>
				<TR>
				</TR>
			</table>
			<table cellSpacing="1" cellPadding="2" width="740" align="center" border="0">
				<tr>
					<td vAlign="top" colSpan="2">
						<table cellSpacing="3" cellPadding="2" width="740" align="center" bgColor="#64ad80" border="0">
							<tr>
								<td bgColor="#e9fbed">
									<div align="center">
										<table cellSpacing="1" cellPadding="2" width="100%" align="center" border="0">
											<tr>
												<td colSpan="2">
													<h3 align="center">City Of Topeka, Kansas<br>
														License</h3>
													<div align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
														This is to certify 
														that&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;License No.
														<asp:label id="lblLicenseNo" runat="server" CssClass="regtext">Label</asp:label></div>
												</td>
											</tr>
											<tr>
												<td colSpan="2"><strong>
														<DIV align="center"><asp:label id="lblLicenseLine1" runat="server" Width="209px" CssClass="regtext">Label</asp:label><br>
															<asp:label id="lblLicenseLine2" runat="server" Width="205px" Height="12px" CssClass="regtext">Label</asp:label></DIV>
														<DIV align="center"><asp:label id="lblLicenseLine3" runat="server" Width="203px" CssClass="regtext">Label</asp:label></DIV>
													</strong>
												</td>
											</tr>
											<tr>
												<td style="HEIGHT: 20px" colSpan="2">
													<div align="center">
														<HR style="WIDTH: 57.82%; HEIGHT: 2px" align="center" width="57.82%" SIZE="2">
													</div>
												</td>
											</tr>
											<tr>
												<td colSpan="2">
													<div align="center">Having fulfilled the legal requirements for licensure as a<br>
														<asp:label id="lblLealReq" runat="server" Width="329px" CssClass="regtext">Label</asp:label></div>
												</td>
											</tr>
											<tr>
												<td colSpan="2">
													<div align="center">
														<HR style="WIDTH: 57.77%; HEIGHT: 2px" align="center" width="57.77%" SIZE="2">
													</div>
												</td>
											</tr>
											<tr>
												<td style="HEIGHT: 38px" colSpan="2">
													<div align="center">is hereby authorized and licensed to<br>
														<asp:label id="lblAuthorized" runat="server" Width="265px" CssClass="regtext">Label</asp:label></div>
												</td>
											</tr>
											<tr>
												<td colSpan="2">
													<HR style="WIDTH: 59.15%; HEIGHT: 2px" align="center" width="59.15%" SIZE="2">
												</td>
											</tr>
											<tr>
												<td colSpan="2">
													<div align="center">in the City of Topeka, Kansas<br>
														From:
														<asp:label id="lblIssueDate" runat="server" Width="104px" CssClass="regtext">Label</asp:label>To:&nbsp;
														<asp:label id="lblExpirationDate" runat="server" Width="121px" CssClass="regtext">Label</asp:label></div>
												</td>
											</tr>
											<tr>
												<td colSpan="2">
													<HR style="WIDTH: 61.08%; HEIGHT: 2px" align="center" width="61.08%" SIZE="2">
												</td>
											</tr>
											<tr>
												<td colSpan="2">
													<div align="center">both inclusive, subject to the provisions of the city code
													</div>
												</td>
											</tr>
											<tr>
												<td colSpan="2">&nbsp;</td>
											</tr>
											<tr>
												<td width="50%">
													<div align="center">Amount Paid $
														<asp:label id="lblFee" runat="server" CssClass="regtext">Label</asp:label></div>
												</td>
												<td width="50%">
													<div align="center"></div>
												</td>
											</tr>
											<tr>
												<td colSpan="2">
													<div align="right"></div>
												</td>
											</tr>
											<tr>
												<td colSpan="2">
													<table cellSpacing="1" cellPadding="2" width="100%" align="center" border="0">
														<tr>
															<td width="33%">&nbsp;</td>
															<td width="33%">
																<div align="center"><IMG height="88" src="images\seal.gif" width="95" align="center"></div>
															</td>
															<td width="33%">
																<div align="right"><IMG height="24" src="images\Brenda.gif" width="150"><br>
																	Brenda Younger</div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td style="BORDER-RIGHT: green thin solid; BORDER-TOP: green thin solid; BORDER-LEFT: green thin solid; BORDER-BOTTOM: green thin solid"
						vAlign="middle" width="50%" colSpan="1" rowSpan="1">
						<div align="left">
							<table style="WIDTH: 360px; HEIGHT: 231px" cellSpacing="1" cellPadding="2" width="360"
								border="0">
								<tr>
									<td width="95">
										<div align="center"><IMG height="88" src="images\seal.gif" width="95" align="center"></div>
									</td>
									<td vAlign="top" width="398">
										<DIV align="center">City Of Topeka Kansas<br>
											LICENSE<br>
										</DIV>
										<DIV align="center"><br>
											This is to certify that<br>
											<asp:label id="lblSamllCertify" runat="server" Width="203px" Font-Size="Smaller" CssClass="regtext">Label</asp:label></DIV>
										<DIV align="center">is hereby licensed to<br>
											<asp:label id="lblHerbyLicensedTo" runat="server" Width="223px" Font-Size="Smaller" CssClass="regtext">Label</asp:label><br>
											From:
											<asp:label id="lblSmallIssueDate" runat="server" Width="59px" Font-Size="Smaller" CssClass="regtext">Label</asp:label>To:
											<asp:label id="lblSamllExpirationDate" runat="server" Width="105px" Font-Size="Smaller" CssClass="regtext">Label</asp:label><br>
										</DIV>
										<DIV align="center">&nbsp;</DIV>
										<DIV align="center"><IMG height="21" src="images\Brenda.gif" width="150"><br>
											Brenda Younger
										</DIV>
									</td>
								</tr>
							</table>
						</div>
					</td>
					<td style="BORDER-RIGHT: green thin solid; BORDER-TOP: green thin solid; BORDER-LEFT: green thin solid; BORDER-BOTTOM: green thin solid"
						width="50%">
						<DIV align="center">City Of Topeka, Kansas<br>
							RECEIPT<br>
							<br>
							Receipt No:&nbsp;
							<asp:label id="lblReciptNo" runat="server" Width="67px" Font-Size="Smaller" CssClass="regtext">Label</asp:label>Date:
							<asp:label id="lblReceiptIssueDate" runat="server" Width="112px" Font-Size="Smaller" CssClass="regtext">Label</asp:label><br>
							Received From:<br>
							<asp:label id="lblReceivedFrom" runat="server" Width="203px" Font-Size="Smaller" Font-Bold="True"
								CssClass="regtext">Label</asp:label><br>
							<br>
							Mailing Address:<br>
							&nbsp;
							<asp:label id="lblMailAddressLine1" runat="server" Width="203px" Font-Size="Smaller" CssClass="regtext">Label</asp:label></DIV>
						<DIV align="center"><asp:label id="lblmailAddressLine2" runat="server" Width="203px" Font-Size="Smaller" CssClass="regtext">Label</asp:label></DIV>
						<DIV align="center"><asp:label id="lblMailAddressLine3" runat="server" Width="203px" Font-Size="Smaller" CssClass="regtext">Label</asp:label><br>
							<br>
							Amount Paid:&nbsp;
							<asp:label id="lblAmtPaid" runat="server" Width="71px" Font-Size="Smaller" CssClass="regtext">Label</asp:label>Check 
							No:
							<asp:label id="lblCheckNo" runat="server" Width="64px" Font-Size="Smaller" CssClass="regtext">Label</asp:label>Cash
							<asp:label id="lblCash" runat="server" Width="67px" Font-Size="Smaller" CssClass="regtext">Label</asp:label><br>
							<br>
							For:
							<asp:label id="lblReceiptFor" runat="server" Width="203px" Font-Size="Smaller" CssClass="regtext">Label</asp:label></DIV>
					</td>
				</tr>
				<TR>
					<TD style="WIDTH: 359px" vAlign="middle" width="359"></TD>
					<TD width="50%"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" align="center" colSpan="4">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
					</TD>
				<TR>
				<TR>
					<TD vAlign="middle" width="50%" colSpan="2"><uc1:footer id="Footer1" runat="server"></uc1:footer></TD>
				</TR>
			</table>
			<div align="center">
				<p>&nbsp;</p>
			</div>
		</form>
	</body>
</HTML>

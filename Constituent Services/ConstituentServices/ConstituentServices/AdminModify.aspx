<%@ Register TagPrefix="uc1" TagName="adminTabsPlaceHolder1" Src="controls/AdminTabsPlaceHolder.ascx" %>
<%@ Page language="c#" Codebehind="AdminModify.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.Modify" %>
<%@ Register TagPrefix="uc1" TagName="adminHeader" Src="controls/adminHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="controls/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Constituent Services - Modify</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:adminheader id="AdminHeader1" runat="server"></uc1:adminheader>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<tr>
					<td colSpan="2">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="http://www.topeka.org/images/nav_dotted.gif"><IMG height="3" src="http://www.topeka.org/images/spacer.gif" width="20"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<fieldset style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
							DESIGNTIMEDRAGDROP="18">
							<table cellSpacing="1" cellPadding="1" width="100%">
								<TR>
									<TD align="center" colSpan="2" style="HEIGHT: 1px">
										<asp:label id="Label13" runat="server" Font-Bold="True" CssClass="regtext">Status:</asp:label>&nbsp;
										<asp:radiobutton id="rbtnOpen" runat="server" CssClass="regtext" GroupName="Open" Text="Open" AutoPostBack="True"
											Enabled="False" Width="56px"></asp:radiobutton>&nbsp;|
										<asp:radiobutton id="rbtnClosed" runat="server" CssClass="regtext" GroupName="Open" Text="Closed"
											AutoPostBack="True" Enabled="False"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 22px" align="center" colSpan="2">
										<asp:label id="Label10" runat="server" CssClass="regtext" Font-Bold="True">I am requesting this incident to be closed:</asp:label>
										<asp:radiobutton id="rbtnYesClose" runat="server" CssClass="regtext" Text="Yes" GroupName="RequestingClosure"
											Width="56px" AutoPostBack="True"></asp:radiobutton>&nbsp;|
										<asp:radiobutton id="rbtnNoClose" runat="server" CssClass="regtext" Text="No" GroupName="RequestingClosure"
											AutoPostBack="True"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:button id="btnPrint" runat="server" Text="Print Incident"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="regtext"></asp:ValidationSummary></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2" style="HEIGHT: 20px">
										<asp:Label id="lblErrorMessage" runat="server" Visible="False" ForeColor="Red"></asp:Label></TD>
								</TR>
								<tr>
									<td class="regtext" onmouseover="this.style.background='#f5f5f5'" onmouseout="this.style.background='#ffffff'">
										<fieldset style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid">
											<LEGEND class="legend">
												<B>Incident/Constituent Information</B></LEGEND>
											<table width="100%">
												<TR>
													<TD style="WIDTH: 50%"><asp:label id="lblIncidentNumber" runat="server" CssClass="regtext">Incident Number:</asp:label></TD>
													<TD style="WIDTH: 50%"><asp:label id="Label2" runat="server" CssClass="regtext">First Name:</asp:label><asp:textbox id="txtFirstName" runat="server" CssClass="regtext" Enabled="False"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 50%; HEIGHT: 26px"><asp:label id="lblDateSubmitted" runat="server" CssClass="regtext">Date Submitted:</asp:label></TD>
													<TD style="WIDTH: 50%; HEIGHT: 26px"><asp:label id="Label3" runat="server" CssClass="regtext">Last Name:</asp:label><asp:textbox id="txtLastName" runat="server" CssClass="regtext" Enabled="False"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 50%"><asp:label id="lblLastUpdated" runat="server" CssClass="regtext">Incident Last Updated:</asp:label></TD>
													<TD style="WIDTH: 50%"><asp:label id="Label4" runat="server" CssClass="regtext">Phone Number:</asp:label><asp:textbox id="txtPhoneNumber" runat="server" CssClass="regtext" Enabled="False"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 28px">
														<asp:label id="Label7" runat="server" CssClass="regtext">Pending Date:</asp:label>
														<asp:textbox id="txtPendingDate" runat="server" CssClass="regtext"></asp:textbox>
														<asp:RangeValidator id="RangeValidator1" runat="server" CssClass="regtext" ErrorMessage="Invalid Pending Date"
															Type="Date" MaximumValue="12/30/2099" MinimumValue="1/1/1900" ControlToValidate="txtPendingDate">*</asp:RangeValidator></TD>
													<TD style="HEIGHT: 28px"><asp:label id="Label5" runat="server" CssClass="regtext">Email:</asp:label><asp:textbox id="txtEmail" runat="server" CssClass="regtext" Enabled="False"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 9px">
														<asp:label id="Label12" runat="server" CssClass="regtext">Municipal Court Date:</asp:label>
														<asp:textbox id="txtCourtDate" runat="server" CssClass="regtext"></asp:textbox>
														<asp:RangeValidator id="RangeValidator2" runat="server" CssClass="regtext" ErrorMessage="Invalid Court Date"
															Type="Date" MaximumValue="12/12/2099" MinimumValue="1/1/1900" ControlToValidate="txtCourtDate">*</asp:RangeValidator></TD>
													<TD style="HEIGHT: 9px">
														<asp:Label id="lblContactConstituent" runat="server" CssClass="regtext">Contact Constituent:</asp:Label>
														<asp:RadioButton id="rbtnYes" runat="server" CssClass="regtext" Text="Yes" GroupName="contact" EnableViewState="False"></asp:RadioButton>
														<asp:RadioButton id="rbtnNo" runat="server" CssClass="regtext" GroupName="contact" Text="No" EnableViewState="False"></asp:RadioButton></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 24px">
														<asp:label id="lblInsertedBy" runat="server" CssClass="regtext">Inserted By:</asp:label></TD>
													<TD style="HEIGHT: 24px">
														<asp:Label id="Label9" runat="server" CssClass="regtext">Has The Constituent been contacted:</asp:Label>
														<asp:RadioButton id="rbtnCityContactedYes" runat="server" CssClass="regtext" Text="Yes" GroupName="citycontact"></asp:RadioButton>
														<asp:RadioButton id="rbtnCityContactedNo" runat="server" CssClass="regtext" Text="No" GroupName="citycontact"></asp:RadioButton></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 50%; HEIGHT: 15px"></TD>
													<TD style="WIDTH: 50%; HEIGHT: 15px">
														<asp:label id="Label11" runat="server" CssClass="regtext">Council Dist:</asp:label>assignmentCol
														<asp:dropdownlist id="councilDistList" runat="server"></asp:dropdownlist></TD>
												</TR>
											</table>
										</fieldset>
									</td>
								</tr>
								<tr>
									<td class="regtext" onmouseover="this.style.background='#f5f5f5'" onmouseout="this.style.background='#ffffff'"
										width="100%" colSpan="2">
										<fieldset style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid">
											<LEGEND class="legend">
												<B>Incident Description</B></LEGEND>
											<table cellSpacing="1" cellPadding="1" width="100%">
												<TR>
													<TD colSpan="2"><asp:label id="lblProblemType" runat="server" CssClass="regtext">Problem Type:</asp:label><asp:dropdownlist id="problemTypeList" runat="server" CssClass="regtext"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 26px" colSpan="2"><asp:label id="Label8" runat="server" CssClass="regtext">Address:</asp:label><asp:textbox id="txtAddress" runat="server" CssClass="regtext" Width="448px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD colSpan="2"><asp:label id="Label6" runat="server" CssClass="regtext"> Description</asp:label></TD>
												</TR>
												<TR>
													<TD colSpan="2"><asp:textbox id="txtIncidentDescription" runat="server" CssClass="regtext" Width="100%" Height="71px"
															TextMode="MultiLine"></asp:textbox></TD>
												</TR>
											</table>
										</fieldset>
									</td>
								</tr>
								<TR>
									<TD style="HEIGHT: 6px" align="left" colSpan="2"><asp:button id="btnUpdate" runat="server" Text="Update Incident Information"></asp:button></TD>
								</TR>
							</table>
						</fieldset>
					</td>
				</tr>
				<tr>
					<td class="regtext" width="100%" colSpan="2" onmouseover="this.style.background='#f5f5f5'"
						onmouseout="this.style.background='#ffffff'">
						<fieldset style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid">
							<LEGEND class="legend">
								<B>Assignment Information</B></LEGEND>
							<table cellSpacing="1" cellPadding="1" width="100%">
								<TR>
									<TD colSpan="2"><uc1:admintabsplaceholder1 id="adminTabsPlaceHolder1" runat="server"></uc1:admintabsplaceholder1></TD>
								</TR>
							</table>
						</fieldset>
					</td>
				</tr>
			</TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>

<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Page language="c#" Codebehind="Enter_New_License.aspx.cs" AutoEventWireup="false" Inherits="CLAS.New_License1" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CLAS- Enter License</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="760" align="center" border="0">
				<TR>
					<TD style="align: 'center'" colSpan="5"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" align="center" colSpan="4">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
						<asp:label id="Label1" runat="server" Visible="False">Label</asp:label></TD>
				<TR>
					<TD class="regtext" style="vAlign: 'middle'" align="center" bgColor="#f5f6f5" colSpan="4"><FONT face="Verdana, Arial, Helvetica" color="#ff0000" size="2"><B><I>Step 
									#2&nbsp;</I></B></FONT> <FONT face="Verdana, Arial, Helvetica" color="#000000" size="2">
							Record the details for the new license off of the application form(s). Enter 
							all required fields to the right then click the 'Generate the License' button 
							below the form. </FONT><FONT face="Verdana, Arial, Helvetica" color="red" size="2">
							RED</FONT> <FONT face="Verdana, Arial, Helvetica" color="#000000" size="2">Letters 
							Denote a required field.</FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 30px" align="center" colSpan="4">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
						<asp:label id="lblErrorMessage" runat="server" CssClass="regtext"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap align="center" colSpan="4"><asp:label id="lblTypeOfLicense" runat="server" Font-Bold="True" CssClass="regtext">Creating a license for type:</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 30px" align="center" colSpan="4">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="regtext"></asp:validationsummary></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px" align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validAppName" runat="server" ControlToValidate="txtAppName" Enabled="False"
							ErrorMessage="Applicants Name Required">*</asp:requiredfieldvalidator><asp:label id="lblAppName" runat="server" Font-Bold="True" CssClass="smalltext">Applicant Name:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:textbox id="txtAppName" tabIndex="1" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD align="center" bgColor="#f5f5f5"><asp:radiobutton id="rbtnDba" tabIndex="18" runat="server" Width="64px" Font-Bold="True" GroupName="For"
							Text="DBA" CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnFor" tabIndex="19" runat="server" Font-Bold="True" GroupName="For" Text="FOR"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD bgColor="#f5f5f5" colSpan="1"><asp:radiobutton id="rbtnOwner" tabIndex="20" runat="server" Font-Bold="True" GroupName="Who" Text="OWNER"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnManager" tabIndex="21" runat="server" Font-Bold="True" GroupName="Who" Text="MANAGER"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validLicName" runat="server" ControlToValidate="txtLicName" Enabled="False"
							ErrorMessage="License Name Required">*</asp:requiredfieldvalidator><asp:label id="lblLicName" runat="server" Font-Bold="True" CssClass="smalltext">License Name:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:textbox id="txtLicName" tabIndex="1" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBusName" runat="server" ControlToValidate="txtBusName" Enabled="False"
							ErrorMessage="Business Name Required" CssClass="regtext">*</asp:requiredfieldvalidator><asp:label id="lblBusName" runat="server" Font-Bold="True" CssClass="smalltext">Business Name:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:textbox id="txtBusName" tabIndex="22" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validMailAddress" runat="server" ControlToValidate="txtMailAddress" Enabled="False"
							ErrorMessage="Mailing Address Required">*</asp:requiredfieldvalidator><asp:label id="lblMailAddress" runat="server" Font-Bold="True" CssClass="smalltext">Mailing Address:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:textbox id="txtMailAddress" tabIndex="2" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBusAddress" runat="server" ControlToValidate="txtBusAdd" Enabled="False"
							ErrorMessage="Business Address Required">*</asp:requiredfieldvalidator><asp:label id="lblBusAddress" runat="server" Font-Bold="True" CssClass="smalltext">Business Address:</asp:label></TD>
					<TD style="HEIGHT: 24px" bgColor="#f5f6f5"><asp:textbox id="txtBusAdd" tabIndex="23" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 240px; HEIGHT: 24px" align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validMailState" runat="server" ControlToValidate="txtMailSt" Enabled="False"
							ErrorMessage="Mail State Required">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="validMailCity" runat="server" ControlToValidate="txtMailCity" Enabled="False"
							ErrorMessage="Mail City Required">*</asp:requiredfieldvalidator><asp:label id="lblMailCst" runat="server" Font-Bold="True" CssClass="smalltext">Mailing City/St:</asp:label></TD>
					<TD style="HEIGHT: 24px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtMailCity" tabIndex="3" runat="server" Width="88px" CssClass="regtext"></asp:textbox><font class="smalltext">,</font><asp:textbox id="txtMailSt" tabIndex="4" runat="server" Width="48px" CssClass="regtext"></asp:textbox></TD>
					<TD style="HEIGHT: 24px" noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBusCity" runat="server" ControlToValidate="txtBusCity" Enabled="False"
							ErrorMessage="Business City Required" CssClass="regtext">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="validBusSt" runat="server" ControlToValidate="txtBusSt" Enabled="False" ErrorMessage="Business State Required"
							CssClass="regtext">*</asp:requiredfieldvalidator><asp:label id="lblBusCst" runat="server" Font-Bold="True" CssClass="smalltext">Business City/St:</asp:label></TD>
					<TD style="HEIGHT: 24px" bgColor="#f5f6f5"><asp:textbox id="txtBusCity" tabIndex="24" runat="server" Width="87px" CssClass="regtext"></asp:textbox><font class="smalltext">,</font><asp:textbox id="txtBusSt" tabIndex="25" runat="server" Width="46px" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px" noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validMailZip" runat="server" ControlToValidate="txtMailZip" Enabled="False"
							ErrorMessage="Mailing Zip Required">*</asp:requiredfieldvalidator><asp:label id="lblMailZip" runat="server" Font-Bold="True" CssClass="smalltext">Mailing Zip:</asp:label></TD>
					<TD style="HEIGHT: 25px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtMailZip" tabIndex="5" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD style="HEIGHT: 25px" align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBusZip" runat="server" ControlToValidate="txtBusZip" Enabled="False" ErrorMessage="Business Zip Required"
							CssClass="regtext">*</asp:requiredfieldvalidator><asp:label id="lblBusZip" runat="server" Font-Bold="True" CssClass="smalltext">Business Zip:</asp:label></TD>
					<TD style="HEIGHT: 25px" bgColor="#f5f6f5"><asp:textbox id="txtBusZip" tabIndex="26" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validOwName" runat="server" ControlToValidate="txtOwName" Enabled="False" ErrorMessage="Owner Name Required">*</asp:requiredfieldvalidator><asp:label id="lblOwName" runat="server" Font-Bold="True" CssClass="smalltext">Owner Name:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:textbox id="txtOwName" tabIndex="6" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBusPhone" runat="server" ControlToValidate="txtBusPhone" Enabled="False"
							ErrorMessage="Business Phone Required" CssClass="regtext">*</asp:requiredfieldvalidator><asp:label id="lblBusPhone" runat="server" Width="102px" Font-Bold="True" CssClass="smalltext"> Business Phone:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:textbox id="txtBusPhone" tabIndex="27" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 240px; HEIGHT: 21px" align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validOwAddress" runat="server" ControlToValidate="txtOwAddress" Enabled="False"
							ErrorMessage="Owner Address Required">*</asp:requiredfieldvalidator><asp:label id="lblOwAddress" runat="server" Font-Bold="True" CssClass="smalltext">Owner Address:</asp:label></TD>
					<TD noWrap bgColor="#f5f6f5"><asp:textbox id="txtOwAddress" tabIndex="7" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validSsn" runat="server" ControlToValidate="txtSsn" Enabled="False" ErrorMessage="SSN  Required"
							CssClass="regtext" Visible="False">*</asp:requiredfieldvalidator><asp:label id="lblSsn" runat="server" Font-Bold="True" CssClass="smalltext" Visible="False"
							Enabled="False">SSN:</asp:label></TD>
					<TD style="HEIGHT: 21px" bgColor="#f5f6f5"><asp:textbox id="txtSsn" tabIndex="28" runat="server" CssClass="regtext" Visible="False" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validOwCity" runat="server" ControlToValidate="txtOwCity" Enabled="False" ErrorMessage="Owner City Required">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="validOwSt" runat="server" ControlToValidate="txtOwSt" Enabled="False" ErrorMessage="Owner State Required">*</asp:requiredfieldvalidator><asp:label id="lblOwCST" runat="server" Font-Bold="True" CssClass="smalltext">Owner City/St:</asp:label></TD>
					<TD class="smalltext" noWrap bgColor="#f5f6f5"><asp:textbox id="txtOwCity" tabIndex="8" runat="server" Width="88px" CssClass="regtext"></asp:textbox><font class="smalltext">,</font>
						<asp:textbox id="txtOwSt" tabIndex="9" runat="server" Width="40px" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validDriverLic" runat="server" ControlToValidate="txtDriverLic" Enabled="False"
							ErrorMessage="Deivers License Required" CssClass="regtext" Visible="False">*</asp:requiredfieldvalidator><asp:label id="lblDrLic" runat="server" Font-Bold="True" CssClass="smalltext" Visible="False"
							Enabled="False">Driver License:</asp:label></TD>
					<TD style="HEIGHT: 26px" bgColor="#f5f6f5"><asp:textbox id="txtDriverLic" tabIndex="29" runat="server" CssClass="regtext" Visible="False"
							Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" noWrap align="center" bgColor="#f5f6f5" colSpan="1" rowSpan="1"><asp:requiredfieldvalidator id="validOwZip" runat="server" ControlToValidate="txtOwZip" Enabled="False" ErrorMessage="Owner Zip Required">*</asp:requiredfieldvalidator><asp:label id="lblOwZip" runat="server" Font-Bold="True" CssClass="smalltext">Owner Zip:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:textbox id="txtOwZip" tabIndex="10" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validLiqLic" runat="server" ControlToValidate="txtLiqLic" Enabled="False" ErrorMessage="Liquor License Required"
							CssClass="regtext">*</asp:requiredfieldvalidator><asp:label id="lblLiqLic" runat="server" Width="112px" Font-Bold="True" CssClass="smalltext">St. Liquor License:</asp:label></TD>
					<TD style="HEIGHT: 26px" bgColor="#f5f6f5"><asp:textbox id="txtLiqLic" tabIndex="30" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 240px; HEIGHT: 25px" align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validOwPhone" runat="server" ControlToValidate="txtOwPhone" Enabled="False"
							ErrorMessage="Owner Phone Required">*</asp:requiredfieldvalidator><asp:label id="lblOwPhone" runat="server" Font-Bold="True" CssClass="smalltext">Owner Phone:</asp:label></TD>
					<TD noWrap bgColor="#f5f6f5"><asp:textbox id="txtOwPhone" tabIndex="11" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validSalesTax" runat="server" ControlToValidate="txtSalesTax" Enabled="False"
							ErrorMessage="Sales Tax Required">*</asp:requiredfieldvalidator><asp:label id="lblSalesTax" runat="server" Font-Bold="True" CssClass="smalltext">Sales Tax #:</asp:label></TD>
					<TD style="HEIGHT: 25px" bgColor="#f5f6f5"><asp:textbox id="txtSalesTax" tabIndex="31" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 240px; HEIGHT: 19px" align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validZoning" runat="server" ControlToValidate="txtZoning" Enabled="False" ErrorMessage="Zoning Required">*</asp:requiredfieldvalidator><asp:label id="lblZoning" runat="server" Font-Bold="True" CssClass="smalltext">Zoning:</asp:label></TD>
					<TD noWrap bgColor="#f5f6f5"><asp:textbox id="txtZoning" tabIndex="12" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validLeqalId" runat="server" ControlToValidate="txtLegalId" Enabled="False"
							ErrorMessage="Legal Id Required" CssClass="regtext">*</asp:requiredfieldvalidator><asp:label id="lblLegalId" runat="server" Font-Bold="True" CssClass="smalltext">Legal ID #:</asp:label></TD>
					<TD style="HEIGHT: 19px" bgColor="#f5f6f5"><asp:textbox id="txtLegalId" tabIndex="32" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" noWrap align="center" bgColor="#f5f6f5"><asp:label id="lblAcctNum" runat="server" Font-Bold="True" CssClass="smalltext">Account #:</asp:label></TD>
					<TD style="HEIGHT: 27px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtAcctNum" tabIndex="13" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD style="HEIGHT: 27px" noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validVin" runat="server" ControlToValidate="txtVin" Enabled="False" ErrorMessage="Vin Required">*</asp:requiredfieldvalidator><asp:label id="lblVin" runat="server" Width="40px" Font-Bold="True" ForeColor="Black" CssClass="smalltext">VIN:</asp:label></TD>
					<TD style="HEIGHT: 27px" bgColor="#f5f6f5"><asp:textbox id="txtVin" tabIndex="33" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validBondAmt" runat="server" ControlToValidate="txtBondAmt" Enabled="False"
							ErrorMessage="Bond Amount Required">*</asp:requiredfieldvalidator><asp:label id="lblBondAmt" runat="server" Font-Bold="True" CssClass="smalltext">Bond Amount:</asp:label></TD>
					<TD noWrap bgColor="#f5f6f5"><asp:textbox id="txtBondAmt" tabIndex="14" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validInsuDate" runat="server" ControlToValidate="txtInsuDate" Enabled="False"
							ErrorMessage="Insurance Date Required" CssClass="regtext">*</asp:requiredfieldvalidator><asp:label id="lblInsuDate" runat="server" Width="96px" Font-Bold="True" CssClass="smalltext">Insurance Date:</asp:label></TD>
					<TD style="HEIGHT: 26px" bgColor="#f5f6f5"><asp:textbox id="txtInsuDate" tabIndex="34" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 11px" noWrap align="center" bgColor="#f5f6f5"><asp:label id="lblIssueDate" runat="server" Font-Bold="True" CssClass="smalltext">Issue Date:</asp:label></TD>
					<TD style="HEIGHT: 11px" noWrap bgColor="#f5f6f5"><asp:label id="lblDyIssueDate" runat="server" CssClass="regtext">Label</asp:label></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBondDate" runat="server" ControlToValidate="txtBondDate" Enabled="False"
							ErrorMessage="Bond Date Required" CssClass="regtext">*</asp:requiredfieldvalidator><asp:label id="lblBondDate" runat="server" Width="72px" Font-Bold="True" CssClass="smalltext">Bond Date:</asp:label></TD>
					<TD style="HEIGHT: 11px" bgColor="#f5f6f5"><asp:textbox id="txtBondDate" tabIndex="35" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 240px; HEIGHT: 27px" align="center" bgColor="#f5f6f5"><asp:label id="lblDatePaid" runat="server" Width="72px" Font-Bold="True" CssClass="smalltext">Date Paid:</asp:label></TD>
					<TD noWrap bgColor="#f5f6f5"><asp:textbox id="txtDatePaid" tabIndex="15" runat="server" Width="144px" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:label id="lblExpDate" runat="server" Font-Bold="True" CssClass="smalltext">Expire Date:</asp:label></TD>
					<TD style="HEIGHT: 27px" bgColor="#f5f6f5"><asp:textbox id="txtExpDate" tabIndex="36" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:label id="lblPayType" runat="server" Width="64px" Font-Bold="True" CssClass="smalltext">Pay Type:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:dropdownlist id="drplstPayType" tabIndex="16" runat="server" AutoPostBack="True" CssClass="regtext">
							<asp:ListItem Value="CASH">CASH</asp:ListItem>
							<asp:ListItem Value="CHECK">CHECK</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:label id="lblLicFee" runat="server" Font-Bold="True" CssClass="smalltext">Lic Fees:</asp:label></TD>
					<TD style="HEIGHT: 16px" bgColor="#f5f6f5"><asp:textbox id="txtLicFee" tabIndex="37" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:label id="lblEmail" runat="server" Font-Bold="True" CssClass="smalltext">Email Address</asp:label></TD>
					<TD bgColor="#f5f5f5"><asp:textbox id="txtEmailAddress" tabIndex="17" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validCheckNo" runat="server" ControlToValidate="txtCheckNo" Enabled="False"
							ErrorMessage="Need a Check Number" CssClass="regtext">*</asp:requiredfieldvalidator><asp:label id="lblCheckNo" runat="server" Font-Bold="True" CssClass="smalltext">Check No:</asp:label></TD>
					<TD style="HEIGHT: 26px" bgColor="#f5f6f5"><asp:textbox id="txtCheckNo" tabIndex="38" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" align="center" bgColor="#f5f6f5" colSpan="4"><asp:label id="Label30" runat="server" Font-Bold="True" CssClass="smalltext">Notes Regarding the License:</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center" bgColor="#f5f6f5" colSpan="4"><asp:textbox id="txtNotes" tabIndex="39" runat="server" Width="608px" Height="68px" TextMode="MultiLine"
							CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px; colSpan: '4'" align="center" colSpan="4"><asp:button id="btnGenerateLicense" tabIndex="40" runat="server" Text="Insert the License" CssClass="regtext"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnInsertPending" runat="server" Visible="False" Enabled="False" Text="Insert Pending License"
							CssClass="regtext"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnPrint" runat="server" Enabled="False" Text="Print License" CssClass="regtext"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 45px" colSpan="4">
						<TABLE cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TR>
								<TD background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="align: 'center'" colSpan="4"><uc1:footer id="Footer1" runat="server"></uc1:footer></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

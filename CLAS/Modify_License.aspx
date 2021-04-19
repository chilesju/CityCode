<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Page language="c#" Codebehind="Modify_License.aspx.cs" AutoEventWireup="false" Inherits="CLAS.Modify_Licnese" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Modify License</title>
		<script language="javascript" src="script.js" type="text/javascript"></script>
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
					<TD style="HEIGHT: 7px" align="center" colSpan="4">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
						<asp:label id="licenseType" runat="server" Visible="False" Enabled="False"></asp:label><asp:label id="lblStatus" runat="server" Visible="False"></asp:label><asp:label id="lblFirstIssueDate" runat="server" Visible="False" Enabled="False">Label</asp:label>&nbsp;
						<asp:textbox id="txtRenew" runat="server" BorderStyle="None" ReadOnly="True" Width="1px"></asp:textbox>&nbsp;
						<asp:label id="lblCheckPostBack" runat="server" Visible="False" Enabled="False">false</asp:label>&nbsp;
						<asp:textbox id="txtStatus" runat="server" BorderStyle="None" ReadOnly="True" Width="1px"></asp:textbox></TD>
				<TR>
					<TD style="vAlign: 'middle'" align="center" bgColor="#f5f6f5" colSpan="4"><font class="regtext">Updates 
							the license</font> <FONT class="regtext" color="#000000">off of the application 
							form(s). Enter all required fields to the right then click the 'Update the 
							License' button below the form. </FONT><FONT color="red">RED</FONT> <FONT class="regtext" color="#000000">
							letters denote a required field.</FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 30px" align="center" colSpan="4">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
						<asp:label id="lblErrorMessage" runat="server" Width="112px" CssClass="regtext"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 6px" align="center" colSpan="4"><asp:label id="lblLicense" runat="server" CssClass="largetext" Font-Bold="True"> License:</asp:label></TD>
				</TR>
				<TR>
					<TD noWrap align="center" colSpan="4">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="regtext"></asp:validationsummary></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">&nbsp;
						<asp:button id="btnRevoke" runat="server" CssClass="regtext" Text="Revoke"></asp:button>&nbsp;
						<asp:button id="btnSurrender" runat="server" CssClass="regtext" Text="Surrender"></asp:button>&nbsp;
						<asp:button id="btnDelete" runat="server" CssClass="regtext" Text="Delete"></asp:button>&nbsp;&nbsp;
						<asp:button id="btnActivate" runat="server" CssClass="regtext" Text="Activate"></asp:button>&nbsp;
						<asp:button id="btnRenew" runat="server" CssClass="regtext" Text="Renew" CausesValidation="False"></asp:button>
						<HR width="100%" SIZE="1">
						<asp:button id="btnUpdateLicense" tabIndex="41" runat="server" CssClass="regtext" Text="Update"></asp:button>&nbsp;
						<asp:button id="btnPrint" runat="server" Enabled="False" CssClass="regtext" Text="Reprint Report"></asp:button></TD>
				</TR>
				<tr>
					<td style="HEIGHT: 5px" background="images/nav_dotted.gif" colSpan="4"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
				</tr>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validAppName" runat="server" Enabled="False" ControlToValidate="txtAppName"
							ErrorMessage="Applicants Name Required">*</asp:requiredfieldvalidator><asp:label id="lblAppName" runat="server" CssClass="smalltext" Font-Bold="True">Applicant Name:</asp:label></TD>
					<TD style="WIDTH: 178px" bgColor="#f5f6f5"><asp:textbox id="txtAppName" tabIndex="1" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:radiobutton id="rbtnDba" tabIndex="19" runat="server" CssClass="smalltext" Font-Bold="True"
							Text="DBA" GroupName="For"></asp:radiobutton><asp:radiobutton id="rbtnFor" tabIndex="20" runat="server" CssClass="smalltext" Font-Bold="True"
							Text="For" GroupName="For"></asp:radiobutton></TD>
					<TD bgColor="#f5f5f5" colSpan="1"><asp:radiobutton id="rbtnOwner" tabIndex="21" runat="server" CssClass="smalltext" Font-Bold="True"
							Text="Owner" GroupName="Who"></asp:radiobutton><asp:radiobutton id="rbtnManager" tabIndex="22" runat="server" CssClass="smalltext" Font-Bold="True"
							Text="Manager" GroupName="Who"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validLicName" runat="server" Enabled="False" ControlToValidate="txtLicName"
							ErrorMessage="License Name Required">*</asp:requiredfieldvalidator><asp:label id="lblLicName" runat="server" CssClass="smalltext" Font-Bold="True">License Name:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:textbox id="txtLicName" tabIndex="2" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD style="HEIGHT: 21px" noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBusName" runat="server" Enabled="False" ControlToValidate="txtBusName"
							ErrorMessage="Business Name Required">*</asp:requiredfieldvalidator><asp:label id="lblBusName" runat="server" CssClass="smalltext" Font-Bold="True">Business Name:</asp:label></TD>
					<TD style="HEIGHT: 21px" bgColor="#f5f6f5"><asp:textbox id="txtBusName" tabIndex="23" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validMailAddress" runat="server" Enabled="False" ControlToValidate="txtMailAddress"
							ErrorMessage="Mailing Address Required">*</asp:requiredfieldvalidator><asp:label id="lblMailAddress" runat="server" CssClass="smalltext" Font-Bold="True">Mailing Address:</asp:label></TD>
					<TD style="WIDTH: 178px; HEIGHT: 26px" bgColor="#f5f6f5"><asp:textbox id="txtMailAddress" tabIndex="3" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD style="HEIGHT: 26px" align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBusAddress" runat="server" Enabled="False" ControlToValidate="txtBusAdd"
							ErrorMessage="Business Address Required">*</asp:requiredfieldvalidator><asp:label id="lblBusAddress" runat="server" CssClass="smalltext" Font-Bold="True">Business Address:</asp:label></TD>
					<TD style="HEIGHT: 26px" bgColor="#f5f6f5"><asp:textbox id="txtBusAdd" tabIndex="24" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validMailState" runat="server" ControlToValidate="txtMailSt" ErrorMessage="Mail State Required">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="validMailCity" runat="server" ControlToValidate="txtMailCity" ErrorMessage="Mail City Required">*</asp:requiredfieldvalidator><asp:label id="lblMailCst" runat="server" Width="120px" CssClass="smalltext" Font-Bold="True">Mailing City/St:</asp:label></TD>
					<TD style="WIDTH: 178px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtMailCity" tabIndex="4" runat="server" Width="96px" CssClass="regtext"></asp:textbox><font class="smalltext">,</font><asp:textbox id="txtMailSt" tabIndex="5" runat="server" Width="48px" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBusCity" runat="server" Enabled="False" Width="16px" ControlToValidate="txtBusCity"
							ErrorMessage="Business City Required">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="validBusSt" runat="server" Enabled="False" ControlToValidate="txtBusSt" ErrorMessage="Business State Required">*</asp:requiredfieldvalidator><asp:label id="lblBusCst" runat="server" CssClass="smalltext" Font-Bold="True">Business City/St:</asp:label></TD>
					<TD style="HEIGHT: 25px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtBusCity" tabIndex="25" runat="server" Width="85px" CssClass="regtext"></asp:textbox><font class="smalltext">,</font><asp:textbox id="txtBusSt" tabIndex="26" runat="server" Width="59px" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validMailZip" runat="server" Enabled="False" ControlToValidate="txtMailZip"
							ErrorMessage="Mailing Zip Required">*</asp:requiredfieldvalidator><asp:label id="lblMailZip" runat="server" CssClass="smalltext" Font-Bold="True">Mailing Zip:</asp:label></TD>
					<TD style="WIDTH: 178px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtMailZip" tabIndex="6" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBusZip" runat="server" Enabled="False" ControlToValidate="txtBusZip" ErrorMessage="Business Zip Required">*</asp:requiredfieldvalidator><asp:label id="lblBusZip" runat="server" CssClass="smalltext" Font-Bold="True">Business Zip:</asp:label></TD>
					<TD style="HEIGHT: 25px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtBusZip" tabIndex="27" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validOwName" runat="server" Enabled="False" ControlToValidate="txtOwName" ErrorMessage="Owner Name Required">*</asp:requiredfieldvalidator><asp:label id="lblOwName" runat="server" CssClass="smalltext" Font-Bold="True">Owner Name:</asp:label></TD>
					<TD style="WIDTH: 178px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtOwName" tabIndex="7" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBusPhone" runat="server" Enabled="False" ControlToValidate="txtBusPhone"
							ErrorMessage="Business Phone Required">*</asp:requiredfieldvalidator><asp:label id="lblBusPhone" runat="server" CssClass="smalltext" Font-Bold="True"> Business Phone:</asp:label></TD>
					<TD style="HEIGHT: 25px" bgColor="#f5f6f5"><asp:textbox id="txtBusPhone" tabIndex="28" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validOwAddress" runat="server" Enabled="False" ControlToValidate="txtOwAddress"
							ErrorMessage="Owner Address Required">*</asp:requiredfieldvalidator><asp:label id="lblOwAddress" runat="server" CssClass="smalltext" Font-Bold="True">Owner Address:</asp:label></TD>
					<TD style="WIDTH: 178px; HEIGHT: 21px" bgColor="#f5f6f5"><asp:textbox id="txtOwAddress" tabIndex="8" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:label id="lblSsn" runat="server" Visible="False" Enabled="False" CssClass="smalltext"
							Font-Bold="True">SSN:</asp:label></TD>
					<TD style="HEIGHT: 21px" bgColor="#f5f6f5"><asp:textbox id="txtSsn" tabIndex="29" runat="server" Visible="False" Enabled="False" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validOwCity" runat="server" Enabled="False" ControlToValidate="txtOwCity" ErrorMessage="Owner City Required">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="validOwSt" runat="server" Enabled="False" ControlToValidate="txtOwSt" ErrorMessage="Owner State Required">*</asp:requiredfieldvalidator><asp:label id="lblOwCST" runat="server" CssClass="smalltext" Font-Bold="True">Owner City/St:</asp:label></TD>
					<TD style="WIDTH: 178px; HEIGHT: 26px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtOwCity" tabIndex="9" runat="server" Width="88px" CssClass="regtext"></asp:textbox><font class="smalltext">,</font>
						<asp:textbox id="txtOwSt" tabIndex="10" runat="server" Width="40px" CssClass="regtext"></asp:textbox></TD>
					<TD style="HEIGHT: 26px" noWrap align="center" bgColor="#f5f5f5"><asp:label id="lblDrLic" runat="server" Visible="False" Enabled="False" CssClass="smalltext"
							Font-Bold="True">Driver License:</asp:label></TD>
					<TD style="HEIGHT: 26px" bgColor="#f5f6f5"><asp:textbox id="txtDriverLic" tabIndex="30" runat="server" Visible="False" Enabled="False" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5" colSpan="1" rowSpan="1"><asp:requiredfieldvalidator id="validOwZip" runat="server" Enabled="False" ControlToValidate="txtOwZip" ErrorMessage="Owner Zip Required">*</asp:requiredfieldvalidator><asp:label id="lblOwZip" runat="server" CssClass="smalltext" Font-Bold="True">Owner Zip:</asp:label></TD>
					<TD style="WIDTH: 178px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtOwZip" tabIndex="11" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validLiqLic" runat="server" Enabled="False" ControlToValidate="txtLiqLic" ErrorMessage="Liquor License Required">*</asp:requiredfieldvalidator><asp:label id="lblLiqLic" runat="server" CssClass="smalltext" Font-Bold="True">St. Liquor License:</asp:label></TD>
					<TD style="HEIGHT: 26px" bgColor="#f5f6f5"><asp:textbox id="txtLiqLic" tabIndex="31" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validOwPhone" runat="server" Enabled="False" ControlToValidate="txtOwPhone"
							ErrorMessage="Owner Phone Required">*</asp:requiredfieldvalidator><asp:label id="lblOwPhone" runat="server" CssClass="smalltext" Font-Bold="True">Owner Phone:</asp:label></TD>
					<TD noWrap bgColor="#f5f6f5"><asp:textbox id="txtOwPhone" tabIndex="12" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validSalesTax" runat="server" Enabled="False" ControlToValidate="txtSalesTax"
							ErrorMessage="Sales Tax Required">*</asp:requiredfieldvalidator><asp:label id="lblSalesTax" runat="server" CssClass="smalltext" Font-Bold="True">Sales Tax #:</asp:label></TD>
					<TD style="HEIGHT: 26px" bgColor="#f5f6f5"><asp:textbox id="txtSalesTax" tabIndex="32" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validZoning" runat="server" Enabled="False" ControlToValidate="txtZoning" ErrorMessage="Zoning Required">*</asp:requiredfieldvalidator><asp:label id="lblZoning" runat="server" CssClass="smalltext" Font-Bold="True">Zoning:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:textbox id="txtZoning" tabIndex="13" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validLeqalId" runat="server" Enabled="False" ControlToValidate="txtLegalId"
							ErrorMessage="Legal Id Required">*</asp:requiredfieldvalidator><asp:label id="lblLegalId" runat="server" CssClass="smalltext" Font-Bold="True">Legal ID #:</asp:label></TD>
					<TD style="HEIGHT: 7px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtLegalId" tabIndex="33" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:label id="lblAcctNum" runat="server" CssClass="smalltext" Font-Bold="True">Account #:</asp:label></TD>
					<TD noWrap bgColor="#f5f6f5"><asp:textbox id="txtAcctNum" tabIndex="14" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validVin" runat="server" Enabled="False" ControlToValidate="txtVin" ErrorMessage="Vin Required">*</asp:requiredfieldvalidator><asp:label id="lblVin" runat="server" CssClass="smalltext" Font-Bold="True" ForeColor="Black">VIN:</asp:label></TD>
					<TD style="HEIGHT: 27px" bgColor="#f5f6f5"><asp:textbox id="txtVin" tabIndex="34" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px" align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="validBondAmt" runat="server" Enabled="False" ControlToValidate="txtBondAmt"
							ErrorMessage="Bond Amount Required">*</asp:requiredfieldvalidator><asp:label id="lblBondAmt" runat="server" CssClass="smalltext" Font-Bold="True">Bond Amount:</asp:label></TD>
					<TD style="HEIGHT: 26px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtBondAmt" tabIndex="15" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD style="HEIGHT: 26px" align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validInsuDate" runat="server" Enabled="False" ControlToValidate="txtInsuDate"
							ErrorMessage="Insurance Date Required">*</asp:requiredfieldvalidator><asp:label id="lblInsuDate" runat="server" CssClass="smalltext" Font-Bold="True">Insurance Date:</asp:label></TD>
					<TD style="HEIGHT: 26px" bgColor="#f5f6f5"><asp:textbox id="txtInsuDate" tabIndex="35" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" noWrap align="center" bgColor="#f5f6f5"><asp:requiredfieldvalidator id="vaildIssueDate" runat="server" Width="14px" ControlToValidate="txtIssueDate"
							ErrorMessage="No Issue Date">*</asp:requiredfieldvalidator><asp:label id="lblIssueDate" runat="server" CssClass="smalltext" Font-Bold="True">Issue Date:</asp:label></TD>
					<TD style="HEIGHT: 27px" noWrap bgColor="#f5f6f5"><asp:textbox id="txtIssueDate" runat="server" ReadOnly="True" CssClass="regtext" AutoPostBack="True"></asp:textbox></TD>
					<TD style="HEIGHT: 27px" align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="validBondDate" runat="server" Enabled="False" ControlToValidate="txtBondDate"
							ErrorMessage="Bond Date Required">*</asp:requiredfieldvalidator><asp:label id="lblBondDate" runat="server" CssClass="smalltext" Font-Bold="True">Bond Date:</asp:label></TD>
					<TD style="HEIGHT: 27px" bgColor="#f5f6f5"><asp:textbox id="txtBondDate" tabIndex="36" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" noWrap align="center" bgColor="#f5f6f5"><asp:label id="lblDatePaid" runat="server" CssClass="smalltext" Font-Bold="True">Date Paid:</asp:label></TD>
					<TD noWrap bgColor="#f5f6f5"><asp:textbox id="txtDatePaid" tabIndex="16" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD style="WIDTH: 163px; HEIGHT: 27px" align="center" bgColor="#f5f5f5"><asp:requiredfieldvalidator id="vaildExpDate" runat="server" Width="14px" ControlToValidate="txtExpDate" ErrorMessage="No Experation Date">*</asp:requiredfieldvalidator><asp:label id="lblExpDate" runat="server" CssClass="smalltext" Font-Bold="True">Expire Date:</asp:label></TD>
					<TD style="HEIGHT: 27px" bgColor="#f5f6f5"><asp:textbox id="txtExpDate" tabIndex="37" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap align="center" bgColor="#f5f6f5"><asp:label id="lblPayType" runat="server" CssClass="smalltext" Font-Bold="True">Pay Type:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:dropdownlist id="drplstPayType" tabIndex="17" runat="server" CssClass="regtext">
							<asp:ListItem Value="CASH">CASH</asp:ListItem>
							<asp:ListItem Value="CHECK">CHECK</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="center" bgColor="#f5f5f5"><asp:label id="lblLicFee" runat="server" CssClass="smalltext" Font-Bold="True">Lic Fees:</asp:label></TD>
					<TD style="HEIGHT: 19px" bgColor="#f5f6f5"><asp:textbox id="txtLicFee" tabIndex="38" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#f5f5f5"><asp:label id="lblEmail" runat="server" CssClass="smalltext" Font-Bold="True">Email Address</asp:label></TD>
					<TD bgColor="#f5f5f5"><asp:textbox id="txtEmailAddress" tabIndex="18" runat="server" CssClass="regtext"></asp:textbox></TD>
					<TD noWrap align="center" bgColor="#f5f5f5"><asp:label id="lblCheckNo" runat="server" CssClass="smalltext" Font-Bold="True">Check No:</asp:label></TD>
					<TD bgColor="#f5f6f5"><asp:textbox id="txtCheckNo" tabIndex="39" runat="server" CssClass="regtext"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#f5f6f5" colSpan="4"><asp:label id="Label30" runat="server" CssClass="smalltext" Font-Bold="True">Notes Regarding the License:</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 29px" align="center" bgColor="#f5f6f5" colSpan="4"><asp:textbox id="txtNotes" tabIndex="40" runat="server" Width="608px" TextMode="MultiLine" Height="68px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" colSpan="4">
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

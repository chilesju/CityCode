<%@ Page language="c#" Codebehind="Modify_License_Type.aspx.cs" AutoEventWireup="false" Inherits="CLAS.Modify_License" trace="False" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CLAS-Modify License Type</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 760px; HEIGHT: 894px" cellSpacing="1" cellPadding="1"
				width="760" align="center" border="0">
				<TR>
					<TD align="center" colSpan="4"><uc1:header id="Header1" runat="server"></uc1:header></TD>
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
					<TD align="center" bgColor="#f5f5f5" colSpan="4"><FONT class="regtext">Modify all the 
							appropriate fields to be included when data entering for the new type. Also 
							select whether or not the field should be required. Complete all required 
							fields to the right then click the 'Modify the Type Code' button below the 
							form. </FONT>
					</TD>
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
					<TD style="HEIGHT: 35px" align="center" bgColor="#f5f5f5" colSpan="4"><asp:label id="lblLicType" runat="server" Font-Bold="True" CssClass="largeText">License Type:</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 30px" colSpan="4"><asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="Red" CssClass="smalltext">Type Code:</asp:label><asp:textbox id="txtTypeCode" runat="server" CssClass="regtext"></asp:textbox><asp:requiredfieldvalidator id="vldTypeCode" runat="server" ErrorMessage="Type Code Cannot be blank." ControlToValidate="txtTypeCode"
							CssClass="smalltext">*</asp:requiredfieldvalidator><asp:label id="Label1" runat="server" Font-Bold="True" ForeColor="Red" CssClass="smalltext">Name:</asp:label><asp:textbox id="txtTypeName" runat="server" Width="318px" CssClass="regtext"></asp:textbox><asp:requiredfieldvalidator id="vldName" runat="server" ErrorMessage="Name Cannot be blank" ControlToValidate="txtTypeName"
							CssClass="smalltext">*</asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px" colSpan="4"><asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="Red" CssClass="smalltext">Account #:</asp:label>&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtAccountNum" runat="server" Width="112px" CssClass="regtext"></asp:textbox><asp:requiredfieldvalidator id="valdAccountNum" runat="server" ErrorMessage="Account Number cannt be blank"
							ControlToValidate="txtAccountNum" CssClass="smalltext">*</asp:requiredfieldvalidator>&nbsp;
						<asp:label id="Label28" runat="server" Font-Bold="True" ForeColor="Red" CssClass="smalltext">License Fee:</asp:label><asp:textbox id="txtbxLicFee" runat="server" CssClass="regtext"></asp:textbox><asp:requiredfieldvalidator id="vldLicenseFee" runat="server" ErrorMessage="License Fee Cann't be blank" ControlToValidate="txtbxLicFee">*</asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 36px" colSpan="4"><asp:label id="Label27" runat="server" Font-Bold="True" ForeColor="Red" CssClass="smalltext">Expire Date:</asp:label><asp:textbox id="txtExpireDateMonth" runat="server" Width="64px" CssClass="regtext"></asp:textbox>/
						<asp:textbox id="txtExpireDateDay" runat="server" Width="72px" CssClass="regtext"></asp:textbox><asp:label id="Label5" runat="server" CssClass="smalltext">Or Days:</asp:label><asp:textbox id="txtExpireDay" runat="server" Width="104px" CssClass="regtext"></asp:textbox><asp:label id="Label6" runat="server" CssClass="smalltext">Or Months:</asp:label><asp:textbox id="txtExpireMonth" runat="server" CssClass="regtext"></asp:textbox><asp:customvalidator id="CustomValidator1" runat="server" ErrorMessage="CustomValidator" CssClass="smalltext">*</asp:customvalidator></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" align="left" bgColor="white" colSpan="4" height="15">
						<TABLE cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 39px; align: 'center'" align="center" bgColor="#f5f5f5" colSpan="4"
						rowSpan="1"><asp:label id="Label7" runat="server" Font-Bold="True" CssClass="largeText">Choose Included Fields for This Type</asp:label></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="lightyellow" noWrap><asp:label id="Label29" runat="server" Font-Bold="True" CssClass="smalltext">Application Name:</asp:label></TD>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnAppNameInc" runat="server" Font-Bold="True" Text="Include" GroupName="AppNameInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnAppNameNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="AppNameInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD style="HEIGHT: 11px; align: 'center'" align="left" bgColor="#ffffe0" colSpan="2"><asp:radiobutton id="rbtnAppNameReq" runat="server" Font-Bold="True" Text="Required" GroupName="AppNameReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnAppNameNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="AppNameReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="gainsboro" colSpan="1" rowSpan="1" noWrap><asp:label id="Label18" runat="server" Font-Bold="True" CssClass="smalltext">Licensee Name:</asp:label></TD>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:radiobutton id="rbtnLicNamInc" runat="server" Font-Bold="True" Text="Include" GroupName="LicNameInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnLicNamNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="LicNameInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnLicNamReq" runat="server" Font-Bold="True" Text="Required" GroupName="LicNameReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnLicNameNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="LicNameReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:label id="Label11" runat="server" Font-Bold="True" CssClass="smalltext">Mailing Address:</asp:label></TD>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnMailAddInc" runat="server" Font-Bold="True" Text="Include" GroupName="MailAddInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnMailAddNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="MailAddInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#ffffe0" colSpan="2" noWrap><asp:radiobutton id="rbtnMailAddReq" runat="server" Font-Bold="True" Text="Required" GroupName="MailAddReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnMailAddNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="MailAddReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:label id="Label9" runat="server" Font-Bold="True" CssClass="smalltext">Mailing City/St/Zip:</asp:label></TD>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:radiobutton id="rbtnMailCstInc" runat="server" Font-Bold="True" Text="Include" GroupName="MailCSTInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnMailCstNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="MailCSTInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnMailCstReq" runat="server" Font-Bold="True" Text="Required" GroupName="MailCSTReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnMailCstNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="MailCSTReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:label id="Label4" runat="server" Font-Bold="True" CssClass="smalltext">Owner Name:</asp:label></TD>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnOwnerNameInc" runat="server" Font-Bold="True" Text="Include" GroupName="OwnNamInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnOwNameNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="OwnNamInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD style="HEIGHT: 22px" align="left" bgColor="#ffffe0" colSpan="2" noWrap><asp:radiobutton id="rbtnOwNameReq" runat="server" Font-Bold="True" Text="Required" GroupName="OwnNameReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnOwNameNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="OwnNameReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:label id="Label10" runat="server" Font-Bold="True" CssClass="smalltext">Owner Address:</asp:label></TD>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:radiobutton id="rbtnOwAddInc" runat="server" Font-Bold="True" Text="Include" GroupName="OwAddInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnOwAddNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="OwAddInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnOwAddReq" runat="server" Font-Bold="True" Text="Required" GroupName="OwAddReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnOwAddNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="OwAddReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:label id="Label12" runat="server" Font-Bold="True" CssClass="smalltext">Owner City/St/Zip:</asp:label></TD>
					<TD style="HEIGHT: 21px" align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnOwCstInc" runat="server" Font-Bold="True" Text="Include" GroupName="OwnerCSTInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnOwCstNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="OwnerCSTInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD style="HEIGHT: 21px" align="left" bgColor="#ffffe0" colSpan="2" noWrap><asp:radiobutton id="rbtnOwCstReq" runat="server" Font-Bold="True" Text="Required" GroupName="OwCSTReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnOwCstNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="OwCSTReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="left" bgColor="#dcdcdc" noWrap><asp:label id="Label15" runat="server" Font-Bold="True" CssClass="smalltext">Owner Phone:</asp:label></TD>
					<TD style="HEIGHT: 18px" align="left" bgColor="#dcdcdc" noWrap><asp:radiobutton id="rbtnOwPhInc" runat="server" Font-Bold="True" Text="Include" GroupName="OwnerPhoInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnOwPhNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="OwnerPhoInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD style="HEIGHT: 18px" align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnOwPhReq" runat="server" Font-Bold="True" Text="Required" GroupName="OwnerPhoReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnOwPhNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="OwnerPhoReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffe0" colSpan="1" rowSpan="1" style="HEIGHT: 16px" noWrap><asp:label id="Label19" runat="server" Font-Bold="True" CssClass="smalltext">Business Name:</asp:label></TD>
					<TD style="HEIGHT: 16px" align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnBusNameInc" runat="server" Font-Bold="True" Text="Include" GroupName="BusNameInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnBusNameNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="BusNameInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD style="HEIGHT: 16px" align="left" bgColor="#ffffe0" colSpan="2" noWrap><asp:radiobutton id="rbtnBusNameReq" runat="server" Font-Bold="True" Text="Required" GroupName="BusNameReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnBusNameNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="BusNameReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:label id="Label26" runat="server" Font-Bold="True" CssClass="smalltext">Business Address:</asp:label></TD>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:radiobutton id="rbtnBusAddInc" runat="server" Font-Bold="True" Text="Include" GroupName="BusAddInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnBusAddNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="BusAddInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnBusAddReq" runat="server" Font-Bold="True" Text="Required" GroupName="BusAddReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnBusAddNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="BusAddReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:label id="Label21" runat="server" Font-Bold="True" CssClass="smalltext">Business City/St/Zip:</asp:label></TD>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnBusCstInc" runat="server" Font-Bold="True" Text="Include" GroupName="BusCSTInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnBusCstNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="BusCSTInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#ffffe0" colSpan="2" noWrap><asp:radiobutton id="rbtnBusCstReq" runat="server" Font-Bold="True" Text="Required" GroupName="BusCSTReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnBusCstNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="BusCSTReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:label id="Label17" runat="server" Font-Bold="True" CssClass="smalltext">Business Phone:</asp:label></TD>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:radiobutton id="rbtnBusPhoInc" runat="server" Font-Bold="True" Text="Include" GroupName="BusPhoInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnBusPhoNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="BusPhoInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnBusPhoReq" runat="server" Font-Bold="True" Text="Required" GroupName="BusPhoReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnBusPhoNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="BusPhoReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:label id="Label16" runat="server" Font-Bold="True" CssClass="smalltext">Zoning:</asp:label></TD>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnZoningInc" runat="server" Font-Bold="True" Text="Include" GroupName="ZoneInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnZoningNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="ZoneInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#ffffe0" colSpan="2" noWrap><asp:radiobutton id="rbtnZoningReq" runat="server" Font-Bold="True" Text="Required" GroupName="ZoneReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnZoningNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="ZoneReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD bgColor="#dcdcdc" noWrap><asp:label id="Label22" runat="server" Font-Bold="True" CssClass="smalltext">Insurance Date:</asp:label></TD>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:radiobutton id="rbtnInsurInc" runat="server" Font-Bold="True" Text="Include" GroupName="InsInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnInsuNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="InsInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnInsuReq" runat="server" Font-Bold="True" Text="Required" GroupName="InsReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnInsuNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="InsReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:label id="Label25" runat="server" Font-Bold="True" CssClass="smalltext">Bond Date:</asp:label></TD>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnBondInc" runat="server" Font-Bold="True" Text="Include" GroupName="BondInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnBondNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="BondInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD style="HEIGHT: 23px" align="left" bgColor="#ffffe0" colSpan="2" noWrap><asp:radiobutton id="rbtnBondReq" runat="server" Font-Bold="True" Text="Required" GroupName="BondReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnBondNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="BondReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:label id="Label8" runat="server" Font-Bold="True" CssClass="smalltext" Visible="False"
							Enabled="False">SSN:</asp:label></TD>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:radiobutton id="rbtnSsnInc" runat="server" Font-Bold="True" Text="Include" GroupName="SsnInc"
							CssClass="smalltext" Visible="False" Enabled="False"></asp:radiobutton><asp:radiobutton id="rbtnSsnNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="SsnInc"
							CssClass="smalltext" Visible="False" Enabled="False"></asp:radiobutton></TD>
					<TD align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnSsnReq" runat="server" Font-Bold="True" Text="Required" GroupName="SsnReq"
							CssClass="smalltext" Visible="False" Enabled="False"></asp:radiobutton><asp:radiobutton id="rbtnSsnNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="SsnReq"
							CssClass="smalltext" Visible="False" Enabled="False"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:label id="Label23" runat="server" Font-Bold="True" CssClass="smalltext" Visible="False"
							Enabled="False">Driver License:</asp:label></TD>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnDrivLicInc" runat="server" Font-Bold="True" Text="Include" GroupName="DrivLicInc"
							CssClass="smalltext" Visible="False" Enabled="False"></asp:radiobutton><asp:radiobutton id="rbtnDriverLicNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="DrivLicInc"
							CssClass="smalltext" Visible="False" Enabled="False"></asp:radiobutton></TD>
					<TD align="left" bgColor="#ffffe0" colSpan="2" noWrap><asp:radiobutton id="rbtnDrivLicReq" runat="server" Font-Bold="True" Text="Required" GroupName="DrivLicReq"
							CssClass="smalltext" Visible="False" Enabled="False"></asp:radiobutton><asp:radiobutton id="rbtnDrivLicNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="DrivLicReq"
							CssClass="smalltext" Visible="False" Enabled="False"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:label id="Label13" runat="server" Font-Bold="True" CssClass="smalltext">Liquor License:</asp:label></TD>
					<TD style="HEIGHT: 7px" align="left" bgColor="#dcdcdc" noWrap><asp:radiobutton id="rbtnLiqLicInc" runat="server" Font-Bold="True" Text="Include" GroupName="LiqLicInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnLiqLicNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="LiqLicInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD style="HEIGHT: 7px" align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnLiqLicReq" runat="server" Font-Bold="True" Text="Required" GroupName="LiqLicReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnLiqLicNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="LiqLicReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:label id="Label24" runat="server" Font-Bold="True" CssClass="smalltext">Sales Tax #:</asp:label></TD>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnSalesInc" runat="server" Font-Bold="True" Text="Include" GroupName="SalesInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnSalesNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="SalesInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#ffffe0" colSpan="2" noWrap><asp:radiobutton id="rbtnSalesReq" runat="server" Font-Bold="True" Text="Required" GroupName="SalesReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnSalesNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="SalesReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:label id="Label14" runat="server" Font-Bold="True" CssClass="smalltext">VIN:</asp:label></TD>
					<TD style="WIDTH: 244px; HEIGHT: 1px; align: 'center'" align="left" bgColor="#dcdcdc"><asp:radiobutton id="rbtnVinInc" runat="server" Font-Bold="True" Text="Include" GroupName="VinInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnVinNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="VinInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnVinReq" runat="server" Font-Bold="True" Text="Required" GroupName="VinReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnVinNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="VinReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#ffffe0" noWrap><asp:label id="Label20" runat="server" Font-Bold="True" CssClass="smalltext">Legal ID:</asp:label></TD>
					<TD style="HEIGHT: 22px" align="left" bgColor="#ffffe0" noWrap><asp:radiobutton id="rbtnLegalInc" runat="server" Font-Bold="True" Text="Include" GroupName="LegalInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnLegalNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="LegalInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD style="HEIGHT: 22px" align="left" bgColor="#ffffe0" colSpan="2" noWrap><asp:radiobutton id="rbtnLegalReq" runat="server" Font-Bold="True" Text="Required" GroupName="LegalReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnLegalNotReq" runat="server" Font-Bold="True" Text="Not Required" GroupName="LegalReq"
							CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:label id="lblEmailAddress" runat="server" Font-Bold="True" CssClass="smalltext">Email Address:</asp:label></TD>
					<TD align="left" bgColor="#dcdcdc" noWrap><asp:radiobutton id="rbtnEmailInc" runat="server" Font-Bold="True" Text="Include" GroupName="EmailInc"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnEmailNotInc" runat="server" Font-Bold="True" Text="Not Included" GroupName="EmailInc"
							CssClass="smalltext"></asp:radiobutton></TD>
					<TD align="left" bgColor="#dcdcdc" colSpan="2" noWrap><asp:radiobutton id="rbtnEmailReq" runat="server" Font-Bold="True" Text="Required" GroupName="EmailReq"
							CssClass="smalltext"></asp:radiobutton><asp:radiobutton id="rbtnEmailNotReq" runat="server" Font-Bold="True" Text="Not Required" CssClass="smalltext"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 183px; HEIGHT: 48px; align: 'center'" align="center" colSpan="4">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="500" align="center" border="0">
							<TR>
								<TD align="left" style="WIDTH: 227px"><A href="/CLAS/Type_Code_List.aspx" class="reglinks">..Back&nbsp;to 
										License Type..</A>
								</TD>
								<TD style="WIDTH: 145px"><asp:button id="btnViewReport" runat="server" Text="View Report" CssClass="regtext"></asp:button>&nbsp;
								</TD>
								<TD><asp:button id="btnUpdate" runat="server" Text="Update" CssClass="regtext"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 221px; HEIGHT: 29px; align: 'center'" align="left"></TD>
					<TD style="WIDTH: 244px; HEIGHT: 29px; align: 'center'" align="left">
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="regtext"></asp:validationsummary></TD>
					<TD style="HEIGHT: 29px; align: 'center'" align="left" colSpan="2"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 5px; align: 'center'" align="left" colSpan="5">
						<uc1:footer id="Footer1" runat="server"></uc1:footer></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

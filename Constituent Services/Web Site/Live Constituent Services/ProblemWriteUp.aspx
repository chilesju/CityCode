<%@ Register TagPrefix="uc1" TagName="footer" Src="controls/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="adminHeader" Src="controls/adminHeader.ascx" %>
<%@ Page language="c#" Codebehind="ProblemWriteUp.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.ProblemWriteUp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Constituent Services - Problem Write Up</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
	</head>
	<body>
		<script language="javascript" src="JScript.js" type="text/javascript"></script>
		<form id="Form1" method="post" runat="server">
		<table id="LayoutOutside" borderColor="#e9e9e9" height="100%" cellSpacing="0" cellPadding="0" width="780" align="center" bgColor="#f4f4f4" border="2" rules="none" frame="vSides">
	        <tr>
	        <td class="regtext" align="center">
			    <uc1:adminHeader id="AdminHeader1" runat="server"></uc1:adminHeader>
			</td>
			</tr>
			<tr>
			<td class="regtext" align="center">
			<table id="Table1" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
				<tr>
					<td style="HEIGHT: 20px" align="right"><asp:label id="lblDate" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 5px"><asp:label id="Label11" runat="server" CssClass="regtext" Font-Underline="True" Font-Bold="True">Problem:</asp:label><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="regtext"></asp:validationsummary><asp:label id="lblMoreInfo" runat="server" CssClass="largeText" ForeColor="Red"></asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server" CssClass="regtext">Problem Type:</asp:label><asp:label id="lblPropblem" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 18px"><asp:label id="lblDetail" runat="server" CssClass="smalltext"></asp:label></td>
				</tr>
				<tr>
					<td><asp:textbox id="txtProblemDetail" runat="server" CssClass="TEXTAREA" TextMode="MultiLine" Width="95%"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="regtext" ControlToValidate="txtProblemDetail"
							ErrorMessage="Please include the details of this issue">*</asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<td style="HEIGHT: 18px" colspan="4">
						<table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="http://www.topeka.org/images/nav_dotted.gif"><img height="3" src="http://www.topeka.org/images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td style="HEIGHT: 20px"><asp:label id="Label15" runat="server" CssClass="regtext" Font-Underline="True" Font-Bold="True">Location:</asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 19px"><asp:label id="Label3" runat="server" CssClass="smalltext">An exact address is appreciated</asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 25px"><a class="smallinks" href="javascript:OpenAddress('txtIntersection', true)">If 
							you need help locating a address click here to search all property address..</a></td>
				</tr>
				<tr>
					<td style="HEIGHT: 27px"><asp:label id="Label14" runat="server" CssClass="regtext">Street Number:</asp:label><asp:textbox id="txtStreetNumber" runat="server" CssClass="regtext"></asp:textbox></td>
				</tr>
				<tr>
					<td style="HEIGHT: 24px"><asp:label id="Label2" runat="server" CssClass="regtext">Street Name:</asp:label><asp:dropdownlist id="directionList" runat="server" CssClass="regtext">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="E">E</asp:ListItem>
							<asp:ListItem Value="N">N</asp:ListItem>
							<asp:ListItem Value="NW">NW</asp:ListItem>
							<asp:ListItem Value="NE">NE</asp:ListItem>
							<asp:ListItem Value="S">S</asp:ListItem>
							<asp:ListItem Value="SE">SE</asp:ListItem>
							<asp:ListItem Value="SW">SW</asp:ListItem>
							<asp:ListItem Value="W">W</asp:ListItem>
						</asp:dropdownlist>&nbsp;<asp:textbox id="txtRoad" runat="server" CssClass="regtext" Width="208px"></asp:textbox></td>
				</tr>
				<tr>
					<td style="HEIGHT: 25px"></td>
				</tr>
				<tr>
					<td style="HEIGHT: 22px"><asp:label id="Label16" runat="server" CssClass="regtext">Or if this is intersection or you found the adddress in the link above or city wide then fill out the box below:</asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 32px"><asp:textbox id="txtIntersection" onblur="" runat="server" CssClass="regtext" size="55"></asp:textbox></td>
				</tr>
				<tr>
					<td style="HEIGHT: 18px" colspan="4">
						<table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="http://www.topeka.org/images/nav_dotted.gif"><img height="3" src="http://www.topeka.org/images/vert_spacer.gif" width="20"/></td>
							</tr>
						</table>
						<asp:label id="Label22" runat="server" CssClass="regtext" Font-Underline="True" Font-Bold="True">Personal Information:</asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 26px"><asp:label id="Label21" runat="server" CssClass="regtext">Your First Name:</asp:label><asp:textbox id="txtFirstName" runat="server" CssClass="TEXTAREA" BorderColor="White"></asp:textbox></td>
				</tr>
				<tr>
					<td style="HEIGHT: 26px"><asp:label id="Label20" runat="server" CssClass="regtext">Your Last Name:</asp:label><asp:textbox id="txtLastName" runat="server" CssClass="regtext"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label19" runat="server" CssClass="regtext">Your Phone:</asp:label><asp:textbox id="txtPhoneNumber" runat="server" CssClass="regtext"></asp:textbox><asp:regularexpressionvalidator id="regexpvalidPhoneNumber" runat="server" CssClass="regtext" ControlToValidate="txtPhoneNumber"
							ErrorMessage="Phone Number is Invalid- Format:(555-5555)" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"><--- (Format-555-5555)</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td style="HEIGHT: 25px"><asp:label id="Label18" runat="server" CssClass="regtext">Your Email:</asp:label><asp:textbox id="txtEmail" runat="server" CssClass="regtext"></asp:textbox><asp:regularexpressionvalidator id="validEmail" runat="server" CssClass="regtext" ControlToValidate="txtEmail" ErrorMessage="E-mail Address is invalid"
							ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><-- Invalid Email Format</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td><asp:checkbox id="chbxAnonymous" runat="server" CssClass="regtext" Height="24px" Text="Remain Anonymous-Check here to omit personal information"></asp:checkbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label8" runat="server" CssClass="regtext">Would you like to be contacted on this issue?</asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 22px"><asp:radiobutton id="rbtnYes" runat="server" CssClass="regtext" Text="Yes" Checked="True" GroupName="YesNo"></asp:radiobutton><asp:radiobutton id="rbtnNo" runat="server" CssClass="regtext" Text="No" GroupName="YesNo"></asp:radiobutton></td>
				</tr>
				<tr>
					<td style="HEIGHT: 25px" align="center"><asp:button id="btnSubmit" runat="server" CssClass="regtext" Text="Submit" OnClick="btnSubmit_Click1"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" CssClass="regtext" Text="Reset" OnClick="btnReset_Click1"></asp:button></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px" align="left">
						<asp:Label id="lblAssignmentInformation" runat="server" CssClass="regtext">Users that are assigned to this catagory:</asp:Label></td>
				</tr>
				<tr>
					<td align="left">
						<asp:DataGrid id="dgUsersAssignedToThisCatagory" runat="server" CssClass="regtext"></asp:DataGrid></td>
				</tr>
				<tr>
					<td style="HEIGHT: 18px" colspan="4">
						<table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="http://www.topeka.org/images/nav_dotted.gif"><img height="3" src="http://www.topeka.org/images/vert_spacer.gif" width="20"/></td>
							</tr>
						</table>
					</td>
				</tr>
							<tr>
			<td>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
			</td>
			</tr>
			</table>
			</td>
			</tr>

			</table>
		</form>
		
	</body>
</html>

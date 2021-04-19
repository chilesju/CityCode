<%@ Page language="c#" Codebehind="Confirmation.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.Confirmation" %>
<%@ Register TagPrefix="uc1" TagName="adminHeader" Src="controls/adminHeader.ascx" %>
<%@ Register TagPrefix="uc2" TagName="footer" Src="controls/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Constituent Services - Confirmation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		<table id="LayoutOutside" bordercolor="#e9e9e9" height="100%" cellspacing="0" cellpadding="0" width="780" align="center" bgcolor="#f4f4f4" border="2" rules="none" frame="vSides">
		<tr>
		<td>
			<uc1:adminheader id="AdminHeader1" runat="server"></uc1:adminheader>
			</td>
			</tr>
			<tr>
			<td>
			<table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
				<tr>
					<td class="regtext" style="HEIGHT: 20px">Thank You
						<asp:label id="lblName" runat="server"></asp:label>for submitting a ticket</TD>
				</tr>
				<tr>
					<td style="HEIGHT: 20px">
						<asp:Label id="lblInformOnGraffiti" runat="server" CssClass="regtext" Visible="False" Enabled="False">This is a Graffiti Incident; two tickets were created one for Code and one for Police. </asp:Label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 19px"><asp:label id="Label1" runat="server" CssClass="regtext" Font-Bold="True">Incident Number: </asp:label><asp:label id="lblIncidentNumber" runat="server" CssClass="regtext"></asp:label>&nbsp;
						<asp:Label id="lblIncidentNumber2Graffiti" runat="server" CssClass="regtext" Visible="False"
							Enabled="False">and </asp:Label></TD>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server" CssClass="regtext" Font-Bold="True">Date Submited:</asp:label><asp:label id="lblDate" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px"><asp:label id="Label3" runat="server" CssClass="regtext" Font-Bold="True"> Address: </asp:label><asp:label id="lblAddress" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px"><asp:label id="lblProblemType" runat="server" CssClass="regtext" Font-Bold="True">Problem Type: </asp:label><asp:label id="lblProblem" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="lblFname" runat="server" CssClass="regtext" Font-Bold="True">First Name: </asp:label><asp:label id="lblFirstName" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px"><asp:label id="lblLname" runat="server" CssClass="regtext" Font-Bold="True">Last Name: </asp:label><asp:label id="lblLastName" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px"><asp:label id="lblYourPhone" runat="server" CssClass="regtext" Font-Bold="True">Phone: </asp:label><asp:label id="lblPhone" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="lblYourEmail" runat="server" CssClass="regtext" Font-Bold="True">Email: </asp:label><asp:label id="lblEmail" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td><asp:button id="btnEmail" runat="server" Text="Send The Constituent An E-mail" OnClick="btnEmail_Click1"></asp:button></td>
				</tr>
				<tr>
					<td colspan="4">
						<table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="http://www.topeka.org/images/nav_dotted.gif"><img height="3" src="http://www.topeka.org/images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label4" runat="server" CssClass="regtext">If you know the Council District input it now:</asp:label></td>
				</tr>
				<tr>
					<td style="height: 24px"><asp:label id="Label11" runat="server" CssClass="regtext">Council Dist:</asp:label><asp:dropdownlist id="councilDistList" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:button id="btnCouncilDist" runat="server" Text="Input District" OnClick="btnCouncilDist_Click1"></asp:button></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server" CssClass="regtext">Click the Question Mark to help locate the district:</asp:Label>
						<asp:Image id="Image1" runat="server" CssClass="regtext" ImageUrl="Images/question_mark.gif"></asp:Image></td>
				</tr>
				<tr>
					<td><asp:hyperlink id="HyperLink1" runat="server" CssClass="reglinks" NavigateUrl="AddNewCall.aspx">Go Back</asp:hyperlink></td>
				</tr>
							<tr>
			<td>
			<uc2:footer id="Footer1" runat="server"></uc2:footer>
			</td>
			</tr>
			</table>
			</td>
			</tr>

			</table>
			</form>
	</body>
</html>

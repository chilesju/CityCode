<%@ Register TagPrefix="uc1" TagName="footer" Src="controls/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="adminHeader" Src="controls/adminHeader.ascx" %>
<%@ Page language="c#" Codebehind="ConfirmationWithAssignment.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.ConfirmationWithAssignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Constituent Services - -Confirmation With Assignment</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1" />
		<meta name="CODE_LANGUAGE" Content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		<table id="LayoutOutside" bordercolor="#e9e9e9" height="100%" cellspacing="0" cellpadding="0" width="780" align="center" bgcolor="#f4f4f4" border="2" rules="none" frame="vSides">
		<tr>
		<td>
			<uc1:adminHeader id="AdminHeader1" runat="server"></uc1:adminHeader>
			</td>
			</tr>
			<tr>
			<td>
			<table id="Table1" cellSpacing="1" cellPadding="1" width="680" border="0">
				<tr>
					<td class="regtext" style="HEIGHT: 21px">Thank You
						<asp:Label id="lblName" runat="server"></asp:Label>for submitting a ticket</td>
				</tr>
				<tr>
					<td>
						<asp:label id="Label1" runat="server" CssClass="regtext" Font-Bold="True">Incident Number: </asp:label>
						<asp:label id="lblIncidentNumber" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td>
						<asp:label id="Label2" runat="server" CssClass="regtext" Font-Bold="True">Date Submited:</asp:label>
						<asp:label id="lblDate" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px">
						<asp:label id="Label3" runat="server" CssClass="regtext" Font-Bold="True"> Address: </asp:label>
						<asp:label id="lblAddress" runat="server" CssClass="regtext"></asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px">
						<asp:label id="lblProblemType" runat="server" CssClass="regtext" Font-Bold="True">Problem Type: </asp:label>
						<asp:label id="lblProblem" runat="server" CssClass="regtext"></asp:label></td>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px">
						<asp:label id="Label6" runat="server" CssClass="regtext" Font-Bold="True">Problem: </asp:label>
						<asp:label id="lblProblemDisc" runat="server" CssClass="regtext"></asp:label></td>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px">
						<asp:label id="lblFname" runat="server" CssClass="regtext" Font-Bold="True">First Name: </asp:label>
						<asp:label id="lblFirstName" runat="server" CssClass="regtext"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px">
						<asp:label id="lblLname" runat="server" CssClass="regtext" Font-Bold="True">Last Name: </asp:label>
						<asp:label id="lblLastName" runat="server" CssClass="regtext"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px">
						<asp:label id="lblYourPhone" runat="server" CssClass="regtext" Font-Bold="True">Phone: </asp:label>
						<asp:label id="lblPhone" runat="server" CssClass="regtext"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px">
						<asp:label id="lblYourEmail" runat="server" CssClass="regtext" Font-Bold="True">Email: </asp:label>
						<asp:label id="lblEmail" runat="server" CssClass="regtext"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px">&nbsp;
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:button id="btnEmail" runat="server" Text="Send The Constituent An E-mail" OnClick="btnEmail_Click1"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px" colSpan="4">
						<TABLE cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TR>
								<TD background="http://www.topeka.org/images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="Label7" runat="server" Font-Bold="True" CssClass="regtext" BackColor="White"
							ForeColor="Red">This type of Call needs to be assigned to a department.</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblWichDepartment" runat="server" CssClass="regtext" Font-Bold="True">Which Department?: </asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px">
						<asp:label id="lblAssignment" runat="server" CssClass="regtext" Font-Bold="True">Assignment: </asp:label>
						<asp:DropDownList id="departmentList1" runat="server" AutoPostBack="True" Width="137px">
							<asp:ListItem Value="Department">Department</asp:ListItem>
						</asp:DropDownList>
						<asp:DropDownList id="divisionList" runat="server" Width="145px">
							<asp:ListItem Value="Division">Division</asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="btnAssignTo" runat="server" Text="Assign to Department" OnClick="btnAssignTo_Click1"></asp:Button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" colSpan="4">
						<TABLE cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TR>
								<TD background="http://www.topeka.org/images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="Label8" runat="server" Font-Bold="True" CssClass="regtext">If you know the Council District Input it now:</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="Label11" runat="server" CssClass="regtext">Council Dist:</asp:label>
						<asp:dropdownlist id="councilDistList" runat="server" Enabled="False"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 6px">
						<asp:Button id="btnCouncilDist" runat="server" Text="Input District" Enabled="False" OnClick="btnCouncilDist_Click1"></asp:Button></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblAssignemntNumber" runat="server" Width="136px"></asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="AddNewCall.aspx" CssClass="reglinksbold">Go Back</asp:HyperLink></TD>
				</TR>
							<tr>
			<td>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
			</td>
			</tr>
			</TABLE>
			</td>
			</tr>

			</table>
		</FORM>
	</body>
</HTML>

<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SignIn.ascx.cs" Inherits="Constituent_Services.controls.SignIn" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%--
The SignIn User Control enables clients to authenticate themselves using the 
ASP.NET Forms based authentication system. When a client enters their 
username/password within the appropriate textboxes and clicks the "Login" 
button, the LoginBtn_Click event handler executes on the server and attempts to 
validate their credentials against a SQL database. If the password check 
succeeds, then the LoginBtn_Click event handler sets the customers username in 
an encrypted cookieID and redirects back to the portal home page. If the 
password check fails, then an appropriate error message is displayed. --%>
<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
	<TR>
		<TD class="regtext" colSpan="2"><B>Constituent Services:</B> Allows the City 
			Council staff to work with citizens to resolve concerns involving city 
			government, explain city programs, and expedite government action.
		</TD>
	</TR>
	<tr>
		<td style="HEIGHT: 20px"><span class="regtext" style="HEIGHT: 20px"><strong>Account Login</strong></span></td>
		<td width="300" rowSpan="6">
			<div align="center"><span class="regtext" style="HEIGHT: 8px"></span><span class="regtext" style="HEIGHT: 8px"><asp:image id="Image1" ImageUrl="..\Images\CityConstituentSrv.jpg" runat="server"></asp:image></span></div>
		</td>
	</tr>
	<tr>
		<td height="20"><span class="regtext">User name:</span>
			<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtUserName"
				CssClass="regtext"></asp:requiredfieldvalidator></td>
	</tr>
	<tr>
		<td height="20"><asp:textbox id="txtUserName" runat="server" columns="9" width="185px" cssclass="textbox"></asp:textbox></td>
	</tr>
	<tr>
		<td class="regtext" style="HEIGHT: 8px" height="20"><span class="Normal">Password:</span>
			<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtPassword"
				CssClass="regtext"></asp:requiredfieldvalidator></td>
	</tr>
	<tr>
		<td height="20"><asp:textbox id="txtPassword" runat="server" columns="9" width="185px" cssclass="TextBox" textmode="password"></asp:textbox></td>
	</tr>
	<tr>
		<td><asp:button id="btnSignin" runat="server" CssClass="regtext" Text="sign-in"></asp:button>&nbsp;
			<asp:button id="btnRegister" runat="server" CssClass="regtext" Text="register" CausesValidation="False"></asp:button>&nbsp;
			<asp:hyperlink id="HyperLink1" runat="server" CssClass="reglinks" NavigateUrl="http://www.topeka.org/support/index.shtml">Help</asp:hyperlink><br>
			<asp:label class="NormalRed" id="Message" runat="server" CssClass="regtext" Font-Bold="True"
				ForeColor="Red"></asp:label></td>
	</tr>
</table>

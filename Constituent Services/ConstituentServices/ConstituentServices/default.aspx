<%@ Register TagPrefix="uc2" TagName="SignIn" Src="controls/SignIn.ascx" %>
<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services._default" %>
<%@ Register TagPrefix="uc1" TagName="LoginHeader" Src="controls/LoginHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="controls/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Constituent Services - default</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:LoginHeader id="LoginHeader1" runat="server"></uc1:LoginHeader>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="780" border="0">
				<TR>
					<TD align="left">
						<uc2:SignIn id="SignIn1" runat="server"></uc2:SignIn></TD>
				</TR>
			</TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>

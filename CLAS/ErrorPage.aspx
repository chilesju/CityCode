<%@ Page language="c#" Codebehind="ErrorPage.aspx.cs" AutoEventWireup="false" Inherits="CLAS.ErrorPage" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header3" Src="header3.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ErrorPage</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
				<TR>
					<TD class="regtext" width="100%">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD class="regtext" width="100%">We are sorry but an error has occured.</TD>
				</TR>
				<TR>
					<TD class="regtext" width="100%">
						<uc1:footer id="Footer1" runat="server"></uc1:footer></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

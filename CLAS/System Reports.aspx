<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page language="c#" Codebehind="System Reports.aspx.cs" AutoEventWireup="false" Inherits="CLAS.SystemReports" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>System Reports</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="1" cellPadding="2" width="760" align="center" border="0">
				<TR>
					<TD colSpan="3" rowSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD bgColor="#f5f5f5" rowSpan="7">
						<P align="center"><strong><FONT face="Verdana, Arial, Helvetica" color="#000000" size="2">C.L.A.S. 
									has several types of system reports available. A menu of these selections is to 
									the right. Make your selection by clicking on the option you desire.</FONT></strong></P>
					</TD>
				</TR>
				<TR>
					<TD bgColor="#f5f5f5"></TD>
				</TR>
				<TR>
				</TR>
				<TR>
					<TD width="392">
						<P align="center"><IMG height="40" alt="" src="images\report_options.gif" width="392"></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><A href="/CLAS/Daily_Activity.aspx"><IMG height="40" alt="" src="images\daily_activity.gif" width="392" border="0"></A></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><A href="/CLAS/Yearly_Activity.aspx"><IMG height="40" alt="" src="images\annual_activity.gif" width="392" border="0"></A></P>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<tr>
								<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:footer id="Footer1" runat="server"></uc1:footer></TD>
				</TR>
				<TR>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

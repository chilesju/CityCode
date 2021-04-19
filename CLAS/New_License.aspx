<%@ Page language="c#" Codebehind="New_License.aspx.cs" AutoEventWireup="false" Inherits="CLAS.New_License" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CLAS-Start New License</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">
.style1 { FONT-SIZE: 12px }
		</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="2" width="760" border="0" align="center">
				<TR>
					<TD colSpan="2" align="center">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="2" align="center"><table width="100%" border="0" align="center" cellpadding="1" cellspacing="1">
							<tr>
								<td background="images/nav_dotted.gif"><img src="images/vert_spacer.gif" width="20" height="3"></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD width="50%" style="HEIGHT: 85px" bgColor="#f5f5f5"><div align="center"><FONT face="Verdana, Arial, Helvetica" color="#000000" class="regtext"><B>Begin 
									the process of generating a new license. Please enter what type of license you 
									will be wanting to generate in the appropriate field to the right. If you have 
									an application that can not be finalized today, please leave the issue date 
									field to the right empty and we will save the application as a 'PENDING' 
									license.</B></FONT></div>
					</TD>
					<TD width="50%" vAlign="top" bgColor="white" style="HEIGHT: 85px" noWrap><FONT face="Verdana, Arial, Helvetica" color="#000000" size="2">&nbsp;
						</FONT>
						<table width="371" border="0" align="center" cellpadding="1" cellspacing="1">
							<TR>
								<TD vAlign="middle" align="left" noWrap>
									<asp:Label id="Label1" runat="server" Font-Bold="True" CssClass="regtext">License Type:</asp:Label></TD>
								<TD align="left">
									<asp:DropDownList id="dropListLicenseType" runat="server" CssClass="regtext"></asp:DropDownList></TD>
							</TR>
							<tr>
								<td vAlign="top" align="left" noWrap><font face="Verdana, Arial, Helvetica" color="#000000" size="2"></font><font face="Verdana, Arial, Helvetica" color="#000000" size="2">
										<asp:Label id="Label2" runat="server" Font-Bold="True" CssClass="regtext">Issue Date:</asp:Label>
									</font>
								</td>
								<TD style="HEIGHT: 46px" align="left">
									<asp:Calendar id="Calendar1" runat="server" Width="224px" BackColor="White" DayNameFormat="FirstLetter"
										ForeColor="Black" Height="180px" Font-Size="8pt" Font-Names="Verdana" BorderColor="#999999"
										CellPadding="4" CssClass="regtext">
										<TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
										<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
										<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
										<DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
										<SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
										<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
										<WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
										<OtherMonthDayStyle ForeColor="Gray"></OtherMonthDayStyle>
									</asp:Calendar></TD>
							</tr>
							<tr>
								<td align="center" colSpan="2" rowSpan="1"><font face="Verdana, Arial, Helvetica" color="#000000" size="2"><asp:Button ID="btnBeginLicense" runat="server" Text="Begin License Entry" CssClass="regtext"></asp:Button>
									</font>
								</td>
							</tr>
							<TR>
								<TD align="left" colSpan="2">
									<asp:Label id="Label3" runat="server" CssClass="regtext">Click Box for A Pending License</asp:Label>
									<asp:CheckBox id="chbxPending" runat="server" Text="Pending" CssClass="regtext"></asp:CheckBox></TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><table width="100%" border="0" align="center" cellpadding="1" cellspacing="1">
							<tr>
								<td background="images/nav_dotted.gif"><img src="images/vert_spacer.gif" width="20" height="3"></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<div align="center"><uc1:footer id="Footer1" runat="server"></uc1:footer></div>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

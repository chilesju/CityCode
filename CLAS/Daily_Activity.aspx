<%@ Page language="c#" Codebehind="Daily_Activity.aspx.cs" AutoEventWireup="false" Inherits="CLAS.Daily_Activity" %>
<%@ Register TagPrefix="cr1" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.2.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CLAS | Daily Activity</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 760px; HEIGHT: 128px" cellSpacing="1" cellPadding="1"
				width="760" align="center" border="0">
				<TBODY>
					<TR>
						<TD align="center" bgColor="#f5f5f5"><uc1:header id="Header1" runat="server"></uc1:header></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 25px" align="center" bgColor="#f5f5f5"><asp:label id="Label1" runat="server" CssClass="regtext">Enter Date:</asp:label><asp:textbox id="txtDate" runat="server" CssClass="regtext"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 26px" align="center" bgColor="#f5f5f5"><input style="WIDTH: 65px; HEIGHT: 24px" onclick="gone()" type="button" value="Print" name="test"
								class="regtext"></TD>
					</TR>
					<tr>
						<td>
							<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
								<tr>
									<td background="images/nav_dotted.gif"><IMG height="3" src="images/vert_spacer.gif" width="20"></td>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD>
							<uc1:footer id="Footer2" runat="server"></uc1:footer></TD>
					</TR>
					<TR>
						<TD><form name="jumpy">
								<script language="javascript">
                         //Specify display mode (0 or 1)
                         //0 causes document to be displayed in an inline frame, while 1 in a new browser window
                          var displaymode=0
                          var date = document.getElementById('txtDate')
                          var iframecode='<iframe id="external" style="width:100%;height:400px" </iframe>'
                          if (displaymode==0)
                              document.write(iframecode)

                           function gone(){
                             
                             var selectedurl="http://www.topeka.org/CLAS/PrintDailyReport.aspx?dte="+date.value
                              if (document.getElementById&&displaymode==0)
                                  document.getElementById("external").src=selectedurl
                               else if (document.all&&displaymode==0)
                                   document.all.external.src=selectedurl
                                   else{
                                      if (!window.win2||win2.closed)
                                            win2=window.open(selectedurl)
                                      else{
                                         win2.location=selectedurl
                                         win2.focus()
                                        }
                                      }
                                }

								</script>
							</form>
						</TD>
					</TR>
		</form>
		</TBODY></TABLE>
	</body>
</HTML>

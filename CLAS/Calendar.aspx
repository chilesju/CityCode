<%@ Page language="c#" Codebehind="Calendar.aspx.cs" AutoEventWireup="false" Inherits="ASPNET.StarterKit.TimeTracker.Web.Calendar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Calendar</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			//function CloseWindow()
			//{
				
			//	self.close();
				 
		//	}
			function SetPending()
			{
				//document.getElementById['btnRenewInput'].
				/*var pending = document.getElementById('chbxPending');
				var isuDatetext= document.getElementById('txtIssueDate');
				var expDatetext= document.getElementById('txtExperationDate');
				if(pending.checked)
				{
				
				isuDatetext.value="Pending";
				expDatetext.value="Pending";
				}
				else
				{
				var now = new Date();
				
				isuDatetext.value=now;
				expDatetext.value="Pendidsfsdfng";
				}*/
			}

		</script>
	</HEAD>
	<body bgColor="#ffffff" leftMargin="5" topMargin="5">
		<form id="Calendar" method="post" runat="server">
			<table style="WIDTH: 344px; HEIGHT: 216px" cellSpacing="0" cellPadding="0" width="344"
				border="0">
				<tr bgColor="white">
					<td style="HEIGHT: 33px" noWrap align="center" colSpan="1" rowSpan="1"><asp:label id="Label1" runat="server" CssClass="regtext">Select the Issue Date</asp:label></td>
				</tr>
				<tr bgColor="white">
					<td align="center">&nbsp;<asp:calendar id="Cal" runat="server" CellPadding="4" BackColor="White" Width="200px" Height="180px"
							Font-Size="8pt" Font-Names="Verdana" BorderColor="#999999" DayNameFormat="FirstLetter" ForeColor="Black" FirstDayOfWeek="Monday">
							<TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
							<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
							<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
							<DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
							<SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
							<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
							<WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
							<OtherMonthDayStyle ForeColor="Gray"></OtherMonthDayStyle>
						</asp:calendar></td>
				</tr>
				<tr>
					<td style="HEIGHT: 22px" align="center" colSpan="2">Date Selected:&nbsp;
						<asp:TextBox id="txtIssueDate" runat="server"></asp:TextBox>
					</td>
				</tr>
				<TR>
					<TD style="HEIGHT: 22px" align="center" colSpan="2"><asp:label id="Label2" runat="server" CssClass="regtext">Or Select Pending</asp:label>
						<asp:checkbox id="chbxPending" runat="server" Text="Pending" AutoPostBack="True"></asp:checkbox></TD>
				</TR>
				<tr>
					<td noWrap align="center"><A href="javascript:CloseWindow()"><asp:button id="OKButton" runat="server" Width="60px" Text="OK"></asp:button></A>&nbsp;<A href="javascript:CloseWindow()"><asp:button id="CancelButton" runat="server" Width="60px" Text="Cancel"></asp:button></A>
						<A href="javascript:CloseWindow()"></A>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

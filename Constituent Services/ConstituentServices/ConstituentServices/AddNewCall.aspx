<%@ Register TagPrefix="uc1" TagName="adminHeader" Src="controls/adminHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="controls/footer.ascx" %>
<%@ Page language="c#" Codebehind="AddNewCall.aspx.cs" AutoEventWireup="false" Inherits="Constituent_Services.AddNewCall" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Constituent Services-Add New Call</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:adminheader id="AdminHeader1" runat="server"></uc1:adminheader>
			<TABLE id="Table1" style="DISPLAY: inline; VISIBILITY: visible; POSITION: static" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 9px" colSpan="2"><asp:label id="Label5" runat="server" Font-Size="Larger" Font-Bold="True" CssClass="regtext">Report a Problem</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD vAlign="top" width="50%">&nbsp;
									<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left"><LEGEND class="legend"><B>Police</B>
													</LEGEND>
													<asp:datagrid id="dgPolice" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton id=lblCodeCategory runat="server" CssClass="reglinksbold" CommandName="Edit" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>'>
																	</asp:LinkButton><BR>
																	<asp:Label id=lblCodeInformationNeeded runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></FIELDSET>
											</TD>
										</TR>
										<TR>
											<TD>
												<FIELDSET align="left"><LEGEND class="legend" id="lblParksRec"><B>Parks &amp; Recreation</B>
													</LEGEND>
													<asp:datagrid id="dgParksRec" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton id=lblParksRecCatagory runat="server" CssClass="reglinksbold" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>' CommandName="Edit">
																	</asp:LinkButton><BR>
																	<asp:Label id=lblParksRec runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></FIELDSET>
											</TD>
										</TR>
										<TR>
											<TD>
												<FIELDSET align="left"><LEGEND class="legend"><STRONG>Planning</STRONG></LEGEND><asp:datagrid id="dgPlanning" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px" Height="100%">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton id=lblPlanningCategory runat="server" CssClass="reglinksbold" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>' CommandName="Edit">
																	</asp:LinkButton><BR>
																	<asp:Label id=lblPlanning runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></FIELDSET>
											</TD>
										</TR>
										<TR>
											<TD>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left" DESIGNTIMEDRAGDROP="84"><LEGEND class="legend"><B>General</B></LEGEND><asp:datagrid id="dgGeneral" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton id=lblGeneralCatagory runat="server" CssClass="reglinksbold" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>' CommandName="Edit">
																	</asp:LinkButton><BR>
																	<asp:Label id=lblGeneralNeeded runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></FIELDSET>
											</TD>
										</TR>
									</TABLE>
									<asp:label id="Label1" runat="server" Font-Bold="True" CssClass="regtext" Visible="False" Enabled="False"
										Font-Underline="True"></asp:label><asp:datagrid id="dgMyList" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
										HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px" Visible="False" Enabled="False">
										<Columns>
											<asp:TemplateColumn>
												<ItemTemplate>
													<asp:LinkButton id=lklblMyCatagory runat="server" CssClass="reglinksbold" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>' CommandName="Edit">
													</asp:LinkButton><BR>
													<asp:Label id=lblMyStuff runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></TD>
								<TD class="regtext" vAlign="top" align="left">&nbsp;
									<asp:label id="Label2" runat="server" Font-Bold="True">Public Works</asp:label>
									<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left"><LEGEND class="legend"><B>Miscellaneous</B></LEGEND><asp:datagrid id="dgPublicWorks" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton id=lblPwCatagory runat="server" CssClass="reglinksbold" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>' CommandName="Edit">
																	</asp:LinkButton><BR>
																	<asp:Label id=lblPublicWorks runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></FIELDSET>
											</TD>
										</TR>
										<TR>
											<TD>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left"><LEGEND class="legend"><B>Code Services</B></LEGEND><asp:datagrid id="dgCodeServices" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton id=lblCodeServicesCatagory runat="server" CssClass="reglinksbold" CommandName="Edit" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>'>
																	</asp:LinkButton><BR>
																	<asp:Label id=lblCodeServices runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></FIELDSET>
											</TD>
										</TR>
										<TR>
											<TD>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left"><LEGEND class="legend"><STRONG>Traffic</STRONG></LEGEND><asp:datagrid id="dgTraffic" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton id=lblTrafficCatagory runat="server" CssClass="reglinksbold" CommandName="Edit" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>'>
																	</asp:LinkButton><BR>
																	<asp:Label id=lblTraffic runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></FIELDSET>
											</TD>
										</TR>
										<TR>
											<TD>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left"><LEGEND class="legend"><STRONG>Water WPC</STRONG></LEGEND><asp:datagrid id="dgWater" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton id=lblWaterCategory runat="server" CssClass="reglinksbold" CommandName="Edit" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>'>
																	</asp:LinkButton><BR>
																	<asp:Label id=lblWater runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></FIELDSET>
											</TD>
										</TR>
									</TABLE>
									<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
										align="left"><LEGEND class="legend"><STRONG>Street</STRONG></LEGEND><asp:datagrid id="dgStreet" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
											HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px">
											<Columns>
												<asp:TemplateColumn>
													<ItemTemplate>
														<asp:LinkButton id=lblStreetCategory runat="server" CssClass="reglinksbold" CommandName="Edit" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>'>
														</asp:LinkButton><BR>
														<asp:Label id=lblStreet runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</asp:datagrid></FIELDSET>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
			</TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>

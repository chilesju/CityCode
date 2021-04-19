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
        <link href="http://www.topeka.org/css/css.css" rel="stylesheet" type="text/css" />
        <link href="http://www.topeka.org/css/css.css" rel="stylesheet" type="text/css" />
        <link href="http://www.topeka.org/css/css.css" rel="stylesheet" type="text/css" />
        <link href="http://www.topeka.org/css/css.css" rel="stylesheet" type="text/css" />
        <link href="http://www.topeka.org/css/css.css" rel="stylesheet" type="text/css" />
        <link href="http://www.topeka.org/css/css.css" rel="stylesheet" type="text/css" />
        <link href="http://www.topeka.org/css/css.css" rel="stylesheet" type="text/css" />
        <link href="http://www.topeka.org/css/css.css" rel="stylesheet" type="text/css" />
	</HEAD>
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
			<TABLE id="Table1" style="DISPLAY: inline; VISIBILITY: visible; POSITION: static" cellspacing="1"
				cellPadding="1" width="100%" border="0">
				<tr>
					<td style="HEIGHT: 9px" colSpan="2"><asp:label id="Label5" runat="server" Font-Size="Larger" Font-Bold="True" CssClass="regtext">Report a Problem</asp:label></TD>
				</tr>
				<tr>
					<td colSpan="2">
						<table id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<tr>
								<td vAlign="top" width="50%" style="height: 924px">&nbsp; &nbsp;&nbsp;&nbsp;
									<table id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<tr>
											<td>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left"><LEGEND class="legend"><B>Police-Code Compliance</B>&nbsp;</LEGEND>
													<asp:datagrid id="dgCodeServices" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton id=lblCodeServicesCatagory runat="server" CssClass="reglinksbold" CommandName="Edit" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>'></asp:LinkButton><BR>
																	<asp:Label id=lblCodeInformationNeeded runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></FIELDSET>
											</td>
										</tr>
										<tr>
											<td>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left"><LEGEND class="legend"><B>Police-Miscellaneous</B></LEGEND><asp:datagrid id="dgPolice" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px">
                                                        <Columns>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lblCodeCategory" runat="server" CommandName="Edit" CssClass="reglinksbold"
                                                                        Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>'>
																	</asp:LinkButton><BR>
                                                                    <asp:Label ID="lblCodeInformationNeeded" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    </asp:DataGrid></FIELDSET>
											</td>
										</tr>
										<tr>
											<td>
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
											</td>
										</tr>
										<tr>
											<td>
												<FIELDSET align="left"><LEGEND class="legend"><STRONG>General</STRONG></LEGEND><asp:datagrid id="dgGeneral" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px" Height="100%">
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
											</td>
										</tr>
										
                          					<tr>
											<td>
												<FIELDSET align="left"><LEGEND class="legend"><STRONG>City Council</STRONG></LEGEND><asp:datagrid id="dgCityCouncil" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
														HorizontalAlign="Left" CaptionAlign="Top" ShowHeader="False" BorderWidth="0px" Height="100%">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton id=lblCityCouncilCategory runat="server" CssClass="reglinksbold" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>' CommandName="Edit">
																	</asp:LinkButton><BR>
																	<asp:Label id=lblCityCouncil runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></FIELDSET>
											</td>
										</tr>
                          
									</table>
								</td>
								<td class="regtext" vAlign="top" align="left" style="height: 924px">&nbsp;&nbsp;
									<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<tr>
											<td>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left"><LEGEND class="legend"><B>Public Works-Miscellaneous</B></LEGEND><asp:datagrid id="dgPublicWorks" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
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
											</td>
										</tr>

										<tr>
											<td>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left"><LEGEND class="legend"><STRONG>Public Works-Traffic</STRONG></LEGEND><asp:datagrid id="dgTraffic" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
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
											</td>
										</tr>
										<tr>
											<td>
												<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
													align="left"><LEGEND class="legend"><STRONG>Public Works-Water WPC</STRONG></LEGEND><asp:datagrid id="dgWater" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
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
									<tr>
									<td>
									<FIELDSET style="BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; MARGIN-TOP: 1px; PADDING-LEFT: 5px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 100%; BORDER-BOTTOM: #cccccc 1px solid"
										align="left"><LEGEND class="legend"><STRONG>Public Works-Street</STRONG></LEGEND><asp:datagrid id="dgStreet" runat="server" CssClass="regtext" Width="100%" AutoGenerateColumns="False"
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
										</td>
									</tr>
										<tr>
											<td>
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
											</td>
										</tr>
									
	
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td colspan="2"></td>
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
			</form>
	</body>
</HTML>

namespace CLAS
{
    using CLAS.BusinessLogicLayer;
    using System;
    using System.Data;
    using System.IO;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class License_Search : Page
    {
        private void BindSearch(bool useMailMerge, bool createReport, bool lookInCache)
        {
            try
            {
                License license1 = new License();
                license1.LicNo = CLAS_Security.CleanStringRegex(this.txtLicNo.Text);
                license1.LicStat = this.statusList.SelectedItem.Text.StartsWith("--Do Not Use") ? "" : this.statusList.SelectedItem.Text;
                license1.PayType = this.paymentList.SelectedItem.Text.StartsWith("--Do Not Use") ? "" : this.paymentList.SelectedItem.Text;
                DateTime time1 = Convert.ToDateTime("1/1/1900");
                DateTime time2 = Convert.ToDateTime("12/12/2060");
                license1.AName = CLAS_Security.CleanStringRegex(this.txtAppName.Text);
                license1.OName = CLAS_Security.CleanStringRegex(this.txtOwName.Text);
                license1.OAddr = CLAS_Security.CleanStringRegex(this.txtOwAdd.Text);
                license1.IssueDate1 = (this.txtIsuDateOne.Text == string.Empty) ? time1 : Convert.ToDateTime(this.txtIsuDateOne.Text);
                license1.IssueDate2 = (this.txtIsuDateTwo.Text == string.Empty) ? time2 : Convert.ToDateTime(this.txtIsuDateTwo.Text);
                license1.PaidDate1 = (this.txtPaidDateOne.Text == string.Empty) ? time1 : Convert.ToDateTime(this.txtPaidDateOne.Text);
                license1.PaidDate2 = (this.txtPaidDateTwo.Text == string.Empty) ? time2 : Convert.ToDateTime(this.txtPaidDateTwo.Text);
                license1.StDate1 = (this.txtStDateOne.Text == string.Empty) ? time1 : Convert.ToDateTime(this.txtStDateOne.Text);
                license1.StDate2 = (this.txtStDateTwo.Text == string.Empty) ? time2 : Convert.ToDateTime(this.txtStDateTwo.Text);
                license1.ExpDate1 = (this.txtExpDateOne.Text == string.Empty) ? time1 : Convert.ToDateTime(this.txtExpDateOne.Text);
                license1.ExpDate2 = (this.txtExpDateTwo.Text == string.Empty) ? time2 : Convert.ToDateTime(this.txtExpDateTwo.Text);
                license1.LiqLic = CLAS_Security.CleanStringRegex(this.txtLiqLic.Text);
                license1.Vin = CLAS_Security.CleanStringRegex(this.txtVin.Text);
                license1.TypeCode = this.licenseTypeList.SelectedItem.Text.StartsWith("--Do Not Use") ? "" : this.licenseTypeList.SelectedItem.Text.Substring(0, 4);
                license1.CheckNo = CLAS_Security.CleanStringRegex(this.txtCheckNu.Text);
                license1.LName = CLAS_Security.CleanStringRegex(this.txtLicName.Text);
                license1.BName = CLAS_Security.CleanStringRegex(this.txtBusName.Text);
                license1.BAddr = CLAS_Security.CleanStringRegex(this.txtBusAdd.Text);
                license1.Ssn = "";
                license1.PayType = this.paymentList.SelectedItem.Text.StartsWith("--Do Not Use") ? "" : this.paymentList.SelectedItem.Text;
                license1.AcctNo = CLAS_Security.CleanStringRegex(this.txtAcctNum.Text);
                license1.DriverLic = "";
                license1.SalesTax = CLAS_Security.CleanStringRegex(this.txtSalesTax.Text);
                license1.LegalId = CLAS_Security.CleanStringRegex(this.txtLegalId.Text);
                if (!useMailMerge && !createReport)
                {
                    if (lookInCache)
                    {
                        this.ds = (DataSet) base.Cache.Get("dsSearch");
                    }
                    else
                    {
                        this.ds = license1.GetSearchResult();
                        base.Cache["dsSearch"] = this.ds;
                    }
                    DataTable table1 = this.ds.Tables[0];
                    DataView view1 = new DataView(table1);
                    if (!lookInCache && (((license1.IssueDate1 != Convert.ToDateTime("1/1/1900")) || (license1.IssueDate2 != Convert.ToDateTime("12/12/2060"))) || ((license1.ExpDate1 != Convert.ToDateTime("1/1/1900")) || (license1.ExpDate2 != Convert.ToDateTime("12/12/2060")))))
                    {
                        foreach (DataRow row1 in table1.Rows)
                        {
                            if ((row1[5].ToString() != "ACTIVE") && (row1[5].ToString() != "EXPIRED"))
                            {
                                row1.Delete();
                            }
                        }
                        table1.AcceptChanges();
                    }
                    view1.Sort = this.sortLable.Text;
                    this.DataGrid2.DataSource = view1;
                    this.DataGrid2.DataBind();
                    this.Label4.Text = "NUMBER OF ROWS: " + table1.Rows.Count;
                }
                else if (useMailMerge && !createReport)
                {
                    this.ds = license1.GetMailMerge();
                    DataTable table2 = this.ds.Tables[0];
                    if (((license1.IssueDate1 != Convert.ToDateTime("1/1/1900")) || (license1.IssueDate2 != Convert.ToDateTime("12/12/2060"))) || ((license1.ExpDate1 != Convert.ToDateTime("1/1/1900")) || (license1.ExpDate2 != Convert.ToDateTime("12/12/2060"))))
                    {
                        foreach (DataRow row2 in table2.Rows)
                        {
                            if ((row2[1].ToString() != "ACTIVE") && (row2[1].ToString() != "EXPIRED"))
                            {
                                row2.Delete();
                            }
                        }
                        table2.AcceptChanges();
                    }
                    if (table2.Rows.Count > 0)
                    {
                        int num1 = 0;
                        try
                        {
                            while (num1 < table2.Rows.Count)
                            {
                                string text3;
                                string text4;
                                string text5;
                                string text1 = "";
                                string text2 = "";
                                if (table2.Rows[num1].ItemArray[9].ToString() != "0")
                                {
                                    text3 = table2.Rows[num1].ItemArray[9].ToString().Remove(table2.Rows[num1].ItemArray[9].ToString().Length - 2, 2);
                                }
                                else
                                {
                                    text3 = "0";
                                }
                                table2.Rows[num1][9] = text3;
                                table2.Rows[num1][14] = text1;
                                table2.Rows[num1][15] = text2;
                                if (table2.Rows[num1].ItemArray[7] != DBNull.Value)
                                {
                                    text4 = Convert.ToDateTime(table2.Rows[num1].ItemArray[7]).ToShortDateString();
                                }
                                else
                                {
                                    text4 = "PENDING";
                                }
                                if (table2.Rows[num1].ItemArray[8] != DBNull.Value)
                                {
                                    text5 = Convert.ToDateTime(table2.Rows[num1].ItemArray[8]).ToShortDateString();
                                }
                                else
                                {
                                    text5 = "PENDING";
                                }
                                string text6 = Convert.ToDateTime(table2.Rows[num1].ItemArray[2]).ToShortDateString();
                                table2.Rows[num1][7] = text4;
                                table2.Rows[num1][8] = text5;
                                table2.Rows[num1][2] = text6;
                                num1++;
                            }
                        }
                        catch (Exception)
                        {
                            this.lblAcctNum.Text = table2.Rows[num1].ItemArray[9].ToString();
                            this.Label11.Text = "jkjkl";
                        }
                    }
                    StreamWriter writer1 = new StreamWriter(base.MapPath(@"Reports\MailMerge.txt"));
                    int num2 = table2.Columns.Count;
                    for (int num3 = 0; num3 < num2; num3++)
                    {
                        writer1.Write("\"" + table2.Columns[num3] + "\"");
                        if (num3 < (num2 - 1))
                        {
                            writer1.Write(",");
                        }
                    }
                    writer1.Write(writer1.NewLine);
                    foreach (DataRow row3 in table2.Rows)
                    {
                        for (int num4 = 0; num4 < num2; num4++)
                        {
                            if (!Convert.IsDBNull(row3[num4]))
                            {
                                writer1.Write("\"" + row3[num4].ToString() + "\"");
                            }
                            if (num4 < (num2 - 1))
                            {
                                writer1.Write(",");
                            }
                        }
                        writer1.Write(writer1.NewLine);
                    }
                    writer1.Close();
                }
                else if (!useMailMerge && createReport)
                {
                    this.ds = license1.GetMailMerge();
                    DataTable table3 = this.ds.Tables[0];
                    if (((license1.IssueDate1 != Convert.ToDateTime("1/1/1900")) || (license1.IssueDate2 != Convert.ToDateTime("12/12/2060"))) || ((license1.ExpDate1 != Convert.ToDateTime("1/1/1900")) || (license1.ExpDate2 != Convert.ToDateTime("12/12/2060"))))
                    {
                        foreach (DataRow row4 in table3.Rows)
                        {
                            if ((row4[1].ToString() != "ACTIVE") && (row4[1].ToString() != "EXPIRED"))
                            {
                                row4.Delete();
                            }
                        }
                        table3.AcceptChanges();
                    }
                    if (table3.Rows.Count > 0)
                    {
                        for (int num5 = 0; num5 < table3.Rows.Count; num5++)
                        {
                            string text7 = "";
                            string text8 = "";
                            table3.Rows[num5][14] = text7;
                            table3.Rows[num5][15] = text8;
                            string text9 = Convert.ToDateTime(table3.Rows[num5].ItemArray[7]).ToShortDateString();
                            string text10 = Convert.ToDateTime(table3.Rows[num5].ItemArray[8]).ToShortDateString();
                            string text11 = Convert.ToDateTime(table3.Rows[num5].ItemArray[2]).ToShortDateString();
                            table3.Rows[num5].ItemArray[0x1a].ToString();
                            table3.Rows[num5][7] = text9;
                            table3.Rows[num5][8] = text10;
                            table3.Rows[num5][2] = text11;
                        }
                        if (table3.Rows.Count == 1)
                        {
                            object[] objArray1 = new object[] { "BBBB", "BBBB" };
                            table3.DataSet.Tables[0].Rows.Add(objArray1);
                            string text12 = table3.DataSet.GetXml();
                            string text13 = table3.DataSet.GetXmlSchema();
                            string text15 = text12 + text13;
                            table3.AcceptChanges();
                        }
                        string text14 = base.MapPath(@"Reports\LicenseSearchResultXML.XML");
                        table3.DataSet.WriteXml(text14);
                    }
                }
            }
            catch (Exception exception1)
            {
                this.Label4.Text = exception1.ToString();
            }
        }

        private void btnEasySearch_Click(object sender, EventArgs e)
        {
            this.EasySearch();
            this.ViewState["TestEasySearch"] = "true";
        }

        private void btnMailMerge_Click(object sender, EventArgs e)
        {
            HttpResponse response1 = HttpContext.Current.Response;
            this.DataGrid2.CurrentPageIndex = 0;
            this.BindSearch(true, false, false);
            response1.ContentType = "plain/text";
            this.ViewState["TestEasySearch"] = "false";
            string text1 = base.MapPath(@"Reports\MailMerge.txt");
            response1.AppendHeader("content-disposition", "attachment; filename=MailMerge.txt");
            response1.WriteFile(text1);
            response1.Flush();
            response1.End();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.DataGrid2.CurrentPageIndex = 0;
            this.BindSearch(false, true, false);
            base.Server.Transfer("Report_Search_Results.aspx", true);
            this.ViewState["TestEasySearch"] = "false";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.DataGrid2.CurrentPageIndex = 0;
            this.ViewState["TestEasySearch"] = "false";
            this.BindSearch(false, false, false);
        }

        private void DataGrid2_EditCommand_1(object source, DataGridCommandEventArgs e)
        {
            DataGridItem item1 = this.DataGrid2.Items[e.Item.ItemIndex];
            LinkButton button1 = (LinkButton) item1.FindControl("lblLicenseNumber");
            string text1 = button1.Text;
            this.Session["licenseNumber"] = text1;
            Label label1 = (Label) item1.FindControl("lblTypeCode");
            string text2 = label1.Text;
            this.Session["licenseType"] = text2;
            base.Server.Transfer("Modify_License.aspx", true);
        }

        private void DataGrid2_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#DEDFDE'");
                e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#99ccff'");
            }
            else if (e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#99ccff'");
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#FBFFDD'");
            }
        }

        private void DataGrid2_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
        {
            this.DataGrid2.CurrentPageIndex = e.NewPageIndex;
            if (this.ViewState["TestEasySearch"].ToString() == "true")
            {
                this.EasySearch();
            }
            else
            {
                this.BindSearch(false, false, true);
            }
        }

        private void DataGrid2_SortCommand_1(object source, DataGridSortCommandEventArgs e)
        {
            this.DataGrid2.CurrentPageIndex = 0;
            this.sortField = e.SortExpression.ToString() + ' ' + this.SortOrder.Text;
            this.sortLable.Text = this.sortField;
            if (this.ViewState["TestEasySearch"].ToString() == "true")
            {
                this.EasySearch();
            }
            else
            {
                this.BindSearch(false, false, true);
            }
            if (this.SortOrder.Text == "DESC")
            {
                this.SortOrder.Text = "ASC";
            }
            else
            {
                this.SortOrder.Text = "DESC";
            }
        }

        private void EasySearch()
        {
            DataSet set1 = License.EasySearch(this.txtEasySearch.Text);
            DataTable table1 = set1.Tables[0];
            DataView view1 = new DataView(table1);
            view1.Sort = this.sortLable.Text;
            this.DataGrid2.DataSource = view1;
            this.DataGrid2.DataBind();
            this.Label4.Text = "NUMBER OF ROWS: " + table1.Rows.Count;
        }

        private void InitializeComponent()
        {
            this.btnEasySearch.Click += new EventHandler(this.btnEasySearch_Click);
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            this.btnMailMerge.Click += new EventHandler(this.btnMailMerge_Click);
            this.btnReport.Click += new EventHandler(this.btnReport_Click);
            this.DataGrid2.ItemCreated += new DataGridItemEventHandler(this.DataGrid2_ItemCreated);
            this.DataGrid2.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid2_PageIndexChanged_1);
            this.DataGrid2.EditCommand += new DataGridCommandEventHandler(this.DataGrid2_EditCommand_1);
            this.DataGrid2.SortCommand += new DataGridSortCommandEventHandler(this.DataGrid2_SortCommand_1);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                LicenseType type1 = new LicenseType();
                type1.GetAllLicense();
                this.licenseTypeList.DataSource = type1.GetAllLicense();
                this.licenseTypeList.DataTextField = "LicenseName";
                this.licenseTypeList.DataBind();
                this.licenseTypeList.Items.Add("--Do Not Use--");
                int num1 = this.licenseTypeList.Items.Count - 1;
                this.licenseTypeList.SelectedIndex = num1;
                this.SortOrder.Text = "DESC";
            }
        }


        protected int _totalNumberOfPages;
        protected Button btnEasySearch;
        protected Button btnMailMerge;
        protected Button btnReport;
        protected Button btnSearch;
        protected Button Button1;
        protected DataGrid DataGrid1;
        protected DataGrid DataGrid2;
        private DataSet ds;
        protected HtmlForm Form1;
        protected Label Label11;
        protected Label Label12;
        protected Label Label17;
        protected Label Label2;
        protected Label Label4;
        protected Label Label5;
        protected Label lblAcctNum;
        protected Label lblAppaName;
        protected Label lblBusAdd;
        protected Label lblBusName;
        protected Label lblChNum;
        protected Label lblDrLic;
        protected Label lblExpDate;
        protected Label lblIsuDate;
        protected Label lblLegalId;
        protected Label lblLicName;
        protected Label lblLicNum;
        protected Label lblLicSt;
        protected Label lblLiqLic;
        protected Label lblOwAdd;
        protected Label lblOwName;
        protected Label lblPaidDt;
        protected Label lblPayType;
        protected Label lblSalexTax;
        protected Label lblSsn;
        protected Label lblStDate;
        protected Label lblType;
        protected Label lblVin;
        protected DropDownList licenseTypeList;
        protected DropDownList paymentList;
        protected string sortField;
        protected Label sortLable;
        protected Label SortOrder;
        protected DropDownList statusList;
        protected TextBox txtAcctNum;
        protected TextBox txtAppName;
        protected TextBox txtBusAdd;
        protected TextBox txtBusName;
        protected TextBox txtCheckNu;
        protected TextBox txtDriLic;
        protected TextBox txtEasySearch;
        protected TextBox txtExpDateOne;
        protected TextBox txtExpDateTwo;
        protected TextBox txtIsuDateOne;
        protected TextBox txtIsuDateTwo;
        protected TextBox txtLegalId;
        protected TextBox txtLicName;
        protected TextBox txtLicNo;
        protected TextBox txtLiqLic;
        protected TextBox txtOwAdd;
        protected TextBox txtOwName;
        protected TextBox txtPaidDateOne;
        protected TextBox txtPaidDateTwo;
        protected TextBox txtSalesTax;
        protected TextBox txtSsn;
        protected TextBox txtStDateOne;
        protected TextBox txtStDateTwo;
        protected TextBox txtVin;
    }
}


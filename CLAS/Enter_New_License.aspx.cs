namespace CLAS
{
    using CLAS.BusinessLogicLayer;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class New_License1 : Page
    {
        public New_License1()
        {
            this.license = new License();
        }

        private void btnGenerateLicense_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetValues();
                string text1 = this.license.InsertLicense();
                this.Session["licenseNumber"] = text1;
                this.Session["licenseType"] = this.license.TypeCode;
                this.btnGenerateLicense.Enabled = false;
                this.btnPrint.Enabled = true;
                this.lblTypeOfLicense.Text = "License: " + this.license.TypeCode + text1;
                this.Session["FirstTimeToPage"] = "NO";
            }
            catch
            {
                this.lblErrorMessage.Text = this.errorHandle;
            }
        }

        private void btnInsertPending_Click(object sender, EventArgs e)
        {
            this.SetValues();
            string text1 = this.license.InsertLicense();
            this.Session["licenseNumber"] = text1;
            this.Session["licenseType"] = this.license.TypeCode;
            this.btnInsertPending.Enabled = false;
            this.btnPrint.Enabled = true;
            this.lblTypeOfLicense.Text = "Licnese: " + text1;
        }

        private void drplstPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drplstPayType.SelectedValue == "CHECK")
            {
                this.validCheckNo.Enabled = true;
                this.lblCheckNo.ForeColor = Color.Red;
            }
            else
            {
                this.validCheckNo.Enabled = false;
                this.lblCheckNo.ForeColor = Color.Black;
            }
        }

        private void InitializeComponent()
        {
            this.drplstPayType.SelectedIndexChanged += new EventHandler(this.drplstPayType_SelectedIndexChanged);
            this.btnGenerateLicense.Click += new EventHandler(this.btnGenerateLicense_Click);
            this.btnInsertPending.Click += new EventHandler(this.btnInsertPending_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.btnPrint.Attributes.Add("onclick", "javascript: window.open('PrintLicense.aspx');");
            if (!base.IsPostBack)
            {
                New_License license1 = (New_License) this.Context.Handler;
                string text1 = license1.IssueDate;
                string text2 = license1.LicenseTypeCode;
                if (license1.Status == "PENDING")
                {
                    this.btnInsertPending.Visible = true;
                    this.btnInsertPending.Enabled = true;
                    this.btnGenerateLicense.Enabled = false;
                }
                LicenseType type1 = new LicenseType(text2);
                if (type1.LoadLicenseType())
                {
                    this.lblDyIssueDate.Text = text1;
                    this.txtDatePaid.Text = DateTime.Now.ToShortDateString();
                    this.txtAcctNum.Text = type1.AccountNumber;
                    this.txtLicFee.Text = type1.Fee.ToString().Remove(type1.Fee.ToString().Length - 2, 2);
                    this.lblTypeOfLicense.Text = this.lblTypeOfLicense.Text + " " + type1.TypeCode + "-" + type1.TypeName;
                    this.Label1.Text = type1.TypeCode;
                    this.rbtnFor.Checked = true;
                    this.rbtnManager.Checked = true;
                    if (text1 != "Pending")
                    {
                        DateTime time2;
                        if (type1.ExpDate == string.Empty)
                        {
                            if (type1.Days == 0)
                            {
                                time2 = Convert.ToDateTime(text1);
                                this.txtExpDate.Text = Convert.ToString(time2.AddMonths(type1.Months).ToShortDateString());
                            }
                            else
                            {
                                time2 = Convert.ToDateTime(text1);
                                this.txtExpDate.Text = time2.AddDays((double) type1.Days).ToShortDateString();
                            }
                        }
                        else
                        {
                            string text4 = type1.ExpDate.Substring(2, 2);
                            string text5 = type1.ExpDate.Substring(0, 2);
                            int num2 = DateTime.Now.Year;
                            object[] objArray1 = new object[5];
                            objArray1[0] = text5;
                            objArray1[1] = "/";
                            objArray1[2] = text4;
                            objArray1[3] = "/";
                            time2 = Convert.ToDateTime(text1);
                            objArray1[4] = time2.Year;
                            DateTime time1 = DateTime.Parse(string.Concat(objArray1));
                            if (time1 < Convert.ToDateTime(text1))
                            {
                                time1 = time1.AddYears(1);
                            }
                            this.txtExpDate.Text = time1.ToShortDateString();
                        }
                        this.license.ExpDate = Convert.ToDateTime(this.txtExpDate.Text);
                    }
                    else
                    {
                        this.txtExpDate.Text = "Pending";
                    }
                    if (type1.ANameReq == 1)
                    {
                        this.lblAppName.ForeColor = Color.Red;
                        this.validAppName.Enabled = true;
                    }
                    else if (type1.ANameInc == 0)
                    {
                        this.lblAppName.Text = "Applicants Name not included";
                        this.license.AName = string.Empty;
                        this.lblAppName.ForeColor = Color.LightGray;
                        this.txtAppName.Visible = false;
                    }
                    if (type1.LNameReq == 1)
                    {
                        this.lblLicName.ForeColor = Color.Red;
                        this.validLicName.Enabled = true;
                    }
                    else if (type1.LNameInc == 0)
                    {
                        this.txtLicName.Visible = false;
                        this.lblLicName.Text = "License Name not included";
                        this.lblLicName.ForeColor = Color.LightGray;
                        this.license.LName = string.Empty;
                    }
                    if (type1.MAddressReq == 1)
                    {
                        this.lblMailAddress.ForeColor = Color.Red;
                        this.validMailAddress.Enabled = true;
                    }
                    else if (type1.MAddressInc == 0)
                    {
                        this.lblMailAddress.ForeColor = Color.LightGray;
                        this.lblMailAddress.Text = "Mail Address not included";
                        this.txtMailAddress.Visible = false;
                        this.license.MAddr = string.Empty;
                    }
                    if (type1.MCityStZipReq == 1)
                    {
                        this.lblMailCst.ForeColor = Color.Red;
                        this.validMailCity.Enabled = true;
                        this.lblMailZip.ForeColor = Color.Red;
                        this.validMailState.Enabled = true;
                        this.validMailZip.Enabled = true;
                    }
                    else if (type1.MCityStZipInc == 0)
                    {
                        this.txtMailCity.Visible = false;
                        this.txtMailSt.Visible = false;
                        this.txtMailZip.Visible = false;
                        this.lblMailCst.Text = "Mail City/St not included";
                        this.lblMailCst.ForeColor = Color.LightGray;
                        this.lblMailZip.ForeColor = Color.LightGray;
                        this.lblMailZip.Text = "Mail Zip not included";
                    }
                    if (type1.ONameReq == 1)
                    {
                        this.lblOwName.ForeColor = Color.Red;
                        this.validOwName.Enabled = true;
                    }
                    else if (type1.ONameInc == 0)
                    {
                        this.txtOwName.Visible = false;
                        this.lblOwName.ForeColor = Color.LightGray;
                        this.lblOwName.Text = "Owner Name not included";
                    }
                    if (type1.OAddressReq == 1)
                    {
                        this.lblOwAddress.ForeColor = Color.Red;
                        this.validOwAddress.Enabled = true;
                    }
                    else if (type1.OAddressInc == 0)
                    {
                        this.txtOwAddress.Visible = false;
                        this.lblOwAddress.ForeColor = Color.LightGray;
                        this.lblOwAddress.Text = "Owner Address not included";
                    }
                    if (type1.OCityStZipReq == 1)
                    {
                        this.lblOwCST.ForeColor = Color.Red;
                        this.validOwCity.Enabled = true;
                        this.validOwSt.Enabled = true;
                        this.validOwZip.Enabled = true;
                        this.lblOwZip.ForeColor = Color.Red;
                    }
                    else if (type1.OCityStZipInc == 0)
                    {
                        this.txtOwCity.Visible = false;
                        this.txtOwSt.Visible = false;
                        this.txtOwZip.Visible = false;
                        this.lblOwCST.Text = "Owner City/St not included";
                        this.lblOwZip.Text = "Owner Zip included";
                        this.lblOwCST.ForeColor = Color.LightGray;
                        this.lblOwZip.ForeColor = Color.LightGray;
                    }
                    if (type1.OwPhoneReq == 1)
                    {
                        this.lblOwPhone.ForeColor = Color.Red;
                        this.validOwPhone.Enabled = true;
                    }
                    else if (type1.OwPhoneInc == 0)
                    {
                        this.txtOwPhone.Visible = false;
                        this.lblOwPhone.Text = "Owner Phone not included";
                        this.lblOwPhone.ForeColor = Color.LightGray;
                    }
                    if (type1.ZoningReq == 1)
                    {
                        this.lblZoning.ForeColor = Color.Red;
                        this.validZoning.Enabled = true;
                    }
                    else if (type1.ZoningInc == 0)
                    {
                        this.lblZoning.ForeColor = Color.LightGray;
                        this.lblZoning.Text = "Zoning not included";
                        this.txtZoning.Visible = false;
                    }
                    if (type1.BondReq == 1)
                    {
                        this.lblBondAmt.ForeColor = Color.Red;
                        this.validBondAmt.Enabled = true;
                        this.validBondDate.Enabled = true;
                        this.lblBondDate.ForeColor = Color.Red;
                    }
                    else if (type1.BondInc == 0)
                    {
                        this.txtBondAmt.Visible = false;
                        this.lblBondAmt.Text = "Bond not included";
                        this.lblBondAmt.ForeColor = Color.LightGray;
                        this.txtBondDate.Visible = false;
                        this.lblBondDate.Text = "Bond Date not included";
                        this.lblBondDate.ForeColor = Color.LightGray;
                    }
                    if (type1.BNameReq == 1)
                    {
                        this.lblBusName.ForeColor = Color.Red;
                        this.validBusName.Enabled = true;
                    }
                    else if (type1.BNameInc == 0)
                    {
                        this.txtBusName.Visible = false;
                        this.lblBusName.ForeColor = Color.LightGray;
                        this.lblBusName.Text = "Busness Name not included";
                    }
                    if (type1.BAddressReq == 1)
                    {
                        this.lblBusAddress.ForeColor = Color.Red;
                        this.validBusAddress.Enabled = true;
                    }
                    else if (type1.BAddressInc == 0)
                    {
                        this.txtBusAdd.Visible = false;
                        this.lblBusAddress.ForeColor = Color.LightGray;
                        this.lblBusAddress.Text = "Busness Name not included";
                    }
                    if (type1.BCityStZipReq == 1)
                    {
                        this.lblBusCst.ForeColor = Color.Red;
                        this.validBusCity.Enabled = true;
                        this.validBusSt.Enabled = true;
                        this.validBusZip.Enabled = true;
                        this.lblBusZip.ForeColor = Color.Red;
                    }
                    else if (type1.BCityStZipInc == 0)
                    {
                        this.txtBusCity.Visible = false;
                        this.txtBusSt.Visible = false;
                        this.txtBusZip.Visible = false;
                        this.lblBusCst.Text = "Busness City/St not included";
                        this.lblBusCst.ForeColor = Color.LightGray;
                        this.lblBusZip.Text = "Busness zip not included";
                        this.lblBusZip.ForeColor = Color.LightGray;
                    }
                    if (type1.BPhoneReq == 1)
                    {
                        this.lblBusPhone.ForeColor = Color.Red;
                        this.validBusPhone.Enabled = true;
                    }
                    else if (type1.BPhoneInc == 0)
                    {
                        this.lblBusPhone.Text = "Busness Phone not included";
                        this.lblBusPhone.ForeColor = Color.LightGray;
                        this.txtBusPhone.Visible = false;
                    }
                    if (type1.LiqLicReq == 1)
                    {
                        this.lblLiqLic.ForeColor = Color.Red;
                        this.validLiqLic.Enabled = true;
                    }
                    else if (type1.LiqLicInc == 0)
                    {
                        this.lblLiqLic.ForeColor = Color.LightGray;
                        this.lblLiqLic.Text = "St. Liq Lic not included";
                        this.txtLiqLic.Visible = false;
                    }
                    if (type1.SalesTaxReq == 1)
                    {
                        this.lblSalesTax.ForeColor = Color.Red;
                        this.validSalesTax.Enabled = true;
                    }
                    else if (type1.SalesTaxInc == 0)
                    {
                        this.lblSalesTax.ForeColor = Color.LightGray;
                        this.lblSalesTax.Text = "Sales Tax not included";
                        this.txtSalesTax.Visible = false;
                    }
                    if (type1.LegalIdReq == 1)
                    {
                        this.lblLegalId.ForeColor = Color.Red;
                        this.validLeqalId.Enabled = true;
                    }
                    else if (type1.LegalIdInc == 0)
                    {
                        this.lblLegalId.ForeColor = Color.LightGray;
                        this.lblLegalId.Text = "Legal Id not included";
                        this.txtLegalId.Visible = false;
                    }
                    if (type1.VinReq == 1)
                    {
                        this.lblVin.ForeColor = Color.Red;
                        this.validVin.Enabled = true;
                    }
                    else if (type1.VinInc == 0)
                    {
                        this.lblVin.ForeColor = Color.LightGray;
                        this.lblVin.Text = "Vin not included";
                        this.txtVin.Visible = false;
                    }
                    if (type1.InsuranceReq == 1)
                    {
                        this.lblInsuDate.ForeColor = Color.Red;
                        this.validInsuDate.Enabled = true;
                    }
                    else if (type1.InsuranceInc == 0)
                    {
                        this.lblInsuDate.ForeColor = Color.LightGray;
                        this.lblInsuDate.Text = "Ins Date not included";
                        this.txtInsuDate.Visible = false;
                    }
                }
            }
        }

        private void SetValues()
        {
            this.license.TypeCode = this.Label1.Text;
            this.license.AcctNo = CLAS_Security.CleanStringRegex(this.txtAcctNum.Text);
            this.license.AName = CLAS_Security.CleanStringRegex(this.txtAppName.Text);
            this.license.BAddr = CLAS_Security.CleanStringRegex(this.txtBusAdd.Text);
            this.license.BCity = CLAS_Security.CleanStringRegex(this.txtBusCity.Text);
            this.license.BName = CLAS_Security.CleanStringRegex(this.txtBusName.Text);
            this.errorHandle = "Check the Bond Amount. Invalid number";
            this.license.BondAmt = (this.txtBondAmt.Text != string.Empty) ? Convert.ToDecimal(CLAS_Security.CleanStringRegex(this.txtBondAmt.Text)) : new decimal(0);
            this.errorHandle = "Check the Bond Date. Invalid Date mm/dd/yyyy";
            this.license.BondDate = (this.txtBondDate.Text == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(this.txtBondDate.Text);
            this.license.BPhone = CLAS_Security.CleanStringRegex(this.txtBusPhone.Text);
            this.license.BState = CLAS_Security.CleanStringRegex(this.txtBusSt.Text);
            this.license.BZip = CLAS_Security.CleanStringRegex(this.txtBusZip.Text);
            this.license.CheckNo = CLAS_Security.CleanStringRegex(this.txtCheckNo.Text);
            this.license.DbaFor = this.rbtnDba.Checked ? "DBA" : "FOR";
            this.license.DriverLic = "";
            this.license.Fee = Convert.ToDecimal(CLAS_Security.CleanStringRegex(this.txtLicFee.Text));
            this.errorHandle = "Check the Insurance Date. Invalid Date mm/dd/yyyy.";
            this.license.InsDate = (this.txtInsuDate.Text == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(this.txtInsuDate.Text);
            this.license.LegalId = CLAS_Security.CleanStringRegex(this.txtLegalId.Text);
            this.license.InsAmt = new decimal(0);
            this.license.LicStat = (this.lblDyIssueDate.Text == "Pending") ? "PENDING" : "ACTIVE";
            this.license.LiqLic = CLAS_Security.CleanStringRegex(this.txtLiqLic.Text);
            this.license.LName = CLAS_Security.CleanStringRegex(this.txtLicName.Text);
            this.license.MAddr = CLAS_Security.CleanStringRegex(this.txtMailAddress.Text);
            this.license.MCity = CLAS_Security.CleanStringRegex(this.txtMailCity.Text);
            this.license.MState = CLAS_Security.CleanStringRegex(this.txtMailSt.Text);
            this.license.MZip = CLAS_Security.CleanStringRegex(this.txtMailZip.Text);
            this.license.OAddr = CLAS_Security.CleanStringRegex(this.txtOwAddress.Text);
            this.license.OCity = CLAS_Security.CleanStringRegex(this.txtOwCity.Text);
            this.license.OName = CLAS_Security.CleanStringRegex(this.txtOwName.Text);
            this.license.Notes = CLAS_Security.CleanStringRegex(this.txtNotes.Text);
            this.license.OPhone = CLAS_Security.CleanStringRegex(this.txtOwPhone.Text);
            this.license.OState = CLAS_Security.CleanStringRegex(this.txtOwSt.Text);
            this.license.OwMgr = this.rbtnOwner.Checked ? "OWNER" : "MANAGER";
            this.license.OZip = CLAS_Security.CleanStringRegex(this.txtOwZip.Text);
            this.errorHandle = "Check the Paid Date. Invalid Date mm/dd/yyyy.";
            this.license.PaidDate = Convert.ToDateTime(this.txtDatePaid.Text);
            this.license.PayType = this.drplstPayType.SelectedValue;
            this.license.SalesTax = CLAS_Security.CleanStringRegex(this.txtSalesTax.Text);
            this.license.Ssn = "";
            this.license.StatDate = DateTime.Now;
            this.license.Vin = CLAS_Security.CleanStringRegex(this.txtVin.Text);
            this.license.IssueDate = (this.lblDyIssueDate.Text == "Pending") ? DateTime.MinValue : Convert.ToDateTime(this.lblDyIssueDate.Text);
            this.license.ExpDate = (this.txtExpDate.Text == "Pending") ? DateTime.MinValue : Convert.ToDateTime(this.txtExpDate.Text);
            this.license.Zoning = CLAS_Security.CleanStringRegex(this.txtZoning.Text);
            this.license.EmailAddress = CLAS_Security.CleanStringRegex(this.txtEmailAddress.Text);
            this.license.Notes = this.txtNotes.Text;
            this.errorHandle = "";
        }


        protected Button btnGenerateLicense;
        protected Button btnInsertPending;
        protected Button btnPrint;
        protected DropDownList drplstPayType;
        protected string errorHandle;
        protected Label Label1;
        protected Label Label30;
        protected Label lblAcctNum;
        protected Label lblAppName;
        protected Label lblBondAmt;
        protected Label lblBondDate;
        protected Label lblBusAddress;
        protected Label lblBusCst;
        protected Label lblBusName;
        protected Label lblBusPhone;
        protected Label lblBusZip;
        protected Label lblCheckNo;
        protected Label lblDatePaid;
        protected Label lblDrLic;
        protected Label lblDyIssueDate;
        protected Label lblEmail;
        protected Label lblErrorMessage;
        protected Label lblExpDate;
        protected Label lblInsuDate;
        protected Label lblIssueDate;
        protected Label lblLegalId;
        protected Label lblLicFee;
        protected Label lblLicName;
        protected Label lblLiqLic;
        protected Label lblMailAddress;
        protected Label lblMailCst;
        protected Label lblMailZip;
        protected Label lblOwAddress;
        protected Label lblOwCST;
        protected Label lblOwName;
        protected Label lblOwPhone;
        protected Label lblOwZip;
        protected Label lblPayType;
        protected Label lblSalesTax;
        protected Label lblSsn;
        protected Label lblTypeOfLicense;
        protected Label lblVin;
        protected Label lblZoning;
        protected License license;
        protected RadioButton rbtnDba;
        protected RadioButton rbtnFor;
        protected RadioButton rbtnManager;
        protected RadioButton rbtnOwner;
        protected TextBox txtAcctNum;
        protected TextBox txtAppName;
        protected TextBox txtBondAmt;
        protected TextBox txtBondDate;
        protected TextBox txtBusAdd;
        protected TextBox txtBusCity;
        protected TextBox txtBusName;
        protected TextBox txtBusPhone;
        protected TextBox txtBusSt;
        protected TextBox txtBusZip;
        protected TextBox txtCheckNo;
        protected TextBox txtDatePaid;
        protected TextBox txtDriverLic;
        protected TextBox txtEmailAddress;
        protected TextBox txtExpDate;
        protected TextBox txtInsuDate;
        protected TextBox txtLegalId;
        protected TextBox txtLicFee;
        protected TextBox txtLicName;
        protected TextBox txtLiqLic;
        protected TextBox txtMailAddress;
        protected TextBox txtMailCity;
        protected TextBox txtMailSt;
        protected TextBox txtMailZip;
        protected TextBox txtNotes;
        protected TextBox txtOwAddress;
        protected TextBox txtOwCity;
        protected TextBox txtOwName;
        protected TextBox txtOwPhone;
        protected TextBox txtOwSt;
        protected TextBox txtOwZip;
        protected TextBox txtSalesTax;
        protected TextBox txtSsn;
        protected TextBox txtVin;
        protected TextBox txtZoning;
        public string typeCode;
        protected RequiredFieldValidator validAppName;
        protected ValidationSummary ValidationSummary1;
        protected RequiredFieldValidator validBondAmt;
        protected RequiredFieldValidator validBondDate;
        protected RequiredFieldValidator validBusAddress;
        protected RequiredFieldValidator validBusCity;
        protected RequiredFieldValidator validBusName;
        protected RequiredFieldValidator validBusPhone;
        protected RequiredFieldValidator validBusSt;
        protected RequiredFieldValidator validBusZip;
        protected RequiredFieldValidator validCheckNo;
        protected RequiredFieldValidator validDriverLic;
        protected RequiredFieldValidator validInsuDate;
        protected RequiredFieldValidator validLeqalId;
        protected RequiredFieldValidator validLicName;
        protected RequiredFieldValidator validLiqLic;
        protected RequiredFieldValidator validMailAddress;
        protected RequiredFieldValidator validMailCity;
        protected RequiredFieldValidator validMailState;
        protected RequiredFieldValidator validMailZip;
        protected RequiredFieldValidator validOwAddress;
        protected RequiredFieldValidator validOwCity;
        protected RequiredFieldValidator validOwName;
        protected RequiredFieldValidator validOwPhone;
        protected RequiredFieldValidator validOwSt;
        protected RequiredFieldValidator validOwZip;
        protected RequiredFieldValidator validSalesTax;
        protected RequiredFieldValidator validSsn;
        protected RequiredFieldValidator validVin;
        protected RequiredFieldValidator validZoning;
    }
}


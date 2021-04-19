namespace CLAS
{
    using CLAS.BusinessLogicLayer;
    using System;
    using System.Drawing;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Modify_Licnese : Page
    {
        private void btnActivate_Click(object sender, EventArgs e)
        {
            string text1 = Convert.ToString(this.Session["licenseNumber"]);
            if (text1.Substring(0, 4) == "PEND")
            {
                this.txtExpDate.Enabled = true;
                this.lblStatus.Text = "Pending";
                this.txtExpDate.Text = "";
                this.txtIssueDate.Text = DateTime.Now.ToShortDateString();
                this.CalculateLicenseTypeValues(this.txtIssueDate.Text);
                this.vaildExpDate.Enabled = true;
                this.vaildIssueDate.Enabled = true;
                this.btnUpdateLicense.Enabled = false;
                this.btnRenew.Enabled = false;
                this.btnActivate.Enabled = false;
                this.btnUpdateLicense.Enabled = true;
                this.btnPrint.Enabled = false;
                this.btnRevoke.Enabled = false;
                this.btnSurrender.Enabled = false;
                this.btnUpdateLicense.Text = "Insert";
                this.btnDelete.Enabled = false;
                this.CheckRequiredFields(true);
                this.txtIssueDate.Enabled = true;
                this.txtIssueDate.ReadOnly = false;
                this.btnUpdateLicense.Enabled = true;
                this.lblLicense.Text = "Activating License " + text1;
                string text2 = "<script language= 'javascript'> alert('Please Check the issue date and experation date. If everthing is correct then click the [INSERT] button.');</script>";
                this.Page.RegisterStartupScript("PopupScript", text2);
            }
            else if (Convert.ToDateTime(this.txtExpDate.Text) < DateTime.Now)
            {
                string text3 = "<script language= 'javascript'> alert('The Expiration Date has passed for this license. Renew the license.');</script>";
                this.Page.RegisterStartupScript("PopupScript", text3);
            }
            else
            {
                this.SetLicenseValues("ACTIVE");
                this.license.UpdateLicense();
                this.lblLicense.Text = "License: " + this.license.TypeCode + this.license.LicNo;
                this.EnableTextBoxes(true);
                this.txtRenew.Text = "false";
                this.btnRenew.Enabled = true;
                this.btnUpdateLicense.Text = "Update";
                this.btnUpdateLicense.Enabled = true;
                this.btnPrint.Enabled = true;
                this.btnPrint.Enabled = true;
                this.btnRevoke.Enabled = true;
                this.btnSurrender.Enabled = true;
                this.txtIssueDate.Enabled = false;
                this.txtExpDate.Enabled = true;
                this.btnActivate.Enabled = false;
                this.btnUpdateLicense.Text = "Update";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string text1 = Convert.ToString(this.Session["licenseNumber"]);
            this.SetLicenseValues("DELETED");
            this.license.UpdateLicense();
            this.lblLicense.Text = "License: " + text1 + " has been deleted.";
            this.btnActivate.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnPrint.Enabled = false;
            this.btnRevoke.Enabled = false;
            this.btnSurrender.Enabled = false;
            this.btnUpdateLicense.Enabled = false;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
        }

        private void btnRevoke_Click(object sender, EventArgs e)
        {
            this.SetLicenseValues("REVOKED");
            this.license.UpdateLicense();
            this.lblLicense.Text = this.licenseType.Text + Convert.ToString(this.Session["licenseNumber"]) + " Status:" + this.license.LicStat + "  as of " + this.license.StatDate.ToShortDateString();
            this.btnRevoke.Enabled = false;
            this.btnActivate.Enabled = true;
            this.btnPrint.Enabled = false;
            this.btnSurrender.Enabled = false;
            this.CheckRequiredFields(false);
            this.SetValidation(false);
            this.btnUpdateLicense.Enabled = false;
            this.lblStatus.Text = "REVOKED";
        }

        private void btnSurrender_Click(object sender, EventArgs e)
        {
            this.SetLicenseValues("SURRENDER");
            this.license.UpdateLicense();
            this.lblLicense.Text = this.licenseType.Text + Convert.ToString(this.Session["licenseNumber"]) + " Status:" + this.license.LicStat + "  as of " + this.license.StatDate.ToShortDateString();
            this.btnActivate.Enabled = true;
            this.btnRevoke.Enabled = false;
            this.btnSurrender.Enabled = false;
            this.CheckRequiredFields(false);
            this.SetValidation(false);
            this.btnPrint.Enabled = false;
            this.lblStatus.Text = "SURRENDER";
        }

        private void btnUpdateLicense_Click(object sender, EventArgs e)
        {
            if (this.btnUpdateLicense.Text == "Update")
            {
                this.SetLicenseValues(this.lblStatus.Text);
                try
                {
                    this.license.UpdateLicense();
                }
                catch (Exception exception1)
                {
                    this.lblEmail.Text = exception1.ToString();
                }
            }
            else if (this.lblStatus.Text == "NewPending")
            {
                this.SetLicenseValues("Pending");
                this.lblStatus.Text = "Pending";
                this.txtRenew.Text = "false";
                this.btnActivate.Enabled = true;
                this.btnDelete.Enabled = true;
                this.btnUpdateLicense.Text = "Update";
                this.btnUpdateLicense.Enabled = true;
                this.btnPrint.Enabled = true;
                string text1 = this.license.InsertLicense();
                this.lblLicense.Text = "License: " + this.license.TypeCode + text1;
                this.Session["licenseNumber"] = text1;
            }
            else if (this.lblStatus.Text == "Pending")
            {
                this.license.RemoveLicense();
                this.lblStatus.Text = "ACTIVE";
                this.SetLicenseValues("ACTIVE");
                this.txtRenew.Text = "false";
                this.btnRenew.Enabled = true;
                this.btnUpdateLicense.Text = "Update";
                this.btnUpdateLicense.Enabled = true;
                this.btnPrint.Enabled = true;
                this.btnPrint.Enabled = true;
                this.btnRevoke.Enabled = true;
                this.btnSurrender.Enabled = true;
                this.txtIssueDate.Enabled = true;
                this.txtExpDate.Enabled = true;
                this.btnActivate.Enabled = false;
                this.btnDelete.Enabled = true;
                this.txtRenew.Text = "false";
                string text2 = this.license.InsertLicense();
                this.lblLicense.Text = "License: " + this.license.TypeCode + text2;
                this.btnUpdateLicense.Text = "Update";
                this.Session["licenseNumber"] = text2;
            }
            else if ((this.lblStatus.Text == "ACTIVE") || (this.lblStatus.Text == "EXPIRED"))
            {
                string text3 = Convert.ToString(this.Session["licenseNumber"]);
                this.license.LicNo = text3;
                this.lblStatus.Text = "ACTIVE";
                this.SetLicenseValues("ACTIVE");
                this.txtRenew.Text = "false";
                this.btnRenew.Enabled = true;
                this.btnUpdateLicense.Text = "Update";
                this.btnUpdateLicense.Enabled = true;
                this.btnPrint.Enabled = true;
                this.btnPrint.Enabled = true;
                this.btnRevoke.Enabled = true;
                this.btnSurrender.Enabled = true;
                this.txtIssueDate.Enabled = false;
                this.txtExpDate.Enabled = true;
                this.btnActivate.Enabled = false;
                this.btnUpdateLicense.Text = "Update";
                string text4 = this.license.InsertLicense();
                this.lblLicense.Text = "License: " + this.license.TypeCode + text4;
                this.Session["licenseNumber"] = text4;
            }
        }

        private void CalculateLicenseTypeValues(string issueDate)
        {
            DateTime time2;
            LicenseType type1 = new LicenseType(this.licenseType.Text);
            type1.LoadLicenseType();
            this.txtLicFee.Text = type1.Fee.ToString().Remove(type1.Fee.ToString().Length - 2, 2);
            if (type1.ExpDate == string.Empty)
            {
                if (type1.Days == 0)
                {
                    time2 = Convert.ToDateTime(issueDate);
                    this.txtExpDate.Text = Convert.ToString(time2.AddMonths(type1.Months).ToShortDateString());
                    this.txtIssueDate.Text = issueDate;
                }
                else
                {
                    time2 = Convert.ToDateTime(issueDate);
                    this.txtExpDate.Text = time2.AddDays((double) type1.Days).ToShortDateString();
                    this.txtIssueDate.Text = issueDate;
                }
            }
            else
            {
                string text1 = type1.ExpDate.Substring(2, 2);
                string text2 = type1.ExpDate.Substring(0, 2);
                time2 = Convert.ToDateTime(issueDate);
                int num2 = time2.Year;
                object[] objArray1 = new object[5];
                objArray1[0] = text2;
                objArray1[1] = "/";
                objArray1[2] = text1;
                objArray1[3] = "/";
                time2 = Convert.ToDateTime(issueDate);
                objArray1[4] = time2.Year;
                DateTime time1 = DateTime.Parse(string.Concat(objArray1));
                if (time1 < Convert.ToDateTime(issueDate))
                {
                    time1 = time1.AddYears(1);
                }
                this.txtExpDate.Text = time1.ToShortDateString();
                this.license.ExpDate = time1;
            }
        }

        private void CheckRequiredFields(bool editTextBox)
        {
            this.lblIssueDate.ForeColor = Color.Red;
            this.lblExpDate.ForeColor = Color.Red;
            this.rbtnDba.Enabled = editTextBox;
            this.rbtnFor.Enabled = editTextBox;
            this.rbtnManager.Enabled = editTextBox;
            this.rbtnOwner.Enabled = editTextBox;
            this.txtCheckNo.Enabled = editTextBox;
            this.txtAcctNum.Enabled = editTextBox;
            this.txtCheckNo.Enabled = editTextBox;
            this.txtDatePaid.Enabled = editTextBox;
            this.txtExpDate.Enabled = editTextBox;
            this.txtNotes.Enabled = editTextBox;
            this.txtLicFee.Enabled = editTextBox;
            this.drplstPayType.Enabled = editTextBox;
            this.licenseType.Text = Convert.ToString(this.Session["licenseType"]);
            LicenseType type1 = new LicenseType(this.licenseType.Text);
            type1.LoadLicenseType();
            if (type1.ANameReq == 1)
            {
                this.lblAppName.ForeColor = Color.Red;
                this.validAppName.Enabled = true;
                this.txtAppName.Enabled = editTextBox;
            }
            else if (type1.ANameInc == 0)
            {
                this.lblAppName.Text = "Applicants Name not included";
                this.lblAppName.ForeColor = Color.LightGray;
                this.txtAppName.Visible = false;
            }
            else
            {
                this.txtAppName.Enabled = editTextBox;
            }
            if (type1.LNameReq == 1)
            {
                this.lblLicName.ForeColor = Color.Red;
                this.validLicName.Enabled = true;
                this.txtLicName.Enabled = editTextBox;
            }
            else if (type1.LNameInc == 0)
            {
                this.txtLicName.Visible = false;
                this.lblLicName.Text = "License Name not included";
                this.lblLicName.ForeColor = Color.LightGray;
            }
            else
            {
                this.txtLicName.Enabled = editTextBox;
            }
            if (type1.MAddressReq == 1)
            {
                this.lblMailAddress.ForeColor = Color.Red;
                this.validMailAddress.Enabled = true;
                this.txtMailAddress.Enabled = editTextBox;
            }
            else if (type1.MAddressInc == 0)
            {
                this.lblMailAddress.ForeColor = Color.LightGray;
                this.lblMailAddress.Text = "Mail Address not included";
                this.txtMailAddress.Visible = false;
            }
            else
            {
                this.txtMailAddress.Enabled = editTextBox;
            }
            if (type1.MCityStZipReq == 1)
            {
                this.lblMailCst.ForeColor = Color.Red;
                this.validMailCity.Enabled = true;
                this.lblMailZip.ForeColor = Color.Red;
                this.validMailState.Enabled = true;
                this.validMailZip.Enabled = true;
                this.txtMailCity.Enabled = editTextBox;
                this.txtMailSt.Enabled = editTextBox;
                this.txtMailZip.Enabled = editTextBox;
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
            else
            {
                this.txtMailCity.Enabled = editTextBox;
                this.txtMailSt.Enabled = editTextBox;
                this.txtMailZip.Enabled = editTextBox;
            }
            if (type1.ONameReq == 1)
            {
                this.lblOwName.ForeColor = Color.Red;
                this.validOwName.Enabled = true;
                this.txtOwName.Enabled = editTextBox;
            }
            else if (type1.ONameInc == 0)
            {
                this.txtOwName.Visible = false;
                this.lblOwName.ForeColor = Color.LightGray;
                this.lblOwName.Text = "Owner Name not included";
            }
            else
            {
                this.txtOwName.Enabled = editTextBox;
            }
            if (type1.OAddressReq == 1)
            {
                this.lblOwAddress.ForeColor = Color.Red;
                this.validOwAddress.Enabled = true;
                this.txtOwAddress.Enabled = editTextBox;
            }
            else if (type1.OAddressInc == 0)
            {
                this.txtOwAddress.Visible = false;
                this.lblOwAddress.ForeColor = Color.LightGray;
                this.lblOwAddress.Text = "Owner Address not included";
            }
            else
            {
                this.txtOwAddress.Enabled = editTextBox;
            }
            if (type1.OCityStZipReq == 1)
            {
                this.lblOwCST.ForeColor = Color.Red;
                this.validOwCity.Enabled = true;
                this.validOwSt.Enabled = true;
                this.validOwZip.Enabled = true;
                this.lblOwZip.ForeColor = Color.Red;
                this.txtOwCity.Enabled = editTextBox;
                this.txtOwSt.Enabled = editTextBox;
                this.txtOwZip.Enabled = editTextBox;
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
            else
            {
                this.txtOwCity.Enabled = editTextBox;
                this.txtOwSt.Enabled = editTextBox;
                this.txtOwZip.Enabled = editTextBox;
            }
            if (type1.OwPhoneReq == 1)
            {
                this.lblOwPhone.ForeColor = Color.Red;
                this.validOwPhone.Enabled = true;
                this.txtOwPhone.Enabled = editTextBox;
            }
            else if (type1.OwPhoneInc == 0)
            {
                this.txtOwPhone.Visible = false;
                this.lblOwPhone.Text = "Owner Phone not included";
                this.lblOwPhone.ForeColor = Color.LightGray;
            }
            else
            {
                this.txtOwPhone.Enabled = editTextBox;
            }
            if (type1.ZoningReq == 1)
            {
                this.lblZoning.ForeColor = Color.Red;
                this.validZoning.Enabled = true;
                this.txtZoning.Enabled = editTextBox;
            }
            else if (type1.ZoningInc == 0)
            {
                this.lblZoning.ForeColor = Color.LightGray;
                this.lblZoning.Text = "Zoning not included";
                this.txtZoning.Visible = false;
            }
            else
            {
                this.txtZoning.Enabled = editTextBox;
            }
            if (type1.BondReq == 1)
            {
                this.lblBondAmt.ForeColor = Color.Red;
                this.validBondAmt.Enabled = true;
                this.validBondDate.Enabled = true;
                this.lblBondDate.ForeColor = Color.Red;
                this.txtBondAmt.Enabled = editTextBox;
                this.txtBondDate.Enabled = editTextBox;
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
            else
            {
                this.txtBondAmt.Enabled = editTextBox;
                this.txtBondDate.Enabled = editTextBox;
            }
            if (type1.BNameReq == 1)
            {
                this.lblBusName.ForeColor = Color.Red;
                this.validBusName.Enabled = true;
                this.txtBusName.Enabled = editTextBox;
                if (this.txtBusName.Text == string.Empty)
                {
                    this.validBusName.Enabled = false;
                }
            }
            else if (type1.BNameInc == 0)
            {
                this.txtBusName.Visible = false;
                this.lblBusName.ForeColor = Color.LightGray;
                this.lblBusName.Text = "Busness Name not included";
            }
            else
            {
                this.txtBusName.Enabled = editTextBox;
            }
            if (type1.BAddressReq == 1)
            {
                this.lblBusAddress.ForeColor = Color.Red;
                this.validBusAddress.Enabled = true;
                this.txtBusAdd.Enabled = editTextBox;
            }
            else if (type1.BAddressInc == 0)
            {
                this.txtBusAdd.Visible = false;
                this.lblBusAddress.ForeColor = Color.LightGray;
                this.lblBusAddress.Text = "Busness Name not included";
            }
            else
            {
                this.txtBusAdd.Enabled = editTextBox;
            }
            if (type1.BCityStZipReq == 1)
            {
                this.lblBusCst.ForeColor = Color.Red;
                this.validBusCity.Enabled = true;
                this.validBusSt.Enabled = true;
                this.validBusZip.Enabled = true;
                this.lblBusZip.ForeColor = Color.Red;
                this.txtBusCity.Enabled = editTextBox;
                this.txtBusSt.Enabled = editTextBox;
                this.txtBusZip.Enabled = editTextBox;
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
            else
            {
                this.txtBusCity.Enabled = editTextBox;
                this.txtBusSt.Enabled = editTextBox;
                this.txtBusZip.Enabled = editTextBox;
            }
            if (type1.BPhoneReq == 1)
            {
                this.lblBusPhone.ForeColor = Color.Red;
                this.validBusPhone.Enabled = true;
                this.txtBusPhone.Enabled = editTextBox;
            }
            else if (type1.BPhoneInc == 0)
            {
                this.lblBusPhone.Text = "Busness Phone not included";
                this.lblBusPhone.ForeColor = Color.LightGray;
                this.txtBusPhone.Visible = false;
            }
            else
            {
                this.txtBusPhone.Enabled = editTextBox;
            }
            if (type1.LiqLicReq == 1)
            {
                this.lblLiqLic.ForeColor = Color.Red;
                this.validLiqLic.Enabled = true;
                this.txtLiqLic.Enabled = editTextBox;
            }
            else if (type1.LiqLicInc == 0)
            {
                this.lblLiqLic.ForeColor = Color.LightGray;
                this.lblLiqLic.Text = "St. Liq Lic not included";
                this.txtLiqLic.Visible = false;
            }
            else
            {
                this.txtLiqLic.Enabled = editTextBox;
            }
            if (type1.SalesTaxReq == 1)
            {
                this.lblSalesTax.ForeColor = Color.Red;
                this.validSalesTax.Enabled = true;
                this.txtSalesTax.Enabled = editTextBox;
            }
            else if (type1.SalesTaxInc == 0)
            {
                this.lblSalesTax.ForeColor = Color.LightGray;
                this.lblSalesTax.Text = "Sales Tax not included";
                this.txtSalesTax.Visible = false;
            }
            else
            {
                this.txtSalesTax.Enabled = editTextBox;
            }
            if (type1.LegalIdReq == 1)
            {
                this.lblLegalId.ForeColor = Color.Red;
                this.validLeqalId.Enabled = true;
                this.txtLegalId.Enabled = editTextBox;
            }
            else if (type1.LegalIdInc == 0)
            {
                this.lblLegalId.ForeColor = Color.LightGray;
                this.lblLegalId.Text = "Legal Id not included";
                this.txtLegalId.Visible = false;
            }
            else
            {
                this.txtLegalId.Enabled = editTextBox;
            }
            if (type1.VinReq == 1)
            {
                this.lblVin.ForeColor = Color.Red;
                this.validVin.Enabled = true;
                this.txtVin.Enabled = editTextBox;
            }
            else if (type1.VinInc == 0)
            {
                this.lblVin.ForeColor = Color.LightGray;
                this.lblVin.Text = "Vin not included";
                this.txtVin.Visible = false;
            }
            else
            {
                this.txtVin.Enabled = editTextBox;
            }
            if (type1.InsuranceReq == 1)
            {
                this.lblInsuDate.ForeColor = Color.Red;
                this.validInsuDate.Enabled = true;
                this.txtInsuDate.Enabled = editTextBox;
            }
            else if (type1.InsuranceInc == 0)
            {
                this.lblInsuDate.ForeColor = Color.LightGray;
                this.lblInsuDate.Text = "Ins Date not included";
                this.txtInsuDate.Visible = false;
            }
            if (type1.EmailReq == 1)
            {
                this.lblEmail.ForeColor = Color.Red;
                this.txtEmailAddress.Enabled = editTextBox;
            }
            else if (type1.EmailInc == 0)
            {
                this.lblEmail.ForeColor = Color.LightGray;
                this.lblEmail.Text = "E-mail not included";
                this.txtEmailAddress.Visible = false;
            }
            else
            {
                this.txtEmailAddress.Enabled = editTextBox;
            }
        }

        private void EnableTextBoxes(bool enableTextBox)
        {
            this.txtBusName.Enabled = enableTextBox;
            this.txtBusAdd.Enabled = enableTextBox;
            this.txtBusCity.Enabled = enableTextBox;
            this.txtBusSt.Enabled = enableTextBox;
            this.txtBusZip.Enabled = enableTextBox;
            this.txtBusPhone.Enabled = enableTextBox;
            this.txtSsn.Enabled = enableTextBox;
            this.txtDriverLic.Enabled = enableTextBox;
            this.txtLiqLic.Enabled = enableTextBox;
            this.txtSalesTax.Enabled = enableTextBox;
            this.txtLegalId.Enabled = enableTextBox;
            this.txtVin.Enabled = enableTextBox;
            this.txtInsuDate.Enabled = enableTextBox;
            this.txtBondDate.Enabled = enableTextBox;
            this.txtExpDate.Enabled = enableTextBox;
            this.txtLicFee.Enabled = enableTextBox;
            this.txtCheckNo.Enabled = enableTextBox;
            this.txtNotes.Enabled = enableTextBox;
            this.txtLicName.Enabled = enableTextBox;
            this.txtMailAddress.Enabled = enableTextBox;
            this.txtMailCity.Enabled = enableTextBox;
            this.txtMailSt.Enabled = enableTextBox;
            this.txtMailZip.Enabled = enableTextBox;
            this.txtOwName.Enabled = enableTextBox;
            this.txtOwAddress.Enabled = enableTextBox;
            this.txtOwCity.Enabled = enableTextBox;
            this.txtOwSt.Enabled = enableTextBox;
            this.txtOwZip.Enabled = enableTextBox;
            this.txtOwPhone.Enabled = enableTextBox;
            this.txtZoning.Enabled = enableTextBox;
        }

        private void InitializeComponent()
        {
            this.btnRevoke.Click += new EventHandler(this.btnRevoke_Click);
            this.btnSurrender.Click += new EventHandler(this.btnSurrender_Click);
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnActivate.Click += new EventHandler(this.btnActivate_Click);
            this.btnRenew.Click += new EventHandler(this.btnRenew_Click);
            this.btnUpdateLicense.Click += new EventHandler(this.btnUpdateLicense_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.btnDelete.Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this license??');");
            this.btnPrint.Attributes.Add("onclick", "javascript: window.open('PrintLicense.aspx');");
            StringBuilder builder1 = new StringBuilder();
            builder1.Append("if (typeof(Page_ClientValidate) == 'function') { ");
            builder1.Append("if (Page_ClientValidate() == false) { return false; }} ");
            builder1.Append("this.value = 'Please wait...';");
            builder1.Append("this.disabled = true;");
            builder1.Append("btnUpdateLicense.disabled=true;");
            builder1.Append("btnActivate.disabled=true;");
            builder1.Append("btnDelete.disabled=true;");
            builder1.Append("btnPrint.disabled=true;");
            builder1.Append("btnRevoke.disabled=true;");
            builder1.Append("btnSurrender.disabled=true;");
            builder1.Append("btnUpdateLicense.disabled=true;");
            builder1.Append("OpenCalendar('txtIssueDate',true,'txtExpDate');");
            builder1.Append(";");
            this.btnRenew.Attributes.Add("onclick", builder1.ToString());
            string text3 = this.txtIssueDate.Text;
            if (!base.IsPostBack)
            {
                string text1 = Convert.ToString(this.Session["licenseNumber"]);
                this.licenseType.Text = Convert.ToString(this.Session["licenseType"]);
                this.license = new License(text1);
                this.license.SelectLicense();
                this.lblStatus.Text = this.license.LicStat;
                this.txtStatus.Text = this.license.LicStat;
                this.lblLicense.Text = this.lblLicense.Text + " " + this.licenseType.Text + text1 + " Status:" + this.license.LicStat + "  as of " + this.license.StatDate.ToShortDateString();
                bool flag1 = true;
                if (this.license.LicStat == "ACTIVE")
                {
                    flag1 = true;
                    this.btnActivate.Enabled = false;
                    this.btnPrint.Enabled = true;
                    this.CheckRequiredFields(true);
                }
                else if (this.license.LicStat == "PENDING")
                {
                    flag1 = true;
                    this.btnRenew.Enabled = false;
                    this.btnRevoke.Enabled = false;
                    this.btnSurrender.Enabled = false;
                    this.CheckRequiredFields(true);
                    this.btnPrint.Enabled = true;
                }
                else if ((this.license.LicStat == "SURRENDER") || (this.license.LicStat == "REVOKED"))
                {
                    flag1 = false;
                    this.btnRevoke.Enabled = false;
                    this.btnSurrender.Enabled = false;
                    this.CheckRequiredFields(false);
                    this.btnUpdateLicense.Enabled = false;
                    this.SetValidation(false);
                }
                else if (this.license.LicStat == "EXPIRED")
                {
                    flag1 = false;
                    this.btnUpdateLicense.Enabled = false;
                    this.btnActivate.Enabled = false;
                    this.btnRevoke.Enabled = false;
                    this.btnSurrender.Enabled = false;
                    this.CheckRequiredFields(false);
                    this.SetValidation(false);
                }
                else if (this.license.LicStat == "DELETED")
                {
                    flag1 = false;
                    this.btnUpdateLicense.Enabled = false;
                    this.btnDelete.Enabled = false;
                    this.btnActivate.Enabled = false;
                    this.btnRevoke.Enabled = false;
                    this.btnSurrender.Enabled = false;
                    this.CheckRequiredFields(false);
                    this.SetValidation(false);
                    this.btnRenew.Enabled = false;
                }
                this.txtDatePaid.Text = this.license.PaidDate.ToShortDateString();
                this.txtDatePaid.Enabled = flag1;
                this.txtExpDate.Text = (this.license.ExpDate == DateTime.MinValue) ? "PENDING" : this.license.ExpDate.ToShortDateString();
                this.txtExpDate.Enabled = flag1;
                if (this.license.Fee.ToString() != "0")
                {
                    this.txtLicFee.Text = this.license.Fee.ToString().Remove(this.license.Fee.ToString().Length - 2, 2);
                }
                else
                {
                    this.txtLicFee.Text = "0.00";
                }
                this.txtLicFee.Enabled = flag1;
                this.txtCheckNo.Text = this.license.CheckNo;
                this.txtCheckNo.Enabled = flag1;
                this.txtEmailAddress.Text = this.license.EmailAddress;
                this.txtEmailAddress.Enabled = flag1;
                this.txtIssueDate.Text = (this.license.IssueDate == DateTime.MinValue) ? "PENDING" : this.license.IssueDate.ToShortDateString();
                this.txtNotes.Text = this.license.Notes;
                this.txtNotes.Enabled = flag1;
                this.txtAcctNum.Text = this.license.AcctNo;
                this.txtAcctNum.Enabled = flag1;
                this.rbtnOwner.Enabled = flag1;
                this.rbtnDba.Enabled = flag1;
                this.drplstPayType.Enabled = flag1;
                this.rbtnFor.Enabled = flag1;
                this.rbtnManager.Enabled = flag1;
                this.txtAppName.Text = this.license.AName;
                this.txtLicName.Text = this.license.LName;
                this.txtBondAmt.Text = this.license.BondAmt.ToString();
                this.txtBondDate.Text = this.license.BondDate.ToShortDateString();
                this.txtVin.Text = this.license.Vin;
                this.txtBusAdd.Text = this.license.BAddr;
                this.txtBusCity.Text = this.license.BCity;
                this.txtBusName.Text = this.license.BName;
                this.txtBusPhone.Text = this.license.BPhone;
                this.txtBusSt.Text = this.license.BState;
                this.txtBusZip.Text = this.license.BZip;
                this.txtDriverLic.Text = this.license.DriverLic;
                this.txtEmailAddress.Text = this.license.EmailAddress;
                this.txtLegalId.Text = this.license.LegalId;
                this.txtLiqLic.Text = this.license.LiqLic;
                this.txtMailAddress.Text = this.license.MAddr;
                this.txtMailCity.Text = this.license.MCity;
                this.txtMailSt.Text = this.license.MState;
                this.txtMailZip.Text = this.license.MZip;
                this.txtInsuDate.Text = this.license.InsDate.ToShortDateString();
                this.txtOwAddress.Text = this.license.OAddr;
                this.txtOwCity.Text = this.license.OCity;
                this.txtOwName.Text = this.license.OName;
                this.txtOwPhone.Text = this.license.OPhone;
                this.txtOwSt.Text = this.license.OState;
                this.txtOwZip.Text = this.license.OZip;
                this.txtSalesTax.Text = this.license.SalesTax;
                this.txtSsn.Text = this.license.Ssn;
                this.txtVin.Text = this.license.Vin;
                this.txtZoning.Text = this.license.Zoning;
                ListItem item1 = this.drplstPayType.Items.FindByValue(this.license.PayType);
                item1.Selected = true;
                if (this.license.OwMgr == "OWNER")
                {
                    this.rbtnOwner.Checked = true;
                }
                else
                {
                    this.rbtnManager.Checked = true;
                }
                if (this.license.DbaFor == "DBA")
                {
                    this.rbtnDba.Checked = true;
                }
                else
                {
                    this.rbtnFor.Checked = true;
                }
            }
            else
            {
                string text2 = Convert.ToString(this.Session["licenseNumber"]);
                this.license = new License(text2);
                if (this.txtRenew.Text == "true")
                {
                    this.txtRenew.Text = "false";
                    this.btnRenew.Enabled = false;
                    this.CheckRequiredFields(true);
                    this.btnUpdateLicense.Enabled = true;
                    this.btnUpdateLicense.Text = "Insert";
                    this.lblLicense.Text = "Renew License for Type " + this.licenseType.Text;
                    this.txtIssueDate.Visible = true;
                    this.btnUpdateLicense.Text = "Insert";
                    this.btnActivate.Enabled = false;
                    this.btnDelete.Enabled = false;
                    this.btnPrint.Enabled = false;
                    this.btnRevoke.Enabled = false;
                    this.btnSurrender.Enabled = false;
                    this.txtIssueDate.Enabled = true;
                    this.txtDatePaid.Text = DateTime.Now.ToShortDateString();
                    this.txtCheckNo.Text = "";
                    this.vaildExpDate.Enabled = false;
                    this.vaildIssueDate.Enabled = false;
                    this.btnUpdateLicense.Enabled = false;
                    this.btnUpdateLicense.Enabled = true;
                    if (this.txtIssueDate.Text == "Pending")
                    {
                        this.txtExpDate.Text = "Pending";
                        this.lblStatus.Text = "NewPending";
                    }
                    else
                    {
                        this.CalculateLicenseTypeValues(this.txtIssueDate.Text);
                    }
                }
            }
        }

        private void SetLicenseValues(string status)
        {
            DateTime time1;
            this.license.TypeCode = this.licenseType.Text;
            this.license.LicNo = Convert.ToString(this.Session["licenseNumber"]);
            this.license.LicStat = status;
            this.license.AcctNo = CLAS_Security.CleanStringRegex(this.txtAcctNum.Text);
            this.license.AName = CLAS_Security.CleanStringRegex(this.txtAppName.Text);
            this.license.BAddr = CLAS_Security.CleanStringRegex(this.txtBusAdd.Text);
            this.license.BCity = CLAS_Security.CleanStringRegex(this.txtBusCity.Text);
            this.license.BName = CLAS_Security.CleanStringRegex(this.txtBusName.Text);
            this.errorHandle = "Check the Bond Amount. Invalid number";
            this.license.BondAmt = (this.txtBondAmt.Text != string.Empty) ? Convert.ToDecimal(CLAS_Security.CleanStringRegex(this.txtBondAmt.Text)) : new decimal(0);
            this.errorHandle = "Check the Bond Date. Invalid Date mm/dd/yyyy";
            this.license.BondDate = (this.txtBondDate.Text == string.Empty) ? DateTime.MinValue : (time1 = Convert.ToDateTime(this.txtBondDate.Text)).Date;
            this.license.BPhone = CLAS_Security.CleanStringRegex(this.txtBusPhone.Text);
            this.license.BState = CLAS_Security.CleanStringRegex(this.txtBusSt.Text);
            this.license.BZip = CLAS_Security.CleanStringRegex(this.txtBusZip.Text);
            this.license.CheckNo = CLAS_Security.CleanStringRegex(this.txtCheckNo.Text);
            this.license.DbaFor = this.rbtnDba.Checked ? "DBA" : "FOR";
            this.license.DriverLic = "";
            this.license.Fee = Convert.ToDecimal(CLAS_Security.CleanStringRegex(this.txtLicFee.Text));
            this.license.InsDate = (this.txtInsuDate.Text == string.Empty) ? DateTime.MinValue : (time1 = Convert.ToDateTime(this.txtInsuDate.Text)).Date;
            this.license.LegalId = CLAS_Security.CleanStringRegex(this.txtLegalId.Text);
            this.license.InsAmt = new decimal(0);
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
            this.license.StatDate = DateTime.Now.Date;
            this.license.Vin = CLAS_Security.CleanStringRegex(this.txtVin.Text);
            if ((this.txtIssueDate.Text == "Pending") || (this.txtIssueDate.Text == "PENDING"))
            {
                this.license.IssueDate = DateTime.MinValue;
            }
            else
            {
                time1 = Convert.ToDateTime(this.txtIssueDate.Text);
                this.license.IssueDate = time1.Date;
            }
            if ((this.txtExpDate.Text == "Pending") || (this.txtExpDate.Text == "PENDING"))
            {
                this.license.ExpDate = DateTime.MinValue;
            }
            else
            {
                time1 = Convert.ToDateTime(this.txtExpDate.Text);
                this.license.ExpDate = time1.Date;
            }
            this.license.Zoning = CLAS_Security.CleanStringRegex(this.txtZoning.Text);
            this.license.EmailAddress = CLAS_Security.CleanStringRegex(this.txtEmailAddress.Text);
            this.errorHandle = "";
        }

        private void SetValidation(bool checkValidation)
        {
            this.validAppName.Enabled = checkValidation;
            this.validLicName.Enabled = checkValidation;
            this.validMailAddress.Enabled = checkValidation;
            this.validMailCity.Enabled = checkValidation;
            this.validMailZip.Enabled = checkValidation;
            this.validOwName.Enabled = checkValidation;
            this.validOwAddress.Enabled = checkValidation;
            this.validOwSt.Enabled = checkValidation;
            this.validOwZip.Enabled = checkValidation;
            this.validOwPhone.Enabled = checkValidation;
            this.validZoning.Enabled = checkValidation;
            this.validBondAmt.Enabled = checkValidation;
            this.validOwCity.Enabled = checkValidation;
            this.validMailState.Enabled = checkValidation;
            this.validBusName.Enabled = checkValidation;
            this.validBusAddress.Enabled = checkValidation;
            this.validBusSt.Enabled = checkValidation;
            this.validBusZip.Enabled = checkValidation;
            this.validBusPhone.Enabled = checkValidation;
            this.validBusCity.Enabled = checkValidation;
            this.validLiqLic.Enabled = checkValidation;
            this.validSalesTax.Enabled = checkValidation;
            this.validLeqalId.Enabled = checkValidation;
            this.validVin.Enabled = checkValidation;
            this.validInsuDate.Enabled = checkValidation;
            this.validBondDate.Enabled = checkValidation;
        }


        protected Button btnActivate;
        protected Button btnDelete;
        protected Button btnPrint;
        protected Button btnRenew;
        protected Button btnRevoke;
        protected Button btnSurrender;
        protected Button btnUpdateLicense;
        protected DropDownList drplstPayType;
        protected string errorHandle;
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
        protected Label lblCheckPostBack;
        protected Label lblDatePaid;
        protected Label lblDrLic;
        protected Label lblEmail;
        protected Label lblErrorMessage;
        protected Label lblExpDate;
        protected Label lblFirstIssueDate;
        protected Label lblInsuDate;
        protected Label lblIssueDate;
        protected Label lblLegalId;
        protected Label lblLicense;
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
        protected Label lblStatus;
        protected Label lblVin;
        protected Label lblZoning;
        protected License license;
        protected Label licenseType;
        protected RadioButton rbtnDba;
        protected RadioButton rbtnFor;
        protected RadioButton rbtnManager;
        protected RadioButton rbtnOwner;
        protected string status;
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
        protected TextBox txtIssueDate;
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
        protected TextBox txtRenew;
        protected TextBox txtSalesTax;
        protected TextBox txtSsn;
        protected TextBox txtStatus;
        protected TextBox txtVin;
        protected TextBox txtZoning;
        public string typeCode;
        protected RequiredFieldValidator vaildExpDate;
        protected RequiredFieldValidator vaildIssueDate;
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
        protected RequiredFieldValidator validVin;
        protected RequiredFieldValidator validZoning;
    }
}


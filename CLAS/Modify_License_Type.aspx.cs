namespace CLAS
{
    using CLAS.BusinessLogicLayer;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Modify_License : Page
    {
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                this.lt.AccountNumber = this.txtAccountNum.Text;
                this.lt.TypeCode = this.txtTypeCode.Text;
                this.lt.TypeName = this.txtTypeName.Text;
                this.lt.Fee = Convert.ToDecimal(this.txtbxLicFee.Text);
                this.lt.Months = Convert.ToInt32(this.txtExpireMonth.Text);
                this.lt.Days = Convert.ToInt32(this.txtExpireDay.Text);
                if ((this.txtExpireDateMonth.Text.Length == 0) || (this.txtExpireDateDay.Text.Length == 0))
                {
                    this.lt.ExpDate = this.txtExpireDateMonth.Text + this.txtExpireDateDay.Text;
                }
                else
                {
                    this.lt.ExpDate = string.Empty;
                }
                this.lt.ANameInc = this.rbtnAppNameInc.Checked ? 1 : 0;
                this.lt.ANameReq = this.rbtnAppNameReq.Checked ? 1 : 0;
                this.lt.LNameInc = this.rbtnLicNamInc.Checked ? 1 : 0;
                this.lt.LNameReq = this.rbtnLicNamReq.Checked ? 1 : 0;
                this.lt.MAddressInc = this.rbtnMailAddInc.Checked ? 1 : 0;
                this.lt.MAddressReq = this.rbtnMailAddReq.Checked ? 1 : 0;
                this.lt.MCityStZipInc = this.rbtnMailCstInc.Checked ? 1 : 0;
                this.lt.MCityStZipReq = this.rbtnMailCstReq.Checked ? 1 : 0;
                this.lt.ONameInc = this.rbtnOwnerNameInc.Checked ? 1 : 0;
                this.lt.ONameReq = this.rbtnOwNameReq.Checked ? 1 : 0;
                this.lt.OAddressInc = this.rbtnOwAddInc.Checked ? 1 : 0;
                this.lt.OCityStZipInc = this.rbtnOwCstInc.Checked ? 1 : 0;
                this.lt.OCityStZipReq = this.rbtnOwCstReq.Checked ? 1 : 0;
                this.lt.OwPhoneInc = this.rbtnOwPhInc.Checked ? 1 : 0;
                this.lt.ANameInc = this.rbtnAppNameInc.Checked ? 1 : 0;
                this.lt.ANameReq = this.rbtnAppNameReq.Checked ? 1 : 0;
                this.lt.BNameInc = this.rbtnBusNameInc.Checked ? 1 : 0;
                this.lt.BNameReq = this.rbtnBusNameReq.Checked ? 1 : 0;
                this.lt.BAddressInc = this.rbtnBusAddInc.Checked ? 1 : 0;
                this.lt.BAddressReq = this.rbtnBusAddReq.Checked ? 1 : 0;
                this.lt.BCityStZipInc = this.rbtnBusCstInc.Checked ? 1 : 0;
                this.lt.BCityStZipReq = this.rbtnBusCstReq.Checked ? 1 : 0;
                this.lt.BPhoneInc = this.rbtnBusPhoInc.Checked ? 1 : 0;
                this.lt.BPhoneReq = this.rbtnBusPhoReq.Checked ? 1 : 0;
                this.lt.ZoningInc = this.rbtnZoningInc.Checked ? 1 : 0;
                this.lt.ZoningReq = this.rbtnZoningReq.Checked ? 1 : 0;
                this.lt.InsuranceInc = this.rbtnInsurInc.Checked ? 1 : 0;
                this.lt.InsuranceReq = this.rbtnInsuReq.Checked ? 1 : 0;
                this.lt.BondInc = this.rbtnBondInc.Checked ? 1 : 0;
                this.lt.BondReq = this.rbtnBondReq.Checked ? 1 : 0;
                this.lt.SsnInc = 1;
                this.lt.SsnReq = 0;
                this.lt.DriverLicInc = 1;
                this.lt.DriverLicReq = 0;
                this.lt.LiqLicInc = this.rbtnLiqLicInc.Checked ? 1 : 0;
                this.lt.LiqLicReq = this.rbtnLiqLicReq.Checked ? 1 : 0;
                this.lt.SalesTaxInc = this.rbtnSalesInc.Checked ? 1 : 0;
                this.lt.SalesTaxReq = this.rbtnSalesReq.Checked ? 1 : 0;
                this.lt.VinInc = this.rbtnVinInc.Checked ? 1 : 0;
                this.lt.VinReq = this.rbtnVinReq.Checked ? 1 : 0;
                this.lt.LegalIdInc = this.rbtnLegalInc.Checked ? 1 : 0;
                this.lt.LegalIdReq = this.rbtnLegalReq.Checked ? 1 : 0;
                this.lt.OAddressReq = this.rbtnOwAddReq.Checked ? 1 : 0;
                this.lt.OwPhoneReq = this.rbtnOwPhReq.Checked ? 1 : 0;
                this.lt.ONameReq = this.rbtnOwNameReq.Checked ? 1 : 0;
                this.lt.EmailInc = this.rbtnEmailInc.Checked ? 1 : 0;
                this.lt.EmailReq = this.rbtnEmailReq.Checked ? 1 : 0;
                if (this.btnUpdate.Text == "Update")
                {
                    this.lt.TypeCode = Convert.ToString(base.Request.QueryString[0]);
                    this.lt.UpdateType();
                }
                else
                {
                    try
                    {
                        this.lt.InsertType();
                        base.Response.Redirect("View_Document.aspx?" + this.lt.TypeCode);
                    }
                    catch (Exception exception1)
                    {
                        this.strMessage = "There was an error trying to insert the License Type!" + exception1;
                        string text1 = "<script language=JavaScript>alert('" + this.strMessage + "')</script>";
                        this.RegisterClientScriptBlock("showMessage", text1);
                    }
                }
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("View_Document.aspx?" + Convert.ToString(base.Request.QueryString[0]));
        }

        private void InitializeComponent()
        {
            this.btnViewReport.Click += new EventHandler(this.btnViewReport_Click);
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void lkbtnGoBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("View_Document.aspx?" + Convert.ToString(base.Request.QueryString[0]));
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (base.IsPostBack)
            {
                this.lt = new LicenseType();
            }
            else if (!base.IsPostBack)
            {
                if (Convert.ToString(base.Request.QueryString[0]) == "New")
                {
                    this.lt = new LicenseType();
                    this.btnUpdate.Text = "Insert";
                    this.lblLicType.Text = this.lblLicType.Text + " New Case.";
                    this.txtbxLicFee.Text = "0";
                    this.txtExpireDay.Text = "0";
                    this.txtExpireMonth.Text = "0";
                    this.rbtnAppNameNotInc.Checked = true;
                    this.rbtnAppNameNotReq.Checked = true;
                    this.rbtnBusAddNotInc.Checked = true;
                    this.rbtnBusAddNotReq.Checked = true;
                    this.rbtnBusAddNotInc.Checked = true;
                    this.rbtnBusCstNotReq.Checked = true;
                    this.rbtnBusNameNotInc.Checked = true;
                    this.rbtnBusNameNotReq.Checked = true;
                    this.rbtnBondNotInc.Checked = true;
                    this.rbtnBondNotReq.Checked = true;
                    this.rbtnBusPhoNotInc.Checked = true;
                    this.rbtnBusPhoNotReq.Checked = true;
                    this.rbtnInsuNotInc.Checked = true;
                    this.rbtnInsuNotReq.Checked = true;
                    this.rbtnLegalNotInc.Checked = true;
                    this.rbtnLegalNotReq.Checked = true;
                    this.rbtnLiqLicNotInc.Checked = true;
                    this.rbtnLiqLicNotReq.Checked = true;
                    this.rbtnLicNamNotInc.Checked = true;
                    this.rbtnLicNameNotReq.Checked = true;
                    this.rbtnMailAddNotInc.Checked = true;
                    this.rbtnMailAddNotReq.Checked = true;
                    this.rbtnMailCstNotInc.Checked = true;
                    this.rbtnMailCstNotReq.Checked = true;
                    this.rbtnOwAddNotInc.Checked = true;
                    this.rbtnOwNameNotInc.Checked = true;
                    this.rbtnOwAddNotReq.Checked = true;
                    this.rbtnOwCstNotInc.Checked = true;
                    this.rbtnOwCstNotReq.Checked = true;
                    this.rbtnOwnerNameInc.Checked = true;
                    this.rbtnOwNameNotReq.Checked = true;
                    this.rbtnOwPhNotInc.Checked = true;
                    this.rbtnOwPhNotReq.Checked = true;
                    this.rbtnSalesNotInc.Checked = true;
                    this.rbtnSalesNotReq.Checked = true;
                    this.rbtnVinNotInc.Checked = true;
                    this.rbtnVinNotReq.Checked = true;
                    this.rbtnZoningNotInc.Checked = true;
                    this.rbtnZoningNotReq.Checked = true;
                    this.rbtnEmailNotInc.Checked = true;
                    this.rbtnEmailNotReq.Checked = true;
                    this.btnViewReport.Enabled = false;
                }
                else
                {
                    this.lt = new LicenseType(Convert.ToString(base.Request.QueryString[0]));
                    try
                    {
                        this.lt.LoadLicenseType();
                    }
                    catch (Exception exception1)
                    {
                        this.lblLicType.Text = exception1.ToString();
                    }
                    this.lblLicType.Text = this.lblLicType.Text + " " + this.lt.TypeName;
                    this.txtAccountNum.Text = this.lt.AccountNumber;
                    this.txtTypeName.Text = this.lt.TypeName;
                    if (this.lt.ANameInc == 1)
                    {
                        this.rbtnAppNameInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnAppNameNotInc.Checked = true;
                    }
                    if (this.lt.ANameReq == 1)
                    {
                        this.rbtnAppNameReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnAppNameNotReq.Checked = true;
                    }
                    if (this.lt.BAddressInc == 1)
                    {
                        this.rbtnBusAddInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnBusAddNotInc.Checked = true;
                    }
                    if (this.lt.BAddressReq == 1)
                    {
                        this.rbtnBusAddReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnBusAddNotReq.Checked = true;
                    }
                    if (this.lt.BCityStZipInc == 1)
                    {
                        this.rbtnBusCstInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnBusAddNotInc.Checked = true;
                    }
                    if (this.lt.BCityStZipReq == 1)
                    {
                        this.rbtnBusCstReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnBusCstNotReq.Checked = true;
                    }
                    if (this.lt.BNameInc == 1)
                    {
                        this.rbtnBusNameInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnBusNameNotInc.Checked = true;
                    }
                    if (this.lt.BNameReq == 1)
                    {
                        this.rbtnBusNameReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnBusNameNotReq.Checked = true;
                    }
                    if (this.lt.BondInc == 1)
                    {
                        this.rbtnBondInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnBondNotInc.Checked = true;
                    }
                    if (this.lt.BondReq == 1)
                    {
                        this.rbtnBondReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnBondNotReq.Checked = true;
                    }
                    if (this.lt.BPhoneInc == 1)
                    {
                        this.rbtnBusPhoInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnBusPhoNotInc.Checked = true;
                    }
                    if (this.lt.BPhoneReq == 1)
                    {
                        this.rbtnBusPhoReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnBusPhoNotReq.Checked = true;
                    }
                    if (this.lt.InsuranceInc == 1)
                    {
                        this.rbtnInsurInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnInsuNotInc.Checked = true;
                    }
                    if (this.lt.InsuranceReq == 1)
                    {
                        this.rbtnInsuReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnInsuNotReq.Checked = true;
                    }
                    if (this.lt.LegalIdInc == 1)
                    {
                        this.rbtnLegalInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnLegalNotInc.Checked = true;
                    }
                    if (this.lt.LegalIdReq == 1)
                    {
                        this.rbtnLegalReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnLegalNotReq.Checked = true;
                    }
                    if (this.lt.LiqLicInc == 1)
                    {
                        this.rbtnLiqLicInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnLiqLicNotInc.Checked = true;
                    }
                    if (this.lt.LiqLicReq == 1)
                    {
                        this.rbtnLiqLicReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnLiqLicNotReq.Checked = true;
                    }
                    if (this.lt.LNameInc == 1)
                    {
                        this.rbtnLicNamInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnLicNamNotInc.Checked = true;
                    }
                    if (this.lt.LNameReq == 1)
                    {
                        this.rbtnLicNamReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnLicNameNotReq.Checked = true;
                    }
                    if (this.lt.MAddressInc == 1)
                    {
                        this.rbtnMailAddInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnMailAddNotInc.Checked = true;
                    }
                    if (this.lt.MAddressReq == 1)
                    {
                        this.rbtnMailAddReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnMailAddNotReq.Checked = true;
                    }
                    if (this.lt.MCityStZipInc == 1)
                    {
                        this.rbtnMailCstInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnMailCstNotInc.Checked = true;
                    }
                    if (this.lt.MCityStZipReq == 1)
                    {
                        this.rbtnMailCstReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnMailCstNotReq.Checked = true;
                    }
                    if (this.lt.OAddressInc == 1)
                    {
                        this.rbtnOwAddInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnOwAddNotInc.Checked = true;
                    }
                    if (this.lt.OAddressReq == 1)
                    {
                        this.rbtnOwAddReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnOwAddNotReq.Checked = true;
                    }
                    if (this.lt.OCityStZipInc == 1)
                    {
                        this.rbtnOwCstInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnOwCstNotInc.Checked = true;
                    }
                    if (this.lt.OCityStZipReq == 1)
                    {
                        this.rbtnOwCstReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnOwCstNotReq.Checked = true;
                    }
                    if (this.lt.ONameInc == 1)
                    {
                        this.rbtnOwnerNameInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnOwNameNotInc.Checked = true;
                    }
                    if (this.lt.ONameReq == 1)
                    {
                        this.rbtnOwNameReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnOwNameNotReq.Checked = true;
                    }
                    if (this.lt.OwPhoneInc == 1)
                    {
                        this.rbtnOwPhInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnOwPhNotInc.Checked = true;
                    }
                    if (this.lt.OwPhoneReq == 1)
                    {
                        this.rbtnOwPhReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnOwPhNotReq.Checked = true;
                    }
                    if (this.lt.SalesTaxInc == 1)
                    {
                        this.rbtnSalesInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnSalesNotInc.Checked = true;
                    }
                    if (this.lt.SalesTaxReq == 1)
                    {
                        this.rbtnSalesReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnSalesNotReq.Checked = true;
                    }
                    if (this.lt.VinInc == 1)
                    {
                        this.rbtnVinInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnVinNotInc.Checked = true;
                    }
                    if (this.lt.VinReq == 1)
                    {
                        this.rbtnVinReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnVinNotReq.Checked = true;
                    }
                    if (this.lt.ZoningInc == 1)
                    {
                        this.rbtnZoningInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnZoningNotInc.Checked = true;
                    }
                    if (this.lt.ZoningReq == 1)
                    {
                        this.rbtnZoningReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnZoningNotReq.Checked = true;
                    }
                    if (this.lt.EmailInc == 1)
                    {
                        this.rbtnEmailInc.Checked = true;
                    }
                    else
                    {
                        this.rbtnEmailNotInc.Checked = true;
                    }
                    if (this.lt.EmailReq == 1)
                    {
                        this.rbtnEmailReq.Checked = true;
                    }
                    else
                    {
                        this.rbtnEmailNotReq.Checked = true;
                    }
                    this.txtbxLicFee.Text = Convert.ToString(this.lt.Fee);
                    this.txtTypeCode.Text = this.lt.TypeCode;
                    this.txtExpireDay.Text = Convert.ToString(this.lt.Days);
                    this.txtExpireMonth.Text = Convert.ToString(this.lt.Months);
                    if (this.lt.ExpDate.Length > 0)
                    {
                        this.txtExpireDateDay.Text = this.lt.ExpDate.Substring(2, 2);
                        this.txtExpireDateMonth.Text = this.lt.ExpDate.Substring(0, 2);
                    }
                }
            }
        }


        protected Button btnUpdate;
        protected Button btnViewReport;
        protected CustomValidator CustomValidator1;
        protected Label Label1;
        protected Label Label10;
        protected Label Label11;
        protected Label Label12;
        protected Label Label13;
        protected Label Label14;
        protected Label Label15;
        protected Label Label16;
        protected Label Label17;
        protected Label Label18;
        protected Label Label19;
        protected Label Label2;
        protected Label Label20;
        protected Label Label21;
        protected Label Label22;
        protected Label Label23;
        protected Label Label24;
        protected Label Label25;
        protected Label Label26;
        protected Label Label27;
        protected Label Label28;
        protected Label Label29;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;
        protected Label Label7;
        protected Label Label8;
        protected Label Label9;
        protected Label lblEmailAddress;
        protected Label lblLicType;
        protected LicenseType lt;
        protected RadioButton rbtnAppNameInc;
        protected RadioButton rbtnAppNameNotInc;
        protected RadioButton rbtnAppNameNotReq;
        protected RadioButton rbtnAppNameReq;
        protected RadioButton rbtnBondInc;
        protected RadioButton rbtnBondNotInc;
        protected RadioButton rbtnBondNotReq;
        protected RadioButton rbtnBondReq;
        protected RadioButton rbtnBusAddInc;
        protected RadioButton rbtnBusAddNotInc;
        protected RadioButton rbtnBusAddNotReq;
        protected RadioButton rbtnBusAddReq;
        protected RadioButton rbtnBusCstInc;
        protected RadioButton rbtnBusCstNotInc;
        protected RadioButton rbtnBusCstNotReq;
        protected RadioButton rbtnBusCstReq;
        protected RadioButton rbtnBusNameInc;
        protected RadioButton rbtnBusNameNotInc;
        protected RadioButton rbtnBusNameNotReq;
        protected RadioButton rbtnBusNameReq;
        protected RadioButton rbtnBusPhoInc;
        protected RadioButton rbtnBusPhoNotInc;
        protected RadioButton rbtnBusPhoNotReq;
        protected RadioButton rbtnBusPhoReq;
        protected RadioButton rbtnDriverLicNotInc;
        protected RadioButton rbtnDrivLicInc;
        protected RadioButton rbtnDrivLicNotReq;
        protected RadioButton rbtnDrivLicReq;
        protected RadioButton rbtnEmailInc;
        protected RadioButton rbtnEmailNotInc;
        protected RadioButton rbtnEmailNotReq;
        protected RadioButton rbtnEmailReq;
        protected RadioButton rbtnInsuNotInc;
        protected RadioButton rbtnInsuNotReq;
        protected RadioButton rbtnInsuReq;
        protected RadioButton rbtnInsurInc;
        protected RadioButton rbtnLegalInc;
        protected RadioButton rbtnLegalNotInc;
        protected RadioButton rbtnLegalNotReq;
        protected RadioButton rbtnLegalReq;
        protected RadioButton rbtnLicNameNotReq;
        protected RadioButton rbtnLicNamInc;
        protected RadioButton rbtnLicNamNotInc;
        protected RadioButton rbtnLicNamReq;
        protected RadioButton rbtnLiqLicInc;
        protected RadioButton rbtnLiqLicNotInc;
        protected RadioButton rbtnLiqLicNotReq;
        protected RadioButton rbtnLiqLicReq;
        protected RadioButton rbtnMailAddInc;
        protected RadioButton rbtnMailAddNotInc;
        protected RadioButton rbtnMailAddNotReq;
        protected RadioButton rbtnMailAddReq;
        protected RadioButton rbtnMailCstInc;
        protected RadioButton rbtnMailCstNotInc;
        protected RadioButton rbtnMailCstNotReq;
        protected RadioButton rbtnMailCstReq;
        protected RadioButton rbtnOwAddInc;
        protected RadioButton rbtnOwAddNotInc;
        protected RadioButton rbtnOwAddNotReq;
        protected RadioButton rbtnOwAddReq;
        protected RadioButton rbtnOwCstInc;
        protected RadioButton rbtnOwCstNotInc;
        protected RadioButton rbtnOwCstNotReq;
        protected RadioButton rbtnOwCstReq;
        protected RadioButton rbtnOwNameNotInc;
        protected RadioButton rbtnOwNameNotReq;
        protected RadioButton rbtnOwNameReq;
        protected RadioButton rbtnOwnerNameInc;
        protected RadioButton rbtnOwPhInc;
        protected RadioButton rbtnOwPhNotInc;
        protected RadioButton rbtnOwPhNotReq;
        protected RadioButton rbtnOwPhReq;
        protected RadioButton rbtnSalesInc;
        protected RadioButton rbtnSalesNotInc;
        protected RadioButton rbtnSalesNotReq;
        protected RadioButton rbtnSalesReq;
        protected RadioButton rbtnSsnInc;
        protected RadioButton rbtnSsnNotInc;
        protected RadioButton rbtnSsnNotReq;
        protected RadioButton rbtnSsnReq;
        protected RadioButton rbtnVinInc;
        protected RadioButton rbtnVinNotInc;
        protected RadioButton rbtnVinNotReq;
        protected RadioButton rbtnVinReq;
        protected RadioButton rbtnZoningInc;
        protected RadioButton rbtnZoningNotInc;
        protected RadioButton rbtnZoningNotReq;
        protected RadioButton rbtnZoningReq;
        public string strMessage;
        protected TextBox txtAccountNum;
        protected TextBox txtbxLicFee;
        protected TextBox txtExpireDateDay;
        protected TextBox txtExpireDateMonth;
        protected TextBox txtExpireDay;
        protected TextBox txtExpireMonth;
        protected TextBox txtTypeCode;
        protected TextBox txtTypeName;
        protected int typeId;
        protected RequiredFieldValidator valdAccountNum;
        protected ValidationSummary ValidationSummary1;
        protected RequiredFieldValidator vldLicenseFee;
        protected RequiredFieldValidator vldName;
        protected RequiredFieldValidator vldTypeCode;
    }
}


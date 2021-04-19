namespace CLAS
{
    using CLAS.BusinessLogicLayer;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class ViewDocument : Page
    {
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.document.AuthorizedDescription = this.txtAuthorized.Text;
            this.document.LegalDescription = this.txtLegalReq.Text;
            this.document.MainLinceseLine1 = this.listLicenseLine1.SelectedItem.Text;
            this.document.MainLinceseLine2 = this.listLicenseLine2.SelectedValue.ToString();
            this.document.MainLinceseLine3 = this.listLicenseLine3.SelectedValue.ToString();
            this.document.MailAddressLine1 = this.listMailAddressName.SelectedValue.ToString();
            this.document.MailAddressLine2 = this.listMailAddressStreet.SelectedValue.ToString();
            this.document.MailAddressLine3 = this.listMailCityStZip.SelectedValue.ToString();
            this.document.RecivedFrom = this.listRecivedFrom.SelectedValue.ToString();
            this.document.SmallCertify = this.listSmallCertify.SelectedValue.ToString();
            this.document.UpdateLicenseTypePrintView();
            this.FillLablesWithDefaultData();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private void FillDropDownList()
        {
            this.listLicenseLine1.DataSource = this.dsDropDownList;
            this.listLicenseLine1.DataTextField = "Value";
            this.listLicenseLine1.DataBind();
            this.listLicenseLine2.DataSource = this.dsDropDownList;
            this.listLicenseLine2.DataTextField = "Value";
            this.listLicenseLine2.DataBind();
            this.listLicenseLine3.DataSource = this.dsDropDownList;
            this.listLicenseLine3.DataTextField = "Value";
            this.listLicenseLine3.DataBind();
            this.listSmallCertify.DataSource = this.dsDropDownList;
            this.listSmallCertify.DataTextField = "Value";
            this.listSmallCertify.DataBind();
            this.listRecivedFrom.DataSource = this.dsDropDownList;
            this.listRecivedFrom.DataTextField = "Value";
            this.listRecivedFrom.DataBind();
            this.listMailAddressName.DataSource = this.dsDropDownList;
            this.listMailAddressName.DataTextField = "Value";
            this.listMailAddressName.DataBind();
            this.listMailCityStZip.DataSource = this.dsDropDownList;
            this.listMailCityStZip.DataTextField = "Value";
            this.listMailCityStZip.DataBind();
            this.listMailAddressStreet.DataSource = this.dsDropDownList;
            this.listMailAddressStreet.DataTextField = "Value";
            this.listMailAddressStreet.DataBind();
        }

        private void FillLablesWithDefaultData()
        {
            this.lblAmtPaid.Text = "Amount";
            this.lblAuthorized.Text = this.txtAuthorized.Text;
            this.lblCash.Text = "Cash";
            this.lblCheckNo.Text = "CheckNo.";
            this.lblExperationDate.Text = DateTime.Now.ToShortDateString();
            this.lblFee.Text = "0.00";
            this.lblHerbyLicensedTo.Text = this.txtAuthorized.Text;
            this.lblLealReq.Text = this.txtLegalReq.Text;
            this.lblLicenseLine1.Text = this.listLicenseLine1.SelectedItem.ToString();
            this.lblLicenseLine2.Text = this.listLicenseLine2.SelectedItem.ToString();
            this.lblLicenseLine3.Text = this.listLicenseLine3.SelectedItem.ToString();
            this.lblLicenseNo.Text = "Lic No.";
            this.lblMailAddressLine1.Text = this.listMailAddressName.SelectedItem.ToString();
            this.lblmailAddressLine2.Text = this.listMailAddressStreet.SelectedItem.ToString();
            this.lblMailAddressLine3.Text = this.listMailCityStZip.SelectedItem.ToString();
            this.lblReceiptFor.Text = "Receipt For";
            this.lblReceiptIssueDate.Text = DateTime.Now.ToShortDateString();
            this.lblReceivedFrom.Text = this.listRecivedFrom.SelectedItem.ToString();
            this.lblReciptNo.Text = "Recipt No.";
            this.lblSamllCertify.Text = this.listSmallCertify.SelectedItem.ToString();
            this.lblIssueDate.Text = DateTime.Now.ToShortDateString();
            this.lblSamllExperationDate.Text = DateTime.Now.ToShortDateString();
            this.lblSmallIssueDate.Text = DateTime.Now.ToShortDateString();
        }

        private void InitializeComponent()
        {
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.licenseType = Convert.ToString(base.Request.QueryString[0]);
            this.document = new MainPrintedDocument(this.licenseType);
            if (!base.IsPostBack)
            {
                this.lblType.Text = "License Type: " + this.licenseType;
                this.dsDropDownList = this.document.FillDataSetForDropDownList();
                this.FillDropDownList();
                this.SelectDropDownListValues();
                this.FillLablesWithDefaultData();
            }
        }

        private void SelectDropDownListValues()
        {
            this.document.SelectLicenseTypePrintView();
            this.listLicenseLine1.SelectedValue = this.document.MainLinceseLine1;
            this.listLicenseLine2.SelectedValue = this.document.MainLinceseLine2;
            this.listLicenseLine3.SelectedValue = this.document.MainLinceseLine3;
            this.listMailAddressName.SelectedValue = this.document.MailAddressLine1;
            this.listMailAddressStreet.SelectedValue = this.document.MailAddressLine2;
            this.listMailCityStZip.SelectedValue = this.document.MailAddressLine3;
            this.listRecivedFrom.SelectedValue = this.document.RecivedFrom;
            this.listSmallCertify.SelectedValue = this.document.SmallCertify;
            this.txtAuthorized.Text = this.document.AuthorizedDescription;
            this.txtLegalReq.Text = this.document.LegalDescription;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }


        protected Button btnUpdate;
        protected MainPrintedDocument document;
        protected DataSet dsDropDownList;
        protected Label Label1;
        protected Label Label12;
        protected Label Label13;
        protected Label Label14;
        protected Label Label2;
        protected Label Label29;
        protected Label Label30;
        protected Label Label31;
        protected Label Label32;
        protected Label Label33;
        protected Label lblAmtPaid;
        protected Label lblAuthorized;
        protected Label lblCash;
        protected Label lblCheckNo;
        protected Label lblExperationDate;
        protected Label lblFee;
        protected Label lblHerbyLicensedTo;
        protected Label lblIssueDate;
        protected Label lblLealReq;
        protected Label lblLicenseLine1;
        protected Label lblLicenseLine2;
        protected Label lblLicenseLine3;
        protected Label lblLicenseNo;
        protected Label lblMailAddressLine1;
        protected Label lblmailAddressLine2;
        protected Label lblMailAddressLine3;
        protected Label lblReceiptFor;
        protected Label lblReceiptIssueDate;
        protected Label lblReceivedFrom;
        protected Label lblReciptNo;
        protected Label lblSamllCertify;
        protected Label lblSamllExperationDate;
        protected Label lblSmallIssueDate;
        protected Label lblType;
        protected string licenseType;
        protected DropDownList listLicenseLine1;
        protected DropDownList listLicenseLine2;
        protected DropDownList listLicenseLine3;
        protected DropDownList listMailAddressName;
        protected DropDownList listMailAddressStreet;
        protected DropDownList listMailCityStZip;
        protected DropDownList listRecivedFrom;
        protected DropDownList listSmallCertify;
        protected TextBox txtAuthorized;
        protected TextBox txtLegalReq;
    }
}


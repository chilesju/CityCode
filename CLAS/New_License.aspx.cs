namespace CLAS
{
    using CLAS.BusinessLogicLayer;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class New_License : Page
    {
        private void btnBeginLicense_Click(object sender, EventArgs e)
        {
            if (this.chbxPending.Checked)
            {
                this.issueDate = "Pending";
                this.dropListLicenseType.SelectedItem.Text.Substring(0, 4);
                base.Server.Transfer("Enter_New_License.aspx", true);
            }
            else
            {
                this.issueDate = this.Calendar1.SelectedDate.ToShortDateString();
                base.Server.Transfer("Enter_New_License.aspx", true);
            }
        }

        private void InitializeComponent()
        {
            this.btnBeginLicense.Click += new EventHandler(this.btnBeginLicense_Click);
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
                this.dropListLicenseType.DataSource = type1.GetAllLicense();
                this.dropListLicenseType.DataTextField = "LicenseName";
                this.dropListLicenseType.DataBind();
                this.Calendar1.SelectedDate = DateTime.Today;
            }
        }


        public string IssueDate
        {
            get
            {
                return this.issueDate;
            }
        }

        public string LicenseTypeCode
        {
            get
            {
                return this.dropListLicenseType.SelectedItem.Text.Substring(0, 4);
            }
        }

        public string Status
        {
            get
            {
                if (this.chbxPending.Checked)
                {
                    return "PENDING";
                }
                return "ACTIVE";
            }
        }


        protected Button btnBeginLicense;
        protected Calendar Calendar1;
        protected CheckBox chbxPending;
        protected DropDownList dropListLicenseType;
        protected string issueDate;
        protected Label Label1;
        protected Label Label2;
        protected Label Label3;
        protected string licenseType;
    }
}


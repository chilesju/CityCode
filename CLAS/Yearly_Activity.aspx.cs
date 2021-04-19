namespace CLAS
{
    using CLAS.BusinessLogicLayer;
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Yearly_Activity : Page
    {
        public Yearly_Activity()
        {
            this.orpt = new ReportDocument();
        }

        private void BindReportToCrystalViewer(string reportRequested)
        {
            new DateReport(Convert.ToDateTime(this.txtEndDate.Text), Convert.ToDateTime(this.txtStartDate.Text), this.listLicenseType.SelectedValue.Substring(0, 4));
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
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
                Report report1 = new Report();
                DateTime time1 = DateTime.Today;
                TimeSpan span1 = new TimeSpan(0x16e, 0, 0, 0);
                this.txtStartDate.Text = Convert.ToDateTime(time1.Subtract(span1)).ToShortDateString();
                this.txtEndDate.Text = DateTime.Today.ToShortDateString();
                this.listYearlyReports.DataSource = report1.GetReportNames();
                this.listYearlyReports.DataTextField = "Report Name";
                this.listYearlyReports.DataBind();
                this.listLicenseType.DataSource = new LicenseType().GetAllLicense();
                this.listLicenseType.DataTextField = "LicenseName";
                this.listLicenseType.DataBind();
                this.BindReportToCrystalViewer(this.listYearlyReports.SelectedValue);
            }
        }


        protected Label firstDate;
        protected HtmlForm Form1;
        protected Label Label1;
        protected Label Label2;
        protected Label Label4;
        protected DropDownList listLicenseType;
        protected DropDownList listYearlyReports;
        private ReportDocument orpt;
        protected TextBox txtEndDate;
        protected TextBox txtStartDate;
    }
}


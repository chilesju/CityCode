namespace CLAS
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Web;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Daily_Activity : Page
    {
        public Daily_Activity()
        {
            this.orpt = new ReportDocument();
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
                this.txtDate.Text = DateTime.Now.ToShortDateString();
            }
        }


        protected Button btnPrintRpt;
        protected CrystalReportViewer CrystalReportViewer1;
        protected HtmlForm Form1;
        protected Label Label1;
        private ReportDocument orpt;
        protected RangeValidator RangeValidator1;
        protected TextBox txtDate;
    }
}


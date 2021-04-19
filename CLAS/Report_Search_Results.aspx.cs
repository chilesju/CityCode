namespace CLAS
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Report_Search_Results : Page
    {
        public Report_Search_Results()
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
            string text1 = base.Server.MapPath("/CLAS/Reports/LicenseSearch.rpt");
            this.orpt.Load(text1);
            MemoryStream stream1 = (MemoryStream) this.orpt.ExportToStream(ExportFormatType.PortableDocFormat);
            base.Response.Clear();
            base.Response.Buffer = true;
            base.Response.ContentType = "application/pdf";
            base.Response.BinaryWrite(stream1.ToArray());
            base.Response.End();
        }


        protected LinkButton btnHome;
        protected LinkButton LinkButton3;
        protected LinkButton LinkButton4;
        protected LinkButton LinkButton5;
        private ReportDocument orpt;
    }
}


namespace CLAS
{
    using CLAS.BusinessLogicLayer;
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.IO;
    using System.Web.UI;

    public class PrintReport : Page
    {
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
            base.Request.QueryString.ToString();
            string text1 = base.Request.QueryString[0];
            string text2 = base.Request.QueryString[1].Substring(0, 4);
            string text3 = base.Request.QueryString[2];
            string text4 = base.Request.QueryString[3];
            DateReport report1 = new DateReport(Convert.ToDateTime(text4), Convert.ToDateTime(text3), text2);
            ReportDocument document1 = report1.GetDocument(text1);
            MemoryStream stream1 = report1.ConvertToPDF(document1);
            base.Response.Clear();
            base.Response.Buffer = true;
            base.Response.ContentType = "application/pdf";
            base.Response.BinaryWrite(stream1.ToArray());
            base.Response.End();
        }

    }
}


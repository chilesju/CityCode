namespace CLAS
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Web;
    using System.Web.UI;

    public class PrintDailyReport : Page
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
            string text1 = base.Request.QueryString[0];
            ReportDocument document1 = new ReportDocument();
            string text2 = HttpContext.Current.Server.MapPath(@"Reports\DailyCLASReport.rpt");
            document1.Load(text2);
            document1.DataDefinition.RecordSelectionFormula = "{License.Paid Date} =DateValue('" + text1 + "') and {License.Status} <> 'DELETED'";
            TableLogOnInfo info1 = new TableLogOnInfo();
            info1 = document1.Database.Tables[0].LogOnInfo;
            foreach (Table table1 in document1.Database.Tables)
            {
                info1.ConnectionInfo.ServerName = ConfigurationSettings.AppSettings["CrystalReportServer"];
                info1.ConnectionInfo.UserID = ConfigurationSettings.AppSettings["CrystalReportUserId"];
                info1.ConnectionInfo.Password = ConfigurationSettings.AppSettings["CrystalReportPassword"];
                table1.ApplyLogOnInfo(info1);
            }
            MemoryStream stream1 = (MemoryStream) document1.ExportToStream(ExportFormatType.PortableDocFormat);
            base.Response.Clear();
            base.Response.Buffer = true;
            base.Response.ContentType = "application/pdf";
            base.Response.BinaryWrite(stream1.ToArray());
            base.Response.End();
        }

    }
}


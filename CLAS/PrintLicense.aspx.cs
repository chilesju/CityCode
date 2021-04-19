namespace CLAS
{
    using CLAS.BusinessLogicLayer;
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.IO;
    using System.Web.UI;

    public class PrintLicense : Page
    {
        private void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("New_License.aspx");
        }

        private void InitializeComponent()
        {
            base.Unload += new EventHandler(this.PrintLicense_Unload);
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
                MemoryStream stream1;
                string text1 = this.Session["licenseNumber"].ToString();
                string text2 = this.Session["licenseType"].ToString();
                if (text1.Substring(0, 4) == "PEND")
                {
                    MainReport report1 = new MainReport(text2, text1);
                    ReportDocument document1 = report1.GetDocument("PendingRecipt");
                    stream1 = report1.ConvertToPDF(document1);
                }
                else
                {
                    MainReport report2 = new MainReport(text2, text1);
                    ReportDocument document2 = report2.GetDocument("MainDocument");
                    stream1 = report2.ConvertToPDF(document2);
                }
                base.Response.Clear();
                base.Response.Buffer = true;
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(stream1.ToArray());
                base.Response.End();
            }
        }

        private void PrintLicense_Unload(object sender, EventArgs e)
        {
        }

    }
}


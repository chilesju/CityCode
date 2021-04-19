namespace CLAS.BusinessLogicLayer
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using System;
    using System.Web;

    public class MainReport : Report
    {
        public MainReport(string licenseType, string licenseNumber)
        {
            this.licenseNumber = licenseNumber;
            this.licenseType = licenseType;
        }

        public ReportDocument GetDocument(string reportName)
        {
            ReportDocument document1 = new ReportDocument();
            string text1 = HttpContext.Current.Server.MapPath(@"Reports\" + reportName + ".rpt");
            document1.Load(text1);
            TableLogOnInfo info1 = new TableLogOnInfo();
            info1 = document1.Database.Tables[0].LogOnInfo;
            foreach (Table table1 in document1.Database.Tables)
            {
                info1.ConnectionInfo.ServerName = base.ReportServer;
                info1.ConnectionInfo.UserID = base.ReportUserId;
                info1.ConnectionInfo.Password = base.ReportPassword;
                table1.ApplyLogOnInfo(info1);
            }
            ParameterFields fields1 = new ParameterFields();
            ParameterField field1 = new ParameterField();
            ParameterField field2 = new ParameterField();
            field1.ParameterFieldName = "LicenseType";
            field2.ParameterFieldName = "LicenseNumber";
            ParameterDiscreteValue value1 = new ParameterDiscreteValue();
            ParameterDiscreteValue value2 = new ParameterDiscreteValue();
            value1.Value = this.licenseType;
            value2.Value = this.licenseNumber;
            field1.CurrentValues.Add(value1);
            field2.CurrentValues.Add(value2);
            fields1.Add(field1);
            fields1.Add(field2);
            document1.SetParameterValue("LicenseType", value1);
            document1.SetParameterValue("LicenseNumber", value2);
            return document1;
        }


        private string licenseNumber;
        private string licenseType;
    }
}


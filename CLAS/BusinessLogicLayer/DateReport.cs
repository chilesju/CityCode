namespace CLAS.BusinessLogicLayer
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using System;
    using System.Web;

    public class DateReport : Report
    {
        public DateReport(DateTime endDate, DateTime startDate, string licenseType)
        {
            this.endDate = endDate;
            this.startDate = startDate;
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
            ParameterField field3 = new ParameterField();
            field1.ParameterFieldName = "LicenseType";
            field2.ParameterFieldName = "LicenseFirstDate";
            field3.ParameterFieldName = "LicenseSecondDate";
            ParameterDiscreteValue value1 = new ParameterDiscreteValue();
            ParameterDiscreteValue value2 = new ParameterDiscreteValue();
            ParameterDiscreteValue value3 = new ParameterDiscreteValue();
            value1.Value = this.licenseType;
            value2.Value = this.startDate;
            value3.Value = this.endDate;
            field1.CurrentValues.Add(value1);
            field2.CurrentValues.Add(value2);
            field3.CurrentValues.Add(value3);
            fields1.Add(field1);
            fields1.Add(field2);
            fields1.Add(field3);
            document1.SetParameterValue("LicenseType", value1);
            document1.SetParameterValue("LicenseFirstDate", value2);
            document1.SetParameterValue("LicenseSecondDate", value3);
            return document1;
        }


        private DateTime endDate;
        private string licenseType;
        private DateTime startDate;
    }
}


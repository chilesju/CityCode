namespace CLAS.BusinessLogicLayer
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using System;

    public class DailyReport : Report
    {
        public DailyReport(string date)
        {
            this.date = date;
        }

        public ReportDocument GetDocument(string reportName)
        {
            ReportDocument document1 = new ReportDocument();
            string text1 = base.ReportLocation + @"\" + reportName;
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
            document1.DataDefinition.RecordSelectionFormula = "{License.Paid Date} =DateValue('" + this.date + "')";
            return document1;
        }


        private string date;
    }
}


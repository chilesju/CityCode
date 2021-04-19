namespace CLAS.BusinessLogicLayer
{
    using CLAS;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using System;
    using System.Configuration;
    using System.Data;
    using System.IO;

    public class Report
    {
        public Report()
        {
            this.reportServer = ConfigurationSettings.AppSettings["CrystalReportServer"];
            this.reportUserId = ConfigurationSettings.AppSettings["CrystalReportUserId"];
            this.reportPassword = ConfigurationSettings.AppSettings["CrystalReportPassword"];
            this.reportLocation = ConfigurationSettings.AppSettings["CrystalLocation"];
        }

        public MemoryStream ConvertToPDF(ReportDocument report)
        {
            return (MemoryStream) report.ExportToStream(ExportFormatType.PortableDocFormat);
        }

        public ReportDocument GetDocument(string reportName)
        {
            ReportDocument document1 = new ReportDocument();
            this.reportLocation = this.reportLocation + @"\" + reportName + ".rpt";
            document1.Load(this.reportLocation);
            TableLogOnInfo info1 = new TableLogOnInfo();
            info1 = document1.Database.Tables[0].LogOnInfo;
            foreach (Table table1 in document1.Database.Tables)
            {
                info1.ConnectionInfo.ServerName = this.reportServer;
                info1.ConnectionInfo.UserID = this.reportUserId;
                info1.ConnectionInfo.Password = this.reportPassword;
                table1.ApplyLogOnInfo(info1);
            }
            return document1;
        }

        public DataSet GetReportNames()
        {
            return SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_GetReportNames", new object[0]);
        }


        public string ReportLocation
        {
            get
            {
                return this.reportLocation;
            }
        }

        public string ReportPassword
        {
            get
            {
                return this.reportPassword;
            }
        }

        public string ReportServer
        {
            get
            {
                return this.reportServer;
            }
        }

        public string ReportUserId
        {
            get
            {
                return this.reportUserId;
            }
        }


        private string reportLocation;
        private string reportPassword;
        private string reportServer;
        private string reportUserId;
    }
}


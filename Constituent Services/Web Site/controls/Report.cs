using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.Web;
using System.IO;

namespace Constituent_Services.controls
{
	public class Report
	{
		private string reportLocation;
		private string reportServer;
		private string reportUserId;
		private string reportPassword;

		
		public Report()
		{

            reportServer = System.Configuration.ConfigurationManager.AppSettings["CrystalReportServer"].ToString();
            reportUserId = System.Configuration.ConfigurationManager.AppSettings["CrystalReportUserId"].ToString();
            reportPassword = System.Configuration.ConfigurationManager.AppSettings["CrystalReportPassword"].ToString();
		}
		public string ReportServer
		{
			get { return reportServer;}
		}
		public string ReportUserId
		{
			get { return reportUserId;}
		}
		public string ReportPassword
		{
			get { return reportPassword;}
		}
		public string ReportLocation
		{
			get { return reportLocation;}
		}

		public static MemoryStream ConvertToPDF(ReportDocument report)
		{
			MemoryStream oStream; 
			oStream = (MemoryStream)
				report.ExportToStream(
				CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
			return oStream;

		}
		//Retruns a generic Crystal report with no parameters.
		
		public  ReportDocument GetDocument(string reportName)
		{
		
			ReportDocument document = new ReportDocument();
			string fileName = HttpContext.Current.Server.MapPath("Crystal Reports\\"+ reportName+ ".rpt");
		
			document.Load(fileName);
	
			TableLogOnInfo logonInfo = new TableLogOnInfo();
			logonInfo= document.Database.Tables[0].LogOnInfo;
			
			foreach(  CrystalDecisions.CrystalReports.Engine.Table myTable in document.Database.Tables)
			{
				logonInfo.ConnectionInfo.ServerName=reportServer;
				logonInfo.ConnectionInfo.UserID=reportUserId;
				logonInfo.ConnectionInfo.Password=reportPassword;
				myTable.ApplyLogOnInfo(logonInfo);
			}	

			return document;
		}
		public  ReportDocument GetDocument(string reportName, int incidentNumber)
		{
		
			ReportDocument document = new ReportDocument();
			string fileName = HttpContext.Current.Server.MapPath("Crystal Reports\\"+ reportName+ ".rpt");
		
			document.Load(fileName);
	
			TableLogOnInfo logonInfo = new TableLogOnInfo();
			logonInfo= document.Database.Tables[0].LogOnInfo;
			
			foreach(  CrystalDecisions.CrystalReports.Engine.Table myTable in document.Database.Tables)
			{
				logonInfo.ConnectionInfo.ServerName=reportServer;
				logonInfo.ConnectionInfo.UserID=reportUserId;
				logonInfo.ConnectionInfo.Password=reportPassword;
				myTable.ApplyLogOnInfo(logonInfo);
			}	
			ParameterFields paramFields = new ParameterFields(); 

			// the parameter fields to be sent to the report 
			ParameterField pfPermitNumber = new ParameterField(); 

			// setting the name of parameter fields with wich they will be recieved in report 
			pfPermitNumber.ParameterFieldName = "IncidentNumber"; 

			// the above declared parameter fields accept values as discrete objects 

			ParameterDiscreteValue dcPermitNumber = new ParameterDiscreteValue(); 

			// setting the values of discrete objects 


			dcPermitNumber.Value = incidentNumber;

			// now adding these discrete values to parameters 
			pfPermitNumber.CurrentValues.Add(dcPermitNumber); 

			// now adding all these parameter fields to the parameter collection 

			paramFields.Add(pfPermitNumber); 
		
			document.SetParameterValue("IncidentNumber",dcPermitNumber);
			return document;
		} 

		
		
	}
}

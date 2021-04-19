using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Constituent_Services
{
	
	public class PrintScreen : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString.Count==1)
			{
				string reportName=  Request.QueryString[0];
				Constituent_Services.controls.Report rpt = new Constituent_Services.controls.Report();
				ReportDocument orpt = new ReportDocument();
				orpt= rpt.GetDocument(reportName);
				ConvertToPDF(orpt);
			}
			else
			{
				string reportName=  Request.QueryString[0];
				int permitNumber= Convert.ToInt32(Request.QueryString[1]);
				Constituent_Services.controls.Report rpt = new Constituent_Services.controls.Report();
				ReportDocument orpt = new ReportDocument();
				orpt= rpt.GetDocument(reportName,permitNumber);
				ConvertToPDF(orpt);
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
		private void ConvertToPDF(ReportDocument rptDoc)
		{
			MemoryStream oStream; 
			oStream = (MemoryStream)
				rptDoc.ExportToStream(
				CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
			Response.Clear();
			Response.Buffer= true;
			Response.ContentType = "application/pdf"; 
			Response.BinaryWrite(oStream.ToArray());
			Response.End();
		}
	}
}

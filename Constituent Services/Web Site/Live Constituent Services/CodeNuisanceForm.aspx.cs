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

namespace Constituent_Services
{
	/// <summary>
	/// Summary description for CodeNuisanceForm.
	/// </summary>
	public class CodeNuisanceForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblCaseNumber;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblAddress;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblInspector;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblCaseType;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblDateComplaint;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblFirstInspDate;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblReturnDate;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblCertMailSigned;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label lblCertMailReturned;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label lblLastChanceLetter;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label lblPublishedDate;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label lblHearingDate;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label lblDoorKnocker;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label lblWarrentDate;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label lblWarrentApprovedDate;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label lblAbatementCrew;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
	}
}

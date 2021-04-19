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
using Utilites;

namespace Constituent_Services
{
	/// <summary>
	/// Summary description for FindCouncilDistrict.
	/// </summary>
	public class FindCouncilDistrict : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.ListBox addressList;
		protected System.Web.UI.WebControls.Button btnClose;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			btnClose.Attributes.Add("onClick", "CloseWindow()");
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
            //DataSet addressSet = Utilites.Address.LocateCouncilDistrictFromParcelTableUsingStreetNum(CleanString.CleanInput(txtAddress.Text));
            //addressList.DataSource = addressSet.Tables[0];
            //addressList.DataTextField = addressSet.Tables[0].Columns[1].ToString();
            //if (addressSet.Tables[0].Rows.Count > 4)
            //{
            //    addressList.Rows = addressSet.Tables[0].Rows.Count;
            //}
            //addressList.DataBind();
		}
	}
}

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Utilites;
using System.Security.Principal;

using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Constituent_Services
{
	
	public class MainScreen : System.Web.UI.Page
	{
		//protected SecurityManager sm;
		string role;
		protected System.Web.UI.WebControls.Label lblWelcome;
		protected System.Web.UI.WebControls.Label Label1;
        protected Utilites.User user;

		private void Page_Load(object sender, System.EventArgs e)
		{

			if(!Page.IsPostBack)
			{

                IIdentity WinId = HttpContext.Current.User.Identity;
                WindowsIdentity wi = (WindowsIdentity)WinId;
                user = new User(wi.Name);
                Session["User"] = user;
				lblWelcome.Text = "Welcome " + User.Identity.Name + ". You are currently logged in as " + role + " Date:" + System.DateTime.Now.ToLongDateString();

			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public System.Drawing.Color PickColor(object date)
		{
			System.DateTime date2 = Convert.ToDateTime(date);
            //if(date2.AddDays(Global.MaxNumberOfDays)< System.DateTime.Now)
            //{
            //    return System.Drawing.Color.Red;
            //}
            //else if(date2.AddDays((Global.MaxNumberOfDays)-1)< System.DateTime.Now)
            //    return System.Drawing.Color.Orange;
            //else if(date2.AddDays(Global.MinNumberofDays)< System.DateTime.Now)
            //    return System.Drawing.Color.Blue;
            //else
				return System.Drawing.Color.Black;
		}
	}
}

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

namespace Constituent_Services
{
	
	public class MainScreen : System.Web.UI.Page
	{
		//protected SecurityManager sm;
		string role;
		protected System.Web.UI.WebControls.Label lblWelcome;
		protected System.Web.UI.WebControls.Label Label1;
		protected ProfileInfo profileInfo = new ProfileInfo();

		private void Page_Load(object sender, System.EventArgs e)
		{
		//	string refreshTimeout = System.Configuration.ConfigurationSettings.AppSettings["RefreshTimeout"];
			//Response.AppendHeader("Refresh", refreshTimeout+"; MainScreen.aspx");
            //sm = new SecurityManager();
            //sm.AuthorizationProvider = "Authorization Provider";
            //sm.SecurityCacheProvider = "Caching Store Provider";

			
			if(!Page.IsPostBack)
			{
				
				// null principal causes exception. null role returns false
				role = "";
                //if(sm.IsUserInRole(User, Global.RoleITAdmin)) role = Global.RoleITAdmin;
                //else if(sm.IsUserInRole(User,Global.RoleCouncil)) role = Global.RoleCouncil;
                //else if(sm.IsUserInRole(User,Global.RoleCityManager)) role =Global.RoleCityManager;
                //else if (sm.IsUserInRole(User,Global.RoleDepartment)) role =Global.RoleDepartment;
                //else if (sm.IsUserInRole(User,Global.RoleDivision)) role =Global.RoleDivision;
				Session["Department"] = profileInfo.GetUserDepartment(User.Identity.Name);
				Session["Division"] = profileInfo.GetUserDivision(User.Identity.Name);
				lblWelcome.Text = "Welcome " + User.Identity.Name + ". You are currently logged in as " + role + " Date:" + System.DateTime.Now.ToLongDateString();
				Session["userRights"] = role;
				Session["name"]= Context.User.Identity.Name;
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

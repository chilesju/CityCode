namespace Constituent_Services.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Utilites;
	using System.Collections;
	using System.Web.Security;

	public class header4 : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton lkbtnLogOff;
		protected System.Web.UI.WebControls.DataList linksTabs;
		//private SecurityManager sm;

		private void Page_Load(object sender, System.EventArgs e)
		{
            //sm = new SecurityManager();
            //sm.AuthorizationProvider = "Authorization Provider";
            //sm.SecurityCacheProvider = "Caching Store Provider";
			if(!IsPostBack)
			{
				

				string role = Session["userRights"].ToString(); 
				ArrayList tabItems = new ArrayList();
				tabItems.Add(new LinkTabs("Main Screen", "MainScreen.aspx?index=" + tabItems.Count));
				if (role=="administrator"  || role=="Council" || role=="IT Admin")
				{  
					tabItems.Add(new LinkTabs("Add New Call", "addnewcall.aspx?index=" + tabItems.Count));
					tabItems.Add(new LinkTabs("Reports", "Reports.aspx?index=" + tabItems.Count));	
				}
				tabItems.Add(new LinkTabs("Search", "Search.aspx?index=" + tabItems.Count));
				tabItems.Add(new LinkTabs("Administration", "Administration.aspx?index=" + tabItems.Count));
				linksTabs.DataSource = tabItems;
				linksTabs.SelectedIndex = (Request["index"]==null) ? 0 : Convert.ToInt32(Request["index"]);
				linksTabs.DataBind();
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
			this.lkbtnLogOff.Click += new System.EventHandler(this.lkbtnLogOff_Click_1);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lkbtnLogOff_Click(object sender, System.EventArgs e)
		{
		
		}

		private void linksTabs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lkbtnLogOff_Click_1(object sender, System.EventArgs e)
		{
			sm.LogOutUser(Page.User.Identity, Session.SessionID);
			Session.Clear();
			Session.Abandon();
			
			Response.Redirect("~/LogIn.aspx");
		}

	}
}

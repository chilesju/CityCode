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
        private Utilites.User _user;

		private void Page_Load(object sender, System.EventArgs e)
		{

			if(!IsPostBack)
			{


                this._user = (Utilites.User)Session["User"];

				ArrayList tabItems = new ArrayList();
				tabItems.Add(new LinkTabs("Main Screen", "MainScreen.aspx?index=" + tabItems.Count));
                if (this._user.IsUserCounciRole() || this._user.IsUserITAdminRole())
                {
                    tabItems.Add(new LinkTabs("Add New Call", "Addnewcall.aspx?index=" + tabItems.Count));
                   //tabItems.Add(new LinkTabs("Reports", "Reports.aspx?index=" + tabItems.Count));
                    tabItems.Add(new LinkTabs("Search", "Search.aspx?index=" + tabItems.Count));
                    tabItems.Add(new LinkTabs("Administration", "Administration.aspx?index=" + tabItems.Count));
                }
                else
                {
                    tabItems.Add(new LinkTabs("Search", "Search.aspx?index=" + tabItems.Count));
                }
				
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void linksTabs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}



	}
}

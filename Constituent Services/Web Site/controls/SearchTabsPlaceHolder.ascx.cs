namespace Constituent_Services.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.UI;

	
	public class SearchTabsPlaceHolder : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton lkbtnSearchAssignment;
		protected System.Web.UI.WebControls.LinkButton lkbtnSearchIncident;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.AddTabControl("SearchIncident");
				Session["tabControlName"] = "SearchIncident";
			}
			else
			{
				this.AddTabControl(Session["tabControlName"].ToString());
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
			this.lkbtnSearchIncident.Click += new System.EventHandler(this.lkbtnSearchIncident_Click);
			this.lkbtnSearchAssignment.Click += new System.EventHandler(this.lkbtnSearchAssignment_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	
		private Control contentControl;
		private void AddTabControl(string controlName)
		{
			if(controlName=="SearchAssignment")
			{
				contentControl = Page.LoadControl("~/Controls/SearchAssignment.ascx");
				((ISearchTab)contentControl).Initialize();
				PlaceHolder1.Controls.Clear();
				PlaceHolder1.Controls.Add( contentControl );
				contentControl.ID = "SearchAssignment";
				this.lkbtnSearchIncident.ForeColor = Color.Red;
				Session["controlName"]="SearchAssignment.ascx";
				this.lkbtnSearchIncident.ForeColor = Color.Black;
				this.lkbtnSearchAssignment.ForeColor= Color.Red;
				this.lkbtnSearchIncident.Font.Bold=false;
				this.lkbtnSearchAssignment.Font.Bold=true;
				this.lkbtnSearchIncident.Font.Underline=false;
				this.lkbtnSearchAssignment.Font.Underline=true;
			}
			else if(controlName=="SearchIncident")
			{
				contentControl = Page.LoadControl("~/Controls/SearchIncident.ascx");
				((ISearchTab)contentControl).Initialize();
				PlaceHolder1.Controls.Clear();
				PlaceHolder1.Controls.Add( contentControl );
				contentControl.ID = "SearchIncident";
				Session["controlName"]="SearchIncident.ascx";
				this.lkbtnSearchIncident.ForeColor = Color.Red;
				this.lkbtnSearchIncident.Font.Bold=true;
				this.lkbtnSearchAssignment.ForeColor= Color.Black;
				this.lkbtnSearchAssignment.Font.Bold=false;
				this.lkbtnSearchIncident.Font.Underline=true;
				this.lkbtnSearchAssignment.Font.Underline=false;
			}

		}

		private void lkbtnSearchAssignment_Click(object sender, System.EventArgs e)
		{
			this.AddTabControl("SearchAssignment");
			Session["tabControlName"] = "SearchAssignment";
			
		}
		private void lkbtnSearchIncident_Click(object sender, System.EventArgs e)
		{
			this.AddTabControl("SearchIncident");
			Session["tabControlName"] = "SearchIncident";
			
		}
	}
}

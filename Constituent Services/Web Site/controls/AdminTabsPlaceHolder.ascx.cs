namespace Constituent_Services.controls
{
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

	public class AdminTabsPlaceHolder : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton lkbtnHistory;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
		protected System.Web.UI.WebControls.LinkButton lkbtnAssignment1;
		private int _IncidentId;
		protected System.Web.UI.WebControls.LinkButton AdditionalUsersLinkbutton;
		private Utilites.AssignmentCollection _assignmentCollection= new AssignmentCollection();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				
				AddTabInfo("Assignment.ascx", "assignment1");
				((IIncidentTab)contentControl).Initialize();
			}
			else
			{
				AddTabInfo(Session["controlName"].ToString(), Session["assignment"].ToString());

				Utilites.Assignment assignemnt = new Utilites.Assignment();
				//assignemntCol = assignemnt.GetAllIncidentAssignments(_IncidentId);
				//this.IncidentId=incidentnumber;
				this.AssignmentCollection = assignemnt.GetAllIncidentAssignments(_IncidentId);
			}
		}
		private Control contentControl;


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			
			InitializeComponent();
			base.OnInit(e);
		}
		
		
		private void InitializeComponent()
		{
			this.lkbtnAssignment1.Click += new System.EventHandler(this.lkbtnAssignment1_Click);
			this.lkbtnHistory.Click += new System.EventHandler(this.lkbtnHistory_Click);
			this.AdditionalUsersLinkbutton.Click += new System.EventHandler(this.AdditionalUsersLinkbutton_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new System.EventHandler(this.AdminTabsPlaceHolder_PreRender);

		}
		#endregion
		

		

		public int IncidentId 
		{
			get { return _IncidentId; }
			set { _IncidentId = value; }
		}
		public Utilites.AssignmentCollection AssignmentCollection
		{
			get { return _assignmentCollection; }
			set { _assignmentCollection = value; }
		}

		private void AddTabInfo(string controlName, string assignment)
		{
			contentControl = Page.LoadControl("~/Controls/" + controlName);
			if(assignment =="assignment1")
			{
				((IIncidentTab)contentControl).IncidentId = _IncidentId;
				//if(_assignmentCollection.Count>0)
				//{
					foreach(Utilites.Assignment asg in _assignmentCollection)
					{
				
						((IIncidentTab)contentControl).IndividualAssignment =asg;
					
					}
				this.lkbtnAssignment1.ForeColor= System.Drawing.Color.Red;
				this.lkbtnAssignment1.Font.Bold=true;
		
						
				this.lkbtnHistory.ForeColor= System.Drawing.Color.Black;
				this.lkbtnHistory.Font.Bold=false;
				this.AdditionalUsersLinkbutton.ForeColor= System.Drawing.Color.Black;
				this.AdditionalUsersLinkbutton.Font.Bold=false;
				//}
			}
			else if(assignment =="history")
			{
				((IHistoryTab)contentControl).IncidentId = _IncidentId;
				this.lkbtnAssignment1.ForeColor= System.Drawing.Color.Black;
				this.lkbtnAssignment1.Font.Bold=false;
				this.lkbtnHistory.ForeColor= System.Drawing.Color.Red;
				this.lkbtnHistory.Font.Bold=true;
				this.AdditionalUsersLinkbutton.ForeColor= System.Drawing.Color.Black;
				this.AdditionalUsersLinkbutton.Font.Bold=false;
				

			}
			else if(assignment =="AdditionalUsers")
			{
				((IHistoryTab)contentControl).IncidentId = _IncidentId;
				this.lkbtnAssignment1.ForeColor= System.Drawing.Color.Black;
				this.lkbtnHistory.ForeColor= System.Drawing.Color.Black;
				this.AdditionalUsersLinkbutton.ForeColor= System.Drawing.Color.Red;
				this.AdditionalUsersLinkbutton.Font.Bold=true;
				this.lkbtnAssignment1.Font.Bold=false;
				this.lkbtnHistory.Font.Bold=false;
			}
			
			PlaceHolder1.Controls.Clear();
			PlaceHolder1.Controls.Add( contentControl );
			contentControl.ID = controlName;
			Session["controlName"]=controlName;
			Session["assignment"]= assignment;
		}
		



		private void lkbtnAssignment2_Click(object sender, System.EventArgs e)
		{
			 AddTabInfo("Assignment.ascx", "assignment2");
			((IIncidentTab)contentControl).Initialize();
		}

		private void AdminTabsPlaceHolder_PreRender(object sender, System.EventArgs e)
		{
			//if (!Page.IsPostBack)
			//	((IIncidentTab)contentControl).Initialize();
		}

		private void lkbtnHistory_Click(object sender, System.EventArgs e)
		{
			AddTabInfo("History.ascx", "history");
			((IHistoryTab)contentControl).Initialize();
		}

		private void lkbtnAssignment1_Click(object sender, System.EventArgs e)
		{
			AddTabInfo("Assignment.ascx", "assignment1");
			((IIncidentTab)contentControl).Initialize();
		
		}

		private void lkbtnEmail_Click(object sender, System.EventArgs e)
		{
			//AddTabInfo("Email.ascx", "email");
			//((IHistoryTab)contentControl).Initialize();
		
		}

		private void AdditionalUsersLinkbutton_Click(object sender, System.EventArgs e)
		{
			AddTabInfo("AdditionalUsers.ascx", "AdditionalUsers");
			((IHistoryTab)contentControl).Initialize();
		}
	}
}

namespace Constituent_Services.Incident_Views
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

	
	public class ViewPlaceHolder : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton lkbtnClosedIncidents;
		protected System.Web.UI.WebControls.LinkButton lkbtnPendingIncidents;
		protected System.Web.UI.WebControls.LinkButton lkbtnOpenIncidents;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
		protected Incident_Views.OpenIncidents myOpenView;
		protected Incident_Views.Pending myPendingView;
		protected System.Web.UI.WebControls.LinkButton lkbtnOverDue;
		protected Incident_Views.Closed  myClosedView;
		protected System.Web.UI.WebControls.LinkButton lkbtnRequestingClosure;
		protected Incident_Views.OverDue  myOverDueView;
		protected Incident_Views.RequestingClosure  myRequestingClosure;
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			try
			{
				if(Context.Session!=null)
				{
					if(!Page.IsPostBack  )
					{
						AddTabInfo("OpenIncidents.ascx");
						this.lkbtnOpenIncidents.ForeColor= System.Drawing.Color.Red;
						this.lkbtnOpenIncidents.Font.Bold=true;
						this.lkbtnPendingIncidents.Font.Bold=false;
						this.lkbtnPendingIncidents.ForeColor= System.Drawing.Color.Black;
						this.lkbtnClosedIncidents.ForeColor= System.Drawing.Color.Black;
						this.lkbtnClosedIncidents.Font.Bold=false;
						this.lkbtnOverDue.ForeColor= System.Drawing.Color.Black;
						this.lkbtnOverDue.Font.Bold=false;
						this.lkbtnRequestingClosure.ForeColor= System.Drawing.Color.Black;
						this.lkbtnRequestingClosure.Font.Bold=false;
					
					}
					AddTabInfo(Session["tabView"].ToString());
				}
				else
				{	
					//SecurityManager sm = new SecurityManager();
					//sm.LogOutUser(Context.User.Identity, Session.SessionID);
					Session["userRights"] = null;
					Response.Redirect("~/LogIn.aspx");
				}
			}
		
		
			catch(Exception ex)
			{
				Response.Write(ex.ToString() + " Session: " + Session.Count.ToString());

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
			this.lkbtnOpenIncidents.Click += new System.EventHandler(this.lkbtnOpenIncidents_Click);
			this.lkbtnPendingIncidents.Click += new System.EventHandler(this.lkbtnPendingIncidents_Click);
			this.lkbtnClosedIncidents.Click += new System.EventHandler(this.lkbtnClosedIncidents_Click);
			this.lkbtnOverDue.Click += new System.EventHandler(this.lkbtnOverDue_Click);
			this.lkbtnRequestingClosure.Click += new System.EventHandler(this.lkbtnRequestingClosure_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private Control contentControl;
		private void lkbtnOpenIncidents_Click(object sender, System.EventArgs e)
		{
			AddTabInfo("OpenIncidents.ascx");
			
			this.lkbtnOpenIncidents.ForeColor= System.Drawing.Color.Red;
			this.lkbtnOpenIncidents.Font.Bold=true;
			this.lkbtnPendingIncidents.Font.Bold=false;
			this.lkbtnPendingIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnClosedIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnClosedIncidents.Font.Bold=false;
			this.lkbtnOverDue.ForeColor= System.Drawing.Color.Black;
			this.lkbtnOverDue.Font.Bold=false;
			this.lkbtnRequestingClosure.ForeColor= System.Drawing.Color.Black;
			this.lkbtnRequestingClosure.Font.Bold=false;
			
		}

		private void lkbtnPendingIncidents_Click(object sender, System.EventArgs e)
		{
			AddTabInfo("Pending.ascx");
			this.lkbtnOpenIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnOpenIncidents.Font.Bold=false;
			this.lkbtnPendingIncidents.Font.Bold=true;
			this.lkbtnPendingIncidents.ForeColor= System.Drawing.Color.Red;
			this.lkbtnClosedIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnClosedIncidents.Font.Bold=false;
			this.lkbtnOverDue.ForeColor= System.Drawing.Color.Black;
			this.lkbtnOverDue.Font.Bold=false;
			this.lkbtnRequestingClosure.ForeColor= System.Drawing.Color.Black;
			this.lkbtnRequestingClosure.Font.Bold=false;
			
		}

		private void lkbtnClosedIncidents_Click(object sender, System.EventArgs e)
		{
			AddTabInfo("Closed.ascx");
			this.lkbtnOpenIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnOpenIncidents.Font.Bold=false;
			this.lkbtnPendingIncidents.Font.Bold=false;
			this.lkbtnPendingIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnClosedIncidents.ForeColor= System.Drawing.Color.Red;
			this.lkbtnClosedIncidents.Font.Bold=true;
			this.lkbtnOverDue.ForeColor= System.Drawing.Color.Black;
			this.lkbtnOverDue.Font.Bold=false;
			this.lkbtnRequestingClosure.ForeColor= System.Drawing.Color.Black;
			this.lkbtnRequestingClosure.Font.Bold=false;
			
		}

		private void AddTabInfo(string controlName)
		{
			contentControl = Page.LoadControl("~/Incident Views/" + controlName);
			if(controlName=="OpenIncidents.ascx")
			{
				myOpenView = (Incident_Views.OpenIncidents)Page.LoadControl("~/Incident Views/" + controlName);
				myOpenView.UserRights= Session["userRights"].ToString();
				PlaceHolder1.Controls.Clear();//plhContent.Controls.Clear();
				PlaceHolder1.Controls.Add( myOpenView );
				myOpenView.ID = controlName;
				myOpenView.Initialize();
				Session["tabView"]=controlName;
				
			}
			else if(controlName=="Pending.ascx")
			{
				myPendingView = (Incident_Views.Pending)Page.LoadControl("~/Incident Views/" + controlName);
				myPendingView.UserRights= Session["userRights"].ToString();
				PlaceHolder1.Controls.Clear();
				PlaceHolder1.Controls.Add( myPendingView );
				myPendingView.ID = controlName;
				myPendingView.Initialize();
				Session["tabView"]=controlName;
				
			}
			else if(controlName=="Closed.ascx")
			{
				myClosedView = (Incident_Views.Closed)Page.LoadControl("~/Incident Views/" + controlName);
				myClosedView.UserRights= Session["userRights"].ToString();
				PlaceHolder1.Controls.Clear();
				PlaceHolder1.Controls.Add( myClosedView );
				myClosedView.ID = controlName;
				myClosedView.Initialize();
				Session["tabView"]=controlName;

			}
			else if(controlName=="OverDue.ascx")
			{
				myOverDueView = (Incident_Views.OverDue)Page.LoadControl("~/Incident Views/" + controlName);
				myOverDueView.UserRights= Session["userRights"].ToString();
				PlaceHolder1.Controls.Clear();
				PlaceHolder1.Controls.Add( myOverDueView );
				myOverDueView.ID = controlName;
				myOverDueView.Initialize();
				Session["tabView"]=controlName;
			}
			else if(controlName=="RequestingClosure.ascx")
			{
				myRequestingClosure = (Incident_Views.RequestingClosure)Page.LoadControl("~/Incident Views/" + controlName);
				myRequestingClosure.UserRights= Session["userRights"].ToString();
				PlaceHolder1.Controls.Clear();
				PlaceHolder1.Controls.Add( myRequestingClosure );
				myRequestingClosure.ID = controlName;
				myRequestingClosure.Initialize();
				Session["tabView"]=controlName;
			}
			
		}

		private void lkbtnOverDue_Click(object sender, System.EventArgs e)
		{
			AddTabInfo("OverDue.ascx");
			this.lkbtnOpenIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnOpenIncidents.Font.Bold=false;
			this.lkbtnPendingIncidents.Font.Bold=false;
			this.lkbtnPendingIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnClosedIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnClosedIncidents.Font.Bold=false;
			this.lkbtnOverDue.ForeColor= System.Drawing.Color.Red;
			this.lkbtnOverDue.Font.Bold=true;
			this.lkbtnRequestingClosure.ForeColor= System.Drawing.Color.Black;
			this.lkbtnRequestingClosure.Font.Bold=false;
					
		}

		private void lkbtnRequestingClosure_Click(object sender, System.EventArgs e)
		{
			AddTabInfo("RequestingClosure.ascx");
			this.lkbtnOpenIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnOpenIncidents.Font.Bold=false;
			this.lkbtnPendingIncidents.Font.Bold=false;
			this.lkbtnPendingIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnClosedIncidents.ForeColor= System.Drawing.Color.Black;
			this.lkbtnClosedIncidents.Font.Bold=false;
			this.lkbtnOverDue.ForeColor= System.Drawing.Color.Black;
			this.lkbtnOverDue.Font.Bold=false;
			this.lkbtnRequestingClosure.ForeColor= System.Drawing.Color.Red;
			this.lkbtnRequestingClosure.Font.Bold=true;
		}

	}
}

namespace Constituent_Services.Incident_Views
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Utilites;

	
	public class Pending : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		private string _userRights;
		private void Page_Load(object sender, System.EventArgs e)
		{
			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			
			InitializeComponent();
			base.OnInit(e);
		}
		
		
		private void InitializeComponent()
		{
			this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if( e.CommandArgument.ToString()=="IncidentNumber")
			{
				
				
				DataGridItem item = DataGrid1.Items[e.Item.ItemIndex];
				LinkButton lbl = (LinkButton)item.FindControl("lblIncidentNumber");
				string incidentnumber= lbl.Text;
				Label catLabel= (Label)item.FindControl("lblCatagory");
				string catagory = catLabel.Text;
				Session["IncidentNumber"] =incidentnumber ;
				Session["ProblemType"]= catagory;
				Server.Transfer("AdminModify.aspx",true);
			}
		}
		public string PickLink()
		{
			string url;
			
			url=  "../AdminModify";
			return url;
		}
	
		public string UserRights
		{
			set {_userRights = value;}
			get { return _userRights;}
		}
		public void Initialize() 
		{
			Bind();
		}
		public void Bind()
		{

			if(_userRights==Global.RoleCouncil || _userRights==Global.RoleCityManager || _userRights==Global.RoleITAdmin)
			{
				DataGrid1.DataSource= Incident.SelectAdminIncidents("P");
				DataGrid1.DataBind();

			}
			else if(_userRights==Global.RoleDepartment)
			{
				int departmentId = Convert.ToInt32(Session["Department"]);
				DataGrid1.DataSource= Incident.SelectDepartmentIncidents(departmentId, "P");
				DataGrid1.DataBind();
			}
			else if(_userRights==Global.RoleDivision)
			{
				int divisionId = Convert.ToInt32(Session["Division"]);
				DataGrid1.DataSource= Incident.SelectDivisionIncidents(divisionId, "P");
				DataGrid1.DataBind();
			}

		}

		private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
				e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#DEDFDE'");
			}
			else if(  e.Item.ItemType == ListItemType.AlternatingItem)
			{
				e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#DEDFDE'");
				e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff'");
			}
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Footer)
			{
				e.Item.Cells[4].Text= "Total Count:" + DataGrid1.Items.Count.ToString();
			}
		}
		public System.Drawing.Color PickColor(object incNumb)
		{
			try
			{
				int incidentNumber  = Convert.ToInt32(incNumb);
				Incident incident = new Incident(incidentNumber);
				DateTime pendingDate = incident.GetPendingDate();
				if(pendingDate==System.DateTime.MinValue)
				{
			
					return System.Drawing.Color.Black;
				}
				else
				{
					if(pendingDate < System.DateTime.Now)
					{
						return System.Drawing.Color.Red;
					}
					else
						return System.Drawing.Color.Blue;
				}
			}
			catch
			{
				return System.Drawing.Color.Blue;
			}

		}
	
	}
}

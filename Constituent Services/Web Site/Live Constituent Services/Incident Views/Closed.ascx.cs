namespace Constituent_Services.Incident_Views
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Utilites;

	
	public class Closed : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
        private User _user;


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

		}
		#endregion

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if( e.CommandArgument.ToString()=="IncidentNumber")
			{
				
				{
					DataGridItem item = DataGrid1.Items[e.Item.ItemIndex];
					LinkButton lbl = (LinkButton)item.FindControl("lblIncidentNumber");
					string incidentnumber= lbl.Text;
					Label catLabel= (Label)item.FindControl("lblCatagory");
					string catagory = catLabel.Text;
                    Utilites.Incident incident = new Incident(Convert.ToInt32(incidentnumber));
                    Session["Incident"] = incident;
					Server.Transfer("AdminModify.aspx",true);
				}
				
			}
		}
		public string PickLink()
		{
			string url;
			
			url=  "../AdminModify";
			return url;

		}
		public System.Drawing.Color PickColor(object date)
		{

				return System.Drawing.Color.Black;
		}
	

		public void Initialize() 
		{
            _user = (User)Session["User"];
			Bind();
		}
		public void Bind()
		{

            //if (this._user.IsUserCounciRole() || this._user.IsUserCityManagerRole() || this._user.IsUserITAdminRole())
            //{
            //    DataGrid1.DataSource = Utilites.StaticMethods.SelectAdminIncidents("C");
            //    DataGrid1.DataBind();

            //}
            //else if (this._user.IsUSerDeptRole())
            //{
            //    int departmentId = Convert.ToInt32(Session["Department"]);
            //    DataGrid1.DataSource = Utilites.StaticMethods.SelectDepartmentIncidents(departmentId, "C");
            //    DataGrid1.DataBind();
            //}
            //else if (this._user.IsUserDivRole())
            //{
            //    int divisionId = Convert.ToInt32(Session["Division"]);
            //    DataGrid1.DataSource = Utilites.StaticMethods.SelectDivisionIncidents(divisionId, "C");
            //    DataGrid1.DataBind();
            //}

            DataGrid1.DataSource = this._user.SelectUsersIncidents("C");
            DataGrid1.DataBind();

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
				e.Item.Cells[4].Text= "Total Count: " + DataGrid1.Items.Count.ToString();
			}
		}
	}
}

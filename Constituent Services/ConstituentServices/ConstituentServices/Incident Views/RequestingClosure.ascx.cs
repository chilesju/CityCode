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


	public class RequestingClosure : System.Web.UI.UserControl
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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

		//	if(_userRights==Global.RoleCouncil || _userRights==Global.RoleCityManager || _userRights==Global.RoleITAdmin)
		//	{
			//	DataGrid1.DataSource= Incident.SelectAdminRequestingClosure();
			//	DataGrid1.DataBind();

			//}
            //else if(_userRights==Global.RoleDepartment)
            //{
            //    int departmentId = Convert.ToInt32(Session["Department"]);
            //    DataGrid1.DataSource= Incident.SelectDepartmentRequestingClosure(departmentId);
            //    DataGrid1.DataBind();
            //}
            //else if(_userRights==Global.RoleDivision)
            //{
            //    int divisionId = Convert.ToInt32(Session["Division"]);
            //    DataGrid1.DataSource= Incident.SelectDivisionRequestingClosure(divisionId);
            //    DataGrid1.DataBind();
            //}

		}

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

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Footer)
			{
				e.Item.Cells[4].Text= "Total Count:" + DataGrid1.Items.Count.ToString();
			}
		}
	}
}


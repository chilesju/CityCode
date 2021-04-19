namespace Constituent_Services.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for SearchIncident.
	/// </summary>
	public class SearchIncident : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblLastName;
		protected System.Web.UI.WebControls.Button btnRest;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Label lblFirstName;
		protected System.Web.UI.WebControls.DropDownList councilList;
		protected System.Web.UI.WebControls.DropDownList incidentTypeList;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txIncidentNumber;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.TextBox txtOpenDateMin;
		protected System.Web.UI.WebControls.TextBox txtOpenDateMax;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList statusList;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator2;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator3;
		protected System.Web.UI.WebControls.Label lblIncidentNumber;
		protected string role;
		protected int departmentId, divisionId;

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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			int incidentNumber;
			if(this.txIncidentNumber.Text=="")
			{
				incidentNumber=0;
			}
			else
				incidentNumber = Convert.ToInt32(this.txIncidentNumber.Text);

			string cleanFirstName = Utilites.CleanString.CleanInput(this.txtFirstName.Text);
			string cleanLastName =  Utilites.CleanString.CleanInput(this.txtLastName.Text);
			int problemTypeId;
			if(this.incidentTypeList.SelectedValue=="0")
			{
				problemTypeId = 0;
			}
			else 
				problemTypeId = Convert.ToInt32(this.incidentTypeList.SelectedValue);
			string cleanAddress = Utilites.CleanString.CleanInput(this.txtAddress.Text);
			string councilId;
			if(this.councilList.SelectedValue=="0")
			{
				councilId= "0";
			}
			else
				councilId = this.councilList.SelectedValue;
			string cleanDescription;
			cleanDescription = Utilites.CleanString.CleanInput(this.txtDescription.Text);
			System.DateTime minOpenDate;
			System.DateTime maxOpenDate;
			if(this.txtOpenDateMin.Text=="")
			{
				minOpenDate=Convert.ToDateTime("1/1/1900");
			}
			else
				minOpenDate = Convert.ToDateTime(this.txtOpenDateMin.Text);
			
			if(this.txtOpenDateMax.Text=="")
			{
				maxOpenDate=Convert.ToDateTime("1/1/2099");
			}
			else
				maxOpenDate = Convert.ToDateTime(this.txtOpenDateMax.Text);

			string status;
			
			if(this.statusList.SelectedValue=="0")
			{
				status="0";
			}
			else
				status=this.statusList.SelectedValue;

			role = Session["userRights"].ToString();
			departmentId = Convert.ToInt32(Session["Department"]);
			divisionId = Convert.ToInt32(Session["Division"]);
			//if (role == Global.RoleITAdmin || role== Global.RoleCouncil || role== Global.RoleCityManager)
			//{
				System.Data.DataSet ds = Utilites.Incident.SearchAdminIncidents(incidentNumber,cleanFirstName.Trim(),cleanLastName.Trim(),problemTypeId,councilId,cleanAddress.Trim(),cleanDescription.Trim(),minOpenDate,maxOpenDate,status);
				DataGrid1.DataSource = ds;
				DataGrid1.DataBind();
			//}
            //else if (role== Global.RoleDepartment)
            //{
            //    try
            //    {
            //        System.Data.DataSet ds = Utilites.Incident.SearchDepartmentIncidents(incidentNumber,cleanFirstName.Trim(),cleanLastName.Trim(),problemTypeId,councilId,cleanAddress.Trim(),cleanDescription.Trim(),minOpenDate,maxOpenDate,status, departmentId);
            //        DataGrid1.DataSource = ds;
            //        DataGrid1.DataBind();
            //    }
            //    catch(Exception ex)
            //    {
            //        this.lblFirstName.Text= ex.ToString();
            //    }
            //}
            //else if (role ==Global.RoleDivision)
            //{
            //    System.Data.DataSet ds = Utilites.Incident.SearchDivisionIncidents(incidentNumber,cleanFirstName.Trim(),cleanLastName.Trim(),problemTypeId,councilId,cleanAddress.Trim(),cleanDescription.Trim(),minOpenDate,maxOpenDate,status, divisionId);
            //    DataGrid1.DataSource = ds;
            //    DataGrid1.DataBind();
            //}
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
				/*if(_userRights==Global.RoleITAdmin)
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
				else if(_userRights==Global.RoleUser)
				{
					DataGridItem item = DataGrid1.Items[e.Item.ItemIndex];
					LinkButton lbl = (LinkButton)item.FindControl("lblIncidentNumber");
					string incidentnumber= lbl.Text;
					Label catLabel= (Label)item.FindControl("lblCatagory");
					string catagory = catLabel.Text;
					Session["IncidentNumber"] =incidentnumber;
					Session["ProblemType"]= catagory;
					Server.Transfer("UserModify.aspx",true);

				}*/
				DataGridItem item = DataGrid1.Items[e.Item.ItemIndex];
				LinkButton lbl = (LinkButton)item.FindControl("lkbtnPermitNumber");
				string incidentNumber= lbl.Text;
				Label catLabel= (Label)item.FindControl("lbldgCatagory");
				string catagory = catLabel.Text;
				Session["IncidentNumber"] =incidentNumber ;
				Session["ProblemType"]= catagory;
				Server.Transfer("AdminModify.aspx",true);
			
		
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
		private void BindData()
		{
			

			this.councilList.DataSource= Utilites.CouncilDist.GetAllCouncilDistricts();
			this.councilList.DataTextField= "Council District";
			this.councilList.DataValueField= "Council District";
			this.councilList.DataBind();
			this.councilList.Items.Insert(0, new ListItem("--Select--","0"));

			this.incidentTypeList.DataSource=Utilites.ProblemType.LoadCatagoryAreaForAdmin();
			this.incidentTypeList.DataTextField= "Category";
			this.incidentTypeList.DataValueField= "Id";
			this.incidentTypeList.DataBind();
			this.incidentTypeList.Items.Insert(0, new ListItem("--Select--","0"));

			role = Session["userRights"].ToString();
			departmentId = Convert.ToInt32(Session["Department"]);
			divisionId = Convert.ToInt32(Session["Division"]);
			//if (role == Global.RoleITAdmin || role== Global.RoleCouncil || role== Global.RoleCityManager)
			//{
				this.incidentTypeList.DataSource=Utilites.ProblemType.LoadCatagoryAreaForAdmin();
				
			//}
            //else if (role== Global.RoleDepartment)
            //{
            //        this.incidentTypeList.DataSource=Utilites.ProblemType.LoadCatagoryAreaForDepartment(departmentId);
								
            //}
            //else if (role ==Global.RoleDivision)
            //{
            //    this.incidentTypeList.DataSource=Utilites.ProblemType.LoadCatagoryAreaForDivision(divisionId);
		
            //}
			this.incidentTypeList.DataTextField= "Category";
			this.incidentTypeList.DataValueField= "Id";
			this.incidentTypeList.DataBind();
			this.incidentTypeList.Items.Insert(0, new ListItem("--Select--","0"));

		}
		public void Initialize()
		{
			BindData();
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

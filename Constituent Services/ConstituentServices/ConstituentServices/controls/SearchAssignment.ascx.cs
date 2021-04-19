namespace Constituent_Services.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	public class SearchAssignment : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lblIncidentNumber;
		protected System.Web.UI.WebControls.TextBox txtIncidentNumber;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList departmentList;
		protected System.Web.UI.WebControls.Label lblStreetNumber;
		protected System.Web.UI.WebControls.DropDownList divisionList;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtMinAssignmentDate;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator4;
		protected System.Web.UI.WebControls.TextBox txtMaxAssignmentDate;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator5;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtResolutionDescription;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Button btnRest;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected string role;
		protected int departmentId, divisionId;

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{
			this.departmentList.SelectedIndexChanged += new System.EventHandler(this.departmentList_SelectedIndexChanged);
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.Datagrid2.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.Datagrid2_ItemCreated);
			this.Datagrid2.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid2_EditCommand);
			this.Datagrid2.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.Datagrid2_ItemDataBound);
			this.Load += new System.EventHandler(this.SearchAssignment_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			int incidentNumber;
			int department;
			int division;
			System.DateTime minAssignmentDate;
			System.DateTime maxAssignmentDate;
			string cleanResolution;
			

			if(this.txtIncidentNumber.Text=="")
			{
				incidentNumber=0;
			}
			else
				incidentNumber = Convert.ToInt32(Utilites.CleanString.CleanInput(this.txtIncidentNumber.Text).Trim());
			if(departmentList.SelectedValue=="0")
			{
				department=0;
			}
			else
				department= Convert.ToInt32(departmentList.SelectedValue);

			if(divisionList.SelectedValue=="0")
			{
				division=0;
			}
			else
				division= Convert.ToInt32(divisionList.SelectedValue);

			if(this.txtMinAssignmentDate.Text=="")
			{
				minAssignmentDate=Convert.ToDateTime("1/1/1900");
			}
			else
				minAssignmentDate= Convert.ToDateTime(this.txtMinAssignmentDate.Text.Trim());

			if(this.txtMaxAssignmentDate.Text=="")
			{
				maxAssignmentDate=Convert.ToDateTime("12/12/2900");
			}
			else
				maxAssignmentDate= Convert.ToDateTime(this.txtMaxAssignmentDate.Text.Trim());
			cleanResolution = Utilites.CleanString.CleanInput(this.txtResolutionDescription.Text).Trim();

			

			System.Data.DataSet ds = Utilites.Incident.SearchAssignments(incidentNumber,department,division,minAssignmentDate,maxAssignmentDate,cleanResolution);
			Datagrid2.DataSource = ds;
			Datagrid2.DataBind();
		
		}

		private void SearchAssignment_Load(object sender, System.EventArgs e)
		{

		
		}

		
		private void BindData()
		{
			role = Session["userRights"].ToString();
			departmentId = Convert.ToInt32(Session["Department"]);
			divisionId = Convert.ToInt32(Session["Division"]);

			this.departmentList.DataSource= Utilites.Department.GetDeaprtments();
			this.departmentList.DataTextField= "Department";
			this.departmentList.DataValueField= "DeptId";
			this.departmentList.DataBind();
			this.departmentList.Items.Insert(0, new ListItem("--Select--","0"));
			
			if (role == Global.RoleDepartment)
			{
				this.departmentList.Items.FindByValue(departmentId.ToString()).Selected=true;
				System.Data.DataSet divisionSet = Utilites.Division.GetDivision(departmentId);
				divisionList.DataSource =divisionSet;
				divisionList.DataTextField= "Division";
				divisionList.DataValueField= "DivisionId";
				divisionList.DataBind();
				this.divisionList.DataSource= Utilites.Division.GetDivision(departmentId);
				this.divisionList.DataBind();
				
				ListItem itm2 = new ListItem("--Select All--","0");
				this.divisionList.Items.Insert(0,itm2);
				this.departmentList.Enabled=false;

				
			}
			if (role == Global.RoleDivision)
			{
				this.departmentList.Items.FindByValue(departmentId.ToString()).Selected=true;
				System.Data.DataSet divisionSet = Utilites.Division.GetDivision(departmentId);
				divisionList.DataSource =divisionSet;
				divisionList.DataTextField= "Division";
				divisionList.DataValueField= "DivisionId";
				divisionList.DataBind();
				this.divisionList.DataSource= Utilites.Division.GetDivision(departmentId);
				this.divisionList.DataBind();
				
				ListItem itm2 = new ListItem("--Select All--","0");
				this.divisionList.Items.Insert(0,itm2);
				this.departmentList.Enabled=false;
				this.divisionList.Items.FindByValue(divisionId.ToString()).Selected=true;
				this.divisionList.Enabled=false;
				
			}
				

				}
		public void Initialize()
		{
			BindData();
		}

		private void Datagrid2_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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

		private void Datagrid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Footer)
			{
				e.Item.Cells[4].Text= "Total Count:" + Datagrid2.Items.Count.ToString();
			}
		}

		private void departmentList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.departmentList.SelectedValue=="0")
			{
				this.divisionList.Items.Clear();
				ListItem itm = new ListItem("--Select Department--","0");
			

				this.divisionList.Items.Add(itm);
			}
			else
			{
				int departmentId= Convert.ToInt32(this.departmentList.SelectedValue);
				System.Data.DataSet divisionSet = Utilites.Division.GetDivision(departmentId);
				divisionList.DataSource =divisionSet;
				divisionList.DataTextField= "Division";
				divisionList.DataValueField= "DivisionId";
				divisionList.DataBind();
				this.divisionList.DataSource= Utilites.Division.GetDivision(departmentId);
				this.divisionList.DataBind();
				
					ListItem itm2 = new ListItem("--Select All--","0");
					this.divisionList.Items.Insert(0,itm2);
			
				if(this.divisionList.Items.Count==0)
				{
					ListItem itm = new ListItem("--Select Department--","0");
					this.divisionList.Items.Add(itm);
				}
			
			}
		}

		private void Datagrid2_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = Datagrid2.Items[e.Item.ItemIndex];
			LinkButton lbl = (LinkButton)item.FindControl("lkbtnPermitNumber");
			string incidentNumber= lbl.Text;
			Label catLabel= (Label)item.FindControl("lbldgCatagory");
			string catagory = catLabel.Text;
			Session["IncidentNumber"] =incidentNumber ;
			Session["ProblemType"]= catagory;
			Server.Transfer("AdminModify.aspx",true);
		}

	}
}

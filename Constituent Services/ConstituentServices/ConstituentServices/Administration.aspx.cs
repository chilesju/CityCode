using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Utilites;

namespace Constituent_Services
{

	public class Administration : System.Web.UI.Page
	{
		string role;
		int departmentId, divisionId;
		protected System.Web.UI.WebControls.DataGrid dgUserList;
		protected System.Web.UI.WebControls.Label lblCatagories;
		protected System.Web.UI.WebControls.DataGrid dgCatagories;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblRole;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			role = Session["userRights"].ToString();
			departmentId = Convert.ToInt32(Session["Department"]);
			divisionId = Convert.ToInt32(Session["Division"]);

			//if (role == Global.RoleDepartment)
			//{
                //this.lblRole.Text= "Department Active Contacts:";
                //this.dgUserList.DataSource = Utilites.User.GetAllUsersInADepartment(departmentId);
                //this.dgUserList.DataBind();
                //this.lblCatagories.Text= "All the Catagories for this Department:";
                //this.dgCatagories.DataSource= Utilites.ProblemType.LoadCatagoryAreaForDepartment(departmentId);
                //this.dgCatagories.DataBind();
				
            //}
            //else if (role == Global.RoleDivision)
            //{
            //    this.lblRole.Text= "Division Active Contacts:";	
            //    this.dgUserList.DataSource = Utilites.User.GetAllUsersInADivision(divisionId);
            //    this.dgUserList.DataBind();
            //    this.lblCatagories.Text= "All the Catagories for this Division:";
            //    this.dgCatagories.DataSource= Utilites.ProblemType.LoadCatagoryAreaForDivision(divisionId);
            //    this.dgCatagories.DataBind();
            //}
            //else if (role==Global.RoleCityManager || role==Global.RoleCouncil || role==Global.RoleITAdmin)
            //{
            //    this.lblRole.Text= "Admin  Active Contacts:";
            //    this.dgUserList.DataSource = Utilites.User.GetAllUsersInformation();
            //    this.dgUserList.DataBind();
            //    this.lblCatagories.Text= "All the Catagories:";
            //    this.dgCatagories.DataSource= Utilites.ProblemType.LoadCatagoryAreaForAdmin();
            //    this.dgCatagories.DataBind();
	
            //}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			
			InitializeComponent();
			base.OnInit(e);
		}
		
		
		private void InitializeComponent()
		{    
			this.dgUserList.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgUserList_ItemCreated);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgUserList_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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


	}
}


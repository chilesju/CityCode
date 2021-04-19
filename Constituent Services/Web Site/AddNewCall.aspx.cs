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
using ConstituentServices.controls;

namespace Constituent_Services
{
	
	public class AddNewCall : System.Web.UI.Page
	{
		protected string role;
		protected int departmentId, divisionId;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.DataGrid dgPolice;
		protected System.Web.UI.WebControls.DataGrid dgParksRec;
		protected System.Web.UI.WebControls.DataGrid dgGeneral;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid dgPublicWorks;
		protected System.Web.UI.WebControls.DataGrid dgCodeServices;
		protected System.Web.UI.WebControls.DataGrid dgTraffic;
		protected System.Web.UI.WebControls.DataGrid dgWater;
		protected System.Web.UI.WebControls.DataGrid dgStreet;
		protected System.Web.UI.WebControls.DataGrid dgPlanning;
        protected System.Web.UI.WebControls.DataGrid dgCityCouncil;
		protected System.Web.UI.WebControls.Label Label12;
        private Utilites.User _user;
		private void Page_Load(object sender, System.EventArgs e)
		{
            try
            {
                this._user = (Utilites.User)Session["User"];
                if (!IsPostBack)
                {

                    if (this._user.IsUserITAdminRole() || this._user.IsUserCounciRole())
                    {
                        // initialize the DataSet
                        DataSet problemTypeDataSet;
                        problemTypeDataSet = Utilites.Category.LoadAllProblemTypes();

                        //Code Services
                        dgCodeServices.DataSource = problemTypeDataSet.Tables[0];
                        dgCodeServices.DataBind();

                        //Street
                        dgStreet.DataSource = problemTypeDataSet.Tables[1];
                        dgStreet.DataBind();

                        //Public Works (everything else)
                        dgPublicWorks.DataSource = problemTypeDataSet.Tables[2];
                        dgPublicWorks.DataBind();

                        //Trans Op (traffic)
                        dgTraffic.DataSource = problemTypeDataSet.Tables[3];
                        dgTraffic.DataBind();

                        //Water
                        dgWater.DataSource = problemTypeDataSet.Tables[4];
                        dgWater.DataBind();

                        //Parks & Rec
                        dgParksRec.DataSource = problemTypeDataSet.Tables[5];
                        dgParksRec.DataBind();

                        //General
                        dgGeneral.DataSource = problemTypeDataSet.Tables[6];
                        dgGeneral.DataBind();

                        //Police
                        dgPolice.DataSource = problemTypeDataSet.Tables[7];
                        dgPolice.DataBind();

                        //Planning
                        dgPlanning.DataSource = problemTypeDataSet.Tables[8];
                        dgPlanning.DataBind();

                        //City Council
                        this.dgCityCouncil.DataSource = problemTypeDataSet.Tables[10];
                        dgCityCouncil.DataBind();

                    }
                }
            }
            catch
            {
                Server.Transfer("MainScreen.aspx", true);
            }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgPolice.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgWater_ItemCreated);
			this.dgPolice.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgPolice_EditCommand);
			this.dgParksRec.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgWater_ItemCreated);
			this.dgParksRec.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgParksRec_EditCommand);
			this.dgPlanning.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgWater_ItemCreated);
			this.dgPlanning.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgPlanning_EditCommand);
			this.dgGeneral.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgWater_ItemCreated);
            this.dgGeneral.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgGeneral_EditCommand);
			this.dgPublicWorks.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgWater_ItemCreated);
			this.dgPublicWorks.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgPublicWorks_EditCommand);
            this.dgCodeServices.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgWater_ItemCreated);
			this.dgCodeServices.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCodeServices_EditCommand);
			this.dgTraffic.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgWater_ItemCreated);
			this.dgTraffic.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTraffic_EditCommand);
			this.dgWater.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgWater_ItemCreated);
			this.dgWater.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgWater_EditCommand);
			this.dgStreet.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgWater_ItemCreated);
			this.dgStreet.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgStreet_EditCommand);
			this.dgStreet.SelectedIndexChanged += new System.EventHandler(this.dgStreet_SelectedIndexChanged);
            this.dgCityCouncil.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCityCouncil_EditCommand);
            this.dgCityCouncil.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgWater_ItemCreated);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgPolice_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = dgPolice.Items[e.Item.ItemIndex];
			
			//Creates link button to connect to correct page
			LinkButton lblcat = (LinkButton)item.FindControl("lblCodeCategory");
			string catagory= lblcat.Text;
			Session["Catagory"] =catagory ;
			
			Label lblCodeInformationNeeded = (Label)item.FindControl("lblCodeInformationNeeded");
			string detail = lblCodeInformationNeeded.Text;
			Session["Detail"]= detail;
			Server.Transfer("ProblemWriteUp.aspx?" +catagory,true);
		}

		private void dgGeneral_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = dgGeneral.Items[e.Item.ItemIndex];
			
			LinkButton lblcat = (LinkButton)item.FindControl("lblGeneralCatagory");
			string catagory= lblcat.Text;
			Session["Catagory"] =catagory ;
			
			Label lblDetail = (Label)item.FindControl("lblGeneralNeeded");
			string detail = lblDetail.Text;
			Session["Detail"]= detail;
			Server.Transfer("ProblemWriteUp.aspx?" +catagory,true);
		}


		private void dgCodeServices_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = dgCodeServices.Items[e.Item.ItemIndex];
			
			LinkButton lblcat = (LinkButton)item.FindControl("lblCodeServicesCatagory");
			string catagory= lblcat.Text;
			Session["Catagory"] =catagory ;

            Label lblDetail = (Label)item.FindControl("lblCodeInformationNeeded");
			string detail = lblDetail.Text;
			Session["Detail"]= detail;
            Response.Redirect("ProblemWriteUp.aspx?" + catagory);
			//Server.Transfer("ProblemWriteUp.aspx?" +catagory);
		}

		private void dgTraffic_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = dgTraffic.Items[e.Item.ItemIndex];
			
			LinkButton lblcat = (LinkButton)item.FindControl("lblTrafficCatagory");
			string catagory= lblcat.Text;
			Session["Catagory"] =catagory ;
			
			Label lblDetail = (Label)item.FindControl("lblTraffic");
			string detail = lblDetail.Text;
			Session["Detail"]= detail;
			Server.Transfer("ProblemWriteUp.aspx?" +catagory,true);
		}

		private void dgWater_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = dgWater.Items[e.Item.ItemIndex];
			
			LinkButton lblcat = (LinkButton)item.FindControl("lblWaterCategory");
			string catagory= lblcat.Text;
			Session["Catagory"] =catagory ;
			
			Label lblDetail = (Label)item.FindControl("lblWater");
			string detail = lblDetail.Text;
			Session["Detail"]= detail;
			Server.Transfer("ProblemWriteUp.aspx?" +catagory,true);
		}

		
		private void dgPublicWorks_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = dgPublicWorks.Items[e.Item.ItemIndex];
			
			LinkButton lblcat = (LinkButton)item.FindControl("lblPwCatagory");
			string catagory= lblcat.Text;
			Session["Catagory"] =catagory ;
			
			Label lblDetail = (Label)item.FindControl("lblPublicWorks");
			string detail = lblDetail.Text;
			Session["Detail"]= detail;
			Server.Transfer("ProblemWriteUp.aspx?" +catagory,true);
		}

		private void dgParksRec_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = dgParksRec.Items[e.Item.ItemIndex];
			
			LinkButton lblcat = (LinkButton)item.FindControl("lblParksRecCatagory");
			string catagory= lblcat.Text;
			Session["Catagory"] =catagory ;
			
			Label lblDetail = (Label)item.FindControl("lblParksRec");
			string detail = lblDetail.Text;
			Session["Detail"]= detail;
			Server.Transfer("ProblemWriteUp.aspx?" +catagory,true);
		}

		private void dgPublicWorks_EditCommand_1(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = dgPublicWorks.Items[e.Item.ItemIndex];
			
			LinkButton lblcat = (LinkButton)item.FindControl("lblPwCatagory");
			string catagory= lblcat.Text;
			Session["Catagory"] =catagory ;
			
			Label lblDetail = (Label)item.FindControl("lblPublicWorks");
			string detail = lblDetail.Text;
			Session["Detail"]= detail;
			Server.Transfer("ProblemWriteUp.aspx?" +catagory,true);
		}

		private void dgWater_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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


		private void dgPlanning_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = dgPlanning.Items[e.Item.ItemIndex];
			
			LinkButton lblcat = (LinkButton)item.FindControl("lblPlanningCategory");
			string catagory= lblcat.Text;
			Session["Catagory"] =catagory ;
			
			Label lblDetail = (Label)item.FindControl("lblPlanning");
			string detail = lblDetail.Text;
			Session["Detail"]= detail;
			Server.Transfer("ProblemWriteUp.aspx?" +catagory,true);
		}

		private void dgStreet_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem item = dgStreet.Items[e.Item.ItemIndex];
			
			LinkButton lblcat = (LinkButton)item.FindControl("lblStreetCategory");
			string catagory= lblcat.Text;
			Session["Catagory"] =catagory ;
			
			Label lblDetail = (Label)item.FindControl("lblStreet");
			string detail = lblDetail.Text;
			Session["Detail"]= detail;
			Server.Transfer("ProblemWriteUp.aspx?" +catagory,true);
		}
        private void dgCityCouncil_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            DataGridItem item = this.dgCityCouncil.Items[e.Item.ItemIndex];

            LinkButton lblcat = (LinkButton)item.FindControl("lblCityCouncilCategory");
            string catagory = lblcat.Text;
            Session["Catagory"] = catagory;

            Label lblDetail = (Label)item.FindControl("lblCityCouncil");
            string detail = lblDetail.Text;
            Session["Detail"] = detail;
            Server.Transfer("ProblemWriteUp.aspx?" + catagory, true);
        }

		private void dgStreet_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


		
	}
}

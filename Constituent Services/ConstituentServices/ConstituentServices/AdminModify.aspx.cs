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
	public class Modify : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblLastUpdated;
		protected System.Web.UI.WebControls.Label lblDateSubmitted;
		protected System.Web.UI.WebControls.Label lblProblemType;
		protected System.Web.UI.WebControls.DropDownList problemTypeList;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label lblIncidentNumber;
		protected System.Web.UI.WebControls.TextBox txtIncidentDescription;
		protected System.Web.UI.WebControls.RadioButton rbtnClosed;
		protected System.Web.UI.WebControls.RadioButton rbtnOpen;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected Constituent_Services.controls.AdminTabsPlaceHolder adminTabsPlaceHolder1;
		protected AssignmentCollection assignemntCol= new AssignmentCollection();
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList councilDistList;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtPendingDate;
		protected System.Web.UI.WebControls.RadioButton rbtnPendning;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		int incidentnumber;
		private string status;
		protected System.Web.UI.WebControls.RadioButton rbtnYes;
		protected System.Web.UI.WebControls.RadioButton rbtnNo;
		protected System.Web.UI.WebControls.TextBox txtCourtDate;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lblInsertedBy;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.RadioButton rbtnCityContactedYes;
		protected System.Web.UI.WebControls.RadioButton rbtnCityContactedNo;
		protected System.Web.UI.WebControls.RadioButton rbtnNoClose;
		protected System.Web.UI.WebControls.RadioButton rbtnYesClose;
		protected System.Web.UI.WebControls.Label Label10;
		//protected SecurityManager sm;
		protected string role;
		protected System.Web.UI.WebControls.Label lblContactConstituent;
		private int citizenId;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			incidentnumber=  Convert.ToInt32(Session["IncidentNumber"]);
			this.btnPrint.Attributes.Add("onclick","javascript: window.open('PrintScreen.aspx?rpt=IncidentReport&prtNum="+ incidentnumber +"');");
			problemTypeList.Attributes.Add("OnChange","alert('NOTE:  If you are changing the problem type and this problem is not associated with your division please change to the correct Department and or Division below and click on the Reassign Call button. Thank you.')"); 
            //sm = new SecurityManager();
            //sm.AuthorizationProvider = "Authorization Provider";
            //sm.SecurityCacheProvider = "Caching Store Provider";
            //if(sm.IsUserInRole(User, Global.RoleITAdmin)) role = Global.RoleITAdmin;
            //else if(sm.IsUserInRole(User,Global.RoleCouncil)) role = Global.RoleCouncil;
            //else if(sm.IsUserInRole(User,Global.RoleCityManager)) role =Global.RoleCityManager;
            //else if (sm.IsUserInRole(User,Global.RoleDepartment)) role =Global.RoleDepartment;
            //else if (sm.IsUserInRole(User,Global.RoleDivision)) role =Global.RoleDivision;
			
			if (!Page.IsPostBack) 
			{
				BindData();
				Utilites.Incident incident = new Utilites.Incident(incidentnumber);
				incident.GetIndividualIncident();
				lblIncidentNumber.Text +=incident.IncidentId.ToString();
				lblDateSubmitted.Text += incident.OpenDate.ToString();
				txtAddress.Text= incident.Address;
				txtIncidentDescription.Text = incident.IncidentDisc;
				lblLastUpdated.Text += incident.ModifyDate.ToString();
				councilDistList.Items.FindByValue(incident.CouncilDist).Selected=true;
				this.lblInsertedBy.Text += incident.InsertedBy;
				if(incident.Openclose=="O")
				{
					rbtnOpen.Checked=true;
					this.btnUpdate.Enabled=true;
					Session["Status"]="O";
				}
				else if(incident.Openclose=="C")
				{
					rbtnClosed.Checked=true;
					this.btnUpdate.Enabled=false;
					Session["Status"]="C";
				}
				if(incident.HasCitizenBeenContacted==true)
				{
					this.rbtnCityContactedYes.Checked=true;
				}
				else
					this.rbtnCityContactedNo.Checked= true;

				if(incident.RequstingClosure==true)
				{
					this.rbtnYesClose.Checked=true;
				}
				else
					this.rbtnNoClose.Checked=true;

				if(incident.Contact==1)
				{
					rbtnYes.Checked=true;
				}
				else if(incident.Contact==0)
				{
					rbtnNo.Checked=true;
				}
				if(incident.CourtDate==System.DateTime.MinValue)
				{
					txtCourtDate.Text= "";
				}
				else
					txtCourtDate.Text= incident.CourtDate.ToShortDateString();
				if(incident.PendingDate==System.DateTime.MinValue)
				{
					txtPendingDate.Text= "";
				}
				else
					txtPendingDate.Text= incident.PendingDate.ToShortDateString();
	
				

				problemTypeList.Items.FindByValue(Convert.ToString(incident.ProblemTypeId)).Selected=true;
			
				foreach(Utilites.Citizen citizen in incident.CitizenCollection)
				{
					Session["citizen"]= citizen;
					citizenId= citizen.CitizenId;	
					txtFirstName.Text= citizen.FirstName;
					txtLastName.Text= citizen.LastName;
					txtPhoneNumber.Text= citizen.PhoneNumber;
					txtEmail.Text= citizen.Email;
				}
			}
			Utilites.Assignment assignemnt = new Utilites.Assignment();
			assignemntCol = assignemnt.GetAllIncidentAssignments(incidentnumber);
			adminTabsPlaceHolder1.IncidentId=incidentnumber;
			adminTabsPlaceHolder1.AssignmentCollection = assignemntCol;
			this.rbtnClosed.Enabled=false;
			this.rbtnOpen.Enabled=false;
			if(role=="Council" || role== "IT Admin")
			{
				this.rbtnClosed.Enabled=true;
				this.rbtnOpen.Enabled=true;
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
			this.rbtnOpen.CheckedChanged += new System.EventHandler(this.rbtnOpen_CheckedChanged);
			this.rbtnClosed.CheckedChanged += new System.EventHandler(this.rbtnClosed_CheckedChanged);
			this.rbtnYesClose.CheckedChanged += new System.EventHandler(this.rbtnYesClose_CheckedChanged);
			this.rbtnNoClose.CheckedChanged += new System.EventHandler(this.rbtnNoClose_CheckedChanged);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//if (Page.IsValid)
			
		}
		private void BindData()
		{
			DataSet problemDataSet= Utilites.ProblemType.LoadCatagoryAreaForAdmin();
			problemTypeList.DataSource=problemDataSet;
			problemTypeList.DataTextField= "Category";
			problemTypeList.DataValueField= "Id";
			problemTypeList.DataBind();
			string problemType = Session["ProblemType"].ToString();

			DataSet councilDataSet = Utilites.CouncilDistrict.GetCouncilDistricts();
			councilDistList.DataSource= councilDataSet;
			councilDistList.DataTextField= "Council District";
			councilDistList.DataValueField= "Council District";
			councilDistList.DataBind();
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			
			lblErrorMessage.Visible=false;

			string cleanAddress = CleanString.CleanInput(txtAddress.Text);
			string cleanDescription = CleanString.CleanInput(txtIncidentDescription.Text);
			string status="";
			int contact=0;
			if(rbtnOpen.Checked==true)
			{
				status="O";
			}
			else if(rbtnClosed.Checked==true)
			{
				status="C";
			}
			if(rbtnYes.Checked==true)
			{
				contact= 1;
			}
			else if(rbtnNo.Checked==true)
			{
				contact=0;
			}

			int problemTypeint = Convert.ToInt32(problemTypeList.SelectedValue);
			System.DateTime pendingDate;
			if(txtPendingDate.Text=="")
			{
				pendingDate=System.DateTime.MinValue;
			}
			else
			{
				pendingDate = Convert.ToDateTime(txtPendingDate.Text);
			}
					
			bool citizenBeenContacted, requestClosure;
			if(this.rbtnCityContactedYes.Checked==true)
			{
				citizenBeenContacted=true;
			}
			else
				citizenBeenContacted=false;

			if(this.rbtnYesClose.Checked==true)
			{
				requestClosure=true;
			}
			else
				requestClosure=false;

			System.DateTime courtDate;
			if(txtCourtDate.Text=="")
			{
				courtDate=System.DateTime.MinValue;
			}
			else
				courtDate = Convert.ToDateTime(txtCourtDate.Text);
		
			Incident incident = new Incident(cleanAddress,problemTypeint,cleanDescription,councilDistList.SelectedValue,status,User.Identity.Name,pendingDate,incidentnumber,contact,courtDate,User.Identity.Name,requestClosure,citizenBeenContacted);
			if(incident.UpdateIncident())
			{

			}
			else{}
			
		}

		private void rbtnOpen_CheckedChanged(object sender, System.EventArgs e)
		{
			Incident incident = new Incident();
			incident.PersonUpdating = User.Identity.Name;
			if(incident.UpdateStatus(incidentnumber, "O"))
			{
				this.btnUpdate.Enabled=true;
				Session["Status"]="O";
			}
			else{}
		}

		private void rbtnClosed_CheckedChanged(object sender, System.EventArgs e)
		{
			Incident incident = new Incident();
			incident.PersonUpdating = User.Identity.Name;
			if(incident.UpdateStatus(incidentnumber, "C"))
			{
				this.btnUpdate.Enabled=false;
				Session["Status"]="C";

			}
			else{}
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
		
		}

		private void rbtnYesClose_CheckedChanged(object sender, System.EventArgs e)
		{
			Incident incident = new Incident();
			incident.PersonUpdating = User.Identity.Name;
			if(incident.UpdateRequestingClosure(incidentnumber,1))
			{
				this.btnUpdate.Enabled=false;
				Session["Status"]="C";

			}
			else{}
		}

		private void rbtnNoClose_CheckedChanged(object sender, System.EventArgs e)
		{
			Incident incident = new Incident();
			incident.PersonUpdating = User.Identity.Name;
			if(incident.UpdateRequestingClosure(incidentnumber, 0))
			{
				this.btnUpdate.Enabled=false;
				Session["Status"]="C";

			}
			else{}
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{

		
		}
	}
}

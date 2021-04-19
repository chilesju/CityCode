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
		protected System.Web.UI.WebControls.Label lblContactConstituent;
		private int citizenId;
        private Utilites.Incident _incident;
        private Utilites.User _user;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
            _incident = (Utilites.Incident)Session["Incident"];
            _user = (Utilites.User)Session["User"];

			this.btnPrint.Attributes.Add("onclick","javascript: window.open('PrintScreen.aspx?rpt=IncidentReport&prtNum="+ this._incident.IncidentId +"');");
			problemTypeList.Attributes.Add("OnChange","alert('NOTE:  If you are changing the problem type and this problem is not associated with your division please change to the correct Department and or Division below and click on the Reassign Call button. Thank you.')"); 

			
			if (!Page.IsPostBack) 
			{
				BindData();
				lblIncidentNumber.Text +=_incident.IncidentId.ToString();
				lblDateSubmitted.Text += _incident.OpenDate.ToString();
                txtAddress.Text = _incident.Address;
                txtIncidentDescription.Text = _incident.IncidentDisc;
                lblLastUpdated.Text += _incident.ModifyDate.ToString();
                councilDistList.Items.FindByValue(_incident.CouncilDist).Selected = true;
                this.lblInsertedBy.Text += _incident.InsertedBy;
                if (_incident.Openclose == "O")
				{
					rbtnOpen.Checked=true;
					this.btnUpdate.Enabled=true;
					Session["Status"]="O";
				}
                else if (_incident.Openclose == "C")
				{
					rbtnClosed.Checked=true;
					this.btnUpdate.Enabled=false;
					Session["Status"]="C";
				}
                if (_incident.HasCitizenBeenContacted == true)
				{
					this.rbtnCityContactedYes.Checked=true;
				}
				else
					this.rbtnCityContactedNo.Checked= true;

                if (_incident.RequstingClosure == true)
				{
					this.rbtnYesClose.Checked=true;
				}
				else
					this.rbtnNoClose.Checked=true;

                if (_incident.Contact == 1)
				{
					rbtnYes.Checked=true;
				}
                else if (_incident.Contact == 0)
				{
					rbtnNo.Checked=true;
				}
                if (_incident.CourtDate == System.DateTime.MinValue)
				{
					txtCourtDate.Text= "";
				}
				else
                    txtCourtDate.Text = _incident.CourtDate.ToShortDateString();
                if (_incident.PendingDate == System.DateTime.MinValue)
				{
					txtPendingDate.Text= "";
				}
				else
                    txtPendingDate.Text = _incident.PendingDate.ToShortDateString();



                problemTypeList.Items.FindByValue(Convert.ToString(_incident.ProblemTypeId)).Selected = true;

                foreach (Utilites.Citizen citizen in _incident.CitizenCollection)
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
            assignemntCol = assignemnt.GetAllIncidentAssignments(this._incident.IncidentId);
            adminTabsPlaceHolder1.IncidentId = this._incident.IncidentId;
			adminTabsPlaceHolder1.AssignmentCollection = assignemntCol;
			this.rbtnClosed.Enabled=false;
			this.rbtnOpen.Enabled=false;
            if (this._user.IsUserCounciRole() || this._user.IsUserITAdminRole())
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	    private void BindData()
		{


            DataSet problemDataSet = Utilites.Category.LoadCatagoryAreaForAdmin();
			problemTypeList.DataSource=problemDataSet;
			problemTypeList.DataTextField= "Category";
			problemTypeList.DataValueField= "Id";
			problemTypeList.DataBind();

            DataSet councilDataSet = Utilites.StaticMethods.GetCouncilDistricts();
			councilDistList.DataSource= councilDataSet;
			councilDistList.DataTextField= "Council District";
			councilDistList.DataValueField= "Council District";
			councilDistList.DataBind();
		}


        private void SetIncidentValues()
        {
            string cleanAddress = CleanString.CleanInput(txtAddress.Text);
            this._incident.Address= cleanAddress;

            string cleanDescription = CleanString.CleanInput(txtIncidentDescription.Text);
            this._incident.IncidentDisc = cleanDescription;

            string status = "";
           

            if (rbtnOpen.Checked == true)
            {
                status = "O";
            }
            else if (rbtnClosed.Checked == true)
            {
                status = "C";
            }
            this._incident.Openclose = status;

            int contact = 0;
            if (rbtnYes.Checked == true)
            {
                contact = 1;
            }
            else if (rbtnNo.Checked == true)
            {
                contact = 0;
            }
            this._incident.Contact = contact;

            int problemTypeint = Convert.ToInt32(problemTypeList.SelectedValue);
            this._incident.ProblemTypeId = problemTypeint;

            System.DateTime pendingDate;
            if (txtPendingDate.Text == "")
            {
                pendingDate = System.DateTime.MinValue;
            }
            else
            {
                pendingDate = Convert.ToDateTime(txtPendingDate.Text);
            }
            this._incident.PendingDate = pendingDate;

            bool citizenBeenContacted;
            bool requestClosure;

            if (this.rbtnCityContactedYes.Checked == true)
            {
                citizenBeenContacted = true;
            }
            else
                citizenBeenContacted = false;
            this._incident.HasCitizenBeenContacted = citizenBeenContacted;

            if (this.rbtnYesClose.Checked == true)
            {
                requestClosure = true;
            }
            else
                requestClosure = false;
            this._incident.RequstingClosure = requestClosure;


            System.DateTime courtDate;
            if (txtCourtDate.Text == "")
            {
                courtDate = System.DateTime.MinValue;
            }
            else
                courtDate = Convert.ToDateTime(txtCourtDate.Text);
            this._incident.CourtDate = courtDate;
            string councilDist = this.councilDistList.SelectedValue;
            this._incident.CouncilDist = councilDist;

        }
        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            this._incident.PersonUpdating = "me";
            SetIncidentValues();
            if (this._incident.UpdateIncident())
            {

            }
            else { }
        }

        protected void rbtnYesClose_CheckedChanged1(object sender, EventArgs e)
        {
            this._incident.PersonUpdating = User.Identity.Name;
            SetIncidentValues();
            if (this._incident.UpdateIncident())
            {
                this.btnUpdate.Enabled = false;
                Session["Status"] = "C";

            }
            else { }
        }

        protected void rbtnNoClose_CheckedChanged1(object sender, EventArgs e)
        {
           
            this._incident.PersonUpdating = User.Identity.Name;
            SetIncidentValues();
            if (this._incident.UpdateIncident())
            {
                this.btnUpdate.Enabled = false;
                Session["Status"] = "C";

            }
            else { }
        }

        protected void rbtnOpen_CheckedChanged1(object sender, EventArgs e)
        {
            try
            {
                this._incident.PersonUpdating = User.Identity.Name;
                if (this._incident.UpdateStatus(this._incident.IncidentId, "O"))
                {
                    this.btnUpdate.Enabled = true;
                    Session["Status"] = "O";
                }
                else { }
            }
            catch (Exception ex)
            {
                this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = "Error Opening the incident: " + ex.ToString();
            }
        }

        protected void rbtnClosed_CheckedChanged1(object sender, EventArgs e)
        {
            try
            {
                this._incident.PersonUpdating = User.Identity.Name;
                if (this._incident.UpdateStatus(this._incident.IncidentId, "C"))
                {
                    this.btnUpdate.Enabled = false;
                    Session["Status"] = "C";

                }
                else { }
            }
            catch (Exception ex)
            {
                this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = "Error Closing the incident: " + ex.ToString();
            }
        }
	}
}

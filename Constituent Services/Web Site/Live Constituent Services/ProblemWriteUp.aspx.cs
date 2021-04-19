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
	
	public class ProblemWriteUp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lblMoreInfo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblPropblem;
		protected System.Web.UI.WebControls.Label lblDetail;
		protected System.Web.UI.WebControls.TextBox txtProblemDetail;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox txtStreetNumber;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList directionList;
		protected System.Web.UI.WebControls.TextBox txtRoad;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtIntersection;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.RegularExpressionValidator regexpvalidPhoneNumber;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.RegularExpressionValidator validEmail;
		protected System.Web.UI.WebControls.CheckBox chbxAnonymous;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.RadioButton rbtnYes;
		protected System.Web.UI.WebControls.RadioButton rbtnNo;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Label lblAssignmentInformation;
		protected System.Web.UI.WebControls.DataGrid dgUsersAssignedToThisCatagory;
		protected System.Web.UI.WebControls.Button btnReset;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			lblDate.Text= System.DateTime.Now.ToString();
			chbxAnonymous.Attributes.Add("OnClick", "DisablePersonalInfo()");
			this.txtIntersection.Attributes.Add("onchange", "DisableStreet()");
	
			
			if(!IsPostBack)
			{
				lblPropblem.Text= Request.QueryString[0];
				lblDetail.Text = Session["Detail"].ToString();
				Session["Problem"] = this.lblPropblem.Text;
                if (this.lblPropblem.Text != "General")
                {
                    this.dgUsersAssignedToThisCatagory.DataSource = Utilites.Category.GetUsersAssigedToCatagory(lblPropblem.Text);
                    this.dgUsersAssignedToThisCatagory.DataBind();
                }
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

			
        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (this.rbtnYes.Checked == true && this.txtEmail.Text == "" && this.txtPhoneNumber.Text == "")
                {
                    this.lblMoreInfo.Text = "To be contacted please include a phone number or email address";
                }
                else
                {

                    if (this.txtIntersection.Text == "" && this.txtRoad.Text == "" && this.txtStreetNumber.Text == "")
                    {
                        lblMoreInfo.Text = "You need to include some sort of address or intersection.";
                    }

                    else
                    {

                        if ((this.chbxAnonymous.Checked == false) && (this.txtFirstName.Text == "" && this.txtLastName.Text == "" && this.txtPhoneNumber.Text == "" && this.txtEmail.Text == ""))
                        {
                            lblMoreInfo.Text = "Please include contact information or select anonymous.";
                        }
                        else
                        {
                            lblMoreInfo.Text = "";
                            Citizen citizen;
                            if (chbxAnonymous.Checked == true)
                            {
                                citizen = new Citizen("Anonymous", "Anonymous", "Anonymous", "Anonymous");
                            }
                            else
                            {
                                string cleanEmail = CleanString.CleanInput(txtEmail.Text);
                                string cleanFirstName = CleanString.CleanInput(txtFirstName.Text);
                                string cleanLastName = CleanString.CleanInput(txtLastName.Text);
                                string cleanPhoneNumber = CleanString.CleanInput(txtPhoneNumber.Text);
                                citizen = new Citizen(cleanFirstName.ToUpper(), cleanLastName.ToUpper(), cleanPhoneNumber, cleanEmail);
                            }

                            int citizenId = citizen.InsertCitizen();
                            Session["Citizen"] = citizen;
                            int contact = 0;
                            int problemTypeId = Category.GetCatagoryId(lblPropblem.Text);
                            string cleanDesc = CleanString.CleanInput(this.txtProblemDetail.Text);

                            string insertedBy = User.Identity.Name;
                            if (rbtnYes.Checked == true)
                            {
                                contact = 1;
                            }
                            else if (rbtnNo.Checked == true)
                            {
                                contact = 0;
                            }
                            if (this.txtIntersection.Text == "")
                            {

                                string cleanNumber = CleanString.CleanInput(this.txtStreetNumber.Text);
                                string direction = this.directionList.SelectedValue;
                                string cleanRoad = CleanString.CleanInput(this.txtRoad.Text);
                                string address = cleanNumber + " " + direction + " " + cleanRoad;

                                Incident incident = new Incident(address.ToUpper(), problemTypeId, cleanDesc.ToUpper(), citizenId, contact);


                                int id = incident.InsertIncident(insertedBy);
                                Session["Incident"] = incident;
                                Session["IncidentId"] = id;

                                if (problemTypeId == 1)
                                {
                                    Server.Transfer("ConfirmationWithAssignment.aspx", false);
                                }
                                else
                                {
                                    Server.Transfer("Confirmation.aspx", false);
                                }
                                Server.Transfer("Confirmation.aspx", false);
                            }

                            else
                            {
                                string cleanIntersection = CleanString.CleanInput(this.txtIntersection.Text);
                                Incident incident = new Incident(cleanIntersection.ToUpper(), problemTypeId, cleanDesc.ToUpper(), citizenId, contact);

                                int id = incident.InsertIncident(insertedBy);
                                Session["Incident"] = incident;
                                Session["IncidentId"] = id;

                                if (problemTypeId == 1)
                                {
                                    Server.Transfer("ConfirmationWithAssignment.aspx", false);
                                }
                                else
                                {
                                    Server.Transfer("Confirmation.aspx", false);
                                }
                                Server.Transfer("Confirmation.aspx", false);

                            }
                        }
                    }
                }
            }
        }

        protected void btnReset_Click1(object sender, EventArgs e)
        {

        }


	}
}

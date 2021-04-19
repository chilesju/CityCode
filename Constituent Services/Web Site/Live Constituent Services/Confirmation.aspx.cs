using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using Utilites;
using System.Web.Mail;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Constituent_Services
{
	
	public class Confirmation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnEmail;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.Label lblAddress;
		protected System.Web.UI.WebControls.Label lblIncidentNumber;
		protected System.Web.UI.WebControls.Label lblProblemType;
		protected System.Web.UI.WebControls.Label lblProblem;
		protected System.Web.UI.WebControls.Label lblEmail;
		protected System.Web.UI.WebControls.Label lblYourEmail;
		protected System.Web.UI.WebControls.Label lblPhone;
		protected System.Web.UI.WebControls.Label lblYourPhone;
		protected System.Web.UI.WebControls.Label lblLastName;
		protected System.Web.UI.WebControls.Label lblLname;
		protected System.Web.UI.WebControls.Label lblFirstName;
		protected System.Web.UI.WebControls.Label lblFname;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label Label3;
		private int incidentNumber;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.DropDownList councilDistList;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Button btnCouncilDist;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblIncidentNumber2Graffiti;
		protected System.Web.UI.WebControls.Label lblInformOnGraffiti;
		private Assignment assignment = new Assignment();
		private bool IsThisGraffiti;
        private Utilites.Incident _incident;
        private Utilites.Citizen _citizen;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Image1.Attributes.Add("onclick", "window.open('FindCouncilDistrict.aspx');");//,'toolbar=yes,location=no,scrollbars=yes,resizable=yes,width=550,height=550');");
			if((Convert.ToString(Session["Problem"])=="Graffiti"))
			{
				this.IsThisGraffiti=true;
			}

            this._incident = (Utilites.Incident)Session["Incident"];
            this._citizen = (Utilites.Citizen)Session["Citizen"];
			//link.Attributes.Add("onclick", "window.open('Chart.aspx?"+ _myButton2.Text+ "','Graph','toolbar=yes,location=no,scrollbars=yes,resizable=yes,width=550,height=550');");
			incidentNumber = Convert.ToInt32(Session["IncidentId"]);
            if (!IsPostBack)
			{


                DataSet councilDataSet = Utilites.StaticMethods.GetCouncilDistricts();
				councilDistList.DataSource= councilDataSet;
				councilDistList.DataTextField= "Council District";
				councilDistList.DataValueField= "Council District";
				councilDistList.DataBind();

                incidentNumber = this._incident.IncidentId;
				
				this.lblIncidentNumber.Text = incidentNumber.ToString();
				if(this.IsThisGraffiti==true)
				{
					this.lblIncidentNumber2Graffiti.Enabled=true;
					this.lblIncidentNumber2Graffiti.Visible=true;
					this.lblInformOnGraffiti.Enabled=true;
					this.lblInformOnGraffiti.Visible=true;

					int number = incidentNumber+1;
					this.lblIncidentNumber2Graffiti.Text= Convert.ToString(number);
				}
				
				this.lblDate.Text = Convert.ToString(System.DateTime.Now);
                this.lblAddress.Text = this._incident.Address;
				this.lblProblem.Text = Convert.ToString(Session["Problem"]);
				this.lblEmail.Text = this._citizen.Email;
				this.lblFirstName.Text = this._citizen.FirstName;
                this.lblLastName.Text = this._citizen.LastName;;
				this.lblPhone.Text = this._citizen.PhoneNumber;
				if (this.lblEmail.Text == "Anonymous" || this.lblEmail.Text=="")
				{
					this.btnEmail.Enabled = false;
					this.lblName.Text = "";
				}
				if (this.lblFirstName.Text == "Annoymous")
				{
					this.lblName.Text = Convert.ToString(Session["fname"]) + " ";
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



        protected void btnEmail_Click1(object sender, EventArgs e)
        {
            /*	if(lblEmail.Text=="")
            {
                lblMessage.Text="We were unable to send an email confirmation. You didn’t provide an email address.";
                lblMessage.ForeColor= System.Drawing.Color.Red;
            }
            else
            {    */
            try
            {

                string strTo = "jknox@topeka.org";//Convert.ToString(Session["email"]);
                string strFrom = "webmaster@topeka.org";
                string strSubject = "Burning Permit Notification";
                SmtpMail.SmtpServer = "mail.topeka.org";
                SmtpMail.Send(strFrom, strTo, strSubject,
                    "The Topeka Fire Department has received your request for an inspection. \n" +
                    "NOTE: THIS IS NOT THE ACUTAL PERMIT \n" +
                    "On the day you wish to burn, notify Topeka Fire Department at 785-368-9514 before and after burning. \n" +
                    "For all other issues or questions concerning this request please call 785-368-4000. \n" +
                    "If you are unable to sign the permit at the burning location, then you will need to pick up your permit at: \n" +
                    "Topeka Fire Academy \n" +
                    "324 SE Jefferson \n" +
                    "Topeka , KS 66607 \n\n" +
                    //"Permit Number: " + lblPermitNumber.Text+ "\n"+ "Issue Date: " +lblIssueDate.Text + "\n" + "Burn Address: " +lblBurningAddress.Text +
                    "\n\nNOTE: If you are going to pick up the permit you have TWO weeks after the issue date to pick up the permit.  If you fail to pick up the permit within these two weeks you must reapply for another permit.");

            }
            catch (Exception ex)
            {
                string test;
                test = ex.ToString();
            }
            //	}
        }

        protected void btnCouncilDist_Click1(object sender, EventArgs e)
        {
            string councilDist = this.councilDistList.SelectedValue;
            this._incident.InsertCouncilDist(councilDist);
            try
            {
                //if(this.IsThisGraffiti==true)
                //{
                //    int otherIncidentNumber = incidentNumber+1;
                //    Incident.InsertCouncilDist(councilDist,otherIncidentNumber);
                //}
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                string test2 = str;
            }
        }
	}
}

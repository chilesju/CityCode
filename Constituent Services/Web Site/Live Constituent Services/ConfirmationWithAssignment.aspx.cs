using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mail;
using System.Web.UI.HtmlControls;
using Utilites;

namespace Constituent_Services
{
	/// <summary>
	/// Summary description for ConfirmationWithAssignment.
	/// </summary>
	public class ConfirmationWithAssignment : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.Label lblAssignment;
		protected System.Web.UI.WebControls.Label Label3;
		private int incidentNumber;
		private int citizenId;
		private int problemTypeId;
		
		protected System.Web.UI.WebControls.Label lblAssignemntNumber;
		protected System.Web.UI.WebControls.Label lblProblemDisc;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button btnCouncilDist;
		protected System.Web.UI.WebControls.DropDownList councilDistList;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList departmentList1;
		protected System.Web.UI.WebControls.DropDownList divisionList;
		protected System.Web.UI.WebControls.Button btnAssignTo;
		protected System.Web.UI.WebControls.Label lblWichDepartment;
        private Utilites.Assignment assignment = new Utilites.Assignment();
        private Utilites.Incident _incident;
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			incidentNumber = Convert.ToInt32(Session["IncidentId"]);
			 citizenId = Convert.ToInt32(Session["citizenId"]);
			 problemTypeId = Convert.ToInt32(Session["problemTypeId"]);
			if (!IsPostBack)
			{


				System.Data.DataSet departmentSet = Utilites.Department.GetDeaprtments();
				departmentList1.DataSource= departmentSet;
				departmentList1.DataTextField= "Department";
				departmentList1.DataValueField= "DeptId";
				departmentList1.DataBind();
				departmentList1.Items.Insert(0, new ListItem("--Please Select--","0"));

				DataSet councilDataSet = Utilites.StaticMethods.GetCouncilDistricts();
				councilDistList.DataSource= councilDataSet;
				councilDistList.DataTextField= "Council District";
				councilDistList.DataValueField= "Council District";
				councilDistList.DataBind();

				// Put user code to initialize the page here
				//btnPrint.Attributes.Add("onclick", "window.print();");
				 

				this.lblIncidentNumber.Text = incidentNumber.ToString();
				this.lblDate.Text = Convert.ToString(System.DateTime.Now);
				this.lblAddress.Text = Convert.ToString(Session["Address"]);
				this.lblProblem.Text = Convert.ToString(Session["Problem"]);
				this.lblEmail.Text = Convert.ToString(Session["email"]);
				this.lblFirstName.Text = Convert.ToString(Session["fname"]);
				this.lblLastName.Text = Convert.ToString(Session["lname"]);
				this.lblPhone.Text = Convert.ToString(Session["phone"]);
				this.lblProblemDisc.Text = Convert.ToString(Session["cleanDesc"]);
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
			this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
			this.departmentList1.SelectedIndexChanged += new System.EventHandler(this.departmentList1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnEmail_Click(object sender, System.EventArgs e)
		{

		}

		private void departmentList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.departmentList1.SelectedValue=="0")

			{

				this.divisionList.Items.Clear();

				ListItem itm = new ListItem("--Select Department--","0");
				this.divisionList.Items.Add(itm);

			}

			else

			{

				int departmentId= Convert.ToInt32(this.departmentList1.SelectedValue);

				System.Data.DataSet divisionSet = Utilites.Division.GetDivision(departmentId);

				divisionList.DataSource =divisionSet;

				divisionList.DataTextField= "Division";

				divisionList.DataValueField= "DivisionId";

				divisionList.DataBind();

				this.divisionList.DataSource= Utilites.Division.GetDivision(departmentId);

				this.divisionList.DataBind();

				ListItem itm2 = new ListItem("--General--","0");

				this.divisionList.Items.Insert(0,itm2);

				if(this.divisionList.Items.Count==0)
				{
					ListItem itm = new ListItem("--Select Department--","0");
					this.divisionList.Items.Add(itm);
				}
			}

		}

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

        protected void btnAssignTo_Click1(object sender, EventArgs e)
        {
            assignment.DepartmentId = Convert.ToInt32(this.departmentList1.SelectedValue);
            assignment.DivisionId = Convert.ToInt32(this.divisionList.SelectedValue);
            assignment.Resolution = "";
            assignment.IncidentId = incidentNumber;
            string user = User.Identity.Name;
            int assignmentReturnValue = assignment.InsertAssignemntWithEmail(user, this.lblAddress.Text, citizenId, problemTypeId, this.lblProblemDisc.Text);

            if (assignmentReturnValue == -1)
            {
                this.lblAssignemntNumber.Text = "There was an error.";
            }
            else
            {
                this.btnAssignTo.Enabled = false;
                this.lblWichDepartment.Text = "You Call was assigned to: " + this.departmentList1.Items[this.departmentList1.SelectedIndex].Text + " " + this.divisionList.Items[this.divisionList.SelectedIndex].Text;

            }
            this.councilDistList.Enabled = true;
            this.btnCouncilDist.Enabled = true;
        }

        protected void btnCouncilDist_Click1(object sender, EventArgs e)
        {
            //string councilDist = this.councilDistList.SelectedValue;
            //Incident.InsertCouncilDist(councilDist);
        }
	}
}

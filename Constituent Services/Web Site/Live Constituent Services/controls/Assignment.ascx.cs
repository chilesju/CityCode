namespace Constituent_Services.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.UI;
    using System.Configuration;
	
	public class Assignment : System.Web.UI.UserControl 
	{
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.DropDownList departmentList1;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.DropDownList divisionList;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblAssignmentMessage;
		
		protected System.Web.UI.WebControls.Label lblDateResponded;
		protected System.Web.UI.WebControls.Button btnReassign;
		protected System.Web.UI.WebControls.DataGrid dgComments;
		protected System.Web.UI.WebControls.Button btnNewComment;
		protected System.Web.UI.WebControls.TextBox txtComment;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.Button btnAddCase;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.TextBox txtCaseNumber;
		protected System.Web.UI.WebControls.Label lblCodeCase;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
		private Utilites.Assignment _assignment= new Utilites.Assignment();
        private Utilites.Incident _incident;
		private Control contentControl;
        private int _IncidentId;

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{
			this.departmentList1.SelectedIndexChanged += new System.EventHandler(this.departmentList1_SelectedIndexChanged);
			this.dgComments.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgComments_CancelCommand);
			this.dgComments.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgComments_EditCommand);
			this.dgComments.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgComments_UpdateCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public void Initialize() 
		{
			BindData();
		}


		public Utilites.Assignment  IndividualAssignment
		{
			get { return _assignment;}
			set{ _assignment= value;}
		}
        public int IncidentId
        {
            get { return _IncidentId; }
            set { _IncidentId = value; }
        }

		private void BindData()
		{
            this._incident = (Utilites.Incident)Session["Incident"];
			System.Data.DataSet departmentSet = Utilites.Department.GetDeaprtments();
			departmentList1.DataSource= departmentSet;
			departmentList1.DataTextField= "Department";
			departmentList1.DataValueField= "DeptId";
			departmentList1.DataBind();
			departmentList1.Items.Insert(0, new ListItem("--Please Select--","0"));
			//this.txtProblemResolution1.Text= _assignment.Resolution;

			if(_assignment.AssignemtnId==0)
			{
				lblAssignmentMessage.Visible=true;
				divisionList.Items.Insert(0, new ListItem("--Select A Department--","0"));
			}
			else
			{
				
				departmentList1.Items.FindByValue(_assignment.DepartmentId.ToString()).Selected=true;//SelectedItem.Value=;
				BindDivision(_assignment.DepartmentId);

					ListItem itm2 = new ListItem("--General--","0");
					this.divisionList.Items.Insert(0,itm2);
					divisionList.Items.FindByValue(_assignment.DivisionId.ToString()).Selected=true;
		
			
				BindComments();

				//Code has the option of adding a case number to this Incident.
                if (_assignment.DivisionId == 3)
                {
                    this.txtCaseNumber.Visible = true;
                    this.lblCodeCase.Visible = true;
                    this.btnAddCase.Visible = true;
                    this.btnRemove.Visible = true;

                    string caseNumber = Utilites.CodeCase.SelectCodeCase(this._incident.IncidentId);
                    if (caseNumber == "None")
                    {
                        this.btnAddCase.Enabled = true;
                        this.btnRemove.Enabled = false;
                        this.txtCaseNumber.Enabled = true;

                    }
                    else
                    {
                        this.txtCaseNumber.Text = caseNumber;
                        this.btnRemove.Enabled = true;
                        this.btnAddCase.Enabled = false;
                        this.txtCaseNumber.Enabled = false;

                        if (System.Configuration.ConfigurationManager.AppSettings["includeCodeInfo"].ToString() == "true")
                        {
                            contentControl = Page.LoadControl("~/Controls/CodeNuisanceCase.ascx");
                            contentControl.ID = "SearchAssignment";
                            PlaceHolder1.Controls.Clear();
                            PlaceHolder1.Controls.Add(contentControl);
                        }
                    }
                }
				
			}
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
			lblErrorMessage.Visible=false;
		}

		private void BindDivision(int deptValue)
		{
			System.Data.DataSet divisionSet = Utilites.Division.GetDivision(deptValue);
			divisionList.DataSource =divisionSet;
			divisionList.DataTextField= "Division";
			divisionList.DataValueField= "DivisionId";
			divisionList.DataBind();
		}

		private void Page_Load(object sender, System.EventArgs e)
		{

            this._incident = (Utilites.Incident)Session["Incident"];
			if(Session["Status"].ToString()=="O")
			{
				this.btnReassign.Enabled=true;
			}
			else if(Session["Status"].ToString()=="C")
			{
				this.btnReassign.Enabled=false;
			}
		}

		private void BindComments()
		{

			this.dgComments.DataSource = Utilites.AssingmentComments.SelectAssignmentComments(_assignment.AssignemtnId);
			this.dgComments.DataBind();
		}

		private void dgComments_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgComments.EditItemIndex= e.Item.ItemIndex;
			DataGridItem item = dgComments.Items[e.Item.ItemIndex];
			BindComments();
			lblErrorMessage.Visible=false;
		}

		private void dgComments_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgComments.EditItemIndex= -1;
			BindComments();
			lblErrorMessage.Visible=false;
		}

		private void dgComments_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

            
			int commentId =  Convert.ToInt32(((Label)e.Item.Cells[0].Controls[1]).Text);
			string comment = ((TextBox)e.Item.Cells[1].Controls[1]).Text;
			if(comment.Length==0)
			{
				this.lblErrorMessage.Text= "You are trying to update the comment textbox and you do not have any text.";
			}
			else
			{
				if(Utilites.AssingmentComments.UpdateAssignmentComment(commentId,comment,Page.User.Identity.Name)==1)
				{
					dgComments.EditItemIndex=-1;
					BindComments();
					lblErrorMessage.Visible=false;
				}
			}
					
					
		}

		public string FormatString(object comment)
		{
			string smallcomment = comment.ToString();
			if(smallcomment.Length >200)
			{

				smallcomment = smallcomment.Substring(0,199);
				smallcomment += "...";
				return smallcomment;
			}
			else
				return smallcomment;
		}

		private void InsertComment(string comment)
		{
			string user = Page.User.Identity.Name;
			int assignmentId = _assignment.AssignemtnId;
			if(comment.Length==0)
			{
				this.lblErrorMessage.Text= "You are trying to add a comment and you have no text in the textbox.";
			}
			else
			{
				int returnvalue = Utilites.AssingmentComments.InsertAssignmentComment(assignmentId,comment,user);
				if(returnvalue==1)
				{
					BindComments();
					lblErrorMessage.Visible=false;
				}
			}
		}

        protected void btnNewComment_Click1(object sender, EventArgs e)
        {
            string comment = Utilites.CleanString.CleanInput(this.txtComment.Text);
            InsertComment(comment);
        }

        protected void btnReassign_Click1(object sender, EventArgs e)
        {
            try
            {
                int newDepartmentId = Convert.ToInt32(this.departmentList1.SelectedValue);
                int newDivisionId = Convert.ToInt32(this.divisionList.SelectedValue);
                if (_assignment.DepartmentId == newDepartmentId && _assignment.DivisionId == newDivisionId)
                {
                    this.lblErrorMessage.Text = "You are trying to assign the Incident to the same Department/Division";
                    this.lblErrorMessage.Visible = true;
                }
                else
                {
                    _assignment.DepartmentId = newDepartmentId;
                    _assignment.DivisionId = newDivisionId;
                    _assignment.IncidentId = this._incident.IncidentId;
                    _assignment.DateSent = System.DateTime.Now;

                    if (_assignment.AssignemtnId == 0)
                    {
                        _assignment.AssignemtnId = _assignment.InsertAssignemntLaterOn(Page.User.Identity.Name);
                        lblAssignmentMessage.Visible = false;
                    }
                    else
                    {
                        _assignment.ReassignAssignemnt(Page.User.Identity.Name);
                        lblErrorMessage.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {

                this.lblErrorMessage.Text = "Error Reassinging the incident: " + ex.ToString();
                this.lblErrorMessage.Visible = true;
            }
        }

        protected void btnRemove_Click1(object sender, EventArgs e)
        {
            try
            {
                string caseId = this.txtCaseNumber.Text;
                Utilites.CodeCase.RemoveCase(this._incident.IncidentId);

                this.btnRemove.Enabled = false;
                this.btnAddCase.Enabled = true;

                InsertComment("Case Number " + caseId + " has been removed from this Incident");
                this.txtCaseNumber.Enabled = true;
                this.txtCaseNumber.Text = "";
            }
            catch (Exception ex)
            {
                this.lblErrorMessage.Text = "There was an error trying to insert the case.";
            }
        }

        protected void btnAddCase_Click1(object sender, EventArgs e)
        {
            try
            {
                string caseId = this.txtCaseNumber.Text;
                Utilites.CodeCase.InputCase(this._incident.IncidentId, caseId, "O");

                this.btnAddCase.Enabled = false;
                this.btnRemove.Enabled = true;
                InsertComment("Case Number " + caseId + " has been assigned to this Incident");
                this.txtCaseNumber.Enabled = false;


            }
            catch (Exception ex)
            {
                this.lblErrorMessage.Text = "There was an error trying to insert the case.";
            }

        }
        
	}
}

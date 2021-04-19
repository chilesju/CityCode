namespace Constituent_Services.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for AdditionalUsers.
	/// </summary>
	public class AdditionalUsers : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblAdditionalUsers;
		protected System.Web.UI.WebControls.Button btnAssignToUser;
		protected System.Web.UI.WebControls.DropDownList AssignToAdditionalList;
		protected System.Web.UI.WebControls.Label lblAssignAdditionalUsers;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		private int _IncidentId;
		private int UserId;
		private Utilites.Assignment assignment = new Utilites.Assignment();

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAssignToUser.Click += new System.EventHandler(this.btnAssignToUser_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void BindData()
		{
	
			DataSet userDataSet = Utilites.User.GetUsersNameAndDept();
			this.AssignToAdditionalList.DataSource= userDataSet;
			this.AssignToAdditionalList.DataTextField= "Name";
			this.AssignToAdditionalList.DataValueField= "UserID";
			this.AssignToAdditionalList.DataBind();
			UserId = Convert.ToInt32(this.AssignToAdditionalList.SelectedValue);
			//assignment.InsertAdditionalUserToAssignemnt(userId, this._IncidentId);
			DataSet userSet = assignment.SelectAdditonalUsersToAssignments(this._IncidentId);
			this.DataGrid1.DataSource = userSet;
			this.DataGrid1.DataBind();
			
		}

		public int IncidentId 
		{
			get { return _IncidentId; }
			set { _IncidentId = value; }
		}
		public void Initialize()
		{
			BindData();	
		}

		private void btnAssignToUser_Click(object sender, System.EventArgs e)
		{
			UserId = Convert.ToInt32(this.AssignToAdditionalList.SelectedValue);
			assignment.InsertAdditionalUserToAssignemnt(UserId, this._IncidentId);
			DataSet userSet = assignment.SelectAdditonalUsersToAssignments(this._IncidentId);
			this.DataGrid1.DataSource = userSet;
			this.DataGrid1.DataBind();
		}
	}
}

namespace Constituent_Services.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;

	public class Email : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Button btnSendEmail;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblEmailHistory;
		protected System.Web.UI.WebControls.DataGrid emailHistoryList;
		protected System.Web.UI.WebControls.CheckBoxList emailList;
		private int _IncidentId;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
		}
		
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			
			InitializeComponent();
			base.OnInit(e);
		}
		
		
		private void InitializeComponent()
		{
			this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSendEmail_Click(object sender, System.EventArgs e)
		{
			string emailFrom = ConfigurationSettings.AppSettings[Global.CfgKeyEmailString];
			
			foreach(ListItem itm in emailList.Items)
			{
				if(itm.Selected==true)
				{
					string emailTo = Utilites.User.GetUsersEmail(Convert.ToInt32(itm.Value));
					Utilites.Email.SendEmail(emailTo,emailFrom);
					Utilites.Email.InsertEmailHistory(_IncidentId,emailTo);
					


				}

			}
			
			this.emailHistoryList.DataSource= Utilites.Email.GetEmailHistory(_IncidentId);
			this.emailHistoryList.DataBind();

		}
		private void BindData()
		{
		
			DataSet emailDataSet = Utilites.User.GetUsersNameAndDept();
			emailList.DataSource= emailDataSet;
			emailList.DataTextField= "Name";
			emailList.DataValueField= "UserID";
			emailList.DataBind();
			this.emailHistoryList.DataSource= Utilites.Email.GetEmailHistory(_IncidentId);
			
			this.emailHistoryList.DataBind();


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

	}
}

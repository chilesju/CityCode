namespace Constituent_Services.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using  Utilites;


	/// <summary>
	///		Summary description for SignIn.
	/// </summary>
	public class SignIn : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtUserName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Button btnSignin;
		protected System.Web.UI.WebControls.Button btnRegister;
		protected System.Web.UI.WebControls.Label Message;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		//protected Utilites.SecurityManager sm;

		private void Page_Load(object sender, System.EventArgs e)
		{
			 sm = new SecurityManager();
			 sm.AuthenticationProvider= "Authentication Provider";
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
			this.btnSignin.Click += new System.EventHandler(this.btnSignin_Click);
			this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSignin_Click(object sender, System.EventArgs e)
		{
			
			if(Page.IsValid)
			{
				
				bool login = sm.LoginUser(txtUserName.Text,txtPassword.Text, Session.SessionID);
				if( login == true )
				{	
					//HttpContext.Current.User
					Session["username"] = txtUserName.Text;
					Response.Redirect("~/MainScreen.aspx", false);

					return;
				}
				else
				{
					Message.Text= "Invalid Login";
					
				}
					
			}
		}

		private void btnRegister_Click(object sender, System.EventArgs e)
		{
			Message.Text= "To register please contact the City Council Office at 368-3710 for a user name and password.";
		
		}
	

	}
}

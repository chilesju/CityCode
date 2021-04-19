using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Database;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Database.Authentication;
using Microsoft.Practices.EnterpriseLibrary.Security.Database.Authentication.Configuration;

namespace User_Administration
{
	
	public class UserForm : System.Windows.Forms.Form
	{
		private Button btnCancel;
		private Button btnSave;

		private DbAuthenticationProviderData dbAuthenticationProvider;
		private ConfigurationContext context;
		private bool editMode;
		private GroupBox gbxAddUser;
		private IHashProvider hashProvider;
		private Label label1;
		private TextBox tbxUser;
		private ProfileInfo userProfile;
		private UserRoleManager userRoleMgr;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFirstName;
		private System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.Button btnChangePassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbxDepartment;
		private System.Windows.Forms.CheckBox chbxDisable;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtPhoneNumber;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cmbxDivision;
		private System.Windows.Forms.Button btnAddCatagory;

 

		private System.ComponentModel.Container components = null;

		public UserForm()
		{
			InitializeComponent();
		}
		public UserForm(DbAuthenticationProviderData dbAuthenticationProvider, ConfigurationContext context)
		{
			try
			{
				this.components = null;
				this.dbAuthenticationProvider = dbAuthenticationProvider;
				this.context=context;
				this.userProfile = new ProfileInfo(dbAuthenticationProvider.Database, context);
				this.editMode = false;
				this.InitializeComponent();
				GetDepartments();
				
				this.userRoleMgr = new UserRoleManager(dbAuthenticationProvider.Database, context);
				HashProviderFactory factory1 = new HashProviderFactory(context);
				this.hashProvider = factory1.CreateHashProvider(dbAuthenticationProvider.HashProvider);
				this.UpdateSaveButtonEnabled();
				this.Text="Create A New User";
				this.chbxDisable.Visible=false;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		public UserForm(DbAuthenticationProviderData dbAuthenticationProvider, ConfigurationContext context, string username) : this(dbAuthenticationProvider, context)
		{
		
			try
			{
				this.tbxUser.Text = username;
				this.tbxUser.Enabled = false;
				this.editMode = true;
				this.txtFirstName.Text = this.userProfile.GetFirstName(username);
				this.txtLastName.Text = this.userProfile.GetLastName(username);
				this.txtEmail.Text= this.userProfile.GetEmail(username);
				this.txtPhoneNumber.Text= this.userProfile.GetPhone(username);
				this.Text="Modify User";
				this.chbxDisable.Visible=true;
				this.cmbxDepartment.SelectedValue= this.userProfile.GetUserDepartment(username);
				BindDivision(Convert.ToInt32(this.cmbxDepartment.SelectedValue));
				
				this.cmbxDivision.SelectedValue= this.userProfile.GetUserDivision(username);
				tbxUser.Enabled=false;
				txtPassword.Enabled=false;
				if(this.userProfile.GetAccountEnabled(username)==2)
				{
					this.DisableControls();
					this.chbxDisable.Checked=true;
				
				}
				else
				{
					this.EnabledControls();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.gbxAddUser = new System.Windows.Forms.GroupBox();
			this.cmbxDivision = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtPhoneNumber = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.chbxDisable = new System.Windows.Forms.CheckBox();
			this.cmbxDepartment = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnChangePassword = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxUser = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAddCatagory = new System.Windows.Forms.Button();
			this.gbxAddUser.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "User Name";
			// 
			// gbxAddUser
			// 
			this.gbxAddUser.Controls.Add(this.btnAddCatagory);
			this.gbxAddUser.Controls.Add(this.cmbxDivision);
			this.gbxAddUser.Controls.Add(this.label8);
			this.gbxAddUser.Controls.Add(this.label7);
			this.gbxAddUser.Controls.Add(this.txtPhoneNumber);
			this.gbxAddUser.Controls.Add(this.label6);
			this.gbxAddUser.Controls.Add(this.txtEmail);
			this.gbxAddUser.Controls.Add(this.label3);
			this.gbxAddUser.Controls.Add(this.txtPassword);
			this.gbxAddUser.Controls.Add(this.chbxDisable);
			this.gbxAddUser.Controls.Add(this.cmbxDepartment);
			this.gbxAddUser.Controls.Add(this.label2);
			this.gbxAddUser.Controls.Add(this.btnChangePassword);
			this.gbxAddUser.Controls.Add(this.label5);
			this.gbxAddUser.Controls.Add(this.txtLastName);
			this.gbxAddUser.Controls.Add(this.txtFirstName);
			this.gbxAddUser.Controls.Add(this.label4);
			this.gbxAddUser.Controls.Add(this.tbxUser);
			this.gbxAddUser.Controls.Add(this.label1);
			this.gbxAddUser.Controls.Add(this.btnSave);
			this.gbxAddUser.Controls.Add(this.btnCancel);
			this.gbxAddUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbxAddUser.Location = new System.Drawing.Point(8, 8);
			this.gbxAddUser.Name = "gbxAddUser";
			this.gbxAddUser.Size = new System.Drawing.Size(296, 560);
			this.gbxAddUser.TabIndex = 2;
			this.gbxAddUser.TabStop = false;
			this.gbxAddUser.Text = "User";
			// 
			// cmbxDivision
			// 
			this.cmbxDivision.Location = new System.Drawing.Point(8, 376);
			this.cmbxDivision.Name = "cmbxDivision";
			this.cmbxDivision.Size = new System.Drawing.Size(216, 21);
			this.cmbxDivision.TabIndex = 6;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 344);
			this.label8.Name = "label8";
			this.label8.TabIndex = 20;
			this.label8.Text = "Division";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 464);
			this.label7.Name = "label7";
			this.label7.TabIndex = 19;
			this.label7.Text = "Phone Number";
			// 
			// txtPhoneNumber
			// 
			this.txtPhoneNumber.Location = new System.Drawing.Point(8, 488);
			this.txtPhoneNumber.Name = "txtPhoneNumber";
			this.txtPhoneNumber.Size = new System.Drawing.Size(208, 20);
			this.txtPhoneNumber.TabIndex = 8;
			this.txtPhoneNumber.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 408);
			this.label6.Name = "label6";
			this.label6.TabIndex = 17;
			this.label6.Text = "E-mail";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(8, 432);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(208, 20);
			this.txtEmail.TabIndex = 7;
			this.txtEmail.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 120);
			this.label3.Name = "label3";
			this.label3.TabIndex = 15;
			this.label3.Text = "Password";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(8, 144);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(208, 20);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Text = "";
			// 
			// chbxDisable
			// 
			this.chbxDisable.Location = new System.Drawing.Point(16, 24);
			this.chbxDisable.Name = "chbxDisable";
			this.chbxDisable.Size = new System.Drawing.Size(112, 24);
			this.chbxDisable.TabIndex = 12;
			this.chbxDisable.Text = "Disable Account";
			this.chbxDisable.CheckedChanged += new System.EventHandler(this.chbxDisable_CheckedChanged);
			// 
			// cmbxDepartment
			// 
			this.cmbxDepartment.Location = new System.Drawing.Point(8, 312);
			this.cmbxDepartment.Name = "cmbxDepartment";
			this.cmbxDepartment.Size = new System.Drawing.Size(216, 21);
			this.cmbxDepartment.TabIndex = 5;
			this.cmbxDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbxDepartment_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 288);
			this.label2.Name = "label2";
			this.label2.TabIndex = 11;
			this.label2.Text = "Department";
			// 
			// btnChangePassword
			// 
			this.btnChangePassword.Location = new System.Drawing.Point(136, 24);
			this.btnChangePassword.Name = "btnChangePassword";
			this.btnChangePassword.Size = new System.Drawing.Size(112, 23);
			this.btnChangePassword.TabIndex = 11;
			this.btnChangePassword.Text = "Change Password";
			this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 232);
			this.label5.Name = "label5";
			this.label5.TabIndex = 9;
			this.label5.Text = "Last Name";
			// 
			// txtLastName
			// 
			this.txtLastName.Location = new System.Drawing.Point(8, 256);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(208, 20);
			this.txtLastName.TabIndex = 4;
			this.txtLastName.Text = "";
			// 
			// txtFirstName
			// 
			this.txtFirstName.Location = new System.Drawing.Point(8, 200);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(208, 20);
			this.txtFirstName.TabIndex = 3;
			this.txtFirstName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 176);
			this.label4.Name = "label4";
			this.label4.TabIndex = 6;
			this.label4.Text = "First Name";
			// 
			// tbxUser
			// 
			this.tbxUser.Location = new System.Drawing.Point(8, 88);
			this.tbxUser.Name = "tbxUser";
			this.tbxUser.Size = new System.Drawing.Size(208, 20);
			this.tbxUser.TabIndex = 1;
			this.tbxUser.Text = "";
			this.tbxUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUser_KeyPress);
			this.tbxUser.TextChanged += new System.EventHandler(this.tbxUser_TextChanged);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(16, 520);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(104, 520);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAddCatagory
			// 
			this.btnAddCatagory.Location = new System.Drawing.Point(184, 520);
			this.btnAddCatagory.Name = "btnAddCatagory";
			this.btnAddCatagory.Size = new System.Drawing.Size(88, 23);
			this.btnAddCatagory.TabIndex = 21;
			this.btnAddCatagory.Text = "Add Catagory";
			this.btnAddCatagory.Click += new System.EventHandler(this.btnAddCatagory_Click);
			// 
			// UserForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 582);
			this.Controls.Add(this.gbxAddUser);
			this.Name = "UserForm";
			this.Text = "Edit User";
			this.Load += new System.EventHandler(this.UserForm_Load);
			this.gbxAddUser.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			byte[] buffer1 = this.hashProvider.CreateHash(Encoding.Unicode.GetBytes(this.txtPassword.Text));
			if (this.editMode)
			{
				this.userProfile.ChangeUserInfo(this.tbxUser.Text,this.txtFirstName.Text,this.txtLastName.Text,this.cmbxDepartment.SelectedValue,this.cmbxDivision.SelectedValue,this.txtEmail.Text,this.txtPhoneNumber.Text);
			}
			else
			{
				if (this.userRoleMgr.UserExists(this.tbxUser.Text))
				{
					MessageBox.Show(SR.UserAlreadyExists);
					return;
				}
				this.userProfile.CreateUser(this.tbxUser.Text,txtFirstName.Text,txtLastName.Text,cmbxDepartment.Text,this.cmbxDivision.Text, buffer1,1,this.txtEmail.Text,this.txtPhoneNumber.Text);
			}
			base.DialogResult = DialogResult.OK;
		}
		private void GetDepartments()
		{
			DataSet set1 = this.userProfile.GetDepartments();
			this.cmbxDepartment.BeginUpdate();
			this.cmbxDepartment.DisplayMember = "Department";
			this.cmbxDepartment.ValueMember = "id";
			this.cmbxDepartment.DataSource = set1.Tables[0];
			this.cmbxDepartment.EndUpdate();	
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			base.DialogResult = DialogResult.Abort;

		}

		private void tbxPassword1_TextChanged(object sender, System.EventArgs e)
		{
			this.UpdateSaveButtonEnabled();

		}

		private void tbxPassword2_TextChanged(object sender, System.EventArgs e)
		{
			this.UpdateSaveButtonEnabled();

		}

		private void tbxUser_TextChanged(object sender, System.EventArgs e)
		{
			this.UpdateSaveButtonEnabled();

		}

		private void tbxUser_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnSave.PerformClick();
			}

		}
		private void UpdateSaveButtonEnabled()
		{
			
		}

		private void UserForm_Load(object sender, System.EventArgs e)
		{
			this.tbxUser.Focus();

		}
		private void GetPersonalInfo(string username)
		{
			
		}

		private void btnChangePassword_Click(object sender, System.EventArgs e)
		{
			this.ShowPasswordialog(tbxUser.Text);
		}
		private void ShowPasswordialog()
		{
			this.ShowPasswordialog(string.Empty);
		}
		private void ShowCatagroydialog()
		{
			this.ShowCatagroydialog(string.Empty);
		}
		private void DisableControls()
		{
			this.txtFirstName.Enabled=false;
			this.txtLastName.Enabled=false;
			this.chbxDisable.Text="Enable Account";
			this.cmbxDepartment.Enabled=false;
			this.Text= "Account is Disabled";
			this.btnSave.Enabled=false;
			this.btnChangePassword.Enabled=false;

		}
		private void EnabledControls()
		{
			this.txtFirstName.Enabled=true;
			this.txtLastName.Enabled=true;
			this.chbxDisable.Text="Disable Account";
			this.cmbxDepartment.Enabled=true;
			this.Text= "Account is Active";
			this.btnChangePassword.Enabled=true;
			this.btnSave.Enabled=true;

		}

		private void chbxDisable_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chbxDisable.Checked==true)
			{
				this.userProfile.DisableAccount(this.tbxUser.Text,2);
				this.DisableControls();
			}
			else
			{
				this.userProfile.DisableAccount(this.tbxUser.Text,1);
				this.EnabledControls();
			}
		}
		
		private void ShowPasswordialog(string username)
		{
			 ChangePasswordForm form1;
			if (username.Length > 0)
			{
				form1 = new ChangePasswordForm(this.dbAuthenticationProvider, this.context, username);
			}
			else
			{
				form1 = new ChangePasswordForm(this.dbAuthenticationProvider, this.context);
			}
			if (form1.ShowDialog(this) == DialogResult.OK)
			{
				
			}
		}

		private void ShowCatagroydialog(string username)
		{
			CatagoryForm form1;
			if (username.Length > 0)
			{
				form1 = new CatagoryForm(this.dbAuthenticationProvider, this.context, username);
			}
			else
			{
				form1 = new CatagoryForm(this.dbAuthenticationProvider, this.context);
			}
			if (form1.ShowDialog(this) == DialogResult.OK)
			{
				
			}
		}

		private void BindDivision(int deptValue)
		{
			DataSet set1 = this.userProfile.GetDivisions(deptValue);
			this.cmbxDivision.BeginUpdate();
			this.cmbxDivision.DisplayMember = "Division";
			this.cmbxDivision.ValueMember = "id";
			
			DataRow newRow;
			newRow = set1.Tables[0].NewRow();
			newRow[0]= "--None--";
			newRow[1]= 0;

			set1.Tables[0].Rows.Add(newRow);
			this.cmbxDivision.DataSource = set1.Tables[0];
	
			this.cmbxDivision.EndUpdate();	
			
			
		}

		private void cmbxDepartment_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindDivision(Convert.ToInt32(this.cmbxDepartment.SelectedValue));
		}

		private void btnAddCatagory_Click(object sender, System.EventArgs e)
		{
			this.ShowCatagroydialog(tbxUser.Text);
		}



	}
}

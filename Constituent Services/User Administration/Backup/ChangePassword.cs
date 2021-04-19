using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Database;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Database.Authentication;
using Microsoft.Practices.EnterpriseLibrary.Security.Database.Authentication.Configuration;

namespace User_Administration
{
	
	public class ChangePasswordForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbxPassword2;
		private System.Windows.Forms.TextBox tbxPassword1;
		private System.Windows.Forms.TextBox tbxUser;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;

		private DbAuthenticationProviderData dbAuthenticationProvider;
		private bool editMode;
		private IHashProvider hashProvider;
		private UserRoleManager userRoleMgr;

	
		private System.ComponentModel.Container components = null;

		public ChangePasswordForm(DbAuthenticationProviderData dbAuthenticationProvider, ConfigurationContext context)
		{
			this.components = null;
			this.dbAuthenticationProvider = dbAuthenticationProvider;
			this.InitializeComponent();
			this.userRoleMgr = new UserRoleManager(dbAuthenticationProvider.Database, context);
			HashProviderFactory factory1 = new HashProviderFactory(context);
			this.hashProvider = factory1.CreateHashProvider(dbAuthenticationProvider.HashProvider);
			this.UpdateSaveButtonEnabled();
		}
		public ChangePasswordForm(DbAuthenticationProviderData dbAuthenticationProvider, ConfigurationContext context, string username) : this(dbAuthenticationProvider, context)
		{
			this.tbxUser.Text = username;
			this.tbxUser.Enabled = false;
			this.editMode = true;
			//this.label3.Text = SR.NewPasswordLabel;
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
		
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbxPassword2 = new System.Windows.Forms.TextBox();
			this.tbxPassword1 = new System.Windows.Forms.TextBox();
			this.tbxUser = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnSave);
			this.groupBox1.Controls.Add(this.btnCancel);
			this.groupBox1.Controls.Add(this.tbxPassword2);
			this.groupBox1.Controls.Add(this.tbxPassword1);
			this.groupBox1.Controls.Add(this.tbxUser);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 280);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Change Password";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(48, 240);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(136, 240);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tbxPassword2
			// 
			this.tbxPassword2.Location = new System.Drawing.Point(24, 200);
			this.tbxPassword2.Name = "tbxPassword2";
			this.tbxPassword2.PasswordChar = '*';
			this.tbxPassword2.Size = new System.Drawing.Size(208, 20);
			this.tbxPassword2.TabIndex = 2;
			this.tbxPassword2.Text = "";
			this.tbxPassword2.TextChanged += new System.EventHandler(this.tbxPassword2_TextChanged);
			// 
			// tbxPassword1
			// 
			this.tbxPassword1.Location = new System.Drawing.Point(24, 136);
			this.tbxPassword1.Name = "tbxPassword1";
			this.tbxPassword1.PasswordChar = '*';
			this.tbxPassword1.Size = new System.Drawing.Size(208, 20);
			this.tbxPassword1.TabIndex = 1;
			this.tbxPassword1.Text = "";
			this.tbxPassword1.TextChanged += new System.EventHandler(this.tbxPassword1_TextChanged);
			// 
			// tbxUser
			// 
			this.tbxUser.Location = new System.Drawing.Point(24, 72);
			this.tbxUser.Name = "tbxUser";
			this.tbxUser.Size = new System.Drawing.Size(208, 20);
			this.tbxUser.TabIndex = 8;
			this.tbxUser.Text = "";
			this.tbxUser.TextChanged += new System.EventHandler(this.tbxUser_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "User Name";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(192, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "New Password";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(200, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Verify Password";
			// 
			// ChangePasswordForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 310);
			this.Controls.Add(this.groupBox1);
			this.Name = "ChangePasswordForm";
			this.Text = "Change Password";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (this.tbxPassword1.Text != this.tbxPassword2.Text)
			{
				MessageBox.Show(SR.PasswordsMustMatch);
			}
			else
			{
				byte[] buffer1 = this.hashProvider.CreateHash(Encoding.Unicode.GetBytes(this.tbxPassword1.Text));
				if (this.editMode)
				{
					this.userRoleMgr.ChangeUserPassword(this.tbxUser.Text, buffer1);
				}
				else
				{
					if (this.userRoleMgr.UserExists(this.tbxUser.Text))
					{
						MessageBox.Show(SR.UserAlreadyExists);
						return;
					}
					this.userRoleMgr.CreateUser(this.tbxUser.Text, buffer1);
				}
				base.DialogResult = DialogResult.OK;
			}

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
		private void UpdateSaveButtonEnabled()
		{
			this.btnSave.Enabled = ((this.tbxUser.Text.Trim().Length > 0) && (this.tbxPassword1.Text.Trim().Length > 0)) && (this.tbxPassword2.Text.Trim().Length > 0);
		}
 

	}
}

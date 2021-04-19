using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Database;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Database.Authentication;
using Microsoft.Practices.EnterpriseLibrary.Security.Database.Authentication.Configuration;
using System.Resources;

namespace User_Administration
{
	
	public class RoleForm : System.Windows.Forms.Form
	{

		// Fields
		private Button btnCancel;
		private Button btnSave;
		private Container components;
		private DbAuthenticationProviderData dbAuthenticationproviderData;
		private bool editMode;
		private GroupBox gbxAddUser;
		private string originalRoleName;
		private TextBox tbxRole;
		private UserRoleManager userRoleMgr;

		//private System.ComponentModel.Container components = null;
	


		public RoleForm(DbAuthenticationProviderData dbAuthenticationProviderData, ConfigurationContext context)
		{
			this.components = null;
			this.dbAuthenticationproviderData = dbAuthenticationProviderData;
			this.InitializeComponent();
			this.userRoleMgr = new UserRoleManager(dbAuthenticationProviderData.Database, context);
			this.UpdateSaveButtonEnabled();
		}
		public RoleForm(DbAuthenticationProviderData dbAuthenticationProviderData, ConfigurationContext context, string role) : this(dbAuthenticationProviderData, context)
		{
			this.tbxRole.Text = role;
			this.originalRoleName = role;
			this.editMode = true;
			this.UpdateSaveButtonEnabled();
	
		}
 

		protected override void Dispose(bool disposing)
		{
			if (disposing && (this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
 


		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.gbxAddUser = new System.Windows.Forms.GroupBox();
			this.tbxRole = new System.Windows.Forms.TextBox();
			this.gbxAddUser.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(120, 88);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(208, 88);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// gbxAddUser
			// 
			this.gbxAddUser.Controls.Add(this.tbxRole);
			this.gbxAddUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbxAddUser.ForeColor = System.Drawing.Color.Blue;
			this.gbxAddUser.Location = new System.Drawing.Point(16, 16);
			this.gbxAddUser.Name = "gbxAddUser";
			this.gbxAddUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.gbxAddUser.Size = new System.Drawing.Size(272, 64);
			this.gbxAddUser.TabIndex = 0;
			this.gbxAddUser.TabStop = false;
			this.gbxAddUser.Text = "Role Name";
			// 
			// tbxRole
			// 
			this.tbxRole.Location = new System.Drawing.Point(16, 24);
			this.tbxRole.Name = "tbxRole";
			this.tbxRole.Size = new System.Drawing.Size(240, 20);
			this.tbxRole.TabIndex = 0;
			this.tbxRole.Text = "";
			this.tbxRole.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxRole_KeyPress);
			this.tbxRole.TextChanged += new System.EventHandler(this.tbxRole_TextChanged);
			// 
			// RoleForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 126);
			this.Controls.Add(this.gbxAddUser);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "RoleForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "Edit Role";
			this.Load += new System.EventHandler(this.RoleForm_Load);
			this.gbxAddUser.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (this.userRoleMgr.GetRoleIdFromRoleName(this.tbxRole.Text) > -1)
			{
				MessageBox.Show(SR.RoleAlreadyExists, SR.RoleAlreadyExists, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (this.editMode && (this.tbxRole.Text != this.originalRoleName))
				{
					this.userRoleMgr.RenameRole(this.originalRoleName, this.tbxRole.Text.Trim());
				}
				else
				{
					this.userRoleMgr.CreateRole(this.tbxRole.Text.Trim());
				}
				base.DialogResult = DialogResult.OK;
			}

		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
	
		}

		private void tbxRole_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnSave.PerformClick();
			}

		}

		private void RoleForm_Load(object sender, System.EventArgs e)
		{
			this.tbxRole.Focus();

		}
	
		public string RoleName
		{
			get
			{
				return this.tbxRole.Text;
			}
		}
		private void UpdateSaveButtonEnabled()
		{
			if (this.editMode)
			{
				this.btnSave.Enabled = (this.tbxRole.Text.Trim().Length > 0) && (this.tbxRole.Text != this.originalRoleName);
			}
			else
			{
				this.btnSave.Enabled = this.tbxRole.Text.Trim().Length > 0;
			}
		}

		private void tbxRole_TextChanged(object sender, System.EventArgs e)
		{
			this.UpdateSaveButtonEnabled();

		}
 

 

	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Database;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Database.Authentication;
using Microsoft.Practices.EnterpriseLibrary.Security.Database.Authentication.Configuration;



namespace User_Administration
{
	
	public class MainScreen : System.Windows.Forms.Form
	{

		private UserRoleManager userRoleMgr;
		private static readonly string paragraphSeparator;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button selectDbButton;
		private System.Windows.Forms.Button btnAddNewUser;
		private System.Windows.Forms.Button btnAddNewRole;
		private System.Windows.Forms.Button btnDelRole;
		private System.Windows.Forms.Button btnEditRole;
		private System.Windows.Forms.Button btnDelUser;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.ListBox lbxUsers;
		private System.Windows.Forms.Button editUserButton;
		private System.Windows.Forms.ComboBox cbxDbInstances;
		private System.Windows.Forms.Label lblRoles;
		private System.Windows.Forms.Label lblRoleUsers;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnQuit;
		private System.Windows.Forms.GroupBox databasesGroupBox;
		private System.Windows.Forms.GroupBox gbxUserRoles;
		private System.Windows.Forms.Label lblUsers;
		private System.Windows.Forms.ComboBox cbxRoles;
		private System.Windows.Forms.ListBox lbxRoleUsers;
		private ConfigurationContext configurationContext= new ConfigurationContext();
		private DbAuthenticationProviderData dbAuthenticationproviderData = new DbAuthenticationProviderData();
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;

					
 


		
		private System.ComponentModel.Container components = null;

		public MainScreen()
		{
			
			InitializeComponent();

		
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
		[STAThread]
		private static void Main()
		{
			Application.Run(new MainScreen());
		}
 


		#region Windows Form Designer generated code
		
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.databasesGroupBox = new System.Windows.Forms.GroupBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.cbxDbInstances = new System.Windows.Forms.ComboBox();
			this.selectDbButton = new System.Windows.Forms.Button();
			this.gbxUserRoles = new System.Windows.Forms.GroupBox();
			this.lblRoleUsers = new System.Windows.Forms.Label();
			this.lblRoles = new System.Windows.Forms.Label();
			this.cbxRoles = new System.Windows.Forms.ComboBox();
			this.lbxUsers = new System.Windows.Forms.ListBox();
			this.lblUsers = new System.Windows.Forms.Label();
			this.lbxRoleUsers = new System.Windows.Forms.ListBox();
			this.editUserButton = new System.Windows.Forms.Button();
			this.btnDelUser = new System.Windows.Forms.Button();
			this.btnAddNewUser = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAddNewRole = new System.Windows.Forms.Button();
			this.btnDelRole = new System.Windows.Forms.Button();
			this.btnEditRole = new System.Windows.Forms.Button();
			this.btnQuit = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
			this.databasesGroupBox.SuspendLayout();
			this.gbxUserRoles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			// 
			// databasesGroupBox
			// 
			this.databasesGroupBox.Controls.Add(this.btnConnect);
			this.databasesGroupBox.Controls.Add(this.cbxDbInstances);
			this.databasesGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.databasesGroupBox.Location = new System.Drawing.Point(16, 8);
			this.databasesGroupBox.Name = "databasesGroupBox";
			this.databasesGroupBox.Size = new System.Drawing.Size(640, 64);
			this.databasesGroupBox.TabIndex = 3;
			this.databasesGroupBox.TabStop = false;
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(448, 24);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.TabIndex = 2;
			this.btnConnect.Text = "Connect";
			this.btnConnect.Click += new System.EventHandler(this.selectDbButton_Click);
			// 
			// cbxDbInstances
			// 
			this.cbxDbInstances.Cursor = System.Windows.Forms.Cursors.Default;
			this.cbxDbInstances.DisplayMember = "Name";
			this.cbxDbInstances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxDbInstances.Location = new System.Drawing.Point(16, 24);
			this.cbxDbInstances.Name = "cbxDbInstances";
			this.cbxDbInstances.Size = new System.Drawing.Size(400, 21);
			this.cbxDbInstances.TabIndex = 1;
			this.cbxDbInstances.ValueMember = "Name";
			// 
			// selectDbButton
			// 
			this.selectDbButton.Cursor = System.Windows.Forms.Cursors.Default;
			this.selectDbButton.Location = new System.Drawing.Point(552, 24);
			this.selectDbButton.Name = "selectDbButton";
			this.selectDbButton.TabIndex = 0;
			this.selectDbButton.Text = "Connect";
			// 
			// gbxUserRoles
			// 
			this.gbxUserRoles.Controls.Add(this.lblRoleUsers);
			this.gbxUserRoles.Controls.Add(this.lblRoles);
			this.gbxUserRoles.Controls.Add(this.cbxRoles);
			this.gbxUserRoles.Controls.Add(this.lbxUsers);
			this.gbxUserRoles.Controls.Add(this.lblUsers);
			this.gbxUserRoles.Controls.Add(this.lbxRoleUsers);
			this.gbxUserRoles.Controls.Add(this.editUserButton);
			this.gbxUserRoles.Controls.Add(this.btnDelUser);
			this.gbxUserRoles.Controls.Add(this.btnAddNewUser);
			this.gbxUserRoles.Controls.Add(this.btnAdd);
			this.gbxUserRoles.Controls.Add(this.btnRemove);
			this.gbxUserRoles.Controls.Add(this.btnAddNewRole);
			this.gbxUserRoles.Controls.Add(this.btnDelRole);
			this.gbxUserRoles.Controls.Add(this.btnEditRole);
			this.gbxUserRoles.Enabled = false;
			this.gbxUserRoles.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbxUserRoles.Location = new System.Drawing.Point(16, 80);
			this.gbxUserRoles.Name = "gbxUserRoles";
			this.gbxUserRoles.Size = new System.Drawing.Size(648, 280);
			this.gbxUserRoles.TabIndex = 5;
			this.gbxUserRoles.TabStop = false;
			// 
			// lblRoleUsers
			// 
			this.lblRoleUsers.Location = new System.Drawing.Point(16, 96);
			this.lblRoleUsers.Name = "lblRoleUsers";
			this.lblRoleUsers.Size = new System.Drawing.Size(240, 23);
			this.lblRoleUsers.TabIndex = 8;
			this.lblRoleUsers.Text = "Users In Role";
			// 
			// lblRoles
			// 
			this.lblRoles.Location = new System.Drawing.Point(16, 24);
			this.lblRoles.Name = "lblRoles";
			this.lblRoles.TabIndex = 10;
			this.lblRoles.Text = "Roles";
			// 
			// cbxRoles
			// 
			this.cbxRoles.Cursor = System.Windows.Forms.Cursors.Default;
			this.cbxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxRoles.Location = new System.Drawing.Point(16, 56);
			this.cbxRoles.Name = "cbxRoles";
			this.cbxRoles.Size = new System.Drawing.Size(232, 21);
			this.cbxRoles.TabIndex = 7;
			this.cbxRoles.SelectedIndexChanged += new System.EventHandler(this.cbxRoles_SelectedIndexChanged);
			// 
			// lbxUsers
			// 
			this.lbxUsers.Location = new System.Drawing.Point(376, 128);
			this.lbxUsers.Name = "lbxUsers";
			this.lbxUsers.Size = new System.Drawing.Size(248, 95);
			this.lbxUsers.TabIndex = 11;
			this.lbxUsers.DoubleClick += new System.EventHandler(this.editUserButton_Click);
			this.lbxUsers.SelectedIndexChanged += new System.EventHandler(this.lbxUsers_SelectedIndexChanged);
			// 
			// lblUsers
			// 
			this.lblUsers.Location = new System.Drawing.Point(384, 104);
			this.lblUsers.Name = "lblUsers";
			this.lblUsers.Size = new System.Drawing.Size(240, 23);
			this.lblUsers.TabIndex = 12;
			this.lblUsers.Text = "All Users";
			// 
			// lbxRoleUsers
			// 
			this.lbxRoleUsers.Location = new System.Drawing.Point(16, 128);
			this.lbxRoleUsers.Name = "lbxRoleUsers";
			this.lbxRoleUsers.Size = new System.Drawing.Size(248, 95);
			this.lbxRoleUsers.TabIndex = 9;
			this.lbxRoleUsers.DoubleClick += new System.EventHandler(this.btnEditRole_Click);
			this.lbxRoleUsers.SelectedIndexChanged += new System.EventHandler(this.lbxRoleUsers_SelectedIndexChanged);
			// 
			// editUserButton
			// 
			this.editUserButton.Cursor = System.Windows.Forms.Cursors.Default;
			this.editUserButton.Location = new System.Drawing.Point(552, 232);
			this.editUserButton.Name = "editUserButton";
			this.editUserButton.TabIndex = 13;
			this.editUserButton.Text = "Edit User";
			this.editUserButton.Click += new System.EventHandler(this.editUserButton_Click);
			// 
			// btnDelUser
			// 
			this.btnDelUser.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnDelUser.Location = new System.Drawing.Point(464, 232);
			this.btnDelUser.Name = "btnDelUser";
			this.btnDelUser.TabIndex = 3;
			this.btnDelUser.Text = "Delete User";
			this.btnDelUser.Click += new System.EventHandler(this.btnDelUser_Click);
			// 
			// btnAddNewUser
			// 
			this.btnAddNewUser.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnAddNewUser.Location = new System.Drawing.Point(376, 232);
			this.btnAddNewUser.Name = "btnAddNewUser";
			this.btnAddNewUser.TabIndex = 4;
			this.btnAddNewUser.Text = "New  User";
			this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnAdd.Location = new System.Drawing.Point(288, 136);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(64, 23);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "<<<";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnRemove.Location = new System.Drawing.Point(288, 168);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(64, 23);
			this.btnRemove.TabIndex = 1;
			this.btnRemove.Text = ">>>";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAddNewRole
			// 
			this.btnAddNewRole.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnAddNewRole.Location = new System.Drawing.Point(16, 232);
			this.btnAddNewRole.Name = "btnAddNewRole";
			this.btnAddNewRole.TabIndex = 5;
			this.btnAddNewRole.Text = "New Role";
			this.btnAddNewRole.Click += new System.EventHandler(this.btnAddNewRole_Click);
			// 
			// btnDelRole
			// 
			this.btnDelRole.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnDelRole.Location = new System.Drawing.Point(96, 232);
			this.btnDelRole.Name = "btnDelRole";
			this.btnDelRole.TabIndex = 6;
			this.btnDelRole.Text = "Delete Role";
			this.btnDelRole.Click += new System.EventHandler(this.btnDelRole_Click);
			// 
			// btnEditRole
			// 
			this.btnEditRole.Location = new System.Drawing.Point(176, 232);
			this.btnEditRole.Name = "btnEditRole";
			this.btnEditRole.TabIndex = 0;
			this.btnEditRole.Text = "Edit Role";
			this.btnEditRole.Click += new System.EventHandler(this.btnEditRole_Click);
			// 
			// btnQuit
			// 
			this.btnQuit.Location = new System.Drawing.Point(576, 368);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.TabIndex = 6;
			this.btnQuit.Text = "Close";
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 416);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2,
																						  this.statusBarPanel3,
																						  this.statusBarPanel4});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(692, 22);
			this.statusBar1.TabIndex = 7;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Width = 120;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Width = 175;
			// 
			// statusBarPanel3
			// 
			this.statusBarPanel3.Width = 210;
			// 
			// statusBarPanel4
			// 
			this.statusBarPanel4.Width = 175;
			// 
			// MainScreen
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(692, 438);
			this.Controls.Add(this.gbxUserRoles);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.btnQuit);
			this.Controls.Add(this.databasesGroupBox);
			this.Name = "MainScreen";
			this.Text = "User Administration";
			this.Load += new System.EventHandler(this.MainScreen_Load);
			this.databasesGroupBox.ResumeLayout(false);
			this.gbxUserRoles.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void selectDbButton_Click(object sender, System.EventArgs e)
		{
			
			this.ConnectToDatabase();

		}

		private void btnAddNewRole_Click(object sender, System.EventArgs e)
		{
			this.ShowRoleFormDialog();
			this.UpdateUserToRoleButtonsEnabled();

		}

		private void btnEditRole_Click(object sender, System.EventArgs e)
		{
			this.ShowRoleFormDialog(this.cbxRoles.Text);

		}

		private void btnDelRole_Click(object sender, System.EventArgs e)
		{
			if (this.cbxRoles.SelectedIndex < 0)
			{
				MessageBox.Show(SR.MustSelectRoleToDelete);
			}
			else
			{
				MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
				if (MessageBox.Show(this, SR.DeleteRoleConfirmation, SR.DeleteRoleConfirmation, buttons1) == DialogResult.Yes)
				{
					string text1 = ((DataRowView) this.cbxRoles.SelectedItem)["RoleName"].ToString();
					this.userRoleMgr.DeleteRole(text1);
					this.GetAllRoles();
					this.GetAllUsers();
				}
				this.GetUsersInRole(this.cbxRoles.Text);
				this.UpdateEditRoleButtonEnabled();
				this.UpdateUserToRoleButtonsEnabled();
			}

		}

		private void btnAddNewUser_Click(object sender, System.EventArgs e)
		{
			this.ShowUserFormDialog();

		}

		private void editUserButton_Click(object sender, System.EventArgs e)
		{
			this.ShowUserFormDialog(this.lbxUsers.Text);

		}

		private void btnDelUser_Click(object sender, System.EventArgs e)
		{
			if (this.lbxUsers.SelectedIndex < 0)
			{
				MessageBox.Show(SR.MustSelectUserToDelete);
			}
			else
			{
				string text1 = SR.DeleteUserConfirmation;
				string text2 = SR.DeleteUserConfirmationCaption;
				MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
				if (MessageBox.Show(this, text1, text2, buttons1) != DialogResult.No)
				{
					string text3 = ((DataRowView) this.lbxUsers.SelectedItem)["UserName"].ToString();
					this.userRoleMgr.DeleteUser(text3);
					this.GetAllUsers();
					this.GetUsersInRole(this.cbxRoles.Text);
					this.UpdateEditUserButtonEnabled();
					this.UpdateUserToRoleButtonsEnabled();
				}
			}

		}

		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.AddUserRole();
			this.btnAdd.Enabled=false;

		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			this.RemoveUserRole();
			this.btnRemove.Enabled=true;
			this.GetAllUsers();

		}
		private void AddUserRole()
		{
			string text1 = ((DataRowView) this.lbxUsers.SelectedItem)["UserName"].ToString();
			this.userRoleMgr.CreateUserRole(text1, this.cbxRoles.Text);
			this.GetUsersInRole(this.cbxRoles.Text);
			this.UpdateUserToRoleButtonsEnabled();
		}

		private void cbxDbInstances_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.UpdateConnectButtonEnabled();

		}

		private void cbxRoles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.GetUsersInRole(this.cbxRoles.Text);
			this.UpdateEditRoleButtonEnabled();
			this.UpdateUserToRoleButtonsEnabled();
			this.GetAllUsers();

		}
		private void ConnectToDatabase()
		{
			this.gbxUserRoles.Enabled = false;
			string text1 = this.DbAuthenticationProvider.Database;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.userRoleMgr = new UserRoleManager(text1, ConfigurationManager.GetCurrentContext());
				this.GetAllUsers();
				this.GetAllRoles();
				this.gbxUserRoles.Enabled = true;
			}
			catch (Exception exception1)
			{
				string text2 = SR.NoDatabaseExceptionMessage(MainScreen.paragraphSeparator, MainScreen.paragraphSeparator, MainScreen.paragraphSeparator, exception1.Message);
				MessageBox.Show(text2, SR.DatabaseConnectionError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		private void GetAllRoles()
		{
			DataSet set1 = this.userRoleMgr.GetAllRoles();
			this.cbxRoles.BeginUpdate();
			this.cbxRoles.DisplayMember = "RoleName";
			this.cbxRoles.ValueMember = "RoleID";
			this.cbxRoles.DataSource = set1.Tables[0];
			this.cbxRoles.EndUpdate();
			
		}
		private void GetAllUsers()
		{
			DataSet set1 = this.userRoleMgr.GetAllUsers();
			set1.Tables[0].DefaultView.Sort= "UserName";
			this.lbxUsers.BeginUpdate();
			this.lbxUsers.DisplayMember = "UserName";
			this.lbxUsers.ValueMember = "UserID";
			this.lbxUsers.DataSource = set1.Tables[0];
			this.lbxUsers.EndUpdate();
		}

		private void GetUsersInRole(string role)
		{
			if (role.Trim().Length > 0)
			{
				DataSet set1 = this.userRoleMgr.GetRoleUsers(role.Trim());
				set1.Tables[0].DefaultView.Sort= "UserName";
				this.lbxRoleUsers.BeginUpdate();
				this.lbxRoleUsers.DisplayMember = "UserName";
				this.lbxRoleUsers.ValueMember = "UserID";
				this.lbxRoleUsers.DataSource = set1.Tables[0];
				this.lbxRoleUsers.EndUpdate();
				
			}
			else
			{
				this.lbxRoleUsers.DataSource = null;
			}
			this.lblRoleUsers.Text = SR.UsersInRole(role);
		}

		private void lbxRoleUsers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//this.UpdateEditUserButtonEnabled();
			//this.UpdateUserToRoleButtonsEnabled();

		}


		private void RemoveUserRole()
		{
			string text1 = ((DataRowView) this.lbxRoleUsers.SelectedItem)["UserName"].ToString();
			this.userRoleMgr.DeleteUserRole(text1, this.cbxRoles.Text);
			this.GetUsersInRole(this.cbxRoles.Text);
			this.UpdateUserToRoleButtonsEnabled();
		}
		private void ShowRoleFormDialog()
		{
			this.ShowRoleFormDialog(string.Empty);
		}
		private void ShowRoleFormDialog(string role)
		{
			RoleForm form1;
			if (role.Length > 0)
			{
				form1 = new RoleForm(this.DbAuthenticationProvider, this.configurationContext, role);
			}
			else
			{
				form1 = new RoleForm(this.DbAuthenticationProvider, this.configurationContext);
			}
			if (form1.ShowDialog(this) == DialogResult.OK)
			{
				this.GetAllRoles();
				this.cbxRoles.SelectedIndex = this.cbxRoles.FindStringExact(form1.RoleName);
				this.GetUsersInRole(form1.RoleName);
			}
		}
		private void ShowUserFormDialog()
		{
			this.ShowUserFormDialog(string.Empty);
		}
		private void ShowUserFormDialog(string username)
		{
			UserForm form1;
			if (username.Length > 0)
			{
				form1 = new UserForm(this.DbAuthenticationProvider, this.configurationContext, username);
				
			}
			else
			{
				form1 = new UserForm(this.DbAuthenticationProvider, this.configurationContext);
			}
			if (form1.ShowDialog(this) == DialogResult.OK)
			{
				this.GetAllUsers();
			}
		}
		private void UpdateConnectButtonEnabled()
		{
			this.selectDbButton.Enabled = this.cbxDbInstances.SelectedItem != null;
		}
 
		private void UpdateEditRoleButtonEnabled()
		{
			this.btnEditRole.Enabled = this.cbxRoles.SelectedItem != null;
		}
 
		private void UpdateEditUserButtonEnabled()
		{
			this.editUserButton.Enabled = this.lbxUsers.SelectedIndex >= 0;
		}
 
		private void UpdateUserToRoleButtonsEnabled()
		{
			this.btnAdd.Enabled = ((this.lbxUsers.SelectedItem != null) && (this.cbxRoles.SelectedItem != null)) && (this.lbxRoleUsers.FindStringExact(this.lbxUsers.SelectedValue.ToString()) == -1);
			this.btnRemove.Enabled = this.lbxRoleUsers.SelectedItem != null;
		}

		private void MainScreen_Load(object sender, System.EventArgs e)
		{
			SecuritySettings settings1 = (SecuritySettings) this.configurationContext.GetConfiguration("securityConfiguration");
			foreach (AuthenticationProviderData data1 in settings1.AuthenticationProviders)
			{
				if (data1 is DbAuthenticationProviderData)
				{
					this.cbxDbInstances.Items.Add(data1);
				}
			}
			this.cbxDbInstances.SelectedIndex=0;
		}


		public DbAuthenticationProviderData DbAuthenticationProvider
		{
			get
			{
				return (this.cbxDbInstances.SelectedItem as DbAuthenticationProviderData);
			}
		}

		private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			MessageBox.Show(e.Exception.Message, SR.UnhandledException, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		private void lbxUsers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ProfileInfo userProfile = new ProfileInfo(this.DbAuthenticationProvider.Database,this.configurationContext);
			string userName= lbxUsers.Text;
			SetPanelInfo(userName);
			if((userProfile.IsUserInThisRole((int)this.cbxRoles.SelectedValue,(int)this.lbxUsers.SelectedValue)==1))
			{	
				btnAdd.Enabled=false;
			}
			else
				btnAdd.Enabled=true;
		}
		private void SetPanelInfo(string userName)
		{	
			ProfileInfo userProfile = new ProfileInfo(this.DbAuthenticationProvider.Database,this.configurationContext);
			string name;
			name = userProfile.GetFirstName(userName) + " ";
			name += userProfile.GetLastName(userName);
			this.statusBarPanel1.Text= System.DateTime.Now.ToShortDateString();
			this.statusBarPanel2.Text= name;
			this.statusBarPanel3.Text= "Last Login:" + userProfile.GetLastLogIn(userName);
			if(userProfile.GetAccountEnabled(userName)==2)
			{
				this.statusBarPanel4.Text= "Account is Disabled";

				
			}
			else
			{
				this.statusBarPanel4.Text= "Account is Enabled";
			}
		}


	}
}

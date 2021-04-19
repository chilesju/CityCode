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
	
	public class CatagoryForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lbxCatagory;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ListBox lbxUsersCatagory;
		private System.Windows.Forms.Button btnRemove;
		private DbAuthenticationProviderData dbAuthenticationProvider;
		private ConfigurationContext context;
		private IHashProvider hashProvider;
		private ProfileInfo userProfile;
		private UserRoleManager userRoleMgr;
		private bool editMode;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private string user;
		
		private System.ComponentModel.Container components = null;

		
		public CatagoryForm(DbAuthenticationProviderData dbAuthenticationProvider, ConfigurationContext context)
		{
			try
			{
				this.components = null;
				this.dbAuthenticationProvider = dbAuthenticationProvider;
				this.context=context;
				this.userProfile = new ProfileInfo(dbAuthenticationProvider.Database, context);
				this.editMode = false;
				this.InitializeComponent();
	
				
				this.userRoleMgr = new UserRoleManager(dbAuthenticationProvider.Database, context);
				HashProviderFactory factory1 = new HashProviderFactory(context);
				this.hashProvider = factory1.CreateHashProvider(dbAuthenticationProvider.HashProvider);
				
				this.Text="Users Catagories";
			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		public CatagoryForm(DbAuthenticationProviderData dbAuthenticationProvider, ConfigurationContext context, string username) : this(dbAuthenticationProvider, context)
		{
		
			try
			{
				this.user= username;
				this.GetAllCatagories();
				this.GetUsersCatagories(username);
				
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
		
		private void InitializeComponent()
		{
			this.lbxCatagory = new System.Windows.Forms.ListBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.lbxUsersCatagory = new System.Windows.Forms.ListBox();
			this.btnRemove = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbxCatagory
			// 
			this.lbxCatagory.Location = new System.Drawing.Point(8, 16);
			this.lbxCatagory.Name = "lbxCatagory";
			this.lbxCatagory.Size = new System.Drawing.Size(488, 199);
			this.lbxCatagory.TabIndex = 0;
			this.lbxCatagory.DoubleClick += new System.EventHandler(this.lbxCatagory_DoubleClick);
			this.lbxCatagory.SelectedIndexChanged += new System.EventHandler(this.lbxCatagory_SelectedIndexChanged);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(16, 256);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(144, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add User to this Catagory";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(432, 536);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lbxUsersCatagory
			// 
			this.lbxUsersCatagory.Location = new System.Drawing.Point(8, 24);
			this.lbxUsersCatagory.Name = "lbxUsersCatagory";
			this.lbxUsersCatagory.Size = new System.Drawing.Size(488, 199);
			this.lbxUsersCatagory.TabIndex = 3;
			this.lbxUsersCatagory.SelectedIndexChanged += new System.EventHandler(this.lbxUsersCatagory_SelectedIndexChanged);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(16, 528);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(128, 23);
			this.btnRemove.TabIndex = 4;
			this.btnRemove.Text = "Remove Catagory";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbxUsersCatagory);
			this.groupBox1.Location = new System.Drawing.Point(8, 288);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(504, 232);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "User is Assinged To these Catagories";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lbxCatagory);
			this.groupBox2.Location = new System.Drawing.Point(8, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(504, 232);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "All Catagories";
			// 
			// CatagoryForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 574);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnAdd);
			this.Name = "CatagoryForm";
			this.Text = "Catagory";
			this.Load += new System.EventHandler(this.CatagoryForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void CatagoryForm_Load(object sender, System.EventArgs e)
		{
		
		}
		private void GetAllCatagories()
		{
			DataSet set1 = this.userProfile.LoadCatagories();
			this.lbxCatagory.BeginUpdate();
			this.lbxCatagory.DisplayMember = "Category";
			this.lbxCatagory.ValueMember = "Id";
			this.lbxCatagory.DataSource = set1.Tables[0];
			this.lbxCatagory.EndUpdate();	
		}
		private void GetUsersCatagories(string user)
		{
			DataSet set1 = this.userProfile.GetUsersCatagory(user);
			this.lbxUsersCatagory.BeginUpdate();
			this.lbxUsersCatagory.DisplayMember = "Category";
			this.lbxUsersCatagory.ValueMember = "Id";
			this.lbxUsersCatagory.DataSource = set1.Tables[0];
			this.lbxUsersCatagory.EndUpdate();	
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void lbxCatagory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			if(this.lbxUsersCatagory.FindStringExact(this.lbxCatagory.Text,-1)!=-1)
			{
				this.btnAdd.Enabled=false;
			}
			else
				this.btnAdd.Enabled=true;


		}

		private void lbxCatagory_DoubleClick(object sender, System.EventArgs e)
		{
		
		}

		private void lbxUsersCatagory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.btnRemove.Enabled==false)
			{
				this.btnRemove.Enabled=true;
			}
	

		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			int catagory = Convert.ToInt32(this.lbxUsersCatagory.SelectedValue);
			try
			{
				this.userProfile.RemoveUserFromCatagroy(catagory, this.user);
				//this.lbxUsersCatagory.se

				this.GetUsersCatagories(this.user);
				this.GetAllCatagories();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			int catagory = Convert.ToInt32(this.lbxCatagory.SelectedValue);
			try
			{
				this.userProfile.AddUserFromCatagroy(catagory, this.user);

				this.GetUsersCatagories(this.user);
				this.GetAllCatagories();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace User_Administration
{
	
	public class UserForm : System.Windows.Forms.Form
    {


        private bool editMode;
        private ProfileInfo userProfile;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private CheckBox chbxDisable;
        private TextBox txtFirstName;
        private Label label1;
        private Label label7;
        private TextBox tbxUser;
        private TextBox txtPhoneNumber;
        private Label label4;
        private Label label6;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private Label label5;
        private TabPage tabPage2;
        private ComboBox cmbxDivision;
        private Label label8;
        private ComboBox cmbxDepartment;
        private Label label2;
        private Button btnCancel;
        private Button btnSave;
        private Button btnAddCatagory;
        private DataGridView dgUsersAssingments;
        private Button btnRemoveAssigment;
        private Button btnAddAssigment;
		private System.ComponentModel.Container components = null;
        private Button btnAddAll;
        private Button btnAddAllDivForDept;
        private int assingmentID;


		public UserForm()
		{
			try
			{
                this.components = null;
                this.userProfile = new ProfileInfo();
				this.editMode = false;
				this.InitializeComponent();
				GetDepartments();
				this.UpdateSaveButtonEnabled();
				this.Text="Create A New User";
				this.chbxDisable.Visible=false;
                this.btnAddCatagory.Enabled = false;
                assingmentID = -1;
                this.btnRemoveAssigment.Enabled = false;
                this.btnAddAssigment.Enabled = false;
                this.btnAddAllDivForDept.Enabled = false;
                this.btnAddAll.Enabled = false;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public UserForm(int userID)
		{
            InitializeComponent();
			try
			{
                this.userProfile = new ProfileInfo(userID);
                GetDepartments();
                GetUsersAssingments();
                this.tbxUser.Text = userProfile.UserName;
				this.tbxUser.Enabled = true;
				this.editMode = true;
                this.txtFirstName.Text = userProfile.FirstName;
                this.txtLastName.Text = userProfile.LastName;
                this.txtEmail.Text = userProfile.Email;
                this.txtPhoneNumber.Text = userProfile.Phone;
                this.btnAddCatagory.Enabled = true;
				this.Text="Modify User";
				this.chbxDisable.Visible=true;
                assingmentID = -1;
                this.btnRemoveAssigment.Enabled = false;
                
				if(this.userProfile.Enabled==2)
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

        private void GetUsersAssingments()
        {
            this.dgUsersAssingments.DataSource = this.userProfile.GetUsersAssingments().Tables[0];
        
            
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chbxDisable = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddCatagory = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxUser = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRemoveAssigment = new System.Windows.Forms.Button();
            this.btnAddAssigment = new System.Windows.Forms.Button();
            this.dgUsersAssingments = new System.Windows.Forms.DataGridView();
            this.cmbxDivision = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbxDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddAllDivForDept = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsersAssingments)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(385, 438);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chbxDisable);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.btnAddCatagory);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.txtFirstName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tbxUser);
            this.tabPage1.Controls.Add(this.txtPhoneNumber);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.txtLastName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(377, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chbxDisable
            // 
            this.chbxDisable.Location = new System.Drawing.Point(95, 209);
            this.chbxDisable.Name = "chbxDisable";
            this.chbxDisable.Size = new System.Drawing.Size(112, 24);
            this.chbxDisable.TabIndex = 12;
            this.chbxDisable.Text = "Disable Account";
            this.chbxDisable.CheckedChanged += new System.EventHandler(this.chbxDisable_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(53, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddCatagory
            // 
            this.btnAddCatagory.Location = new System.Drawing.Point(215, 280);
            this.btnAddCatagory.Name = "btnAddCatagory";
            this.btnAddCatagory.Size = new System.Drawing.Size(88, 23);
            this.btnAddCatagory.TabIndex = 21;
            this.btnAddCatagory.Text = "Add Catagory";
            this.btnAddCatagory.Click += new System.EventHandler(this.btnAddCatagory_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(134, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(95, 80);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(208, 20);
            this.txtFirstName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "User Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Phone Number:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxUser
            // 
            this.tbxUser.Location = new System.Drawing.Point(95, 45);
            this.tbxUser.Name = "tbxUser";
            this.tbxUser.Size = new System.Drawing.Size(208, 20);
            this.tbxUser.TabIndex = 1;
            this.tbxUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUser_KeyPress);
            this.tbxUser.TextChanged += new System.EventHandler(this.tbxUser_TextChanged);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(95, 169);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(208, 20);
            this.txtPhoneNumber.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "First Name:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(38, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "E-mail:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(95, 139);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(95, 110);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(208, 20);
            this.txtLastName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Last Name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddAll);
            this.tabPage2.Controls.Add(this.btnAddAllDivForDept);
            this.tabPage2.Controls.Add(this.btnRemoveAssigment);
            this.tabPage2.Controls.Add(this.btnAddAssigment);
            this.tabPage2.Controls.Add(this.dgUsersAssingments);
            this.tabPage2.Controls.Add(this.cmbxDivision);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cmbxDepartment);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(377, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Assignments";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAssigment
            // 
            this.btnRemoveAssigment.Location = new System.Drawing.Point(90, 148);
            this.btnRemoveAssigment.Name = "btnRemoveAssigment";
            this.btnRemoveAssigment.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAssigment.TabIndex = 23;
            this.btnRemoveAssigment.Text = "Remove";
            this.btnRemoveAssigment.UseVisualStyleBackColor = true;
            this.btnRemoveAssigment.Click += new System.EventHandler(this.btnRemoveAssigment_Click);
            // 
            // btnAddAssigment
            // 
            this.btnAddAssigment.Location = new System.Drawing.Point(9, 148);
            this.btnAddAssigment.Name = "btnAddAssigment";
            this.btnAddAssigment.Size = new System.Drawing.Size(75, 23);
            this.btnAddAssigment.TabIndex = 22;
            this.btnAddAssigment.Text = "Add";
            this.btnAddAssigment.UseVisualStyleBackColor = true;
            this.btnAddAssigment.Click += new System.EventHandler(this.btnAddAssigment_Click);
            // 
            // dgUsersAssingments
            // 
            this.dgUsersAssingments.AllowUserToAddRows = false;
            this.dgUsersAssingments.AllowUserToDeleteRows = false;
            this.dgUsersAssingments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsersAssingments.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgUsersAssingments.Location = new System.Drawing.Point(3, 187);
            this.dgUsersAssingments.MultiSelect = false;
            this.dgUsersAssingments.Name = "dgUsersAssingments";
            this.dgUsersAssingments.ReadOnly = true;
            this.dgUsersAssingments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUsersAssingments.Size = new System.Drawing.Size(371, 222);
            this.dgUsersAssingments.TabIndex = 21;
            this.dgUsersAssingments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUsersAssingments_CellClick);
            // 
            // cmbxDivision
            // 
            this.cmbxDivision.Location = new System.Drawing.Point(9, 110);
            this.cmbxDivision.Name = "cmbxDivision";
            this.cmbxDivision.Size = new System.Drawing.Size(216, 21);
            this.cmbxDivision.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "Division";
            // 
            // cmbxDepartment
            // 
            this.cmbxDepartment.Location = new System.Drawing.Point(9, 46);
            this.cmbxDepartment.Name = "cmbxDepartment";
            this.cmbxDepartment.Size = new System.Drawing.Size(216, 21);
            this.cmbxDepartment.TabIndex = 5;
            this.cmbxDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbxDepartment_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Department";
            // 
            // btnAddAllDivForDept
            // 
            this.btnAddAllDivForDept.Location = new System.Drawing.Point(231, 46);
            this.btnAddAllDivForDept.Name = "btnAddAllDivForDept";
            this.btnAddAllDivForDept.Size = new System.Drawing.Size(102, 38);
            this.btnAddAllDivForDept.TabIndex = 24;
            this.btnAddAllDivForDept.Text = "Add All Divisions For Department";
            this.btnAddAllDivForDept.UseVisualStyleBackColor = true;
            this.btnAddAllDivForDept.Click += new System.EventHandler(this.btnAddAllDivForDept_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(231, 17);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(102, 23);
            this.btnAddAll.TabIndex = 25;
            this.btnAddAll.Text = "Add All";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // UserForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(385, 495);
            this.Controls.Add(this.tabControl1);
            this.Name = "UserForm";
            this.Text = "Edit User";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUsersAssingments)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
            try
            {
                if (this.tbxUser.Text.Trim() == "")
                {
                    MessageBox.Show(this, "You must imput a user name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SetUserProfileInformation();
                    if (this.editMode)
                    {
                        this.userProfile.ChangeUserInfo();
                        MessageBox.Show(this, SR.UserUpdated, "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (AdminManager.UserNameValid(this.tbxUser.Text)) //Add
                        {
                            this.userProfile.Enabled = 1;
                            this.userProfile.CreateUser();
                            this.editMode = true;
                            MessageBox.Show(this, SR.UserCreated, "Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.btnAddCatagory.Enabled = true;
                            this.btnAddAssigment.Enabled = true;
                            this.btnAddAllDivForDept.Enabled = true;
                            this.btnAddAll.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show(this, SR.UserAlreadyExists, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error saving the user information: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

        private void SetUserProfileInformation()
        {
            try
            {
                this.userProfile.UserName = this.tbxUser.Text.Trim();
                this.userProfile.FirstName = this.txtFirstName.Text.Trim();
                this.userProfile.LastName = this.txtLastName.Text.Trim();
                this.userProfile.Phone = this.txtPhoneNumber.Text.Trim();
                this.userProfile.Email = this.txtEmail.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error getting the Profile Information: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



		private void GetDepartments()
		{
            try
            {
                DataSet set1 = AdminManager.GetDepartments();
                this.cmbxDepartment.BeginUpdate();
                this.cmbxDepartment.DisplayMember = "Department";
                this.cmbxDepartment.ValueMember = "id";
                this.cmbxDepartment.DataSource = set1.Tables[0];
                this.cmbxDepartment.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error getting the Departments: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


		private void DisableControls()
		{
			this.txtFirstName.Enabled=false;
			this.txtLastName.Enabled=false;
			this.chbxDisable.Text="Enable Account";
			this.cmbxDepartment.Enabled=false;
			this.Text= "Account is Disabled";
			this.btnSave.Enabled=false;

		}
		private void EnabledControls()
		{
			this.txtFirstName.Enabled=true;
			this.txtLastName.Enabled=true;
			this.chbxDisable.Text="Disable Account";
			this.cmbxDepartment.Enabled=true;
			this.Text= "Account is Active";
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
		


		private void ShowCatagoryDialog()
		{
			CatagoryForm form1;
				form1 = new CatagoryForm(this.userProfile);

			if (form1.ShowDialog(this) == DialogResult.OK)
			{
				
			}
		}

		private void BindDivision(int deptValue)
		{
            try
            {
                DataSet set1 = AdminManager.GetDivisions(deptValue);
                this.cmbxDivision.BeginUpdate();
                this.cmbxDivision.DisplayMember = "Division";
                this.cmbxDivision.ValueMember = "id";

                DataRow newRow;
                newRow = set1.Tables[0].NewRow();
                newRow[0] = "--None--";
                newRow[1] = 0;

                set1.Tables[0].Rows.Add(newRow);
                this.cmbxDivision.DataSource = set1.Tables[0];

                this.cmbxDivision.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error getting getting the Divisions: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			
			
		}

		private void cmbxDepartment_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindDivision(Convert.ToInt32(this.cmbxDepartment.SelectedValue));
		}

		private void btnAddCatagory_Click(object sender, System.EventArgs e)
		{
            this.ShowCatagoryDialog();
		}

        private void btnAddAssigment_Click(object sender, EventArgs e)
        {
            try
            {
                int deptID;
                int divID;
                string deptString;
                string divString;
                deptString = this.cmbxDepartment.Text;
                divString = this.cmbxDivision.Text;
                if (divString == "--None--")
                {
                    divString = "None";
                }

                bool isValid;
                isValid = true;


                foreach (DataGridViewRow row in this.dgUsersAssingments.Rows)
                {
                    string cell1 = row.Cells[1].Value.ToString();
                    string cell2 = row.Cells[2].Value.ToString();
                    if (cell1 == deptString && cell2 == divString)
                    {
                        isValid = false;
                    }
                }

                if (isValid == true)
                {
                    deptID = Convert.ToInt32(this.cmbxDepartment.SelectedValue);
                    divID = Convert.ToInt32(this.cmbxDivision.SelectedValue);
                    this.userProfile.AddUserAssingment(deptID, divID);
                    GetUsersAssingments();
                }
                else
                {
                    MessageBox.Show(this, "This Department and Division is already loaded", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error Adding an assingment: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgUsersAssingments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                assingmentID= Convert.ToInt32(this.dgUsersAssingments.Rows[e.RowIndex].Cells[0].Value);
                this.btnRemoveAssigment.Enabled = true;
            }
        }

        private void btnRemoveAssigment_Click(object sender, EventArgs e)
        {
            try
            {
                this.userProfile.RemoveUserFromAssingment(assingmentID);
                GetUsersAssingments();
                this.btnRemoveAssigment.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error removing the assingment: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.userProfile.AddUserToAllAssingnments();
                GetUsersAssingments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error Adding all of the categories: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAddAllDivForDept_Click(object sender, EventArgs e)
        {
            try
            {
                int deptID;
                deptID = Convert.ToInt32(this.cmbxDepartment.SelectedValue);
                this.userProfile.AddUserToAllDivsionsForDepartment(deptID);
                GetUsersAssingments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error Adding All of the Divisions to the Department: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

	}
}

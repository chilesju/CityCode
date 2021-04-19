using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
namespace User_Administration
{
	
	public class ProfileInfo
	{
		private Database securityDb;
        private string _userName;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private int _userID;
        private int _enabled;
        private System.DateTime _lastLogIn;

		public ProfileInfo() 
		{
            this.securityDb = DatabaseFactory.CreateDatabase();
            this._email = "";
            this._firstName = "";
            this._lastName = "";
            this._phone = "";
            this._userID = -1;
            this._userName = "";
            this._enabled = -1;
		}

        public ProfileInfo(int userID)
        {
            _userID = userID;
            this.securityDb = DatabaseFactory.CreateDatabase();
            SetUserProfileInformation();
        }

        /// <summary>
        /// Changes the user info.
        /// </summary>
        public void ChangeUserInfo()
		{
            try
            {

                string sqlCommand = "ChangePersonalInformation";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand, this._userName,this._firstName,this._lastName,this._email,this._phone, this._userID);
                this.securityDb.ExecuteNonQuery(dbCommand);
            }

            catch (Exception ex)
            {
                throw ex;
            }
		}


        /// <summary>
        /// Creates the user.
        /// </summary>
		public void CreateUser()
		{
            try
            {

                string sqlCommand = "InsertUser";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand, this._userName,this._firstName, this._lastName,this._enabled,this._email,this._phone);
                int returnValue = Convert.ToInt32(this.securityDb.ExecuteScalar(dbCommand));
                this._userID = returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        /// <summary>
        /// Sets the users profile information.
        /// </summary>
        public void SetUserProfileInformation()
        {
            try
            {
                string sqlCommand = "GetUserProfileInformation";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);

                this.securityDb.AddInParameter(dbCommand, "userID", DbType.Int32, this._userID);
                this.securityDb.ExecuteReader(dbCommand);

                using (IDataReader dataReader = this.securityDb.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        // Get the value of the Name column in the DbDataReader.
                        this._userName = dataReader["UserName"].ToString();
                        this._firstName = dataReader["First Name"].ToString();
                        this._lastName = dataReader["Last Name"].ToString();
                        this._enabled = Convert.ToInt32(dataReader["Enabled"]);
                        this._lastLogIn = Convert.ToDateTime(dataReader["Activity"]);
                        this._phone = dataReader["PhoneNumber"].ToString();
                        this._email = dataReader["Email"].ToString();
  
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Disables the account.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="enabled">The enabled.</param>
        public void DisableAccount(string userName, int enabled)
        {
            try
            {
                string sqlCommand = "DisableAccount";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);

                this.securityDb.AddInParameter(dbCommand, "userName", DbType.String, userName);
                this.securityDb.AddInParameter(dbCommand, "enabled", DbType.Int32, enabled);
                this.securityDb.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Gets the account enabled.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public int GetAccountEnabled(string userName)
        {
            try
            {
                string sqlCommand = "GetAccountEnabled";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);

                this.securityDb.AddInParameter(dbCommand, "userName", DbType.String, userName);
                this.securityDb.AddOutParameter(dbCommand, "enabled", DbType.Int32, 4);
                this.securityDb.ExecuteNonQuery(dbCommand);
                object obj1 = this.securityDb.GetParameterValue(dbCommand, "enabled");
                return ((obj1 == DBNull.Value) ? -1 : ((int)obj1));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// Adds the user to role.
        /// </summary>
        /// <param name="roleID">The role ID.</param>
        public void AddUserToRole(int roleID)
        {
            try
            {
                string sqlCommand = "AddUserToRoleByName";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);

                this.securityDb.AddInParameter(dbCommand, "UserID", DbType.Int32, this.UserID);
                this.securityDb.AddInParameter(dbCommand, "RoleID", DbType.Int32, roleID);
                this.securityDb.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Removes the user from role.
        /// </summary>
        /// <param name="roleID">The role ID.</param>
        public void RemoveUserFromRole(int roleID)
        {
            try
            {
                string sqlCommand = "RemoveUserFromRoleByName";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);

                this.securityDb.AddInParameter(dbCommand, "UserID", DbType.Int32, this.UserID);
                this.securityDb.AddInParameter(dbCommand, "RoleID", DbType.Int32, roleID);
                this.securityDb.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Removes the user from catagroy.
        /// </summary>
        /// <param name="catId">The cat id.</param>
        /// <param name="user">The user.</param>
		public void RemoveUserFromCatagroy(int catId, string user)
		{
            try
            {
                string sqlCommand = "Council_RemoveUserFromCatagories";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);

                this.securityDb.AddInParameter(dbCommand, "catId", DbType.Int32, catId);
                this.securityDb.AddInParameter(dbCommand, "user", DbType.String, user);
                this.securityDb.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        /// <summary>
        /// Adds the user from catagroy.
        /// </summary>
        /// <param name="catId">The cat id.</param>
        /// <param name="user">The user.</param>
		public void AddUserFromCatagroy(int catId, string user)
		{
            string sqlCommand = "Council_AddUserToThisCatagory";
            System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);

            this.securityDb.AddInParameter(dbCommand,"catId", DbType.Int32, catId);
            this.securityDb.AddInParameter(dbCommand,"user", DbType.String, user);
            this.securityDb.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Gets the users catagory.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
		public System.Data.DataSet GetUsersCatagory()
		{
            try
            {
                string sqlCommand = "Council_LoadUsersCatagories";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);
                this.securityDb.AddInParameter(dbCommand, "userID", DbType.String, this.UserID);
                return this.securityDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        /// <summary>
        /// Gets the users assigments.
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet GetUsersAssingments()
        {
            try
            {
                string sqlCommand = "Council_LoadUsersAssingments";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);
                this.securityDb.AddInParameter(dbCommand, "userID", DbType.Int32, this._userID);
                return this.securityDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds the user assingment.
        /// </summary>
        /// <param name="DeptID">The dept ID.</param>
        /// <param name="DivID">The div ID.</param>
        /// <returns></returns>
        public System.Data.DataSet AddUserAssingment(int DeptID, int DivID)
        {
            try
            {
                string sqlCommand = "Council_AddUserAssingment";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);
                this.securityDb.AddInParameter(dbCommand, "userID", DbType.Int32, this.UserID);
                this.securityDb.AddInParameter(dbCommand, "DeptID", DbType.Int32, DeptID);
                this.securityDb.AddInParameter(dbCommand, "DivID", DbType.Int32, DivID);
                return this.securityDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Removes the user from assingment.
        /// </summary>
        /// <param name="AssingmentID">The assingment ID.</param>
        /// <returns></returns>
        public System.Data.DataSet RemoveUserFromAssingment(int AssingmentID)
        {
            try
            {
                string sqlCommand = "Council_RemoveUserAssingment";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);
                this.securityDb.AddInParameter(dbCommand, "AssingmentID", DbType.Int32, AssingmentID);
                return this.securityDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Adds the user to all assingnments.
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet AddUserToAllAssingnments()
        {
            try
            {
                string sqlCommand = "Council_AddUserToAllAssingments";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);
                this.securityDb.AddInParameter(dbCommand, "UserID", DbType.Int32, this.UserID);
                return this.securityDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds the user to all divsions for department.
        /// </summary>
        /// <param name="DepartmentID">The department ID.</param>
        /// <returns></returns>
        public System.Data.DataSet AddUserToAllDivsionsForDepartment(int DepartmentID)
        {
            try
            {
                string sqlCommand = "Council_AddUserToAllDivisionsForDepartment";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);
                this.securityDb.AddInParameter(dbCommand, "userID", DbType.Int32, this.UserID);
                this.securityDb.AddInParameter(dbCommand, "departmentID", DbType.Int32, DepartmentID);
                return this.securityDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Determines whether [is user in this role] [the specified role id].
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public int IsUserInThisRole(int roleId, int userId)
        {
            try
            {
                string sqlCommand = "IsUserInThisRole";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);

                this.securityDb.AddInParameter(dbCommand, "nameId", DbType.Int32, userId);
                this.securityDb.AddInParameter(dbCommand, "roleID", DbType.Int32, roleId);
                this.securityDb.AddOutParameter(dbCommand, "value", DbType.Int32, 4);
                this.securityDb.ExecuteNonQuery(dbCommand);
                object obj1 = this.securityDb.GetParameterValue(dbCommand, "value");
                return ((obj1 == DBNull.Value) ? -1 : ((int)obj1));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string UserName
        {
            get { return this._userName; }
            set { this._userName = value; }
        }
        public string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }
        public string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }
        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public string Phone
        {
            get { return this._phone; }
            set { this._phone = value; }
        }

        public int UserID
        {
            get { return this._userID; }
        }

        public int Enabled
        {
            get { return this._enabled; }
            set { this._enabled = value; }
        }

        public System.DateTime LastLogIn
        {
            get { return this._lastLogIn; }
            set { this._lastLogIn = value; }
        }
	}
}

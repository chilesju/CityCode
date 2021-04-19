using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;


namespace Utilites
{
	
	public class ProfileInfo 
	{

		public void ChangeUserInfo(string userName, string firstName,string lastName,int deptId)
		{
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
			this.ValidateParam("userName", userName);
            DbCommand dbCommand = db.GetStoredProcCommand("ChangePersonalInformation", userName, firstName, lastName, deptId);
            db.ExecuteNonQuery(dbCommand);
		}

		public System.DateTime GetLastLogIn(string userName)
		{
            Database securityDb = DatabaseFactory.CreateDatabase();	
			this.ValidateParam("name", userName);
            DbCommand dbCommand = securityDb.GetStoredProcCommand("GetLastLogIn", userName);
            object obj1 = securityDb.ExecuteScalar(dbCommand);
			return ((obj1 == DBNull.Value) ? System.DateTime.MinValue : ((System.DateTime) obj1));

		}

		public int GetUserDepartment(string userName)
		{
            try
            {
                Database securityDb;
                securityDb = DatabaseFactory.CreateDatabase();
                string sqlCommand = "GetUserDepartment";
                System.Data.Common.DbCommand dbCommand = securityDb.GetStoredProcCommand(sqlCommand);
                securityDb.AddInParameter(dbCommand, "name", DbType.String, userName);
                securityDb.AddOutParameter(dbCommand, "deptId", DbType.Int32, 4);
                securityDb.ExecuteNonQuery(dbCommand);
                object obj1 = securityDb.GetParameterValue(dbCommand, "deptId");
                return ((obj1 == DBNull.Value) ? -1 : ((int)obj1));
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        public int GetUserDivision(string userName)
        {
            try
            {
                Database securityDb;
                securityDb = DatabaseFactory.CreateDatabase();
                string sqlCommand = "GetUserDivision";
                System.Data.Common.DbCommand dbCommand = securityDb.GetStoredProcCommand(sqlCommand);
                securityDb.AddInParameter(dbCommand, "name", DbType.String, userName);
                securityDb.AddOutParameter(dbCommand, "@divisionId", DbType.Int32, 4);

                securityDb.ExecuteNonQuery(dbCommand);
                object obj1 = securityDb.GetParameterValue(dbCommand, "@divisionId");
                return ((obj1 == DBNull.Value) ? -1 : ((int)obj1));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public void DisableAccount(string userName, int enabled)
		{
            Database securityDb = DatabaseFactory.CreateDatabase();
			this.ValidateParam("userName", userName);
			this.ValidateParam("enabled", enabled);
            DbCommand dbCommand = securityDb.GetStoredProcCommand("DisableAccount", userName, enabled);
            securityDb.ExecuteNonQuery(dbCommand);
		}

		public int GetAccountEnabled(string userName)
		{
            Database securityDb = DatabaseFactory.CreateDatabase();
			this.ValidateParam("userName", userName);
            DbCommand dbCommand = securityDb.GetStoredProcCommand("GetAccountEnabled", userName);

            object obj1= securityDb.ExecuteScalar(dbCommand);
			return ((obj1 == DBNull.Value) ? -1 : ((int) obj1));

		}
	    public  void ChangeUserPassword(string userName, byte[] newEncryptedPassword)
		{
            Database securityDb = DatabaseFactory.CreateDatabase();
			this.ValidateParam("userName", userName);
			this.ValidateParam("newPassword", newEncryptedPassword);
            DbCommand dbCommand = securityDb.GetStoredProcCommand("ChangePasswordByName", userName, newEncryptedPassword);
            securityDb.ExecuteNonQuery(dbCommand);
		}

		private void ValidateParam(string paramName, object param)
		{
			if (param == null)
			{
				throw new ArgumentNullException(paramName);
			}
			if (param is string)
			{
				string text1 = (string) param;
				if (text1.Length == 0)
				{
					throw new ArgumentNullException(paramName);
				}
			}
		}
		public bool CreateUser(string userName, byte[] password,string firstName,string lastName)
		{
            Database securityDb = DatabaseFactory.CreateDatabase();
			this.ValidateParam("userName", userName);
			this.ValidateParam("password", password);
            DbCommand dbCommand = securityDb.GetStoredProcCommand("InsertUser", userName, password, firstName, lastName);
            securityDb.ExecuteNonQuery(dbCommand);
            return true;
		}

		public string GetFirstName(string userName)
		{
            Database securityDb = DatabaseFactory.CreateDatabase();
			this.ValidateParam("userName", userName);
            DbCommand dbCommand = securityDb.GetStoredProcCommand("GetFirstName", userName);
            return (string)securityDb.ExecuteScalar(dbCommand);

		}
		public string GetLastName(string userName)
		{
            Database securityDb = DatabaseFactory.CreateDatabase();
			this.ValidateParam("userName", userName);
            DbCommand dbCommand = securityDb.GetStoredProcCommand("GetLastName", userName);
            return (string)securityDb.ExecuteScalar(dbCommand);
		}
		public System.Data.DataSet GetDepartments()
		{
            Database securityDb = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = securityDb.GetStoredProcCommand("GetDepartments");
            return securityDb.ExecuteDataSet(dbCommand);
		}
		public System.Data.DataSet GetUsersForDepartment(int departmentId)
		{
            Database securityDb = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = securityDb.GetStoredProcCommand("GetDepartmentUsers", departmentId);
            return securityDb.ExecuteDataSet(dbCommand);
		}

	}
}

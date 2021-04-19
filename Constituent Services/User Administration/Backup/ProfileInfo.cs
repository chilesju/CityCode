using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Database;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Database.Authentication;
using Microsoft.Practices.EnterpriseLibrary.Security.Database.Authentication.Configuration;
namespace User_Administration
{
	
	public class ProfileInfo : UserRoleManager 
	{
		private Database securityDb;
		private const string SPChangePassword = "ChangePasswordByName";
		private const string SPCreateRole = "InsertRole";
		private const string SPCreateUser = "InsertUser";
		private const string SPCreateUserRole = "AddUserToRoleByName";
		private const string SPDeleteRole = "DeleteRoleByName";
		private const string SPDeleteUser = "DeleteUserByName";
		private const string SPDeleteUserRole = "RemoveUserFromRoleByName";
		private const string SPGetAllRoles = "GetAllRoles";
		private const string SPGetAllUsers = "GetAllUsers";
		private const string SPGetIdentityId = "GetUserIdByName";
		private const string SPGetPassword = "GetPassword";
		private const string SPGetRoleId = "GetRoleIdByName";
		private const string SPGetRolesByName = "GetRolesByName";
		private const string SPGetRoleUsers = "GetUserInRoleByName";
		private const string SPRenameRole = "UpdateRoleById";

		public ProfileInfo(string database, ConfigurationContext context) : base(database,context)
		{
			DatabaseProviderFactory factory1 = new DatabaseProviderFactory(context);
			this.securityDb = factory1.CreateDatabase(database);
		}
		public void ChangeUserInfo(string userName, string firstName,string lastName,object deptId,object divId,string email,string phone)
		{
			int dept = (int)deptId;
			int div = (int)divId;
			this.ValidateParam("userName", userName);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("ChangePersonalInformation");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddInParameter("firstName",DbType.String,firstName);
			wrapper1.AddInParameter("lastName",DbType.String,lastName);
			wrapper1.AddInParameter("deptId",DbType.Int32,dept);
			wrapper1.AddInParameter("divId",DbType.Int32,div);
			wrapper1.AddInParameter("email",DbType.String,email);
			wrapper1.AddInParameter("phone",DbType.String,phone);
			this.securityDb.ExecuteNonQuery(wrapper1);

		}
		public  bool CreateUser(string userName, string firstName,string lastName,string dept,string div, byte[] password,int enabled,string email,string phone)
		{

			this.ValidateParam("userName", userName);
			this.ValidateParam("password", password);
			this.ValidateParam("firstName", userName);
			this.ValidateParam("lastName", password);
			this.ValidateParam("email", email);
			this.ValidateParam("phone", phone);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("InsertUser");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddInParameter("password", DbType.Binary, password);
			wrapper1.AddInParameter("firstName", DbType.String, firstName);
			wrapper1.AddInParameter("lastName", DbType.String, lastName);
			wrapper1.AddInParameter("dept", DbType.String,dept);
			wrapper1.AddInParameter("div", DbType.String,div);
			wrapper1.AddInParameter("enabled", DbType.Int32,enabled );
			wrapper1.AddInParameter("email", DbType.String,email );
			wrapper1.AddInParameter("phone", DbType.String,phone );
			wrapper1.AddOutParameter("userExists", DbType.Byte, 1);
			this.securityDb.ExecuteNonQuery(wrapper1);
			int num1 = (byte) wrapper1.GetParameterValue("userExists");
			return (num1 == 0);
		}

		public System.DateTime GetLastLogIn(string userName)
		{
					
			this.ValidateParam("name", userName);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("GetLastLogIn");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddOutParameter("date", DbType.DateTime,4);
			this.securityDb.ExecuteNonQuery(wrapper1);
			object obj1 = wrapper1.GetParameterValue("date");
			return ((obj1 == DBNull.Value) ? System.DateTime.MinValue : ((System.DateTime) obj1));

		}
		public int GetUserDepartment(string userName)
		{
		
			this.ValidateParam("name", userName);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("GetUserDepartment");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddOutParameter("deptId", DbType.Int32,4);
			this.securityDb.ExecuteNonQuery(wrapper1);
			object obj1 = wrapper1.GetParameterValue("deptId");
			return ((obj1 == DBNull.Value) ? -1 : ((int) obj1));



		}

		public int GetUserDivision(string userName)
		{
		
			this.ValidateParam("name", userName);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("GetUserDivision");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddOutParameter("@divisionId", DbType.Int32,4);
			this.securityDb.ExecuteNonQuery(wrapper1);
			object obj1 = wrapper1.GetParameterValue("@divisionId");
			return ((obj1 == DBNull.Value) ? -1 : ((int) obj1));



		}
		public void DisableAccount(string userName, int enabled)
		{
			this.ValidateParam("userName", userName);
			this.ValidateParam("enabled", enabled);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("DisableAccount");
			wrapper1.AddInParameter("userName", DbType.String, userName);
			wrapper1.AddInParameter("enabled", DbType.Int32, enabled);
			this.securityDb.ExecuteNonQuery(wrapper1);

		}
		public int GetAccountEnabled(string userName)
		{
			this.ValidateParam("userName", userName);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("GetAccountEnabled");
			wrapper1.AddInParameter("userName", DbType.String, userName);
			wrapper1.AddOutParameter("enabled", DbType.Int32,4);
			this.securityDb.ExecuteNonQuery(wrapper1);
			object obj1 = wrapper1.GetParameterValue("enabled");
			return ((obj1 == DBNull.Value) ? -1 : ((int) obj1));

		}
	    public new void ChangeUserPassword(string userName, byte[] newEncryptedPassword)
		{
		
			this.ValidateParam("userName", userName);
			this.ValidateParam("newPassword", newEncryptedPassword);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("ChangePasswordByName");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddInParameter("password", DbType.Binary, newEncryptedPassword);
			this.securityDb.ExecuteNonQuery(wrapper1);
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
		public bool CreateUser(string userName, byte[] password,string firstName,string lastName,string email,string phone)
		{
			this.ValidateParam("userName", userName);
			this.ValidateParam("password", password);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("InsertUser");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddInParameter("password", DbType.Binary, password);
			wrapper1.AddInParameter("firstName", DbType.String, firstName);
			wrapper1.AddInParameter("lastName", DbType.String, lastName);
			wrapper1.AddInParameter("email", DbType.String, email);
			wrapper1.AddInParameter("phone", DbType.String, phone);
			wrapper1.AddOutParameter("userExists", DbType.Byte, 1);
			this.securityDb.ExecuteNonQuery(wrapper1);
			int num1 = (byte) wrapper1.GetParameterValue("userExists");
			return (num1 == 0);
		}
		public string GetFirstName(string userName)
		{
			this.ValidateParam("userName", userName);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("GetFirstName");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddOutParameter("firstName", DbType.String, 50);
			return (string)this.securityDb.ExecuteScalar(wrapper1);

		}
		public string GetLastName(string userName)
		{
			this.ValidateParam("userName", userName);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("GetLastName");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddOutParameter("lastName", DbType.String, 50);
			return (string)this.securityDb.ExecuteScalar(wrapper1);
		}
		public string GetEmail(string userName)
		{
			this.ValidateParam("userName", userName);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("GetEmail");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddOutParameter("email", DbType.String, 50);
			return (string)this.securityDb.ExecuteScalar(wrapper1);
		}
		public string GetPhone(string userName)
		{
			this.ValidateParam("userName", userName);
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("GetPhone");
			wrapper1.AddInParameter("name", DbType.String, userName);
			wrapper1.AddOutParameter("phone", DbType.String, 50);
			return (string)this.securityDb.ExecuteScalar(wrapper1);
		}
		public System.Data.DataSet GetDepartments()
		{
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("GetDepartments");
			return this.securityDb.ExecuteDataSet(wrapper1);
		}
		public System.Data.DataSet GetDivisions(int departId)
		{
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("GetDivision");
			wrapper1.AddInParameter("deptId", DbType.Int32, departId);
			return this.securityDb.ExecuteDataSet(wrapper1);
		}
		public System.Data.DataSet LoadCatagories()
		{
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("Council_LoadCatagories");
			return this.securityDb.ExecuteDataSet(wrapper1);
		}

		public void RemoveUserFromCatagroy(int catId, string user)
		{
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("Council_RemoveUserFromCatagories");
			wrapper1.AddInParameter("catId", DbType.Int32, catId);
			wrapper1.AddInParameter("user", DbType.String, user);
			this.securityDb.ExecuteNonQuery(wrapper1);

		}
		public void AddUserFromCatagroy(int catId, string user)
		{
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("Council_AddUserToThisCatagory");
			wrapper1.AddInParameter("catId", DbType.Int32, catId);
			wrapper1.AddInParameter("user", DbType.String, user);
			this.securityDb.ExecuteNonQuery(wrapper1);

		}
		public System.Data.DataSet GetUsersCatagory(string user)
		{
			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("Council_LoadUsersCatagories");
			wrapper1.AddInParameter("user", DbType.String, user);
			return this.securityDb.ExecuteDataSet(wrapper1);
		}
		public int IsUserInThisRole(int roleId,int userId)
		{

			DBCommandWrapper wrapper1 = this.securityDb.GetStoredProcCommandWrapper("IsUserInThisRole");
			wrapper1.AddInParameter("nameId", DbType.Int32, userId);
			wrapper1.AddInParameter("roleID", DbType.Int32, roleId);
			wrapper1.AddOutParameter("value", DbType.Int32,4);
			this.securityDb.ExecuteNonQuery(wrapper1);
			object obj1 = wrapper1.GetParameterValue("value");
			return ((obj1 == DBNull.Value) ? -1 : ((int) obj1));

		}
	}
}

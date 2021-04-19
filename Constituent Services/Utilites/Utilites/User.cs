using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
namespace Utilites
{

	public class User
	{
        private Database securityDb;
        private string _userName;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private int _userId;
        private int _enabled;
        private System.DateTime _lastLogIn;

        public User(string userName)
        {
            try
            {

                _userName = userName;
                GetUserIDByName();
                this.securityDb = DatabaseFactory.CreateDatabase();
                SetUserInformation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the users profile information.
        /// </summary>
        public void SetUserInformation()
        {
            try
            {
                string sqlCommand = "GetUserProfileInformation";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);

                this.securityDb.AddInParameter(dbCommand, "userID", DbType.Int32, this._userId);
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
                        this._email = dataReader["Email"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GetUserIDByName()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_GetUserIDByName";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._userName);

            this._userId = Convert.ToInt32(db.ExecuteScalar(dbCommand));

        }
        /// <summary>
        /// Gets the users email.
        /// </summary>
        /// <returns></returns>
		public  string GetUsersEmail()
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "Council_GetUserEmailById";
            System.Data.Common.DbCommand dbCommand  = db.GetStoredProcCommand(sqlCommand, this._userId);
            return db.ExecuteScalar(dbCommand).ToString();
		}

        /// <summary>
        /// Logs the users log in.
        /// </summary>
        /// <param name="Username">The username.</param>
        /// <param name="SessionId">The session id.</param>
        public static void LogUsersLogIn(string Username, string SessionId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_LogUserLogIn";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, Username, SessionId);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects the users over due incidents.
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet SelectUsersOverDueIncidents()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SelectUsersOverDueIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._userId);
            return db.ExecuteDataSet(dbCommand);
        }
        public System.Data.DataSet SelectUsersIncidents(string status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SelectUsersIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._userId, status);
            return db.ExecuteDataSet(dbCommand);
        }

        public System.Data.DataSet SelectUsersRequestingCloserIncidents()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SelectUsersRequestingClosure";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._userId);
            return db.ExecuteDataSet(dbCommand);
        }

        public  System.Data.DataSet SearchUsersIncidents(int IncidentNumber, string FirstName, string LastName, int ProblemTypeId, string Council, string Address, string Description, System.DateTime MinOpenDate, System.DateTime MaxOpenDate, string Status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SearchUsersIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, IncidentNumber, FirstName, LastName, ProblemTypeId, Council, Address, Description, MinOpenDate, MaxOpenDate, Status, this._userId);
            try
            {
                return db.ExecuteDataSet(dbCommand);
            }
            catch (SqlException Sqlex)
            {
                throw Sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Data.DataSet GetUsersCatagory()
        {
            try
            {
                string sqlCommand = "Council_LoadUsersCatagories";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);
                this.securityDb.AddInParameter(dbCommand, "userID", DbType.String, this._userId);
                return this.securityDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public System.Data.DataSet GetUsersDepartments()
        {
            try
            {
                string sqlCommand = "Council_GetUsersDepartments";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);
                this.securityDb.AddInParameter(dbCommand, "userID", DbType.String, this._userId);
                return this.securityDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public System.Data.DataSet GetUsersDivisions(int deptID)
        {
            try
            {
                string sqlCommand = "Council_GetUsersDivisions";
                System.Data.Common.DbCommand dbCommand = this.securityDb.GetStoredProcCommand(sqlCommand);
                this.securityDb.AddInParameter(dbCommand, "userID", DbType.String, this._userId);
                this.securityDb.AddInParameter(dbCommand, "deptID", DbType.String, deptID);
                return this.securityDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUserITAdminRole()
        {
            bool isUserInRole;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_IsUserInRole";

            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._userId, "IT Admin");
            try
            {
                isUserInRole = Convert.ToBoolean(db.ExecuteScalar(dbCommand));
                return isUserInRole;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUserCityManagerRole()
        {
            bool isUserInRole;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_IsUserInRole";

            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._userId, "City Manager");
            try
            {
                isUserInRole = Convert.ToBoolean(db.ExecuteScalar(dbCommand));
                return isUserInRole;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool IsUserCounciRole()
        {
            bool isUserInRole;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_IsUserInRole";

            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._userId, "Council");
            try
            {
                isUserInRole = Convert.ToBoolean(db.ExecuteScalar(dbCommand));
                return isUserInRole;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUSerDeptRole()
        {
            bool isUserInRole;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_IsUserInRole";

            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._userId, "Department");
            try
            {
                isUserInRole = Convert.ToBoolean(db.ExecuteScalar(dbCommand));
                return isUserInRole;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUserDeptHeadRole()
        {
            bool isUserInRole;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_IsUserInRole";

            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._userId, "Department Head");
            try
            {
                isUserInRole = Convert.ToBoolean(db.ExecuteScalar(dbCommand));
                return isUserInRole;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUserDivRole()
        {
            bool isUserInRole;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_IsUserInRole";

            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._userId, "Divisionfeg");
            try
            {
                isUserInRole = Convert.ToBoolean(db.ExecuteScalar(dbCommand));
                return isUserInRole;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
	}
}

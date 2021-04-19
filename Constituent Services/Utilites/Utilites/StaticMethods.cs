using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Utilites
{
    public class StaticMethods
    {
        public StaticMethods()
        {

        }
        public static System.Data.DataSet GetAllUsers()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "GetDepartmentUsers";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            DataSet userList = null;
            userList = db.ExecuteDataSet(dbCommand);
            return userList;
        }

        public static System.Data.DataSet GetUsersNameAndDept()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_GetUsersNameDept";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            DataSet userList = null;
            userList = db.ExecuteDataSet(dbCommand);
            return userList;
        }
        public static void LogUsersLogOut(string SessionId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_LogUserLogOut";

            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, SessionId);
            db.ExecuteNonQuery(dbCommand);
        }
        public static DataSet GetUsersCurrentlyLoggedIn()
        {
            DataSet ds;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_GetUsersCurrentlyLoggedIn";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }
        public static System.Data.DataSet SelectAdminOVerDueIncidents()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SelectAdminOverDueIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }

        public static System.Data.DataSet LoadCatagories()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_LoadCatagories";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            return db.ExecuteDataSet(dbCommand);
        }

        public static System.Data.DataSet SelectNewIncidents()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SelectNewIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }
        public static System.Data.DataSet SelectAdminIncidents(string status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SelectAdminIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, status);
            return db.ExecuteDataSet(dbCommand);
        }
        public static System.Data.DataSet SelectDepartmentIncidents(int departmentId, string status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SelectDepartmentIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, departmentId, status);
            return db.ExecuteDataSet(dbCommand);
        }

        public static System.Data.DataSet SelectDivisionIncidents(int divisionId, string status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SelectDivisionIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, divisionId, status);
            return db.ExecuteDataSet(dbCommand);
        }

        public static System.Data.DataSet SearchAdminIncidents(int IncidentNumber, string FirstName, string LastName, int ProblemTypeId, string Council, string Address, string Description, System.DateTime MinOpenDate, System.DateTime MaxOpenDate, string Status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SearchAdminIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, IncidentNumber, FirstName, LastName, ProblemTypeId, Council, Address, Description, MinOpenDate, MaxOpenDate, Status);
            try
            {
                return db.ExecuteDataSet(dbCommand);
            }
            catch (SqlException ex)
            {
                string help = ex.ToString();
                string help2 = help;
                return db.ExecuteDataSet(dbCommand);
            }
        }
        public static System.Data.DataSet SearchDepartmentIncidents(int IncidentNumber, string FirstName, string LastName, int ProblemTypeId, string Council, string Address, string Description, System.DateTime MinOpenDate, System.DateTime MaxOpenDate, string Status, int departmentId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SearchDepartmentIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, IncidentNumber, FirstName, LastName, ProblemTypeId, Council, Address, Description, MinOpenDate, MaxOpenDate, Status, departmentId);

            return db.ExecuteDataSet(dbCommand);

        }
        public static System.Data.DataSet SearchDivisionIncidents(int IncidentNumber, string FirstName, string LastName, int ProblemTypeId, string Council, string Address, string Description, System.DateTime MinOpenDate, System.DateTime MaxOpenDate, string Status, int divisionId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SearchDivisionIncidents";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, IncidentNumber, FirstName, LastName, ProblemTypeId, Council, Address, Description, MinOpenDate, MaxOpenDate, Status, divisionId);
            try
            {
                return db.ExecuteDataSet(dbCommand);
            }
            catch (SqlException ex)
            {
                string help = ex.ToString();
                string help2 = help;
                return db.ExecuteDataSet(dbCommand);
            }
        }



        public static System.Data.DataSet SearchAssignments(int IncidentNumber, int Department, int Division, System.DateTime MinAssignmentDate, System.DateTime MaxAssignmentDate, string Resolution)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SearchAssignments";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, IncidentNumber, Department, Division, MinAssignmentDate, MaxAssignmentDate, Resolution);
            return db.ExecuteDataSet(dbCommand);
        }

        public static System.Data.DataSet GetCouncilDistricts()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_GetCouncilDistricts";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            DataSet ds;
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }

    }
}

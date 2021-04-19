using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace User_Administration
{
    class AdminManager
    {
        public AdminManager()
        {

        }
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public static System.Data.DataSet GetAllUsers()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "GetAllUsers";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns></returns>
        public static System.Data.DataSet GetAllRoles()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "GetAllRoles";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <returns></returns>
        public static System.Data.DataSet GetDepartments()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "GetDepartments";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Gets the divisions.
        /// </summary>
        /// <param name="departId">The depart id.</param>
        /// <returns></returns>
        public static System.Data.DataSet GetDivisions(int departId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "GetDivision";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "deptId", DbType.Int32, departId);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Loads the catagories.
        /// </summary>
        /// <returns></returns>
        public static System.Data.DataSet LoadCatagories()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_LoadCatagories";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Users the name valid.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static bool UserNameValid(string user)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "UserNameValid";

                System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@name", DbType.String, user);
                int count;
                bool isValid;

                count = Convert.ToInt32(db.ExecuteScalar(dbCommand));
                if (count <= 0)
                {
                    isValid = true;
                }
                else
                    isValid = false;

                return isValid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public static void DeleteUser(string userName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "DeleteUserByName";
                System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "name", DbType.String, userName);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

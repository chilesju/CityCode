using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace User_Administration
{
    class RoleManager
    {
        public RoleManager()
        {

        }



        /// <summary>
        /// Roles the name valid.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public static bool RoleNameValid(string role)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "GetRoleIdByName";
                bool isValid;
                System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "@name", DbType.String, role);
                db.AddOutParameter(dbCommand, "@roleID", DbType.Int32, 4);
                db.ExecuteScalar(dbCommand);
                object obj1 = db.GetParameterValue(dbCommand, "roleID");
                if(obj1 == DBNull.Value)
                {
                    isValid=true;
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
        /// Modifies the name of the role.
        /// </summary>
        /// <param name="roleID">The role ID.</param>
        /// <param name="roleName">Name of the role.</param>
        public static void ModifyRoleName(int roleID, string roleName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "UpdateRoleById";
                System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, roleID, roleName);
                db.ExecuteNonQuery(dbCommand);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        public static void CreateRole(string roleName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "InsertRole";
                System.Data.Common.DbCommand dbCommand =db.GetStoredProcCommand(sqlCommand, roleName);
                db.ExecuteScalar(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Gets the users in role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public static System.Data.DataSet GetUsersInRole(string roleName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "GetUserInRoleByName";
                System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "roleName", DbType.String, roleName);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteRole(string roleName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "DeleteRoleByName";
                System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "name", DbType.String, roleName);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

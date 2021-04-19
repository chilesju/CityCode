using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

namespace Utilites
{
    public class CodeCase
    {
        public CodeCase()
        {

        }
        public static void InputCase(int incidentNumber, string caseNumber, string status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_InsertCodeCase";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, incidentNumber, caseNumber, status);
            db.ExecuteNonQuery(dbCommand);
        }

        public static void RemoveCase(int incidentNumber)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_RemoveCodeCase";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, incidentNumber);
            db.ExecuteNonQuery(dbCommand);
        }

        public static string SelectCodeCase(int incidentNumber)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SelectCodeCase";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, incidentNumber);
            return db.ExecuteScalar(dbCommand).ToString();
        }

    }
}

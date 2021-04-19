using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Utilites
{
	
	public class History
	{
		public History()
		{
			
		}
		public static System.Data.DataSet GetHistory(int incidentId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "Council_GetHistory";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, incidentId);
			DataSet divisionDataSet = null;
            divisionDataSet = db.ExecuteDataSet(dbCommand);
			return divisionDataSet;
		}
	}
}

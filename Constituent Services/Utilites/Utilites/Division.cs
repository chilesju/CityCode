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
	
	public class Division
	{
		public Division()
		{
			
		}
		private int _divisionId;
		private int _departmentId;
		private string _divisionString;
		private int _divisionHead;

		public int DivisionId
		{
			get { return _divisionId;}
			set { _divisionId=value;}
		}
		public string DivisionString
		{
			get { return _divisionString;}
			set { _divisionString= value;}
		}
		public int DepartmentId
		{
			get { return _departmentId;}
			set { _departmentId=value;}
		}
		public int DivisionHead
		{
			get { return _divisionHead;}
			set { _divisionHead=value;}
		}
		public static DataSet  GetDivision(int departmentId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "Council_GetDivisions";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, departmentId);
			DataSet divisionDataSet = null;
            divisionDataSet = db.ExecuteDataSet(dbCommand);
			return divisionDataSet;
		
		}
	}
}

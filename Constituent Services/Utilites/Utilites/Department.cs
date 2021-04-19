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
	
	public class Department
	{
		private int _departmentId;
		private string _deprtmentString;

		public Department()
		{
			
		}

        /// <summary>
        /// Gets the deaprtments.
        /// </summary>
        /// <returns></returns>
		public static DataSet  GetDeaprtments()
		{
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_GetDepartments";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                DataSet departmentDataSet = null;
                departmentDataSet = db.ExecuteDataSet(dbCommand);
                return departmentDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
		
		}
        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
        public string DeprtmentString
        {
            get { return _deprtmentString; }
            set { _deprtmentString = value; }
        }

	}
}

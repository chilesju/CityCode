using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Utilites
{
	
	public class Category
	{
        public Category()
		{
			
		}

		public static DataSet LoadCatagoryAreaForDepartment(int DepartmentId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "Council_LoadCatagoriesForDepartment";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, DepartmentId);
			DataSet productsDataSet = null;
            productsDataSet = db.ExecuteDataSet(dbCommand);
			return productsDataSet;
		}
		public static DataSet LoadCatagoryAreaForDivision(int DivisionId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "Council_LoadCatagoriesForDivision";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, DivisionId);
			DataSet productsDataSet = null;
            productsDataSet = db.ExecuteDataSet(dbCommand);
			return productsDataSet;
		}
		public static DataSet LoadCatagoryAreaForAdmin()
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "Council_LoadCatagoriesForAdmin";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			DataSet productsDataSet = null;
            productsDataSet = db.ExecuteDataSet(dbCommand);
			return productsDataSet;
		}
		public static DataSet LoadAllProblemTypes()
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "Council_LoadAllProblemTypes";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			DataSet productsDataSet = null;
            productsDataSet = db.ExecuteDataSet(dbCommand);
			return productsDataSet;
		}
		public static int GetCatagoryId(string Catagory)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "Council_GetCatagoryId";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, Catagory);
			int catagory;
            catagory = (int)db.ExecuteScalar(dbCommand);
			return catagory;
		}

        public static int GetCategoriesDeptID(int categoryID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_GetCategoriesDeprtmentID";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, categoryID);
            int depatment;
            depatment = (int)db.ExecuteScalar(dbCommand);
            return depatment;
        }

        public static DataSet GetUsersAssigedToCatagory(string Catgory)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_GetUsersAssingedToCatagory";
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, Catgory);
            return db.ExecuteDataSet(dbCommand);
        }

 

 

	}
}

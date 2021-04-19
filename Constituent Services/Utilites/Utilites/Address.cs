using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Utilites
{
	
	public class Address
	{
		private string pin;
		private string streetNumber;
		private string streetName;
		private string streetDirection;
		private string streetSuffix;
		private int coucil;
		private int niaNumber;
		private string niaName;


		public Address()
		{
			
		}
		public string Pin
		{
			get { return pin;}
			set { pin=value;}
		}
		public string StreetNumber
		{	get { return streetNumber;}
			set { streetNumber=value;}
		}
		public string StreetName
		{
			get { return streetName;}
			set { streetName=value;}
		}
		public string StreetDirection
		{
			get { return streetDirection;}
			set { streetDirection=value;}
		}
		public string StreetSuffix
		{
			get { return streetSuffix;}
			set { streetSuffix=value;}
		}
		public int Coucil
		{
			get { return coucil;}
			set { coucil=value;}
		}
		public int NiaNumber
		{
			get { return niaNumber;}
			set { niaNumber=value;}
		}
		public string NiaName
		{
			get { return niaName;}
			set { niaName=value;}
		}

		public static DataSet LocateAddressFromParcelTableUsingStreetNum(string address)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "Council_SearchParcelUsingStreetNmber";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, address);

			// DataSet that will hold the returned results		
			DataSet productsDataSet = null;

            productsDataSet = db.ExecuteDataSet(dbCommand);

			// Note: connection was closed by ExecuteDataSet method call 

			return productsDataSet;


		}
	}
}

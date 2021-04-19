using System;
using System.Text.RegularExpressions;

namespace Utilites
{
	public class CleanString
	{
		public CleanString()
		{
			
		}
		public static string CleanInput(string strIn)
		{
			// Replace invalid characters with empty strings.
			strIn = strIn.ToUpper();
			string cleanString = Regex.Replace(strIn, @"[^\w\.)(@-]"," ");
			//Replace possiable Implicit Transactions with Pleural Drop,Truncate,Delete,Insert,Alert Table,Revoke,Update,Create
			cleanString= Regex.Replace(cleanString,@"DROP","DROPS");
			cleanString= Regex.Replace(cleanString,@"DELETE","DELETS");
			cleanString= Regex.Replace(cleanString,@"INSERT","INSERTS");
			cleanString= Regex.Replace(cleanString,@"TRUNCATE","TRUNCATES");
			cleanString= Regex.Replace(cleanString,@"ALTER TABLE","ALTER TABLES");
			cleanString= Regex.Replace(cleanString,@"REVOKE","REVOKES");
			cleanString= Regex.Replace(cleanString,@"UPDATE","UPDATES");
			cleanString= Regex.Replace(cleanString,@"CREATE","CREATES");
			cleanString= Regex.Replace(cleanString,@"EXECUTE","EXECUTES");

			return cleanString; 
		}

	}
}

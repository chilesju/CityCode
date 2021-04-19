using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.Mail;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

namespace Utilites
{
	
	public class Email
	{
		public Email()
		{
			
		}

		public static System.Data.DataSet GetEmailHistory(int incidentId)
		{
			DataSet ds;
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "Council_GetEmailHistory";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, incidentId);
            ds = db.ExecuteDataSet(dbCommand);
			return ds;

		}
		public static void InsertEmailHistory(int incidentId,string emailName)
		{

			try
			{
				Database db = DatabaseFactory.CreateDatabase();
				string sqlCommand = "Council_InsertEmailHistroy";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, incidentId, emailName);
                db.ExecuteNonQuery(dbCommand);
				
			}
			catch
			{

			}

		}
		public static void SendEmail(string toUserName, string fromUserName)
		{
			try
			{
				
				string strTo = toUserName;
				string strFrom = fromUserName;
				//string strSubject = "Burning Permit Notification";
				SmtpMail.SmtpServer = "mail.topeka.org"; 
				/*SmtpMail.Send(strFrom, strTo, strSubject,
					"The Topeka Fire Department has received your request for an inspection. \n"+ 
					"NOTE: THIS IS NOT THE ACUTAL PERMIT \n"+ 
					"On the day you wish to burn, notify Topeka Fire Department at 785-368-9514 before and after burning. \n"+
					"For all other issues or questions concerning this request please call 785-368-4000. \n"+
					"If you are unable to sign the permit at the burning location, then you will need to pick up your permit at: \n"+
					"Topeka Fire Academy \n"+ 
					"324 SE Jefferson \n"+ 
					"Topeka , KS 66607 \n\n"+
					"Permit Number: " + lblPermitNumber.Text+ "\n"+ "Issue Date: " +lblIssueDate.Text + "\n" + "Burn Address: " +lblBurningAddress.Text +
					"\n\nNOTE: If you are going to pick up the permit you have TWO weeks after the issue date to pick up the permit.  If you fail to pick up the permit within these two weeks you must reapply for another permit." );*/
				

			}
			catch{}



		}
	}
}

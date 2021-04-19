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
    public class AssingmentComments
    {

        private int _assignmentId;
        private string _comment;
        private int _commentId;
        private DateTime _dateEntered;
        private DateTime _dateUpdated;
        private string _personUpdating;

        public static int InsertAssignmentComment(int assignmentId, string comment, string user)
        {
            try
            {
                Database database = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_InsertAssignmentComment";
                DbCommand dbCommand = database.GetStoredProcCommand(sqlCommand, assignmentId, comment, user);
                database.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch
            {
                return -1;
            }

        }

        public static DataSet SelectAssignmentComments(int assignmentId)
        {
            Database database = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_SelectAssignmentComments";
            DbCommand dbCommand = database.GetStoredProcCommand(sqlCommand, assignmentId);
            return database.ExecuteDataSet(dbCommand);
        }

        public static int UpdateAssignmentComment(int commentId, string comment, string user)
        {
            try
            {
                Database database = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_UpdateAssignmentComments";
                 DbCommand dbCommand = database.GetStoredProcCommand(sqlCommand, commentId, comment, user);
                database.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public int AssignemtnId
        {
            get
            {
                return this._assignmentId;
            }
            set
            {
                this._assignmentId = value;
            }
        }

        public string Comment
        {
            get
            {
                return this._comment;
            }
            set
            {
                this._comment = value;
            }
        }

        public int CommentId
        {
            get
            {
                return this._commentId;
            }
            set
            {
                this._commentId = value;
            }
        }

        public DateTime DateEntered
        {
            get
            {
                return this._dateEntered;
            }
            set
            {
                this._dateEntered = value;
            }
        }

        public DateTime DateUpdated
        {
            get
            {
                return this._dateUpdated;
            }
            set
            {
                this._dateUpdated = value;
            }
        }

        public string PersonUpdating
        {
            get
            {
                return this._personUpdating;
            }
            set
            {
                this._personUpdating = value;
            }
        }

    }

}

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

    public class Assignment
    {
        private int _assignmentId;
        private int _incidentId;
        private int _departmentId;
        private int _divisionId;
        private string _resolution;
        private System.DateTime _lastUpdate;
        private string _personUpdating;
        private System.DateTime _dateSent;


        /// <summary>
        /// Initializes a new instance of the <see cref="Assignment"/> class.
        /// </summary>
        /// <param name="IncidentId">The incident id.</param>
        /// <param name="AssignmentType">Type of the assignment.</param>
        /// <param name="PersonUpdating">The person updating.</param>
        public Assignment(int IncidentId, int AssignmentType, string PersonUpdating)
        {
            this._incidentId = IncidentId;
            this._personUpdating = PersonUpdating;
            SetDefaultValues();
        }

        public Assignment()
        {

        }


        private void SetDefaultValues()
        {
            _departmentId = 0;
            _divisionId = 0;
            _lastUpdate = System.DateTime.Now;
            _resolution = "";
        }

        /// <summary>
        /// Gets all incident assignments.
        /// </summary>
        /// <param name="IncidentId">The incident id.</param>
        /// <returns></returns>
        public AssignmentCollection GetAllIncidentAssignments(int IncidentId)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_GetAssignments";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, IncidentId);
                DataSet ds;
                ds = db.ExecuteDataSet(dbCommand);
                AssignmentCollection collectionOfAssignments = new AssignmentCollection();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Assignment assignment = new Assignment();
                    assignment.AssignemtnId = Convert.ToInt32(r["AssignmentId"]);
                    assignment.DepartmentId = Convert.ToInt32(r["DeptId"]);
                    assignment.DivisionId = Convert.ToInt32(r["DivId"]);
                    assignment.IncidentId = Convert.ToInt32(r["IncidentNumber"]);
                    assignment.LastUpdate = Convert.ToDateTime(r["LastUpdated"]);
                    assignment.Resolution = (r["Resolution"]).ToString();
                    collectionOfAssignments.Add(assignment);
                }
                return collectionOfAssignments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Counts the number of assignments.
        /// </summary>
        /// <returns></returns>
        public int CountNumberOfAssignments()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_CountAssignment";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, _incidentId);
                int count = (int)db.ExecuteScalar(dbCommand);
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates the assignemnt.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public int UpdateAssignemnt(string user)
        {
           
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_UpdateAssignment";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, _divisionId, _departmentId, _incidentId, _resolution, user);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                return 1;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Selects the additonal users to assignments.
        /// </summary>
        /// <param name="incidentId">The incident id.</param>
        /// <returns></returns>
        public DataSet SelectAdditonalUsersToAssignments(int incidentId)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_SelectAdditionalUserToAssignemnt";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, incidentId);
                DataSet userSet = db.ExecuteDataSet(dbCommand);
                return userSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inserts the additional user to assignemnt.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="incidentId">The incident id.</param>
        public void InsertAdditionalUserToAssignemnt(int userId, int incidentId)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_InsertAdditionalUserToAssignemnt";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, userId, incidentId);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inserts the assignemnt.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public int InsertAssignemnt(string user)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_InsertAssignment";

            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, _divisionId, _departmentId, _incidentId, _resolution, user, _dateSent);
            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Inserts the assignemnt with email.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="address">The address.</param>
        /// <param name="citizen">The citizen.</param>
        /// <param name="problemType">Type of the problem.</param>
        /// <param name="problem">The problem.</param>
        /// <returns></returns>
        public int InsertAssignemntWithEmail(string user, string address, int citizen, int problemType, string problem)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Council_InsertAssignmentWithNewEmail";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, _divisionId, _departmentId, _incidentId, address, problemType, citizen, problem, user);
            try
            {
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reassigns the assignemnt.
        /// </summary>
        /// <param name="user">The user.</param>
        public void ReassignAssignemnt(string user)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_ReassignAssignment";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._divisionId, this._departmentId, this._incidentId, user);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inserts the assignemnt later on.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public int InsertAssignemntLaterOn(string user)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_InsertAssignmentLaterOn";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, this._divisionId, this._departmentId, this._incidentId, this._resolution, user);
                return Convert.ToInt32(db.ExecuteScalar(dbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Resolution
        {
            get { return _resolution; }
            set { _resolution = value; }
        }

        public System.DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }
        public int AssignemtnId
        {
            get { return _assignmentId; }
            set { _assignmentId = value; }
        }
        public int IncidentId
        {
            get { return _incidentId; }
            set { _incidentId = value; }
        }
        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
        public int DivisionId
        {
            get { return _divisionId; }
            set { _divisionId = value; }
        }
        public string PersonUpdating
        {
            get { return _personUpdating; }
            set { _personUpdating = value; }
        }


        public System.DateTime DateSent
        {
            get { return _dateSent; }
            set { _dateSent = value; }
        }

    }
}

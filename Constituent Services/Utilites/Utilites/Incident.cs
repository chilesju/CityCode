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


	public class Incident
	{
		private int _incidentId;
		private string _address;
		private System.DateTime _openDate;
		private System.DateTime _modifyDate;
		private System.DateTime _pendingDate;
		private System.DateTime _courtDate;
		private string _councilDist;
		private int _problemTypeId;
		private string _incidentDisc;
		private string _openclose;
		private string _sender;
		private int _citizenId;
		private string _comments;
		private CitizenCollection _citizenCollection;
		private AssignmentCollection _assignmentCollection;
		private string _personUpdating;
		private int _contact;
        private string _insertedBy;
        private bool _requstingClosure;
        private bool _hasCitizenBeenContacted;


		public Incident()
		{
			
		}
		public Incident(int IncidentId)
		{
			_incidentId= IncidentId;
            SetIncidentValues();
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="Incident"/> class.
        /// </summary>
        /// <param name="Address">The address.</param>
        /// <param name="ProblemTypeId">The problem type id.</param>
        /// <param name="ProblemDisc">The problem disc.</param>
        /// <param name="CitizenId">The citizen id.</param>
        /// <param name="Contact">The contact.</param>
		public Incident(string Address, int ProblemTypeId, string ProblemDisc,int CitizenId, int Contact)
		{
			this._address=Address;
			this._problemTypeId=ProblemTypeId;
			this._incidentDisc=ProblemDisc;
			this._citizenId=CitizenId;
			this._contact = Contact;
			
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="Incident"/> class.
        /// </summary>
        /// <param name="Address">The address.</param>
        /// <param name="ProblemTypeId">The problem type id.</param>
        /// <param name="IncidentDisc">The incident disc.</param>
        /// <param name="CouncilId">The council id.</param>
        /// <param name="Status">The status.</param>
        /// <param name="Sender">The sender.</param>
        /// <param name="Pending">The pending.</param>
        /// <param name="IncidentId">The incident id.</param>
        /// <param name="Contact">The contact.</param>
        /// <param name="CourtDate">The court date.</param>
        /// <param name="PersonUpdating">The person updating.</param>
		public Incident(string Address, int ProblemTypeId, string IncidentDisc,string CouncilId,string Status,string Sender, System.DateTime Pending,int IncidentId, int Contact, System.DateTime CourtDate , string PersonUpdating)
		{
			this._address= Address;
			this._problemTypeId= ProblemTypeId;
			this._incidentDisc= IncidentDisc;
			this._councilDist= CouncilId;
			this._openclose= Status;
			this._sender= Sender;
			this._pendingDate= Pending;
			this._incidentId= IncidentId;
			this._contact= Contact;
			this._courtDate= CourtDate;
			this.PersonUpdating= PersonUpdating;
		}

        /// <summary>
        /// Sets the incident values.
        /// </summary>
        public void SetIncidentValues()
        {
            try
            {
                Database database = DatabaseFactory.CreateDatabase();
                string str = "Council_GetIndividualIncident";
                DbCommand dbCommand = database.GetStoredProcCommand(str, this._incidentId);
                DataSet set = database.ExecuteDataSet(dbCommand);
                if (set.Tables[0].Rows.Count < 1)
                {

                }
                else
                {
                    this._address = Convert.ToString(set.Tables[0].Rows[0]["Address"]);
                    this._openDate = Convert.ToDateTime(set.Tables[0].Rows[0]["Open Date"]);
                    this._incidentDisc = Convert.ToString(set.Tables[0].Rows[0]["Problem Disc"]);
                    this._councilDist = Convert.ToString(set.Tables[0].Rows[0]["CouncilDistId"]);
                    this._problemTypeId = Convert.ToInt32(set.Tables[0].Rows[0]["ProblemTypeId"]);
                    this._openclose = Convert.ToString(set.Tables[0].Rows[0]["OpenClose"]);
                    this._modifyDate = Convert.ToDateTime(set.Tables[0].Rows[0]["Modified"]);
                    this._insertedBy = Convert.ToString(set.Tables[0].Rows[0]["InsertedBy"]);
                    this._contact = Convert.ToInt32(set.Tables[0].Rows[0]["Contact"]);
                    this._hasCitizenBeenContacted = Convert.ToBoolean(set.Tables[0].Rows[0]["CitizenContacted"]);
                    this._requstingClosure = Convert.ToBoolean(set.Tables[0].Rows[0]["RequestingClosure"]);
                    if (set.Tables[0].Rows[0]["Pending"] == DBNull.Value)
                    {
                        this._pendingDate = DateTime.MinValue;
                    }
                    else
                    {
                        this._pendingDate = Convert.ToDateTime(set.Tables[0].Rows[0]["Pending"]);
                    }
                    if (set.Tables[0].Rows[0]["CourtDate"] == DBNull.Value)
                    {
                        this._courtDate = DateTime.MinValue;
                    }
                    else
                    {
                        this._courtDate = Convert.ToDateTime(set.Tables[0].Rows[0]["CourtDate"]);
                    }
                    this._citizenCollection = new CitizenCollection();
                    Citizen citizen = new Citizen(Convert.ToInt32(set.Tables[0].Rows[0]["CitizenId"]));
                    if (citizen.GetCitizen())
                    {
                        this._citizenCollection.Add(citizen);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Inserts the council dist.
        /// </summary>
        /// <param name="CouncilDist">The council dist.</param>
        public void InsertCouncilDist(string CouncilDist)
        {

            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_InsertCouncilDist";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, CouncilDist, this._incidentId);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Inserts the incident.
        /// </summary>
        /// <returns></returns>
		public int InsertIncident(string isertedBy)
		{
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_InsertIncident";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, _address, _problemTypeId, _incidentDisc, "O", _citizenId, _contact, isertedBy);
                int id= Convert.ToInt32(db.ExecuteScalar(dbCommand));
                this._incidentId=id;
                return id; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="incidentId">The incident id.</param>
        /// <param name="status">The status.</param>
        /// <returns></returns>
		public bool UpdateStatus(int incidentId, string status)
		{
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_UpdateStatus";
                DbCommand dbCommand;

                //court Date != null and pending date != null
                dbCommand = db.GetStoredProcCommand(sqlCommand, _personUpdating, incidentId, status);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        /// <summary>
        /// Updates the incident.
        /// </summary>
        /// <returns></returns>
		public bool UpdateIncident()
		{
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_UpdateIncident";
                DbCommand dbCommand;
                if (this._pendingDate == DateTime.MinValue)
                {
                    if (this._courtDate == DateTime.MinValue)
                    {
                        dbCommand = db.GetStoredProcCommand(sqlCommand, this._address, this._councilDist, this._problemTypeId, this._incidentDisc, this._openclose, DBNull.Value, this._incidentId, this._contact, DBNull.Value, this._personUpdating, this._requstingClosure, this._hasCitizenBeenContacted);
                    }
                    else
                    {
                        dbCommand = db.GetStoredProcCommand(sqlCommand, this._address, this._councilDist, this._problemTypeId, this._incidentDisc, this._openclose, DBNull.Value, this._incidentId, this._contact, this._courtDate, this._personUpdating, this._requstingClosure, this._hasCitizenBeenContacted);
                    }
                }
                else if (this._courtDate == DateTime.MinValue)
                {
                    dbCommand = db.GetStoredProcCommand(sqlCommand, this._address, this._councilDist, this._problemTypeId, this._incidentDisc, this._openclose, this._pendingDate, this._incidentId, this._contact, DBNull.Value, this._personUpdating, this._requstingClosure, this._hasCitizenBeenContacted);
                }
                else
                {
                    dbCommand = db.GetStoredProcCommand(sqlCommand, this._address, this._councilDist, this._problemTypeId, this._incidentDisc, this._openclose, this._pendingDate, this._incidentId, this._contact, this._courtDate, this._personUpdating, this._requstingClosure, this._hasCitizenBeenContacted);
                }
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}


        /// <summary>
        /// Gets the pending date.
        /// </summary>
        /// <returns></returns>
        public System.DateTime GetPendingDate()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_GetPendingDate";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, _incidentId);
                DataSet ds;
                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows[0]["Pending"] == DBNull.Value)
                {
                    _pendingDate = System.DateTime.MinValue;

                }
                else
                    _pendingDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["Pending"]);

                return _pendingDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Utilites.CitizenCollection CitizenCollection
        {
            get { return _citizenCollection; }
            set { _citizenCollection = value; }
        }
        public Utilites.AssignmentCollection AssignmentCollection
        {
            get { return _assignmentCollection; }
            set { _assignmentCollection = value; }
        }
        public System.DateTime PendingDate
        {
            get { return _pendingDate; }
            set { _pendingDate = value; }
        }
        public System.DateTime CourtDate
        {
            get { return _courtDate; }
            set { _courtDate = value; }
        }
        public System.DateTime OpenDate
        {
            get { return _openDate; }
            set { _openDate = value; }
        }
        public System.DateTime ModifyDate
        {
            get { return _modifyDate; }
            set { _modifyDate = value; }
        }
        public int Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
        public int IncidentId
        {
            get { return _incidentId; }
            set { _incidentId = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string CouncilDist
        {
            get { return _councilDist; }
            set { _councilDist = value; }
        }
        public string IncidentDisc
        {
            get { return _incidentDisc; }
            set { _incidentDisc = value; }
        }
        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        public string Openclose
        {
            get { return _openclose; }
            set { _openclose = value; }
        }
        public string Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }
        public string PersonUpdating
        {
            get { return _personUpdating; }
            set { _personUpdating = value; }
        }
        public int ProblemTypeId
        {
            get { return _problemTypeId; }
            set { _problemTypeId = value; }
        }

        public int CitizenId
        {
            get { return _citizenId; }
            set { _citizenId = value; }
        }

        public string InsertedBy
        {
            get
            {
                return this._insertedBy;
            }
            set
            {
                this._insertedBy = value;
            }
        }
        public bool RequstingClosure
        {
            get
            {
                return this._requstingClosure;
            }
            set
            {
                this._requstingClosure = value;
            }
        }
        public bool HasCitizenBeenContacted
        {
            get
            {
                return this._hasCitizenBeenContacted;
            }
            set
            {
                this._hasCitizenBeenContacted = value;
            }
        }
	}
}

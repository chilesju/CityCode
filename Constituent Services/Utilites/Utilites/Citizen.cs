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
	
	public class Citizen
	{
		private int _citizenId;
		private string _firstName;
		private string _lastName;
		private string _phoneNumber;
		private string _email;
		private CitizenCollection _citizenCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Citizen"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
		public Citizen(int id)
		{
			_citizenId=id;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="Citizen"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="email">The email.</param>
		public Citizen(string firstName,string lastName,string phoneNumber,string email)
		{	
			_firstName=firstName;
			_lastName=lastName;
			_phoneNumber=phoneNumber;
			_email=email;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="Citizen"/> class.
        /// </summary>
        /// <param name="citizenId">The citizen id.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="email">The email.</param>
		public Citizen(int citizenId,string firstName,string lastName,string phoneNumber,string email)
		{	
			_citizenId = citizenId;
			_firstName=firstName;
			_lastName=lastName;
			_phoneNumber=phoneNumber;
			_email=email;
		}
        /// <summary>
        /// Inserts the citizen.
        /// </summary>
        /// <returns></returns>
		public int InsertCitizen()
		{
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_InsertCitizen";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, _firstName, _lastName, _phoneNumber, _email);
                int citizenId;
                citizenId = (int)db.ExecuteScalar(dbCommand);
                return citizenId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}
        /// <summary>
        /// Updates the citizen.
        /// </summary>
        /// <returns></returns>
		public int UpdateCitizen()
		{
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_UpdateCitizen";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, _citizenId, _firstName, _lastName, _phoneNumber, _email);
                int citizenId;
                citizenId = (int)db.ExecuteScalar(dbCommand);
                return citizenId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        /// <summary>
        /// Gets the citizen.
        /// </summary>
        /// <returns></returns>
        public bool GetCitizen()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "Council_GetCitizen";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand, _citizenId);
                DataSet ds;
                ds = db.ExecuteDataSet(dbCommand);


                if (ds.Tables[0].Rows.Count < 1)
                    return false;

                _firstName = (ds.Tables[0].Rows[0]["First Name"]).ToString();
                _lastName = (ds.Tables[0].Rows[0]["Last Name"]).ToString();
                _email = (ds.Tables[0].Rows[0]["Email"]).ToString();
                _phoneNumber = (ds.Tables[0].Rows[0]["Phone"]).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CitizenCollection CitizenCollection
        {
            get { return _citizenCollection; }
            set { _citizenCollection = value; }
        }
        public int CitizenId
        {
            get { return _citizenId; }
            set { _citizenId = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }


        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
	}
}

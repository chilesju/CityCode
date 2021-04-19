namespace CLAS.BusinessLogicLayer
{
    using CLAS;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlTypes;

    public class License
    {
        public License()
        {
        }

        public License(string licNo)
        {
            this._licNo = licNo;
        }

        public static DataSet EasySearch(string searchValue)
        {
            return SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_EasySearch", new object[] { searchValue });
        }

        public DataSet GetMailMerge()
        {
            return SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_MailMerge", new object[] { 
                this._licNo, this._licStat, this._aName, this._oName, this._oAddr, this._issueDate1, this._issueDate2, this._expDate1, this._expDate2, this._paidDate1, this._paidDate2, this._stDate1, this._stDate2, this._liqLic, this._vin, this._typeCode, 
                this._checkNo, this._lName, this._bName, this._bAddr, this._ssn, this._payType, this._acctNo, this._driverLic, this._salesTax, this._legalId
             });
        }

        public DataSet GetSearchResult()
        {
            return SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_ListLicense", new object[] { 
                this._licNo, this._licStat, this._aName, this._oName, this._oAddr, this._issueDate1, this._issueDate2, this._expDate1, this._expDate2, this._paidDate1, this._paidDate2, this._stDate1, this._stDate2, this._liqLic, this._vin, this._typeCode, 
                this._checkNo, this._lName, this._bName, this._bAddr, this._ssn, this._payType, this._acctNo, this._driverLic, this._salesTax, this._legalId
             });
        }

        public string InsertLicense()
        {
            if (this._bondDate == DateTime.MinValue)
            {
                SqlDateTime time1 = SqlDateTime.Null;
                this.bondDateParm = time1;
            }
            else
            {
                this.bondDateParm = this._bondDate;
            }
            if (this._insDate == DateTime.MinValue)
            {
                SqlDateTime time2 = SqlDateTime.Null;
                this.insDateParm = time2;
            }
            else
            {
                this.insDateParm = this._insDate;
            }
            if (this._expDate == DateTime.MinValue)
            {
                SqlDateTime time3 = SqlDateTime.Null;
                this.expDateParm = time3;
            }
            else
            {
                this.expDateParm = this._expDate;
            }
            if (this._issueDate == DateTime.MinValue)
            {
                SqlDateTime time4 = SqlDateTime.Null;
                this.isuDateParm = time4;
            }
            else
            {
                this.isuDateParm = this._issueDate;
            }
            return SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_InsertLicense", new object[] { 
                this._typeCode.ToUpper(), this._licStat, this._statDate.ToShortDateString(), this._aName.ToUpper(), this._owMgr.ToUpper(), this._dbaFor.ToUpper(), this.isuDateParm, this.expDateParm, this._paidDate, this._fee, this._payType, this._checkNo.ToUpper(), this._acctNo, this._notes.ToUpper(), this._driverLic.ToUpper(), this._ssn, 
                this._zoning.ToUpper(), this._salesTax.ToUpper(), this._insAmt, this.insDateParm, this._legalId.ToUpper(), this._bondAmt, this.bondDateParm, this._lName.ToUpper(), this._mAddr.ToUpper(), this._mCity.ToUpper(), this._mState.ToUpper(), this._mZip, this._oName.ToUpper(), this._oAddr.ToUpper(), this._oCity.ToUpper(), this._oState.ToUpper(), 
                this._oZip.ToUpper(), this._oPhone, this._bName.ToUpper(), this._bAddr.ToUpper(), this._bCity.ToUpper(), this._bState.ToUpper(), this._bZip, this._bPhone, this._liqLic.ToUpper(), this._vin.ToUpper(), this._emailAddress
             }).ToString();
        }

        public void RemoveLicense()
        {
            SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_RemoveLicense", new object[] { this._licNo });
        }

        public void SelectLicense()
        {
            DataSet set1 = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_SelectLicense", new object[] { this._licNo });
            this._licId = Convert.ToInt32(set1.Tables[0].Rows[0][0]);
            this._typeCode = Convert.ToString(set1.Tables[0].Rows[0][1]).ToUpper();
            this._licStat = Convert.ToString(set1.Tables[0].Rows[0][2]).ToUpper();
            this._statDate = Convert.ToDateTime(set1.Tables[0].Rows[0][3]);
            this._licNo = Convert.ToString(set1.Tables[0].Rows[0][4]);
            this._aName = Convert.ToString(set1.Tables[0].Rows[0][5]).ToUpper();
            this._owMgr = Convert.ToString(set1.Tables[0].Rows[0][6]).ToUpper();
            this._dbaFor = Convert.ToString(set1.Tables[0].Rows[0][7]).ToUpper();
            this._issueDate = (set1.Tables[0].Rows[0][8] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(set1.Tables[0].Rows[0][8]);
            this._expDate = (set1.Tables[0].Rows[0][9] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(set1.Tables[0].Rows[0][9]);
            this._paidDate = Convert.ToDateTime(set1.Tables[0].Rows[0][10]);
            this._fee = Convert.ToDecimal(set1.Tables[0].Rows[0][11]);
            this._payType = Convert.ToString(set1.Tables[0].Rows[0][12]).ToUpper();
            this._checkNo = Convert.ToString(set1.Tables[0].Rows[0][13]).ToUpper();
            this._acctNo = Convert.ToString(set1.Tables[0].Rows[0][14]);
            this._zoning = Convert.ToString(set1.Tables[0].Rows[0][15]).ToUpper();
            this._insAmt = Convert.ToDecimal(set1.Tables[0].Rows[0][0x10]);
            this._insDate = (set1.Tables[0].Rows[0][0x11] == DBNull.Value) ? DateTime.Now : Convert.ToDateTime(set1.Tables[0].Rows[0][0x11]);
            this._ssn = "";
            this._driverLic = "";
            this._salesTax = Convert.ToString(set1.Tables[0].Rows[0][20]).ToUpper();
            this._legalId = Convert.ToString(set1.Tables[0].Rows[0][0x15]).ToUpper();
            this._notes = Convert.ToString(set1.Tables[0].Rows[0][0x16]).ToUpper();
            this._emailAddress = Convert.ToString(set1.Tables[0].Rows[0][0x17]);
            this._bondDate = (set1.Tables[0].Rows[0][0x19] == DBNull.Value) ? DateTime.Now : Convert.ToDateTime(set1.Tables[0].Rows[0][0x19]);
            this._bName = Convert.ToString(set1.Tables[0].Rows[0][0x1a]).ToUpper();
            this._bAddr = Convert.ToString(set1.Tables[0].Rows[0][0x1b]).ToUpper();
            this._bCity = Convert.ToString(set1.Tables[0].Rows[0][0x1c]).ToUpper();
            this._bState = Convert.ToString(set1.Tables[0].Rows[0][0x1d]).ToUpper();
            this._bZip = Convert.ToString(set1.Tables[0].Rows[0][30]);
            this._bPhone = Convert.ToString(set1.Tables[0].Rows[0][0x1f]);
            this._liqLic = Convert.ToString(set1.Tables[0].Rows[0][0x20]).ToUpper();
            this._oName = Convert.ToString(set1.Tables[0].Rows[0][0x21]).ToUpper();
            this._oAddr = Convert.ToString(set1.Tables[0].Rows[0][0x22]).ToUpper();
            this._oCity = Convert.ToString(set1.Tables[0].Rows[0][0x23]).ToUpper();
            this._oState = Convert.ToString(set1.Tables[0].Rows[0][0x24]).ToUpper();
            this._oZip = Convert.ToString(set1.Tables[0].Rows[0][0x25]);
            this._oPhone = Convert.ToString(set1.Tables[0].Rows[0][0x26]);
            this._vin = Convert.ToString(set1.Tables[0].Rows[0][0x27]).ToUpper();
            this._lName = Convert.ToString(set1.Tables[0].Rows[0][40]).ToUpper();
            this._mAddr = Convert.ToString(set1.Tables[0].Rows[0][0x29]).ToUpper();
            this._mCity = Convert.ToString(set1.Tables[0].Rows[0][0x2a]).ToUpper();
            this._mState = Convert.ToString(set1.Tables[0].Rows[0][0x2b]).ToUpper();
            this._mZip = Convert.ToString(set1.Tables[0].Rows[0][0x2c]);
        }

        public void UpdateLicense()
        {
            if (this._bondDate == DateTime.MinValue)
            {
                SqlDateTime time1 = SqlDateTime.Null;
                this.bondDateParm = time1;
            }
            else
            {
                this.bondDateParm = this._bondDate;
            }
            if (this._insDate == DateTime.MinValue)
            {
                SqlDateTime time2 = SqlDateTime.Null;
                this.insDateParm = time2;
            }
            else
            {
                this.insDateParm = this._insDate;
            }
            if (this._expDate == DateTime.MinValue)
            {
                SqlDateTime time3 = SqlDateTime.Null;
                this.expDateParm = time3;
            }
            else
            {
                this.expDateParm = this._expDate;
            }
            if (this._issueDate == DateTime.MinValue)
            {
                SqlDateTime time4 = SqlDateTime.Null;
                this.isuDateParm = time4;
            }
            else
            {
                this.isuDateParm = this._issueDate;
            }
            SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_UpdateLicense", new object[] { 
                this._licNo, this._typeCode.ToUpper(), this._licStat, this._statDate, this._aName.ToUpper(), this._owMgr.ToUpper(), this._dbaFor.ToUpper(), this.isuDateParm, this.expDateParm, this._paidDate, this._fee, this._payType.ToUpper(), this._checkNo, this._acctNo, this._notes.ToUpper(), this._driverLic.ToUpper(), 
                this._ssn, this._zoning.ToUpper(), this._salesTax.ToUpper(), this._insAmt, this.insDateParm, this._legalId.ToUpper(), this._bondAmt, this.bondDateParm, this._lName.ToUpper(), this._mAddr.ToUpper(), this._mCity.ToUpper(), this._mState.ToUpper(), this._mZip, this._oName.ToUpper(), this._oAddr.ToUpper(), this._oCity.ToUpper(), 
                this._oState.ToUpper(), this._oZip, this._oPhone, this._bName.ToUpper(), this._bAddr.ToUpper(), this._bCity.ToUpper(), this._bState.ToUpper(), this._bZip, this._bPhone, this._liqLic.ToUpper(), this._vin.ToUpper(), this._emailAddress
             });
        }


        public string AcctNo
        {
            get
            {
                return this._acctNo;
            }
            set
            {
                this._acctNo = value;
            }
        }

        public string AName
        {
            get
            {
                return this._aName;
            }
            set
            {
                this._aName = value;
            }
        }

        public string BAddr
        {
            get
            {
                return this._bAddr;
            }
            set
            {
                this._bAddr = value;
            }
        }

        public string BCity
        {
            get
            {
                return this._bCity;
            }
            set
            {
                this._bCity = value;
            }
        }

        public string BName
        {
            get
            {
                return this._bName;
            }
            set
            {
                this._bName = value;
            }
        }

        public decimal BondAmt
        {
            get
            {
                return this._bondAmt;
            }
            set
            {
                this._bondAmt = value;
            }
        }

        public DateTime BondDate
        {
            get
            {
                return this._bondDate;
            }
            set
            {
                this._bondDate = value;
            }
        }

        public string BPhone
        {
            get
            {
                return this._bPhone;
            }
            set
            {
                this._bPhone = value;
            }
        }

        public string BState
        {
            get
            {
                return this._bState;
            }
            set
            {
                this._bState = value;
            }
        }

        public string BZip
        {
            get
            {
                return this._bZip;
            }
            set
            {
                this._bZip = value;
            }
        }

        public string CheckNo
        {
            get
            {
                return this._checkNo;
            }
            set
            {
                this._checkNo = value;
            }
        }

        public string DbaFor
        {
            get
            {
                return this._dbaFor;
            }
            set
            {
                this._dbaFor = value;
            }
        }

        public string DriverLic
        {
            get
            {
                return this._driverLic;
            }
            set
            {
                this._driverLic = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return this._emailAddress;
            }
            set
            {
                this._emailAddress = value;
            }
        }

        public DateTime ExpDate
        {
            get
            {
                return this._expDate;
            }
            set
            {
                this._expDate = value;
            }
        }

        public DateTime ExpDate1
        {
            get
            {
                return this._expDate1;
            }
            set
            {
                this._expDate1 = value;
            }
        }

        public DateTime ExpDate2
        {
            get
            {
                return this._expDate2;
            }
            set
            {
                this._expDate2 = value;
            }
        }

        public decimal Fee
        {
            get
            {
                return this._fee;
            }
            set
            {
                this._fee = value;
            }
        }

        public decimal InsAmt
        {
            get
            {
                return this._insAmt;
            }
            set
            {
                this._insAmt = value;
            }
        }

        public DateTime InsDate
        {
            get
            {
                return this._insDate;
            }
            set
            {
                this._insDate = value;
            }
        }

        public DateTime IssueDate
        {
            get
            {
                return this._issueDate;
            }
            set
            {
                this._issueDate = value;
            }
        }

        public DateTime IssueDate1
        {
            get
            {
                return this._issueDate1;
            }
            set
            {
                this._issueDate1 = value;
            }
        }

        public DateTime IssueDate2
        {
            get
            {
                return this._issueDate2;
            }
            set
            {
                this._issueDate2 = value;
            }
        }

        public string LegalId
        {
            get
            {
                return this._legalId;
            }
            set
            {
                this._legalId = value;
            }
        }

        public int LicId
        {
            get
            {
                return this._licId;
            }
            set
            {
                this._licId = value;
            }
        }

        public string LicNo
        {
            get
            {
                return this._licNo;
            }
            set
            {
                this._licNo = value;
            }
        }

        public string LicStat
        {
            get
            {
                return this._licStat;
            }
            set
            {
                this._licStat = value;
            }
        }

        public string LiqLic
        {
            get
            {
                return this._liqLic;
            }
            set
            {
                this._liqLic = value;
            }
        }

        public string LName
        {
            get
            {
                return this._lName;
            }
            set
            {
                this._lName = value;
            }
        }

        public string MAddr
        {
            get
            {
                return this._mAddr;
            }
            set
            {
                this._mAddr = value;
            }
        }

        public string MCity
        {
            get
            {
                return this._mCity;
            }
            set
            {
                this._mCity = value;
            }
        }

        public string MState
        {
            get
            {
                return this._mState;
            }
            set
            {
                this._mState = value;
            }
        }

        public string MZip
        {
            get
            {
                return this._mZip;
            }
            set
            {
                this._mZip = value;
            }
        }

        public string Notes
        {
            get
            {
                return this._notes;
            }
            set
            {
                this._notes = value;
            }
        }

        public string OAddr
        {
            get
            {
                return this._oAddr;
            }
            set
            {
                this._oAddr = value;
            }
        }

        public string OCity
        {
            get
            {
                return this._oCity;
            }
            set
            {
                this._oCity = value;
            }
        }

        public string OName
        {
            get
            {
                return this._oName;
            }
            set
            {
                this._oName = value;
            }
        }

        public string OPhone
        {
            get
            {
                return this._oPhone;
            }
            set
            {
                this._oPhone = value;
            }
        }

        public string OState
        {
            get
            {
                return this._oState;
            }
            set
            {
                this._oState = value;
            }
        }

        public string OwMgr
        {
            get
            {
                return this._owMgr;
            }
            set
            {
                this._owMgr = value;
            }
        }

        public string OZip
        {
            get
            {
                return this._oZip;
            }
            set
            {
                this._oZip = value;
            }
        }

        public DateTime PaidDate
        {
            get
            {
                return this._paidDate;
            }
            set
            {
                this._paidDate = value;
            }
        }

        public DateTime PaidDate1
        {
            get
            {
                return this._paidDate1;
            }
            set
            {
                this._paidDate1 = value;
            }
        }

        public DateTime PaidDate2
        {
            get
            {
                return this._paidDate2;
            }
            set
            {
                this._paidDate2 = value;
            }
        }

        public string PayType
        {
            get
            {
                return this._payType;
            }
            set
            {
                this._payType = value;
            }
        }

        public string SalesTax
        {
            get
            {
                return this._salesTax;
            }
            set
            {
                this._salesTax = value;
            }
        }

        public string Ssn
        {
            get
            {
                return this._ssn;
            }
            set
            {
                this._ssn = value;
            }
        }

        public DateTime StatDate
        {
            get
            {
                return this._statDate;
            }
            set
            {
                this._statDate = value;
            }
        }

        public DateTime StDate1
        {
            get
            {
                return this._stDate1;
            }
            set
            {
                this._stDate1 = value;
            }
        }

        public DateTime StDate2
        {
            get
            {
                return this._stDate2;
            }
            set
            {
                this._stDate2 = value;
            }
        }

        public string TypeCode
        {
            get
            {
                return this._typeCode;
            }
            set
            {
                this._typeCode = value;
            }
        }

        public string Vin
        {
            get
            {
                return this._vin;
            }
            set
            {
                this._vin = value;
            }
        }

        public string Zoning
        {
            get
            {
                return this._zoning;
            }
            set
            {
                this._zoning = value;
            }
        }


        private string _acctNo;
        private string _aName;
        private string _bAddr;
        private string _bCity;
        private string _bName;
        private decimal _bondAmt;
        private DateTime _bondDate;
        private string _bPhone;
        private string _bState;
        private string _bZip;
        private string _checkNo;
        private string _dbaFor;
        private string _driverLic;
        private string _emailAddress;
        private DateTime _expDate;
        private DateTime _expDate1;
        private DateTime _expDate2;
        private decimal _fee;
        private decimal _insAmt;
        private DateTime _insDate;
        private DateTime _issueDate;
        private DateTime _issueDate1;
        private DateTime _issueDate2;
        private string _legalId;
        private int _licId;
        private string _licNo;
        private string _licStat;
        private string _liqLic;
        private string _lName;
        private string _mAddr;
        private string _mCity;
        private string _mState;
        private string _mZip;
        private string _notes;
        private string _oAddr;
        private string _oCity;
        private string _oName;
        private string _oPhone;
        private string _oState;
        private string _owMgr;
        private string _oZip;
        private DateTime _paidDate;
        private DateTime _paidDate1;
        private DateTime _paidDate2;
        private string _payType;
        private string _salesTax;
        private string _ssn;
        private DateTime _statDate;
        private DateTime _stDate1;
        private DateTime _stDate2;
        private string _typeCode;
        private string _vin;
        private string _zoning;
        private object bondDateParm;
        private DataSet ds;
        private object expDateParm;
        private object insDateParm;
        private object isuDateParm;
    }
}


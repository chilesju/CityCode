namespace CLAS.BusinessLogicLayer
{
    using CLAS;
    using System;
    using System.Configuration;
    using System.Data;

    public class LicenseType
    {
        public LicenseType()
        {
        }

        public LicenseType(string typeCode)
        {
            this._typeCode = typeCode;
        }

        public DataSet GetAllLicense()
        {
            return SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_ListLicenseType", new object[0]);
        }

        public int InsertType()
        {
            object obj1 = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_InsertLicenseType", new object[] { 
                this._typeCode.ToUpper(), this._accountNumber, this._fee, this._expDate, this._days, this._months, this._aNameInc, this._aNameReq, this._lNameInc, this._lNameReq, this._mAddressInc, this._mAddressReq, this._mCityStZipInc, this._mCityStZipReq, this._oNameInc, this._oNameReq, 
                this._oAddressInc, this._oAddressReq, this._oCityStZipInc, this._oCityStZipReq, this._bNameInc, this._bNameReq, this._bAddressInc, this._bAddressReq, this._bCityStZipInc, this._bCityStZipReq, this._zoningInc, this._zoningReq, this._insuranceInc, this._insuranceReq, this._bondInc, this._bondReq, 
                this._ssnInc, this._ssnReq, this._driverLicInc, this._driverLicReq, this._liqLicInc, this._liqLicReq, this._salesTaxInc, this._salesTaxReq, this._vinInc, this._vinReq, this._legalIdInc, this._legalIdReq, this._bPhoneInc, this._bPhoneReq, this._owPhoneInc, this._owPhoneReq, 
                this._typeName, this._emailInc, this._emailReq
             });
            return Convert.ToInt32(obj1);
        }

        public bool LoadLicenseType()
        {
            DataSet set1 = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_SelectLicenseType", new object[] { this._typeCode });
            this._typeCode = Convert.ToString(set1.Tables[0].Rows[0][1]);
            this._typeName = Convert.ToString(set1.Tables[0].Rows[0][0x31]);
            this._accountNumber = Convert.ToString(set1.Tables[0].Rows[0][2]);
            this._fee = Convert.ToDecimal(set1.Tables[0].Rows[0][3]);
            this._expDate = Convert.ToString(set1.Tables[0].Rows[0][4]);
            this._days = Convert.ToInt32(set1.Tables[0].Rows[0][5]);
            this._months = Convert.ToInt32(set1.Tables[0].Rows[0][6]);
            this._aNameInc = Convert.ToInt32(set1.Tables[0].Rows[0][7]);
            this._aNameReq = Convert.ToInt32(set1.Tables[0].Rows[0][8]);
            this._lNameInc = Convert.ToInt32(set1.Tables[0].Rows[0][9]);
            this._lNameReq = Convert.ToInt32(set1.Tables[0].Rows[0][10]);
            this._mAddressInc = Convert.ToInt32(set1.Tables[0].Rows[0][11]);
            this._mAddressReq = Convert.ToInt32(set1.Tables[0].Rows[0][12]);
            this._mCityStZipInc = Convert.ToInt32(set1.Tables[0].Rows[0][13]);
            this._mCityStZipReq = Convert.ToInt32(set1.Tables[0].Rows[0][14]);
            this._oNameInc = Convert.ToInt32(set1.Tables[0].Rows[0][15]);
            this._oNameReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x10]);
            this._oAddressInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x11]);
            this._oAddressReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x12]);
            this._oCityStZipInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x13]);
            this._oCityStZipReq = Convert.ToInt32(set1.Tables[0].Rows[0][20]);
            this._bNameInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x15]);
            this._bNameReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x16]);
            this._bAddressInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x17]);
            this._bAddressReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x18]);
            this._bCityStZipInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x19]);
            this._bCityStZipReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x1a]);
            this._zoningInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x1b]);
            this._zoningReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x1c]);
            this._insuranceInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x1d]);
            this._insuranceReq = Convert.ToInt32(set1.Tables[0].Rows[0][30]);
            this._bondInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x1f]);
            this._bondReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x20]);
            this._ssnInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x21]);
            this._ssnReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x22]);
            this._driverLicInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x23]);
            this._driverLicReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x24]);
            this._liqLicInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x25]);
            this._liqLicReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x26]);
            this._salesTaxInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x27]);
            this._salesTaxReq = Convert.ToInt32(set1.Tables[0].Rows[0][40]);
            this._vinInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x29]);
            this._vinReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x2a]);
            this._legalIdInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x2b]);
            this._legalIdReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x2c]);
            this._bPhoneInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x2d]);
            this._bPhoneReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x2e]);
            this._owPhoneInc = Convert.ToInt32(set1.Tables[0].Rows[0][0x2f]);
            this._owPhoneReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x30]);
            this._emailInc = Convert.ToInt32(set1.Tables[0].Rows[0][50]);
            this._emailReq = Convert.ToInt32(set1.Tables[0].Rows[0][0x33]);
            return true;
        }

        public void UpdateType()
        {
            SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_UpdateLicenseType", new object[] { 
                this._typeCode.ToUpper(), this._accountNumber, this._fee, this._expDate, this._days, this._months, this._aNameInc, this._aNameReq, this._lNameInc, this._lNameReq, this._mAddressInc, this._mAddressReq, this._mCityStZipInc, this._mCityStZipReq, this._oNameInc, this._oNameReq, 
                this._oAddressInc, this._oAddressReq, this._oCityStZipInc, this._oCityStZipReq, this._bNameInc, this._bNameReq, this._bAddressInc, this._bAddressReq, this._bCityStZipInc, this._bCityStZipReq, this._zoningInc, this._zoningReq, this._insuranceInc, this._insuranceReq, this._bondInc, this._bondReq, 
                this._ssnInc, this._ssnReq, this._driverLicInc, this._driverLicReq, this._liqLicInc, this._liqLicReq, this._salesTaxInc, this._salesTaxReq, this._vinInc, this._vinReq, this._legalIdInc, this._legalIdReq, this._bPhoneInc, this._bPhoneReq, this._owPhoneInc, this._owPhoneReq, 
                this._emailInc, this._emailReq, this._typeName
             });
        }


        public string AccountNumber
        {
            get
            {
                return this._accountNumber;
            }
            set
            {
                this._accountNumber = value;
            }
        }

        public int ANameInc
        {
            get
            {
                return this._aNameInc;
            }
            set
            {
                this._aNameInc = value;
            }
        }

        public int ANameReq
        {
            get
            {
                return this._aNameReq;
            }
            set
            {
                this._aNameReq = value;
            }
        }

        public int BAddressInc
        {
            get
            {
                return this._bAddressInc;
            }
            set
            {
                this._bAddressInc = value;
            }
        }

        public int BAddressReq
        {
            get
            {
                return this._bAddressReq;
            }
            set
            {
                this._bAddressReq = value;
            }
        }

        public int BCityStZipInc
        {
            get
            {
                return this._bCityStZipInc;
            }
            set
            {
                this._bCityStZipInc = value;
            }
        }

        public int BCityStZipReq
        {
            get
            {
                return this._bCityStZipInc;
            }
            set
            {
                this._bCityStZipInc = value;
            }
        }

        public int BNameInc
        {
            get
            {
                return this._bNameInc;
            }
            set
            {
                this._bNameInc = value;
            }
        }

        public int BNameReq
        {
            get
            {
                return this._bNameReq;
            }
            set
            {
                this._bNameReq = value;
            }
        }

        public int BondInc
        {
            get
            {
                return this._bondInc;
            }
            set
            {
                this._bondInc = value;
            }
        }

        public int BondReq
        {
            get
            {
                return this._bondReq;
            }
            set
            {
                this._bondReq = value;
            }
        }

        public int BPhoneInc
        {
            get
            {
                return this._bPhoneInc;
            }
            set
            {
                this._bPhoneInc = value;
            }
        }

        public int BPhoneReq
        {
            get
            {
                return this._bPhoneReq;
            }
            set
            {
                this._bPhoneReq = value;
            }
        }

        public int Days
        {
            get
            {
                return this._days;
            }
            set
            {
                this._days = value;
            }
        }

        public int DriverLicInc
        {
            get
            {
                return this._driverLicInc;
            }
            set
            {
                this._driverLicInc = value;
            }
        }

        public int DriverLicReq
        {
            get
            {
                return this._driverLicReq;
            }
            set
            {
                this._driverLicReq = value;
            }
        }

        public int EmailInc
        {
            get
            {
                return this._emailInc;
            }
            set
            {
                this._emailInc = value;
            }
        }

        public int EmailReq
        {
            get
            {
                return this._emailReq;
            }
            set
            {
                this._emailReq = value;
            }
        }

        public string ExpDate
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

        public int InsuranceInc
        {
            get
            {
                return this._insuranceInc;
            }
            set
            {
                this._insuranceInc = value;
            }
        }

        public int InsuranceReq
        {
            get
            {
                return this._insuranceReq;
            }
            set
            {
                this._insuranceReq = value;
            }
        }

        public int LegalIdInc
        {
            get
            {
                return this._legalIdInc;
            }
            set
            {
                this._legalIdInc = value;
            }
        }

        public int LegalIdReq
        {
            get
            {
                return this._legalIdReq;
            }
            set
            {
                this._legalIdReq = value;
            }
        }

        public int LiqLicInc
        {
            get
            {
                return this._liqLicInc;
            }
            set
            {
                this._liqLicInc = value;
            }
        }

        public int LiqLicReq
        {
            get
            {
                return this._liqLicReq;
            }
            set
            {
                this._liqLicReq = value;
            }
        }

        public int LNameInc
        {
            get
            {
                return this._lNameInc;
            }
            set
            {
                this._lNameInc = value;
            }
        }

        public int LNameReq
        {
            get
            {
                return this._lNameReq;
            }
            set
            {
                this._lNameReq = value;
            }
        }

        public int MAddressInc
        {
            get
            {
                return this._mAddressInc;
            }
            set
            {
                this._mAddressInc = value;
            }
        }

        public int MAddressReq
        {
            get
            {
                return this._mAddressReq;
            }
            set
            {
                this._mAddressReq = value;
            }
        }

        public int MCityStZipInc
        {
            get
            {
                return this._mCityStZipInc;
            }
            set
            {
                this._mCityStZipInc = value;
            }
        }

        public int MCityStZipReq
        {
            get
            {
                return this._mCityStZipReq;
            }
            set
            {
                this._mCityStZipReq = value;
            }
        }

        public int Months
        {
            get
            {
                return this._months;
            }
            set
            {
                this._months = value;
            }
        }

        public int OAddressInc
        {
            get
            {
                return this._oAddressInc;
            }
            set
            {
                this._oAddressInc = value;
            }
        }

        public int OAddressReq
        {
            get
            {
                return this._oAddressReq;
            }
            set
            {
                this._oAddressReq = value;
            }
        }

        public int OCityStZipInc
        {
            get
            {
                return this._oCityStZipInc;
            }
            set
            {
                this._oCityStZipInc = value;
            }
        }

        public int OCityStZipReq
        {
            get
            {
                return this._oCityStZipReq;
            }
            set
            {
                this._oCityStZipReq = value;
            }
        }

        public int ONameInc
        {
            get
            {
                return this._oNameInc;
            }
            set
            {
                this._oNameInc = value;
            }
        }

        public int ONameReq
        {
            get
            {
                return this._oNameReq;
            }
            set
            {
                this._oNameReq = value;
            }
        }

        public int OwPhoneInc
        {
            get
            {
                return this._owPhoneInc;
            }
            set
            {
                this._owPhoneInc = value;
            }
        }

        public int OwPhoneReq
        {
            get
            {
                return this._owPhoneReq;
            }
            set
            {
                this._owPhoneReq = value;
            }
        }

        public int SalesTaxInc
        {
            get
            {
                return this._salesTaxInc;
            }
            set
            {
                this._salesTaxInc = value;
            }
        }

        public int SalesTaxReq
        {
            get
            {
                return this._salesTaxReq;
            }
            set
            {
                this._salesTaxReq = value;
            }
        }

        public int SsnInc
        {
            get
            {
                return this._ssnInc;
            }
            set
            {
                this._ssnInc = value;
            }
        }

        public int SsnReq
        {
            get
            {
                return this._ssnReq;
            }
            set
            {
                this._ssnReq = value;
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

        public int TypeId
        {
            get
            {
                return this._typeId;
            }
            set
            {
                this._typeId = value;
            }
        }

        public string TypeName
        {
            get
            {
                return this._typeName;
            }
            set
            {
                this._typeName = value;
            }
        }

        public int VinInc
        {
            get
            {
                return this._vinInc;
            }
            set
            {
                this._vinInc = value;
            }
        }

        public int VinReq
        {
            get
            {
                return this._vinReq;
            }
            set
            {
                this._vinReq = value;
            }
        }

        public int ZoningInc
        {
            get
            {
                return this._zoningInc;
            }
            set
            {
                this._zoningInc = value;
            }
        }

        public int ZoningReq
        {
            get
            {
                return this._zoningReq;
            }
            set
            {
                this._zoningReq = value;
            }
        }


        private string _accountNumber;
        private int _aNameInc;
        private int _aNameReq;
        private int _bAddressInc;
        private int _bAddressReq;
        private int _bCityStZipInc;
        private int _bCityStZipReq;
        private int _bNameInc;
        private int _bNameReq;
        private int _bondInc;
        private int _bondReq;
        private int _bPhoneInc;
        private int _bPhoneReq;
        private int _days;
        private int _driverLicInc;
        private int _driverLicReq;
        private int _emailInc;
        private int _emailReq;
        private string _expDate;
        private decimal _fee;
        private int _insuranceInc;
        private int _insuranceReq;
        private int _legalIdInc;
        private int _legalIdReq;
        private int _liqLicInc;
        private int _liqLicReq;
        private int _lNameInc;
        private int _lNameReq;
        private int _mAddressInc;
        private int _mAddressReq;
        private int _mCityStZipInc;
        private int _mCityStZipReq;
        private int _months;
        private int _oAddressInc;
        private int _oAddressReq;
        private int _oCityStZipInc;
        private int _oCityStZipReq;
        private int _oNameInc;
        private int _oNameReq;
        private int _owPhoneInc;
        private int _owPhoneReq;
        private int _salesTaxInc;
        private int _salesTaxReq;
        private int _ssnInc;
        private int _ssnReq;
        private string _typeCode;
        private int _typeId;
        private string _typeName;
        private int _vinInc;
        private int _vinReq;
        private int _zoningInc;
        private int _zoningReq;
    }
}


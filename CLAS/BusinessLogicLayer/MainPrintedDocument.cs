namespace CLAS.BusinessLogicLayer
{
    using CLAS;
    using System;
    using System.Configuration;
    using System.Data;

    public class MainPrintedDocument
    {
        public MainPrintedDocument(string licenseType)
        {
            this._licenseType = licenseType;
        }

        public MainPrintedDocument(string licenseType, string licenseNumber)
        {
            this._licenseType = licenseType;
            this._licenseNumber = licenseNumber;
        }

        public DataSet FillDataSetForDropDownList()
        {
            return SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_DropDownListPrintValues", new object[0]);
        }

        public void InsertLicenseType()
        {
        }

        public void SelectLicenseTypePrintView()
        {
            DataSet set1 = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_SelectLicenseTypePrintView", new object[] { this._licenseType });
            this._legalDescription = Convert.ToString(set1.Tables[0].Rows[0][0]);
            this._authorizedDescription = Convert.ToString(set1.Tables[0].Rows[0][1]);
            this._mainLicenseLine1 = Convert.ToString(set1.Tables[0].Rows[0][2]);
            this._mainLicenseLine2 = Convert.ToString(set1.Tables[0].Rows[0][3]);
            this._mainLicenseLine3 = Convert.ToString(set1.Tables[0].Rows[0][4]);
            this._smallCertify = Convert.ToString(set1.Tables[0].Rows[0][5]);
            this._recivedFrom = Convert.ToString(set1.Tables[0].Rows[0][6]);
            this._mailAddressLine1 = Convert.ToString(set1.Tables[0].Rows[0][7]);
            this._mailAddressLine2 = Convert.ToString(set1.Tables[0].Rows[0][8]);
            this._mailAddressLine3 = Convert.ToString(set1.Tables[0].Rows[0][9]);
        }

        public void UpdateLicenseTypePrintView()
        {
            SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], "CLAS_UpdateLicenseTypePrintView", new object[] { this._licenseType, this._legalDescription, this._authorizedDescription, this._mainLicenseLine1, this._mainLicenseLine2, this._mainLicenseLine3, this._smallCertify, this._recivedFrom, this._mailAddressLine1, this._mailAddressLine2, this._mailAddressLine3 });
        }


        public string AuthorizedDescription
        {
            get
            {
                return this._authorizedDescription;
            }
            set
            {
                this._authorizedDescription = value;
            }
        }

        public decimal Cash
        {
            get
            {
                return this._cash;
            }
            set
            {
                this._cash = value;
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

        public DateTime ExperationDate
        {
            get
            {
                return this._experationDate;
            }
            set
            {
                this._experationDate = value;
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

        public string LegalDescription
        {
            get
            {
                return this._legalDescription;
            }
            set
            {
                this._legalDescription = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this._licenseNumber;
            }
            set
            {
                this._licenseNumber = value;
            }
        }

        public string LicneseType
        {
            get
            {
                return this._licenseType;
            }
            set
            {
                this._licenseType = value;
            }
        }

        public string MailAddressLine1
        {
            get
            {
                return this._mailAddressLine1;
            }
            set
            {
                this._mailAddressLine1 = value;
            }
        }

        public string MailAddressLine2
        {
            get
            {
                return this._mailAddressLine2;
            }
            set
            {
                this._mailAddressLine2 = value;
            }
        }

        public string MailAddressLine3
        {
            get
            {
                return this._mailAddressLine3;
            }
            set
            {
                this._mailAddressLine3 = value;
            }
        }

        public string MainLinceseLine1
        {
            get
            {
                return this._mainLicenseLine1;
            }
            set
            {
                this._mainLicenseLine1 = value;
            }
        }

        public string MainLinceseLine2
        {
            get
            {
                return this._mainLicenseLine2;
            }
            set
            {
                this._mainLicenseLine2 = value;
            }
        }

        public string MainLinceseLine3
        {
            get
            {
                return this._mainLicenseLine3;
            }
            set
            {
                this._mainLicenseLine3 = value;
            }
        }

        public string RecivedFrom
        {
            get
            {
                return this._recivedFrom;
            }
            set
            {
                this._recivedFrom = value;
            }
        }

        public string SmallCertify
        {
            get
            {
                return this._smallCertify;
            }
            set
            {
                this._smallCertify = value;
            }
        }


        private string _authorizedDescription;
        private decimal _cash;
        private string _checkNo;
        private DateTime _experationDate;
        private decimal _fee;
        private DateTime _issueDate;
        private string _legalDescription;
        private string _licenseNumber;
        private string _licenseType;
        private string _mailAddressLine1;
        private string _mailAddressLine2;
        private string _mailAddressLine3;
        private string _mainLicenseLine1;
        private string _mainLicenseLine2;
        private string _mainLicenseLine3;
        private string _recivedFrom;
        private string _smallCertify;
    }
}


namespace CLAS
{
    using System;
    using System.ComponentModel;
    using System.Web;

    public class Global : HttpApplication
    {
        public Global()
        {
            this.components = null;
            this.InitializeComponent();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }


        public const string CfgKeyConnString = "ConnectionString";
        public const string CfgKeyCrystalLocation = "CrystalLocation";
        public const string CfgKeyCrystalReportPassword = "CrystalReportPassword";
        public const string CfgKeyCrystalReportServer = "CrystalReportServer";
        public const string CfgKeyCrystalReportUserId = "CrystalReportUserId";
        private IContainer components;
    }
}


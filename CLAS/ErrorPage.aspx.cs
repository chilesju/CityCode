namespace CLAS
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class ErrorPage : Page
    {
        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
        }


        protected Label Label1;
    }
}


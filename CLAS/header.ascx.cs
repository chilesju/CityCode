namespace CLAS
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class header : UserControl
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


        protected HyperLink HyperLink1;
        protected HyperLink HyperLink2;
        protected HyperLink HyperLink3;
        protected HyperLink HyperLink4;
    }
}


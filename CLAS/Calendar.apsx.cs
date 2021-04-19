namespace ASPNET.StarterKit.TimeTracker.Web
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Calendar : Page
    {
        private void Cal_SelectionChanged(object sender, EventArgs e)
        {
            this.Cal.VisibleDate = this.Cal.SelectedDate;
            this.SelectCorrectValues();
        }

        private void chbxPending_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.chbxPending.Checked)
            {
                this.txtIssueDate.Text = "Pending";
            }
            else
            {
                this.txtIssueDate.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void InitializeComponent()
        {
            this.Cal.SelectionChanged += new EventHandler(this.Cal_SelectionChanged);
            this.chbxPending.CheckedChanged += new EventHandler(this.chbxPending_CheckedChanged_1);
            this.ID = "Calendar";
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                string text6 = base.Request.QueryString["selected"];
                string text1 = base.Request.QueryString["id"];
                string text2 = base.Request.QueryString["formname"];
                string text3 = base.Request.QueryString["postBack"];
                string text4 = base.Request.QueryString["expDate"];
                string text5 = base.Request.QueryString["status"];
                if (Convert.ToDateTime(text4) > DateTime.Now)
                {
                    this.Cal.SelectedDate = Convert.ToDateTime(text4).AddDays(1);
                }
                else
                {
                    this.Cal.SelectedDate = DateTime.Now;
                }
                this.SelectCorrectValues();
                this.OKButton.Attributes.Add("onClick", "window.opener.SetDate('" + text2 + "','" + text1 + "', document.getElementById('txtIssueDate').value," + text3 + ");");
                this.CancelButton.Attributes.Add("onClick", "window.opener.CloseWindow('" + text2 + "','" + text5 + "');");
            }
        }

        private void SelectCorrectValues()
        {
            this.txtIssueDate.Text = this.Cal.SelectedDate.ToShortDateString();
        }


        protected System.Web.UI.WebControls.Calendar Cal;
        protected Button CancelButton;
        protected CheckBox chbxPending;
        protected Label Label1;
        protected Label Label2;
        protected Button OKButton;
        protected TextBox txtIssueDate;
    }
}


namespace CLAS
{
    using CLAS.BusinessLogicLayer;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Type_Code_List : Page
    {
        public Type_Code_List()
        {
            this.lt = new LicenseType();
        }

        private void btnAddNewType_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Modify_License_Type.aspx?New");
        }

        private void DataGrid1_EditCommand_1(object source, DataGridCommandEventArgs e)
        {
            DataGridItem item1 = this.DataGrid1.Items[e.Item.ItemIndex];
            Label label1 = (Label) item1.FindControl("lblLicenseType");
            string text1 = Convert.ToString(label1.Text.Substring(0, 4));
            base.Response.Redirect("Modify_License_Type.aspx?" + text1);
        }

        private void DataGrid1_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#DEDFDE'");
                e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#99ccff'");
            }
            else if (e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#99ccff'");
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#EEEEEE'");
            }
        }

        private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
            this.DataGrid1.DataSource = this.lt.GetAllLicense();
            this.DataGrid1.DataBind();
        }

        private void InitializeComponent()
        {
            this.DataGrid1.ItemCreated += new DataGridItemEventHandler(this.DataGrid1_ItemCreated);
            this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
            this.DataGrid1.EditCommand += new DataGridCommandEventHandler(this.DataGrid1_EditCommand_1);
            this.btnAddNewType.Click += new EventHandler(this.btnAddNewType_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.lt.GetAllLicense();
                this.DataGrid1.DataSource = this.lt.GetAllLicense();
                this.DataGrid1.DataBind();
            }
        }


        protected Button btnAddNewType;
        protected DataGrid DataGrid1;
        protected LicenseType lt;
    }
}


namespace Constituent_Services.controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	
	public class History : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		private int _IncidentId;

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			
			InitializeComponent();
			base.OnInit(e);
		}
		
		
		private void InitializeComponent()
		{
			this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);

		}
		public void Initialize() 
		{
			
			BindData();
			
		}
		public int IncidentId 
		{
			get { return _IncidentId; }
			set { _IncidentId = value; }
		}
		private void BindData()
		{
			DataGrid1.DataSource= Utilites.History.GetHistory(IncidentId);
			DataGrid1.DataBind();

		}
		#endregion

		private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
				e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#DEDFDE'");
			}
			else if(  e.Item.ItemType == ListItemType.AlternatingItem)
			{
				e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#DEDFDE'");
				e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff'");
			}
		}
	}
}

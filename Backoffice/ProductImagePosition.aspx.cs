using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_ProductImagePosition : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    AdminGetData gdata = new AdminGetData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["id"] !=null)
            {
                FillImage(Request.QueryString["id"].ToString()) ;
            }
        }
    }
    public void FillImage(string id_product)
    {
        ds = gdata.GetImageOfProduct(id_product);
        ItemsListView.DataSource = ds;
        ItemsListView.DataBind();
    }

    protected void ItemsListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Cov")
        {
            Data data = new Data();
            if (ViewState["PID"] != null)
            {
                data.executeCommand(" update ps_image set cover = 0  where id_product='" + ViewState["PID"].ToString() + "'");
            }

            string query = " update ps_image set cover = (case when cover=1 then 0 else 1 end)  where id_image=" + e.CommandArgument + "";
            data.executeCommand(query);

            if (Request.QueryString["id"] != null)
            {
                FillImage(Request.QueryString["id"].ToString());
            }
            Session["tab"] = "Images";
        }
    }

    protected void ItemsListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        ListViewItem item = ItemsListView.Items[e.ItemIndex];
        Label id = (Label)item.FindControl("lblId");
        Data data = new Data();
        string query = "update ps_image set IsDeleted = 1 where id_image=" + id.Text + "";
        data.executeCommand(query);
        if (Request.QueryString["id"] != null)
        {
            FillImage(Request.QueryString["id"].ToString());
        }
        Session["tab"] = "Images";
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("addproduct.aspx?" + Request.QueryString.ToString() + "#Images");
    }

    protected void btnReferesh_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            FillImage(Request.QueryString["id"].ToString());
        }
    }
}
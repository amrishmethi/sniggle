using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_addfeature : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdata = new AdminGetData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    BindData(Request.QueryString["id"].ToString());
                    btnFeatureSave.Text = "Update";
                    btnFeatureSaveAnd.Visible = false;
                }
            }
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
    public void BindData(string id)
    {
        string qq = "select * from ps_feature_lang  ";
        qq += "  where id_feature='" + id + "'";
        ds = data.getDataSet(qq);
        txtValue.Text = ds.Tables[0].Rows[0]["name"].ToString();
    }
    protected void btnFeatureSaveAnd_Click(object sender, EventArgs e)
    {
        InsertFeature();
       
    }

    protected void btnFeatureSave_Click(object sender, EventArgs e)
    {
        InsertFeature();
        Response.Redirect("Features.aspx");
    }
    public void InsertFeature()
    {
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();

        }
        int status = gdata.AddFeature( txtValue.Text,ID, action);
        txtValue.Text = "";
        if (Request.QueryString["prd"] != null)
        {
            Response.Redirect("addproduct.aspx?id=" + Request.QueryString["prd"].ToString() + "#Features");
        }
        if(Request.QueryString["id"] != null)
        {
            Response.Redirect("Features.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backoffice_addfeature_value : System.Web.UI.Page
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
                BindFeature();
                if (Request.QueryString["id"] != null)
                {
                    BindData(Request.QueryString["id"].ToString());
                    btnFeatureSave.Text = "Update";
                    btnFeatureSaveAnd.Visible = false;
                }
                if (Request.QueryString["fid"] != null)
                {
                    ViewState["PreviousPage"] =
         Request.UrlReferrer;
                }
                if (Session["AttFPageUrl"] != null)
                {
                    hrfval.HRef = Session["AttFPageUrl"].ToString();
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
        string qq = "select* from ps_feature_value_lang as b inner join ps_feature_value as a on ";
        qq += " a.id_feature_value = b.id_feature_value and b.id_lang = 1 where a.custom = 'false' and a.id_feature_value='" + id + "'";
        ds = data.getDataSet(qq);
        txtValue.Text = ds.Tables[0].Rows[0]["Value"].ToString();
        drpFeature.SelectedValue = ds.Tables[0].Rows[0]["id_feature"].ToString();
    }
    public void BindFeature()
    {
        ds = gdata.GetFeature();
        if (ds.Tables[0].Rows.Count > 0)
        {
            drpFeature.DataSource = ds;
            drpFeature.DataTextField = "name";
            drpFeature.DataValueField = "id_feature";
            drpFeature.DataBind();

            if (Request.QueryString["fid"] != null)
            {
                drpFeature.SelectedValue = Request.QueryString["fid"].ToString();
            }
            else
            {
                drpFeature.Items.Insert(0, "Select");
            }
        }
    }
    protected void btnFeatureSaveAnd_Click(object sender, EventArgs e)
    {
        InsertFeature();
    }

    protected void btnFeatureSave_Click(object sender, EventArgs e)
    {
        InsertFeature();
        if (Session["AttFPageUrl"] != null)
        {
            Response.Redirect(Session["AttFPageUrl"].ToString());
        }

    }
    public void InsertFeature()
    {
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();

        }
        int status = gdata.AddFeatureValueNew(drpFeature.SelectedValue, txtValue.Text, ID, action);
        txtValue.Text = "";
        drpFeature.SelectedIndex = 0;
        if (Session["AttFPageUrl"] != null)
        {
            Response.Redirect(Session["AttFPageUrl"].ToString());
        }
        if (Request.QueryString["id"] != null)
        {
            if (Session["AttFPageUrl"] != null)
            {
                Response.Redirect(Session["AttFPageUrl"].ToString());
            }
        }
        if (ViewState["PreviousPage"] != null)
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Session["AttFPageUrl"] != null)
        {
            Response.Redirect(Session["AttFPageUrl"].ToString());
        }
    }
}
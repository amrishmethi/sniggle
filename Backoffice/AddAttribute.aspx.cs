using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Backoffice_AddAttribute : System.Web.UI.Page
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
        string qq = "SELECT a.name,a.public_name,b.group_type,a.id_attribute_group from  ps_attribute_group_lang as a inner join  ps_attribute_group as b on a.id_attribute_group=b.id_attribute_group ";
        qq += " where a.id_attribute_group='" + id + "'";
        ds = data.getDataSet(qq);
        txtValue.Text = ds.Tables[0].Rows[0]["name"].ToString();
        txtPublicName.Text = ds.Tables[0].Rows[0]["public_name"].ToString();
        drpControl.SelectedValue= ds.Tables[0].Rows[0]["group_type"].ToString();
    }
    protected void btnFeatureSaveAnd_Click(object sender, EventArgs e)
    {
        InsertFeature();
       
    }

    protected void btnFeatureSave_Click(object sender, EventArgs e)
    {
        InsertFeature();
        Response.Redirect("AttributesGroups.aspx");
    }
    public void InsertFeature()
    {
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
            
        }
        int status = gdata.AddattributeG(txtValue.Text.TrimStart().TrimEnd(), txtPublicName.Text,ID,action,drpControl.SelectedValue);
        txtValue.Text =txtPublicName.Text= "";
        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("AttributesGroups.aspx");
        }
        }
}
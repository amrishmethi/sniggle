using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Services;
using Newtonsoft.Json;
using System.Collections.Generic;


public partial class Backoffice_AddProductTag : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.Cookies["Backoffice"] != null)
        {
            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                if(Request.QueryString["id"] !=null)
                {
                    string ss = "select name from ps_product_lang where IsDeletd=0 and id_lang=1 and id_product='" + Request.QueryString["id"].ToString() + "'";
                    DataSet ds3 = data.getDataSet(ss);
                    if(ds3.Tables[0].Rows.Count>0)
                    {
                        lblProduct.Text = ds3.Tables[0].Rows[0][0].ToString();
                    }    
                    FillData();
                   
                }
                //FillData();
            }
        }
    }
   
    public void FillData()
    {
        ds = data.getDataSet("Sp_GetTagByProduct " + Request.QueryString["id"].ToString());
        rep.DataSource = ds;
        rep.DataBind();
    }
    [WebMethod]

    public static string[] getTag(string prefix)
    {

        AdminGetData gdata = new AdminGetData();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        List<string> customers = new List<string>();
        Data data = new Data();
        ds = data.getDataSet("Sp_GetTagList ");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow[] results;
            if (prefix != " ")
            {
                results = ds.Tables[0].Select("name Like '" + prefix + "%' ");
                if (results.Length > 0)
                {
                    dt.Rows.Clear();
                    dt = results.CopyToDataTable();
                }
            }
            else
            {
                dt.Rows.Clear();
                dt = ds.Tables[0];
            }
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            customers.Add(string.Format("{0}-{1}", dt.Rows[i]["name"].ToString(), dt.Rows[i]["id_tag"].ToString()));
            // customers.Add(string.Format(dt.Rows[i]["Colour"].ToString()));
        }

        return customers.ToArray();
    }
    public static string[] getTag1(string prefix)
    {
        AdminGetData gdata = new AdminGetData();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        List<string> customers = new List<string>();
        Data data = new Data();
        ds = data.getDataSet("Sp_GetTagList1 "+ prefix);
        dt = ds.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            customers.Add(string.Format("{0}-{1}", dt.Rows[i]["name"].ToString(), dt.Rows[i]["id_tag"].ToString()));
            // customers.Add(string.Format(dt.Rows[i]["Colour"].ToString()));
        }

        return customers.ToArray();
    }

    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            if ( Request.QueryString["id"] != null)
            {
                string query = "update ps_product_tag set IsDeleted = 1 where id_tag=" + e.CommandArgument + " and id_product='" + Request.QueryString["id"].ToString() + "'";
                data.executeCommand(query);
                FillData();
            }
        }
    }

    protected void btnSaveAnd_Click(object sender, EventArgs e)
    {
        if(tagid.Value !="" && Request.QueryString["id"] != null)
        {
            ds = data.getDataSet("select * from ps_product_tag where id_tag=" + tagid.Value + " and id_product='" + Request.QueryString["id"].ToString() + "' ");
            if(ds.Tables[0].Rows.Count>0)
            {
                hideDiv.Visible = true;
                Div1.Visible = false;
                txtName.Text = "";
                txtName.Focus();
                // ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Already exist.......')", true);
            }
            else
            {
                gdate.AddProductTag(Request.QueryString["id"].ToString(), tagid.Value);
                txtName.Text = "";
                FillData();
                hideDiv.Visible = false;
                Div1.Visible = true;
                txtName.Focus();
            }
           
        }
    }
}
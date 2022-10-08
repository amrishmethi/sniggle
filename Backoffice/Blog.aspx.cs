using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_Blog : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillData();
        }
    }
    public void FillData()
    {
        ds = data.getDataSet("Sp_GetBlog ");
        rep.DataSource = ds;
        rep.DataBind();
    }

    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "update ps_smart_blog_category set IsDeleted = 1,UpdateLoginId=0,UpdateDate=getdate()  where id_smart_blog_category=" + e.CommandArgument + "";
            data.executeCommand(query);

            string query1 = "update ps_smart_blog_category_lang set IsDeleted = 1,UpdateLoginId=0,UpdateDate=getdate()  where id_smart_blog_category=" + e.CommandArgument + "";
            data.executeCommand(query1);
            FillData();
        }
        if (e.CommandName == "Ac")
        {

            data.executeCommand("update ps_smart_blog_category set active = (case when active=1 then 0 else 1 end) where id_smart_blog_category=" + e.CommandArgument + "");
            FillData();
        }
    }
}
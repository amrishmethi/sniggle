using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Backoffice_ErrorLog : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Notification"] == "yes")
            {
                data.executeCommand("update tbl_LogError set Notification=0 ");
                Response.Redirect("ErrorLog.aspx");
            }
            FillData();
        }
    }
    public void FillData()
    {
        ds = data.getDataSet("select * from tbl_LogError order by AddedDate desc");
        rep.DataSource = ds;
        rep.DataBind();
    }

    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "delete from  tbl_LogError where id=" + e.CommandArgument + "";
            data.executeCommand(query);

          
            FillData();
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Backoffice_menu : System.Web.UI.Page
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
                FillData();
            }
        }
    }
    public void FillData()
    {
        ds = gdate.GetMenu();
        if (ds.Tables[0].Rows.Count > 0)
        {
            rep.DataSource = ds;
            rep.DataBind();

        }
    }


    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "update tbl_Menu set IsDeleted = 1 where id_Menu=" + e.CommandArgument + "";
            data.executeCommand(query);
            FillData();
        }
        if (e.CommandName == "Ac")
        {
            data.executeCommand("update tbl_Menu set Active = (case when Active=1 then 0 else 1 end) where id_Menu=" + e.CommandArgument + "");
            FillData();
        }
    }
}
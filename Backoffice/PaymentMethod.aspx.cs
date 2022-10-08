using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_PaymentMethod : System.Web.UI.Page
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
        string sq = " select * from tbl_PaymentMethod where IsDeleted=0 ";
        ds = data.getDataSet(sq);
        rep.DataSource = ds;
        rep.DataBind();
    }


    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "update tbl_PaymentMethod set IsDeleted = 1 where ID=" + e.CommandArgument + "";
            data.executeCommand(query);
            FillData();
        }
    }
}
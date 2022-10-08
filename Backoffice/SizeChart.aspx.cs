using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Backoffice_SizeChart : System.Web.UI.Page
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
        ds = data.getDataSet("Select * from tbl_SizeChart as S inner join ps_category_lang as c on C.id_category=S.CategoryId where S.Isdeleted=0");
        rep.DataSource = ds;
        rep.DataBind();
    }

    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "update tbl_SizeChart set IsDeleted = 1 where ID=" + e.CommandArgument + "";
            data.executeCommand(query);
            FillData();
        }
    }
}
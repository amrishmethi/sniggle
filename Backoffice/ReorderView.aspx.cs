using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Backoffice_ReorderView : System.Web.UI.Page
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
                if (Request.QueryString["id"] != null)
                {
                    FillData();
                }
            }
        }
    }
    public void FillData()
    {
        ds = data.getDataSet("select *,CONVERT(CHAR(11),AddedDate,103) as Date from tbl_ProductEnquiry where IsDeleted=0 and ID='" + Request.QueryString["id"].ToString() + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {

            lblCName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            lblFullName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            lblSubject.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            lblEmailId.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            ltrMessage.Text = ds.Tables[0].Rows[0]["Message"].ToString();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            Data data = new Data();
            string query = "update tbl_ProductEnquiry set IsDeleted = 1 where ID=" + Request.QueryString["id"].ToString() + "";
            data.executeCommand(query);
            Response.Redirect("Enquire.aspx");
        }

    }
}
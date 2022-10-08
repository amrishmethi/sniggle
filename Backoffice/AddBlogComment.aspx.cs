using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_AddBlogComment : System.Web.UI.Page
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
                    BindData(Request.QueryString["id"].ToString());
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
        string qq = "SELECT * FROM ps_smart_blog_comment ";
        qq += " where IsDeleted = 0  and id_smart_blog_comment='" + id + "'";
        ds = data.getDataSet(qq);
        txtComment.Text = ds.Tables[0].Rows[0]["content"].ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
           string id = Request.QueryString["id"].ToString();

            gdate.UpdateBlogComment(txtComment.Text, id);
           
        }
       else
        {
            
        }
        Response.Redirect("BlogComment.aspx");
    }
}
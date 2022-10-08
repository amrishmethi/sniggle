using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_AdminLogin : System.Web.UI.Page
{
    HttpCookie StaffCookie;
    HttpCookie CenterCookie;
    string query;
    Data data = new Data();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            if (Request.Params["logout"] != null)
            {
                HttpContext.Current.Response.Cookies["Backoffice"].Expires = DateTime.Now.AddDays(-1d);
            }

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtPass.Value != "" && txtUserName.Value != "")
        {
            AdminGetData newdata = new AdminGetData();
            ds = newdata.Login( txtUserName.Value, txtPass.Value);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HttpCookie Admin = new HttpCookie("Backoffice");
                Admin.Values.Add("UserId", ds.Tables[0].Rows[0]["id_employee"].ToString());
                Admin.Values.Add("UserName", ds.Tables[0].Rows[0]["firstname"].ToString());
                Admin.Expires = ServerDateTime.getTodayDateTime().AddDays(1);

                Response.Cookies.Add(Admin);
                Response.Redirect("index.aspx");
            }
            else
            {
                lblError.Visible = true;
            }
        }
    }
}
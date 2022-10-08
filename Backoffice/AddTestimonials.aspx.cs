using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_AddTestimonials : System.Web.UI.Page
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
        string qq = "select * from ps_prestahome_testimonial where IsDeleted=0 ";
        qq += "  and id_prestahome_testimonial='" + id + "'";
        ds = data.getDataSet(qq);
        txtAuthor.Text = ds.Tables[0].Rows[0]["author_name"].ToString();
        txtAuthorinfo.Text = ds.Tables[0].Rows[0]["author_info"].ToString();
        txtURL.Text = ds.Tables[0].Rows[0]["author_url"].ToString();
        txtEmail.Text = ds.Tables[0].Rows[0]["author_email"].ToString();
        txtContent.Text = ds.Tables[0].Rows[0]["content"].ToString();
    }

    public void Save()
    {
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();

        }
        int status = gdata.AddTestimonial(action, txtAuthor.Text, txtAuthorinfo.Text, txtURL.Text, txtEmail.Text, txtContent.Text, ID);
    }

    protected void btnSaveAnd_Click(object sender, EventArgs e)
    {
        Save();
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved successfully! ')", true);
        txtAuthor.Text=txtAuthorinfo.Text=txtURL.Text=txtEmail.Text=txtContent.Text = "";
    }

    protected void btneSave_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect("Testimonials.aspx");
    }
}
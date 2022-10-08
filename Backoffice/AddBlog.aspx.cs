using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class Backoffice_AddBlog : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    string filename1;
    string uploadthumburl = "../img/Blog/";
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
        string qq = "SELECT b.*, a.* FROM ps_smart_blog_category a ";
        qq += "LEFT JOIN ps_smart_blog_category_lang b ON(b.id_smart_blog_category = a.id_smart_blog_category AND b.id_lang = 1)";
        qq += " where a.IsDeleted = 0 and b.IsDeleted = 0 and a.id_smart_blog_category='" + id + "'";
        qq += " ORDER BY a.id_smart_blog_category DESC";
        ds = data.getDataSet(qq);
        txtareaDescription.Text = ds.Tables[0].Rows[0]["description"].ToString(); //Server.HtmlEncode(ds.Tables[0].Rows[0]["description"].ToString());
        txtFriendlyURL.Text = ds.Tables[0].Rows[0]["link_rewrite"].ToString();
        txtKeyWord.Text = ds.Tables[0].Rows[0]["meta_keyword"].ToString();
        txtMetaDes.Text = ds.Tables[0].Rows[0]["meta_description"].ToString();
        txtMetaTitle.Text = ds.Tables[0].Rows[0]["meta_title"].ToString();

        imgCover.ImageUrl = "../img/Blog/" + ds.Tables[0].Rows[0]["id_smart_blog_category"].ToString() + ".jpg";
        string img = "../img/Blog/" + ds.Tables[0].Rows[0]["id_smart_blog_category"].ToString() + ".jpg";
        if (File.Exists(Server.MapPath(img)))
            imgCover.Visible = true;
        else
            imgCover.Visible = false;
    }

    

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();

        }

        string Description = txtareaDescription.Text; string Metatitle = txtMetaTitle.Text;
        string Metadescription = txtMetaDes.Text; string Metakeywords = txtKeyWord.Text;
        string Url = txtFriendlyURL.Text;

        ds = gdate.AddBlog(action, ID, Metatitle, Metakeywords, Metadescription, Description, Url);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (flapThumb.HasFile)
            {
                flapThumb.SaveAs(Server.MapPath("../img/Blog/" + ds.Tables[0].Rows[0][0].ToString() + ".jpg"));
            }
            Response.Redirect("Blog.aspx");
        }
    }

    protected void txtMetaTitle_TextChanged(object sender, EventArgs e)
    {
        if (txtMetaTitle.Text != "")
        {
            string ss = "Sp_GenerateCategoryUrl '" + txtMetaTitle.Text + "'";
            ds = data.getDataSet(ss);
            txtFriendlyURL.Text = ds.Tables[0].Rows[0][0].ToString().ToLower();
        }
    }
}
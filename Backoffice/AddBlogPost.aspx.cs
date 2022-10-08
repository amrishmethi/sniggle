using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Backoffice_AddBlogPost : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    string filename1;
    string uploadthumburl = "../img/tmp/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                BindDropDown();
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
    public void BindDropDown()
    {
        ds = data.getDataSet("Sp_GetBlog ");
        drpBlogCat.DataSource = ds;
        drpBlogCat.DataValueField = "id_smart_blog_category";
        drpBlogCat.DataTextField = "meta_title";
        drpBlogCat.DataBind();
    }
    public void BindData(string id)
    {
        string qq = "SELECT *,'../img/tmp/smart_blog_post_mini_'+cast(id_smart_blog_post as nvarchar)+'_1.jpg' as img FROM ps_smart_blog_post_lang ";
        qq += " where IsDeleted = 0 and id_lang=1 and id_smart_blog_post='" + id + "'";
        ds = data.getDataSet(qq);
        txtDescription.Text = ds.Tables[0].Rows[0]["content"].ToString(); //Server.HtmlEncode(ds.Tables[0].Rows[0]["description"].ToString());
        txtBlogTitle.Text = ds.Tables[0].Rows[0]["meta_title"].ToString();
        txtKeyword.Text = ds.Tables[0].Rows[0]["meta_keyword"].ToString();
        txtMetaDes.Text = ds.Tables[0].Rows[0]["meta_description"].ToString();
        txtShortDes.Text = ds.Tables[0].Rows[0]["short_description"].ToString();
        txtTag.Text= ds.Tables[0].Rows[0]["link_rewrite"].ToString();
        txtUrl.Text= ds.Tables[0].Rows[0]["link_rewrite"].ToString();
        txtPostedBy.Text = ds.Tables[0].Rows[0]["PostedBy"].ToString();
        imgCover.ImageUrl = ds.Tables[0].Rows[0]["img"].ToString();
        string img =  ds.Tables[0].Rows[0]["img"].ToString();
        if (File.Exists(Server.MapPath(img)))
            imgCover.Visible = true;
        else
            imgCover.Visible = false;
        string sq= "Sp_GetBlogTagInOneLine  '" + id + "'";
        DataSet dst = data.getDataSet(sq);
        txtTag.Text= dst.Tables[0].Rows[0][0].ToString();
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();

        }
        string meta_title = txtBlogTitle.Text; string meta_keyword = txtKeyword.Text;string meta_description = txtMetaDes.Text;
        string short_description = txtShortDes.Text; string content = txtDescription.Text; string link_rewrite = txtUrl.Text;
        string PostedBy = txtPostedBy.Text;
        ds = gdate.AddBlogPost(action, ID,meta_title, meta_keyword, meta_description,short_description, content,link_rewrite, PostedBy);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (flapThumb.HasFile)
            {
                string sname = "smart_blog_post_mini_" + ds.Tables[0].Rows[0][0].ToString() + "_1.jpg";
                flapThumb.SaveAs(Server.MapPath("../img/tmp/" + sname));
            }
            string ss = txtTag.Text;
            string[] authorsList = ss.Split(',');
            foreach (string author in authorsList)
            {
                DataSet ds2 = gdate.AddBlogPostTag(author,ds.Tables[0].Rows[0][0].ToString());
            }
            Response.Redirect("BlogPost.aspx");
        }
    }

    protected void txtBlogTitle_TextChanged(object sender, EventArgs e)
    {
        if (txtBlogTitle.Text != "")
        {
            string ss = "Sp_GenerateCategoryUrl '" + txtBlogTitle.Text + "'";
            ds = data.getDataSet(ss);
            txtUrl.Text = ds.Tables[0].Rows[0][0].ToString().ToLower();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backoffice_addcms : System.Web.UI.Page
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
                fillDropdown();
                if (Request.QueryString["id"] != null)
                {
                    FillData();
                    btnSave.Text = "Update";
                    btnSaveAnd.Visible = false;
                }
            }
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
    public void FillData()
    {
        string sq = "select * from ps_cms_lang as L inner join ps_cms as c on c.id_cms=l.id_cms where c.IsDeleted=0 and l.IsDeleted=0 and id_lang=1 and c.id_cms='" + Request.QueryString["id"].ToString() + "'";
        ds = data.getDataSet(sq);
        txtFriendlyURL.Text = ds.Tables[0].Rows[0]["link_rewrite"].ToString();
        txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        txtKeyword.Value = ds.Tables[0].Rows[0]["meta_keywords"].ToString();
        txtMetadescription.Text = ds.Tables[0].Rows[0]["meta_description"].ToString();
        txtMetatitle.Text = ds.Tables[0].Rows[0]["meta_title"].ToString();
        txtPagecontent.Text = ds.Tables[0].Rows[0]["content"].ToString();
        drpCategory.SelectedValue = ds.Tables[0].Rows[0]["id_Menu"].ToString();
        if (ds.Tables[0].Rows[0]["IsCategory"].ToString() == "True")
            radIsCat.Checked = true;
        else
            radIsCat.Checked = false;
    }
    public void fillDropdown()
    {
        // Category

        ds = gdate.GetCMSMenu();
        drpCategory.DataSource = ds;
        drpCategory.DataTextField = "MenuName";
        drpCategory.DataValueField = "id_Menu";
        drpCategory.DataBind();
        drpCategory.Items.Insert(0, new ListItem("CMS Category", "0"));
    }

    protected void btnSaveAnd_Click(object sender, EventArgs e)
    {
        Save();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("cms.aspx");
        }
    }
    public void Save()
    {
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
        }
        string IsCat = "false";
        if (radIsCat.Checked == true)
            IsCat = "true";
        string id_Menu = drpCategory.SelectedValue; string meta_title = txtMetatitle.Text; string meta_description = txtMetadescription.Text;
        string meta_keywords = txtKeyword.Value; string content = txtPagecontent.Text; string link_rewrite = txtFriendlyURL.Text;
        int res = gdate.InsCMS(id_Menu,txtName.Text, meta_title, meta_description, meta_keywords, content, link_rewrite, action, ID,IsCat);
        if (res == 0)
        {
            Response.Redirect("cms.aspx");
        }
    }

    protected void txtMetatitle_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        if (txtMetatitle.Text != "")
        {
            string ss = "Sp_GenerateCategoryUrl '" + txtMetatitle.Text + "'";
            ds = data.getDataSet(ss);
            txtFriendlyURL.Text = ds.Tables[0].Rows[0][0].ToString().ToLower();
        }
    }
}
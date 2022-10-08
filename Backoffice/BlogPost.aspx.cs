using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Backoffice_BlogPost : System.Web.UI.Page
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
       
        ds = gdate.GetBlogPost(txtID.Text, txtTitle.Text,drpStatus.SelectedValue, txtFDate.Text,txtTdate.Text);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        rep.DataSource = ds;
        rep.DataBind();
        lblCount.Text = ds.Tables[0].Rows.Count.ToString();
        //}
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillData();
        btnReset.Visible = true;
    }

    protected void rep_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Ac")
        {

            data.executeCommand("update ps_smart_blog_post set active = (case when active=1 then 0 else 1 end) where id_smart_blog_post=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "Delete")
        {

            data.executeCommand("update ps_smart_blog_post set IsDeleted=1 where id_smart_blog_post=" + e.CommandArgument + "");
            data.executeCommand("update ps_smart_blog_post_lang set IsDeleted=1 where id_smart_blog_post=" + e.CommandArgument + "");
            FillData();
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtFDate.Text = txtID.Text = txtFDate.Text = txtTdate.Text =txtTitle.Text= "";
        drpStatus.SelectedIndex = 0;
        btnReset.Visible = false;
        FillData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                Data data = new Data();
                data.executeCommand("update ps_smart_blog_post set IsDeleted =1  where id_smart_blog_post=" + lblid.Text + "");
                data.executeCommand("update ps_smart_blog_post_lang set IsDeleted =1  where id_smart_blog_post=" + lblid.Text + "");
            }
        }
        FillData();

    }
    protected void btnEnable_Click(object sender, EventArgs e)
    {
        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_smart_blog_post set active = 1 where id_smart_blog_post=" + lblid.Text + "");
            }
        }
        FillData();

    }

    protected void btnDisable_Click(object sender, EventArgs e)
    {
        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_smart_blog_post set active = 0 where id_smart_blog_post=" + lblid.Text + "");
            }
        }
        FillData();
    }
}
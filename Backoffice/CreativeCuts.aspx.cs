using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Backoffice_CreativeCuts : System.Web.UI.Page
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
        string qq = "select * from tbl_CreativeCuts where IsDeleted=0 ";
        if (txtName.Text != "")
            qq += " and Name like '%" + txtName.Text + "%'";
        if (txtContent.Text != "")
            qq += " and Description like '%" + txtContent.Text + "%'";
        if (drpStatus.SelectedIndex>0)
            qq += " and Active like '" + drpStatus.SelectedValue + "'";
        ds = data.getDataSet(qq);

        rep.DataSource = ds;
        rep.DataBind();

    }


    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "update tbl_CreativeCuts set IsDeleted = 1 where ID=" + e.CommandArgument + "";
            data.executeCommand(query);
            FillData();
        }
        if (e.CommandName == "A")
        {

            data.executeCommand("update tbl_CreativeCuts set Active = (case when Active=1 then 0 else 1 end) where ID=" + e.CommandArgument + "");
            FillData();
        }
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
                data.executeCommand("update tbl_CreativeCuts set IsDeleted=1 where ID=" + lblid.Text);
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
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update tbl_CreativeCuts set active = 1 where ID=" + lblid.Text + "");
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
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update tbl_CreativeCuts set active = 0 where ID=" + lblid.Text + "");
            }
        }
        FillData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillData();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreativeCuts.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Backoffice_CartRules : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    private static int PageSize = 50;
    private static int pageNo = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {
            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                Session["Cart"] = null;
                if (Request.QueryString["PageNo"] != null)
                    pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
                else
                    pageNo = 1;
                if (Request.QueryString["PageSize"] != null)
                {
                    drpPageSize.SelectedValue = Request.QueryString["PageSize"];
                }
                else
                {
                    drpPageSize.SelectedValue = "50";
                }
                this.FillData(pageNo);
            }
        }
    }

    public void FillData()
    {
        string sq = "select a.*,b.*,CONVERT(CHAR(11),date_from,103) as dd1,CONVERT(CHAR(11),date_to,103) as dd2 from ps_cart_rule as a inner join ps_cart_rule_lang as b on ";
        sq += " a.id_cart_rule = b.id_cart_rule and b.id_lang = 1 ";
        sq += " where a.IsDeleted = 0 and b.IsDeleted = 0 ";
        if (txtName.Text != "")
            sq +=" and name like '%" + txtName.Text + "%'";
        if (txtCode.Text != "")
            sq += " and code like '%" + txtCode.Text.ToUpper() + "%'";
        if (txtQty.Text != "")
            sq += " and quantity like '%" + txtQty.Text + "%'";
        if (drpStatus.SelectedIndex>0)
            sq += " and active ='" + drpStatus.SelectedValue + "'";
        ds = data.getDataSet(sq);
        rep.DataSource = ds;
        rep.DataBind();
        lblCount.Text = ds.Tables[0].Rows.Count.ToString();
        //}
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillData();
    }

    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "A")
        {
            data.executeCommand("update ps_cart_rule set active = (case when active=1 then 0 else 1 end) where id_cart_rule=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "Delete")
        {
            data.executeCommand("update ps_cart_rule set IsDeleted =1  where id_cart_rule=" + e.CommandArgument + "");
            data.executeCommand("update ps_cart_rule_lang set IsDeleted =1  where id_cart_rule=" + e.CommandArgument + "");
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
                data.executeCommand("update ps_cart_rule set IsDeleted =1  where id_cart_rule=" + lblid.Text + "");
                data.executeCommand("update ps_cart_rule_lang set IsDeleted =1  where id_cart_rule=" + lblid.Text + "");
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
                data.executeCommand("update ps_cart_rule set active = 1 where id_cart_rule=" + lblid.Text + "");
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
                data.executeCommand("update ps_cart_rule set active = 0 where id_cart_rule=" + lblid.Text + "");
            }
        }
        FillData();
    }

    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        FillData();
    }

    protected void btnReferesh_Click(object sender, EventArgs e)
    {
        Response.Redirect("CartRules.aspx");
    }

    public void FillData(int pageIndex)
    {
        int dd = Convert.ToInt32(pageIndex);
       
        ds = gdate.GetCarrtRule(txtName.Text,txtCode.Text.ToUpper(),txtQty.Text, drpStatus.SelectedValue, PageSize.ToString(), pageIndex.ToString());

        rep.DataSource = ds;
        rep.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblTotal.Text = ds.Tables[0].Rows[0]["RecordCount"].ToString();
            this.PopulatePager(Convert.ToInt32(ds.Tables[0].Rows[0]["RecordCount"]), pageIndex);
        }
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / (decimal)PageSize);
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("<<", "1", currentPage > 1));
            if (currentPage != 1)
            {
                pages.Add(new ListItem("Previous", (currentPage - 1).ToString()));
            }
            if (pageCount < 4)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            else if (currentPage < 4)
            {
                for (int i = 1; i <= 4; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("...", (currentPage).ToString(), false));
            }
            else if (currentPage > pageCount - 4)
            {
                pages.Add(new ListItem("...", (currentPage).ToString(), false));
                for (int i = currentPage - 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            else
            {
                pages.Add(new ListItem("...", (currentPage).ToString(), false));
                for (int i = currentPage - 2; i <= currentPage + 2; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("...", (currentPage).ToString(), false));
            }
            if (currentPage != pageCount)
            {
                pages.Add(new ListItem("next", (currentPage + 1).ToString()));
            }
            pages.Add(new ListItem(">>", pageCount.ToString(), currentPage < pageCount));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        // this.FillData(pageIndex);
        ViewState["SNO"] = pageIndex.ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Convert.ToInt32(Request.QueryString["PageSize"]);
        else
            PageSize = 50;
        Response.Redirect("CartRules.aspx?PageNo=" + pageIndex.ToString() + "&&PageSize=" + PageSize.ToString());


    }
    protected void drpPageSize_TextChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("CartRules.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }
}
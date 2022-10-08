using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Backoffice_cms : System.Web.UI.Page
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
  
    public void FillData(int pageIndex)
    {
        int dd = Convert.ToInt32(pageIndex);
        if (Request.QueryString["PageSize"] != null)
            PageSize = Convert.ToInt32(Request.QueryString["PageSize"]);
        else
            PageSize = 50;
        ds = gdate.GetCMS(drpPageSize.SelectedValue, pageIndex.ToString(), txtName.Text, txtTitle.Text, txtUrl.Text, txtPosition.Text);

        ItemsListView.DataSource = ds;
        ItemsListView.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.PopulatePager(Convert.ToInt32(ds.Tables[0].Rows[0]["RecordCount"]), pageIndex);
            // lblCount.Text = ds.Tables[0].Rows[0]["RecordCount"].ToString();
            lblTotal.Text = ds.Tables[0].Rows[0]["RecordCount"].ToString();
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
        if (Request.QueryString["PageSize"] != null)
            PageSize = Convert.ToInt32(Request.QueryString["PageSize"]);
        else
            PageSize = 50;
        Response.Redirect("cms.aspx?PageNo=" + pageIndex.ToString() + "&&PageSize=" + PageSize.ToString());
        ViewState["SNO"] = pageIndex.ToString();
    }
    protected void drpPageSize_TextChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("cms.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        Label lblid;
        foreach (ListViewItem checkedItem in ItemsListView.Items)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)checkedItem.FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)checkedItem.FindControl("lblid");
            if (chk.Checked == true)
            {
                Data data = new Data();
                string query = "update ps_cms set IsDeleted = 1  where id_cms=" + lblid.Text + "";
                data.executeCommand(query);
                string query1 = "update ps_cms_lang set IsDeleted = 1  where id_cms=" + lblid.Text + "";
                data.executeCommand(query1);
              
            }
        }
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("cms.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnEnable_Click(object sender, EventArgs e)
    {
        Label lblid;
        foreach (ListViewItem checkedItem in ItemsListView.Items)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)checkedItem.FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)checkedItem.FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_cms set active = 1 where id_cms=" + lblid.Text + "");
               
            }

        }

        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("cms.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnDisable_Click(object sender, EventArgs e)
    {
        Label lblid;
        foreach (ListViewItem checkedItem in ItemsListView.Items)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)checkedItem.FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)checkedItem.FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_cms set active = 0 where id_cms=" + lblid.Text + "");
                
            }

        }

        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("cms.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }
    protected void ItemsListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "update ps_cms set IsDeleted = 1  where id_cms=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "update ps_cms_lang set IsDeleted = 1  where id_cms=" + e.CommandArgument + "";
            data.executeCommand(query1);
           
        }
        if (e.CommandName == "New")
        {

            data.executeCommand("update ps_cms set active = (case when active=1 then 0 else 1 end) where id_cms=" + e.CommandArgument + "");
          
        }
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("cms.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }
    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "update ps_cms set IsDeleted = 1  where id_cms=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "update ps_cms_lang set IsDeleted = 1  where id_cms=" + e.CommandArgument + "";
            data.executeCommand(query1);
           
        }
        if (e.CommandName == "New")
        {

            data.executeCommand("update ps_cms set active = (case when active=1 then 0 else 1 end) where id_cms=" + e.CommandArgument + "");
           
        }
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("cms.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillData(1);
    }

    protected void ItemsListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {

        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("cms.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("cms.aspx");
    }
}
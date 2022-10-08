using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class Backoffice_CustomerNewsletter : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    private static int PageSize = 50;
    private static int pageNo = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
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
    public void FillData(int pageIndex)
    {

        // dtFinaldate = Convert.ToDateTime(sDateTime);

        int dd = Convert.ToInt32(pageIndex);
        if (Request.QueryString["PageSize"] != null)
            PageSize = Convert.ToInt32(Request.QueryString["PageSize"]);
        else
            PageSize = 50;
        SqlCommand cmd = new SqlCommand("Sp_GetCusNewsLetter");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        if (txtFirstName.Text != "")
            cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text);
        else
            cmd.Parameters.AddWithValue("@firstname", '%');
        if (txtLastName.Text != "")
            cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
        else
            cmd.Parameters.AddWithValue("@lastname", '%');
        if (txtEmail.Text != "")
        {
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
        }
        else
            cmd.Parameters.AddWithValue("@email", '%');
        if (drpStatus.SelectedIndex > 0)
        {
            cmd.Parameters.AddWithValue("@newsletter", drpStatus.SelectedValue);
        }
        else
            cmd.Parameters.AddWithValue("@newsletter", '%');

        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        rep.DataSource = ds;
        rep.DataBind();
        int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
        this.PopulatePager(recordCount, pageIndex);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
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
        Response.Redirect("CustomerNewsletter.aspx?PageNo=" + pageIndex.ToString() + "&&PageSize=" + PageSize.ToString());
        ViewState["SNO"] = pageIndex.ToString();
    }
    //public void FillData()
    //{
    //    ds = data.getDataSet("Sp_GetNewsLetter ");
    //    rep.DataSource = ds;
    //    rep.DataBind();
    //}

    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "Ac")
        {

            data.executeCommand("update ps_customer set newsletter = (case when newsletter=1 then 0 else 1 end) where id_customer=" + e.CommandArgument + "");
            if (Request.QueryString["PageNo"] != null)
                pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
            else
                pageNo = 1;

            Response.Redirect("CustomerNewsletter.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.FillData(1);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("CustomerNewsletter.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }
    protected void drpPageSize_TextChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("CustomerNewsletter.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
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
                data.executeCommand("update ps_customer set IsDeleted = 1 where id_customer=" + lblid.Text);
            }
        }

        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Deleted Successfully......')", true);
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("CustomerNewsletter.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
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
                data.executeCommand("update ps_customer set newsletter = 1 where id_customer=" + lblid.Text + "");
            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Enable Successfully......')", true);
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("CustomerNewsletter.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);

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
                data.executeCommand("update ps_customer set newsletter = 0 where id_customer=" + lblid.Text + "");
            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Disable Successfully......')", true);
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("CustomerNewsletter.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void rep_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Ac")
        {

            data.executeCommand("update ps_customer set newsletter = (case when newsletter=1 then 0 else 1 end) where id_customer=" + e.CommandArgument + "");
            if (Request.QueryString["PageNo"] != null)
                pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
            else
                pageNo = 1;

            Response.Redirect("CustomerNewsletter.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
        }
    }
}
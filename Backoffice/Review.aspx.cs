using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;
using System.Globalization;

public partial class Backoffice_Review : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    private static int PageSize = 100;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {
            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                this.FillData(1);
            }
        }
    }
    public void FillData(int pageIndex)
    {
        int dd = Convert.ToInt32(pageIndex);
        ds = gdate.GetReviewAdmin(PageSize.ToString(), pageIndex.ToString());

        rep.DataSource = ds;
        rep.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.PopulatePager(Convert.ToInt32(ds.Tables[0].Rows[0]["RecordCount"]), pageIndex);
        }
    }
    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            //Data data = new Data();
            //string query = "update tbl_Warehouse set IsDeleted = 1,UpdateLoginId=0,UpdateDate=getdate()  where ID=" + e.CommandArgument + "";
            //data.executeCommand(query);
            this.FillData(1);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.FillData(1);
    }

    protected void rep_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
       
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            data.executeCommand("update ps_product_comment set deleted=1  where id_product_comment=" + e.CommandArgument + "");
           //data.executeCommand("delete from ps_product_tag  where id_tag=" + e.CommandArgument + "");
            this.FillData(1);
        }
        if (e.CommandName == "New")
        {

            data.executeCommand("update ps_product_comment set active = (case when active=1 then 0 else 1 end) where id_product_comment=" + e.CommandArgument + "");
            this.FillData(1);
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
        this.FillData(pageIndex);
    }

    protected void rep_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
          
            //Rating Rating1 = (Rating)e.Item.FindControl("rateTweet");
            //Rating1.CurrentRating= Convert.ToInt32(2);
            //HtmlGenericControl eventdiv = (HtmlGenericControl)e.Item.FindControl("eventdiv");
            //Label lblRat = (Label)e.Item.FindControl("lblRat");
            //Rating Rating1 = (Rating)e.Item.FindControl("Rating1");
            //if (lblRat.Text !="")
            //{   
            //    eventdiv.Visible = false;
            //    Rating1.Visible = true;
            //    Rating1.CurrentRating = Convert.ToInt32(lblRat.Text);
            //}
            //else
            //{
            //    eventdiv.Visible = false;
            //    Rating1.Visible = true;
            //    Rating1.CurrentRating = Convert.ToInt32(lblRat.Text);
            //}
        }
    }
    protected void Rating1_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        string ss = e.Value;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Backoffice_CustomerPaymentStatus : System.Web.UI.Page
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
        ds = gdate.GetCustomerPaymentStatus(drpPageSize.SelectedValue, pageIndex.ToString(), txtCartId.Text, "", txtCustomer.Text, drpStatus.SelectedValue); ;

        rep.DataSource = ds;
        rep.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.PopulatePager(Convert.ToInt32(ds.Tables[0].Rows[0]["RecordCount"]), pageIndex);
            // lblCount.Text = ds.Tables[0].Rows[0]["RecordCount"].ToString();
            //lblCount.Text = ds.Tables[0].Rows.Count.ToString();
            lblTotal.Text = ds.Tables[0].Rows[0]["RecordCount"].ToString();
        }
    }
    double shipamount = 0;double FreeShippingAmt = 0;double Tot = 0;
    protected string Total(object AddId, object id_customer, object Total)
    {
        GData gData = new GData();
        if (AddId.ToString() != "" && AddId.ToString() != null && AddId.ToString() != "0")
        {
            string addidd = AddId.ToString();
            try
            {
              DataSet  dsSA = gData.GetShipingAmt(id_customer.ToString(), addidd);
                if (dsSA.Tables[0].Rows.Count > 0)
                {
                    string Ship_Amt = dsSA.Tables[0].Rows[0]["Ship_Amt"].ToString();
                    string MinShipAMt = dsSA.Tables[0].Rows[0]["MinShip_Amt"].ToString();
                    if (Ship_Amt != "" || Ship_Amt != "0")
                    {
                        shipamount = Convert.ToDouble(Ship_Amt);
                    }

                    if (MinShipAMt != "" || MinShipAMt != "0")
                    {
                        FreeShippingAmt = Convert.ToDouble(MinShipAMt);
                    }
                }
            }
            catch
            {
                shipamount = 100;
            }
        }
        if(Total.ToString() !="")
        {
            Tot = Convert.ToDouble(Total.ToString());
        }
        return (shipamount + Tot).ToString();
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
        Response.Redirect("CustomerPaymentStatus.aspx?PageNo=" + pageIndex.ToString() + "&&PageSize=" + PageSize.ToString());
        ViewState["SNO"] = pageIndex.ToString();
    }
    protected void drpPageSize_TextChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("CustomerPaymentStatus.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.FillData(1);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerPaymentStatus.aspx");
    }
}
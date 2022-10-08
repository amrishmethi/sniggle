using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_index : System.Web.UI.Page
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
                txtFDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtTDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                FillOrder();

            }
        }
    }
    private string ConvertToDateTime(string strDateTime)
    {
        string sDateTime;
        string[] sDate = strDateTime.Split('/');
        sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
        return sDateTime;
    }
    public void FillOrder()
    {
        ds = data.getDataSet("Sp_GetOrderDashboard '" + ConvertToDateTime(txtFDate.Text) + "','" + ConvertToDateTime(txtTDate.Text) + "'");
        repOrder.DataSource = ds;
        repOrder.DataBind();
        //}
        string ss = "Sp_GetDasBoardNotification '" + ConvertToDateTime(txtFDate.Text) + "','" + ConvertToDateTime(txtTDate.Text) + "'";
        DataSet dsN = data.getDataSet(ss);
        lblContact.Text = dsN.Tables[0].Rows[0]["ContactUs"].ToString();
        lblcreative.Text = dsN.Tables[0].Rows[0]["Cuts"].ToString();
        lblCustom.Text = dsN.Tables[0].Rows[0]["CustomeOrder"].ToString();
        lblEnquire.Text = dsN.Tables[0].Rows[0]["Enquiry"].ToString();
        lblRequest.Text = dsN.Tables[0].Rows[0]["Request"].ToString();
        lblOrde.Text = dsN.Tables[0].Rows[0]["OrderC"].ToString();
        lblCart.Text = dsN.Tables[0].Rows[0]["Cart"].ToString();
        lblNewCustomer.Text = dsN.Tables[0].Rows[0]["Customer"].ToString();
        lblSale.Text = dsN.Tables[0].Rows[0]["Sale"].ToString();
        lblOrder.Text = dsN.Tables[0].Rows[0]["Orders"].ToString();
        lblSubscriptions.Text = dsN.Tables[0].Rows[0]["SubsTot"].ToString();
        lblVisite.Text = dsN.Tables[0].Rows[0]["VisitTot"].ToString();
        lblReOrder.Text= dsN.Tables[0].Rows[0]["ReOrderTot"].ToString();
        DataSet Bestds = data.getDataSet("Sp_GetBestSellingProduct '" + ConvertToDateTime(txtFDate.Text) + "','" + ConvertToDateTime(txtTDate.Text) + "'");
        repBestSeller.DataSource = Bestds;
        repBestSeller.DataBind();
        string most = "Sp_Get_MostViewProduct '" + ConvertToDateTime(txtFDate.Text) + "','" + ConvertToDateTime(txtTDate.Text) + "'";
        DataSet Mostds = data.getDataSet(most);
        repMostView.DataSource = Mostds;
        repMostView.DataBind();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillOrder();
    }

    protected void btnDay_Click(object sender, EventArgs e)
    {
        txtFDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtTDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        FillOrder();
    }

    protected void btnMonth_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        var startDate = new DateTime(now.Year, now.Month, 1);
        var endDate = startDate.AddMonths(1).AddDays(-1);
        txtFDate.Text = startDate.ToString("dd/MM/yyyy");
        txtTDate.Text = endDate.ToString("dd/MM/yyyy");
        FillOrder();
    }

    protected void btnYear_Click(object sender, EventArgs e)
    {
        int year = DateTime.Now.Year;
        DateTime firstDay = new DateTime(year, 1, 1);
        DateTime lastDay = new DateTime(year, 12, 31);
        txtFDate.Text = firstDay.ToString("dd/MM/yyyy");
        txtTDate.Text = lastDay.ToString("dd/MM/yyyy");
        FillOrder();
    }

    protected void btnDay1_Click(object sender, EventArgs e)
    {

        txtFDate.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
        txtTDate.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
        FillOrder();
    }

    protected void btnMonth1_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        var today = DateTime.Today;
        var month = new DateTime(today.Year, today.Month, 1);
        var first = month.AddMonths(-1);
        var last = month.AddDays(-1);
        txtFDate.Text = first.ToString("dd/MM/yyyy");
        txtTDate.Text = last.ToString("dd/MM/yyyy");
        FillOrder();
    }

    protected void btnYear1_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        var today = DateTime.Today;
        var year = new DateTime(today.Year, today.Month, 1);
        var first = year.AddYears(-1);
        var last = year.AddDays(-1);
        txtFDate.Text = first.ToString("dd/MM/yyyy");
        txtTDate.Text = last.ToString("dd/MM/yyyy");
        FillOrder();
    }
}
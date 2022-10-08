using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using Razorpay.Api;
using System.Net;

public partial class Checkout : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    Data dat = new Data();
    GetData data = new GetData();
    GData gdata = new GData();
    public int coun = 10;
    string totProdAmt = "";
    string UserID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = dat.getDataSet("select * From ps_cms_lang  where id_lang = 1 and id_cms = '36'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.Page.Title = ds.Tables[0].Rows[0]["meta_title"].ToString();
                HtmlMeta keywords = new HtmlMeta();
                keywords.Name = "keywords";
                keywords.Content = ds.Tables[0].Rows[0]["meta_keywords"].ToString();
                this.Page.Header.Controls.Add(keywords);
                Page.Header.Controls.Add(new LiteralControl("\n"));
                HtmlMeta keywords1 = new HtmlMeta();
                keywords1.Name = "description";
                string dss = ds.Tables[0].Rows[0]["meta_description"].ToString();
                keywords1.Content = dss;
                Page.Header.Controls.Add(new LiteralControl("\n"));
                this.Page.Header.Controls.Add(keywords1);
            } 
            if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
            {
                HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
                UserID = user.Values["id_customer"].ToString();
            }
            string cartID = "";
            if (HttpContext.Current.Request.Cookies["cartSG"] != null)
            {
                if (Session["TotalProdAmt"] != null)
                {
                    totProdAmt = Session["TotalProdAmt"].ToString();
                    double totproamt = Convert.ToDouble(totProdAmt);
                    HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
                    cartID = user.Values["cartID"].ToString();
                    FillRazorPayDetail(totproamt, UserID, cartID);
                }
                //hrefBwSuccess.HRef = "BwSuccess.aspx?orderid=" + cartID + "";
            }
        }
    }
    public void FillRazorPayDetail(double finalAmt, string userID, string cartId)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        //finalAmt = 1;
        finalAmt = finalAmt * 100;
        //finalAmt = 100;
        string key = "rzp_live_o2BnycHhBbZNJP";
        string secret = "9kH5EZ5ppyA8wxetqq9HUT8c";
        RazorpayClient client = new RazorpayClient(key, secret);
        Dictionary<string, object> options = new Dictionary<string, object>();
        options.Add("amount", finalAmt);
        options.Add("payment_capture", 1);
        options.Add("currency", "INR");
        Order order = client.Order.Create(options);
        hddOrderId.Value = order.Attributes.id;
        string ddd = "Update ps_cart set secure_key = '" + order.Attributes.id + "' where id_cart = " + cartId + " and id_customer = '" + userID + "'";
        dat.executeCommand(ddd);
    }

    protected void btnCOD_Click(object sender, EventArgs e)
    {

    }
}
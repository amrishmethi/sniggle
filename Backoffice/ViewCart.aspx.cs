using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Backoffice_ViewCart : System.Web.UI.Page
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
                if (Request.QueryString["id"] != null)
                {
                    FillData(Request.QueryString["id"].ToString());
                }

            }
        }
    }
    public void FillData(string id)
    {
        ds = data.getDataSet("Sp_GetCartSummary '" + id + "'");
        RepOrderD.DataSource = ds;
        RepOrderD.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCartId.Text = ds.Tables[0].Rows[0]["id_cart"].ToString();
            DataTable table = ds.Tables[0];
            object sumObject;
            sumObject = table.Compute("Sum(Total)", string.Empty);
            lblTotal.Text = sumObject.ToString();
            //id_customer
            if (ds.Tables[0].Rows[0]["id_customer"].ToString() != "" || ds.Tables[0].Rows[0]["id_customer"].ToString() != "0")
            {
                DataSet dsCust = data.getDataSet("Sp_GetCustomerDetailA '" + ds.Tables[0].Rows[0]["id_customer"].ToString() + "'");
                if (dsCust.Tables[0].Rows.Count > 0)
                {
                    AncCustomer.HRef = "ViewCustomers.aspx?id="+ ds.Tables[0].Rows[0]["id_customer"].ToString();
                    reg.Visible = true;
                    NotReg.Visible = false;
                    lblCName.Text = dsCust.Tables[0].Rows[0]["CustName"].ToString();
                    lblEmail.Text = dsCust.Tables[0].Rows[0]["email"].ToString();
                    ancEmail.HRef = "mailto:" + dsCust.Tables[0].Rows[0]["email"].ToString();
                    lblRegDate.Text = dsCust.Tables[0].Rows[0]["date_add"].ToString();

                    lblAge.Text = dsCust.Tables[0].Rows[0]["Age"].ToString();
                    lblDOB.Text = dsCust.Tables[0].Rows[0]["birthday"].ToString();
                    lblLang.Text = dsCust.Tables[0].Rows[0]["lang"].ToString();
                    lblLastVisitDate.Text = "";
                   // lblMr.Text = dsCust.Tables[0].Rows[0]["title"].ToString();
                    lblStatus.Text = dsCust.Tables[0].Rows[0]["Active"].ToString();
                    lblOpt.Text = dsCust.Tables[0].Rows[0]["optin"].ToString();
                    lblUpdateDate.Text = dsCust.Tables[0].Rows[0]["date_add"].ToString();
                }
                else
                {
                    reg.Visible = false;
                    NotReg.Visible = true;
                }
            }

        }
    }
}
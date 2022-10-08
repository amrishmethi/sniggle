using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_AddCartRules : System.Web.UI.Page
{
    AdminGetData gdata = new AdminGetData();
    DataSet ds = new DataSet();
    Data data = new Data();
    HttpCookie AdminCookie;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                BindCustomer();
                if (Request.QueryString["id"] != null)
                {
                    BindData(Request.QueryString["id"].ToString());
                    Session["Cart"] = Request.QueryString["id"].ToString();
                    //btnSave.Text = "Update";
                    //btnSaveAnd.Visible = false;
                }
                if(Session["Cart"] !=null)
                {
                    BindData(Session["Cart"].ToString());
                }
            }
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }

    }
    public void BindData(string id)
    {
        string sq = "select a.*,b.*,CONVERT(CHAR(11),date_from,103) as dd1,CONVERT(CHAR(11),date_to,103) as dd2 from ps_cart_rule as a inner join ps_cart_rule_lang as b on ";
        sq += " a.id_cart_rule = b.id_cart_rule and b.id_lang = 1 ";
        sq += " where a.IsDeleted = 0 and b.IsDeleted = 0 and a.id_cart_rule = '" + id + "'";
        ds = data.getDataSet(sq);
        DrpCustomer.SelectedValue = ds.Tables[0].Rows[0]["id_customer"].ToString();
        txtFDate.Text = ds.Tables[0].Rows[0]["dd1"].ToString();
        txtTdate.Text = ds.Tables[0].Rows[0]["dd2"].ToString();
        txtDesc.Text = ds.Tables[0].Rows[0]["description"].ToString();
        txtTotalAv.Text = ds.Tables[0].Rows[0]["quantity"].ToString();
        txtCode.Text = ds.Tables[0].Rows[0]["code"].ToString();
        txtMinAmt.Text = ds.Tables[0].Rows[0]["minimum_amount"].ToString();
        drpAmttype.SelectedValue = ds.Tables[0].Rows[0]["minimum_amount_currency"].ToString();
        txtDisValue.Text = ds.Tables[0].Rows[0]["reduction_percent"].ToString();
        txtAmount.Text = ds.Tables[0].Rows[0]["reduction_amount"].ToString();
        drpDisAmtTyp.SelectedValue = ds.Tables[0].Rows[0]["reduction_currency"].ToString();
        drpStatus.SelectedValue = ds.Tables[0].Rows[0]["active"].ToString();
        txtName.Text= ds.Tables[0].Rows[0]["name"].ToString();
        txtTotalAvAllUser.Text= ds.Tables[0].Rows[0]["quantity_per_user"].ToString();
        drpShip.SelectedValue= ds.Tables[0].Rows[0]["minimum_amount_shipping"].ToString();
    }
    public void BindCustomer()
    {
        string query = " select id_customer,isnull(firstname,'')+' '+isnull(lastname,'')+' - '+isnull(email,'') as name from ps_customer where deleted=0";
        ds = data.getDataSet(query);

        DrpCustomer.DataSource = ds;
        DrpCustomer.DataTextField = "name";
        DrpCustomer.DataValueField = "id_customer";
        DrpCustomer.DataBind();
        DrpCustomer.Items.Insert(0, new ListItem("All customers", "0"));
    }
    public static string GenerateCoupon()
    {
        Random random = new Random();
        string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        StringBuilder result = new StringBuilder(8);
        for (int i = 0; i < 8; i++)
        {
            result.Append(characters[random.Next(characters.Length)]);
        }
        return result.ToString();
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        string ss = GenerateCoupon().ToString();
        txtCode.Text = ss;
    }
    public void Save()
    {
        ///var productText = Server.HtmlEncode("<p>example</p>");
        string Action = "Add"; string id_cart_rule = "0";
        string id_customer = DrpCustomer.SelectedValue; string date_from = txtFDate.Text; string date_to = txtTdate.Text; string description = txtDesc.Text;
        string quantity = txtTotalAv.Text; string quantity_per_user = txtTotalAvAllUser.Text; string code = txtCode.Text; string minimum_amount = txtMinAmt.Text;
        string minimum_amount_currency = drpAmttype.SelectedValue; string reduction_percent = txtDisValue.Text;
        string reduction_amount = txtAmount.Text; string reduction_currency = drpDisAmtTyp.SelectedValue; string active = drpStatus.SelectedValue;
        string name = txtName.Text; string minimum_amount_shipping = drpShip.SelectedValue;
        if (Request.QueryString["id"] != null)
        {
            Action = "Update";
            id_cart_rule = Request.QueryString["id"].ToString();
        }
        else if (Session["Cart"] != null)
        {
            Action = "Update";
            id_cart_rule = Session["Cart"].ToString();
        }
       
            ds = gdata.AddCartRules(Action, id_customer, date_from, date_to, description, quantity,
         quantity_per_user, code, minimum_amount, minimum_amount_currency,
         reduction_percent, reduction_amount, reduction_currency, active, id_cart_rule, name, minimum_amount_shipping);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["Cart"] = ds.Tables[0].Rows[0][0].ToString();
                BindData(Session["Cart"].ToString());
            }
       
    }
    protected void btnInfoSave_Click(object sender, EventArgs e)
    {
        Save();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        Session["Cart"] = null;
        Response.Redirect("CartRules.aspx");
    }

    protected void btnCancel1_Click(object sender, EventArgs e)
    {
        Session["Cart"] = null;
        Response.Redirect("CartRules.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["Cart"] = null;
        Response.Redirect("CartRules.aspx");
    }
}
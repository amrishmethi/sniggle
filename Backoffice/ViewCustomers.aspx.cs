using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_ViewCustomers : System.Web.UI.Page
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
                if (Request.QueryString["id"] != null)
                {
                    FillData(Request.QueryString["id"].ToString());
                    //BindStatus();
                }

            }
        }
    }
    public void FillData(string id)
    {

        DataSet dsCust = data.getDataSet("Sp_GetCustomerDetailA '" + id + "'");
        lblCName.Text = dsCust.Tables[0].Rows[0]["firstname"].ToString()+" "+ dsCust.Tables[0].Rows[0]["lastname"].ToString();
        lblEmail.Text = dsCust.Tables[0].Rows[0]["email"].ToString();
        ancEmail.HRef = "mailto:" + dsCust.Tables[0].Rows[0]["email"].ToString();
        lblRegDate.Text = dsCust.Tables[0].Rows[0]["date_add"].ToString(); 

        lblAge.Text = dsCust.Tables[0].Rows[0]["Age"].ToString();
        lblDOB.Text = dsCust.Tables[0].Rows[0]["birthday"].ToString();
        lblLang.Text = dsCust.Tables[0].Rows[0]["lang"].ToString();
       // lblLastVisitDate.Text = "";
        lblMr.Text = dsCust.Tables[0].Rows[0]["title"].ToString();
        lblStatus.Text = dsCust.Tables[0].Rows[0]["Active"].ToString();
       // lblOpt.Text = dsCust.Tables[0].Rows[0]["optin"].ToString();
        lblUpdateDate.Text = dsCust.Tables[0].Rows[0]["date_upd"].ToString();

        DataSet dsOrder = data.getDataSet("Sp_GetCustomerOrderAdmin '" + id + "'");
        repOrder.DataSource = dsOrder;
        repOrder.DataBind();
        lblOrdeCounr.Text = dsOrder.Tables[0].Rows.Count.ToString();
        lblOrdeCounr.Text = dsOrder.Tables[0].Rows.Count.ToString();
        if(dsOrder.Tables[0].Rows.Count>0)
        {
            //DataTable table = dsOrder.Tables[0];

            //// Declare an object variable.
            //object sumObject;
            //sumObject = table.Compute("Sum(total_paid_tax_incl)", string.Empty);
            //Lalbltotalbel1.Text = sumObject.ToString();
        }

        DataSet dsValid = data.getDataSet("Sp_GetValidOrderByCustomer '" + id + "'");
        if (dsValid.Tables[0].Rows.Count > 0)
        {
            Lalbltotalbel1.Text = dsValid.Tables[0].Rows[0]["total_paid"].ToString();
            lblValid.Text = dsValid.Tables[1].Rows[0]["Valid"].ToString();
            lblInValid.Text = dsValid.Tables[2].Rows[0]["InValid"].ToString();
           
        }

        DataSet dsPur = data.getDataSet("Sp_GetOrderByCustomer '" + id + "'");
        repPurchase.DataSource = dsPur;
        repPurchase.DataBind();
        lblPurchaseProduct.Text = dsPur.Tables[0].Rows.Count.ToString();

        DataSet dsMess = data.getDataSet("Sp_GetCustomermessege '" + id + "'");
        RepMess.DataSource = dsMess;
        RepMess.DataBind();
        lblMessTot.Text = dsMess.Tables[0].Rows.Count.ToString();

        DataSet dsCart = data.getDataSet("Sp_GetCustomercart '" + id + "'");
        repCart.DataSource = dsCart;
        repCart.DataBind();
        lblCartTot.Text = dsCart.Tables[0].Rows.Count.ToString();
        string saa = "select a.*,c.name,s.name as stste from ps_address as a left outer join ps_country_lang as c on a.id_country=c.id_country and id_lang=1";
        saa += " LEFT OUTER JOIN ps_state as s on s.id_state=a.id_state where id_customer='" + id + "' and deleted=0 and IsDeleted=0";
        DataSet dsAdd = data.getDataSet(saa);
        if (dsAdd.Tables[0].Rows.Count > 0)
        {
            repAdd.DataSource = dsAdd;
            repAdd.DataBind();
            lblAddress.Text = dsAdd.Tables[0].Rows.Count.ToString();
        }
        if (dsAdd.Tables[0].Rows.Count < 0)
        {
            repAdd.DataSource = null;
            repAdd.DataBind();
            lblAddress.Text = "0";
        }

        DataSet dsWish = data.getDataSet("sp_GetWishlistCustAdmin '" + id + "'");
        repWish.DataSource = dsWish;
        repWish.DataBind();
        lblTotWish.Text = dsWish.Tables[0].Rows.Count.ToString();

        string sq = "select a.*,b.*,CONVERT(CHAR(11),date_from,103) as dd1,CONVERT(CHAR(11),date_to,103) as dd2,case when ( select count(*) from ps_orders where gift=a.id_cart_rule and id_customer='"+id+"')>0 then 'Used' else 'Not Used' end as Status from ps_cart_rule as a inner join ps_cart_rule_lang as b on ";
        sq += " a.id_cart_rule = b.id_cart_rule and b.id_lang = 1 ";
        sq += " where a.IsDeleted = 0 and b.IsDeleted = 0 ";
        
        ds = data.getDataSet(sq);
        rep.DataSource = ds;
        rep.DataBind();
        lblTotVoucher.Text = ds.Tables[0].Rows.Count.ToString();
        DataSet dsLast = data.getDataSet("Sp_ViewLastProductByCust '" + id + "'");
        repLastViewProduct.DataSource = dsLast;
        repLastViewProduct.DataBind();
    }
}
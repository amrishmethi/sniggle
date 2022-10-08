using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Razorpay;
using Razorpay.Api;

public partial class CODSuccess : System.Web.UI.Page
{
    DataSet dsExist = new DataSet();
    Data data = new Data();
    GData gData = new GData();
    GetData getData = new GetData();
    DataSet ds = new DataSet();
    DataSet dsSA = new DataSet();
    SqlCommand cmd = new SqlCommand();
    EmailFormat EF = new EmailFormat();
    double shipamount = 0.00;
    string cartID = "0";
    string UserID = "";
    string query;
    SqlDataReader dr;
    public double FreeShippingAmt = 1500;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
                {
                    divCustLogout.Visible = false;
                    string orderid = "";

                    HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
                    UserID = user.Values["id_customer"].ToString();

                    if (HttpContext.Current.Request.Cookies["cartSG"] != null)
                    {
                        HttpCookie cart = HttpContext.Current.Request.Cookies["cartSG"];
                        orderid = cart.Values["cartID"].ToString();
                    }
                    lblOrderno.Text = orderid;
                    //createOrder("8", "order_IKgUTR60kdO7YZ", "order_IKgUTR60kdO7YZ");
                    dsExist = data.getDataSet(" Select * From ps_orders where id_cart = '" + orderid + "'");
                    if (dsExist.Tables[0].Rows.Count == 0)
                    { 
                        string Rorderid = RandomString(10);
                        string paymetnID = "COD";
                        createOrder(orderid, paymetnID, Rorderid);
                    }
                }
                else
                {
                    DivDetailFailed.Visible = false;
                    DivDetailSuccess.Visible = false;
                    divCustLogout.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string dd = ex.Message;
                DivDetailSuccess.Visible = false;
                DivDetailFailed.Visible = true;
            }
        }
    }
    public void createOrder(string cartID, string TrId, string Reference)
    {
        double discount = 0;
        bool IsSuccess = false;
        decimal Amount = 0;
        string UserID = "0";
        Data dat = new Data();
        DataTable tbl = new DataTable();
        tbl.Columns.Add("ProdID", typeof(string));
        tbl.Columns.Add("AttributeID", typeof(string));
        tbl.Columns.Add("Attribute", typeof(string));
        tbl.Columns.Add("SKU", typeof(string));
        tbl.Columns.Add("Qty", typeof(Int32));
        tbl.Columns.Add("Price", typeof(decimal));
        tbl.Columns.Add("DisPrice", typeof(decimal));
        tbl.Columns.Add("Amount", typeof(decimal));
        tbl.Columns.Add("TotalAmount", typeof(decimal));
        tbl.Columns.Add("TotalCount", typeof(double));
        tbl.Columns.Add("Image1", typeof(string));
        tbl.Columns.Add("ProdName", typeof(string));
        tbl.Columns.Add("Shipping", typeof(decimal));
        tbl.Columns.Add("NetAmount", typeof(decimal));
        tbl.Columns.Add("GrossAmount", typeof(decimal));
        tbl.Columns.Add("Name", typeof(string));
        tbl.Columns.Add("Flat", typeof(string));
        tbl.Columns.Add("Address", typeof(string));
        tbl.Columns.Add("Locality", typeof(string));
        tbl.Columns.Add("FreeItem", typeof(string));
        tbl.Columns.Add("Pincode", typeof(string));
        tbl.Columns.Add("ShipID", typeof(string));
        tbl.Columns.Add("EmailID", typeof(string));
        tbl.Columns.Add("MobileNo", typeof(string));
        tbl.Columns.Add("DiscountType", typeof(string));
        tbl.Columns.Add("CouponDiscount", typeof(decimal));
        tbl.Columns.Add("DiscountCode", typeof(string));

        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }

        string qqq = ""; 
        qqq = "select  cp.*,pa.reference,pl.name,pa.price+prod.price as price,'/img/'+RTRIM(LTRIM(REPLACE(cat.name,'/','-')))+'/'+ cast((select top 1 id_image from ps_image where IsDeleted = 0 and Cover = 1 and id_product = cp.id_product) as nvarchar(50)) +'.jpg' as URL,prod.minimal_quantity, cart.gift, ";

        qqq += " REPLACE(REPLACE(cat.link_rewrite,' ','-'),'/-','')+'/'+cast(prod.id_product as nvarchar(50))+'-'+  + ISNULL(REPLACE(pl.link_rewrite, ' ', '-'), '') + '.html' as DetailUrl,";
        //calculate discountprice
        qqq += "  cast(cast((cast(prod.price as decimal(18,2))- (case when (select top(1) isnull(reduction,0)  ";
        qqq += " from ps_specific_price  as  sp where  sp.IsDeleted = 0 and id_product=prod.id_product) is null then 0 else  ";
        qqq += " (((select top(1) isnull(sp.reduction,0) from ps_specific_price as  sp where  sp.IsDeleted = 0 and ";
        qqq += " sp.id_product=prod.id_product))*cast(prod.price as decimal(18,2))) end) / 100) as decimal(18,2)) + pa.price as decimal(18,2))   as DiscountPrice ";
        qqq += " , cart.id_address_delivery as AddId ";

        qqq += " from ps_cart_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category inner join ps_cart cart on cp.id_cart=cart.id_cart ";
        qqq += " where  pl.id_lang = 1 and cat.id_lang = 1 ";
        if (cartID != "0")
        {
            qqq += " and cp.id_cart = " + cartID + "";
        }

        DataSet dsn = new DataSet();
        dsn = dat.getDataSet(qqq);

        if (dsn.Tables[0].Rows.Count > 0)
        {
            //calculate shipping amount
            if (UserID != "" && UserID != "0")
            {
                if (dsn.Tables[0].Rows[0]["AddId"].ToString() != "" && dsn.Tables[0].Rows[0]["AddId"].ToString() != null && dsn.Tables[0].Rows[0]["AddId"].ToString() != "0")
                {
                    string addidd = dsn.Tables[0].Rows[0]["AddId"].ToString();
                    try
                    {
                        dsSA = gData.GetShipingAmt(UserID, addidd);
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
            }
        }

        tbl.Rows.Clear();
        for (int i = 0; i < dsn.Tables[0].Rows.Count; i++)
        {
            DataRow dtrow = tbl.NewRow();
            dtrow["ProdID"] = dsn.Tables[0].Rows[i]["id_product"].ToString();
            dtrow["AttributeID"] = dsn.Tables[0].Rows[i]["id_product_attribute"].ToString();
            dtrow["Qty"] = Convert.ToInt32(dsn.Tables[0].Rows[i]["quantity"].ToString());
            dtrow["SKU"] = dsn.Tables[0].Rows[i]["reference"].ToString();
            dtrow["Price"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
            dtrow["DisPrice"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["DiscountPrice"].ToString()));
            Amount = Convert.ToDecimal(dsn.Tables[0].Rows[i]["DiscountPrice"].ToString()) * (Convert.ToDecimal(dsn.Tables[0].Rows[i]["quantity"].ToString()));
            dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
            dtrow["Image1"] = dsn.Tables[0].Rows[i]["URL"].ToString();
            dtrow["ProdName"] = dsn.Tables[0].Rows[i]["name"].ToString();
            DataSet dsA = data.getDataSet("select distinct ag.position, agl.name as groupname, alm.name as attributename from ps_product prod  inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute  inner join ps_attribute_lang alm on pac.id_attribute=alm.id_attribute inner join ps_attribute at on alm.id_attribute=at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group=agl.id_attribute_group inner join ps_attribute_group ag on agl.id_attribute_group=ag.id_attribute_group where prod.id_product = " + dsn.Tables[0].Rows[i]["id_product"].ToString() + " and pa.id_product_attribute = " + dsn.Tables[0].Rows[i]["id_product_attribute"].ToString() + "  and prod.active = 1 and alm.id_lang = 1 and agl.id_lang = 1 order by ag.position");
            if (dsA.Tables[0].Rows.Count > 0)
            {
                string att = "";
                for (int j = 0; j < dsA.Tables[0].Rows.Count; j++)
                {
                    if (j == 0)
                        att = dsA.Tables[0].Rows[j]["groupname"].ToString() + " : " + dsA.Tables[0].Rows[j]["attributename"].ToString();
                    else
                        att += ", " + dsA.Tables[0].Rows[j]["groupname"].ToString() + " : " + dsA.Tables[0].Rows[j]["attributename"].ToString();
                }
                dtrow["Attribute"] = att;
            }
            tbl.Rows.Add(dtrow);
        }

        if (tbl.Rows.Count > 0)
        {
            double netAmount = 0;
            double TttolAmt = Convert.ToDouble(tbl.Compute("SUM(Amount)", "").ToString());
            tbl.Rows[0]["TotalAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", "").ToString())));
            tbl.Rows[0]["TotalCount"] = Convert.ToDouble(tbl.Compute("SUM(Qty)", "").ToString());
            if (TttolAmt > 1500)
            {
                tbl.Rows[0]["Shipping"] = 0;
                tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", ""))));
                netAmount = Convert.ToDouble(tbl.Compute("SUM(Amount)", ""));
            }
            else
            {
                tbl.Rows[0]["Shipping"] = shipamount;
                tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", "")) + shipamount));
                netAmount = Convert.ToDouble(tbl.Compute("SUM(Amount)", "")) + Convert.ToDouble(shipamount);
            }

            double TotAmt = Convert.ToDouble(tbl.Compute("SUM(Amount)", "")); 

            if (dsn.Tables[0].Rows[0]["gift"].ToString() != "0")
            {
                double discountedAmt = 0;
                DataSet dsDis = new DataSet();
                dsDis = dat.getDataSet("select reduction_percent, reduction_amount, code, minimum_amount_shipping from ps_cart_rule where id_cart_rule=" + dsn.Tables[0].Rows[0]["gift"].ToString() + "");
                string discountPer = dsDis.Tables[0].Rows[0]["reduction_percent"].ToString();
                string disAmt = dsDis.Tables[0].Rows[0]["reduction_amount"].ToString();
                string shipExInclu = dsDis.Tables[0].Rows[0]["minimum_amount_shipping"].ToString();
                if (shipExInclu == "0")
                {
                    discountedAmt = TotAmt;
                }
                else
                {
                    discountedAmt = TotAmt + Convert.ToDouble(shipamount);
                }
                if (discountPer != "0.00")
                {
                    discount = (discountedAmt * Convert.ToDouble(discountPer)) / 100;
                }
                else
                {
                    if (disAmt != "0.00")
                    {
                        discount = Convert.ToDouble(disAmt);
                    }
                }
                tbl.Rows[0]["DiscountCode"] = dsDis.Tables[0].Rows[0]["code"].ToString();
                tbl.Rows[0]["CouponDiscount"] = discount;
                netAmount = netAmount - discount;
            }
            tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(netAmount)));

            DataSet dsA = data.getDataSet("select * from ps_cart where id_cart=" + cartID + "");
            string DeliverAddressID = dsA.Tables[0].Rows[0]["id_address_delivery"].ToString();
            string BillAddressID = dsA.Tables[0].Rows[0]["id_address_invoice"].ToString();
            string id_carrier = dsA.Tables[0].Rows[0]["id_carrier"].ToString();
            string id_currency = dsA.Tables[0].Rows[0]["id_currency"].ToString();
            string recyclable = dsA.Tables[0].Rows[0]["recyclable"].ToString();
            string gift = dsA.Tables[0].Rows[0]["gift"].ToString();

            string gift_message = dsA.Tables[0].Rows[0]["gift_message"].ToString();
            string mobile_theme = dsA.Tables[0].Rows[0]["mobile_theme"].ToString();
            string shipping_number = "";

            cmd = new SqlCommand("sp_InsertOrderMaster");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reference", Reference);
            cmd.Parameters.AddWithValue("@id_shop_group", "1");
            cmd.Parameters.AddWithValue("@id_shop", "1");
            cmd.Parameters.AddWithValue("@id_carrier", id_carrier);

            cmd.Parameters.AddWithValue("@id_lang", "1");
            cmd.Parameters.AddWithValue("@id_customer", UserID);
            cmd.Parameters.AddWithValue("@id_cart", cartID);
            cmd.Parameters.AddWithValue("@id_currency", id_currency);

            cmd.Parameters.AddWithValue("@id_address_delivery", DeliverAddressID);
            cmd.Parameters.AddWithValue("@id_address_invoice", BillAddressID);
            cmd.Parameters.AddWithValue("@current_state", "14");
            cmd.Parameters.AddWithValue("@secure_key", TrId);

            cmd.Parameters.AddWithValue("@payment", "COD");
            cmd.Parameters.AddWithValue("@conversion_rate", "1.000000");
            cmd.Parameters.AddWithValue("@module", "COD");
            cmd.Parameters.AddWithValue("@recyclable", recyclable);

            cmd.Parameters.AddWithValue("@gift", gift);
            cmd.Parameters.AddWithValue("@gift_message", gift_message);
            cmd.Parameters.AddWithValue("@mobile_theme", mobile_theme);
            cmd.Parameters.AddWithValue("@shipping_number", shipping_number);

            if (tbl.Rows[0]["CouponDiscount"].ToString() != "" && tbl.Rows[0]["CouponDiscount"].ToString() != null)
            {
                cmd.Parameters.AddWithValue("@total_discounts", tbl.Rows[0]["CouponDiscount"].ToString());
                cmd.Parameters.AddWithValue("@total_discounts_tax_incl", tbl.Rows[0]["CouponDiscount"].ToString());
                cmd.Parameters.AddWithValue("@total_discounts_tax_excl", tbl.Rows[0]["CouponDiscount"].ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@total_discounts", "0");
                cmd.Parameters.AddWithValue("@total_discounts_tax_incl", "0");
                cmd.Parameters.AddWithValue("@total_discounts_tax_excl", "0");
            }

            cmd.Parameters.AddWithValue("@total_paid", tbl.Rows[0]["NetAmount"].ToString());

            cmd.Parameters.AddWithValue("@total_paid_tax_incl", tbl.Rows[0]["NetAmount"].ToString());
            cmd.Parameters.AddWithValue("@total_paid_tax_excl", tbl.Rows[0]["NetAmount"].ToString());
            cmd.Parameters.AddWithValue("@total_paid_real", tbl.Rows[0]["NetAmount"].ToString());
            cmd.Parameters.AddWithValue("@total_products", tbl.Rows[0]["TotalAmount"].ToString());

            cmd.Parameters.AddWithValue("@total_products_wt", tbl.Rows[0]["TotalAmount"].ToString());
            cmd.Parameters.AddWithValue("@total_shipping", tbl.Rows[0]["Shipping"].ToString());
            cmd.Parameters.AddWithValue("@total_shipping_tax_incl", tbl.Rows[0]["Shipping"].ToString());
            cmd.Parameters.AddWithValue("@total_shipping_tax_excl", tbl.Rows[0]["Shipping"].ToString());

            cmd.Parameters.AddWithValue("@carrier_tax_rate", "0");
            cmd.Parameters.AddWithValue("@total_wrapping", "0");
            cmd.Parameters.AddWithValue("@total_wrapping_tax_incl", "0");
            cmd.Parameters.AddWithValue("@total_wrapping_tax_excl", "0");

            cmd.Parameters.AddWithValue("@round_mode", "2");
            cmd.Parameters.AddWithValue("@round_type", "3");
            cmd.Parameters.AddWithValue("@invoice_number", "0");
            cmd.Parameters.AddWithValue("@delivery_number", "0");

            cmd.Parameters.AddWithValue("@invoice_date", DBNull.Value);
            cmd.Parameters.AddWithValue("@delivery_date", DBNull.Value);
            cmd.Parameters.AddWithValue("@valid", "0");
            cmd.Parameters.AddWithValue("@date_add", DateTime.Now);

            cmd.Parameters.AddWithValue("@date_upd", DBNull.Value);

            ds = data.getDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                UpdateCart(cartID);
                string maxOrderID = ds.Tables[0].Rows[0]["maxOrder"].ToString();
                // string maxOrderID = data.getDataSet("select max(id_order) as maxOrder from ps_orders ").Tables[0].Rows[0]["maxOrder"].ToString();
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    string ProductName = tbl.Rows[i]["ProdName"].ToString() + "-" + tbl.Rows[i]["Attribute"].ToString();
                    string ProdID = tbl.Rows[i]["ProdID"].ToString();
                    string AttributeID = tbl.Rows[i]["AttributeID"].ToString();
                    string Qty = tbl.Rows[i]["Qty"].ToString();
                    string Price = tbl.Rows[i]["Price"].ToString();
                    string DisPrice = tbl.Rows[i]["DisPrice"].ToString();
                    string SKU = tbl.Rows[i]["SKU"].ToString();
                    string Amt = tbl.Rows[i]["Amount"].ToString();
                    string Pri = tbl.Rows[i]["Price"].ToString();

                    cmd = new SqlCommand("sp_InsertOrderDetail");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id_order", maxOrderID);
                    cmd.Parameters.AddWithValue("@id_order_invoice", "0");
                    cmd.Parameters.AddWithValue("@id_warehouse", "0");
                    cmd.Parameters.AddWithValue("@id_shop", "1");
                    cmd.Parameters.AddWithValue("@product_id", ProdID);
                    cmd.Parameters.AddWithValue("@product_attribute_id", AttributeID);
                    cmd.Parameters.AddWithValue("@product_name", ProductName);
                    cmd.Parameters.AddWithValue("@product_quantity", Qty);
                    cmd.Parameters.AddWithValue("@product_quantity_in_stock", "0");
                    cmd.Parameters.AddWithValue("@product_quantity_refunded", "0");
                    cmd.Parameters.AddWithValue("@product_quantity_return", "0");
                    cmd.Parameters.AddWithValue("@product_quantity_reinjected", "0");
                    cmd.Parameters.AddWithValue("@product_price", DisPrice);
                    cmd.Parameters.AddWithValue("@reduction_percent", "0");
                    cmd.Parameters.AddWithValue("@reduction_amount", "0");
                    cmd.Parameters.AddWithValue("@reduction_amount_tax_incl", "0");
                    cmd.Parameters.AddWithValue("@reduction_amount_tax_excl", "0");
                    cmd.Parameters.AddWithValue("@group_reduction", "0");
                    cmd.Parameters.AddWithValue("@product_quantity_discount", "0");
                    cmd.Parameters.AddWithValue("@product_ean13", DBNull.Value);
                    cmd.Parameters.AddWithValue("@product_upc", DBNull.Value);
                    cmd.Parameters.AddWithValue("@product_reference", SKU);
                    cmd.Parameters.AddWithValue("@product_supplier_reference", DBNull.Value);
                    cmd.Parameters.AddWithValue("@product_weight", "0");
                    cmd.Parameters.AddWithValue("@id_tax_rules_group", "0");
                    cmd.Parameters.AddWithValue("@tax_computation_method", "0");
                    cmd.Parameters.AddWithValue("@tax_name", DBNull.Value);
                    cmd.Parameters.AddWithValue("@tax_rate", "0");
                    cmd.Parameters.AddWithValue("@ecotax", "0");
                    cmd.Parameters.AddWithValue("@ecotax_tax_rate", "0");
                    cmd.Parameters.AddWithValue("@discount_quantity_applied", "0");
                    cmd.Parameters.AddWithValue("@download_hash", DBNull.Value);
                    cmd.Parameters.AddWithValue("@download_nb", "0");
                    cmd.Parameters.AddWithValue("@download_deadline", DBNull.Value);
                    cmd.Parameters.AddWithValue("@total_price_tax_incl", Amt);
                    cmd.Parameters.AddWithValue("@total_price_tax_excl", Amt);
                    cmd.Parameters.AddWithValue("@unit_price_tax_incl", DisPrice);
                    cmd.Parameters.AddWithValue("@unit_price_tax_excl", DisPrice);
                    cmd.Parameters.AddWithValue("@total_shipping_price_tax_incl", "0");
                    cmd.Parameters.AddWithValue("@total_shipping_price_tax_excl", "0");
                    cmd.Parameters.AddWithValue("@purchase_supplier_price", "0");
                    cmd.Parameters.AddWithValue("@original_product_price", Price);
                    cmd.Parameters.AddWithValue("@original_wholesale_price", "0");
                    if (data.executeCommand(cmd) == 0)
                    {
                        IsSuccess = true;
                        UpdateProdQty(ProdID, Qty, AttributeID);
                    }
                }

                gData.InsOrderHistory(UserID, maxOrderID, "14");

                //order payment detail insert start
                cmd = new SqlCommand("sp_InsertOrderPayment");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_order", maxOrderID);
                cmd.Parameters.AddWithValue("@order_reference", Reference);
                cmd.Parameters.AddWithValue("@id_currency", "1");
                cmd.Parameters.AddWithValue("@amount", tbl.Rows[0]["NetAmount"].ToString());
                cmd.Parameters.AddWithValue("@payment_method", "COD");
                cmd.Parameters.AddWithValue("@conversion_rate", "1");
                cmd.Parameters.AddWithValue("@transaction_id", Reference);
                cmd.Parameters.AddWithValue("@card_number", "");
                cmd.Parameters.AddWithValue("@card_brand", "");
                cmd.Parameters.AddWithValue("@card_expiration", "");
                cmd.Parameters.AddWithValue("@card_holder", "");
                cmd.Parameters.AddWithValue("@date_add", DateTime.Now);
                data.executeCommand(cmd);

                if (IsSuccess == true)
                {
                    string str = EF.EmailOrderConfirmation(maxOrderID);
                    divPageHtml.InnerHtml = str;
                    UpdateCart(cartID);
                    EF.EmailOrderConfirmationAdmin(maxOrderID);
                }
            }
        }
    }
    private static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public void UpdateProdQty(string ProdId, string Qty, string AttributeID)
    {
        DataSet dsqty = new DataSet();
        dsqty = getData.getDetail(ProdId);
        if (dsqty.Tables[0].Rows.Count > 0)
        {
            string IsStockAllow = dsqty.Tables[0].Rows[0]["IsStockAllow"].ToString().Trim();
            string stockQty = dsqty.Tables[0].Rows[0]["stockQty"].ToString().Trim();
            //if (IsStockAllow == "Deny")
            //{
            query = " Update ps_stock_available set quantity = quantity - " + Qty + " where id_product = '" + ProdId + "' and id_product_attribute = '" + AttributeID + "' ";
            data.executeCommand(query);
            query = " Update tbl_AllProduct set StockQty = StockQty - " + Qty + " where id_product = '" + ProdId + "' and id_product_attribute = '" + AttributeID + "' ";
            data.executeCommand(query);
            //}
        }
    }

    public void UpdateCart(string CartID)
    {
        query = " Update ps_cart set CartStatus = 'Confirm' where id_cart = '" + CartID + "'";
        if (data.executeCommand(query) == 0)
        {
            HttpContext.Current.Response.Cookies["cartSG"].Expires = DateTime.Now.AddDays(-1d);
            var cookie = new HttpCookie("cartSG");
            cookie.Expires = DateTime.Now.AddDays(-1d);

            HttpCookie carts = new HttpCookie("cartSG");
            carts.Expires = DateTime.Now.AddDays(30d);
            carts.Values.Add("cartID", "0");
            HttpContext.Current.Response.Cookies.Add(carts);
        }
    }
}
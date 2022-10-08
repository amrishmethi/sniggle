using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Backoffice_ViewOrder : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    SqlCommand cmd;
    AdminMailFormat mailFormate = new AdminMailFormat();
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
                    BindStatus();
                }

            }
        }
    }

    public void BindStatus()
    {
        string ss = "select * from ps_order_state_lang where id_lang=1";
        DataSet dsS = data.getDataSet(ss);
        drpStatus.DataSource = dsS;
        drpStatus.DataTextField = "name";
        drpStatus.DataValueField = "id_order_state";
        drpStatus.DataBind();
        drpStatus.Items.Insert(0, "Select");

        string sss = "select * from ps_order_message_lang where id_lang=1";
        DataSet dsSs = data.getDataSet(sss);
        //drpMessageTyp.DataSource = dsSs;
        //drpMessageTyp.DataTextField = "name";
        //drpMessageTyp.DataValueField = "id_order_message";
        //drpMessageTyp.DataBind();
        //drpMessageTyp.Items.Insert(0, "--");
    }
    public void FillData(string id)
    {
        ds = data.getDataSet("Sp_GetOrderDetail '" + id + "'");
        RepOrderD.DataSource = ds;
        RepOrderD.DataBind();
        if(ds.Tables[0].Rows[0]["Gift"] !=null || ds.Tables[0].Rows[0]["Gift"].ToString() != "")
        {
            lblGift.Text =  ds.Tables[0].Rows[0]["Gift"].ToString();
        }
        
        lblCount.Text = ds.Tables[0].Rows.Count.ToString();
        lblTotal.Text = ds.Tables[0].Rows[0]["total_paid"].ToString();
        lblDate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
        lblProduct.Text = ds.Tables[0].Rows.Count.ToString();
        lblMessage.Text = "0";
        lblProductCost.Text = ds.Tables[0].Rows[0]["total_products"].ToString();
        if(ds.Tables[0].Rows[0]["total_discounts"].ToString() != "0.00")
        {
            lblDis.Text = "-₹" + ds.Tables[0].Rows[0]["total_discounts"].ToString();
        }
        
        lblShiping.Text = ds.Tables[0].Rows[0]["total_shipping"].ToString();
        lblTotalAmt.Text = ds.Tables[0].Rows[0]["total_paid"].ToString();
        DataSet dsStatus = data.getDataSet("Sp_GetOrderStatus '" + id + "'");

        repStatus.DataSource = dsStatus;
        repStatus.DataBind();

        DataSet dsCust = data.getDataSet("Sp_GetCustomerOrderDetailA '" + id + "'");
        if (dsCust.Tables[0].Rows.Count > 0)
        {
            lblCustomerName.Text = dsCust.Tables[0].Rows[0]["CustName"].ToString();
            ancCustomerID.HRef = "ViewCustomers.aspx?id=" + dsCust.Tables[0].Rows[0]["id_customer"].ToString();
            lblpaymentC.Text = dsCust.Tables[0].Rows[0]["CustName"].ToString();
            lblEmail.Text = dsCust.Tables[0].Rows[0]["email"].ToString();
            //mailto: alba @globe.ocn.ne.jp
            ancEmail.HRef = "mailto:" + dsCust.Tables[0].Rows[0]["email"].ToString();
            lblRegisDate.Text = dsCust.Tables[0].Rows[0]["date_add"].ToString();
            if (dsCust.Tables[2].Rows.Count > 0)
                lblValidOrder.Text = dsCust.Tables[2].Rows[0]["Valid"].ToString();
            lblTotalSpain.Text = dsCust.Tables[1].Rows[0]["total_paid"].ToString();
        }


        DataSet dsAddr = data.getDataSet("GetOrderAddress '" + id + "'");

        lblNameB.Text = dsAddr.Tables[1].Rows[0]["CustName"].ToString();
        lblCompanyB.Text = dsAddr.Tables[1].Rows[0]["CountryName"].ToString();
        ltrAddressB.Text = dsAddr.Tables[1].Rows[0]["address1"].ToString();
        lblCityandPinB.Text = dsAddr.Tables[1].Rows[0]["city"].ToString();
        lblStateB.Text = dsAddr.Tables[1].Rows[0]["StateName"].ToString();
        lblPinCodeB.Text = dsAddr.Tables[1].Rows[0]["postcode"].ToString();
        lblCountryB.Text = dsAddr.Tables[1].Rows[0]["CountryName"].ToString();
        lblPhoneB.Text = dsAddr.Tables[1].Rows[0]["phone"].ToString();
        lblMobileB.Text = dsAddr.Tables[1].Rows[0]["phone_mobile"].ToString();
        lblAdditionalB.Text = dsAddr.Tables[1].Rows[0]["other"].ToString();

        lblName.Text = dsAddr.Tables[0].Rows[0]["CustName"].ToString();
        lblCompany.Text = dsAddr.Tables[0].Rows[0]["CountryName"].ToString();
        ltrAddress.Text = dsAddr.Tables[0].Rows[0]["address1"].ToString();
        lblCityandPin.Text = dsAddr.Tables[0].Rows[0]["city"].ToString();
        lblState.Text = dsAddr.Tables[0].Rows[0]["StateName"].ToString();
        lblPinCode.Text = dsAddr.Tables[0].Rows[0]["postcode"].ToString();
        lblCountry.Text = dsAddr.Tables[0].Rows[0]["CountryName"].ToString();
        lblPhone.Text = dsAddr.Tables[0].Rows[0]["phone"].ToString();
        lblMobile.Text = dsAddr.Tables[0].Rows[0]["phone_mobile"].ToString();
        lblAdditional.Text = dsAddr.Tables[0].Rows[0]["other"].ToString();
        //ltrAddress.Text = dsAddr.Tables[0].Rows[0]["address1"].ToString() + " " + dsAddr.Tables[0].Rows[0]["address2"].ToString();
        //lblCityandPin.Text = dsAddr.Tables[0].Rows[0]["city"].ToString() + ", " + dsAddr.Tables[0].Rows[0]["postcode"].ToString() + ", " + dsAddr.Tables[0].Rows[0]["StateName"].ToString() + ", " + dsAddr.Tables[0].Rows[0]["CountryName"].ToString();
        ////lblState.Text =
        //lblMobile.Text = dsAddr.Tables[0].Rows[0]["phone_mobile"].ToString();
        //lblPhone.Text = dsAddr.Tables[0].Rows[0]["phone"].ToString();
        //// lblCountry.Text = dsAddr.Tables[0].Rows[0]["CountryName"].ToString();
        //ltrAddressB.Text = dsAddr.Tables[1].Rows[0]["address1"].ToString() + " " + dsAddr.Tables[1].Rows[0]["address2"].ToString();
        //// lblStateB.Text = dsAddr.Tables[0].Rows[0]["StateName"].ToString();
        //lblCityandPinB.Text = dsAddr.Tables[1].Rows[0]["city"].ToString() + ", " + dsAddr.Tables[1].Rows[0]["postcode"].ToString() + ", " + dsAddr.Tables[1].Rows[0]["StateName"].ToString() + ", " + dsAddr.Tables[1].Rows[0]["CountryName"].ToString();
        //lblMobileB.Text = dsAddr.Tables[1].Rows[0]["phone_mobile"].ToString();
        //lblPhoneB.Text = dsAddr.Tables[1].Rows[0]["phone"].ToString();
        ////lblCountryB.Text = dsAddr.Tables[1].Rows[0]["CountryName"].ToString();
        //


        string sqq = "SELECT a.*, b.* FROM ps_carrier a INNER JOIN ps_carrier_lang b ON a.id_carrier = b.id_carrier ";
        sqq += " AND b.id_lang = 1 WHERE a.deleted = 0  ORDER BY a.position ASC";
        DataSet dsCarrm = data.getDataSet(sqq);
        drpCarrier.DataSource = dsCarrm;
        drpCarrier.DataTextField = "name";
        drpCarrier.DataValueField = "id_carrier";
        drpCarrier.DataBind();
        drpCarrier.Items.Insert(0, "Select");

        DataSet dsCarr = data.getDataSet("Sp_GetOrderCarrier '" + id + "'");
        //repShippin.DataSource = dsCarr;
        // repShippin.DataBind();
        if (dsCarr.Tables[0].Rows.Count > 0)
        {
            txtDate.Text = dsCarr.Tables[0].Rows[0]["Date"].ToString();

            lblDateC.Text = dsCarr.Tables[0].Rows[0]["date_add"].ToString();
            lblCarrier.Text = dsCarr.Tables[0].Rows[0]["name"].ToString();
            drpCarrier.SelectedValue = dsCarr.Tables[0].Rows[0]["id_carrier"].ToString();
            lblCost.Text = dsCarr.Tables[0].Rows[0]["shipping_cost_tax_excl"].ToString();
            txtTrackingNo.Text = dsCarr.Tables[0].Rows[0]["tracking_number"].ToString();
            lblTrackingNo.Text = dsCarr.Tables[0].Rows[0]["tracking_number"].ToString();
            txtLink.Text = dsCarr.Tables[0].Rows[0]["url"].ToString();
            lblLink.Text = dsCarr.Tables[0].Rows[0]["url"].ToString();
            txtDate.Visible = false;
            drpCarrier.Visible = false;
            txtTrackingNo.Visible = false;
            txtLink.Visible = false;

        }


        DataSet dsPay = data.getDataSet("Sp_InsGetOrderPaymentAr '" + id + "'");
        repPayment.DataSource = dsPay;
        repPayment.DataBind();
        lblPaymentCount.Text = dsPay.Tables[0].Rows.Count.ToString();
        DataSet dsPayM = data.getDataSet("select CONVERT(CHAR(20),date_add,100) as dd,* from ps_message where id_order='" + id + "'");
        if (dsPayM.Tables[0].Rows.Count > 0)
        {
            lblPaymentdate.Text = dsPayM.Tables[0].Rows[0]["dd"].ToString();
            lblPaymentMess.Text = dsPayM.Tables[0].Rows[0]["message"].ToString();
            lblPaymentCount.Text = dsPayM.Tables[0].Rows.Count.ToString();
        }
        DataSet dsMail = data.getDataSet("Sp_GetMailByOrder '" + id + "'");
        repMail.DataSource = dsMail;
        repMail.DataBind();
    }
    public void UpdateProdQty(string ProdId, string Qty, string AttributeID)
    {
        DataSet dsqty = new DataSet();

        string query = "";
            query = " Update ps_stock_available set quantity = quantity + " + Qty + " where id_product = '" + ProdId + "' and id_product_attribute = '" + AttributeID + "' ";
            data.executeCommand(query);

          
    }
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            //AdminCookie = Request.Cookies["Backoffice"];
            string ss = AdminCookie.Values["UserId"].ToString();
            if (drpStatus.SelectedIndex > 0)
            {
                if (drpStatus.SelectedValue == "6")//OrderCanceled
                {
                    DataSet dsoo = data.getDataSet("select * from ps_orders where IsDeleted=0 and current_state=6 and id_order='" + Request.QueryString["id"].ToString() + "'");
                    if (dsoo.Tables[0].Rows.Count == 0)
                    {
                        string qqo = "select * from ps_order_detail where IsDeleted=0 and id_order='" + Request.QueryString["id"].ToString() + "'";
                        DataSet dsst = data.getDataSet(qqo);
                        for (int ii = 0; ii < dsst.Tables[0].Rows.Count; ii++)
                        {
                            if(ii==0)
                            {
                                string query = "";
                                query = " Update ps_stock_available set quantity = 0 where id_product = '" + dsst.Tables[0].Rows[ii]["product_id"].ToString() + "' and id_product_attribute ='0' ";
                                data.executeCommand(query);
                            }
                            UpdateProdQty(dsst.Tables[0].Rows[ii]["product_id"].ToString(), dsst.Tables[0].Rows[ii]["product_quantity"].ToString(), dsst.Tables[0].Rows[ii]["product_attribute_id"].ToString());
                        }
                    }
                }
                int res = gdate.InsOrderHistory(ss, Request.QueryString["id"].ToString(), drpStatus.SelectedValue);

                if (res == 0)
                {
                    if (drpStatus.SelectedValue == "4")//Shipped
                    {
                        mailFormate.EmailShipped(Request.QueryString["id"].ToString());
                    }
                    if (drpStatus.SelectedValue == "6")//OrderCanceled
                    {
                        mailFormate.EmailOrderCanceled(Request.QueryString["id"].ToString());
                    }
                    if (drpStatus.SelectedValue == "2") //PaymentAcceptede
                    {
                        mailFormate.EmailPaymentAcceptede(Request.QueryString["id"].ToString());
                    }
                    if (drpStatus.SelectedValue == "9")//On backorder (paid)
                    {
                        mailFormate.EmailBackorderPaid(Request.QueryString["id"].ToString());
                        mailFormate.EmailBackorderPaidAdmin(Request.QueryString["id"].ToString());
                    }
                    if (drpStatus.SelectedValue == "13")//On backorder (not paid)
                    {
                        mailFormate.EmailBackorderNotPaid(Request.QueryString["id"].ToString());
                        mailFormate.EmailBackorderNotPaidAdmin(Request.QueryString["id"].ToString());
                    }
                }

            }
            DataSet dsStatus = data.getDataSet("Sp_GetOrderStatus '" + Request.QueryString["id"].ToString() + "'");

            repStatus.DataSource = dsStatus;
            repStatus.DataBind();
        }
        Response.Redirect("ViewOrder.aspx?id="+ Request.QueryString["id"]);
        // AdminCookie.Values["id_employee"].ToString();

    }
    protected void repStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblID = (Label)e.Item.FindControl("lblID");
            LinkButton LinkButton1 = (LinkButton)e.Item.FindControl("LinkButton1");
            if (lblID.Text == "4" || lblID.Text == "6" || lblID.Text == "2" || lblID.Text == "9" || lblID.Text == "13")
            {
                LinkButton1.Visible = true;

            }
            else
                LinkButton1.Visible = false;
        }
    }

    protected void repStatus_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Send")
        {
            Label lblID = (Label)e.Item.FindControl("lblID");
            if (lblID.Text == "4")
            {
                mailFormate.EmailShipped(Request.QueryString["id"].ToString());
            }
            if (lblID.Text == "6")
            {
                mailFormate.EmailOrderCanceled(Request.QueryString["id"].ToString());
            }
            if (lblID.Text == "6")
            {
                mailFormate.EmailOrderCanceled(Request.QueryString["id"].ToString());
            }
            if (lblID.Text == "2")
            {
                mailFormate.EmailPaymentAcceptede(Request.QueryString["id"].ToString());
            }
            if (lblID.Text == "9")//On backorder (paid)
            {
                mailFormate.EmailBackorderPaid(Request.QueryString["id"].ToString());
                mailFormate.EmailBackorderPaidAdmin(Request.QueryString["id"].ToString());
            }
            if (lblID.Text == "13")//On backorder (not paid)
            {
                mailFormate.EmailBackorderNotPaid(Request.QueryString["id"].ToString());
                mailFormate.EmailBackorderNotPaidAdmin(Request.QueryString["id"].ToString());
            }
        }
    }
    protected void tbnTracEdit_Click(object sender, EventArgs e)
    {
        txtDate.Visible = true;
        drpCarrier.Visible = true;
        txtTrackingNo.Visible = true;
        txtLink.Visible = true;
        btnTracking.Visible = true;

        lblDateC.Visible = false;
        lblCarrier.Visible = false;
        lblCost.Visible = false;
        lblTrackingNo.Visible = false;
        lblLink.Visible = false;
        tbnTracEdit.Visible = false;
    }

    protected void btnTracking_Click(object sender, EventArgs e)
    {

        if (txtDate.Text != "" && txtTrackingNo.Text != "" && txtLink.Text != "")
        {
            string sq = "update ps_order_carrier set id_carrier=@id_carrier,tracking_number=@tracking_number,date_add=@date_add,url=@url where id_order=@id_order";
            cmd = new SqlCommand(sq);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id_carrier", drpCarrier.SelectedValue);
            cmd.Parameters.AddWithValue("@tracking_number", txtTrackingNo.Text);
            cmd.Parameters.AddWithValue("@date_add", ConvertToDateTime(txtDate.Text));
            cmd.Parameters.AddWithValue("@url", txtLink.Text);
            cmd.Parameters.AddWithValue("@id_order", Request.QueryString["id"].ToString());
            data.executeCommand(cmd);

            DataSet dsCarr = data.getDataSet("Sp_GetOrderCarrier '" + Request.QueryString["id"].ToString() + "'");
            //repShippin.DataSource = dsCarr;
            // repShippin.DataBind();
            if (dsCarr.Tables[0].Rows.Count > 0)
            {
                txtDate.Text = dsCarr.Tables[0].Rows[0]["Date"].ToString();

                lblDateC.Text = dsCarr.Tables[0].Rows[0]["date_add"].ToString();
                lblCarrier.Text = dsCarr.Tables[0].Rows[0]["name"].ToString();
                drpCarrier.SelectedValue = dsCarr.Tables[0].Rows[0]["id_carrier"].ToString();
                lblCost.Text = dsCarr.Tables[0].Rows[0]["shipping_cost_tax_excl"].ToString();
                txtTrackingNo.Text = dsCarr.Tables[0].Rows[0]["tracking_number"].ToString();
                lblTrackingNo.Text = dsCarr.Tables[0].Rows[0]["tracking_number"].ToString();
                txtLink.Text = dsCarr.Tables[0].Rows[0]["url"].ToString();
                lblLink.Text = dsCarr.Tables[0].Rows[0]["url"].ToString();
                txtDate.Visible = false;
                drpCarrier.Visible = false;
                txtTrackingNo.Visible = false;
                txtLink.Visible = false;

                txtDate.Visible = false;
                drpCarrier.Visible = false;
                txtTrackingNo.Visible = false;
                txtLink.Visible = false;
                btnTracking.Visible = false;

                lblDateC.Visible = true;
                lblCarrier.Visible = true;
                lblCost.Visible = true;
                lblTrackingNo.Visible = true;
                lblLink.Visible = true;
                tbnTracEdit.Visible = true;
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


}
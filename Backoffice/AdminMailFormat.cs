using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for AdminMailFormat
/// </summary>
public class AdminMailFormat
{
    Data data = new Data();
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    AdminGetData adminData = new AdminGetData();
    public AdminMailFormat()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void EmailShipped(string OrderID)
    {
        if (OrderID == "" && OrderID == null)
        {
            return;
        }
        else
        {
            cmd.CommandText = "sp_GetShippedDetailAdmin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderId", OrderID);
            ds = data.getDataSet(cmd);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            string reference = ds.Tables[0].Rows[0]["reference"].ToString();
            DataTable dt = new DataTable();
            string cursign = ds.Tables[0].Rows[0]["cursign"].ToString();
            string firstname = ds.Tables[0].Rows[0]["firstname"].ToString();
            string lastname = ds.Tables[0].Rows[0]["lastname"].ToString();
            string CustName = firstname + " " + lastname;
            string trackingNo = ds.Tables[0].Rows[0]["tracking_number"].ToString();
            string url = ds.Tables[0].Rows[0]["url"].ToString();
            string CustEmail = ds.Tables[0].Rows[0]["email"].ToString();
            //string CustEmail ="cs@sscompusoft.com";

            string str = "";
            str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
            str += " <tr> <td>";

            str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
            str += "  <tr> ";
            str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
            str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

            str += "  <tr> ";
            str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
            str += " <a href='https://www.sniggle.in/' target='_blank'> ";
            str += "  <img src='https://www.sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
            str += "  </a>";
            str += " <td>";
            str += " <tr>";

            str += "  <tr> ";
            str += " <td>";
            str += "  <table width='98%' border='0' cellspacing='0' cellpadding='5' align='center'>";

            str += "  <tr> ";
            str += " <td>&nbsp;</td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td></td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td>Hello " + CustName + ",</td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td></td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td>Your order has been shipped. Thank you for shopping with sniggle.</td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td></td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += "  <td align='center'>";
            str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'>";
            str += "  <tr> ";
            str += " <td> ";
            str += " <h5 style='font-weight: 300; color: #666; padding: 5px 0px;  margin: 0px; font-size:18px;'><strong>ORDER  " + reference + " - SHIPPED </strong></h5> ";
            str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
            str += " <p style='padding-bottom:2px;'> ";
            str += " <span style='color:#777;'>Your order with the reference </span> ";
            str += " <strong>" + reference + "</strong> ";
            //str += " <span style='color:#777;'>from</span> <strong>sniggle</strong>  ";
            str += " <span style='color:#777;'> has been shipped.</ br></span> ";
            // str += "  </p> ";
            //str += " </td> ";
            //str += " </tr> ";
            //str += "  <tr> ";
            //str += " <p style='padding-bottom:2px;'> ";
            str += " <span style='color:#777;'>Your tracking number is </span> ";
            str += " <strong>" + trackingNo + ".</strong> ";
            str += " <span style='color:#777;'> Now you can track your package using the following link: " + url + "</span> ";
            str += "  </p> ";
            str += " </tr> ";
            str += " </table> ";
            str += "  </td> ";
            str += " </tr> ";
            str += "  <tr> ";
            str += " <td></td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td>&nbsp;</td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += "  <td align='center'> ";
            str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";
            str += " <tr> ";
            str += "  <td>You can review your order and download your invoice from the <a href='https://www.sniggle.in/order-history' target='_blank'>'Order history'</a> section of your customer account by clicking  <a href='https://www.sniggle.in/my-account' target='_blank'>'My account'</a> on our shop.</td> ";
            str += "</tr> ";
            str += "  <tr> ";
            str += " <td>&nbsp;</td> ";
            str += " </tr> ";

            //str += "  <tr> ";
            //str += " <td>If you have a guest account, you can follow your order via the <a href='#' target='_blank'>'Guest Tracking'</a> section on our shop.</td> ";
            //str += " </tr> ";
            str += "  <tr> ";
            str += " <td>&nbsp;</td> ";
            str += " </tr> ";
            str += "  </table> ";
            str += " </td> ";
            str += " </tr>";

            str += "  <tr> ";
            str += " <td></td> ";
            str += " </tr> ";

            str += "  </table> ";
            str += " </td> ";
            str += " </tr>";

            str += " <tr> ";
            str += "  <td bgcolor='#f4f5f7'> ";
            str += " <table width='100%' border='0' cellspacing='0' cellpadding='5' align='center'> ";
            str += " <tr> ";
            str += "  <td align='center'><h6 style='padding: 5px 0px; margin:0px; font-size: 18px;'>Follow us and stay in touch</h6></td> ";
            str += " </tr> ";

            str += " <tr>";
            str += " <td align='center'><a href='https://www.facebook.com/earthstoneinc' target='_blank'><img src='https://www.sniggle.in/img/fb1.png' /></a> &nbsp; <a href='https://twitter.com/earthstoneinc' target='_blank'><img src='https://www.sniggle.in/img/tw2.png' /></a> &nbsp; <a href='https://www.youtube.com/channel/UCzWCEOsGgbDD9-Abp3RJF3w' target='_blank'><img src='https://www.sniggle.in/img/yt3.png' /></a> &nbsp; <a href='https://www.linkedin.com/company/earth-stone-inc' target='_blank'><img src='https://www.sniggle.in/img/ld4.png' /></a> &nbsp; <a href='https://in.pinterest.com/myearthstone/pins/' target='_blank'><img src='https://www.sniggle.in/img/pt5.png' /></a> &nbsp; <a href='https://www.instagram.com/myearthstone' target='_blank'><img src='https://www.sniggle.in/img/insta6.png' /></a></td> ";
            str += "  </tr> ";
            str += "  </table> ";
            str += " </td> ";
            str += " </tr> ";

            str += "  </table>";
            str += " </td> ";
            str += "  </tr> ";
            str += " </table> ";
            str += "</td>";
            str += "  </tr> ";
            str += "  </table>";
           // CustEmail = "cs@sscompusoft.com";
            util.mail mail = new util.mail();
            mail.To = CustEmail;

            mail.Subject = "Order Shipped  Notification at sniggle!.";
            mail.Message = str;
           string ststus= mail.sendMailAdmin();
            adminData.InsMail(CustEmail, "Shipped", "Order Shipped  Notification at sniggle!.", ststus, OrderID);
        }
    }
    public void EmailOrderCanceled(string OrderID)
    {
        if (OrderID == "" && OrderID == null)
        {
            return;
        }
        else
        {
            cmd.CommandText = "sp_GetConfirmOrder";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderId", OrderID);
            ds = data.getDataSet(cmd);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            string reference = ds.Tables[0].Rows[0]["reference"].ToString();
            DataTable dt = new DataTable();
            string cursign = ds.Tables[0].Rows[0]["cursign"].ToString();
            string firstname = ds.Tables[0].Rows[0]["firstname"].ToString();
            string lastname = ds.Tables[0].Rows[0]["lastname"].ToString();
            string CustName = firstname + " " + lastname;
            //string CustEmail = "cs@sscompusoft.com";
            string CustEmail = ds.Tables[0].Rows[0]["email"].ToString();

            string str = "";
            str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
            str += " <tr> <td>";

            str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
            str += "  <tr> ";
            str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
            str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

            str += "  <tr> ";
            str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
            str += " <a href='https://www.sniggle.in/' target='_blank'> ";
            str += "  <img src='https://www.sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
            str += "  </a>";
            str += " <td>";
            str += " <tr>";

            str += "  <tr> ";
            str += " <td>";
            str += "  <table width='98%' border='0' cellspacing='0' cellpadding='5' align='center'>";

            str += "  <tr> ";
            str += " <td>&nbsp;</td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td></td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td>Hello " + CustName + ",</td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td></td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td>Your order has been canceled. Details are as follows:</td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td></td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += "  <td align='center'>";
            str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'>";
            str += "  <tr> ";
            str += " <td> ";
            str += " <h5 style='font-weight: 300; color: #777; padding: 5px 0px;  margin: 0px; font-size:18px;'>ORDER " + reference + " - ORDER CANCELED</h5> ";
            str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
            str += " <p style='padding-bottom:2px;'> ";
            str += " <span style='color:#777;'>Your order with the reference </span> ";
            str += " <strong>" + reference + "</strong> ";
            str += " <span style='color:#777;'>from</span> <strong>sniggle</strong>  ";
            str += " <span style='color:#777;'>has been canceled.</span> ";
            str += "  </p> ";
            str += " </td> ";
            str += " </tr> ";
            str += " </table> ";
            str += "  </td> ";
            str += " </tr> ";


            str += "  <tr> ";
            str += " <td></td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += " <td>&nbsp;</td> ";
            str += " </tr> ";

            str += "  <tr> ";
            str += "  <td align='center'> ";
            str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";
            str += " <tr> ";
            str += "  <td>You can review your order and download your invoice from the <a href='https://www.sniggle.in/order-history' target='_blank'>'Order history'</a> section of your customer account by clicking  <a href='https://www.sniggle.in/my-account' target='_blank'>'My account'</a> on our shop.</td> ";
            str += "</tr> ";
            str += "  <tr> ";
            str += " <td>&nbsp;</td> ";
            str += " </tr> ";

            //str += "  <tr> ";
            //str += " <td>If you have a guest account, you can follow your order via the <a href='#' target='_blank'>'Guest Tracking'</a> section on our shop.</td> ";
            //str += " </tr> ";
            str += "  <tr> ";
            str += " <td>&nbsp;</td> ";
            str += " </tr> ";
            str += "  </table> ";
            str += " </td> ";
            str += " </tr>";

            str += "  <tr> ";
            str += " <td></td> ";
            str += " </tr> ";

            str += "  </table> ";
            str += " </td> ";
            str += " </tr>";

            str += " <tr> ";
            str += "  <td bgcolor='#f4f5f7'> ";
            str += " <table width='100%' border='0' cellspacing='0' cellpadding='5' align='center'> ";
            str += " <tr> ";
            str += "  <td align='center'><h6 style='padding: 5px 0px; margin:0px; font-size: 18px;'>Follow us and stay in touch</h6></td> ";
            str += " </tr> ";

            str += " <tr>";
            str += " <td align='center'><a href='https://www.facebook.com/earthstoneinc' target='_blank'><img src='https://www.sniggle.in/img/fb1.png' /></a> &nbsp; <a href='https://twitter.com/earthstoneinc' target='_blank'><img src='https://www.sniggle.in/img/tw2.png' /></a> &nbsp; <a href='https://www.youtube.com/channel/UCzWCEOsGgbDD9-Abp3RJF3w' target='_blank'><img src='https://www.sniggle.in/img/yt3.png' /></a> &nbsp; <a href='https://www.linkedin.com/company/earth-stone-inc' target='_blank'><img src='https://www.sniggle.in/img/ld4.png' /></a> &nbsp; <a href='https://in.pinterest.com/myearthstone/pins/' target='_blank'><img src='https://www.sniggle.in/img/pt5.png' /></a> &nbsp; <a href='https://www.instagram.com/myearthstone' target='_blank'><img src='https://www.sniggle.in/img/insta6.png' /></a></td> ";
            str += "  </tr> ";
            str += "  </table> ";
            str += " </td> ";
            str += " </tr> ";

            str += "  </table>";
            str += " </td> ";
            str += "  </tr> ";
            str += " </table> ";
            str += "</td>";
            str += "  </tr> ";
            str += "  </table>";
            //CustEmail = "shankar@sscompusoft.co.in";
            util.mail mail = new util.mail();
            mail.To = CustEmail;

            mail.Subject = "Order Cancellation  Notification at sniggle!.";
            mail.Message = str;
           // mail.sendMail();
            string ststus = mail.sendMailAdmin();
            adminData.InsMail(CustEmail, "Cancell", "Order Cancellation  Notification at sniggle!.", ststus, OrderID);
        }
    }

    public string EmailPaymentAcceptede(string OrderID)
    {
        string str = "";
        if (OrderID == "" && OrderID == null)
        {
            return "Order Id Not Valid";
        }
        else
        {
            cmd.CommandText = "sp_GetConfirmOrder";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderId", OrderID);
            ds = data.getDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string TotalAmt = "";
                DataTable dt = new DataTable();
                string cursign = ds.Tables[0].Rows[0]["cursign"].ToString();
                string firstname = ds.Tables[0].Rows[0]["firstname"].ToString();
                string lastname = ds.Tables[0].Rows[0]["lastname"].ToString();
                string CustName = firstname + " " + lastname;
                string reference = ds.Tables[0].Rows[0]["reference"].ToString();
                string DateTime = ds.Tables[0].Rows[0]["date_add"].ToString();
                string payment = ds.Tables[0].Rows[0]["payment"].ToString();
                string SubTotal = "0.00";
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (SubTotal != "" && SubTotal != null)
                    {
                        SubTotal = cursign + " " + ds.Tables[1].Rows[0]["SubTotal"].ToString();
                    }

                    dt = ds.Tables[1];
                }

                string Discounts = ds.Tables[0].Rows[0]["discountamt"].ToString();
                string code = ds.Tables[0].Rows[0]["code"].ToString();
                string Shipping = ds.Tables[0].Rows[0]["shippingamt"].ToString();
                string GTotal = ds.Tables[0].Rows[0]["OrderAmt"].ToString();
                string PsCareer = "PS career";

                string CustEmail = ds.Tables[0].Rows[0]["email"].ToString();

                string DCustName = ds.Tables[2].Rows[0]["CustName"].ToString();
                string DComName = ds.Tables[2].Rows[0]["company"].ToString();
                string DLine1 = ds.Tables[2].Rows[0]["address1"].ToString();
                string DLineCity = ds.Tables[2].Rows[0]["city"].ToString();
                string DLinepostcode = ds.Tables[2].Rows[0]["postcode"].ToString();
                string DStateName = ds.Tables[2].Rows[0]["StateName"].ToString();
                string DLineCounName = ds.Tables[2].Rows[0]["CountryName"].ToString();
                string DLinePMobile = ds.Tables[2].Rows[0]["phone_mobile"].ToString();
                string DLinePhone = ds.Tables[2].Rows[0]["phone"].ToString();
                string DotherInfo = ds.Tables[2].Rows[0]["other"].ToString();

                string BCustName = ds.Tables[3].Rows[0]["CustName"].ToString();
                string BComName = ds.Tables[3].Rows[0]["company"].ToString();
                string BLine1 = ds.Tables[3].Rows[0]["address1"].ToString();
                string BLineCity = ds.Tables[3].Rows[0]["city"].ToString();
                string BLinepostcode = ds.Tables[3].Rows[0]["postcode"].ToString();
                string BStateName = ds.Tables[3].Rows[0]["StateName"].ToString();
                string BLineCounName = ds.Tables[3].Rows[0]["CountryName"].ToString();
                string BLinePMobile = ds.Tables[3].Rows[0]["phone_mobile"].ToString();
                string BLinePhone = ds.Tables[3].Rows[0]["phone"].ToString();
                string BotherInfo = ds.Tables[3].Rows[0]["other"].ToString();


                str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
                str += " <tr> <td>";

                str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                str += "  <tr> ";
                str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
                str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

                str += "  <tr> ";
                str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
                str += " <a href='https://www.sniggle.in/' target='_blank'> ";
                str += "  <img src='https://www.sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
                str += "  </a>";
                str += " <td>";
                str += " <tr>";

                str += "  <tr> ";
                str += " <td>";
                str += "  <table width='98%' border='0' cellspacing='0' cellpadding='5' align='center'>";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>Hello " + CustName + ",</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>Thank you for shopping with sniggle.</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                #region Order Detail Portion Start
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += "  <td> ";
                str += " <h4 style='font-size: 20px; padding: 5px 0px; margin: 0px; font-weight: bold;'> ORDER " + reference + " - PAYMENT PROCESSED</h4> ";
                str += "<p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                str += " <p style='padding-bottom:2px;'> ";
                str += "  Your payment for order with the reference " + reference + " was successfully processed.";
                str += " </p> ";
                str += "  </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "  </td> ";
                str += "  </tr> ";
                #endregion

                

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";
                str += "  <tr> ";
                str += "  <td align='center'> ";
                str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";
                str += " <tr> ";
                str += "  <td>You can review your order and download your invoice from the <a href='https://www.sniggle.in/order-history' target='_blank'>'Order history'</a> section of your customer account by clicking  <a href='https://www.sniggle.in/my-account' target='_blank'>'My account'</a> on our shop.</td> ";
                str += "</tr> ";
                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";
                str += "  </table> ";
                str += " </td> ";
                str += " </tr>";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  </table> ";
                str += " </td> ";
                str += " </tr>";

                str += " <tr> ";
                str += "  <td bgcolor='#f4f5f7'> ";
                str += " <table width='100%' border='0' cellspacing='0' cellpadding='5' align='center'> ";
                str += " <tr> ";
                str += "  <td align='center'><h6 style='padding: 5px 0px; margin:0px; font-size: 18px;'>Follow us and stay in touch</h6></td> ";
                str += " </tr> ";

                str += " <tr>";
                str += " <td align='center'><a href='https://www.facebook.com/earthstoneinc' target='_blank'><img src='https://www.sniggle.in/img/fb1.png' /></a> &nbsp; <a href='https://twitter.com/earthstoneinc' target='_blank'><img src='https://www.sniggle.in/img/tw2.png' /></a> &nbsp; <a href='https://www.youtube.com/channel/UCzWCEOsGgbDD9-Abp3RJF3w' target='_blank'><img src='https://www.sniggle.in/img/yt3.png' /></a> &nbsp; <a href='https://www.linkedin.com/company/earth-stone-inc' target='_blank'><img src='https://www.sniggle.in/img/ld4.png' /></a> &nbsp; <a href='https://in.pinterest.com/myearthstone/pins/' target='_blank'><img src='https://www.sniggle.in/img/pt5.png' /></a> &nbsp; <a href='https://www.instagram.com/myearthstone' target='_blank'><img src='https://www.sniggle.in/img/insta6.png' /></a></td> ";
                str += "  </tr> ";
                str += "  </table> ";
                str += " </td> ";
                str += " </tr> ";

                str += "  </table>";
                str += " </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "</td>";
                str += "  </tr> ";
                str += "  </table>";
                //CustEmail = "gemsbead.jpr@gmail.com";
                //CustEmail = "cs@sscompusoft.com";
                util.mail mail = new util.mail();
                mail.To = CustEmail;
                mail.Subject = "Payment accepted at sniggle!.";
                mail.Message = str;
                // mail.sendMail();
                string ststus = mail.sendMailAdmin();
                adminData.InsMail(CustEmail, "Payment accepted", "Payment accepted at sniggle!.", ststus, OrderID);
            }
            return str;
        }
    }

    public string EmailBackorderPaid(string OrderID)
    {
        string str = "";
        if (OrderID == "" && OrderID == null)
        {
            return "Order Id Not Valid";
        }
        else
        {
            cmd.CommandText = "sp_GetConfirmOrder";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderId", OrderID);
            ds = data.getDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                string cursign = ds.Tables[0].Rows[0]["cursign"].ToString();
                string firstname = ds.Tables[0].Rows[0]["firstname"].ToString();
                string lastname = ds.Tables[0].Rows[0]["lastname"].ToString();
                string CustName = firstname + " " + lastname;
                string reference = ds.Tables[0].Rows[0]["reference"].ToString();
                string DateTime = ds.Tables[0].Rows[0]["date_add"].ToString();
                string payment = ds.Tables[0].Rows[0]["payment"].ToString();
                string SubTotal = "0.00";
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (SubTotal != "" && SubTotal != null)
                    {
                        SubTotal = cursign + " " + ds.Tables[1].Rows[0]["SubTotal"].ToString();
                    }

                    dt = ds.Tables[1];
                }

                string Discounts = ds.Tables[0].Rows[0]["discountamt"].ToString();
                string code = ds.Tables[0].Rows[0]["code"].ToString();
                string Shipping = ds.Tables[0].Rows[0]["shippingamt"].ToString();
                string GTotal = ds.Tables[0].Rows[0]["OrderAmt"].ToString();
                string PsCareer = "PS career";

                string CustEmail = ds.Tables[0].Rows[0]["email"].ToString();

                string DCustName = ds.Tables[2].Rows[0]["CustName"].ToString();
                string DComName = ds.Tables[2].Rows[0]["company"].ToString();
                string DLine1 = ds.Tables[2].Rows[0]["address1"].ToString();
                string DLineCity = ds.Tables[2].Rows[0]["city"].ToString();
                string DLinepostcode = ds.Tables[2].Rows[0]["postcode"].ToString();
                string DStateName = ds.Tables[2].Rows[0]["StateName"].ToString();
                string DLineCounName = ds.Tables[2].Rows[0]["CountryName"].ToString();
                string DLinePMobile = ds.Tables[2].Rows[0]["phone_mobile"].ToString();
                string DLinePhone = ds.Tables[2].Rows[0]["phone"].ToString();
                string DotherInfo = ds.Tables[2].Rows[0]["other"].ToString();

                string BCustName = ds.Tables[3].Rows[0]["CustName"].ToString();
                string BComName = ds.Tables[3].Rows[0]["company"].ToString();
                string BLine1 = ds.Tables[3].Rows[0]["address1"].ToString();
                string BLineCity = ds.Tables[3].Rows[0]["city"].ToString();
                string BLinepostcode = ds.Tables[3].Rows[0]["postcode"].ToString();
                string BStateName = ds.Tables[3].Rows[0]["StateName"].ToString();
                string BLineCounName = ds.Tables[3].Rows[0]["CountryName"].ToString();
                string BLinePMobile = ds.Tables[3].Rows[0]["phone_mobile"].ToString();
                string BLinePhone = ds.Tables[3].Rows[0]["phone"].ToString();
                string BotherInfo = ds.Tables[3].Rows[0]["other"].ToString();


                str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
                str += " <tr> <td>";

                str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                str += "  <tr> ";
                str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
                str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

                str += "  <tr> ";
                str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
                str += " <a href='https://www.sniggle.in/' target='_blank'> ";
                str += "  <img src='https://www.sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
                str += "  </a>";
                str += " <td>";
                str += " <tr>";

                str += "  <tr> ";
                str += " <td>";
                str += "  <table width='98%' border='0' cellspacing='0' cellpadding='5' align='center'>";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>Hello " + CustName + ",</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>Thank you for shopping with sniggle. You order details are as follows:</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                #region Order Detail Portion Start
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += "  <td> ";
                str += " <h4 style='font-size: 20px; padding: 5px 0px; margin: 0px; font-weight: bold;'> ORDER DETAILS </h4> ";
                str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                str += " <p style='padding-bottom:2px;'> ";
                str += "  Order: ";
                str += " <span> ";
                str += " " + reference + " Place on " + DateTime + " ";
                str += " </span> <br /><br /> ";
                str += " Payment : " + payment + "";
                str += " </p> ";
                str += "  </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "  </td> ";
                str += "  </tr> ";
                #endregion

                #region Product Detail Start
                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                //str += "  <td align='center'><h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'>Image</h6></td> ";
                str += "  <td align='center'><h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'>Reference</h6></td> ";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Product </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Unit price </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Quantity </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Total price </h6>  </td>";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td colspan='5' bgcolor='#FFFFFF'>&nbsp;</td> ";
                str += " </tr> ";

                foreach (DataRow dr in dt.Rows)
                {
                    str += "  <tr> ";
                    //str += " <td bgcolor='#FFFFFF'><a target='_blank' href='https://www.sniggle.in/" + dr["DetailUrl"] + "'> <img id='img" + dr["ProdReference"] + "' src = 'https://www.sniggle.in/" + dr["URL"] + "'  alt='img' /> <a /></td> ";
                    str += " <td bgcolor='#FFFFFF'>" + dr["ProdReference"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF'>" + dr["product_name"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='right'>" + dr["ProdPrice"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='center'>" + dr["ProdQty"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='right'>" + dr["ProdTotPrice"] + "</td> ";

                    str += " </tr> ";
                }

                str += "  <tr> ";
                str += " <td colspan='5' bgcolor='#FFFFFF'>&nbsp;</td> ";
                str += " </tr> ";


                #region Total Protion Start
                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Sub Total</strong></td> ";
                str += " <td align='right'>" + SubTotal + "</td> ";
                str += " </tr> ";

                if (code != "" && code != null)
                {
                    str += "  <tr> ";
                    str += "  <td colspan='4' align='right'><strong>Discounts  </strong></td> ";
                    str += " <td align='right'> -" + Discounts + "</td> ";
                    str += " </tr> ";
                }


                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Shipping</strong></td> ";
                str += " <td align='right'>" + Shipping + "</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Grand Total</strong></td> ";
                str += " <td align='right'  width='80px'>" + GTotal + "</td> ";
                str += " </tr> ";
                #endregion

                str += " </table>";
                str += " </td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                #endregion

                #region Shippind Detail
                //str += " <tr> ";
                //str += " <td align='center'> ";
                //str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                //str += " <tr> ";
                //str += " <td> ";
                //str += " <h4 style='font-size:20px; padding: 5px 0px; margin: 0px;'>SHIPPING</h4> ";
                //str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                //str += "  <p> ";
                //str += "  Order: <span style='color:#999;'>" + PsCareer + "</span> <br /><br /> ";
                //str += " Payment : " + payment + "";
                //str += " </p> ";
                //str += " </td> ";
                //str += "  </tr> ";
                //str += " </table> ";
                //str += " </td> ";
                //str += " </tr> ";

                //str += "  <tr> ";
                //str += " <td>&nbsp;</td> ";
                //str += " </tr> ";
                #endregion

                #region Bind Address Start
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";
                str += " <tr> ";
                str += " <td width='48%'> ";
                str += "  <table width='100%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += " <td style='color:#777777;'> ";
                str += " <h5 style='color: #565457; font-size: 18px; padding: 5px 0px; margin: 0px;'> ";
                str += "  DELIVERY ADDRESS ";
                str += "  </h5> ";
                str += " <p style='margin:0px 2px; background:#d5d5d5; height:1px;'></p> ";
                str += " <p> ";
                str += " <strong>" + DCustName + "</strong><br /> ";
                if (DComName != "")
                {
                    str += " " + DComName + " <br />";
                }
                if (DLine1 != "")
                {
                    str += " " + DLine1 + " <br />";
                }
                if (DLineCity != "")
                {
                    str += " " + DLineCity + " <br />";
                }
                if (DStateName != "")
                {
                    str += " " + DStateName + " <br />";
                }
                if (DLinepostcode != "")
                {
                    str += " " + DLinepostcode + " <br />";
                }
                if (DLineCounName != "")
                {
                    str += " " + DLineCounName + " <br />";
                }
                if (DLinePMobile != "")
                {
                    str += " " + DLinePMobile + " <br />";
                }
                if (DLinePhone != "")
                {
                    str += " " + DLinePhone + " <br />";
                }
                if (DotherInfo != "")
                {
                    str += " " + DotherInfo + " <br />";
                }
                str += " </p> ";
                str += " </td> ";
                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";

                str += " <td width='4%'>&nbsp;</td> ";

                str += " <td width='48%'> ";
                str += "  <table width='100%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += " <td style='color:#777777;'> ";
                str += " <h5 style='color: #565457; font-size: 18px; padding: 5px 0px; margin: 0px;'> ";
                str += "  BILLING ADDRESS ";
                str += "  </h5> ";
                str += " <p style='margin:0px 2px; background:#d5d5d5; height:1px;'></p> ";
                str += " <p> ";
                str += " <strong>" + BCustName + "</strong><br /> ";
                if (BComName != "")
                {
                    str += " " + BComName + " <br />";
                }
                if (BLine1 != "")
                {
                    str += " " + BLine1 + " <br />";
                }
                if (BLineCity != "")
                {
                    str += " " + BLineCity + " <br />";
                }
                if (BStateName != "")
                {
                    str += " " + BStateName + " <br />";
                }
                if (BLinepostcode != "")
                {
                    str += " " + BLinepostcode + " <br />";
                }
                if (BLineCounName != "")
                {
                    str += " " + BLineCounName + " <br />";
                }
                if (BLinePMobile != "")
                {
                    str += " " + BLinePMobile + " <br />";
                }
                if (BLinePhone != "")
                {
                    str += " " + BLinePhone + " <br />";
                }
                if (BotherInfo != "")
                {
                    str += " " + BotherInfo + " <br />";
                }
                str += " </p> ";
                str += " </td> ";
                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";

                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";
                str += " </tr> ";
                #endregion

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";


                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += "  <td align='center'> ";
                str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";
                str += " <tr> ";
                str += "  <td>You can review your order and download your invoice from the <a href='https://www.sniggle.in/order-history' target='_blank'>'Order history'</a> section of your customer account by clicking  <a href='https://www.sniggle.in/my-account' target='_blank'>'My account'</a> on our shop.</td> ";
                str += "</tr> ";
                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";
                str += "  </table> ";
                str += " </td> ";
                str += " </tr>";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  </table> ";
                str += " </td> ";
                str += " </tr>";

                str += " <tr> ";
                str += "  <td bgcolor='#f4f5f7'> ";
                str += " <table width='100%' border='0' cellspacing='0' cellpadding='5' align='center'> ";
                str += " <tr> ";
                str += "  <td align='center'><h6 style='padding: 5px 0px; margin:0px; font-size: 18px;'>Follow us and stay in touch</h6></td> ";
                str += " </tr> ";

                str += " <tr>";
                str += " <td align='center'><a href='https://www.facebook.com/earthstoneinc' target='_blank'><img src='https://www.sniggle.in/img/fb1.png' /></a> &nbsp; <a href='https://twitter.com/earthstoneinc' target='_blank'><img src='https://www.sniggle.in/img/tw2.png' /></a> &nbsp; <a href='https://www.youtube.com/channel/UCzWCEOsGgbDD9-Abp3RJF3w' target='_blank'><img src='https://www.sniggle.in/img/yt3.png' /></a> &nbsp; <a href='https://www.linkedin.com/company/earth-stone-inc' target='_blank'><img src='https://www.sniggle.in/img/ld4.png' /></a> &nbsp; <a href='https://in.pinterest.com/myearthstone/pins/' target='_blank'><img src='https://www.sniggle.in/img/pt5.png' /></a> &nbsp; <a href='https://www.instagram.com/myearthstone' target='_blank'><img src='https://www.sniggle.in/img/insta6.png' /></a></td> ";
                str += "  </tr> ";
                str += "  </table> ";
                str += " </td> ";
                str += " </tr> ";

                str += "  </table>";
                str += " </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "</td>";
                str += "  </tr> ";
                str += "  </table>";
                //CustEmail = "gemsbead.jpr@gmail.com";
                //CustEmail = "shankar@sscompusoft.co.in";
                util.mail mail = new util.mail();
                mail.To = CustEmail;

                mail.Subject = "Order Confirmation Details at sniggle!.";
                mail.Message = str;
              //  mail.sendMail();
                string ststus = mail.sendMailAdmin();
                adminData.InsMail(CustEmail, "Order Confirmation", "Order Confirmation Details at sniggle!.", ststus, OrderID);
            }
            return str;
        }
    }

    public void EmailBackorderPaidAdmin(string OrderID)
    {
        string str = "";
        if (OrderID == "" && OrderID == null)
        {

        }
        else
        {
            cmd.CommandText = "sp_GetConfirmOrder";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderId", OrderID);
            ds = data.getDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                string cursign = ds.Tables[0].Rows[0]["cursign"].ToString();
                string firstname = ds.Tables[0].Rows[0]["firstname"].ToString();
                string lastname = ds.Tables[0].Rows[0]["lastname"].ToString();
                string CustName = firstname + " " + lastname;
                string CustEmail = ds.Tables[0].Rows[0]["email"].ToString();
                string reference = ds.Tables[0].Rows[0]["reference"].ToString();
                string DateTime = ds.Tables[0].Rows[0]["date_add"].ToString();
                string payment = ds.Tables[0].Rows[0]["payment"].ToString();
                string SubTotal = "0.00";
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (SubTotal != "" && SubTotal != null)
                    {
                        SubTotal = cursign + " " + ds.Tables[1].Rows[0]["SubTotal"].ToString();
                    }

                    dt = ds.Tables[1];
                }

                string Discounts = ds.Tables[0].Rows[0]["discountamt"].ToString();
                string code = ds.Tables[0].Rows[0]["code"].ToString();
                string Shipping = ds.Tables[0].Rows[0]["shippingamt"].ToString();
                string GTotal = ds.Tables[0].Rows[0]["OrderAmt"].ToString();
                string PsCareer = "PS career";


                string DCustName = ds.Tables[2].Rows[0]["CustName"].ToString();
                string DComName = ds.Tables[2].Rows[0]["company"].ToString();
                string DLine1 = ds.Tables[2].Rows[0]["address1"].ToString();
                string DLineCity = ds.Tables[2].Rows[0]["city"].ToString();
                string DLinepostcode = ds.Tables[2].Rows[0]["postcode"].ToString();
                string DStateName = ds.Tables[2].Rows[0]["StateName"].ToString();
                string DLineCounName = ds.Tables[2].Rows[0]["CountryName"].ToString();
                string DLinePMobile = ds.Tables[2].Rows[0]["phone_mobile"].ToString();
                string DLinePhone = ds.Tables[2].Rows[0]["phone"].ToString();
                string DotherInfo = ds.Tables[2].Rows[0]["other"].ToString();

                string BCustName = ds.Tables[3].Rows[0]["CustName"].ToString();
                string BComName = ds.Tables[3].Rows[0]["company"].ToString();
                string BLine1 = ds.Tables[3].Rows[0]["address1"].ToString();
                string BLineCity = ds.Tables[3].Rows[0]["city"].ToString();
                string BLinepostcode = ds.Tables[3].Rows[0]["postcode"].ToString();
                string BStateName = ds.Tables[3].Rows[0]["StateName"].ToString();
                string BLineCounName = ds.Tables[3].Rows[0]["CountryName"].ToString();
                string BLinePMobile = ds.Tables[3].Rows[0]["phone_mobile"].ToString();
                string BLinePhone = ds.Tables[3].Rows[0]["phone"].ToString();
                string BotherInfo = ds.Tables[3].Rows[0]["other"].ToString();


                str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
                str += " <tr> <td>";

                str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                str += "  <tr> ";
                str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
                str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

                str += "  <tr> ";
                str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
                str += " <a href='https://www.sniggle.in/' target='_blank'> ";
                str += "  <img src='https://www.sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
                str += "  </a>";
                str += " <td>";
                str += " <tr>";
                str += "  <tr> ";
                str += " <td>";
                str += "  <table width='98%' border='0' cellspacing='0' cellpadding='5' align='center'>";


                str += "  <tr> ";
                str += " <td><h4 style='font-size: 22px; font-weight: bold;'>CONGRATULATIONS!</h4> </td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td> A new order was placed on sniggle by the following customer.</td> ";
                str += " </tr> ";
                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";
                str += "  <tr> ";
                str += " <td><b>Customer Name:</b>  " + CustName + ",</td> ";
                str += " </tr> ";
                str += "  <tr> ";
                str += " <td><b>Email:</b> " + CustEmail + ",</td> ";
                str += " </tr> ";
                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                #region Order Detail Portion Start
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += "  <td> ";
                str += " <h4 style='font-size: 20px; padding: 5px 0px; margin: 0px; font-weight: bold;'> ORDER DETAILS </h4> ";
                str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                str += " <p style='padding-bottom:2px;'> ";
                str += "  Order: ";
                str += " <span> ";
                str += " " + reference + " Place on " + DateTime + " ";
                str += " </span> <br /><br /> ";
                str += " Payment : " + payment + "";
                str += " </p> ";
                str += "  </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "  </td> ";
                str += "  </tr> ";
                #endregion

                #region Product Detail Start
                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                //str += "  <td align='center'><h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'>Image</h6></td> ";
                str += "  <td align='center'><h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'>Reference</h6></td> ";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Product </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Unit price </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Quantity </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Total price </h6>  </td>";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td colspan='5' bgcolor='#FFFFFF'>&nbsp;</td> ";
                str += " </tr> ";

                foreach (DataRow dr in dt.Rows)
                {
                    str += "  <tr> ";
                    //str += " <td bgcolor='#FFFFFF'><a target='_blank' href='https://www.sniggle.in/" + dr["DetailUrl"] + "'> <img id='img" + dr["ProdReference"] + "' src = 'https://www.sniggle.in/" + dr["URL"] + "'  alt='img' /> <a /></td> ";
                    str += " <td bgcolor='#FFFFFF'>" + dr["ProdReference"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF'>" + dr["product_name"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='right'>" + dr["ProdPrice"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='center'>" + dr["ProdQty"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='right'>" + dr["ProdTotPrice"] + "</td> ";
                    str += " </tr> ";
                }

                str += "  <tr> ";
                str += " <td colspan='5' bgcolor='#FFFFFF'>&nbsp;</td> ";
                str += " </tr> ";


                #region Total Protion Start
                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Sub Total</strong></td> ";
                str += " <td align='right'>" + SubTotal + "</td> ";
                str += " </tr> ";

                if (code != "" && code != null)
                {
                    str += "  <tr> ";
                    str += "  <td colspan='4' align='right'><strong>Discounts  </strong></td> ";
                    str += " <td align='right'> -" + Discounts + "</td> ";
                    str += " </tr> ";
                }


                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Shipping</strong></td> ";
                str += " <td align='right'>" + Shipping + "</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Grand Total</strong></td> ";
                str += " <td align='right'  width='80px'>" + GTotal + "</td> ";
                str += " </tr> ";
                #endregion

                str += " </table>";
                str += " </td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                #endregion

                #region Bind Address Start
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";
                str += " <tr> ";
                str += " <td width='48%'> ";
                str += "  <table width='100%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += " <td style='color:#777777;'> ";
                str += " <h5 style='color: #565457; font-size: 18px; padding: 5px 0px; margin: 0px;'> ";
                str += "  DELIVERY ADDRESS ";
                str += "  </h5> ";
                str += " <p style='margin:0px 2px; background:#d5d5d5; height:1px;'></p> ";
                str += " <p> ";
                str += " <strong>" + DCustName + "</strong><br /> ";
                if (DComName != "")
                {
                    str += " " + DComName + " <br />";
                }
                if (DLine1 != "")
                {
                    str += " " + DLine1 + " <br />";
                }
                if (DLineCity != "")
                {
                    str += " " + DLineCity + " <br />";
                }
                if (DStateName != "")
                {
                    str += " " + DStateName + " <br />";
                }
                if (DLinepostcode != "")
                {
                    str += " " + DLinepostcode + " <br />";
                }
                if (DLineCounName != "")
                {
                    str += " " + DLineCounName + " <br />";
                }
                if (DLinePMobile != "")
                {
                    str += " " + DLinePMobile + " <br />";
                }
                if (DLinePhone != "")
                {
                    str += " " + DLinePhone + " <br />";
                }
                if (DotherInfo != "")
                {
                    str += " " + DotherInfo + " <br />";
                }
                str += " </p> ";
                str += " </td> ";
                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";

                str += " <td width='4%'>&nbsp;</td> ";

                str += " <td width='48%'> ";
                str += "  <table width='100%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += " <td style='color:#777777;'> ";
                str += " <h5 style='color: #565457; font-size: 18px; padding: 5px 0px; margin: 0px;'> ";
                str += "  BILLING ADDRESS ";
                str += "  </h5> ";
                str += " <p style='margin:0px 2px; background:#d5d5d5; height:1px;'></p> ";
                str += " <p> ";
                str += " <strong>" + BCustName + "</strong><br /> ";

                if (BComName != "")
                {
                    str += " " + BComName + " <br />";
                }
                if (BLine1 != "")
                {
                    str += " " + BLine1 + " <br />";
                }
                if (BLineCity != "")
                {
                    str += " " + BLineCity + " <br />";
                }
                if (BStateName != "")
                {
                    str += " " + BStateName + " <br />";
                }
                if (BLinepostcode != "")
                {
                    str += " " + BLinepostcode + " <br />";
                }
                if (BLineCounName != "")
                {
                    str += " " + BLineCounName + " <br />";
                }
                if (BLinePMobile != "")
                {
                    str += " " + BLinePMobile + " <br />";
                }
                if (BLinePhone != "")
                {
                    str += " " + BLinePhone + " <br />";
                }

                if (BotherInfo != "")
                {
                    str += " " + BotherInfo + " <br />";
                }
                str += " </p> ";
                str += " </td> ";
                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";

                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";
                str += " </tr> ";
                #endregion

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";


                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += "  <td align='center'> ";
                str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";


                //str += "  <tr> ";
                //str += " <td>If you have a guest account, you can follow your order via the <a href='#' target='_blank'>'Guest Tracking'</a> section on our shop.</td> ";
                //str += " </tr> ";
                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";
                str += "  </table> ";
                str += " </td> ";
                str += " </tr>";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  </table> ";
                str += " </td> ";
                str += " </tr>";


                str += "  </table>";
                str += " </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "</td>";
                str += "  </tr> ";
                str += "  </table>";
                util.mail mail = new util.mail();
                mail.To = "jaipur@gemspacific.com";
                //mail.To = "cs@sscompusoft.com";

                mail.Subject = "Order Confirmation Details at sniggle!.";
                mail.Message = str;
                 mail.sendMail();
               // string ststus = mail.sendMailAdmin();
                //adminData.InsMail(CustEmail, "Order Confirmation", "Order Confirmation Details at sniggle!.", ststus, OrderID);
            }
            //return str;
        }
    }

    public string EmailBackorderNotPaid(string OrderID)
    {
        string str = "";
        if (OrderID == "" && OrderID == null)
        {
            return "Order Id Not Valid";
        }
        else
        {
            cmd.CommandText = "sp_GetConfirmOrder";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderId", OrderID);
            ds = data.getDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                string cursign = ds.Tables[0].Rows[0]["cursign"].ToString();
                string firstname = ds.Tables[0].Rows[0]["firstname"].ToString();
                string lastname = ds.Tables[0].Rows[0]["lastname"].ToString();
                string CustName = firstname + " " + lastname;
                string reference = ds.Tables[0].Rows[0]["reference"].ToString();
                string DateTime = ds.Tables[0].Rows[0]["date_add"].ToString();
                string payment = ds.Tables[0].Rows[0]["payment"].ToString();
                string SubTotal = "0.00";
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (SubTotal != "" && SubTotal != null)
                    {
                        SubTotal = cursign + " " + ds.Tables[1].Rows[0]["SubTotal"].ToString();
                    }

                    dt = ds.Tables[1];
                }

                string Discounts = ds.Tables[0].Rows[0]["discountamt"].ToString();
                string code = ds.Tables[0].Rows[0]["code"].ToString();
                string Shipping = ds.Tables[0].Rows[0]["shippingamt"].ToString();
                string GTotal = ds.Tables[0].Rows[0]["OrderAmt"].ToString();
                string PsCareer = "PS career";

                string CustEmail = ds.Tables[0].Rows[0]["email"].ToString();

                string DCustName = ds.Tables[2].Rows[0]["CustName"].ToString();
                string DComName = ds.Tables[2].Rows[0]["company"].ToString();
                string DLine1 = ds.Tables[2].Rows[0]["address1"].ToString();
                string DLineCity = ds.Tables[2].Rows[0]["city"].ToString();
                string DLinepostcode = ds.Tables[2].Rows[0]["postcode"].ToString();
                string DStateName = ds.Tables[2].Rows[0]["StateName"].ToString();
                string DLineCounName = ds.Tables[2].Rows[0]["CountryName"].ToString();
                string DLinePMobile = ds.Tables[2].Rows[0]["phone_mobile"].ToString();
                string DLinePhone = ds.Tables[2].Rows[0]["phone"].ToString();
                string DotherInfo = ds.Tables[2].Rows[0]["other"].ToString();

                string BCustName = ds.Tables[3].Rows[0]["CustName"].ToString();
                string BComName = ds.Tables[3].Rows[0]["company"].ToString();
                string BLine1 = ds.Tables[3].Rows[0]["address1"].ToString();
                string BLineCity = ds.Tables[3].Rows[0]["city"].ToString();
                string BLinepostcode = ds.Tables[3].Rows[0]["postcode"].ToString();
                string BStateName = ds.Tables[3].Rows[0]["StateName"].ToString();
                string BLineCounName = ds.Tables[3].Rows[0]["CountryName"].ToString();
                string BLinePMobile = ds.Tables[3].Rows[0]["phone_mobile"].ToString();
                string BLinePhone = ds.Tables[3].Rows[0]["phone"].ToString();
                string BotherInfo = ds.Tables[3].Rows[0]["other"].ToString();


                str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
                str += " <tr> <td>";

                str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                str += "  <tr> ";
                str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
                str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

                str += "  <tr> ";
                str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
                str += " <a href='https://www.sniggle.in/' target='_blank'> ";
                str += "  <img src='https://www.sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
                str += "  </a>";
                str += " <td>";
                str += " <tr>";

                str += "  <tr> ";
                str += " <td>";
                str += "  <table width='98%' border='0' cellspacing='0' cellpadding='5' align='center'>";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>Hello " + CustName + ",</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>Thank you for shopping with sniggle. You order details are as follows:</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                #region Order Detail Portion Start
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += "  <td> ";
                str += " <h4 style='font-size: 20px; padding: 5px 0px; margin: 0px; font-weight: bold;'> ORDER DETAILS </h4> ";
                str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                str += " <p style='padding-bottom:2px;'> ";
                str += "  Order: ";
                str += " <span> ";
                str += " " + reference + " Place on " + DateTime + " ";
                str += " </span> <br /><br /> ";
                str += " Payment : Bank wire payment";
                str += " </p> ";
                str += "  </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "  </td> ";
                str += "  </tr> ";
                #endregion

                #region Product Detail Start
                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                //str += "  <td align='center'><h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'>Image</h6></td> ";
                str += "  <td align='center'><h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'>Reference</h6></td> ";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Product </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Unit price </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Quantity </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Total price </h6>  </td>";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td colspan='5' bgcolor='#FFFFFF'>&nbsp;</td> ";
                str += " </tr> ";

                foreach (DataRow dr in dt.Rows)
                {
                    str += "  <tr> ";
                    //str += " <td bgcolor='#FFFFFF'><a target='_blank' href='https://www.sniggle.in/" + dr["DetailUrl"] + "'> <img id='img" + dr["ProdReference"] + "' src = 'https://www.sniggle.in/" + dr["URL"] + "'  alt='img' /> <a /></td> ";
                    str += " <td bgcolor='#FFFFFF'>" + dr["ProdReference"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF'>" + dr["product_name"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='right'>" + dr["ProdPrice"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='center'>" + dr["ProdQty"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='right'>" + dr["ProdTotPrice"] + "</td> ";

                    str += " </tr> ";
                }

                str += "  <tr> ";
                str += " <td colspan='5' bgcolor='#FFFFFF'>&nbsp;</td> ";
                str += " </tr> ";


                #region Total Protion Start
                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Sub Total</strong></td> ";
                str += " <td align='right'>" + SubTotal + "</td> ";
                str += " </tr> ";

                if (code != "" && code != null)
                {
                    str += "  <tr> ";
                    str += "  <td colspan='4' align='right'><strong>Discounts  </strong></td> ";
                    str += " <td align='right'> -" + Discounts + "</td> ";
                    str += " </tr> ";
                }


                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Shipping</strong></td> ";
                str += " <td align='right'>" + Shipping + "</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Grand Total</strong></td> ";
                str += " <td align='right'  width='80px'>" + GTotal + "</td> ";
                str += " </tr> ";
                #endregion

                str += " </table>";
                str += " </td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                #endregion

                #region Shippind Detail
                //str += " <tr> ";
                //str += " <td align='center'> ";
                //str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                //str += " <tr> ";
                //str += " <td> ";
                //str += " <h4 style='font-size:20px; padding: 5px 0px; margin: 0px;'>SHIPPING</h4> ";
                //str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                //str += "  <p> ";
                //str += "  Order: <span style='color:#999;'>" + PsCareer + "</span> <br /><br /> ";
                //str += " Payment : " + payment + "";
                //str += " </p> ";
                //str += " </td> ";
                //str += "  </tr> ";
                //str += " </table> ";
                //str += " </td> ";
                //str += " </tr> ";

                //str += "  <tr> ";
                //str += " <td>&nbsp;</td> ";
                //str += " </tr> ";
                #endregion

                #region Bind Address Start
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";
                str += " <tr> ";
                str += " <td width='48%'> ";
                str += "  <table width='100%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += " <td style='color:#777777;'> ";
                str += " <h5 style='color: #565457; font-size: 18px; padding: 5px 0px; margin: 0px;'> ";
                str += "  DELIVERY ADDRESS ";
                str += "  </h5> ";
                str += " <p style='margin:0px 2px; background:#d5d5d5; height:1px;'></p> ";
                str += " <p> ";
                str += " <strong>" + DCustName + "</strong><br /> ";
                if (DComName != "")
                {
                    str += " " + DComName + " <br />";
                }
                if (DLine1 != "")
                {
                    str += " " + DLine1 + " <br />";
                }
                if (DLineCity != "")
                {
                    str += " " + DLineCity + " <br />";
                }
                if (DStateName != "")
                {
                    str += " " + DStateName + " <br />";
                }
                if (DLinepostcode != "")
                {
                    str += " " + DLinepostcode + " <br />";
                }
                if (DLineCounName != "")
                {
                    str += " " + DLineCounName + " <br />";
                }
                if (DLinePMobile != "")
                {
                    str += " " + DLinePMobile + " <br />";
                }
                if (DLinePhone != "")
                {
                    str += " " + DLinePhone + " <br />";
                }
                if (DotherInfo != "")
                {
                    str += " " + DotherInfo + " <br />";
                }
                str += " </p> ";
                str += " </td> ";
                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";

                str += " <td width='4%'>&nbsp;</td> ";

                str += " <td width='48%'> ";
                str += "  <table width='100%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += " <td style='color:#777777;'> ";
                str += " <h5 style='color: #565457; font-size: 18px; padding: 5px 0px; margin: 0px;'> ";
                str += "  BILLING ADDRESS ";
                str += "  </h5> ";
                str += " <p style='margin:0px 2px; background:#d5d5d5; height:1px;'></p> ";
                str += " <p> ";
                str += " <strong>" + BCustName + "</strong><br /> ";
                if (BComName != "")
                {
                    str += " " + BComName + " <br />";
                }
                if (BLine1 != "")
                {
                    str += " " + BLine1 + " <br />";
                }
                if (BLineCity != "")
                {
                    str += " " + BLineCity + " <br />";
                }
                if (BStateName != "")
                {
                    str += " " + BStateName + " <br />";
                }
                if (BLinepostcode != "")
                {
                    str += " " + BLinepostcode + " <br />";
                }
                if (BLineCounName != "")
                {
                    str += " " + BLineCounName + " <br />";
                }
                if (BLinePMobile != "")
                {
                    str += " " + BLinePMobile + " <br />";
                }
                if (BLinePhone != "")
                {
                    str += " " + BLinePhone + " <br />";
                }
                if (BotherInfo != "")
                {
                    str += " " + BotherInfo + " <br />";
                }
                str += " </p> ";
                str += " </td> ";
                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";

                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";
                str += " </tr> ";
                #endregion

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";


                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += "  <td align='center'> ";
                str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";
                str += " <tr> ";
                str += "  <td>You can review your order and download your invoice from the <a href='https://www.sniggle.in/order-history' target='_blank'>'Order history'</a> section of your customer account by clicking  <a href='https://www.sniggle.in/my-account' target='_blank'>'My account'</a> on our shop.</td> ";
                str += "</tr> ";
                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";
                str += "  </table> ";
                str += " </td> ";
                str += " </tr>";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  </table> ";
                str += " </td> ";
                str += " </tr>";

                str += " <tr> ";
                str += "  <td bgcolor='#f4f5f7'> ";
                str += " <table width='100%' border='0' cellspacing='0' cellpadding='5' align='center'> ";
                str += " <tr> ";
                str += "  <td align='center'><h6 style='padding: 5px 0px; margin:0px; font-size: 18px;'>Follow us and stay in touch</h6></td> ";
                str += " </tr> ";

                str += " <tr>";
                str += " <td align='center'><a href='https://www.facebook.com/earthstoneinc' target='_blank'><img src='https://www.sniggle.in/img/fb1.png' /></a> &nbsp; <a href='https://twitter.com/earthstoneinc' target='_blank'><img src='https://www.sniggle.in/img/tw2.png' /></a> &nbsp; <a href='https://www.youtube.com/channel/UCzWCEOsGgbDD9-Abp3RJF3w' target='_blank'><img src='https://www.sniggle.in/img/yt3.png' /></a> &nbsp; <a href='https://www.linkedin.com/company/earth-stone-inc' target='_blank'><img src='https://www.sniggle.in/img/ld4.png' /></a> &nbsp; <a href='https://in.pinterest.com/myearthstone/pins/' target='_blank'><img src='https://www.sniggle.in/img/pt5.png' /></a> &nbsp; <a href='https://www.instagram.com/myearthstone' target='_blank'><img src='https://www.sniggle.in/img/insta6.png' /></a></td> ";
                str += "  </tr> ";
                str += "  </table> ";
                str += " </td> ";
                str += " </tr> ";

                str += "  </table>";
                str += " </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "</td>";
                str += "  </tr> ";
                str += "  </table>";
                //CustEmail = "gemsbead.jpr@gmail.com";
               // CustEmail = "cs@sscompusoft.com";
                util.mail mail = new util.mail();
                mail.To = CustEmail;

                mail.Subject = "Order Confirmation Details at sniggle!.";
                mail.Message = str;
                // mail.sendMail();
                string ststus = mail.sendMailAdmin();
                adminData.InsMail(CustEmail, "Bank wire", "Bank wire at sniggle!.", ststus, OrderID);
            }
            return str;
        }
    }

    public void EmailBackorderNotPaidAdmin(string OrderID)
    {
        string str = "";
        if (OrderID == "" && OrderID == null)
        {

        }
        else
        {
            cmd.CommandText = "sp_GetConfirmOrder";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderId", OrderID);
            ds = data.getDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                string cursign = ds.Tables[0].Rows[0]["cursign"].ToString();
                string firstname = ds.Tables[0].Rows[0]["firstname"].ToString();
                string lastname = ds.Tables[0].Rows[0]["lastname"].ToString();
                string CustName = firstname + " " + lastname;
                string CustEmail = ds.Tables[0].Rows[0]["email"].ToString();
                string reference = ds.Tables[0].Rows[0]["reference"].ToString();
                string DateTime = ds.Tables[0].Rows[0]["date_add"].ToString();
                string payment = ds.Tables[0].Rows[0]["payment"].ToString();
                string SubTotal = "0.00";
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (SubTotal != "" && SubTotal != null)
                    {
                        SubTotal = cursign + " " + ds.Tables[1].Rows[0]["SubTotal"].ToString();
                    }

                    dt = ds.Tables[1];
                }

                string Discounts = ds.Tables[0].Rows[0]["discountamt"].ToString();
                string code = ds.Tables[0].Rows[0]["code"].ToString();
                string Shipping = ds.Tables[0].Rows[0]["shippingamt"].ToString();
                string GTotal = ds.Tables[0].Rows[0]["OrderAmt"].ToString();
                string PsCareer = "PS career";


                string DCustName = ds.Tables[2].Rows[0]["CustName"].ToString();
                string DComName = ds.Tables[2].Rows[0]["company"].ToString();
                string DLine1 = ds.Tables[2].Rows[0]["address1"].ToString();
                string DLineCity = ds.Tables[2].Rows[0]["city"].ToString();
                string DLinepostcode = ds.Tables[2].Rows[0]["postcode"].ToString();
                string DStateName = ds.Tables[2].Rows[0]["StateName"].ToString();
                string DLineCounName = ds.Tables[2].Rows[0]["CountryName"].ToString();
                string DLinePMobile = ds.Tables[2].Rows[0]["phone_mobile"].ToString();
                string DLinePhone = ds.Tables[2].Rows[0]["phone"].ToString();
                string DotherInfo = ds.Tables[2].Rows[0]["other"].ToString();

                string BCustName = ds.Tables[3].Rows[0]["CustName"].ToString();
                string BComName = ds.Tables[3].Rows[0]["company"].ToString();
                string BLine1 = ds.Tables[3].Rows[0]["address1"].ToString();
                string BLineCity = ds.Tables[3].Rows[0]["city"].ToString();
                string BLinepostcode = ds.Tables[3].Rows[0]["postcode"].ToString();
                string BStateName = ds.Tables[3].Rows[0]["StateName"].ToString();
                string BLineCounName = ds.Tables[3].Rows[0]["CountryName"].ToString();
                string BLinePMobile = ds.Tables[3].Rows[0]["phone_mobile"].ToString();
                string BLinePhone = ds.Tables[3].Rows[0]["phone"].ToString();
                string BotherInfo = ds.Tables[3].Rows[0]["other"].ToString();


                str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
                str += " <tr> <td>";

                str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                str += "  <tr> ";
                str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
                str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

                str += "  <tr> ";
                str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
                str += " <a href='https://www.sniggle.in/' target='_blank'> ";
                str += "  <img src='https://www.sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
                str += "  </a>";
                str += " <td>";
                str += " <tr>";
                str += "  <tr> ";
                str += " <td>";
                str += "  <table width='98%' border='0' cellspacing='0' cellpadding='5' align='center'>";


                str += "  <tr> ";
                str += " <td><h4 style='font-size: 22px; font-weight: bold;'>CONGRATULATIONS!</h4> </td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td> A new order was placed on sniggle by the following customer.</td> ";
                str += " </tr> ";
                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";
                str += "  <tr> ";
                str += " <td><b>Customer Name:</b>  " + CustName + ",</td> ";
                str += " </tr> ";
                str += "  <tr> ";
                str += " <td><b>Email:</b> " + CustEmail + ",</td> ";
                str += " </tr> ";
                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                #region Order Detail Portion Start
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += "  <td> ";
                str += " <h4 style='font-size: 20px; padding: 5px 0px; margin: 0px; font-weight: bold;'> ORDER DETAILS </h4> ";
                str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                str += " <p style='padding-bottom:2px;'> ";
                str += "  Order: ";
                str += " <span> ";
                str += " " + reference + " Place on " + DateTime + " ";
                str += " </span> <br /><br /> ";
                str += " Payment : Bank wire payment";
                str += " </p> ";
                str += "  </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "  </td> ";
                str += "  </tr> ";
                #endregion

                #region Product Detail Start
                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                //str += "  <td align='center'><h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'>Image</h6></td> ";
                str += "  <td align='center'><h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'>Reference</h6></td> ";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Product </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Unit price </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Quantity </h6>  </td>";
                str += " <td>  <h6 style='font-size:16px; padding: 5px 0px; margin: 0px;'> Total price </h6>  </td>";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td colspan='5' bgcolor='#FFFFFF'>&nbsp;</td> ";
                str += " </tr> ";

                foreach (DataRow dr in dt.Rows)
                {
                    str += "  <tr> ";
                    //str += " <td bgcolor='#FFFFFF'><a target='_blank' href='https://www.sniggle.in/" + dr["DetailUrl"] + "'> <img id='img" + dr["ProdReference"] + "' src = 'https://www.sniggle.in/" + dr["URL"] + "'  alt='img' /> <a /></td> ";
                    str += " <td bgcolor='#FFFFFF'>" + dr["ProdReference"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF'>" + dr["product_name"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='right'>" + dr["ProdPrice"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='center'>" + dr["ProdQty"] + "</td> ";

                    str += " <td bgcolor='#FFFFFF' align='right'>" + dr["ProdTotPrice"] + "</td> ";
                    str += " </tr> ";
                }

                str += "  <tr> ";
                str += " <td colspan='5' bgcolor='#FFFFFF'>&nbsp;</td> ";
                str += " </tr> ";


                #region Total Protion Start
                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Sub Total</strong></td> ";
                str += " <td align='right'>" + SubTotal + "</td> ";
                str += " </tr> ";

                if (code != "" && code != null)
                {
                    str += "  <tr> ";
                    str += "  <td colspan='4' align='right'><strong>Discounts  </strong></td> ";
                    str += " <td align='right'> -" + Discounts + "</td> ";
                    str += " </tr> ";
                }


                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Shipping</strong></td> ";
                str += " <td align='right'>" + Shipping + "</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += "  <td colspan='4' align='right'><strong>Grand Total</strong></td> ";
                str += " <td align='right'  width='80px'>" + GTotal + "</td> ";
                str += " </tr> ";
                #endregion

                str += " </table>";
                str += " </td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                #endregion

                #region Bind Address Start
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";
                str += " <tr> ";
                str += " <td width='48%'> ";
                str += "  <table width='100%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += " <td style='color:#777777;'> ";
                str += " <h5 style='color: #565457; font-size: 18px; padding: 5px 0px; margin: 0px;'> ";
                str += "  DELIVERY ADDRESS ";
                str += "  </h5> ";
                str += " <p style='margin:0px 2px; background:#d5d5d5; height:1px;'></p> ";
                str += " <p> ";
                str += " <strong>" + DCustName + "</strong><br /> ";
                if (DComName != "")
                {
                    str += " " + DComName + " <br />";
                }
                if (DLine1 != "")
                {
                    str += " " + DLine1 + " <br />";
                }
                if (DLineCity != "")
                {
                    str += " " + DLineCity + " <br />";
                }
                if (DStateName != "")
                {
                    str += " " + DStateName + " <br />";
                }
                if (DLinepostcode != "")
                {
                    str += " " + DLinepostcode + " <br />";
                }
                if (DLineCounName != "")
                {
                    str += " " + DLineCounName + " <br />";
                }
                if (DLinePMobile != "")
                {
                    str += " " + DLinePMobile + " <br />";
                }
                if (DLinePhone != "")
                {
                    str += " " + DLinePhone + " <br />";
                }
                if (DotherInfo != "")
                {
                    str += " " + DotherInfo + " <br />";
                }
                str += " </p> ";
                str += " </td> ";
                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";

                str += " <td width='4%'>&nbsp;</td> ";

                str += " <td width='48%'> ";
                str += "  <table width='100%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += " <td style='color:#777777;'> ";
                str += " <h5 style='color: #565457; font-size: 18px; padding: 5px 0px; margin: 0px;'> ";
                str += "  BILLING ADDRESS ";
                str += "  </h5> ";
                str += " <p style='margin:0px 2px; background:#d5d5d5; height:1px;'></p> ";
                str += " <p> ";
                str += " <strong>" + BCustName + "</strong><br /> ";

                if (BComName != "")
                {
                    str += " " + BComName + " <br />";
                }
                if (BLine1 != "")
                {
                    str += " " + BLine1 + " <br />";
                }
                if (BLineCity != "")
                {
                    str += " " + BLineCity + " <br />";
                }
                if (BStateName != "")
                {
                    str += " " + BStateName + " <br />";
                }
                if (BLinepostcode != "")
                {
                    str += " " + BLinepostcode + " <br />";
                }
                if (BLineCounName != "")
                {
                    str += " " + BLineCounName + " <br />";
                }
                if (BLinePMobile != "")
                {
                    str += " " + BLinePMobile + " <br />";
                }
                if (BLinePhone != "")
                {
                    str += " " + BLinePhone + " <br />";
                }

                if (BotherInfo != "")
                {
                    str += " " + BotherInfo + " <br />";
                }
                str += " </p> ";
                str += " </td> ";
                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";

                str += " </tr> ";
                str += " </table> ";
                str += " </td> ";
                str += " </tr> ";
                #endregion

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";


                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += "  <td align='center'> ";
                str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";


                //str += "  <tr> ";
                //str += " <td>If you have a guest account, you can follow your order via the <a href='#' target='_blank'>'Guest Tracking'</a> section on our shop.</td> ";
                //str += " </tr> ";
                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";
                str += "  </table> ";
                str += " </td> ";
                str += " </tr>";

                str += "  <tr> ";
                str += " <td></td> ";
                str += " </tr> ";

                str += "  </table> ";
                str += " </td> ";
                str += " </tr>";


                str += "  </table>";
                str += " </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "</td>";
                str += "  </tr> ";
                str += "  </table>";
                util.mail mail = new util.mail();
                mail.To = "jaipur@gemspacific.com";
              //  mail.To = "cs@sscompusoft.com";

                mail.Subject = "Order Confirmation Details at sniggle!.";
                mail.Message = str;
                mail.sendMail();
            }
            //return str;
        }
    }
}
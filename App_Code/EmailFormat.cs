using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for EmailFormat
/// </summary>
public class EmailFormat
{
    Data data = new Data();
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    AdminGetData adminData = new AdminGetData();
    public EmailFormat()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void EmailRegistration(string Email, string Password, string CustName)
    {
        string str = "";
        str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
        str += " <tr> <td>";

        str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
        str += "  <tr> ";
        str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
        str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

        str += "  <tr> ";
        str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
        str += " <a href='https://sniggle.in/' target='_blank'> ";
        str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
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
        str += " <td><h2 style='padding: 5px 0px; margin: 0px;'>Welcome to Sniggle!</h2></td> ";
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
        str += " <td>Thank you for creating a customer account at Sniggle. Your login details are as follows:</td> ";
        str += " </tr> ";
        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";
        str += "  <tr> ";
        str += " <td><strong>E-mail address:</strong> " + Email + "</td> ";
        str += " </tr> ";
        str += "  <tr> ";
        str += " <td><strong>Password:</strong> " + Password + "</td> ";
        str += " </tr> ";
        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";
        str += "  <tr> ";
        str += " <td>Don't miss out on this great deal on your first order!</td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td align='center'> ";
        str += " <div style='position:relative; display:block; border:1px dashed #bdbdbd;'>";
        str += " <h3 style='color: #6CD1BB; padding: 5px 0px;  margin: 0px; font-size: 22px'> ";
        str += "  Use Code &quot;<b> WELCOME </b>&quot; &amp; Get Flat 5% Discount ";
        str += "  </h3>";
        str += "  <img src='https://sniggle.in/img/scissors.png'  ";
        str += " style='position:absolute;  bottom:-7px; left:30px; z-index:1; ' />";
        str += " </div>";
        str += " </td>";
        str += " </tr>";

        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

        str += "  <tr>";
        str += "  <td><h4 style='padding: 5px 0px; margin:0px;'>Important Security Tips:</h4></td>";
        str += " </tr>";


        str += "  <tr> ";
        str += " <td>";
        str += "  <table width='100%' border='0' cellspacing='0' cellpadding='5'>";

        str += " <tr>";
        str += "  <td>1.</td>";
        str += "  <td>Always Keep your account details safe.</td>";
        str += " </tr>";

        str += " <tr>";
        str += " <td>2.</td>";
        str += " <td>Never disclose your login details to anyone.</td>";
        str += " </tr>";

        str += " <tr>";
        str += " <td>3.</td>";
        str += " <td>Change your password regulary.</td>";
        str += "  </tr>";

        str += " <tr>";
        str += " <td>4.</td> ";
        str += " <td>Should you suspect someone is using your account illegally, please notify us immadiately.</td>";
        str += " </tr>";
        str += "  </table> ";
        str += " </td> ";
        str += " </tr>";

        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

        str += "<tr>";
        str += " <td>Now you can place orders on our shop : <a href='https://sniggle.in/' target='_blank' style='text-decoration:none;'>Sniggle</a></td> ";
        str += " </tr> ";

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
        str += " <td align='center'><a href='#' target='_blank'><img src='https://sniggle.in/img/fb1.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/tw2.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/yt3.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/ld4.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/pt5.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/insta6.png' /></a></td> ";
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
        str += AddressBar();
        str += "  </table>";

        util.mail mail = new util.mail();
        mail.To = Email;

        mail.Subject = "New Customer Registerd at Sniggle!.";
        mail.Message = str;
        string ststus = mail.sendMailAdmin();
        adminData.InsMail(Email, "Customer Registerd", "New Customer Registerd at Sniggle!.", ststus, "0");
    }



    public void EmailForgotPassword(string CustName, string link, string Email)
    {
        string str = "";
        str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
        str += " <tr> <td>";

        str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
        str += "  <tr> ";
        str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
        str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

        str += "  <tr> ";
        str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
        str += " <a href='https://sniggle.in/' target='_blank'> ";
        str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
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
        str += " <td>We received a request to reset your password. Use the link below to set up a new password for your account.</td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

        str += " <tr> ";
        str += " <td align='center'> ";
        str += " <table width='80%' border='0' cellspacing='0' cellpadding='0'> ";
        str += " <tr> ";
        str += " <td style='background:#f7f7ff; border:3px solid #6CD1BB; border-radius:5px;'> ";

        str += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
        str += " <tr> ";
        str += " <td align='center'><img src='https://sniggle.in/img/forget-lock.png' /></td> ";
        str += " </tr> ";

        str += " <tr> ";
        str += " <td align='center'> ";
        str += "<h2 style='font-size: 24px; padding:5px 0px; margin:0px;'> FORGOT <br/>  YOUR PASSWORD </h2> ";
        str += " </td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td>&nbsp;</td> ";
        str += " </tr> ";

        str += " <tr> ";
        str += "  <td align='center'>Not to worry! Click on button &amp; get a new password!</td>";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td>&nbsp;</td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td align='center'><a href='" + link + "' target='_blank'><img src='https://sniggle.in/img/reset-button.png' /></a></td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td>&nbsp;</td> ";
        str += " </tr> ";

        str += "  </table> ";
        str += " </td> ";
        str += "  </tr> ";
        str += "  </table> ";
        str += " </td> ";
        str += "  </tr> ";


        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td>&nbsp;</td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td>If you're having trouble clicking the reset password button, copy and paste the url below into your web browser.</td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td><a href='" + link + "' target='_blank' style='text-decoration:none;'>" + link + "</a></td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td>&nbsp;</td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td>Please note that this will change your current password, if you didn't request to reset your password, ignore this email, your password will not change.</td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td>&nbsp;</td> ";
        str += " </tr> ";

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
        str += " <td align='center'><a href='#' target='_blank'><img src='https://sniggle.in/img/fb1.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/tw2.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/yt3.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/ld4.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/pt5.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/insta6.png' /></a></td> ";
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
        str += AddressBar();
        str += "  </table>";
        util.mail mail = new util.mail();
        mail.To = Email;

        mail.Subject = "Forgot password details at Sniggle!.";
        mail.Message = str;
        string ststus = mail.sendMailAdmin();
        adminData.InsMail(Email, "Forgot password", "Forgot password details at Sniggle!.", ststus, "0");
    }

    public string EmailOrderConfirmation(string OrderID)
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
                string cust_msg = ds.Tables[0].Rows[0]["message"].ToString();
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
                str += " <a href='https://sniggle.in/' target='_blank'> ";
                str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
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
                str += " <td>Thank you for shopping with Sniggle. You order details are as follows:</td> ";
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
                    //str += " <td bgcolor='#FFFFFF'><a target='_blank' href='https://sniggle.in/" + dr["DetailUrl"] + "'> <img id='img" + dr["ProdReference"] + "' src = 'https://sniggle.in/" + dr["URL"] + "'  alt='img' /> <a /></td> ";
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
                #region Customer Message
                if (cust_msg != "" && cust_msg != null && cust_msg.Trim() != "")
                {
                    str += " <tr> ";
                    str += " <td align='center'> ";
                    str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                    str += " <tr> ";
                    str += " <td> ";
                    str += " <h4 style='font-size:20px; padding: 5px 0px; margin: 0px;'>Message</h4> ";
                    str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                    str += "  <p> ";
                    str += "   " + cust_msg + "";
                    str += " </p> ";
                    str += " </td> ";
                    str += "  </tr> ";
                    str += " </table> ";
                    str += " </td> ";
                    str += " </tr> ";

                }
                #endregion

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
                str += "  <td>You can review your order and download your invoice from the <a href='https://sniggle.in/order-history' target='_blank'>'Order history'</a> section of your customer account by clicking  <a href='https://sniggle.in/my-account' target='_blank'>'My account'</a> on our shop.</td> ";
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
                str += " <td align='center'><a href='#' target='_blank'><img src='https://sniggle.in/img/fb1.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/tw2.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/yt3.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/ld4.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/pt5.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/insta6.png' /></a></td> ";
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
                str += AddressBar();
                str += "  </table>"; 
                //CustEmail = "shankar@sscompusoft.co.in";
                util.mail mail = new util.mail();
                mail.To = CustEmail; 
                mail.Subject = "Order Confirmation Details at Sniggle!.";
                mail.Message = str;
                string ststus = mail.sendMailAdmin();
                adminData.InsMail(CustEmail, "Order Confirmation", "Order Confirmation Details at Sniggle!.", ststus, OrderID);
            }
            return str;
        }
    }

    public void EmailOrderConfirmationAdmin(string OrderID)
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
                string cust_msg = ds.Tables[0].Rows[0]["message"].ToString();
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
                str += " <a href='https://sniggle.in/' target='_blank'> ";
                str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
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
                str += " <td> A new order was placed on Sniggle by the following customer.</td> ";
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
                    //str += " <td bgcolor='#FFFFFF'><a target='_blank' href='https://sniggle.in/" + dr["DetailUrl"] + "'> <img id='img" + dr["ProdReference"] + "' src = 'https://sniggle.in/" + dr["URL"] + "'  alt='img' /> <a /></td> ";
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

                #region Customer Message
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += " <td> ";
                str += " <h4 style='font-size:20px; padding: 5px 0px; margin: 0px;'>Message</h4> ";
                str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                str += "  <p> ";
                str += "   " + cust_msg + "";
                str += " </p> ";
                str += " </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += " </td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";
                #endregion

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
                str += AddressBar();
                str += "  </table>";
                util.mail mail = new util.mail();
                //mail.To = "snigglejpr@gmail.com";
                mail.To = "snigglejpr@gmail.com";

                mail.Subject = "Order Confirmation Details at Sniggle!.";
                mail.Message = str;
                string ststus = mail.sendMailAdmin();
                adminData.InsMail("snigglejpr@gmail.com", "Order Confirmation", "Order Confirmation Details at Sniggle!.", ststus, OrderID);
            }
            //return str;
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
            str += " <a href='https://sniggle.in/' target='_blank'> ";
            str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
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
            str += " <span style='color:#777;'>from</span> <strong>Sniggle</strong>  ";
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
            str += "  <td>You can review your order and download your invoice from the <a href='https://sniggle.in/order-history' target='_blank'>'Order history'</a> section of your customer account by clicking  <a href='https://sniggle.in/my-account' target='_blank'>'My account'</a> on our shop.</td> ";
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
            str += " <td align='center'><a href='#' target='_blank'><img src='https://sniggle.in/img/fb1.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/tw2.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/yt3.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/ld4.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/pt5.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/insta6.png' /></a></td> ";
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
            str += AddressBar();
            str += "  </table>";
            //CustEmail = "shankar@sscompusoft.co.in";
            util.mail mail = new util.mail();
            mail.To = CustEmail;

            mail.Subject = "Order Cancellation  Notification at Sniggle!.";
            mail.Message = str;
            string ststus = mail.sendMailAdmin();
            adminData.InsMail(CustEmail, "Order Confirmation", "Order Confirmation Details at Sniggle!.", ststus, OrderID);

        }
    }


    public void EmailProductEnquiry(string CustName, string CustEmail, string Subject, string msg,
        string img, string price, string ProdId, string ProdName, string url)
    {
        string str = "";
        str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
        str += " <tr> <td>";

        str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
        str += "  <tr> ";
        str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
        str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

        str += "  <tr> ";
        str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
        str += " <a href='https://sniggle.in/' target='_blank'> ";
        str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
        str += "  </a>";
        str += " <td>";
        str += " </tr>";

        str += "  <tr> ";
        str += " <td>";
        str += "  <table width='98%' border='0' cellspacing='0' cellpadding='5' align='center'>";
        str += "  <tr> ";
        str += " <td>&nbsp;</td> ";
        str += " </tr> ";
        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

        #region Product detail start
        str += "  <tr> ";
        str += " <td align='center'>";
        str += " <table width='98%' border='1' cellspacing='0' cellpadding='10' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'>";
        str += "<tr>";
        str += "<td>";
        str += " <h4 style='padding: 5px 0px; margin: 0px; font-size:20px;'>This mail is send by a customer regarding this product:</h4>";
        str += "<p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p>";

        str += " <p>";
        str += "<table width='100%' border='1' cellspacing='0' cellpadding='10' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;' align='center'>";

        str += "<tr>";
        str += "<td width='19%' align='center'><h6 style='padding: 5px 0px; margin: 0px; font-size:16px;'>Product Id</h6></td>";
        str += "<td width='21%'><h6 style='padding: 5px 0px; margin: 0px; font-size: 16px;'>Product Image</h6></td>";
        str += "<td width='44%'><h6 style='padding: 5px 0px; margin: 0px; font-size: 16px;'>Product Name</h6></td>";
        str += "<td width='16%'><h6 style='padding: 5px 0px; margin: 0px; font-size: 16px;'>Price (tax Incl.)</h6></td>";
        str += " </tr>";

        str += "<tr>";
        str += "<td bgcolor='#FFFFFF'>" + ProdId + "</td>";
        str += "<td bgcolor='#FFFFFF'><a href='" + url + "' target='_blank'><img src='https://sniggle.in/" + img + "' width='auto' height='100px' /></a></td> ";
        str += "<td bgcolor='#FFFFFF'><a href='" + url + "' target='_blank'>" + ProdName + "</a></td>";
        str += "<td bgcolor='#FFFFFF'>$" + price + "</td>";
        str += " </tr>";

        str += " </table>";
        str += " </p>";

        str += " <p><span> <strong>Name :</strong> " + CustName + " </span></p>";
        str += " <p><span> <strong>Email :</strong> <a href='mailto:" + CustEmail + "' target='_blank'>" + CustEmail + "</a></span></p>";
        str += " <p><strong>Subject:</strong> " + Subject + "</p> ";
        if (msg != "" || msg != null)
        {
            str += " <p><strong>Message:</strong> " + msg + "</p> ";
        }

        str += " </td> ";
        str += "  </tr> ";
        str += "  </table> ";
        str += " </td> ";
        str += "  </tr> ";
        #endregion

        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td>&nbsp;</td> ";
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
        str += AddressBar();
        str += "  </table>";

        util.mail mail = new util.mail();
        //mail.To = "snigglejpr@gmail.com";
        mail.To = "snigglejpr@gmail.com";
        if (Subject == "Notification for reorder")
        {
            mail.Subject = "Notification for reorder.";
        }
        else
        {
            mail.Subject = "Enquiry About this product";
        }
        mail.Message = str;
        string ststus = mail.sendMailAdmin();
        adminData.InsMail("snigglejpr@gmail.com", "Enquiry About this product", "Enquiry About this product", ststus, "0");
    }

    public void EmailCustomOrder(string msg, string Name, string Email, string contactno, string stonename, string description, string attachfile)
    {
        string str = "";
        #region  Header 
        str = " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
        str += " <tr>";
        str += " <td> ";
        str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
        str += " <tr> ";
        str += " <td style='border:1px solid #f4f5f7; border-radius:3px;'> ";
        str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

        str += "  <tr> ";
        str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
        str += " <a href='https://sniggle.in/' target='_blank'> ";
        str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
        str += "  </a>";
        str += " <td>";
        str += " </tr>";

        #endregion

        #region Content Region
        str += "  <tr> ";
        str += " <td> ";
        str += " <table width='98%' border='0' cellspacing='0' cellpadding='5' align='center'> ";


        str += " <tr> <td>&nbsp;</td> </tr>";
        str += " <tr> <td><h5  style='padding: 5px 0px; margin: 0px; font-size:18px;'>" + msg + "</h5></td></tr>";
        str += " <tr> <td> </td> </tr>";


        str += "  <tr> ";
        str += " <td align='center' style='border:1px solid #d6d4d5; background-color:#f8f8f8; color:#666;'> ";
        str += " <table width='100%' border='0' cellspacing='0' cellpadding='5'>";
        str += " <tr> <td> </td> </tr>";
        str += " <tr> <td><strong>Customer Name:</strong> " + Name + " </td> </tr>";
        str += " <tr> <td><strong>E-mail address:</strong> " + Email + " </td> </tr>";
        str += " <tr> <td><strong>Contact No.:</strong> " + contactno + " </td> </tr>";
        if (stonename != "")
        {
            str += " <tr> <td><strong>Stone Name:</strong> " + stonename + " </td> </tr>";
        }
        str += " <tr> <td><strong>Message:</strong> " + description + " </td> </tr>";
        str += " <tr> <td>&nbsp;</td> </tr>";
        str += " <tr> <td>&nbsp;</td> </tr>";
        if (attachfile != "" && attachfile != null)
        {
            str += " <tr> <td><strong>Attached File : </strong> <a href='https://sniggle.in/img/ContactUs/" + attachfile + "' target='_blank'>View Attached File</a></td> </tr>";
        }
        str += " <tr> <td>&nbsp;</td> </tr>";
        str += " </table> ";
        str += " </td> ";
        str += " </tr> ";


        str += " <tr> <td></td> </tr>";
        str += " <tr> <td>&nbsp;</td> </tr>";
        str += " <tr> <td></td> </tr>";

        str += " </table> ";
        str += " </td> ";
        str += " </tr> ";
        #endregion

        #region Footer
        str += " </table> ";
        str += " </td> ";
        str += " </tr> ";
        str += " </table> ";
        str += " </td> ";
        str += " </tr>";
        str += AddressBar();
        str += " </table> ";
        #endregion

        util.mail mail = new util.mail();
        //mail.To = "shankar@sscompusoft.co.in";
        mail.To = "snigglejpr@gmail.com";

        mail.Subject = msg;
        mail.Message = str;
        string ststus = mail.sendMailAdmin();
        adminData.InsMail("snigglejpr@gmail.com", "Custom Order", msg, ststus, "0");
    }

    public void EmailContactUs(string msg, string Name, string Email, string subject, string Message, string attachfile)
    {
        string str = "";
        #region  Header 
        str = " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
        str += " <tr>";
        str += " <td> ";
        str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
        str += " <tr> ";
        str += " <td style='border:1px solid #f4f5f7; border-radius:3px;'> ";
        str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

        str += "  <tr> ";
        str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
        str += " <a href='https://sniggle.in/' target='_blank'> ";
        str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
        str += "  </a>";
        str += " <td>";
        str += " </tr>";

        #endregion

        #region Content Region
        str += "  <tr> ";
        str += " <td> ";
        str += " <table width='98%' border='0' cellspacing='0' cellpadding='5' align='center'> ";


        str += " <tr> <td>&nbsp;</td> </tr>";
        str += " <tr> <td><h5  style='padding: 5px 0px; margin: 0px; font-size:18px;'>" + msg + "</h5></td></tr>";
        str += " <tr> <td> </td> </tr>";


        str += "  <tr> ";
        str += " <td align='center' style='border:1px solid #d6d4d5; background-color:#f8f8f8; color:#666;'> ";
        str += " <table width='100%' border='0' cellspacing='0' cellpadding='5'>";
        str += " <tr> <td> </td> </tr>";
        str += " <tr> <td><strong>Customer Name:</strong> " + Name + " </td> </tr>";
        str += " <tr> <td><strong>E-mail address:</strong> " + Email + " </td> </tr>";
        if (subject != "")
        {
            str += " <tr> <td><strong>Subject:</strong> " + subject + " </td> </tr>";
        }
        str += " <tr> <td><strong>Message:</strong> " + Message + " </td> </tr>";
        str += " <tr> <td>&nbsp;</td> </tr>";
        str += " <tr> <td>&nbsp;</td> </tr>";
        if (attachfile != "" && attachfile != null)
        {
            str += " <tr> <td><strong>Attached File : </strong> <a href='https://sniggle.in/img/ContactUs/" + attachfile + "' target='_blank'>View Attached File</a></td> </tr>";
        }
        str += " <tr> <td>&nbsp;</td> </tr>";
        str += " </table> ";
        str += " </td> ";
        str += " </tr> ";


        str += " <tr> <td></td> </tr>";
        str += " <tr> <td>&nbsp;</td> </tr>";
        str += " <tr> <td></td> </tr>";

        str += " </table> ";
        str += " </td> ";
        str += " </tr> ";
        #endregion

        #region Footer
        str += " </table> ";
        str += " </td> ";
        str += " </tr> ";
        str += " </table> ";
        str += " </td> ";
        str += " </tr>";
        str += AddressBar();
        str += " </table> ";
        #endregion

        util.mail mail = new util.mail();
        //mail.To = "shankar@sscompusoft.co.in";
        mail.To = "snigglejpr@gmail.com";

        mail.Subject = msg;
        mail.Message = str;
        string ststus = mail.sendMailAdmin();
        adminData.InsMail("snigglejpr@gmail.com", "Contact Us", msg, ststus, "0");
    }

    public void EmailReferAFriend(string CustName, string CustEmail,
       string img, string ProdId, string ProdName, string url, string EmailType = "product")
    {
        string str = "";
        str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
        str += " <tr> <td>";

        str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
        str += "  <tr> ";
        str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
        str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

        str += "  <tr> ";
        str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
        str += " <a href='https://sniggle.in/' target='_blank'> ";
        str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
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
        str += " <td>A friend has sent you a link to a " + EmailType + " that (s) he thinks may you interest in this " + EmailType + ".</td> ";
        str += " </tr> ";

        str += " <tr> ";
        str += "<td align='center'>";
        str += "<table width='90%' border='2px' cellspacing='0' cellpadding='5px' style='border:2px solid #333;'>";
        str += "<tr>";
        str += " <td width='40%'><a href='" + url + "' target='_blank'><img src='" + img + "'  style='width:250px; height:auto;' /></a></td>";
        str += " <td width='60%'><table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
        str += "<tr>";
        str += " <td align='center' style='font-size:18px; padding-bottom:20px;'>Click here to view this item.</td>";
        str += "  </tr>";
        str += "  <tr>";
        str += "  <td  align='center' style='font-size:18px; padding-top:20px;'><a href='" + url + "' target='_blank'>" + ProdName + "</a></td>";
        str += "  </tr>";
        str += "</table>";
        str += "</td>";
        str += " </tr>";
        str += " </table> ";
        str += " </td>";
        str += "</tr>";

        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

        str += "  <tr> ";
        str += " <td></td> ";
        str += " </tr> ";

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
        str += " <td align='center'><a href='#' target='_blank'><img src='https://sniggle.in/img/fb1.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/tw2.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/yt3.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/ld4.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/pt5.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/insta6.png' /></a></td> ";
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
        str += AddressBar();
        str += "  </table>";
        util.mail mail = new util.mail();
        mail.To = CustEmail;

        mail.Subject = "Sent you a "+ EmailType + " link of " + ProdName + "";
        mail.Message = str;
        string ststus = mail.sendMailAdmin();
        adminData.InsMail(CustEmail, "Contact Us", "Sent you a product link of " + ProdName + "", ststus, "0");
    }

    public void EmailCreativeCuts(string msg, string Name, string Email, string description, string attachfile, string prodname, string prodimg)
    {
        string str = "";
        #region  Header 
        str = " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
        str += " <tr>";
        str += " <td> ";
        str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
        str += " <tr> ";
        str += " <td style='border:1px solid #f4f5f7; border-radius:3px;'> ";
        str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

        str += "  <tr> ";
        str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
        str += " <a href='https://sniggle.in/' target='_blank'> ";
        str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
        str += "  </a>";
        str += " <td>";
        str += " </tr>";

        #endregion


        #region Product detail start
        str += "  <tr> ";
        str += " <td align='center'>";
        str += " <table width='98%' border='1' cellspacing='0' cellpadding='10' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'>";
        str += "<tr>";
        str += "<td>";
        str += " <p>";
        str += "<table width='100%' border='1' cellspacing='0' cellpadding='10' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;' align='center'>";

        str += "<tr>";
        str += "<td width='21%'><h6 style='padding: 5px 0px; margin: 0px; font-size: 16px;'>Product Image</h6></td>";
        str += "<td width='44%'><h6 style='padding: 5px 0px; margin: 0px; font-size: 16px;'>Product Name</h6></td>";
        str += " </tr>";

        str += "<tr>";
        str += "<td bgcolor='#FFFFFF'><a href='#' ><img src='https://sniggle.in/img/FancyShape/" + prodimg + "' width='auto' height='100px' /></a></td> ";
        str += "<td bgcolor='#FFFFFF'><a href='#' >" + prodname + "</a></td>";
        str += " </tr>";

        str += " </table>";
        str += " </p>";

        str += " <p><span> <strong>Customer Name:</strong> " + Name + " </span></p>";
        str += " <p><span> <strong>Email :</strong> <a href='mailto:" + Email + "' target='_blank'>" + Email + "</a></span></p>";
        str += " <p><strong>Description:</strong> " + description + "</p> ";

        if (attachfile != "" && attachfile != null)
        {
            str += " <p><strong>Attached File:</strong>  <a href='https://sniggle.in/img/creativecuts/" + attachfile + "' target='_blank'>View Attached File</a> </p> ";
        }
        str += " </td> ";
        str += "  </tr> ";
        str += "  </table> ";
        str += " </td> ";
        str += "  </tr> ";
        #endregion 

        #region Footer
        str += " </table> ";
        str += " </td> ";
        str += " </tr> ";
        str += " </table> ";
        str += " </td> ";
        str += " </tr>";
        str += AddressBar();
        str += " </table> ";
        #endregion

        util.mail mail = new util.mail();
        //mail.To = "snigglejpr@gmail.com";
        mail.To = "snigglejpr@gmail.com";

        mail.Subject = msg;
        mail.Message = str;
        string ststus = mail.sendMailAdmin();
        adminData.InsMail("snigglejpr@gmail.com", "Creative Cuts", msg, ststus, "0");
    }

    public string EmailOrderBankWire(string OrderID)
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
                string firstname = ds.Tables[0].Rows[0]["firstname"].ToString();
                string lastname = ds.Tables[0].Rows[0]["lastname"].ToString();
                string CustName = firstname + " " + lastname;
                string reference = ds.Tables[0].Rows[0]["reference"].ToString();

                string GTotal = ds.Tables[0].Rows[0]["OrderAmt"].ToString();

                string CustEmail = ds.Tables[0].Rows[0]["email"].ToString();

                str = " <table width='100%'  border= '0'; cellpadding='0' cellspacing='0' cellpadding='0'>";
                str += " <tr> <td>";

                str += " <table width='650' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                str += "  <tr> ";
                str += " <td style='border: 1px solid #f4f5f7; border-radius:3px;'> ";
                str += " <table width='650' border='0' cellspacing='0' cellpadding='0'> ";

                str += "  <tr> ";
                str += " <td bgcolor='#6CD1BB' style='padding:10px;'>";
                str += " <a href='https://sniggle.in/' target='_blank'> ";
                str += "  <img src='https://sniggle.in/img/new-store-logo.png' height='60px' width='auto' />";
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
                str += " <td>Thank you for shopping with Sniggle.</td> ";
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
                str += " <h4 style='font-size: 20px; padding: 5px 0px; margin: 0px; font-weight: bold;'> ORDER " + reference + " - AWAITING WIRE PAYMENT</h4> ";
                str += "<p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                str += " <p style='padding-bottom:2px;'> ";
                str += "  Your order with the reference " + reference + " has been place successfully and will be shipped as soon as we receive your payment.";
                str += " </p> ";
                str += "  </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += "  </td> ";
                str += "  </tr> ";
                #endregion

                #region Pay By Bank Wire Portion
                str += " <tr> ";
                str += " <td align='center'> ";
                str += " <table width='94%' border='1' cellspacing='0' cellpadding='5' style='border:1px solid #d6d4d5; border-collapse:collapse; background-color:#f8f8f8;'> ";
                str += " <tr> ";
                str += " <td> ";
                str += " <h4 style='font-size:20px; padding: 5px 0px; margin: 0px;'>YOU HAVE SELECTED TO PAY BY WIRE TRANSFER</h4> ";
                str += " <p style='margin:5px 2px;  background:#d5d5d5; height:1px;'></p> ";
                str += "  <p> ";
                str += "<span style='color:#666;'>Here are the bank details for your transfer:</span><br />";
                str += " <b>Amount:</b> <span style='color:#666;'>" + GTotal + "</span> <br /> ";
                str += " <b>Beneficiary Name:</b>  <span style='color:#666;'>Sniggle</span> <br />";
                str += " <b>Beneficiary Address: </b>  <span style='color:#666;'>Unit 16, 6/F, Focal industrial Centre Tower A, 21, Man Lok Street, Hung Hom, Kowloon, Hong Kong</span> <br />";
                str += "  <b>Bank Details:</b>  <br />";
                str += "&nbsp;&nbsp;<span style='color:#666;'> Bank : HSBC<br />";
                str += "&nbsp;&nbsp; Ac. No. : 817 423288 838<br />";
                str += " &nbsp;&nbsp; ABA: HSBCHKHHHKH </span><br />";
                str += " <b>Bank address:</b><span style='color: #666'> Cameron Road, TST, Kowloon Hong Kong</span>";
                str += " </p> ";
                str += " </td> ";
                str += "  </tr> ";
                str += " </table> ";
                str += " </td> ";
                str += " </tr> ";

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";
                #endregion

                str += "  <tr> ";
                str += " <td>&nbsp;</td> ";
                str += " </tr> ";
                str += "  <tr> ";
                str += "  <td align='center'> ";
                str += " <table width='94%' border='0' cellspacing='0' cellpadding='0'> ";
                str += " <tr> ";
                str += "  <td>You can review your order and download your invoice from the <a href='https://sniggle.in/order-history' target='_blank'>'Order history'</a> section of your customer account by clicking  <a href='https://sniggle.in/my-account' target='_blank'>'My account'</a> on our shop.</td> ";
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
                str += " <td align='center'><a href='#' target='_blank'><img src='https://sniggle.in/img/fb1.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/tw2.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/yt3.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/ld4.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/pt5.png' /></a> &nbsp; <a href='#' target='_blank'><img src='https://sniggle.in/img/insta6.png' /></a></td> ";
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
                str += AddressBar();
                str += "  </table>";
                //CustEmail = "gemsbead.jpr@gmail.com";
                //CustEmail = "snigglejpr@gmail.com";
                util.mail mail = new util.mail();
                mail.To = CustEmail;
                mail.Subject = "Awaiting bank wire payment at Sniggle!.";
                mail.Message = str;
                string ststus = mail.sendMailAdmin();
                adminData.InsMail(CustEmail, "Order Confirmation", "Awaiting bank wire payment at Sniggle!.", ststus, OrderID);
            }
            return str;
        }
    }

    public string AddressBar()
    {
        string str1 = "";
        str1 += "<tr>";
        str1 += "<td>";
        str1 += " <table width='680' border='0' cellspacing='0' cellpadding='0' align='center'> ";
        str1 += "  <tr> ";
        str1 += " <td><br /></td> ";
        str1 += " </tr> ";
        str1 += "  <tr> ";
        str1 += " <td><hr style='border-top:1px solid' /></td> ";
        str1 += " </tr> ";
        str1 += "  <tr> ";
        str1 += " <td><b>Sniggle</b></td>";
        str1 += " </tr> ";
        //str1 += "  <tr> ";
        //str1 += " <td>4828, Sotian Street, 3<sup>rd</sup> Crossing,</td> ";
        //str1 += " </tr> ";
        //str1 += "  <tr> ";
        //str1 += " <td>K.G.B. Ka Rasta, Johari Bazar</td> ";
        //str1 += " </tr> ";
        //str1 += "  <tr> ";
        //str1 += " <td>Jaipur-302003(INDIA)</td> ";
        //str1 += " </tr> ";
        //str1 += "  <tr> ";
        //str1 += " <td>Tel:+919983762207</td> ";
        //str1 += " </tr> ";
        str1 += "  <tr> ";
        str1 += " <td>Email:snigglejpr@gmail.com</td> ";
        str1 += " </tr> ";
        str1 += " <tr> ";
        str1 += " <td><br /></td> ";
        str1 += " </tr> ";
        str1 += " </table>";
        str1 += " </td>";
        str1 += "  </tr> "; 
        return str1;
    }
}
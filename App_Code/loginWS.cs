using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for loginWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class loginWS : System.Web.Services.WebService
{
    Data data = new Data();
    DataSet ds = new DataSet();
    GetData getData = new GetData();
    GData gdata = new GData();
    NData nData = new NData();
    EmailFormat EF = new EmailFormat();
    HttpCookie myCookie;
    string query = "";
    string CustId = "0";
    public loginWS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod(EnableSession = true)]
    public string CustomerLogin(string Email, string Pwd)
    {
        string str = "Success";
        ds = gdata.GetCustomerDtl(Email, Pwd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            HttpCookie customer = new HttpCookie("custSniggle");
            customer.Expires = DateTime.Now.AddDays(10d);
            customer.Values.Add("id_customer", ds.Tables[0].Rows[0]["id_customer"].ToString());
            customer.Values.Add("firstname", ds.Tables[0].Rows[0]["firstname"].ToString());
            customer.Values.Add("email", ds.Tables[0].Rows[0]["email"].ToString());
            customer.Values.Add("newsletter", ds.Tables[0].Rows[0]["newsletter"].ToString());
            customer.Values.Add("lastname", ds.Tables[0].Rows[0]["lastname"].ToString());
            HttpContext.Current.Response.Cookies.Add(customer);

            ds = gdata.GetWishListId(ds.Tables[0].Rows[0]["id_customer"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                HttpCookie wishList = new HttpCookie("wishlistSG");
                wishList.Expires = DateTime.Now.AddDays(30d);
                wishList.Values.Add("wishListID", ds.Tables[0].Rows[0]["id_wishlist"].ToString());
                HttpContext.Current.Response.Cookies.Add(wishList);
            }
        }
        else
        {
            ds = data.getDataSet("select * From ps_customer where active = 1 and IsPasswordUpdated = 0 and email = '" + Email + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                str = "ChangePwd";
            }
            else
            {
                str = "Not Exists";
            }
        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string CheckCustomer(string Email)
    {
        string str = "Not Exists";
        ds = gdata.CheckCustomer(Email);
        if (ds.Tables[0].Rows[0]["Sta"].ToString() == "Exists")
        {
            str = "Exists";
        }
        else
        {
            Session["CustEmail"] = Email;
        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string CustomerRegistration(string gender, string FName, string LName, string Email, string Pwd, string dob, string RecOff, string NewsL, string TC, string FNameA, string LNameA, string CompA, string AddA, string CounNameA, string CounValA, string StateNameA, string StateValA, string CityA, string PINA, string AddInfo, string HomePhone, string MobPhone, string alias)
    {
        string str = "Failed";
        ds = gdata.InsertCustomer(gender, FName, LName, Email, Pwd, dob, RecOff, NewsL, TC, FNameA, LNameA, CompA, AddA, CounNameA, CounValA, StateNameA, StateValA, CityA, PINA, AddInfo, HomePhone, MobPhone, alias);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string CustName = ds.Tables[0].Rows[0]["firstname"].ToString() + " " + ds.Tables[0].Rows[0]["lastname"].ToString();
            HttpCookie customer = new HttpCookie("custSniggle");
            customer.Expires = DateTime.Now.AddDays(10d);
            customer.Values.Add("id_customer", ds.Tables[0].Rows[0]["id_customer"].ToString());
            customer.Values.Add("firstname", ds.Tables[0].Rows[0]["firstname"].ToString());
            customer.Values.Add("email", ds.Tables[0].Rows[0]["email"].ToString());
            customer.Values.Add("newsletter", ds.Tables[0].Rows[0]["newsletter"].ToString());
            customer.Values.Add("lastname", ds.Tables[0].Rows[0]["lastname"].ToString());
            HttpContext.Current.Response.Cookies.Add(customer);
            str = "Success";

            //Email to customer
            EF.EmailRegistration(ds.Tables[0].Rows[0]["email"].ToString(), ds.Tables[0].Rows[0]["passwd"].ToString(), CustName);
        }
        return str;
    }


    [WebMethod(EnableSession = true)]
    public string RecoverPwd(string Email)
    {
        string str = "Not Exists";
        ds = gdata.CheckCustomer(Email);
        if (ds.Tables[0].Rows[0]["Sta"].ToString() == "Exists")
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                string id_customer = ds.Tables[1].Rows[0]["id_customer"].ToString();
                string firstname = ds.Tables[1].Rows[0]["firstname"].ToString();
                string lastname = ds.Tables[1].Rows[0]["lastname"].ToString();
                string EncryptPwd = gdata.Encrypt(id_customer);
                string Name = firstname + " " + lastname;
                string link = "https://sniggle.in/password-recovery.aspx?token=" + EncryptPwd;
                nData.SubmitPasswordRecoverDtl("0", id_customer);
                //Email to Customer
                EF.EmailForgotPassword(Name, link, Email);

                str = "Success";
            }
        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string UpdatePwd(string token, string NPwd)
    {
        string str = "Failed";
        string DID = gdata.Decrypt(token);
        ds = data.getDataSet("SELECT * from  ps_customer where id_customer = '" + DID + "' and (DATEDIFF(MINUTE, pwdUpdateDate, getdate()) < 30 and IsPasswordUpdated = 0)");
        if (ds.Tables[0].Rows.Count > 0)
        {
            int dd = gdata.UpdatePwd(DID, NPwd);
            if (dd == 1)
            {
                str = "Success";
            }
        }
        else
        {
            str = "Password link is expired. Please retrieve password again.";
        }

        return str;
    }

    [WebMethod(EnableSession = true)]
    public string ChangeYourPwd(string NPwd, string CurrentPwd)
    {
        string str = "Failed";
        string UserID = "0";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        int dd = gdata.ChangeYourPwd(UserID, CurrentPwd, NPwd);
        if (dd == 1)
        {
            str = "Success";
        }
        return str;
    }
    [WebMethod(EnableSession = true)]
    public string CustomerDtlUpdate(string gender, string FName, string LName, string Email, string dob, string RecOff, string NewsL)
    {
        string jsonstring = "Failed";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.CustomerDtlUpdate(CustId, gender, FName, LName, Email, dob, RecOff, NewsL);
            jsonstring = string.Empty;
            jsonstring = "Success";
        }
        return jsonstring;
    }
    [WebMethod(EnableSession = true)]
    public string GetCountryList()
    {
        ds = gdata.GetCountryList();
        return JsonConvert.SerializeObject(ds.Tables[0]);
    }

    [WebMethod(EnableSession = true)]
    public string GetStateList(string CID)
    {
        ds = gdata.GetStateList(CID);
        return JsonConvert.SerializeObject(ds.Tables[0]);
    }

    [WebMethod(EnableSession = true)]
    public string NewsletterSubmit(string Email)
    {
        string str = "Success";
        ds = data.getDataSet("Select * From ps_newsletter where email = '" + Email + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            str = "Email Exist";
            HttpCookie Newsletter = new HttpCookie("Newsletter");
            Newsletter.Expires = DateTime.Now.AddDays(30d);
            Newsletter.Values.Add("Email", Email);
            HttpContext.Current.Response.Cookies.Add(Newsletter);
        }
        else
        {
            query = "Insert Into ps_newsletter (id_shop, id_shop_group, email, newsletter_date_add, ip_registration_newsletter)";
            query += " Values (1, 1, '" + Email + "', '" + DateTime.Now + "', '') ";
            if (data.executeCommand(query) == 0)
            {
                str = "Success";
                HttpCookie Newsletter = new HttpCookie("Newsletter");
                Newsletter.Expires = DateTime.Now.AddDays(30d);
                Newsletter.Values.Add("Email", Email);
                HttpContext.Current.Response.Cookies.Add(Newsletter);
            }
            else
            {
                str = "Please try again";
            }
        }
        return str;
    }
    [WebMethod(EnableSession = true)]
    public string UpdatePwd111(string token111)
    {
        string str = "Failed";
        string DID = gdata.Decrypt(token111);
        ds = data.getDataSet("SELECT * from  ps_customer where id_customer = '" + DID + "' and (DATEDIFF(MINUTE, pwdUpdateDate, getdate()) < 30 and IsPasswordUpdated = 0)");
        if (ds.Tables[0].Rows.Count > 0)
        {
            str = "Active";
        }
        else
        {
            str = "Expired";
        }
        return str;
    }
}

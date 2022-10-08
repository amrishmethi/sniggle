using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CustomerService
/// </summary>
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class CustomerService : System.Web.Services.WebService
{
    Data data = new Data();
    DataSet ds = new DataSet();
    GData gdata = new GData();
    EmailFormat EF = new EmailFormat();
    HttpCookie myCookie;
    string query = "";
    string CustId = "0";
    public CustomerService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region Customer Order Detail Start

    [WebMethod(EnableSession = true)]
    public string GetCustomerOrder()
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetCustomerOrder(CustId);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetOrderDetailTbl0(string oid)
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetCustomerOrderDetail(oid);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetOrderDetailTbl1(string oid)
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetCustomerOrderDetail(oid);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[1]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetOrderDetailDelAdd(string oid)
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetCustomerOrderDetail(oid);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[2]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetOrderDetailInvAdd(string oid)
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetCustomerOrderDetail(oid);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[3]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetOrderDetailStatus(string oid)
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetCustomerOrderDetail(oid);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[4]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetOrderDetailTracking(string oid)
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetCustomerOrderDetail(oid);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[5]);
        }
        return jsonstring;
    }
    #endregion

    [WebMethod(EnableSession = true)]
    public string GetCustomerAddress()
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetCustomerAddress(CustId);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string deleteAddress(string addid)
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            if (addid != "")
            {
                string qq = "";
                qq = " Update ps_address set deleted = 1 where id_address = '" + addid + "'";
                data.executeCommand(qq);
            }

            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetCustomerAddress(CustId);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetPersonalInfo()
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetPersonalInfo(CustId);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetAddress()
    {
        GetData gdata = new GetData();
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            string addId = "";
            if (HttpContext.Current.Session["shipaddid"] != null && HttpContext.Current.Session["shipaddid"].ToString() != "0")
            {
                addId = HttpContext.Current.Session["shipaddid"].ToString();
            }
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.getAddress(CustId, addId);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetAddressDetail(string addId)
    {
        GetData gdata = new GetData();
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            if (addId != "0")
            {
                myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
                CustId = myCookie.Values["id_customer"].ToString();
                ds = gdata.getAddress(CustId, addId);
                jsonstring = string.Empty;
                jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
            }
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetAddressAlias(string addid, string alias)
    {
        GetData gdata = new GetData();
        string jsonstring = "NotExist";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetAddressAlias(CustId, alias, addid);
            jsonstring = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                jsonstring = "Exist";
            }

        }
        return jsonstring;
    }


    [WebMethod(EnableSession = true)]
    public string CustomerAddress(string addid, string FNameA, string LNameA, string CompA, string AddA, string CounNameA, string CounValA, string StateNameA, string StateValA, string CityA, string PINA, string AddInfo, string HomePhone, string MobPhone, string alias)
    {
        string IOSSNo = "";
        myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
        CustId = myCookie.Values["id_customer"].ToString();
        string str = "Failed";
        string query = "";
        Data data = new Data();
        if (addid == "0")
        {
            query = "insert into ps_address(id_country, id_state, id_customer, id_manufacturer, id_supplier, id_warehouse, alias, company, lastname, firstname, address1, address2, postcode, city, other, phone, phone_mobile, vat_number, dni, date_add, date_upd, active, deleted )";
            query += "values(" + CounValA + "," + StateValA + "," + CustId + ",0,0,0,'" + alias + "','" + CompA + "','" + LNameA + "','" + FNameA + "','" + AddA + "','" + DBNull.Value + "','" + PINA + "', '" + CityA + "','" + AddInfo + "','" + HomePhone + "','" + MobPhone + "','" + DBNull.Value + "','" + DBNull.Value + "','" + DateTime.Now + "','" + DateTime.Now + "',1,0 )";
        }
        else
        {
            query = "update ps_address set id_country=" + CounValA + ", id_state='" + StateValA + "', alias='" + alias + "', company='" + CompA + "', lastname='" + LNameA + "', firstname='" + FNameA + "', address1='" + AddA + "', postcode='" + PINA + "', city='" + CityA + "', other='" + AddInfo + "', phone='" + HomePhone + "', phone_mobile='" + MobPhone + "'  where id_address=" + addid + "";
        }
        if (data.executeCommand(query) == 0)
        {
            str = "Success";
            if (addid == "0")
            {
                ds = data.getDataSet("select top(1) * From ps_address where id_customer = " + CustId + " and active = 1 order by id_address desc");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HttpContext.Current.Session["shipaddid"] = ds.Tables[0].Rows[0]["id_address"].ToString();
                }
            }
            else
            {
                HttpContext.Current.Session["shipaddid"] = addid;
            }

        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string GetWishList()
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.GetWishList(CustId);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string RemoveFromWL(string ProdId)
    {
        string jsonstring = "";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            ds = gdata.RemoveFromWL(CustId, ProdId);
            jsonstring = string.Empty;
            jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        return jsonstring;
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
    public string SubmitContactUs(string Name, string Email, string Subject, string Message, string imgName)
    {
        string msg = "";
        string jsonstring = "Failed";
        ds = gdata.InsertContactUs(Name, Email, Subject, Message, imgName);
        jsonstring = string.Empty;
        if (ds.Tables[0].Rows.Count > 0)
        {
            msg = "Message received from contact us.";
            EF.EmailContactUs(msg, Name, Email, Subject, Message, imgName);
            string MaxiD = ds.Tables[0].Rows[0]["MaxId"].ToString();
            jsonstring = "Success_" + MaxiD;
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string SubmitCustomOrderForm(string Name, string Email, string ContactNo, string StoneName, string Description, string filename, string EntryType)
    {
        string msg = "";
        string jsonstring = "Failed";
        ds = gdata.InsertCustomOrderForm(Name, Email, ContactNo, StoneName, Description, filename, EntryType);
        jsonstring = string.Empty;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (EntryType != "")
            {
                if (EntryType == "Custom")
                {
                    msg = "Message received from custom order.";
                }
                else
                {
                    msg = "Message received from Request a Quote.";
                }
            }
            EF.EmailCustomOrder(msg, Name, Email, ContactNo, StoneName, Description, filename);
            string MaxiD = ds.Tables[0].Rows[0]["MAxId"].ToString();
            jsonstring = "Success_" + MaxiD;
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string submitBlogPost(string Name, string Email, string Comment, string BlogPostID)
    {
        string msg = "";
        string jsonstring = "Failed";
        ds = gdata.submitBlogPost(Name, Email, Comment, BlogPostID);
        jsonstring = string.Empty;
        if (ds.Tables[0].Rows.Count > 0)
        {
            //msg = "Message received from contact us.";
            //EF.EmailContactUs(msg, Name, Email, Subject, Message, imgName);
            string MaxiD = ds.Tables[0].Rows[0]["MaxId"].ToString();
            jsonstring = "Success_" + MaxiD;
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetCountryList()
    {
        ds = gdata.GetCountryList();
        string jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        return jsonstring;
    }
}

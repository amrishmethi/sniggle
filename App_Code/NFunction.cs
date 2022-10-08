using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;

/// <summary>
/// Summary description for NFunction
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class NFunction : System.Web.Services.WebService
{
    GData gdata = new GData();
    Data data = new Data();
    DataSet ds = new DataSet();
    NData nData = new NData();
    EmailFormat EF = new EmailFormat();
    public NFunction()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod(EnableSession = true)]
    public string getWSProdList(string AttID)
    {
        //DataSet ds = nData.getWSProdList(AttID.Split('=')[1]);
        DataSet ds = nData.getWSProdList(AttID, "");
        string jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds);
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string getAttributes(string AttID)
    {
        DataSet ds = nData.getMainGroupNew(AttID);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ds = nData.getAttribute(dt.Rows[i]["id_attribute_group"].ToString());
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                        jsonString.Append("\"Attri\":[");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            {
                                if (k == 0)
                                {
                                    jsonString.Append("{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\",\"coun\": \"" + ds.Tables[0].Rows[k]["coun"].ToString() + "\",\"isCheck\": \"false\"}");
                                }
                                else
                                {
                                    jsonString.Append(",{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\",\"coun\": \"" + ds.Tables[0].Rows[k]["coun"].ToString() + "\",\"isCheck\": \"false\"}");
                                }
                            }
                        }
                        jsonString.Append("]");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    jsonString.Append("}");
                }
                else
                {
                    jsonString.Append("},");
                }
            }
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }

    [WebMethod(EnableSession = true)]
    public string getFilterProducts(string AttID, string TypeID, string OrderBy)
    {
        DataSet ds = nData.getFilterProduct(AttID, TypeID, OrderBy);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getTestimonial()
    {
        ds = nData.getTestimonial();
        string jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string reorderProduct(string ProdId, string AttriID, string OrderDetailId)
    {
        string UserID = "0";
        string cartID = "0";
        string gustID = "0";
        if (HttpContext.Current.Request.Cookies["customer"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["customer"];
            UserID = user.Values["id_customer"].ToString();
        }
        if (HttpContext.Current.Request.Cookies["cart"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cart"];
            cartID = user.Values["cartID"].ToString();
        }
        else
        {
            gustID = data.getDataSet("select max(id_guest)+1 as maxid from ps_cart").Tables[0].Rows[0]["maxid"].ToString();
        }

        if (UserID == "0")
        {

        }
        if (cartID == "0")
        {
            string qqw = "insert into ps_cart(id_shop_group, id_shop, id_carrier, delivery_option, id_lang, id_address_delivery, id_address_invoice, id_currency, id_customer, id_guest, secure_key, recyclable, gift, gift_message, mobile_theme, allow_seperated_package, date_add, date_upd) values(1,1,0,'" + DBNull.Value + "',1,0,0,1," + UserID + "," + gustID + ",'" + DBNull.Value + "',0,0,'" + DBNull.Value + "',0,0,'" + DateTime.Now + "','" + DateTime.Now + "')";
            if (data.executeCommand(qqw) == 0)
            {
                cartID = data.getDataSet("select max(id_cart) as maxid from ps_cart").Tables[0].Rows[0]["maxid"].ToString();
                HttpCookie carts = new HttpCookie("cart");
                carts.Expires = DateTime.Now.AddDays(30d);
                carts.Values.Add("cartID", cartID);
                HttpContext.Current.Response.Cookies.Add(carts);
            }
        }
        string Status = nData.submitReorderProd(ProdId, AttriID, OrderDetailId, cartID);
        return Status;
    }

    [WebMethod]
    public string submitTestimonial(string name, string AdditionalInfo, string Email, string URL, string Content)
    {
        string action = "Add"; string ID = "0";
        string str = "Failed";
        int dd = nData.AddTestimonial(action, name, AdditionalInfo, URL, Email, Content, ID);
        if (dd == 0)
        {
            str = "Success";
        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string notifyReorder(string pRef, string pName, string pPrice, string pImg, string pDtlUrl, string pProdId, string cName, string Email)
    {
        string url = "#";
        string siteurl = ConfigurationManager.AppSettings["siteurl"].ToString();
        pDtlUrl = siteurl + pDtlUrl;
        url = siteurl + pImg;
        pImg = pImg.Replace(" ", "%20");
        string jsonstring = string.Empty;
        int dd = gdata.InsertProductEnquiry(cName, Email, "From Reorder", "",
         pImg, pPrice, pProdId, pName, pDtlUrl);
        if (dd == 1)
        {
            EF.EmailProductEnquiry(cName, Email, "Notification for reorder", "", pImg, pPrice, pProdId, pName, pDtlUrl);
            jsonstring = "Success";
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string UpdatePwd(string token)
    {
        string str = "Failed";
        string DID = gdata.Decrypt(token);
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
    [WebMethod(EnableSession = true)]
    public string SubmitBlogReferFriend(string CustName, string CustEmail, string img, string ProdId, string ProdName, string Url)
    { 
        string jsonstring = string.Empty;
        EF.EmailReferAFriend(CustName, CustEmail, img, ProdId, ProdName, Url, "blog");
        jsonstring = "Success";
        return jsonstring; 
    }
}

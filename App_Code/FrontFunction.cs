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
/// Summary description for FrontFunction
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class FrontFunction : System.Web.Services.WebService
{
    Data data = new Data();
    DataSet ds = new DataSet();
    GetData getData = new GetData();
    GData gdata = new GData();
    NData nData = new NData();
    EmailFormat EF = new EmailFormat();
    string query = "";
    public FrontFunction()
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
    public string DoNotShowAgain(string Status)
    {
        string str = "Success";
        if (Status == "true")
        {
            str = "Success";
            HttpCookie Newsletter = new HttpCookie("Newsletter");
            Newsletter.Expires = DateTime.Now.AddDays(5d);
            Newsletter.Values.Add("Email", Status);
            HttpContext.Current.Response.Cookies.Add(Newsletter);
        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string CustomerLogin(string Email, string Pwd)
    {
        string str = "Success";
        ds = gdata.GetCustomerDtl(Email, Pwd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            HttpCookie customer = new HttpCookie("customer");
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
                HttpCookie wishList = new HttpCookie("wishlist");
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
            HttpCookie customer = new HttpCookie("customer");
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
                string link = "https://myearthstone.com/password-recovery.aspx?token=" + EncryptPwd;
                nData.SubmitPasswordRecoverDtl("0", id_customer);
                //Email to Customer
                EF.EmailForgotPassword(Name, link, Email);

                str = "Success";
            }
        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string UpdatePwd(string NPwd, string token)
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
        if (HttpContext.Current.Request.Cookies["customer"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["customer"];
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
    public string GetCountryList()
    {
        ds = gdata.GetCountryList();
        string jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetStateList(string CID)
    {
        ds = gdata.GetStateList(CID);
        string jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        return jsonstring;
    }

    [WebMethod]
    public string GetSearchList(string CID, string Prod)
    {
        if (CID == "" || CID == "%")
        {
            CID = "%";
        }
        DataSet ds = new DataSet();
        GetData data = new GetData();
        DataTable dt = new DataTable();
        Data dat = new Data();
        dt.Columns.Add("ProductName", typeof(string));
        dt.Columns.Add("Url", typeof(string));
        List<string> customers = new List<string>();
        //ds = dat.getDataSet(" select distinct name from ps_product_lang as PL Inner Join ps_product as Prod on PL.id_product = Prod.id_product where active=1 order by name");
        ds = gdata.GetSearchList(CID, Prod);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dt.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dtrow = dt.NewRow();
                dtrow["ProductName"] = ds.Tables[0].Rows[i]["ShowName"].ToString();
                dtrow["Url"] = ds.Tables[0].Rows[i]["DetailUrl"].ToString();
                dt.Rows.Add(dtrow);
            }
        }
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getBlogDetail(string BlogId)
    {
        query = "update ps_smart_blog_post set viewed = (select (viewed + 1) from ps_smart_blog_post where id_smart_blog_post = '" + BlogId + "') where id_smart_blog_post = '" + BlogId + "' ";
        data.executeCommand(query);
        ds = gdata.GetBlogDetail(BlogId);
        string jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds);
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string getBlogList()
    {
        ds = gdata.GetBlogList();
        string jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string EnquiryAboutProduct(string CustName, string CustEmail, string Subject, string msg,
        string img, string price, string ProdId, string ProdName, string refNo)
    {
        string url = "#";
        string siteurl = ConfigurationManager.AppSettings["siteurl"].ToString();
        ds = nData.GetEnqAbtThisProdCombDtl(refNo.Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            url = ds.Tables[0].Rows[0]["fullDetailUrl"].ToString();
            img = "img/" + ds.Tables[0].Rows[0]["ProdImg"].ToString();
            price = ds.Tables[0].Rows[0]["FinalPrice"].ToString();
            ProdName = ProdName + " - " + ds.Tables[0].Rows[0]["pair"].ToString();
        }
        else
        {
            ds = gdata.GetProductUrl(ProdId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                url = siteurl + "img/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString();
            }
        }

        img = img.Replace(" ", "%20");
        string jsonstring = string.Empty;
        int dd = gdata.InsertProductEnquiry(CustName, CustEmail, Subject, msg,
         img, price, ProdId, ProdName, url);
        if (dd == 1)
        {
            EF.EmailProductEnquiry(CustName, CustEmail, Subject, msg,
         img, price, ProdId, ProdName, url);
            jsonstring = "Success";
        }
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string SubmitReferFriend(string CustName, string CustEmail, string img, string ProdId, string ProdName)
    {
        string url = "#";
        string siteurl = ConfigurationManager.AppSettings["siteurl"].ToString();
        ds = gdata.GetProductUrl(ProdId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            url = siteurl + ds.Tables[0].Rows[0]["DetailUrl"].ToString();
        }
        img = "https://myearthstone.com/" + img.Replace(" ", "%20");
        string jsonstring = string.Empty;
        EF.EmailReferAFriend(CustName, CustEmail, img, ProdId, ProdName, url);
        jsonstring = "Success";
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string getProductsSearch(string Slug, string OBY)
    {
        string[] dd = Slug.Split(',');
        string[] query1 = dd[0].Split('=');
        string[] query2 = dd[1].Split('=');
        string cat = query1[1];
        string keyw = query2[1];

        //DataSet ds = gdata.getProductsSearch(cat, keyw.Replace("+", " "), OBY); 
        //dt.Merge(ds.Tables[0]);
        DataTable dt = new DataTable();
        dt = getData.getProductsSearch(cat, keyw.Replace("+", " "), OBY);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getNewArrivalsProdForPage(string OBY)
    {
        string filter = "";
        if (OBY == "0")
        {
            filter = " tt.id_product desc";
        }
        else if (OBY == "AZ")
        {
            filter = " tt.ProdName  ";
        }
        else if (OBY == "ZA")
        {
            filter = " tt.ProdName desc ";
        }
        else if (OBY == "PL")
        {
            filter = "tt.DiscountPrice asc ";
        }
        else if (OBY == "PH")
        {
            filter = "tt.DiscountPrice desc ";
        }
        DataSet ds = gdata.getNewArrivalsProdForPage("", filter);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getBestSellingProdForPage(string OBY)
    {
        string filter = "";
        if (OBY == "0")
        {
            filter = " NEWID() ";
        }
        //if (OBY == "0")
        //{
        //    filter = " tt.id_product desc";
        //}
        else if (OBY == "AZ")
        {
            filter = " tt.ProdName  ";
        }
        else if (OBY == "ZA")
        {
            filter = " tt.ProdName desc ";
        }
        else if (OBY == "PL")
        {
            filter = "tt.DiscountPrice asc ";
        }
        else if (OBY == "PH")
        {
            filter = "tt.DiscountPrice desc ";
        }
        DataSet ds = gdata.getBestSellingProdForPage(filter);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getCreativeCutsProd(string OBY)
    {
        string filter = "";
        if (OBY == "0")
        {
            filter = " Prod.position";
        }
        else if (OBY == "AZ")
        {
            filter = " Prod.Title  ";
        }
        else if (OBY == "ZA")
        {
            filter = " Prod.Title desc ";
        }

        DataSet ds = gdata.getCreativeCutsProd(filter);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getCreativeCustModelDetail(string prodID)
    {
        Data dat = new Data();
        DataSet dsImg = gdata.getCCutsProd(prodID);
        string str = "";

        if (dsImg.Tables[0].Rows.Count > 0)
        {
            string prodURL = dsImg.Tables[0].Rows[0]["Url"].ToString();
            string img1 = dsImg.Tables[0].Rows[0]["Image1"].ToString();
            string img2 = dsImg.Tables[0].Rows[0]["Image2"].ToString();
            string img3 = dsImg.Tables[0].Rows[0]["Image3"].ToString();
            string img4 = dsImg.Tables[0].Rows[0]["Image4"].ToString();
            string img5 = dsImg.Tables[0].Rows[0]["Image5"].ToString();
            string Urlimg1 = dsImg.Tables[0].Rows[0]["UrlImage1"].ToString();
            string Urlimg2 = dsImg.Tables[0].Rows[0]["UrlImage2"].ToString();
            string Urlimg3 = dsImg.Tables[0].Rows[0]["UrlImage3"].ToString();
            string Urlimg4 = dsImg.Tables[0].Rows[0]["UrlImage4"].ToString();
            string Urlimg5 = dsImg.Tables[0].Rows[0]["UrlImage5"].ToString();
            string videoLink = dsImg.Tables[0].Rows[0]["VideoLink"].ToString();
            string prodName = dsImg.Tables[0].Rows[0]["prodTitle"].ToString();
            string ProdDesc = dsImg.Tables[0].Rows[0]["Description"].ToString();

            str = "<div class=\"row\">";
            //Image Model Div New Design 
            str += "<div class=\"col-md-6\">";
            str += "<div class=\"column\">";

            str += " <input type=\"hidden\" id=\"hddProdImgCC\" name=\"hddProdImgCC\" value=" + img1 + " />";
            str += "   <img id=\"featured\" src=\"" + Urlimg1 + "\" /> ";

            if (videoLink != "" && videoLink != null && videoLink != "no_image.jpg")
            {
                str += "<div class=\"mySlides\" style=\"display: none;\">";
                str += "<div class=\"video-responsive\">";
                str += "<iframe class=\"responsive-iframe\" style='width: 100%; height: 100%;' src='https://www.youtube.com/embed/" + videoLink + "' allowfullscreen></iframe>";
                str += "</div>";
                str += "</div>";
            }
            str += "<div id=\"slide-wrapper\">";
            //str += " <img id=\"slideLeft\" onclick=\"slideLeftmod();\" class=\"arrow\" src=\"img/arrow-left.png\" />";

            str += "<div id=\"slider\">";
            int imgpsition = 0;
            if (img1 != "" && img1 != null)
            {
                imgpsition = imgpsition + 1;
                str += "<img id=\"m" + imgpsition + "\" class=\"thumbnail2 active modClass\" src=\"" + Urlimg1 + "\" onmouseover=\"shankartest();\"   />";
            }
            if (img2 != "" && img2 != null && img2 != "no_image.jpg")
            {
                imgpsition = imgpsition + 1;
                str += "<img id=\"m" + imgpsition + "\" class=\"thumbnail2 active modClass\" src=\"" + Urlimg2 + "\" onmouseover=\"shankartest();\"   />";

            }
            if (img3 != "" && img3 != null && img3 != "no_image.jpg")
            {
                imgpsition = imgpsition + 1;
                str += "<img id=\"m" + imgpsition + "\" class=\"thumbnail2 active modClass\" src=\"" + Urlimg3 + "\" onmouseover=\"shankartest();\"   />";
            }
            if (img4 != "" && img4 != null && img4 != "no_image.jpg")
            {
                imgpsition = imgpsition + 1;
                str += "<img id=\"m" + imgpsition + "\" class=\"thumbnail2 active modClass\" src=\"" + Urlimg4 + "\" onmouseover=\"shankartest();\"   />";
            }
            if (img5 != "" && img5 != null && img5 != "no_image.jpg")
            {
                imgpsition = imgpsition + 1;
                str += "<img id=\"m" + imgpsition + "\" class=\"thumbnail2 active modClass\" src=\"" + Urlimg5 + "\" onmouseover=\"shankartest();\"   />";
            }
            if (videoLink != "" && videoLink != null && videoLink != "no_image.jpg")
            {
                imgpsition = imgpsition + 1;
                str += "<img id=\"m" + imgpsition + "\" class=\"thumbnail2video active modClass\" src=\"/img/YouTubeVideoLink.jpg\" onclick=\"quickViewImgPopupCreativeCut()\"  />";
            }
            str += "</div>";
            //str += " <img id=\"slideRight\" onclick=\"slideRightmod();\" class=\"arrow\" src=\"img/arrow-right.png\" />";
            str += "</div>";
            str += "</div>";
            str += "</div>";

            #region Form Start
            str += "<div class=\" col-md-6 \">";
            str += "<div class=\"content_info\">";
            str += "<h1 class='h1 namne_details' itemprop='name' id=\"hProductName\">" + prodName + "</h1>";
            str += "<p>" + ProdDesc + "</p>";
            str += "<div class=\"product-information\">";
            str += "<div class=\"product-actions pt-0\">";
            str += "<div class=\"add-to-cart-or-refresh\">";

            #region Form Fields
            str += "<div class=\"col-md-12 pl-0 mb-1\">";
            str += "<div class=\"clearfix\" style=\"margin-top:5px;\">";
            str += "<span class=\"control-label mb-0\">Name <sup class=\"required\">*</sup></span>";
            str += "<input class=\"form-control col-md-12 fieldReq1\" type=\"text\" id=\"txtCreativeCutsName\" name=\"txtCreativeCutsName\" >";
            str += "</div>";
            str += "</div>";

            str += "<div class=\"col-md-12 pl-0 mb-1\">";
            str += "<div class=\"clearfix\" style=\"margin-top:5px;\">";
            str += "<span class=\"control-label mb-0\">Email  <sup class=\"required\">*</sup></span>";
            str += "<input class=\"form-control col-md-12 fieldReq2\" type=\"text\" id=\"txtCreativeCutsEmail\" name=\"txtCreativeCutsEmail\"  >";
            str += "</div>";
            str += "</div>";

            str += "<div class=\"col-md-12 pl-0 mb-1\">";
            str += "<div class=\"clearfix\" style=\"margin-top:5px;\">";
            str += "<span class=\"control-label mb-0\">Description </span>";
            str += "<textarea class=\"form-control col-md-12\" id=\"txtCreativeCutsDescription\" name=\"txtCreativeCutsDescription\"></textarea>";
            str += "</div>";
            str += "</div>";

            str += "<div class=\"col-md-12 pl-0 mb-1\">";
            str += "<div class=\"clearfix\" style=\"margin-top:5px;\">";
            str += "<span class=\"control-label mb-0\">Upload File </span>";
            str += "<input type=\"file\" id=\"CreativeCutsfileToUpload\" name=\"CreativeCutsfileToUpload\" >";
            str += "</div>";
            str += "</div>";
            #endregion
            str += "<div class=\"product-additional-info\">";
            str += "<div class=\"product_comments_block_tab\">";
            str += "<p class=\"align_center\" style=\"padding-top:5px;\">";
            str += " <button type = \"button\" id =\"aCreativeCutsForm\" class=\"btn btn-secondary\" name=\"aCreativeCutsForm\"";
            str += " onclick=\"SubmitCreativeCutsForms();\">Submit</button>";
            //str += "<a id=\"aCreativeCutsForm\" class=\"btn btn-secondary\" name=\"aCreativeCutsForm\" onclick=\"SubmitCreativeCutsForms();\">Submit</a>";
            str += "</p>";
            str += "</div>";

            str += "</div>";
            #endregion

            str += "</div>";
            str += "</div>";
            str += "</div>";

            str += "</div>";
            str += "</div>";
        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string SubmitCreatinveCuts(string CustName, string CustEmail, string img, string description, string ProdName, string prodImg)
    {
        if (img != "" && img != null)
        {
            img = "Creattive_" + img;
        }

        string MaxiD = "0";
        string siteurl = ConfigurationManager.AppSettings["siteurl"].ToString();
        ds = gdata.InsertCreativeCutsEnquiry(CustName, CustEmail, img, description,
        ProdName);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string ddd = ds.Tables[0].Rows[0]["UploadFile"].ToString();
            MaxiD = ds.Tables[0].Rows[0]["ID"].ToString();
            if (ddd != null && ddd != "")
            {
                img = ddd.Replace(" ", "%20");
            }

            EF.EmailCreativeCuts("Message received from creative cuts.", CustName, CustEmail, description, img, ProdName, prodImg);
        }

        string jsonstring = string.Empty;
        jsonstring = "Success_" + MaxiD;
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string GetBlogCommentFront(string BlogId)
    {
        string jsonstring = "";
        ds = gdata.GetBlogCommentFront(BlogId);
        jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string getAttributeWS(string AttID)
    {
        ds = gdata.getAttributeWS(AttID);
        string jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds);
        return jsonstring;
    }
    [WebMethod(EnableSession = true)]
    public string getCategoryWS(string AttID)
    {
        ds = gdata.getCategoryWS(AttID);
        string jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds);
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string CustMsgOnPayment(string msg)
    {
        string cartID = "0";
        string str = "Not Exists";
        if (HttpContext.Current.Request.Cookies["cart"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cart"];
            cartID = user.Values["cartID"].ToString();
            gdata.CustMsgOnPayment(cartID, msg);
        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string getAttributes(string Slug)
    {
        //string[] aa = Slug.Split('/');
        //string catslug = aa[aa.Length - 1];
        //string[] bb = catslug.Split('-');
        //string catid = bb[0].ToString();
        DataSet ds = getData.getMainGroupNew();
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ds = getData.getAttribute(dt.Rows[i]["id_attribute_group"].ToString());
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
}

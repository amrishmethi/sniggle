<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    void Application_BeginRequest(object sender, EventArgs e)
    {
        string cmspage = "";
        string smartbolg = "";
        Data data = new Data();
        string strCustomPath;
        string url = Request.Url.AbsolutePath;
        string newurl = Request.Url.ToString();
        newurl = Request.Url.ToString();
        string[] path2 = newurl.Split('/');
        newurl = path2[path2.Length - 1];
        cmspage = path2[path2.Length - 2];
        smartbolg = path2[path2.Length - 3];
        string strCurrentPath = url;
        string qry = Request.Url.Query.ToString();
        string path = System.IO.Path.GetExtension(strCurrentPath);
        string path1 = System.IO.Path.GetFileNameWithoutExtension(strCurrentPath);
        HttpApplication app = sender as HttpApplication;

        string pagename = path1 + path;

        if (path1 != "fckeditor" && !newurl.Contains(".") && path1 != "Handler" && path1 != "uploadify" && path1 != "loader_frame" && path != "css")
        {
            if (path1 == "index" || path1 == "home")
            {
                strCustomPath = "~/index.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "search")
            {
                strCustomPath = "~/Search.aspx" + qry + "";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "Return-Policy")
            {
                strCustomPath = "~/Policy.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "Terms-Condition")
            {
                strCustomPath = "~/Terms.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "Privacy-Policy")
            {
                strCustomPath = "~/PrivacyPolicy.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "my-account")
            {
                strCustomPath = "~/dashboard.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "registration")
            {
                strCustomPath = "~/Registration.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "login")
            {
                strCustomPath = "~/login.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "Logout")
            {
                strCustomPath = "~/Logout.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "Shopping-Cart")
            {
                strCustomPath = "~/ShoppingCart.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "Check-Out")
            {
                strCustomPath = "~/CheckOut.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "Payment-Method")
            {
                strCustomPath = "~/Payment-Method.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "contact-us")
            {
                strCustomPath = "~/contactus.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "Add-Money")
            {
                strCustomPath = "~/AddMoney.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "Company-Profile")
            {
                strCustomPath = "~/AboutUs.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "Contact-Us")
            {
                strCustomPath = "~/ContactUs.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "MyAccount")
            {
                strCustomPath = "~/MyAccount.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "change-password")
            {
                strCustomPath = "~/ChangePassword.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "User-Address")
            {
                strCustomPath = "~/UserAddress.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "order-history")
            {
                strCustomPath = "~/OrderHistory.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "addresses")
            {
                strCustomPath = "~/addresses.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "identity")
            {
                strCustomPath = "~/identity.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "discount")
            {
                strCustomPath = "~/discount.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "mywishlist")
            {
                strCustomPath = "~/mywishlist.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "rfq")
            {
                strCustomPath = "~/rfq.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "password-recovery")
            {
                strCustomPath = "~/password-recovery.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "password-recovery")
            {
                strCustomPath = "~/password-recovery.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "credit-slip")
            {
                strCustomPath = "~/CreditSlip.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "new-products")
            {
                strCustomPath = "~/new-products.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "best-sales")
            {
                strCustomPath = "~/best-sales.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "creative-cuts")
            {
                strCustomPath = "~/creative-cuts.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "smartblog")
            {
                strCustomPath = "~/smartbloglist.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "testimonial")
            {
                strCustomPath = "~/testimonial.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (path1 == "61-gemstone-world")
            {
                strCustomPath = "~/websitesummery.aspx";
                app.Context.RewritePath(strCustomPath, true);
            }
            else if (cmspage == "gemstone-world")
            {
                string[] aa = path1.Split('-');
                strCustomPath = "~/ws-productlist.aspx?id=" + aa[0] + "";
                app.Context.RewritePath(strCustomPath, true);
            }
            else
            {
                if (cmspage == "content")
                {
                    strCustomPath = "~/CMSDetail.aspx?" + path1 + "";
                    app.Context.RewritePath(strCustomPath, true);
                }
                else
                {
                    if (path1.Contains("-"))
                    {
                        string[] aa = path1.Split('-');
                        //if (data.Exist("select PCL.name from ps_category_lang as PCL inner join ps_category as PC on PC.id_category = PCL.id_category  where PC.IsDeleted = 0 and PC.active = 1 and PCL.IsDeleted = 0 and PCL.id_category=" + aa[0] + ""))
                        if (data.Exist("select PCL.name from ps_category_lang as PCL inner join ps_category as PC on PC.id_category = PCL.id_category  where PC.IsDeleted = 0 and PC.active = 1 and PCL.IsDeleted = 0 and PCL.link_rewrite='" + path1 + "'"))
                        {
                            string qq = " SELECT * FROM ps_category a ";
                            qq += " LEFT JOIN ps_category_lang b ON (b.id_category = a.id_category AND b.id_lang = 1 AND b.id_shop = 1) ";
                            //qq += "  WHERE  a.IsDeleted=0 and b.IsDeleted=0 and id_parent = " + aa[0] + "	  and a.active = 1 ORDER BY a.position ASC ";
                            qq += "  WHERE  a.IsDeleted=0 and b.IsDeleted=0 and b.link_rewrite='" + path1 + "' and a.active = 1 ORDER BY a.position ASC ";
                            if (data.Exist(qq))
                            {
                                string st = CheckUrlExist(path1, "subcat");
                                if (st == "True")
                                {
                                    strCustomPath = "~/SubCategory.aspx?" + path1 + "";
                                    app.Context.RewritePath(strCustomPath, true);
                                }
                                else
                                {
                                    strCustomPath = "~/404.aspx";
                                    app.Context.RewritePath(strCustomPath, true);
                                }
                            }
                            else
                            {
                                string st = CheckUrlExist(path1, "prodlist");
                                if (st == "True")
                                {
                                    strCustomPath = "~/Products.aspx?" + path1 + "";
                                    app.Context.RewritePath(strCustomPath, true);
                                }
                                else
                                {
                                    strCustomPath = "~/404.aspx";
                                    app.Context.RewritePath(strCustomPath, true);
                                }
                            }
                        }
                        else
                        {
                            strCustomPath = "~/index.aspx";
                        }
                    }
                }
            }
        }
        else if (path1 == "search")
        {
            strCustomPath = "~/Search.aspx" + qry + "";
            app.Context.RewritePath(strCustomPath, true);
        }
        else if (path == ".html")
        {
            string[] aa = path1.Split('-');
            if (smartbolg == "smartblog")
            {
                strCustomPath = "~/smartblog.aspx?id=" + cmspage + "";
                app.Context.RewritePath(strCustomPath, true);
            }
            else
            {
                string st = CheckUrlDetailExist(path1, "subcat");
                if (st == "True")
                {
                    strCustomPath = "~/ProductDetail.aspx?" + aa[0] + "";
                    app.Context.RewritePath(strCustomPath, true);
                }
                else
                {
                    strCustomPath = "~/404.aspx";
                    app.Context.RewritePath(strCustomPath, true);
                }
            }
        }
    }

    public string CheckUrlExist(string Url, string from)
    {
        string status = "False";
        Data data = new Data();
        string qq = "Select * From ps_category as a inner join ps_category_lang as b on a.id_category = b.id_category ";
        qq += " where  b.id_lang = 1 ";
        //qq += " and   ISNULL(cast( a.id_category as nvarchar ),'') + '-' +  ISNULL(REPLACE(b.link_rewrite ,' ','-'),'')   = '" + Url + "'";
        qq += " and    ISNULL(REPLACE(b.link_rewrite ,' ','-'),'')   = '" + Url + "'";
        if (data.Exist(qq))
        {
            status = "True";
        }
        return status;
    }

    public string CheckUrlDetailExist(string Url, string from)
    {
        string url = Request.Url.AbsolutePath;
        Url =url.Replace(".html", "");
        string status = "False";
        Data data = new Data();
        NData nData = new NData();
        string dd = nData.checkUrlGlobal(url);
        if (dd != "True" && dd != "False")
        {
            Response.Redirect(dd);
        }
        string qq = " select  cast(prod.id_product as nvarchar(50))+'-'+   ISNULL(REPLACE(pl.link_rewrite ,' ','-'),'')  as DetailUrl from ps_product as prod ";
        qq += " inner  join ps_product_lang pl on prod.id_product = pl.id_product ";
        qq += " inner join ps_category_lang as cl on cl.id_category = prod.id_category_default ";
        qq += " where  prod.active = 1 and prod.IsDeleted = 0 and pl.id_lang = 1  and cl.id_lang = 1 ";
        qq += " and + '/' +  ISNULL(REPLACE(cl.link_rewrite ,' ','-'),'') + '/' + cast(prod.id_product as nvarchar(50))+'-'+   ISNULL(REPLACE(pl.link_rewrite ,' ','-'),'')    = '" + Url + "'";
        if (data.Exist(qq))
        {
            status = "True";
        }
        return status;
    }

</script>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Import Namespace="System.Data" %>
<script runat="server">
    Data data = new Data();
    GData gData = new GData();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public string siteurl;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region bind meta code    
            this.siteurl = ConfigurationManager.AppSettings["siteurl"].ToString();
            ds = data.getDataSet("select * From ps_cms_lang  where id_lang = 1 and id_cms = '36'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.Page.Title = ds.Tables[0].Rows[0]["meta_title"].ToString();
                HtmlMeta keywords = new HtmlMeta();
                keywords.Name = "keywords";
                keywords.Content = ds.Tables[0].Rows[0]["meta_keywords"].ToString();
                this.Page.Header.Controls.Add(keywords);
                Page.Header.Controls.Add(new LiteralControl("\n"));
                HtmlMeta keywords1 = new HtmlMeta();
                keywords1.Name = "description";
                string dss = ds.Tables[0].Rows[0]["meta_description"].ToString();
                keywords1.Content = dss;
                Page.Header.Controls.Add(new LiteralControl("\n"));
                this.Page.Header.Controls.Add(keywords1);
                HtmlLink canonical = new HtmlLink();
                canonical.Attributes.Add("rel", "canonical");
                canonical.Href = "https://singgle.in/";
                Header.Controls.Add(canonical);
            }
            #endregion
            BindBanner();
            if (Request.Browser.IsMobileDevice == true)
            {
                HBM("Mobile");
                FillLatest("M");
                FillNewArrivals("M");
            }
            else
            {
                HBM("Website");
                FillLatest("D");
                FillNewArrivals("D");
            }
            FillCustomerReview();
        }
    }
    public void HBM(string B_For)
    {
        ds = gData.getBannerDetail("Home Banner 1", B_For);
        if (B_For == "Website")
        {
            rptBanner.DataSource = ds;
            rptBanner.DataBind();
        }
        else
        {
            rptBannerM.DataSource = ds;
            rptBannerM.DataBind();
        }
    }
    public void BindBanner()
    {
        //ds = gData.getBannerDetail("Home Banner 1");
        //rptBanner.DataSource = ds;
        //rptBanner.DataBind();

        ds = gData.getBannerDetail("Home Banner 2");
        rptBanner2.DataSource = ds;
        rptBanner2.DataBind();

        dt = gData.getBannerDetail4("Home Banner 4");
        rptBanner3.DataSource = dt;
        rptBanner3.DataBind();

        //dt = GetData.getBannerDetail4("Home Banner 4");
        //rptBanner4.DataSource = dt;
        //rptBanner4.DataBind(); 

        //ds = GetData.getBannerDetail("HotDeals");
        //rptHotDeals.DataSource = ds;
        //rptHotDeals.DataBind();
    }
    public void FillLatest(string device)
    {
        dt = gData.getNewArrivals("Latest", "0");
        rptNewArrivals.DataSource = dt;
        rptNewArrivals.DataBind();
    }
    public void FillNewArrivals(string device)
    {
        ds = gData.getNewArrivalsHead("NewA", "null");
        rptNewHead.DataSource = ds.Tables[0];
        rptNewHead.DataBind();
        int totProd = device == "M" ? 4 : 12;
        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = gData.getNewArrivals("NewA", ds.Tables[0].Rows[0]["id_category"].ToString());
            rptNew1.DataSource = dt;
            rptNew1.DataBind();
        }
        if (ds.Tables[0].Rows.Count > 1)
        {
            dt = gData.getNewArrivals("NewA", ds.Tables[0].Rows[1]["id_category"].ToString());
            rptNew2.DataSource = dt;
            rptNew2.DataBind();
        }
        if (ds.Tables[0].Rows.Count > 2)
        {
            dt = gData.getNewArrivals("NewA", ds.Tables[0].Rows[2]["id_category"].ToString());
            rptNew3.DataSource = dt;
            rptNew3.DataBind();
        }
    }
    public void FillCustomerReview()
    {
        dt = gData.getCustomerReview(6);
        if (dt.Rows.Count > 0)
        {
            divCustReview.Visible = true;
            rptCustomerReview.DataSource = dt;
            rptCustomerReview.DataBind();
        }
        else
        {
            divCustReview.Visible = false;
        }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- Start Hero Slider Section-->
    <div class="hero-slider-section d-xs-none">
        <!-- Slider main container -->
        <div class="hero-slider-active swiper-container">
            <!-- Additional required wrapper -->
            <div class="swiper-wrapper">
                <!-- Start Hero Single Slider Item -->
                <asp:Repeater ID="rptBanner" runat="server">
                    <ItemTemplate>
                        <div class="hero-single-slider-item swiper-slide">
                            <div class="hero-slider-bg">
                                <a href="<%#Eval("UrlLink") %>" target="<%#Eval("LinkOpen") %>" title="slide show1">
                                    <img src='<%# Eval("imgBanner").ToString() %>' alt="<%#Eval("Title") %>" />
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- End Hero Single Slider Item -->
            </div>
            <!-- If we need pagination -->
            <div class="swiper-pagination active-color-aqua"></div>

            <!-- If we need navigation buttons -->
            <div class="swiper-button-prev d-none d-lg-block"></div>
            <div class="swiper-button-next d-none d-lg-block"></div>
        </div>
    </div>
    <!-- End Hero Slider Section-->
    <!-- Start Hero Slider Section-->
    <div class="hero-slider-section d-lg-block d-xl-none ">
        <!-- Slider main container -->
        <div class="hero-slider-active swiper-container">
            <!-- Additional required wrapper -->
            <div class="swiper-wrapper">
                <asp:Repeater ID="rptBannerM" runat="server">
                    <ItemTemplate>
                        <div class="hero-single-slider-item swiper-slide">
                            <div class="hero-slider-bg">
                                <a href="<%#Eval("UrlLink") %>" target="<%#Eval("LinkOpen") %>" title="slide show1">
                                    <img src='<%# Eval("imgBanner").ToString() %>' alt="<%#Eval("Title") %>" class="img-responsive" width="100%" height="auto" />
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <!-- If we need pagination -->
            <div class="swiper-pagination active-color-aqua"></div>
            <!-- If we need navigation buttons -->
            <div class="swiper-button-prev d-none d-lg-block"></div>
            <div class="swiper-button-next d-none d-lg-block"></div>
        </div>
    </div>
    <!-- End Hero Slider Section-->
    <!-- Start Banner Section -->
    <div class="banner-section section-top-gap-100 section-fluid">
        <div class="banner-wrapper">
            <div class="container">
                <div class="row mb-n6">
                    <asp:Repeater ID="rptBanner2" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 col-12 mb-6">
                                <!-- Start Banner Single Item -->
                                <div class="banner-single-item banner-style-5 img-responsive" data-aos="fade-up"
                                    data-aos-delay="0">
                                    <a href="<%#Eval("UrlLink") %>" target="<%#Eval("LinkOpen") %>" title="slide show1" class="image banner-animation">
                                        <img src='<%# Eval("imgBanner").ToString() %>' alt="<%#Eval("Title") %>" />
                                    </a>
                                </div>
                                <!-- End Banner Single Item -->
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <!-- End Banner Section -->
    <!-- Start Product Default Slider Section -->
    <div class="product-default-slider-section section-top-gap-100 section-fluid">
        <!-- Start Section Content Text Area -->
        <div class="section-title-wrapper" data-aos="fade-up" data-aos-delay="0">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="section-content-gap">
                            <div class="secton-content">
                                <h3 class="section-title">New arrivals</h3>
                                <p>Preorder now to receive exclusive deals & gifts</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Start Section Content Text Area -->
        <div class="product-wrapper" data-aos="fade-up" data-aos-delay="200">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="product-slider-default-2rows default-slider-nav-arrow">
                            <!-- Slider main container -->
                            <div class="swiper-container product-default-slider-4grid-2row">
                                <div class="swiper-wrapper">
                                    <asp:Repeater ID="rptNewArrivals" runat="server">
                                        <ItemTemplate>
                                            <!-- Start Product Default Single Item -->
                                            <div class="product-default-single-item product-color--aqua swiper-slide">
                                                <div class="image-box">
                                                    <a href='<%#Eval("DetailUrl") %>' class="image-link">
                                                        <img src='<%#Eval("URL") %>' alt='<%#Eval("ImgCaption") %>' title='<%#Eval("ImgCaption") %>' />
                                                        <img src='<%#Eval("imgSecond") %>' alt='<%#Eval("imgSecondCaption") %>' title='<%#Eval("imgSecondCaption") %>' />
                                                    </a>
                                                    <div class="tag <%#Eval("pDis") %>">
                                                        <span><%#Eval("Discount") %>% Off</span>
                                                    </div>
                                                    <div class="action-link">
                                                        <div class="action-link-left">
                                                            <%--<a href="#" data-bs-toggle="modal"
                                                                        data-bs-target="#modalAddcart" onclick="addProdDetail(<%#Eval("ProdID") %>);">Add to Cart</a>--%>
                                                            <a href='<%#Eval("DetailUrl") %>'>Add to Cart</a>
                                                        </div>
                                                        <div class="action-link-right">
                                                            <a href="javaScript:void(0);" onclick="addWishList('<%#Eval("ProdID") %>');"><i class="icon-heart"></i></a>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="content">
                                                    <div class="content-left">
                                                        <h6 class="title"><a href='<%#Eval("DetailUrl") %>'><%#Eval("ProdName") %></a></h6>
                                                        <%-- <ul class="review-star">
                                                            <%# gData.BindStar(Eval("Rating").ToString()) %>
                                                        </ul>--%>
                                                    </div>
                                                    <div class="content-right">
                                                        <del class="<%#Eval("pDis") %>">₹ <%#Eval("ProdPrice") %></del>
                                                        <span class="price font-weight-bolder">₹ <%#Eval("DiscountPrice") %></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- End Product Default Single Item -->
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <!-- If we need navigation buttons -->
                            <div class="swiper-button-prev"></div>
                            <div class="swiper-button-next"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End Product Default Slider Section -->

    <!-- Start Banner Section -->
    <div class="banner-section section-top-gap-100">
        <div class="banner-wrapper">
            <div class="container-fluid">
                <div class="row mb-n6">
                    <asp:Repeater ID="rptBanner3" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 col-12 mb-6">
                                <!-- Start Banner Single Item -->
                                <a href='<%#Eval("UrlLink") %>' target="<%#Eval("LinkOpen1") %>">
                                    <div class="banner-single-item banner-style-11  img-responsive"
                                        data-aos="fade-up" data-aos-delay="0">
                                        <div class="image">
                                            <a href='<%#Eval("UrlLink") %>' target="<%#Eval("LinkOpen1") %>">
                                                <img src='<%# Eval("imgBanner").ToString() %>' alt='' />
                                            </a>
                                        </div>
                                    </div>
                                </a>
                                <!-- End Banner Single Item -->
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <!-- End Banner Section -->

    <!-- Start Product Default Tab Slider Section -->
    <div class="product-default-tab-slider-section section-top-gap-100 section-fluid">
        <!-- Start Section Content Text Area -->
        <div class="section-title-wrapper" data-aos="fade-up" data-aos-delay="0">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="section-content-gap">
                            <ul class="tablist-default tablist nav">
                                <asp:Repeater ID="rptNewHead" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a class="nav-link tablinks bb" data-bs-toggle="tab" href='<%# "#" +Eval("rptNo") %>' onclick="rptActive(event, '<%#Eval("rptNo") %>')"><%#Eval("name") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Start Section Content Text Area -->
        <div class="product-wrapper" data-aos="fade-up" data-aos-delay="200">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="tab-content">
                            <!-- Start Tab Item Single Item -->
                            <div class="tab-pane tabcontent" id="divNew1">
                                <div class="product-slider-default-1row default-slider-nav-arrow">
                                    <!-- Slider main container -->
                                    <div class="swiper-container product-default-slider-4grid-1row">
                                        <!-- Additional required wrapper -->
                                        <div class="swiper-wrapper">
                                            <asp:Repeater ID="rptNew1" runat="server">
                                                <ItemTemplate>
                                                    <!-- Start Product Default Single Item -->
                                                    <div class="product-default-single-item product-color--aqua swiper-slide">
                                                        <div class="image-box">
                                                            <a href='<%#Eval("DetailUrl") %>' class="image-link">
                                                                <img src='<%#Eval("URL") %>' alt='<%#Eval("ImgCaption") %>' title='<%#Eval("ImgCaption") %>' />
                                                                <img src='<%#Eval("imgSecond") %>' alt='<%#Eval("imgSecondCaption") %>' title='<%#Eval("imgSecondCaption") %>' />
                                                            </a>
                                                            <div class="tag <%#Eval("pDis") %>">
                                                                <span><%#Eval("Discount") %>% Off</span>
                                                            </div>
                                                            <div class="action-link">
                                                                <div class="action-link-left">
                                                                    <%--<a href="#" data-bs-toggle="modal"
                                                                        data-bs-target="#modalAddcart" onclick="addProdDetail(<%#Eval("ProdID") %>);">Add to Cart</a>--%>
                                                                    <a href='<%#Eval("DetailUrl") %>'>Add to Cart</a>
                                                                </div>
                                                                <div class="action-link-right">
                                                                    <a href="javaScript:void(0);" onclick="addWishList('<%#Eval("ProdID") %>');"><i class="icon-heart"></i></a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="content">
                                                            <div class="content-left">
                                                                <h6 class="title"><a href='<%#Eval("DetailUrl") %>'><%#Eval("ProdName") %></a></h6>
                                                                <%-- <ul class="review-star">
                                                                    <%# gData.BindStar(Eval("Rating").ToString()) %>
                                                                </ul>--%>
                                                            </div>
                                                            <div class="content-right">
                                                                <del class="<%#Eval("pDis") %>">₹ <%#Eval("ProdPrice") %></del>
                                                                <span class="price font-weight-bolder">₹ <%#Eval("DiscountPrice") %></span>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <!-- End Product Default Single Item -->
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <!-- If we need navigation buttons -->
                                    <div class="swiper-button-prev"></div>
                                    <div class="swiper-button-next"></div>
                                </div>
                            </div>
                            <!-- End Tab Item Single Item -->
                            <!-- Start Tab Item Single Item -->
                            <div class="tab-pane tabcontent active show" id="divNew2">
                                <div class="product-slider-default-1row default-slider-nav-arrow">
                                    <!-- Slider main container -->
                                    <div class="swiper-container product-default-slider-4grid-1row">
                                        <!-- Additional required wrapper -->
                                        <div class="swiper-wrapper">
                                            <asp:Repeater ID="rptNew2" runat="server">
                                                <ItemTemplate>
                                                    <!-- Start Product Default Single Item -->
                                                    <div class="product-default-single-item product-color--aqua swiper-slide">
                                                        <div class="image-box">
                                                            <a href='<%#Eval("DetailUrl") %>' class="image-link">
                                                                <img src='<%#Eval("URL") %>' alt='<%#Eval("ImgCaption") %>' title='<%#Eval("ImgCaption") %>' />
                                                                <img src='<%#Eval("imgSecond") %>' alt='<%#Eval("imgSecondCaption") %>' title='<%#Eval("imgSecondCaption") %>' />
                                                            </a>
                                                            <div class="tag <%#Eval("pDis") %>">
                                                                <span><%#Eval("Discount") %>% Off</span>
                                                            </div>
                                                            <div class="action-link">
                                                                <div class="action-link-left">
                                                                    <%--<a href="#" data-bs-toggle="modal"
                                                                        data-bs-target="#modalAddcart" onclick="addProdDetail(<%#Eval("ProdID") %>);">Add to Cart</a>--%>
                                                                    <a href='<%#Eval("DetailUrl") %>'>Add to Cart</a>
                                                                </div>
                                                                <div class="action-link-right">
                                                                    <a href="javaScript:void(0);" onclick="addWishList('<%#Eval("ProdID") %>');"><i class="icon-heart"></i></a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="content">
                                                            <div class="content-left">
                                                                <h6 class="title"><a href='<%#Eval("DetailUrl") %>'><%#Eval("ProdName") %></a></h6>
                                                                <%--<ul class="review-star">
                                                                    <%# gData.BindStar(Eval("Rating").ToString()) %>
                                                                </ul>--%>
                                                            </div>
                                                            <div class="content-right">
                                                                <del class="<%#Eval("pDis") %>">₹ <%#Eval("ProdPrice") %></del><br />
                                                                <span class="price">₹ <%#Eval("DiscountPrice") %></span>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <!-- End Product Default Single Item -->
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <!-- If we need navigation buttons -->
                                    <div class="swiper-button-prev"></div>
                                    <div class="swiper-button-next"></div>
                                </div>
                            </div>
                            <!-- End Tab Item Single Item -->
                            <!-- Start Tab Item Single Item -->
                            <div class="tab-pane tabcontent active show" id="divNew3">
                                <div class="product-slider-default-1row default-slider-nav-arrow">
                                    <!-- Slider main container -->
                                    <div class="swiper-container product-default-slider-4grid-1row">
                                        <!-- Additional required wrapper -->
                                        <div class="swiper-wrapper">
                                            <asp:Repeater ID="rptNew3" runat="server">
                                                <ItemTemplate>
                                                    <!-- Start Product Default Single Item -->
                                                    <div class="product-default-single-item product-color--aqua swiper-slide">
                                                        <div class="image-box">
                                                            <a href='<%#Eval("DetailUrl") %>' class="image-link">
                                                                <img src='<%#Eval("URL") %>' alt='<%#Eval("ImgCaption") %>' title='<%#Eval("ImgCaption") %>' />
                                                                <img src='<%#Eval("imgSecond") %>' alt='<%#Eval("imgSecondCaption") %>' title='<%#Eval("imgSecondCaption") %>' />
                                                            </a>
                                                            <div class="tag <%#Eval("pDis") %>">
                                                                <span><%#Eval("Discount") %>% Off</span>
                                                            </div>
                                                            <div class="action-link">
                                                                <div class="action-link-left">
                                                                    <%--<a href="#" data-bs-toggle="modal"
                                                                        data-bs-target="#modalAddcart" onclick="addProdDetail(<%#Eval("ProdID") %>);">Add to Cart</a>--%>
                                                                    <a href='<%#Eval("DetailUrl") %>'>Add to Cart</a>
                                                                </div>
                                                                <div class="action-link-right">
                                                                    <a href="javaScript:void(0);" onclick="addWishList('<%#Eval("ProdID") %>');"><i class="icon-heart"></i></a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="content">
                                                            <div class="content-left">
                                                                <h6 class="title"><a href='<%#Eval("DetailUrl") %>'><%#Eval("ProdName") %></a></h6>
                                                                <%--<ul class="review-star">
                                                                    <%# gData.BindStar(Eval("Rating").ToString()) %>
                                                                </ul>--%>
                                                            </div>
                                                            <div class="content-right">
                                                                <del class="<%#Eval("pDis") %>">₹ <%#Eval("ProdPrice") %></del><br />
                                                                <span class="price">₹ <%#Eval("DiscountPrice") %></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- End Product Default Single Item -->
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <!-- If we need navigation buttons -->
                                    <div class="swiper-button-prev"></div>
                                    <div class="swiper-button-next"></div>
                                </div>
                            </div>
                            <!-- End Tab Item Single Item -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End Product Default Tab Slider Section -->
    <!-- Start Blog Slider Section -->
    <div class="blog-default-slider-section pt-10 pb-5 section-fluid  bg-light" id="divCustReview" runat="server">
        <!-- Start Section Content Text Area -->
        <div class="section-title-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="section-content-gap">
                            <div class="secton-content">
                                <h3 class="section-title  text-center">Customer Stories and Reviews</h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Start Section Content Text Area -->
        <div class="blog-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="blog-default-slider default-slider-nav-arrow">
                            <!-- Slider main container -->
                            <div class="swiper-container blog-slider">
                                <!-- Additional required wrapper -->
                                <div class="swiper-wrapper">
                                    <!-- Start Product Default Single Item -->
                                    <asp:Repeater ID="rptCustomerReview" runat="server">
                                        <ItemTemplate>
                                            <div class="blog-default-single-item blog-color--golden swiper-slide testimonial">
                                                <div class="content">
                                                    <ul class="review-star">
                                                        <%# gData.BindStar(Eval("grade").ToString()) %>
                                                    </ul>
                                                </div>

                                                <div class="image-box">
                                                    <a href='<%#Eval("DetailUrl") %>' class="image-link">
                                                        <img class="img-fluid" src='<%#Eval("Url") %>' />
                                                    </a>
                                                </div>
                                                <div class="content">
                                                    <h6 class="title"><a href='<%#Eval("DetailUrl") %>'><%#Eval("customer_name") %></a> </h6>
                                                    <p>
                                                        <%#Eval("content") %>
                                                    </p>
                                                    <div class="inner mt-0">
                                                        <a>&nbsp;</a>
                                                        <div class="post-meta">
                                                            <a href='<%#Eval("DetailUrl") %>' class="date"><%#Eval("addDate") %></a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <!-- End Product Default Single Item -->
                                </div>
                            </div>
                            <!-- If we need navigation buttons -->
                            <div class="swiper-button-prev"></div>
                            <div class="swiper-button-next"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End Blog Slider Section -->
    <!-- Start Service Section -->
    <div class="service-promo-section section-top-gap-100">
        <div class="service-wrapper">
            <div class="container">
                <div class="row">
                    <!-- Start Service Promo Single Item -->
                    <div class="col-lg-3 col-sm-6 col-12">
                        <div class="service-promo-single-item" data-aos="fade-up" data-aos-delay="0">
                            <div class="image">
                                <img src="assets/images/icons/service-promo-5.png" alt="">
                            </div>
                            <div class="content">
                                <h6 class="title">FREE SHIPPING</h6>
                                <p>Get Free Shipping on orders above Rs. 500.</p>
                            </div>
                        </div>
                    </div>
                    <!-- End Service Promo Single Item -->
                    <!-- Start Service Promo Single Item -->
                    <div class="col-lg-3 col-sm-6 col-12">
                        <div class="service-promo-single-item" data-aos="fade-up" data-aos-delay="200">
                            <div class="image">
                                <img src="assets/images/icons/service-promo-6.png" alt="">
                            </div>
                            <div class="content">
                                <h6 class="title">100% SATISFACTION</h6>
                                <p>100% satisfaction guaranteed.</p>
                            </div>
                        </div>
                    </div>
                    <!-- End Service Promo Single Item -->
                    <!-- Start Service Promo Single Item -->
                    <div class="col-lg-3 col-sm-6 col-12">
                        <div class="service-promo-single-item" data-aos="fade-up" data-aos-delay="400">
                            <div class="image">
                                <img src="assets/images/icons/service-promo-7.png" alt="">
                            </div>
                            <div class="content">
                                <h6 class="title">SAFE PAYMENT</h6>
                                <p>Pay with the world’s most popular and secure payment methods.</p>
                            </div>
                        </div>
                    </div>
                    <!-- End Service Promo Single Item -->
                    <!-- Start Service Promo Single Item -->
                    <div class="col-lg-3 col-sm-6 col-12">
                        <div class="service-promo-single-item" data-aos="fade-up" data-aos-delay="600">
                            <div class="image">
                                <img src="assets/images/icons/custom-desing.png" alt="">
                            </div>
                            <div class="content">
                               <h6 class="title">CUSTOMIZE</h6>
                                <p>Customize t-shirts/accessories and more based on your personal choices!</p>
                            </div>
                        </div>
                    </div>
                    <!-- End Service Promo Single Item -->
                </div>
            </div>
        </div>
    </div>
    <!-- End Service Section -->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script defer src="appjs/index.js"></script>
</asp:Content>


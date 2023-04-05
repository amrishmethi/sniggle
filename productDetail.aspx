<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>



<%@ Import Namespace="System.Data" %>
<script runat="server">
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    Data dta = new Data();
    GetData data = new GetData();
    GData gdata = new GData();
    public int coun = 10;
    public string siteurl;
    public string produrl;
    public string caturl;
    public string productname;
    public string catname;
    public string sizedescription;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.siteurl = ConfigurationManager.AppSettings["siteurl"].ToString();
            BindProductDetail();
            FillSmallImg();
        }
    }

    public void BindProductDetail()
    {
        string proIdd = Request.QueryString[0].ToString();
        string ss = data.BindProductHtml(proIdd);
        divProductHtml.InnerHtml = ss;
        data.ProdViewdCookies(proIdd);
    }

    public void FillSmallImg()
    {
        string catid = Request.QueryString[0].ToString();
        string proIdd = Request.QueryString[0].ToString();
        lblProdId.Text = proIdd;
        lblProdIdDtailPage.Text = proIdd;

        ds = data.getItemImagesList(catid);
        rptImgThumb.DataSource = ds;
        rptImgThumb.DataBind();

        ds = data.getSizeChart(catid);
        if (ds.Tables[0].Rows.Count > 0)
            sizedescription = ds.Tables[0].Rows[0]["Description"].ToString();

        ds = data.getItemImages(catid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            productname = ds.Tables[0].Rows[0]["ProdName"].ToString();
            catname = ds.Tables[0].Rows[0]["CatName"].ToString();
            produrl = ds.Tables[0].Rows[0]["DetailUrl"].ToString();
            caturl = "/" + ds.Tables[0].Rows[0]["CatURL"].ToString();
            catlinkb.HRef = caturl;
            catnameb.InnerText = catname;
            prodlinkb.HRef = "/" + produrl;
            prodnameb.InnerText = productname;
            lblImgDtailPage.Text = ds.Tables[0].Rows[0]["bigimg"].ToString();
            //imgReview.Src = ds.Tables[0].Rows[0]["bigimg"].ToString();
            lblBigImg.Text = ds.Tables[0].Rows[0]["bigimg"].ToString();

            if (ds.Tables[0].Rows[0]["available_nowTag"].ToString().ToUpper() == "OUT OF STOCK")
            {
                //statusDetail.Visible = false;
                //lblOutOfStockk.Text = ds.Tables[0].Rows[0]["available_nowTag"].ToString();
                //divlblOutOfStockk.Visible = true;
            }
            else
            {
                //divlblOutOfStockk.Visible = false;
                //statusDetail.Visible = true;
                //statusDetail.InnerHtml = ds.Tables[0].Rows[0]["available_nowHtml"].ToString();
            }
            if (ds.Tables[0].Rows[0]["Discount"].ToString() == "0" || ds.Tables[0].Rows[0]["Discount"].ToString() == "0.00" || ds.Tables[0].Rows[0]["Discount"].ToString() == "")
            {
                //divDiscountPr.Visible = false;
            }
            else
            {
                //divDiscountPr.Visible = false;
                //lblDisTag.Text = "- " + ds.Tables[0].Rows[0]["Discount"].ToString() + "%";
            }

            //imgprodCustEnq.Src = ds.Tables[0].Rows[0]["bigimg"].ToString();
            //imgshareprodonemail.Src = ds.Tables[0].Rows[0]["bigimg"].ToString();
            this.Page.Title = ds.Tables[0].Rows[0]["meta_title"].ToString();
            if (ds.Tables[2].Rows.Count > 0)
            {
                HtmlMeta keywords = new HtmlMeta();
                keywords.Name = "keywords";
                keywords.Content = ds.Tables[2].Rows[0]["meta_keywords"].ToString();
                this.Page.Header.Controls.Add(keywords);
                Page.Header.Controls.Add(new LiteralControl("\n"));
            }
            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "description";
            string dss = ds.Tables[0].Rows[0]["meta_description"].ToString();
            keywords1.Content = dss;
            Page.Header.Controls.Add(new LiteralControl("\n"));
            this.Page.Header.Controls.Add(keywords1);
            Page.Header.Controls.Add(new LiteralControl("\n"));
            HtmlLink canonical = new HtmlLink();
            canonical.Attributes.Add("rel", "canonical");
            canonical.Href = siteurl + produrl;
            Header.Controls.Add(canonical);

            //og Detail Bind

            string[] metaTags = { "og:title", "og:site_name", "og:description", "og:type", "og:url", "og:image" };

            foreach (string str in metaTags)
            {
                HtmlMeta tag = new HtmlMeta();
                switch (str)
                {
                    case "og:title":
                        tag.Attributes.Add("property", "og:title");
                        tag.Content = ds.Tables[0].Rows[0]["meta_title"].ToString();
                        Page.Header.Controls.Add(tag);
                        break;
                    case "og:site_name":
                        tag.Attributes.Add("property", "og:site_name");
                        tag.Content = siteurl;
                        Page.Header.Controls.Add(tag);
                        break;
                    case "og:description":
                        tag.Attributes.Add("property", "og:description");
                        tag.Content = dss;
                        Page.Header.Controls.Add(tag);
                        break;
                    case "og:url":
                        tag.Attributes.Add("property", "og:url");
                        tag.Content = siteurl + produrl;
                        Page.Header.Controls.Add(tag);
                        break;
                    case "og:image":
                        tag.Attributes.Add("property", "og:image");
                        tag.Content = String.Format(ds.Tables[0].Rows[0]["bigimg"].ToString());
                        Page.Header.Controls.Add(tag);
                        break;
                    case "og:type":
                        tag.Attributes.Add("property", "og:type");
                        tag.Content = siteurl;
                        Page.Header.Controls.Add(tag);
                        break;
                }
            }
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            DivDetail.InnerHtml = ds.Tables[1].Rows[0]["description"].ToString();
            //lblCusrProdNameCustEnq.Text = ds.Tables[1].Rows[0]["name"].ToString();
            //lblCusrProdNameCustEmail.Text = ds.Tables[1].Rows[0]["name"].ToString();
        }
        if (ds.Tables[3].Rows.Count > 0)
        {
            szDesc.InnerHtml = ds.Tables[3].Rows[0]["Description"].ToString();
            //<% --szImg.Src = ds.Tables[3].Rows[0]["imgUrl"].ToString(); --%>
        }

        rptImgBig.DataSource = ds;
        rptImgBig.DataBind();

        ds = dta.getDataSet("select * from  ps_product_attribute where id_product=" + catid + " and default_on=1");
        if (ds.Tables[0].Rows.Count > 0)
        {
            //lblattID.Text = ds.Tables[0].Rows[0]["id_product_attribute"].ToString();
        }

        ds = dta.getDataSet("Select id_category_default From ps_product where id_product = '" + catid + "'");
        catid = ds.Tables[0].Rows[0]["id_category_default"].ToString();
        dt = gdata.getNewArrivals("Related", catid);
        rptRelatedProd.DataSource = dt;
        rptRelatedProd.DataBind();

        ds = data.getVideo(proIdd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //liProdVideo.Visible = true;
            //frVideoLink.Src = ds.Tables[0].Rows[0]["link"].ToString();
            //lblProdVideoName.Text = ds.Tables[0].Rows[0]["name"].ToString();
            //lblProdVideodescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
        else
        {
            //liProdVideo.Visible = false;
        }
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/assets/css/vendor/vendor.min.css" rel="stylesheet" />
    <link href="/assets/css/plugins/plugins.min.css" rel="stylesheet" />
    <link href="/assets/css/style.min.css" rel="stylesheet" />
    <style type="text/css">
        /* main menu styles */
        .usermenu, .usermenu ul {
            list-style: none;
            margin: 0;
            padding: 0;
        }

        .usermenu {
            line-height: 30px;
            padding-left: 5px;
            padding-top: 5px;
            position: relative;
            z-index: 2;
        }

            .usermenu ul {
                left: -9999px;
                position: absolute;
                top: 40px;
                width: auto;
            }

                .usermenu ul ul {
                    left: -9999px;
                    position: absolute;
                    top: 0;
                    width: auto;
                }

            .usermenu li {
                float: left;
                margin-right: 5px;
                position: relative;
            }

                .usermenu li a {
                    color: #FFF;
                    display: block;
                    float: left;
                    font-size: 14px;
                    padding: 0px 10px;
                    text-decoration: none;
                }

            .usermenu > li > a {
                -moz-border-radius: 6px;
                -webkit-border-radius: 6px;
                -o-border-radius: 6px;
                border-radius: 6px;
                overflow: hidden;
            }

            .usermenu li a.fly {
                /* background:#c1c1bf url(../images/arrow.gif) no-repeat right center;*/
                padding-right: 15px;
            }

            .usermenu ul li {
                padding: 0px;
                margin: 0;
            }

                .usermenu ul li a {
                    width: 130px;
                    background: #333;
                    border-top: 1px solid #444;
                }

                    .usermenu ul li a.fly {
                        padding-right: 10px;
                    }

            /*hover styles*/
            .usermenu li:hover > a {
                background-color: #858180;
                color: #fff;
            }

            /*focus styles*/
            .usermenu li a:focus {
                outline-width: 0;
            }

                /*popups*/
                .usermenu li a:active + ul.dd, .usermenu li a:focus + ul.dd, .usermenu li ul.dd:hover {
                    left: 0;
                }

            .usermenu ul.dd li a:active + ul, .usermenu ul.dd li a:focus + ul, .usermenu ul.dd li ul:hover {
                left: 140px;
            }

        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 40%;
        }

        /* The Close Button */
        .close1 {
            color: #aaaaaa;
            float: right;
            text-align: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close1:hover,
            .close1:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }

        @media (max-width:767px) {
            /* Modal Content */
            .modal-content {
                background-color: #fefefe;
                margin: auto;
                padding: 10px;
                border: 1px solid #888;
                width: 90%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div data-ng-controller="ProductDetailController">
        <!-- ...:::: Start Breadcrumb Section:::... -->
        <div class="breadcrumb-section breadcrumb-bg-color--golden">
            <div class="breadcrumb-wrapper">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <asp:Label ID="lblattID" runat="server" Text="" Style="display: none;"></asp:Label>
                            <asp:Label ID="lblImgDtailPage" runat="server" Text="" Style="display: none;"></asp:Label>
                            <asp:Label ID="lblBigImg" runat="server" Text="" Style="display: none;"></asp:Label>
                            <asp:Label ID="lblProdId" runat="server" Text="" Style="display: none;"></asp:Label>
                            <asp:Label ID="lblProdIdDtailPage" runat="server" Text="" Style="display: none;"></asp:Label>
                            <%-- <h3 class="breadcrumb-title">Product Details - Default</h3>--%>
                            <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                                <nav aria-label="breadcrumb">
                                    <ul>
                                        <li><a href="/">Home</a></li>
                                        <li><a itemprop="item" id="catlinkb" runat="server"><span itemprop="name" id="catnameb" runat="server"></span></a></li>
                                        <li class="active" data-aria-current="page"><a itemprop="item" id="prodlinkb" runat="server"><span itemprop="name" id="prodnameb" runat="server"></span></a></li>
                                    </ul>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- ...:::: End Breadcrumb Section:::... -->

        <!-- Start Product Details Section -->
        <div class="product-details-section">
            <div class="container">
                <div class="row">
                    <div class="col-xl-5 col-lg-6">
                        <div class="product-details-gallery-area" data-aos="fade-up" data-aos-delay="0">
                            <!-- Start Large Image -->
                            <div class="product-large-image product-large-image-horaizontal swiper-container">
                                <div class="swiper-wrapper">
                                    <asp:Repeater ID="rptImgBig" runat="server">
                                        <ItemTemplate>
                                            <div class="product-image-large-image swiper-slide zoom-image-hover img-responsive">
                                                <img id="bigimg" src='<%#Eval("bigimg").ToString().TrimEnd() %>' alt='<%#Eval("Caption").ToString().TrimEnd() %>' title='<%#Eval("ProdName").ToString().TrimEnd() %>' />

                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <!-- End Large Image -->
                            <!-- Start Thumbnail Image -->
                            <div class="product-image-thumb product-image-thumb-horizontal swiper-container pos-relative mt-5">
                                <div class="swiper-wrapper">
                                    <asp:Repeater ID="rptImgThumb" runat="server">
                                        <ItemTemplate>
                                            <%--<div id='<%#Eval("id_image") %>' class="product-image-thumb-single swiper-slide">
                                                <img onclick="image(this)" class="img-fluid" src='<%#Eval("smallimg").ToString().TrimEnd() %>' title='<%#Eval("ProdName").ToString().TrimEnd() %>' height="" alt='<%#Eval("Caption") %>' />
                                                <script>
                                                    function image(img) {
                                                        $('#bigimg').attr('src', img.src);
                                                        $('.zoomImg').attr('src', img.src);
                                                        $('.zoomImg').attr('url', img.src);
                                                        $('.zoom-image-hover').trigger('zoom.destroy');
                                                        $('.zoom-image-hover').zoom({ url: img.src });
                                                    }

                                                </script>
                                            </div>--%>
                                            <div id='<%#Eval("id_image") %>' class="product-image-thumb-single swiper-slide">
                                                <img onclick="image(this)" class="img-fluid" src='<%#Eval("smallimg").ToString().TrimEnd() %>' title='<%#Eval("ProdName").ToString().TrimEnd() %>' alt='<%#Eval("Caption") %>' />
                                                <script>
                                                    function image(img) {
                                                        $('#bigimg').attr('src', img.src);
                                                        $('.zoomImg').attr('src', img.src);
                                                        $('.zoomImg').attr('url', img.src);
                                                        $('.zoom-image-hover').trigger('zoom.destroy');
                                                        $('.zoom-image-hover').zoom({ url: img.src });
                                                    }

                                                </script>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!-- Add Arrows -->
                                <div class="gallery-thumb-arrow swiper-button-next"></div>
                                <div class="gallery-thumb-arrow swiper-button-prev"></div>
                            </div>
                            <!-- End Thumbnail Image -->
                        </div>
                    </div>
                    <div class="col-xl-7 col-lg-6">
                        <div class="product-details-content-area product-details--golden" data-aos="fade-up"
                            data-aos-delay="200">
                            <div id="divProductHtml" runat="server">
                            </div>
                            <div id="sizeModal" class="modal">
                                <!-- Modal content -->
                                <div class="modal-content">
                                    <span class="close1">&times;</span>
                                    <h2 class="text-center">Size Chart</h2>
                                    <div id="szDesc" runat="server"></div>
                                    <img id="szImg" runat="server" />
                                </div>
                            </div>
                            <script>
                                // Get the modal
                                var modal = document.getElementById("sizeModal");

                                // Get the button that opens the modal
                                var btn = document.getElementById("sizeBtn");

                                // Get the <span> element that closes the modal
                                var span = document.getElementsByClassName("close1")[0];

                                // When the user clicks the button, open the modal 
                                btn.onclick = function () {
                                    modal.style.display = "block";
                                }

                                // When the user clicks on <span> (x), close the modal
                                span.onclick = function () {
                                    modal.style.display = "none";
                                }

                                // When the user clicks anywhere outside of the modal, close it
                                window.onclick = function (event) {
                                    if (event.target == modal) {
                                        modal.style.display = "none";
                                    }
                                }
                            </script>
                            <!-- The Modal -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Product Details Section -->

        <!-- Start Product Content Tab Section -->
        <div class="product-details-content-tab-section section-top-gap-100 mt-10">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="product-details-content-tab-wrapper" data-aos="fade-up" data-aos-delay="0">
                            <!-- Start Product Details Tab Button -->
                            <ul class="nav tablist product-details-content-tab-btn d-flex justify-content-center">
                                <li><a class="nav-link active" data-bs-toggle="tab" href="#description">Description
                                </a></li>
                                <li><a class="nav-link" data-bs-toggle="tab" href="#specification">Specification
                                </a></li>
                                <li><a class="nav-link" data-bs-toggle="tab" href="#review">Reviews
                                </a></li>
                            </ul>
                            <!-- End Product Details Tab Button -->

                            <!-- Start Product Details Tab Content -->
                            <div class="product-details-content-tab">
                                <div class="tab-content">
                                    <!-- Start Product Details Tab Content Singel -->
                                    <div class="tab-pane active show" id="description">
                                        <div class="single-tab-content-item">
                                            <div id="DivDetail" runat="server" class="parent"></div>
                                        </div>
                                    </div>
                                    <!-- End Product Details Tab Content Singel -->
                                    <!-- Start Product Details Tab Content Singel -->
                                    <div class="tab-pane" id="specification">
                                        <div class="single-tab-content-item">
                                            <table class="table table-bordered mb-20">
                                                <tbody>
                                                    <tr data-ng-repeat="a in fets">
                                                        <%--<th scope="row">{{a.SNO}}</th>--%>
                                                        <td>{{a.ITem}}</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- End Product Details Tab Content Singel -->
                                    <!-- Start Product Details Tab Content Singel -->
                                    <div class="tab-pane" id="review">
                                        <div class="single-tab-content-item">
                                            <!-- Start - Review Comment -->
                                            <ul class="comment">
                                                <!-- Start - Review Comment list-->
                                                <li class="comment-list" data-ng-repeat="re in revs">
                                                    <div class="comment-wrapper">
                                                        <div class="comment-img">
                                                            <img src="/assets/images/user/image-3.png" alt="">
                                                        </div>
                                                        <div class="comment-content">
                                                            <div class="comment-content-top">
                                                                <div class="comment-content-left">
                                                                    <h6 class="comment-name">{{re.customer_name}}</h6>
                                                                    <div>
                                                                        <ul class="review-star">
                                                                            <li class="fill"><i class="ion-android-star"></i></li>
                                                                            <li class="fill"><i class="ion-android-star"></i>
                                                                            </li>
                                                                            <li class="fill"><i class="ion-android-star"></i>
                                                                            </li>
                                                                            <li class="fill"><i class="ion-android-star"></i>
                                                                            </li>
                                                                            <li class="fill"><i class="ion-android-star"></i>
                                                                            </li>
                                                                            <li class="fill"><i class="ion-android-star"></i>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                                <div class="comment-content-right">
                                                                    <a href="#"><i class="fa fa-reply"></i>Reply</a>
                                                                </div>
                                                            </div>

                                                            <div class="para-content">
                                                                <p>
                                                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                                                                Tempora inventore dolorem a unde modi iste odio amet,
                                                                fugit fuga aliquam, voluptatem maiores animi dolor nulla
                                                                magnam ea! Dignissimos aspernatur cumque nam quod sint
                                                                provident modi alias culpa, inventore deserunt
                                                                accusantium amet earum soluta consequatur quasi eum eius
                                                                laboriosam, maiores praesentium explicabo enim dolores
                                                                quaerat! Voluptas ad ullam quia odio sint sunt. Ipsam
                                                                officia, saepe repellat.
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </li>
                                                <!-- End - Review Comment list-->
                                            </ul>
                                            <!-- End - Review Comment -->
                                            <div class="review-form">
                                                <div class="review-form-text-top">
                                                    <h5>ADD A REVIEW</h5>
                                                </div>

                                                <form action="#" method="post">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="default-form-box">
                                                                <label for="comment-name">Your name <span>*</span></label>
                                                                <input id="comment-name" type="text"
                                                                    placeholder="Enter your name" required>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="default-form-box">
                                                                <label for="comment-email">Your Email <span>*</span></label>
                                                                <input id="comment-email" type="email"
                                                                    placeholder="Enter your email" required>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="default-form-box">
                                                                <label for="comment-review-text">
                                                                    Your review
                                                                <span>*</span></label>
                                                                <textarea id="comment-review-text"
                                                                    placeholder="Write a review" required></textarea>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <button class="btn btn-md btn-black-default-hover"
                                                                type="submit">
                                                                Submit</button>
                                                        </div>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End Product Details Tab Content Singel -->
                                </div>
                            </div>
                            <!-- End Product Details Tab Content -->

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Product Content Tab Section -->

        <!-- Start Product Default Slider Section -->
        <div class="product-default-slider-section section-top-gap-100 section-fluid mt-10">
            <!-- Start Section Content Text Area -->
            <div class="section-title-wrapper" data-aos="fade-up" data-aos-delay="0">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="section-content-gap">
                                <div class="secton-content">
                                    <h3 class="section-title">RELATED PRODUCTS</h3>
                                    <p>Browse the collection of our related products.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Start Section Content Text Area -->
            <div class="product-wrapper" data-aos="fade-up" data-aos-delay="0">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="product-slider-default-1row default-slider-nav-arrow">
                                <!-- Slider main container -->
                                <div class="swiper-container product-default-slider-4grid-1row">
                                    <!-- Additional required wrapper -->
                                    <div class="swiper-wrapper">
                                        <asp:Repeater ID="rptRelatedProd" runat="server">
                                            <ItemTemplate>
                                                <!-- Start Product Default Single Item -->
                                                <div class="product-default-single-item product-color--aqua swiper-slide product-color--golden">
                                                    <div class="image-box">
                                                        <a href='/<%#Eval("DetailUrl") %>' class="image-link">
                                                            <img src='<%#Eval("URL") %>' alt='<%#Eval("ImgCaption") %>' title='<%#Eval("ImgCaption") %>' />
                                                            <img src='<%#Eval("imgSecond") %>' alt='<%#Eval("imgSecondCaption") %>' title='<%#Eval("imgSecondCaption") %>' />
                                                        </a>
                                                        <div class='tag1 <%#Eval("pDis") %>'>
                                                            <span><%#Eval("Discount") %>%</span>
                                                        </div>
                                                    </div>
                                                    <div class="content">
                                                        <div class="content-left">
                                                            <h6 class="title  text-center"><a href='/<%#Eval("DetailUrl") %>'><%#Eval("ProdName") %></a></h6>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-xl-6 col-lg-6 col-sm-8 col-8 text-center">
                                                            <ul class="review-star">
                                                                <%# gdata.BindStar(Eval("Rating").ToString()) %>
                                                            </ul>
                                                        </div>
                                                        <div class="col-xl-6 col-lg-6 col-sm-4 col-4 text-center action-link-right">
                                                            <a href="javaScript:void(0);" onclick="addWishList('<%#Eval("ProdID") %>');"><i class="icon-heart"></i></a>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-xl-6 col-lg-6 col-sm-6 col-12 text-center">
                                                            <span class="price"><del class='<%#Eval("pDis") %>'>₹<%#Eval("ProdPrice") %></del>₹ <%#Eval("DiscountPrice") %></span>
                                                        </div>
                                                        <div class="col-xl-6 col-lg-6 col-sm-6 col-12  text-center">
                                                            <a href='/<%#Eval("DetailUrl") %>' class="btb btn-sm btn-black-default-hover"><b>Add To Cart</b></a>
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
        <div id="myModal" class="modal">
            <!-- Modal content -->

        </div>
        <!-- End Product Default Slider Section -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="/appjs/product.js?v=10254"></script>
</asp:Content>


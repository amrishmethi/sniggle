<%@ Control Language="C#" ClassName="bestsalemob" %>

<%@ Import Namespace="System.Data" %>
<script runat="server">
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    GetData data = new GetData();
    GData gData = new GData();
    HttpCookie viewedprod;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt = gData.GetNewArrivalProd();
            rptNewArrivalMob.DataSource = dt;
            rptNewArrivalMob.DataBind();
            if (HttpContext.Current.Request.Cookies["viewedprod"] != null)
            {
                viewedprod = HttpContext.Current.Request.Cookies["viewedprod"];
                string ProdId = viewedprod.Values["ProdID"].ToString();
                dt = gData.GetLastViewedProd(ProdId);
                rptLastViewedProdMob.DataSource = dt;
                rptLastViewedProdMob.DataBind();
                divLastViewedProdMob.Visible = true;
            }
            else
            {
                divLastViewedProdMob.Visible = false;
            }
        }
    }

    public string BindStar(string myValue1)
    {
        string ddd = myValue1.ToString();
        string revicount = myValue1.ToString();
        string str = "";
        if (myValue1.ToString() == "5")
        {
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
        }
        if (myValue1.ToString() == "4")
        {
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_off\"></div>";
        }
        if (myValue1.ToString() == "3")
        {
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
        }
        if (myValue1.ToString() == "2")
        {
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
        }
        if (myValue1.ToString() == "1")
        {
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
        }
        if (myValue1.ToString() == "0" || myValue1.ToString() == "")
        {
            revicount = "1";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
        }
        str += "<meta itemprop=\"worstRating\" content=\"0\" />";
        str += "<meta itemprop=\"ratingValue\" content=\"5\" />";
        str += "<meta itemprop=\"bestRating\" content=\"5\" />";
        str += "<meta itemprop=\"reviewCount\" content=\"" + revicount + "\" />";
        return str;
    }
</script>

<!------------------1 new arrivals on mobile--------->
<div class="hidden-xl-up">
    <div id="search_filters" class="links p-0">
        <div class="title clearfix" data-target="#newarrivals" data-toggle="collapse">
            <span class="float-xs-right  hidden-md-up"><span class="navbar-toggler collapse-icons"><i class="material-icons add">keyboard_arrow_down</i> <i class="material-icons remove">keyboard_arrow_up</i> </span></span>
            <p class="h6">New Arrivals</p>
        </div>
        <section class="facet clearfix collapse" id="newarrivals">
            <div class="poslistcateproduct poslistcateproduct_0 product_container"
                data-items="1"
                data-speed="1000"
                data-autoplay="0"
                data-time="0"
                data-arrow="1"
                data-pagination="0"
                data-move="0"
                data-pausehover="0"
                data-lg="2"
                data-md="1"
                data-sm="2"
                data-xs="1"
                data-xxs="1">
                <div class="row">
                    <div class="col-xs-12 col-md-12 col-lg-12 col-xl-12">
                        <div class="listcateproduct-products">
                            <div class="row pos_content pl-1 pr-1">
                                <div class="listcateSlide owl-carousel">
                                    <asp:Repeater ID="rptNewArrivalMob" runat="server">
                                        <ItemTemplate>
                                            <div class="item-product">
                                                <article class="style_product_default product-miniature js-product-miniature item_in">
                                                    <div itemtype="http://schema.org/Product" itemscope>
                                                        <div class="img_block">
                                                            <a href='<%#Eval("DetailUrl") %>' class="thumbnail product-thumbnail">
                                                                <img class="first-image "
                                                                    src='<%#Eval("URL") %>'
                                                                    alt='<%#Eval("URL") %>'
                                                                    data-full-size-image-url='<%#Eval("URL") %>' />
                                                                <img class="img-responsive second-image animation1 "
                                                                    src='<%#Eval("imgSecond") %>'
                                                                    alt='<%#Eval("imgSecond") %>'
                                                                    data-full-size-image-url='<%#Eval("imgSecond") %>' />
                                                            </a>
                                                        </div>
                                                        <div class="product_desc">
                                                            <div class="hook-reviews">
                                                                <div class="comments_note text-center" itemprop="aggregateRating" itemscope itemtype="https://schema.org/AggregateRating">
                                                                    <div class="star_content clearfix">
                                                                        <%# BindStar(Eval("Rating").ToString()) %>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <h3 itemprop="name"><a href='/<%#Eval("DetailUrl") %>' class="product_name text-center" title='<%#Eval("ProdName") %>'><%#Eval("ProdName") %></a></h3>
                                                            <div class="product-price-and-shipping text-center"><span class="sr-only">Regular price</span> <%#Eval("DisPrice") %><span class="sr-only">Price</span> <span class="price ">$ <%#Eval("DiscountPrice") %></span> </div>
                                                        </div>
                                                        <link itemprop="image" href="<%#Eval("URL") %>" />
                                                        <meta itemprop="description" content='<%#Eval("description") %>' />
                                                        <div itemprop="offers" itemscope itemtype="http://schema.org/Offer">
                                                            <link itemprop="url" href="<%#Eval("DetailUrl1") %>" />
                                                            <meta itemprop="availability" content="https://schema.org/InStock" />
                                                            <meta itemprop="priceCurrency" content="USD" />
                                                            <meta itemprop="itemCondition" content="https://schema.org/NEW" />
                                                            <meta itemprop="price" content="<%#Eval("DiscountPrice") %>" />
                                                            <meta itemprop="priceValidUntil" content="2125-11-20" />
                                                        </div>
                                                        <meta itemprop="sku" content='<%#Eval("reference") %>' />
                                                        <div itemprop="brand" itemtype="http://schema.org/Brand" itemscope>
                                                            <meta itemprop="name" content="EARTH STONE INC" />
                                                        </div>
                                                    </div>
                                                </article>
                                                <article class="style_product_default product-miniature js-product-miniature item_in">
                                                    <div itemtype="http://schema.org/Product" itemscope>
                                                        <div class="img_block">
                                                            <a href='/<%#Eval("DetailUrl1") %>' class="thumbnail product-thumbnail">
                                                                <img class="first-image "
                                                                    src='<%#Eval("URL1") %>'
                                                                    alt='<%#Eval("URL1") %>'
                                                                    data-full-size-image-url='<%#Eval("URL1") %>' />
                                                                <img class="img-responsive second-image animation1 "
                                                                    src='<%#Eval("imgSecond1") %>'
                                                                    alt='<%#Eval("imgSecond1") %>'
                                                                    data-full-size-image-url='<%#Eval("imgSecond1") %>' />
                                                            </a>
                                                        </div>
                                                        <div class="product_desc">
                                                            <div class="hook-reviews">
                                                                <div class="comments_note text-center" itemprop="aggregateRating" itemscope itemtype="https://schema.org/AggregateRating">
                                                                    <div class="star_content clearfix">
                                                                        <%# BindStar(Eval("Rating").ToString()) %>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <h3 itemprop="name"><a href='/<%#Eval("DetailUrl1") %>' class="product_name text-center" title='<%#Eval("ProdName1") %>'><%#Eval("ProdName1") %></a></h3>
                                                            <div class="product-price-and-shipping text-center"><span class="sr-only">Regular price</span> <%#Eval("DisPrice1") %><span class="sr-only">Price</span> <span class="price ">$ <%#Eval("DiscountPrice1") %></span> </div>
                                                        </div>
                                                        <link itemprop="image" href="<%#Eval("URL1") %>" />
                                                        <meta itemprop="description" content='<%#Eval("description1") %>' />
                                                        <div itemprop="offers" itemtype="http://schema.org/Offer" itemscope>
                                                            <link itemprop="url" href="<%#Eval("DetailUrl1") %>" />
                                                            <meta itemprop="availability" content="https://schema.org/InStock" />
                                                            <meta itemprop="priceCurrency" content="USD" />
                                                            <meta itemprop="itemCondition" content="https://schema.org/NEW" />
                                                            <meta itemprop="price" content="<%#Eval("DiscountPrice1") %>" />
                                                            <meta itemprop="priceValidUntil" content="2125-11-20" />
                                                        </div>
                                                        <meta itemprop="sku" content='<%#Eval("reference1") %>' />
                                                        <div itemprop="brand" itemtype="http://schema.org/Brand" itemscope>
                                                            <meta itemprop="name" content="EARTH STONE INC" />
                                                        </div>
                                                    </div>
                                                </article>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</div>
<!------------------ new arrivals on mobile close--------->
<!------------------Last view product on Mobile ---------->
<div id="divLastViewedProdMob" runat="server" class="hidden-xl-up">
    <div id="search_filters" class="links p-0">
        <div class="title clearfix" data-target="#last-selling" data-toggle="collapse">
            <span class="float-xs-right  hidden-md-up"><span class="navbar-toggler collapse-icons"><i class="material-icons add">keyboard_arrow_down</i> <i class="material-icons remove">keyboard_arrow_up</i> </span></span>
            <p class="h6">Last View Products</p>
        </div>
        <section class="facet clearfix collapse" id="last-selling">
            <div id="facet_last-views" class="poslistcateproduct poslistcateproduct_0 product_container collapse"
                data-items="1"
                data-speed="1000"
                data-autoplay="0"
                data-time="0"
                data-arrow="1"
                data-pagination="0"
                data-move="0"
                data-pausehover="0"
                data-lg="2"
                data-md="1"
                data-sm="2"
                data-xs="1"
                data-xxs="1">
                <div class="row">
                    <div class="col-xs-12 col-md-12 col-lg-12 col-xl-12">
                        <div class="listcateproduct-products">
                            <div class="row pos_content pl-1 pr-1">
                                <div class="listcateSlide owl-carousel">
                                    <asp:Repeater ID="rptLastViewedProdMob" runat="server">
                                        <ItemTemplate>
                                            <div class="item-product">
                                                <article class="style_product_default product-miniature js-product-miniature item_in">
                                                    <div class="img_block">
                                                        <a href='/<%#Eval("DetailUrl") %>' class="thumbnail product-thumbnail">
                                                            <img class="first-image "
                                                                src='<%#Eval("URL") %>'
                                                                alt='<%#Eval("URL") %>'
                                                                data-full-size-image-url='<%#Eval("URL") %>' />
                                                            <img class="img-responsive second-image animation1 "
                                                                src='<%#Eval("imgSecond") %>'
                                                                alt='<%#Eval("imgSecond") %>'
                                                                data-full-size-image-url='<%#Eval("imgSecond") %>' />
                                                        </a>
                                                    </div>
                                                    <div class="product_desc">
                                                        <div class="hook-reviews">
                                                            <div class="comments_note text-center">
                                                                <div class="star_content clearfix">
                                                                    <%# BindStar(Eval("Rating").ToString()) %>
                                                                </div>
                                                            </div>
                                                            <h3 itemprop="name"><a href='/<%#Eval("DetailUrl") %>' class="product_name text-center" title='<%#Eval("ProdName") %>'><%#Eval("ProdName") %></a></h3>
                                                            <div class="product-price-and-shipping text-center"><span class="sr-only">Regular price</span> <%#Eval("DisPrice") %><span class="sr-only">Price</span> <span class="price ">$ <%#Eval("DiscountPrice") %></span> </div>
                                                        </div>
                                                </article>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</div>
<!----------------Last view product on Mobile------------>

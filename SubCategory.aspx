<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Import Namespace="System.Data" %>
<script runat="server">
    DataSet ds = new DataSet();
    GetData getData = new GetData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string siteurl = ConfigurationManager.AppSettings["siteurl"].ToString();
            if (Request.QueryString[0] != null)
            {
                ds = getData.getCategory(Request.QueryString[0].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string pageurl = ds.Tables[0].Rows[0]["Url"].ToString();
                    //Image1.ImageUrl = ds.Tables[0].Rows[0]["CatImage"].ToString();
                    lblCategory.Text = ds.Tables[0].Rows[0]["CatName"].ToString();
                    lblTopCategory.Text = ds.Tables[0].Rows[0]["CatName"].ToString();
                    //CatDescription.InnerHtml = ds.Tables[0].Rows[0]["description"].ToString();
                    //catlink.HRef = pageurl;

                    this.Page.Title = ds.Tables[0].Rows[0]["meta_title"].ToString();
                    HtmlMeta keywords = new HtmlMeta();
                    keywords.Name = "keywords";
                    keywords.Content = ds.Tables[0].Rows[0]["meta_keywords"].ToString();
                    HtmlMeta keywords1 = new HtmlMeta();
                    keywords1.Name = "Description";
                    keywords1.Content = ds.Tables[0].Rows[0]["meta_description"].ToString();
                    this.Page.Header.Controls.Add(keywords);
                    Page.Header.Controls.Add(new LiteralControl("\n"));
                    this.Page.Header.Controls.Add(keywords1);
                    Page.Header.Controls.Add(new LiteralControl("\n"));
                    HtmlLink canonical = new HtmlLink();
                    canonical.Attributes.Add("rel", "canonical");
                    canonical.Href = siteurl + pageurl;
                    Header.Controls.Add(canonical);
                }
            }
            ulMenu.InnerHtml = getData.getLeftCategory();
        }
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/css/vendor/vendor.min.css" rel="stylesheet" />
    <link href="assets/css/plugins/plugins.min.css" rel="stylesheet" />
    <link href="assets/css/style.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="breadcrumb-section breadcrumb-bg-color--golden">
        <div class="breadcrumb-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h3 class="breadcrumb-title">
                            <asp:Label ID="lblTopCategory" runat="server"></asp:Label></h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li><a id="catlink" runat="server"><span itemprop="name">
                                        <asp:Label ID="lblCategory" runat="server"></asp:Label></span></a></li>
                                </ul>
                                <meta itemprop="position" content="2">
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="shop-section" data-ng-controller="ProductsController">
        <div id="loading" data-ng-if="loading">
            <div id="loading-image">
                <img src="https://ik.imagekit.io/sniggle/img/loader.gif?tr=w-125%2Ch125" alt="Loading..." style="border-radius: 5%;" />
            </div>
        </div>
        <div class="container">
            <div class="row flex-column-reverse flex-lg-row">
                <div class="col-lg-3">
                    <div class="siderbar-section" data-aos="fade-up" data-aos-delay="0">
                        <div class="sidebar-single-widget">
                            <h6 class="sidebar-title">CATEGORIES</h6>
                            <div class="sidebar-content">
                                <ul class="sidebar-menu" id="ulMenu" runat="server">
                                </ul>
                            </div>
                        </div>
                        <!-- Start Single Sidebar Widget -->
                        <p class="h6 facet-title" data-ng-if="RfineLoading">Loading...</p>
                        <div class="sidebar-single-widget">
                            <h6 class="sidebar-title">DISCOUNT RANGE</h6>
                            <div class="sidebar-content">
                                <div class="filter-type-select">
                                    <ul>
                                        <li>
                                            <label class="checkbox-default">
                                                <input id="txtDicount10" name="discount" type="radio" data-ng-click="getItems()" data-ng-checked="{{a.isCheck}}" class="input-radio" />
                                                <span>10% - 20%</span>
                                            </label>
                                        </li>
                                        <li>
                                            <label class="checkbox-default">
                                                <input id="txtDicount20" name="discount" type="radio" data-ng-click="getItems()" class="input-radio" />
                                                <span>21% - 30%</span>
                                            </label>
                                        </li>
                                        <li>
                                            <label class="checkbox-default">
                                                <input id="txtDicount30" name="discount" type="radio" data-ng-click="getItems()" class="input-radio" />
                                                <span>31% - 40%</span>
                                            </label>
                                        </li>
                                        <li>
                                            <label class="checkbox-default">
                                                <input id="txtDicount40" name="discount" type="radio" data-ng-click="getItems()" class="input-radio" />
                                                <span>41% - 50%</span>
                                            </label>
                                        </li>
                                        <li>
                                            <label class="checkbox-default">
                                                <input id="txtDicount50" name="discount" type="radio" data-ng-click="getItems()" class="input-radio" />
                                                <span>51% and above</span>
                                            </label>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="sidebar-single-widget" data-ng-repeat="fil in filts">
                            <h6 class="sidebar-title">{{fil.groupname}}</h6>
                            <div class="default-search-style d-flex">
                                <input id="txt{{fil.id_attribute_group}}" class="default-search-style-input-box" type="search" placeholder="Search..." data-ng-change="getFilter(fil.id_attribute_group);" data-ng-model="sch" />
                            </div>
                            <div class="sidebar-content">
                                <div class="filter-type-select">
                                    <ul>
                                        <li data-ng-repeat="a in fil.Attri" id="li{{a.id}}">
                                            <label class="checkbox-default" for="att{{a.id}}">
                                                <input id="att{{a.id}}" type="checkbox" data-ng-click="getItems(a.id);" data-ng-checked="{{a.isCheck}}" data-ng-model="a.isCheck" />
                                                <span>{{a.Name}}</span>
                                            </label>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- End Single Sidebar Widget -->
                    </div>
                    <!-- End Sidebar Area -->
                </div>
                <div class="col-lg-9">
                    <!-- Start Shop Product Sorting Section -->
                    <div class="shop-sort-section">
                        <div class="container">
                            <div class="row">
                                <!-- Start Sort Wrapper Box -->
                                <div class="sort-box d-flex justify-content-between align-items-md-center align-items-start flex-md-row flex-column"
                                    data-aos="fade-up" data-aos-delay="0">
                                    <!-- Start Sort tab Button -->
                                    <div class="sort-tablist d-flex align-items-center">
                                        <!-- Start Page Amount -->
                                        <div class="page-amount ml-2">
                                            Showing
                                            <span data-ng-if="currentPage == 1">1
                                            </span>
                                            <span data-ng-if="currentPage != 1">{{(currentPage - 1) * products[0].coun}}
                                            </span>
                                            - <span data-ng-if="(currentPage * products[0].coun) > products.length">{{products.length}}</span>
                                            <span data-ng-if="(currentPage * products[0].coun) <= products.length">{{(currentPage) * products[0].coun}}</span>
                                            of 
                                                    <label id="lblItemCount"></label>
                                        </div>
                                        <!-- End Page Amount -->
                                    </div>
                                    <!-- End Sort tab Button -->
                                    <!-- Start Sort Select Option -->
                                    <div class="sort-select-list d-flex align-items-center d-none">
                                        <label class="mr-2">Sort By:</label>
                                        <fieldset>
                                            <select name="speed" id="drpFilter" data-ng-change="getOrderBy();" data-ng-model="aaa">
                                                <option value="0">Name, A to Z</option>
                                                <option value="ND">Name, Z to A</option>
                                                <option value="PL">Price, low to high</option>
                                                <option value="PH">Price, high to low</option>
                                            </select>
                                        </fieldset>
                                    </div>
                                    <!-- End Sort Select Option -->
                                </div>
                                <!-- Start Sort Wrapper Box -->
                            </div>
                        </div>
                    </div>
                    <!-- End Section Content -->
                    <!-- Start Tab Wrapper -->
                    <div class="sort-product-tab-wrapper">
                        <div class="container">
                            <div class="row">
                                <div class="col-12">
                                    <div class="tab-content tab-animate-zoom">
                                        <!-- Start Grid View Product -->
                                        <div class="tab-pane active show sort-layout-single" id="layout-3-grid">
                                            <div class="row">
                                                <div class="col-xl-4 col-sm-6 col-12" data-dir-paginate="prod in products | itemsPerPage:products[0].coun" data-current-page="currentPage">
                                                    <div class="product-default-single-item product-color--golden"
                                                        data-aos="fade-up" data-aos-delay="0">
                                                        <div class="image-box">
                                                            <a href="{{prod.DetailUrl}}" class="image-link">
                                                                <img data-ng-src="{{prod.URL}}"
                                                                    alt="{{prod.ImgCaption}}" title="{{prod.ImgCaption}}"
                                                                    data-full-size-image-url="{{prod.URL}}" />
                                                                <img data-ng-src="{{prod.imgSecond}}"
                                                                    alt="{{prod.imgSecondCaption}}" title="{{prod.imgSecondCaption}}" itemprop="image" />
                                                            </a>
                                                            <div class="tag" data-ng-hide="{{prod.ProdPrice === prod.DiscountPrice}}">
                                                                <span>{{prod.Discount}}% Off</span>
                                                            </div>
                                                            <div class="action-link">
                                                                <div class="action-link-left">
                                                                    <a href='{{prod.DetailUrl}}'>Add to Cart</a>
                                                                </div>
                                                                <div class="action-link-right">
                                                                    <a href="javaScript:void(0);" onclick="addWishList(this.id)">
                                                                        <i class="icon-heart"></i>
                                                                    </a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="content">
                                                            <div class="content-left">
                                                                <h6 class="title">
                                                                    <a href="{{prod.DetailUrl}}">{{prod.ProdName}}
                                                                    </a>
                                                                </h6>
                                                            </div>
                                                            <div class="content-right">
                                                                <del data-ng-hide="{{prod.ProdPrice === prod.DiscountPrice}}" class="regular-price ">₹ {{prod.ProdPrice | number : 2}}</del>
                                                                <span class="price font-weight-bold">₹ {{prod.DiscountPrice | number : 2}}</span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- End Product Default Single Item -->
                                                </div>
                                            </div>
                                        </div>
                                        <!-- End Grid View Product -->
                                        <!-- Start List View Product -->

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="page-pagination text-center" data-aos="fade-up" data-aos-delay="0">
                        <ul>
                            <li>
                                <dir-pagination-controls max-size="10" direction-links="true" boundary-links="true">
                                </dir-pagination-controls>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="/appjs/product.js?v=<%=DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>


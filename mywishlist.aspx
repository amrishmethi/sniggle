<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/controls/LeftCustomer.ascx" TagPrefix="uc1" TagName="LeftCustomer" %>
<%@ Import Namespace="System.Data" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        Data data = new Data();
        if (!IsPostBack)
        {
            ds = data.getDataSet("select * From ps_cms_lang  where id_lang = 1 and id_cms = '57'");
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
            }
            if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
            {

            }
            else
            {
                Response.Redirect("/login");
            }
        }
    }

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="breadcrumb-section breadcrumb-bg-color--golden">
        <div class="breadcrumb-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h3 class="breadcrumb-title">My wishlist</h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li class="active" aria-current="page">My wishlist</li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="account-dashboard">
        <div class="container" data-ng-controller="CustomerController">
            <div class="row">
                <uc1:LeftCustomer runat="server" ID="LeftCustomer" />
                <div class="col-sm-12 col-md-9 col-lg-9">
                    <div class="row">
                        <div class="col-md-12 col-xs-12">
                            <h1 id="js-product-list-header" class="h2">My wishlist</h1>
                            <hr>
                        </div>
                    </div>
                    <div class="table_page table-responsive">
                        <table class="table  responsive table-bordered ">
                            <thead class="bg-gray">
                                <tr>
                                    <th scope="col">Image</th>
                                    <th scope="col">Product Description</th>
                                    <th scope="col">View</th>
                                    <th scope="col">Remove</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr id="wishlist_31" data-ng-repeat="item in WishList">
                                    <td><span class="product-image media-middle">
                                        <img ng-src="{{item.URL}}" alt="{{item.ProdName}}" width="100px" height="80">
                                    </span></td>
                                    <td>
                                        <div class="product-line-info">
                                            <a class="product_name" href="{{item.DetailUrl}}" data-id_customization="0" style="width: 100%;">{{item.ProdName}}</a>
                                        </div>
                                        <span class="product_name" data-id_customization="0" style="width: 100%; text-align: left;">{{item.pair}}</span>
                                        <br />
                                         <del data-ng-hide="{{item.ProdPrice === item.DiscountPrice}}" class="regular-price ">₹{{item.ProdPrice | number : 2}}</del>
                                                    <span class="price   price-sale font-weight-bold">₹{{item.DiscountPrice | number : 2}}</span> 
                                    </td>
                                    <td>
                                        <a href='{{item.DetailUrl}}' class="btn btn-md btn-golden">View
                                        </a>
                                    </td>
                                    <td>
                                        <a href="#" data-ng-click="RemoveItemWL(item.id_wishlist_product)"><i class="fa fa-trash-o"></i></a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="/appjs/dashboard.js"></script>
</asp:Content>


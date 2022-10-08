<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="~/controls/LeftCustomer.ascx" TagPrefix="uc1" TagName="LeftCustomer" %>


<script runat="server">
    DataSet ds = new DataSet();
    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = data.getDataSet("select * From ps_cms_lang  where id_lang = 1 and id_cms = '53'");
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
                        <h3 class="breadcrumb-title">Order Detail</h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li class="active" aria-current="page">Order Detail</li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="account-dashboard" data-ng-controller="CustomerController">
        <div class="container">
            <div class="row">
                <uc1:LeftCustomer runat="server" ID="LeftCustomer" />
                <div class="col-sm-12 col-md-9 col-lg-9">

                    <div class="row">
                        <div class="col-md-12 col-xs-12">
                            <h1 id="js-product-list-header" class="h2">Order detail</h1>
                            <hr>
                            <h4 style="background-color: #f1f4f7; padding: 10px;">Order reference : {{OrderDetailTbl0[0].reference}} </h4>
                        </div>
                    </div>
                    <div class="clearfix">&nbsp;</div> 
                    <div class="table_page table-responsive">
                        <table>
                            <thead>
                                <tr>
                                    <th>Status</th>
                                    <th>Date</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr data-ng-repeat="item in orderstatus">
                                    <td>
                                        <span style="color: #fff; padding: 3px 8px 3px 8px; background-color: {{item.color}};">{{item.name}}</span>
                                    </td>
                                    <td class="bold align_center">{{item.date_add | date:'medium'}}
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                     <div class="clearfix">&nbsp;</div>
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <div id="content" class="col-md-12 bg-gray" style="min-height: 220px;">
                                <div class="box p-1">
                                    <h3 class="page-subheading"  style="background-color: #f1f4f7; padding:8px">Delivery address({{OrderDetailDelAdd[0].alias}})</h3>
                                    <div class="form_content clearfix">
                                        <span id="spShipping">
                                            <p>{{OrderDetailDelAdd[0].firstname}} {{OrderDetailDelAdd[0].lastname}}</p>
                                            <p ng-show="ShipAddressDetail[0].company">{{OrderDetailDelAdd[0].company}}</p>
                                            <p>{{OrderDetailDelAdd[0].address1}}  </p>
                                            <Referencep>
                                                {{OrderDetailDelAdd[0].city}}, 
                                                                    <span ng-show="OrderDetailDelAdd[0].StateName">{{OrderDetailDelAdd[0].StateName}}, </span>{{OrderDetailDelAdd[0].postcode}}, {{OrderDetailDelAdd[0].CountryName}}
                                            </Referencep>
                                            <p>{{OrderDetailDelAdd[0].phone_mobile}}</p>
                                            <p>{{OrderDetailDelAdd[0].phone}}</p>
                                            <p>{{OrderDetailDelAdd[0].other}}</p>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <div id="content" class="col-md-12 bg-gray" style="min-height: 220px;">
                                <div class="box p-1">
                                    <h3 class="page-subheading" style="background-color: #f1f4f7; padding:8px">Invoice address ({{OrderDetailInvAdd[0].alias}})</h3>
                                    <div class="form_content clearfix">
                                        <span id="spBilling">
                                            <p>{{OrderDetailInvAdd[0].firstname}} {{OrderDetailInvAdd[0].lastname}}</p>
                                            <p ng-show="ShipAddressDetail[0].company">{{OrderDetailInvAdd[0].company}}</p>
                                            <p>{{OrderDetailInvAdd[0].address1}} </p>
                                            <p>
                                                {{OrderDetailInvAdd[0].city}}, 
                                                                     <span ng-show="OrderDetailDelAdd[0].StateName">{{OrderDetailInvAdd[0].StateName}}, </span>{{OrderDetailInvAdd[0].postcode}}, {{OrderDetailInvAdd[0].CountryName}}
                                            </p>
                                            <p>{{OrderDetailInvAdd[0].phone_mobile}}</p>
                                            <p>{{OrderDetailInvAdd[0].phone}}</p>
                                            <p>{{OrderDetailInvAdd[0].other}}</p>
                                        </span>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 col-sm-12 pt-1" style="overflow-x: auto;">
                            <table class="table  responsive table-bordered">
                                <thead style="background-color: #f1f4f7;">
                                    <tr>
                                        <th class="hidden-xs-down">Reference</th>
                                        <th>Product</th>
                                        <th style="text-align: center;">Qty</th>
                                        <th>Unit Price</th>
                                        <th>Total Price</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="wishlist_31" data-ng-repeat="item in OrderDetailTbl1">
                                        <td style="width: 200px;" class="hidden-xs-down">{{item.product_reference}}
                                        </td>
                                        <td class="bold align_center"> 
                                            {{item.product_name}}
                                             <div class="product-line-info" data-ng-show="item.CustomizeImg">
                                                    <a class="link-info" href="img/CustomizeOrder/{{item.CustomizeImg}}" target="_blank">View Your Personalize Image</a> 
                                                </div>
                                        </td>
                                        <td class="td_none text-center">{{item.ProdQty}} </td>
                                        <td class="td_none" style="width: 90px; text-align: right;">{{item.ProdPrice | currency:"₹" }}</td>
                                        <td style="width: 100px; text-align: right;">{{item.ProdTotPrice | currency:"₹" }}
                                        </td>
                                        <td class="d-none">
                                            <a class="btn btn-primary btn-md btn-shadow" data-ng-hide="'OutofStock' === '{{item.prodStatus}}'" data-ng-click="reorderProduct(item.product_id, item.product_attribute_id, item.id_order_detail);">Reorder
                                            </a>
                                            <a class="btn btn-secondary" data-ng-show="'OutofStock' === '{{item.prodStatus}}'" style="background-color: gainsboro;" data-toggle="modal" data-target="#reorderNotifyMe" data-ng-click="reorderNotifyMe(item.product_reference, item.product_name, item.ProdPrice, item.URL, item.DetailUrl, item.product_id, item.CustName, item.email);">Reorder
                                            </a>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #f1f4f7; text-align: right;">
                                        <td colspan="4">Sub Total
                                        </td>
                                        <td colspan="2">{{OrderDetailTbl0[0].SubTotal}}
                                        </td>
                                    </tr>
                                    <tr style="background-color: #f1f4f7; text-align: right;">
                                        <td colspan="4">Shipping & handling
                                        </td>
                                        <td colspan="2">{{OrderDetailTbl0[0].shippingamt}}
                                        </td>
                                    </tr>
                                    <tr style="background-color: #f1f4f7; text-align: right;">
                                        <td colspan="4">Discounts
                                        </td>
                                        <td colspan="2">{{OrderDetailTbl0[0].discountamt}}
                                        </td>
                                    </tr>
                                    <tr style="background-color: #f1f4f7; text-align: right;">
                                        <td colspan="4">Total
                                        </td>
                                        <td colspan="2">{{OrderDetailTbl0[0].OrderAmt}}
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="/appjs/dashboard.js"></script>
</asp:Content>


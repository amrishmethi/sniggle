<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- ...:::: Start Breadcrumb Section:::... -->
    <div class="breadcrumb-section breadcrumb-bg-color--golden">
        <div class="breadcrumb-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h3 class="breadcrumb-title">Checkout</h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li><a href="#">Checkout</a></li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ...:::: End Breadcrumb Section:::... -->
    <!-- ...:::: Start Account Dashboard Section:::... -->
    <div class="account-dashboard" data-ng-controller="shoppingCartController">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <!-- Tab panes -->
                    <div class="tab-content dashboard_content" data-aos="fade-up" data-aos-delay="200">
                        <div class="tab-pane fade active" id="Payment">
                            <h4>Payment</h4>
                            <%--<label id="lblName">snigglejpr@gmail.com</label>--%>
                            <div class="table_page table-responsive">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Image</th>
                                            <th>Description</th>
                                            <th>Qty</th>
                                            <th>Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr data-ng-repeat="c in carts">
                                            <td><span class="product-image media-middle">
                                                <img data-ng-src="{{c.Image1}}" width="100px" height="80" />
                                            </span></td>
                                            <td>
                                                <div class="product-line-info">
                                                    <a class="product_name" href="{{c.DetailUrl}}" data-id_customization="0" style="width: 100%; margin-bottom: 6px;">{{c.ProdName}}</a>
                                                </div>
                                                <div class="product-line-info">
                                                    <span class="product_name">{{c.Attribute}}</span>
                                                </div>
                                                <div class="product-line-info product-price-and-shipping product-price h5 has-discount">
                                                    <del data-ng-hide="{{c.Price === c.DisPrice}}" class="regular-price ">{{c.Price | number : 2}}</del>
                                                    <span class="price   price-sale ">{{c.DisPrice | number : 2}}</span>
                                                </div>
                                                <div class="product-line-info" ng-hide="{{c.Availability == ''}}">
                                                    <span class="product_name" style="background-color: indianred; color: white; padding: 2px 5px 2px 5px; font-size: 18px; font-weight: bold;">{{c.Availability}}</span>
                                                </div>
                                                <div class="product-line-info" style="display: none">
                                                    <span class="label">Color:</span>
                                                    <span class="value">White</span>
                                                </div>
                                            </td>
                                            <td style="width: 160px;">
                                                <div class="qty">
                                                    {{c.Qty}}
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-md-6 col-xs-2 price">
                                                    <div class="product-line-info product-price-and-shipping product-price h5 has-discount">
                                                        <span class="price   price-sale ">₹ {{c.Amount | number : 2}}</span>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                            <th><b>Sub Total</b></th>
                                            <td class="float-right"><b class="value">₹ {{carts[0]["TotalAmount"] | number : 2}}</b>&nbsp;</td>
                                        </tr>
                                        <tr data-ng-show="carts[0].Shipping!=0.00">
                                            <td colspan="3">&nbsp;</td>
                                            <th><b>Shipping Cost</b></th>
                                            <td class="float-right"><b class="value">₹ {{carts[0]["Shipping"] | number : 2}}</b>&nbsp;</td>
                                        </tr>
                                        <tr data-ng-show="carts[0].CouponDiscount!=0.00">
                                            <td colspan="2">&nbsp;</td>
                                            <th><b>Discount</b></th>
                                            <td class="float-right"><b class="value">-₹ {{carts[0]["CouponDiscount"] | number : 2}}</b>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                            <td>
                                                <h4>TOTAL</h4>
                                            </td>
                                            <td class="float-right">
                                                <h4 class="value">₹ {{carts[0]["NetAmount"] | number : 2}}</h4>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                            <div class="cart_submit" role="tablist">
                                <a class="btn btn-md btn-golden float-left" href="/">Continue Shopping</a> 
                                <a data-ng-show="carts[0].NetAmount > 0" class="btn btn-md btn-golden center-center" href="/CODSuccess.aspx">Cash On Delivery</a> &nbsp;&nbsp;
                                <a data-ng-show="carts[0].NetAmount > 0" runat="server" class="btn btn-md btn-golden float-right" onclick='payNow();'>I CONFIRM MY ORDER</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input id="hddOrderId" runat="server" type="hidden" />
    <!-- ...:::: End Account Dashboard Section:::... -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="/appjs/shoppingCart.js"></script>
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <script>
        //var ddd = ₹ ('#ContentPlaceHolder1_hddPaymentAmt').text();
        //var amount = $('#ContentPlaceHolder1_lblPaymentAmt').text();
        //amount = parseFloat(amount) * 100;
        var descc = "SNIGGLE";
        var oid = $('#content_hddOrderId').val();
        var options = {
            "name": "SNIGGLE",
            "description": "SNIGGLE",
            "image": "https://cdn.razorpay.com/logos/7K3b6d18wHwKzL_medium.png",
            "order_id": oid,
            "callback_url": "https://sniggle.in//PaySuccess.aspx",
            "prefill": {
                "name": "",
                "email": "",
                "contact": ""
            },
            "notes": {
                "address": "Razorpay Corporate Office"
            },
            "theme": {
                "color": "#6A59CE"
            }
        };
        var rzp1 = new Razorpay(options);
        function payNow() { 
            var ss = $('#lblName').html();
            rzp1.open();
        }
    </script>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- ...:::: Start Breadcrumb Section:::... -->
    <div class="breadcrumb-section breadcrumb-bg-color--golden">
        <div class="breadcrumb-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h3 class="breadcrumb-title">My Cart</h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li><a href="#">My Cart</a></li>
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
                <div class="col-sm-12 col-md-3 col-lg-3">
                    <!-- Nav tabs -->
                    <div class="dashboard_tab_button" data-aos="fade-up" data-aos-delay="0">
                        <ul role="tablist" class="nav flex-column dashboard-list">
                            <li><a href="#summery" data-bs-toggle="tab"
                                class="nav-link btn btn-block btn-md btn-black-default-hover active summery">Summary</a>
                            </li>
                            <li><a id="aAddress" data-bs-toggle="tab"
                                class="nav-link btn btn-block btn-md btn-black-default-hover Address">Address</a></li>
                            <li><a id="aPayment" data-bs-toggle="tab"
                                class="nav-link btn btn-block btn-md btn-black-default-hover Payment">Payment</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-sm-12 col-md-9 col-lg-9">
                    <!-- Tab panes -->
                    <div class="tab-content dashboard_content" data-aos="fade-up" data-aos-delay="200">
                        <div class="tab-pane fade active" id="summery">
                            <div class="table_page table-responsive">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Image</th>
                                            <th>Description</th>
                                            <th>Qty</th>
                                            <th>Total</th>
                                            <th>Actions</th>
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
                                                <div class="product-line-info" data-ng-show="c.cust_msg">
                                                    <a class="link-info" href="img/CustomizeOrder/{{c.cust_msg}}" target="_blank">View Your Personalize Image</a> 
                                                </div>
                                                <div class="product-line-info">
                                                    <span class="product_name">{{c.Attribute}}</span>
                                                </div>
                                                <div class="product-line-info product-price-and-shipping product-price h5 has-discount">
                                                    <del data-ng-hide="{{c.Price === c.DisPrice}}" class="regular-price ">₹ {{c.Price | number : 2}}</del>
                                                    <span class="price   price-sale ">₹ {{c.DisPrice | number : 2}}</span>
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
                                                    <a href="javaScript:void(0)" ng-click="removeQty(c.AttributeID, c.minimal_quantity,c.Qty);" class="btn btn-light" style="width: 30px; float: left; margin-right: 5px;">-</a>
                                                    <input
                                                        type="text"
                                                        name="Qty"
                                                        id="Qty"
                                                        value='{{c.Qty}}'
                                                        class="form-control"
                                                        min='{{c.Qty}}' style="width: 60px; float: left; padding: 8px 5px;" ng-blur="cartQtyChangenew(c.AttributeID, c.ProdID,c.Qty, c.minimal_quantity);" ng-model='c.Qty' />
                                                    &nbsp;
                                                                <a href="javaScript:void(0)" ng-click="addQty(c.AttributeID, c.ProdID,c.Qty);" class="btn btn-light" style="width: 30px; float: left; margin-left: 1px;">+</a>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-md-6 col-xs-2 price">
                                                    <div class="product-line-info product-price-and-shipping product-price h5 has-discount">
                                                        <span class="price   price-sale ">₹ {{c.Amount | number : 2}}</span>
                                                    </div>
                                                </div>
                                            </td>

                                            <td>
                                                <a href="#" data-ng-click="delCart(c.AttributeID)" title="Remove Item"><i class="fa fa-trash-o"></i></a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="cart_submit" role="tablist">
                                <a class="btn btn-md btn-golden float-left" href="/">Continue Shopping</a>
                                <a id="aLogin" runat="server" class="btn btn-md btn-golden float-right" href="/login">Checkout</a>
                                <a id="aNext" runat="server" class="btn btn-md btn-golden float-right" data-ng-click="pCheckout('Address')">Checkout</a>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="Address">
                            <h4>Address</h4>
                            <div class="table_page table-responsive">
                                <div class="container">
                                    <div class="row">
                                        <asp:DropDownList ID="drpShippingAddress" runat="server" CssClass="col-md-6" onchange="getShippingAddress();"></asp:DropDownList>
                                    </div>
                                    <div class="row" style="display: none;">
                                        <asp:DropDownList ID="drpBillingAddress" runat="server" CssClass="col-md-6 hide" onchange="getBillingAddress();" Style="display: none;"></asp:DropDownList>
                                        <div class="col-md-12">
                                            <input id="chk" name="psgdpr" type="checkbox" value="1" onchange="getCommonAddress();" required checked="checked" class="float-left" />
                                            Use the delivery address as the billing address.
                                        </div>
                                        <asp:Label ID="lblAddressQty" runat="server" Text="0" Style="display: none;"></asp:Label>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <!--login area start-->
                                        <div class="col-lg-6 col-md-6">
                                            <div class="account_form" data-aos="fade-up" data-aos-delay="0">
                                                <div style="border: 1px solid #ededed; padding: 23px 20px 29px; border-radius: 5px;">
                                                    <div class="default-form-box">
                                                        <h4>Your delivery address</h4>
                                                    </div>
                                                    <div class="default-form-box">
                                                        <span id="spShipping">
                                                            <p>{{ShipAddressDetail[0].firstname}} {{ShipAddressDetail[0].lastname}}</p>
                                                            <p ng-show="ShipAddressDetail[0].company">{{ShipAddressDetail[0].company}}</p>
                                                            <p>{{ShipAddressDetail[0].address1}} {{ShipAddressDetail[0].address2}} </p>
                                                            <p>
                                                                {{ShipAddressDetail[0].city}}, 
                                                                    <span ng-hide="{{ShipAddressDetail[0].State == null}}">{{ShipAddressDetail[0].State}}, </span>{{ShipAddressDetail[0].postcode}}, {{ShipAddressDetail[0].Country}}
                                                            </p>
                                                            <p>{{ShipAddressDetail[0].phone_mobile}}</p>
                                                            <p>{{ShipAddressDetail[0].phone}}</p>
                                                            <p>{{ShipAddressDetail[0].other}}</p>
                                                        </span>
                                                    </div>
                                                    <div class="login_submit dUpdate">
                                                        <input type="hidden" class="hidden" name="back" value="my-account">
                                                        <a href="AddAddress.aspx?addid={{ShipAddressDetail[0].id_address}}" class="btn btn-md btn-black-default-hover mb-4">UPDATE  </a>
                                                        <input type="hidden" class="hidden" name="SubmitCreate" value="Create an account">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-6">
                                            <div class="account_form" data-aos="fade-up" data-aos-delay="0">
                                                <div style="border: 1px solid #ededed; padding: 23px 20px 29px; border-radius: 5px;">
                                                    <div class="default-form-box">
                                                        <h4>Your billing address</h4>
                                                    </div>
                                                    <div class="default-form-box">
                                                        <span id="spBilling">
                                                            <p>{{BillAddressDetail[0].firstname}} {{ShipAddressDetail[0].lastname}}</p>
                                                            <p ng-show="ShipAddressDetail[0].company">{{BillAddressDetail[0].company}}</p>
                                                            <p>{{BillAddressDetail[0].address1}} {{ShipAddressDetail[0].address2}} </p>
                                                            <p>
                                                                {{BillAddressDetail[0].city}}, 
                                                                     <span ng-hide="{{BillAddressDetail[0].State == null}}">{{ShipAddressDetail[0].State}}, </span>{{BillAddressDetail[0].postcode}}, {{BillAddressDetail[0].Country}}
                                                            </p>
                                                            <p>{{BillAddressDetail[0].phone_mobile}}</p>
                                                            <p>{{BillAddressDetail[0].phone}}</p>
                                                            <p>{{BillAddressDetail[0].other}}</p>
                                                        </span>
                                                    </div>
                                                    <div class="login_submit dUpdate">
                                                        <input type="hidden" class="hidden" name="back" value="my-account">
                                                        <a href="AddAddress.aspx?addid={{BillAddressDetail[0].id_address}}" class="btn btn-md btn-black-default-hover mb-4">UPDATE  </a>
                                                        <input type="hidden" class="hidden" name="SubmitCreate" value="Create an account">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="cart_submit" role="tablist">
                                            <a href="/AddAddress.aspx?addid=0" class="btn btn-md btn-golden float-left">ADD NEW ADDRESS</a>
                                            <a href="javaScript:void(0)" data-ng-if="ShipAddressDetail[0].firstname" data-ng-click="getAddress();" class="btn btn-md btn-golden float-right">Continue</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="Payment">
                            <h4>Payment</h4>
                            <div class="table_page table-responsive">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Image</th>
                                            <th>Description</th>
                                            <th>Qty</th>
                                            <th>Total</th>
                                            <th>Actions</th>
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
                                                    <del data-ng-hide="{{c.Price === c.DisPrice}}" class="regular-price ">₹ {{c.Price | number : 2}}</del>
                                                    <span class="price   price-sale ">₹ {{c.DisPrice | number : 2}}</span>
                                                </div>
                                                <div class="product-line-info" ng-hide="{{c.Availability == ''}}">
                                                    <span class="product_name" style="background-color: indianred; color: white; padding: 2px 5px 2px 5px; font-size: 18px; font-weight: bold;">{{c.Availability}}</span>
                                                </div>
                                            </td>
                                            <td style="width: 160px;">
                                                <div class="qty">
                                                    <a href="javaScript:void(0)" ng-click="removeQty(c.AttributeID, c.minimal_quantity,c.Qty);" class="btn btn-light" style="width: 30px; float: left; margin-right: 5px;">-</a>
                                                    <input
                                                        type="text"
                                                        name="Qty"
                                                        id="Qty"
                                                        value='{{c.Qty}}'
                                                        class="form-control"
                                                        min='{{c.Qty}}' style="width: 60px; float: left; padding: 8px 5px;" ng-blur="cartQtyChangenew(c.AttributeID, c.ProdID,c.Qty, c.minimal_quantity);" ng-model='c.Qty' />
                                                    &nbsp;
                                                                <a href="javaScript:void(0)" ng-click="addQty(c.AttributeID, c.ProdID,c.Qty);" class="btn btn-light" style="width: 30px; float: left; margin-left: 1px;">+</a>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-md-6 col-xs-2 price">
                                                    <div class="product-line-info product-price-and-shipping product-price h5 has-discount">
                                                        <span class="price   price-sale ">{{c.Amount | number : 2}}</span>
                                                    </div>
                                                </div>
                                            </td>

                                            <td>
                                                <a href="#" data-ng-click="delCart(c.AttributeID)" title="Remove Item"><i class="fa fa-trash-o"></i></a>
                                            </td>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="3">&nbsp;</td>
                                            <th><b>Sub Total</b></th>
                                            <td class="float-right"><b class="value">₹ {{carts[0]["TotalAmount"] | number : 2}}</b>&nbsp;</td>
                                        </tr>
                                        <tr data-ng-show="carts[0].Shipping!=0.00">
                                            <td colspan="3">&nbsp;</td>
                                            <th><b>Shipping Cost</b></th>
                                            <td class="float-right"><b class="value">₹ {{carts[0]["Shipping"] | number : 2}}</b>&nbsp;</td>
                                        </tr>
                                        <tr data-ng-show="carts[0].CouponDiscount!=0.00">
                                            <td colspan="3">&nbsp;</td>
                                            <th><b>Discount</b></th>
                                            <td class="float-right"><b class="value">-₹ {{carts[0]["CouponDiscount"] | number : 2}}</b>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">&nbsp;</td>
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
                                <a href="Checkout.aspx" class="btn btn-md btn-golden float-right">CHECKOUT</a>
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
    <script src="/appjs/shoppingCart.js?v=1"></script>
    <%-- <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <script> 
        var descc = "SNIGGLE";
        var oid = $('#content_hddOrderId').val();
        var options = {
            "name": "SNIGGLE",
            "description": "SNIGGLE",
            "image": "https://cdn.razorpay.com/logos/7K3b6d18wHwKzL_medium.png",
            "order_id": oid,
            "callback_url": "https://sniggle.in/PaySuccess.aspx",
            "prefill": {
                "name": $('#content_lblName').html(),
                "phone": $('#content_lblMobileNo').html()
            },
            "notes": {
                "address": "Address"
            },
            "theme": {
                "color": "#6A59CE"
            }
        };
        var rzp1 = new Razorpay(options);
        function payNow() {
            rzp1.open();
        }
    </script>--%>
</asp:Content>


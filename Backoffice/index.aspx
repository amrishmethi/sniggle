<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Backoffice_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .col-lg-1 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }

        .col-lg-2 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }

        .col-lg-3 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }

        .col-lg-4 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }

        .col-lg-5 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }

        .col-lg-6 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }

        .col-lg-7 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }

        .col-lg-8 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }

        .col-lg-9 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">

    <!-- Breadcome start-->
    <div class="breadcome-area mg-b-30 small-dn">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcome-list map-mg-t-40-gl shadow-reset">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul class="breadcome-menu alignleft" style="margin-top: -21px;">
                                        <li><a href="Index.aspx">Dashboard</a>
                                        </li>
                                        <%--<li><span>Dashboard</span>
                                        </li>--%>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Dashboard</h1>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <%--<ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li><a href="addproduct.aspx">
                                            <h1 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h1>
                                            <br />
                                            <h5 style="float: left">Add new product</h5>
                                        </a>
                                        </li>
                                    </ul>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clearfix">&nbsp;</div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcome-list map-mg-t-30-gl shadow-reset">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <div class="list-group">
                                        <ul class="breadcome-menu alignleft" id="ullist">
                                            <li class="list-group-item active">
                                                <asp:LinkButton ID="btnDay" OnClientClick="addactiveclass()" runat="server" OnClick="btnDay_Click">Day</asp:LinkButton>
                                            </li>
                                            <li class="list-group-item">
                                                <asp:LinkButton ID="btnMonth" OnClientClick="addactiveclass()" runat="server" OnClick="btnMonth_Click">Month</asp:LinkButton>
                                                <%--  <a href=""></a>--%>
                                            </li>
                                            <li class="list-group-item">
                                                <asp:LinkButton ID="btnYear" OnClientClick="addactiveclass()" runat="server" OnClick="btnYear_Click">Year</asp:LinkButton>

                                            </li>
                                            <li class="list-group-item">
                                                <asp:LinkButton ID="btnDay1" OnClientClick="addactiveclass()" runat="server" OnClick="btnDay1_Click">Day-1</asp:LinkButton>

                                            </li>
                                            <li class="list-group-item">
                                                <asp:LinkButton ID="btnMonth1" OnClientClick="addactiveclass()" runat="server" OnClick="btnMonth1_Click">Month-1</asp:LinkButton>

                                            </li>
                                            <li class="list-group-item">
                                                <asp:LinkButton ID="btnYear1" OnClientClick="addactiveclass()" runat="server" OnClick="btnYear1_Click">Year-1</asp:LinkButton>

                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <div class="row">
                                            <div class="col-lg-1">&nbsp;</div>
                                            <div class="col-lg-5">
                                                <div class="input-mark-inner mg-b-22">
                                                    <div class="input-group">
                                                        <span class="input-group-addon">From</span>
                                                        <%--<input type="text" class="form-control" data-mask="99/99/9999" placeholder="">--%>
                                                        <asp:TextBox ID="txtFDate" CssClass="form-control datePicK" runat="server" data-mask="99/99/9999" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-5">
                                                <div class="input-group">
                                                    <span class="input-group-addon">To</span>
                                                    <asp:TextBox ID="txtTDate" CssClass="form-control datePicK" runat="server" data-mask="99/99/9999" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-1">
                                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn btn-default" OnClick="btnSearch_Click"><i class="fa fa fa-search"></i></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnDay" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnMonth" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnYear" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnDay1" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnMonth1" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnYear1" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcome End-->

    <!-- welcome Project, sale area start-->
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="welcome-adminpro-area">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12">
                            <div class="welcome-wrapper shadow-reset res-mg-t mg-b-30">
                                <div class="welcome-adminpro-title">
                                    <div class="welcome-adminpro-title">
                                        <br />
                                        <span class="badge" style="background-color: #00aff0; color: #efebf6; width: 100%; font-size: 14px; height: 40px; padding-top: 10px;">Currently Pending</span>
                                        <div class="adminpro-message-list">
                                            <ul class="message-list-menu">
                                                <li>
                                                    <a href="Orders.aspx"><span class="message-serial message-cl-one">1</span> <span class="message-info">Orders</span>
                                                        <span class="message-time">
                                                            <asp:Label ID="lblOrde" runat="server"></asp:Label></span>
                                                    </a>
                                                </li>
                                                <li>
                                                    <a href="CartList.aspx"><span class="message-serial message-cl-two">2
                                                    </span><span class="message-info">Abandoned Carts </span>
                                                        <span class="message-time">
                                                            <asp:Label ID="lblCart" runat="server"></asp:Label></span></a>
                                                </li>
                                               <%-- <li><a href="#"><span class="message-serial message-cl-three">3</span> <span class="message-info">Out Of Stock Products</span>
                                                    <span class="message-time">
                                                        <asp:Label ID="lblOutStock" runat="server"></asp:Label></span></a>
                                                </li>--%>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="welcome-adminpro-title">
                                        <br />
                                        <span class="badge" style="background-color: #00aff0; color: #efebf6; width: 100%; font-size: 14px; height: 40px; padding-top: 10px;">Notifications</span>

                                        <div class="adminpro-message-list">
                                            <ul class="message-list-menu">
                                                <li><a href="ContactUs.aspx"><span class="message-serial message-cl-one">1</span> <span class="message-info">Contact Us</span>
                                                    <span class="message-time">
                                                        <asp:Label ID="lblContact" runat="server"></asp:Label></span></a>
                                                </li>
                                                <li><a href="Request_Quote.aspx"><span class="message-serial message-cl-two">2</span> <span class="message-info">Request Quote</span>
                                                    <span class="message-time">
                                                        <asp:Label ID="lblRequest" runat="server"></asp:Label></span></a>
                                                </li>
                                                <li><a href="CustomOrder.aspx"><span class="message-serial message-cl-three">3</span> <span class="message-info">Custom Order</span>
                                                    <span class="message-time">
                                                        <asp:Label ID="lblCustom" runat="server"></asp:Label></span></a>
                                                </li>
                                                <li><a href="Enquire.aspx"><span class="message-serial message-cl-four">4</span> <span class="message-info">Enquire</span>
                                                    <span class="message-time">
                                                        <asp:Label ID="lblEnquire" runat="server"></asp:Label></span></a>
                                                </li>
                                                <li><a href="CreativeCutsEnquiry.aspx"><span class="message-serial message-cl-five">5</span> <span class="message-info">Creative Cuts Enquire</span>
                                                    <span class="message-time">
                                                        <asp:Label ID="lblcreative" runat="server"></asp:Label></span></a>
                                                </li>
                                                 <li><a href="ReOrder.aspx"><span class="message-serial message-cl-five">6</span> <span class="message-info">Reorder Enquire</span>
                                                    <span class="message-time">
                                                        <asp:Label ID="lblReOrder" runat="server"></asp:Label></span></a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="welcome-adminpro-title">
                                        <br />
                                        <span class="badge" style="background-color: #00aff0; color: #efebf6; width: 100%; font-size: 14px; height: 40px; padding-top: 10px;">Customers & Newsletters
                                
                                   <%-- <h6>(FROM 2021-01-01 TO 2021-01-11)</h6>--%>
                                        </span>
                                        <div class="adminpro-message-list">
                                            <ul class="message-list-menu">
                                                <li><a href="Customers.aspx"><span class="message-serial message-cl-one">1</span> <span class="message-info">New Customers</span>
                                                    <span class="message-time">
                                                        <asp:Label ID="lblNewCustomer" runat="server"></asp:Label></span></a>
                                                </li>
                                                <li><a href="Newsletter.aspx"><span class="message-serial message-cl-two">2</span> <span class="message-info">New Subscriptions </span>
                                                    <span class="message-time">
                                                        <asp:Label ID="lblSubscriptions" runat="server"></asp:Label></span></a>
                                                </li>
                                                <%--                                                <li><span class="message-serial message-cl-three">3</span>
                                                    <span class="message-info">Total Subscribers</span> <span class="message-time">
                                                        <asp:Label ID="lblTotalSubscribers" runat="server"></asp:Label></span>
                                                </li>--%>
                                            </ul>
                                        </div>
                                    </div>

                                    <%--<div class="welcome-adminpro-title">
                                <br />
                                <span class="badge" style="background-color: #00aff0; color: #efebf6; width: 100%; font-size: 14px; height: 40px; padding-top: 10px;">Traffic
                                     <h6>(FROM 2021-01-01 TO 2021-01-11)</h6>
                                </span>

                                <div class="adminpro-message-list">
                                    <ul class="message-list-menu">
                                        <li><span class="message-serial message-cl-one">1</span> <span class="message-info">Visits </span><span class="message-time">10</span>
                                        </li>
                                        <li><span class="message-serial message-cl-two">2</span> <span class="message-info">Unique Visitors</span><span class="message-time">10</span>
                                        </li>

                                    </ul>
                                </div>
                            </div>--%>
                                </div>


                            </div>
                        </div>
                        <div class="col-lg-8 col-md-6 col-sm-12 col-xs-12">
                            <div class="welcome-wrapper shadow-reset res-mg-t mg-b-30">
                                <div class="row">
                                    <div class="list-group">
                                        <ul class="col-lg-12 col-md-6 col-sm-12 col-xs-12 breadcome-menu alignleft">
                                            <li class="col-lg-4 list-group-item" style="background-color: #ffffff; color: #c4b9b4; text-align: center;">
                                                <a href=""><span>Sale</span><br />
                                                    <br />
                                                    ₹<asp:Label ID="lblSale" runat="server"></asp:Label>
                                                    <%--<asp:Label ID="lblSaleComp" runat="server"></asp:Label>--%>
                                                    <%--<dd class="dash_trend dash_trend_up"><span style="color: #72c279">+3616.88%</span></dd>--%>
                                                </a>

                                            </li>
                                            <li class="col-lg-4 list-group-item" style="background-color: #ffffff; color: #c4b9b4; text-align: center;">
                                                <a href=""><span>Orders</span><br />
                                                    <br />
                                                    <asp:Label ID="lblOrder" runat="server"></asp:Label>
                                                    <%--<dd class="dash_trend dash_trend_up"><span style="color: #72c279">+3616.88%</span></dd>--%>
                                                </a>
                                            </li>
                                            <%-- <li class="col-lg-3 list-group-item" style="background-color: #ffffff; color: #c4b9b4; text-align: center;">
                                        <a href=""><span>Cart Value</span><br />
                                            <br />
                                            10000
                                            <dd class="dash_trend dash_trend_up"><span style="color: #72c279">+3616.88%</span></dd>
                                        </a>
                                    </li>--%>
                                            <li class="col-lg-4 list-group-item" style="background-color: #ffffff; color: #c4b9b4; text-align: center;">
                                                <a href="Visiter.aspx"><span>Visits</span><br />
                                                    <br />
                                                    <asp:Label ID="lblVisite" runat="server" ></asp:Label>
                                            <%--<dd class="dash_trend dash_trend_up"><span style="color: #72c279">+3616.88%</span></dd>--%>
                                                </a>
                                            </li>

                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="sparkline-hd">
                                    <div class="main-spark-hd">
                                        <h1>Products and Sales </h1>
                                        <div class="outline-icon">
                                            <span class="collapse-link"><i class="fa fa-chevron-up"></i></span>
                                            <span><i class="fa fa-wrench"></i></span>
                                            <span class="collapse-close"><i class="fa fa-times"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <section id="dashproducts" class="panel widget  allow_push loading">
                                    <section>
                                        <nav>
                                            <ul class="nav nav-pills">
                                                <li class="active">
                                                    <a href="#dash_recent_orders" data-toggle="tab">
                                                        <i class="icon-fire"></i>
                                                        <span class="hidden-inline-xs">Recent Orders</span>
                                                    </a>
                                                </li>
                                                <li class="">
                                                    <a href="#dash_best_sellers" data-toggle="tab">
                                                        <i class="icon-trophy"></i>
                                                        <span class="hidden-inline-xs">Best Selling Product</span>
                                                    </a>
                                                </li>
                                                <li class="">
                                                    <a href="#dash_most_viewed" data-toggle="tab">
                                                        <i class="icon-eye-open"></i>
                                                        <span class="hidden-inline-xs">Most Viewed</span>
                                                    </a>
                                                </li>

                                            </ul>
                                        </nav>
                                        <div class="sparkline9-graph dashone-comment">
                                            <div class="datatable-dashv1-list custom-datatable-overright dashtwo-project-list-data">
                                                <div class="tab-content panel">
                                                    <div class="tab-pane active" id="dash_recent_orders">

                                                        <div class="table-responsive">
                                                            <table class="table data_table" id="table_recent_orders">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="text-left">Customer Name</th>
                                                                        <th class="text-center">Products</th>
                                                                        <th class="text-center">Total Tax excl.</th>
                                                                        <th class="text-center">Date</th>
                                                                        <th class="text-center">Status</th>
                                                                        <th class="text-right"></th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <asp:Repeater ID="repOrder" runat="server">
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td class="text-left " id="firstname_lastname"><a class="btn btn-link" href='ViewCustomers.aspx?id=<%#Eval("id_customer") %>'><%#Eval("customer") %></a></td>
                                                                                <td class="text-center" id="total_products"><%#Eval("PCount") %></td>
                                                                                <td class="text-center" id="total_paid">₹<%#Eval("total_paid_tax_incl") %></td>
                                                                                <td class="text-center" id="date_add"><%#Eval("date_add") %></td>
                                                                                <td class="text-center" id="status"><%#Eval("osname") %></td>
                                                                                <td class="text-right" id="details"><a class="btn btn-default" href='ViewOrder.aspx?id=<%#Eval("id_order") %>' title="Details"><i class=" fa fa fa-search"></i></a></td>
                                                                            </tr>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane" id="dash_best_sellers">
                                                        <%--  <h3>Top 10 products
					<span>From 01/01/2021 to 11/01/2021</span>
                                                </h3>--%>
                                                        <div class="table-responsive">
                                                            <table class="table data_table" id="table_best_sellers">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="text-center">Image</th>
                                                                        <th class="text-center">Product</th>
                                                                        <th class="text-center">Category</th>
                                                                        <th class="text-center">Qty.</th>
                                                                        <th class="text-center">Sales</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <asp:Repeater ID="repBestSeller" runat="server">
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td class="text-center ">
                                                                                    <img src='<%#Eval("ImageUrl") %>' height="50px" width="50px" /></td>
                                                                                <td class="text-center "><a class="btn btn-link" href="#"><%#Eval("PrdName") %></a></td>
                                                                                <td class="text-center"><%#Eval("CatName") %></td>
                                                                                <td class="text-center"><%#Eval("Qty") %></td>
                                                                                <td class="text-center">₹<%#Eval("Total") %></td>
                                                                            </tr>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane" id="dash_most_viewed">
                                                        <h3>Most Viewed
					<span></span>
                                                        </h3>
                                                        <div class="table-responsive">
                                                            <table class="table data_table" id="table_most_viewed">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="text-center" id="image">Image</th>
                                                                        <th class="text-center" id="product">Product</th>
                                                                        <th class="text-center" id="views">Views</th>
                                                                        <th class="text-center" id="added_to_cart">Added to cart</th>
                                                                        <th class="text-center" id="purchased">Purchased</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <asp:Repeater ID="repMostView" runat="server">
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td class="text-center ">
                                                                                    <img src='<%#Eval("ImageUrl") %>' height="50px" width="50px" /></td>
                                                                                <td class="text-center" id="product"><%#Eval("name") %><br>
                                                                                    ₹<%#Eval("price") %></td>
                                                                                <td class="text-center" id="views"><%#Eval("PViews") %></td>
                                                                                <td class="text-center" id="added_to_cart"><%#Eval("cart") %></td>
                                                                                <td class="text-center" id="purchased"><%#Eval("Purchase") %></td>
                                                                            </tr>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>

                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </section>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnDay" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnMonth" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnYear" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDay1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnMonth1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnYear1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datePicK").datepicker({
                inline: true,
                changeMonth: true,
                changeYear: true,

                dateFormat: 'dd/mm/yy'

            });
        });
    </script>
    <script>
        function addactiveclass() {
            $('ul#ullist li').click(function () {
                $('li.active').removeClass('active');
                $(this).addClass('active');
            });
        }
    </script>
    <!-- input-mas JS
		============================================ -->
    <script src="../Admin/js/input-mask/jasny-bootstrap.min.js"></script>
</asp:Content>


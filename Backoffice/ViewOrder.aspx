<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewOrder.aspx.cs" Inherits="Backoffice_ViewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .switch-field {
            display: flex;
            margin-bottom: 36px;
            overflow: hidden;
        }

            .switch-field input {
                position: absolute !important;
                clip: rect(0, 0, 0, 0);
                height: 1px;
                width: 1px;
                border: 0;
                overflow: hidden;
            }

            .switch-field label {
                background-color: #e4e4e4;
                color: rgba(0, 0, 0, 0.6);
                font-size: 14px;
                line-height: 1;
                text-align: center;
                padding: 8px 16px;
                margin-right: -1px;
                border: 1px solid rgba(0, 0, 0, 0.2);
                box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.3), 0 1px rgba(255, 255, 255, 0.1);
                transition: all 0.1s ease-in-out;
            }

                .switch-field label:hover {
                    cursor: pointer;
                    background-color: #e08f95;
                }

            .switch-field input:checked + label {
                background-color: #2eacce;
                box-shadow: none;
            }

            .switch-field label:first-of-type {
                border-radius: 4px 0 0 4px;
            }

            .switch-field label:last-of-type {
                border-radius: 0 4px 4px 0;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <div class="admin-dashone-data-table-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcome-list map-mg-t-40-gl shadow-reset">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul class="breadcome-menu alignleft" style="margin-top: -21px;">
                                        <li>Orders <span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="Orders.aspx">Orders</a>
                                        </li>
                                    </ul>
                                </div>
                                <%--<div class="row">

                                    <h4 style="float: left">Orders</h4>
                                </div>--%>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <%-- <div class="row">
                                    <ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li><a href="#">
                                            <h1 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h1>
                                            <br />
                                            <h5 style="float: left">Add New Orders</h5>
                                        </a>
                                        </li>
                                    </ul>
                                </div>--%>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
            <div class="clearfix">&nbsp;</div>
            <div class="row">
                <div class="clearfix">&nbsp;</div>
                <div class="col-lg-12">
                    <div class="breadcome-list map-mg-t-40-gl shadow-reset">
                        <div class="row">
                            <div class="col-lg-3 col-md-2 col-sm-6 col-xs-6">
                                <ul class="breadcome-menu alignleft">
                                    <li>
                                        <%-- <h1 style="float: left; color: #2ba8e3"><i class="fa fa-power-off btn btn-button-success-ct" aria-hidden="true"></i></h1>--%>
                                        <h5 style="float: left; margin-left: 10px">Date</h5>
                                        <br />
                                        <h4 style="float: left; margin-left: 10px; color: #31a8e3">
                                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                                        </h4>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6">
                                <ul class="breadcome-menu alignleft">
                                    <li>
                                        <h5 style="float: left; margin-left: 10px">Total</h5>
                                        <br />
                                        <h4 style="float: left; margin-left: 10px; color: #31a8e3">
                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                        </h4>

                                    </li>

                                </ul>
                            </div>

                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6">
                                <ul class="breadcome-menu alignleft">
                                    <li>
                                        <h5 style="float: left; margin-left: 10px">Messages</h5>
                                        <br />
                                        <h4 style="float: left; margin-left: 10px; color: #31a8e3">
                                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                        </h4>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-lg-2 col-md-3 col-sm-6 col-xs-6">
                                <ul class="breadcome-menu alignleft">
                                    <li>
                                        <h5 style="float: left; margin-left: 10px">Products</h5>
                                        <br />
                                        <h4 style="float: left; margin-left: 10px; color: #31a8e3">
                                            <asp:Label ID="lblProduct" runat="server"></asp:Label>
                                        </h4>
                                    </li>
                                </ul>
                            </div>

                            <div class="col-lg-1 col-md-1 col-sm-6 col-xs-6">
                                <ul class="breadcome-menu alignright">
                                    <%-- <li>
                                                    <h1 style="float: left; color: #cbcbcb"><i class="fa fa-refresh " aria-hidden="true"></i></h1>

                                                </li>--%>
                                </ul>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-lg-12">
            &nbsp;
        </div>
        <div class="row">
            <div class="col-lg-6">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <ul class="nav nav-tabs" id="tabOrder">

                        <li class="active">
                            <a href="#status">
                                <i class="icon-time"></i>
                                Status <span class="badge">
                                    <asp:Label ID="lblStatusCount" runat="server"></asp:Label></span>
                            </a>
                        </li>
                        <%--<li>
                            <a href="#documents">
                                <i class="icon-file-text"></i>
                                Documents <span class="badge">
                                    <asp:Label ID="lblDocCount" runat="server"></asp:Label></span>
                            </a>
                        </li>--%>
                    </ul>
                    <div class="tab-content panel">

                        <!-- Tab status -->
                        <div class="tab-pane active" id="status">
                            <h4 class="visible-print">Status <span class="badge">
                                <asp:Label ID="lblTotStatus" runat="server"></asp:Label></span></h4>
                            <!-- History of status -->
                            <div class="table-responsive">
                                <table class="table" id="documents_table">
                                    <asp:Repeater ID="repStatus" runat="server" OnItemDataBound="repStatus_ItemDataBound" OnItemCommand="repStatus_ItemCommand">
                                        <ItemTemplate>


                                            <tr style="text-align: left">
                                                <td><%#Eval("name") %></td>
                                                <td><%#Eval("CName") %></td>
                                                <td><%#Eval("date_add") %></td>
                                                <td>
                                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("id_order_state") %>' Visible="false"></asp:Label>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Send" CssClass="btn btn-default"
                                                        CommandArgument='<%#Eval("id_order_state") %>'><i class="fa fa-reply" >  Resend email</i></asp:LinkButton></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                            <!-- Change status form -->
                            <div class="form-horizontal well hidden-print">
                                <div class="row">
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="drpStatus" runat="server" CssClass="chosen form-control"></asp:DropDownList>

                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Button ID="btnStatus" runat="server" OnClick="btnStatus_Click" CssClass="btn btn-primary" Text=" Update status" />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-lg-6">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <ul class="nav nav-tabs" id="myTab">

                        <li class="active">
                            <a href="#shipping">
                                <i class="icon-truck "></i>
                                Shipping <span class="badge">
                                    <asp:Label ID="lblShippingCount" runat="server"></asp:Label></span>
                            </a>
                        </li>
                        <%-- <li class="">
                            <a href="#Tracking">
                                <i class="icon-undo"></i>
                                Tracking Details <span class="badge"></span>
                            </a>
                        </li>--%>
                    </ul>
                    <div class="tab-content panel">

                        <!-- Tab shipping -->
                        <div class="tab-pane active" id="shipping">
                            <h4 class="visible-print">Shipping <span class="badge">
                                <asp:Label ID="lblShipping" runat="server"></asp:Label></span></h4>
                            <!-- Shipping block -->
                            <div class="form-horizontal">
                                <div class="table-responsive">
                                    <table class="table" id="shipping_table">
                                        <thead>
                                            <tr>
                                                <th>
                                                    <span class="title_box ">Date</span>
                                                </th>

                                                <th>
                                                    <span class="title_box ">Carrier</span>
                                                </th>
                                                <%-- <th>
                                                    <span class="title_box ">Weight</span>
                                                </th>--%>
                                                <th>
                                                    <span class="title_box ">Shipping cost</span>
                                                </th>
                                                <th>
                                                    <span class="title_box ">Tracking number</span>
                                                </th>
                                                <th>
                                                    <span class="title_box ">Link</span>
                                                </th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>

                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control dpk"></asp:TextBox>
                                                    <asp:Label ID="lblDateC" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpCarrier" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    <asp:Label ID="lblCarrier" runat="server"></asp:Label>
                                                </td>
                                                <td>

                                                    <asp:Label ID="lblCost" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTrackingNo" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:Label ID="lblTrackingNo" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtLink" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:Label ID="lblLink" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnTracking" runat="server" Text="Update" CssClass="btn btn-primary" Visible="false" OnClick="btnTracking_Click" />
                                                    <asp:Button ID="tbnTracEdit" runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="tbnTracEdit_Click" />
                                                </td>
                                            </tr>
                                            <%-- <asp:Repeater ID="repShippin" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("date_add") %> </td>
                                                        <td><%#Eval("name") %> </td>
                                                        <td class="weight"><%#Eval("weight") %></td>
                                                        <td class="center">$ <%#Eval("shipping_cost_tax_excl") %> 
                                                        </td>
                                                        <td>
                                                            <span class="shipping_number_show"><%#Eval("tracking_number") %></span>
                                                        </td>

                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>--%>
                                        </tbody>
                                    </table>
                                </div>

                            </div>
                        </div>
                        <%-- <div class="tab-pane" id="Tracking">
                            <h4 class="visible-print">Tracking Details <span class="badge">
                                <asp:Label ID="Label1" runat="server"></asp:Label></span></h4>
                            <!-- Shipping block -->
                            <div class="form-horizontal">
                                <div class="table-responsive">
                                    <table class="table" id="shipping_table">
                                        <thead>
                                            <tr>
                                                <th>
                                                    <span class="title_box ">Date</span>
                                                </th>

                                                <th>
                                                    <span class="title_box ">Company Name</span>
                                                </th>
                                                <th>
                                                    <span class="title_box ">Tracking Number</span>
                                                </th>
                                                <th>
                                                    <span class="title_box ">Link</span>
                                                </th>
                                                
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                           <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><asp:TextBox ID="txtDate" runat="server" CssClass="form-control"></asp:TextBox> </td>
                                                        <td><asp:TextBox ID="txtCompany" runat="server" CssClass="form-control"></asp:TextBox> </td>
                                                        <td ><asp:TextBox ID="txtTrackingNo" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td ><asp:TextBox ID="txtLink" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnTracking" runat="server" Text="Update" CssClass="btn btn-primary" />
                                                        </td>

                                                    </tr>
                                               </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
                                </div>

                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">&nbsp</div>

        <div class="row">
            <div class="col-lg-6">
                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <!-- Customer informations -->
                    <div class="panel">
                        <div class="panel-heading text-uppercase">
                            <i class="icon-user"></i>
                            Customer
						<span class="badge">
                            <a runat="server" id="ancCustomerID" style="color: white;">
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label></a>
                        </span>
                            <%--  <span class="badge">#11
                            </span>--%>
                        </div>
                        <div class="row">
                            <div class="col-xs-6">
                                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                                    <div style="margin-left: 10px; padding: 10px; border: 2px; border-color: #25b9d7;">
                                        <dl class="">
                                            <dt>Email</dt>
                                            <dd>
                                                <a runat="server" id="ancEmail" style="color: #0077a4"><i class="icon-envelope-o"></i>
                                                    <asp:Label ID="lblEmail" runat="server"></asp:Label></a>

                                            </dd>
                                            <dt>Account registered</dt>
                                            <dd class="text-muted"><i class="icon-calendar-o"></i>
                                                <asp:Label ID="lblRegisDate" runat="server"></asp:Label></dd>
                                            <dt>Valid orders placed</dt>
                                            <dd><span class="badge">
                                                <asp:Label ID="lblValidOrder" runat="server"></asp:Label></span></dd>
                                            <dt>Total spent since registration</dt>
                                            <dd><span class="badge badge-success">₹<asp:Label ID="lblTotalSpain" runat="server"></asp:Label></span></dd>
                                        </dl>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Tab nav -->
                    </div>


                </div>
            </div>
            <div class="col-lg-6">
                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="panel">
                        <ul class="nav nav-tabs" id="tabAddresses">
                            <li class="active">
                                <a href="#addressShipping">
                                    <i class="icon-truck"></i>
                                    Shipping address
                                </a>
                            </li>
                            <li>
                                <a href="#addressInvoice">
                                    <i class="icon-file-text"></i>
                                    Invoice address
                                </a>
                            </li>
                        </ul>
                        <!-- Tab content -->
                        <div class="tab-content panel">
                            <!-- Tab status -->
                            <div class="tab-pane  in active" id="addressShipping">
                                <!-- Addresses -->
                                <h4 class="visible-print">Shipping address</h4>
                                <!-- Shipping address -->


                                <div class="row">
                                    <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                                        <div class="col-sm-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-sm-4">
                                            <br />
                                            <asp:Label ID="lblName" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblCompany" runat="server"></asp:Label><br />
                                            <asp:Literal ID="ltrAddress" runat="server"></asp:Literal><br />
                                            <asp:Label ID="lblCityandPin" runat="server"></asp:Label><br />
                                            <asp:Literal ID="lblState" runat="server"></asp:Literal><br />
                                            <asp:Label ID="lblPinCode" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblCountry" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblPhone" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblMobile" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblAdditional" runat="server"></asp:Label><br />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 hidden-print">
                                        <div id="map-delivery-canvas" style="height: 190px"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane " id="addressInvoice">
                                <!-- Invoice address -->
                                <h4 class="visible-print">Invoice address</h4>

                                <div class="row">

                                    <div class="col-sm-2">
                                        &nbsp;
                                    </div>
                                    <div class="col-sm-4">
                                        <br />
                                        <asp:Label ID="lblNameB" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblCompanyB" runat="server"></asp:Label><br />
                                        <asp:Literal ID="ltrAddressB" runat="server"></asp:Literal><br />
                                        <asp:Label ID="lblCityandPinB" runat="server"></asp:Label><br />
                                        <asp:Literal ID="lblStateB" runat="server"></asp:Literal><br />
                                        <asp:Label ID="lblPinCodeB" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblCountryB" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblPhoneB" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblMobileB" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblAdditionalB" runat="server"></asp:Label><br />
                                    </div>
                                    <div class="col-sm-6 hidden-print">
                                        <div id="map-delivery-canvas" style="height: 190px"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">&nbsp;</div>
        <div class="row">
            <div class="col-lg-6">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">

                    <div class="tab-content panel">

                        <!-- Tab shipping -->
                        <div class="tab-pane active">
                            <div class="sparkline13-hd">
                                <div class="main-sparkline13-hd">
                                    <h4><span class="table-project-n">PAYMENT</span>
                                        <asp:Label ID="lblPaymentCount" runat="server"></asp:Label></h4>
                                    <div class="sparkline13-outline-icon">
                                        <span class="sparkline13-collapse-link"><i class="fa fa-chevron-up"></i></span>
                                        <span><i class="fa fa-wrench"></i></span>
                                        <span class="sparkline13-collapse-close"><i class="fa fa-times"></i></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-horizontal">
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th>
                                                    <span class="title_box ">Date</span>
                                                </th>

                                                <th>
                                                    <span class="title_box ">Payment method</span>
                                                </th>
                                                <th>
                                                    <span class="title_box ">Reference ID</span>
                                                </th>
                                                <th>
                                                    <span class="title_box ">Amount</span>
                                                </th>
                                                <th>
                                                    <span class="title_box ">Invoice</span>
                                                </th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="repPayment" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("date_add") %> </td>
                                                        <td><%#Eval("payment_method") %> </td>
                                                        <td class="weight"><%#Eval("transaction_id") %></td>
                                                        <td class="center"><%#Eval("sign") %>  <%#Eval("amount") %> 
                                                        </td>
                                                        <td>
                                                            <span class="shipping_number_show"><%#Eval("invoice") %></span>
                                                        </td>

                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
                                </div>

                            </div>
                        </div>
                        <!-- Tab returns -->

                    </div>
                </div>
            </div>
            <div class="col-lg-6">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">

                    <div class="tab-content panel">

                        <!-- Tab shipping -->
                        <div class="tab-pane active">
                            <div class="sparkline13-hd">
                                <div class="main-sparkline13-hd">
                                    <h4><span class="table-project-n">MESSAGES </span>
                                        <asp:Label ID="lblMessageCount" runat="server"></asp:Label></h4>
                                    <div class="sparkline13-outline-icon">
                                        <span class="sparkline13-collapse-link"><i class="fa fa-chevron-up"></i></span>
                                        <span><i class="fa fa-wrench"></i></span>
                                        <span class="sparkline13-collapse-close"><i class="fa fa-times"></i></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-horizontal">
                                <div class="clearfix">&nbsp;</div>
                                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                                    <div style="margin-left: 10px; padding: 10px; border: 2px; border-color: #25b9d7;">
                                        <h6>
                                            <asp:Label ID="lblPaymentdate" runat="server"></asp:Label>
                                            -<b><asp:Label ID="lblpaymentC" runat="server"></asp:Label></b>  <span class="badge badge-info">Private</span></h6>
                                        <h6>
                                            <asp:Label ID="lblPaymentMess" runat="server"></asp:Label></h6>
                                    </div>
                                </div>
                                <div class="clearfix">&nbsp;</div>
                                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                                    <div style="margin-left: 10px; padding: 10px; border: 2px; border-color: #25b9d7;">
                                        <div class="form-horizontal">
                                            <div class="table-responsive">
                                                <table class="table">
                                                    <thead>
                                                        <tr>
                                                            <th>
                                                                <span class="title_box ">Email</span>
                                                            </th>

                                                            <th>
                                                                <span class="title_box ">Status</span>
                                                            </th>
                                                            <th>
                                                                <span class="title_box ">Sent Date</span>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="repMail" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td><%#Eval("template") %></td>
                                                                    <td><%#Eval("subject") %> </td>
                                                                    <td><%#Eval("Date") %> </td>
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
                        </div>
                        <!-- Tab returns -->

                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">&nbsp</div>
        <div class="row">
            <div class="col-lg-12">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="sparkline13-hd">
                        <div class="main-sparkline13-hd">
                            <h1><span class="table-project-n">Product Qty</span>
                                <asp:Label ID="lblCount" runat="server"></asp:Label></h1>
                            <div class="sparkline13-outline-icon">
                                <span class="sparkline13-collapse-link"><i class="fa fa-chevron-up"></i></span>
                                <span><i class="fa fa-wrench"></i></span>
                                <span class="sparkline13-collapse-close"><i class="fa fa-times"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="sparkline13-graph">
                        <div class="datatable-dashv1-list custom-datatable-overright">
                            <table id="table" data-toggle="table" data-toolbar="#toolbar">
                                <thead>
                                    <tr class="nodrag nodrop">
                                        <th style="width: 45%">
                                            <span class="title_box">Product
                                            </span>
                                        </th>
                                        <th style="width: 5%">
                                            <span class="title_box">Unit Price<br />
                                                (tax excluded.)
                                            </span>
                                        </th>
                                        <th style="width: 5%">
                                            <span class="title_box">Unit Price<br />
                                                (tax included.)
                                            </span>
                                        </th>
                                        <th style="width: 5%">
                                            <span class="title_box">Qty
                                            </span>
                                        </th>
                                        <th style="width: 5%">
                                            <span class="title_box">Refunded
                                            </span>
                                        </th>
                                        <th style="width: 5%">
                                            <span class="title_box">Returned
                                            </span>
                                        </th>
                                        <th style="width: 5%">
                                            <span class="title_box">Available<br />
                                                quantity
                                            </span>
                                        </th>
                                        <th style="width: 5%">
                                            <span class="title_box">Total<br />
                                                (tax included.)
                                            </span>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepOrderD" runat="server">
                                        <ItemTemplate>
                                            <tr class="highlighted odd selected-line">
                                                <td>
                                                    <a href='<%#Eval("DetailUrl") %>' style="color: #0077a4" target="_blank"><%#Eval("product_name") %></a>
                                                     <div class="<%#Eval("showCustImg") %>"><br />
                                                    <a class="badge" href="/img/CustomizeOrder/<%#Eval("CustomizeImg") %>" target="_blank">View Personalize Image</a> 
                                                </div> 
                                                </td>
                                                <td><%#Eval("unit_price_tax_excl") %>
                                                </td>
                                                <td><%#Eval("unit_price_tax_incl") %>
                                                </td>
                                                <td><%#Eval("product_quantity") %>
                                                </td>
                                                <td><%#Eval("product_quantity_refunded") %>
                                                </td>
                                                <td><%#Eval("product_quantity_return") %>
                                                </td>
                                                <td><%#Eval("product_quantity_in_stock") %>
                                                </td>
                                                <td><%#Eval("total_price_tax_incl") %>
                                                </td>
                                                <%-- <td ><%#Eval("pair") %>
                                                </td>--%>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>Products
                                        </td>
                                        <td>₹
                                            <asp:Label ID="lblProductCost" runat="server"></asp:Label>
                                        </td>
                                        <%-- <td ><%#Eval("pair") %>
                                                </td>--%>
                                    </tr>
                                    <tr style="border: 0; border-right-style: hidden;">
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="lblGift" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDis" runat="server"></asp:Label>
                                        </td>
                                        <%-- <td ><%#Eval("pair") %>
                                                </td>--%>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>Shipping
                                        </td>
                                        <td>₹
                                            <asp:Label ID="lblShiping" runat="server"></asp:Label>
                                        </td>
                                        <%-- <td ><%#Eval("pair") %>
                                                </td>--%>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td><b>Total</b>
                                        </td>
                                        <td><b>₹
                                            <asp:Label ID="lblTotalAmt" runat="server"></asp:Label></b>
                                        </td>
                                        <%-- <td ><%#Eval("pair") %>
                                                </td>--%>
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
    <script>
        $('#tabOrder a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        })
    </script>
    <script>
        $('#myTab a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        })
    </script>
    <script>
        $('#tabAddresses a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        })
    </script>
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
</asp:Content>


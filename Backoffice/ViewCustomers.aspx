<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewCustomers.aspx.cs" Inherits="Backoffice_ViewCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                                        <li><a href="Customers.aspx">Customers</a> <span class="bread-slash">/</span>
                                        </li>
                                        <li><span>Customers</span>
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
        </div>
        <div class="clearfix">&nbsp</div>
        <div class="row">

            <div class="col-lg-6">
                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="panel clearfix">
                        <div class=" header-title">
                            <a runat="server" id="AncCoustomer">
                                <i class="fa fa-user"></i>&nbsp;
                            <asp:Label ID="lblCName" runat="server" Style="color: black"></asp:Label>
                                -  </a>
                            <a runat="server" id="ancEmail" style="color: #0077a4"><i class="fa fa-envelope"></i>
                                <asp:Label ID="lblEmail" runat="server"></asp:Label></a>

                        </div>
                        <div class="form-horizontal">
                            <div class="row">
                                <label class="control-label col-lg-3">Social Title</label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                        <asp:Label ID="lblMr" runat="server"></asp:Label>.
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <label class="control-label col-lg-3">Age</label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                        <asp:Label ID="lblAge" runat="server"></asp:Label>
                                        years old (birth date:  
                                        <asp:Label ID="lblDOB" runat="server"></asp:Label>)
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <label class="control-label col-lg-3">Registration Date</label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                        <asp:Label ID="lblRegDate" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <%--<div class="row">
                                <label class="control-label col-lg-3">Last Visit</label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                        <asp:Label ID="lblLastVisitDate" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>--%>
                            <div class="row">
                                <label class="control-label col-lg-3">Language</label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                        <asp:Label ID="lblLang" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <label class="control-label col-lg-3">Registrations  </label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &nbsp; &nbsp;
                                        <span class="label label-danger">
                                            <i class="icon-remove"></i>
                                            Newsletter
                                        </span>
                                        <%--  &nbsp;
																	<span class="label label-danger">
                                                                        <i class="icon-remove"></i>
                                                                        &emsp;<asp:Label ID="lblOpt" runat="server"></asp:Label>
                                                                    </span>--%>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <label class="control-label col-lg-3">Latest Update</label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                        <asp:Label ID="lblUpdateDate" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <label class="control-label col-lg-3">Status</label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                        <span class="label label-success">
                                            <i class="icon-check"></i>

                                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                        </span>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel">
                        <div class="panel-heading">
                            <a href="Orders.aspx"><i class="fa fa-file"></i>&nbsp;ORDERS <span class="badge">

                                <asp:Label ID="lblOrdeCounr" runat="server"></asp:Label>
                            </span>
                            </a>
                        </div>
                        <div class="panel">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                                        <i class="icon-ok-circle icon-big"></i>
                                        Valid orders
								<span class="label label-success">
                                    <asp:Label ID="lblValid" runat="server"></asp:Label></span>
                                        for a total amount of $<asp:Label ID="Lalbltotalbel1" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                                        <i class="icon-exclamation-sign icon-big"></i>
                                        Invalid orders
								<span class="label label-danger">
                                    <asp:Label ID="lblInValid" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="center"><span class="title_box ">ID</span></th>
                                    <th><span class="title_box">Date</span></th>
                                    <th><span class="title_box">Payment</span></th>
                                    <th><span class="title_box">Status</span></th>
                                    <%--   <th><span class="title_box">Products</span></th>--%>
                                    <th><span class="title_box ">Total spent</span></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repOrder" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("id_order") %></td>
                                            <td><%#Eval("date_add") %></td>
                                            <td><%#Eval("payment") %></td>
                                            <td><%#Eval("osname") %></td>
                                            <td><%#Eval("total_paid_tax_incl") %></td>
                                            <%-- <td>$<%#Eval("id_order") %></td>--%>
                                            <td>
                                                <a class="btn btn-default" href='ViewOrder.aspx?id=<%#Eval("id_order") %>'>
                                                    <i class="icon-search"></i>View
                                                </a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>


                    </div>

                    <div class="panel">
                        <div class="panel-heading">
                            <a href="CartList.aspx"><i class="fa fa-shopping-cart"></i>Carts <span class="badge">
                                <asp:Label ID="lblCartTot" runat="server"></asp:Label></span></a>
                        </div>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th><span class="title_box">ID</span></th>
                                    <th><span class="title_box">Date</span></th>
                                    <th><span class="title_box">Carrier</span></th>
                                    <th><span class="title_box">Total</span></th>
                                    <th style="text-align: center;">View</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repCart" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("id_cart") %></td>
                                            <td><%#Eval("Date") %></td>
                                            <td>
                                                <%#Eval("name") %>
                                            </td>
                                            <td>
                                                <%#Eval("Total") %>
                                            </td>
                                            <td style="text-align: center;">
                                                <div class="row">
                                                    <a href='ViewCart.aspx?id=<%#Eval("id_cart") %>' class=" btn btn-info " rel="lightbox" style="color: white; width: 25px; padding: 4px 3px;"><i class="fa fa-eye fa-align-center" style="color: white;"></i></a>

                                                </div>

                                            </td>
                                            <%-- <td></td>--%>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                    <div class="panel">
                        <div class="panel-heading">
                            <i class="icon-file"></i>PURCHASED PRODUCTS  <span class="badge">
                                <asp:Label ID="lblPurchaseProduct" runat="server"></asp:Label></span>
                        </div>
                        <table class="table">
                            <thead>
                                <tr>

                                    <th><span class="title_box">Date</span></th>
                                    <th><span class="title_box">Name</span></th>
                                    <th><span class="title_box">Quantity</span></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repPurchase" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Date") %></td>
                                            <td>
                                                <a href='ViewOrder.aspx?id=<%#Eval("id_order") %>' style="color: #4c8bc1;"><%#Eval("product_name") %></a>
                                            </td>
                                            <td><%#Eval("product_quantity") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>


                    </div>
                </div>
            </div>


            <div class="col-lg-6">
                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="panel hide">
                        <div class="panel-heading">
                            <i class="icon-eye-close"></i>Add a private note
                        </div>
                        <div class="alert alert-info">This note will be displayed to all employees but not to customers.</div>
                        <form id="customer_note" class="form-horizontal" action="ajax.php" method="post" onsubmit="saveCustomerNote(100);return false;">
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <textarea name="note" id="noteContent" onkeyup="$('#submitCustomerNote').removeAttr('disabled');"></textarea>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <button type="submit" id="submitCustomerNote" class="btn btn-default pull-right" disabled="disabled">
                                        <i class="icon-save"></i>
                                        Save
                                    </button>
                                </div>
                            </div>
                            <span id="note_feedback"></span>
                        </form>
                    </div>
                    <div class="panel">
                        <div class="panel-heading">
                            <i class="icon-file"></i>MESSAGES  <span class="badge">
                                <asp:Label ID="lblMessTot" runat="server"></asp:Label></span>
                        </div>
                        <table class="table">
                            <thead>
                                <tr>

                                    <th><span class="title_box">Status</span></th>
                                    <th><span class="title_box">Message</span></th>
                                    <th><span class="title_box">Sent on</span></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepMess" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("status") %></td>
                                            <td>
                                                <%#Eval("message") %>
                                            </td>
                                            <td><%#Eval("date_add") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>


                    </div>

                    <div class="panel">
                        <div class="panel-heading">
                            <i class="icon-file"></i>WISHLIST <span class="badge">
                                <asp:Label ID="lblTotWish" runat="server"></asp:Label></span>
                        </div>
                        <table class="table">
                            <thead>
                                <tr>

                                    <th><span class="title_box">Image</span></th>
                                    <th><span class="title_box">Product Description</span></th>
                                    <th><span class="title_box">View</span></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repWish" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <img src="<%#Eval("URL") %>" height="100px" width="100px" /></td>
                                            <td>
                                                <%#Eval("ProdName") %><br />
                                                <%#Eval("pair") %><br />
                                                <%#Eval("ProdPrice") %>
                                            </td>
                                            <td><a href='<%#Eval("DetailUrl") %>' target="_blank" class="btn btn-info " rel="lightbox" style="color: white; width: 25px; padding: 4px 3px;"><i class="fa fa-eye fa-align-center" style="color: white;"></i></a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>


                    </div>

                    <div class="panel">
                        <div class="panel-heading">
                            <i class="icon-ticket"></i>Vouchers <span class="badge">
                                <asp:Label ID="lblTotVoucher" runat="server"></asp:Label></span>
                        </div>
                        <%--  <p class="text-muted text-center">
                            liwei yeong has no discount vouchers
                        </p>--%>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th><span class="title_box">Name</span></th>
                                    <th><span class="title_box">Code</span></th>
                                    <%--  <th><span class="title_box">Quantity</span></th>--%>
                                    <th><span class="title_box">Expiration date</span></th>
                                    <th><span class="title_box">Status</span></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rep" runat="server">
                                    <ItemTemplate>
                                        <tr class="gradeA">

                                            <td>
                                                <%#Eval("name") %> 
                                            </td>
                                            <td>
                                                <%#Eval("code") %>
                                            </td>
                                            <%--<td>
                                                <%#Eval("quantity") %>
                                            </td>--%>
                                            <td>
                                                <%#Eval("dd2") %>
                                            </td>
                                            <td>
                                                <%#Eval("Status") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                    <div class="panel">
                        <div class="panel-heading">
                            <i class="icon-ticket"></i>Last View Product <%--<span class="badge"><asp:Label ID="Label1" runat="server" ></asp:Label></span>--%>
                        </div>
                        <%--  <p class="text-muted text-center">
                            liwei yeong has no discount vouchers
                        </p>--%>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th><span class="title_box">Product Name</span></th>
                                    <th><span class="title_box">Date</span></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repLastViewProduct" runat="server">
                                    <ItemTemplate>
                                        <tr class="gradeA">

                                            <td>
                                                <%#Eval("name") %> 
                                            </td>

                                            <td>
                                                <%#Eval("dd1") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="panel">
                        <div class="panel-heading">
                            <i class="icon-file"></i>ADDRESSES   <span class="badge">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label></span>
                        </div>
                        <table class="table">
                            <thead>
                                <tr>

                                    <th><span class="title_box">Company</span></th>
                                    <th><span class="title_box">Name</span></th>
                                    <th><span class="title_box">Address Type</span></th>
                                    <th><span class="title_box">Address</span></th>
                                    <th><span class="title_box">Country</span></th>
                                    <th><span class="title_box">Phone number(s)</span></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repAdd" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Company") %></td>
                                            <td>
                                                <%#Eval("firstname") %>&nbsp;<%#Eval("lastname") %>
                                            </td>
                                            <td><%#Eval("alias") %></td>
                                            <td><%#Eval("address1") %>&nbsp;<%#Eval("address2") %>&nbsp;<%#Eval("city") %>&nbsp;<%#Eval("stste") %>&nbsp;<%#Eval("postcode") %>&nbsp;<%#Eval("name") %></td>
                                            <td><%#Eval("name") %></td>
                                            <td><%#Eval("phone") %>&nbsp;<%#Eval("phone_mobile") %></td>

                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>


                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix">&nbsp</div>


    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>


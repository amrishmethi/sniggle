<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="Backoffice_ViewCart" %>

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
                                        <li>Customers <span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="CartList.aspx">Shopping Carts</a>
                                        </li>
                                    </ul>
                                </div>

                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                            </div>
                        </div>

                    </div>
                </div>

            </div>

        </div>
        <div class="col-lg-12">
            &nbsp;
        </div>
        <div class="col-lg-12">
            <div class="row">

                <div class="col-lg-6">
                    <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                        <div class="panel clearfix" runat="server" id="NotReg">
                            <div class=" header-title">
                                <i class="fa fa-user"></i>&nbsp;
                            <asp:Label ID="Label1" runat="server" Style="color: black"> </asp:Label>
                                -  
                             <a href="#" style="color: #0077a4"><i class="fa fa-envelope"></i>
                                 <asp:Label ID="Label2" runat="server">Customers Not Registered</asp:Label></a>

                            </div>
                        </div>
                        <div class="panel clearfix" runat="server" id="reg">
                            <div class=" header-title">
                                <a id="AncCustomer" runat="server" style="color: #0077a4"><i class="fa fa-user"></i>&nbsp;
                            <asp:Label ID="lblCName" runat="server" Style="color: black"></asp:Label>
                                    -  </a>
                                <a runat="server" id="ancEmail" style="color: #0077a4"><i class="fa fa-envelope"></i>
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label></a>

                            </div>
                            <div class="form-horizontal">

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
                                <div class="row">
                                    <label class="control-label col-lg-3">Last Visit</label>
                                    <div class="col-lg-9">
                                        <p class="form-control-static">
                                            &emsp;
                                        <asp:Label ID="lblLastVisitDate" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>
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
                                            &nbsp;
																	<span class="label label-danger">
                                                                        <i class="icon-remove"></i>
                                                                        &emsp;<asp:Label ID="lblOpt" runat="server"></asp:Label>
                                                                    </span>
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
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="sparkline13-hd">
                        <div class="main-sparkline13-hd">
                            <h1><span class="table-project-n">CART SUMMARY</span>
                                <asp:Label ID="lblCartId" runat="server"></asp:Label></h1>
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
                                        <th style="width: 5%">Date</th>
                                        <th style="width: 45%">
                                            <span class="title_box">Product
                                            </span>
                                        </th>
                                        <th style="width: 5%">
                                            <span class="title_box">Price<br />
                                            </span>
                                        </th>
                                        <th style="width: 5%">
                                            <span class="title_box">Qty
                                            </span>
                                        </th>
                                        <th style="width: 5%">
                                            <span class="title_box">Total<br />

                                            </span>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepOrderD" runat="server">
                                        <ItemTemplate>
                                            <tr class="highlighted odd selected-line">
                                                <td><%#Eval("Date") %></td>
                                                <td>
                                                    <%--<a href='<%#Eval("DetailUrl") %>' style="color: #0077a4" target="_blank"><%#Eval("product_name") %></a>--%>
                                                    <%#Eval("name") %>
                                                    <br />
                                                    <%#Eval("pair") %>
                                                </td>
                                                <td><%#Eval("DiscountPrice") %>
                                                </td>
                                                <td><%#Eval("quantity") %>
                                                </td>
                                                <td><%#Eval("Total") %>
                                                </td>

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>Total
                                        </td>
                                        <td>$
                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
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
</asp:Content>


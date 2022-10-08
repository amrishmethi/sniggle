<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ReorderView.aspx.cs" Inherits="Backoffice_ReorderView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
    <div class="admin-dashone-data-table-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcome-list map-mg-t-40-gl shadow-reset">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul class="breadcome-menu alignleft" style="margin-top: -21px;">
                                        <li><a href="ReOrder.aspx">Enquire</a> <span class="bread-slash">/</span>
                                        </li>
                                        <li><span>Reorder Enquire</span>
                                        </li>
                                    </ul>
                                </div>
                                <%--<div class="row">

                                    <h4 style="float: left">Orders</h4>
                                </div>--%>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                 <div class="row">
                                    <ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" OnClick="btnDelete_Click" style="color:white"><i  class="fa fa-trash-o" aria-hidden="true"> Delete</i></asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
        <div class="clearfix">&nbsp</div>
        <div class="row">

            <div class="col-lg-12">
                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="panel clearfix">
                        <div class=" header-title">
                            <i class="icon-user"></i>
                            <asp:Label ID="lblCName" runat="server"></asp:Label>
                            -  
                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            <%--<a href="mailto:liweiyeong@hotmail.com"><i class="icon-envelope"></i>
                        liweiyeong@hotmail.com
                    </a>--%>
                        </div>
                        <div class="form-horizontal">
                            <div class="row">
                                <label class="control-label col-lg-3"> Name</label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                        <asp:Label ID="lblFullName" runat="server"></asp:Label>.
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <label class="control-label col-lg-3">Email</label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                        <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <label class="control-label col-lg-3">Subject </label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                        <asp:Label ID="lblSubject" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            
                            <div class="row">
                                <label class="control-label col-lg-3">Message</label>
                                <div class="col-lg-9">
                                    <p class="form-control-static">
                                        &emsp;
                                         <asp:Literal ID="ltrMessage" runat="server" ></asp:Literal>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="clearfix">&nbsp</div>


    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>


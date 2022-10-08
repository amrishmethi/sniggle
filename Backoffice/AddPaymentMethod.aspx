<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddPaymentMethod.aspx.cs" Inherits="Backoffice_AddPaymentMethod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12">
                <div class="breadcome-list map-mg-t-40-gl shadow-reset">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                            <div class="row">
                                <ul class="breadcome-menu alignleft" style="margin-top: -21px;">
                                    <li><a href="index.aspx">Modules</a> <span class="bread-slash">/</span>
                                    </li>
                                    <li><span>Payment Method</span>
                                    </li>
                                </ul>
                            </div>
                            <div class="row">
                                <h1 style="float: left">Add New</h1>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                            <div class="row">
                                <%--<ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li><a href="addcategory.aspx">
                                            <h1 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h1>
                                            <br />
                                            <h5 style="float: left">Add new Categorie</h5>
                                        </a>
                                        </li>
                                    </ul>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                &nbsp;
            </div>
            <div id="adminpro-register-form" class="adminpro-form">
                <div class="col-lg-12">
                    <div class="sparkline13-list shadow-reset">
                        <div class="sparkline13-hd">
                            <div class="main-sparkline13-hd">
                                <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">PAYMENT METHOD</span> </h1>
                            </div>
                        </div>

                        <div class="login-bg">
                            <div class="row">
                                <div class="col-lg-2">
                                    &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtEmail" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-2">
                                    <div class="login-input-head alignright" style="margin-right: 10px">
                                        <p>Email Id </p>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="login-input-area">
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-2">
                                    &nbsp;
                                      
                                </div>
                                <div class="col-lg-2">
                                    <div class="login-input-head alignright" style="margin-right: 10px">
                                        <p>Marchant_id</p>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="login-input-area">
                                        <asp:TextBox ID="txtMerchant" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-2">
                                    &nbsp;
                                     <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtCont" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-lg-2">
                                    <div class="login-input-head alignright" style="margin-right: 10px">
                                        <p>WorkingKey </p>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="login-input-area">
                                        <asp:TextBox ID="txtWorkingKey" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-2">
                                    &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtCont" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-lg-2">
                                    <div class="login-input-head alignright" style="margin-right: 10px">
                                        <p>Access Code</p>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="login-input-area">
                                        <asp:TextBox ID="txtAccessCode" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-2">
                                    &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtCont" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-lg-2">
                                    <div class="login-input-head alignright" style="margin-right: 10px">
                                        <p>Action Url</p>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="login-input-area">
                                        <asp:TextBox ID="txtActionUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-2">
                                    &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtCont" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-lg-2">
                                    <div class="login-input-head alignright" style="margin-right: 10px">
                                        <p>Cancel Url</p>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="login-input-area">
                                        <asp:TextBox ID="txtCancelleUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-2">
                                    &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtCont" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-lg-2">
                                    <div class="login-input-head alignright" style="margin-right: 10px">
                                        <p>Success Url</p>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="login-input-area">
                                        <asp:TextBox ID="txtSuccessUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class=" alignleft">
                                        <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/Backoffice/PaymentMethod.aspx" CssClass="btn btn-danger"><i class="fa fa-times" aria-hidden="true"> Cancel</i></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="alignright">
                                        <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSave_Click"><i  class="fa fa-floppy-o" aria-hidden="true"> Save</i></asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>


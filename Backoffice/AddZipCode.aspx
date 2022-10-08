<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddZipCode.aspx.cs" Inherits="Backoffice_AddZipCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
      <div class="login-form-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcome-list map-mg-t-40-gl shadow-reset">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul class="breadcome-menu alignleft" style="margin-top: -21px;">
                                        <li><a href="ZipCode.aspx">Shipping</a> <span class="bread-slash">/</span>
                                        </li>
                                        <li><span>Zip Code</span>
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
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">Zip Code</span> </h1>

                                </div>
                            </div>

                            <div class="login-bg">
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="drpCountry" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Country </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:DropDownList ID="drpCountry" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtZipCode" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Zip Code</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtAmt" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Shipping Amount</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtAmt" runat="server" CssClass="form-control" Text="0"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class=" alignleft">
                                            <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/Backoffice/ZipCode.aspx" CssClass="btn btn-danger"><i class="fa fa-times fa-2x" aria-hidden="true"> Cancel</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="alignright">
                                            <asp:LinkButton ID="btnSaveAnd" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSaveAnd_Click"><i  class="fa fa-floppy-o fa-2x" aria-hidden="true"> Save and Stay</i></asp:LinkButton>
                                            <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSave_Click"><i  class="fa fa-floppy-o fa-2x" aria-hidden="true"> Save</i></asp:LinkButton>

                                        </div>
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
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>


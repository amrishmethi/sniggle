<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddCarrier.aspx.cs" Inherits="Backoffice_AddCarrier" %>

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
                                        <li><a href="Carrier.aspx">Shipping</a> <span class="bread-slash">/</span>
                                        </li>
                                        <li><span>Carrier</span>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Add New Carrier</h1>
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
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">CARRIER</span> </h1>

                                </div>
                            </div>

                            <div class="login-bg">

                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtValue" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p><span style="color: red">*</span>Carrier Name</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">&nbsp;</div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class=" alignleft">
                                            <asp:LinkButton ID="LinkButton16" runat="server" PostBackUrl="~/Backoffice/Carrier.aspx" CssClass="btn btn-danger"><i class="fa fa-times" aria-hidden="true"><br /> Cancel</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="alignright">
                                            <ul>
                                                <%--<li class="floatleft">
                                                    <asp:LinkButton ID="btnSaveAnd" ValidationGroup="add" runat="server" CssClass="btn btn-default" OnClick="btnSaveAnd_Click" Style="margin-right: 10px"><i  class="fa fa-floppy-o" aria-hidden="true"><br /> Save and E</i></asp:LinkButton></li>--%>
                                                <li class="floatleft">
                                                    <asp:LinkButton ID="btneSave" ValidationGroup="add" runat="server" CssClass="btn btn-default" OnClick="btneSave_Click"><i  class="fa fa-floppy-o" aria-hidden="true"><br /> Save</i></asp:LinkButton></li>
                                            </ul>
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


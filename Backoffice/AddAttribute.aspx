<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddAttribute.aspx.cs" Inherits="Backoffice_AddAttribute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <div class="login-form-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcome-list map-mg-t-40-gl shadow-reset">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul class="breadcome-menu alignleft" style="margin-top: -21px;">
                                        <li>Catalog<span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="AttributesGroups.aspx">Product Attribute</a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Add New Attribute</h1>
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
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">PRODUCT ATTRIBUTES</span> </h1>

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
                                            <p><span style="color: red">*</span> Name</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtPublicName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p><span style="color: red">*</span> Public name</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtPublicName" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="drpControl" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p><span style="color: red">*</span>Control</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:DropDownList ID="drpControl" runat="server" style="width:100%;height: 35px;">
                                                <asp:ListItem Text="Dropdown" Value="select"></asp:ListItem>
                                                <asp:ListItem Text="Radio Button" Value="radio"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row hidden">
                                    <div class="col-lg-2">
                                        &nbsp;
                                          <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                              ControlToValidate="drpCategory" ForeColor="Red"
                                              Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                          </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>URL</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
                                            <br />
                                            <p class="help-block">When the Layered Navigation Block module is enabled, you can get more detailed URLs by choosing the word that best represent this feature's value. By default, PrestaShop uses the value's name, but you can change that setting using this field.</p>
                                        </div>
                                    </div>

                                </div>
                                <div class="row hidden">
                                    <div class="col-lg-2">
                                        &nbsp;
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>
                                                Meta title
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtMetatitle" runat="server"></asp:TextBox>
                                            <br />
                                            <p class="help-block">When the Layered Navigation Block module is enabled, you can get more detailed page titles by choosing the word that best represent this feature's value. By default, PrestaShop uses the value's name, but you can change that setting using this field.</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">&nbsp;</div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="button-style-four btn-mg-b-10">
                                            <a href="AttributesGroups.aspx" class="btn btn-danger"><i class="fa fa-times fa-2x" aria-hidden="true">Cancel</i></a>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="alignright">
                                            <ul>
                                                <li class="floatleft">
                                                    <asp:LinkButton ID="btnFeatureSaveAnd" runat="server" ValidationGroup="add" CssClass="btn btn-default" OnClick="btnFeatureSaveAnd_Click" Style="margin-right: 10px"><i  class="fa fa-floppy-o" aria-hidden="true"><br /> Save and add new</i></asp:LinkButton></li>
                                                <li class="floatleft">
                                                    <asp:LinkButton ID="btnFeatureSave" runat="server" ValidationGroup="add" CssClass="btn btn-default" OnClick="btnFeatureSave_Click"><i  class="fa fa-floppy-o" aria-hidden="true"><br /> Save</i></asp:LinkButton></li>
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
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>


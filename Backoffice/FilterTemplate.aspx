<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="FilterTemplate.aspx.cs" Inherits="Backoffice_FilterTemplate" %>

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
                                        <li>Filter Template<span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="FilterTemplate.aspx"></a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Filter Template</h1>
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
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">Filter Template</span> </h1>
                                </div>
                            </div>

                            <div class="login-bg">
                                <div class="row">
                                    <div class="col-lg-1">
                                        &nbsp;
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Categories</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="drpCategory" runat="server" CssClass="select2_demo_2 form-control" OnTextChanged="drpCategory_TextChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="clearfix">&nbsp;</div>
                                <div class="row">
                                    <div class="col-lg-1">&nbsp;</div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Filters:</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-9">
                                        <div class="sparkline13-graph">
                                            <div class="datatable-dashv1-list custom-datatable-overright">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                    <ContentTemplate>
                                                        <asp:ListView ID="ItemsListView" runat="server" ItemPlaceholderID="myItemPlaceHolder">
                                                            <ItemTemplate>

                                                                <table id="ListViewTable" class="table">
                                                                    <tr class="gradeA">
                                                                        <td style="text-align: left; width: 1%;">
                                                                            <%--  Checked='<%# Eval("FilterActive") %>' Text='<%#Eval("Position") %>'--%>
                                                                            <asp:CheckBox ID="chk" runat="server" />
                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("id_attribute_group") %>' Visible="false"></asp:Label>
                                                                        </td>
                                                                        <td style="text-align: left; width: 15%;">
                                                                            <%#Eval("name") %>( <%#Eval("Value") %>)
                                                                             <asp:TextBox ID="txtPosition" runat="server" Text="0" Visible="false"></asp:TextBox>
                                                                        </td>
                                                                       
                                                                    </tr>
                                                                </table>

                                                            </ItemTemplate>
                                                        </asp:ListView>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="drpCategory" EventName="TextChanged" />

                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix">&nbsp;</div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class=" alignleft">

                                            <asp:LinkButton ID="btnAssoCancel" runat="server" OnClick="btnAssoCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true"> Cancel</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="alignright">
                                            <asp:LinkButton ID="btnAssociateSaveAnd" runat="server" ValidationGroup="asso" CssClass="btn btn-primary" OnClick="btnAssociateSaveAnd_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>
                                            <%--<asp:LinkButton ID="btnAssociateSave" runat="server" ValidationGroup="asso" CssClass="btn btn-primary" OnClick="btnAssociateSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>--%>
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


<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AttributeGenerator.aspx.cs" Inherits="Backoffice_AttributeGenerator" %>

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
                                        <li>Combinations Generator <span class="bread-slash">/</span>
                                        </li>
                                       <li><a onclick="history.go(-1); return false;" href="##">Back</a>
                                        </li>
                                    </ul>
                                </div>

                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    &nbsp;
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    &nbsp;
                </div>
                <div class="sparkline13-list shadow-reset">
                    <div class="col-lg-12">
                        <div class="panel">
                            <div class="sparkline13-hd">
                                <div class="main-sparkline13-hd">
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">ASSOCIATIONS</span> </h1>
                                </div>
                            </div>
                            <div class="login-bg">
                                <div class="row">
                                    <div class="col-lg-3">
                                        <div class="form-group" style="height: 500px; overflow-y: auto">
                                            <ul class="list-group">
                                                <li class="list-group-item ">
                                                    <%-- <span class="box">
                                <span class="valueTwo hidden">2</span>
                                <input type="checkbox" id="chkHome" class="shan box" />
                                <span class="valueOne">Home</span>
                            </span>--%>
                                                    <ul>
                                                        <asp:Repeater ID="repCat" runat="server" OnItemDataBound="repCat_ItemDataBound">
                                                            <ItemTemplate>
                                                                <li >
                                                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("id_attribute_group") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("name") %>' Style="font-size: 12px; font-weight: bold;"></asp:Label>
                                                                    <asp:Repeater ID="repSub" runat="server" OnItemDataBound="repSub_ItemDataBound">
                                                                        <ItemTemplate>
                                                                            <ul style="margin-left: 20px">
                                                                                <li>
                                                                                    <asp:Label ID="lblValID" runat="server" Text='<%#Eval("id_attribute") %>' Visible="false"></asp:Label>
                                                                                    <asp:CheckBox ID="chk1" runat="server" />
                                                                                    <asp:Label ID="lblValueName" runat="server" Text='<%#Eval("name") %>' Style="font-size: 12px; font-weight: bold;"></asp:Label>
                                                                                </li>
                                                                            </ul>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                    </span></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="form-group">
                                             <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-default" OnClick="btnDelete_Click"><i  class="icon-plus-sign" aria-hidden="true"> Delete</i></asp:LinkButton>
                                            <%--<button type="button" class="btn btn-default" onclick="del_attr_multiple();"><i class="icon-minus-sign"></i>Delete</button>--%>
                                            <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-default pull-right" OnClick="btnAdd_Click"><i  class="icon-plus-sign" aria-hidden="true"> Add</i></asp:LinkButton>
                                            <%--<button type="button" class="btn btn-default pull-right" onclick="add_attr_multiple();"><i class="icon-plus-sign"></i>Add</button>--%>
                                        </div>
                                    </div>
                                    <div class="col-lg-8 col-lg-offset-1">
                                        <div class="alert alert-info">The Combinations Generator is a tool that allows you to easily create a series of combinations by selecting the related attributes. For example, if you're selling t-shirts in three different sizes and two different colors, the generator will create six combinations for you.</div>

                                        <div class="alert alert-info">You're currently generating combinations for the following product <b></b></div>

                                        <div class="alert alert-info"><strong>Step 1: On the left side, select the attributes you want to use (Hold down the "Ctrl" key on your keyboard and validate by clicking on "Add")</strong></div>

                                        <div class="row">
                                            <table class="table">


                                                <asp:Repeater ID="repAtt" runat="server" OnItemDataBound="repAtt_ItemDataBound">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <th id="tab_h1" class="fixed-width-md">
                                                                <asp:Label ID="lblId" runat="server" Visible="false" Text='<%#Eval("id_attribute_group") %>'></asp:Label>
                                                                <asp:Label ID="lblGroup" runat="server" CssClass="title_box" Text='<%#Eval("name") %>'></asp:Label></th>
                                                        <th id="tab_h2" colspan="2"><span class="title_box">Impact on the product price ($)</span></th>
                                                                <th><span class="title_box">Impact on the product weight (Cts)</span></th>
                                                        </tr>
                                                        <tr>
                                                            <asp:Repeater ID="repCombination" runat="server">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                              <asp:Label ID="lblAttId" runat="server" Visible="false" Text='<%#Eval("id_attribute_group") %>'></asp:Label>
                                                                            <asp:Label ID="lblValueId" runat="server" Visible="false" Text='<%#Eval("id_attribute") %>'></asp:Label>
                                                                            <asp:Label ID="lblGroup" runat="server" Text='<%#Eval("Attname") %>'></asp:Label>
                                                                        </td>
                                                                        <td>Tax Excluded<br />
                                                                            <asp:TextBox ID="txtprdPrice" runat="server" Width="50px" Text="0.00"></asp:TextBox>
                                                                        </td>
                                                                        <td>Tax Excluded<br />
                                                                            <asp:TextBox ID="txtPrice" runat="server" Width="50px" Text="0.00"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <br />
                                                                            <asp:TextBox ID="txtWeight" runat="server" Width="50px" Text="0.00"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>


                                            </table>
                                        </div>

                                        <div class="alert alert-info">Select a default quantity, and reference, for each combination the generator will create for this product.</div>
                                        <table class="table">
                                            <tbody>
                                                <tr>
                                                    <td>Default Quantity</td>
                                                    <td>
                                                        <asp:TextBox ID="txtquantity" runat="server" Text="0" CssClass="form-control" ></asp:TextBox>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td>Default Reference</td>
                                                    <td>
                                                   <asp:TextBox ID="txtreference" runat="server" Text="" CssClass="form-control" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <div class="alert alert-info">Please click on "Generate these Combinations"</div>
                                        <asp:LinkButton ID="btnAssociateSaveAnd" runat="server" CssClass="btn btn-default" OnClick="btnAssociateSaveAnd_Click"><i  class="icon-random" aria-hidden="true"> Generate these Combinations</i></asp:LinkButton>
                                        <%--             <button type="submit" class="btn btn-default" name="generate"><i class="icon-random"></i>Generate these Combinations</button>--%>
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


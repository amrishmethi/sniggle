<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="addMenu.aspx.cs" Inherits="Backoffice_addMenu" %>

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
                                        <li>Modules <span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="menu.aspx">Menu</a>
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
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">Menu</span> </h1>
                                </div>
                            </div>

                            <div class="login-bg">
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Menu </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox>
                                            <input type="radio" id="radIsCat" runat="server"   />
                                                    Is Main Category
                                        </div>
                                        
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-area" style="margin-top:16px;">
                                            <asp:RadioButton ID="IsMegaMenu" runat="server"  />
                                            <%--<input type="radio" id="IsMegaMenu" runat="server" style="margin-top:20px;" />--%>
                                            Is Mega Menu
                                        </div>

                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                    </div>
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <label id="label_out_of_stock_1" for="out_of_stock_1">
                                                <input type="radio" id="radcms" runat="server" name="out_of_stock" class="out_of_stock" onclick="OpenClose('menu')" />
                                                CMS
                                            </label>
                                            <label id="label_out_of_stock_2" for="out_of_stock_2">
                                                <input type="radio" id="radcat" runat="server" name="out_of_stock" class="out_of_stock" onclick="OpenClose('cat')" />
                                                Category
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" id="menu" style="display: none;">
                                    <div class="col-lg-2">
                                        &nbsp;
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Parent Menu</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:DropDownList ID="drpMenu" runat="server" CssClass=" form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                                <div class="row" id="cat" style="display: none;">
                                    <div class="col-lg-2">
                                        &nbsp;
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Category</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <ul class="list-group" id="myUL">
                                            <li class="list-group-item ">
                                                <ul class="list-group nested active" id="myUL1">
                                                    <asp:Repeater ID="repCat" runat="server" OnItemDataBound="repCat_ItemDataBound">
                                                        <ItemTemplate>
                                                            <li class="list-group-item">
                                                                <asp:Label ID="lblID" runat="server" CssClass="bb valueOne" Text='<%#Eval("id_category") %>' Visible="false"></asp:Label>
                                                                <asp:CheckBox ID="chk1" runat="server" Text='<%#Eval("name") %>' />
                                                                <asp:Repeater ID="repSub" runat="server" OnItemDataBound="repSub_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <ul class="list-group nested active" id="myUL2">
                                                                            <li class="list-group-item">
                                                                                <asp:Label ID="lblParentId" runat="server" Text='<%#Eval("id_parent") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblID1" runat="server" CssClass="bb valueOne" Text='<%#Eval("id_category") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblSubCatName" runat="server" Text='<%#Eval("name") %>' Visible="false"></asp:Label>
                                                                                <span class="valueTwo hidden"><%#Eval("id_category") %></span>
                                                                                <asp:CheckBox ID="chk2" runat="server" Text='<%#Eval("name") %>' />
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
                                </div>
                                <div class="clearfix">&nbsp;</div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                        
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Link</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtLink" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtDis" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Position</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtDis" type="number" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                 <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtDis" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Color code</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" placeholder="#000000"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtDis" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Text Bold</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtBold" runat="server" CssClass="form-control" placeholder="Bold"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class=" alignleft">
                                            <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/Backoffice/menu.aspx" CssClass="btn btn-danger"><i class="fa fa-times" aria-hidden="true"> Cancel</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="alignright">
                                            <asp:LinkButton ID="btnSaveAnd" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSaveAnd_Click"><i  class="fa fa-floppy-o" aria-hidden="true"> Save and Stay</i></asp:LinkButton>
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
    </div>
    <asp:HiddenField ID="hdd" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script>
        $(document).ready(function () {

            var ss = $("#Body_hdd").val();
            if (ss == 'False') {
                $("#menu").hide();
                $("#cat").show();

            }
            else {
                $("#menu").show();
                $("#cat").hide();
            }

        });
        function OpenClose(th) {
            debugger
            if (th == 'menu') {
                $("#menu").show();
                $("#cat").hide();
            }

            else if (th == 'cat') {
                $("#menu").hide();
                $("#cat").show();
            }
            else {
                $("#menu").hide();
                $("#cat").hide();
            }
        }
    </script>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddCartRules.aspx.cs" Inherits="Backoffice_AddCartRules" %>

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
                                        <li>Cart Rules<span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="CartRules.aspx">Cart Rules</a>
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
            <div class="clearfix">&nbsp;</div>

        </div>
        <div class="col-lg-12">
            &nbsp;
        </div>
        <div class="row">
            <div class="col-lg-12">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <ul class="nav nav-tabs" id="tabOrder">

                        <li class="active">
                            <a href="#INFORMATION">
                                <i class="icon-time"></i>
                                INFORMATION <span class="badge">
                                    <asp:Label ID="lblStatusCount" runat="server"></asp:Label></span>
                            </a>
                        </li>
                        <li>
                            <a href="#CONDITION">
                                <i class="icon-file-text"></i>
                                CONDITION <span class="badge">
                                    <asp:Label ID="lblDocCount" runat="server"></asp:Label></span>
                            </a>
                        </li>
                    </ul>
                    <div class="tab-content panel">

                        <!-- Tab status -->
                        <div class="tab-pane active" id="INFORMATION">
                            <h4 class="visible-print">INFORMATION <span class="badge">
                                <asp:Label ID="lblTotStatus" runat="server"></asp:Label></span></h4>
                            <div class="login-bg">
                                <div class="row">
                                    <div class="col-lg-1">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="Info">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Name</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-9">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1">
                                        &nbsp;
                                      
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Description</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-9">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-1">
                                        &nbsp;
                                     <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtCont" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Code </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGenerate" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class=" alignleft" style="margin-top: 10px;">
                                            <asp:LinkButton ID="btnGenerate" runat="server" CssClass="btn btn btn-default" OnClick="btnGenerate_Click"><i class="fa fa-random"></i> Generate</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-lg-3">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Status </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area">
                                            <asp:DropDownList ID="drpStatus" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="InActive" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                                <div class="row hidden">
                                    <div class="col-lg-1">
                                        &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtCont" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Priority</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-1">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtPriority" runat="server" CssClass="form-control" Text="1" type="number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class=" alignleft">
                                            <asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times" aria-hidden="true"> Cancel</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="alignright">
                                          
                                                <asp:LinkButton ID="btnInfoSave" runat="server" ValidationGroup="Info" CssClass="btn btn-primary" OnClick="btnInfoSave_Click"><i  class="fa fa-floppy-o" aria-hidden="true"> Save</i></asp:LinkButton>
                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Tab documents -->
                        <div class="tab-pane" id="CONDITION">
                            <div class="login-bg">
                                <div class="row">

                                    <div class="col-lg-3">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Limit to a single customer</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="DrpCustomer" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-lg-3">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Valid</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtFDate" CssClass="form-control datePicK" runat="server" placeholder="From"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtTdate" CssClass="form-control datePicK" runat="server" placeholder="To"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-lg-3">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Minimum amount </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtMinAmt" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area" style="margin-top: 10px">
                                            <asp:DropDownList ID="drpAmttype" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="1">
						USD
                                                </asp:ListItem>
                                                <asp:ListItem Value="2">
						EUR
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area" style="margin-top: 10px">
                                            <asp:DropDownList ID="drpShip" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="0">Shipping excluded</asp:ListItem>
                                                <asp:ListItem Value="1">Shipping included</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-lg-3">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Total available</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-9">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtTotalAv" runat="server" Text="1" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">

                                    <div class="col-lg-3">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Total available for each user</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-9">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtTotalAvAllUser" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-lg-3">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Apply a discount</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-9">
                                        <div class="login-input-area">
                                            <p class="radio">
                                                <label id="label_out_of_stock_1" for="out_of_stock_1">
                                                    <input type="radio" id="out_of_stock_1" runat="server" name="out_of_stock" value="0" class="out_of_stock" onclick="OpenClose('Percent')" />
                                                    Percent (%)
                                                </label>
                                            </p>
                                            <p class="radio">
                                                <label id="label_out_of_stock_2" for="out_of_stock_2">
                                                    <input type="radio" id="out_of_stock_2" runat="server" name="out_of_stock" value="1" class="out_of_stock" onclick="OpenClose('Amount')" />
                                                    Amount
                                                </label>
                                            </p>
                                            <p class="radio">
                                                <label id="label_out_of_stock_3" for="out_of_stock_3">
                                                    <input type="radio" id="out_of_stock_3" runat="server" name="out_of_stock" value="2" class="out_of_stock" onclick="OpenClose('None')" />
                                                    None	
                                                </label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" id="Percent" style="display: none;">
                                    <div class="col-lg-2">
                                        &nbsp;
                                      
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Value</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="input-group">
                                            <span class="input-group-addon">%</span>
                                            <asp:TextBox ID="txtDisValue" runat="server" CssClass=" form-control" Text="0" Width="100px" MaxLength="27"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <div class="row" id="Amount" style="display: none;">

                                    <div class="col-lg-3">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Amount </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area" style="margin-top: 10px">
                                            <asp:DropDownList ID="drpDisAmtTyp" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="1">
						USD
                                                </asp:ListItem>
                                                <asp:ListItem Value="2">
						EUR
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class=" alignleft">
                                            <asp:LinkButton ID="btnCancel1" runat="server" OnClick="btnCancel1_Click" CssClass="btn btn-danger"><i class="fa fa-times" aria-hidden="true"> Cancel</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="alignright">
                                            <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="Info" CssClass="btn btn-primary" OnClick="btnSave_Click"><i  class="fa fa-floppy-o" aria-hidden="true"> Save</i></asp:LinkButton>
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
        $('#tabOrder a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        })
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datePicK").datepicker({
                inline: true,
                changeMonth: true,
                changeYear: true,

                dateFormat: 'dd/mm/yy'

            });
        });
    </script>
    <script>
        $(document).ready(function () {

            var ss = $("#Body_hdd").val();
            if (ss == 'Percent') {
                $("#Percent").show();
                $("#Amount").hide();
            }

            else if (ss == 'Amount') {
                $("#Percent").hide();
                $("#Amount").show();
            }
            else if (ss == 'None') {
                $("#Percent").hide();
                $("#Amount").hide();
            }
            else {
                $("#Percent").hide();
                $("#Amount").hide();
            }
        });
        function OpenClose(th) {
            debugger
            if (th == 'Percent') {
                $("#Percent").show();
                $("#Amount").hide();
            }

            else if (th == 'Amount') {
                $("#Percent").hide();
                $("#Amount").show();
            }
            else if (th == 'None') {
                $("#Percent").hide();
                $("#Amount").hide();
            }
            else {
                $("#Percent").hide();
                $("#Amount").hide();
            }
        }
    </script>
</asp:Content>


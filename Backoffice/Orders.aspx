<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Backoffice_Orders" %>

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
                                        <li>Orders <span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="Orders.aspx">Orders</a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">

                                    <h3 style="float: left">Orders</h3>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <%--<ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li><a href="#">
                                            <h1 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h1>
                                            <br />
                                            <h5 style="float: left">Add New Orders</h5>
                                        </a>
                                        </li>--%>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="col-lg-12">
            &nbsp;
        </div>
        <div class="row">
            <div class="col-lg-12">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="sparkline13-hd">
                        <div class="main-sparkline13-hd">
                            <h1><span class="table-project-n">Orders</span>
                                <asp:Label ID="lblCount" runat="server"></asp:Label></h1>
                            <%--<div class="sparkline13-outline-icon">
                                <span class="sparkline13-collapse-link"><i class="fa fa-chevron-up"></i></span>
                                <span><i class="fa fa-wrench"></i></span>
                                <span class="sparkline13-collapse-close"><i class="fa fa-times"></i></span>
                            </div>--%>
                        </div>
                    </div>
                    <%--<asp:TextBox ID="TextBox1" CssClass="form-control datePicK" runat="server" placeholder="From"></asp:TextBox>--%>
                    <div class="sparkline13-graph">
                        <div class="datatable-dashv1-list custom-datatable-overright">
                            <%-- <div id="toolbar">
                                <select class="form-control">
                                    <option value="">Export Basic</option>
                                    <option value="all">Export All</option>
                                    <option value="selected">Export Selected</option>
                                </select>
                            </div>--%>
                            <table id="table" data-toggle="table" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true" data-cookie-id-table="saveId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th data-field="ID">ID</th>
                                        <th data-field="Reference">Reference</th>
                                        <th data-field="New client">New client</th>
                                        <th data-field="Delivery">Delivery</th>
                                        <th data-field="Customer">Customer</th>
                                        <th data-field="Total">Total</th>
                                        <th data-field="Payment">Payment</th>
                                        <th data-field="Status">Status</th>
                                        <th data-field="Date">Date</th>
                                        <%-- <th data-field="PDF">PDF</th>--%>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtID" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtReference" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpNew" runat="server" class="form-control">
                                                <asp:ListItem Value="">-</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpDelivery" runat="server" class="form-control">
                                                <asp:ListItem Value="">-</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomer" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotal" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPayment" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                                <asp:ListItem Value="">-</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <%-- <input type="date" name="txtFDate" class="form-control" id="txtFDate"  />--%>
                                            <%--<input type="date" name="txtTdate" id="txtTdate" class="form-control"  />--%>
                                            <asp:TextBox ID="txtFDate" CssClass="form-control datePicK" runat="server" placeholder="From"></asp:TextBox>
                                            <asp:TextBox ID="txtTdate" CssClass="form-control datePicK" runat="server" placeholder="To"></asp:TextBox>
                                        </td>
                                        <%--  <td></td>--%>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-custon-rounded-four btn-default" />

                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand1">
                                        <ItemTemplate>
                                            <tr class="gradeA">
                                                <td>
                                                    <input runat="server" name="chk" id="chk" type="checkbox" class="checkitem" />
                                                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("id_order") %>' Visible="false"></asp:Label>
                                                </td>
                                                <td><%#Eval("id_order") %> </td>
                                                <td>
                                                    <%#Eval("reference") %> 
                                                </td>
                                                <td>
                                                    <%#Eval("NewC") %>
                                                </td>
                                                <td>
                                                    <%#Eval("countryname") %>
                                                </td>
                                                <td>
                                                    <%#Eval("customer") %>
                                                </td>
                                                <td>
                                                    <%#Eval("total_paid_tax_incl") %>
                                                </td>
                                                <td>
                                                    <%#Eval("payment") %>
                                                </td>
                                                <td>
                                                    <%#Eval("osname") %>
                                                </td>
                                                <td>
                                                    <%#Eval("date_add") %> </td>
                                                <%-- <td>
                                                  
                                                </td>--%>
                                                <td>
                                                    <div class="row">
                                                        <%--  <a href='#' class="btn btn-custon-rounded-three btn-primary" style="width: 25px; padding: 4px 3px;"><i class="fa fa-pencil-square-o fa-align-center" style="color: white;"></i></a>--%>
                                                        <a href='ViewOrder.aspx?id=<%#Eval("id_order") %>' class=" btn btn-info " rel="lightbox" style="color: white; width: 25px; padding: 4px 3px;"><i class="fa fa-eye fa-align-center" style="color: white;"></i></a>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete1" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                            CommandArgument='<%#Eval("id_order") %>' Style="width: 25px; padding: 4px 3px;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <div class="clearfix">&nbsp;</div>
                        <div class="row">
                            <div class="fixed-table-pagination">
                                <div class="col-lg-3">
                                    <div class="btn-group bulk-actions dropup  pagination floatleft">
                                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                            Bulk actions <span class="caret"></span>
                                        </button>

                                        <ul class="dropdown-menu checkbox">
                                            <li>
                                                <asp:CheckBox ID="Selectall" runat="server" CssClass="form-control" Text="Check all" />
                                            </li>
                                            <li>
                                                <asp:CheckBox ID="Unselectall" runat="server" CssClass="form-control" Text="UnCheck all" />
                                            </li>
                                            <%-- <li>
                                                <asp:LinkButton ID="btnEnable" runat="server" OnClick="btnEnable_Click" OnClientClick="javascript:return confirm('Are you sure you want to enable ?');"><i class="fa fa-power-off text-success"></i>&nbsp;Enable selection</asp:LinkButton>

                                            </li>
                                            <li>
                                                <asp:LinkButton ID="btnDisable" runat="server" OnClick="btnDisable_Click" OnClientClick="javascript:return confirm('Are you sure you want to disable ?');"><i class="fa fa-power-off text-danger"></i>&nbsp;Disable selection</asp:LinkButton>

                                            </li>--%>
                                            <li>
                                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="form-control" OnClick="btnDelete_Click" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');"><i class="fa fa-trash text-danger"></i>&nbsp;Delete selected</asp:LinkButton>

                                            </li>
                                        </ul>

                                    </div>
                                </div>
                                <div class="col-lg-1">
                                    <div class="pull-right pagination floatright"><span class="pagination-info">Display</span></div>
                                </div>
                                <div class="col-lg-1">
                                    <div class="pull-right pagination floatright">
                                        <asp:DropDownList ID="drpPageSize" runat="server" Style="width: 85px" CssClass="form-control" OnTextChanged="drpPageSize_TextChanged" AutoPostBack="true">

                                            <asp:ListItem Value="50" Text="50" Selected></asp:ListItem>
                                            <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                            <asp:ListItem Value="300" Text="300"></asp:ListItem>
                                            <asp:ListItem Value="1000" Text="1000"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-1">
                                    <div class="pull-right pagination floatright"><span class="pagination-info">/<asp:Label ID="lblTotal" runat="server"></asp:Label>&nbsp;result(s)</span></div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="pull-right pagination floatright">
                                        <div class="">
                                            <asp:Repeater ID="rptPager" runat="server">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                        CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                                        OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:Repeater>
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
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $(".datePicK").datepicker({
                inline: true,
                changeMonth: true,
                changeYear: true,

                dateFormat: 'dd/mm/yy'

            });
        });
    </script>--%>
    <script type="text/javascript">
        // When the document is ready
        $(document).ready(function () {
            $('.datePicK').datepicker({
                dateFormat: "dd/mm/yyyy",
                showOtherMonths: true,
                selectOtherMonths: true,
                autoclose: true,
                changeMonth: true,
                changeYear: true,
                todayHighlight: true,
                orientation: "top"
            });

        });
    </script>
</asp:Content>


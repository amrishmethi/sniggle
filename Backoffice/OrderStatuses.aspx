<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="OrderStatuses.aspx.cs" Inherits="Backoffice_OrderStatuses" %>

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
                                        <li><a href="OrderStatuses.aspx">Status </a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">

                                    <h3 style="float: left">Status </h3>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <%--<div class="row">
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
        </div>
        <div class="col-lg-12">
            &nbsp;
        </div>
        <div class="row">
            <div class="col-lg-12">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="sparkline13-hd">
                        <div class="main-sparkline13-hd">
                            <h1><span class="table-project-n">STATUS </span>
                                <asp:Label ID="lblCount" runat="server"></asp:Label></h1>
                            <%--<div class="sparkline13-outline-icon">
                                <span class="sparkline13-collapse-link"><i class="fa fa-chevron-up"></i></span>
                                <span><i class="fa fa-wrench"></i></span>
                                <span class="sparkline13-collapse-close"><i class="fa fa-times"></i></span>
                            </div>--%>
                        </div>
                    </div>
                    <div class="sparkline13-graph">
                        <div class="datatable-dashv1-list custom-datatable-overright">
                            <%-- <div id="toolbar">
                                <select class="form-control">
                                    <option value="">Export Basic</option>
                                    <option value="all">Export All</option>
                                    <option value="selected">Export Selected</option>
                                </select>
                            </div>--%>
                            <table id="table" data-toggle="table" data-search="true" data-show-columns="true" data-show-pagination-switch="true"  data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true" data-cookie-id-table="saveId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                <thead>
                                    <tr>
                                        <th data-field="ID">ID</th>
                                        <th data-field="Name">Name</th>
                                        <th data-field="Icon">Icon</th>
                                        <th data-field="Send email to customer">Send email to customer</th>
                                        <th data-field="Delivery">Delivery</th>
                                        <th data-field="Invoice">Invoice</th>
                                        <th data-field="Email template">Email template</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtID" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>--</td>
                                        <td>
                                            <asp:DropDownList ID="drpSendMail" runat="server" class="form-control">
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
                                            <asp:DropDownList ID="drpInvoice" runat="server" class="form-control">
                                                <asp:ListItem Value="">-</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmailTemp" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-custon-rounded-four btn-default" />

                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand1">
                                        <ItemTemplate>
                                            <tr class="gradeA">
                                                <td><%#Eval("id_order_state") %> </td>
                                                <td>
                                                    <span class="label color_field" style='<%# Eval("bg") %>' >
                                                        <%#Eval("name") %> 
                                                    </span>
                                                </td>
                                                <td > 

                                                   <div runat="server" visible='<%# ProcessMyDataItem(Eval("img")).ToString()!=""?true:false %>'>
                                                        <img src="<%#Eval("img") %> " style="width:26px; height:26px;"  />
                                                   </div>
                                                  <%-- <div runat="server" visible="">Arvind</div>--%>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lnkDetail" runat="server" CommandName="Mail" CommandArgument='<%#Eval("id_order_state") %>'>
                                        <%# bool.Parse(Eval("send_email").ToString())==true ? "<img src='../img/show.gif' title='Make Show' border='0'/>":"<img src='../img/hide.gif' title='Make Hide' border='0'/>" %>
                                                    </asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delever" CommandArgument='<%#Eval("id_order_state") %>'>
                                        <%# bool.Parse(Eval("delivery").ToString())==true ? "<img src='../img/show.gif' title='Make Show' border='0'/>":"<img src='../img/hide.gif' title='Make Hide' border='0'/>" %>
                                                    </asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Inv" CommandArgument='<%#Eval("id_order_state") %>'>
                                        <%# bool.Parse(Eval("invoice").ToString())==true ? "<img src='../img/show.gif' title='Make Show' border='0'/>":"<img src='../img/hide.gif' title='Make Hide' border='0'/>" %>
                                                    </asp:LinkButton></td>
                                                <td>
                                                    <%#Eval("template") %>
                                                </td>
                                                <td></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <%-- <asp:Repeater ID="rptPager" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                            OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="sparkline13-hd">
                        <div class="main-sparkline13-hd">
                            <h1><span class="table-project-n">Status </span>
                                <asp:Label ID="lblR" runat="server"></asp:Label></h1>
                            <div class="sparkline13-outline-icon">
                                <span class="sparkline13-collapse-link"><i class="fa fa-chevron-up"></i></span>
                                <span><i class="fa fa-wrench"></i></span>
                                <span class="sparkline13-collapse-close"><i class="fa fa-times"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="sparkline13-graph">
                        <div class="datatable-dashv1-list custom-datatable-overright">
                            <%-- <div id="toolbar">
                                <select class="form-control">
                                    <option value="">Export Basic</option>
                                    <option value="all">Export All</option>
                                    <option value="selected">Export Selected</option>
                                </select>
                            </div>--%>
                            <table id="table" data-toggle="table" data-search="true" data-show-columns="true" data-show-pagination-switch="true"  data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true" data-cookie-id-table="saveId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                <thead>
                                    <tr>
                                        <th data-field="ID">ID</th>
                                        <th data-field="Name">Name</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtRID" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRName" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        
                                        <td>
                                            <asp:Button ID="btnRSearch" runat="server" Text="Search" OnClick="btnRSearch_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                            <asp:Button ID="btnRReset" runat="server" Text="Reset" OnClick="btnRReset_Click" CssClass="btn btn-custon-rounded-four btn-default" />

                                        </td>
                                    </tr>
                                    <asp:Repeater ID="RepR" runat="server" >
                                        <ItemTemplate>
                                            <tr class="gradeA">
                                                <td style="width:100px;"><%#Eval("id_order_return_state") %> </td>
                                                <td>
                                                    <span class="label color_field" style='<%# Eval("bg") %>' >
                                                        <%#Eval("name") %> 
                                                    </span>

                                                </td>
                                                <td></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <%-- <asp:Repeater ID="rptPager" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                            OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>


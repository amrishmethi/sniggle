<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ProductTag.aspx.cs" Inherits="Backoffice_ProductTag" %>

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
                                        <li>Catalog<span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="ProductTag">Product Tag</a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Product Tag</h1>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                   <%-- <ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li><a href="AddTag.aspx">
                                            <h1 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h1>
                                            <br />
                                            <h5 style="float: left">Add New Product Tag</h5>
                                        </a>
                                        </li>
                                    </ul>--%>
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
                            <h1><span class="table-project-n">Product Tag</span>
                                <asp:Label ID="lblCount" runat="server"></asp:Label></h1>
                            <%-- <div class="sparkline13-outline-icon">
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
                            <table id="table" data-toggle="table" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true" data-cookie-id-table="saveId" data-show-export="true" data-toolbar="#toolbar">
                                <thead>
                                    <tr>
                                        <th data-field="ID">ID</th>
                                        <th data-field="Product Name">Product Name</th>
                                        <th data-field="Tags">Tags</th>
                                        <td>Total Tag</td>
                                      
                                         <th>Last Updated Date</th>
                                          <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                       
                                        <td>
                                            <asp:TextBox ID="txtID" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtProduct" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txttag" CssClass="form-control" runat="server"></asp:TextBox>
                                             
                                        </td>

                                        <td></td>
                                        <td></td>
                                     <td><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-custon-rounded-four btn-default" /></td>
                                    </tr>
                                    <asp:Repeater ID="rep" runat="server" >
                                        <ItemTemplate>
                                            <tr class="gradeA">
                                                <td>
                                                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("id_product") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <%#Eval("name") %> 
                                                </td>
                                                <td>
                                                    <%#Eval("tag") %>
                                                </td>
                                                <td>
                                                    <%#Eval("TotalTag") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Date") %>
                                                </td>
                                                <td>  <a href='AddProductTag.aspx?id=<%#Eval("id_product") %>' class="btn btn-custon-rounded-three btn-primary" style="width:25px;padding: 4px 3px;"><i class="fa fa-pencil-square-o fa-align-center" style="color: white;"></i></a></td>
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
                                    &nbsp;
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
</asp:Content>


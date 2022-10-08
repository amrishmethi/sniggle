<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="CreativeCuts.aspx.cs" Inherits="Backoffice_CreativeCuts" %>

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
                                        <li><a href="CreativeCuts.aspx">Creative Cuts</a> <span class="bread-slash">/</span>
                                        </li>
                                        <li><span>Creative Cuts Category</span>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Creative Cuts Category</h1>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li><a href="AddCreativeCuts.aspx">
                                            <h1 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h1>
                                            <br />
                                            <h5 style="float: left">Add New </h5>
                                        </a>
                                        </li>
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
                            <h1><span class="table-project-n">Creative Cuts Category</span> List</h1>
                            <%-- <div class="sparkline13-outline-icon">
                                <span class="sparkline13-collapse-link"><i class="fa fa-chevron-up"></i></span>
                                <span><i class="fa fa-wrench"></i></span>
                                <span class="sparkline13-collapse-close"><i class="fa fa-times"></i></span>
                            </div>--%>
                        </div>
                    </div>
                    <div class="sparkline13-graph">
                        <div class="datatable-dashv1-list custom-datatable-overright">
                            <%--<div id="toolbar">
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
                                        <th data-field="SNO">SNO</th>
                                        <th data-field="Name">Name</th>
                                        <th data-field="Content">Content</th>
                                        <th data-field="Image">Image</th>
                                        <th data-field="Status">Status</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtContent" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:DropDownList ID="drpStatus" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="">-</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand">
                                        <ItemTemplate>
                                            <tr class="gradeA">
                                                <td>
                                                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                                                    <input runat="server" name="chk" id="chk" type="checkbox" class="checkitem" /></td>
                                                <td><%#Container.ItemIndex + 1 %></td>

                                                <td>
                                                    <%#Eval("Name") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Description") %>
                                                </td>
                                                <td>
                                                    <img src='../img/FancyShape/<%#Eval("Image") %>' height="50px" width="50px" />
                                                </td>
                                                <td style="text-align: left; width: 5%;">
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="A" CommandArgument='<%#Eval("ID") %>'>
                                        <%# bool.Parse(Eval("Active").ToString())==true ? "<img src='../img/show.gif' title='Make Hide' border='0'/>":"<img src='../img/hide.gif' title='Make Show' border='0'/>" %>
                                                    </asp:LinkButton>

                                                </td>
                                                <td style="text-align: center;">
                                                    <div class="row">
                                                        <a href='AddCreativeCuts.aspx?id=<%#Eval("ID") %>' class="btn btn-custon-rounded-three btn-primary" style="width: 25px; padding: 4px 3px;"><i class="fa fa-pencil-square-o fa-align-center" style="color: white;"></i></a>
                                                        <%-- <a href='#' class="fancybox fancybox.iframe btn btn-info " rel="lightbox" style="color: white; width: 25px; padding: 4px 3px;"><i class="fa fa-eye fa-align-center" style="color: white;"></i></a>--%>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                            CommandArgument='<%#Eval("ID") %>' Style="width: 25px; padding: 4px 3px;"><i class="fa fa-trash-o"></i></asp:LinkButton>
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
                                            <li>
                                                <asp:LinkButton ID="btnEnable" runat="server" CssClass="form-control" OnClick="btnEnable_Click" OnClientClick="javascript:return confirm('Are you sure you want to enable ?');"><i class="fa fa-power-off text-success"></i>&nbsp;Enable selection</asp:LinkButton>

                                            </li>
                                            <li>
                                                <asp:LinkButton ID="btnDisable" runat="server" CssClass="form-control" OnClick="btnDisable_Click" OnClientClick="javascript:return confirm('Are you sure you want to disable ?');"><i class="fa fa-power-off text-danger"></i>&nbsp;Disable selection</asp:LinkButton>

                                            </li>
                                            <li>
                                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="form-control" OnClick="btnDelete_Click" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');"><i class="fa fa-trash text-success"></i>&nbsp;Delete selected</asp:LinkButton>

                                            </li>


                                        </ul>

                                    </div>
                                </div>
                                <div class="col-lg-1">
                                    &nbsp;
                                </div>
                                <div class="col-lg-1">
                                    &nbsp;
                                </div>
                                <div class="col-lg-1">
                                    &nbsp;
                                </div>
                                <div class="col-lg-6">
                                    &nbsp;
                                    
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


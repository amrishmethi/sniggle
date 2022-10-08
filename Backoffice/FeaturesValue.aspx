<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="FeaturesValue.aspx.cs" Inherits="Backoffice_FeaturesValue" %>

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
                                        <li>Catalog <span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="Features.aspx">Product Feature</a><span class="bread-slash">/</span>
                                        </li>
                                        <li><a runat="server" id="hrfval">Product Feature Value</a>
                                        </li>
                                    </ul>

                                </div>
                                <div class="row">
                                    <h1 style="float: left">Product Feature Value</h1>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <%-- <li style="margin-right:10px"><a href="AddAttribute.aspx">
                                            <h3 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h3>
                                           <h5 style="float: left">Add New Attribute</h5>
                                        </a>
                                        </li>--%>
                                        <li style="margin-right: 10px"><a href="addfeature_value.aspx">
                                            <h3 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h3>
                                            <h5 style="float: left">Add New Value</h5>
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
                            <h1><span class="table-project-n">PRODUCT FEATURE </span>LIST</h1>
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
                            <table id="table" data-toggle="table" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true" data-cookie-id-table="saveId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                <thead>
                                    <tr>
                                        <th style="text-align: left; width: 5%;"></th>
                                        <th data-field="ID">ID</th>
                                        <th data-field="Value">Value</th>
                                        <th></th>
                                    </tr>

                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="text-align: left; width: 5%;"></td>
                                        <td>
                                            <asp:TextBox ID="txtID" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>


                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand">
                                        <ItemTemplate>
                                            <tr class="gradeA">
                                                <td style="text-align: left; width: 5%;">
                                                    <input runat="server" name="chk" id="chk" type="checkbox" class="checkitem" />
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id_feature_value") %>' Visible="false"></asp:Label>
                                                </td>
                                                <td><%#Eval("id_feature_value") %> </td>
                                                <td>
                                                    <%#Eval("Value") %> 
                                                </td>


                                                <td>
                                                    <div class="row">
                                                        <a href='addfeature_value.aspx?id=<%#Eval("id_feature_value") %>' class="btn btn-custon-rounded-three btn-primary "><i class="fa fa-pencil-square-o" style="color: white;"></i></a>
                                                        <%--<a href='#' class="fancybox fancybox.iframe btn btn-info " rel="lightbox" style="color: white;"><i class="fa fa-eye fa-lg" style="color: white;"></i></a>--%>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                            CommandArgument='<%#Eval("id_feature_value") %>'><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    </div>
                                                </td>
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
                                            <%--<li>
                                                <asp:LinkButton ID="btnEnable" runat="server" CssClass="form-control"  OnClick="btnEnable_Click" OnClientClick="javascript:return confirm('Are you sure you want to enable ?');"><i class="fa fa-power-off text-success"></i>&nbsp;Enable selection</asp:LinkButton>

                                            </li>
                                            <li>
                                                <asp:LinkButton ID="btnDisable" runat="server" CssClass="form-control"  OnClick="btnDisable_Click" OnClientClick="javascript:return confirm('Are you sure you want to disable ?');"><i class="fa fa-power-off text-danger"></i>&nbsp;Disable selection</asp:LinkButton>

                                            </li>--%>
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
                                    <%--<div class="pull-right pagination floatright">
                                        <div class="">
                                            <asp:Repeater ID="rptPager" runat="server">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                        CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                                        OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>--%>
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


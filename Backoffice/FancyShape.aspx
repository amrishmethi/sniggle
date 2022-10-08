﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="FancyShape.aspx.cs" Inherits="Backoffice_FancyShape" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .dragGroup {
            width: 80px;
            cursor: move;
            text-align: center;
            position: relative;
            font-size: 14px;
            padding: 4px 4px 4px 20px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
        }

            .dragGroup:hover {
                color: #fff;
                background-color: #00aff0 !important;
            }

        .positions {
            display: inline-block;
            border: solid 1px #ccc;
            background-color: #eee;
            padding: 0 5px;
            color: #aaa;
            width: 43px;
            text-shadow: #fff 1px 1px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
            -webkit-box-shadow: rgba(0,0,0,0.2) 0 1px 3px inset;
            box-shadow: rgba(0,0,0,0.2) 0 1px 3px inset;
        }

        .dragGroup:before {
            display: block;
            height: 16px;
            width: 16px;
            position: absolute;
            top: 8px;
            left: 6px;
        }

        .dragGroup:before {
            content: "";
            display: inline-block;
            font: normal normal normal 14px/1 FontAwesome;
            font-size: inherit;
            text-rendering: auto;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
            transform: translate(0, 0);
        }
    </style>
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
                                        <li><a href="FancyShape.aspx">Creative Cuts</a> <span class="bread-slash">/</span>
                                        </li>
                                        <li><span>Creative Cuts</span>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Creative Cuts</h1>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li><a href="AddFancyShape.aspx">
                                            <h1 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h1>
                                            <br />
                                            <h5 style="float: left">Add New Creative Cuts</h5>
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
                            <h1><span class="table-project-n">Creative Cuts</span> List</h1>
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
                            <ul id="sortable">
                                <li>
                                    <table id="table" class="table">

                                        <tr>
                                            <th></th>
                                            <th></th>
                                            <th data-field="Creative Cuts Category" style="text-align: left; width: 10%;">Creative Cut Category</th>
                                            <th data-field="Title" style="text-align: left; width: 10%;">Title</th>
                                            <th data-field="Image 1" style="text-align: left; width: 10%;">Image 1</th>
                                            <th data-field="Image 2" style="text-align: left; width: 10%;">Image 2</th>
                                            <th data-field="Image 3" style="text-align: left; width: 10%;">Image 3</th>
                                            <th data-field="Image 4" style="text-align: left; width: 10%;">Image 4</th>
                                            <th data-field="Image 5" style="text-align: left; width: 10%;">Image 5</th>
                                            <th style="text-align: left; width: 5%;">Position</th>
                                            <th data-field="Status" style="text-align: left; width: 5%;">Status</th>

                                            <th style="text-align: center; width: 20%;">Action</th>
                                        </tr>
                                    </table>
                                </li>
                                <li>
                                    <table class="table">
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td style="text-align: left; width: 10%;">
                                                <asp:TextBox ID="txtCat" CssClass="form-control" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left; width: 10%;">
                                                <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left; width: 10%;">&nbsp;</td>
                                            <td style="text-align: left; width: 10%;">&nbsp;</td>
                                            <td style="text-align: left; width: 10%;">&nbsp;</td>
                                            <td style="text-align: left; width: 10%;">&nbsp;</td>
                                            <td style="text-align: left; width: 10%;">&nbsp;</td>
                                            <td style="text-align: left; width: 5%;">&nbsp;</td>
                                            <td style="text-align: left; width: 5%;">&nbsp;</td>
                                            <td style="text-align: left; width: 20%;">
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                                <asp:Button ID="btnReferesh" runat="server" Text="Reset" OnClick="btnReferesh_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                            </td>
                                        </tr>
                                    </table>
                                </li>
                                <asp:ListView ID="ItemsListView" runat="server" ItemPlaceholderID="myItemPlaceHolder" OnItemCommand="ItemsListView_ItemCommand" OnItemDeleting="ItemsListView_ItemDeleting">
                                    <ItemTemplate>
                                        <li id='id_<%# Eval("ID") %>' style="min-height: 35px">
                                            <table id="ListViewTable" class="table">
                                                <tr class="gradeA">
                                                    <%--<td style="text-align: left; width: 5%;">
                                                        <%#Container.DataItemIndex + 1 %>
                                                    </td>--%>
                                                    <td>
                                                        <input runat="server" name="chk" id="chk" type="checkbox" class="checkitem" />
                                                        <asp:Label ID="lblid" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left; width: 10%;">
                                                        <%#Eval("Name") %> 
                                                    </td>
                                                    <td style="text-align: left; width: 10%;">
                                                        <%#Eval("Title") %>
                                                    </td>
                                                    <td style="text-align: left; width: 10%;">
                                                        <img src='../img/FancyShape/<%#Eval("Image1") %>' height="50px" width="50px" />
                                                    </td>
                                                    <td style="text-align: left; width: 10%;">
                                                        <img src='../img/FancyShape/<%#Eval("Image2") %>' height="50px" width="50px" />
                                                    </td>
                                                    <td style="text-align: left; width: 10%;">
                                                        <img src='../img/FancyShape/<%#Eval("Image3") %>' height="50px" width="50px" />
                                                    </td>
                                                    <td style="text-align: left; width: 10%;">
                                                        <img src='../img/FancyShape/<%#Eval("Image4") %>' height="50px" width="50px" />
                                                    </td>
                                                    <td style="text-align: left; width: 10%;">
                                                        <img src='../img/FancyShape/<%#Eval("Image5") %>' height="50px" width="50px" />
                                                    </td>
                                                    <td
                                                        class="pointer dragHandle fixed-width-xs center" style="text-align: left; width: 5%; align-content: center">
                                                        <div class="dragGroup">
                                                            <div class="positions">
                                                                <%#Eval("position") %>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td style="text-align: left; width: 5%;">
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="A" CommandArgument='<%#Eval("ID") %>'>
                                        <%# bool.Parse(Eval("Active").ToString())==true ? "<img src='../img/show.gif' title='Make Hide' border='0'/>":"<img src='../img/hide.gif' title='Make Show' border='0'/>" %>
                                                        </asp:LinkButton>

                                                    </td>
                                                    <td style="text-align: center; width: 20%">
                                                        <div class="row">
                                                            <a href='AddFancyShape.aspx?id=<%#Eval("ID") %>' class="btn btn-custon-rounded-three btn-primary" style="width: 25px; padding: 4px 3px;"><i class="fa fa-pencil-square-o fa-align-center" style="color: white;"></i></a>
                                                            <%-- <a href='#' class="fancybox fancybox.iframe btn btn-info " rel="lightbox" style="color: white; width: 25px; padding: 4px 3px;"><i class="fa fa-eye fa-align-center" style="color: white;"></i></a>--%>
                                                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                                CommandArgument='<%#Eval("ID") %>' Style="width: 25px; padding: 4px 3px;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>
                            </ul>
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
                                                <asp:LinkButton ID="btnEnable" runat="server" OnClick="btnEnable_Click" OnClientClick="javascript:return confirm('Are you sure you want to enable ?');"><i class="fa fa-power-off text-success"></i>&nbsp;Enable selection</asp:LinkButton>

                                            </li>
                                            <li>
                                                <asp:LinkButton ID="btnDisable" runat="server" OnClick="btnDisable_Click" OnClientClick="javascript:return confirm('Are you sure you want to disable ?');"><i class="fa fa-power-off text-danger"></i>&nbsp;Disable selection</asp:LinkButton>

                                            </li>
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
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/themes/redmond/jquery-ui.css"
        type="text/css" media="all" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js" type="text/javascript"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $('#sortable').sortable({
                placeholder: 'ui-state-highlight',
                update: OnSortableUpdate
            });
            $('#sortable').disableSelection();

            var progressMessage = 'Saving changes... <img src="loading.gif"/>';
            var successMessage = 'Saved successfully!';
            var errorMessage = 'There was some error in processing your request';
            var messageContainer = $('#message').find('p');
            page
            function OnSortableUpdate(event, ui) {
                debugger
                var order = $('#sortable').sortable('toArray').join(',').replace(/id_/gi, '')
                //console.info(order);

                messageContainer.html(progressMessage);

                $.ajax({
                    type: 'POST',
                    url: 'Sortable.asmx/UpdateCreativeCut',
                    data: '{itemOrder: \'' + order + '\'}',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: OnSortableUpdateSuccess,
                    error: OnSortableUpdateError,

                });
            }

            function OnSortableUpdateSuccess(response) {
                if (response != null && response.d != null) {
                    debugger
                    var data = response.d;
                    if (data == true) {

                        messageContainer.html(successMessage);
                        //  $("#sss").load(" #sss");
                        //$("#sss").fadeIn(1500);
                        // $("#sss").load(location.href + "#sss");
                        //  $("#sss").load();
                        //debugger
                        //$('#sss').html();
                    }
                    else {
                        messageContainer.html(errorMessage);
                    }
                    //console.info(data);
                }
            }

            function OnSortableUpdateError(xhr, ajaxOptions, thrownError) {
                messageContainer.html(errorMessage);
            }

        });

    </script>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ProductImagePosition.aspx.cs" Inherits="Backoffice_ProductImagePosition" %>

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
                                        <li><a href="Products.aspx">Product</a> <span class="bread-slash">/</span>
                                        </li>
                                        <li><span>Image</span>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Image</h1>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li>
                                            <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click" style="color:white">Back</asp:LinkButton>

                                        </li>
                                        <li>
                                            <asp:LinkButton ID="btnReferesh" runat="server" CssClass="btn btn-primary" OnClick="btnReferesh_Click" style="color:white">Save</asp:LinkButton>
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
                            <h1><span class="table-project-n">Image</span> List</h1>
                            <%-- <div class="sparkline13-outline-icon">
                                <span class="sparkline13-collapse-link"><i class="fa fa-chevron-up"></i></span>
                                <span><i class="fa fa-wrench"></i></span>
                                <span class="sparkline13-collapse-close"><i class="fa fa-times"></i></span>
                            </div>--%>
                        </div>
                    </div>
                    <div class="sparkline13-graph">
                        <div class="datatable-dashv1-list custom-datatable-overright">
                            <div id="sss">
                                <table class="table">
                                    <tr>
                                        <th style="text-align: left; width: 15%;">Image</th>
                                        <th style="text-align: left; width: 30%;">Caption</th>
                                        <th style="text-align: left; width: 15%;">Position</th>
                                        <th style="text-align: left; width: 15%;">Cover</th>
                                        <th style="text-align: left; width: 15%;">Delete</th>
                                    </tr>
                                </table>
                                <ul id="sortable">
                                    <asp:ListView ID="ItemsListView" runat="server" ItemPlaceholderID="myItemPlaceHolder" OnItemCommand="ItemsListView_ItemCommand" OnItemDeleting="ItemsListView_ItemDeleting">
                                        <ItemTemplate>
                                            <li id='id_<%# Eval("id_image") %>'>
                                                <table class="table">
                                                    <%--  <asp:UpdatePanel ID="pn1" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>--%>
                                                    <%-- <asp:Timer ID="tm1" runat="server" Interval="3000" OnTick="tm1_Tick">
                                                                                    </asp:Timer>--%>
                                                    <tr>
                                                        <td style="text-align: left; width: 15%;">
                                                            <img src='<%#Eval("imgg") %>' height="50px" width="50px" /></td>
                                                        <td style="text-align: left; width: 30%;"><%#Eval("legend") %> </td>
                                                        <td class="pointer dragHandle fixed-width-xs center" style="text-align: left; width: 15%;">
                                                            <div class="dragGroup">
                                                                <div class="positions">
                                                                    <%#Eval("position") %>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td style="text-align: left; width: 15%;">
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cov" CommandArgument='<%#Eval("id_image") %>'>
                                        <%# bool.Parse(Eval("cover").ToString())==true ? "<img src='../img/show.gif' title='Make Show' border='0'/>":"<img src='../img/hide.gif' title='Make Hide' border='0'/>" %>
                                                            </asp:LinkButton>
                                                        </td>
                                                        <td style="text-align: left; width: 15%;">
                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("id_image") %>' Visible="false"></asp:Label>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                                CommandArgument='<%#Eval("id_image") %>' Style="width: 25px; padding: 4px 3px;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%--</ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:AsyncPostBackTrigger ControlID="tm1" EventName="Tick" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>--%>
                                                </table>
                                            </li>
                                        </ItemTemplate>
                                    </asp:ListView>


                                </ul>
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

            function OnSortableUpdate(event, ui) {
                debugger
                var order = $('#sortable').sortable('toArray').join(',').replace(/id_/gi, '')
                //console.info(order);

                messageContainer.html(progressMessage);

                $.ajax({
                    type: 'POST',
                    url: 'Sortable.asmx/UpdateItemsOrder',
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


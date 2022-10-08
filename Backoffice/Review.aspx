0<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Review.aspx.cs" Inherits="Backoffice_Review" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style type="text/css">
        .Star
        {
            background-image: url(images/Star.gif);
            height: 17px;
            width: 17px;
        }
        .WaitingStar
        {
            background-image: url(images/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }
        .FilledStar
        {
            background-image: url(images/FilledStar.gif);
            height: 17px;
            width: 17px;
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
                                        <li><a href="index.aspx">Review</a> <span class="bread-slash">/</span>
                                        </li>
                                        <li><span>Review</span>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Review</h1>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <%--<ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li><a href="AddTag.aspx">
                                            <h1 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h1>
                                            <br />
                                            <h5 style="float: left">Add New Tags</h5>
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
                            <h1><span class="table-project-n">Review</span>
                                <asp:Label ID="lblCount" runat="server"></asp:Label></h1>
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
                                        <th data-field="Review">Review</th>
                                        <th data-field="Customer Name">Customer Name</th>
                                        <th data-field="Date">Date</th>
                                        <th data-field="Rating">Rating</th>
                                        <th >Status</th>
                                        <th></th>
                                    </tr>

                                </thead>
                                <tbody>
                                    <%--<tr>
                                        <td>
                                            <asp:TextBox ID="txtID" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                      
                                        <td>
                                            <asp:TextBox ID="txtProduct" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                        </td>
                                    </tr>--%>
                                    <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand1" OnItemDataBound="rep_ItemDataBound">
                                        <ItemTemplate>
                                            <tr class="gradeA">
                                                <td><%#Eval("id_product_comment") %> </td>
                                                <td>
                                                    <%#Eval("content") %> 
                                                </td>
                                                <td>
                                                    <%#Eval("customer_name") %>
                                                </td>
                                                <td>
                                                    <%#Eval("dat") %>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRat" runat="server" Text='<%#Eval("grade") %>'></asp:Label>
                                                    <%--<cc1:Rating ID="Rating1"  runat="server" StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star" FilledStarCssClass="FilledStar" CurrentRating='<%# Eval("grade") %>'>                </cc1:Rating>--%>
                                                    <%-- <cc1:Rating ID="Rating1"  runat="server"
                                                        StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                                                        FilledStarCssClass="FilledStar">
                                                    </cc1:Rating>
                                                    <div class="rating1" runat="server" id="eventdiv">
                                                        <span class="starRating">
                                                            <input id='<%# "ratinge5" + Container.ItemIndex+1  %>' type="radio" name="event" value="5" class="ccb" />
                                                            <label for='<%# "ratinge5" + Container.ItemIndex+1  %>'>5</label>
                                                            <input id='<%# "ratinge4" + Container.ItemIndex+1  %>' type="radio" name="event" value="4" class="ccb" />
                                                            <label for='<%# "ratinge4" + Container.ItemIndex+1  %>'>4</label>
                                                            <input id='<%# "ratinge3" + Container.ItemIndex+1  %>' type="radio" name="event" value="3" class="ccb" />
                                                            <label for='<%# "ratinge3" + Container.ItemIndex+1  %>'>3</label>
                                                            <input id='<%# "ratinge2" + Container.ItemIndex+1  %>' type="radio" name="event" value="2" class="ccb" />
                                                            <label for='<%# "ratinge2" + Container.ItemIndex+1  %>'>2</label>
                                                            <input id='<%# "ratinge1" + Container.ItemIndex+1  %>' type="radio" name="event" value="1" class="ccb" />
                                                            <label for='<%# "ratinge1" + Container.ItemIndex+1  %>'>1</label>
                                                        </span>
                                                    </div>--%>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lnkDetail" runat="server" CommandName="New" CommandArgument='<%#Eval("id_product_comment") %>'>
                                        <%# bool.Parse(Eval("active").ToString())==true ? "<img src='../img/show.gif' title='Make Hide' border='0'/>":"<img src='../img/hide.gif' title='Make Show' border='0'/>" %>
                                                    </asp:LinkButton>
                                                </td>
                                                <td>
                                                    <div class="row">
                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                            CommandArgument='<%#Eval("id_product_comment") %>'><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script>
        $(document).ready(function () {
            $('img').attr('src', 'star-empty.png');     // CLEAR ALL THE STARS.

            // SHOW STARS ACCORDING TO AVERAGE RATE OF EACH BOOK.
            $('#GridView1 tr').each(function (index, value) {
                var avg = $(this).find('#avgRate').text();
                $(this).find('.rating > img').each(function () {
                    if ($(this).attr('alt') <= avg) {
                        $(this).attr('src', 'star-fill.png');
                    }
                });
            });

            // SAVE USER SELECTED RATE IN DB.
            // GET TOTAL AND AVERAGE RATINGS FROM DB AND UPDATE THE ROW.
            $('img').click(function () {

                var userRating = $(this).attr('alt');
                var bookID = $(this).parent().parent().attr('id');

                $.ajax({
                    type: "GET",
                    url: 'http://localhost:38331/api/books/',
                    data: {
                        iBookID: bookID,
                        iUserRating: userRating
                    },
                    success: function (data) {
                        $.map(data, function () {

                            // REFRESH AVERAGE AND TOTAL RATINGS FOR THE ROW.
                            $('#' + bookID + ' #avgRate').text(data[0].AvgRatings);
                            $('#' + bookID + ' #totRatings').text(data[0].TotalRatings);

                            // UPDATE STARS RATING.
                            $('#' + bookID).find('.rating > img').each(function () {
                                if ($(this).attr('alt') <= data[0].AvgRatings) {
                                    $(this).attr('src', 'star-fill.png');
                                }
                                else $(this).attr('src', 'star-empty.png');
                            });
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            });
        });
    </script>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddProductTag.aspx.cs" Inherits="Backoffice_AddProductTag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Admin/jquery-ui.css" rel="stylesheet" />
    <link href="../Admin/jquery.toast.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
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
                                    <li><a href="ProductTag.aspx">Product Tag</a>
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
                                <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">Product Name :&nbsp;&nbsp;&nbsp;
                                       <asp:Label ID="lblProduct" runat="server"></asp:Label>
                                </span></h1>

                            </div>
                        </div>

                        <div class="login-bg">

                            <div class="row">
                                <div class="alert alert-warning alert-success-style3" id="hideDiv" runat="server" visible="false">
                                    <button type="button" class="close sucess-op" data-dismiss="alert" aria-label="Close">
                                        <span class="icon-sc-cl" aria-hidden="true" style="color: red; font-size: large; background-color: red">×</span>
                                    </button>
                                    <i style="margin-left: 5px; margin-right: 10px; margin-top: 10px; margin-bottom: 5px;" class="fa fa-exclamation-triangle" aria-hidden="true">Already exist.......</i>

                                </div>
                                <div class="alert alert-warning alert-success-style3" id="Div1" runat="server" visible="false">
                                    <button type="button" class="close sucess-op" data-dismiss="alert" aria-label="Close">
                                        <span class="icon-sc-cl" aria-hidden="true" style="color: red; font-size: large; background-color: red">×</span>
                                    </button>
                                    <i style="margin-left: 5px; margin-right: 10px; margin-top: 10px; margin-bottom: 5px;" class="fa fa-exclamation-triangle" aria-hidden="true">Saved successfully!</i>

                                </div>
                                <div class="col-lg-1">
                                    <div class="login-input-head alignright" style="margin-right: 10px">
                                        <p>Tag Name </p>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="login-input-area">
                                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="login-input-area" style="margin-top: 10px;">
                                        <asp:LinkButton ID="btnSaveAnd" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSaveAnd_Click"><i  class="fa fa-floppy-o" aria-hidden="true" > Save</i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/Backoffice/ProductTag.aspx" CssClass="btn btn-danger"><i class="fa fa-times" aria-hidden="true">Exit </i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="sparkline13-graph">
                                        <div class="datatable-dashv1-list custom-datatable-overright">

                                            <table id="table" data-toggle="table" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true" data-cookie-id-table="saveId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                                <thead>
                                                    <tr>
                                                        <th>SNO</th>
                                                        <th>Tag</th>
                                                        <th>Delete</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand">
                                                        <ItemTemplate>
                                                            <tr class="gradeA">
                                                                <td><%#Container.ItemIndex + 1 %></td>
                                                                <td>
                                                                    <%#Eval("name") %> 
                                                                </td>
                                                                <td style="text-align: center;">
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                                        CommandArgument='<%#Eval("id_tag") %>' Style="width: 25px; padding: 4px 3px;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class=" alignleft">
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <asp:HiddenField ID="tagid" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="../Admin/jquery.min.js"></script>
    <script src="../Admin/jquery-ui.min.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            getTag();
        });
        function getTag() {
            $("[id*=Body_txtName]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: 'AddProductTag.aspx/getTag',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            // alert(response.responseText);
                        },
                        failure: function (response) {
                            //  alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $('#Body_tagid').val(i.item.val);
                },
                change: function (event, ui) {
                    if (ui.item === null) {
                        tostpro('Please select from list', 'Error', 'error', 'top-right', '2000');
                        $(this).val('');
                        $('#Body_txtName').val('');
                        $('#Body_txtName').focus();
                    }
                },
                minLength: 1
            });

        };
    </script>
    <script type="text/javascript">
        $(function () {
            setTimeout(function () {
                $("#Body_hideDiv").fadeOut(1000);
            }, 5000);
        });
    </script>
</asp:Content>


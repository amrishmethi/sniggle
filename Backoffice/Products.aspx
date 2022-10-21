<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Backoffice_Products" %>

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
                                        <li><span><a href="Products.aspx">Products</a></span>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Products</h1>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul class="breadcome-menu alignright" style="margin-top: -21px;">
                                        <li><a href="addproduct.aspx">
                                            <h1 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true"></i></h1>
                                            <br />
                                            <h5 style="float: left">Add new product</h5>
                                        </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix">&nbsp;</div>
                <div class="col-lg-12">
                    <div class="breadcome-list map-mg-t-40-gl shadow-reset">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6">
                                <ul class="breadcome-menu alignleft">
                                    <li>
                                        <h1 style="float: left;"><i class="fa fa-archive btn btn-button-success-ct" aria-hidden="true"></i></h1>
                                        <h5 style="float: left; margin-left: 10px">Out of stock items</h5>
                                        <br />
                                        <h5 style="float: left; margin-left: 10px; color: #31a8e3">99%</h5>
                                    </li>
                                </ul>
                            </div>

                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6">
                                <ul class="breadcome-menu alignleft">
                                    <li>
                                        <h1 style="float: left;"><i class="fa fa-tag btn btn-button-success-ct" aria-hidden="true"></i></h1>
                                        <h5 style="float: left; margin-left: 10px">Average Gross Margin %</h5>
                                        <br />
                                        <h5 style="float: left; margin-left: 10px; color: #31a8e3">97%</h5>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6">
                                <ul class="breadcome-menu alignleft">
                                    <li>
                                        <h1 style="float: left;"><i class="fa fa-beaker r btn btn-button-success-ct" aria-hidden="true"></i></h1>
                                        <h5 style="float: left; margin-left: 10px">Purchased references</h5>
                                        <br />
                                        <h5 style="float: left; margin-left: 10px; color: #31a8e3">30 days</h5>
                                        <br />
                                        <h5 style="float: left; margin-left: 35px; color: #31a8e3">0% of your Catalog</h5>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6">
                                <ul class="breadcome-menu alignleft">
                                    <li>
                                        <h1 style="float: left;"><i class="fa fa-power-off btn btn-button-success-ct" aria-hidden="true"></i></h1>
                                        <h5 style="float: left; margin-left: 10px">Disabled Products</h5>
                                        <br />
                                        <h5 style="float: left; margin-left: 10px; color: #31a8e3">0.37% </h5>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-lg-1 col-md-1 col-sm-6 col-xs-6">
                                <ul class="breadcome-menu alignright">
                                    <li>
                                        <h1 style="float: left;"><i class="fa fa-refresh " aria-hidden="true"></i></h1>
                                    </li>
                                </ul>
                            </div> 
                        </div>
                    </div>
                </div>
                <div class="clearfix">&nbsp;</div>
                <div class="col-lg-12">
                    <div class="col-lg-6">
                        <div class="breadcome-list map-mg-t-40-gl shadow-reset">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class=" alignleft">
                                        <asp:FileUpload ID="FlpExcel" runat="server" Width="200px" />
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class=" alignleft">
                                        <asp:LinkButton ID="btnSaveP" runat="server" OnClick="btnSaveP_Click" CssClass="btn btn-primary"><i  class="fa fa-floppy-o " aria-hidden="true">Save Product Excel</i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix hidden">&nbsp;</div>
                            <div class="row hidden">
                                <div class="col-lg-6">
                                    <div class=" alignleft">
                                        <asp:FileUpload ID="FlpExcelUpdate" runat="server" Width="200px" />
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="alignleft">
                                        <asp:LinkButton ID="btnUpdate" runat="server" Text="Update Product Excel" OnClick="btnUpdate_Click" CssClass="btn btn-primary"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="row">
                                <div class="col-lg-6">
                                    &nbsp;
                                </div>
                                <div class="col-lg-6">
                                    <div class="alignleft">
                                        <asp:LinkButton ID="btnDownload" runat="server" Text="Download Excel" OnClick="btnDownload_Click" CssClass="btn btn-primary"></asp:LinkButton>
                                    </div>
                                </div>
                            </div> 
                        </div>
                    </div>

                    <div class="col-lg-6">
                        <div class="breadcome-list map-mg-t-40-gl shadow-reset hidden">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class=" alignleft">
                                        <asp:FileUpload ID="flapTagSave" runat="server" Width="200px" />
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class=" alignleft">
                                        <asp:LinkButton ID="btnTagSave" runat="server" OnClick="btnTagSave_Click" CssClass="btn btn-primary"><i  class="fa fa-floppy-o " aria-hidden="true">Update Tag Excel</i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="clearfix">&nbsp;</div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class=" alignleft">
                                        <asp:FileUpload ID="flapTagUpdate" runat="server" Width="200px" />
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="alignleft">

                                        <asp:LinkButton ID="btnTagUpdate" runat="server" Text="Update Tag Excel" OnClick="btnTagUpdate_Click" CssClass="btn btn-primary"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="clearfix">&nbsp;</div>
                            <div class="row">
                                <div class="col-lg-6">
                                    &nbsp;
                                </div>
                                <div class="col-lg-6">
                                    <div class="alignleft">

                                        <asp:LinkButton ID="btnTagDownload" runat="server" Text="Download Tag Excel" OnClick="btnTagDownload_Click" CssClass="btn btn-primary"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <%--<asp:Button ID="btnDownload" runat="server" Text="Download Excel" OnClick="btnDownload_Click" CssClass="btn btn-success" TabIndex="2" />--%>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="clearfix">&nbsp;</div>
        <div class="row">
            <div class="col-lg-12">

                <div class="sparkline13-list shadow-reset" style="margin-left: 16px; margin-right: 16px;">
                    <div class="sparkline13-hd">
                        <div class="main-sparkline13-hd">
                            <h1><span class="table-project-n">Product</span> List&nbsp;
                                <asp:Label ID="lblPcount" runat="server"></asp:Label></h1>
                            <%-- <div class="sparkline13-outline-icon">
                               hh
                            </div>--%>
                        </div>
                    </div>
                    <div class="sparkline13-graph">
                        <div class="datatable-dashv1-list custom-datatable-overright">
                            <div id="toolbar">
                                <select class="form-control">
                                    <option value="">Export Basic</option>
                                    <option value="all">Export All</option>
                                    <option value="selected">Export Selected</option>
                                </select>
                            </div>
                            <table>
                                <%--<tr>
                                    <td style="width:30px;">&nbsp;</td>

                                    <td style="width:60px;">
                                        <asp:TextBox ID="txtID" CssClass="form-control" placeholder="ID" runat="server"></asp:TextBox></td>
                                     <td style="width:65px;">&nbsp;</td>
                                    <td style="width:150px;">
                                        <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtReference" CssClass="form-control" placeholder="Reference" runat="server"></asp:TextBox></td>
                                    <td style="width:142px;">
                                        <asp:TextBox ID="txtCat" CssClass="form-control" runat="server" placeholder="Category"></asp:TextBox></td>
                                    <td style="width:100px;">
                                        <asp:TextBox ID="txtBPrice" CssClass="form-control" runat="server" placeholder="Price"></asp:TextBox></td>
                                
                                    <td style="width:90px;">
                                        <asp:TextBox ID="txtQty" CssClass="form-control" runat="server" placeholder="Qty"></asp:TextBox></td>
                                    <td>
                                        <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                            <asp:ListItem Value="">Status</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpIsHome" runat="server" class="form-control">
                                            <asp:ListItem Value="">Home</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style=" width:87px;">
                                        <asp:Button ID="btnSearch" TabIndex="0" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                        <asp:Button ID="btnReset" TabIndex="1" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                    </td>
                                </tr>--%>
                            </table>
                            <table id="table" data-toggle="table" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true" data-cookie-id-table="saveId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">

                                <thead>
                                    <tr>
                                        <th></th>
                                        <th data-field="ID">ID</th>
                                        <th data-field="Image">Image</th>
                                        <th data-field="Name">Name</th>
                                        <th data-field="Reference">Reference</th>
                                        <th data-field="Category">Category</th>
                                        <th data-field="Base price">Base price</th>
                                        <%--  <th data-field="Final price">Final price</th>--%>
                                        <th data-field="Quantity">Quantity</th>
                                        <th data-field="Status">Status</th>
                                        <th>Home</th>
                                        <th>Stock For Bar Code</th>
                                        <%-- <th data-field="Position">Position</th>--%>
                                        <th>GroupId</th>
                                        <th>Action</th>
                                    </tr>

                                </thead>
                                <tbody>

                                    <tr>
                                        <td></td>

                                        <td>
                                            <asp:TextBox ID="txtID" CssClass="form-control" runat="server"></asp:TextBox></td>
                                        <td>--</td>
                                        <td>
                                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtReference" CssClass="form-control" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtCat" CssClass="form-control" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtBPrice" CssClass="form-control" runat="server"></asp:TextBox></td>
                                        <%-- <td>---</td>--%>
                                        <td>
                                            <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                                <asp:ListItem Value="">-</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpIsHome" runat="server" class="form-control">
                                                <asp:ListItem Value="">-</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpBarcode" runat="server" class="form-control">
                                                <asp:ListItem Value="">-</asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnSearch" TabIndex="0" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                            <asp:Button ID="btnReset" TabIndex="1" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-custon-rounded-four btn-default" />
                                        </td>
                                    </tr>

                                    <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand">
                                        <ItemTemplate>
                                            <tr class="gradeA">
                                                <td>
                                                    <input runat="server" name="chk" id="chk" type="checkbox" class="checkitem" />

                                                </td>
                                                <td>
                                                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("id_product") %>'></asp:Label>

                                                </td>
                                                <td>
                                                    <img src='<%#Eval("ImageUrl") %>' height="50px" width="50px" />
                                                </td>
                                                <td><%#Eval("name") %> </td>
                                                <td><%#Eval("reference") %> </td>
                                                <td><%#Eval("name_category") %> </td>
                                                <td>
                                                    <div style="text-align: center;"><%#Eval("price") %> </div>
                                                </td>
                                                <%-- <td><%#Eval("price") %> </td>--%>
                                                <td>
                                                    <div style="text-align: center;"><%#Eval("quantity") %></div>
                                                </td>
                                                <td>
                                                    <div style="text-align: center;">
                                                        <asp:LinkButton ID="lnkDetail" runat="server" CommandName="New" CommandArgument='<%#Eval("id_product") %>'>
                                        <%# bool.Parse(Eval("active").ToString())==true ? "<img src='../img/show.gif' title='Make Hide' border='0'/>":"<img src='../img/hide.gif' title='Make Show' border='0'/>" %>
                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div style="text-align: center;">
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="H" CommandArgument='<%#Eval("id_product") %>'>
                                        <%# bool.Parse(Eval("IsHome").ToString())==true ? "<img src='../img/show.gif' title='Make Hide' border='0'/>":"<img src='../img/hide.gif' title='Make Show' border='0'/>" %>
                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div style="text-align: center;">
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="B" CommandArgument='<%#Eval("id_product") %>'>
                                        <%# bool.Parse(Eval("StockForBarCode").ToString())==true ? "<img src='../img/show.gif' title='Make Hide' border='0'/>":"<img src='../img/hide.gif' title='Make Show' border='0'/>" %>
                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                                <td><%#Eval("GroupId") %></td>
                                                <td>
                                                    <div class="row" style="text-align: center;">
                                                        <%--<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CssClass="btn btn-custon-rounded-three btn-primary"
                                                            CommandArgument='<%#Eval("id_product") %>' Style="width: 25px; padding: 4px 3px;"><i class="fa fa-pencil-square-o fa-align-center" style="color: white;"></i></asp:LinkButton>--%>
                                                        <a href='<%# Url(Eval("id_product")) %>' class="btn btn-custon-rounded-three btn-primary" style="width: 25px; padding: 4px 3px;"><i class="fa fa-pencil-square-o fa-align-center" style="color: white;"></i></a>
                                                        <a href='<%#Eval("DetailUrl") %>' target="_blank" class="btn btn-info " rel="lightbox" style="color: white; width: 25px; padding: 4px 3px;"><i class="fa fa-eye fa-align-center" style="color: white;"></i></a>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                            CommandArgument='<%#Eval("id_product") %>' Style="width: 25px; padding: 4px 3px;"><i class="fa fa-trash-o"></i></asp:LinkButton>
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
                                                <asp:LinkButton ID="btnEnable" runat="server" OnClick="btnEnable_Click" OnClientClick="javascript:return confirm('Are you sure you want to enable ?');"><i class="fa fa-power-off text-success"></i>&nbsp;Active Product</asp:LinkButton>

                                            </li>
                                            <li>
                                                <asp:LinkButton ID="btnDisable" runat="server" OnClick="btnDisable_Click" OnClientClick="javascript:return confirm('Are you sure you want to disable ?');"><i class="fa fa-power-off text-danger"></i>&nbsp;Inactive Product</asp:LinkButton>

                                            </li>

                                            <li>
                                                <asp:LinkButton ID="btnEnableHome" runat="server" OnClick="btnEnableHome_Click" OnClientClick="javascript:return confirm('Are you sure you want to enable ?');"><i class="fa fa-power-off text-success"></i>&nbsp;Enable Home</asp:LinkButton>

                                            </li>
                                            <li>
                                                <asp:LinkButton ID="btnDesableHome" runat="server" OnClick="btnDesableHome_Click" OnClientClick="javascript:return confirm('Are you sure you want to disable ?');"><i class="fa fa-power-off text-danger"></i>&nbsp;Disable Home</asp:LinkButton>

                                            </li>

                                            <li>
                                                <asp:LinkButton ID="btnEnableStock" runat="server" OnClick="btnEnableStock_Click" OnClientClick="javascript:return confirm('Are you sure you want to enable ?');"><i class="fa fa-power-off text-success"></i>&nbsp;Enable Stock</asp:LinkButton>

                                            </li>
                                            <li>
                                                <asp:LinkButton ID="btnDesableStock" runat="server" OnClick="btnDesableStock_Click" OnClientClick="javascript:return confirm('Are you sure you want to disable ?');"><i class="fa fa-power-off text-danger"></i>&nbsp;Disable Stock</asp:LinkButton>

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
</asp:Content>


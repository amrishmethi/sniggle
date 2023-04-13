<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="addproduct.aspx.cs" Inherits="Backoffice_addproduct" ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../Admin/multiUpload/jquery-1.3.2.js"></script>
    <script src="../Admin/multiUpload/jquery.MultiFile.js"></script>
    <style> 
        .MultiFile-list {
            padding: 2px;
        }

        .MultiFile-remove {
            color: red;
            font-size: 22px;
        }
    </style>
    <style>
        ul, #myUL {
            list-style-type: none;
        }

        #myUL {
            margin: 0;
            padding: 0;
        }

        ul, #myUL1 {
            list-style-type: none;
        }

        #myUL1 {
            margin: 0;
            padding: 0;
        }

        ul, #myUL2 {
            list-style-type: none;
        }

        #myUL2 {
            margin: 0;
            padding: 10px;
        }

        .box {
            cursor: pointer;
            -webkit-user-select: none; /* Safari 3.1+ */
            -moz-user-select: none; /* Firefox 2+ */
            -ms-user-select: none; /* IE 10+ */
            user-select: none;
        }

            .box::before {
                /*content: "\2610";*/
                color: black;
                display: inline-block;
                margin-right: 6px;
            }

        .check-box::before {
            /*content: "\2611";*/
            color: dodgerblue;
        }

        .nested {
            display: none;
        }

        .active {
            display: block;
        }
    </style>
    <script type="text/javascript">
        //function callback() {
        //    window.opener.document.forms["form1"].elements["btnCombSaveAnd"].click();
        //    window.opener.document.forms["form1"].elements["btnCombSave"].click();
        //}
    </script>
    <script type="text/javascript">
        $(function () {
            setTimeout(function () {
                $("#Body_hideDiv").fadeOut(1500);
            }, 5000);
        });
    </script>

    <%--<style type="text/css">
        #sortable
        {
            list-style-type: none;
           /* margin: 0;
            padding: 0;
            width: 400px;*/
        }
        #sortable li
        {
            /*margin: 0 5px 5px 5px;
            padding: 5px;
            font-size: 1.2em;
            height: 1.5em;*/
            cursor: move;
        }
        html > body #sortable li
        {
           /* height: 1.5em;
            line-height: 1.2em;*/
        }
        
    </style>--%>
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
    <div class="login-form-area mg-b-15">
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
                                        <li><a href="Products.aspx">Products</a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">
                                        <asp:Label ID="lblPName" runat="server"></asp:Label></h1>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <ul id="toolbar-nav" class="nav nav-pills pull-right collapse navbar-collapse">
                                        <li>
                                            <a id="ancpreview" class="toolbar_btn  _blank pointer" runat="server" title="Preview" target="_blank">
                                                <i class="fa fa-eye fa-2x previewUrl"></i>
                                                <div>Preview</div>
                                            </a>
                                        </li>
                                        <%--<li>
                                            <a id="page-header-desc-product-duplicate" class="toolbar_btn  pointer" title="Duplicate">
                                                <i class="process-icon-duplicate"></i>
                                                <div>Duplicate</div>
                                            </a>
                                        </li>
                                        <li>
                                            <a id="page-header-desc-product-stats" class="toolbar_btn  pointer">
                                                <i class="process-icon-stats"></i>
                                                <div>Product sales</div>
                                            </a>
                                        </li>
                                        <li>
                                            <a id="page-header-desc-product-delete" class="toolbar_btn  pointer">
                                                <i class="process-icon-delete"></i>
                                                <div>Delete this product</div>
                                            </a>
                                        </li>--%>
                                        <li>
                                            <a id="page-header-desc-product-modules-list" class="toolbar_btn" href="#" title="Recommended Modules and Services">
                                                <i class="process-icon-modules-list"></i>
                                                <div>Recommended Modules and Services</div>
                                            </a>
                                        </li>
                                        <li>
                                            <a class="toolbar_btn btn-help" title="Help">
                                                <i class="fa fa-question-circle fa-2x" aria-hidden="true"></i>
                                                <div>Help</div>
                                            </a>
                                        </li>
                                    </ul>
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
                        <div class="col-lg-2">
                            <div class="sparkline13-list shadow-reset" style="margin-right: 10px">
                                <div class="login-bg">
                                    <div class="list-group">
                                        <ul>
                                            <li class="list-group-item active tablinks" onclick="openTab(event, 'Information')"><a href="#Information">Information</a></li>
                                            <li class="list-group-item tablinks" onclick="openTab(event, 'Prices')"><a href="#Prices">Prices</a></li>
                                            <li class="list-group-item tablinks" onclick="openTab(event, 'SEO')"><a href="#SEO">SEO</a></li>
                                            <li class="list-group-item tablinks" onclick="openTab(event, 'Associations')"><a href="#Associations">Associations</a></li>
                                            <li class="list-group-item tablinks" onclick="openTab(event, 'Shipping')"><a href="#Shipping">Shipping</a></li>
                                            <li class="list-group-item tablinks" onclick="openTab(event, 'Combinations')"><a href="#Combinations">Combinations</a></li>
                                            <li class="list-group-item tablinks" onclick="openTab(event, 'Quantities')"><a href="#Quantities">Quantities</a></li>
                                            <%-- <li class="list-group-item tablinks" onclick="openTab(event, 'VirtualProduct')"><a href="#VirtualProduct">Virtual Product</a> </li>--%>
                                            <li class="list-group-item tablinks" onclick="openTab(event, 'Images')"><a href="#Images">Images</a></li>
                                            <li class="list-group-item tablinks" onclick="openTab(event, 'Features')"><a href="#Features">Features</a></li>
                                            <%--   <li class="list-group-item tablinks" onclick="openTab(event, 'Customization')"><a href="#Customization">Customization</a></li>--%>
                                            <%--    <li class="list-group-item tablinks" onclick="openTab(event, 'Attachments')"><a href="#Attachments">Attachments</a></li>--%>
                                            <%--  <li class="list-group-item tablinks" onclick="openTab(event, 'Suppliers')"><a href="#Suppliers">Suppliers</a></li>--%>
                                            <li class="list-group-item tablinks" onclick="openTab(event, 'TMProductVideos')"><a href="#TMProductVideos">Videos</a></li>
                                            <li class="list-group-item tablinks" onclick="openTab(event, 'Hot')"><a href="#Hot">Hot Deals</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-10">
                            <div class="alert alert-warning alert-success-style3" id="hideDiv" runat="server" visible="false">
                                <button type="button" class="close sucess-op" data-dismiss="alert" aria-label="Close">
                                    <span class="icon-sc-cl" aria-hidden="true" style="color: red; font-size: large; background-color: red">×</span>
                                </button>
                                <i style="margin-left: 5px; margin-right: 10px; margin-top: 10px; margin-bottom: 5px;" class="fa fa-exclamation-triangle" aria-hidden="true">Saved successfully!</i>

                            </div>
                            <%--INFORMATION  Tab --%>
                            <div class="sparkline13-list shadow-reset tabcontent" id="Information">
                                <div class="sparkline13-hd">
                                    <div class="main-sparkline13-hd">
                                        <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">INFORMATION</span> </h1>

                                    </div>
                                </div>
                                <div class="login-bg">
                                    <%--<div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                     
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Type</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <asp:RadioButton ID="rbtnMale" runat="server" GroupName="Type" Text="  Standard product" /><br />
                                              
                                            </div>
                                        </div>

                                    </div>--%>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                                  ControlToValidate="txtName" ForeColor="Red"
                                                  Display="Dynamic" SetFocusOnError="true" ValidationGroup="addInfo">
                                              </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p><span style="color: red">* </span>Name</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                              ControlToValidate="ReferenceCode" ForeColor="Red"
                                              Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                          </asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Reference code <span style="color: red">* </span></p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <asp:TextBox runat="server" ID="txtReferenceCode"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row hide">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>EAN-13 or JAN barcode</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <asp:TextBox runat="server" ID="txtJanbarcode"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row hide">
                                        <div class="col-lg-2">
                                            &nbsp;

                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>UPC barcode</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <asp:TextBox runat="server" ID="txtUpcbarcode"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Enabled</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Redirect when disabled</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <asp:DropDownList ID="drpDisable" runat="server" CssClass="form-control custom-select-value">
                                                    <asp:ListItem Value="404">No redirect (404)</asp:ListItem>
                                                    <asp:ListItem Value="301">Redirected permanently (301)</asp:ListItem>
                                                    <asp:ListItem Value="302">Redirected temporarily (302)</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <%-- <p>Meta description</p>--%>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <div class="Alert alert-info">
                                                    <ul style="padding: 10px">
                                                        <li style="margin-left: 20px; margin-top: 10px; margin-bottom: 5px;">404 Not Found = Do not redirect and display a 404 page.</li>
                                                        <li style="margin-left: 20px; margin-top: 0px; margin-bottom: 5px;">301 Moved Permanently = Permanently display another product instead.</li>
                                                        <li style="margin-left: 20px; margin-top: 0px; margin-bottom: 5px;">302 Moved Temporarily = Temporarily display another product instead.</li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix">&nbsp;</div>
                                    <div class="row hidden">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Visibility</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <asp:DropDownList ID="drpVisibility" runat="server" CssClass="form-control custom-select-value">
                                                    <asp:ListItem Value="both">Everywhere</asp:ListItem>
                                                    <asp:ListItem Value="catalog">Catalog only</asp:ListItem>
                                                    <asp:ListItem Value="search">Search only</asp:ListItem>
                                                    <asp:ListItem Value="none">Nowhere</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>
                                                    Options
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <br />
                                                <asp:CheckBox ID="chkOnline" runat="server" Text="Online only (not sold in your retail store)" /><br />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix">&nbsp;</div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Condition</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <asp:DropDownList ID="drpCondition" runat="server" CssClass="form-control custom-select-value">
                                                    <asp:ListItem Value="new">New</asp:ListItem>
                                                    <asp:ListItem Value="used">Used</asp:ListItem>
                                                    <asp:ListItem Value="refurbished">Refurbished</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row hide">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Short description</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <%--<ce:editor id="txtShortDes" runat="server" style="width: 600px; height:400px">
                                </ce:editor>--%>
                                                <%-- <textarea id="txtShortDes" runat="server" class="myTextEditor" style="width: 100%"></textarea>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix">&nbsp;</div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Description</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <CKEditor:CKEditorControl ID="txtDes" BasePath="../Admin/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                                <%-- <ce:editor id="txtDes" runat="server" style="width: 600px; height:400px;">
                                </ce:editor>--%>
                                                <%--    <textarea id="txtDes" runat="server" class="myTextEditor" style="width: 100%"></textarea>--%>
                                            </div>
                                        </div>
                                    </div>   <div class="clearfix">&nbsp;</div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Terms & Condition</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="login-input-area">
                                                <CKEditor:CKEditorControl ID="txtTerms" BasePath="../Admin/ckeditor/" runat="server"></CKEditor:CKEditorControl> 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix">&nbsp;</div>
                                    <div class="row" runat="server" id="tag" visible="false">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Tags</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:ListBox ID="drpTag" runat="server" CssClass="form-control select2_demo_2" SelectionMode="Multiple"></asp:ListBox>
                                            <%-- <asp:DropDownList ID="drpCenter" runat="server" CssClass="form-control select2_demo_2" multiple="multiple">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hddTag" runat="server" />
                                            <asp:Literal ID="litTag" runat="server"></asp:Literal>--%>

                                            <%--<div class="bs-example">
                                                <input runat="server" id="txtTag" type="text" data-role="tagsinput" />
                                            </div>
                                            <br />--%>
                                            <%-- <span>Each tag has to be followed by a comma. The following characters are forbidden: !<;>;?=+#"°{}_$%.</span>--%>
                                        </div>
                                    </div>

                                    <div class="clearfix">&nbsp;</div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>GroupId</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txtGroupID" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                <p>Color</p>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="drpColor" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="clearfix">&nbsp;</div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class=" alignleft">
                                                <asp:LinkButton ID="btnInfoCancel" runat="server" OnClick="btnInfoCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true">Cancel</i></asp:LinkButton>
                                                <%-- <a href="User.aspx" class="btn btn-danger"></a>--%>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="alignright">
                                                <asp:LinkButton ID="btnInfoSaveAnd" runat="server" OnClientClick="this.onclick=new Function('return false;');" ValidationGroup="addInfo" CssClass="btn btn-primary" OnClick="btnInfoSaveAnd_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save and Stay</i></asp:LinkButton>
                                                <asp:LinkButton ID="btnSave" runat="server" OnClientClick="this.onclick=new Function('return false;');" ValidationGroup="addInfo" CssClass="btn btn-primary" OnClick="btnSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>
                                                <asp:LinkButton ID="btnAdddTag" runat="server" OnClientClick="this.onclick=new Function('return false;');" ValidationGroup="addInfo" CssClass="btn btn-primary" Visible="false" OnClick="btnAdddTag_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save Tag</i></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- PRICES Tab --%>
                            <div class="tabcontent" id="Prices" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">PRODUCT PRICE</span> </h1>

                                        </div>
                                    </div>

                                    <div class="login-bg">
                                        <div class="row hidden">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Wholesale price</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="">
                                                    <div class="input-group">
                                                        <span class="input-group-addon">₹</span>
                                                        <asp:TextBox ID="txtWholesaleprice" runat="server" CssClass=" form-control" Text="0" Width="200px" MaxLength="27"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Retail price</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="">
                                                    <div class="input-group">
                                                        <span class="input-group-addon">₹</span>
                                                        <asp:TextBox ID="txtRetailprice" runat="server" Text="0" CssClass=" form-control" Width="200px" MaxLength="27" onchange="RPrice(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row hidden">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Tax rule</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="drpTaxrule" runat="server" CssClass="select2_demo_2 form-control RequiredV">
                                                </asp:DropDownList>
                                            </div>
                                            <%--<div class="col-lg-4">
                                                <a href="addcategory.aspx">
                                                    <h4 style="text-align: center"><i class="fa fa-plus-square" aria-hidden="true">Create new tax </i></h4>
                                                </a>
                                            </div>--%>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;

                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="alert">
                                                    Taxes are currently disabled
				<a href="index.php?controller=AdminTaxes&amp;token=78af193ea98942967482170353fa6048">Click here to open the Taxes configuration page.</a>
                                                    <input type="hidden" value="0" name="id_tax_rules_group">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Unit price (tax excl.)</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">₹</span>
                                                    <asp:TextBox ID="txtUnitPrice" runat="server" Text="0" Height="35px" Width="100px" MaxLength="27" onchange="unitPrice(this)"></asp:TextBox>
                                                    <span class="input-group-addon">Per</span>
                                                    <asp:TextBox ID="txtUnit" runat="server" Height="35px" Width="70px" MaxLength="27" onchange="unit(this)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <%--<p>Meta title</p>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <div class="Alert alert-warning">
                                                        <ul style="padding: 10px">
                                                            <li><i style="margin-left: 5px; margin-right: 10px; margin-top: 10px; margin-bottom: 5px;" class="fa fa-exclamation-triangle " aria-hidden="true"></i>
                                                                or ₹ <span id="unitPrice" runat="server"></span>per  <span id="unit" runat="server"></span></li>

                                                        </ul>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <%--<p>Meta title</p>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <p>
                                                        <asp:CheckBox ID="chkOnSale" runat="server" />
                                                        Display the "on sale" icon on the product page, and in the text found within the product listing.
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <%--<p>Meta title</p>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <div class="Alert alert-warning">
                                                        <ul style="padding: 10px">
                                                            <li><i style="margin-left: 5px; margin-right: 10px; margin-top: 10px; margin-bottom: 5px;" class="fa fa-exclamation-triangle fa-2x" aria-hidden="true"></i>Final retail price ₹ <span id="RPrice" runat="server"></span></li>

                                                        </ul>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">

                                                    <asp:LinkButton ID="btnPriceCancel" runat="server" OnClick="btnPriceCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true"> Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <asp:LinkButton ID="btnPriceSaveAnd" runat="server" ValidationGroup="addPrice" CssClass="btn btn-primary" OnClick="btnPriceSaveAnd_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save and Stay</i></asp:LinkButton>
                                                    <asp:LinkButton ID="btnPriceSave" runat="server" ValidationGroup="addPrice" CssClass="btn btn-primary" OnClick="btnPriceSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--SPECIFIC PRICES Tab --%>
                                <div class="clearfix">&nbsp;</div>
                                <div class="sparkline13-list shadow-reset ">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">SPECIFIC PRICES</span> </h1>
                                        </div>
                                    </div>
                                    <div class="login-bg">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <%--<p>Meta title</p>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <div class="Alert alert-info">
                                                        <ul style="padding: 10px">
                                                            <li><i style="margin-left: 5px; margin-right: 10px; margin-top: 10px; margin-bottom: 5px;" class="fa fa-question-circle fa-2x" aria-hidden="true"></i>You can set specific prices for clients belonging to different groups, different countries, etc.</li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="login-input-area">
                                                    <div class="list-group">
                                                        <ul>
                                                            <li class="list-group-item" onclick="specific1()" id="lispecific1">
                                                                <a class="btn btn-default" href="#" id="show_specific_price1" style="display: inline-block;">
                                                                    <i class="fa fa-plus fa-adjust"></i>Add a new specific price
                                                                </a>
                                                            </li>
                                                            <li class="list-group-item tablinks" id="liCancel2" onclick="Cancel1()" style="display: none">
                                                                <a class="btn btn-default" href="#Cancel"><i class="fa fa-times fa-adjust"></i>Cancel new specific price
                                                                </a></li>
                                                        </ul>
                                                    </div>
                                                    <div id="specific1" style="display: none">
                                                        <div class="sparkline13-list shadow-reset ">
                                                            <div class="sparkline13-hd">
                                                                <div class="main-sparkline13-hd">
                                                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">SPECIFIC PRICES</span> </h1>
                                                                </div>
                                                            </div>
                                                            <div class="login-bg">
                                                                <div class="row">
                                                                    <%--  <label class="control-label col-lg-2" for="spm_currency_0">For</label>--%>
                                                                    <div class="col-lg-3 hide" style="margin-right: 10px">
                                                                        <asp:DropDownList ID="drpCurrency" runat="server" CssClass="form-control">
                                                                            <asp:ListItem Value="0">All currencies</asp:ListItem>
                                                                            <asp:ListItem Value="1">Dollar</asp:ListItem>
                                                                            <asp:ListItem Value="2">Euro</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>

                                                                    <div class="col-lg-3 hide" style="margin-right: 10px">
                                                                        <asp:DropDownList ID="DrpGroup" runat="server" CssClass="form-control">
                                                                            <asp:ListItem Value="0">All groups</asp:ListItem>
                                                                            <asp:ListItem Value="1">Visitor</asp:ListItem>
                                                                            <asp:ListItem Value="2">Guest</asp:ListItem>
                                                                            <asp:ListItem Value="3">Customer</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix">&nbsp;</div>
                                                                <div class="row">
                                                                    <%-- <label class="control-label col-lg-2" for="customer">Country</label>--%>
                                                                    <div class="col-lg-3 hide" style="margin-right: 10px">
                                                                        <asp:DropDownList ID="drpCountry" runat="server" CssClass="form-control">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <label class="control-label col-lg-2" for="customer">Customer</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:DropDownList ID="DrpCustomer" runat="server" CssClass="form-control">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix">&nbsp;</div>
                                                                <div class="row">
                                                                    <label class="control-label col-lg-2" for="sp_id_product_attribute">Combination</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:DropDownList ID="drpCombination" runat="server" CssClass="form-control">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix">&nbsp;</div>
                                                                <div class="row">
                                                                    <div class="col-lg-2">
                                                                        <label class="control-label " for="sp_id_product_attribute" style="margin-top: 15px;">From</label>
                                                                    </div>
                                                                    <div class="col-lg-4" style="margin-right: 10px">
                                                                        <asp:TextBox ID="txtFDate" CssClass="form-control datePicK" runat="server" placeholder="From"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-lg-1">
                                                                        <label class="control-label " for="sp_id_product_attribute" style="margin-top: 15px;">To</label>
                                                                    </div>
                                                                    <div class="col-lg-4">
                                                                        <asp:TextBox ID="txtTo" CssClass="form-control datePicK" runat="server" placeholder="To"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix">&nbsp;</div>
                                                                <div class="row">
                                                                    <label class="control-label col-lg-2" for="sp_from_quantity">Starting at(unit)</label>
                                                                    <div class="col-lg-4">

                                                                        <asp:TextBox ID="txtStarunit" CssClass="form-control" runat="server" Text="1"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix">&nbsp;</div>
                                                                <div class="row">
                                                                    <label class="control-label col-lg-2" for="sp_price" style="margin-top: 15px;">
                                                                        Product price
											(tax excl in ₹)
                                                                    </label>
                                                                    <div class="col-lg-4">
                                                                        <asp:TextBox ID="txtProductPrice" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        <p>
                                                                            <label for="leave_bprice">Leave base price </label>
                                                                            <input type="checkbox" runat="server" id="leave_bprice" name="leave_bprice" />
                                                                        </p>
                                                                    </div>
                                                                </div>
                                                                <div class="clearfix">&nbsp;</div>
                                                                <div class="row">
                                                                    <label class="control-label col-lg-2" for="sp_reduction" style="margin-top: 15px;">Apply a discount of</label>
                                                                    <div class="col-lg-2" style="margin-right: 10px;">
                                                                        <asp:TextBox ID="txtDescount" CssClass="form-control" runat="server" Text="0"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-lg-2" style="margin-right: 10px; margin-top: 10px">
                                                                        <asp:DropDownList ID="drpDisType" runat="server" CssClass="form-control">
                                                                            <asp:ListItem Value="percentage">%</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-lg-3 hidden" style="margin-right: 10px; margin-top: 10px">
                                                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                                                            <asp:ListItem Value="0">Tax excluded</asp:ListItem>
                                                                            <asp:ListItem Value="1">Tax included</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <table id="specific_prices_list" class="table table-bordered">
                                                            <thead>
                                                                <tr>
                                                                    <th>Rule</th>
                                                                    <th>Combination</th>
                                                                    <th>Currency</th>
                                                                    <th>Country</th>
                                                                    <th>Group</th>
                                                                    <th>Customer</th>
                                                                    <th>Fixed price (tax excl.)</th>
                                                                    <th>Impact</th>
                                                                    <th>Period</th>
                                                                    <th>From (quantity)</th>
                                                                    <th>Action</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:Repeater ID="rptSpecificPrice" runat="server" OnItemCommand="rptSpecificPrice_ItemCommand">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>--
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("combinations") %>
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("CurrencieName") %>
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("CountryName") %>
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("groupName") %>
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("customersName") %>
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("price1") %>
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("reduction1") %>
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("Period") %>
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("from_quantity") %>
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                                                    CommandArgument='<%#Eval("id_specific_price") %>' Style="width: 25px; padding: 4px 3px;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                                <tr id="trNoData" runat="server" visible="false">
                                                                    <td class="text-center" colspan="13"><i class="icon-warning-sign"></i>&nbsp;No specific prices.</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix">&nbsp;</div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class=" alignleft">

                                                        <asp:LinkButton ID="btnSpecificCancel" runat="server" OnClick="btnSpecificCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true"> Cancel</i></asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="alignright">
                                                        <asp:LinkButton ID="btnSpecificSaveAnd" runat="server" ValidationGroup="addSpec" CssClass="btn btn-primary" OnClick="btnSpecificSaveAnd_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save and Stay</i></asp:LinkButton>
                                                        <asp:LinkButton ID="btnSpecificSave" runat="server" ValidationGroup="addSpec" CssClass="btn btn-primary" OnClick="btnSpecificSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--PRIORITY MANAGEMENT Tab --%>
                                <div class="clearfix">&nbsp;</div>
                                <div class="sparkline13-list shadow-reset hide">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">PRIORITY MANAGEMENT</span> </h1>
                                        </div>
                                    </div>
                                    <div class="login-bg">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <%--<p>Meta title</p>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <div class="Alert alert-info">
                                                        <ul style="padding: 10px">
                                                            <li><i style="margin-left: 5px; margin-right: 10px; margin-top: 10px; margin-bottom: 5px;" class="fa fa-question-circle fa-2x" aria-hidden="true"></i>Sometimes one customer can fit into multiple price rules. Priorities allow you to define which rule applies to the customer.</li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="login-input-area">
                                                    <div id="PriorityManagement">
                                                        <div class="row">
                                                            <label class="control-label col-lg-2 pad-l20" for="spm_currency_0">Priorities</label>
                                                            <div class="col-lg-3" style="margin-right: 10px">
                                                                <asp:DropDownList ID="drpPriority1" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="id_shop" Selected="True">Shop</asp:ListItem>
                                                                    <asp:ListItem Value="id_currency">Currency</asp:ListItem>
                                                                    <asp:ListItem Value="id_country">Country</asp:ListItem>
                                                                    <asp:ListItem Value="id_group">Group</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-2" style="margin-right: 10px">
                                                                <asp:DropDownList ID="drpPriority2" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="id_shop">Shop</asp:ListItem>
                                                                    <asp:ListItem Value="id_currency" Selected="True">Currency</asp:ListItem>
                                                                    <asp:ListItem Value="id_country">Country</asp:ListItem>
                                                                    <asp:ListItem Value="id_group">Group</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-2" style="margin-right: 10px">
                                                                <asp:DropDownList ID="drpPriority3" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="id_shop">Shop</asp:ListItem>
                                                                    <asp:ListItem Value="id_currency">Currency</asp:ListItem>
                                                                    <asp:ListItem Value="id_country" Selected="True">Country</asp:ListItem>
                                                                    <asp:ListItem Value="id_group">Group</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-2" style="margin-right: 10px">
                                                                <asp:DropDownList ID="drpPriority4" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="id_shop">Shop</asp:ListItem>
                                                                    <asp:ListItem Value="id_currency">Currency</asp:ListItem>
                                                                    <asp:ListItem Value="id_country">Country</asp:ListItem>
                                                                    <asp:ListItem Value="id_group" Selected="True">Group</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix">&nbsp;</div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">

                                                    <asp:LinkButton ID="btnPriorityMngCancel" runat="server" OnClick="btnPriorityMngCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true"> Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <asp:LinkButton ID="btnPriorityMngSaveAdd" runat="server" CssClass="btn btn-primary" OnClick="btnPriorityMngSaveAdd_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save and Stay</i></asp:LinkButton>
                                                    <asp:LinkButton ID="btnPriorityMngSave" runat="server" CssClass="btn btn-primary" OnClick="btnPriorityMngSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%-- SEO Tab --%>
                            <div class="tabcontent" id="SEO" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">SEO</span> </h1>

                                        </div>
                                    </div>

                                    <div class="login-bg">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                              <%-- <div class="compose-multiple-email">
                                                   <input type="email" name="recipient_email" id="recipient_email" class="form-control">
                                               </div>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Meta title</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><span id="mtitle">70</span></span>
                                                    <asp:TextBox ID="txtMetatitle" runat="server" CssClass=" form-control"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Meta description</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><span id="mDes">160</span></span>
                                                    <asp:TextBox ID="txtMetadescription" runat="server" CssClass=" form-control" Height="200px" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                       
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Friendly URL</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="login-input-area">
                                                    <asp:TextBox ID="txtUrl" runat="server" CssClass=" form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <%--  <div class="col-lg-2">
                                                <a href="addcategory.aspx">
                                                    <asp:LinkButton ID="btnGenerate" runat="server" OnClientClick="Generate()"><i class="fa fa-random" aria-hidden="true"></i>Generate</asp:LinkButton>
                                                </a>
                                            </div>--%>
                                        </div>
                                        <div class="row ">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <div class="Alert alert-warning">
                                                        <ul style="padding: 10px">
                                                            <li><i style="margin-left: 5px; margin-right: 10px; margin-top: 10px; margin-bottom: 5px;" class=" fa fa-link" aria-hidden="true"></i>The product link will look like this</li>
                                                            <li>
                                                                <asp:Label ID="lblUrl" runat="server"></asp:Label></li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">
                                                    <asp:LinkButton ID="btnSCOCancel" runat="server" OnClick="btnSCOCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true"> Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <asp:LinkButton ID="btnSEOSaveAnd" runat="server" ValidationGroup="addSEO" CssClass="btn btn-primary" OnClick="btnSEOSaveAnd_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save and Stay</i></asp:LinkButton>
                                                    <asp:LinkButton ID="btnSEOSave" runat="server" ValidationGroup="addSEO" CssClass="btn btn-primary" OnClick="btnSEOSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>

                                                </div>
                                            </div>
                                        </div>
                                    </div>



                                </div>
                            </div>
                            <%-- Associations Tab --%>
                            <div class="tabcontent" id="Associations" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">ASSOCIATIONS</span> </h1>
                                        </div>
                                    </div>

                                    <div class="login-bg">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                              <%-- <div class="compose-multiple-email">
                                                   <input type="email" name="recipient_email" id="recipient_email" class="form-control">
                                               </div>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Associated Categories</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <ul class="list-group" id="myUL">
                                                    <li class="list-group-item ">
                                                        <span class="box check-box">
                                                            <span class="valueTwo hidden">2</span>
                                                            <input type="checkbox" id="chkHome" class="shan box" />
                                                            <span class="valueOne">Home</span>
                                                        </span>
                                                        <ul class="list-group nested active" id="myUL1">
                                                            <asp:Repeater ID="repCat" runat="server" OnItemDataBound="repCat_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <li class="list-group-item">
                                                                        <%-- <span class="valueTwo"><%#Eval("name") %></span>--%>
                                                                        <asp:Label ID="lblID" runat="server" CssClass="bb valueOne" Text='<%#Eval("id_category") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblCarname" runat="server" Text='<%#Eval("name") %>' Visible="false"></asp:Label>
                                                                        <span class="valueTwo hidden"><%#Eval("id_category") %></span>
                                                                        <input id="chk1" runat="server" type="checkbox" class="shan" value='<%#Eval("name") %>' />
                                                                        <span class="valueOne"><%#Eval("name") %></span>
                                                                        <asp:Repeater ID="repSub" runat="server" OnItemDataBound="repSub_ItemDataBound">
                                                                            <ItemTemplate>
                                                                                <ul class="list-group nested active" id="myUL2">
                                                                                    <li class="list-group-item">
                                                                                        <asp:Label ID="lblParentId" runat="server" Text='<%#Eval("id_parent") %>' Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblID" runat="server" CssClass="bb valueOne" Text='<%#Eval("id_category") %>' Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblSubCatName" runat="server" Text='<%#Eval("name") %>' Visible="false"></asp:Label>
                                                                                        <span class="valueTwo hidden"><%#Eval("id_category") %></span>
                                                                                        <input type="checkbox" id="chk1" runat="server" class="shan box" value='<%#Eval("name") %>' />
                                                                                        <span class="valueOne"><%#Eval("name") %></span>
                                                                                         <asp:Repeater ID="repSub2" runat="server" OnItemDataBound="repSub2_ItemDataBound">
                                                                                            <ItemTemplate>
                                                                                                <ul class="list-group nested active" id="myUL2">
                                                                                                    <li class="list-group-item">
                                                                                                        <asp:Label ID="lblSubParentId" runat="server" Text='<%#Eval("id_parent") %>' Visible="false"></asp:Label>
                                                                                                        <asp:Label ID="lblSubID" runat="server" CssClass="bb valueOne" Text='<%#Eval("id_category") %>' Visible="false"></asp:Label>
                                                                                                        <asp:Label ID="lblSubCatName2" runat="server" Text='<%#Eval("name") %>' Visible="false"></asp:Label>
                                                                                                        <span class="valueTwo hidden"><%#Eval("id_category") %></span>
                                                                                                        <input type="checkbox" id="chk2" runat="server" class="shan box" value='<%#Eval("name") %>' />
                                                                                                        <span class="valueOne"><%#Eval("name") %></span>
                                                                                                    </li>
                                                                                                </ul>
                                                                                            </ItemTemplate>
                                                                                        </asp:Repeater>
                                                                                    </li>
                                                                                </ul>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                        </span></li>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ul>
                                                    </li>
                                                </ul>
                                                <br />
                                                <asp:LinkButton ID="btnAddcat" runat="server" CssClass="btn btn-link bt-icon confirm_leave" OnClick="btnAddcat_Click"><i class=" fa fa-plus"></i> Create new category <i class=" fa fa-external-link"></i></asp:LinkButton>

                                            </div>

                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                              <%-- <div class="compose-multiple-email">
                                                   <input type="email" name="recipient_email" id="recipient_email" class="form-control">
                                               </div>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Default category</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <asp:DropDownList ID="drpDefaultCat" runat="server" CssClass="form-control custom-select-value" Width="250px"></asp:DropDownList>

                                                </div>


                                            </div>
                                        </div>

                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Size Chart category</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <asp:DropDownList ID="drpSizeChart" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Is Personalized</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <asp:DropDownList ID="drpPersonalized" runat="server" CssClass="form-control" Width="250px">
                                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>

                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">
                                                    <asp:LinkButton ID="btnAssoCancel" runat="server" OnClick="btnAssoCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true"> Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <asp:LinkButton ID="btnAssociateSaveAnd" runat="server" ValidationGroup="asso" CssClass="btn btn-primary" OnClick="btnAssociateSaveAnd_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save and Stay</i></asp:LinkButton>
                                                    <asp:LinkButton ID="btnAssociateSave" runat="server" ValidationGroup="asso" CssClass="btn btn-primary" OnClick="btnAssociateSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>

                                                </div>
                                            </div>
                                        </div>
                                    </div>



                                </div>
                            </div>

                            <%-- Combinations Tab --%>
                            <%--<asp:UpdatePanel ID="updateCombinations" runat="server">
                                <ContentTemplate>--%>
                            <div class="tabcontent" id="Combinations" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">ADD OR MODIFY COMBINATIONS FOR THIS PRODUCT</span> </h1>

                                        </div>
                                    </div>

                                    <div class="login-bg">
                                        <div class="alert alert-info">
                                            You can also use the 
                                            <asp:LinkButton ID="btnGenerat" runat="server" CssClass="btn btn-link bt-icon confirm_leave" OnClick="btnGenerat_Click"><i class="icon-external-link-sign">Product Combinations Generator</i></asp:LinkButton>
                                            in order to automatically create a set of combinations.
                                        </div>
                                        <div id="specific" style="display: none;">

                                            <div class="row">
                                                <div class="col-lg-2">
                                                    &nbsp;
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:Label ID="lblCombinationId" runat="server" Visible="false"></asp:Label>
                                                    <asp:HiddenField runat="server" ID="hddCombinationId" />
                                                    <div class="login-input-head alignright" style="margin-right: 10px">
                                                        <p>Attribute</p>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">
                                                    <div class="login-input-area">
                                                        <asp:DropDownList ID="drpAttribute" runat="server" Style="width: 300px" CssClass="form-control custom-select-value select2_demo_2" OnSelectedIndexChanged="drpAttribute_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Value</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="login-input-area">
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="drpValue" runat="server" Style="width: 400px" CssClass="form-control custom-select-value select2_demo_2">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="drpAttribute" EventName="SelectedIndexChanged" />

                                                                    </Triggers>
                                                                </asp:UpdatePanel>

                                                                <br />
                                                                <br />
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                    <ContentTemplate>
                                                                        <asp:ListBox runat="server" ID="listValue" Width="400px" Height="150px"></asp:ListBox>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="btnAddAtr" EventName="Click" />
                                                                        <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>

                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Button ID="btnAddAtr" runat="server" Text="Add" CssClass="btn btn-default" OnClick="btnAddAtr_Click" /><br />
                                                            <br />
                                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-default" OnClick="btnDelete_Click" />
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Reference code</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <div class="login-input-area">
                                                                <asp:TextBox ID="txtRefCode" runat="server" Width="400px" CssClass=" form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Wholesale price</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <div class="login-input-area">
                                                                <asp:TextBox ID="txtHolsalePrice" runat="server" Text="0" Width="200px" CssClass=" form-control"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Impact on price</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="login-input-area">
                                                                <asp:DropDownList ID="drpImpactPrice" runat="server" Style="width: 200px" CssClass="form-control custom-select-value select2_demo_2">
                                                                    <asp:ListItem Value="0">None</asp:ListItem>
                                                                    <asp:ListItem Value="1">Increase</asp:ListItem>
                                                                    <asp:ListItem Value="-1">Decrease</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">of</span>&nbsp;&nbsp;&nbsp;
                                                        <span class="input-group-addon">₹ (tax excl.)</span>
                                                                <asp:TextBox ID="txtImpactPrice" runat="server" Text="0.00" CssClass="form-control" Width="190px" MaxLength="27"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row hidden">
                                                        <div class="col-lg-7">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">or</span>&nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtImpactOrPrice" runat="server" Text="0.00" CssClass="form-control" Width="190px" MaxLength="27"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">&nbsp;</div>
                                                    <div class="row">
                                                        <div class="col-lg-1">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Impact on weight</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="login-input-area">
                                                                <asp:DropDownList ID="drpImpactWeight" runat="server" Style="width: 230px" CssClass="form-control custom-select-value select2_demo_2">
                                                                    <asp:ListItem Value="0">None</asp:ListItem>
                                                                    <asp:ListItem Value="1">Increase</asp:ListItem>
                                                                    <asp:ListItem Value="-1">Decrease</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">of</span>&nbsp;&nbsp;&nbsp;
                                                        <span class="input-group-addon">Cts</span>
                                                                <asp:TextBox ID="txtImpactW" runat="server" CssClass="form-control" Width="200px" MaxLength="27"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row hidden">
                                                        <div class="col-lg-1">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Impact on unit price</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="login-input-area">
                                                                <asp:DropDownList ID="drpImpactUnit" runat="server" Style="width: 230px" CssClass="form-control custom-select-value select2_demo_2">
                                                                    <asp:ListItem Value="0">None</asp:ListItem>
                                                                    <asp:ListItem Value="1">Increase</asp:ListItem>
                                                                    <asp:ListItem Value="-1">Decrease</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">of</span>&nbsp;&nbsp;&nbsp;
                                                        <span class="input-group-addon">₹ / pair</span>
                                                                <asp:TextBox ID="txtImpactUnitP" runat="server" Text="0.00" CssClass="form-control" Width="190px" MaxLength="27"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Minimum quantity</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">x</span>
                                                                <asp:TextBox ID="txtMinumamQty" runat="server" Text="1" CssClass="form-control" Width="100px" MaxLength="27"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Availability date</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <div class="input-group">
                                                                <asp:TextBox ID="txtAvlDate" CssClass="form-control datePicK" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                                <%--<input type="date" name="txtAvlDate" class="form-control" id="txtAvlDate" value="<%= txtAvlDate %>" style="width: 170px" />--%>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <hr />

                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                Image :
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <asp:Repeater ID="repCombImage" runat="server">
                                                                <ItemTemplate>

                                                                    <div class="col-lg-3">
                                                                        <asp:Label ID="lblImgId" runat="server" Text='<%#Eval("id_image") %>' Visible="false"></asp:Label>
                                                                        <asp:CheckBox ID="chkCompImag" runat="server" />
                                                                        <img src='<%#Eval("ImageUrl") %>' height="100px" width="100px" style="margin-bottom: 10px;" />
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                Default :
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <div class="login-input-area">
                                                                <p>
                                                                    <asp:CheckBox ID="chkDefaultComb" runat="server" />
                                                                    Make this combination the default combination for this product.
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class=" alignleft">
                                                                <ul>
                                                                    <li class="tablinks" id="liCancel1" onclick="Cancel()">
                                                                        <a class="btn btn-default" href="#Cancel"><i class="fa fa-undo fa-2x"></i>

                                                                            Cancel combination
                                                                        </a>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="drpAttribute" EventName="SelectedIndexChanged" />

                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">

                                            <div class="col-lg-12">
                                                <div class="datatable-dashv1-list custom-datatable-overright">
                                                    <table id="table" data-toggle="table" data-toolbar="#toolbar">
                                                        <thead>
                                                            <tr class="nodrag nodrop">
                                                                <th class=" left">
                                                                    <span class="title_box">Attribute - value pair
                                                                    </span>
                                                                </th>
                                                                <th class=" left">
                                                                    <span class="title_box">Impact on price
                                                                    </span>
                                                                </th>
                                                                <th class=" left">
                                                                    <span class="title_box">Impact on weight
                                                                    </span>
                                                                </th>
                                                                <th class=" left">
                                                                    <span class="title_box">Reference
                                                                    </span>
                                                                </th>
                                                                <th class=" left">
                                                                    <span class="title_box">Min. Qty
                                                                    </span>
                                                                </th>
                                                                <th>&emsp;&emsp;&emsp;&emsp;&emsp;</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:Repeater ID="repComb" runat="server" OnItemCommand="repComb_ItemCommand" OnItemDataBound="repComb_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <tr class="odd selected-line " id="trActive" runat="server">
                                                                        <td class=" left">
                                                                            <%#Eval("pair") %>
                                                                            <asp:Label ID="lblCompId" runat="server" Text='<%#Eval("id_product_attribute") %>' Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblActiveID" runat="server" Text='<%#Eval("default_on") %>' Visible="false"></asp:Label>
                                                                        </td>
                                                                        <td class=" left"><%#Eval("price") %></td>
                                                                        <td class=" left"><%#Eval("weight") %></td>
                                                                        <td class=" left"><%#Eval("reference") %></td>
                                                                        <td><span style="margin-left: 30%;"><%#Eval("minimal_quantity") %></span>
                                                                        </td>
                                                                        <td class="text-right">
                                                                            <div class="row">
                                                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" OnClientClick="specific()" CssClass="btn btn-custon-rounded-three btn-primary"
                                                                                    CommandArgument='<%#Eval("id_product_attribute") %>'><i class="fa fa-pencil-square-o fa-align-center" style="color: white;"></i></asp:LinkButton>
                                                                                <asp:LinkButton ID="LinkButton9" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                                                    CommandArgument='<%#Eval("id_product_attribute") %>' Style="width: 25px; padding: 4px 3px;"><i class="fa fa-trash-o" style="color: white;"></i></asp:LinkButton>
                                                                            </div>


                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>

                                                        </tbody>

                                                    </table>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                    </div>
                                                </div>


                                            </div>
                                        </div>


                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <div class=" alignleft">
                                                    <asp:LinkButton ID="btnCombCancel" runat="server" OnClick="btnCombCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true">Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-9">
                                                <div class="alignright">
                                                    <ul>
                                                        <li class="floatleft" onclick="specific()" id="lispecific">
                                                            <a class="btn btn-default" href="#" id="show_specific_price" style="display: inline-block; margin-right: 10px">
                                                                <i class="fa fa-plus fa-adjust "></i>
                                                                New combination
                                                            </a>
                                                        </li>
                                                        <li class="floatleft tablinks" id="liCancel" onclick="Cancel()" style="display: none; margin-right: 10px">
                                                            <a class="btn btn-default" href="#Cancel"><i class="fa fa-minus-square-o "></i>
                                                                Cancel combination
                                                            </a></li>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnCombSaveAnd" runat="server" CssClass="btn btn-default" OnClick="btnCombSaveAnd_Click" Style="margin-right: 10px"><i  class="fa fa-floppy-o " aria-hidden="true">Save and Stay</i></asp:LinkButton></li>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnCombSave" runat="server" CssClass="btn btn-default" OnClick="btnCombSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true">Save</i></asp:LinkButton></li>
                                                    </ul>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                            <%-- Shipping Tab --%>
                            <div class="tabcontent" id="Shipping" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">SHIPPING</span> </h1>

                                        </div>
                                    </div>

                                    <div class="login-bg ">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Package width</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="">
                                                    <div class="input-group">
                                                        <span class="input-group-addon">CM</span>
                                                        <asp:TextBox ID="txtPackegW" runat="server" placeholder="0.000000" CssClass=" form-control" Width="200px" MaxLength="27"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Package height</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="">
                                                    <div class="input-group">
                                                        <span class="input-group-addon">CM</span>
                                                        <asp:TextBox ID="txtPackageH" runat="server" placeholder="0.000000" CssClass=" form-control" Width="200px" MaxLength="27"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Package depth</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="">
                                                    <div class="input-group">
                                                        <span class="input-group-addon">CM</span>
                                                        <asp:TextBox ID="txtPackagD" runat="server" placeholder="0.000000" CssClass=" form-control" Width="200px" MaxLength="27"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Package weight</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="">
                                                    <div class="input-group">
                                                        <span class="input-group-addon">KG</span>
                                                        <asp:TextBox ID="txtPackageweight" runat="server" placeholder="0.000000" CssClass=" form-control" Width="200px" MaxLength="27"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Additional shipping fees (for a single item)</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="">
                                                    <div class="input-group">
                                                        <span class="input-group-addon">₹ (tax excl.)</span>
                                                        <asp:TextBox ID="txtAddFee" runat="server" placeholder="0.00" CssClass=" form-control" Width="100px" MaxLength="27"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row hidden">
                                            <div class="col-lg-2">
                                                &nbsp;

                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>
                                                        Carriers Available carriers
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="dual-list-box-inner">
                                                    <div id="form" action="#" class="wizard-big">
                                                        <select class="form-control dual_select" multiple>
                                                            <option value="United States">United States</option>
                                                            <option value="United Kingdom">United Kingdom</option>
                                                            <option value="Australia">Australia</option>
                                                            <option selected value="Austria">Austria</option>
                                                            <option selected value="Bahamas">Bahamas</option>
                                                            <option value="Barbados">Barbados</option>
                                                            <option value="Belgium">Belgium</option>
                                                            <option value="Bermuda">Bermuda</option>
                                                            <option value="Brazil">Brazil</option>
                                                            <option value="Bulgaria">Bulgaria</option>
                                                            <option value="Cameroon">Cameroon</option>
                                                            <option value="Canada">Canada</option>
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">

                                                    <asp:LinkButton ID="btnShippingCancel" runat="server" OnClick="btnShippingCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true"> Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <asp:LinkButton ID="btnSpSaveAnd" runat="server" ValidationGroup="addSP" CssClass="btn btn-primary" OnClick="btnSpSaveAnd_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save and Stay</i></asp:LinkButton>
                                                    <asp:LinkButton ID="btnSpSave" runat="server" ValidationGroup="addSP" CssClass="btn btn-primary" OnClick="btnSpSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>

                                                </div>
                                            </div>
                                        </div>
                                    </div>



                                </div>
                            </div>

                            <%-- AVAILABLE QUANTITIES FOR SALE Tab --%>
                            <div class="tabcontent" id="Quantities" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">AVAILABLE QUANTITIES FOR SALE</span> </h1>

                                        </div>
                                    </div>
                                    <div class="login-bg">
                                        <%--<div class="row">
                                            <div class="col-lg-12">
                                                <div class="alert alert-info">
                                                    <p style="margin-left: 5px; margin-right: 10px; margin-top: 10px; margin-bottom: 5px; font: normal normal normal 13px/2 FontAwesome;">
                                                        <i class="fa fa-exclamation-triangle fa-2x" aria-hidden="true"></i>This interface allows you to manage available quantities for sale for products. It also allows you to manage product combinations in the current shop.<br>
                                                        You can choose whether or not to use the advanced stock management system for this product.<br>
                                                        You can manually specify the quantities for the product/each product combination, or you can choose to automatically determine these quantities based on your stock (if advanced stock management is activated).<br>
                                                        In this case, quantities correspond to the real-stock quantities in the warehouses connected with the current shop, or current group of shops.<br>
                                                        For packs: If it has products that use advanced stock management, you have to specify a common warehouse for these products in the pack.<br>
                                                        Also, please note that when a product has combinations, its default combination will be used in stock movements.
                                                    </p>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div class="row hidden">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">

                                                    <p class="checkbox">
                                                        <label for="advanced_stock_management">
                                                            <input type="checkbox" id="advanced_stock_management" name="advanced_stock_management" class="advanced_stock_management">
                                                            I want to use the advanced stock management system for this product.
                                                        </label>
                                                    </p>
                                                    <p class="help-block"><i class="fa fa-exclamation-triangle" aria-hidden="true"></i>&nbsp;This requires you to enable advanced stock management.</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row hide">
                                            <div class="col-lg-2">
                                                &nbsp;
                                       
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <%--<p>Friendly URL</p>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <p class="radio">
                                                        <label for="depends_on_stock_1">
                                                            <input type="radio" id="depends_on_stock_1" runat="server" name="depends_on_stock" class="depends_on_stock" value="1" />
                                                            The available quantities for the current product and its combinations are based on the stock in your warehouse (using the advanced stock management system). 
								 &nbsp;-&nbsp;This requires you to enable advanced stock management globally or for this product.
                                                        </label>
                                                    </p>
                                                    <p class="radio">
                                                        <label for="depends_on_stock_0">
                                                            <input type="radio" id="depends_on_stock_0" runat="server" name="depends_on_stock" class="depends_on_stock" value="0" />
                                                            I want to specify available quantities manually.
                                                        </label>
                                                    </p>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row     ">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="datatable-dashv1-list custom-datatable-overright">
                                                    <table id="table" data-toggle="table" data-toolbar="#toolbar">
                                                        <thead>
                                                            <tr class="nodrag nodrop">
                                                                <th class=" left">
                                                                    <span class="title_box">Quantity
                                                                    </span>
                                                                </th>
                                                                <th class=" left">
                                                                    <span class="title_box">Designation
                                                                    </span>
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:Repeater ID="repQuantity" runat="server">
                                                                <ItemTemplate>
                                                                    <tr class="highlighted odd selected-line">
                                                                        <td class=" left">
                                                                            <asp:Label ID="lblQuantityid" runat="server" Visible="false" Text='<%#Eval("id_product_attribute") %>'></asp:Label>
                                                                            <asp:TextBox ID="txtQQty" runat="server" Width="70px" Text='<%#Eval("qty") %>'></asp:TextBox>
                                                                        </td>
                                                                        <td class=" left"><%#Eval("pair") %>
                                                                        </td>

                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>

                                                        </tbody>

                                                    </table>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                    </div>
                                                </div>


                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>When out of stock</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <p class="radio">
                                                        <label id="label_out_of_stock_1" for="out_of_stock_1">
                                                            <input type="radio" id="out_of_stock" runat="server" name="out_of_stock" value="0" class="out_of_stock" />
                                                            Deny orders
                                                        </label>
                                                    </p>
                                                    <p class="radio">
                                                        <label id="label_out_of_stock_2" for="out_of_stock_2">
                                                            <input type="radio" id="out_of_stock_2" runat="server" name="out_of_stock" value="1" class="out_of_stock" />
                                                            Allow orders
                                                        </label>
                                                    </p>
                                                    <p class="radio hidden">
                                                        <label id="label_out_of_stock_3" for="out_of_stock_3">
                                                            <input type="radio" id="out_of_stock_3" runat="server" name="out_of_stock" value="2" class="out_of_stock" />
                                                            Default:
																Allow orders
																<%--<a class="link" href="#">as set in the Products Preferences page
                                                                </a>--%>
                                                        </label>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">
                                                    <asp:LinkButton ID="btnQueCancel" runat="server" OnClick="btnQueCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true">Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <ul>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnQSaveAnd" runat="server" CssClass="btn btn-default" OnClick="btnQSaveAnd_Click" Style="margin-right: 10px"><i  class="fa fa-floppy-o " aria-hidden="true">Save and Stay</i></asp:LinkButton></li>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnQSave" runat="server" CssClass="btn btn-default" OnClick="btnQSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true">Save</i></asp:LinkButton></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix">&nbsp;</div>
                                <div class="sparkline13-list shadow-reset ">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">AVAILABILITY SETTINGS</span> </h1>
                                        </div>
                                    </div>
                                    <div class="login-bg">
                                        <div class="row" runat="server" id="minimum" visible="false">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Minimum quantity</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <asp:TextBox ID="txtStockMinQty" runat="server" CssClass="form-control" Text="In Stock"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Displayed text when in-stock</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <asp:TextBox ID="txtavailable_now" runat="server" CssClass="form-control" Text="In Stock"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Displayed text when backordering is allowed</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <asp:TextBox ID="txtavailable_later" runat="server" Text="In Stock" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">

                                                    <asp:LinkButton ID="btnAvalCancel" runat="server" OnClick="btnAvalCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true">Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <ul>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnQASaveAnd" runat="server" CssClass="btn btn-default" OnClick="btnQASaveAnd_Click" Style="margin-right: 10px"><i  class="fa fa-floppy-o " aria-hidden="true">Save and Stay</i></asp:LinkButton></li>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnQASave" runat="server" CssClass="btn btn-default" OnClick="btnQASave_Click"><i  class="fa fa-floppy-o " aria-hidden="true">Save</i></asp:LinkButton></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <%-- Image Tab --%>
                            <div class="tabcontent" id="Images" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">IMAGES </span></h1>

                                        </div>
                                    </div>
                                    <div class="login-bg">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                              <%-- <div class="compose-multiple-email">
                                                   <input type="email" name="recipient_email" id="recipient_email" class="form-control">
                                               </div>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Upload image </p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area" style="margin-top: 10px;">
                                                    <asp:FileUpload ID="flpCover" runat="server" multiple="multiple" />
                                                    <%--<asp:FileUpload ID="flpCover" runat="server" class="multi" AllowMultiple="true" />--%>
                                                    <hr />
                                                    <div id="dvPreview">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Image Link</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="login-input-area ">
                                                    <asp:TextBox ID="txtImageLink" runat="server" CssClass=" form-control" Width="400px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Caption</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="login-input-area ">
                                                    <asp:TextBox ID="txtCaption" runat="server" CssClass=" form-control" Width="400px"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:DropDownList ID="drpPosition" runat="server" CssClass=" form-control"></asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Button ID="btnAddFile" runat="server" OnClick="btnAddFile_Click" Text="Add" CssClass="btn btn-default" />
                                                <asp:Button ID="btnCaptionUpdate" runat="server" OnClick="btnCaptionUpdate_Click" Text="Update" CssClass="btn btn-default" />
                                                <asp:Button ID="btnPosition" runat="server" OnClick="btnPosition_Click" Text="Set Position" CssClass="btn btn-default" />
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">

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

                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">
                                                    <asp:LinkButton ID="btnImagCancel" runat="server" OnClick="btnImagCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true"> Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <asp:LinkButton ID="LinkButton11" runat="server" ValidationGroup="addSEO" CssClass="btn btn-primary" OnClick="btnSEOSaveAnd_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save and Stay</i></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton12" runat="server" ValidationGroup="addSEO" CssClass="btn btn-primary" OnClick="btnSEOSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%-- ASSIGN FEATURES TO THIS PRODUCT--%>
                            <div class="tabcontent" id="Features" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">ASSIGN FEATURES TO THIS PRODUCT</span> </h1>
                                        </div>
                                    </div>
                                    <div class="login-bg">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="alert alert-info">
                                                    <p style="margin-left: 5px; margin-right: 10px; margin-top: 10px; margin-bottom: 5px; font: normal normal normal 13px/2 FontAwesome;">
                                                        <i class="fa fa-exclamation-triangle " aria-hidden="true"></i>You can specify a value for each relevant feature regarding this product. Empty fields will not be displayed.
You can either create a specific value, or select among the existing pre-defined values you've previously added.
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">

                                            <div class="col-lg-12">
                                                <div class="table-responsive-row clearfix">
                                                    <table class="table">
                                                        <thead>
                                                            <tr class="nodrag nodrop">
                                                                <th class=" left">
                                                                    <span class="title_box">Feature
                                                                    </span>
                                                                </th>
                                                                <th class=" left">
                                                                    <span class="title_box">Pre-defined value
                                                                    </span>
                                                                </th>
                                                                <th class=" left">
                                                                    <span class="title_box">or Customized value
                                                                    </span>
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:Repeater ID="repFeature" runat="server" OnItemDataBound="repFeature_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <tr class="highlighted odd selected-line">
                                                                        <td>
                                                                            <%#Eval("name") %>
                                                                            <asp:Label ID="lblid_feature" runat="server" Text='<%#Eval("id_feature") %>' Visible="false"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <%--  <input type="hidden" name="feature_8_value" value="0">--%>
                                                                            <span runat="server" id="AddPre_defined">N/A -
						<a href="addfeature_value.aspx?fid=<%#Eval("id_feature") %>" class="confirm_leave btn btn-link"><i class="icon-plus-sign"></i>Add pre-defined values first <i class="icon-external-link-sign"></i></a>
                                                                            </span>
                                                                            <asp:DropDownList ID="drpPreValue" runat="server" Style="width: 400px">
                                                                            </asp:DropDownList>
                                                                            <asp:Label ID="lblPreValue" runat="server" Text='<%#Eval("value") %>' Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblIsCustom" runat="server" Text='<%#Eval("custom") %>' Visible="false"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCustomeValue" runat="server" CssClass="form-control" TextMode="MultiLine" Text='<%#Eval("Custmvalue") %>'></asp:TextBox></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                    </div>
                                                </div>
                                                <asp:LinkButton ID="btnFeature" runat="server" CssClass="btn btn-link bt-icon confirm_leave" OnClick="btnFeature_Click"><i class=" fa fa-plus"></i> Create new Feature <i class=" fa fa-external-link"></i></asp:LinkButton>
                                            </div>
                                        </div>

                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">

                                                    <asp:LinkButton ID="btnFeatureCancel" runat="server" OnClick="btnFeatureCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true">Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <ul>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnFeatureSaveAnd" runat="server" CssClass="btn btn-default" OnClick="btnFeatureSaveAnd_Click" Style="margin-right: 10px"><i  class="fa fa-floppy-o " aria-hidden="true">Save and Stay</i></asp:LinkButton></li>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnFeatureSave" runat="server" CssClass="btn btn-default" OnClick="btnFeatureSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true">Save</i></asp:LinkButton></li>
                                                    </ul>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- ATTACHMENT Tab --%>
                            <div class="tabcontent" id="Attachments" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">ATTACHMENT</span> </h1>

                                        </div>
                                    </div>

                                    <div class="login-bg">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                                ControlToValidate="txtFileName" ForeColor="Red"
                                                Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                            </asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Filename</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <asp:TextBox ID="txtFileName" runat="server" CssClass=" form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Description</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="login-input-area">
                                                    <asp:TextBox ID="txtAttDescription" runat="server" CssClass=" form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>File</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="login-input-area">
                                                    <input id="attachment_file" type="file" name="attachment_file" class="hide">
                                                    <button class="btn btn-default" data-style="expand-right" data-size="s" type="button" id="attachment_file-add-button" onclick="document.getElementById('attachment_file').click();">
                                                        <span class="ladda-label">
                                                            <i class="fa fa-plus"></i>Add file
                                                        </span><span class="ladda-spinner"></span>
                                                    </button>
                                                    <p class="help-block">Upload a file from your computer (64.00 MB max.)</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="dual-list-box-inner">
                                                    <div class="wizard-big">
                                                        <select class="form-control dual_select" multiple>
                                                            <option value="United States">United States</option>
                                                            <option value="United Kingdom">United Kingdom</option>
                                                            <option value="Australia">Australia</option>
                                                            <option selected value="Austria">Austria</option>
                                                            <option selected value="Bahamas">Bahamas</option>
                                                            <option value="Barbados">Barbados</option>
                                                            <option value="Belgium">Belgium</option>
                                                            <option value="Bermuda">Bermuda</option>
                                                            <option value="Brazil">Brazil</option>
                                                            <option value="Bulgaria">Bulgaria</option>
                                                            <option value="Cameroon">Cameroon</option>
                                                            <option value="Canada">Canada</option>
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="button-style-four btn-mg-b-10">
                                                    <a href="User.aspx" class="btn btn-danger"><i class="fa fa-times fa-2x" aria-hidden="true">Cancel</i></a>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="login-button-pro alignright">
                                                    <asp:LinkButton ID="LinkButton8" runat="server" ValidationGroup="add" CssClass=" btn btn-primary"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>


                                                </div>
                                            </div>
                                        </div>
                                    </div>



                                </div>
                            </div>

                            <%-- TMProductVideos Tab --%>
                            <div class="tabcontent" id="TMProductVideos" style="display: none">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" ValidateRequest="false">
                                    <ContentTemplate>
                                        <div role="form">
                                            <div class="sparkline13-list shadow-reset">
                                                <div class="sparkline13-hd">
                                                    <div class="main-sparkline13-hd">
                                                        <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">PRODUCT VIDEOS</span> </h1>

                                                    </div>
                                                </div>

                                                <div class="login-bg">
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                              <%-- <div class="compose-multiple-email">
                                                   <input type="email" name="recipient_email" id="recipient_email" class="form-control">
                                               </div>--%>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Video Link/Path</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <div class="login-input-area">
                                                                <asp:TextBox ID="txtVideoLink" runat="server" CssClass=" form-control" Text="https://www.youtube.com/embed/"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Cover image</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <div class="login-input-area" style="margin-top: 10px">
                                                                <div class="file-upload-inner file-upload-inner-right ts-forms">
                                                                    <div class="input append-small-btn">
                                                                        <div class="file-button">
                                                                            Browse
                                                         <asp:FileUpload runat="server" ID="FileUpload1" onchange="document.getElementById('append').value = this.value;" />

                                                                        </div>
                                                                        <input runat="server" type="text" id="append" placeholder="no file selected" />
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                       
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Video Heading</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="login-input-area">
                                                                <asp:TextBox ID="txtVideHeading" runat="server" CssClass=" form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            &nbsp;
                                       
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <div class="login-input-head alignright" style="margin-right: 10px">
                                                                <p>Videos Description</p>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="login-input-area">
                                                                <CKEditor:CKEditorControl ID="txtVideoDescription" BasePath="../Admin/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                                                <%--<textarea id="txtVideoDescription" runat="server" style="width: 100%; height: 100px;"></textarea>--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">&nbsp;</div>
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class=" alignleft">

                                                                <asp:LinkButton ID="btnVideoCancel" runat="server" OnClick="btnVideoCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true"> Cancel</i></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="alignright">
                                                                <asp:LinkButton ID="btnVideoSaveAnd" runat="server" ValidationGroup="addVideo" CssClass="btn btn-primary" OnClick="btnVideoSaveAnd_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save and Stay</i></asp:LinkButton>
                                                                <asp:LinkButton ID="btnVideoSave" runat="server" ValidationGroup="addVideo" CssClass="btn btn-primary" OnClick="btnVideoSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true"> Save</i></asp:LinkButton>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" runat="server" id="video">
                                                        <div class="sparkline13-graph">
                                                            <div class="datatable-dashv1-list custom-datatable-overright">
                                                                <table id="table" data-toggle="table" data-toolbar="#toolbar">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>Video</th>
                                                                            <th>Heading</th>
                                                                            <th>Description</th>
                                                                            <th></th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <asp:Repeater ID="repVideo" runat="server" OnItemCommand="repVideo_ItemCommand">
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <td>
                                                                                        <%--<object width="427" height="258">
                                                                                            <param name="movie" value="<%#Eval("link") %>"></param>
                                                                                            <param name="allowFullScreen" value="true"></param>
                                                                                            <param name="allowscriptaccess" value="always"></param>
                                                                                            <param name="wmode" value="opaque"></param>
                                                                                            <embed src="<%#Eval("link") %>?" type="application/x-shockwave-flash" width="427" height="258" allowscriptaccess="always" allowfullscreen="true" wmode="opaque"></embed>
                                                                                        </object>--%>
                                                                                        <iframe width="480" height="360" src="<%#Eval("link") %>" frameborder="0" allowfullscreen></iframe>
                                                                                        <%--  <iframe width="420" height="315" style="width: 200px; height: 200px;" id="irm1" src='<%#Eval("link") %>' runat="server" frameborder="0" allowfullscreen></iframe>--%>
                                                                                    </td>
                                                                                    <td><%#Eval("name") %> </td>
                                                                                    <td><%#Eval("description") %> </td>

                                                                                    <td>
                                                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CssClass="btn btn-small btn-danger"
                                                                                            CommandArgument='<%#Eval("id_video") %>'><i class="fa fa-trash-o fa-lg"></i></asp:LinkButton>
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
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <%-- RELATED PRODUCTS--%>
                            <div class="tabcontent" id="TemplateMonster" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">RELATED PRODUCTS</span> </h1>

                                        </div>
                                    </div>

                                    <div class="login-bg">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                              <%-- <div class="compose-multiple-email">
                                                   <input type="email" name="recipient_email" id="recipient_email" class="form-control">
                                               </div>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>Related products</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="input-group">
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass=" form-control"></asp:TextBox>
                                                    <span class="input-group-addon"><i class="icon-search"></i></span>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">

                                                    <asp:LinkButton ID="LinkButton20" runat="server" PostBackUrl="~/Backoffice/Products.aspx" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true">Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <ul>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnRelatedSaveAnd" runat="server" CssClass="btn btn-default" OnClick="btnRelatedSaveAnd_Click" Style="margin-right: 10px"><i  class="fa fa-floppy-o " aria-hidden="true">Save and Stay</i></asp:LinkButton></li>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnRelatedSave" runat="server" CssClass="btn btn-default" OnClick="btnRelatedSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true">Save</i></asp:LinkButton></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- HOT DEALS--%>
                            <div class="tabcontent" id="Hot" style="display: none">
                                <div class="sparkline13-list shadow-reset">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">HOT DEALS</span> </h1>

                                        </div>
                                    </div>

                                    <div class="login-bg">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                              <%-- <div class="compose-multiple-email">
                                                   <input type="email" name="recipient_email" id="recipient_email" class="form-control">
                                               </div>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>From Date</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtDealFromdate" CssClass="form-control datePicK" runat="server" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                              <%-- <div class="compose-multiple-email">
                                                   <input type="email" name="recipient_email" id="recipient_email" class="form-control">
                                               </div>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>To Date</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtDealToDate" CssClass="form-control datePicK" runat="server" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>From Time</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtDealFromTime" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                &nbsp;
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="login-input-head alignright" style="margin-right: 10px">
                                                    <p>To Time</p>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtDealToTime" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="clearfix">&nbsp;</div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class=" alignleft">

                                                    <asp:LinkButton ID="btnHotCancel" runat="server" OnClick="btnHotCancel_Click" CssClass="btn btn-danger"><i class="fa fa-times " aria-hidden="true">Cancel</i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="alignright">
                                                    <ul>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnHotSaveAnd" runat="server" CssClass="btn btn-default" OnClick="btnHotSaveAnd_Click" Style="margin-right: 10px"><i  class="fa fa-floppy-o " aria-hidden="true">Save and Stay</i></asp:LinkButton></li>
                                                        <li class="floatleft">
                                                            <asp:LinkButton ID="btnHotSave" runat="server" CssClass="btn btn-default" OnClick="btnHotSave_Click"><i  class="fa fa-floppy-o " aria-hidden="true">Save</i></asp:LinkButton></li>
                                                    </ul>
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
        </div>
    </div>

    <asp:HiddenField ID="hddProduct" runat="server" Value="test" />
    <asp:HiddenField ID="hddid" runat="server" />
    <asp:HiddenField ID="hddTab" runat="server" />
    <asp:HiddenField ID="hddHome" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">

    <%-- <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/themes/redmond/jquery-ui.css"
        type="text/css" media="all" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js" type="text/javascript"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/jquery-ui.min.js"
        type="text/javascript"></script>--%>


    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datePicK").datepicker({
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

    <%--<script type="text/javascript">
        $('input[type="checkbox"]').click(function () {
            var opts;
            var array;
            if ($(this).prop("checked") == true) {
                //debugger
                var dd = $(this).next('.valueOne').html();
                var dd1 = $(this).prev('.valueTwo').html();
                var exists = 0 != $('#Body_drpDefaultCat option[value=' + dd1 + ']').length;
                // if (exists ="false") {
                $("#Body_drpDefaultCat").append('<option value=' + dd1 + '>' + dd + '</option>');
                // } ;
                opts = $('#Body_drpDefaultCat')[0].options;
                array = $.map(opts, function (elem) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: 'addproduct.aspx/AddCat',
                        data: '{ ID: "' + elem.value + '", CatName: "' + elem.text + '"}',
                        dataType: "json",
                        success: function (data) {
                        },
                        error: function ajaxerror(data) {
                            // alert(data.Status + " : " + data.StatusText);
                        }
                    });

                    // alert(elem.value+'Or'+ elem.text);
                });
                //$('#Body_drpDefaultCat option').each(function () {
                //    values.push($(this).attr('value'));
                //    alert(e.values, e.in);
                //});
            }
            else {
                var dd = $(this).next('.valueOne').html();
                var dd1 = $(this).prev('.valueTwo').html();
                $("#Body_drpDefaultCat option[value=" + dd1 + "]").remove();
                //   $("#Body_drpDefaultCat").re('<option value=' + dd1 + '>' + dd + '</option>');

            }
            //for (i = 0; i < Cate.length; i++) {
            //    alert(values );
            //}

        });
    </script>--%>

    <script type="text/javascript">

        $('input[type="checkbox"]').click(function () {
            ////debugger
            var opts;
            var array;
            if ($(this).prop("checked") == true) {
                debugger
                var dd = $(this).next('.valueOne').html();
                var dd1 = $(this).prev('.valueTwo').html();

                var exists = 0 != $('#Body_drpDefaultCat option[value=' + dd1 + ']').length;
                //debugger
                if (exists = "false") {
                    $("#Body_drpDefaultCat").append('<option value=' + dd1 + '>' + dd + '</option>');
                };
                opts = $('#Body_drpDefaultCat')[0].options;
                array = $.map(opts, function (elem) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: 'addproduct.aspx/AddCat',
                        data: '{ ID: "' + elem.value + '", CatName: "' + elem.text + '"}',
                        dataType: "json",
                        success: function (data) {
                            ////debugger
                            //if (dd == "Home") {
                            //    $('#myUL1').addClass('active');
                            //}
                        },
                        error: function ajaxerror(data) {
                            // alert(data.Status + " : " + data.StatusText);
                        }
                    });

                    // alert(elem.value+'Or'+ elem.text);
                });
                //$('#Body_drpDefaultCat option').each(function () {
                //    values.push($(this).attr('value'));
                //    alert(e.values, e.in);
                //});
            }
            else {
                var dd = $(this).next('.valueOne').html();
                var dd1 = $(this).prev('.valueTwo').html();
                $("#Body_drpDefaultCat option[value=" + dd1 + "]").remove();
                $('#myUL1').addClass('active');
                $.ajax({
                    type: "POST",
                    contentType: "application/json;",
                    url: 'addproduct.aspx/RemCat',
                    data: '{ ID: "' + dd1 + '", CatName: "' + dd + '"}',
                    dataType: "json",
                    success: function (data) {
                        ////debugger
                        //if (dd == "Home") {
                        //    $('#myUL1').addClass('active');
                        //}
                    },
                    error: function ajaxerror(data) {
                        // alert(data.Status + " : " + data.StatusText);
                    }
                });
                //   $("#Body_drpDefaultCat").re('<option value=' + dd1 + '>' + dd + '</option>');

            }
            //for (i = 0; i < Cate.length; i++) {
            //    alert(values );
            //}

        });
        $(document).ready(function () {
            debugger
            var dd = $('#Body_hddHome').val();
            if (dd == "Active") {
                document.getElementById("chkHome").checked = true;
                //$('#chkHome').addClass('active');
            }
            else {
                document.getElementById("chkHome").checked = false;
            }
        });
    </script>

    <script type="text/javascript">
        function openTab(evt, tabName) {
            //debugger
            var withhash = window.location.hash;
            var withouthash = window.location.hash.replace('#', '');
            if (tabName == "Combinations1") {
                $('#lispecific').hide();
                $('#specific').show();
                $('#liCancel').hide();
                $('#lispecific').show();
                tabName = "Combinations"

            }
            else {
                $('#lispecific').hide();
                $('#specific').hide();
                $('#liCancel').hide();
                $('#lispecific').show();
                if (tabName != "") {

                }
                else {
                    tabName = withouthash;
                }
            }
            if (tabName == "Combinations") {

                //$('#lispecific').hide();
                //$('#specific').hide();
                //$('#liCancel').hide();
                //  $('#lispecific').show();
            }
            //else {
            //    if (withouthash == "") {

            //    }
            //    else {
            //        if (withouthash == "Combinations") {
            //            tabName = withouthash;
            //        }
            //        else {
            //            tabName = withouthash;
            //        }
            //    }
            //}

            // Declare all variables
            var i, tabcontent, tablinks;

            // Get all elements with class="tabcontent" and hide them
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }

            // Get all elements with class="tablinks" and remove the class "active"
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            //debugger
            document.getElementById(tabName).style.display = "block";
            //evt.currentTarget.className += " active";

            //document.getElementById(tabName).parent.addClass(" active");
            //tablinks[3].addClass(" active");

            var ff = "a[href='#" + tabName + "']";
            document.querySelector(ff).closest('li').classList.add('active');
            $('#Body_hddTab').val(tabName);

 <%--   '<%Session["tab"] = "' + tab + '"; %>';
            alert('<%=Session["tab"] %>');--%>

            // Show the current tab, and add an "active" class to the button that opened the tab
           <%-- //debugger
            var ss = ' <%= Session["PID"] %>'
            if (ss != '') {
                document.getElementById(tabName).style.display = "block";
                evt.currentTarget.className += " active";
                window.location.replace("/Backoffice/addproduct.aspx?id=" + ss + "#" + tabName);
            }--%>

        }
    </script>

    <script>
        function Generate() {
            //var url = "http://localhost:63853/" + $("#Body_hddProduct").val();
            //$("#Body_lblUrl").val(url);

        }
        //Combination
        function specific() {
            //$("#hddTdis").val(th.value);
            $('#lispecific').hide();
            $('#specific').show();
            $('#liCancel').show();
        }
        function Cancel() {
            //$("#hddTdis").val(th.value);
            $('#lispecific').show();
            $('#specific').hide();
            $('#liCancel').hide();
        }
        //Price
        function specific1() {
            //$("#hddTdis").val(th.value);
            $('#lispecific1').hide();
            $('#specific1').show();
            $('#liCancel2').show();
        }
        function Cancel1() {
            //$("#hddTdis").val(th.value);
            $('#lispecific1').show();
            $('#specific1').hide();
            $('#liCancel2').hide();
        }
    </script>

    <%--<script>

        var toggler = document.getElementsByClassName("box");
        var i;

        for (i = 0; i < toggler.length; i++) {
            ////debugger
            toggler[i].addEventListener("click", function () {
                this.parentElement.querySelector(".nested").classList.toggle("active");
                this.classList.toggle("check-box");
            });
        }
    </script>--%>
    <script>

        var toggler = document.getElementsByClassName("box");
        var i;

        for (i = 0; i < toggler.length; i++) {
            ////debugger
            toggler[i].addEventListener("click", function () {
                //$('#myUL1').addClass('active');
                if (this.classList != null) {
                    this.parentElement.querySelector(".nested").classList.toggle("active");
                    this.classList.toggle("check-box");
                }

            });
        }
    </script>
    <script type="text/javascript">
        $("select").select2_demo_2();

        $("select").on("select2_demo_2:select", function (evt) {
            var element = evt.params.data.element;
            var $element = $(element);

            $element.detach();
            $(this).append($element);
            $(this).trigger("change");
        });
        $(document).ready(function () {
            // $("select").select2_demo_2();

            //debugger
            var withhash = window.location.hash;
            var withouthash = window.location.hash.replace('#', '');
            if (withouthash == null || (withouthash == "")) {
                withouthash = "Information";
            }
            //$('ul li.tablinks').removeClass('active');
            var ff = "a[href='#" + withouthash + "']";
            document.querySelector(ff).closest('li').classList.add('active');
            openTab(event, withouthash);

            //$('#lispecific').hide();
            //$('#specific').hide();
            //$('#liCancel').hide();
            //$('#lispecific').show();
            //$('.tablinks').each(function (i) {
            //    //debugger
            //    //var innerhtml = $(this).textContent;
            //    //var dd = $(this).innerText.val();
            //    //var innertext = $(this).innertext;
            //    var tab_url = $(this).attr('data-url');
            //    if ($(this).attr('data-url')) {
            //        $(this).closest('.tab-item').attr("id", tab_url);
            //        $(this).attr("href", "#" + tab_url);
            //    } else {
            //        $(this).closest('.tab-item').attr("id", "tab-" + (i + 1));
            //        $(this).attr("href", "#tab-" + (i + 1));
            //    }
            //});
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //debugger
            var withouthash = window.location.hash.replace('#', '');
            if (withouthash == "") {
                var username = '<%= Session["tab"] %>';
                if (username != "") {
                    if (username == "Combinations1") {
                        openTab(event, "Combinations1");
                    }
                    else {
                        openTab(event, username);
                    }

                    //$('#lispecific').hide();
                    //$('#specific').hide();
                    //$('#liCancel').hide();
                    //$('#lispecific').show();
                }
            }
            else {

                openTab(event, withouthash);
            }
            //else
            //    openTab(event, 'Information');
        });

    </script>
    <script type="text/javascript">
        function unitPrice(th) {
            //debugger
            var ss = th.value;
            var ss1 = $("#Body_txtUnitPrice").value;
            $("#Body_unitPrice").text(th.value);

        }
        function unit(th) {
            //  //debugger
            $("#Body_unit").text(th.value);
        }
        function RPrice(th) {
            //  //debugger
            $("#Body_RPrice").text(th.value);
        }
    </script>

    <%-- <link href="../Admin/Arjs/DragCss.css" rel="stylesheet" />
    <script src="../Admin/Arjs/Drag.js"></script>
    <script src="../Admin/Arjs/DragUi.js"></script>--%>

    <%--<script type="text/javascript">

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

    --%>
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("[id*=Body_flpCover]").change(function () {
                if (typeof (FileReader) != "undefined") {
                    var dvPreview = $("#dvPreview");
                    dvPreview.html("");
                    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                    $($(this)[0].files).each(function () {
                        var file = $(this);
                        if (regex.test(file[0].name.toLowerCase())) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                var img = $("<img />");
                                img.attr("style", "height:40px;width: 40px;margin-right:10px");
                                img.attr("src", e.target.result);
                                dvPreview.append(img);
                            }
                            reader.readAsDataURL(file[0]);
                        } else {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                var img = $("<img />");
                                img.attr("style", "height:40px;width: 40px;margin-right:10px");
                                img.attr("src", e.target.result);
                                dvPreview.append(img);
                            }
                            reader.readAsDataURL(file[0]);
                            //alert(file[0].name + " is not a valid image file.");
                            //dvPreview.html("");
                            //return false;
                        }
                    });
                } else {
                    alert("This browser does not support HTML5 FileReader.");
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtDes.ClientID %>', { filebrowserImageUploadUrl: 'Upload.ashx' });
        });
    </script>
</asp:Content>


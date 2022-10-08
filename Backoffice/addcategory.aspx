<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="addcategory.aspx.cs" Inherits="Backoffice_addcategory" ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .switch-field {
            display: flex;
            margin-bottom: 36px;
            overflow: hidden;
        }

            .switch-field input {
                position: absolute !important;
                clip: rect(0, 0, 0, 0);
                height: 1px;
                width: 1px;
                border: 0;
                overflow: hidden;
            }

            .switch-field label {
                background-color: #e4e4e4;
                color: rgba(0, 0, 0, 0.6);
                font-size: 14px;
                line-height: 1;
                text-align: center;
                padding: 8px 16px;
                margin-right: -1px;
                border: 1px solid rgba(0, 0, 0, 0.2);
                box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.3), 0 1px rgba(255, 255, 255, 0.1);
                transition: all 0.1s ease-in-out;
            }

                .switch-field label:hover {
                    cursor: pointer;
                    background-color: #e08f95;
                }

            .switch-field input:checked + label {
                background-color: #2eacce;
                box-shadow: none;
            }

            .switch-field label:first-of-type {
                border-radius: 4px 0 0 4px;
            }

            .switch-field label:last-of-type {
                border-radius: 0 4px 4px 0;
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
                                       <%-- <li><a href="Categories.aspx">Categories</a> <span class="bread-slash">/</span>
                                        </li>--%>
                                        <li><a onClick="history.go(-1); return false;" href="##"> Categories</a>
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
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">Categories</span> </h1>
                                </div>
                            </div>
                            <div class="login-bg">
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Name</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtName" runat="server" OnTextChanged="txtName_TextChanged" AutoPostBack="true"></asp:TextBox>
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
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                              ControlToValidate="drpCategory" ForeColor="Red"
                                              Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                          </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Parent category</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">

                                        <asp:DropDownList ID="drpCategory" runat="server" CssClass="select2_demo_2 form-control RequiredV">
                                        </asp:DropDownList>
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
                                            <CKEditor:CKEditorControl ID="txtareaDescription" BasePath="../Admin/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                            <%--<CE:Editor ID="txtareaDescription" runat="server" style="width:700px;">
                                </CE:Editor>--%>
                                            <%--<textarea id="txtareaDescription" runat="server" style="width: 100%"></textarea>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">&nbsp;</div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;

                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Category Cover Image</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area" style="margin-top: 10px">
                                            <div class="file-upload-inner file-upload-inner-right ts-forms">
                                                <div class="input append-small-btn">
                                                    <div class="file-button">
                                                        Browse
                                                         <asp:FileUpload runat="server" ID="flpCover" onchange="document.getElementById('Body_append').value = this.value;" />

                                                    </div>
                                                    <input runat="server" type="text" id="append" placeholder="no file selected" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Image ID="imgCover" runat="server" Height="100px" Width="100px" />

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Category thumbnail</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area" style="margin-top: 10px">
                                            <div class="file-upload-inner file-upload-inner-right ts-forms">
                                                <div class="input append-small-btn">
                                                    <div class="file-button">
                                                        Browse
                                                         <asp:FileUpload runat="server" ID="flpThumb" onchange="document.getElementById('Body_txtImage').value = this.value;" />

                                                    </div>
                                                    <input runat="server" type="text" id="txtImage" placeholder="no file selected" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Image ID="imgThumb" runat="server" Height="100px" Width="100px" />

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
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
                                <div class="clearfix">&nbsp;</div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Meta keywords</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="">
                                            <div class="bs-example">
                                                <input runat="server" id="txtKeyword" class="form-control" type="text" placeholder="Enter keywords" data-role="tagsinput" />
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
                                            <p>Friendly URL</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtFriendlyURL" runat="server"></asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="txtName" EventName="TextChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="button-style-four btn-mg-b-10">
                                            <a onClick="history.go(-1); return false;" href="##" class="btn btn-danger"><i class="fa fa-times fa-2x" aria-hidden="true">Cancel</i></a>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-button-pro alignright">
                                            <%-- <a href="#" class="login-button login-button-lg"><i class="fa fa-save" aria-hidden="true">--%>
                                            <%--  <asp:Button ID="btnSave" runat="server" ValidationGroup="A" Text="Save" class="login-button login-button-lg" />--%>
                                            <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSave_Click" ><i  class="fa fa-floppy-o fa-2x" aria-hidden="true"> Save</i></asp:LinkButton>


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
    <script>
        initSample();
    </script>
      <script type="text/javascript">
          $(function () {
              CKEDITOR.replace('<%=txtareaDescription.ClientID %>', { filebrowserImageUploadUrl: 'Upload.ashx' });
        });
      </script>
</asp:Content>


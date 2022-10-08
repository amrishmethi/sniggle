<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddBlog.aspx.cs" Inherits="Backoffice_AddBlog"  ValidateRequest="false" %>
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
                                        <li>Blog<span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="Blog.aspx">Blog Category</a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Edit</h1>
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
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">BLOG CATEGORY</span> </h1>
                                </div>
                            </div>
                            <div class="login-bg">
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtMetaTitle" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Meta Title <span style="color: red">*</span></p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtMetaTitle" runat="server" OnTextChanged="txtMetaTitle_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <br />
                                            <p class="help-block">
                                                Enter Your Category Name
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
                                            <p>Description</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                             <CKEditor:CKEditorControl ID="txtareaDescription" BasePath="../Admin/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                            <%--<textarea id="" runat="server" class="myTextEditor" style="width: 100%"></textarea>--%>
                                             <br />
                                             
                                            <p class="help-block">
                                               Enter Your Category Description
                                            </p>
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
                                            <p>Category Image</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:FileUpload ID="flapThumb" runat="server" CssClass="form-control" />
                                           
                                        </div>
                                    </div>
                                    
                                    <div class="col-lg-2">
                                        <asp:Image ID="imgCover" runat="server" Height="100px" Width="100px" Visible="false" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Meta Keyword</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>
                                             <br />
                                            <p class="help-block">
                                                Enter Your Category Meta Keyword. Separated by comma(,)
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
                                            <p>Meta Description</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtMetaDes" runat="server"></asp:TextBox>
                                             <br />
                                            <p class="help-block">
                                                Enter Your Category Meta Description
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
                                            <p>Link Rewrite <span style="color: red">*</span></p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                     <asp:TextBox ID="txtFriendlyURL" runat="server"></asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="txtMetaTitle" EventName="TextChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                          
                                             <br />
                                            <p class="help-block">
                                                Enetr Your Category Slug. Use In SEO Friendly URL </p>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="button-style-four btn-mg-b-10">
                                            <a href="Blog.aspx" class="btn btn-danger"><i class="fa fa-times" aria-hidden="true">Cancel</i></a>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-button-pro alignright">
                                            <%-- <a href="#" class="login-button login-button-lg"><i class="fa fa-save" aria-hidden="true">--%>
                                            <%--  <asp:Button ID="btnSave" runat="server" ValidationGroup="A" Text="Save" class="login-button login-button-lg" />--%>
                                            <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSave_Click" ><i  class="fa fa-floppy-o" aria-hidden="true"> Save</i></asp:LinkButton>


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
    <script type="text/javascript">

        tinymce.init({ selector: '#Body_txtareaDescription' });
        //tinymce.init({ selector: '#Body_txtDes' });
        //tinyMCE.init({
        //    forced_root_block: true

        //});
    </script>
        <script type="text/javascript">
            $(function () {
                CKEDITOR.replace('<%=txtareaDescription.ClientID %>', { filebrowserImageUploadUrl: 'Upload.ashx' });
          });
        </script>
</asp:Content>


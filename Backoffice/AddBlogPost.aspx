<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddBlogPost.aspx.cs" Inherits="Backoffice_AddBlogPost" ValidateRequest="false" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                                        <li>Blog <span class="bread-slash">/</span>
                                        </li>
                                        <li><a href="BlogPost.aspx">Blog Post</a>
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
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">BLOG POST</span> </h1>

                                </div>
                            </div>
                            <div class="login-bg">

                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtBlogTitle" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Blog Title <span style="color: red;">*</span></p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtBlogTitle" runat="server" OnTextChanged="txtBlogTitle_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtPostedBy" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Posted By <span style="color: red;">*</span></p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtPostedBy" runat="server" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                              ControlToValidate="txtDescription" ForeColor="Red"
                                              Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                          </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Description</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                          
                                             <CKEditor:CKEditorControl ID="txtDescription" BasePath="../Admin/ckeditor/" runat="server"></CKEditor:CKEditorControl>
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
                                            <p>Feature Image</p>
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
                                            <p>Blog Category</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:DropDownList ID="drpBlogCat" runat="server" CssClass="select2_demo_2 form-control"></asp:DropDownList>
                                        </div>
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
                                        <div class="">
                                            <div class="bs-example">
                                                <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control"></asp:TextBox>
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
                                            <p>Short Description</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtShortDes" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
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
                                            <asp:TextBox ID="txtMetaDes" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;

                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Link Rewrite</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                             <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                   <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="txtBlogTitle" EventName="TextChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            
                                        </div>
                                    </div>

                                </div>
                                <div class="row ">
                                    <div class="col-lg-2">
                                        &nbsp;

                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Tag </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtTag" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class=" alignleft">
                                            <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/Backoffice/BlogPost.aspx" CssClass="btn btn-danger"><i class="fa fa-times fa-2x" aria-hidden="true"> Cancel</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="alignright">
                                            <%--  <asp:LinkButton ID="btnSaveAnd" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSaveAnd_Click"><i  class="fa fa-floppy-o fa-2x" aria-hidden="true"> Save and Stay</i></asp:LinkButton>--%>
                                            <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSave_Click"><i  class="fa fa-floppy-o" aria-hidden="true"> Save</i></asp:LinkButton>

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

        tinymce.init({ selector: '#Body_txtDescription' });
        //tinymce.init({ selector: '#Body_txtDes' });
        //tinyMCE.init({
        //    forced_root_block: true

        //});
    </script>
      <script type="text/javascript">
          $(function () {
              CKEDITOR.replace('<%=txtDescription.ClientID %>', { filebrowserImageUploadUrl: 'Upload.ashx' });
        });
      </script>
</asp:Content>


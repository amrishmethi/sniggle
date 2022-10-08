<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddAttributeValue.aspx.cs" Inherits="Backoffice_AddAttributeValue" ValidateRequest="false" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
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
                                        <li><a href="AttributesGroups.aspx">Product Attribute</a><span class="bread-slash">/</span>
                                        </li>
                                        <li><a runat="server" id="hrfval" >Product Attribute Value</a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <h1 style="float: left">Add New Value</h1>
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
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n text-capitalize">PRODUCT ATTRIBUTE VALUE</span> </h1>

                                </div>
                            </div>

                            <div class="login-bg">
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="drpFeature" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p><span style="color: red">*</span> Attribute group</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:DropDownList ID="drpFeature" runat="server" CssClass="select2_demo_2 form-control"></asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtValue" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p><span style="color: red">*</span> Value</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtValue" runat="server" OnTextChanged="txtValue_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p> Color Code</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtColor" runat="server" ></asp:TextBox>
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
                                            <p> Cover Image</p>
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
                                        
                                        <img runat="server" id="img" style="height:100px; width:100px;"  />
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
                                                    <asp:AsyncPostBackTrigger ControlID="txtValue" EventName="TextChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                        </div>
                                    </div>
                                </div>
                                
                                <div class="row">&nbsp;</div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="button-style-four btn-mg-b-10">
                                             <asp:LinkButton ID="btnCancel" runat="server"  CssClass="btn btn-danger" OnClick="btnCancel_Click"  Style="margin-right: 10px"><i class="fa fa-times fa-2x" aria-hidden="true">Cancel</i></asp:LinkButton>
                                          
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="alignright">
                                            <ul>
                                                <li class="floatleft">
                                                    <asp:LinkButton ID="btnFeatureSaveAnd" ValidationGroup="add" runat="server" CssClass="btn btn-default" OnClick="btnFeatureSaveAnd_Click"  Style="margin-right: 10px"><i  class="fa fa-floppy-o" aria-hidden="true"><br />Save and add new</i></asp:LinkButton></li>
                                                <li class="floatleft">
                                                    <asp:LinkButton ID="btnFeatureSave" ValidationGroup="add" runat="server" CssClass="btn btn-default" OnClick="btnFeatureSave_Click"  ><i  class="fa fa-floppy-o" aria-hidden="true"><br /> Save</i></asp:LinkButton></li>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
     <script type="text/javascript">
          $(function () {
              CKEDITOR.replace('<%=txtareaDescription.ClientID %>', { filebrowserImageUploadUrl: 'Upload.ashx' });
        });
     </script>
</asp:Content>


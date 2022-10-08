<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddFancyShape.aspx.cs" Inherits="Backoffice_AddFancyShape" %>

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
                                        <li><a href="FancyShape.aspx">Creative Cuts</a> <span class="bread-slash">/</span>
                                        </li>
                                        <li><span>Creative Cuts</span>
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
                                    <h1><i class="fa fa-tag btn btn-button-success-ct"></i><span class="table-project-n">Creative Cuts</span> </h1>

                                </div>
                            </div>

                            <div class="login-bg">

                                 <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="drpCuts" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Creative Cuts Category </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                          <asp:DropDownList ID="drpCuts" runat="server" CssClass="form-control" ></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
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
                                            <p>Title </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                      <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Video Link </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="txtDis" ForeColor="Red"
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
                                            <textarea id="txtareaDescription" runat="server" style="width: 100%"></textarea>
                                        </div>
                                    </div>
                                </div>
                                <div class="row hidden">
                                    <div class="col-lg-2">
                                        &nbsp;
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Thumb Image </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:FileUpload ID="flapThumb" runat="server" CssClass="form-control" />
                                            <br />
                                            <span style="color: red" class="b1">Size 1000X1000 pexels</span>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <asp:Image ID="imgThumb" runat="server" Visible="false" Width="50px" Height="50px" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                      <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Caption 1 </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtCaption1" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                     <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="FlapBanner" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Image 1</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:FileUpload ID="flap1" runat="server" CssClass="form-control" />
                                            <br />
                                            <span style="color: red" class="b1">Size 1000X1000 pexels</span>

                                        </div>
                                    </div>
                                     <div class="row">
                                    <div class="col-lg-2">
                                        <asp:Image ID="img1" runat="server" Visible="false" Width="50px" Height="50px" />
                                    </div>
                                </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                      <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Caption 2 </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtCaption2" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                               
                                
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="FlapBanner" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Image 2</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:FileUpload ID="flap2" runat="server" CssClass="form-control" />
                                            <br />
                                            <span style="color: red" class="b1">Size 1000X1000 pexels</span>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <asp:Image ID="imag2" runat="server" Visible="false" Width="50px" Height="50px" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                      <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Caption 3 </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtCaption3" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="FlapBanner" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Image 3</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:FileUpload ID="flap3" runat="server" CssClass="form-control" />
                                            <br />
                                            <span style="color: red" class="b1">Size 1000X1000 pexels</span>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <asp:Image ID="imag3" runat="server" Visible="false" Width="50px" Height="50px" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                      <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Caption 4 </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtCaption4" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="FlapBanner" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Image 4</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:FileUpload ID="Flap4" runat="server" CssClass="form-control" />
                                            <br />
                                            <span style="color: red" class="b1">Size 1000X1000 pexels</span>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <asp:Image ID="imag4" runat="server" Visible="false" Width="50px" Height="50px" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                      <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required"
                                             ControlToValidate="txtName" ForeColor="Red"
                                             Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                         </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Caption 5 </p>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <div class="login-input-area">
                                            <asp:TextBox ID="txtCaption5" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">
                                        &nbsp;
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required"
                                            ControlToValidate="FlapBanner" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="add">
                                        </asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="login-input-head alignright" style="margin-right: 10px">
                                            <p>Image 5</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="login-input-area">
                                            <asp:FileUpload ID="flap5" runat="server" CssClass="form-control" />
                                            <br />
                                            <span style="color: red" class="b1">Size 1000X1000 pexels</span>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <asp:Image ID="imag5" runat="server" Visible="false" Width="50px" Height="50px" />
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix">&nbsp;</div>

                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class=" alignleft">
                                            <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/Backoffice/FancyShape.aspx" CssClass="btn btn-danger"><i class="fa fa-times fa-2x" aria-hidden="true"> Cancel</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="alignright">
                                            <%-- <asp:LinkButton ID="btnSaveAnd" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSaveAnd_Click"><i  class="fa fa-floppy-o fa-2x" aria-hidden="true"> Save and Stay</i></asp:LinkButton>--%>
                                            <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="add" CssClass="btn btn-primary" OnClick="btnSave_Click"><i  class="fa fa-floppy-o fa-2x" aria-hidden="true"> Save</i></asp:LinkButton>

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


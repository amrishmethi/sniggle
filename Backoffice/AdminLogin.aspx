<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Backoffice_AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>Sniggle &gt; Administration panel</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- favicon
		============================================ -->
    <link rel="shortcut icon" type="image/x-icon" href="../Admin/img/favicon.ico" />
    <!-- Google Fonts
		============================================ -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i,800" rel="stylesheet">
    <!-- Bootstrap CSS
		============================================ -->
    <link rel="stylesheet" href="../Admin/css/bootstrap.min.css" />
    <!-- Bootstrap CSS
		============================================ -->
    <link rel="stylesheet" href="../Admin/css/font-awesome.min.css" />
    <!-- adminpro icon CSS
		============================================ -->
    <link rel="stylesheet" href="../Admin/css/adminpro-custon-icon.css" />
    <!-- meanmenu icon CSS
		============================================ -->

    <!-- form CSS
		============================================ -->
    <link rel="stylesheet" href="../Admin/css/form.css" />
    <!-- style CSS
		============================================ -->
    <link rel="stylesheet" href="../Admin/css/style.css">
    <!-- responsive CSS
		============================================ -->
    <link rel="stylesheet" href="../Admin/css/responsive.css">
    <!-- modernizr JS
		============================================ -->
    <script src="../Admin/js/vendor/modernizr-2.8.3.min.js"></script>
</head>

<body class="materialdesign">
    <div class="login-form-area mg-t-30 mg-b-40">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-4"></div>
                <form id="adminpro" runat="server" class="adminpro-form">
                    <div class="col-lg-4">
                        <div class="login-bg">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="logo">
                                        <a href="#">
                                            <img src="../Admin/img/preston-login@2x.png" width="69px" height="118px" />

                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="login-title" style="text-align: center">
                                        <h1>sniggle</h1>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <span>Email address</span>
                                    <div class="login-input-area">
                                        <input type="text" name="txtUserName" runat="server" id="txtUserName" />
                                        <i class="fa fa-envelope login-user" aria-hidden="true"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <span>Password</span>
                                    <div class="login-input-area">
                                        <input type="password" name="password" runat="server" id="txtPass" />
                                        <i class="fa fa-lock login-user"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                </div>
                                <div class="col-lg-12">
                                    <div class="login-button-pro">
                                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Log In" class="login-button login-button-lg" Style="width: 100%" />
                                        <%--<button type="submit" class="login-button login-button-lg">Log in</button>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4">
                                </div>
                                <div class="col-lg-8">
                                    <asp:Label ID="lblError" ForeColor="Red" Visible="false" runat="server">Invalid UserId or Password</asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="login-keep-me">
                                        <label class="checkbox">
                                            <input type="checkbox" name="remember" checked><i></i>Keep me logged in
                                                       
                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    &nbsp;
                                </div>
                                <div class="col-lg-3">
                                    <div class="forgot-password">
                                        <a href="#">Forgot password?</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
                <div class="col-lg-4"></div>
            </div>
        </div>
    </div>
    <!-- jquery
		============================================ -->
    <script src="../Admin/js/vendor/jquery-1.11.3.min.js"></script>
    <!-- bootstrap JS
		============================================ -->
    <script src="../Admin/js/bootstrap.min.js"></script>
    <!-- meanmenu JS
		============================================ -->

    <!-- form validate JS
		============================================ -->
    <script src="../Admin/js/jquery.form.min.js"></script>
    <script src="../Admin/js/jquery.validate.min.js"></script>
    <script src="../Admin/js/form-active.js"></script>
    <!-- main JS
		============================================ -->
    <script src="../Admin/js/main.js"></script>
</body>
</html>

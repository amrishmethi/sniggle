<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/css/style.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="breadcrumb-section breadcrumb-bg-color--golden">
        <div class="breadcrumb-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h3 class="breadcrumb-title">Login</h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li class="active" data-aria-current="page">Login</li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="customer-login">
        <div class="container">
            <div class="row">
                <!--login area start-->
                <div class="col-lg-6 col-md-6">
                    <div class="account_form" data-aos="fade-up" data-aos-delay="0">
                        <h3>Authentication</h3>
                        <div style="border: 1px solid #ededed; padding: 23px 20px 29px; border-radius: 5px;">
                            <div class="default-form-box">
                                <h4>Create an account</h4> 
                                <h5>Please enter your email address to create an account.</h5>
                            </div>
                            <div class="default-form-box">
                                <label><span>Email address*</span></label>
                                 <input type="email"  data-validate="isEmail" id="txtEmailExists" name="txtEmailExists" value="" placeholder="Email address" />
                            </div> 
                            <div class="login_submit">
                                <button class="btn btn-md btn-black-default-hover mb-4" type="button"  onclick="CustomerExists();">Create An Account</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6">
                    <div class="account_form register" data-aos="fade-up" data-aos-delay="200">
                        <h3>Already registered?</h3>
                        <div style="border: 1px solid #ededed; padding: 23px 20px 29px; border-radius: 5px;">
                            <div class="default-form-box">
                                <label>Email address <span>*</span></label>
                                 <input id="txtCustomerEmail1" name="txtCustomerEmail1" type="email" placeholder="Email Address"  />
                            </div>
                            <div class="default-form-box">
                                <label>Passwords <span>*</span></label>
                                 <input type="password" data-validate="isPasswd" id="txtCustomerPassword1" name="txtCustomerPassword1" placeholder="Password" />
                            </div>
                            <div class="login_submit">
                                <button class="btn btn-md btn-black-default-hover" type="button"  onclick="CustomerLogin1();">Login</button><br />
                                <a href="/password-recovery" title="Recover your forgotten password" rel="nofollow">Forgot your password?</a> 
                            </div>
                        </div>
                    </div>
                </div>
                <!--register area end-->
            </div>
        </div>
    </div> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server"> 
    <script src="/appjs/login.js"></script>
</asp:Content>


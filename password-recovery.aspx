<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Import Namespace="System.Data" %>
<script runat="server">
    Data dta = new Data();
    GData GetData = new GData();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = dta.getDataSet("select * From ps_cms_lang  where id_lang = 1 and id_cms = '59'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.Page.Title = ds.Tables[0].Rows[0]["meta_title"].ToString();
                HtmlMeta keywords = new HtmlMeta();
                keywords.Name = "keywords";
                keywords.Content = ds.Tables[0].Rows[0]["meta_keywords"].ToString();
                this.Page.Header.Controls.Add(keywords);
                Page.Header.Controls.Add(new LiteralControl("\n"));
                HtmlMeta keywords1 = new HtmlMeta();
                keywords1.Name = "description";
                string dss = ds.Tables[0].Rows[0]["meta_description"].ToString();
                keywords1.Content = dss;
                Page.Header.Controls.Add(new LiteralControl("\n"));
                this.Page.Header.Controls.Add(keywords1);
            }
            if (Request.QueryString["token"] != null)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                string DID = GetData.Decrypt(Request.QueryString["token"].ToString()); ;
                divForgotPwd.Visible = false;
                divChangePassword.Visible = true;
            }
            else
            {
                divForgotPwd.Visible = true;
                divChangePassword.Visible = false;
            }

        }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server"> 
    <div class="breadcrumb-section breadcrumb-bg-color--golden">
            <div class="breadcrumb-wrapper">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <h3 class="breadcrumb-title">Forgot your password</h3>
                            <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                                <nav aria-label="breadcrumb">
                                    <ul>
                                        <li><a href="/">Home</a></li>
                                        <li class="active" data-aria-current="page">Forgot your password</li>
                                    </ul>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <aside id="notifications">
        <div class="container">
        </div>
    </aside>
    <div id="wrapper" class="" data-ng-controller="pwdRecoveryController"> 
        <div id="loading" style="display: none;">
            <div id="loading-image">
                <img src="img/NicLoader200.gif" alt="Loading..." style="border-radius: 5%;" />
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div id="content-wrapper" class="col-xs-12">
                    <section id="main">
                        <div class="row page-authentication">
                            <div class="col-xs-12 col-sm-12">
                                <div id="divForgotPwd" runat="server" class="col-md-12 bg-gray" style="min-height: 280px;">
                                    <div id="create-account_form" class="box">
                                        <div class="clearfix">&nbsp;</div>
                                        <h1 class="page-subheading">Forgot your password?</h1>
                                        <div class="form_content clearfix">
                                            <p class="mt-1">Please enter the email address you used to register. We will then send you a new password.</p>
                                            <div class="alert alert-danger" id="create_account_error" style="display: none"></div>
                                            <div class="form-group mt-05 col-md-4 col-xs-12 pl-0">
                                                <label for="email_create">Email address</label>
                                                <input type="email" class="is_required validate account_input form-control" data-validate="isEmail" id="txtEmailPasswordRecover" name="txtEmailPasswordRecover" value="" placeholder="Email address" />
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="submit ">
                                                <input type="hidden" class="hidden" name="back" value="my-account">
                                                <button id="btnPleaseWait" class="btn btn-secondary" disabled="disabled" style="display: none;">
                                                    <i class="fa fa-spinner fa-spin"></i>&nbsp;&nbsp;Please wait
                                                </button>
                                                <br />
                                                <button  id="btnRetrievePwd" type="button" class="btn btn-md btn-black-default-hover mb-4"  onclick="RecoverPwd();">Retrieve Password</button>
                                                <%-- <a class="btn btn-primary btn-md btn-shadow" onclick="RecoverPwd();">Retrieve Password</a>--%>
                                                <input type="hidden" class="hidden" name="SubmitCreate" value="Create an account">
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div id="divChangePassword" runat="server" class="col-md-12 bg-gray" style="min-height: 280px;">
                                    <div id="create-account_form" class="box">
                                        <div class="clearfix">&nbsp;</div>
                                        <h3 class="page-subheading">Update your password</h3>
                                        <div class="form_content clearfix">
                                            <div class="alert alert-danger" id="create_account_error" style="display: none"></div>
                                            <div class="form-group mt-05 col-md-4 col-xs-12 pl-0">
                                                <label for="email_create">New Password :</label>
                                                <input type="password" class="is_required validate account_input form-control" data-validate="isEmail" id="txtNewPassword" name="txtNewPassword" value="" placeholder="Please Enter New Password" />
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="form-group mt-05 col-md-4 col-xs-12 pl-0">
                                                <label for="email_create">Confirm Password :</label>
                                                <input type="password" class="is_required validate account_input form-control" data-validate="isEmail" id="txtConfirmPassword" name="txtConfirmPassword" value="" placeholder="Please Enter Confirm Password" />
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="submit "><br />
                                                <input type="hidden" class="hidden" name="back" value="my-account">
                                                <button type="button" class="btn btn-secondary btn-shadow"  onclick="ChangePwd();">Change Password</button>
                                                <input type="hidden" class="hidden" name="SubmitCreate" value="Create an account">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <hr />
                                    <a class="btn btn-md btn-black-default-hover mb-4" href="/login">BACK TO LOGIN</a>
                                </div>
                            </div>
                        </div>
                        <section class="page-content card card-block">
                        </section>
                    </section>
                </div>
            </div>
        </div>
    </div> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">  
    <script src="/appjs/login.js"></script>
    <script src="Toster/jquery.toast.js"></script>
</asp:Content>


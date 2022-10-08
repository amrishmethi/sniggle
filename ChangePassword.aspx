<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/controls/LeftCustomer.ascx" TagPrefix="uc1" TagName="LeftCustomer" %>

<%@ Import Namespace="System.Data" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        Data data = new Data();
        if (!IsPostBack)
        {
            ds = data.getDataSet("select * From ps_cms_lang  where id_lang = 1 and id_cms = '59'");
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
            if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
            {

            }
            else
            {
                Response.Redirect("/login");
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
                        <h3 class="breadcrumb-title">Change your password</h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li class="active" data-aria-current="page">Change your password</li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div> 
    <div class="account-dashboard">
        <div class="container">
            <div class="row">
                <uc1:LeftCustomer runat="server" ID="LeftCustomer" />
                <div class="col-sm-12 col-md-9 col-lg-9">
                    <div id="loading" data-ng-if="loading">
                        <div id="loading-image">
                            <%--<img src="/img/NicLoader200.gif" alt="Loading..." style="border-radius: 5%;" />--%>
                        </div>
                    </div>
                    <div data-ng-controller="CustomerController">
                        <section id="main">
                            <div class="row">
                                <div class="col-md-12 col-xs-12">
                                    <h1 class="h2">Change your password</h1>
                                    <hr />
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">
                                            <section class="register-form">
                                                <div class="js-customer-form">
                                                    <section>
                                                        <input type="hidden" name="id_customer" value="">
                                                        <div id="create-account_form" class="box">
                                                            <div class="form_content clearfix">
                                                                <div class="alert alert-danger" id="create_account_error" style="display: none"></div>
                                                                <div class="form-group mt-05 col-md-4 col-xs-12 pl-0">
                                                                    <label for="email_create">Current Password :</label>
                                                                    <input type="password" class="is_required validate account_input form-control" data-validate="isEmail" id="txtCurrentPassword" name="txtCurrentPassword" value="" placeholder="Please Enter Current Password" />
                                                                </div>
                                                                <div class="clearfix">&nbsp;</div>
                                                                <div class="form-group mt-05 col-md-4 col-xs-12 pl-0">
                                                                    <label for="email_create">New Password :</label>
                                                                    <input type="password" class="is_required validate account_input form-control" data-validate="isEmail" id="txtNewPassword" name="txtNewPassword" value="" placeholder="Please Enter New Password" />
                                                                </div>
                                                               <div class="clearfix">&nbsp;</div>
                                                                <div class="form-group mt-05 col-md-4 col-xs-12 pl-0">
                                                                    <label for="email_create">Confirm Password :</label>
                                                                    <input type="password" class="is_required validate account_input form-control" data-validate="isEmail" id="txtConfirmPassword" name="txtConfirmPassword" value="" placeholder="Please Enter Confirm Password" />
                                                                </div>
                                                               <div class="clearfix">&nbsp;</div>
                                                                <div class="submit ">
                                                                    <input type="hidden" class="hidden" name="back" value="my-account">
                                                                    <button type="button" class="btn btn-md btn-golden" onclick="ChangeYrPwd();">Change Password</button>
                                                                    <input type="hidden" class="hidden" name="SubmitCreate" value="Create an account">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </section>
                                                </div>
                                            </section> 
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">
                                            <div class="col-md-12 pl-0 pb-1">
                                                <div class="submit mt-1"><span><a href="/my-account" class="btn btn-md btn-golden">BACK TO YOUR ACCOUNT </a></span>&nbsp; <span><a href="/" class="btn btn-md btn-golden">HOME </a></span></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="js-product-list-header">
                                <div class="block-category card card-block "></div>
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="/appjs/login.js"></script>
</asp:Content>


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
            ds = data.getDataSet("select * From ps_cms_lang  where id_lang = 1 and id_cms = '55'");
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="breadcrumb-section breadcrumb-bg-color--golden">
        <div class="breadcrumb-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h3 class="breadcrumb-title">Your personal information</h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li class="active" aria-current="page">Your personal information</li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <aside id="notifications">
        <div class="container"></div>
    </aside>
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
                                    <h1 class="h2">Your personal information</h1>
                                    <hr />
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">
                                            <div class="col-md-12 pl-0 pb-1">
                                                <h6>Please be sure to update your personal information if it has changed.
                                                </h6>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">
                                            <section class="register-form">
                                                <div class="js-customer-form">
                                                    <div>
                                                        <section>
                                                            <input type="hidden" name="id_customer" value="">
                                                            <div class="form-group row" style="display: none;">
                                                                <label class="col-md-3 form-control-label">
                                                                    Social title
                                                                </label>
                                                                <div class="col-md-6 form-control-valign">
                                                                    <label class="radio-inline">
                                                                        <span class="custom-radio" style="margin-right: 0px;">
                                                                            <input name="id_gender"
                                                                                type="radio"
                                                                                value="1" ng-checked="CustPersonalInfo[0].id_gender == 1" />
                                                                            <span></span>
                                                                        </span>
                                                                        Mr.
                                                                    </label>
                                                                    <label class="radio-inline">
                                                                        <span class="custom-radio" style="margin-right: 0px;">
                                                                            <input name="id_gender"
                                                                                type="radio"
                                                                                value="2" ng-checked="CustPersonalInfo[0].id_gender == 2" />
                                                                            <span></span>
                                                                        </span>
                                                                        Mrs.
                                                                    </label>
                                                                    <label class="radio-inline">
                                                                        <span class="custom-radio" style="margin-right: 0px;">
                                                                            <input name="id_gender"
                                                                                type="radio"
                                                                                value="0" ng-checked="CustPersonalInfo[0].id_gender == 0" />
                                                                            <span></span>
                                                                        </span>
                                                                        Other
                                                                    </label>
                                                                </div>
                                                                <div class="col-md-3 form-control-comment">
                                                                </div>
                                                            </div>
                                                            <div class="form-group row ">
                                                                <label class="col-md-3 form-control-label required">
                                                                    First name <span style="color: orangered;">*</span>
                                                                </label>
                                                                <div class="col-md-6">
                                                                    <input class="form-control" id="txtFirstName" name="txtFirstName" type="text" value="{{CustPersonalInfo[0].firstname}}" required />
                                                                </div>
                                                                <div class="col-md-3 form-control-comment">
                                                                </div>
                                                            </div>
                                                            <div class="clearfix">&nbsp;</div>
                                                            <div class="form-group row ">
                                                                <label class="col-md-3 form-control-label required">
                                                                    Last name
                                                                </label>
                                                                <div class="col-md-6">
                                                                    <input class="form-control" id="txtLastName"
                                                                        name="txtLastName" type="text" value="{{CustPersonalInfo[0].lastname}}" required />
                                                                </div>
                                                                <div class="col-md-3 form-control-comment">
                                                                </div>
                                                            </div>
                                                            <div class="clearfix">&nbsp;</div>
                                                            <div class="form-group row ">
                                                                <label class="col-md-3 form-control-label required">
                                                                    Email <span style="color: orangered;">*</span>
                                                                </label>
                                                                <div class="col-md-6">
                                                                    <input class="form-control EmailIdV" id="txtEmail" name="txtEmail" type="email" runat="server" value="{{CustPersonalInfo[0].email}}" required />
                                                                </div>
                                                                <div class="col-md-3 form-control-comment">
                                                                </div>
                                                            </div> 
                                                            <div class="form-group row " style="display: none;">
                                                                <label class="col-md-3 form-control-label">
                                                                    Birthdate <span style="color: orangered;">*</span>
                                                                </label>
                                                                <div class="col-md-6">
                                                                    <input class="form-control datePicK"
                                                                        name="txtDOB" id="txtDOB" type="text"
                                                                        placeholder="DD/MM/YYYY" value="{{CustPersonalInfo[0].birthday | date:'dd/MM/yyyy'}}" />
                                                                    <span class="form-control-comment">(E.g.: 31/05/2001)
                                                                    </span>
                                                                </div>
                                                                <div class="col-md-3 form-control-comment">
                                                                    <%-- Optional--%>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix">&nbsp;</div>
                                                            <div class="form-group row" style="display: none;">
                                                                <label class="col-md-3 form-control-label">
                                                                </label>
                                                                <div class="col-md-6">
                                                                    <span class="custom-checkbox">
                                                                        <label>
                                                                            <input id="chkReceiveOffer" name="chkReceiveOffer" type="checkbox" value="1" />
                                                                            <span><i class="material-icons rtl-no-flip checkbox-checked">&#xE5CA;</i></span>
                                                                            Receive offers from our partners
                                                                        </label>
                                                                    </span>
                                                                </div>
                                                                <div class="col-md-3 form-control-comment">
                                                                </div>
                                                            </div>
                                                            <div class="form-group row ">
                                                                <label class="col-md-3 form-control-label">
                                                                </label>
                                                                <div class="col-md-6">
                                                                    <input id="chknewsletter" name="chknewsletter" type="checkbox" data-ng-checked="CustPersonalInfo[0].newsletter" value="1" style="width: 5%;" />
                                                                    Sign up for our newsletter 
                                                                </div>
                                                                <div class="col-md-3 form-control-comment">
                                                                </div>
                                                            </div>
                                                        </section>
                                                    </div>
                                                </div>
                                            </section>
                                            <footer class="form-footer clearfix">
                                                <input type="hidden" name="submitCreate" value="1">
                                                <button type="button" class="btn btn-md btn-golden" onclick="CustomerDtlUpdates();">Update</button>
                                            </footer>
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
    <script src="/appjs/dashboard.js"></script>
</asp:Content>


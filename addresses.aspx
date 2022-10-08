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
            ds = data.getDataSet("select * From ps_cms_lang  where id_lang = 1 and id_cms = '54'");
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
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="breadcrumb-section breadcrumb-bg-color--golden">
        <div class="breadcrumb-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h3 class="breadcrumb-title">Your addresses</h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li class="active" aria-current="page">Your addresses</li>
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
                                    <h1 id="js-product-list-header" class="h2">My Addresses</h1>
                                    <hr>
                                    <div class="hidden-sm-down"> 
                                        <p><b>Your addresses are listed below.</b> </p>
                                        <p>Be sure to update your personal information if it has changed.</p> 
                                    </div>
                                </div>
                            </div>
                            <div id="js-product-list-header">
                                <div class="block-category card card-block "></div>
                            </div>
                            <section id="products-list">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-6 mb-1" data-ng-repeat="item in CustAddressList">
                                        <div id="content" class="col-md-12 bg-gray pt-1 pb-1">
                                            <div id="create-account_form" style="border: 1px solid #808080;" class="p-5">
                                                <h3 class="page-subheading">{{item.alias}}</h3>
                                                <hr />
                                                <div class="form_content clearfix" style="min-height: 271px;">
                                                    <p>{{item.firstname}} {{item.lastname}}</p>
                                                    <p ng-show="{{item.company != ''}}">{{item.company}}</p>
                                                    <p>{{item.address1}}</p>
                                                    <p>
                                                        {{item.city}}, 
                                                                    <span ng-hide="{{item.State == null}}">{{item.State}}, </span>{{item.postcode}} 
                                                    </p>
                                                    <p>{{item.countryname}}</p>
                                                    <p>{{item.phone_mobile}}</p>
                                                    <p>{{item.phone}}</p>
                                                    <p>{{item.other}}</p>
                                                    <div class="submit mt-1">
                                                        <a href="AddAddress.aspx?id={{item.id_address}}" class="btn btn-md btn-golden">UPDATE <i class="icon-refresh"></i></a>&nbsp;  <a href="#" data-ng-click="DeleteAddress(item.id_address)" class="btn btn-md btn-golden">DELETE <i class="icon-delete"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12 col-xs-12">
                                        <div id="content" class="col-md-12 pt-1 pb-1">
                                            <a href="/AddAddress.aspx" class="btn btn-md btn-golden">ADD NEW ADDRESS </a>
                                        </div>
                                    </div>
                                </div>

                                <hr>

                                <div class="row">
                                    <div class="col-xs-12 col-sm-12">
                                        <div class="col-md-12 pl-0 pb-1">
                                            <div class="submit mt-1"><span><a href="/my-account" class="btn btn-md btn-golden">BACK TO YOUR ACCOUNT </a></span>&nbsp; <span><a href="/" class="btn btn-md btn-golden">HOME </a></span></div>
                                        </div>
                                    </div>
                                </div>
                            </section> 
                        </section>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
    <script src="/appjs/dashboard.js"></script>
</asp:Content>


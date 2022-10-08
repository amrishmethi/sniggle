<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/controls/LeftCustomer.ascx" TagPrefix="uc1" TagName="LeftCustomer" %>
<%@ Import Namespace="System.Data" %>

<script runat="server">
    DataSet ds = new DataSet();
    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = data.getDataSet("select * From ps_cms_lang  where id_lang = 1 and id_cms = '53'");
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
                        <h3 class="breadcrumb-title">Order history</h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li class="active" aria-current="page">Order history</li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="account-dashboard">
        <div class="container" data-ng-controller="CustomerController">
            <div class="row">
                <uc1:LeftCustomer runat="server" ID="LeftCustomer" />
                <div class="col-sm-12 col-md-9 col-lg-9">
                    <div class="row">
                        <div class="col-md-12 col-xs-12">
                            <h1 id="js-product-list-header" class="h2">Order history</h1>
                            <hr> 
                        </div>
                    </div>
                    <div class="table_page table-responsive">
                        <table>
                            <thead>
                                <tr>
                                    <th>Order reference</th>
                                    <th>Date</th>
                                    <th>Price</th>
                                    <th>Payment</th>
                                    <th>Status</th>
                                    <th>Order Detail</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr data-ng-repeat="item in CustOrderList">
                                    <td><a href="orderdetail.aspx?oid={{item.id_order}}" style="text-underline-position: below; border-bottom: solid 1px;">
                                        <b>{{item.reference}}</b>
                                    </a></td>
                                    <td>{{item.date_add}}</td>
                                    <td>{{item.OrderAmt}}</td>
                                    <td>{{item.payment}}</td>
                                    <td><span style="color: #fff; background-color: {{item.color}}">{{item.osname}}</span></td>
                                    <td><a class="btn btn-md btn-golden" href="orderdetail.aspx?oid={{item.id_order}}">View
                                    </a></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="/appjs/dashboard.js"></script>
</asp:Content>



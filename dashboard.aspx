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
            ds = data.getDataSet("select * From ps_cms_lang  where id_lang = 1 and id_cms = '52'");
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
    <!-- ...:::: Start Breadcrumb Section:::... -->
    <div class="breadcrumb-section breadcrumb-bg-color--golden">
        <div class="breadcrumb-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h3 class="breadcrumb-title">My Account</h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li class="active" aria-current="page">My Account</li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="account-dashboard" data-ng-controller="CustomerController">
        <div class="container">
            <div class="row">
                 <uc1:LeftCustomer runat="server" ID="LeftCustomer" />
                <div class="col-sm-12 col-md-9 col-lg-9">
                    <!-- Tab panes -->
                    <div class="tab-content dashboard_content" data-aos="fade-up" data-aos-delay="200">
                        <div class="tab-pane fade show active" id="dashboard">
                            <h4>Dashboard </h4>
                            <p>
                                From your account dashboard. you can easily check &amp; <a href="/order-history">view your recent orders,</a> and manage your<a href="/addresses"> &nbsp;  Billing and shipping address</a> and <a href="/change-password">Change Password.</a>
                            </p>
                        </div>
                        <div class="tab-pane fade" id="orders">
                            <h4>Order history</h4>
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
                                            <td><a class="btn btn-primary btn-md btn-shadow" href="orderdetail.aspx?oid={{item.id_order}}">View
                                            </a></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="downloads">
                            <h4>Downloads</h4>
                            <div class="table_page table-responsive">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Product</th>
                                            <th>Downloads</th>
                                            <th>Expires</th>
                                            <th>Download</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>Shopnovilla - Free Real Estate PSD Template</td>
                                            <td>May 10, 2018</td>
                                            <td><span class="danger">Expired</span></td>
                                            <td><a href="#" class="view">Click Here To Download Your File</a></td>
                                        </tr>
                                        <tr>
                                            <td>Organic - ecommerce html template</td>
                                            <td>Sep 11, 2018</td>
                                            <td>Never</td>
                                            <td><a href="#" class="view">Click Here To Download Your File</a></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="tab-pane" id="address">
                            <p>The following addresses will be used on the checkout page by default.</p>
                            <h5 class="billing-address">Billing address</h5>
                            <a href="#" class="view">Edit</a>
                            <p><strong>Bobby Jackson</strong></p>
                            <address>
                                Address: Your address goes here.
                            </address>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ...:::: End Account Dashboard Section:::... -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="/appjs/dashboard.js"></script>
</asp:Content>


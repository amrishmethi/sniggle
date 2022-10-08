<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Import Namespace="System.Data" %>
<script runat="server">
    DataSet ds = new DataSet();
    GetData data = new GetData();
    public int coun = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string siteurl = ConfigurationManager.AppSettings["siteurl"].ToString();
            if (Request.QueryString[0] != null)
            {
                string dd = Request.QueryString[0].ToString();
                ds = data.getCMSpage(Request.QueryString[0].ToString(), "Detail");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string pageurl = siteurl + "content/" + ds.Tables[0].Rows[0]["Url"].ToString();
                    lblTopCategory.Text = lblHeading.Text = lblMainHeading.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    divContent.InnerHtml = ds.Tables[0].Rows[0]["content"].ToString();
                    urllink.HRef = "/content/" + ds.Tables[0].Rows[0]["Url"].ToString();
                    this.Page.Title = ds.Tables[0].Rows[0]["meta_title"].ToString();
                    HtmlMeta keywords = new HtmlMeta();
                    keywords.Name = "keywords";
                    keywords.Content = ds.Tables[0].Rows[0]["meta_keywords"].ToString();
                    this.Page.Header.Controls.Add(keywords);
                    HtmlMeta keywords1 = new HtmlMeta();
                    Page.Header.Controls.Add(new LiteralControl("\n"));
                    keywords1.Name = "description";
                    string dss = ds.Tables[0].Rows[0]["meta_description"].ToString();
                    keywords1.Content = dss;
                    this.Page.Header.Controls.Add(keywords1);
                    Page.Header.Controls.Add(new LiteralControl("\n"));
                    HtmlLink canonical = new HtmlLink();
                    canonical.Attributes.Add("rel", "canonical");
                    canonical.Href = pageurl;
                    Header.Controls.Add(canonical);
                }
                else
                {
                    Response.Redirect("/404.aspx");
                }
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
                        <h3 class="breadcrumb-title"> <asp:Label ID="lblMainHeading" runat="server" Text=""></asp:Label></h3>
                        <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                            <nav aria-label="breadcrumb">
                                <ul>
                                    <li><a href="/">Home</a></li>
                                    <li class="active" aria-current="page"><a itemprop="item" id="urllink" runat="server">
                                        <asp:Label ID="lblTopCategory" runat="server" Text=""></asp:Label></a></li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ...:::: End Breadcrumb Section:::... -->
    <div class="account-dashboard">
        <div class="container">
            <div class="row" data-ng-controller="CMSController">
                <h1>
                    <asp:Label ID="lblHeading" runat="server"></asp:Label>
                </h1>
                <div class="cms-block" id="divContent" runat="server">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="/appjs/cmdModule.js"></script> 
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="~/controls/LeftCustomer.ascx" TagPrefix="uc1" TagName="LeftCustomer" %>
<script runat="server">
    GData GetData = new GData();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    GetData data = new GetData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divState.Visible = false;
            ds = GetData.GetCountryList();
            drpCountry.DataSource = ds;
            drpCountry.DataTextField = "name";
            drpCountry.DataValueField = "id_country";
            drpCountry.DataBind();
            drpCountry.Items.Insert(0, "Select");
            if (Request.QueryString["addid"] != null)
            {
                fillDetail(Request.QueryString["addid"].ToString());
                Session["shipaddid"] = Request.QueryString["addid"].ToString();
            }

            if (Request.QueryString["id"] != null)
            {
                fillDetail(Request.QueryString["id"].ToString());
                Session["shipaddid"] = null;
            }
        }
    }

    public void fillDetail(string addid)
    {
        if (addid != "0" && addid != "")
        {
            DataSet ds1 = data.getAddress("", addid);
            string countryid = ds1.Tables[0].Rows[0]["id_country"].ToString();
            string stateid = ds1.Tables[0].Rows[0]["id_state"].ToString();
            drpCountry.SelectedValue = countryid;
            fillState(countryid);
            drpState.SelectedValue = stateid;
        }
    }

    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpCountry.SelectedIndex > 0)
            fillState(drpCountry.SelectedValue);
    }

    public void fillState(string countryid)
    {
        drpState.Items.Clear();
        ds = GetData.GetStateList(countryid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            divState.Visible = true;
            lblStateMan.Text = "Yes";
        }
        else
        {
            divState.Visible = false;
            lblStateMan.Text = "No";
        }
        drpState.DataSource = ds;
        drpState.DataTextField = "name";
        drpState.DataValueField = "id_state";
        drpState.DataBind();
        drpState.Items.Insert(0, "Select");
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
                    <div data-ng-controller="AddAddressController">
                        <section id="main">
                            <div class="row">
                                <div class="col-md-12 col-xs-12">
                                    <h1 class="h2">Your addresses</h1>
                                    <hr />
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">
                                            <div class="col-md-12 pl-0 pb-1">
                                                <h6>To add a new address, please fill out the form below.
                                                </h6>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">
                                            <section class="register-form">
                                                <div class="js-customer-form">
                                                    <div>
                                                        <section class="register-form">
                                                            <%-- <header class="page-header">
                                                                <h1>Your address</h1>
                                                            </header>--%>
                                                            <div class="js-customer-form">
                                                                <section>
                                                                    <input type="hidden" name="id_customer" value="">
                                                                    <div class="form-group row ">
                                                                        <label class="col-md-3 form-control-label required">
                                                                            First name <span style="color: orangered;">*</span>
                                                                        </label>
                                                                        <div class="col-md-6">
                                                                            <input class="form-control fieldReq1" id="txtFirstNameA" name="txtFirstNameA" type="text" value="{{AddressDetail[0].firstname}}" required />
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
                                                                            <input class="form-control" id="txtLastNameA" name="txtLastNameA" type="text" value="{{AddressDetail[0].lastname}}" required />
                                                                        </div>
                                                                        <div class="col-md-3 form-control-comment">
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearfix">&nbsp;</div>
                                                                    <div class="form-group row ">
                                                                        <label class="col-md-3 form-control-label required">
                                                                            Company
                                                                        </label>
                                                                        <div class="col-md-6">
                                                                            <input class="form-control" id="txtCompanyA" name="txtCompanyA" type="text" value="{{AddressDetail[0].company}}" required />
                                                                        </div>
                                                                        <div class="col-md-3 form-control-comment">
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearfix">&nbsp;</div>
                                                                    <div class="form-group row ">
                                                                        <label class="col-md-3 form-control-label required">
                                                                            Address <span style="color: orangered;">*</span>
                                                                        </label>
                                                                        <div class="col-md-6">
                                                                            <input class="form-control fieldReq2" id="txtAddressA" name="txtAddressA" type="text" required value="{{AddressDetail[0].address1}}" />
                                                                        </div>
                                                                        <div class="col-md-3 form-control-comment">
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearfix">&nbsp;</div>
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>

                                                                            <div class="form-group row ">
                                                                                <label class="col-md-3 form-control-label required">
                                                                                    Country <span style="color: orangered;">*</span>
                                                                                </label>
                                                                                <div class="col-md-6">
                                                                                    <asp:DropDownList ID="drpCountry" runat="server" CssClass="form-select fieldReq3" AutoPostBack="True" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged"></asp:DropDownList>

                                                                                </div>
                                                                                <div class="col-md-3 form-control-comment">
                                                                                    <input type="hidden" id="hddPinFormat" name="hddPinFormat" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="clearfix">&nbsp;</div>
                                                                            <div class="form-group row " id="divState" runat="server">
                                                                                <label class="col-md-3 form-control-label required">
                                                                                    State <span style="color: orangered;">*</span>
                                                                                </label>
                                                                                <div class="col-md-6">
                                                                                    <asp:DropDownList ID="drpState" runat="server" CssClass="form-select fieldReq4"></asp:DropDownList>
                                                                                </div>
                                                                                <div class="col-md-3 form-control-comment">
                                                                                </div>
                                                                            </div>
                                                                            <div class="clearfix">&nbsp;</div>
                                                                            <asp:Label ID="lblStateMan" runat="server" Style="display: none;" Text="No"></asp:Label>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                    <div class="form-group row ">
                                                                        <label class="col-md-3 form-control-label required">
                                                                            City <span style="color: orangered;">*</span>
                                                                        </label>
                                                                        <div class="col-md-6">
                                                                            <input class="form-control fieldReq5" id="txtCityA" name="txtCityA" type="text" required value="{{AddressDetail[0].city}}" />
                                                                        </div>
                                                                        <div class="col-md-3 form-control-comment">
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearfix">&nbsp;</div>
                                                                    <div class="form-group row ">
                                                                        <label class="col-md-3 form-control-label required">
                                                                            Zip/Postal Code  <span style="color: orangered;">*</span>
                                                                        </label>
                                                                        <div class="col-md-6">
                                                                            <input class="form-control fieldReq6" id="txtPostalCodeA" name="txtPostalCodeA" type="text" required value="{{AddressDetail[0].postcode}}" />
                                                                        </div>
                                                                        <div class="col-md-3 form-control-comment">
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearfix">&nbsp;</div>
                                                                    <div class="form-group row " style="display: none;">
                                                                        <label class="col-md-3 form-control-label">
                                                                            IOSS Number 
                                                                        </label>
                                                                        <div class="col-md-6">
                                                                            <input class="form-control" id="txtIOSSNo" name="txtIOSSNo" type="text" value="{{AddressDetail[0].IOSSNo}}" />
                                                                        </div>
                                                                        <div class="col-md-3 form-control-comment">
                                                                        </div>
                                                                    </div> 
                                                                    <div class="form-group row ">
                                                                        <label class="col-md-3 form-control-label required">
                                                                            Additional information
                                                                        </label>
                                                                        <div class="col-md-6">
                                                                            <input class="form-control" id="txtAdditionalInfo" name="txtAdditionalInfo" type="text" value="{{AddressDetail[0].other}}" required />
                                                                        </div>
                                                                        <div class="col-md-3 form-control-comment">
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearfix">&nbsp;</div>
                                                                    <div class="form-group row ">
                                                                        <label class="col-md-3 form-control-label required">
                                                                            Home phone 
                                                                        </label>
                                                                        <div class="col-md-6">
                                                                            <input class="form-control" id="txtHomePhone" name="txtHomePhone" type="text" required value="{{AddressDetail[0].phone}}" />
                                                                        </div>
                                                                        <div class="col-md-3 form-control-comment">
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearfix">&nbsp;</div>
                                                                    <div class="form-group row ">
                                                                        <label class="col-md-3 form-control-label required">
                                                                            Mobile phone <span style="color: orangered;">*</span>
                                                                        </label>
                                                                        <div class="col-md-6">
                                                                            <input class="form-control" id="txtMobilePhone" name="txtMobilePhone" type="text" required value="{{AddressDetail[0].phone_mobile}}" />
                                                                        </div>
                                                                        <div class="col-md-3 form-control-comment">
                                                                        </div>
                                                                    </div>
                                                                    <div class="clearfix">&nbsp;</div>
                                                                    <%-- <div class="form-group row">
                                                                        <label class="col-md-3 form-control-label">
                                                                            &nbsp;
                                                                        </label>
                                                                        <div class="col-md-6" style="color: red;">
                                                                            **You must register at least one phone number.
                                                                        </div>
                                                                    </div>--%>
                                                                    <div class="form-group row ">
                                                                        <label class="col-md-3 form-control-label required">
                                                                            Assign an address nickname for future reference.<span style="color: orangered;">*</span>
                                                                        </label>
                                                                        <div class="col-md-6">
                                                                            <input class="form-control fieldReq7" id="txtalias" name="txtalias" type="text" value="{{AddressDetail[0].alias }}" required />
                                                                        </div>
                                                                        <div class="col-md-3 form-control-comment">
                                                                        </div>
                                                                    </div>
                                                                </section>
                                                                <footer class="form-footer clearfix">
                                                                    <input type="hidden" name="submitCreate" value="1">
                                                                    <button type="button" class="btn btn-md btn-golden float-right" data-ng-click="addAddress();">Save</button>
                                                                </footer>
                                                            </div>
                                                        </section>
                                                    </div>
                                                </div>
                                            </section>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">
                                            <div class="col-md-12 pl-0 pb-1">
                                                <div class="submit mt-1"><span><a href="/my-account" class="btn btn-md btn-golden float-left">BACK TO YOUR ACCOUNT </a></span>&nbsp; &nbsp;&nbsp;<span><a href="/index" class="btn btn-md btn-golden">HOME </a></span></div>
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
    <script src="/appjs/address.js"></script>
</asp:Content>


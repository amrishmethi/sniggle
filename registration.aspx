<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Import Namespace="System.Data" %>
<script runat="server">
    GData GetData = new GData();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CustEmail"] != null)
            {
                string email = Session["CustEmail"].ToString();
                txtEmail.Value = email;
            }
        }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/css/style.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div data-ng-controller="registerController">
        <div class="breadcrumb-section breadcrumb-bg-color--golden">
            <div class="breadcrumb-wrapper">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <h3 class="breadcrumb-title">Registration</h3>
                            <div class="breadcrumb-nav breadcrumb-nav-color--black breadcrumb-nav-hover-color--golden">
                                <nav aria-label="breadcrumb">
                                    <ul>
                                        <li><a href="/">Home</a></li>
                                        <li class="active" data-aria-current="page">Registration</li>
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
                    <div class="col-lg-12 col-md-12">
                        <div class="account_form" data-aos="fade-up" data-aos-delay="0">
                            <div style="border: 1px solid #ededed; padding: 23px 20px 29px; border-radius: 5px;">
                                <div class="default-form-box mb-20">
                                    <h3>Your personal information</h3>
                                    <label>Social title</label>
                                    <div class="input-radio">
                                        <span class="custom-radio">
                                            <input name="id_gender"
                                                type="radio"
                                                value="1" />
                                            Mr.</span>
                                        <span class="custom-radio">
                                            <input name="id_gender"
                                                type="radio"
                                                value="2" />
                                            Mrs.</span>
                                        <span class="custom-radio">
                                            <input name="id_gender"
                                                type="radio"
                                                value="0" />
                                            Other</span>
                                    </div>
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>First Name<sup style="color: orangered;">*</sup></label>
                                    <input id="txtFirstName" class="fieldReq1" name="txtFirstName" type="text" value="" required data-ng-model="FirstName" />
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>Last Name</label>
                                    <input id="txtLastName"
                                        name="txtLastName" type="text" data-ng-model="LastName" />
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>Email<sup style="color: orangered;">*</sup></label>
                                    <input class="fieldReq2 EmailIdV" id="txtEmail" name="txtEmail" type="email" runat="server" required />
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>Password<sup style="color: orangered;">*</sup></label>
                                    <input class="charLength fieldReq3" id="txtPassword" name="txtPassword" type="password" pattern=".{5,}" required />
                                </div>
                                <div class="default-form-box mb-20" style="display: none;">
                                    <label>Birthdate</label>
                                    <input type="date" name="txtDOB" id="txtDOB" />
                                </div>
                                <span class="example">(E.g.: 05/31/1970)
                                </span>
                                <label class="checkbox-default" for="offer" style="display: none;">
                                    <input id="chkReceiveOffer" name="chkReceiveOffer" type="checkbox" value="1" />
                                    <span>Sign up for our newsletter</span>
                                </label>
                                <br>
                                <label class="checkbox-default" for="offer">
                                    <input id="chknewsletter" name="chknewsletter" type="checkbox" value="1" />
                                    <span>Sign up for our newsletter</span>
                                </label>

                                <label class="checkbox-default checkbox-default-more-text" for="newsletter" style="display: none;">
                                    <input type="checkbox" id="newsletter">
                                    <span>Sign up for our newsletter<br>
                                        <em>You may unsubscribe at any
                                                        moment. For that purpose, please find our contact info in the
                                                        legal notice.</em></span>
                                </label>
                                <br>
                                <label class="checkbox-default" for="offer">
                                    <input id="chkTC" name="chkTC" type="checkbox" value="1" required />
                                    <span>I agree to the <a href="/content/19-privacy-policy" style="text-decoration: underline; cursor: pointer;" target="_blank"><b>privacy policy.</b></a></span>
                                </label>
                                <div class="default-form-box mt-3">
                                    <h3>Your address</h3>
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>First Name<sup style="color: orangered;">*</sup></label>
                                    <input class="fieldReq5" id="txtFirstNameA" name="txtFirstNameA" type="text" value="{{FirstName}}" required />
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>Last Name</label>
                                    <input id="txtLastNameA"
                                        name="txtLastNameA" type="text" required value="{{LastName}}" />
                                </div>
                                <div class="default-form-box mb-20" style="display: none;">
                                    <label>Company</label>
                                    <input id="txtCompanyA"
                                        name="txtCompanyA" type="text" required value="" />
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>Address<sup style="color: orangered;">*</sup></label>
                                    <input class="fieldReq6" id="txtAddressA" name="txtAddressA" type="text" required />
                                </div>
                                <div class="default-form-box mb-20" style="width: 100%; display: none;">
                                    <label>Country<sup style="color: orangered;">*</sup></label>
                                    <select id="drpCountryA" name="drpCountryA">
                                        <option value="0" selected>Select Country</option>
                                        <option data-ng-repeat="sl in CountryList" value="{{sl.id_country}}">{{sl.name}}</option>
                                    </select>
                                    <input type="hidden" id="hddPinFormat" name="hddPinFormat" />
                                </div>
                                <%--<br />
                                <div class="default-form-box mb-20" data-ng-show="Statecount > 0">
                                    <input type="hidden" id="lblStateMan" value="{{Statecount}}" />
                                    <label>State<sup style="color: orangered;">*</sup></label>
                                    <select id="drpStateA" name="drpStateA" class="fieldReq8">
                                        <option value="0">Select State</option>
                                        <option data-ng-repeat="sl in StateList" value="{{sl.id_state}}">{{sl.name}}</option>
                                    </select>
                                </div> --%>
                                <div class="default-form-box mb-20">
                                    <label>City</label>
                                    <input id="txtCityA" name="txtCityA" type="text" required value="" />
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>State</label>
                                    <input id="txtStateA" name="txtStateA" type="text" required value="" />
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>Zip/Postal Code<sup style="color: orangered;">*</sup></label>
                                    <input class="fieldReq10" id="txtPostalCodeA" name="txtPostalCodeA" type="text" required />
                                </div>
                                <div class="default-form-box mb-20" style="display: none;">
                                    <label>Home phone</label>
                                    <input id="txtHomePhone" name="txtHomePhone" type="text" value="" />
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>Contact No<sup style="color: orangered;">*</sup></label>
                                    <input id="txtMobilePhone" name="txtMobilePhone" type="text" required />
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>Additional information</label>
                                    <input id="txtAdditionalInfo" name="txtAdditionalInfo" type="text" value="" />
                                </div>
                                <div class="default-form-box mb-20">
                                    <label>Assign an address nickname for future reference.<sup style="color: orangered;">*</sup></label>
                                    <input id="txtalias" name="txtalias" type="text" value="My Address" />
                                </div>
                                <div class="save_button mt-3">
                                    <button type="button" class="btn btn-md btn-black-default-hover" onclick="CustomerRegistration();">Submit</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="/appjs/login.js"></script>
</asp:Content>


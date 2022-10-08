<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CODSuccess.aspx.cs" Inherits="CODSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- =====  BREADCRUMB STRAT  ===== -->
    <div class="breadcrumb section pt-60 pb-60 mb-30">
        <div class="container">
        </div>
    </div>
    <!-- =====  BREADCRUMB END===== -->
    <div class="product-section section">
        <!-- =====  CONTAINER START  ===== -->
        <div class="container">
            <div class="row">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="brightex-col">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100%">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; padding-right: 10px; padding-left: 10px; height: 200px;">
                            <div id="DivDetailSuccess" runat="server" class="normaltxt1" style="color: green;">
                                <strong>Your   Order No 
    <asp:Label ID="lblOrderno" runat="server"></asp:Label>
                                    has been successfully placed.<br />
                                    <br />
                            </div>
                            <div id="DivDetailFailed" runat="server" class="normaltxt1" visible="false" style="color: indianred;">
                                <strong>Your Order  
                                    was failed. Please try again.<br />
                                    <br />
                            </div>
                            <div id="divCustLogout" runat="server" class="normaltxt1" style="color: indianred;">
                                <strong>Your order not processed successfully at <a href="https://sniggle.in/" style="font-weight: bold">sniggle.in</a> . It may be due to any of these reasons:<br />
                                </strong>
                                <strong>Session expired due to inactivity</strong><br />
                                <strong>Our system encountered an obstacle</strong><br />
                                <strong><a href="https://sniggle.in/" style="font-weight: bold">Please go back to try again.</a></strong><br />
                                <br />
                            </div>
                            <div id="divPageHtml" runat="server" class="normaltxt1">
                            </div>
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100%; text-align: center;">
                            <div id="divpayment" runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%"></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>


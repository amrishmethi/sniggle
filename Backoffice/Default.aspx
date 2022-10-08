<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Backoffice_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
    <br />   <br />   <br />
 <%--   <asp:Button ID="btn" runat="server" Text="Copy" OnClick="btn_Click" />--%>


  

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
    <script>
    function OnClientLoad(sender, args) {
        $telerik.$(sender.get_inputElement()).on('keypress', function (e) {
            if (sender.get_entries().get_count() > 0) {
                // optionally, notify user that a single selection is allowed
                e.preventDefault();
            }
        });
    }
</script>
</asp:Content>


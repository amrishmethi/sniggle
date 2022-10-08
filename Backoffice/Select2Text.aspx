<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Select2Text.aspx.cs" Inherits="Select2Text" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select 2 on Text Box</title>


</head>
<body>
    <form id="form1" runat="server">
        <script src="https://code.jquery.com/jquery-1.10.1.min.js"></script>
        <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/css/select2.min.css" rel="stylesheet" />
        <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>

        <asp:ListBox ID="drpSelelcted" runat="server" class="select2 js-example-tags drpSelelcted" SelectionMode="Multiple" Style="width: 500px;"></asp:ListBox>
        <asp:TextBox ID="txtSelect2" runat="server"> </asp:TextBox>
        <%--<a class="btnSubmit">Submit</a>--%>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="su" />

        <script type="text/javascript">

            $(".js-example-tags").select2({
                tags: true
            });

        </script>

        <script type="text/javascript">

            $(document).ready(function () {
                $('.btnSubmit').click(function () {
                    var x = document.getElementById("drpSelelcted");
                    for (var i = 0; i < x.options.length; i++) {
                        if (x.options[i].selected == true) {
                            alert(x.options[i].selected);
                        }
                    }
                    alert("Shankar");
                    debugger
                    $.each($(".drpSelelcted option:selected"), function () {
                        var $val = $(this).text();
                    });
                });
            })
        </script>
    </form>
</body>
</html>

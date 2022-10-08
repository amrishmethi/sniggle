<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
        .selected
        {
            background-color: #666;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="gvLocations" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Id" ItemStyle-Width="30">
                <ItemTemplate>
                    <%# Eval("Id") %>
                    <input type="hidden" name="LocationId" value='<%# Eval("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NAME" HeaderText="POSITION" ItemStyle-Width="150" />
            <%--<asp:BoundField DataField="Preference" HeaderText="Preference" ItemStyle-Width="100" />--%>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button Text="Update Preference" runat="server" OnClick="UpdatePreference" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            debugger
            $("[id*=gvLocations]").sortable({
                items: 'tr:not(tr:first-child)',
                cursor: 'pointer',
                axis: 'y',
                dropOnEmpty: false,
                start: function (e, ui) {
                    ui.item.addClass("selected");
                },
                stop: function (e, ui) {
                    ui.item.removeClass("selected");
                },
                receive: function (e, ui) {
                    $(this).find("tbody").append(ui.item);
                }
            });
        });
    </script>
    </form>
</body>
</html>

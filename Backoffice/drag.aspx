<%@ Page Language="C#" AutoEventWireup="true" CodeFile="drag.aspx.cs" Inherits="Backoffice_drag" %>


<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections.ObjectModel" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/themes/redmond/jquery-ui.css"
        type="text/css" media="all" />

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js" type="text/javascript"></script>

    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/jquery-ui.min.js"
        type="text/javascript"></script>

    <script type="text/javascript">

        $(function() {
            $('#sortable').sortable({
                placeholder: 'ui-state-highlight',
                update: OnSortableUpdate
            });
            $('#sortable').disableSelection();

            var progressMessage = 'Saving changes... <img src="loading.gif"/>';
            var successMessage = 'Saved successfully!';
            var errorMessage = 'There was some error in processing your request';
            var messageContainer = $('#message').find('p');

            function OnSortableUpdate(event, ui) {
                debugger
                var order = $('#sortable').sortable('toArray').join(',').replace(/id_/gi, '')
                //console.info(order);
                
                messageContainer.html(progressMessage);
                
                $.ajax({
                    type: 'POST',
                    url: 'Sortable.asmx/UpdateItemsOrder',
                    data: '{itemOrder: \'' + order + '\'}',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: OnSortableUpdateSuccess,
                    error: OnSortableUpdateError
                });
            }

            function OnSortableUpdateSuccess(response) {
                if (response != null && response.d != null) {
                    var data = response.d;
                    if (data == true) {
                        messageContainer.html(successMessage);
                    }
                    else {
                        messageContainer.html(errorMessage);
                    }
                    //console.info(data);
                }
            }

            function OnSortableUpdateError(xhr, ajaxOptions, thrownError) {
                messageContainer.html(errorMessage);
            }

        });

    </script>

    <style type="text/css">
        #sortable
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 400px;
        }
        #sortable li
        {
            margin: 0 5px 5px 5px;
            padding: 5px;
            font-size: 1.2em;
            height: 1.5em;
            cursor: move;
        }
        html > body #sortable li
        {
            height: 1.5em;
            line-height: 1.2em;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="ui-widget" id="message">
        <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
            <p>
                Reorder Items
            </p>
        </div>
    </div>
    <br />
    <ul id="sortable">
        <asp:ListView ID="ItemsListView" runat="server" ItemPlaceholderID="myItemPlaceHolder">
            <LayoutTemplate>
            </LayoutTemplate>
            <LayoutTemplate>
                <asp:PlaceHolder ID="myItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <li class="ui-state-default" id='id_<%# Eval("ItemID") %>'>
                    <%# Eval("ItemName") %></li>
            </ItemTemplate>
        </asp:ListView>
    </ul>
    </div>
    </form>
</body>
    
</html>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        ItemsListView.DataSource = FindItems();
        ItemsListView.DataBind();

    }

    public static IEnumerable<Item> FindItems()
    {
        Collection<Item> items = new Collection<Item>();
      string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(constr))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SelectItems";
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    Item item;
                    while (dataReader.Read())
                    {
                        item = new Item();
                        item.ItemID = (int)dataReader["ItemID"];
                        item.ItemName = Convert.ToString(dataReader["ItemName"]);
                        items.Add(item);
                    }
                }
            }
        }
        return items;
    }
</script>

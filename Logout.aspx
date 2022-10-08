<%@ Page Language="C#" %>

<!DOCTYPE html>

<%@ Import Namespace="System.Data" %>
<script runat="server">
    DataSet ds = new DataSet();
    GetData data = new GetData();
    HttpCookie CustCookie;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["custSniggle"] != null)
        {
            HttpContext.Current.Response.Cookies["custSniggle"].Expires = DateTime.Now.AddDays(-1d);
             HttpContext.Current.Response.Cookies["cartSG"].Expires = DateTime.Now.AddDays(-1d);
            Session.Abandon();
            Response.Redirect("/");
        }

        Response.Redirect("/");
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>

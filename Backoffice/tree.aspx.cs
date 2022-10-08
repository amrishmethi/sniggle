using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backoffice_tree : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string f = Request.ServerVariables["REMOTE_ADDR"].ToString();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + f + "')", true);
        }
    }
}
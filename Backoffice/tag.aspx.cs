using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backoffice_tag : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.Browser.IsMobileDevice)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('mobile')", true);
               
         }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Lap')", true);
            }
        }
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        string ss = tag.Value;
    }
}
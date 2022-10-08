using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Select2Text : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //string selectedItem = "";
        //if (drpSelelcted.Items.Count > 0)
        //{
        //    for (int i = 0; i < drpSelelcted.Items.Count; i++)
        //    {
        //        if (drpSelelcted.Items[i].Selected)
        //        {
        //            if (selectedItem == "")
        //            {
        //                selectedItem = drpSelelcted.Items[i].Value;
        //                break;
        //            }
        //        }
        //    }
        //}
     
        //foreach (ListItem item in drpSelelcted.Items)
        //{
        //    if (item.Selected)
        //    {
        //        string dfd = item.Value;
        //    }
        //}
    }
}
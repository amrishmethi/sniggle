using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_AddCarrier : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdata = new AdminGetData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    BindData(Request.QueryString["id"].ToString());
                }
            }
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
    public void BindData(string id)
    {
        string qq = "select * from ps_carrier  ";
        qq += "  where id_carrier='" + id + "'";
        ds = data.getDataSet(qq);
        txtValue.Text = ds.Tables[0].Rows[0]["name"].ToString();
    }

    public void Save()
    {
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();

        }
        int status = gdata.AddCarrier(action,txtValue.Text, ID);
    }

    protected void btnSaveAnd_Click(object sender, EventArgs e)
    {
        Save();
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved successfully! ')", true);
        txtValue.Text = "";
    }

    protected void btneSave_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect("Carrier.aspx");
    }
}
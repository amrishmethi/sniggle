using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_AddZone : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    string filename1;
    //G:\Project\Earthstone\myearthstone\upload\img\c
    //  string smallUpload_dir = "G:/Project/Earthstone/myearthstone/upload/img/c/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    FillData();
                    btnSave.Text = "Update";
                    btnSaveAnd.Visible = false;
                }
            }
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }

    public void FillData()
    {
        ds = data.getDataSet("select * from ps_zone where IsDeleted=0 and id_zone='" + Request.QueryString["id"].ToString() + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtAmt.Text = ds.Tables[0].Rows[0]["Ship_Amt"].ToString();
            txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
            txtMinimum.Text = ds.Tables[0].Rows[0]["MinShip_Amt"].ToString();
        }
    }
    public void Save()
    {
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
        }

        string name = txtName.Text.Trim(); string Amt = txtAmt.Text; string MinShip_Amt = txtMinimum.Text;
        ds = gdate.InsZone(action, name, txtAmt.Text, ID, MinShip_Amt);
        if (ds.Tables[0].Rows.Count > 0)
        {
            RMG.Functions.MsgBox(ds.Tables[0].Rows[0][0].ToString());
            txtAmt.Text = "0";
            txtName.Text = "";
        }

    }

    protected void btnSaveAnd_Click(object sender, EventArgs e)
    {
        Save();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect("Zone.aspx");
    }
}
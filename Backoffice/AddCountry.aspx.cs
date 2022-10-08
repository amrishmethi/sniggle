using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_AddCountry : System.Web.UI.Page
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
                BindZone();
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
    public void BindZone()
    {
        ds = data.getDataSet("select * from ps_zone where IsDeleted=0 ");
        if (ds.Tables[0].Rows.Count > 0)
        {
            drpZone.DataSource = ds;
            drpZone.DataTextField = "name";
            drpZone.DataValueField = "id_zone";
            drpZone.DataBind();
            drpZone.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void FillData()
    {
        string sq = " select a.id_country,b.name AS name,iso_code,call_prefix,z. id_zone AS zone,a.active AS active ";
        sq += " , z. name AS zoneName FROM  ps_country a LEFT JOIN  ps_country_lang b ON(b.id_country = a.id_country ";
        sq += " AND b.id_lang = 1) LEFT JOIN  ps_zone z ON(z.id_zone = a.id_zone) WHERE a.id_country = '" + Request.QueryString["id"].ToString() + "'";

        ds = data.getDataSet(sq);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCall.Text = ds.Tables[0].Rows[0]["call_prefix"].ToString();
            txtCont.Text = ds.Tables[0].Rows[0]["name"].ToString();
            txtISD.Text = ds.Tables[0].Rows[0]["iso_code"].ToString();
            drpZone.SelectedValue = ds.Tables[0].Rows[0]["zone"].ToString();
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

        string name = txtCont.Text.Trim(); string ISD = txtISD.Text;
        string Call = txtCall.Text; string Zone = drpZone.SelectedValue;
        ds = gdate.InsCountry(action, name, ISD, Call, Zone, ID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            RMG.Functions.MsgBox(ds.Tables[0].Rows[0][0].ToString());
            txtCall.Text = txtCont.Text = txtISD.Text = "";
            drpZone.SelectedIndex = 0;
        }

    }

    protected void btnSaveAnd_Click(object sender, EventArgs e)
    {
        Save();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect("Country.aspx");
    }
}
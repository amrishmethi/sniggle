using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Backoffice_AddZipCode : System.Web.UI.Page
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
                BindCountry();
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
    public void BindCountry()
    {
      
        ds = data.getDataSet("select * from ps_country_lang where id_lang = 1");
        drpCountry.DataSource = ds;
        drpCountry.DataTextField = "name";
        drpCountry.DataValueField = "id_country";
        drpCountry.DataBind();
        drpCountry.Items.Insert(0, new ListItem("Select ", "0"));

       
    }
    public void FillData()
    {
        ds = data.getDataSet("select * from tbl_ZipCode where IsDeleted=0 and ID='" + Request.QueryString["id"].ToString() + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtAmt.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
            txtZipCode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();
           drpCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryID"].ToString();
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

        string ZipCode = txtZipCode.Text.Trim(); string Amt = txtAmt.Text; string CountryID =drpCountry.SelectedValue;
        gdate.InsZipCode(action, CountryID, ZipCode, Amt, ID);

        RMG.Functions.MsgBox("Record Added Successfully......");
        txtAmt.Text = "0";
            txtZipCode.Text = "";
            drpCountry.SelectedIndex = 0;
        

    }

    protected void btnSaveAnd_Click(object sender, EventArgs e)
    {
        Save();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect("ZipCode.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class Backoffice_SizeChartAdd : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    string filename1;
    string uploadthumburl = "../img/SizeChart/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gdate.CategoryDrp(drpCategory);
            if (Request.QueryString["id"] != null)
                FillData();
        }
    }


    public void FillData()
    {
        string sq = "select * from tbl_SizeChart  where IsDeleted=0 and ID='" + Request.QueryString["id"].ToString() + "'";
        ds = data.getDataSet(sq);
        drpCategory.SelectedValue = ds.Tables[0].Rows[0]["CategoryId"].ToString();
        txtDiscription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
        imgChart.ImageUrl = "../img/SizeChart/" + ds.Tables[0].Rows[0]["Image"].ToString();
        ViewState["SizeChart"] = ds.Tables[0].Rows[0]["Image"].ToString();

    }
    public void Save()
    {
        ///var productText = Server.HtmlEncode("<p>example</p>");
        ///
        string sq = "select max(ID) as MaxID from tbl_SizeChart  where IsDeleted=0 ";
        ds = data.getDataSet(sq);
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
        }

        string file = "no_image.jpg";
        if (flpImage.HasFile)
        {
            string fileName = flpImage.FileName;
            filename1 = fileName.Replace(' ', '-');
            Regex reg = new Regex("[*'\",_&#^@]");
            filename1 = reg.Replace(filename1, string.Empty);

            Regex reg1 = new Regex("[ ]");
            filename1 = reg.Replace(filename1, "-");
            if (Request.QueryString["id"] != null)
                file = Request.QueryString["id"].ToString() + "_" + filename1;
            else
                file = ds.Tables[0].Rows[0][0].ToString() + "_" + filename1;
        }
        else if (ViewState["SizeChart"] != null)
        {
            file = ViewState["SizeChart"].ToString();
        }
        else
            file = "no_image.jpg";

        int res = gdate.SizeChartIns(action, ID, drpCategory.SelectedValue, file, txtDiscription.Text);
        if (res == 0)
        {
            if (flpImage.HasFile)
            {
                flpImage.SaveAs(Server.MapPath("../img/SizeChart/" + file));

            }
            RMG.Functions.MsgBox("Record Added Successfully......");
            drpCategory.SelectedIndex = 0;
            txtDiscription.Text = "";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("SizeChart.aspx");
        }
    }
}
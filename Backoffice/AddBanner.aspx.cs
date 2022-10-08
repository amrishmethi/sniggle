using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Configuration;
using System.Net;

public partial class Backoffice_AddBanner : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    string filename1;
    //G:\Project\Earthstone\myearthstone\upload\img\c ../img/FancyShape/
    string smallUpload_dir = "../img/banner/";
    string uploadthumburl = "../img/banner/";
    imgKit imgkt = new imgKit();
    public string FolderPath = ConfigurationManager.AppSettings["smallUpload_dir"].ToString();
    public string onlinePath = ConfigurationManager.AppSettings["smallUpload_dir"].ToString();
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
                    //  btnSaveAnd.Visible = false;
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
        string sq = "select * from tbl_Banner  where IsDeleted=0 and ID='" + Request.QueryString["id"].ToString() + "'";
        ds = data.getDataSet(sq);
        txtDis.Text = ds.Tables[0].Rows[0]["DisIndex"].ToString();
        txtLink.Text = ds.Tables[0].Rows[0]["Link"].ToString();
        txtName.Text = ds.Tables[0].Rows[0]["Title"].ToString();
        drpBanne.SelectedValue = ds.Tables[0].Rows[0]["Type"].ToString();
        drpBannerFor.SelectedValue = ds.Tables[0].Rows[0]["BannerFor"].ToString();
        imgBanner.ImageUrl = "img/banner/" + ds.Tables[0].Rows[0]["Banner"].ToString();
        ViewState["Banner"] = ds.Tables[0].Rows[0]["Banner"].ToString();
        imgBanner.Visible = true;
        if (ds.Tables[0].Rows[0]["LinkOpen"].ToString() == "_blank")
            radNew.Checked = true;
        else if (ds.Tables[0].Rows[0]["LinkOpen"].ToString() == "_self")
            radWithin.Checked = true;
        else
        {
            radNew.Checked = false;
            radWithin.Checked = false;
        }
    }
    public void Save()
    {
        ///var productText = Server.HtmlEncode("<p>example</p>");
        ///
        string sq = "select max(ID) as MaxID from tbl_Banner  where IsDeleted=0 ";
        ds = data.getDataSet(sq);
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
        }

        string file = "no_image.jpg";
        if (FlapBanner.HasFile)
        {
            string fileName = FlapBanner.FileName;
            string newFile = fileName.Replace(' ', '-');
            if (Request.QueryString["id"] != null)
                file = Request.QueryString["id"].ToString() + "_" + newFile;
            else
                file = ds.Tables[0].Rows[0][0].ToString() + "_" + newFile;
        }
        else if (ViewState["Banner"] != null)
        {
            file = ViewState["Banner"].ToString();
        }
        else
            file = "no_image.jpg";
        string name = txtName.Text.Trim(); string DisIndex = txtDis.Text;
        string Type = drpBanne.SelectedValue; string Link = txtLink.Text; string OpenLink = "";
        if (radNew.Checked == true)
            OpenLink = "_blank";
        else if (radWithin.Checked == true)
            OpenLink = "_self";
        else
            OpenLink = "_blank";

        int res = gdate.InsBanner(action, name, Type, file, DisIndex, ID, Link, OpenLink, drpBannerFor.SelectedValue);
        if (res == 0)
        {
            if (FlapBanner.HasFile)
            {
                //if (Type == "Home Banner 1" || Type == "Home Banner 2")
                //{
                //    ResizeImages(FlapBanner.FileName, FlapBanner, Type);
                //}
                //else
                //{
                //    FlapBanner.SaveAs(Server.MapPath("img/banner/" + FlapBanner.FileName));
                //}
                FlapBanner.SaveAs(Server.MapPath("../img/banner/" + file));
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string FName = "banner/";
                string imgFullPath = onlinePath + FName + "/" + file;
                imgkt.uploadImgKit(file, "banner/", imgFullPath);
            }
            RMG.Functions.MsgBox("Record Added Successfully......");
            txtDis.Text = txtName.Text = "";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect("Banner.aspx");
    }
    public void ResizeImages(string Filename, FileUpload FlpDownload, string type)
    {
        string dir = smallUpload_dir;
        smallUpload_dir = uploadthumburl;
        int maxHeight = 0;
        int maxWidth = 0;
        // Resize Image Before Uploading to DataBase
        System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FlpDownload.PostedFiles[0].InputStream);
        int imageHeight = imageToBeResized.Height;
        int imageWidth = imageToBeResized.Width;
        if (type == "Home Banner 1")
        {
            maxHeight = 420;
            maxWidth = 1600;
            imageHeight = maxHeight;
            imageWidth = maxWidth;
        }
        else if (type == "Home Banner 2")
        {
            maxHeight = 128;
            maxWidth = 317;
            imageHeight = maxHeight;
            imageWidth = maxWidth;
        }
        else
        {
            maxHeight = 800;
            maxWidth = 800;
            imageHeight = maxHeight;
            imageWidth = maxWidth;
        }
        Bitmap source = new Bitmap(FlpDownload.PostedFiles[0].InputStream);

        Bitmap target = new Bitmap(imageWidth, imageHeight);
        Graphics g = Graphics.FromImage(target);

        EncoderParameters e;
        g.CompositingQuality = CompositingQuality.HighSpeed;
        g.InterpolationMode = InterpolationMode.Low;

        Rectangle recCompression = new Rectangle(0, 0, imageWidth, imageHeight);
        g.DrawImage(source, recCompression);

        e = new EncoderParameters(2);
        e.Param[0] = new EncoderParameter(Encoder.Quality, 70);
        e.Param[1] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionLZW);

        target.Save(Server.MapPath(uploadthumburl) + Filename, ImageFormat.Jpeg);

        g.Dispose();

    }
}
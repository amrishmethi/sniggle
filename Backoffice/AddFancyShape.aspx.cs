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
public partial class Backoffice_AddFancyShape : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    string filename1;
    //G:\Project\Earthstone\myearthstone\upload\img\c
    string uploadthumburl = "../img/FancyShape/";
    string smallUpload_dir;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                FillCuts();
                if (Request.QueryString["id"] != null)
                {
                    FillData();
                    btnSave.Text = "Update";
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
        string sq = "select * from tbl_FancyShape where ID='" + Request.QueryString["id"].ToString() + "'";
        ds = data.getDataSet(sq);
        txtareaDescription.InnerText = ds.Tables[0].Rows[0]["Description"].ToString();
        txtLink.Text = ds.Tables[0].Rows[0]["VideoLink"].ToString();
        txtName.Text = ds.Tables[0].Rows[0]["Title"].ToString();
        txtCaption1.Text= ds.Tables[0].Rows[0]["caption1"].ToString();
        txtCaption2.Text = ds.Tables[0].Rows[0]["caption2"].ToString();
        txtCaption3.Text = ds.Tables[0].Rows[0]["caption3"].ToString();
        txtCaption4.Text = ds.Tables[0].Rows[0]["caption4"].ToString();
        txtCaption5.Text = ds.Tables[0].Rows[0]["caption5"].ToString();
        img1.ImageUrl = "../img/FancyShape/" + ds.Tables[0].Rows[0]["Image1"].ToString();
        imag2.ImageUrl = "../img/FancyShape/" + ds.Tables[0].Rows[0]["Image2"].ToString();
        imag3.ImageUrl = "../img/FancyShape/" + ds.Tables[0].Rows[0]["Image3"].ToString();
        imag4.ImageUrl = "../img/FancyShape/" + ds.Tables[0].Rows[0]["Image4"].ToString();
        imag5.ImageUrl = "../img/FancyShape/" + ds.Tables[0].Rows[0]["Image5"].ToString();
        imgThumb.ImageUrl = "../img/FancyShape/" + ds.Tables[0].Rows[0]["Thumb"].ToString();
        img1.Visible = true;
        imag3.Visible = true;
        imag4.Visible = true;
        imag5.Visible = true;
        imag2.Visible = true;
        imgThumb.Visible = true;
        ViewState["file1"] = ds.Tables[0].Rows[0]["Image1"].ToString();
        ViewState["file2"] = ds.Tables[0].Rows[0]["Image2"].ToString();
        ViewState["file3"] = ds.Tables[0].Rows[0]["Image3"].ToString();
        ViewState["file4"] = ds.Tables[0].Rows[0]["Image4"].ToString();
        ViewState["file5"] = ds.Tables[0].Rows[0]["Image5"].ToString();
        ViewState["Thumb"] = ds.Tables[0].Rows[0]["Thumb"].ToString();
        drpCuts.SelectedValue= ds.Tables[0].Rows[0]["CreativeCuts"].ToString();
    }
    public void FillCuts()
    {
        ds = data.getDataSet("select * from tbl_CreativeCuts where IsDeleted=0 ");
        drpCuts.DataSource = ds;
        drpCuts.DataTextField = "Name";
        drpCuts.DataValueField = "ID";
        drpCuts.DataBind();
        drpCuts.Items.Insert(0, "Select");
    }
    public void Save()
    {
        ///var productText = Server.HtmlEncode("<p>example</p>");
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
        }
        string name = txtName.Text.Trim(); string Des = txtareaDescription.InnerText;
        string link = txtLink.Text; string file1 = "no_image.jpg"; string file2 = "no_image.jpg";
        string file3 = "no_image.jpg"; string file4 = "no_image.jpg"; string file5 = "no_image.jpg";
        string Thumb = "no_image.jpg";string c1 = txtCaption1.Text;string c2 = txtCaption2.Text;
        string c3 = txtCaption3.Text;string c4 = txtCaption4.Text;string c5 = txtCaption5.Text;
        string CreativeCuts = drpCuts.SelectedValue;
        if (flap1.HasFile)
        {
            file1 = flap1.FileName;
        }
        else if (ViewState["file1"] != null)
        {
            file1 = ViewState["file1"].ToString();
        }
        if (flap2.HasFile)
        {
            file2 = flap2.FileName;
        }
        else if (ViewState["file2"] != null)
        {
            file2 = ViewState["file2"].ToString();
        }
        if (flap3.HasFile)
        {
            file3 = flap3.FileName;
        }
        else if (ViewState["file3"] != null)
        {
            file3 = ViewState["file3"].ToString();
        }
        if (Flap4.HasFile)
        {
            file4 = Flap4.FileName;
        }
        else if (ViewState["file4"] != null)
        {
            file4 = ViewState["file4"].ToString();
        }
        if (flap5.HasFile)
        {
            file5 = flap5.FileName;
        }
        else if (ViewState["file5"] != null)
        {
            file5 = ViewState["file5"].ToString();
        }
        if (flapThumb.HasFile)
        {
            Thumb = flapThumb.FileName;
        }
        else if (ViewState["Thumb"] != null)
        {
            Thumb = ViewState["Thumb"].ToString();
        }
        int res = gdate.InsFancyShap(action, name, link, Des, file1, file2, file3, file4, file5, ID,Thumb,c1,c2,c3,c4,c5, CreativeCuts);
        if (res == 0)
        {
            if (flap1.HasFile)
            {
                ResizeImages(file1, flap1);
            }
            if (flap2.HasFile)
            {
                ResizeImages(file2, flap2);
            }
            if (flap3.HasFile)
            {
                ResizeImages(file3, flap3);
            }
            if (Flap4.HasFile)
            {
                ResizeImages(file4, Flap4);
            }
            if (flap5.HasFile)
            {
                ResizeImages(file5, flap5);
            }
            if (flapThumb.HasFile)
            {
                ResizeImages(Thumb, flapThumb);
            }
            RMG.Functions.MsgBox("Record Added Successfully......");
            txtLink.Text = txtName.Text = txtareaDescription.InnerText = "";
            txtCaption5.Text = txtCaption4.Text = txtCaption3.Text = txtCaption2.Text = txtCaption1.Text = "";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect("FancyShape.aspx");
    }
    public void ResizeImages(string Filename, FileUpload FlpDownload)
    {
        int maxHeight = 0;
        int maxWidth = 0;
        // Resize Image Before Uploading to DataBase
        System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FlpDownload.PostedFile.InputStream);
        int imageHeight = imageToBeResized.Height;
        int imageWidth = imageToBeResized.Width;

        maxHeight = 1000;
        maxWidth = 1000;

        smallUpload_dir = uploadthumburl;


        if (imageHeight > maxHeight)
        {
            imageWidth = (imageWidth * maxHeight) / imageHeight;
            imageHeight = maxHeight;
        }
        if (imageWidth > maxWidth)
        {
            imageHeight = (imageHeight * maxWidth) / imageWidth;
            imageWidth = maxWidth;
        }

        System.IO.MemoryStream stream = new System.IO.MemoryStream(FlpDownload.FileBytes);
        Bitmap source = new Bitmap(stream);

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
    public void ResizeImages1(string Filename, FileUpload FlpDownload)
    {
        string dir = smallUpload_dir;
        int maxHeight = 0;
        int maxWidth = 0;
        // Resize Image Before Uploading to DataBase
        System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FlpDownload.PostedFiles[0].InputStream);
        int imageHeight = imageToBeResized.Height;
        int imageWidth = imageToBeResized.Width;

        maxHeight = 270;
        maxWidth = 270;
        imageHeight = maxHeight;
        imageWidth = maxWidth;
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

        target.Save(dir + Filename, ImageFormat.Jpeg);

        g.Dispose();

    }
}
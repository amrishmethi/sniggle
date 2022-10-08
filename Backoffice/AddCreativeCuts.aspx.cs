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

public partial class Backoffice_AddCreativeCuts : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdata = new AdminGetData();
    string uploadthumburl = "../img/FancyShape/";
    string smallUpload_dir;
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
        string qq = "select * from tbl_CreativeCuts where IsDeleted=0 ";
        qq += "  and ID='" + id + "'";
        ds = data.getDataSet(qq);
        txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        txtContent.Text = ds.Tables[0].Rows[0]["Description"].ToString();
        imgThumb.ImageUrl = "../img/FancyShape/" + ds.Tables[0].Rows[0]["Image"].ToString();
         ViewState["Image"]= ds.Tables[0].Rows[0]["Image"].ToString();
    }

    public void Save()
    {
        string action = "Add"; string ID = "0";
        string file = "no_image.jpg";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();

        }
        if (flapThumb.HasFile)
        {
            file = "CreativeCuts_" + flapThumb.FileName;
        }
        else if (ViewState["Image"] != null)
        {
            file = ViewState["Image"].ToString();
        }
        int status = gdata.AddCreativeCuts(action, txtName.Text, txtContent.Text, file, ID);
        if (flapThumb.HasFile)
        {
            ResizeImages(file, flapThumb);
        }
    }

    protected void btnSaveAnd_Click(object sender, EventArgs e)
    {
        Save();
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved successfully! ')", true);
        txtContent.Text = txtName.Text = "";
    }

    protected void btneSave_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect("CreativeCuts.aspx");
    }
    public void ResizeImages(string Filename, FileUpload FlpDownload)
    {
        int maxHeight = 0;
        int maxWidth = 0;
        // Resize Image Before Uploading to DataBase
        System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FlpDownload.PostedFile.InputStream);
        int imageHeight = imageToBeResized.Height;
        int imageWidth = imageToBeResized.Width;

        maxHeight = 270;
        maxWidth = 270;

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
}
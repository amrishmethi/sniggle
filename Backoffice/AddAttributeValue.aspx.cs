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

public partial class Backoffice_AddAttributeValue : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdata = new AdminGetData();
    string smallUpload_dir = "C:/HostingSpaces/admin/sniggle.in/wwwroot/img/Attribute/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];

            if (!IsPostBack)
            {
                BindFeature();
                if (Request.QueryString["id"] != null)
                {
                    BindData(Request.QueryString["id"].ToString());
                    btnFeatureSave.Text = "Update";
                    btnFeatureSaveAnd.Visible = false;
                }

                if (Session["AttVPageUrl"] != null)
                {
                    hrfval.HRef = Session["AttVPageUrl"].ToString();
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
        string qq = "select * from ps_attribute as a inner join ps_attribute_lang as b ";
        qq += " on a.id_attribute=b.id_attribute and b.id_lang=1 where a.id_attribute='" + id + "'";
        ds = data.getDataSet(qq);
        txtValue.Text = ds.Tables[0].Rows[0]["name"].ToString();
        drpFeature.SelectedValue = ds.Tables[0].Rows[0]["id_attribute_group"].ToString();
        txtFriendlyURL.Text = ds.Tables[0].Rows[0]["link_rewrite"].ToString();
        txtKeyword.Value = ds.Tables[0].Rows[0]["meta_keywords"].ToString();
        txtMetadescription.Text = ds.Tables[0].Rows[0]["meta_description"].ToString();
        txtMetatitle.Text = ds.Tables[0].Rows[0]["meta_title"].ToString();
        img.Src = "../img/Attribute/" + ds.Tables[0].Rows[0]["CoverImage"].ToString();
        ViewState["CoverImage"] = ds.Tables[0].Rows[0]["CoverImage"].ToString();
        txtareaDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
        txtColor.Text = ds.Tables[0].Rows[0]["color"].ToString();
    }
    public void BindFeature()
    {
        ds = gdata.GetAttributeGroup();
        if (ds.Tables[0].Rows.Count > 0)
        {
            drpFeature.DataSource = ds;
            drpFeature.DataTextField = "name";
            drpFeature.DataValueField = "id_attribute_group";
            drpFeature.DataBind();

            if (Request.QueryString["Aid"] != null)
            {
                drpFeature.SelectedValue = Request.QueryString["Aid"].ToString();
            }
            else
            {
                drpFeature.Items.Insert(0, "Select");
            }
        }
    }
    protected void btnFeatureSaveAnd_Click(object sender, EventArgs e)
    {
        InsertFeature();
    }

    protected void btnFeatureSave_Click(object sender, EventArgs e)
    {
        InsertFeature();
        if (Session["AttVPageUrl"] != null)
        {
            Response.Redirect(Session["AttVPageUrl"].ToString());
        }

    }
    public void InsertFeature()
    {
        string action = "Add"; string ID = "0"; string Image = "";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();

        }
        if (flpCover.HasFile)
        {
            Image = flpCover.FileName;
        }
        else if (ViewState["CoverImage"] != null)
        {
            Image = ViewState["CoverImage"].ToString();
        }
        string Metatitle = txtMetatitle.Text.TrimStart().TrimEnd(); string description = txtareaDescription.Text.TrimStart().TrimEnd();
        string Metadescription = txtMetadescription.Text.TrimStart().TrimEnd(); string Metakeywords = txtKeyword.Value.TrimStart().TrimEnd(); string Url = txtFriendlyURL.Text.ToLower();
        int status = gdata.AddattributeV(drpFeature.SelectedValue, txtValue.Text.TrimStart().TrimEnd(), ID, action, Metatitle, Metadescription, Metakeywords, Url, Image, description,txtColor.Text);
        if (flpCover.HasFile)
        {
            ResizeImages(Image, flpCover);

        }
        txtValue.Text =txtareaDescription.Text=txtFriendlyURL.Text=txtKeyword.Value=txtMetadescription.Text=txtMetatitle.Text=txtColor.Text= "";
        drpFeature.SelectedIndex = 0;
        if (Request.QueryString["id"] != null)
        {
            if (Session["AttVPageUrl"] != null)
            {
                Response.Redirect(Session["AttVPageUrl"].ToString());
            }
        }
    }
    public void ResizeImages(string Filename, FileUpload FlpDownload)
    {
        int maxHeight = 0;
        int maxWidth = 0;
        // Resize Image Before Uploading to DataBase
        System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FlpDownload.PostedFile.InputStream);
        int imageHeight = imageToBeResized.Height;
        int imageWidth = imageToBeResized.Width;

        //Filename = Filename ;
        maxHeight = 270;
        maxWidth = 270;
        imageHeight = maxHeight;
        imageWidth = maxWidth;
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

        target.Save(smallUpload_dir + Filename, ImageFormat.Jpeg);

        g.Dispose();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Session["AttVPageUrl"] != null)
        {
            Response.Redirect(Session["AttVPageUrl"].ToString());
        }
    }

    protected void txtValue_TextChanged(object sender, EventArgs e)
    {
        if (txtValue.Text != "")
        {
            string ss = "Sp_GenerateCategoryUrl '" + txtValue.Text.TrimStart().TrimEnd() + "'";
            ds = data.getDataSet(ss);
            txtFriendlyURL.Text = ds.Tables[0].Rows[0][0].ToString().ToLower();
        }
    }
}
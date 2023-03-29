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

public partial class Backoffice_addcategory : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    string filename1;
    //G:\Project\Earthstone\myearthstone\upload\img\c
  //  string smallUpload_dir = "G:/Project/Earthstone/myearthstoneNew/img/c/";
    string smallUpload_dir = "C:/HostingSpaces/admin/sniggle.in/wwwroot/img/c/";
    string pro = "C:/HostingSpaces/admin/sniggle.in/wwwroot/img/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
               
                fillDropdown();
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
        string qq = "SELECT a.id_category, name, description, active,a.NewArrival, a.position position,b.link_rewrite, ";
        qq += " '../img/c/' + cast( a.id_category as nvarchar(500)) + '.jpg' as ImgP, case when active='True' then 1 else 0 end as activeN, ";
        qq += " '../img/c/category_' + cast( a.id_category as nvarchar(500)) + '-thumb.jpg' as ImgPp,";
        qq += "b.meta_title,b.meta_keywords,b.meta_description,a.id_parent FROM ps_category a LEFT JOIN ps_category_lang b ON(b.id_category = a.id_category AND b.id_lang = 1) ";
        qq += " where a.id_category='" + id + "'";
        ds = data.getDataSet(qq);
        txtareaDescription.Text = ds.Tables[0].Rows[0]["description"].ToString(); //Server.HtmlEncode(ds.Tables[0].Rows[0]["description"].ToString());
        txtFriendlyURL.Text = ds.Tables[0].Rows[0]["link_rewrite"].ToString();
        txtKeyword.Value = ds.Tables[0].Rows[0]["meta_keywords"].ToString();
        txtMetadescription.Text = ds.Tables[0].Rows[0]["meta_description"].ToString();
        txtMetatitle.Text = ds.Tables[0].Rows[0]["meta_title"].ToString();
        txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
        ViewState["name"]= ds.Tables[0].Rows[0]["name"].ToString();
        drpCategory.SelectedValue = ds.Tables[0].Rows[0]["id_parent"].ToString();
        imgCover.ImageUrl = ds.Tables[0].Rows[0]["ImgP"].ToString();
        imgThumb.ImageUrl = ds.Tables[0].Rows[0]["ImgPp"].ToString();
        drpStatus.SelectedValue = ds.Tables[0].Rows[0]["activeN"].ToString();
    }
    public void fillDropdown()
    {
        // Category

        ds = gdate.GetCategory();
        drpCategory.DataSource = ds;
        drpCategory.DataTextField = "name";
        drpCategory.DataValueField = "id_category";
        drpCategory.DataBind();
        drpCategory.Items.Insert(0, new ListItem("Parent Category", "2"));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ///var productText = Server.HtmlEncode("<p>example</p>");
        string action = "Add"; string ID = "0";
        byte bb=0;
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
            bb = 0;
        }
        else
            bb = Convert.ToByte(gdate.chkCategory(txtName.Text.TrimStart().TrimEnd()));
        string name = txtName.Text.TrimStart().TrimEnd(); string Parentcategory = drpCategory.SelectedValue;
        string Description = txtareaDescription.Text; string Metatitle = txtMetatitle.Text;
        string Metadescription = txtMetadescription.Text; string Metakeywords = txtKeyword.Value; string Url = txtFriendlyURL.Text.ToLower();
        string one = "1";
        string Displayed = drpStatus.SelectedValue;
        if (bb == 0)
        {
            ds = gdate.AddCategory(action, name, Displayed, Parentcategory, Description, Metatitle, Metadescription, Metakeywords, Url, ID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Request.QueryString["id"] != null)
                {
                    string dir = pro + ViewState["name"].ToString() + "/";
                    string dirN = pro + name + "/";
                    if (Directory.Exists(@dir))
                    { 
                        if(ViewState["name"].ToString() != name)
                        {
                            RenameFolder(dir, dirN);
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(@dir);
                       
                    }
                }
                if (flpCover.HasFile)
                {
                    ResizeImages(ds.Tables[0].Rows[0][0].ToString(), flpCover);
                    ResizeThumbImages(ds.Tables[0].Rows[0][0].ToString(), flpCover);

                }
                if(Request.QueryString["prd"] !=null)
                {
                    Response.Redirect("addproduct.aspx?id=" + Request.QueryString["prd"].ToString() + "#Associations");
                }
                else
                {
                    Response.Redirect("Categories.aspx");
                }
               
            }
            // else
            // RMG.Functions.MsgBox("Please check entry.");
        }
        else
            RMG.Functions.MsgBox("Category Name already exist.");
    }
    /// <summary>
    /// Renames a folder name
    /// </summary>
    /// <param name="directory">The full directory of the folder</param>
    /// <param name="newFolderName">New name of the folder</param>
    /// <returns>Returns true if rename is successfull</returns>
    public static bool RenameFolder(string directory, string newFolderName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(directory) ||
                string.IsNullOrWhiteSpace(newFolderName))
            {
                return false;
            }


            var oldDirectory = new DirectoryInfo(directory);

            if (!oldDirectory.Exists)
            {
                return false;
            }

            if (string.Equals(oldDirectory.Name, newFolderName, StringComparison.OrdinalIgnoreCase))
            {
                //new folder name is the same with the old one.
                return false;
            }

            string newDirectory;

            if (oldDirectory.Parent == null)
            {
                //root directory
                newDirectory = Path.Combine(directory, newFolderName);
            }
            else
            {
                newDirectory = Path.Combine(oldDirectory.Parent.FullName, newFolderName);
            }

            if (Directory.Exists(newDirectory))
            {
                //target directory already exists
                return false;
            }

            oldDirectory.MoveTo(newDirectory);

            return true;
        }
        catch
        {
            //ignored
            return false;
        }
    }
    public void ResizeThumbImages(string Filename, FileUpload FlpDownload)
    {
        int maxHeight = 0;
        int maxWidth = 0;
        // Resize Image Before Uploading to DataBase
        System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FlpDownload.PostedFile.InputStream);
        int imageHeight = imageToBeResized.Height;
        int imageWidth = imageToBeResized.Width;

        Filename = "category_" + Filename + "-thumb.jpg";
        maxHeight = 125;
        maxWidth = 125;
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

    public void ResizeImages(string Filename, FileUpload FlpDownload)
    {
        int maxHeight = 0;
        int maxWidth = 0;
        // Resize Image Before Uploading to DataBase
        System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FlpDownload.PostedFile.InputStream);
        int imageHeight = imageToBeResized.Height;
        int imageWidth = imageToBeResized.Width;

        Filename = Filename + ".jpg";
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

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        if (txtName.Text != "")
        {
            string ss = "Sp_GenerateCategoryUrl '" + txtName.Text.Trim() + "'";
            ds = data.getDataSet(ss);
            txtFriendlyURL.Text = ds.Tables[0].Rows[0][0].ToString().ToLower();
        }
    }
}
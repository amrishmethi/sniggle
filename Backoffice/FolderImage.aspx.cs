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
using System.Web.UI.HtmlControls;
using System.Web.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Net;

public partial class Backoffice_FolderImage : System.Web.UI.Page
{
    HttpCookie folImg;
    imgKit imgkt = new imgKit();
    public string FolderPath = "D:/Shankar/Running_Project/EarthStone_Project/EarthStoneImgKit/img/";
    // public string FolderPath = "C:/HostingSpaces/admin/myearth.sscompusoft.co.in/wwwroot/img/";
    string fileName = @"D:\Shankar\Running_Project\EarthStone_Project\EarthStoneBack\totalimg.txt";
    public string onlinePath = "https://myearth.sscompusoft.co.in/img/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DirectoryInfo info = new DirectoryInfo(FolderPath);
            //var ss = info.GetFiles().Count();
        }
    }
    protected void btn_Click1(object sender, EventArgs e)
    {
        Data data = new Data();
        DataSet dss = data.getDataSet("GetImageTranfer");
        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
        {
            fileName = dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img1"].ToString();

            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img1"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img1"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img2"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img2"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img3"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img3"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img4"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img4"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img5"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img5"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img6"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img6"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img7"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img7"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img8"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img8"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img9"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img9"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img10"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img10"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img11"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img11"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img12"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img12"].ToString());
            imgkt.uploadImgKit(dss.Tables[0].Rows[i]["img13"].ToString(), dss.Tables[0].Rows[i]["FolderName"].ToString(), dss.Tables[0].Rows[i]["imgFullPath"].ToString() + dss.Tables[0].Rows[i]["img13"].ToString());


        }
    }
    protected void btn_Click2(object sender, EventArgs e)
    {
        var info = new DirectoryInfo(FolderPath);
        var files = info.FullName;
        var dirs = info.GetDirectories();
        var dd = dirs.Length;
        foreach (DirectoryInfo foldername in dirs)
        {
            string folderName = foldername.ToString();
            if ("FancyShape" == folderName)
            {
                foreach (string imageFileName in Directory.GetFiles(FolderPath + foldername + "/", "*.jpg"))
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var info1 = new DirectoryInfo(imageFileName);
                    string imagenamewithDirectry = imageFileName;
                    var imagename = info1.Name;
                    string FNameold = foldername.Name;
                    string FName = foldername.Name.Replace(' ', '-');
                    FName = FName.Replace('/', '-').Replace(@"(", string.Empty);
                    FName = FName.Replace(@")", string.Empty);
                    string imgFullPath = FolderPath + FNameold + "/" + imagename;

                    string fileName = "https://ik.imagekit.io/sscomp/img/" + FName + "/" + imagename;
                    imgkt.uploadImgKit(imagename, FName, imgFullPath);
                    //bool result = false;
                    //WebRequest webRequest = WebRequest.Create(fileName);
                    //webRequest.Method = "HEAD";
                    //HttpWebResponse response = null;
                    //try
                    //{
                    //    response = (HttpWebResponse)webRequest.GetResponse();
                    //    result = true;
                    //}
                    //catch (WebException webException)
                    //{
                    //    imgkt.uploadImgKit(imagename, FName, imgFullPath);
                    //}
                    //finally
                    //{
                    //    if (response != null)
                    //    {
                    //        response.Close();
                    //    }
                    //} 
                }
            }
        }
    }

    protected void btn_Click3(object sender, EventArgs e)
    {
        var info = new DirectoryInfo(FolderPath);
        var files = info.FullName;
        var dirs = info.GetDirectories();
        var dd = dirs.Length;
        foreach (DirectoryInfo foldername in dirs)
        {
            string folderName = foldername.ToString();
            if ("FancyShape" == folderName)
            {
                foreach (string imageFileName in Directory.GetFiles(FolderPath + foldername + "/", "*.jpg"))
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var info1 = new DirectoryInfo(imageFileName);
                    string imagenamewithDirectry = imageFileName;
                    var imagename = info1.Name;
                    string FNameold = foldername.Name;
                    string FName = foldername.Name.Replace(' ', '-');
                    FName = FName.Replace('/', '-').Replace(@"(", string.Empty);
                    FName = FName.Replace(@")", string.Empty);
                    string imgFullPath = FolderPath + FNameold + "/" + imagename;

                    string fileName = "https://ik.imagekit.io/sscomp/img/" + FName + "/" + imagename;
                    string sourceFilePath = "https://ik.imagekit.io/sscomp/giftyimg/By-Types/10280.jpg";
                    string destinationPath = "https://ik.imagekit.io/sscomp/giftyimg/Home/";
                }
            }
        }
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        string sourceFilePath = "/aa/about-3.jpg";
        string destinationPath = "/giftyimg/Home";
        imgkt.moveImgKit(sourceFilePath, destinationPath);
    }
}
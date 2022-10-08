<%@ WebHandler Language="C#" Class="UploadFile" %>

using System;
using System.Web;
using System.IO;
public class UploadFile : IHttpHandler
{
    NData nData = new NData();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string ProdID = context.Request.QueryString["ProdID"].Trim();
        string AttriID = context.Request.QueryString["AttriID"].Trim();
        if (context.Request.Files.Count > 0)
        {
            string cartID = "0";
            HttpFileCollection files = context.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                if (HttpContext.Current.Request.Cookies["cartSG"] != null)
                {
                    HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
                    cartID = user.Values["cartID"].ToString();
                }
                HttpPostedFile file;
                file = files[i];
                string fname;
                if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    fname = file.FileName;
                }
                fname = file.FileName;
                bool folderExists = Directory.Exists(context.Server.MapPath("~/img/CustomizeOrder/"));
                if (!folderExists)
                    Directory.CreateDirectory(context.Server.MapPath("~/img/CustomizeOrder/"));

                fname = Path.Combine(context.Server.MapPath("~/img/CustomizeOrder/"), fname);
                file.SaveAs(fname);
                    nData.UploadCusomizeFile(cartID, ProdID, AttriID, file.FileName);
            }
        }
        context.Response.ContentType = "text/plain";
        context.Response.Write("File Uploaded Successfully!");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
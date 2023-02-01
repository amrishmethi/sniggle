using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Setting
/// </summary>
public class Setting
{
    Data data = new Data();
    string query;
    int status;
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand(); 
    public Setting()
    {
        WebSetting();
        //
        // TODO: Add constructor logic here
        //
    }
    public string WebsiteName { get;set; }
    public string WebsiteFrontUrl { get;set; }
    public string WebsiteBackUrl { get;set; }
    public string ImageUrl { get;set; }
    public string ImageId { get;set; }
    public string frommailaddress { get;set; }
    public string hostname { get;set; }
    public string smtp { get;set; }
    public string mailServer { get;set; }
    public string Password { get;set; }
    public string Port { get;set; }
    public string Upload_dir { get;set; }
    public string ImageApiLink { get;set; }
    public string IKPubKey { get;set; }
    public string IKPrivateKey { get;set; }
    public string ImgMoveApi { get;set; }
    public string Authorization_Basic { get;set; }
    public string Cookie_csrf { get;set; }
    public string ExcelPath { get; set; }


    public void WebSetting()
    {
        cmd = new SqlCommand("Select * from tbl_WebsiteSetting");
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Clear();
        ds = data.getDataSet(cmd);
        WebsiteName = ds.Tables[0].Rows[0]["WebsiteName"].ToString();
        WebsiteFrontUrl = ds.Tables[0].Rows[0]["WebsiteFrontUrl"].ToString();
        WebsiteBackUrl = ds.Tables[0].Rows[0]["WebsiteBackUrl"].ToString();
        ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
        ImageId = ds.Tables[0].Rows[0]["ImageId"].ToString();
        frommailaddress = ds.Tables[0].Rows[0]["frommailaddress"].ToString();
        hostname = ds.Tables[0].Rows[0]["hostname"].ToString();
        smtp = ds.Tables[0].Rows[0]["smtp"].ToString();
        mailServer = ds.Tables[0].Rows[0]["mailServer"].ToString();
        Password = ds.Tables[0].Rows[0]["Password"].ToString();
        Port = ds.Tables[0].Rows[0]["Port"].ToString();
        Upload_dir = ds.Tables[0].Rows[0]["Upload_dir"].ToString();
        ImageApiLink = ds.Tables[0].Rows[0]["ImageApiLink"].ToString();
        IKPubKey = ds.Tables[0].Rows[0]["IKPubKey"].ToString();
        IKPrivateKey = ds.Tables[0].Rows[0]["IKPrivateKey"].ToString();
        ImgMoveApi = ds.Tables[0].Rows[0]["ImgMoveApi"].ToString();
        Authorization_Basic = ds.Tables[0].Rows[0]["Authorization_Basic"].ToString();
        Cookie_csrf = ds.Tables[0].Rows[0]["Cookie_csrf"].ToString();
        
       
        ExcelPath = ds.Tables[0].Rows[0]["ExcelPath"].ToString();
    }

     
}
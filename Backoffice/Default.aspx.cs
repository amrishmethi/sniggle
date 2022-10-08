using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backoffice_Default : System.Web.UI.Page
{
    Data data = new Data();
    GetData gdate = new GetData();
    DataSet ds = new DataSet();
    protected void Page_Init(object sender, EventArgs e)
    {
        var dataSource = new string[] { "One", "Two", "Three" };
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        string qq = "select img.id_image,cat.name from myearth_db.ps_image img inner join myearth_db.ps_product prod on img.id_product=prod.id_product ";
        qq += " inner join myearth_db.ps_category_lang cat on prod.id_category_default=cat.id_category where cat.id_lang = 1";
        ds = data.getDataSet(qq);
        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        {
            int n = Convert.ToInt32(ds.Tables[0].Rows[j]["id_image"]);
            int len = (n.ToString()).Length;
            //if (n == 0) s=0;

            var digits = new List<int>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            var s = arr;
            string ff = "";
            for (int i = 0; i < len; i++)
            {
                int d = arr[i];
                //if (i < len - 1)
                ff += d + "/";
                //if (i == len - 1)
                //    ff += d;
               // G:\Project\Earthstone\myearthstone\upload\ppp
                if (Directory.Exists(@"G:/Project/Earthstone/myearthstone/upload/ppp/" + ff))
                {
                    if (i == len - 1)
                    {
                        //if (File.Exists(Server.MapPath(@"~/upload/ppp/ppp/" + ff + ds.Tables[0].Rows[j]["id_image"] + ".jpg")))
                        if (File.Exists(Server.MapPath("~/upload/ppp/" + ff + ds.Tables[0].Rows[j]["id_image"] + ".jpg")))
                        {
                            if (Directory.Exists(@"G:/Project/Earthstone/myearthstone/upload/ppp/img/" + ds.Tables[0].Rows[j]["name"]))
                            {
                                string path = "G:/Project/Earthstone/myearthstone/upload/ppp/img/" + ds.Tables[0].Rows[j]["name"] + "/";
                                string Fromfile = "G:/Project/Earthstone/myearthstone/upload/ppp/" + ff + ds.Tables[0].Rows[j]["id_image"] + ".jpg";
                                string Tofile = path + ds.Tables[0].Rows[j]["id_image"] + ".jpg";
                                File.Move(Fromfile, Tofile);
                            }
                            else
                            {
                                Directory.CreateDirectory(@"G:/Project/Earthstone/myearthstone/upload/ppp/img/" + ds.Tables[0].Rows[j]["name"]);
                                if (Directory.Exists(@"G:/Project/Earthstone/myearthstone/upload/ppp/img/" + ds.Tables[0].Rows[j]["name"]))
                                {
                                    string path = "G:/Project/Earthstone/myearthstone/upload/ppp/img/" + ds.Tables[0].Rows[j]["name"] + "/";
                                    string Fromfile = "G:/Project/Earthstone/myearthstone/upload/ppp/" + ff + ds.Tables[0].Rows[j]["id_image"] + ".jpg";
                                    string Tofile = path + ds.Tables[0].Rows[j]["id_image"] + ".jpg";
                                    File.Move(Fromfile, Tofile);
                                }
                            }
                        }
                        else
                        {

                        }

                        //
                        string sq = " select name from myearth_db.ps_image_type ";
                        DataSet dsimg = data.getDataSet(sq);
                        for (int ii = 0; ii < dsimg.Tables[0].Rows.Count; ii++)
                        {
                            //if (File.Exists(Server.MapPath("~/upload/ppp/ppp/" + ff + dsimg.Tables[0].Rows[ii]["name"] + ".jpg")))
                            if (File.Exists(Server.MapPath("~/upload/ppp/" + ff + ds.Tables[0].Rows[j]["id_image"] + "-" + dsimg.Tables[0].Rows[ii]["name"] + ".jpg")))
                            {
                                if (Directory.Exists(@"G:/Project/Earthstone/myearthstone/upload/ppp/img/" + ds.Tables[0].Rows[j]["name"]))
                                {
                                    string path = "G:/Project/Earthstone/myearthstone/upload/ppp/img/" + ds.Tables[0].Rows[j]["name"]+"/";
                                    string Fromfile = "G:/Project/Earthstone/myearthstone/upload/ppp/" + ff + ds.Tables[0].Rows[j]["id_image"]+"-"+ dsimg.Tables[0].Rows[ii]["name"] + ".jpg";
                                    string Tofile = path + ds.Tables[0].Rows[j]["id_image"] + "-" + dsimg.Tables[0].Rows[ii]["name"] + ".jpg";
                                    File.Move(Fromfile, Tofile);
                                }
                                else
                                {
                                    Directory.CreateDirectory(@"G:/Project/Earthstone/myearthstone/upload/ppp/img/" + ds.Tables[0].Rows[j]["name"]);
                                    if (Directory.Exists(@"G:/Project/Earthstone/myearthstone/upload/ppp/img/" + ds.Tables[0].Rows[j]["name"]))
                                    {
                                        string path = "G:/Project/Earthstone/myearthstone/upload/ppp/img/" + ds.Tables[0].Rows[j]["name"] + "/";
                                        string Fromfile = "G:/Project/Earthstone/myearthstone/upload/ppp/" + ff + ds.Tables[0].Rows[j]["id_image"] + "-" + dsimg.Tables[0].Rows[ii]["name"] + ".jpg";
                                        string Tofile = path + ds.Tables[0].Rows[j]["id_image"] + "-" + dsimg.Tables[0].Rows[ii]["name"] + ".jpg";
                                        File.Move(Fromfile, Tofile);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
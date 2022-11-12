using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Admin
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class FrontWeb : System.Web.Services.WebService
{
    Data data = new Data();
    DataSet ds = new DataSet();
    DataSet dsSA = new DataSet();
    GetData gdata = new GetData();
    GData gdat = new GData();
    EmailFormat EF = new EmailFormat();
    public double FreeShippingAmt = 1500;
    public FrontWeb()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public string GetSearchCat()
    {
        ds = gdata.getSearchCategory();
        string jsonstring = string.Empty;
        jsonstring = JsonConvert.SerializeObject(ds.Tables[0]);
        return jsonstring;
    }

    [WebMethod(EnableSession = true)]
    public string getMainLogin(string EmailID, string Password)
    {
        string str = "Not Exist";
        ds = data.getDataSet("select * from tbl_MainLogin where UserName='" + EmailID + "' and Password='" + Password + "' and IsActive=1");
        if (ds.Tables[0].Rows.Count > 0)
        {
            HttpCookie User = new HttpCookie("WebAdmin");
            User.Expires = DateTime.Now.AddDays(30d);
            User.Values.Add("UserName", ds.Tables[0].Rows[0]["UserName"].ToString());
            User.Values.Add("Password", ds.Tables[0].Rows[0]["Password"].ToString());
            HttpContext.Current.Response.Cookies.Add(User);
            str = "Products.aspx";
        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string getProducts(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getProducts(catid, "");
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getProductsSearch(string Slug, string OBY)
    {
        string[] dd = Slug.Split(',');
        string[] query1 = dd[0].Split('=');
        string[] query2 = dd[1].Split('=');
        string cat = query1[1];
        string keyw = query2[1];

        //DataSet ds = gdata.getProductsSearch(cat, keyw.Replace("+", " "), OBY); 
        //dt.Merge(ds.Tables[0]);
        DataTable dt = new DataTable();
        dt = gdata.getProductsSearch(cat, keyw.Replace("+", " "), OBY);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getFilterProducts(string Slug, string TypeID, string OrderBy, string subType)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getFilterProduct(catid, TypeID, OrderBy, subType);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getFilterProductsForOther(string TypeID, string OrderBy)
    {
        DataSet ds = gdata.getFilterProductForOther(TypeID, OrderBy);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getAttributeStone(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getMainGroupStone(catid);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ds = gdata.getAttribute(catid, dt.Rows[i]["id_attribute_group"].ToString());
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                        jsonString.Append("\"Attri\":[");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            {
                                if (k == 0)
                                {
                                    jsonString.Append("{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\",\"coun\": \"" + ds.Tables[0].Rows[k]["coun"].ToString() + "\"}");
                                }
                                else
                                {
                                    jsonString.Append(",{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\",\"coun\": \"" + ds.Tables[0].Rows[k]["coun"].ToString() + "\"}");
                                }
                            }
                        }
                        jsonString.Append("]");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    jsonString.Append("}");
                }
                else
                {
                    jsonString.Append("},");
                }
            }
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }


    [WebMethod(EnableSession = true)]
    public string getAttributes(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getMainGroup(catid);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ds = gdata.getAttribute(catid, dt.Rows[i]["id_attribute_group"].ToString());
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                        jsonString.Append("\"Attri\":[");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            {
                                if (k == 0)
                                {
                                    jsonString.Append("{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\",\"coun\": \"" + ds.Tables[0].Rows[k]["coun"].ToString() + "\",\"isCheck\": \"false\"}");
                                }
                                else
                                {
                                    jsonString.Append(",{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\",\"coun\": \"" + ds.Tables[0].Rows[k]["coun"].ToString() + "\",\"isCheck\": \"false\"}");
                                }
                            }
                        }
                        jsonString.Append("]");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    jsonString.Append("}");
                }
                else
                {
                    jsonString.Append("},");
                }
            }
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }


    [WebMethod(EnableSession = true)]
    public string getSubCategories(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getSubCategory(catid);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(ds.Tables[0]);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getStoneAttributes(string Slug, string TypeID)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getMainGroup(catid);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ds = gdata.getAttribute(catid, dt.Rows[i]["id_attribute_group"].ToString());

                jsonString.Append("{");



                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                        jsonString.Append("\"Attri\":[");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            {
                                if (k == 0)
                                {
                                    jsonString.Append("{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\",\"coun\": \"" + ds.Tables[0].Rows[k]["coun"].ToString() + "\"}");
                                }
                                else
                                {
                                    jsonString.Append(",{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\",\"coun\": \"" + ds.Tables[0].Rows[k]["coun"].ToString() + "\"}");
                                }
                            }
                        }
                        jsonString.Append("]");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    jsonString.Append("}");
                }
                else
                {
                    jsonString.Append("},");
                }
            }
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }

    [WebMethod(EnableSession = true)]
    public string getFilterAttributes(string Slug, string TypeID)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        string[] attId = TypeID.Split(',');
        int count = 0;
        string query = "";


        DataSet ds = gdata.getMainGroup(catid);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ds = gdata.getAttribute(catid, dt.Rows[i]["id_attribute_group"].ToString());


                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                        jsonString.Append("\"Attri\":[");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            {
                                count = Convert.ToInt32(ds.Tables[0].Rows[k]["coun"].ToString());
                                if (TypeID != "")
                                {
                                    query = "select distinct pl.name,at.id_attribute_group from ps_product prod  inner join ps_category_lang cat on prod.id_category_default = cat.id_category inner join ps_product_lang pl on prod.id_product = pl.id_product inner join ps_category_product catp on prod.id_product = catp.id_product inner join ps_product_attribute pa on prod.id_product = pa.id_product";
                                    query += " inner join ps_product_attribute_combination pac on pa.id_product_attribute = pac.id_product_attribute ";
                                    for (int att = 0; att < attId.Length; att++)
                                        query += " inner join ps_product_attribute_combination pac" + att + " on pa.id_product_attribute = pac" + att + ".id_product_attribute ";
                                    query += " inner join ps_attribute_lang al on pac.id_attribute = al.id_attribute inner join ps_attribute at on  al.id_attribute = at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group = agl.id_attribute_group where cat.id_lang = 1  and pl.id_lang = 1 and prod.active = 1 and al.id_lang = 1 and agl.id_lang = 1 and catp.id_category = " + catid + " and  pac.id_attribute=" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "";
                                    for (int att = 0; att < attId.Length; att++)
                                        query += " and pac" + att + ".id_attribute = " + attId[att] + " ";
                                    DataSet dsCount = data.getDataSet(query);
                                    if (dsCount.Tables[0].Rows.Count > 0)
                                    {
                                        // if (ds.Tables[0].Rows[k]["id_attribute_group"].ToString() != dsCount.Tables[0].Rows[0]["id_attribute_group"].ToString())
                                        count = dsCount.Tables[0].Rows.Count;
                                    }
                                }
                                string isChecked = "false";
                                if (attId.Length > 0)
                                {
                                    for (int att = 0; att < attId.Length; att++)
                                    {
                                        if (ds.Tables[0].Rows[k]["id_attribute"].ToString() == attId[att])
                                        {
                                            isChecked = "true";
                                        }
                                    }
                                }
                                if (count != 0)
                                {
                                    if (k == 0)
                                    {
                                        jsonString.Append("{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\",\"coun\": \"" + count + "\",\"isCheck\": \"" + isChecked + "\"}");
                                    }
                                    else
                                    {
                                        jsonString.Append(",{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\",\"coun\": \"" + count + "\",\"isCheck\": \"" + isChecked + "\"}");
                                    }
                                }
                            }
                        }
                        jsonString.Append("]");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    jsonString.Append("}");
                }
                else
                {
                    jsonString.Append("},");
                }
            }
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }

    [WebMethod(EnableSession = true)]
    public string getDetail(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getDetail(catid);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\"");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    jsonString.Append("}");
                }
                else
                {
                    jsonString.Append("},");
                }
            }
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }


    [WebMethod(EnableSession = true)]
    public string getStockQty(string ProdId)
    {
        DataSet ds = gdata.getDetail(ProdId);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\"");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    jsonString.Append("}");
                }
                else
                {
                    jsonString.Append("},");
                }
            }
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }

    [WebMethod(EnableSession = true)]
    public string getStockQtyAttribute(string ProdId, string AttId)
    {
        DataSet ds = gdata.getProductStockDetail(ProdId, AttId);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\"");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    jsonString.Append("}");
                }
                else
                {
                    jsonString.Append("},");
                }
            }
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }


    [WebMethod(EnableSession = true)]
    public string getImage(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getItemImages(catid);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getVideo(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getVideo(catid);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }


    [WebMethod(EnableSession = true)]
    public string geItemFeatures(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.geItemFeatures(catid);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getItemReviews(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.geItemReviews(catid);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getItemAttributesRadio(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getItemMainGroup(catid, "radio");
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        DataColumn clm = new DataColumn("SelectedItem", typeof(Int32));
        dt.Columns.Add(clm);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ds = gdata.getItemAttribute(catid, dt.Rows[i]["id_attribute_group"].ToString());
                dt.Rows[i]["SelectedItem"] = ds.Tables[0].Rows[0]["id_attribute"].ToString();
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                        jsonString.Append("\"Attri\":[");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            {
                                if (k == 0)
                                {
                                    jsonString.Append("{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\"}");
                                }
                                else
                                {
                                    jsonString.Append(",{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\"}");
                                }
                            }
                        }
                        jsonString.Append("]");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    jsonString.Append("}");
                }
                else
                {
                    jsonString.Append("},");
                }
            }
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }


    [WebMethod(EnableSession = true)]
    public string getProductPrice(string Slug, string TypeID, string price, string disprice)
    {
        DataSet ds = new DataSet();
        string str = "";
        string catid = "";
        string imgstr = "";
        if (!TypeID.Contains("undefined"))
        {

            string[] aa = Slug.Split('/');
            string catslug = aa[aa.Length - 1];
            string[] bb = catslug.Split('-');
            catid = bb[0].ToString();

            DataTable tbl = new DataTable();
            tbl.Columns.Add("att", typeof(Int32));


            string[] kk = TypeID.Split(',');
            for (int i = 0; i < kk.Length; i++)
            {
                DataRow dtrow = tbl.NewRow();
                dtrow["att"] = kk[i];
                tbl.Rows.Add(dtrow);
            }

            DataSet ds1 = data.getDataSet("select distinct alm.id_attribute,agl.id_attribute_group, agl.name as groupname, alm.name as attributename,at.position from ps_product prod  inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute  inner join ps_attribute_lang alm on pac.id_attribute=alm.id_attribute inner join ps_attribute at on alm.id_attribute=at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group=agl.id_attribute_group where prod.id_product = " + catid + " and(agl.id_attribute_group = 6 or agl.id_attribute_group = 7)  and prod.active = 1 and alm.id_lang = 1 and agl.id_lang = 1 and pa.IsDeleted = 0 order by at.position");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < ds1.Tables[0].Rows.Count; k++)
                {
                    DataRow dtrow = tbl.NewRow();
                    dtrow["att"] = ds1.Tables[0].Rows[k]["id_attribute"].ToString();
                    tbl.Rows.Add(dtrow);
                }
            }

            DataView dv = tbl.DefaultView;
            dv.Sort = "att";
            DataTable sortedDT = dv.ToTable();
            for (int i = 0; i < sortedDT.Rows.Count; i++)
            {
                if (!str.Contains(sortedDT.Rows[i]["att"].ToString())) //add on 10/11/2020
                {
                    if (i == 0)
                        str = sortedDT.Rows[i]["att"].ToString();
                    else
                        str += ", " + sortedDT.Rows[i]["att"].ToString();
                }
            }

            //string query = "with tblFeatured as (SELECT distinct PPA.id_product_attribute, PPA.id_product, PPA.reference,ppa.unit_price_impact, Stuff( (SELECT N', ' + cast(PPAC.id_attribute as nvarchar) FROM ps_product_attribute_combination as PPAC WHERE PPAC.id_product_attribute = PPA.id_product_attribute order by PPAC.id_attribute FOR XML PATH(''), TYPE).value('text()[1]', 'nvarchar(max)'),1,2,N'') as Attt FROM ps_product_attribute as PPA Inner Join ps_product_attribute_combination as PPAC on PPA.id_product_attribute = PPAC.id_product_attribute where PPA.id_product = " + catid + ") Select* From tblFeatured where  Attt = '" + str + "' ";
            //ds = data.getDataSet(query);

            ds = gdat.GetProductImpectPrice(catid, str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                double MinOrderQty = Convert.ToDouble(ds.Tables[0].Rows[0]["MinOrderQty"].ToString()); ;
                double StockQty = Convert.ToDouble(ds.Tables[0].Rows[0]["StockQty"].ToString()); ;
                double oldprice = Convert.ToDouble(price.Replace("$", ""));
                double olddisprice = Convert.ToDouble(disprice.Replace("$", ""));
                double newprice = Convert.ToDouble(ds.Tables[0].Rows[0]["unit_price_impact"].ToString());
                double newprice1 = Convert.ToDouble(ds.Tables[0].Rows[0]["unit_price_impact1"].ToString());
                double finalprice = oldprice + newprice1;
                double discountprice = olddisprice + newprice;
                string prodAttID = ds.Tables[0].Rows[0]["id_product_attribute"].ToString();
                string prodStatus = ds.Tables[0].Rows[0]["StockStatus"].ToString();
                str = String.Format("{0:0.00}", finalprice) + "_" + String.Format("{0:0.00}", discountprice) + "_" + prodAttID + "_" + ds.Tables[0].Rows[0]["reference"].ToString() + "_" + MinOrderQty + "_" + StockQty + "_" + prodStatus;
            }
            else
            {
                str = price + "_" + disprice + "_0_NotExist";
            }
        }
        else
        {
            str = price + "_" + disprice;
        }

        #region Bind Image According To Combination Start
        if (ds.Tables[0].Rows.Count > 0)
        {
            string ProdId = ds.Tables[0].Rows[0]["id_product"].ToString();
            string AttId = ds.Tables[0].Rows[0]["id_product_attribute"].ToString();
            imgstr = gdat.GetImgAccordingToCombination(ProdId, AttId);
        }
        str = str + "_" + imgstr;
        #endregion

        return str;
    }


    [WebMethod(EnableSession = true)]
    public string addProductReview(string Slug, string Name, string Rating, string Title, string Comment)
    {
        Data dat = new Data();
        string str = "Success";
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();

        string maxid = dat.getDataSet("select max(id_guest)+1 as maxid from ps_product_comment").Tables[0].Rows[0]["maxid"].ToString();

        dat.executeCommand("insert into ps_product_comment(id_product, id_customer, id_guest, title, [content], customer_name, grade, validate, deleted, date_add) values(" + catid + ",0," + maxid + ",'" + Title + "','" + Comment + "','" + Name + "'," + Rating + ",1,0,'" + DateTime.Now + "')");


        return str;
    }




    [WebMethod(EnableSession = true)]
    public string getItemAttributesSelect(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = gdata.getItemMainGroup(catid, "select");
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        DataColumn clm = new DataColumn("SelectedItem", typeof(Int32));
        dt.Columns.Add(clm);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ds = gdata.getItemAttribute(catid, dt.Rows[i]["id_attribute_group"].ToString());

                string dd = ds.Tables[1].Rows[0]["id_attribute"].ToString();
                string aaaid = ds.Tables[1].Rows[0]["id_attribute_group"].ToString();
                dt.Rows[i]["SelectedItem"] = ds.Tables[0].Rows[0]["id_attribute"].ToString();
                if (aaaid == "1")
                {
                    dt.Rows[i]["SelectedItem"] = dd;
                }
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                          + "\":" + "\""
                                          + dt.Rows[i][j].ToString().Replace('\"', '\'') + "\",");
                        jsonString.Append("\"Attri\":[");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            {
                                if (k == 0)
                                {
                                    jsonString.Append("{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\"}");
                                }
                                else
                                {
                                    jsonString.Append(",{\"id\": \"" + ds.Tables[0].Rows[k]["id_attribute"].ToString() + "\",\"Name\": \"" + ds.Tables[0].Rows[k]["attributename"].ToString() + "\"}");
                                }
                            }
                        }
                        jsonString.Append("]");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    jsonString.Append("}");
                }
                else
                {
                    jsonString.Append("},");
                }
            }
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }

    [WebMethod(EnableSession = true)]
    public string addToCart(string ProdID, string AttriID, string SKU, string Image1, string ProductName, string Qty, string Price, string DiscountPrice)
    {
        if (Qty == "" || Qty == "0")
        {
            Qty = "1";
        }

        string UserID = "0";
        string cartID = "0";
        string gustID = "0";
        string[] aa = ProdID.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        ProdID = bb[0].ToString();
        Data dat = new Data();
        string status = "0";
        decimal Amount = 0;

        DataSet ds = data.getDataSet("select * from ps_product_attribute where id_product_attribute=" + AttriID + "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            double oldprice = Convert.ToDouble(Price);
            double olddisprice = Convert.ToDouble(DiscountPrice);
            double newprice = Convert.ToDouble(ds.Tables[0].Rows[0]["unit_price_impact"].ToString());
            Price = (oldprice + newprice).ToString();
            DiscountPrice = (olddisprice + newprice).ToString();
        }
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        if (HttpContext.Current.Request.Cookies["cartSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
            cartID = user.Values["cartID"].ToString();
            ds = dat.getDataSet("select * from ps_cart where CartStatus = 'Cart' and id_cart = '" + cartID + "'");
            if (ds.Tables[0].Rows.Count == 0)
            {
                gustID = dat.getDataSet("select max(id_guest)+1 as maxid from ps_cart").Tables[0].Rows[0]["maxid"].ToString();
                cartID = "0";
            }
        }
        else
        {
            gustID = dat.getDataSet("select ISNULL(max(id_guest)+1, 1) as maxid from ps_cart").Tables[0].Rows[0]["maxid"].ToString();
        }
        DataTable tbl = new DataTable();

        tbl.Columns.Add("ProdID", typeof(string));
        tbl.Columns.Add("AttributeID", typeof(string));
        tbl.Columns.Add("Attribute", typeof(string));
        tbl.Columns.Add("SKU", typeof(string));
        tbl.Columns.Add("Qty", typeof(Int32));
        tbl.Columns.Add("Price", typeof(decimal));
        tbl.Columns.Add("DisPrice", typeof(decimal));
        tbl.Columns.Add("Amount", typeof(decimal));
        tbl.Columns.Add("TotalAmount", typeof(decimal));
        tbl.Columns.Add("TotalCount", typeof(double));
        tbl.Columns.Add("Image1", typeof(string));
        tbl.Columns.Add("ProdName", typeof(string));
        tbl.Columns.Add("Shipping", typeof(decimal));
        tbl.Columns.Add("NetAmount", typeof(decimal));
        tbl.Columns.Add("GrossAmount", typeof(decimal));
        tbl.Columns.Add("Name", typeof(string));
        tbl.Columns.Add("Flat", typeof(string));
        tbl.Columns.Add("Address", typeof(string));
        tbl.Columns.Add("Locality", typeof(string));
        tbl.Columns.Add("FreeItem", typeof(string));
        tbl.Columns.Add("Pincode", typeof(string));
        tbl.Columns.Add("ShipID", typeof(string));
        tbl.Columns.Add("EmailID", typeof(string));
        tbl.Columns.Add("MobileNo", typeof(string));
        tbl.Columns.Add("DiscountType", typeof(string));
        tbl.Columns.Add("CouponDiscount", typeof(decimal));
        tbl.Columns.Add("DiscountCode", typeof(string));

        if (UserID == "0")
        {

        }
        if (cartID == "0")
        {
            string qqw = "insert into ps_cart(id_shop_group, id_shop, id_carrier, delivery_option, id_lang, id_address_delivery, id_address_invoice, id_currency, id_customer, id_guest, secure_key, recyclable, gift, gift_message, mobile_theme, allow_seperated_package, date_add, date_upd) values(1,1,0,'" + DBNull.Value + "',1,0,0,1," + UserID + "," + gustID + ",'" + DBNull.Value + "',0,0,'" + DBNull.Value + "',0,0,'" + DateTime.Now + "','" + DateTime.Now + "')";
            if (dat.executeCommand(qqw) == 0)
            {
                cartID = dat.getDataSet("select max(id_cart) as maxid from ps_cart").Tables[0].Rows[0]["maxid"].ToString();
                dat.executeCommand("insert into ps_cart_product (id_cart, id_product, id_address_delivery, id_shop, id_product_attribute, quantity, date_add) values(" + cartID + "," + ProdID + ",0,1," + AttriID + "," + Qty + ",'" + DateTime.Now + "')");
                DataRow dtrow = tbl.NewRow();
                dtrow["ProdID"] = ProdID;
                dtrow["AttributeID"] = AttriID;
                dtrow["Qty"] = Convert.ToInt32(Qty);
                dtrow["SKU"] = SKU;
                dtrow["Price"] = string.Format("{0:0.00}", (Price));
                dtrow["DisPrice"] = string.Format("{0:0.00}", (DiscountPrice));
                Amount = Convert.ToDecimal(DiscountPrice) * (Convert.ToDecimal(Qty));
                dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
                dtrow["Image1"] = Image1;
                dtrow["ProdName"] = ProductName;
                tbl.Rows.Add(dtrow);
                HttpCookie carts = new HttpCookie("cartSG");
                carts.Expires = DateTime.Now.AddDays(30d);
                carts.Values.Add("cartID", cartID);
                HttpContext.Current.Response.Cookies.Add(carts);
            }
        }
        else
        {
            DataSet dsn = new DataSet();
            //dsn = dat.getDataSet("select  cp.*,pa.reference,pl.name,pa.price+prod.price as price,'/img/' + RTRIM(LTRIM(REPLACE(cat.name, '/', '-'))) + '/' + cast((select top 1 id_image from ps_image where id_product = cp.id_product ) as nvarchar(50)) + '.jpg' as URL from ps_cart_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category where cp.id_cart = " + cartID + " and pl.id_lang = 1 and cat.id_lang = 1");

            dsn = gdat.GetAddToCartDetail(cartID);
            tbl.Rows.Clear();
            for (int i = 0; i < dsn.Tables[0].Rows.Count; i++)
            {
                DataRow dtrow = tbl.NewRow();
                dtrow["ProdID"] = dsn.Tables[0].Rows[i]["id_product"].ToString();
                dtrow["AttributeID"] = dsn.Tables[0].Rows[i]["id_product_attribute"].ToString();
                dtrow["Qty"] = Convert.ToInt32(dsn.Tables[0].Rows[i]["quantity"].ToString());
                dtrow["SKU"] = dsn.Tables[0].Rows[i]["reference"].ToString();
                dtrow["Price"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
                dtrow["DisPrice"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["DiscountPrice"].ToString()));
                Amount = Convert.ToDecimal(dsn.Tables[0].Rows[i]["DiscountPrice"].ToString()) * (Convert.ToDecimal(dsn.Tables[0].Rows[i]["quantity"].ToString()));
                dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
                dtrow["Image1"] = dsn.Tables[0].Rows[i]["URL"].ToString();
                dtrow["ProdName"] = dsn.Tables[0].Rows[i]["name"].ToString();
                tbl.Rows.Add(dtrow);
            }

            DataRow[] results = tbl.Select("ProdID=" + ProdID.Trim() + " and AttributeID=" + AttriID.Trim() + "");
            if (results.Length == 0)
            {
                results = tbl.Select("ProdID = '" + ProdID.Trim() + "' and AttributeID = '" + AttriID.Trim() + "'");
            }
            if (results.Length > 0)
            {
                bool isBuyQtyUpdate = true;
                #region Check Stock Qty
                DataSet dsqty = new DataSet();
                dsqty = gdata.getProductStockDetail(ProdID, AttriID);
                if (dsqty.Tables[0].Rows.Count > 0)
                {
                    string IsStockAllow = dsqty.Tables[0].Rows[0]["IsStockAllow"].ToString().Trim();
                    string stockQty = dsqty.Tables[0].Rows[0]["stockQty"].ToString().Trim();
                    double sQty = 1;
                    int bQty = Convert.ToInt32(results[0][4]) + Convert.ToInt32(Qty);
                    if (stockQty != "")
                    {
                        sQty = Convert.ToDouble(stockQty);
                    }
                    if (IsStockAllow == "Deny")
                    {
                        if (bQty > sQty)
                        {
                            isBuyQtyUpdate = false;
                            status = "2";
                        }
                    }
                }
                #endregion
                if (isBuyQtyUpdate == true)
                {
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        if (tbl.Rows[i]["ProdID"].ToString() == ProdID && tbl.Rows[i]["AttributeID"].ToString() == AttriID)
                        {
                            tbl.Rows[i]["Qty"] = Convert.ToInt32(tbl.Rows[i]["Qty"]) + Convert.ToInt32(Qty);
                            Amount = Convert.ToDecimal(DiscountPrice) * (Convert.ToInt32(tbl.Rows[i]["Qty"]) + Convert.ToInt32(Qty));
                            tbl.Rows[i]["Amount"] = string.Format("{0:0.00}", (Amount));
                            dat.executeCommand("update ps_cart_product set quantity=" + tbl.Rows[i]["Qty"] + " where id_product_attribute=" + AttriID + " and  id_cart=" + cartID + "");
                        }
                    }
                }
            }
            else
            {
                dat.executeCommand("insert into ps_cart_product (id_cart, id_product, id_address_delivery, id_shop, id_product_attribute, quantity, date_add) values(" + cartID + "," + ProdID + ",0,1," + AttriID + "," + Qty + ",'" + DateTime.Now + "')");
                DataRow dtrow = tbl.NewRow();
                dtrow["ProdID"] = ProdID;
                dtrow["SKU"] = SKU;
                dtrow["AttributeID"] = AttriID;
                // dtrow["Attribute"] = ds.Tables[0].Rows[0]["Weight"].ToString() + " " + ds.Tables[0].Rows[0]["Unit"].ToString();
                dtrow["Qty"] = Convert.ToInt32(Qty);
                dtrow["Price"] = string.Format("{0:0.00}", (Price));
                dtrow["DisPrice"] = string.Format("{0:0.00}", (DiscountPrice));
                Amount = Convert.ToDecimal(DiscountPrice) * (Convert.ToDecimal(Qty));
                dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
                dtrow["Image1"] = Image1;
                dtrow["ProdName"] = ProductName;
                tbl.Rows.Add(dtrow);
            }
        }

        if (tbl.Rows.Count > 0)
        {
            tbl.Rows[0]["TotalAmount"] = string.Format("{0:0.00}", (Convert.ToDecimal(tbl.Compute("SUM(Amount)", "").ToString())));
            tbl.Rows[0]["TotalCount"] = Convert.ToDouble(tbl.Compute("SUM(Qty)", "").ToString());

            tbl.Rows[0]["Shipping"] = "35";
            tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDecimal(tbl.Compute("SUM(Amount)", "")) + 35));


            //if (tbl.Rows[0]["DiscountType"].ToString() != "")
            //{
            //    tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", ((Convert.ToDecimal(tbl.Rows[0]["NetAmount"].ToString())) - (Convert.ToDecimal(tbl.Rows[0]["CouponDiscount"].ToString()))));
            //}
            //else
            //{
            //    tbl.Rows[0]["CouponDiscount"] = "0.00";
            //}
        }
        HttpContext.Current.Session["cartSG"] = tbl;
        return status;
    }

    [WebMethod(EnableSession = true)]
    public string addQtyToCart(string AttriID)
    {
        Data dat = new Data();
        string status = "0";
        decimal Amount = 0;
        string UserID = "0";
        string cartID = "0";

        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        if (HttpContext.Current.Request.Cookies["cartSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
            cartID = user.Values["cartID"].ToString();
        }
        DataTable tbl = new DataTable();

        tbl.Columns.Add("ProdID", typeof(string));
        tbl.Columns.Add("AttributeID", typeof(string));
        tbl.Columns.Add("Attribute", typeof(string));
        tbl.Columns.Add("SKU", typeof(string));
        tbl.Columns.Add("Qty", typeof(Int32));
        tbl.Columns.Add("Price", typeof(decimal));
        tbl.Columns.Add("DisPrice", typeof(decimal));
        tbl.Columns.Add("Amount", typeof(decimal));
        tbl.Columns.Add("TotalAmount", typeof(decimal));
        tbl.Columns.Add("TotalCount", typeof(double));
        tbl.Columns.Add("Image1", typeof(string));
        tbl.Columns.Add("ProdName", typeof(string));
        tbl.Columns.Add("Shipping", typeof(decimal));
        tbl.Columns.Add("NetAmount", typeof(decimal));
        tbl.Columns.Add("GrossAmount", typeof(decimal));
        tbl.Columns.Add("Name", typeof(string));
        tbl.Columns.Add("Flat", typeof(string));
        tbl.Columns.Add("Address", typeof(string));
        tbl.Columns.Add("Locality", typeof(string));
        tbl.Columns.Add("FreeItem", typeof(string));
        tbl.Columns.Add("Pincode", typeof(string));
        tbl.Columns.Add("ShipID", typeof(string));
        tbl.Columns.Add("EmailID", typeof(string));
        tbl.Columns.Add("MobileNo", typeof(string));
        tbl.Columns.Add("DiscountType", typeof(string));
        tbl.Columns.Add("CouponDiscount", typeof(decimal));
        tbl.Columns.Add("DiscountCode", typeof(string));

        DataSet dsQty = data.getDataSet("update ps_cart_product set  quantity=(quantity+1) where  id_cart=" + cartID + " and id_product_attribute=" + AttriID + "");


        DataSet dsn = dat.getDataSet("select  cp.*,pa.reference,pl.name,pa.price+prod.price as price, prod.ImgURL1 as URL from ps_cart_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category where cp.id_cart = " + cartID + " and pl.id_lang = 1 and cat.id_lang = 1");
        tbl.Rows.Clear();
        for (int i = 0; i < dsn.Tables[0].Rows.Count; i++)
        {
            DataRow dtrow = tbl.NewRow();
            dtrow["ProdID"] = dsn.Tables[0].Rows[i]["id_product"].ToString();
            dtrow["AttributeID"] = dsn.Tables[0].Rows[i]["id_product_attribute"].ToString();
            dtrow["Qty"] = Convert.ToInt32(dsn.Tables[0].Rows[i]["quantity"].ToString());
            dtrow["SKU"] = dsn.Tables[0].Rows[i]["reference"].ToString();
            dtrow["Price"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
            dtrow["DisPrice"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
            Amount = Convert.ToDecimal(dsn.Tables[0].Rows[i]["price"].ToString()) * (Convert.ToDecimal(dsn.Tables[0].Rows[i]["quantity"].ToString()));
            dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
            dtrow["Image1"] = dsn.Tables[0].Rows[i]["URL"].ToString();
            dtrow["ProdName"] = dsn.Tables[0].Rows[i]["name"].ToString();
            tbl.Rows.Add(dtrow);
        }

        if (tbl.Rows.Count > 0)
        {
            tbl.Rows[0]["TotalAmount"] = string.Format("{0:0.00}", (Convert.ToDecimal(tbl.Compute("SUM(Amount)", "").ToString())));
            tbl.Rows[0]["TotalCount"] = Convert.ToDouble(tbl.Compute("SUM(Qty)", "").ToString());

            tbl.Rows[0]["Shipping"] = "35";
            tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDecimal(tbl.Compute("SUM(Amount)", "")) + 35));


            //if (tbl.Rows[0]["DiscountType"].ToString() != "")
            //{
            //    tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", ((Convert.ToDecimal(tbl.Rows[0]["NetAmount"].ToString())) - (Convert.ToDecimal(tbl.Rows[0]["CouponDiscount"].ToString()))));
            //}
            //else
            //{
            //    tbl.Rows[0]["CouponDiscount"] = "0.00";
            //}
        }
        HttpContext.Current.Session["cartSG"] = tbl;
        return status;
    }


    //function create on 08/12/2020
    [WebMethod(EnableSession = true)]
    public string addQtyToCartonChange(string AttriID, string qty)
    {
        string status = "0";
        if (qty != "" && qty != null && qty != "0" && qty != "undefined")
        {
            Data dat = new Data();
            decimal Amount = 0;
            string UserID = "0";
            string cartID = "0";

            if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
            {
                HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
                UserID = user.Values["id_customer"].ToString();
            }
            if (HttpContext.Current.Request.Cookies["cartSG"] != null)
            {
                HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
                cartID = user.Values["cartID"].ToString();
            }
            DataTable tbl = new DataTable();

            tbl.Columns.Add("ProdID", typeof(string));
            tbl.Columns.Add("AttributeID", typeof(string));
            tbl.Columns.Add("Attribute", typeof(string));
            tbl.Columns.Add("SKU", typeof(string));
            tbl.Columns.Add("Qty", typeof(Int32));
            tbl.Columns.Add("Price", typeof(decimal));
            tbl.Columns.Add("DisPrice", typeof(decimal));
            tbl.Columns.Add("Amount", typeof(decimal));
            tbl.Columns.Add("TotalAmount", typeof(decimal));
            tbl.Columns.Add("TotalCount", typeof(double));
            tbl.Columns.Add("Image1", typeof(string));
            tbl.Columns.Add("ProdName", typeof(string));
            tbl.Columns.Add("Shipping", typeof(decimal));
            tbl.Columns.Add("NetAmount", typeof(decimal));
            tbl.Columns.Add("GrossAmount", typeof(decimal));
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Flat", typeof(string));
            tbl.Columns.Add("Address", typeof(string));
            tbl.Columns.Add("Locality", typeof(string));
            tbl.Columns.Add("FreeItem", typeof(string));
            tbl.Columns.Add("Pincode", typeof(string));
            tbl.Columns.Add("ShipID", typeof(string));
            tbl.Columns.Add("EmailID", typeof(string));
            tbl.Columns.Add("MobileNo", typeof(string));
            tbl.Columns.Add("DiscountType", typeof(string));
            tbl.Columns.Add("CouponDiscount", typeof(decimal));
            tbl.Columns.Add("DiscountCode", typeof(string));

            //DataSet dsQty = data.getDataSet("update ps_cart_product set  quantity=(quantity+1) where  id_cart=" + cartID + " and id_product_attribute=" + AttriID + "");

            DataSet dsQty = data.getDataSet("update ps_cart_product set  quantity=" + qty + " where  id_cart=" + cartID + " and id_product_attribute=" + AttriID + "");


            DataSet dsn = dat.getDataSet("select  cp.*,pa.reference,pl.name,pa.price+prod.price as price,prod.ImgURL1 as URL from ps_cart_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category where cp.id_cart = " + cartID + " and pl.id_lang = 1 and cat.id_lang = 1");
            tbl.Rows.Clear();
            for (int i = 0; i < dsn.Tables[0].Rows.Count; i++)
            {
                DataRow dtrow = tbl.NewRow();
                dtrow["ProdID"] = dsn.Tables[0].Rows[i]["id_product"].ToString();
                dtrow["AttributeID"] = dsn.Tables[0].Rows[i]["id_product_attribute"].ToString();
                dtrow["Qty"] = Convert.ToInt32(dsn.Tables[0].Rows[i]["quantity"].ToString());
                dtrow["SKU"] = dsn.Tables[0].Rows[i]["reference"].ToString();
                dtrow["Price"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
                dtrow["DisPrice"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
                Amount = Convert.ToDecimal(dsn.Tables[0].Rows[i]["price"].ToString()) * (Convert.ToDecimal(dsn.Tables[0].Rows[i]["quantity"].ToString()));
                dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
                dtrow["Image1"] = dsn.Tables[0].Rows[i]["URL"].ToString();
                dtrow["ProdName"] = dsn.Tables[0].Rows[i]["name"].ToString();
                tbl.Rows.Add(dtrow);
            }

            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["TotalAmount"] = string.Format("{0:0.00}", (Convert.ToDecimal(tbl.Compute("SUM(Amount)", "").ToString())));
                tbl.Rows[0]["TotalCount"] = Convert.ToDouble(tbl.Compute("SUM(Qty)", "").ToString());

                tbl.Rows[0]["Shipping"] = "35";
                tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDecimal(tbl.Compute("SUM(Amount)", "")) + 35));


                //if (tbl.Rows[0]["DiscountType"].ToString() != "")
                //{
                //    tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", ((Convert.ToDecimal(tbl.Rows[0]["NetAmount"].ToString())) - (Convert.ToDecimal(tbl.Rows[0]["CouponDiscount"].ToString()))));
                //}
                //else
                //{
                //    tbl.Rows[0]["CouponDiscount"] = "0.00";
                //}
            }
            HttpContext.Current.Session["cartSG"] = tbl;
        }
        return status;
    }


    [WebMethod(EnableSession = true)]
    public string removeQtyToCart(string AttriID)
    {
        Data dat = new Data();
        string status = "0";
        decimal Amount = 0;
        string UserID = "0";
        string cartID = "0";

        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        if (HttpContext.Current.Request.Cookies["cartSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
            cartID = user.Values["cartID"].ToString();
        }
        DataTable tbl = new DataTable();

        tbl.Columns.Add("ProdID", typeof(string));
        tbl.Columns.Add("AttributeID", typeof(string));
        tbl.Columns.Add("Attribute", typeof(string));
        tbl.Columns.Add("SKU", typeof(string));
        tbl.Columns.Add("Qty", typeof(Int32));
        tbl.Columns.Add("Price", typeof(decimal));
        tbl.Columns.Add("DisPrice", typeof(decimal));
        tbl.Columns.Add("Amount", typeof(decimal));
        tbl.Columns.Add("TotalAmount", typeof(decimal));
        tbl.Columns.Add("TotalCount", typeof(double));
        tbl.Columns.Add("Image1", typeof(string));
        tbl.Columns.Add("ProdName", typeof(string));
        tbl.Columns.Add("Shipping", typeof(decimal));
        tbl.Columns.Add("NetAmount", typeof(decimal));
        tbl.Columns.Add("GrossAmount", typeof(decimal));
        tbl.Columns.Add("Name", typeof(string));
        tbl.Columns.Add("Flat", typeof(string));
        tbl.Columns.Add("Address", typeof(string));
        tbl.Columns.Add("Locality", typeof(string));
        tbl.Columns.Add("FreeItem", typeof(string));
        tbl.Columns.Add("Pincode", typeof(string));
        tbl.Columns.Add("ShipID", typeof(string));
        tbl.Columns.Add("EmailID", typeof(string));
        tbl.Columns.Add("MobileNo", typeof(string));
        tbl.Columns.Add("DiscountType", typeof(string));
        tbl.Columns.Add("CouponDiscount", typeof(decimal));
        tbl.Columns.Add("DiscountCode", typeof(string));

        DataSet dsQty = data.getDataSet("update ps_cart_product set  quantity=(quantity-1) where  id_cart=" + cartID + " and id_product_attribute=" + AttriID + "");


        DataSet dsn = dat.getDataSet("select  cp.*,pa.reference,pl.name,pa.price+prod.price as price, prod.ImgURL1 as URL from ps_cart_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category where cp.id_cart = " + cartID + " and pl.id_lang = 1 and cat.id_lang = 1");
        tbl.Rows.Clear();
        for (int i = 0; i < dsn.Tables[0].Rows.Count; i++)
        {
            DataRow dtrow = tbl.NewRow();
            dtrow["ProdID"] = dsn.Tables[0].Rows[i]["id_product"].ToString();
            dtrow["AttributeID"] = dsn.Tables[0].Rows[i]["id_product_attribute"].ToString();
            dtrow["Qty"] = Convert.ToInt32(dsn.Tables[0].Rows[i]["quantity"].ToString());
            dtrow["SKU"] = dsn.Tables[0].Rows[i]["reference"].ToString();
            dtrow["Price"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
            dtrow["DisPrice"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
            Amount = Convert.ToDecimal(dsn.Tables[0].Rows[i]["price"].ToString()) * (Convert.ToDecimal(dsn.Tables[0].Rows[i]["quantity"].ToString()));
            dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
            dtrow["Image1"] = dsn.Tables[0].Rows[i]["URL"].ToString();
            dtrow["ProdName"] = dsn.Tables[0].Rows[i]["name"].ToString();
            tbl.Rows.Add(dtrow);
        }

        if (tbl.Rows.Count > 0)
        {
            tbl.Rows[0]["TotalAmount"] = string.Format("{0:0.00}", (Convert.ToDecimal(tbl.Compute("SUM(Amount)", "").ToString())));
            tbl.Rows[0]["TotalCount"] = Convert.ToDouble(tbl.Compute("SUM(Qty)", "").ToString());

            tbl.Rows[0]["Shipping"] = "35";
            tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDecimal(tbl.Compute("SUM(Amount)", "")) + 35));


            //if (tbl.Rows[0]["DiscountType"].ToString() != "")
            //{
            //    tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", ((Convert.ToDecimal(tbl.Rows[0]["NetAmount"].ToString())) - (Convert.ToDecimal(tbl.Rows[0]["CouponDiscount"].ToString()))));
            //}
            //else
            //{
            //    tbl.Rows[0]["CouponDiscount"] = "0.00";
            //}
        }
        HttpContext.Current.Session["cartSG"] = tbl;
        return status;
    }

    [WebMethod(EnableSession = true)]
    public string GetVoucher(string code)
    {
        Data dat = new Data();
        string status = "";
        string cartID = "0";
        if (HttpContext.Current.Request.Cookies["cartSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
            cartID = user.Values["cartID"].ToString();
        }
        DataSet ds = dat.getDataSet("select id_customer, gift from ps_cart where id_cart=" + cartID + "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataSet ds1 = new DataSet();
            string CustId = ds.Tables[0].Rows[0]["id_customer"].ToString();
            if (ds.Tables[0].Rows[0]["gift"].ToString() == "0")
            {
                ds = data.getDataSet("select * from ps_cart_rule where id_customer = 0 and IsDeleted = 0 and code='" + code + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string giftid = ds.Tables[0].Rows[0]["id_cart_rule"].ToString();
                    string quantity = ds.Tables[0].Rows[0]["quantity"].ToString();
                    string quantity_per_user = ds.Tables[0].Rows[0]["quantity_per_user"].ToString();
                    string totusecount = data.getDataSet("select count(*) as totcount From ps_orders where gift = '" + giftid + "' and id_customer = '" + CustId + "'").Tables[0].Rows[0]["totcount"].ToString();
                    if (Convert.ToInt32(quantity_per_user) > Convert.ToInt32(totusecount))
                    {
                        dat.executeCommand("update ps_cart set gift=" + ds.Tables[0].Rows[0]["id_cart_rule"].ToString() + " where id_cart=" + cartID + "");
                        status = "You have added successfully voucher";
                    }
                    else
                    {
                        status = "You have already use this voucher";
                    }

                }
                else
                {
                    ds = data.getDataSet("select * from ps_cart_rule where IsDeleted = 0 and code='" + code + "' and id_customer='" + CustId + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string giftid = ds.Tables[0].Rows[0]["id_cart_rule"].ToString();
                        string quantity = ds.Tables[0].Rows[0]["quantity"].ToString();
                        string quantity_per_user = ds.Tables[0].Rows[0]["quantity_per_user"].ToString();
                        string totusecount = data.getDataSet("select count(*) as totcount From ps_orders where gift = '" + giftid + "' and id_customer = '" + CustId + "'").Tables[0].Rows[0]["totcount"].ToString();
                        if (Convert.ToInt32(quantity_per_user) > Convert.ToInt32(totusecount))
                        {
                            dat.executeCommand("update ps_cart set gift=" + ds.Tables[0].Rows[0]["id_cart_rule"].ToString() + " where id_cart=" + cartID + "");
                            status = "You have added successfully voucher";
                        }
                        else
                        {
                            status = "You have already use this voucher";
                        }
                    }
                    else
                    {
                        status = "Please Enter Valid Voucher";
                    }
                }
            }
            else
                status = "You have already voucher used";
        }
        return status;
    }

    [WebMethod(EnableSession = true)]
    public string removeVoucherDtl()
    {
        Data dat = new Data();
        string status = "";
        string cartID = "0";
        if (HttpContext.Current.Request.Cookies["cartSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
            cartID = user.Values["cartID"].ToString();
        }
        DataSet ds = dat.getDataSet("select gift from ps_cart where id_cart=" + cartID + "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                dat.executeCommand("update ps_cart set gift=0 where id_cart=" + cartID + "");
                status = "Voucher code removed successfully.";
            }
        }
        return status;
    }


    [WebMethod(EnableSession = true)]
    public string getCart()
    {
        string qqq = "";
        string cartID = "0";
        decimal Amount = 0;
        string UserID = "0";
        string shipamount = "0.00";
        string cust_msg = "";
        Data dat = new Data();
        DataTable tbl = new DataTable();

        tbl.Columns.Add("ProdID", typeof(string));
        tbl.Columns.Add("AttributeID", typeof(string));
        tbl.Columns.Add("Attribute", typeof(string));
        tbl.Columns.Add("SKU", typeof(string));
        tbl.Columns.Add("Qty", typeof(Int32));
        tbl.Columns.Add("Price", typeof(decimal));
        tbl.Columns.Add("DisPrice", typeof(decimal));
        tbl.Columns.Add("Amount", typeof(decimal));
        tbl.Columns.Add("TotalAmount", typeof(decimal));
        tbl.Columns.Add("TotalCount", typeof(double));
        tbl.Columns.Add("Image1", typeof(string));
        tbl.Columns.Add("ProdName", typeof(string));
        tbl.Columns.Add("Shipping", typeof(decimal));
        tbl.Columns.Add("NetAmount", typeof(decimal));
        tbl.Columns.Add("GrossAmount", typeof(decimal));
        tbl.Columns.Add("Name", typeof(string));
        tbl.Columns.Add("Flat", typeof(string));
        tbl.Columns.Add("Address", typeof(string));
        tbl.Columns.Add("Locality", typeof(string));
        tbl.Columns.Add("FreeItem", typeof(string));
        tbl.Columns.Add("Pincode", typeof(string));
        tbl.Columns.Add("ShipID", typeof(string));
        tbl.Columns.Add("EmailID", typeof(string));
        tbl.Columns.Add("MobileNo", typeof(string));
        tbl.Columns.Add("DiscountType", typeof(string));
        tbl.Columns.Add("CouponDiscount", typeof(decimal));
        tbl.Columns.Add("DiscountCode", typeof(string));
        tbl.Columns.Add("minimal_quantity", typeof(string));
        tbl.Columns.Add("DetailUrl", typeof(string));
        tbl.Columns.Add("Availability", typeof(string));
        tbl.Columns.Add("StockStatus", typeof(string));
        tbl.Columns.Add("cust_msg", typeof(string));

        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        if (HttpContext.Current.Request.Cookies["cartSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
            cartID = user.Values["cartID"].ToString();
            if (UserID != "" && UserID != "0")
            {
                try
                {
                    ds = dat.getDataSet("select * from ps_cart where CartStatus = 'Cart' and id_cart = '" + cartID + "'");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        DataSet ds4 = new DataSet();
                        ds4 = dat.getDataSet("select MAX(id_cart) as CartId from ps_cart where CartStatus = 'Cart' and id_customer = '" + UserID + "'");
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            cartID = ds4.Tables[0].Rows[0]["CartId"].ToString();
                            HttpCookie carts = new HttpCookie("cartSG");
                            carts.Expires = DateTime.Now.AddDays(30d);
                            carts.Values.Add("cartID", cartID);
                            HttpContext.Current.Response.Cookies.Add(carts);
                        }
                    }
                }
                catch
                {

                }

                DataSet ds7 = new DataSet();
                ds7 = data.getDataSet("Select * from ps_cart where id_cart = " + cartID + " and id_customer = '" + UserID + "'");
                if (ds7.Tables[0].Rows.Count > 0)
                {
                    cust_msg = ds7.Tables[0].Rows[0]["cust_msg"].ToString();
                    qqq = " Update ps_cart_product set IsConfirm = 1  where id_cart = '" + cartID + "' ";
                    data.executeCommand(qqq);
                    DataSet ds6 = new DataSet();
                    qqq = " Select top(4) id_cart from ps_cart where CartStatus = 'Cart' and  id_cart != " + cartID + " and  id_customer = '" + UserID + "' order by id_cart desc";
                    ds6 = data.getDataSet(qqq);
                    if (ds6.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds6.Tables[0].Rows.Count; j++)
                        {
                            qqq = " Update ps_cart_product set id_cart = '" + cartID + "' where id_cart = '" + ds6.Tables[0].Rows[j]["id_cart"].ToString() + "' ";
                            data.executeCommand(qqq);
                            //if (data.executeCommand(qqq) == 0)
                            //{
                            //    string delcart = ds6.Tables[0].Rows[0]["id_cart"].ToString();
                            //    qqq = " delete from ps_cart where id_cart = '" + ds6.Tables[0].Rows[j]["id_cart"].ToString() + "' ";
                            //    //data.executeCommand(qqq);
                            //}
                        }
                    }
                }
                else
                {
                    qqq = " Update ps_cart set id_customer = '" + UserID + "' where id_cart = " + cartID + "";
                    if (data.executeCommand(qqq) == 0)
                    {
                        qqq = " Update ps_cart_product set IsConfirm = 1  where id_cart = '" + cartID + "' ";
                        data.executeCommand(qqq);
                        DataSet ds6 = new DataSet();
                        qqq = " Select top(4) id_cart from ps_cart where  CartStatus = 'Cart' and  id_cart != " + cartID + " and  id_customer = '" + UserID + "'  order by id_cart desc";
                        ds6 = data.getDataSet(qqq);
                        if (ds6.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds6.Tables[0].Rows.Count; j++)
                            {
                                qqq = " Update ps_cart_product set id_cart = '" + cartID + "' where id_cart = '" + ds6.Tables[0].Rows[j]["id_cart"].ToString() + "' ";
                                data.executeCommand(qqq);
                                //if (data.executeCommand(qqq) == 0)
                                //{
                                //    string delcart = ds6.Tables[0].Rows[0]["id_cart"].ToString();
                                //    qqq = " delete from ps_cart where id_cart = '" + ds6.Tables[0].Rows[j]["id_cart"].ToString() + "' ";
                                //    //data.executeCommand(qqq);
                                //}
                            }
                        }
                    }
                }
                if (UserID != "" && UserID != "0" && cartID != "")
                {
                    string qDelete = "";
                    string qUpdate = "";
                    DataSet ds8 = new DataSet();
                    DataSet dsqty = new DataSet();
                    #region Delete Duplicate Entry From Cart
                    ds8 = gdat.GetDuplicateEntryFromCart(cartID, UserID);
                    if (ds8.Tables[0].Rows.Count > 0)
                    {
                        for (int s = 0; s < ds8.Tables[0].Rows.Count; s++)
                        {
                            string ProdID = ds8.Tables[0].Rows[s]["id_product"].ToString();
                            string PAttID = ds8.Tables[0].Rows[s]["id_product_attribute"].ToString();
                            int bQty = Convert.ToInt32(ds8.Tables[0].Rows[s]["qty"].ToString());
                            #region Check Stock Qty 
                            dsqty = gdata.getDetail(ProdID);
                            if (dsqty.Tables[0].Rows.Count > 0)
                            {
                                string IsStockAllow = dsqty.Tables[0].Rows[0]["IsStockAllow"].ToString().Trim();
                                string stockQty = dsqty.Tables[0].Rows[0]["stockQty"].ToString().Trim();
                                double sQty = 1;
                                if (stockQty != "")
                                {
                                    sQty = Convert.ToDouble(stockQty);
                                }
                                qDelete = "DELETE TOP(1) FROM ps_cart_product WHERE id_cart = '" + cartID + "' and id_product = '" + ProdID + "' and id_product_attribute = '" + PAttID + "' ";
                                data.executeCommand(qDelete);
                                if (IsStockAllow == "Deny")
                                {
                                    if (bQty > sQty)
                                    {

                                    }
                                    else
                                    {
                                        qUpdate = " Update ps_cart_product set quantity = '" + bQty + "'WHERE id_cart = '" + cartID + "' and id_product = '" + ProdID + "' and id_product_attribute = '" + PAttID + "' ";
                                        data.executeCommand(qUpdate);
                                    }
                                }
                                else
                                {
                                    qUpdate = " Update ps_cart_product set quantity = '" + bQty + "'WHERE id_cart = '" + cartID + "' and id_product = '" + ProdID + "' and id_product_attribute = '" + PAttID + "' ";
                                    data.executeCommand(qUpdate);
                                }
                            }
                            #endregion
                        }

                    }
                    #endregion

                    #region Get Product Availability status
                    DataSet dsc = new DataSet();
                    dsc = data.getDataSet(" select * From ps_cart_product where id_cart = '" + cartID + "' ");
                    if (dsc.Tables[0].Rows.Count > 0)
                    {
                        qUpdate = " Update ps_cart_product set Availability = '' WHERE id_cart = '" + cartID + "'";
                        data.executeCommand(qUpdate);
                        for (int s = 0; s < dsc.Tables[0].Rows.Count; s++)
                        {
                            string ProdID = dsc.Tables[0].Rows[s]["id_product"].ToString();
                            string PAttID = dsc.Tables[0].Rows[s]["id_product_attribute"].ToString();
                            int bQty = Convert.ToInt32(dsc.Tables[0].Rows[s]["quantity"].ToString());
                            dsqty = gdata.getDetail(ProdID);
                            if (dsqty.Tables[0].Rows.Count > 0)
                            {
                                string IsStockAllow = dsqty.Tables[0].Rows[0]["IsStockAllow"].ToString().Trim();
                                string stockQty = dsqty.Tables[0].Rows[0]["stockQty"].ToString().Trim();
                                string minqty = dsqty.Tables[0].Rows[0]["minimal_quantity"].ToString().Trim();
                                double sQty = 0;
                                if (stockQty != "")
                                {
                                    sQty = Convert.ToDouble(stockQty);
                                }
                                double minimumQty = 0;
                                if (minqty != "")
                                {
                                    minimumQty = Convert.ToDouble(minqty);
                                }
                                string availstatus = "";
                                if (IsStockAllow == "Deny")
                                {
                                    if (bQty > sQty)
                                    {
                                        if (sQty != 0 && sQty > 0)
                                        {
                                            if (minimumQty > sQty)
                                            {
                                                availstatus = "Out of stock";
                                                qUpdate = " Update ps_cart_product set Availability = '" + availstatus + "'WHERE id_cart = '" + cartID + "' and id_product = '" + ProdID + "' and id_product_attribute = '" + PAttID + "' ";
                                                data.executeCommand(qUpdate);
                                            }
                                            else
                                            {
                                                availstatus = "Only " + sQty + " quantity available in stock";
                                                qUpdate = " Update ps_cart_product set Availability = '" + availstatus + "'WHERE id_cart = '" + cartID + "' and id_product = '" + ProdID + "' and id_product_attribute = '" + PAttID + "' ";
                                                data.executeCommand(qUpdate);
                                            }
                                        }
                                        else
                                        {
                                            availstatus = "Out of stock";
                                            qUpdate = " Update ps_cart_product set Availability = '" + availstatus + "'WHERE id_cart = '" + cartID + "' and id_product = '" + ProdID + "' and id_product_attribute = '" + PAttID + "' ";
                                            data.executeCommand(qUpdate);
                                        }
                                    }
                                    else
                                    {
                                        if (minimumQty > sQty)
                                        {
                                            availstatus = "Out of stock";
                                            qUpdate = " Update ps_cart_product set Availability = '" + availstatus + "'WHERE id_cart = '" + cartID + "' and id_product = '" + ProdID + "' and id_product_attribute = '" + PAttID + "' ";
                                            data.executeCommand(qUpdate);
                                        }
                                        else
                                        {
                                            if (minimumQty > bQty)
                                            {
                                                availstatus = "Minimun order quantity is " + minqty + ".";
                                                qUpdate = " Update ps_cart_product set Availability = '" + availstatus + "'WHERE id_cart = '" + cartID + "' and id_product = '" + ProdID + "' and id_product_attribute = '" + PAttID + "' ";
                                                data.executeCommand(qUpdate);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        qqq = "select  cp.*,pa.reference,pl.name,pa.price+prod.price as price,";

        //qqq += "'/img/'+RTRIM(LTRIM(REPLACE(cat.name,'/','-')))+'/'+ cast((select top 1 id_image from ps_image where IsDeleted = 0 and Cover = 1 and id_product = cp.id_product) as nvarchar(50)) +'.jpg' as URL,";
        qqq += " prod.ImgURL1  +'?tr=w-100%2Ch-100' as URL, ";
        qqq += " pa.minimal_quantity, cart.gift, ";

        qqq += " REPLACE(REPLACE(cat.link_rewrite,' ','-'),'/-','')+'/'+cast(prod.id_product as nvarchar(50))+'-'+  + ISNULL(REPLACE(pl.link_rewrite, ' ', '-'), '') + '.html' as DetailUrl,";
        //calculate discountprice
        qqq += "  cast(cast((cast(prod.price as decimal(18,2))- (case when (select top(1) isnull(reduction,0)  ";
        qqq += " from ps_specific_price  as  sp where  sp.IsDeleted = 0 and id_product=prod.id_product) is null then 0 else  ";
        qqq += " (((select top(1) isnull(sp.reduction,0) from ps_specific_price as  sp where  sp.IsDeleted = 0 and ";
        qqq += " sp.id_product=prod.id_product))*cast(prod.price as decimal(18,2))) end) / 100) as decimal(18,2)) + pa.price as decimal(18,2))   as DiscountPrice ";
        qqq += " , cart.id_address_delivery as AddId ";

        qqq += " from ps_cart_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category inner join ps_cart cart on cp.id_cart=cart.id_cart ";
        qqq += " where  pl.id_lang = 1 and cat.id_lang = 1 ";
        if (cartID != "0")
        {
            qqq += " and cp.id_cart = " + cartID + "";
        }
        if (UserID != "" && UserID != "0")
        {
            if (cartID == "0")
            {
                DataSet ds6 = new DataSet();
                string q6 = " ";
                q6 = " Select top(1) id_cart from ps_cart where CartStatus = 'Cart' and id_customer = '" + UserID + "' order by id_cart desc";
                ds6 = data.getDataSet(q6);
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    cartID = ds6.Tables[0].Rows[0]["id_cart"].ToString();
                    HttpCookie carts = new HttpCookie("cartSG");
                    carts.Expires = DateTime.Now.AddDays(30d);
                    carts.Values.Add("cartID", cartID);
                    HttpContext.Current.Response.Cookies.Add(carts);
                }
                qqq += " and cp.id_cart = " + cartID + "";
            }
            qqq += " and cart.id_customer = '" + UserID + "'";
        }
        else
        {
            if (cartID != "0")
            {
                qqq += " and cp.IsConfirm = 0 ";
            }
            else
            {
                qqq += "  and cart.id_cart = 0 ";
            }
        }

        DataSet dsn = dat.getDataSet(qqq);
        if (dsn.Tables[0].Rows.Count > 0)
        {
            //calculate shipping amount
            if (UserID != "" && UserID != "0")
            {
                if (dsn.Tables[0].Rows[0]["AddId"].ToString() != "" && dsn.Tables[0].Rows[0]["AddId"].ToString() != null && dsn.Tables[0].Rows[0]["AddId"].ToString() != "0")
                {
                    string addidd = dsn.Tables[0].Rows[0]["AddId"].ToString();
                    try
                    {
                        dsSA = gdat.GetShipingAmt(UserID, addidd);
                        if (dsSA.Tables[0].Rows.Count > 0)
                        {
                            string Ship_Amt = dsSA.Tables[0].Rows[0]["Ship_Amt"].ToString();
                            string MinShipAMt = dsSA.Tables[0].Rows[0]["MinShip_Amt"].ToString();
                            if (Ship_Amt != "" || Ship_Amt != "0")
                            {
                                shipamount = Ship_Amt;
                            }

                            if (MinShipAMt != "" || MinShipAMt != "0")
                            {
                                FreeShippingAmt = Convert.ToDouble(MinShipAMt);
                            }
                        }
                        //shipamount = data.getDataSet("select zon.Ship_Amt, zon.MinShip_Amt from ps_address ad inner join ps_country con on ad.id_country=con.id_country inner join ps_zone zon on con.id_zone=zon.id_zone where zon.active = 1 and  id_customer=" + UserID + " and ad.id_address=" + addidd + "").Tables[0].Rows[0]["Ship_Amt"].ToString();
                    }
                    catch
                    {
                        shipamount = "100";
                    }
                }
            }
        }

        //if (dsn.Tables[0].Rows.Count > 0)
        //{
        //}
        //else
        //{
        //    DataSet ds6 = new DataSet();
        //    string q6 = " ";
        //    q6 = " Select top(1) id_cart from ps_cart where CartStatus = 'Cart' and id_customer = '" + UserID + "' order by id_cart desc";
        //    ds6 = data.getDataSet(q6);
        //    if (ds6.Tables[0].Rows.Count > 0)
        //    {
        //        cartID = ds6.Tables[0].Rows[0]["id_cart"].ToString();
        //        HttpCookie carts = new HttpCookie("cartSG");
        //        carts.Expires = DateTime.Now.AddDays(30d);
        //        carts.Values.Add("cartID", cartID);
        //        HttpContext.Current.Response.Cookies.Add(carts);
        //    }
        //}
        bool stockstatus = false;
        tbl.Rows.Clear();
        for (int i = 0; i < dsn.Tables[0].Rows.Count; i++)
        {
            //price repleace to DiscountPrice on 01/12/2020
            DataRow dtrow = tbl.NewRow();
            dtrow["ProdID"] = dsn.Tables[0].Rows[i]["id_product"].ToString();
            dtrow["AttributeID"] = dsn.Tables[0].Rows[i]["id_product_attribute"].ToString();
            dtrow["Qty"] = Convert.ToInt32(dsn.Tables[0].Rows[i]["quantity"].ToString());
            dtrow["SKU"] = dsn.Tables[0].Rows[i]["reference"].ToString();
            dtrow["Price"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
            dtrow["DisPrice"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["DiscountPrice"].ToString()));
            Amount = Convert.ToDecimal(dsn.Tables[0].Rows[i]["DiscountPrice"].ToString()) * (Convert.ToDecimal(dsn.Tables[0].Rows[i]["quantity"].ToString()));
            dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
            dtrow["Image1"] = dsn.Tables[0].Rows[i]["URL"].ToString();
            dtrow["ProdName"] = dsn.Tables[0].Rows[i]["name"].ToString();
            dtrow["minimal_quantity"] = dsn.Tables[0].Rows[i]["minimal_quantity"].ToString();
            dtrow["DetailUrl"] = dsn.Tables[0].Rows[i]["DetailUrl"].ToString();
            dtrow["Shipping"] = shipamount;
            dtrow["Availability"] = dsn.Tables[0].Rows[i]["Availability"].ToString();
            dtrow["cust_msg"] = dsn.Tables[0].Rows[i]["CustomizeImg"].ToString();
            if (dsn.Tables[0].Rows[i]["Availability"].ToString() != "" && dsn.Tables[0].Rows[i]["Availability"].ToString() != null)
            {
                stockstatus = true;
            }
            DataSet dsA = data.getDataSet("select distinct ag.position, agl.name as groupname, alm.name as attributename from ps_product prod  inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute  inner join ps_attribute_lang alm on pac.id_attribute=alm.id_attribute inner join ps_attribute at on alm.id_attribute=at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group=agl.id_attribute_group inner join ps_attribute_group ag on agl.id_attribute_group=ag.id_attribute_group where prod.id_product = " + dsn.Tables[0].Rows[i]["id_product"].ToString() + " and pa.id_product_attribute = " + dsn.Tables[0].Rows[i]["id_product_attribute"].ToString() + "  and prod.active = 1 and alm.id_lang = 1 and agl.id_lang = 1 order by ag.position");
            if (dsA.Tables[0].Rows.Count > 0)
            {
                string att = "";
                for (int j = 0; j < dsA.Tables[0].Rows.Count; j++)
                {
                    if (j == 0)
                        att = dsA.Tables[0].Rows[j]["groupname"].ToString() + " : " + dsA.Tables[0].Rows[j]["attributename"].ToString();
                    else
                        att += ", " + dsA.Tables[0].Rows[j]["groupname"].ToString() + " : " + dsA.Tables[0].Rows[j]["attributename"].ToString();
                }
                dtrow["Attribute"] = att;
            }
            tbl.Rows.Add(dtrow);
        }

        if (tbl.Rows.Count > 0)
        { 
            //tbl.Rows[0]["cust_msg"] = cust_msg;
            double netAmount = 0;
            double TttolAmt = Convert.ToDouble(tbl.Compute("SUM(Amount)", "").ToString());
            tbl.Rows[0]["TotalAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", "").ToString())));
            tbl.Rows[0]["TotalCount"] = Convert.ToDouble(tbl.Compute("SUM(Qty)", "").ToString());
            if (TttolAmt > FreeShippingAmt)
            {
                tbl.Rows[0]["Shipping"] = 0;
                netAmount = Convert.ToDouble(tbl.Compute("SUM(Amount)", ""));
            }
            else
            {
                tbl.Rows[0]["Shipping"] = shipamount;
                netAmount = Convert.ToDouble(tbl.Compute("SUM(Amount)", "")) + Convert.ToDouble(shipamount);
            }

            tbl.Rows[0]["CouponDiscount"] = "0.00";
            if (stockstatus == true)
            {
                tbl.Rows[0]["StockStatus"] = "outofstock";
            }

            double TotAmttt = Convert.ToDouble(tbl.Compute("SUM(Amount)", ""));


            if (dsn.Tables[0].Rows[0]["gift"].ToString() != "0")
            {
                double discountedAmt = 0;
                double discount = 0;
                DataSet dsDis = new DataSet();
                dsDis = dat.getDataSet("select reduction_percent, reduction_amount, code, minimum_amount_shipping from ps_cart_rule where id_cart_rule=" + dsn.Tables[0].Rows[0]["gift"].ToString() + "");
                string discountPer = dsDis.Tables[0].Rows[0]["reduction_percent"].ToString();
                string disAmt = dsDis.Tables[0].Rows[0]["reduction_amount"].ToString();
                string shipExInclu = dsDis.Tables[0].Rows[0]["minimum_amount_shipping"].ToString();
                if (shipExInclu == "0")
                {
                    discountedAmt = TotAmttt;
                }
                else
                {
                    discountedAmt = TotAmttt + Convert.ToDouble(shipamount);
                }
                if (discountPer != "0.00")
                {
                    discount = (discountedAmt * Convert.ToDouble(discountPer)) / 100;
                }
                else
                {
                    if (disAmt != "0.00")
                    {
                        discount = Convert.ToDouble(disAmt);
                    }
                }
                tbl.Rows[0]["DiscountCode"] = dsDis.Tables[0].Rows[0]["code"].ToString();
                tbl.Rows[0]["CouponDiscount"] = discount;
                netAmount = netAmount - discount;
            }
            tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(netAmount)));
            Session["TotalProdAmt"] = string.Format("{0:0.00}", (Convert.ToDouble(netAmount)));
        }

        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(tbl);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string addAddressCart(string shippingAddId, string billingAddId)
    {
        string cartID = "0";
        Data dat = new Data();
        if (HttpContext.Current.Request.Cookies["cartSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
            cartID = user.Values["cartID"].ToString();
        }

        dat.executeCommand("update ps_cart set id_address_delivery=" + shippingAddId + ", id_address_invoice=" + billingAddId + " where id_cart=" + cartID + "");
        return cartID;
    }

    [WebMethod(EnableSession = true)]
    public string removeCart(string AttriID)
    {
        Data dat = new Data();
        string status = "0";
        string cartID = "0";
        DataSet ds = new DataSet();
        DataTable tbl = new DataTable();


        tbl.Columns.Add("ProdID", typeof(string));
        tbl.Columns.Add("AttributeID", typeof(string));
        tbl.Columns.Add("Attribute", typeof(string));
        tbl.Columns.Add("SKU", typeof(string));
        tbl.Columns.Add("Qty", typeof(Int32));
        tbl.Columns.Add("Price", typeof(decimal));
        tbl.Columns.Add("DisPrice", typeof(decimal));
        tbl.Columns.Add("Amount", typeof(decimal));
        tbl.Columns.Add("TotalAmount", typeof(decimal));
        tbl.Columns.Add("TotalCount", typeof(double));
        tbl.Columns.Add("Image1", typeof(string));
        tbl.Columns.Add("ProdName", typeof(string));
        tbl.Columns.Add("Shipping", typeof(decimal));
        tbl.Columns.Add("NetAmount", typeof(decimal));
        tbl.Columns.Add("GrossAmount", typeof(decimal));
        tbl.Columns.Add("Name", typeof(string));
        tbl.Columns.Add("Flat", typeof(string));
        tbl.Columns.Add("Address", typeof(string));
        tbl.Columns.Add("Locality", typeof(string));
        tbl.Columns.Add("FreeItem", typeof(string));
        tbl.Columns.Add("Pincode", typeof(string));
        tbl.Columns.Add("ShipID", typeof(string));
        tbl.Columns.Add("EmailID", typeof(string));
        tbl.Columns.Add("MobileNo", typeof(string));
        tbl.Columns.Add("DiscountType", typeof(string));
        tbl.Columns.Add("CouponDiscount", typeof(decimal));
        tbl.Columns.Add("DiscountCode", typeof(string));

        if (HttpContext.Current.Request.Cookies["cartSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
            cartID = user.Values["cartID"].ToString();
        }

        decimal Amount = 0;

        DataSet dsn = dat.getDataSet("select  cp.*,pa.reference,pl.name,pa.price+prod.price as price,prod.ImgURL1 as URL from ps_cart_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category where cp.id_cart = " + cartID + " and pl.id_lang = 1 and cat.id_lang = 1");
        tbl.Rows.Clear();
        for (int i = 0; i < dsn.Tables[0].Rows.Count; i++)
        {
            DataRow dtrow = tbl.NewRow();
            dtrow["ProdID"] = dsn.Tables[0].Rows[i]["id_product"].ToString();
            dtrow["AttributeID"] = dsn.Tables[0].Rows[i]["id_product_attribute"].ToString();
            dtrow["Qty"] = Convert.ToInt32(dsn.Tables[0].Rows[i]["quantity"].ToString());
            dtrow["SKU"] = dsn.Tables[0].Rows[i]["reference"].ToString();
            dtrow["Price"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
            dtrow["DisPrice"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
            Amount = Convert.ToDecimal(dsn.Tables[0].Rows[i]["price"].ToString()) * (Convert.ToDecimal(dsn.Tables[0].Rows[i]["quantity"].ToString()));
            dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
            dtrow["Image1"] = dsn.Tables[0].Rows[i]["URL"].ToString();
            dtrow["ProdName"] = dsn.Tables[0].Rows[i]["name"].ToString();
            tbl.Rows.Add(dtrow);
        }

        if (tbl.Rows.Count > 0)
        {
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if (tbl.Rows[i]["AttributeID"].ToString() == AttriID)
                {
                    dat.executeCommand("delete from ps_cart_product where id_cart=" + cartID + " and id_product_attribute=" + AttriID + "");
                    tbl.Rows[i].Delete();
                }
            }
        }
        if (tbl.Rows.Count > 0)
        {
            tbl.Rows[0]["TotalAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", "").ToString())));
            tbl.Rows[0]["TotalCount"] = Convert.ToDouble(tbl.Compute("SUM(Qty)", "").ToString());
            if (Convert.ToDouble(tbl.Compute("SUM(Amount)", "")) < 300)
            {
                tbl.Rows[0]["Shipping"] = "40";
                tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", "")) + 40));
            }
            else
            {
                tbl.Rows[0]["Shipping"] = "0";
                tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", ""))));
            }

            //if (tbl.Rows[0]["DiscountType"].ToString() != "")
            //{
            //    tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", ((Convert.ToDecimal(tbl.Rows[0]["NetAmount"].ToString())) - (Convert.ToDecimal(tbl.Rows[0]["CouponDiscount"].ToString()))));
            //}
            //else
            //{
            //    tbl.Rows[0]["CouponDiscount"] = "0.00";
            //}
        }
        HttpContext.Current.Session["cartSG"] = tbl;
        return status;
    }

    [WebMethod(EnableSession = true)]
    public string addToWishList(string ProdID, string AttriID)
    {
        if (AttriID != "undefined" && AttriID != "" && AttriID != "0")
        {

        }
        else
        {
            AttriID = gdat.GetProdDefaultAttID(ProdID);
        }

        string UserID = "0";
        string wishListID = "0";
        string[] aa = ProdID.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        ProdID = bb[0].ToString();
        Data dat = new Data();
        string status = "0";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        if (HttpContext.Current.Request.Cookies["wishlistSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["wishlistSG"];
            wishListID = user.Values["wishListID"].ToString();
        } 
        if (UserID != "0")
        {
            if (wishListID == "0")
            {
                dat.executeCommand("insert into ps_wishlist(id_customer, token, name, counter, id_shop, id_shop_group, date_add, date_upd, [default]) values(" + UserID + ",'" + DBNull.Value + "','My Wishlist',0,1,1,'" + DateTime.Now + "','" + DateTime.Now + "',1)");
                wishListID = dat.getDataSet("select max(id_wishlist) as maxid from ps_wishlist").Tables[0].Rows[0]["maxid"].ToString();
                dat.executeCommand("insert into ps_wishlist_product (id_wishlist, id_product, id_product_attribute, quantity, priority) values(" + wishListID + "," + ProdID + "," + AttriID + ",1,1)");

                HttpCookie wishList = new HttpCookie("wishlistSG");
                wishList.Expires = DateTime.Now.AddDays(30d);
                wishList.Values.Add("wishListID", wishListID);
                HttpContext.Current.Response.Cookies.Add(wishList);
                status = "1";
            }
            else
            {
                //DataSet dsn = dat.getDataSet("select  * from ps_wishlist_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category where cp.id_wishlist = " + wishListID + " and pl.id_lang = 1 and cat.id_lang = 1");
                DataSet dsn = gdat.GetWishList(UserID);
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    DataRow[] results = dsn.Tables[0].Select("id_product=" + ProdID + " and id_product_attribute=" + AttriID + "", "");
                    if (results.Length > 0)
                    {
                        status = "2";
                    }
                    else
                    {
                        dat.executeCommand("insert into ps_wishlist_product (id_wishlist, id_product, id_product_attribute, quantity, priority) values(" + wishListID + "," + ProdID + "," + AttriID + ",1,1)");

                        status = "1";
                    }
                }
                else
                {
                    dat.executeCommand("insert into ps_wishlist_product (id_wishlist, id_product, id_product_attribute, quantity, priority) values(" + wishListID + "," + ProdID + "," + AttriID + ",1,1)");

                    status = "1";
                }
            }

        }
        return status;
    }

    [WebMethod(EnableSession = true)]
    public string getWishList()
    {
        string wishListID = "0";
        string wishItemQty = "0";
        string UserID = "0";
        Data dat = new Data();
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
            if (HttpContext.Current.Request.Cookies["wishlistSG"] != null)
            {
                HttpCookie wishh = HttpContext.Current.Request.Cookies["wishlistSG"];
                wishListID = wishh.Values["wishListID"].ToString();
            }

            //DataSet dsn = gdat.GetWishDetail(UserID, wishListID);
            DataSet dsn = gdat.GetWishList(UserID);
            if (dsn.Tables[0].Rows.Count > 0)
            {
                //wishItemQty = dsn.Tables[0].Rows[0]["coun"].ToString();
                wishItemQty = dsn.Tables[0].Rows.Count.ToString();
            }
        }
        return wishItemQty;
    }

    [WebMethod(EnableSession = true)]
    public string addWishList(string ProdID)
    {
        string AttriID = "0";
        string UserID = "0";
        string wishListID = "0";
        string[] aa = ProdID.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        ProdID = bb[0].ToString();
        Data dat = new Data();
        string status = "0";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        if (HttpContext.Current.Request.Cookies["wishlistSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["wishlistSG"];
            wishListID = user.Values["wishListID"].ToString();
        }

        if (UserID != "0")
        {
            ds = data.getDataSet("select id_product_attribute from ps_product_attribute where default_on=1 and id_product=" + ProdID + "");
            if (ds.Tables[0].Rows.Count > 0)
                AttriID = ds.Tables[0].Rows[0]["id_product_attribute"].ToString();


            if (wishListID == "0")
            {
                dat.executeCommand("insert into ps_wishlist(id_customer, token, name, counter, id_shop, id_shop_group, date_add, date_upd, [default]) values(" + UserID + ",'" + DBNull.Value + "','My Wishlist',0,1,1,'" + DateTime.Now + "','" + DateTime.Now + "',1)");
                wishListID = dat.getDataSet("select max(id_wishlist) as maxid from ps_wishlist").Tables[0].Rows[0]["maxid"].ToString();
                dat.executeCommand("insert into ps_wishlist_product (id_wishlist, id_product, id_product_attribute, quantity, priority) values(" + wishListID + "," + ProdID + "," + AttriID + ",1,1)");

                HttpCookie wishList = new HttpCookie("wishlistSG");
                wishList.Expires = DateTime.Now.AddDays(30d);
                wishList.Values.Add("wishListID", wishListID);
                HttpContext.Current.Response.Cookies.Add(wishList);
            }
            else
            {
                DataSet dsn = dat.getDataSet("select  * from ps_wishlist_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category where cp.id_wishlist = " + wishListID + " and pl.id_lang = 1 and cat.id_lang = 1");
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    DataRow[] results = dsn.Tables[0].Select("id_product=" + ProdID + " and id_product_attribute=" + AttriID + "", "");
                    if (results.Length > 0)
                    {

                    }
                    else
                    {
                        dat.executeCommand("insert into ps_wishlist_product (id_wishlist, id_product, id_product_attribute, quantity, priority) values(" + wishListID + "," + ProdID + "," + AttriID + ",1,1)");
                    }
                }
                else
                {
                    dat.executeCommand("insert into ps_wishlist_product (id_wishlist, id_product, id_product_attribute, quantity, priority) values(" + wishListID + "," + ProdID + "," + AttriID + ",1,1)");
                }
            }
            status = "1";
        }
        return status;
    }

    [WebMethod(EnableSession = true)]
    public string getShippingAddress(string addId)
    {
        string UserID = "0";
        Data dat = new Data();
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();

            if (HttpContext.Current.Session["shipaddid"] != null && HttpContext.Current.Session["shipaddid"].ToString() != "0")
            {
                addId = HttpContext.Current.Session["shipaddid"].ToString();
            }

        }
        DataSet dsn = dat.getDataSet("select con.name as Country,sta.name as State,a.* from ps_address a inner join ps_country_lang con on a.id_country = con.id_country left outer join ps_state sta on a.id_state = sta.id_state  where a.active = 1 and a.id_customer = " + UserID + " and a.id_address=" + addId + " and con.id_lang=1");
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dsn.Tables[0]);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getBillingAddress(string addId)
    {
        string UserID = "0";
        Data dat = new Data();
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();

            if (HttpContext.Current.Session["shipaddid"] != null && HttpContext.Current.Session["shipaddid"].ToString() != "0")
            {
                addId = HttpContext.Current.Session["shipaddid"].ToString();
            }
        }
        DataSet dsn = dat.getDataSet("select con.name as Country,sta.name as State,a.* from ps_address a inner join ps_country_lang con on a.id_country = con.id_country left outer join ps_state sta on a.id_state = sta.id_state  where a.active = 1 and a.id_customer = " + UserID + " and a.id_address=" + addId + " and con.id_lang=1");
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dsn.Tables[0]);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getShippingAddressFilter(string addId)
    {
        string UserID = "0";
        Data dat = new Data();
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        DataSet dsn = dat.getDataSet("select con.name as Country,sta.name as State,a.* from ps_address a inner join ps_country_lang con on a.id_country = con.id_country left outer join ps_state sta on a.id_state = sta.id_state  where a.id_customer = " + UserID + " and a.id_address=" + addId + " and con.id_lang=1");
        string jsonstring1 = string.Empty;
        jsonstring1 = "<p>" + dsn.Tables[0].Rows[0]["firstname"].ToString() + " " + dsn.Tables[0].Rows[0]["lastname"].ToString() + "</p>";
        string company = dsn.Tables[0].Rows[0]["company"].ToString().Trim();
        string State = dsn.Tables[0].Rows[0]["State"].ToString().Trim();
        if (company != "" && company != null)
        {
            jsonstring1 += "<p>" + company + "</p>";
        }
        jsonstring1 += "<p>" + dsn.Tables[0].Rows[0]["address1"].ToString() + " " + dsn.Tables[0].Rows[0]["address2"].ToString() + "</p>";
        jsonstring1 += "<p>";
        jsonstring1 += dsn.Tables[0].Rows[0]["city"].ToString();
        if (State != "" && State != null)
        {
            jsonstring1 += ", " + dsn.Tables[0].Rows[0]["State"].ToString();
        }

        jsonstring1 += ", " + dsn.Tables[0].Rows[0]["postcode"].ToString() + ", " + dsn.Tables[0].Rows[0]["Country"].ToString();
        jsonstring1 += "</p>";

        jsonstring1 += "<p>" + dsn.Tables[0].Rows[0]["phone_mobile"].ToString() + "</p>";
        jsonstring1 += "<p>" + dsn.Tables[0].Rows[0]["phone"].ToString() + "</p>";
        jsonstring1 += "<p>" + dsn.Tables[0].Rows[0]["other"].ToString() + "</p>";

        jsonstring1 += " <div class='submit mt-1'> ";
        jsonstring1 += "  <input type='hidden' class='hidden' name='back' value='my-account'> ";
        jsonstring1 += "  <a href='AddAddress.aspx?addid=" + dsn.Tables[0].Rows[0]["id_address"].ToString() + "' class='btn btn-md btn-black-default-hover mb-4'>UPDATE</a> ";
        jsonstring1 += " <input type='hidden' class='hidden' name='SubmitCreate' value='Create an account'> ";
        jsonstring1 += " </div> ";
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string chkLogin()
    {
        string UserID = "0";
        Data dat = new Data();
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        return UserID;
    }

    [WebMethod(EnableSession = true)]
    public string getBillingAddressFilter(string addId)
    {
        string UserID = "0";
        Data dat = new Data();
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        DataSet dsn = dat.getDataSet("select con.name as Country,sta.name as State,a.* from ps_address a inner join ps_country_lang con on a.id_country = con.id_country left outer join ps_state sta on a.id_state = sta.id_state  where a.id_customer = " + UserID + " and a.id_address=" + addId + " and con.id_lang=1");
        string jsonstring1 = string.Empty;
        jsonstring1 = "<p>" + dsn.Tables[0].Rows[0]["firstname"].ToString() + " " + dsn.Tables[0].Rows[0]["lastname"].ToString() + "</p>";
        string company = dsn.Tables[0].Rows[0]["company"].ToString().Trim();
        string State = dsn.Tables[0].Rows[0]["State"].ToString().Trim();
        if (company != "" && company != null)
        {
            jsonstring1 += "<p>" + company + "</p>";
        }
        jsonstring1 += "<p>" + dsn.Tables[0].Rows[0]["address1"].ToString() + " " + dsn.Tables[0].Rows[0]["address2"].ToString() + "</p>";
        jsonstring1 += "<p>";
        jsonstring1 += dsn.Tables[0].Rows[0]["city"].ToString();
        if (State != "" && State != null)
        {
            jsonstring1 += ", " + dsn.Tables[0].Rows[0]["State"].ToString();
        }

        jsonstring1 += ", " + dsn.Tables[0].Rows[0]["postcode"].ToString() + ", " + dsn.Tables[0].Rows[0]["Country"].ToString();
        jsonstring1 += "</p>";
        jsonstring1 += "<p>" + dsn.Tables[0].Rows[0]["phone_mobile"].ToString() + "</p>";
        jsonstring1 += "<p>" + dsn.Tables[0].Rows[0]["phone"].ToString() + "</p>";
        jsonstring1 += "<p>" + dsn.Tables[0].Rows[0]["other"].ToString() + "</p>";
        jsonstring1 += " <div class='submit mt-1'> ";
        jsonstring1 += "  <input type='hidden' class='hidden' name='back' value='my-account'> ";
        jsonstring1 += "  <a href='AddAddress.aspx?addid=" + dsn.Tables[0].Rows[0]["id_address"].ToString() + "' class='btn btn-md btn-black-default-hover mb-4'>UPDATE  </a> ";
        jsonstring1 += " <input type='hidden' class='hidden' name='SubmitCreate' value='Create an account'> ";
        jsonstring1 += " </div> ";
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getModelDetail(string prodID)
    {
        GetData data = new GetData();
        Data dat = new Data();
        DataSet ds = data.getDetail(prodID);
        DataSet dsImg = data.getItemImages(ds.Tables[0].Rows[0]["id_product"].ToString());
        string str = "<div class=\"row\">";
        int totImg = dsImg.Tables[0].Rows.Count;
        //Image Model Div New Design 
        str += "<div class=\"col-md-6\">";
        str += "<div class=\"column\">";
        str += "<a href= \'" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "\' class=\"reviews\"> ";
        str += "   <img id=\"featured\" src=\"" + dsImg.Tables[0].Rows[0]["bigimg"].ToString().TrimEnd() + "\" /> ";
        str += "</a>";
        if (ds.Tables[0].Rows[0]["available_nowHtml"].ToString() != "")
        {
            str += "<div style=\"position: absolute; top: 1px; left: 16px;\">";
            str += "<ul class=\"product-flag\">" + ds.Tables[0].Rows[0]["available_nowHtml"].ToString() + " ";
            str += "</ul></div>";
        }
        if (ds.Tables[0].Rows[0]["Discount"].ToString() == "0" || ds.Tables[0].Rows[0]["Discount"].ToString() == "0.00" || ds.Tables[0].Rows[0]["Discount"].ToString() == "")
        {
        }
        else
        {
            //str += "<div style=\"position: absolute; top: 1px; right: 16px;\">";
            //str += "<div class=\"product-price-and-shipping-top\"><span class=\"discount-percentage discount-product\">-" + ds.Tables[0].Rows[0]["Discount"].ToString() + "%</span> </div>";
            //str += "</div>";
        }

        //Thumb Image Start
        str += "<div id=\"slide-wrapper\">";
        if (totImg > 2)
        {
            str += " <img id=\"slideLeft\" onclick=\"slideLeftmod();\" class=\"arrow\" src=\"/img/arrow-left.png\" />";
        }

        str += "<div id=\"slider\">";
        bool styleblosk = true;
        foreach (DataRow dr in dsImg.Tables[0].Rows)
        {
            if (styleblosk == true)
            {
                str += "<img id=\"m" + dr["id_image"].ToString().TrimEnd() + "\" class=\"thumbnail2 active modClass\" src=\"" + dr["bigimg"].ToString().TrimEnd() + "\" onmouseover=\"shankartest();\"   />";
                styleblosk = false;
            }
            else
            {
                str += "<img id=\"m" + dr["id_image"].ToString().TrimEnd() + "\" class=\"thumbnail2 active modClass\" src=\"" + dr["bigimg"].ToString().TrimEnd() + "\" onmouseover=\"shankartest();\"   />";
            }
        }
        str += "</div>";

        if (totImg > 2)
        {
            str += " <img id=\"slideRight\" onclick=\"slideRightmod();\" class=\"arrow\" src=\"/img/arrow-right.png\" />";
        }

        str += "</div>";

        //Thumb Image End 


        str += "</div>";
        str += "</div>";

        //getDetail and Description detail DIV
        str += "<div class=\" col-md-6 \">";
        str += "<div class=\"content_info\">";
        str += " <p class=\"reference\">Reference:<span id=\"skuquik\"> " + ds.Tables[0].Rows[0]["reference"].ToString() + "</span></p>";
        str += "<a href= \'" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "\' class=\"reviews\"> ";
        str += "<h1 class=\"h1 namne_details\" itemprop=\"name\">" + ds.Tables[0].Rows[0]["ProdName"].ToString() + "</h1>";
        str += "</a>";
        str += "<span id=\"productNamequik\" style=\"display: none; \">" + ds.Tables[0].Rows[0]["ProdName"].ToString() + "</span>";
        str += "<span id=\"dispricequik\" style=\"display: none; \">" + ds.Tables[0].Rows[0]["DiscountPrice"].ToString() + "</span>";
        str += "<span id=\"rpricequik\" style=\"display: none;\" >" + ds.Tables[0].Rows[0]["ProdPrice"].ToString() + "</span> ";
        str += "<span id=\"lblRadio\" style=\"display: none;\" >Yes</span> ";
        str += "<asp:Label ID=\"lblImg\" runat=\"server\" Text=\"\" Style=\"display: none; \">" + dsImg.Tables[0].Rows[0]["smallimg"].ToString() + "</asp:Label>";
        str += "<asp:Label ID=\"lblBigImg\" runat=\"server\" Text=\"\" Style=\"display: none; \">" + dsImg.Tables[0].Rows[0]["bigimg"].ToString() + "</asp:Label>";
        DataSet dsatt = dat.getDataSet("select * from  ps_product_attribute where id_product=" + ds.Tables[0].Rows[0]["id_product"].ToString() + " and default_on=1");
        if (dsatt.Tables[0].Rows.Count > 0)
        {

            str += "<asp:Label ID=\"lblattIDquik\" runat=\"server\" Text=\"\" Style=\"display: none; \">" + dsatt.Tables[0].Rows[0]["id_product_attribute"].ToString() + "</asp:Label>";
        }
        str += "<span id=\"spCat\" style=\"display: none;\" >" + ds.Tables[0].Rows[0]["id_product"].ToString() + "</span> ";
        str += "<div class=\"product-price-and-shipping\">";
        str += "<span class=\"notExistMsg\"></span>";
        if (ds.Tables[0].Rows[0]["Discount"].ToString() == "0" || ds.Tables[0].Rows[0]["Discount"].ToString() == "0.00" || ds.Tables[0].Rows[0]["Discount"].ToString() == "")
        {
            str += "<span class=\"sr-only\">Price</span>";
            str += "<span itemprop=\"price\" class=\"price price-sale prshowornot\" style=\"font-size: 20px;\">$<span id=\"sppricenewquik\">" + ds.Tables[0].Rows[0]["ProdPrice"].ToString() + "</span> per " + ds.Tables[0].Rows[0]["unity"].ToString() + "</span>";
        }
        else
        {

            str += "<span class=\"sr-only\">Price</span>";
            str += "<span itemprop=\"price\" class=\"price price-sale pr-1\" style=\"font-size: 20px;\">$<span id=\"spdispricequik\">" + ds.Tables[0].Rows[0]["DiscountPrice"].ToString() + "</span>  per " + ds.Tables[0].Rows[0]["unity"].ToString() + "</span>&nbsp;";
            str += "<span class=\"sr-only\">Regular price</span>";
            str += "<span class=\"regular-price\" style=\"font-size: 20px;\">$<span id=\"sppricequik\">" + ds.Tables[0].Rows[0]["ProdPrice"].ToString() + "</span> </span>";
            str += "<span  style=\"font-size: 20px; color:#b22222;\"><b>(- " + ds.Tables[0].Rows[0]["Discount"].ToString() + "%)</b></span>";
        }
        str += " </div>";
        str += "<div class=\"product-price-and-shipping pt-1\">";

        string rdoid = "0";
        DataSet dsr = gdata.getItemMainGroup(prodID, "radio");

        if (dsr.Tables[0].Rows.Count > 0)
        {
            bool rdoidAdd = false;
            for (int i = 0; i < dsr.Tables[0].Rows.Count; i++)
            {
                str += "<span id=\"lblRadio\" style=\"display: none;\" >No</span> ";
                str += "<p>";
                str += "<h6 class=\"control-label\" style=\"font-size: 15px;\">" + dsr.Tables[0].Rows[i]["groupname"].ToString() + " </h6>";
                str += "</p>";
                str += " <div>";
                DataSet dsi = gdata.getItemAttribute(prodID, dsr.Tables[0].Rows[i]["id_attribute_group"].ToString());
                if (dsi.Tables[0].Rows.Count > 0)
                {
                    string raddefault = "";
                    if (dsi.Tables[1].Rows.Count > 0)
                    {
                        raddefault = dsi.Tables[1].Rows[0]["id_attribute"].ToString();
                    }
                    bool firstRadioChecked = false;
                    for (int j = 0; j < dsi.Tables[0].Rows.Count; j++)
                    {
                        if (rdoidAdd == false)
                        {
                            if (j == 0)
                            {
                                rdoid = dsi.Tables[0].Rows[j]["id_attribute"].ToString();
                            }
                            else
                            {
                                rdoid += "," + dsi.Tables[0].Rows[j]["id_attribute"].ToString();
                            }
                            rdoidAdd = true;
                        }
                        else
                        {
                            if (j == 0)
                            {
                                rdoid += "," + dsi.Tables[0].Rows[j]["id_attribute"].ToString();
                            }
                            else
                            {
                                rdoid += "," + dsi.Tables[0].Rows[j]["id_attribute"].ToString();
                            }
                        }
                        if (raddefault != "")
                        {
                            if (raddefault.Trim() == dsi.Tables[0].Rows[j]["id_attribute"].ToString().Trim())
                            {
                                str += " <label>";
                                str += "<input checked=\"checked\" type=\"radio\" id=\"rdoquik" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdoquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";
                            }
                            else
                            {
                                str += " <label>";
                                str += "<input  type=\"radio\" id=\"rdoquik" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdoquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";
                            }
                        }
                        else
                        {
                            if (firstRadioChecked == false)
                            {
                                str += " <label>";
                                str += "<input checked=\"checked\" type=\"radio\" id=\"rdoquik" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdoquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";

                                firstRadioChecked = true;
                            }
                            else
                            {
                                str += " <label>";
                                str += "<input  type=\"radio\" id=\"rdoquik" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdoquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";
                            }
                        }



                        //if (dsi.Tables[0].Rows[j]["attributename"].ToString() == "Checker Cutting")
                        //{
                        //    str += "<span id=\"lblCheckerCuttingVal\" style=\"display: none;\" >" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "</span> ";
                        //    str += " <label>";
                        //    str += "<input checked=\"checked\" type =\"radio\" id=\"rdo" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdo" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";
                        //}
                        //else
                        //{
                        //    str += " <label>";
                        //    str += "<input checked=\"checked\" type=\"radio\" id=\"rdo" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdo" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";
                        //}




                        //str += "<label class=\"radio-inline mr-2\">";
                        //str += "<span class=\"custom-radio mr-0\" style=\"margin-top: -5px;\">";
                        //str += "<input name=\"checker-cutting\" type=\"radio\" value=\"1\">";
                        //str += "<span></span>";
                        //str += "</span>";
                        //str += ""+dsi.Tables[0].Rows[j]["attributename"].ToString()+"";
                        //str += "</label>";
                    }
                }
                str += "</div>";
            }
        }
        str += "<span id=\"rdoDataquik\" style=\"display: none; \">" + rdoid + "</span>";
        str += " </div>";
        str += "<div class=\"product-information\">";
        str += "<div class=\"product-actions pt-0\">";
        str += "<form action=\"#\" method=\"post\" id=\"add-to-cart-or-refresh\">";
        str += "<input type=\"hidden\" name=\"token\" value=\"3b8dc4acde28257687abb3d4ddf26fc2\">";
        str += "<input type=\"hidden\" name=\"id_product\" value=\"17\" id=\"product_page_product_id\">";
        str += "<input type=\"hidden\" name=\"id_customization\" value=\"0\" id=\"product_customization_id\">";


        string selectId = "0";
        dsr = gdata.getItemMainGroup(prodID, "select");
        if (dsr.Tables[0].Rows.Count > 0)
        {
            str += "<div class=\"product-variants\">";
            str += "<div class=\"clearfix product-variants-item\" style=\"margin-top: 5px;\">";
            for (int i = 0; i < dsr.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                    selectId = dsr.Tables[0].Rows[i]["id_attribute_group"].ToString();
                else
                    selectId += "," + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString();
                str += "<span class=\"control-label mb-0\">" + dsr.Tables[0].Rows[i]["groupname"].ToString() + "</span>";
                str += "<select id=\"drpquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\" class=\"form-control-select classic\" name=\"group[3]\" style=\"width: 228px\">";
                DataSet dsi = gdata.getItemAttribute(prodID, dsr.Tables[0].Rows[i]["id_attribute_group"].ToString());
                if (dsi.Tables[0].Rows.Count > 0)
                {
                    string dd = dsi.Tables[1].Rows[0]["id_attribute"].ToString();
                    string aaaid = dsi.Tables[1].Rows[0]["id_attribute_group"].ToString();
                    for (int j = 0; j < dsi.Tables[0].Rows.Count; j++)
                    {
                        if (dd == dsi.Tables[0].Rows[j]["id_attribute"].ToString())
                        {
                            str += "<option selected value = \"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" title=\"40x60cm\" >" + dsi.Tables[0].Rows[j]["attributename"].ToString() + "</option>";
                        }
                        else
                        {
                            str += "<option value = \"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" title=\"40x60cm\" >" + dsi.Tables[0].Rows[j]["attributename"].ToString() + "</option>";
                        }
                    }
                }
                str += " </select>";
            }

            str += " </div>";
            str += " </div>";
        }

        str += "<span id=\"selectDataquik\" style=\"display: none; \">" + selectId + "</span>";




        //str += "<div class=\"product-variants\">";
        //str += "<div class=\"clearfix product-variants-item\" style=\"margin-top: 5px;\">";
        //str += "<span class=\"control-label mb-0\">Color</span>";
        //str += "<select class=\"form-control-select classic\" name=\"group[3]\" style=\"width: 228px\">";
        //str += "<option value = \"19\" title=\"40x60cm\" selected=\"selected\">Purple</option>";
        //str += " </select>";
        //str += " </div>";
        //str += " </div>";

        str += "  <input type='hidden' id='IsStockAllow' value='" + ds.Tables[0].Rows[0]["IsStockAllow"].ToString() + "'  /> ";
        str += "  <input type='hidden' id='stockQty' value='" + ds.Tables[0].Rows[0]["StockQty"].ToString() + "'  /> ";

        str += "<section class=\"product-discounts\">";
        str += " </section>";
        str += " <div class=\"product-add-to-cart\">";
        str += "<span class=\"control-label\">Quantity</span>";
        str += " <div class=\"notoutofstockdiv\">";
        str += " <div class=\"#\"  style=\"width:120px; float: left;\">";
        #region out of stock
        if (ds.Tables[0].Rows[0]["StockStatus"].ToString().Trim() != "OutOfStock")
        {
            str += "<a href=\"javaScript:void(0)\" onclick=\"removeQty();\" class=\"btn btn-primary\" style=\"width:24px; float: left; margin-right:5px;\">-</a> &nbsp;";

            str += "<input type = \"text\" name = \"Qty\" id = \"Qty\" value = \'" + ds.Tables[0].Rows[0]["minimal_quantity"].ToString() + "\'  class=\"form-control\" min=\'" + ds.Tables[0].Rows[0]["minimal_quantity"].ToString() + "\' onchange=\"cartQtyChange();\" style=\"width:50px; float: left; padding: 8px 5px 8px 5px;\"   />";

            str += " <a href=\"javaScript:void(0)\" onclick=\"addQtyPlus();\" class=\"btn btn-primary\" style=\"width:24px; float: left;\">+</a>";
            str += "</div>";
            str += "<div class=\"add\">";
            str += "<a href=\"#\" class=\"btn btn-primary add-to-cart\" data-button-action=\"add-to-cart\" onclick=\"addToCart();\">";
            str += "<i class=\"material-icons shopping-cart\">&#xE547;</i>";
            str += " Add to cart";
            str += "  </a>";
            str += " </div>";
            str += "  </div>";
            str += "<div class=\"row\">&nbsp;</div>";
            str += "<div class=\"row\">";
            str += " <div class=\"col-md-12\" style=\"padding-top: 1px;\">";
            str += "<p class=\"notoutofstockdiv\">The minimum purchase order quanitity of the product is <span id=\"minQty\">" + ds.Tables[0].Rows[0]["minimal_quantity"].ToString() + " </span>&nbsp;" + ds.Tables[0].Rows[0]["unity"].ToString() + "</p>";
        }
        #endregion
        str += "</div>";
        str += "</div>";

        str += " <span id=\"product-availability\" ></ span >";
        str += "<p class=\"product-minimal-quantity\">";
        str += "</p>";
        str += " </div>";
        str += " <div class=\"product-additional-info\">";
        str += "<p class=\"panel-product-line panel-product-actions\">";
        //str += " <a id=\"wishlist_button\" href=\"#\" onclick=\"WishlistCart('wishlist_block_list', 'add', '17', $('#idCombination').val(), document.getElementById('quantity_wanted').value); return false;\" rel=\"nofollow\" title=\"Add to my wishlist\">";
        str += " <a id=\"" + ds.Tables[0].Rows[0]["minimal_quantity"].ToString() + "\" href=\"javaScript:void(0);\" onclick=\"addWishList(" + ds.Tables[0].Rows[0]["ProdID"].ToString() + ");\" title=\"Add to my wishlist\">";
        str += "<i class=\"icon-heart\"></i>Add to wishlist";
        str += "</a>";
        str += "</p>";
        str += " <div class=\"clearfix\"></div>";
        str += " <div id=\"product_comments_block_extra\" class=\"no-print\" itemprop=\"aggregateRating\" itemscope itemtype=\"#\" >";
        str += "<div class=\"comments_note clearfix\">";
        str += "<span>Rating&nbsp;</span>";
        str += "<div class=\"star_content clearfix\">";
        string ddd = BindStar(ds.Tables[0].Rows[0]["Rating"].ToString());
        str += ddd;
        //str += " <div class=\"star star_on\"></div>";
        //str += "<div class=\"star star_on\"></div>";
        //str += "<div class=\"star star_on\"></div>";
        //str += "<div class=\"star star_on\"></div>";
        //str += " <div class=\"star star_on\"></div>";
        //str += "<meta itemprop=\"worstRating\" content=\"0\" />";
        //str += "<meta itemprop=\"ratingValue\" content=\"5\" />";
        //str += "<meta itemprop=\"bestRating\" content=\"5\" />";
        str += "</div>";
        str += "</div>";
        str += "<ul class=\"comments_advices\">";
        str += "<li>";
        str += "<a href= \'" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "\' class=\"reviews\">Read reviews(<span itemprop = \"reviewCount\" >" + ds.Tables[0].Rows[0]["ReviewCount"].ToString() + "</span>)";
        str += "</a>";
        str += "</li>";
        //str += "<li>";
        //str += "<a class=\"open-comment-form\">Write a review";
        //str += "</a>";DetailUrl
        //str += "</li>";
        str += " </ul>";
        str += "</div>";
        str += " <div style=\"padding-top: 5px;\" >";
        str += "<div class=\"clearfix\"></div>";
        str += " <div id=\"product_comments_block_tab\" >";
        str += " <p class=\"align_center\" style=\"padding-top: 5px;\">";
        str += "<a id=\"new_comment_tab_btn\" class=\"open-comment-form1 btn btn-secondary add-to-cart EnqNotifyDiv\" data-toggle=\"modal\" data-target=\"#custEnquiryModel\" ng-click=\"custProdEnquiryModel(" + prodID + ")\" style=\"padding: 0px 10px;\">Enquire About This Product</a>";
        str += "</p>";
        str += "</div>";
        str += "<div class=\"container\">";
        str += "<div class=\"modal fade\" id=\"myModal1\" role=\"dialog\">";
        str += "<div class=\"modal-dialog\">";
        str += "<!-- Modal content-->";
        str += "<div class=\"modal-content\">";
        str += "<div class=\"modal-body\">";
        str += "<div id=\"new_comment_form\" >";
        str += "<form id=\"id_new_comment_form\" action=\"#\">";
        str += "<h2 class=\"title\">How can I contact you?</h2>";
        str += "<div class=\"row\">";
        str += " <div class=\"product clearfix col-xs-12 col-sm-12	\">";
        str += " <div class=\"product_desc\">";
        str += " <p class=\"product_name\">Pink Tourmaline Carved Fancy Shape Gemstone - Stone Name - Pink Tourmaline</p>";
        str += "</div>";
        str += "</div>";
        str += "</div>";
        str += " <div class=\"row\">";
        str += " <div class=\"product clearfix col-xs-12 col-sm-6\">";
        str += "<img src=\"modules/products/lavender-jade-color-silver-rosary-chain.jpg\" alt=\"Pink Tourmaline Carved Fancy Shape Gemstone - Stone Name - Pink Tourmaline\" />";
        str += " </div>";
        str += "<div class=\"new_comment_form_content col-xs-12 col-sm-6\">";
        str += "<label class=\"mt-0\">Customer Name<sup class=\"required\">*</sup></label>";
        str += "<input id=\"commentCustomerName\" name=\"customer_name\" type=\"text\" value=\"\" />";
        str += "<label>Customer Email<sup class=\"required\">*</sup></label>";
        str += " <input id=\"commentCustomerName\" name=\"customer_email\" type=\"text\" value=\"\" />";
        str += "<label for=\"content\">Message<sup class=\"required\">*</sup></label>";
        str += " <textarea id=\"content\" name=\"content\"></textarea>";
        str += " <div id=\"new_comment_form_footer\" >";
        str += "<input id=\"id_product_comment_send\" name=\"id_product\" type=\"hidden\" value='17' />";
        str += "<p class=\"fl required\" style=\"margin-bottom: 10px;\"><sup>*</sup> Required fields</p>";
        str += "<p class=\"fr\">";
        str += "<button id=\"submitNewMessage\" class=\"btn btn-secondary\" name=\"submitMessage\" type=\"submit\">Send</button>";
        str += " &nbsp;";
        str += " or&nbsp;";
        str += "<button type = \"button\" class=\"closefb btn btn-secondary\" data-dismiss=\"modal\" aria-label=\"Close\">";
        str += "<span aria-hidden=\"true\">Cancel</span>";
        str += " </button>";
        str += "</p>";
        str += "<div class=\"clearfix\"></div>";
        str += "</div>";
        str += "</div>";
        str += " </div>";
        str += " </form>";
        str += " </div>";
        str += " </div>";
        str += " </div>";
        str += " </div>";
        str += "</div>";
        str += " </div>";
        str += " </div>";
        str += "<div class=\"social-sharing\">";
        str += " <span>Share</span>";
        str += " <ul>";
        //str += " <li class=\"email\"><a href = \"#\" title=\"Email Share\" target=\"_blank\" class=\"ion-email\">Email Share</a></li>";

        str += " <li class=\"email\"><a data-toggle=\"modal\" data-target=\"#shareprodonemail\" ng-click=\"shareprodonemail(" + prodID + ")\" title=\"Email Share\" target=\"_blank\" class=\"ion-email\">Email Share</a></li>";

        //str += "<li class=\"whatsapp\"><a href = \"#\" title=\"Whatsapp Share\" target=\"_blank\" class=\"ion-social-whatsapp\">Whatsapp Share</a></li>";
        //str += "<li class=\"facebook\"><a href = \"#\" title=\"Share\" target=\"_blank\">Share</a></li>";

        str += "<li class=\"whatsapp\"><a href = \"https://api.whatsapp.com/send?text=https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "\" title=\"Whatsapp Share\" target=\"_blank\" class=\"ion-social-whatsapp\">Whatsapp Share</a></li>";
        str += "<li class=\"facebook\"><a onclick=\"socialWindow('https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "','fb');\" title=\"Share\" target=\"_blank\">Share</a></li>";
        str += " <li class=\"twitter\"><a onclick=\"socialWindow('https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "','twitter');\" title=\"Tweet\" target=\"_blank\">Tweet</a></li>";
        str += "<li class=\"pinterest\"><a onclick=\"socialWindow('https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "','pinterest');\" title=\"Pinterest\" target=\"_blank\">Pinterest</a></li>";
        str += " </ul>";
        str += " </div>";
        str += " </div>";
        str += "</form>";
        str += "</div>";
        str += " </div>";
        str += "</div>";
        str += " </div>";
        str += "</div>";
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string getModelDetailold(string prodID)
    {
        GetData data = new GetData();
        Data dat = new Data();
        DataSet ds = data.getDetail(prodID);
        DataSet dsImg = data.getItemImages(ds.Tables[0].Rows[0]["id_product"].ToString());
        string str = "<div class=\"row\">";

        //Loader Bind
        //str += "  <div id='loading' data-ng-if='loading'> ";
        //str += "  <div id='loading-image'> ";
        //str += " <img src='img/ajax-loader.gif' alt='Loading...' style='border-radius: 5%;' /> ";
        //str += " </div> ";
        //str += " </div> ";

        //Image Model Div New Design 
        str += "<div class=\"col-md-6\">";
        str += "<section class=\"page-content\" id=\"content\">";
        str += "<div class=\"container\">";
        bool styleblosk = true;
        foreach (DataRow dr in dsImg.Tables[0].Rows)
        {
            if (styleblosk == true)
            {
                //str += " ";
                str += "<ul  class=\"product-flag\"><li class=\"new\" style=\"margin-left: 15px;\"><span>" + dr["available_nowTag"].ToString().TrimEnd() + "</span></li></ul>";
                //str += "<div style=\"margin-left: 15px;\"> <ul class=\"product-flag\">" + dr["available_nowTag"].ToString().TrimEnd() + "</ul></div>"; 
                str += "<div id=\"" + dr["id_image"].ToString().TrimEnd() + "\" class=\"mySlides popMySlides\" style=\"display: block;\">";
                str += "<img class=\"\" style=\"width: 100%;\" src=\"" + dr["bigimg"].ToString().TrimEnd() + "\" />";
                str += "</div>";
                styleblosk = false;
            }
            else
            {
                str += "<div id=\"" + dr["id_image"].ToString().TrimEnd() + "\" class=\"mySlides popMySlides\" style=\"display: none;\">";
                str += "<img class=\"\" style=\"width: 100%;\" src=\"" + dr["bigimg"].ToString().TrimEnd() + "\" />";
                str += "</div>";
            }
        }

        //Next and previous buttons
        str += "<a class=\"prev\" onclick=\"plusSlides(-1)\">&#10094;</a>";
        str += "<a class=\"next\" onclick=\"plusSlides(1)\">&#10095;</a>";

        //Image text
        str += "<div class=\"caption-container\">";
        str += "<p class=\"caption\"></p>";
        str += "</div>";

        //Thumbnail images
        str += "<div class=\"row ml-0\">";
        foreach (DataRow dr in dsImg.Tables[0].Rows)
        {
            str += "<div class=\"column\">";
            str += "<img class=\"cursor\" style=\"width: 100%;\" src=\"" + dr["bigimg"].ToString().TrimEnd() + "\"  onclick=\"currentSlide(" + dr["position"] + ")\"  />";
            str += "</div>";
        }
        str += "</div>";


        str += "</div>";
        str += "</section>";
        str += "</div>";

        //getDetail and Description detail DIV
        str += "<div class=\" col-md-6 \">";
        str += "<div class=\"content_info\">";
        str += " <p class=\"reference\">Reference:<span id=\"skuquik\"> " + ds.Tables[0].Rows[0]["reference"].ToString() + "</span></p>";
        str += "<a href= \'" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "\' class=\"reviews\"> ";
        str += "<h1 class=\"h1 namne_details\" itemprop=\"name\">" + ds.Tables[0].Rows[0]["ProdName"].ToString() + "</h1>";
        str += "</a>";
        str += "<span id=\"productNamequik\" style=\"display: none; \">" + ds.Tables[0].Rows[0]["ProdName"].ToString() + "</span>";
        str += "<span id=\"dispricequik\" style=\"display: none; \">" + ds.Tables[0].Rows[0]["DiscountPrice"].ToString() + "</span>";
        str += "<span id=\"rpricequik\" style=\"display: none;\" >" + ds.Tables[0].Rows[0]["ProdPrice"].ToString() + "</span> ";
        str += "<span id=\"lblRadio\" style=\"display: none;\" >Yes</span> ";
        str += "<asp:Label ID=\"lblImg\" runat=\"server\" Text=\"\" Style=\"display: none; \">" + dsImg.Tables[0].Rows[0]["smallimg"].ToString() + "</asp:Label>";
        str += "<asp:Label ID=\"lblBigImg\" runat=\"server\" Text=\"\" Style=\"display: none; \">" + dsImg.Tables[0].Rows[0]["bigimg"].ToString() + "</asp:Label>";
        DataSet dsatt = dat.getDataSet("select * from  ps_product_attribute where id_product=" + ds.Tables[0].Rows[0]["id_product"].ToString() + " and default_on=1");
        if (dsatt.Tables[0].Rows.Count > 0)
        {

            str += "<asp:Label ID=\"lblattIDquik\" runat=\"server\" Text=\"\" Style=\"display: none; \">" + dsatt.Tables[0].Rows[0]["id_product_attribute"].ToString() + "</asp:Label>";
        }
        str += "<span id=\"spCat\" style=\"display: none;\" >" + ds.Tables[0].Rows[0]["id_product"].ToString() + "</span> ";
        str += "<div class=\"product-price-and-shipping\">";
        str += "<span class=\"notExistMsg\"></span>";
        if (ds.Tables[0].Rows[0]["Discount"].ToString() == "0")
        {
            str += "<span class=\"sr-only\">Price</span>";
            str += "<span itemprop=\"price\" class=\"price price-sale prshowornot\" style=\"font-size: 20px;\">$<span id=\"sppricenewquik\">" + ds.Tables[0].Rows[0]["ProdPrice"].ToString() + "</span> per " + ds.Tables[0].Rows[0]["unity"].ToString() + "</span>";
        }
        else
        {
            str += "<span class=\"sr-only\">Regular price</span>";
            str += "<span class=\"regular-price\" style=\"font-size: 20px;\">$<span id=\"sppricequik\">" + ds.Tables[0].Rows[0]["ProdPrice"].ToString() + "</span> </span>";
            str += "<span class=\"sr-only\">Price</span>";
            str += "<span itemprop=\"price\" class=\"price price-sale\" style=\"font-size: 20px;\">$<span id=\"spdispricequik\">" + ds.Tables[0].Rows[0]["DiscountPrice"].ToString() + "</span>  per " + ds.Tables[0].Rows[0]["unity"].ToString() + "</span>";
        }
        str += " </div>";
        str += "<div class=\"product-price-and-shipping pt-1\">";

        string rdoid = "0";
        DataSet dsr = gdata.getItemMainGroup(prodID, "radio");

        if (dsr.Tables[0].Rows.Count > 0)
        {
            bool rdoidAdd = false;
            for (int i = 0; i < dsr.Tables[0].Rows.Count; i++)
            {
                str += "<span id=\"lblRadio\" style=\"display: none;\" >No</span> ";
                str += "<p>";
                str += "<h6 class=\"control-label\" style=\"font-size: 15px;\">" + dsr.Tables[0].Rows[i]["groupname"].ToString() + " </h6>";
                str += "</p>";
                str += " <div>";
                DataSet dsi = gdata.getItemAttribute(prodID, dsr.Tables[0].Rows[i]["id_attribute_group"].ToString());
                if (dsi.Tables[0].Rows.Count > 0)
                {
                    string raddefault = "";
                    if (dsi.Tables[1].Rows.Count > 0)
                    {
                        raddefault = dsi.Tables[1].Rows[0]["id_attribute"].ToString();
                    }
                    bool firstRadioChecked = false;
                    for (int j = 0; j < dsi.Tables[0].Rows.Count; j++)
                    {
                        if (rdoidAdd == false)
                        {
                            if (j == 0)
                            {
                                rdoid = dsi.Tables[0].Rows[j]["id_attribute"].ToString();
                            }
                            else
                            {
                                rdoid += "," + dsi.Tables[0].Rows[j]["id_attribute"].ToString();
                            }
                            rdoidAdd = true;
                        }
                        else
                        {
                            if (j == 0)
                            {
                                rdoid += "," + dsi.Tables[0].Rows[j]["id_attribute"].ToString();
                            }
                            else
                            {
                                rdoid += "," + dsi.Tables[0].Rows[j]["id_attribute"].ToString();
                            }
                        }
                        if (raddefault != "")
                        {
                            if (raddefault.Trim() == dsi.Tables[0].Rows[j]["id_attribute"].ToString().Trim())
                            {
                                str += " <label>";
                                str += "<input checked=\"checked\" type=\"radio\" id=\"rdoquik" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdoquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";
                            }
                            else
                            {
                                str += " <label>";
                                str += "<input  type=\"radio\" id=\"rdoquik" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdoquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";
                            }
                        }
                        else
                        {
                            if (firstRadioChecked == false)
                            {
                                str += " <label>";
                                str += "<input checked=\"checked\" type=\"radio\" id=\"rdoquik" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdoquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";

                                firstRadioChecked = true;
                            }
                            else
                            {
                                str += " <label>";
                                str += "<input  type=\"radio\" id=\"rdoquik" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdoquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";
                            }
                        }



                        //if (dsi.Tables[0].Rows[j]["attributename"].ToString() == "Checker Cutting")
                        //{
                        //    str += "<span id=\"lblCheckerCuttingVal\" style=\"display: none;\" >" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "</span> ";
                        //    str += " <label>";
                        //    str += "<input checked=\"checked\" type =\"radio\" id=\"rdo" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdo" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";
                        //}
                        //else
                        //{
                        //    str += " <label>";
                        //    str += "<input checked=\"checked\" type=\"radio\" id=\"rdo" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\"  name=\"rdo" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" value=\"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\">" + dsi.Tables[0].Rows[j]["attributename"].ToString() + " &nbsp; &nbsp; &nbsp;</label>";
                        //}




                        //str += "<label class=\"radio-inline mr-2\">";
                        //str += "<span class=\"custom-radio mr-0\" style=\"margin-top: -5px;\">";
                        //str += "<input name=\"checker-cutting\" type=\"radio\" value=\"1\">";
                        //str += "<span></span>";
                        //str += "</span>";
                        //str += ""+dsi.Tables[0].Rows[j]["attributename"].ToString()+"";
                        //str += "</label>";
                    }
                }
                str += "</div>";
            }
        }
        str += "<span id=\"rdoDataquik\" style=\"display: none; \">" + rdoid + "</span>";
        str += " </div>";
        str += "<div class=\"product-information\">";
        str += "<div class=\"product-actions pt-0\">";
        str += "<form action=\"#\" method=\"post\" id=\"add-to-cart-or-refresh\">";
        str += "<input type=\"hidden\" name=\"token\" value=\"3b8dc4acde28257687abb3d4ddf26fc2\">";
        str += "<input type=\"hidden\" name=\"id_product\" value=\"17\" id=\"product_page_product_id\">";
        str += "<input type=\"hidden\" name=\"id_customization\" value=\"0\" id=\"product_customization_id\">";


        string selectId = "0";
        dsr = gdata.getItemMainGroup(prodID, "select");
        if (dsr.Tables[0].Rows.Count > 0)
        {
            str += "<div class=\"product-variants\">";
            str += "<div class=\"clearfix product-variants-item\" style=\"margin-top: 5px;\">";
            for (int i = 0; i < dsr.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                    selectId = dsr.Tables[0].Rows[i]["id_attribute_group"].ToString();
                else
                    selectId += "," + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString();
                str += "<span class=\"control-label mb-0\">" + dsr.Tables[0].Rows[i]["groupname"].ToString() + "</span>";
                str += "<select id=\"drpquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\" class=\"form-control-select classic\" name=\"group[3]\" style=\"width: 228px\">";
                DataSet dsi = gdata.getItemAttribute(prodID, dsr.Tables[0].Rows[i]["id_attribute_group"].ToString());
                if (dsi.Tables[0].Rows.Count > 0)
                {
                    string dd = dsi.Tables[1].Rows[0]["id_attribute"].ToString();
                    string aaaid = dsi.Tables[1].Rows[0]["id_attribute_group"].ToString();
                    for (int j = 0; j < dsi.Tables[0].Rows.Count; j++)
                    {
                        if (dd == dsi.Tables[0].Rows[j]["id_attribute"].ToString())
                        {
                            str += "<option selected value = \"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" title=\"40x60cm\" >" + dsi.Tables[0].Rows[j]["attributename"].ToString() + "</option>";
                        }
                        else
                        {
                            str += "<option value = \"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" title=\"40x60cm\" >" + dsi.Tables[0].Rows[j]["attributename"].ToString() + "</option>";
                        }
                    }
                }
                str += " </select>";
            }

            str += " </div>";
            str += " </div>";
        }

        str += "<span id=\"selectDataquik\" style=\"display: none; \">" + selectId + "</span>";




        //str += "<div class=\"product-variants\">";
        //str += "<div class=\"clearfix product-variants-item\" style=\"margin-top: 5px;\">";
        //str += "<span class=\"control-label mb-0\">Color</span>";
        //str += "<select class=\"form-control-select classic\" name=\"group[3]\" style=\"width: 228px\">";
        //str += "<option value = \"19\" title=\"40x60cm\" selected=\"selected\">Purple</option>";
        //str += " </select>";
        //str += " </div>";
        //str += " </div>";

        str += "  <input type='hidden' id='IsStockAllow' value='" + ds.Tables[0].Rows[0]["IsStockAllow"].ToString() + "'  /> ";
        str += "  <input type='hidden' id='stockQty' value='" + ds.Tables[0].Rows[0]["StockQty"].ToString() + "'  /> ";

        str += "<section class=\"product-discounts\">";
        str += " </section>";
        str += " <div class=\"product-add-to-cart\">";
        str += "<span class=\"control-label\">Quantity</span>";
        str += " <div class=\"notoutofstockdiv\">";
        str += " <div class=\"#\"  style=\"width:120px; float: left;\">";
        #region out of stock
        if (ds.Tables[0].Rows[0]["StockStatus"].ToString().Trim() != "OutOfStock")
        {
            str += "<a href=\"javaScript:void(0)\" onclick=\"removeQty();\" class=\"btn btn-primary\" style=\"width:24px; float: left; margin-right:5px;\">-</a> &nbsp;";

            str += "<input type = \"text\" name = \"Qty\" id = \"Qty\" value = \'" + ds.Tables[0].Rows[0]["minimal_quantity"].ToString() + "\'  class=\"form-control\" min=\'" + ds.Tables[0].Rows[0]["minimal_quantity"].ToString() + "\' onchange=\"cartQtyChange();\" style=\"width:50px; float: left; padding: 8px 5px 8px 5px;\"   />";

            str += " <a href=\"javaScript:void(0)\" onclick=\"addQtyPlus();\" class=\"btn btn-primary\" style=\"width:24px; float: left;\">+</a>";
            str += "</div>";
            str += "<div class=\"add\">";
            str += "<a href=\"#\" class=\"btn btn-primary add-to-cart\" data-button-action=\"add-to-cart\" onclick=\"addToCart();\">";
            str += "<i class=\"material-icons shopping-cart\">&#xE547;</i>";
            str += " Add to cart";
            str += "  </a>";
            str += " </div>";
            str += "  </div>";
            str += "<div class=\"row\">&nbsp;</div>";
            str += "<div class=\"row\">";
            str += " <div class=\"col-md-12\" style=\"padding-top: 1px;\">";
            str += "<p class=\"notoutofstockdiv\">The minimum purchase order quanitity of the product is <span id=\"minQty\">" + ds.Tables[0].Rows[0]["minimal_quantity"].ToString() + " </span>&nbsp;" + ds.Tables[0].Rows[0]["unity"].ToString() + "</p>";
        }
        #endregion
        str += "</div>";
        str += "</div>";

        str += " <span id=\"product-availability\" ></ span >";
        str += "<p class=\"product-minimal-quantity\">";
        str += "</p>";
        str += " </div>";
        str += " <div class=\"product-additional-info\">";
        str += "<p class=\"panel-product-line panel-product-actions\">";
        //str += " <a id=\"wishlist_button\" href=\"#\" onclick=\"WishlistCart('wishlist_block_list', 'add', '17', $('#idCombination').val(), document.getElementById('quantity_wanted').value); return false;\" rel=\"nofollow\" title=\"Add to my wishlist\">";
        str += " <a id=\"" + ds.Tables[0].Rows[0]["minimal_quantity"].ToString() + "\" href=\"javaScript:void(0);\" onclick=\"addWishList(" + ds.Tables[0].Rows[0]["ProdID"].ToString() + ");\" title=\"Add to my wishlist\">";
        str += "<i class=\"icon-heart\"></i>Add to wishlist";
        str += "</a>";
        str += "</p>";
        str += " <div class=\"clearfix\"></div>";
        str += " <div id=\"product_comments_block_extra\" class=\"no-print\" itemprop=\"aggregateRating\" itemscope itemtype=\"#\" >";
        str += "<div class=\"comments_note clearfix\">";
        str += "<span>Rating&nbsp;</span>";
        str += "<div class=\"star_content clearfix\">";
        string ddd = BindStar(ds.Tables[0].Rows[0]["Rating"].ToString());
        str += ddd;
        //str += " <div class=\"star star_on\"></div>";
        //str += "<div class=\"star star_on\"></div>";
        //str += "<div class=\"star star_on\"></div>";
        //str += "<div class=\"star star_on\"></div>";
        //str += " <div class=\"star star_on\"></div>";
        //str += "<meta itemprop=\"worstRating\" content=\"0\" />";
        //str += "<meta itemprop=\"ratingValue\" content=\"5\" />";
        //str += "<meta itemprop=\"bestRating\" content=\"5\" />";
        str += "</div>";
        str += "</div>";
        str += "<ul class=\"comments_advices\">";
        str += "<li>";
        str += "<a href= \'" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "\' class=\"reviews\">Read reviews(<span itemprop = \"reviewCount\" >" + ds.Tables[0].Rows[0]["ReviewCount"].ToString() + "</span>)";
        str += "</a>";
        str += "</li>";
        //str += "<li>";
        //str += "<a class=\"open-comment-form\">Write a review";
        //str += "</a>";DetailUrl
        //str += "</li>";
        str += " </ul>";
        str += "</div>";
        str += " <div style=\"padding-top: 5px;\" >";
        str += "<div class=\"clearfix\"></div>";
        str += " <div id=\"product_comments_block_tab\" >";
        str += " <p class=\"align_center\" style=\"padding-top: 5px;\">";
        str += "<a id=\"new_comment_tab_btn\" class=\"open-comment-form1 btn btn-secondary add-to-cart EnqNotifyDiv\" data-toggle=\"modal\" data-target=\"#custEnquiryModel\" ng-click=\"custProdEnquiryModel(" + prodID + ")\" style=\"padding: 0px 10px;\">Enquire About This Product</a>";
        str += "</p>";
        str += "</div>";
        str += "<div class=\"container\">";
        str += "<div class=\"modal fade\" id=\"myModal1\" role=\"dialog\">";
        str += "<div class=\"modal-dialog\">";
        str += "<!-- Modal content-->";
        str += "<div class=\"modal-content\">";
        str += "<div class=\"modal-body\">";
        str += "<div id=\"new_comment_form\" >";
        str += "<form id=\"id_new_comment_form\" action=\"#\">";
        str += "<h2 class=\"title\">How can I contact you?</h2>";
        str += "<div class=\"row\">";
        str += " <div class=\"product clearfix col-xs-12 col-sm-12	\">";
        str += " <div class=\"product_desc\">";
        str += " <p class=\"product_name\">Pink Tourmaline Carved Fancy Shape Gemstone - Stone Name - Pink Tourmaline</p>";
        str += "</div>";
        str += "</div>";
        str += "</div>";
        str += " <div class=\"row\">";
        str += " <div class=\"product clearfix col-xs-12 col-sm-6\">";
        str += "<img src=\"modules/products/lavender-jade-color-silver-rosary-chain.jpg\" alt=\"Pink Tourmaline Carved Fancy Shape Gemstone - Stone Name - Pink Tourmaline\" />";
        str += " </div>";
        str += "<div class=\"new_comment_form_content col-xs-12 col-sm-6\">";
        str += "<label class=\"mt-0\">Customer Name<sup class=\"required\">*</sup></label>";
        str += "<input id=\"commentCustomerName\" name=\"customer_name\" type=\"text\" value=\"\" />";
        str += "<label>Customer Email<sup class=\"required\">*</sup></label>";
        str += " <input id=\"commentCustomerName\" name=\"customer_email\" type=\"text\" value=\"\" />";
        str += "<label for=\"content\">Message<sup class=\"required\">*</sup></label>";
        str += " <textarea id=\"content\" name=\"content\"></textarea>";
        str += " <div id=\"new_comment_form_footer\" >";
        str += "<input id=\"id_product_comment_send\" name=\"id_product\" type=\"hidden\" value='17' />";
        str += "<p class=\"fl required\" style=\"margin-bottom: 10px;\"><sup>*</sup> Required fields</p>";
        str += "<p class=\"fr\">";
        str += "<button id=\"submitNewMessage\" class=\"btn btn-secondary\" name=\"submitMessage\" type=\"submit\">Send</button>";
        str += " &nbsp;";
        str += " or&nbsp;";
        str += "<button type = \"button\" class=\"closefb btn btn-secondary\" data-dismiss=\"modal\" aria-label=\"Close\">";
        str += "<span aria-hidden=\"true\">Cancel</span>";
        str += " </button>";
        str += "</p>";
        str += "<div class=\"clearfix\"></div>";
        str += "</div>";
        str += "</div>";
        str += " </div>";
        str += " </form>";
        str += " </div>";
        str += " </div>";
        str += " </div>";
        str += " </div>";
        str += "</div>";
        str += " </div>";
        str += " </div>";
        str += "<div class=\"social-sharing\">";
        str += " <span>Share</span>";
        str += " <ul>";
        //str += " <li class=\"email\"><a href = \"#\" title=\"Email Share\" target=\"_blank\" class=\"ion-email\">Email Share</a></li>";

        str += " <li class=\"email\"><a data-toggle=\"modal\" data-target=\"#shareprodonemail\" ng-click=\"shareprodonemail(" + prodID + ")\" title=\"Email Share\" target=\"_blank\" class=\"ion-email\">Email Share</a></li>";

        //str += "<li class=\"whatsapp\"><a href = \"#\" title=\"Whatsapp Share\" target=\"_blank\" class=\"ion-social-whatsapp\">Whatsapp Share</a></li>";
        //str += "<li class=\"facebook\"><a href = \"#\" title=\"Share\" target=\"_blank\">Share</a></li>";

        str += "<li class=\"whatsapp\"><a href = \"https://api.whatsapp.com/send?text=https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "\" title=\"Whatsapp Share\" target=\"_blank\" class=\"ion-social-whatsapp\">Whatsapp Share</a></li>";
        str += "<li class=\"facebook\"><a onclick=\"socialWindow('https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "','fb');\" title=\"Share\" target=\"_blank\">Share</a></li>";
        str += " <li class=\"twitter\"><a onclick=\"socialWindow('https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "','twitter');\" title=\"Tweet\" target=\"_blank\">Tweet</a></li>";
        str += "<li class=\"pinterest\"><a onclick=\"socialWindow('https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "','pinterest');\" title=\"Pinterest\" target=\"_blank\">Pinterest</a></li>";
        str += " </ul>";
        str += " </div>";
        str += " </div>";
        str += "</form>";
        str += "</div>";
        str += " </div>";
        str += "</div>";
        str += " </div>";
        str += "</div>";
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string custProdEnquiryModel(string prodID)
    {
        GetData data = new GetData();
        Data dat = new Data();
        DataSet ds = data.getDetail(prodID);
        DataSet dsImg = data.getItemImages(ds.Tables[0].Rows[0]["id_product"].ToString());
        string str = "<div class=\"product_desc\">";
        str += "<span id=\"disprice\" style=\"display: none; \">" + ds.Tables[0].Rows[0]["DiscountPrice"].ToString() + "</span>";
        str += "<span id=\"rprice\" style=\"display: none;\" >" + ds.Tables[0].Rows[0]["ProdPrice"].ToString() + "</span> ";
        str += "<span id=\"lblImg\" style=\"display: none; \">" + dsImg.Tables[0].Rows[0]["bigimg"].ToString() + "</span>";
        str += "<span id=\"lblProdId\" style=\"display: none; \">" + prodID + "</span>";
        str += "<span id=\"productName\" style=\"display: none; \">" + ds.Tables[0].Rows[0]["ProdName"].ToString() + "</span>";
        str += "<p class=\"product_name\" id=\"ProdName\">";
        str += " <strong> " + ds.Tables[0].Rows[0]["ProdName"].ToString() + " </strong></p>";
        str += " </div> ";
        str += "<img class=\"\" style=\"width: 100%;\" src=\"" + dsImg.Tables[0].Rows[0]["bigimg"].ToString().TrimEnd() + "\" />";

        string stremail = "<div class=\"product_desc\">";
        stremail += "<span id=\"lblImg\" style=\"display:none;\"></span>";
        stremail += "<p class=\"product_name\" id=\"ProdName\">";
        stremail += "<strong>";
        stremail += "<asp:Label ID=\"lblCusrProdNameCustEmail\"  style=\"display: none; \">" + ds.Tables[0].Rows[0]["ProdName"].ToString() + "</asp:Label>";
        stremail += "</strong>";
        stremail += "</p>";
        stremail += "</div>";
        stremail += "<img class=\"\" style=\"width: 100%;\" src=\"" + dsImg.Tables[0].Rows[0]["bigimg"].ToString().TrimEnd() + "\" style=\"display: none; \" />";
        return str + "^" + stremail;
    }

    [WebMethod(EnableSession = true)]
    public string BeindSuccessModal(string prodID, string AttriID, string url)
    {
        DataTable dtt = getCarttbl();
        string[] aa = prodID.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        prodID = bb[0].ToString();

        DataTable tblFiltered = dtt.AsEnumerable()
                             .Where(r => r.Field<string>("ProdID") == prodID && r.Field<string>("AttributeID") == AttriID)
                             .CopyToDataTable();



        GetData data = new GetData();
        Data dat = new Data();
        DataSet ds = data.getDetail(prodID);
        DataSet dsImg = data.getItemImages(ds.Tables[0].Rows[0]["id_product"].ToString());
        string str = "<div class=\"row\">";
        //Image Model Div New Design 
        #region First
        str += "<div class=\"col-md-6\" style=\"border-right:1px dotted #CCC;\">";
        str += "<h1 class=\"h1\" itemprop=\"name\" style=\"color:#6CD1BB;\">";
        str += " <i class=\"fa fa-check\"></i> Product successfully added to your shopping cart</h1> ";
        str += "<div class=\"left_vertical mt-1\">";
        str += "<div class=\"product-view_content\">";
        str += "<div class=\"\">";
        str += "<div class=\"slick-list draggable\">";
        str += "<div class=\"slick-track\">";
        str += "<div >";
        str += "<img class=\"\" style=\"width: 100%; max-width:250px;\" src=\"" + tblFiltered.Rows[0]["Image1"].ToString().TrimEnd() + "\"  />";
        str += "</div>";
        str += " </div>";
        str += "</div>";
        str += "</div>";
        str += " </div>";
        str += "</div>";

        str += " <div style=\"font-size:16px;\">";
        str += "<h6> " + tblFiltered.Rows[0]["ProdName"].ToString().TrimEnd() + " </h6>";
        str += "<p><strong> " + tblFiltered.Rows[0]["Attribute"].ToString().TrimEnd() + " </strong> </p>";
        str += "<p> <strong>Quantity :</strong> " + tblFiltered.Rows[0]["Qty"].ToString().TrimEnd() + " </p>";
        str += "<p> <strong>Total : </strong>$ " + tblFiltered.Rows[0]["Amount"].ToString().TrimEnd() + " </p>";
        str += "</div>";
        str += "</div>";
        #endregion
        #region Second
        str += "<div class=\"col-md-6\">";
        str += "<div class=\"content_info\">";
        str += " <h1 class=\"h1\">There are <span style=\"color:#6CD1BB;\">" + dtt.Rows[0]["TotalCount"].ToString().TrimEnd() + "</span> items in your cart.</h1>";
        str += "  <div class=\"product-price-and-shipping mt-1\" style=\"font-size:16px;\">";
        str += " <p class=\"pt-1\"><strong>Total products :</strong>  " + dtt.Rows[0]["TotalCount"].ToString().TrimEnd() + " </p>";
        //str += " <p class=\"pt-1\"><strong>Wrapping</strong> $2.00</p>";
        //str += " <p class=\"pt-1\"><strong>Total shipping :</strong> " + dtt.Rows[0]["Shipping"].ToString().TrimEnd() + "</p>";
        str += " <p class=\"pt-1\"><strong>Total amount :</strong> $ " + dtt.Rows[0]["TotalAmount"].ToString().TrimEnd() + "</p>";
        str += "</div>";
        str += " <div class=\"product-price-and-shipping mt-3\">";
        str += " <a href=\"" + url + "\" id=\"new_comment_tab_btn\" class=\"open-comment-form1 btn btn-secondary add-to-cart\">CONTINUE SHOPPING </a>  &nbsp;";
        str += " <a href=\"/ShoppingCart.aspx\" id =\"new_comment_tab_btn\" class=\"open-comment-form1 btn btn-secondary add-to-cart mt10\">PROCEED TO CHECKOUT</a>  &nbsp;";
        str += "</div>";

        str += "  <div class=\"product-information\">";
        str += "  <div class=\"product-actions pt-0\">";
        str += "</div>";
        str += "</div>";

        str += "</div>";
        str += "</div>";
        #endregion

        str += "</div>";

        return str;
    }

    [WebMethod(EnableSession = true)]
    public DataTable getCarttbl()
    {
        double shipamount = 0.00;
        string UserID = "0";
        string cartID = "0";
        decimal Amount = 0;
        Data dat = new Data();
        DataTable tbl = new DataTable();

        tbl.Columns.Add("ProdID", typeof(string));
        tbl.Columns.Add("AttributeID", typeof(string));
        tbl.Columns.Add("Attribute", typeof(string));
        tbl.Columns.Add("SKU", typeof(string));
        tbl.Columns.Add("Qty", typeof(Int32));
        tbl.Columns.Add("Price", typeof(decimal));
        tbl.Columns.Add("DisPrice", typeof(decimal));
        tbl.Columns.Add("Amount", typeof(decimal));
        tbl.Columns.Add("TotalAmount", typeof(decimal));
        tbl.Columns.Add("TotalCount", typeof(double));
        tbl.Columns.Add("Image1", typeof(string));
        tbl.Columns.Add("ProdName", typeof(string));
        tbl.Columns.Add("Shipping", typeof(decimal));
        tbl.Columns.Add("NetAmount", typeof(decimal));
        tbl.Columns.Add("GrossAmount", typeof(decimal));
        tbl.Columns.Add("Name", typeof(string));
        tbl.Columns.Add("Flat", typeof(string));
        tbl.Columns.Add("Address", typeof(string));
        tbl.Columns.Add("Locality", typeof(string));
        tbl.Columns.Add("FreeItem", typeof(string));
        tbl.Columns.Add("Pincode", typeof(string));
        tbl.Columns.Add("ShipID", typeof(string));
        tbl.Columns.Add("EmailID", typeof(string));
        tbl.Columns.Add("MobileNo", typeof(string));
        tbl.Columns.Add("DiscountType", typeof(string));
        tbl.Columns.Add("CouponDiscount", typeof(decimal));
        tbl.Columns.Add("DiscountCode", typeof(string));


        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
            try
            {
                string shipamount1 = data.getDataSet("select zon.Ship_Amt from ps_address ad inner join ps_country con on ad.id_country=con.id_country inner join ps_zone zon on con.id_zone=zon.id_zone where id_customer=" + UserID + "").Tables[0].Rows[0]["Ship_Amt"].ToString();
                if (shipamount1 != "")
                {
                    shipamount = Convert.ToDouble(shipamount1);
                }
            }
            catch
            {
                shipamount = 0;
            }
        }

        if (HttpContext.Current.Request.Cookies["cartSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
            cartID = user.Values["cartID"].ToString();
        }
        DataSet dsn = new DataSet();
        //DataSet dsn = dat.getDataSet("select  cp.*,pa.reference,pl.name,pa.price+prod.price as price, prod.ImgURL1 as URL from ps_cart_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category where cp.id_cart = " + cartID + " and pl.id_lang = 1 and cat.id_lang = 1");
        dsn = gdat.GetAddToCartDetail(cartID);
        tbl.Rows.Clear();
        for (int i = 0; i < dsn.Tables[0].Rows.Count; i++)
        {
            DataRow dtrow = tbl.NewRow();
            dtrow["ProdID"] = dsn.Tables[0].Rows[i]["id_product"].ToString();
            dtrow["AttributeID"] = dsn.Tables[0].Rows[i]["id_product_attribute"].ToString();
            dtrow["Qty"] = Convert.ToInt32(dsn.Tables[0].Rows[i]["quantity"].ToString());
            dtrow["SKU"] = dsn.Tables[0].Rows[i]["reference"].ToString();
            dtrow["Price"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
            dtrow["DisPrice"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["DiscountPrice"].ToString()));
            Amount = Convert.ToDecimal(dsn.Tables[0].Rows[i]["DiscountPrice"].ToString()) * (Convert.ToDecimal(dsn.Tables[0].Rows[i]["quantity"].ToString()));
            dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
            dtrow["Image1"] = dsn.Tables[0].Rows[i]["URL"].ToString();
            dtrow["ProdName"] = dsn.Tables[0].Rows[i]["name"].ToString();

            DataSet dsA = data.getDataSet("select distinct ag.position, agl.name as groupname, alm.name as attributename from ps_product prod  inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute  inner join ps_attribute_lang alm on pac.id_attribute=alm.id_attribute inner join ps_attribute at on alm.id_attribute=at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group=agl.id_attribute_group inner join ps_attribute_group ag on agl.id_attribute_group=ag.id_attribute_group where prod.id_product = " + dsn.Tables[0].Rows[i]["id_product"].ToString() + " and pa.id_product_attribute = " + dsn.Tables[0].Rows[i]["id_product_attribute"].ToString() + "  and prod.active = 1 and alm.id_lang = 1 and agl.id_lang = 1 order by ag.position");
            if (dsA.Tables[0].Rows.Count > 0)
            {
                string att = "";
                for (int j = 0; j < dsA.Tables[0].Rows.Count; j++)
                {
                    if (j == 0)
                        att = dsA.Tables[0].Rows[j]["groupname"].ToString() + " : " + dsA.Tables[0].Rows[j]["attributename"].ToString();
                    else
                        att += ", " + dsA.Tables[0].Rows[j]["groupname"].ToString() + " : " + dsA.Tables[0].Rows[j]["attributename"].ToString();
                }
                dtrow["Attribute"] = att;
            }
            tbl.Rows.Add(dtrow);
        }

        if (tbl.Rows.Count > 0)
        {
            tbl.Rows[0]["TotalAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", "").ToString())));
            tbl.Rows[0]["TotalCount"] = Convert.ToDouble(tbl.Compute("SUM(Qty)", "").ToString());
            if (Convert.ToDouble(tbl.Compute("SUM(Amount)", "")) < 300)
            {
                tbl.Rows[0]["Shipping"] = shipamount;
                tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", "")) + shipamount));
            }
            else
            {
                tbl.Rows[0]["Shipping"] = "0";
                tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", ""))));
            }

            //if (tbl.Rows[0]["DiscountType"].ToString() != "")
            //{
            //    tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", ((Convert.ToDecimal(tbl.Rows[0]["NetAmount"].ToString())) - (Convert.ToDecimal(tbl.Rows[0]["CouponDiscount"].ToString()))));
            //}
            //else
            //{
            //    tbl.Rows[0]["CouponDiscount"] = "0.00";
            //}
        }

        return tbl;
    }

    [WebMethod(EnableSession = true)]
    public string paymentPayPal()
    {
        string jsonstring1 = string.Empty;
        double TotAmtt = 0;
        double discount = 0;
        string UserID = "0";
        double shipamount = 0.00;
        string cartID = "0";
        decimal Amount = 0;
        Data dat = new Data();
        DataTable tbl = new DataTable();

        tbl.Columns.Add("ProdID", typeof(string));
        tbl.Columns.Add("AttributeID", typeof(string));
        tbl.Columns.Add("Attribute", typeof(string));
        tbl.Columns.Add("SKU", typeof(string));
        tbl.Columns.Add("Qty", typeof(Int32));
        tbl.Columns.Add("Price", typeof(decimal));
        tbl.Columns.Add("DisPrice", typeof(decimal));
        tbl.Columns.Add("Amount", typeof(decimal));
        tbl.Columns.Add("TotalAmount", typeof(decimal));
        tbl.Columns.Add("TotalCount", typeof(double));
        tbl.Columns.Add("Image1", typeof(string));
        tbl.Columns.Add("ProdName", typeof(string));
        tbl.Columns.Add("Shipping", typeof(decimal));
        tbl.Columns.Add("NetAmount", typeof(decimal));
        tbl.Columns.Add("GrossAmount", typeof(decimal));
        tbl.Columns.Add("Name", typeof(string));
        tbl.Columns.Add("Flat", typeof(string));
        tbl.Columns.Add("Address", typeof(string));
        tbl.Columns.Add("Locality", typeof(string));
        tbl.Columns.Add("FreeItem", typeof(string));
        tbl.Columns.Add("Pincode", typeof(string));
        tbl.Columns.Add("ShipID", typeof(string));
        tbl.Columns.Add("EmailID", typeof(string));
        tbl.Columns.Add("MobileNo", typeof(string));
        tbl.Columns.Add("DiscountType", typeof(string));
        tbl.Columns.Add("CouponDiscount", typeof(decimal));
        tbl.Columns.Add("DiscountCode", typeof(string));

        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
            string shipamount1 = data.getDataSet("select zon.Ship_Amt from ps_address ad inner join ps_country con on ad.id_country=con.id_country inner join ps_zone zon on con.id_zone=zon.id_zone where id_customer=" + UserID + "").Tables[0].Rows[0]["Ship_Amt"].ToString();
            if (shipamount1 != "")
            {
                shipamount = Convert.ToDouble(shipamount1);
            }
        }

        if (HttpContext.Current.Request.Cookies["cartSG"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["cartSG"];
            cartID = user.Values["cartID"].ToString();
        }
        string qqq = "";

        qqq = "select  cp.*,pa.reference,pl.name,pa.price+prod.price as price, prod.ImgURL1 as URL,prod.minimal_quantity, cart.gift, ";

        qqq += " REPLACE(REPLACE(cat.link_rewrite,' ','-'),'/-','')+'/'+cast(prod.id_product as nvarchar(50))+'-'+  + ISNULL(REPLACE(pl.link_rewrite, ' ', '-'), '') + '.html' as DetailUrl,";
        //calculate discountprice
        qqq += "  cast(cast((cast(prod.price as decimal(18,2))- (case when (select top(1) isnull(reduction,0)  ";
        qqq += " from ps_specific_price  as  sp where  sp.IsDeleted = 0 and id_product=prod.id_product) is null then 0 else  ";
        qqq += " (((select top(1) isnull(sp.reduction,0) from ps_specific_price as  sp where  sp.IsDeleted = 0 and ";
        qqq += " sp.id_product=prod.id_product))*cast(prod.price as decimal(18,2))) end) / 100) as decimal(18,2)) + pa.price as decimal(18,2))   as DiscountPrice ";
        qqq += " , cart.id_address_delivery as AddId ";

        qqq += " from ps_cart_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category inner join ps_cart cart on cp.id_cart=cart.id_cart ";
        qqq += " where  pl.id_lang = 1 and cat.id_lang = 1 ";
        if (cartID != "0")
        {
            qqq += " and cp.id_cart = " + cartID + "";
        }

        DataSet dsn = new DataSet();
        dsn = dat.getDataSet(qqq);
        //DataSet dsn = dat.getDataSet("select  cp.*,pa.reference,pl.name,pa.price+prod.price as price, prod.ImgURL1 as URL, pc.gift from ps_cart_product cp inner join ps_product_lang pl on cp.id_product = pl.id_product inner join ps_product_attribute pa on cp.id_product_attribute = pa.id_product_attribute and cp.id_product = pa.id_product inner join ps_product prod on pl.id_product = prod.id_product inner join ps_category_lang cat on prod.id_category_default = cat.id_category left outer join ps_cart as pc on pc.id_cart = cp.id_cart where cp.id_cart = " + cartID + " and pl.id_lang = 1 and cat.id_lang = 1");


        if (dsn.Tables[0].Rows.Count > 0)
        {
            //calculate shipping amount
            if (UserID != "" && UserID != "0")
            {
                if (dsn.Tables[0].Rows[0]["AddId"].ToString() != "" && dsn.Tables[0].Rows[0]["AddId"].ToString() != null)
                {
                    string addidd = dsn.Tables[0].Rows[0]["AddId"].ToString();
                    try
                    {
                        dsSA = gdat.GetShipingAmt(UserID, addidd);
                        if (dsSA.Tables[0].Rows.Count > 0)
                        {
                            string Ship_Amt = dsSA.Tables[0].Rows[0]["Ship_Amt"].ToString();
                            string MinShipAMt = dsSA.Tables[0].Rows[0]["MinShip_Amt"].ToString();
                            if (Ship_Amt != "" || Ship_Amt != "0")
                            {
                                shipamount = Convert.ToDouble(Ship_Amt);
                            }

                            if (MinShipAMt != "" || MinShipAMt != "0")
                            {
                                FreeShippingAmt = Convert.ToDouble(MinShipAMt);
                            }
                        }
                        //shipamount = data.getDataSet("select zon.Ship_Amt, zon.MinShip_Amt from ps_address ad inner join ps_country con on ad.id_country=con.id_country inner join ps_zone zon on con.id_zone=zon.id_zone where zon.active = 1 and  id_customer=" + UserID + " and ad.id_address=" + addidd + "").Tables[0].Rows[0]["Ship_Amt"].ToString();
                    }
                    catch
                    {
                        shipamount = 100;
                    }
                }
            }
        }


        tbl.Rows.Clear();
        for (int i = 0; i < dsn.Tables[0].Rows.Count; i++)
        {
            DataRow dtrow = tbl.NewRow();
            dtrow["ProdID"] = dsn.Tables[0].Rows[i]["id_product"].ToString();
            dtrow["AttributeID"] = dsn.Tables[0].Rows[i]["id_product_attribute"].ToString();
            dtrow["Qty"] = Convert.ToInt32(dsn.Tables[0].Rows[i]["quantity"].ToString());
            dtrow["SKU"] = dsn.Tables[0].Rows[i]["reference"].ToString();
            dtrow["Price"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["price"].ToString()));
            dtrow["DisPrice"] = string.Format("{0:0.00}", (dsn.Tables[0].Rows[i]["DiscountPrice"].ToString()));
            Amount = Convert.ToDecimal(dsn.Tables[0].Rows[i]["DiscountPrice"].ToString()) * (Convert.ToDecimal(dsn.Tables[0].Rows[i]["quantity"].ToString()));
            dtrow["Amount"] = string.Format("{0:0.00}", (Amount));
            dtrow["Image1"] = dsn.Tables[0].Rows[i]["URL"].ToString();
            dtrow["ProdName"] = dsn.Tables[0].Rows[i]["name"].ToString();
            DataSet dsA = data.getDataSet("select distinct ag.position, agl.name as groupname, alm.name as attributename from ps_product prod  inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute  inner join ps_attribute_lang alm on pac.id_attribute=alm.id_attribute inner join ps_attribute at on alm.id_attribute=at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group=agl.id_attribute_group inner join ps_attribute_group ag on agl.id_attribute_group=ag.id_attribute_group where prod.id_product = " + dsn.Tables[0].Rows[i]["id_product"].ToString() + " and pa.id_product_attribute = " + dsn.Tables[0].Rows[i]["id_product_attribute"].ToString() + "  and prod.active = 1 and alm.id_lang = 1 and agl.id_lang = 1 order by ag.position");
            if (dsA.Tables[0].Rows.Count > 0)
            {
                string att = "";
                for (int j = 0; j < dsA.Tables[0].Rows.Count; j++)
                {
                    if (j == 0)
                        att = dsA.Tables[0].Rows[j]["groupname"].ToString() + " : " + dsA.Tables[0].Rows[j]["attributename"].ToString();
                    else
                        att += ", " + dsA.Tables[0].Rows[j]["groupname"].ToString() + " : " + dsA.Tables[0].Rows[j]["attributename"].ToString();
                }
                dtrow["Attribute"] = att;
            }
            tbl.Rows.Add(dtrow);
        }

        if (tbl.Rows.Count > 0)
        {
            double netAmount = 0;
            double TttolAmt = Convert.ToDouble(tbl.Compute("SUM(Amount)", "").ToString());
            tbl.Rows[0]["TotalAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", "").ToString())));
            tbl.Rows[0]["TotalCount"] = Convert.ToDouble(tbl.Compute("SUM(Qty)", "").ToString());
            if (TttolAmt > FreeShippingAmt)
            {
                tbl.Rows[0]["Shipping"] = 0;
                tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", ""))));
            }
            else
            {
                tbl.Rows[0]["Shipping"] = shipamount;
                tbl.Rows[0]["NetAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", "")) + shipamount));
            }


            netAmount = Convert.ToDouble(tbl.Compute("SUM(Amount)", "")) + Convert.ToDouble(shipamount);

            double TotAmt = Convert.ToDouble(tbl.Compute("SUM(Amount)", ""));

            if (dsn.Tables[0].Rows[0]["gift"].ToString() != "0")
            {
                DataSet dsDis = new DataSet();
                dsDis = dat.getDataSet("select reduction_percent, code from ps_cart_rule where id_cart_rule=" + dsn.Tables[0].Rows[0]["gift"].ToString() + "");
                string discountPer = dsDis.Tables[0].Rows[0]["reduction_percent"].ToString();
                discount = (TotAmt * Convert.ToDouble(discountPer)) / 100;
                tbl.Rows[0]["DiscountCode"] = dsDis.Tables[0].Rows[0]["code"].ToString();
                tbl.Rows[0]["CouponDiscount"] = discount;
                netAmount = netAmount - discount;

                tbl.Rows[0]["TotalAmount"] = string.Format("{0:0.00}", (Convert.ToDouble(tbl.Compute("SUM(Amount)", "").ToString()) - discount));
            }

            //Submit Customer Payment Status
            gdat.CustPaymentStatus("", cartID);

            TotAmtt = TotAmt - discount;
            string ShippingAmt = tbl.Rows[0]["Shipping"].ToString();
            jsonstring1 = "";
            jsonstring1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=sharad@gemspacific.com&amount=" + TotAmtt + "&shipping=" + ShippingAmt + "&item_name=Gemspacific ShopCart&invoice=" + cartID + "&currency_code=USD&return=https://sniggle.in/PayPalSuccess.aspx?orderid=" + cartID + "&cancel_return=https://sniggle.in/PayPalCancel.aspx?orderid=" + cartID + "";
        }
        //jsonstring1 = "http://localhost:55246/PayPalSuccess.aspx?orderid=" + cartID + "";
        return jsonstring1;
    }


    public string BindStar(string myValue1)
    {
        string ddd = myValue1.ToString();
        string str = "";
        if (myValue1.ToString() == "5")
        {
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
        }
        if (myValue1.ToString() == "4")
        {
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_off\"></div>";
        }
        if (myValue1.ToString() == "3")
        {
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
        }
        if (myValue1.ToString() == "2")
        {
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
        }
        if (myValue1.ToString() == "1")
        {
            str += "<div class=\"star star_on\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
        }
        if (myValue1.ToString() == "0" || myValue1.ToString() == "")
        {
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
            str += "<div class=\"star star_off\"></div>";
        }
        return str;
    }

    [WebMethod(EnableSession = true)]
    public string AppLogin(string email, string name)
    {
        string str = "Success";
        if (HttpContext.Current.Request.Cookies["custSniggle"] == null)
        {
            ds = data.getDataSet("select * from ps_customer where email='" + email + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HttpCookie customer = new HttpCookie("custSniggle");
                customer.Expires = DateTime.Now.AddDays(10d);
                customer.Values.Add("id_customer", ds.Tables[0].Rows[0]["id_customer"].ToString());
                customer.Values.Add("firstname", ds.Tables[0].Rows[0]["firstname"].ToString());
                customer.Values.Add("email", ds.Tables[0].Rows[0]["email"].ToString());
                customer.Values.Add("newsletter", ds.Tables[0].Rows[0]["newsletter"].ToString());
                customer.Values.Add("lastname", ds.Tables[0].Rows[0]["lastname"].ToString());
                HttpContext.Current.Response.Cookies.Add(customer);

                ds = gdat.GetWishListId(ds.Tables[0].Rows[0]["id_customer"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HttpCookie wishList = new HttpCookie("wishlistSG");
                    wishList.Expires = DateTime.Now.AddDays(30d);
                    wishList.Values.Add("wishListID", ds.Tables[0].Rows[0]["id_wishlist"].ToString());
                    HttpContext.Current.Response.Cookies.Add(wishList);
                }
            }
            else
            {
                string query = "insert into ps_customer(id_shop_group, id_shop, id_gender, id_default_group, id_lang, id_risk, firstname, email, passwd, last_passwd_gen, newsletter, newsletter_date_add, optin, outstanding_allow_amount, show_public_prices, max_payment_days, secure_key,  active, is_guest, deleted, date_add, date_upd) values(1,1,0,3,1,0,'" + name + "','" + email + "','12345','" + DateTime.Now + "',1,'" + DateTime.Now + "',0,0,0,1,-1,1,0,0,'" + DateTime.Now + "','" + DateTime.Now + "')";
                if (data.executeCommand(query) == 0)
                {
                    ds = data.getDataSet("select * from ps_customer where email='" + email + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HttpCookie customer = new HttpCookie("custSniggle");
                        customer.Expires = DateTime.Now.AddDays(10d);
                        customer.Values.Add("id_customer", ds.Tables[0].Rows[0]["id_customer"].ToString());
                        customer.Values.Add("firstname", ds.Tables[0].Rows[0]["firstname"].ToString());
                        customer.Values.Add("email", ds.Tables[0].Rows[0]["email"].ToString());
                        customer.Values.Add("newsletter", ds.Tables[0].Rows[0]["newsletter"].ToString());
                        customer.Values.Add("lastname", ds.Tables[0].Rows[0]["lastname"].ToString());
                        HttpContext.Current.Response.Cookies.Add(customer);

                        //Email to customer
                        EF.EmailRegistration(ds.Tables[0].Rows[0]["email"].ToString(), ds.Tables[0].Rows[0]["passwd"].ToString(), name);
                    }
                }
            }
        }
        return str;
    }
}

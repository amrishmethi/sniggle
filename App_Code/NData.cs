using System;
using System.Linq;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Net;

/// <summary>
/// Summary description for NData
/// </summary>
public class NData
{
    Data data = new Data();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    SqlCommand cmd = new SqlCommand();
    string query = "";
    public NData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet getWSProdList(string AttId, string FilterBy)
    {
        cmd = new SqlCommand("sp_WebsiteSummery");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@AttId", AttId);
        cmd.Parameters.AddWithValue("@FilterBy", FilterBy);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getAttributeCEO(string AttId)
    {
        cmd = new SqlCommand("sp_getAttributeCEO");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@AttId", AttId);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet getMainGroupNew(string AttId)
    {
        cmd = new SqlCommand("spu_getMainGroupNewWS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@attId", AttId);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getAttribute(string GroupID)
    {
        cmd = new SqlCommand("spu_getAttributesNew");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@GroupID", GroupID);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getFilterProduct(string AttID, string Attribute, string OrderBy)
    {
        string[] att = Attribute.Split(',');
        DataTable tbl = new DataTable();
        tbl.Columns.Add("groupID", typeof(string));
        tbl.Columns.Add("attID", typeof(string));
        tbl.Columns.Add("tblName", typeof(string));
        string filterby = "";
        query = " ";
        if (att[0] != "")
        {
            for (int i = 0; i < att.Length; i++)
            {
                DataRow dtrow = tbl.NewRow();
                dtrow["attID"] = att[i].Split('-')[0];
                dtrow["groupID"] = att[i].Split('-')[1];
                dtrow["tblName"] = "pac" + i.ToString();
                tbl.Rows.Add(dtrow);
            }
        }

        if (tbl.Rows.Count > 0)
        {
            DataView view = new DataView(tbl);
            DataTable distinctValues = view.ToTable(true, "groupID");
            for (int i = 0; i < distinctValues.Rows.Count; i++)
            {
                DataRow[] results = tbl.Select("groupID='" + distinctValues.Rows[i][0].ToString() + "'");
                if (results.Length > 0)
                {
                    filterby += " inner join ps_product_attribute_combination pac" + i + " on ( pa.id_product_attribute=pac" + i + ".id_product_attribute";
                    DataTable dtf = new DataTable();
                    dtf = results.CopyToDataTable();
                    filterby += " and (";
                    for (int j = 0; j < dtf.Rows.Count; j++)
                    {
                        if (j == 0)
                            filterby += " pac" + i + ".id_attribute=" + dtf.Rows[j]["attID"].ToString() + " ";
                        else
                            filterby += " or pac" + i + ".id_attribute=" + dtf.Rows[j]["attID"].ToString() + " ";
                    }
                    filterby += "))";
                }
            }
        }


        if (OrderBy == "0")
            query += " tt.id_product desc";
        if (OrderBy == "AZ")
            query += " tt.ProdName";
        if (OrderBy == "ZA")
            query += " tt.ProdName desc ";
        if (OrderBy == "PL")
            query += " tt.DiscountPrice asc";
        if (OrderBy == "PH")
            query += " tt.DiscountPrice desc";

        ds = getWSProdList(AttID, filterby);
        //ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getTestimonial()
    {
        cmd = new SqlCommand("usp_GetTestimonial");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        ds = data.getDataSet(cmd);
        return ds;
    }
    public int AddTestimonial(string Action, string author_name, string author_info, string author_url, string author_email, string content, string id)
    {
        int status = 0;
        status = 0;
        cmd = new SqlCommand("Sp_InsTestimonial");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@author_name", author_name);
        cmd.Parameters.AddWithValue("@author_info", author_info);
        cmd.Parameters.AddWithValue("@author_url", author_url);
        cmd.Parameters.AddWithValue("@author_email", author_email);
        cmd.Parameters.AddWithValue("@content", content);
        cmd.Parameters.AddWithValue("@ID", id);
        var result = data.executeCommand(cmd);
        status = Convert.ToInt32(result.ToString());
        return status;
    }
    public string submitReorderProd(string ProdId, string AttriID, string OrderDetailId, string CartId)
    {
        string status = "Fail";
        cmd = new SqlCommand("sp_reorderProduct");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdId", ProdId);
        cmd.Parameters.AddWithValue("@AttriID", AttriID);
        cmd.Parameters.AddWithValue("@CartId", CartId);
        cmd.Parameters.AddWithValue("@OrderDetailId", OrderDetailId);
        if (data.executeCommand(cmd) == 0)
        {
            status = "Success";
        }
        return status;
    }

    public DataTable GetProdDtlApi(string SKU)
    {
        cmd = new SqlCommand("usp_PrintBarcode");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@SKU", SKU);
        ds = data.getDataSet(cmd);
        return ds.Tables[0];
    }

    public string GetProdDtlApiNew(string SKU)
    {
        var jsonString = new StringBuilder();
        cmd = new SqlCommand("usp_PrintBarcode");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@SKU", SKU);
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
            jsonString.Append("[");
            jsonString.Append("{");
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                jsonString.Append("\"" + dt.Columns[j].ColumnName.ToString()
                                             + "\":" + "\""
                                             + dt.Rows[0][j].ToString().Replace('\"', '\'') + "\",");
            }
            jsonString.Append("}");
            jsonString.Append("]");
        }
        return jsonString.ToString();
    }

    public DataSet GetEnqAbtThisProdCombDtl(string RefNo)
    {
        cmd = new SqlCommand("usp_getEnqAbtThisProdCombDtl");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@RefNo", RefNo);
        return data.getDataSet(cmd);
    }

    public void SubmitPasswordRecoverDtl(string IsPasswordUpdated, string CustId)
    {
        query = " Update ps_customer set IsPasswordUpdated = '" + IsPasswordUpdated + "', pwdUpdateDate = '" + DateTime.Now.ToString() + "' where id_customer = '" + CustId + "'";
        data.executeCommand(query);
    }
    public string checkUrlGlobal(string url)
    {
        string para = url.Replace(".html", "").Split('/')[2];
        string[] para1 = para.Split('-');
        para = para1[0];
        string rst = "";
        cmd = new SqlCommand("usp_checkUrlGlobal");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@url", para);
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string existUrl = ds.Tables[0].Rows[0]["fullDetailUrl"].ToString();
            if (url.Trim() == existUrl.Trim())
            {
                rst = "True";
            }
            else
            {
                rst = existUrl;
            }
        }
        else
        {
            rst = "False";
        }
        return rst;
    }

    public void cusVisiting()
    {
        string IpAdd = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
        string UserID = "0";
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
            UserID = user.Values["id_customer"].ToString();
        }
        cmd = new SqlCommand("usp_insertIpAddress");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@IpAdd", IpAdd);
        data.executeCommand(cmd);
    }
    public void UploadCusomizeFile(string CartId, string ProdId, string AttrId, string fileName)
    {
        query = " Update ps_cart_product set CustomizeImg = '" + fileName + "' where IsDeleted = 0 and id_cart = " + CartId + " and id_product = " + ProdId + " and id_product_attribute = " + AttrId + " ";
        if (data.executeCommand(query) == 0)
        {

        }
    }
}
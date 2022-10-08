using System;
using System.Linq;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.IO;

/// <summary>
/// Summary description for GData
/// </summary>
public class GData
{
    int status = 0;
    user objUser = new user();
    Data data = new Data();
    GetData getData = new GetData();
    DataTable tbl = new DataTable();
    DataTable tblGuest = new DataTable();
    string query;
    public DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    DataTable tblCart = new DataTable();
    DataTable dt = new DataTable();
    EmailFormat EF = new EmailFormat();
    public int SNO = 0;
    public GData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet getBannerDetail(string Type, string B_For = "Website")
    {
        cmd = new SqlCommand("sp_GetBanner");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@B_For", B_For);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataTable getBannerDetail4(string Type)
    {
        DataTable dtB = new DataTable();
        dtB.Columns.Add("Img1");
        dtB.Columns.Add("UrlLink1");
        dtB.Columns.Add("LinkOpen1");
        dtB.Columns.Add("Img2");
        dtB.Columns.Add("UrlLink2");
        dtB.Columns.Add("LinkOpen2");
        dtB.Columns.Add("Img3");
        dtB.Columns.Add("UrlLink3");
        dtB.Columns.Add("LinkOpen3");
        cmd = new SqlCommand("sp_GetBanner");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Type", Type);
        ds = data.getDataSet(cmd);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    DataRow dr = dtB.NewRow();
        //    dr["Img1"] = ds.Tables[0].Rows[0]["imgBanner"];
        //    dr["UrlLink1"] = ds.Tables[0].Rows[0]["UrlLink"];
        //    dr["LinkOpen1"] = ds.Tables[0].Rows[0]["LinkOpen1"];
        //    dr["Img2"] = ds.Tables[0].Rows[1]["imgBanner"];
        //    dr["UrlLink2"] = ds.Tables[0].Rows[1]["UrlLink"];
        //    dr["LinkOpen2"] = ds.Tables[0].Rows[1]["LinkOpen1"];
        //    dr["Img3"] = ds.Tables[0].Rows[2]["imgBanner"];
        //    dr["UrlLink3"] = ds.Tables[0].Rows[2]["UrlLink"];
        //    dr["LinkOpen3"] = ds.Tables[0].Rows[2]["LinkOpen1"];

        //    dtB.Rows.Add(dr);
        //}
        return ds.Tables[0];
    }


    public DataSet getNewArrivalsHead(string Type, string CatID)
    {
        cmd = new SqlCommand("sp_GetNewArrivalsHead");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Top", "10");
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@CatId", CatID);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataTable getNewArrivals(string Type, string CatID, int totProd = 20)
    {
        cmd = new SqlCommand("usp_FrontArrivalsProd");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Top", totProd);
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@CatId", CatID);
        ds = data.getDataSet(cmd);
        return ds.Tables[0]; ;
    }
    public DataTable getCustomerReview(int top =4)
    {
        cmd = new SqlCommand("usp_getProductReview");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Top", top);  
        return data.getDataSet(cmd).Tables[0]; ;
    }

    public DataTable GetNewArrivalProd()
    {
        cmd = new SqlCommand("sp_GetNewArrivalProd");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        ds = data.getDataSet(cmd);
        tbl = GetTwoRowsForm(ds);
        return tbl;
    }
    public DataTable GetBestSellingProd()
    {
        cmd = new SqlCommand("sp_GetBestSellingProd");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        ds = data.getDataSet(cmd);
        tbl = GetTwoRowsForm(ds);
        return tbl;
    }

    public DataTable GetLastViewedProd(string ProdId)
    {
        cmd = new SqlCommand("sp_GetLastViewedProd");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@prod", ProdId);
        ds = data.getDataSet(cmd);
        //tbl = GetTwoRowsForm(ds);
        return ds.Tables[0];
    }

    public DataTable getFrontCategory(string CatId)
    {
        cmd = new SqlCommand("sp_GetFrontTwoCategory");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CatId", CatId);
        ds = data.getDataSet(cmd);
        tbl = GetTwoRowsForm(ds);
        return tbl;
    }

    public DataTable getHomeProducts()
    {
        cmd = new SqlCommand("sp_GetHomeProducts");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        ds = data.getDataSet(cmd);
        tbl = GetTwoRowsForm(ds);
        return tbl;
    }

    public DataTable getCreativeCuts()
    {
        cmd = new SqlCommand("sp_GetCreativeCustProducts");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        ds = data.getDataSet(cmd);
        tbl = GetTwoRowsCreativeCuts(ds);
        return tbl;
    }

    public DataSet GetBoughtCustProduct(string ProdId)
    {
        //query = " select distinct  stuff(( select distinct ',' + Cast(id_order as nvarchar(250)) ";
        //query += " from ps_order_detail   where product_id = '" + ProdId + "'  for xml path('')),1,1,'') as OrderId ";
        //query += " from ps_order_detail group by id_order ";
        //ds = data.getDataSet(query);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    cmd = new SqlCommand("sp_GetBoughtCustProduct");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Clear();
        //    cmd.Parameters.AddWithValue("@ProdId", ProdId);
        //    cmd.Parameters.AddWithValue("@OrderId", ds.Tables[0].Rows[0]["OrderId"].ToString());
        //    return data.getDataSet(cmd);
        //}
        //else
        //{
        //    return ds;
        //}

        cmd = new SqlCommand("sp_GetBoughtCustProduct");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdId", ProdId);
        return data.getDataSet(cmd);
    }

    public DataSet GetCustomerDtl(string Email, string Pwd)
    {
        cmd = new SqlCommand("sp_GetCustomerDetail");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Email", Email);
        cmd.Parameters.AddWithValue("@Pwd", Pwd);
        return data.getDataSet(cmd);
    }

    public DataSet GetWishListId(string UserID)
    {
        cmd = new SqlCommand("sp_GetWishListId");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@UserID", UserID);
        return data.getDataSet(cmd);
    }

    public DataSet CheckCustomer(string Email)
    {
        cmd = new SqlCommand("sp_CustomerExists");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Email", Email);
        return data.getDataSet(cmd);
    }

    public DataSet GetCountryList()
    {
        cmd = new SqlCommand("sp_GetCountryList");
        cmd.Parameters.Clear();
        return data.getDataSet(cmd);
    }

    public DataSet GetStateList(string CId)
    {
        cmd = new SqlCommand("sp_GetStateList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CountryId", CId);
        return data.getDataSet(cmd);
    }

    public DataSet InsertCustomer(string gender, string FName, string LName, string Email, string Pwd, string dob, string RecOff, string NewsL, string TC, string FNameA, string LNameA, string CompA, string AddA, string CounNameA, string CounValA, string StateNameA, string StateValA, string CityA, string PINA, string AddInfo, string HomePhone, string MobPhone, string alias)
    {
        cmd = new SqlCommand("sp_InsertCustomer");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_shop_group", "1");
        cmd.Parameters.AddWithValue("@id_shop", "1");
        if (gender == "" || gender == "undefined")
        {
            cmd.Parameters.AddWithValue("@id_gender", "0");
        }
        else
        {
            cmd.Parameters.AddWithValue("@id_gender", gender);
        }
        cmd.Parameters.AddWithValue("@id_lang", "1");
        cmd.Parameters.AddWithValue("@id_default_group", "3");
        cmd.Parameters.AddWithValue("@id_risk", "1");
        cmd.Parameters.AddWithValue("@company", CompA);
        cmd.Parameters.AddWithValue("@firstname", FName);
        cmd.Parameters.AddWithValue("@lastname", LName);
        cmd.Parameters.AddWithValue("@email", Email);
        cmd.Parameters.AddWithValue("@passwd", Pwd);
        if (dob != "" && dob != null)
        {
            cmd.Parameters.AddWithValue("@birthday", ConvertToDateTime(dob));
        }
        else
        {
            cmd.Parameters.AddWithValue("@birthday", DBNull.Value);
        }
        if (NewsL == "1")
        {
            cmd.Parameters.AddWithValue("@newsletter", "1");
        }
        else
        {
            cmd.Parameters.AddWithValue("@newsletter", "0");
        }
        cmd.Parameters.AddWithValue("@active", "1");
        cmd.Parameters.AddWithValue("@deleted", "0");
        cmd.Parameters.AddWithValue("@date_add", DateTime.Now);
        cmd.Parameters.AddWithValue("@date_upd", DateTime.Now);
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string CustId = ds.Tables[0].Rows[0]["id_customer"].ToString();

            cmd = new SqlCommand("sp_InsertCustAddress");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id_customer", CustId);
            cmd.Parameters.AddWithValue("@id_country", CounValA);
            cmd.Parameters.AddWithValue("@id_state", StateValA);
            cmd.Parameters.AddWithValue("@id_manufacturer", 0);
            cmd.Parameters.AddWithValue("@id_supplier", 0);
            cmd.Parameters.AddWithValue("@id_warehouse", 0);
            cmd.Parameters.AddWithValue("@alias", "My address");
            cmd.Parameters.AddWithValue("@company", CompA);
            cmd.Parameters.AddWithValue("@firstname", FNameA);
            cmd.Parameters.AddWithValue("@lastname", LNameA);
            cmd.Parameters.AddWithValue("@address1", AddA);
            cmd.Parameters.AddWithValue("@address2", "");
            cmd.Parameters.AddWithValue("@postcode", PINA);
            cmd.Parameters.AddWithValue("@city", CityA);
            cmd.Parameters.AddWithValue("@phone", HomePhone);
            cmd.Parameters.AddWithValue("@phone_mobile", MobPhone);
            cmd.Parameters.AddWithValue("@active", 1);
            cmd.Parameters.AddWithValue("@deleted", 0);
            cmd.Parameters.AddWithValue("@date_add", DateTime.Now);
            cmd.Parameters.AddWithValue("@date_upd", DateTime.Now);
            ds = data.getDataSet(cmd);
        }
        return ds;
    }

    public DataSet GetCustomerOrder(string CustId)
    {
        cmd = new SqlCommand("sp_GetCustomerOrders");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CustID", CustId);
        return data.getDataSet(cmd);
    }

    public DataSet GetCustomerOrderDetail(string Orderid)
    {
        cmd = new SqlCommand("sp_GetOrderDetailonFront");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@OrderId", Orderid);
        return data.getDataSet(cmd);
    }

    public DataSet GetCustomerAddress(string CustId)
    {
        cmd = new SqlCommand("sp_GetCustomerAddress");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CustID", CustId);
        return data.getDataSet(cmd);
    }

    public DataSet GetWishList(string CustId)
    {
        cmd = new SqlCommand("sp_GetWishlistCust");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CustId", CustId);
        return data.getDataSet(cmd);
    }

    public int UpdatePwd(string CustId, string NPwd)
    {
        cmd = new SqlCommand("sp_UpdatePwd");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CustId", CustId);
        cmd.Parameters.AddWithValue("@NPwd", NPwd);
        cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
        if (data.executeCommand(cmd) == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public int InsertProductEnquiry(string CustName, string CustEmail, string Subject, string msg,
        string img, string price, string ProdId, string ProdName, string Url)
    {
        cmd = new SqlCommand("sp_InsertProductEnquiry");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CustName", CustName);
        cmd.Parameters.AddWithValue("@CustEmail", CustEmail);
        cmd.Parameters.AddWithValue("@Subject", Subject);
        cmd.Parameters.AddWithValue("@Msg", msg);
        cmd.Parameters.AddWithValue("@img", img);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.Parameters.AddWithValue("@ProdId", ProdId);
        cmd.Parameters.AddWithValue("@ProdName", ProdName);
        cmd.Parameters.AddWithValue("@Url", Url);
        if (data.executeCommand(cmd) == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public DataSet GetProductUrl(string ProdId)
    {
        cmd = new SqlCommand("sp_GetProductUrl");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdId", ProdId);
        return data.getDataSet(cmd);
    }

    public int ChangeYourPwd(string CustId, string CurretPwd, string NPwd)
    {
        cmd = new SqlCommand("sp_ChangeYourPwd");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CustId", CustId);
        cmd.Parameters.AddWithValue("@CurrentPwd", CurretPwd);
        cmd.Parameters.AddWithValue("@NPwd", NPwd);
        cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows[0]["Status"].ToString() == "Success")
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public DataSet RemoveFromWL(string CustId, string ProdId)
    {
        query = " Delete from ps_wishlist_product where id_wishlist_product = '" + ProdId + "'";
        data.executeCommand(query);

        cmd = new SqlCommand("sp_GetWishlistCust");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CustId", CustId);
        return data.getDataSet(cmd);
    }

    public string OrderCancel(string CustId, string OrderId)
    {
        string status = "Failed";
        query = " Update ps_orders set current_state = 6 where id_order = '" + OrderId + "' ";
        if (data.executeCommand(query) == 0)
        {
            EF.EmailOrderCanceled(OrderId);
            status = "Success";
        }
        return status;
    }

    public DataSet GetPersonalInfo(string CustId)
    {
        query = " Select * From ps_customer where active = 1 and id_customer = '" + CustId + "' ";
        return data.getDataSet(query);
    }

    public DataSet GetSearchList(string CatId, string Pord)
    {
        string ss = "%";
        if (CatId != "")
        {
            ss = CatId.Split('-')[0];
        }

        cmd = new SqlCommand("sp_GetSearchList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CatId", ss);
        cmd.Parameters.AddWithValue("@Pord", Pord);
        return data.getDataSet(cmd);
    }

    public DataSet GetBlogDetail(string BlogId)
    {
        cmd = new SqlCommand("sp_GetFromBlogDetail");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@BlogId", BlogId);
        return data.getDataSet(cmd);
    }

    public DataSet GetBlogList()
    {
        cmd = new SqlCommand("sp_GetFromBlogDetailList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        return data.getDataSet(cmd);
    }

    public DataSet GetWishDetail(string CustId, string wishid)
    {
        cmd = new SqlCommand("sp_getCustWishlist");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CustId", CustId);
        cmd.Parameters.AddWithValue("@Wishid", wishid);
        return data.getDataSet(cmd);
    }


    public DataTable GetTwoRowsForm(DataSet ds)
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        dt = ds.Tables[0].Clone();
        decimal ss = ds.Tables[0].Rows.Count / 2;
        int val2 = Convert.ToInt32(Math.Round(ss));
        for (int i = 0; i < ds.Tables[0].Rows.Count / 2; i++)
        {
            DataRow dr = dt.NewRow();
            dr["Discount"] = ds.Tables[0].Rows[i]["Discount"];
            dr["DiscountPrice"] = ds.Tables[0].Rows[i]["DiscountPrice"];
            dr["CatName"] = ds.Tables[0].Rows[i]["CatName"];
            dr["CatImage"] = ds.Tables[0].Rows[i]["CatImage"];
            dr["ProdID"] = ds.Tables[0].Rows[i]["ProdID"];
            dr["ProdName"] = ds.Tables[0].Rows[i]["ProdName"];
            dr["ProdPrice"] = ds.Tables[0].Rows[i]["ProdPrice"];
            dr["Image1"] = ds.Tables[0].Rows[i]["Image1"];
            dr["URL"] = ds.Tables[0].Rows[i]["URL"];
            dr["imgSecond"] = ds.Tables[0].Rows[i]["imgSecond"];
            dr["DetailUrl"] = ds.Tables[0].Rows[i]["DetailUrl"];
            dr["available_now"] = ds.Tables[0].Rows[i]["available_now"];
            dr["DisHtml"] = ds.Tables[0].Rows[i]["DisHtml"];
            dr["DisPrice"] = ds.Tables[0].Rows[i]["DisPrice"];
            dr["available_nowHtml"] = ds.Tables[0].Rows[i]["available_nowHtml"];
            dr["Rating"] = ds.Tables[0].Rows[i]["Rating"];
            dr["CatUrl"] = ds.Tables[0].Rows[i]["CatUrl"];
            dr["reference"] = ds.Tables[0].Rows[i]["reference"];
            dr["description"] = ds.Tables[0].Rows[i]["description"];
            dr["ImgCaption"] = ds.Tables[0].Rows[i]["ImgCaption"];
            dr["imgSecondCaption"] = ds.Tables[0].Rows[i]["imgSecondCaption"];

            dr["Discount1"] = ds.Tables[0].Rows[i + val2]["Discount"];
            dr["DiscountPrice1"] = ds.Tables[0].Rows[i + val2]["DiscountPrice"];
            dr["CatImage1"] = ds.Tables[0].Rows[i + val2]["CatImage"];
            dr["ProdID1"] = ds.Tables[0].Rows[i + val2]["ProdID"];
            dr["ProdName1"] = ds.Tables[0].Rows[i + val2]["ProdName"];
            dr["ProdPrice1"] = ds.Tables[0].Rows[i]["ProdPrice"];
            dr["Image2"] = ds.Tables[0].Rows[i + val2]["Image1"];
            dr["URL1"] = ds.Tables[0].Rows[i + val2]["URL"];
            dr["imgSecond1"] = ds.Tables[0].Rows[i + val2]["imgSecond"];
            dr["DetailUrl1"] = ds.Tables[0].Rows[i + val2]["DetailUrl"];
            dr["available_now1"] = ds.Tables[0].Rows[i + val2]["available_now"];
            dr["DisHtml1"] = ds.Tables[0].Rows[i + val2]["DisHtml"];
            dr["DisPrice1"] = ds.Tables[0].Rows[i + val2]["DisPrice"];
            dr["available_nowHtml1"] = ds.Tables[0].Rows[i + val2]["available_nowHtml"];
            dr["Rating1"] = ds.Tables[0].Rows[i + val2]["Rating"];
            dr["reference1"] = ds.Tables[0].Rows[i + val2]["reference"];
            dr["description1"] = ds.Tables[0].Rows[i + val2]["description"];
            dr["ImgCaption1"] = ds.Tables[0].Rows[i + val2]["ImgCaption"];
            dr["imgSecondCaption1"] = ds.Tables[0].Rows[i + val2]["imgSecondCaption"];

            dt.Rows.Add(dr);
        }
        return dt;
    }

    public DataTable GetTwoRowsCreativeCuts(DataSet ds)
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        dt = ds.Tables[0].Clone();
        decimal ss = ds.Tables[0].Rows.Count / 2;
        int val2 = Convert.ToInt32(Math.Round(ss));
        for (int i = 0; i < ds.Tables[0].Rows.Count / 2; i++)
        {
            DataRow dr = dt.NewRow();
            dr["ID"] = ds.Tables[0].Rows[i]["ID"];
            dr["catName"] = ds.Tables[0].Rows[i]["catName"];
            dr["catDes"] = ds.Tables[0].Rows[i]["catDes"];
            dr["catImage"] = ds.Tables[1].Rows[0]["Banner"];
            dr["prodTitle"] = ds.Tables[0].Rows[i]["prodTitle"];
            dr["PDesc"] = ds.Tables[0].Rows[i]["PDesc"];
            dr["VideoLink"] = ds.Tables[0].Rows[i]["VideoLink"];
            dr["Image1"] = ds.Tables[0].Rows[i]["Image1"];
            dr["caption1"] = ds.Tables[0].Rows[i]["caption1"];
            dr["Image2"] = ds.Tables[0].Rows[i]["Image2"];
            dr["caption2"] = ds.Tables[0].Rows[i]["caption2"];
            dr["Image3"] = ds.Tables[0].Rows[i]["Image3"];
            dr["caption3"] = ds.Tables[0].Rows[i]["caption3"];
            dr["Image4"] = ds.Tables[0].Rows[i]["Image4"];
            dr["caption4"] = ds.Tables[0].Rows[i]["caption4"];
            dr["Image5"] = ds.Tables[0].Rows[i]["Image5"];
            dr["caption5"] = ds.Tables[0].Rows[i]["caption5"];
            dr["Url"] = ds.Tables[0].Rows[i]["Url"];

            dr["ID1"] = ds.Tables[0].Rows[i + val2]["ID"];
            dr["catName1"] = ds.Tables[0].Rows[i + val2]["catName"];
            dr["catDes1"] = ds.Tables[0].Rows[i + val2]["catDes"];
            dr["catImage1"] = ds.Tables[0].Rows[i + val2]["catImage"];
            dr["prodTitle1"] = ds.Tables[0].Rows[i + val2]["prodTitle"];
            dr["PDesc1"] = ds.Tables[0].Rows[i]["PDesc"];
            dr["VideoLink1"] = ds.Tables[0].Rows[i + val2]["VideoLink"];
            dr["Image11"] = ds.Tables[0].Rows[i + val2]["Image1"];
            dr["caption11"] = ds.Tables[0].Rows[i + val2]["caption1"];
            dr["Image21"] = ds.Tables[0].Rows[i + val2]["Image2"];
            dr["caption21"] = ds.Tables[0].Rows[i + val2]["caption2"];
            dr["Image31"] = ds.Tables[0].Rows[i + val2]["Image3"];
            dr["caption31"] = ds.Tables[0].Rows[i + val2]["caption3"];
            dr["Image41"] = ds.Tables[0].Rows[i + val2]["Image4"];
            dr["caption41"] = ds.Tables[0].Rows[i + val2]["caption4"];
            dr["Image51"] = ds.Tables[0].Rows[i + val2]["Image5"];
            dr["caption51"] = ds.Tables[0].Rows[i + val2]["caption4"];
            dr["Url1"] = ds.Tables[0].Rows[i + val2]["Url"];
            dt.Rows.Add(dr);
        }
        return dt;
    }

    public DataSet InsOrderHistory(string id_employee, string id_order, string id_order_state)
    {
        cmd = new SqlCommand("Sp_InsOrderHistory");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_employee", id_employee);
        cmd.Parameters.AddWithValue("@id_order", id_order);
        cmd.Parameters.AddWithValue("@id_order_state", id_order_state);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet InsertContactUs(string Name, string Email, string Subject, string Msg, string filename)
    {
        cmd = new SqlCommand("sp_InsertContactUs");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Name", Name);
        cmd.Parameters.AddWithValue("@Email", Email);
        cmd.Parameters.AddWithValue("@Subject", Subject);
        cmd.Parameters.AddWithValue("@Message", Msg);
        cmd.Parameters.AddWithValue("@AttachFile", filename);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet CustomerDtlUpdate(string CustId, string gender, string FName, string LName, string Email, string dob, string RecOff, string NewsL)
    {
        cmd = new SqlCommand("sp_UpdateCustomer");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_customer", CustId);
        cmd.Parameters.AddWithValue("@id_gender", gender);
        cmd.Parameters.AddWithValue("@firstname", FName);
        cmd.Parameters.AddWithValue("@lastname", LName);
        cmd.Parameters.AddWithValue("@email", Email);
        //cmd.Parameters.AddWithValue("@passwd", Pwd);
        cmd.Parameters.AddWithValue("@birthday", ConvertToDateTime(dob));
        cmd.Parameters.AddWithValue("@newsletter", NewsL);
        cmd.Parameters.AddWithValue("@date_upd", DateTime.Now);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet InsertCustomOrderForm(string Name, string Email, string ContactNo, string StoneName, string Description, string filename, string EntryType)
    {
        cmd = new SqlCommand("sp_InsertCustomOrderForm");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Name", Name);
        cmd.Parameters.AddWithValue("@Email", Email);
        cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
        cmd.Parameters.AddWithValue("@StoneName", StoneName);
        cmd.Parameters.AddWithValue("@Description", Description);
        cmd.Parameters.AddWithValue("@filename", filename);
        cmd.Parameters.AddWithValue("@EntryType", EntryType);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public string GetImgAccordingToCombination(string ProdId, string AttrId)
    {
        string img = "";
        DataSet dsImg = new DataSet();
        if (AttrId != "")
        {
            cmd = new SqlCommand("sp_GetImgAccordingToCombination");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ProdId", ProdId);
            cmd.Parameters.AddWithValue("@AttId", AttrId);
            dsImg = data.getDataSet(cmd);
            if (dsImg.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsImg.Tables[0].Rows.Count; i++)
                {
                    string imgid = dsImg.Tables[0].Rows[i]["imgStatus"].ToString();
                    if (img == "")
                    {
                        img = imgid;
                    }
                    else
                    {
                        img += "," + imgid;
                    }
                }
            }
            else
            {
                img = "AllImg";
            }
        }
        else
        {
            img = "AllImg";
        }
        return img;
    }


    public DataSet GetDuplicateEntryFromCart(string CartId, string UserID)
    {
        cmd = new SqlCommand("sp_DuplicateEntryFromCart");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CartID", CartId);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet GetAddToCartDetail(string CartId)
    {
        cmd = new SqlCommand("sp_GetAddToCartDetail");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@cartID", CartId);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public string GetProdDefaultAttID(string ProdId)
    {
        string AttId = "0";
        query = " select * From ps_product_attribute where default_on = 1 ";
        query += "  and IsDeleted = 0 and id_product = '" + ProdId + "'";
        ds = data.getDataSet(query);
        if (ds.Tables[0].Rows.Count > 0)
        {
            AttId = ds.Tables[0].Rows[0]["id_product_attribute"].ToString();
        }
        return AttId;
    }

    public DataSet getNewArrivalsProdForPage(string FilterBy, string OBY)
    {
        cmd = new SqlCommand("sp_GetNewArrivalProdForPage");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@FilterBy", FilterBy);
        cmd.Parameters.AddWithValue("@OBY", OBY);
        return data.getDataSet(cmd);
    }

    public DataSet getBestSellingProdForPage(string OBY)
    {
        cmd = new SqlCommand("sp_GetBestSellProdForPage");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@OBY", OBY);
        return data.getDataSet(cmd);
    }

    public DataSet getCreativeCutsProd(string OBY)
    {
        cmd = new SqlCommand("sp_GetCreativeCutsProducts");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@OBY", OBY);
        return data.getDataSet(cmd);
    }

    public DataSet getCCutsProd(string ProdID)
    {
        cmd = new SqlCommand("sp_GetCreativeCutsProd");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdId", ProdID);
        return data.getDataSet(cmd);
    }

    public DataSet InsertCreativeCutsEnquiry(string CustName, string CustEmail, string img, string description, string ProdName)
    {
        cmd = new SqlCommand("sp_InsertCreativeCutsEnquiry");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CustName", CustName);
        cmd.Parameters.AddWithValue("@CustEmail", CustEmail);
        cmd.Parameters.AddWithValue("@img", img);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.Parameters.AddWithValue("@ProdName", ProdName);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet GetProductImpectPrice(string ProdID, string Attt)
    {
        cmd = new SqlCommand("sp_GetProductImpectPrice");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdId", ProdID);
        cmd.Parameters.AddWithValue("@Att", Attt);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet GetShipingAmt(string UserID, string AddID)
    {
        cmd = new SqlCommand("sp_GetShippingAmount");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@AddId", AddID);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet submitBlogPost(string Name, string Email, string Comment, string BlogPostID)
    {
        cmd = new SqlCommand("sp_submitBlogPostComment");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@BlogPostID", BlogPostID);
        cmd.Parameters.AddWithValue("@Name", Name);
        cmd.Parameters.AddWithValue("@Email", Email);
        cmd.Parameters.AddWithValue("@Comment", Comment);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet GetBlogCommentFront(string BlogId)
    {
        cmd = new SqlCommand("Sp_GetBlogCommentFront");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@BlogId", BlogId);
        return data.getDataSet(cmd);
    }

    public DataSet getAttributeWS(string AttID)
    {
        cmd = new SqlCommand("sp_GetAttributeWS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@AttID", AttID);
        return data.getDataSet(cmd);
    }

    public DataSet getCategoryWS(string AttID)
    {
        cmd = new SqlCommand("sp_GetCategoryWS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        return data.getDataSet(cmd);
    }

    public void CustMsgOnPayment(string CartId, string msg)
    {
        cmd = new SqlCommand("sp_SubmitCustMsgOnPayment");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CartId", CartId);
        cmd.Parameters.AddWithValue("@msg", msg);
        data.executeCommand(cmd);
    }
    public void CustPaymentStatus(string order_id, string id_cart)
    {
        cmd = new SqlCommand("sp_CustPaymentStatus");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@order_id", order_id);
        cmd.Parameters.AddWithValue("@id_cart", id_cart);
        data.executeCommand(cmd);
    }
    public string BindStar(string myValue1)
    {
        string ddd = myValue1.ToString();
        string revicount = myValue1.ToString();
        string str = "";
        if (myValue1.ToString() == "5")
        {
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>"; 
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>"; 
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>"; 
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>"; 
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>"; 
        }
        if (myValue1.ToString() == "4")
        {
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>"; 
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";  
        }
        if (myValue1.ToString() == "3")
        {
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>"; 
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
        }
        if (myValue1.ToString() == "2")
        {
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
        }
        if (myValue1.ToString() == "1")
        { 
            str += " <li class=\"fill\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
        }
        if (myValue1.ToString() == "0" || myValue1.ToString() == "")
        {
            revicount = "1";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
            str += " <li class=\"empty\"><i class=\"ion-android-star\"></i></li>";
        }
        str += "<meta itemprop=\"worstRating\" content=\"0\" />";
        str += "<meta itemprop=\"ratingValue\" content=\"5\" />";
        str += "<meta itemprop=\"bestRating\" content=\"5\" />";
        str += "<meta itemprop=\"reviewCount\" content=\"" + revicount + "\" />";
        return str;
    }

    private string ConvertToDateTime(string strDateTime)
    {
        string dtFinaldate; string sDateTime;
        char[] splitBy = new char[] { '\\', '.', '-', '/' };
        string[] sDate = strDateTime.Split(splitBy, StringSplitOptions.RemoveEmptyEntries);
        sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
        dtFinaldate = (sDateTime);
        return dtFinaldate;
    }

    public string Encrypt(string clearText)
    {
        string EncryptionKey = "EARTHGEMSTONESPACIFIC012345INC9876JAIPUR";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    public string Decrypt(string cipherText)
    {
        string EncryptionKey = "EARTHGEMSTONESPACIFIC012345INC9876JAIPUR";
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
}
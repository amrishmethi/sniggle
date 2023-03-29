using System;
using System.Linq;
using System.Data;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GetData
/// </summary>
public class GetData
{
    int status = 0;
    user objUser = new user();
    Data data = new Data();
    DataTable tbl = new DataTable();
    DataTable tblGuest = new DataTable();
    string query;
    public DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    DataTable tblCart = new DataTable();
    DataTable dt = new DataTable();
    public int SNO = 0;
    public GetData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet getProducts(string CatID)
    {
        query = "select cast(cat.id_category as nvarchar(50))+'.jpg' as CatImage, cat.name as CatName, prod.id_product as ProdID, pl.name as ProdName,cast(prod.price as decimal(18,2)) as ProdPrice,  prod.ImgURL1 as Image1,'/img/'+cat.name+'/'+ cast((select top 1 id_image from ps_image where id_product=prod.id_product) as nvarchar(50))+'.jpg' as URL from ps_product prod  inner  join ps_category_lang cat on prod.id_category_default = cat.id_category  inner  join ps_product_lang pl on prod.id_product = pl.id_product where cat.id_lang = 1 and cat.id_category = " + CatID + " and pl.id_lang = 1 and prod.active = 1 order by pl.name";
        ds = data.getDataSet(query);

        return ds;
    }

    public DataSet getCategory(string CatID)
    {
        query = "select '/img/c/'+cast(cat.id_category as nvarchar(50))+'.jpg' as CatImage, cat.name as CatName, cat.description,  cat.meta_title, cat.meta_keywords, cat.meta_description, ISNULL(cast( cat.id_category as nvarchar(500)),'') + '-' +  ISNULL(REPLACE(cat.link_rewrite ,' ','-'),'')  as Url   from ps_category_lang cat  where cat.id_lang = 1 and cat.id_category = " + CatID.Split('-')[0].ToString() + "";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getSubCategory(string CatID)
    {
        cmd = new SqlCommand("sp_getSubCategoryS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CatId", CatID);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public string getLeftCategory()
    {
        string str = "";
        query = "select cl.*, ISNULL(cast( cat.id_category as nvarchar(500)),'') + '-' +  ISNULL(REPLACE(cl.link_rewrite ,' ','-'),'')  as Url  from  ps_category_lang cl inner join ps_category cat on cl.id_category=cat.id_category WHERE cat.IsDeleted = 0 and  cl.id_lang = 1 and cat.active = 1 and cat.id_parent = 2 and cat.IsDeleted = 0 order by cat.position";
        ds = data.getDataSet(query);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                query = "select cl.*, ISNULL(cast( cat.id_category as nvarchar(500)),'') + '-' +  ISNULL(REPLACE(cl.link_rewrite ,' ','-'),'')  as Url  from  ps_category_lang cl inner join ps_category cat on cl.id_category=cat.id_category WHERE cat.IsDeleted = 0 and cl.id_lang = 1 and cat.active = 1 and cat.id_parent = " + ds.Tables[0].Rows[i]["id_category"].ToString() + " order by cat.position";
                DataSet ds1 = data.getDataSet(query);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    str += "<li>";
                    str += "<ul class=\"sidebar-menu-collapse\">";
                    str += "<li class=\"sidebar-menu-collapse-list\">";
                    str += "<div class=\"accordion\">";
                    str += " <a href=\"#\" class=\"accordion-title collapsed\" data-bs-toggle =\"collapse\" data-bs-target=\"#accordian" + ds.Tables[0].Rows[i]["id_category"].ToString() + "\" aria-expanded =\"false\">" + ds.Tables[0].Rows[i]["name"].ToString() + "<i class=\"ion-ios-arrow-right\"></i></ a>";
                    str += "<div id=\"accordian" + ds.Tables[0].Rows[i]["id_category"].ToString() + "\" class=\"collapse\">";
                    str += "<ul class=\"accordion-category-list\">";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        str += "<li><a href=\"/" + ds1.Tables[0].Rows[j]["url"].ToString() + "\">" + ds1.Tables[0].Rows[j]["name"].ToString() + "</a></li>";
                    }
                    str += "</ul>";
                    str += "</div>";
                    str += "</div>";
                    str += "</li>";
                    str += "</ul>";
                    str += "</li>";
                }
                else
                {
                    str += "<li><a href=\"/" + ds.Tables[0].Rows[i]["url"].ToString() + "\">" + ds.Tables[0].Rows[i]["name"].ToString() + "</a></li>";
                }
            }
        }

        return str;
    }

    public DataSet getProducts(string CatID, string OrderBy)
    {
        cmd = new SqlCommand("sp_GetProdcuts");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CatId", CatID);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataTable getProductsSearch(string cat, string keyword, string OBY)
    {
        string keyword1 = ""; string keyword2 = ""; string keyword3 = "";
        string keyword4 = "";
        string IsSub = "False"; ;
        if (cat == "" || cat == null || cat == "0")
        {
            cat = "%";
        }
        else
        {
            cat = cat.Split('-')[0];
            //query = " select a.id_category from ps_category a  where  a.IsDeleted=0   and a.id_parent =  '" + cat + "'  and a.active = 1 ";
            //ds = data.getDataSet(query);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    IsSub = "True";
            //    string catid = "";
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        if (catid == "")
            //        {
            //            catid = ds.Tables[0].Rows[i]["id_category"].ToString();
            //        }
            //        else
            //        {
            //            catid += "," + ds.Tables[0].Rows[i]["id_category"].ToString();
            //        }
            //    }
            //    cat = catid;
            //}
        }
        string filter = "";
        if (keyword == "" || keyword == null)
        {
            keyword = "NOData";
        }
        else
        {
            string[] keyLength = keyword.Replace("+", " ").Split(' ');
            if (keyLength.Length == 1)
            {
                keyword1 = keyword2 = keyword3 = keyword4 = keyword.Replace("+", " ");
            }
            else
            {
                if (keyLength.Length == 2)
                {
                    keyword1 = keyword4 = keyword.Replace("+", " ");
                    keyword2 = keyLength[0];
                    keyword3 = keyLength[1];
                }
                else
                {
                    if (keyLength.Length == 3)
                    {
                        keyword1 = keyword.Replace("+", " ");
                        keyword2 = keyLength[0];
                        keyword3 = keyLength[1];
                        keyword4 = keyLength[2];
                    }
                    else
                    {
                        keyword1 = keyword.Replace("+", " ");
                        keyword2 = keyLength[0] + " " + keyLength[1];
                        keyword3 = keyLength[0];
                        keyword4 = keyLength[1];
                    }
                }
            }
        }
        if (OBY == "0")
        {
            filter = " ProdID desc";
        }
        else if (OBY == "AZ")
        {
            filter = "  ProdName  ";
        }
        else if (OBY == "ZA")
        {
            filter = " ProdName desc ";
        }
        else if (OBY == "PL")
        {
            filter = " DiscountPrice asc ";
        }
        else if (OBY == "PH")
        {
            filter = " DiscountPrice desc ";
        }

        //cmd = new SqlCommand("sp_GetProdcutsSearch");
        cmd = new SqlCommand("sp_GetProdcutsSearchNew");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        //cmd.Parameters.AddWithValue("@IsSub", IsSub);
        cmd.Parameters.AddWithValue("@cat", cat);
        cmd.Parameters.AddWithValue("@KeyWord1", keyword1);
        cmd.Parameters.AddWithValue("@KeyWord2", keyword2);
        cmd.Parameters.AddWithValue("@KeyWord3", keyword3);
        cmd.Parameters.AddWithValue("@KeyWord4", keyword4);
        ds = data.getDataSet(cmd);
        DataView dv = ds.Tables[0].DefaultView;
        if (OBY != "Default")
        {
            dv.Sort = filter;
        }
        DataTable sortedDT = dv.ToTable(true, "available_nowHtml", "Discount", "DiscountPrice", "CatImage", "CatName", "ProdID", "ProdName", "ProdPrice", "Image1", "URL", "imgSecond", "DetailUrl", "StockQty", "out_of_stock", "StockStatus", "Rating", "ReviewCount");
        return sortedDT;
    }

    public DataSet getFilterProduct(string CatID, string Attribute, string OrderBy, string subType = null, string minDis = "0", string maxDis = "0")
    {
        string[] att = Attribute.Split(',');
        DataTable tbl = new DataTable();
        tbl.Columns.Add("groupID", typeof(string));
        tbl.Columns.Add("attID", typeof(string));
        tbl.Columns.Add("tblName", typeof(string));

        query = "  with  tblProd as( select distinct  prod.id_category, prod.ProdID, CASE WHEN LEN( prod.ProdName) > 21 THEN CONCAT(SUBSTRING( prod.ProdName, 1, 21), '...') ELSE  prod.ProdName END  as ProdName,  prod.meta_title,  prod.meta_keywords,  prod.meta_description,  ";
        query += " prod.available_nowHtml,  prod.available_nowHtmlold,   prod.ProdPrice, prod.DiscountPrice, prod.Discount, prod.Image1,";
        query += " [dbo].[fn_GetImageOfProdFromImgKit](prod.CatName, prod.id_product, 'cover') as URL, ";
        query += " [dbo].[fn_GetImageOfProdFromImgKit](prod.CatName, prod.id_product, 'Notcover') as imgSecond, ";
        query += " [dbo].[fn_GetImageProdCaption](prod.id_product, 'cover') as ImgCaption, ";
        query += "[dbo].[fn_GetImageProdCaption](prod.id_product, 'Notcover') as imgSecondCaption,  ";
        query += "  prod.DetailUrl, prod.description, prod.StockQty, prod.out_of_stock, prod.StockStatus, prod.Rating, prod.ReviewCount, IIF(Discount != '0', 'd-show', 'd-none') as pDis  ";
        query += "   From shankar as prod ";
        query += " inner join ps_product_attribute pa on (prod.id_product=pa.id_product ) ";
        query += " left outer join ps_stock_available as psa on (psa.id_product = prod.id_product and psa.id_product_attribute = 0 )  ";

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
                    query += " inner join ps_product_attribute_combination pac" + i + " on ( pa.id_product_attribute=pac" + i + ".id_product_attribute";
                    DataTable dtf = new DataTable();
                    dtf = results.CopyToDataTable();
                    query += " and (";
                    for (int j = 0; j < dtf.Rows.Count; j++)
                    {
                        if (j == 0)
                            query += " pac" + i + ".id_attribute=" + dtf.Rows[j]["attID"].ToString() + " ";
                        else
                            query += " or pac" + i + ".id_attribute=" + dtf.Rows[j]["attID"].ToString() + " ";
                    }
                    query += "))";
                }
            }
        }
        if (subType == "" || subType == null)
        {
            query += "  where prod.id_category =" + CatID + " ";
        }
        else
        {
            query += "  where prod.id_category <> 0 ";
            string[] sss = subType.Split(',');
            for (int i = 0; i < sss.Length; i++)
            {

                if (i == 0)
                {
                    if (sss.Length == 1)
                    {
                        query += " and prod.id_category =" + sss[i] + " ";
                    }
                    else
                    {
                        query += " and ( prod.id_category =" + sss[i] + " ";
                    }
                }
                else if (i == sss.Length - 1)
                {
                    query += " or prod.id_category =" + sss[i] + " )";
                }
                else
                {
                    query += " or prod.id_category =" + sss[i] + " ";
                }
            }
        }
        if (maxDis != "0")
        {
            query += " and prod.Discount between '" + minDis + "' and '" + maxDis + "'";
        }

        //if (OrderBy == "0")
        //    query += " order by ProdName)";
        //if (OrderBy == "ND")
        //    query += " order by ProdName desc)";
        //if (OrderBy == "PL")
        //    query += " order by prod.DiscountPrice) ";
        //if (OrderBy == "PH")
        //    query += " order by prod.DiscountPrice desc)";
        query += ") select * From tblProd order by newid()";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getFilterProductForOther(string Attribute, string OrderBy)
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

        GData gda = new GData();
        ds = gda.getNewArrivalsProdForPage(filterby, query);
        //ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getFilterProductold(string CatID, string Attribute, string OrderBy)
    {
        string[] att = Attribute.Split(',');
        DataTable tbl = new DataTable();
        tbl.Columns.Add("groupID", typeof(string));
        tbl.Columns.Add("attID", typeof(string));
        tbl.Columns.Add("tblName", typeof(string));

        query = " select distinct";
        query += " case when (psa.quantity >= prod.minimal_quantity or psa.out_of_stock != 0 )  ";
        query += " then  case when (available_now = '0' or available_now = '') then 'In Stock'  else   available_now end ";
        query += " else 'OutOfStock' end as available_nowHtml,  ";
        query += "  case when (available_now = '0' or available_now = '') then 'In Stock'  else   available_now   end available_nowHtmlold, ";
        query += "  cast((case when (select top(1) isnull(sp.reduction,0) from ps_specific_price as  sp where sp.id_product=prod.id_product  and sp.IsDeleted = 0) is null then 0 else (((select top(1) isnull(reduction,0) from ps_specific_price as  sp where sp.id_product=prod.id_product and sp.IsDeleted = 0))) end) as decimal(18,2)) as Discount,  ";

        query += " cast((cast(prod.price as decimal(18,4))- (case when (select top(1) isnull(reduction,0) from ps_specific_price  as  sp where  sp.IsDeleted = 0 and id_product=prod.id_product) is null then 0 else  (((select top(1) isnull(sp.reduction,0) from ps_specific_price as  sp where  sp.IsDeleted = 0 and sp.id_product=prod.id_product))*cast(prod.price as decimal(18,4))) end) / 100) as decimal(18,2))  as DiscountPrice,";

        query += " prod.ImgURL1 as URL,";

        query += " REPLACE(REPLACE(cat.link_rewrite,' ','-'),'/-','')+'/'+cast(prod.id_product as nvarchar(50))+'-'+REPLACE(REPLACE(pl.link_rewrite,' ','-'),'/-','')+'.html' as DetailUrl, 32 as coun, ";

        query += " prod.ImgURL1 as Image1,  ";

        query += " cast(cat.id_category as nvarchar(50))+'.jpg' as CatImage,  cat.name as CatName, ";

        query += " prod.id_product as ProdID, pl.name as ProdName,cast(prod.price as decimal(18,2)) as ProdPrice,   ";

        query += "  '/img/'+RTRIM(LTRIM(REPLACE(cat.name,'/','-')))+'/'+ [dbo].[fn_GetProductImage](prod.id_product) +'.jpg' as imgSecond, PL.description, ";

        //Stock Detail 0 = Deny orders, 1 = Allow orders, 2 = Default Allow orders
        query += " psa.quantity as StockQty,   psa.out_of_stock, case when (psa.quantity >= prod.minimal_quantity or psa.out_of_stock != 0 ) then 'InStock' else 'OutOfStock' end as StockStatus ";
        query += " , [dbo].[fn_GetProductRating](prod.id_product) as Rating, ISNULL((select COUNT(id_product_comment)  from ps_product_comment Where deleted = 0 and validate = 1 and  id_product = prod.id_product ),0) as ReviewCount ";



        query += " from ps_product prod  inner  join ps_category_lang cat on prod.id_category_default = cat.id_category  inner  join ps_product_lang pl on prod.id_product = pl.id_product inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product";
        query += " inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute ";
        if (att[0] != "")
        {
            for (int i = 0; i < att.Length; i++)
            {
                query += " inner join ps_product_attribute_combination pac" + i + " on pa.id_product_attribute=pac" + i + ".id_product_attribute";
                DataRow dtrow = tbl.NewRow();
                dtrow["attID"] = att[i].Split('-')[0];
                dtrow["groupID"] = att[i].Split('-')[1];
                dtrow["tblName"] = "pac" + i.ToString();
                tbl.Rows.Add(dtrow);
            }
        }

        query += " left outer join ps_stock_available as psa on (psa.id_product = prod.id_product and psa.id_product_attribute = 0 ) inner join ps_attribute_lang al on pac.id_attribute=al.id_attribute where cat.id_lang = 1 and catp.id_category =" + CatID + "  and pl.id_lang = 1 and prod.active = 1 ";
        if (tbl.Rows.Count > 0)
        {
            DataView view = new DataView(tbl);
            DataTable distinctValues = view.ToTable(true, "groupID");
            for (int i = 0; i < distinctValues.Rows.Count; i++)
            {
                DataRow[] results = tbl.Select("groupID='" + distinctValues.Rows[i][0].ToString() + "'");
                if (results.Length > 0)
                {
                    DataTable dtf = new DataTable();
                    dtf = results.CopyToDataTable();
                    query += " and (";
                    for (int j = 0; j < dtf.Rows.Count; j++)
                    {
                        if (j == 0)
                            query += " " + dtf.Rows[j]["tblName"].ToString() + ".id_attribute=" + dtf.Rows[j]["attID"].ToString() + " ";
                        else
                            query += " or " + dtf.Rows[j]["tblName"].ToString() + ".id_attribute=" + dtf.Rows[j]["attID"].ToString() + " ";
                    }
                    query += ")";
                }
            }






            //for (int i = 0; i < att.Length; i++)
            //{
            //    string pre = "";
            //    if (i == 0)
            //    {
            //        query += " and (";
            //        pre = att[i].Split('-')[1];
            //        query += " pac" + i + ".id_attribute=" + att[i].Split('-')[0] + " ";
            //    }
            //    else
            //    {
            //        if (pre == att[i].Split('-')[1])
            //        {
            //            query += " or pac" + i + ".id_attribute=" + att[i].Split('-')[0] + " ";
            //        }
            //        else
            //        {
            //            query += ") and (";
            //            query += " or pac" + i + ".id_attribute=" + att[i].Split('-')[0] + " ";

            //        }
            //    }

            //}
        }

        string qnew = "";
        if (tbl.Rows.Count > 0)
        {
            DataView view = new DataView(tbl);
            DataTable distinctValues = view.ToTable(true, "groupID");
            for (int i = 0; i < distinctValues.Rows.Count; i++)
            {
                DataRow[] results = tbl.Select("groupID='" + distinctValues.Rows[i][0].ToString() + "'");
                if (results.Length > 0)
                {
                    qnew += " inner join ps_product_attribute_combination pac" + i + " on ( pa.id_product_attribute=pac" + i + ".id_product_attribute";
                    DataTable dtf = new DataTable();
                    dtf = results.CopyToDataTable();
                    qnew += " and (";
                    for (int j = 0; j < dtf.Rows.Count; j++)
                    {
                        if (j == 0)
                            qnew += " pac" + i + ".id_attribute=" + dtf.Rows[j]["attID"].ToString() + " ";
                        else
                            qnew += " or pac" + i + ".id_attribute=" + dtf.Rows[j]["attID"].ToString() + " ";
                    }
                    qnew += "))";
                }
            }
        }

        if (OrderBy == "0")
            query += " order by prod.id_product desc ";
        if (OrderBy == "NA")
            query += " order by pl.name";
        if (OrderBy == "ND")
            query += " order by pl.name desc";
        if (OrderBy == "PL")
            query += " order by cast(prod.price as decimal(18,2))";
        if (OrderBy == "PH")
            query += " order by cast(prod.price as decimal(18,2)) desc";

        ds = data.getDataSet(query);
        return ds;
    }


    public DataSet getMainGroupStone(string CatID)
    {

        cmd = new SqlCommand("SP_getMainGroupStone");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CatID", CatID);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getMainGroup(string CatID)
    {
        cmd = new SqlCommand("SP_getMainGroup");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CatID", CatID);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getAttribute(string CatID, string GroupID)
    {
        cmd = new SqlCommand("SP_getAttributes");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CatID", CatID);
        cmd.Parameters.AddWithValue("@GroupID", GroupID);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getMainGroupNew()
    {

        cmd = new SqlCommand("spu_getMainGroupNew");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
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


    public DataSet getDetail(string ProdID)
    {
        cmd = new SqlCommand("sp_GetProductDetail");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdId", ProdID);
        ds = data.getDataSet(cmd);
        return ds;

        //query = "select distinct cast((case when (select isnull(reduction,0) from ps_specific_price where id_product=prod.id_product) is null then 0 else (((select isnull(reduction,0) from ps_specific_price where id_product=prod.id_product))*100) end) as int)  as Discount,cast((cast(prod.price as decimal(18,2))- (case when (select isnull(reduction,0) from ps_specific_price where id_product=prod.id_product) is null then 0 else (((select isnull(reduction,0) from ps_specific_price where id_product=prod.id_product))*cast(prod.price as decimal(18,2))) end)) as decimal(18,2))  as DiscountPrice,cast(cat.id_category as nvarchar(50))+'.jpg' as CatImage, cat.name as CatName, prod.id_product as ProdID, pl.name as ProdName,cast(prod.price as decimal(18,2)) as ProdPrice,pl.description_short,pl.description, prod.reference,prod.unity, cl.name as CatName, cast(cl.id_category as nvarchar(50))+'-'+replace(replace(cl.name,' ','-'),'-/-','-') as CatURL from ps_product prod  inner  join ps_category_lang cat on prod.id_category_default = cat.id_category  inner  join ps_product_lang pl on prod.id_product = pl.id_product Left outer join ps_category_product catp on prod.id_product=catp.id_product inner  join  ps_category_lang cl on cat.id_category=cl.id_category where cat.id_lang = 1 and prod.id_product =" + ProdID + " and pl.id_lang = 1 and prod.active = 1 and cl.id_lang=1";
        //ds = data.getDataSet(query);
    }

    public DataSet getProductStockDetail(string ProdID, string AttributeID)
    {
        cmd = new SqlCommand("sp_GetProductStockDetail");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdId", ProdID);
        cmd.Parameters.AddWithValue("@AttID", AttributeID);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public void ProdViewdCookies(string ProdId)
    {
        HttpCookie viewedprod;
        HttpCookie myCookie;
        if (HttpContext.Current.Request.Cookies["viewedprod"] != null)
        {
            string UserID = "0";
            myCookie = HttpContext.Current.Request.Cookies["viewedprod"];
            string ProdOld = myCookie.Values["ProdID"].ToString();
            string prodN = ProdOld.Replace("," + ProdId + "", "");
            if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
            {
                HttpCookie user = HttpContext.Current.Request.Cookies["custSniggle"];
                UserID = user.Values["id_customer"].ToString();
            }
            prodN = ProdId + "," + prodN;
            SubmitLastViewProd(UserID, ProdId, DateTime.Now.ToString());
            string prodF = prodN.Replace("," + ProdId + "", "");
            if (prodF != "" && prodF != null)
            {
                string nnn = "";
                string[] prodNew = prodF.Split(',');
                int pLength = prodNew.Length;
                if (pLength >= 10)
                {
                    for (int ii = 9; ii >= 0; ii--)
                    {
                        if (nnn == "")
                        {
                            nnn = prodNew[ii];
                        }
                        else
                        {
                            nnn = prodNew[ii] + "," + nnn;
                        }
                    }
                }
                else
                {
                    for (int ii = pLength - 1; ii >= 0; ii--)
                    {
                        if (nnn == "")
                        {
                            nnn = prodNew[ii];
                        }
                        else
                        {
                            nnn = prodNew[ii] + "," + nnn;
                        }
                    }
                }
                //prodF = nnn.Replace("," + ProdId + "", "");
                HttpContext.Current.Response.Cookies["viewedprod"].Expires = DateTime.Now.AddDays(-1d);
                if (HttpContext.Current.Request.Cookies["viewedprod"] != null)
                {
                    viewedprod = new HttpCookie("viewedprod");
                    viewedprod.Expires = DateTime.Now.AddDays(100d);
                    viewedprod.Values.Add("ProdID", nnn);
                    HttpContext.Current.Response.Cookies.Add(viewedprod);
                }
            }
        }
        else
        {
            viewedprod = new HttpCookie("viewedprod");
            viewedprod.Expires = DateTime.Now.AddDays(10d);
            viewedprod.Values.Add("ProdID", ProdId);
            HttpContext.Current.Response.Cookies.Add(viewedprod);
        }
    }

    public DataSet geItemFeatures(string ProdID)
    {
        //query = "SELECT b.name, value FROM  ps_feature AS a LEFT OUTER JOIN ps_feature_lang AS b ON b.id_feature = a.id_feature AND b.id_lang = 1 INNER JOIN ps_feature_product AS p ON p.id_feature = a.id_feature INNER JOIN ps_feature_value AS fv ON fv.id_feature_value = p.id_feature_value INNER JOIN ps_feature_value_lang AS fl ON fl.id_feature_value = p.id_feature_value AND fl.id_lang = 1 where p.id_product = " + ProdID + " order by a.position";

        cmd = new SqlCommand("sp_GetProductsFeatures");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdId", ProdID);
        ds = data.getDataSet(cmd);
        return ds;
    }


    public DataSet geItemReviews(string ProdID)
    {
        query = "select content,customer_name,grade,CONVERT(char(10), date_add,103) as dat from ps_product_comment where id_product=" + ProdID + " and deleted = 0 and active = 1 order by CONVERT(char(10), date_add,103) desc";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getItemImages(string ProdID)
    {
        cmd = new SqlCommand("sp_GetItemImages");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdId", ProdID);
        ds = data.getDataSet(cmd);
        return ds;

        //query = "select img.id_image,imgl.legend,img.position,img.cover,'/img/'+REPLACE(REPLACE(RTRIM(c.name),' ',' '),'/-','')+'/'+cast(img.id_image as nvarchar)+'.jpg' as ImageUrl, '/img/' + REPLACE(REPLACE(RTRIM(c.name), ' ', ' '), '/', '') + '/' + cast(img.id_image as nvarchar) + '-tm_cart_default.jpg' as smallimg, '/img/' + REPLACE(REPLACE(RTRIM(c.name), ' ', ' '), '/', '') + '/' + cast(img.id_image as nvarchar) + '-tm_thickbox_default.jpg' as bigimg  from ps_image as img inner join ps_image_lang as imgl on img.id_image = imgl.id_image inner join ps_product as P on p.id_product = img.id_product inner join ps_category_lang as C on p.id_category_default = C.id_category and C.id_lang = 1 where img.IsDeleted = 0 and imgl.id_lang = 1 and img.id_product = " + ProdID + " order by img.position";
        //ds = data.getDataSet(query);
        //return ds;
    }

    public DataSet getVideo(string ProdID)
    {
        query = " Select * From ps_product_video_lang where id_product = '" + ProdID + "'";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getItemMainGroup(string ProdID, string Type)
    {
        cmd = new SqlCommand("SP_getMainGroupItem");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdID", ProdID);
        cmd.Parameters.AddWithValue("@Type", Type);
        ds = data.getDataSet(cmd);
        return ds;
    }


    public DataSet getItemAttribute(string ProdID, string Type)
    {
        cmd = new SqlCommand("SP_getAttributesItem");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ProdID", ProdID);
        cmd.Parameters.AddWithValue("@GroupID", Type);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getAddress(string customerid, string addid)
    {
        query = "select * from ps_address where id_address<>0 and active = 1 and deleted  = 0 ";
        if (customerid != "")
            query += " and id_customer =" + customerid + "";
        if (addid != "")
            query += " and id_address=" + addid + "";
        //query += "  order by id_address desc ";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet GetAddressAlias(string customerid, string alias, string addid)
    {
        if (addid == "0")
        {
            query = "select * from ps_address where id_address<>0 and active = 1 and deleted  = 0 ";
            if (customerid != "")
                query += " and id_customer =" + customerid + "";

            query += " and alias ='" + alias + "'";
            //query += "  order by id_address desc ";
            ds = data.getDataSet(query);
        }
        else
        {
            query = "select * from ps_address where id_address<>0 and active = 1 and deleted  = 0 ";
            if (customerid != "")
                query += " and id_customer =" + customerid + "";

            query += " and alias ='" + alias + "' and alias ='" + alias + "' and id_address  !='" + addid + "' ";
            ds = data.getDataSet(query);
        }

        return ds;
    }


    #region Shankar Code Start

    public string getTopMenu()
    {
        bool IsMegaMenu = false;
        bool IsCMSPage = false;
        DataSet dsT = new DataSet();
        string str = "";
        query = "    Select * From tbl_Menu where IsDeleted = 0 and Active = 1 order by DisplayIndex ";
        dsT = data.getDataSet(query);
        if (dsT.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsT.Tables[0].Rows.Count; i++)
            {
                IsCMSPage = false;
                IsMegaMenu = Convert.ToBoolean(dsT.Tables[0].Rows[i]["IsMegaMenu"].ToString());
                if (dsT.Tables[0].Rows[i]["IsCMS"].ToString() == "True")
                {
                    IsCMSPage = true;
                }
                DataSet dsS = new DataSet();
                DataSet dsTH = new DataSet(); 
                dsS = getSearchCategory("0", dsT.Tables[0].Rows[i]["id_Menu"].ToString());
                if (dsS.Tables[0].Rows.Count > 0)
                {
                    if (IsMegaMenu == true)
                    {
                        #region Mega Menu
                        if (dsT.Tables[0].Rows[i]["Link"].ToString() != null && dsT.Tables[0].Rows[i]["Link"].ToString() != "")
                        {
                            string link = dsT.Tables[0].Rows[i]["Link"].ToString();
                            if (link != "" && link != "#")
                            {
                                str += " <li class=\"has-dropdown has-megaitem\"><a href='/" + dsT.Tables[0].Rows[i]["Link"].ToString() + "'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + " <i class=\"fa fa-angle-down\"></i></a>";
                            }
                            else
                            {
                                str += "<li class=\"has-dropdown has-megaitem\"><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "<i class=\"fa fa-angle-down\"></i></a>";
                            }
                        }
                        else
                        {
                            str += "<li class=\"has-dropdown has-megaitem\"><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "<i class=\"fa fa-angle-down\"></i></a>";
                        }
                        str += " <div class=\"mega-menu\">";
                        str += " <div class=\"row\">";
                        int sNo = 0;
                        int lNo = 3;
                        int totCount = dsS.Tables[0].Rows.Count;
                        for (int ii = 0; ii < dsS.Tables[0].Rows.Count; ii++)
                        {

                            str += "<div class=\"col-3\">";
                            dsTH = getSearchCategory(dsS.Tables[0].Rows[ii]["id_category"].ToString(), dsT.Tables[0].Rows[i]["id_Menu"].ToString(), "Mega");

                            str += "<div class=\"title\"><a href='/" + dsS.Tables[0].Rows[ii]["Url"].ToString() + "'><strong>" + dsS.Tables[0].Rows[ii]["name"].ToString() + "</strong></a></div> ";
                            if (dsTH.Tables[0].Rows.Count > 0)
                            {
                                str += " <ul class=\"mega-menu-sub\">";
                                for (int th = 0; th < dsTH.Tables[0].Rows.Count; th++)
                                {
                                    str += "<li><a href='/" + dsTH.Tables[0].Rows[th]["url"].ToString() + "'>" + dsTH.Tables[0].Rows[th]["name"].ToString() + "</a></li>";
                                }
                                str += " </ul> ";
                            }
                            str += " </div> ";
                        }
                        str += " </div> ";
                        str += " </div> ";
                        #endregion
                    }
                    else
                    {
                        #region Normal Menu
                        if (dsT.Tables[0].Rows[i]["Link"].ToString() != null && dsT.Tables[0].Rows[i]["Link"].ToString() != "")
                        {
                            string link = dsT.Tables[0].Rows[i]["Link"].ToString();
                            if (link != "" && link != "#")
                            {
                                str += " <li class=\"has-dropdown\"><a href='/" + dsT.Tables[0].Rows[i]["Link"].ToString() + "'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + " <i class=\"fa fa-angle-down\"></i></a>";
                            }
                            else
                            {
                                str += "<li class=\"has-dropdown\"><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "<i class=\"fa fa-angle-down\"></i></a>";
                            }
                            str += " <ul class=\"sub-menu\" >";
                        }
                        else
                        {
                            str += "<li class=\"has-dropdown\"><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "<i class=\"fa fa-angle-down\"></i></a>";
                            str += " <ul class=\"sub-menu\" >";
                        }
                        for (int ii = 0; ii < dsS.Tables[0].Rows.Count; ii++)
                        {
                            str += "<li><a href='/" + dsS.Tables[0].Rows[ii]["Url"].ToString() + "'>" + dsS.Tables[0].Rows[ii]["name"].ToString() + "</a></li> ";
                        }
                        str += " </ul> ";
                        str += " </li> ";
                        #endregion
                    }
                    //if (dsT.Tables[0].Rows[i]["Link"].ToString() != null && dsT.Tables[0].Rows[i]["Link"].ToString() != "")
                    //{
                    //    string link = dsT.Tables[0].Rows[i]["Link"].ToString();
                    //    if (link != "" && link != "#")
                    //    {
                    //        str += " <li><a href='/" + dsT.Tables[0].Rows[i]["Link"].ToString() + "'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                    //    }
                    //    else
                    //    {
                    //        str += "<li><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                    //    }
                    //    str += " <ul class=\"sub-menu\" >";
                    //}
                    //else
                    //{
                    //    str += "<li><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                    //    str += " <ul class=\"mobile-sub-menu\" >";
                    //}
                    //for (int ii = 0; ii < dsS.Tables[0].Rows.Count; ii++)
                    //{
                    //    str += "<li><a href='/" + dsS.Tables[0].Rows[ii]["Url"].ToString() + "'>" + dsS.Tables[0].Rows[ii]["name"].ToString() + "</a></li> ";
                    //}
                    //str += " </ul> ";
                    //str += " </li> ";
                }
                else
                {
                    if (IsCMSPage == true)
                    {
                        DataSet dsCms = new DataSet();
                        dsCms = getCMSpage(dsT.Tables[0].Rows[i]["id_Menu"].ToString(), "List");
                        if (dsCms.Tables[0].Rows.Count > 0)
                        {
                            string link = dsT.Tables[0].Rows[i]["Link"].ToString();
                            if (link != "" && link != "#")
                            {
                                str += "<li class=\"has-dropdown\"><a href='/" + dsT.Tables[0].Rows[i]["Link"].ToString() + "'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "<i class=\"fa fa-angle-down\"></i></a>";
                            }
                            else
                            {
                                str += "<li class=\"has-dropdown\"><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "<i class=\"fa fa-angle-down\"></i></a>";
                            }
                            str += " <ul class=\"sub-menu\" >";
                            for (int j = 0; j < dsCms.Tables[0].Rows.Count; j++)
                            {
                                if (dsCms.Tables[0].Rows[j]["IsCategory"].ToString() == "True")
                                {
                                    str += "<li><a href='/" + dsCms.Tables[0].Rows[j]["Url"].ToString() + "'>" + dsCms.Tables[0].Rows[j]["Name"].ToString() + "</a></li> ";
                                }
                                else
                                {
                                    str += "<li><a href='/content/" + dsCms.Tables[0].Rows[j]["Url"].ToString() + "'>" + dsCms.Tables[0].Rows[j]["Name"].ToString() + "</a></li> ";
                                }

                            }
                            str += " </ul> ";
                            str += " </li> ";
                        }
                        else
                        {
                            if (dsT.Tables[0].Rows[i]["MenuName"].ToString() == "Home")
                            {
                                str += " <li class=\"\"><a href='/'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + " </a>";
                            }
                            else
                            {
                                str += "<li><a  class=\"active main-menu-link\" href='/content/" + dsT.Tables[0].Rows[i]["Link"].ToString() + "'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a></li> ";
                            }
                        }
                    }
                    else
                    {
                        str += "<li><a class=\"active main-menu-link\" href='/" + dsT.Tables[0].Rows[i]["Link"].ToString() + "'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a></li> ";
                    }
                }
            }
        }
        return str;
    }
    public string getTopMenuM()
    {
        bool flag = false;
        bool flag2 = false;
        DataSet dataSet = new DataSet();
        string text = "";
        query = "    Select * From tbl_Menu where IsDeleted = 0 and Active = 1 order by DisplayIndex ";
        dataSet = data.getDataSet(query);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                flag = false;
                flag2 = Convert.ToBoolean(dataSet.Tables[0].Rows[i]["IsMegaMenu"].ToString());
                if (dataSet.Tables[0].Rows[i]["IsCMS"].ToString() == "True")
                {
                    flag = true;
                }

                DataSet dataSet2 = new DataSet();
                DataSet dataSet3 = new DataSet();
                dataSet2 = getSearchCategory("0", dataSet.Tables[0].Rows[i]["id_Menu"].ToString());
                if (dataSet2.Tables[0].Rows.Count > 0)
                {
                    if (flag2)
                    {
                        if (dataSet.Tables[0].Rows[i]["Link"].ToString() != null && dataSet.Tables[0].Rows[i]["Link"].ToString() != "")
                        {
                            string text2 = dataSet.Tables[0].Rows[i]["Link"].ToString();
                            if (text2 != "" && text2 != "#")
                            {
                                string text3 = text;
                                text = text3 + " <li><a href='/" + dataSet.Tables[0].Rows[i]["Link"].ToString() + "'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                            }
                            else
                            {
                                text = text + "<li><a href='#'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                            }
                        }
                        else
                        {
                            text = text + "<li><a href='#'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                        }

                        text += " <ul class=\"mobile-sub-menu\">";
                        for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
                        {
                            dataSet3 = getSearchCategory(dataSet2.Tables[0].Rows[j]["id_category"].ToString(), dataSet.Tables[0].Rows[i]["id_Menu"].ToString(), "Mega");
                            string text3 = text;
                            text = text3 + "<li><a href='/" + dataSet2.Tables[0].Rows[j]["Url"].ToString() + "'>" + dataSet2.Tables[0].Rows[j]["name"].ToString() + "</a> ";
                            if (dataSet3.Tables[0].Rows.Count > 0)
                            {
                                text += " <ul class=\"mobile-sub-menu\">";
                                for (int k = 0; k < dataSet3.Tables[0].Rows.Count; k++)
                                {
                                    text3 = text;
                                    text = text3 + "<li><a href='/" + dataSet3.Tables[0].Rows[k]["url"].ToString() + "'>" + dataSet3.Tables[0].Rows[k]["name"].ToString() + "</a></li>";
                                }

                                text += " </ul> ";
                            }

                            text += "</li>";
                        }

                        text += " </ul> ";
                        text += " </li> ";
                        continue;
                    }

                    if (dataSet.Tables[0].Rows[i]["Link"].ToString() != null && dataSet.Tables[0].Rows[i]["Link"].ToString() != "")
                    {
                        string text2 = dataSet.Tables[0].Rows[i]["Link"].ToString();
                        if (text2 != "" && text2 != "#")
                        {
                            string text3 = text;
                            text = text3 + " <li><a href='/" + dataSet.Tables[0].Rows[i]["Link"].ToString() + "'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                        }
                        else
                        {
                            text = text + "<li><a href='#'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                        }

                        text += " <ul class=\"sub-menu\" >";
                    }
                    else
                    {
                        text = text + "<li><a href='#'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                        text += " <ul class=\"mobile-sub-menu\" >";
                    }

                    for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
                    {
                        string text3 = text;
                        text = text3 + "<li><a href='/" + dataSet2.Tables[0].Rows[j]["Url"].ToString() + "'>" + dataSet2.Tables[0].Rows[j]["name"].ToString() + "</a></li> ";
                    }

                    text += " </ul> ";
                    text += " </li> ";
                }
                else if (flag)
                {
                    DataSet dataSet4 = new DataSet();
                    dataSet4 = getCMSpage(dataSet.Tables[0].Rows[i]["id_Menu"].ToString(), "List");
                    if (dataSet4.Tables[0].Rows.Count > 0)
                    {
                        string text2 = dataSet.Tables[0].Rows[i]["Link"].ToString();
                        if (text2 != "" && text2 != "#")
                        {
                            string text3 = text;
                            text = text3 + "<li><a href='/" + dataSet.Tables[0].Rows[i]["Link"].ToString() + "'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                        }
                        else
                        {
                            text = text + "<li><a href='#'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                        }

                        text += " <ul class=\"mobile-sub-menu\" >";
                        for (int l = 0; l < dataSet4.Tables[0].Rows.Count; l++)
                        {
                            if (dataSet4.Tables[0].Rows[l]["IsCategory"].ToString() == "True")
                            {
                                string text3 = text;
                                text = text3 + "<li><a href='/" + dataSet4.Tables[0].Rows[l]["Url"].ToString() + "'>" + dataSet4.Tables[0].Rows[l]["Name"].ToString() + "</a></li> ";
                            }
                            else
                            {
                                string text3 = text;
                                text = text3 + "<li><a href='/content/" + dataSet4.Tables[0].Rows[l]["Url"].ToString() + "'>" + dataSet4.Tables[0].Rows[l]["Name"].ToString() + "</a></li> ";
                            }
                        }

                        text += " </ul> ";
                        text += " </li> ";
                    }
                    else if (dataSet.Tables[0].Rows[i]["MenuName"].ToString() == "Home")
                    {
                        text = text + " <li class=\"\"><a href='/'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + " </a>";
                    }
                    else
                    {
                        string text3 = text;
                        text = text3 + "<li><a href='/content/" + dataSet.Tables[0].Rows[i]["Link"].ToString() + "'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + "</a></li> ";
                    }
                }
                else
                {
                    string text3 = text;
                    text = text3 + "<li><a href='/" + dataSet.Tables[0].Rows[i]["Link"].ToString() + "'>" + dataSet.Tables[0].Rows[i]["MenuName"].ToString() + "</a></li> ";
                }
            }
        }

        return text;
    }

    public string getTopMenuM11()
    {
        bool IsCMSPage = false;
        DataSet dsT = new DataSet();
        string str = "";
        query = "    Select * From tbl_Menu where IsDeleted = 0 and Active = 1 order by DisplayIndex ";
        dsT = data.getDataSet(query);
        if (dsT.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsT.Tables[0].Rows.Count; i++)
            {
                IsCMSPage = false;
                if (dsT.Tables[0].Rows[i]["IsCMS"].ToString() == "True")
                {
                    IsCMSPage = true;
                }
                DataSet dsS = new DataSet();
                dsS = getSearchCategory("2", dsT.Tables[0].Rows[i]["id_Menu"].ToString());
                if (dsS.Tables[0].Rows.Count > 0)
                {
                    if (dsT.Tables[0].Rows[i]["Link"].ToString() != null && dsT.Tables[0].Rows[i]["Link"].ToString() != "")
                    {
                        string link = dsT.Tables[0].Rows[i]["Link"].ToString();
                        if (link != "" && link != "#")
                        {
                            str += " <li><a href='/" + dsT.Tables[0].Rows[i]["Link"].ToString() + "'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                        }
                        else
                        {
                            str += "<li><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                        }
                    }
                    else
                    {
                        str += "<li><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a>";
                    }
                    str += " <ul class=\"mobile-sub-menu\">";
                    for (int ii = 0; ii < dsS.Tables[0].Rows.Count; ii++)
                    {
                        //dsTH = getSearchCategory(dsS.Tables[0].Rows[ii]["id_category"].ToString(), dsT.Tables[0].Rows[i]["id_Menu"].ToString(), "Mega");
                        str += "<li><a href='/" + dsS.Tables[0].Rows[ii]["Url"].ToString() + "'>" + dsS.Tables[0].Rows[ii]["name"].ToString() + "</a> ";
                        //if (dsTH.Tables[0].Rows.Count > 0)
                        //{
                        //    str += " <ul class=\"mobile-sub-menu\">";
                        //    for (int th = 0; th < dsTH.Tables[0].Rows.Count; th++)
                        //    {
                        //        str += "<li><a href='/" + dsTH.Tables[0].Rows[th]["url"].ToString() + "'>" + dsTH.Tables[0].Rows[th]["name"].ToString() + "</a></li>";
                        //    }
                        //    str += " </ul> ";
                        //}
                        str += "</li>";
                    }
                    str += " </ul> ";
                    str += " </li> ";
                }
                else
                {
                    if (IsCMSPage == true)
                    {
                        DataSet dsCms = new DataSet();
                        dsCms = getCMSpage(dsT.Tables[0].Rows[i]["id_Menu"].ToString(), "List");
                        if (dsCms.Tables[0].Rows.Count > 0)
                        {
                            string link = dsT.Tables[0].Rows[i]["Link"].ToString();
                            if (link != "" && link != "#")
                            {
                                str += "<li class=\"has-dropdown\"><a href='/" + dsT.Tables[0].Rows[i]["Link"].ToString() + "'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "<i class=\"fa fa-angle-down\"></i></a>";
                            }
                            else
                            {
                                str += "<li class=\"has-dropdown\"><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "<i class=\"fa fa-angle-down\"></i></a>";
                            }
                            str += " <ul class=\"sub-menu\" >";
                            for (int j = 0; j < dsCms.Tables[0].Rows.Count; j++)
                            {
                                if (dsCms.Tables[0].Rows[j]["IsCategory"].ToString() == "True")
                                {
                                    str += "<li><a href='/" + dsCms.Tables[0].Rows[j]["Url"].ToString() + "'>" + dsCms.Tables[0].Rows[j]["Name"].ToString() + "</a></li> ";
                                }
                                else
                                {
                                    str += "<li><a href='/content/" + dsCms.Tables[0].Rows[j]["Url"].ToString() + "'>" + dsCms.Tables[0].Rows[j]["Name"].ToString() + "</a></li> ";
                                }

                            }
                            str += " </ul> ";
                            str += " </li> ";
                        }
                        else
                        {
                            if (dsT.Tables[0].Rows[i]["MenuName"].ToString() == "Home")
                            {
                                str += " <li class=\"\"><a href='/'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + " </a>";
                            }
                            else
                            {
                                str += "<li><a  class=\"active main-menu-link\" href='/content/" + dsT.Tables[0].Rows[i]["Link"].ToString() + "'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a></li> ";
                            }
                        }
                    }
                    else
                    {
                        str += "<li><a class=\"active main-menu-link\" href='/" + dsT.Tables[0].Rows[i]["Link"].ToString() + "'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a></li> ";
                    }
                }
            }
        }
        return str;
    }
    public string getTopMenuOld()
    {
        bool IsCMSPage = false;
        DataSet dsT = new DataSet();
        string str = "";
        query = "   Select * From tbl_Menu where IsDeleted = 0 order by DisplayIndex  ";
        dsT = data.getDataSet(query);
        if (dsT.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsT.Tables[0].Rows.Count; i++)
            {
                if (dsT.Tables[0].Rows[i]["IsCMS"].ToString() == "True")
                {
                    IsCMSPage = true;
                }

                DataSet dsS = new DataSet();
                dsS = getSearchCategory("2", dsT.Tables[0].Rows[i]["id_Menu"].ToString());
                if (dsS.Tables[0].Rows.Count > 0)
                {
                    str += "<li class=\"menu-item menu-item9  hasChild\"><a href='#'><span>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</span> <i class=\"hidden-md-down pe-7s-angle-down\" style=\"font-size: 26px;\"></i></a>";
                    str += "  <span class=\"icon-drop-mobile\"><i class=\"material-icons add\">add</i><i class=\"material-icons remove\">remove </i></span>";
                    str += " <div class=\"menu-dropdown cat-drop-menu menu_slidedown\"> ";
                    str += " <ul class=\"pos-sub-inner\" >";
                    for (int ii = 0; ii < dsS.Tables[0].Rows.Count; ii++)
                    {
                        DataSet dsTT = new DataSet();
                        dsTT = getSearchCategory(dsS.Tables[0].Rows[ii]["id_category"].ToString(), dsT.Tables[0].Rows[i]["id_Menu"].ToString());
                        if (dsTT.Tables[0].Rows.Count > 0)
                        {
                            str += " <li> ";
                            str += "<a href='/" + dsS.Tables[0].Rows[ii]["Url"].ToString() + "'><span>" + dsS.Tables[0].Rows[ii]["name"].ToString() + "</span></a> ";

                            str += "  <span class=\"icon-drop-mobile\"><i class=\"material-icons add\">add</i><i class=\"material-icons remove\">remove </i></span>";
                            str += " <ul class=\"menu-dropdown cat-drop-menu\" >";
                            for (int iii = 0; iii < dsTT.Tables[0].Rows.Count; iii++)
                            {
                                str += "<li><a href='/" + dsTT.Tables[0].Rows[iii]["Url"].ToString() + "'><span>" + dsTT.Tables[0].Rows[iii]["name"].ToString() + "</span></a></li> ";
                            }
                            str += " </ul> ";
                            str += " <li> ";
                        }
                        else
                        {
                            str += "<li><a href='/" + dsS.Tables[0].Rows[ii]["Url"].ToString() + "'><span>" + dsS.Tables[0].Rows[ii]["name"].ToString() + "</span></a></li> ";
                        }
                    }
                    str += " </ul> ";
                    str += " </div> ";
                    str += " </li> ";
                }
                else
                {
                    if (IsCMSPage == true)
                    {
                        DataSet dsCms = new DataSet();
                        dsCms = getCMSpage(dsT.Tables[0].Rows[i]["id_Menu"].ToString(), "List");
                        if (dsCms.Tables[0].Rows.Count > 0)
                        {
                            str += "<li class=\"menu-item menu-item9  hasChild\"><a href='#'><span>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</span> <i class=\"hidden-md-down pe-7s-angle-down\" style=\"font-size: 26px;\"></i></a>";
                            str += "  <span class=\"icon-drop-mobile\"><i class=\"material-icons add\">add</i><i class=\"material-icons remove\">remove </i></span>";
                            str += " <div class=\"menu-dropdown cat-drop-menu menu_slidedown\"> ";
                            str += " <ul class=\"pos-sub-inner\" >";
                            for (int j = 0; j < dsCms.Tables[0].Rows.Count; j++)
                            {
                                str += "<li><a href='/content/" + dsCms.Tables[0].Rows[j]["link_rewrite"].ToString() + "'><span>" + dsCms.Tables[0].Rows[j]["meta_title"].ToString() + "</span></a></li> ";
                            }
                            str += " </ul> ";
                            str += " </div> ";
                            str += " </li> ";
                        }
                        else
                        {
                            str += "<li class=\"menu-item menu-item11\"><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a></li> ";
                        }
                    }
                    else
                    {
                        str += "<li class=\"menu-item menu-item11\"><a href='#'>" + dsT.Tables[0].Rows[i]["MenuName"].ToString() + "</a></li> ";
                    }
                }
            }
        }
        return str;
    }

    public DataSet getSearchCategory(string ParentId, string MenuId, string type = "Normal")
    {
        cmd = new SqlCommand("sp_GetCategoryS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ParentId", ParentId);
        cmd.Parameters.AddWithValue("@MenuId", MenuId); 
        cmd.Parameters.AddWithValue("@type", type);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getSearchCategory()
    {
        //query = " select cl.*, ISNULL(cast( cat.id_category as nvarchar(500)),'') + '-' +  ISNULL(REPLACE(cl.link_rewrite ,' ','-'),'')  as Url  ";
        //query += " from  ps_category_lang cl inner join ps_category cat on cl.id_category=cat.id_category WHERE cat.active = 1 and cat.IsDeleted = 0 and  cl.id_lang = 1  ";
        //query += " and (cat.id_parent  != 0 and cat.id_parent != 1) order by cat.position ";
        //ds = data.getDataSet(query);
        cmd = new SqlCommand("sp_GetSearchCategory");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getCMSpage(string PageName, string Type)
    {
        cmd = new SqlCommand("sp_GetCMSPage");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Page", PageName);
        cmd.Parameters.AddWithValue("@Type", Type);
        ds = data.getDataSet(cmd);
        return ds;
    }


    public DataSet getNewArrivals(string Type, string CatID)
    {
        cmd = new SqlCommand("sp_GetNewArrivals");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Top", "10");
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@CatId", CatID);
        ds = data.getDataSet(cmd);
        return ds;
    }


    public DataSet GetFromTheBlog()
    {
        cmd = new SqlCommand("sp_GetFromBlog");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet GetTestimonials()
    {
        cmd = new SqlCommand("sp_GetTesttimonials");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        ds = data.getDataSet(cmd);
        return ds;
    }

    public string BindProductHtml(string prodID)
    {
        GetData data = new GetData();
        Data dat = new Data();
        DataSet ds = data.getDetail(prodID);
        DataSet dsImg = data.getItemImages(ds.Tables[0].Rows[0]["id_product"].ToString());
        string str = " ";
        string imgurlM = "";
        string descriptionM = "";
        string detailUrlM = ""; string dispriceM = "";
        string prodNameM = ""; string skuM = ""; string IsPersonalized = ""; string TermsCondition = "";

        //getDetail and Description detail DIV
        IsPersonalized = ds.Tables[0].Rows[0]["IsPersonalized"].ToString();
        descriptionM = ds.Tables[0].Rows[0]["description"].ToString();
        TermsCondition = ds.Tables[0].Rows[0]["TermsCondition"].ToString();
        detailUrlM = ds.Tables[0].Rows[0]["DetailUrl"].ToString();
        dispriceM = ds.Tables[0].Rows[0]["DiscountPrice"].ToString();
        prodNameM = ds.Tables[0].Rows[0]["prodFullName"].ToString();
        skuM = ds.Tables[0].Rows[0]["reference"].ToString();
        #region Product Details
        str += " <div class=\"product-details-text\">";
        str += " <p class=\"reference\">Reference:<span id=\"skuquik\"> " + skuM + "</span></p>";
        str += " <h4 class=\"title\">" + ds.Tables[0].Rows[0]["prodFullName"].ToString() + "</h4>";
        str += "<div class=\"d-flex align-items-center\">";
        str += "<ul class=\"review-star\">";
        string rating = BindStar(ds.Tables[0].Rows[0]["Rating"].ToString());
        str += rating;
        str += "</ul>";
        str += " <a data-bs-toggle=\"tab\" href=\"#review\" class=\"customer-review ml-2 nav-link\">(" + ds.Tables[0].Rows[0]["ReviewCount"].ToString() + ")</a>";
        str += "</div>";
        //str += "<div class=\"price\">₹ <del>" + ds.Tables[0].Rows[0]["ProdPrice"].ToString() + "</del></div>";
        str += "<div class=\"price\"><del class=\"" + ds.Tables[0].Rows[0]["pDis"].ToString() + "\">₹<span id=\"prodwithoutdiscountprice\">" + ds.Tables[0].Rows[0]["ProdPrice"].ToString() + "</span></del> ₹<span id=\"sppricenewquik\">" + ds.Tables[0].Rows[0]["DiscountPrice"].ToString() + "</span> <span  class=\"" + ds.Tables[0].Rows[0]["pDis"].ToString() + "\">(" + ds.Tables[0].Rows[0]["Discount"].ToString() + "% Off)</span></div>";
        str += "</div>";
        str += " <hr/>";
        str += "  <h4 class=\"title pb-2 pt-2\">Available Options</h4>"; 
        #endregion
        #region Product According to Group Id
        if (ds.Tables[2].Rows.Count > 0)
        {
            str += "<div class=\"variable-single-item\">";
            str += "<span>Color</span>";
            str += "<div class=\"product-variable-img\">";
            str += " <ul>";
            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            {
                str += " <li class=\"" + ds.Tables[2].Rows[i]["actCalss"].ToString() + "\"><a href=\"/" + ds.Tables[2].Rows[i]["DetailUrl"].ToString() + "\">";
                str += " <img class=\"img-fluid\" src=\"" + ds.Tables[2].Rows[i]["img"].ToString() + "\" />";
                str += "</a></li>";


                //str += "<a href=\"/" + ds.Tables[2].Rows[i]["DetailUrl"].ToString() + "\" >";
                //str += " <li class=\"" + ds.Tables[2].Rows[i]["actCalss"].ToString() + "\" style=\"background-color:" + ds.Tables[2].Rows[i]["ColorCode"].ToString() + "\">";
                //str += " &nbsp;";
                //str += "</li>";
                //str += "</a>";
            }
            str += "</ul>";
            str += " </div>";
            str += " </div>";
            str += "<div class=\"clear-fix\">&nbsp;</div>";
        }

        #endregion
        #region Hidden Fields
        if (dsImg.Tables[0].Rows.Count > 0)
        {
            imgurlM = dsImg.Tables[0].Rows[0]["smallimg"].ToString();
            str += "<asp:Label ID=\"lblImg\" runat=\"server\" Text=\"\" Style=\"display: none; \">" + imgurlM + "</asp:Label>";
        }
        str += "<span id=\"productNamequik\" style=\"display: none; \">" + ds.Tables[0].Rows[0]["ProdName"].ToString() + "</span>";
        str += "<span id=\"dispricequik\" style=\"display: none; \">" + ds.Tables[0].Rows[0]["DiscountPrice"].ToString() + "</span>";
        str += "<span id=\"rpricequik\" style=\"display: none;\" >" + ds.Tables[0].Rows[0]["ProdPrice"].ToString() + "</span> ";
        str += "<span id=\"minQty\" style=\"display: none;\">1</span>";
        str += "<span id=\"spCat\" style=\"display: none;\" >" + ds.Tables[0].Rows[0]["id_product"].ToString() + "</span> ";
        DataSet dsatt = dat.getDataSet("select * from  ps_product_attribute where id_product=" + ds.Tables[0].Rows[0]["id_product"].ToString() + " and default_on=1 and IsDeleted = 0");
        if (dsatt.Tables[0].Rows.Count > 0)
        {
            str += "<asp:Label ID=\"lblattIDquik\" runat=\"server\" Text=\"\" Style=\"display: none; \">" + dsatt.Tables[0].Rows[0]["id_product_attribute"].ToString() + "</asp:Label>";
        }
        #endregion
        #region Product Attribute
        str += "<div class=\"product-price-and-shipping pt-1\">";

        string rdoid = "0";
        DataSet dsr = getItemMainGroup(prodID, "radio");

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
                DataSet dsi = getItemAttribute(prodID, dsr.Tables[0].Rows[i]["id_attribute_group"].ToString());

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

                    }
                }
                str += "</div>";
            }
        }
        str += "<span id=\"rdoDataquik\" style=\"display: none; \">" + rdoid + "</span>";
        str += " </div>";
        str += "<div class=\"product-information\">";
        str += "<div class=\"product-actions pt-0\">";
        str += "<div action=\"#\" method=\"post\" id=\"add-to-cart-or-refresh\">";
        str += "<input type=\"hidden\" name=\"token\" value=\"3b8dc4acde28257687abb3d4ddf26fc2\">";
        str += "<input type=\"hidden\" name=\"id_product\" value=\"17\" id=\"product_page_product_id\">";
        str += "<input type=\"hidden\" name=\"id_customization\" value=\"0\" id=\"product_customization_id\">";

        string selectId = "0";
        dsr = getItemMainGroup(prodID, "select");
        if (dsr.Tables[0].Rows.Count > 0)
        {
            string sizeStr = "";
            str += "<div class=\"d-flex align-items-center flex-wrap d-none\">";
            str += "<div class=\"variable-single-item\" style=\"width: 100%;\"> ";
            for (int i = 0; i < dsr.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                    selectId = dsr.Tables[0].Rows[i]["id_attribute_group"].ToString();
                else
                    selectId += "," + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString();
                str += "<span>" + dsr.Tables[0].Rows[i]["groupname"].ToString() + "</span>";
                str += "<select id=\"drpquik" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + "\" onchange=\"getPrice(" + dsr.Tables[0].Rows[i]["id_attribute_group"].ToString() + ");\" class=\"form-control-select classic\" name=\"group[3]\" style=\"width: 228px\">";
                DataSet dsi = getItemAttribute(prodID, dsr.Tables[0].Rows[i]["id_attribute_group"].ToString());
                if (dsi.Tables[0].Rows.Count > 0)
                {
                    string dd = "0";
                    if (dsi.Tables[1].Rows.Count > 0)
                    {
                        dd = dsi.Tables[1].Rows[0]["id_attribute"].ToString();
                    }
                    //string aaaid = dsi.Tables[1].Rows[0]["id_attribute_group"].ToString();

                    for (int j = 0; j < dsi.Tables[0].Rows.Count; j++)
                    {
                        if (dd == dsi.Tables[0].Rows[j]["id_attribute"].ToString())
                        {
                            if (sizeStr == "")
                            {
                                sizeStr = "<div class=\"d-flex align-items-center\">";
                                sizeStr += "<div class=\"variable-single-item\">";
                                sizeStr += "<span>Slect Size</span>";
                                sizeStr += "<div class=\"selectSize\">";
                            }
                            if (dsi.Tables[0].Rows[j]["groupname"].ToString() == "Size")
                            {
                                sizeStr += "<div id=\"size_" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" class=\"eachSize activeSize\" onclick=\"getPrice('s-" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "');\"><span>" + dsi.Tables[0].Rows[j]["attributename"].ToString() + "</span></div>";
                            }
                            else if (dsi.Tables[0].Rows[j]["groupname"].ToString() == "Weight")
                            {
                                sizeStr += "<div id=\"size_" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" class=\"eachSize activeSize\" onclick=\"getPrice('s-" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "');\"><span>" + dsi.Tables[0].Rows[j]["attributename"].ToString() + "</span></div>";
                            }
                            str += "<option selected value = \"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" title=\"40x60cm\" >" + dsi.Tables[0].Rows[j]["attributename"].ToString() + "</option>";
                        }
                        else
                        {
                            if (dsi.Tables[0].Rows[j]["groupname"].ToString() == "Size")
                            {
                                if (sizeStr == "")
                                {
                                    sizeStr = "<div class=\"d-flex align-items-center\">";
                                    sizeStr += "<div class=\"variable-single-item\">";
                                    sizeStr += "<span>Slect Size</span>";
                                    sizeStr += "<div class=\"selectSize\">";
                                }
                                sizeStr += "<div id=\"size_" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" class=\"eachSize\" onclick=\"getPrice('s-" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "');\"><span>" + dsi.Tables[0].Rows[j]["attributename"].ToString() + "</span></div>";
                            }
                            else if (dsi.Tables[0].Rows[j]["groupname"].ToString() == "Weight")
                            {
                                if (sizeStr == "")
                                {
                                    sizeStr = "<div class=\"d-flex align-items-center\">";
                                    sizeStr += "<div class=\"variable-single-item\">";
                                    sizeStr += "<span>Slect Size</span>";
                                    sizeStr += "<div class=\"selectSize\">";
                                }
                                sizeStr += "<div id=\"size_" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" class=\"eachSize\" onclick=\"getPrice('s-" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "');\"><span>" + dsi.Tables[0].Rows[j]["attributename"].ToString() + "</span></div>";
                            }
                            str += "<option value = \"" + dsi.Tables[0].Rows[j]["id_attribute"].ToString() + "\" title=\"40x60cm\" >" + dsi.Tables[0].Rows[j]["attributename"].ToString() + "</option>";
                        }
                    }

                }
                str += " </select>";
            }
            sizeStr += "</div>";
            sizeStr += "</div>";
            sizeStr += "</div>";
            str += " </div>";
            str += " </div>";
            str += sizeStr;
            str += "<a class=\"btn btn-aqua mb-5\" id=\"sizeBtn\">Size Chart</a>  ";
        }

        str += "<span id=\"selectDataquik\" style=\"display: none; \">" + selectId + "</span>";


        str += "  <input type='hidden' id='IsStockAllow' value='" + ds.Tables[0].Rows[0]["IsStockAllow"].ToString() + "'  /> ";
        str += "  <input type='hidden' id='stockQty' value='" + ds.Tables[0].Rows[0]["quantity"].ToString() + "'  /> ";

        str += "</div>";
        str += "</div>";
        #endregion
        #region Second Portion
        str += " <div class=\"product-details-variable mt-1\">";
        str += "<div class=\"d-flex align-items-center\">";

        str += "<div class=\"variable-single-item\">";
        str += "<span>Quantity</span>";
        str += "<div class=\"product-variable-quantity\">";
        str += " <input id=\"Qty\" name=\"Qty\" min=\"1\" max=\"100\" value=\"1\" type=\"number\" />";
        str += " </div>";
        str += " </div>";

        str += "<div class=\"product-add-to-cart-btn\" style=\"width:100%;\">";
        str += "<a href=\"#\" class=\"btn btn-block btn-lg btn-black-default-hover\" style=\"width:40%; margin-right: 5px;\" onclick =\"addToCartOnDetail();\">+ Add To Cart</a>";
        str += "<a href=\"#\" class=\"btn btn-block btn-lg btn-black-default-hover\" onclick=\"BuyNow();\" style=\"width:35%;\">Buy Now</a>";
        str += " </div>";
        str += "</div>";
        #region Customize Image 
        str += "<input type=\"hidden\" name=\"IsFluCustomize\" value=\"" + IsPersonalized + "\" id=\"IsFluCustomize\">";
        if (IsPersonalized == "True")
        {
            str += "<div class=\"product-details-meta mb-20\">";
            str += " <b>Upload Your Personalize Image </b> :- <input id=\"fluCustomize\" type=\"file\" runat=\"server\" style=\"width:50%;\" />";
            str += "</div>";
        }
        #endregion
        #region Notes
        str += "<div class=\"product-details-meta mb-20\">";
        //str += " <br/>100% Original Products. <br/> Easy 7 days returns and exchanges (T&C apply). <br/> No return/exchanges on customized and bakery products. <br/> Price of customized goods may vary as per design.<br/>";
        str += "" + TermsCondition + "";
        str += "</div>";
        #endregion
        str += "<div class=\"product-details-meta mb-20\">";
        str += "<a  id=\"" + ds.Tables[0].Rows[0]["minimal_quantity"].ToString() + "\" href=\"javaScript:void(0);\" onclick=\"addWishList(" + ds.Tables[0].Rows[0]["ProdID"].ToString() + ");\" title=\"Add to my wishlist\" class=\"icon-space-right\"><i class=\"icon-heart\"></i>Add to wishlist</a> ";
        str += "</div>";
        str += " </div>";
        #region Thired Portion
        str += "<div class=\"product-details-social\">";
        str += " <span class=\"title\">SHARE THIS PRODUCT:</span>";
        str += " <ul>";
        str += " <li><a href=\"https://api.whatsapp.com/send?text=https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "\"  title=\"Whatsapp Share\" target=\"_blank\" ><i class=\"fa fa-whatsapp\"></i></a></li>";
        str += " <li><a onclick=\"socialWindow('https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "','fb');\" title=\"Share\" target=\"_blank\"><i class=\"fa fa-facebook\"></i></a></li>";
        str += " <li><a onclick=\"socialWindow('https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "','twitter');\" title=\"Tweet\" target=\"_blank\"><i class=\"fa fa-twitter\"></i></a></li>";
        str += " <li><a onclick=\"socialWindow('https://sniggle.in/" + ds.Tables[0].Rows[0]["DetailUrl"].ToString() + "','pinterest');\" title=\"Pinterest\" target=\"_blank\"><i class=\"fa fa-pinterest\"></i></a></li>";
        //str += " <li><a data-toggle=\"modal\" data-target=\"#shareprodonemail\" ng-click=\"shareprodonemail(" + prodID + ")\" title=\"Email Share\" target=\"_blank\" class=\"ion-email\"><i class=\"fa fa-google-plus\"></i></a></li>";
        str += " </ul>";
        str += "</div>";
        #endregion
        #endregion 
        str += "</div>";
        return str;
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
    #endregion Shankar Code End

    public void SubmitLastViewProd(string CustID, string ProdId, string ViewedDate)
    {
        cmd = new SqlCommand("sp_LastViewedProduct");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CustID", CustID);
        cmd.Parameters.AddWithValue("@ProdId", ProdId);
        cmd.Parameters.AddWithValue("@ViewedDate", ViewedDate);
        data.executeCommand(cmd);
    }
}



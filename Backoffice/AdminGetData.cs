using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Summary description for AdminGetData
/// </summary>
public class AdminGetData
{
    Data data = new Data();
    string query;
    int status;
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    DataTable dt = new DataTable();
    public AdminGetData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string ConvertToDateTime(string strDateTime)
    {
        string sDateTime;
        string[] sDate = strDateTime.Split('/');
        sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
        return sDateTime;
    }
    public DataSet Login(string UserId, string Pass)
    {
        cmd = new SqlCommand("Sp_Login");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@UserID", UserId);
        cmd.Parameters.AddWithValue("@Password", Pass);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public int chkCategory(string Category)
    {
        status = 0;
        cmd = new SqlCommand("Sp_CategoryChk");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Category", Category);
        ds = data.getDataSet(cmd);
        var result = ds.Tables[0].Rows[0][0];
        status = Convert.ToInt32(result.ToString());
        return status;
    }
    public int chkMenu(string name)
    {
        status = 0;
        cmd = new SqlCommand("Sp_MenuChk");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@MenuName", name);
        ds = data.getDataSet(cmd);
        var result = ds.Tables[0].Rows[0][0];
        status = Convert.ToInt32(result.ToString());
        return status;
    }
    public DataSet InsMenu(string Action, string MenuName, string DisplayIndex, string id, string IsCMS, string id_parent, string Link, string IsCategory)
    {
        status = 0;
        cmd = new SqlCommand("Sp_InsMenu");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@id_Menu", id);
        cmd.Parameters.AddWithValue("@MenuName", MenuName);
        cmd.Parameters.AddWithValue("@IsCMS", IsCMS);
        cmd.Parameters.AddWithValue("@id_parent", id_parent);
        cmd.Parameters.AddWithValue("@Link", Link);
        cmd.Parameters.AddWithValue("@IsCategory", IsCategory);
        cmd.Parameters.AddWithValue("@DisplayIndex", DisplayIndex != "" ? DisplayIndex : "0");
        //status = data.executeCommand(cmd);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public int InsMenuCat(string id_category, string id_Menu)
    {

        status = 0;
        cmd = new SqlCommand("Sp_InsMenuCategory");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_category", id_category);
        cmd.Parameters.AddWithValue("@id_Menu", id_Menu);
        status = data.executeCommand(cmd);
        return status;
    }
    public int InsCMS(string id_Menu, string Name, string meta_title, string meta_description, string meta_keywords, string content, string link_rewrite, string Action, string id_cms, string IsCategory)
    {

        status = 0;
        cmd1 = new SqlCommand("Sp_CMS");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@id_Menu", id_Menu);
        cmd1.Parameters.AddWithValue("@Action", Action);
        cmd1.Parameters.AddWithValue("@id_cms", id_cms);
        cmd1.Parameters.AddWithValue("@IsCategory", IsCategory);
        ds = data.getDataSet(cmd1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cmd = new SqlCommand("Sp_InsCMS");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Action", Action);
            cmd.Parameters.AddWithValue("@id_cms", ds.Tables[0].Rows[0][0].ToString());
            cmd.Parameters.AddWithValue("@meta_title", meta_title);
            cmd.Parameters.AddWithValue("@meta_description", meta_description);
            cmd.Parameters.AddWithValue("@meta_keywords", meta_keywords);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.Parameters.AddWithValue("@link_rewrite", link_rewrite);
            cmd.Parameters.AddWithValue("@Name", Name);
            status = data.executeCommand(cmd);
        }
        return status;
    }
    public DataSet GetCMS(string Name, string meta_title, string link_rewrite, string position)
    {
        cmd = new SqlCommand("Sp_getCMSAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Name", Name);
        cmd.Parameters.AddWithValue("@meta_title", meta_title);
        cmd.Parameters.AddWithValue("@link_rewrite", link_rewrite);
        cmd.Parameters.AddWithValue("@position", position);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet GetMenu()
    {
        ds = data.getDataSet("Sp_GetMenu");
        return ds;
    }
    public DataSet GetCMSMenu()
    {
        ds = data.getDataSet("select * from tbl_Menu where IsDeleted=0 and IsCMS=1");
        return ds;
    }
    public DataSet GetCategory(string ID, string name, string description, string position, string active)
    {

        cmd = new SqlCommand("Sp_GetCategory");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (ID != "")
            cmd.Parameters.AddWithValue("@ID", ID);
        else
            cmd.Parameters.AddWithValue("@ID", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        if (description != "")
            cmd.Parameters.AddWithValue("@description", description);
        else
            cmd.Parameters.AddWithValue("@description", '%');
        if (position != "")
            cmd.Parameters.AddWithValue("@position", position);
        else
            cmd.Parameters.AddWithValue("@position", '%');
        if (active != "")
            cmd.Parameters.AddWithValue("@active", active);
        else
            cmd.Parameters.AddWithValue("@active", '%');
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet GetSubCategory(string ID, string name, string description, string position, string active, string id_parent)
    {

        cmd = new SqlCommand("Sp_GetSubCategoryAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (ID != "")
            cmd.Parameters.AddWithValue("@id_category", ID);
        else
            cmd.Parameters.AddWithValue("@id_category", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        if (description != "")
            cmd.Parameters.AddWithValue("@description", description);
        else
            cmd.Parameters.AddWithValue("@description", '%');
        if (position != "")
            cmd.Parameters.AddWithValue("@position", position);
        else
            cmd.Parameters.AddWithValue("@position", '%');
        if (active != "")
            cmd.Parameters.AddWithValue("@active", active);
        else
            cmd.Parameters.AddWithValue("@active", '%');
        if (id_parent != "")
            cmd.Parameters.AddWithValue("@id_parent", id_parent);
        else
            cmd.Parameters.AddWithValue("@id_parent", '%');
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet GetProductList(string PageSize, string pageIndex, string ID, string name, string reference, string name_category, string price, string sav_quantity, string active, string IsHome)
    {

        cmd = new SqlCommand("Sp_GetProductAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        if (ID != "")
            cmd.Parameters.AddWithValue("@ID", ID);
        else
            cmd.Parameters.AddWithValue("@ID", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        if (reference != "")
            cmd.Parameters.AddWithValue("@reference", reference);
        else
            cmd.Parameters.AddWithValue("@reference", '%');
        if (name_category != "")
            cmd.Parameters.AddWithValue("@name_category", name_category);
        else
            cmd.Parameters.AddWithValue("@name_category", '%');
        if (price != "")
            cmd.Parameters.AddWithValue("@price", price);
        else
            cmd.Parameters.AddWithValue("@price", '%');
        if (sav_quantity != "")
            cmd.Parameters.AddWithValue("@sav_quantity", sav_quantity);
        else
            cmd.Parameters.AddWithValue("@sav_quantity", '%');
        if (IsHome != "")
            cmd.Parameters.AddWithValue("@IsHome", IsHome);
        else
            cmd.Parameters.AddWithValue("@IsHome", '%');
        if (active != "")
            cmd.Parameters.AddWithValue("@active", active);
        else
            cmd.Parameters.AddWithValue("@active", '%');
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }
        return ds;
    }
    public DataSet GetSubCategory(string ID)
    {
        if (ID != "")
            ds = data.getDataSet("Sp_GetSubCategory " + ID);
        else
            ds = data.getDataSet("Sp_GetSubCategory '%'");
        return ds;
    }
    public DataSet AddCategory(string action, string name, string Displayed, string Parentcategory, string Description, string Metatitle, string Metadescription, string Metakeywords, string Url, string ID)
    {
        cmd = new SqlCommand("Sp_InCategoryLag");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", action);
        if (ID != "")
            cmd.Parameters.AddWithValue("@id_category", ID);
        else cmd.Parameters.AddWithValue("@id_category", "0");
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@description", Description);
        cmd.Parameters.AddWithValue("@link_rewrite", Url);
        cmd.Parameters.AddWithValue("@meta_title", Metatitle);
        cmd.Parameters.AddWithValue("@meta_keywords", Metakeywords);
        cmd.Parameters.AddWithValue("@meta_description", Metadescription);
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cmd1 = new SqlCommand("Sp_InsCategory");
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@Action", action);
            if (Parentcategory != "")
                cmd1.Parameters.AddWithValue("@id_parent", Parentcategory);
            else
                cmd1.Parameters.AddWithValue("@id_parent", "0");
            cmd1.Parameters.AddWithValue("@active", Displayed);
            cmd1.Parameters.AddWithValue("@position", "0");
            cmd1.Parameters.AddWithValue("@is_root_category", "1");
            cmd1.Parameters.AddWithValue("@ID", ds.Tables[0].Rows[0][0]);
            data.executeCommand(cmd1);
        }
        return ds;
    }
    public DataSet AddProduct(string action, string id_category_default, string online_only, string minimal_quantity, string price, string wholesale_price, string unity,
        string unit_price_ratio, string reference, string width, string height, string depth, string weight, string out_of_stock, string active, string redirect_type,
        string available_for_order, string condition, string show_price, string indexed, string visibility, string cache_default_attribute, string pack_stock_type,
        string description, string description_short, string link_rewrite, string meta_description, string meta_keywords, string meta_title, string name, string id_product)
    {
        DataSet ds3 = new DataSet();
        DataSet ds2 = new DataSet();
        bool bb = false;
        if (action == "AddInformation")
        {
            query = "select * from ps_product_lang where name='" + name + "' and IsDeletd=0 ";
            ds3 = data.getDataSet(query);
            if (ds3.Tables[0].Rows.Count > 0)
            {
                bb = true;
            }
            else
            {
                bb = true;
            }
        }
        else
        {
            bb = true;
        }
        if (bb == true)
        {
            cmd = new SqlCommand("Sp_InsProduct");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@id_product", id_product);
            cmd.Parameters.AddWithValue("@online_only", online_only);
            cmd.Parameters.AddWithValue("@reference", reference);
            if (active != "")
                cmd.Parameters.AddWithValue("@active", active);
            else
                cmd.Parameters.AddWithValue("@active", "1");
            cmd.Parameters.AddWithValue("@redirect_type", redirect_type);
            cmd.Parameters.AddWithValue("@condition", condition);
            cmd.Parameters.AddWithValue("@show_price", show_price);
            cmd.Parameters.AddWithValue("@visibility", visibility);
            ds2 = data.getDataSet(cmd);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                cmd1 = new SqlCommand("Sp_InsProduct_lang");
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Clear();
                cmd1.Parameters.AddWithValue("@Action", action);
                cmd1.Parameters.AddWithValue("@id_product", ds2.Tables[0].Rows[0][0]);
                cmd1.Parameters.AddWithValue("@description", description);
                cmd1.Parameters.AddWithValue("@description_short", description_short);
                cmd1.Parameters.AddWithValue("@meta_description", meta_description);
                cmd1.Parameters.AddWithValue("@meta_keywords", meta_keywords);
                cmd1.Parameters.AddWithValue("@meta_title", meta_title);
                cmd1.Parameters.AddWithValue("@available_now", "");
                cmd1.Parameters.AddWithValue("@available_later", "");
                cmd1.Parameters.AddWithValue("@name", name);
                cmd1.Parameters.AddWithValue("@link_rewrite", "");
                data.executeCommand(cmd1);
            }
        }

        return ds2;
    }
    public DataSet AddTag(string id_product, string name)
    {
        cmd = new SqlCommand("Sp_InsTagName");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@name", name);
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cmd1 = new SqlCommand("Sp_InsTag");
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@id_product", id_product);
            cmd1.Parameters.AddWithValue("@id_tag", ds.Tables[0].Rows[0][0]);
            data.executeCommand(cmd1);
        }

        return ds;
    }
    public int AddProductTag(string id_product, string id_tag)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_InsTag");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@id_product", id_product);
        cmd1.Parameters.AddWithValue("@id_tag", id_tag);
        status = data.executeCommand(cmd1);

        return status;
    }
    public DataSet GetTaxRul()
    {
        ds = data.getDataSet("Sp_GetTaxRul");
        return ds;
    }
    public DataSet AddPrice(string price, string wholesale_price, string unity, string unit_price_ratio, Boolean on_sale, string id_tax_rules_group, string id_product)
    {
        cmd = new SqlCommand("Sp_UpPrices");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product", id_product);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.Parameters.AddWithValue("@wholesale_price", wholesale_price);
        cmd.Parameters.AddWithValue("@unity", unity);
        cmd.Parameters.AddWithValue("@unit_price_ratio", unit_price_ratio);
        cmd.Parameters.AddWithValue("@on_sale", on_sale);
        cmd.Parameters.AddWithValue("@id_tax_rules_group", id_tax_rules_group);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public int AddSpecificPrice(string Action, string id_product, string id_currency, string id_country,
        string id_group, string id_customer, string id_product_attribute, string price, string from_quantity,
        string reduction, string reduction_tax, string reduction_type, string from, string to)
    {
        status = 0;
        cmd = new SqlCommand("Sp_InsSpecificPrice");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@id_product", id_product);
        cmd.Parameters.AddWithValue("@id_currency", id_currency);
        cmd.Parameters.AddWithValue("@id_country", id_country);
        cmd.Parameters.AddWithValue("@id_group", id_group);
        cmd.Parameters.AddWithValue("@id_customer", id_customer);
        cmd.Parameters.AddWithValue("@id_product_attribute", id_product_attribute);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.Parameters.AddWithValue("@reduction", reduction);
        if (from_quantity != "")
            cmd.Parameters.AddWithValue("@from_quantity", from_quantity);
        else
            cmd.Parameters.AddWithValue("@from_quantity", "0");
        cmd.Parameters.AddWithValue("@reduction_tax", reduction_tax);
        cmd.Parameters.AddWithValue("@reduction_type", reduction_type);
        if (from != "")
            cmd.Parameters.AddWithValue("@from", ConvertToDateTime(from));
        else
            cmd.Parameters.AddWithValue("@from", "");
        if (to != "")
            cmd.Parameters.AddWithValue("@to", ConvertToDateTime(to));
        else
            cmd.Parameters.AddWithValue("@to", "");
        status = data.executeCommand(cmd);

        return status;
    }
    public DataSet AddSEO(string link_rewrite, string meta_description, string meta_title, string id_product)
    {
        cmd = new SqlCommand("Sp_UpSEO");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product", id_product);
        cmd.Parameters.AddWithValue("@link_rewrite", link_rewrite);
        cmd.Parameters.AddWithValue("@meta_description", meta_description);
        cmd.Parameters.AddWithValue("@meta_title", meta_title);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet AddShipping(string width, string height, string depth, string weight, string additional_shipping_cost, string id_product)
    {
        cmd = new SqlCommand("Sp_UpShipping");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product", id_product);
        if (width != "")
            cmd.Parameters.AddWithValue("@width", width);
        else
            cmd.Parameters.AddWithValue("@width", "0");
        if (height != "")
            cmd.Parameters.AddWithValue("@height", height);
        else
            cmd.Parameters.AddWithValue("@height", "0");
        if (depth != "")
            cmd.Parameters.AddWithValue("@depth", depth);
        else
            cmd.Parameters.AddWithValue("@depth", "0");
        if (weight != "")
            cmd.Parameters.AddWithValue("@weight", weight);
        else
            cmd.Parameters.AddWithValue("@weight", "0");
        if (additional_shipping_cost != "")
            cmd.Parameters.AddWithValue("@additional_shipping_cost", additional_shipping_cost);
        else
            cmd.Parameters.AddWithValue("@additional_shipping_cost", "0");
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet AddImage(string legend, string position, string id_product)
    {
        cmd = new SqlCommand("Sp_InsProductImage");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product", id_product);
        cmd.Parameters.AddWithValue("@position", position);
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cmd1 = new SqlCommand("Sp_InsProductImageLang");
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@id_image", ds.Tables[0].Rows[0][0]);
            cmd1.Parameters.AddWithValue("@id_lang", "1");
            cmd1.Parameters.AddWithValue("@legend", legend);
            data.executeCommand(cmd1);
        }
        return ds;
    }
    public DataSet GetImageOfProduct(string id)
    {
        ds = data.getDataSet("Sp_GetImageOfProduct " + id);
        return ds;
    }
    public DataSet GetAttributeGroup()
    {
        ds = data.getDataSet("Sp_GetAttributeGroup ");
        return ds;
    }
    public DataSet GetAttributeValue(string id)
    {
        if (id != "0" && id != "")
            ds = data.getDataSet("Sp_GetAttributeValue " + id);
        else
            ds = data.getDataSet("Sp_GetAttributeValue '%'");
        return ds;
    }
    public DataSet addProductCombination(string id_product, string reference, string wholesale_price, string price, string ecotax, string quantity, string weight,
        string unit_price_impact, string default_on, string minimal_quantity, string available_date)
    {
        // x > y ? "x is greater than y" : "x is less than y";
        cmd = new SqlCommand("Sp_Product_attribute");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product", id_product);
        cmd.Parameters.AddWithValue("@reference", reference);
        cmd.Parameters.AddWithValue("@wholesale_price", wholesale_price != "" ? wholesale_price : "0");
        cmd.Parameters.AddWithValue("@price", price != "" ? price : "0");
        cmd.Parameters.AddWithValue("@ecotax", ecotax != "" ? ecotax : "0");
        cmd.Parameters.AddWithValue("@quantity", quantity != "" ? quantity : "0");
        cmd.Parameters.AddWithValue("@weight", weight != "" ? weight : "0");
        cmd.Parameters.AddWithValue("@unit_price_impact", unit_price_impact != "" ? unit_price_impact : "0");
        cmd.Parameters.AddWithValue("@default_on", default_on != "" ? default_on : "1");
        cmd.Parameters.AddWithValue("@minimal_quantity", minimal_quantity != "" ? minimal_quantity : "0");
        cmd.Parameters.AddWithValue("@available_date", available_date != "" ? ConvertToDateTime(available_date) : "");
        ds = data.getDataSet(cmd);

        return ds;
    }

    public int addProductAttributeValue(string id_product, string id_attribute, string weight, string price)
    {
        status = 0;
        query = "select IDENT_CURRENT('ps_product_attribute') as MaxId";
        DataSet dsMax = data.getDataSet(query);
        if (dsMax.Tables[0].Rows.Count > 0)
        {
            cmd = new SqlCommand("Sp_Product_attribute_combination");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id_product_attribute", dsMax.Tables[0].Rows[0]["MaxId"].ToString());
            cmd.Parameters.AddWithValue("@id_attribute", id_attribute);
            data.executeCommand(cmd);
        }
        cmd1 = new SqlCommand("Sp_Attribute_impact");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@id_product", id_product);
        cmd1.Parameters.AddWithValue("@id_attribute", id_attribute);
        cmd1.Parameters.AddWithValue("@weight", weight != "" ? weight : "0");
        cmd1.Parameters.AddWithValue("@price", price != "" ? price : "0");
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());
        return status;
    }

    public DataSet UpdateProductCombination(string id_product_attribute, string id_product, string reference, string wholesale_price, string price, string ecotax, string quantity, string weight,
        string unit_price_impact, string default_on, string minimal_quantity, string available_date)
    {
        cmd = new SqlCommand("Sp_UpdateProductAttribute");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product_attribute", id_product_attribute);
        cmd.Parameters.AddWithValue("@id_product", id_product);
        cmd.Parameters.AddWithValue("@reference", reference);
        cmd.Parameters.AddWithValue("@wholesale_price", wholesale_price != "" ? wholesale_price : "0");
        cmd.Parameters.AddWithValue("@price", price != "" ? price : "0");
        cmd.Parameters.AddWithValue("@ecotax", ecotax != "" ? ecotax : "0");
        cmd.Parameters.AddWithValue("@quantity", quantity != "" ? quantity : "0");
        cmd.Parameters.AddWithValue("@weight", weight != "" ? weight : "0");
        cmd.Parameters.AddWithValue("@unit_price_impact", unit_price_impact != "" ? unit_price_impact : "0");
        cmd.Parameters.AddWithValue("@default_on", default_on != "" ? default_on : "1");
        cmd.Parameters.AddWithValue("@minimal_quantity", minimal_quantity != "" ? minimal_quantity : "0");
        cmd.Parameters.AddWithValue("@available_date", available_date != "" ? ConvertToDateTime(available_date) : "");
        //cmd.Parameters.AddWithValue("@available_date", available_date != null ? ConvertToDateTime(available_date) : "");
        ds = data.getDataSet(cmd);

        return ds;
    }
    public int UpdateProductAttributeValue(string id_product_attribute, string id_product, string id_attribute, string weight, string price)
    {
        status = 0;
        cmd = new SqlCommand("Sp_Product_attribute_combination");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product_attribute", id_product_attribute);
        cmd.Parameters.AddWithValue("@id_attribute", id_attribute);
        data.executeCommand(cmd);

        cmd1 = new SqlCommand("Sp_Attribute_impact");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@id_product", id_product);
        cmd1.Parameters.AddWithValue("@id_attribute", id_attribute);
        cmd1.Parameters.AddWithValue("@weight", weight != "" ? weight : "0");
        cmd1.Parameters.AddWithValue("@price", price != "" ? price : "0");
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());
        return status;
    }
    public DataSet addCombination(string id_product, string reference, string wholesale_price, string price, string ecotax, string quantity, string weight,
        string unit_price_impact, string default_on, string minimal_quantity, string available_date)
    {
        // x > y ? "x is greater than y" : "x is less than y";
        cmd = new SqlCommand("Sp_Product_attribute");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product", id_product);
        cmd.Parameters.AddWithValue("@reference", reference);
        cmd.Parameters.AddWithValue("@wholesale_price", wholesale_price != "" ? wholesale_price : "0");
        cmd.Parameters.AddWithValue("@price", price != "" ? price : "0");
        cmd.Parameters.AddWithValue("@ecotax", ecotax != "" ? ecotax : "0");
        cmd.Parameters.AddWithValue("@quantity", quantity != "" ? quantity : "0");
        cmd.Parameters.AddWithValue("@weight", weight != "" ? weight : "0");
        cmd.Parameters.AddWithValue("@unit_price_impact", unit_price_impact != "" ? unit_price_impact : "0");
        cmd.Parameters.AddWithValue("@default_on", default_on != "" ? default_on : "1");
        cmd.Parameters.AddWithValue("@minimal_quantity", minimal_quantity != "" ? minimal_quantity : "0");
        cmd.Parameters.AddWithValue("@available_date", available_date != "" ? ConvertToDateTime(available_date) : "");
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
        }
        return ds;
    }
    public int AttCombo(string id_product_attribute, string id_attribute)
    {
        cmd2 = new SqlCommand("Sp_Product_attribute_combination");
        cmd2.CommandType = CommandType.StoredProcedure;
        cmd2.Parameters.Clear();
        cmd2.Parameters.AddWithValue("@id_product_attribute", id_product_attribute);
        cmd2.Parameters.AddWithValue("@id_attribute", id_attribute);
        var result = data.executeCommand(cmd2);
        status = Convert.ToInt32(result.ToString());
        return status;
    }
    public int AddAttribute(string id_product, string id_attribute, string weight, string price)
    {
        status = 0;

        cmd1 = new SqlCommand("Sp_Attribute_impact");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@id_product", id_product);
        cmd1.Parameters.AddWithValue("@id_attribute", id_attribute);
        cmd1.Parameters.AddWithValue("@weight", weight != "" ? weight : "0");
        cmd1.Parameters.AddWithValue("@price", price != "" ? price : "0");
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());
        return status;
    }
    public DataSet GetFeatureByProduct(string id, string id_feature)
    {
        if (id_feature != "")
            ds = data.getDataSet("Sp_GetFeatureByProduct '" + id + "'," + id_feature);
        else
            ds = data.getDataSet("Sp_GetFeatureByProduct '" + id + "','%'");

        if (ds.Tables[0].Rows.Count == 0)
        {
            ds = data.getDataSet("Sp_GetFeatureByProduct '%','%'");
        }
        return ds;
    }

    public DataSet GetSpecificPrice(string pordId)
    {
        ds = data.getDataSet("sp_GetSpecificPrice '" + pordId + "'");
        return ds;
    }
    public DataSet GetFeature()
    {
        ds = data.getDataSet("Sp_GetFeature");
        return ds;
    }
    public int AddProductFeature(string id_feature, string id_product, string id_feature_value, string value)
    {
        DataSet ds2 = new DataSet();
        status = 0;
        if (value != "")
        {
            ds2 = data.getDataSet("Sp_ExistsValue '" + id_product + "','" + value + "'");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                cmd2 = new SqlCommand("Sp_insFeature_value_lang");
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@id_feature_value", ds2.Tables[0].Rows[0]["id_feature_value"]);
                cmd2.Parameters.AddWithValue("@id_lang", "1");
                if (value != "")
                    cmd2.Parameters.AddWithValue("@value", value);
                else
                    cmd2.Parameters.AddWithValue("@value", id_feature_value);
                data.executeCommand(cmd2);
                cmd = new SqlCommand("Sp_InsFeature_Product");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_feature", id_feature);
                cmd.Parameters.AddWithValue("@id_product", id_product);
                cmd.Parameters.AddWithValue("@id_feature_value", ds2.Tables[0].Rows[0]["id_feature_value"]);
                var result = data.executeCommand(cmd);
                status = Convert.ToInt32(result.ToString());
            }
            else
            {
                DataSet ds4 = data.getDataSet("Sp_ExistsValuePNew '" + id_product + "','" + id_feature + "','" + value + "'");
                if (ds4.Tables[0].Rows.Count > 0)
                {

                    cmd2 = new SqlCommand("Sp_insFeature_value_lang");
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("@id_feature_value", ds4.Tables[0].Rows[0]["id_feature_value"]);
                    cmd2.Parameters.AddWithValue("@id_lang", "1");
                    if (value != "")
                        cmd2.Parameters.AddWithValue("@value", value);
                    else
                        cmd2.Parameters.AddWithValue("@value", id_feature_value);
                    data.executeCommand(cmd2);
                }
                else
                {
                    data.executeCommand("update ps_feature_product set IsDeleted=1 where id_product='" + id_product + "' and id_feature='" + id_feature + "'");
                    cmd1 = new SqlCommand("Sp_InsFeature_value");
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.AddWithValue("@id_feature", id_feature);
                    if (value != "")
                        cmd1.Parameters.AddWithValue("@custom", "True");
                    else
                        cmd1.Parameters.AddWithValue("@custom", "False");
                    ds = data.getDataSet(cmd1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cmd = new SqlCommand("Sp_InsFeature_Product");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id_feature", id_feature);
                        cmd.Parameters.AddWithValue("@id_product", id_product);
                        cmd.Parameters.AddWithValue("@id_feature_value", ds.Tables[0].Rows[0][0]);
                        var result = data.executeCommand(cmd);
                        status = Convert.ToInt32(result.ToString());

                        cmd2 = new SqlCommand("Sp_insFeature_value_lang");
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Clear();
                        cmd2.Parameters.AddWithValue("@id_feature_value", ds.Tables[0].Rows[0][0]);
                        cmd2.Parameters.AddWithValue("@id_lang", "1");
                        if (value != "")
                            cmd2.Parameters.AddWithValue("@value", value);
                        else
                            cmd2.Parameters.AddWithValue("@value", id_feature_value);
                        data.executeCommand(cmd2);
                    }
                }
            }
        }
        else
        {

            cmd = new SqlCommand("Sp_InsFeature_Product");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id_feature", id_feature);
            cmd.Parameters.AddWithValue("@id_product", id_product);
            cmd.Parameters.AddWithValue("@id_feature_value", id_feature_value);
            var result = data.executeCommand(cmd);
            status = Convert.ToInt32(result.ToString());
        }

        return status;
    }
    public int AddFeature(string value, string ID, string Action)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_InsFeature");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@name", value);
        cmd1.Parameters.AddWithValue("@ID", ID);
        cmd1.Parameters.AddWithValue("@Action", Action);
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());

        return status;
    }
    public int AddattributeG(string value, string public_name, string ID, string Action)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_InsattributeG");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@name", value);
        cmd1.Parameters.AddWithValue("@public_name", public_name);
        cmd1.Parameters.AddWithValue("@ID", ID);
        cmd1.Parameters.AddWithValue("@Action", Action);
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());

        return status;
    }
    public int AddattributeV(string id_attribute_group, string value, string ID, string Action)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_Insattributev");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@name", value);
        cmd1.Parameters.AddWithValue("@id_attribute_group", id_attribute_group);
        cmd1.Parameters.AddWithValue("@ID", ID);
        cmd1.Parameters.AddWithValue("@Action", Action);
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());

        return status;
    }
    public int AddFeatureValue(string id_feature, string value)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_InsFeature_value");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@id_feature", id_feature);
        if (value != "")
            cmd1.Parameters.AddWithValue("@custom", "True");
        else
            cmd1.Parameters.AddWithValue("@custom", "False");
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());
        if (status == 0)
        {
            query = "select IDENT_CURRENT('ps_feature_value') as MaxId";
            DataSet dsMax = data.getDataSet(query);
            if (dsMax.Tables[0].Rows.Count > 0)
            {
                cmd2 = new SqlCommand("Sp_insFeature_value_lang");
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@id_feature_value", dsMax.Tables[0].Rows[0][0].ToString());
                cmd2.Parameters.AddWithValue("@id_lang", "1");
                cmd2.Parameters.AddWithValue("@value", value);
                data.executeCommand(cmd2);
            }

        }
        return status;
    }

    public int AddFeatureValueNew(string id_feature, string value, string ID, string Action)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_InsFeatureValueNew");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@id_feature", id_feature);
        if (value != "")
            cmd1.Parameters.AddWithValue("@custom", "False");
        else
            cmd1.Parameters.AddWithValue("@custom", "True");
        cmd1.Parameters.AddWithValue("@id_feature_value", ID);
        cmd1.Parameters.AddWithValue("@value", value);
        cmd1.Parameters.AddWithValue("@Action", Action);
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());
        return status;
    }

    public int AddCategoryProduct(string id_category, string id_product, string position)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_InsCategoryProduct");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@id_category", id_category);
        cmd1.Parameters.AddWithValue("@id_product", id_product);
        cmd1.Parameters.AddWithValue("@position", position);
        var result = data.executeCommand(cmd1);

        return status;
    }
    public int InsBanner(string Action, string Title, string Type, string Banner, string DisplayIndex, string id, string Link, string LinkOpen)
    {

        status = 0;
        cmd = new SqlCommand("Sp_InsBanner");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@Title", Title);
        cmd.Parameters.AddWithValue("@Banner", Banner);
        cmd.Parameters.AddWithValue("@DisIndex", DisplayIndex != "" ? DisplayIndex : "0");
        cmd.Parameters.AddWithValue("@Link", Link);
        cmd.Parameters.AddWithValue("@LinkOpen", LinkOpen);
        status = data.executeCommand(cmd);

        return status;
    }

    public DataSet GetAttGroupAdmin(string ID, string name, string position)
    {

        cmd = new SqlCommand("Sp_GetAttributeGroupAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (ID != "")
            cmd.Parameters.AddWithValue("@ID", ID);
        else
            cmd.Parameters.AddWithValue("@ID", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        if (position != "")
            cmd.Parameters.AddWithValue("@position", position);
        else
            cmd.Parameters.AddWithValue("@position", '%');
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet GetAttValueAdmin(string ID, string name, string position, string gid)
    {

        cmd = new SqlCommand("Sp_GetAttributeValueAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (ID != "")
            cmd.Parameters.AddWithValue("@ID", ID);
        else
            cmd.Parameters.AddWithValue("@ID", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        if (position != "")
            cmd.Parameters.AddWithValue("@position", position);
        else
            cmd.Parameters.AddWithValue("@position", '%');
        if (gid != "")
            cmd.Parameters.AddWithValue("@gid", gid);
        else
            cmd.Parameters.AddWithValue("@gid", '%');
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet GetFeaturesAdmin(string ID, string name, string position)
    {

        cmd = new SqlCommand("Sp_GetfeatureAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (ID != "")
            cmd.Parameters.AddWithValue("@id_feature", ID);
        else
            cmd.Parameters.AddWithValue("@id_feature", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        if (position != "")
            cmd.Parameters.AddWithValue("@position", position);
        else
            cmd.Parameters.AddWithValue("@position", '%');
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet GetFeaturesValueAdmin(string ID, string name, string gid)
    {

        cmd = new SqlCommand("Sp_Getfeature_valueAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (ID != "")
            cmd.Parameters.AddWithValue("@ID", ID);
        else
            cmd.Parameters.AddWithValue("@ID", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        if (gid != "")
            cmd.Parameters.AddWithValue("@gid", gid);
        else
            cmd.Parameters.AddWithValue("@gid", '%');
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet GetOrder(string PageSize, string pageIndex, string id_order, string reference, string newsletter, string Deleaver,
        string customer, string Total, string Paymeny, string Status, string FDate, string TDate)
    {
        string dd2 = DateTime.Now.ToString("yyyy-M-d");
        cmd = new SqlCommand("Sp_GetOrderAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        if (id_order != "")
            cmd.Parameters.AddWithValue("@id_order", id_order);
        else
            cmd.Parameters.AddWithValue("@id_order", '%');
        if (reference != "")
            cmd.Parameters.AddWithValue("@reference", reference);
        else
            cmd.Parameters.AddWithValue("@reference", '%');
        if (newsletter != "")
            cmd.Parameters.AddWithValue("@newsletter", newsletter);
        else
            cmd.Parameters.AddWithValue("@newsletter", '%');
        if (Deleaver != "")
            cmd.Parameters.AddWithValue("@Deleaver", Deleaver);
        else
            cmd.Parameters.AddWithValue("@Deleaver", '%');
        if (customer != "")
            cmd.Parameters.AddWithValue("@customer", customer);
        else
            cmd.Parameters.AddWithValue("@customer", '%');
        if (Total != "")
            cmd.Parameters.AddWithValue("@Total", Total);
        else
            cmd.Parameters.AddWithValue("@Total", '%');
        if (Paymeny != "")
            cmd.Parameters.AddWithValue("@Paymeny", Paymeny);
        else
            cmd.Parameters.AddWithValue("@Paymeny", '%');
        if (Status != "")
            cmd.Parameters.AddWithValue("@Status", Status);
        else
            cmd.Parameters.AddWithValue("@Status", '%');
        if (FDate != "")
            cmd.Parameters.AddWithValue("@FDate", ConvertToDateTime(FDate));
        else
            cmd.Parameters.AddWithValue("@FDate", "1900-01-01");
        if (TDate != "")
            cmd.Parameters.AddWithValue("@TDate", ConvertToDateTime(TDate));
        else
            cmd.Parameters.AddWithValue("@TDate", dd2);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public DataSet GetOrderCountry()
    {
        ds = data.getDataSet("Sp_GetOrderCountry");
        return ds;
    }
    public DataSet GetCustomer(string PageSize, string pageIndex, string id_customer, string title, string firstname, string lastname, string email,
        string active, string newsletter, string optin, string FDate, string TDate)
    {
        string dd2 = DateTime.Now.ToString("yyyy-M-d");
        cmd = new SqlCommand("Sp_GetCustomer");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        if (id_customer != "")
            cmd.Parameters.AddWithValue("@id_customer", id_customer);
        else
            cmd.Parameters.AddWithValue("@id_customer", '%');
        if (title != "")
            cmd.Parameters.AddWithValue("@title", title);
        else
            cmd.Parameters.AddWithValue("@title", '%');
        if (firstname != "")
            cmd.Parameters.AddWithValue("@firstname", firstname);
        else
            cmd.Parameters.AddWithValue("@firstname", '%');
        if (lastname != "")
            cmd.Parameters.AddWithValue("@lastname", lastname);
        else
            cmd.Parameters.AddWithValue("@lastname", '%');
        if (email != "")
            cmd.Parameters.AddWithValue("@email", email);
        else
            cmd.Parameters.AddWithValue("@email", '%');
        if (active != "")
            cmd.Parameters.AddWithValue("@active", active);
        else
            cmd.Parameters.AddWithValue("@active", '%');
        if (newsletter != "")
            cmd.Parameters.AddWithValue("@newsletter", newsletter);
        else
            cmd.Parameters.AddWithValue("@newsletter", '%');

        if (optin != "")
            cmd.Parameters.AddWithValue("@optin", optin);
        else
            cmd.Parameters.AddWithValue("@optin", '%');
        if (FDate != "")
            cmd.Parameters.AddWithValue("@FDate", ConvertToDateTime(FDate));
        else
            cmd.Parameters.AddWithValue("@FDate", "1900-01-01");
        if (TDate != "")
            cmd.Parameters.AddWithValue("@TDate", ConvertToDateTime(TDate));
        else
            cmd.Parameters.AddWithValue("@TDate", dd2);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public DataSet GetOrderStatus(string id_order_stat, string name, string send_email, string delivery, string invoice, string template)
    {
        string dd2 = DateTime.Now.ToString("yyyy-M-d");
        cmd = new SqlCommand("Sp_GetOrderStatusAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (id_order_stat != "")
            cmd.Parameters.AddWithValue("@id_order_state", id_order_stat);
        else
            cmd.Parameters.AddWithValue("@id_order_state", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        if (send_email != "")
            cmd.Parameters.AddWithValue("@send_email", send_email);
        else
            cmd.Parameters.AddWithValue("@send_email", '%');
        if (delivery != "")
            cmd.Parameters.AddWithValue("@delivery", delivery);
        else
            cmd.Parameters.AddWithValue("@delivery", '%');
        if (invoice != "")
            cmd.Parameters.AddWithValue("@invoice", invoice);
        else
            cmd.Parameters.AddWithValue("@invoice", '%');
        if (template != "")
            cmd.Parameters.AddWithValue("@template", template);
        else
            cmd.Parameters.AddWithValue("@template", '%');
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet GetOrderReturnStatus(string id_order_stat, string name)
    {
        string dd2 = DateTime.Now.ToString("yyyy-M-d");
        cmd = new SqlCommand("Sp_GetOrderReturnStatusAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (id_order_stat != "")
            cmd.Parameters.AddWithValue("@id_order_return_state", id_order_stat);
        else
            cmd.Parameters.AddWithValue("@id_order_return_state", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet GetTagsAdmin(string PageSize, string pageIndex, string ID, string name, string Product)
    {

        cmd = new SqlCommand("Sp_GetTags");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (ID != "")
            cmd.Parameters.AddWithValue("@id_tag", ID);
        else
            cmd.Parameters.AddWithValue("@id_tag", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        if (Product != "")
            cmd.Parameters.AddWithValue("@PCount", Product);
        else
            cmd.Parameters.AddWithValue("@PCount", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public int AddVideo(string id_product, string link, string name, string description)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_InsProductVideoId");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@id_product", id_product);

        ds = data.getDataSet(cmd1);
        if (ds.Tables[0].Rows[0][0] != null)
        {
            //id_video,id_shop,id_product,id_lang,link,cover_image,name,description,sort_order,status

            cmd2 = new SqlCommand("Sp_InsProductVideo");
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@id_video", ds.Tables[0].Rows[0][0].ToString());
            cmd2.Parameters.AddWithValue("@id_product", id_product);
            cmd2.Parameters.AddWithValue("@link", link);
            cmd2.Parameters.AddWithValue("@cover_image", "");
            cmd2.Parameters.AddWithValue("@name", name);
            cmd2.Parameters.AddWithValue("@description", description);

            status = data.executeCommand(cmd2);
        }
        return status;
    }
    public int InsFancyShap(string Action, string Title, string Link, string Des, string Image1,
        string Image2, string Image3, string Image4, string Image5, string id, string Thumb, string c1, string c2, string c3, string c4, string c5, string CreativeCuts)
    {

        status = 0;
        cmd = new SqlCommand("Sp_InsFancyShape");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@Title", Title);
        cmd.Parameters.AddWithValue("@Description", Des);
        cmd.Parameters.AddWithValue("@VideoLink", Link);
        cmd.Parameters.AddWithValue("@Image1", Image1);
        cmd.Parameters.AddWithValue("@Image2", Image2);
        cmd.Parameters.AddWithValue("@Image3", Image3);
        cmd.Parameters.AddWithValue("@Image4", Image4);
        cmd.Parameters.AddWithValue("@Image5", Image5);
        cmd.Parameters.AddWithValue("@Thumb", Thumb);
        cmd.Parameters.AddWithValue("@caption1", c1);
        cmd.Parameters.AddWithValue("@caption2", c2);
        cmd.Parameters.AddWithValue("@caption3", c3);
        cmd.Parameters.AddWithValue("@caption4", c4);
        cmd.Parameters.AddWithValue("@caption5", c5);
        cmd.Parameters.AddWithValue("@CreativeCuts", CreativeCuts);
        status = data.executeCommand(cmd);

        return status;
    }
    public DataSet InsZone(string Action, string name, string Ship_Amt, string id_zone, string MinShip_Amt)
    {
        cmd = new SqlCommand("Sp_InsZone");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@id_zone", id_zone);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@Ship_Amt", Ship_Amt != "" ? Ship_Amt : "0");
        cmd.Parameters.AddWithValue("@MinShip_Amt", MinShip_Amt != "" ? MinShip_Amt : "0");
        ds = data.getDataSet(cmd);

        return ds;
    }
    public DataSet InsCountry(string Action, string name, string iso_code, string call_prefix, string id_zone, string id_country)
    {

        cmd = new SqlCommand("Sp_Inscountry");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@id_zone", id_zone);
        cmd.Parameters.AddWithValue("@iso_code", iso_code);
        cmd.Parameters.AddWithValue("@call_prefix", call_prefix);
        cmd.Parameters.AddWithValue("@id_country", id_country);
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cmd1 = new SqlCommand("Sp_Inscountry_lang");
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@id_country", ds.Tables[1].Rows[0][0].ToString());
            cmd1.Parameters.AddWithValue("@Action", Action);
            cmd1.Parameters.AddWithValue("@name", name);
            DataSet ds1 = data.getDataSet(cmd1);
        }
        return ds;
    }
    public DataSet InsertPriority(string ProdId, string Priority)
    {
        cmd = new SqlCommand("sp_InsertSpecificPricePriority");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product", ProdId);
        cmd.Parameters.AddWithValue("@priority", Priority);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet AddTagAdmin(string Action, string name, string id_tag)
    {
        cmd = new SqlCommand("Sp_InsTagAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@id_tag", id_tag);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public int AddTagProduct(string id_product, string id_tag)
    {
        cmd1 = new SqlCommand("Sp_InsTag");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@id_product", id_product);
        cmd1.Parameters.AddWithValue("@id_tag", id_tag);
        data.executeCommand(cmd1);
        return 0;
    }
    public DataSet AddHotDeal(string Action, string id_product, string FromDate, string ToDate, string FromTime, string ToTime)
    {

        cmd = new SqlCommand("Sp_InsHotDeal");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@id_product", id_product);
        if (FromDate != "")
            cmd.Parameters.AddWithValue("@FromDate", ConvertToDateTime(FromDate));
        else
            cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
        if (ToDate != "")
            cmd.Parameters.AddWithValue("@ToDate", ConvertToDateTime(ToDate));
        else
            cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
        cmd.Parameters.AddWithValue("@FromTime", FromTime);
        cmd.Parameters.AddWithValue("@ToTime", ToTime);
        //data.executeCommand(cmd);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public int InsOrderHistory(string id_employee, string id_order, string id_order_state)
    {

        status = 0;

        cmd = new SqlCommand("Sp_InsOrderHistory");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_employee", id_employee);
        cmd.Parameters.AddWithValue("@id_order", id_order);
        cmd.Parameters.AddWithValue("@id_order_state", id_order_state);
        status = data.executeCommand(cmd);
        return status;
    }
    public DataSet AddBlog(string action, string id_smart_blog_category, string meta_title, string meta_keyword,
        string meta_description, string description, string link_rewrite)
    {
        cmd = new SqlCommand("Sp_InsBlog");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", action);
        cmd.Parameters.AddWithValue("@id_smart_blog_category", id_smart_blog_category);
        cmd.Parameters.AddWithValue("@meta_title", meta_title);
        cmd.Parameters.AddWithValue("@meta_keyword", meta_keyword);
        cmd.Parameters.AddWithValue("@meta_description", meta_description);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.Parameters.AddWithValue("@link_rewrite", link_rewrite);
        ds = data.getDataSet(cmd);

        return ds;
    }
    public DataSet GetBlogComment(string name, string content, string id_smart_blog_comment, string active,
       string date)
    {

        string dd2 = DateTime.Now.ToString("yyyy-M-d");
        cmd = new SqlCommand("Sp_GetBlogComment");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        if (content != "")
            cmd.Parameters.AddWithValue("@content", content);
        else
            cmd.Parameters.AddWithValue("@content", '%');
        if (id_smart_blog_comment != "")
            cmd.Parameters.AddWithValue("@id_smart_blog_comment", id_smart_blog_comment);
        else
            cmd.Parameters.AddWithValue("@id_smart_blog_comment", '%');
        if (active != "")
            cmd.Parameters.AddWithValue("@active", active);
        else
            cmd.Parameters.AddWithValue("@active", '%');
        if (date != "")
            cmd.Parameters.AddWithValue("@date", ConvertToDateTime(date));
        else
            cmd.Parameters.AddWithValue("@date", "");

        ds = data.getDataSet(cmd);
        return ds;
    }
    public int UpdateBlogComment(string content, string id_smart_blog_comment)
    {

        cmd = new SqlCommand("Sp_Updateblog_comment");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@content", content);
        cmd.Parameters.AddWithValue("@id_smart_blog_comment", id_smart_blog_comment);
        data.executeCommand(cmd);
        // ds = data.getDataSet(cmd);
        return 0;
    }
    public DataSet GetBlogPost(string id_smart_blog_post, string Title, string Status, string FDate, string TDate)
    {

        string dd2 = DateTime.Now.ToString("yyyy-M-d");
        cmd = new SqlCommand("Sp_GetBlog_post");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (id_smart_blog_post != "")
            cmd.Parameters.AddWithValue("@id_smart_blog_post", id_smart_blog_post);
        else
            cmd.Parameters.AddWithValue("@id_smart_blog_post", '%');
        if (Title != "")
            cmd.Parameters.AddWithValue("@Title", Title);
        else
            cmd.Parameters.AddWithValue("@Title", '%');
        if (Status != "")
            cmd.Parameters.AddWithValue("@Status", Status);
        else
            cmd.Parameters.AddWithValue("@Status", '%');

        if (FDate != "")
            cmd.Parameters.AddWithValue("@FDate", ConvertToDateTime(FDate));
        else
            cmd.Parameters.AddWithValue("@FDate", "1900-01-01");
        if (TDate != "")
            cmd.Parameters.AddWithValue("@TDate", ConvertToDateTime(TDate));
        else
            cmd.Parameters.AddWithValue("@TDate", dd2);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet AddBlogPost(string Action, string id_smart_blog_post, string meta_title, string meta_keyword, string meta_description,
        string short_description, string content, string link_rewrite)
    {

        cmd = new SqlCommand("Sp_InsBlogPost");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@id_smart_blog_post", id_smart_blog_post);
        cmd.Parameters.AddWithValue("@meta_title", meta_title);
        cmd.Parameters.AddWithValue("@meta_keyword", meta_keyword);
        cmd.Parameters.AddWithValue("@short_description", short_description);
        cmd.Parameters.AddWithValue("@meta_description", meta_description);
        cmd.Parameters.AddWithValue("@content", content);
        cmd.Parameters.AddWithValue("@link_rewrite", link_rewrite);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet AddBlogPostTag(string name, string id_post)
    {
        cmd = new SqlCommand("Sp_InsBlogPostTag");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@id_post", id_post);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet AddPaymentMethod(string Action, string Marchant_id, string WorkingKeyIP, string AccessCodeIP, string WorkingKey,
        string ActionUrl, string AccessCode, string CancelleUrl, string EmailId, string SuccessUrl, string ID)
    {

        cmd = new SqlCommand("Sp_InsPaymentMethod");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@Marchant_id", Marchant_id);
        cmd.Parameters.AddWithValue("@WorkingKeyIP", WorkingKeyIP);
        cmd.Parameters.AddWithValue("@AccessCodeIP", AccessCodeIP);
        cmd.Parameters.AddWithValue("@WorkingKey", WorkingKey);
        cmd.Parameters.AddWithValue("@ActionUrl", ActionUrl);
        cmd.Parameters.AddWithValue("@AccessCode", AccessCode);
        cmd.Parameters.AddWithValue("@CancelleUrl", CancelleUrl);
        cmd.Parameters.AddWithValue("@EmailId", EmailId);
        cmd.Parameters.AddWithValue("@SuccessUrl", SuccessUrl);
        cmd.Parameters.AddWithValue("@ID", ID);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet AddCartRules(string Action, string id_customer, string date_from, string date_to, string description, string quantity,
        string quantity_per_user, string code, string minimum_amount, string minimum_amount_currency,
        string reduction_percent, string reduction_amount, string reduction_currency, string active, string id_cart_rule, string name)
    {

        cmd = new SqlCommand("Sp_InsCartRules");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@id_customer", id_customer);
        if (date_from != "")
            cmd.Parameters.AddWithValue("@date_from", ConvertToDateTime(date_from));
        else
            cmd.Parameters.AddWithValue("@date_from", DBNull.Value);
        if (date_to != "")
            cmd.Parameters.AddWithValue("@date_to", ConvertToDateTime(date_to));
        else
            cmd.Parameters.AddWithValue("@date_to", DBNull.Value);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.Parameters.AddWithValue("@quantity", quantity != "" ? quantity : "0");
        cmd.Parameters.AddWithValue("@quantity_per_user", quantity_per_user != "" ? quantity_per_user : "1");
        cmd.Parameters.AddWithValue("@priority", "1");
        cmd.Parameters.AddWithValue("@partial_use", "1");
        cmd.Parameters.AddWithValue("@code", code);
        cmd.Parameters.AddWithValue("@minimum_amount", minimum_amount != "" ? minimum_amount : "0");
        cmd.Parameters.AddWithValue("@reduction_currency", reduction_currency != "" ? reduction_currency : "1");
        cmd.Parameters.AddWithValue("@active", active != "" ? active : "1");
        cmd.Parameters.AddWithValue("@minimum_amount_currency", minimum_amount_currency != "" ? minimum_amount_currency : "0");
        cmd.Parameters.AddWithValue("@reduction_percent", reduction_percent != "" ? reduction_percent : "1");
        cmd.Parameters.AddWithValue("@reduction_amount", reduction_amount != "" ? reduction_amount : "1");
        cmd.Parameters.AddWithValue("@id_cart_rule", id_cart_rule);
        cmd.Parameters.AddWithValue("@name", name);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet GetReviewAdmin(string PageSize, string pageIndex, string customer_name, string title, string content, string name)
    {

        cmd = new SqlCommand("Sp_GetReviewAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (customer_name != "")
            cmd.Parameters.AddWithValue("@customer_name", customer_name);
        else
            cmd.Parameters.AddWithValue("@customer_name", '%');
        if (title != "")
            cmd.Parameters.AddWithValue("@title", title);
        else
            cmd.Parameters.AddWithValue("@title", '%');
        if (content != "")
            cmd.Parameters.AddWithValue("@content", content);
        else
            cmd.Parameters.AddWithValue("@content", '%');
        if (name != "")
            cmd.Parameters.AddWithValue("@name", name);
        else
            cmd.Parameters.AddWithValue("@name", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public int AddStock(string id_product, string id_product_attribute, string quantity, string out_of_stock)
    {
        cmd = new SqlCommand("Sp_InsStock");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product", id_product);
        cmd.Parameters.AddWithValue("@id_product_attribute", id_product_attribute);
        cmd.Parameters.AddWithValue("@quantity", quantity);
        cmd.Parameters.AddWithValue("@out_of_stock", out_of_stock);
        data.executeCommand(cmd);
        //ds = data.getDataSet(cmd);
        return 0;
    }
    public int AddStockNew(string id_product, string id_product_attribute, string quantity, string out_of_stock)
    {
        cmd = new SqlCommand("Sp_InsStockNew");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id_product", id_product);
        cmd.Parameters.AddWithValue("@id_product_attribute", id_product_attribute);
        cmd.Parameters.AddWithValue("@quantity", quantity);
        cmd.Parameters.AddWithValue("@out_of_stock", out_of_stock);
        data.executeCommand(cmd);
        //ds = data.getDataSet(cmd);
        return 0;
    }
    public DataSet GetShopingCart(string PageSize, string pageIndex, string id_cart, string id_order, string CustName, string CarrierName, string FDate, string TDate, string Total)
    {
        string dd2 = DateTime.Now.ToString("yyyy-M-d");
        cmd = new SqlCommand("Sp_GetShopingCartAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (id_cart != "")
            cmd.Parameters.AddWithValue("@id_cart", id_cart);
        else
            cmd.Parameters.AddWithValue("@id_cart", '%');
        if (id_order != "")
            cmd.Parameters.AddWithValue("@id_order", id_order);
        else
            cmd.Parameters.AddWithValue("@id_order", '%');
        if (CustName != "")
            cmd.Parameters.AddWithValue("@CustName", CustName);
        else
            cmd.Parameters.AddWithValue("@CustName", '%');
        if (CarrierName != "")
            cmd.Parameters.AddWithValue("@CarrierName", CarrierName);
        else
            cmd.Parameters.AddWithValue("@CarrierName", '%');
        if (FDate != "")
            cmd.Parameters.AddWithValue("@FDate", ConvertToDateTime(FDate));
        else
            cmd.Parameters.AddWithValue("@FDate", "1900-01-01");
        if (TDate != "")
            cmd.Parameters.AddWithValue("@TDate", ConvertToDateTime(TDate));
        else
            cmd.Parameters.AddWithValue("@TDate", dd2);
        if (Total != "")
            cmd.Parameters.AddWithValue("@Total", Total);
        else
            cmd.Parameters.AddWithValue("@Total", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }


        return ds;
    }
    public int UpdateAttValuePosition(string itemOrder)
    {
        cmd = new SqlCommand("UpdateAttValueOrder");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@position", itemOrder);
        data.executeCommand(cmd);
        //ds = data.getDataSet(cmd);
        return 0;
    }
    public int AddCarrier(string Action, string value, string id)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_InsCarrier");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@Action", Action);
        cmd1.Parameters.AddWithValue("@name", value);
        cmd1.Parameters.AddWithValue("@id_carrier", id);
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());

        return status;
    }
    public int AddTestimonial(string Action, string author_name, string author_info, string author_url, string author_email, string content, string id)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_InsTestimonial");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@Action", Action);
        cmd1.Parameters.AddWithValue("@author_name", author_name);
        cmd1.Parameters.AddWithValue("@author_info", author_info);
        cmd1.Parameters.AddWithValue("@author_url", author_url);
        cmd1.Parameters.AddWithValue("@author_email", author_email);
        cmd1.Parameters.AddWithValue("@content", content);
        cmd1.Parameters.AddWithValue("@ID", id);
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());

        return status;
    }
    public int AddCreativeCuts(string Action, string Name, string Description, string Image, string id)
    {
        status = 0;
        cmd1 = new SqlCommand("Sp_InsCreativeCuts");
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Clear();
        cmd1.Parameters.AddWithValue("@Action", Action);
        cmd1.Parameters.AddWithValue("@Name", Name);
        cmd1.Parameters.AddWithValue("@Description", Description);
        cmd1.Parameters.AddWithValue("@Image", Image);
        cmd1.Parameters.AddWithValue("@ID", id);
        var result = data.executeCommand(cmd1);
        status = Convert.ToInt32(result.ToString());

        return status;
    }
    public int InsZipCode(string Action, string CountryID, string ZipCode, string Amt, string ID)
    {
        cmd = new SqlCommand("Sp_InsZipCode");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@CountryID", CountryID);
        cmd.Parameters.AddWithValue("@ZipCode", ZipCode);
        cmd.Parameters.AddWithValue("@Amount", Amt != "" ? Amt : "0");
        cmd.Parameters.AddWithValue("@ID", ID);
        data.executeCommand(cmd);

        return 0;
    }
    public DataSet GetRAQdmin(string PageSize, string pageIndex, string FullName, string Email)
    {

        cmd = new SqlCommand("Sp_GetRAQ");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (FullName != "")
            cmd.Parameters.AddWithValue("@FullName", FullName);
        else
            cmd.Parameters.AddWithValue("@FullName", '%');
        if (Email != "")
            cmd.Parameters.AddWithValue("@Email", Email);
        else
            cmd.Parameters.AddWithValue("@Email", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public DataSet GetCustomdmin(string PageSize, string pageIndex, string FullName, string Email)
    {

        cmd = new SqlCommand("Sp_GetCustom");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (FullName != "")
            cmd.Parameters.AddWithValue("@FullName", FullName);
        else
            cmd.Parameters.AddWithValue("@FullName", '%');
        if (Email != "")
            cmd.Parameters.AddWithValue("@Email", Email);
        else
            cmd.Parameters.AddWithValue("@Email", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public DataSet GetBanner(string PageSize, string pageIndex)
    {
        string dd2 = DateTime.Now.ToString("yyyy-M-d");
        cmd = new SqlCommand("Sp_GetBannerAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public DataSet GetContactUs(string PageSize, string pageIndex, string FullName, string Email)
    {

        cmd = new SqlCommand("Sp_GetContactUs");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (FullName != "")
            cmd.Parameters.AddWithValue("@Name", FullName);
        else
            cmd.Parameters.AddWithValue("@Name", '%');
        if (Email != "")
            cmd.Parameters.AddWithValue("@Email", Email);
        else
            cmd.Parameters.AddWithValue("@Email", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public DataSet GetProductEnquiry(string PageSize, string pageIndex, string FullName, string Email, string ProdName)
    {

        cmd = new SqlCommand("Sp_GetProductEnquiry");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (ProdName != "")
            cmd.Parameters.AddWithValue("@ProdName", ProdName);
        else
            cmd.Parameters.AddWithValue("@ProdName", '%');
        if (FullName != "")
            cmd.Parameters.AddWithValue("@Name", FullName);
        else
            cmd.Parameters.AddWithValue("@Name", '%');
        if (Email != "")
            cmd.Parameters.AddWithValue("@Email", Email);
        else
            cmd.Parameters.AddWithValue("@Email", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public DataSet GetTestimonial(string PageSize, string pageIndex, string author_name, string author_info, string author_url, string author_email, string content)
    {

        cmd = new SqlCommand("Sp_GetTestimonial");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (author_name != "")
            cmd.Parameters.AddWithValue("@author_name", author_name);
        else
            cmd.Parameters.AddWithValue("@author_name", '%');
        if (author_info != "")
            cmd.Parameters.AddWithValue("@author_info", author_info);
        else
            cmd.Parameters.AddWithValue("@author_info", '%');
        if (author_url != "")
            cmd.Parameters.AddWithValue("@author_url", author_url);
        else
            cmd.Parameters.AddWithValue("@author_url", '%');
        if (author_email != "")
            cmd.Parameters.AddWithValue("@author_email", author_email);
        else
            cmd.Parameters.AddWithValue("@author_email", '%');
        if (author_email != "")
            cmd.Parameters.AddWithValue("@content", content);
        else
            cmd.Parameters.AddWithValue("@content", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public DataSet GetFancyShape(string PageSize, string pageIndex, string FullName, string Title)
    {

        cmd = new SqlCommand("Sp_GetFancyShape");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (FullName != "")
            cmd.Parameters.AddWithValue("@Name", FullName);
        else
            cmd.Parameters.AddWithValue("@Name", '%');
        if (Title != "")
            cmd.Parameters.AddWithValue("@Title", Title);
        else
            cmd.Parameters.AddWithValue("@Title", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public DataSet GetCreativeCutsEnquiry(string PageSize, string pageIndex, string FullName, string Email, string ProdName)
    {

        cmd = new SqlCommand("Sp_GetCreativeCutsEnquiry");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (FullName != "")
            cmd.Parameters.AddWithValue("@Name", FullName);
        else
            cmd.Parameters.AddWithValue("@Name", '%');
        if (Email != "")
            cmd.Parameters.AddWithValue("@Email", Email);
        else
            cmd.Parameters.AddWithValue("@Email", '%');
        if (ProdName != "")
            cmd.Parameters.AddWithValue("@ProdName", ProdName);
        else
            cmd.Parameters.AddWithValue("@ProdName", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
    public int InsMail(string recipient, string template, string subject, string Status,string OrderId)
    {
        int res = 0;
        cmd = new SqlCommand("Sp_InsMail");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@recipient", recipient);
        cmd.Parameters.AddWithValue("@template", template);
        cmd.Parameters.AddWithValue("@subject", subject);
        cmd.Parameters.AddWithValue("@Status", Status);
        cmd.Parameters.AddWithValue("@OrderId", OrderId);
        res = data.executeCommand(cmd);
        return res;
    }
    public DataSet GetMail(string PageSize, string pageIndex, string recipient, string template, string subject, string Status)
    {

        cmd = new SqlCommand("Sp_GetMailAdmin");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        if (recipient != "")
            cmd.Parameters.AddWithValue("@recipient", recipient);
        else
            cmd.Parameters.AddWithValue("@recipient", '%');
        if (template != "")
            cmd.Parameters.AddWithValue("@template", template);
        else
            cmd.Parameters.AddWithValue("@template", '%');
        if (subject != "")
            cmd.Parameters.AddWithValue("@subject", subject);
        else
            cmd.Parameters.AddWithValue("@subject", '%');
        if (Status != "")
            cmd.Parameters.AddWithValue("@Status", Status);
        else
            cmd.Parameters.AddWithValue("@Status", '%');
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            ds.Tables[0].Columns.Add("RecordCount", typeof(string));
            ds.Tables[0].Rows[0]["RecordCount"] = recordCount;
        }

        return ds;
    }
}
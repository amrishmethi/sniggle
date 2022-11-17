using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using Spire.Xls;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;

public partial class Backoffice_Products : System.Web.UI.Page
{
    int i = 0;
    int m = 0;
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    private static int PageSize = 50;
    private static int pageNo = 1;
    Workbook workbook = new Workbook();
    string filename;
    string fileExtention;
    string excelConnStr;
    OleDbConnection excelConn = new OleDbConnection();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {
            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                //ConvertToDateTime("2/9/2021");
                Session["tab"] = null;
                if (Request.QueryString["PageNo"] != null)
                    pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
                else
                    pageNo = 1;
                if (Request.QueryString["PageSize"] != null)
                {
                    drpPageSize.SelectedValue = Request.QueryString["PageSize"];
                }
                else
                {
                    drpPageSize.SelectedValue = "50";
                    Session["ID"] = null;
                    Session["Name"] = null;
                    Session["Reference"] = null;
                    Session["Cat"] = null;
                    Session["BPrice"] = null;
                    Session["Qty"] = null;
                    Session["Status"] = null;
                    Session["IsHome"] = null;
                    Session["Barcode"] = null;
                }
                this.FillData(pageNo);
            }
        }
    }

    public void FillData(int pageIndex)
    {
        int dd = Convert.ToInt32(pageIndex);
        if (Request.QueryString["PageSize"] != null)
            PageSize = Convert.ToInt32(Request.QueryString["PageSize"]);
        else
            PageSize = 50;

        var ID = Session["ID"] != null ? Session["ID"].ToString() : txtID.Text;
        var Name = Session["Name"] != null ? Session["Name"].ToString() : txtName.Text;
        var Reference = Session["Reference"] != null ? Session["Reference"].ToString() : txtReference.Text;
        var Cat = Session["Cat"] != null ? Session["Cat"].ToString() : txtCat.Text;
        var BPrice = Session["BPrice"] != null ? Session["BPrice"].ToString() : txtBPrice.Text;
        var Qty = Session["Qty"] != null ? Session["Qty"].ToString() : txtQty.Text;
        var Status = Session["Status"] != null ? Session["Status"].ToString() : drpStatus.SelectedValue;
        var IsHome = Session["IsHome"] != null ? Session["IsHome"].ToString() : drpIsHome.SelectedValue;
        var Barcode = Session["Barcode"] != null ? Session["Barcode"].ToString() : drpBarcode.SelectedValue;

        txtID.Text = ID;
        txtName.Text = Name;
        txtReference.Text = Reference;
        txtCat.Text = Cat;
        txtBPrice.Text = BPrice;
        txtQty.Text = Qty;
        drpStatus.SelectedValue = Status;
        drpIsHome.SelectedValue = IsHome;
        drpBarcode.SelectedValue = Barcode;
        ds = gdate.GetProductList(drpPageSize.SelectedValue, pageIndex.ToString(), ID, Name, Reference, Cat, BPrice, Qty, Status, IsHome, Barcode);

        rep.DataSource = ds;
        rep.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.PopulatePager(Convert.ToInt32(ds.Tables[0].Rows[0]["RecordCount"]), pageIndex);
            lblPcount.Text = ds.Tables[0].Rows[0]["RecordCount"].ToString();
            lblTotal.Text = ds.Tables[0].Rows[0]["RecordCount"].ToString();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["ID"] = txtID.Text;
        Session["Name"] = txtName.Text;
        Session["Reference"] = txtReference.Text;
        Session["Cat"] = txtCat.Text;
        Session["BPrice"] = txtBPrice.Text;
        Session["Qty"] = txtQty.Text;
        Session["Status"] = drpStatus.SelectedValue;
        Session["IsHome"] = drpIsHome.SelectedValue;
        Session["Barcode"] = drpBarcode.SelectedValue;
        this.FillData(1);
    }

    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "New")
        {

            data.executeCommand("update ps_product set active = (case when active=1 then 0 else 1 end) where id_product=" + e.CommandArgument + "");
            //if (ViewState["SNO"] != null)
            //{
            //    this.FillData(Convert.ToInt32(ViewState["SNO"]));
            //}
            //else
            //{
            //    this.FillData(1);
            //}

        }
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            data.executeCommand("Sp_DeleteProduct " + e.CommandArgument);
            //if (ViewState["SNO"] != null)
            //{
            //    this.FillData(Convert.ToInt32(ViewState["SNO"]));
            //}
            //else
            //{
            //    this.FillData(1);
            //}
        }
        if (e.CommandName == "H")
        {

            data.executeCommand("update ps_product set IsHome = (case when IsHome=1 then 0 else 1 end),IsHomeDate=getdate() where id_product=" + e.CommandArgument + "");

        }
        if (e.CommandName == "B")
        {

            data.executeCommand("update ps_product set StockForBarCode = (case when StockForBarCode=1 then 0 else 1 end) where id_product=" + e.CommandArgument + "");

        }
        if (e.CommandName == "Edit")
        {
            if (Request.QueryString["PageNo"] != null)
                pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
            Response.Redirect("addproduct.aspx?id=" + e.CommandArgument + "&&PageNo=" + pageNo + "&&PageSize=" + drpPageSize.SelectedValue);
        }

        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    private void PopulatePager(int recordCount, int currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / (decimal)PageSize);
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("<<", "1", currentPage > 1));
            if (currentPage != 1)
            {
                pages.Add(new ListItem("Previous", (currentPage - 1).ToString()));
            }
            if (pageCount < 4)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            else if (currentPage < 4)
            {
                for (int i = 1; i <= 4; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("...", (currentPage).ToString(), false));
            }
            else if (currentPage > pageCount - 4)
            {
                pages.Add(new ListItem("...", (currentPage).ToString(), false));
                for (int i = currentPage - 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            else
            {
                pages.Add(new ListItem("...", (currentPage).ToString(), false));
                for (int i = currentPage - 2; i <= currentPage + 2; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("...", (currentPage).ToString(), false));
            }
            if (currentPage != pageCount)
            {
                pages.Add(new ListItem("next", (currentPage + 1).ToString()));
            }
            pages.Add(new ListItem(">>", pageCount.ToString(), currentPage < pageCount));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        // this.FillData(pageIndex);
        if (Request.QueryString["PageSize"] != null)
            PageSize = Convert.ToInt32(Request.QueryString["PageSize"]);
        else
            PageSize = 50;
        Response.Redirect("Products.aspx?PageNo=" + pageIndex.ToString() + "&&PageSize=" + PageSize.ToString());
        ViewState["SNO"] = pageIndex.ToString();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ViewState["SNO"] = null;
        txtBPrice.Text = txtCat.Text = txtID.Text = txtName.Text = txtQty.Text = txtReference.Text = "";
        drpStatus.SelectedIndex = 0;
        Response.Redirect("Products.aspx");
    }

    protected void drpPageSize_TextChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                Data data = new Data();
                data.executeCommand("Sp_DeleteProduct " + lblid.Text);
            }
        }

        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Deleted Successfully......')", true);
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnEnable_Click(object sender, EventArgs e)
    {
        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_product set active = 1 where id_product=" + lblid.Text + "");
            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Enable Successfully......')", true);
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);

    }

    protected void btnDisable_Click(object sender, EventArgs e)
    {
        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_product set active = 0 where id_product=" + lblid.Text + "");
            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Disable Successfully......')", true);
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    public string Url(object id_product)
    {
        string ss = "";
        if (id_product.ToString() == "" || id_product.ToString() == null)
        {
            ss = "";
        }
        else
        {
            if (Request.QueryString["PageNo"] != null)
                pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
            ss = "addproduct.aspx?id=" + id_product.ToString() + "&&PageNo=" + pageNo + "&&PageSize=" + drpPageSize.SelectedValue;
        }
        return ss;
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        string sp = "";
        Label lblid; 
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                sp += (sp == "") ? lblid.Text : "," + lblid.Text;
            }
        }
        if (sp != "")
        {
            string ss = "[Usp_DownloadExcel2] '" + sp + "'";
            ds = data.getDataSet(ss);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ExcelWithoutQty(ds);
            }
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string name = "";
            if (url.Contains("localhost"))
            {
                name = @"G:\GitHub\sniggle\ExcelDownload\MyEarthExcel.xlsx";
            }
            else
                name = "C:/HostingSpaces/admin/sniggle.in/wwwroot/ExcelDownload/MyEarthExcel.xlsx";

            workbook.SaveToFile(name);
            string ff = "MyEarthExcel.xlsx";
            string filePath = "../ExcelDownload/MyEarthExcel.xlsx";
            Response.ContentType = "application/excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + ff + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
    }

    private void ExcelWithoutQty(DataSet dsexcel)
    {
        try
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string name = "";
            if (url.Contains("localhost"))
                name = @"G:\GitHub\sniggle\Excel\MyEarthExcel.xlsx";
            else
                name = "C:/HostingSpaces/admin/sniggle.in/wwwroot/Excel/MyEarthExcel.xlsx";

            workbook.LoadFromFile(name);
            Worksheet worksheet = workbook.Worksheets[0];
            #region FillGridDetails
            DataView dv = dsexcel.Tables[0].DefaultView;
            int i = 0;
            int m = 0;
            foreach (DataRow dr in dv.ToTable().Rows)
            {
                m = 2 + i;
                worksheet.Range[m, 1].Style.Font.IsBold = true;

                worksheet.Range[m, 1].Text = dr["ReferenceCode"].ToString();
                worksheet.Range[m, 2].Text = dr["Name"].ToString();
                worksheet.Range[m, 3].Text = dr["Condition"].ToString();
                worksheet.Range[m, 4].Text = dr["RetailPrice"].ToString();
                worksheet.Range[m, 5].Text = dr["PriceUnit"].ToString();
                worksheet.Range[m, 6].Text = dr["DisountValue"].ToString();
                worksheet.Range[m, 7].Text = dr["DefaultCategory"].ToString();
                worksheet.Range[m, 8].Text = dr["Category1"].ToString();
                worksheet.Range[m, 9].Text = dr["Category2"].ToString();
                worksheet.Range[m, 10].Text = dr["Category3"].ToString();
                worksheet.Range[m, 11].Text = dr["Category4"].ToString();
                worksheet.Range[m, 12].Text = dr["Category5"].ToString();
                worksheet.Range[m, 13].Text = dr["Color"].ToString();
                worksheet.Range[m, 14].Text = dr["IsParent"].ToString();
                worksheet.Range[m, 15].Text = dr["DefaultCombination"].ToString();
                worksheet.Range[m, 16].Text = dr["ChildSKU"].ToString();
                worksheet.Range[m, 17].Text = dr["DifferencePrice"].ToString();
                worksheet.Range[m, 18].Text = dr["PriceImpact"].ToString();
                worksheet.Range[m, 19].Text = dr["DifferenceWeight"].ToString();
                worksheet.Range[m, 20].Text = dr["WeightImpact"].ToString();
                worksheet.Range[m, 21].Text = dr["MinQty"].ToString();
                worksheet.Range[m, 22].Text = dr["AvailabilityText"].ToString();
                worksheet.Range[m, 23].Text = dr["StockQty"].ToString();
                worksheet.Range[m, 24].Text = dr["AllowStocktOrder"].ToString();
                worksheet.Range[m, 25].Text = dr["HotDealFromDate"].ToString();
                worksheet.Range[m, 26].Text = dr["HotDealToDate"].ToString();
                worksheet.Range[m, 27].Text = dr["HotDealFromTime"].ToString();
                worksheet.Range[m, 28].Text = dr["HotDealToTime"].ToString();
                worksheet.Range[m, 29].Text = dr["VideoHeading"].ToString();
                worksheet.Range[m, 30].Text = dr["VideoLink"].ToString();
                worksheet.Range[m, 31].Text = dr["MetaTitle"].ToString();
                worksheet.Range[m, 32].Text = dr["MetaDescription"].ToString();
                worksheet.Range[m, 33].Text = dr["FriendlyURL"].ToString();
                worksheet.Range[m, 34].Text = dr["Description"].ToString();
                worksheet.Range[m, 35].Text = dr["Enabled"].ToString();
                worksheet.Range[m, 36].Text = dr["id_product"].ToString();
                worksheet.Range[m, 37].Text = dr["id_product_attribute"].ToString();
                worksheet.Range[m, 38].Text = dr["IsDeleted"].ToString();
                worksheet.Range[m, 39].Text = dr["Size"].ToString();
                worksheet.Range[m, 40].Text = dr["Weight"].ToString(); 
                worksheet.Range[m, 42].Text = dr["ImgURL1"].ToString(); 
                worksheet.Range[m, 43].Text = dr["ImgURL2"].ToString(); 
                worksheet.Range[m, 44].Text = dr["ImgURL3"].ToString(); 
                worksheet.Range[m, 45].Text = dr["ImgURL4"].ToString(); 
                worksheet.Range[m, 46].Text = dr["ImgURL5"].ToString(); 
                worksheet.Range[m, 47].Text = dr["ImgURL6"].ToString(); 
         
                worksheet.Range[m, 2, m, 40].HorizontalAlignment = HorizontalAlignType.Left;
                worksheet.Range[m, 2, m, 40].VerticalAlignment = VerticalAlignType.Center;
                i++;
            }
            #endregion
        }
        catch (Exception ex)
        {
            //Myclass.filewrite(ex.StackTrace);
        }
    }

    private void ExcelDocViewer(string fileName)
    {
        try
        {
            System.Diagnostics.Process.Start(fileName);
        }
        catch (Exception ex)
        {
            //Myclass.filewrite(ex.StackTrace);
        }

    }

    protected void btnSaveP_Click(object sender, EventArgs e)
    {
        if (FlpExcel.HasFile)
        {
            upload();

            this.FillData(pageNo);
        }
    }

    public void upload()
    {
        filename = "";
        string id = "";
        if (Request.QueryString["id"] != null)
        {
            id = Request.QueryString["id"].ToString();
        }
        try
        {
            if (FlpExcel.HasFile)
            {
                filename = Path.GetFileName(FlpExcel.PostedFile.FileName);
                fileExtention = Path.GetExtension(FlpExcel.PostedFile.FileName);
                FlpExcel.PostedFile.SaveAs(Server.MapPath("../SaveUpload/" + filename));

                OleDbCommand excelCommand = new OleDbCommand();
                OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();
                if ((fileExtention == ".xlsx") || (fileExtention == ".XLSX"))
                {
                    excelConnStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath("../SaveUpload/" + filename) + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                }
                else
                {
                    excelConnStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath("../SaveUpload/" + filename) + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                }
                excelConn = new OleDbConnection(excelConnStr);
                excelConn.Close();
                excelConn.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = "Sheet1$";//
                string query = "SELECT  * From [" + sheetName + "] where [ReferenceCode]<>''";
                excelCommand = new OleDbCommand(query, excelConn);
                excelDataAdapter.SelectCommand = excelCommand;
                DbDataReader dr = excelCommand.ExecuteReader();
                dt.Load(dr);

                string CS = data.conString;
                SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                bulkInsert.DestinationTableName = "[dbo].[tbl_AllProduct]";
                bulkInsert.ColumnMappings.Add("ReferenceCode", "[ReferenceCode]");
                bulkInsert.ColumnMappings.Add("Name", "[Name]");
                bulkInsert.ColumnMappings.Add("Condition", "[Condition]");
                bulkInsert.ColumnMappings.Add("RetailPrice", "[RetailPrice]");
                bulkInsert.ColumnMappings.Add("PriceUnit", "[PriceUnit]");
                bulkInsert.ColumnMappings.Add("DisountValue", "[DisountValue]");
                bulkInsert.ColumnMappings.Add("DiscountType", "[DiscountType]");
                bulkInsert.ColumnMappings.Add("DefaultCategory", "[DefaultCategory]");
                bulkInsert.ColumnMappings.Add("Category1", "[Category1]");
                bulkInsert.ColumnMappings.Add("Category2", "[Category2]");
                bulkInsert.ColumnMappings.Add("Category3", "[Category3]");
                bulkInsert.ColumnMappings.Add("Category4", "[Category4]");
                bulkInsert.ColumnMappings.Add("Category5", "[Category5]");
                bulkInsert.ColumnMappings.Add("IsParent", "[IsParent]");
                bulkInsert.ColumnMappings.Add("DefaultCombination", "[DefaultCombination]");
                bulkInsert.ColumnMappings.Add("ChildSKU", "[ChildSKU]");
                bulkInsert.ColumnMappings.Add("CSize", "[Size]");
                bulkInsert.ColumnMappings.Add("Ccolor", "[color]");
                bulkInsert.ColumnMappings.Add("DifferencePrice", "[DifferencePrice]");
                bulkInsert.ColumnMappings.Add("PriceImpact", "[PriceImpact]");
                bulkInsert.ColumnMappings.Add("DifferenceWeight", "[DifferenceWeight]");
                bulkInsert.ColumnMappings.Add("WeightImpact", "[WeightImpact]");
                bulkInsert.ColumnMappings.Add("MinQty", "[MinQty]");
                bulkInsert.ColumnMappings.Add("AvailabilityText", "[AvailabilityText]");
                bulkInsert.ColumnMappings.Add("StockQty", "[StockQty]");
                bulkInsert.ColumnMappings.Add("AllowStockOrder", "[AllowStockOrder]");
                bulkInsert.ColumnMappings.Add("HotDealFromDate", "[HotDealFromDate]");
                bulkInsert.ColumnMappings.Add("HotDealToDate", "[HotDealToDate]");
                bulkInsert.ColumnMappings.Add("HotDealFromTime", "[HotDealFromTime]");
                bulkInsert.ColumnMappings.Add("HotDealToTime", "[HotDealToTime]");
                bulkInsert.ColumnMappings.Add("VideoHeading", "[VideoHeading]");
                bulkInsert.ColumnMappings.Add("VideoLink", "[VideoLink]");
                bulkInsert.ColumnMappings.Add("MetaTitle", "[MetaTitle]");
                bulkInsert.ColumnMappings.Add("MetaDescription", "[MetaDescription]");
                bulkInsert.ColumnMappings.Add("FriendlyURL", "[FriendlyURL]");
                bulkInsert.ColumnMappings.Add("Description", "[Description]");
                bulkInsert.ColumnMappings.Add("Enabled", "[Enabled]");
                bulkInsert.ColumnMappings.Add("id_product", "[id_product]");
                bulkInsert.ColumnMappings.Add("id_product_attribute", "[id_product_attribute]");
                bulkInsert.ColumnMappings.Add("IsDeleted", "[IsDeleted]");
                int res = SaveProduct(dt);
                excelConn.Close();
                if (res == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    string path = Server.MapPath("../SaveUpload/" + filename);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not  
                    {
                        file.Delete();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.StackTrace.ToString() + "')", true);
            gdate.LogError(ex.Message.ToLower(), "Save Sheet", "Product", ex.StackTrace.ToString());
            string path = Server.MapPath("../SaveUpload/" + filename);
            FileInfo file = new FileInfo(path);
            if (file.Exists)//check file exsit or not  
            {
                file.Delete();
            }
        }
    }

    public void uploadUpdate()
    {
        filename = "";
        string id = "";
        if (Request.QueryString["id"] != null)
        {
            id = Request.QueryString["id"].ToString();
        }
        try
        {
            if (FlpExcelUpdate.HasFile)
            {
                filename = Path.GetFileName(FlpExcelUpdate.PostedFile.FileName);
                fileExtention = Path.GetExtension(FlpExcelUpdate.PostedFile.FileName);
                FlpExcelUpdate.PostedFile.SaveAs(Server.MapPath("../SaveUpload/" + filename));

                OleDbCommand excelCommand = new OleDbCommand();
                OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();
                if ((fileExtention == ".xlsx") || (fileExtention == ".XLSX"))
                {
                    excelConnStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath("../SaveUpload/" + filename) + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                }
                else
                {
                    excelConnStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath("../SaveUpload/" + filename) + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                }
                excelConn = new OleDbConnection(excelConnStr);
                excelConn.Close();
                excelConn.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = "Sheet1$";//
                string query = "SELECT  * From [" + sheetName + "] where [Update]='Yes' ";
                excelCommand = new OleDbCommand(query, excelConn);
                excelDataAdapter.SelectCommand = excelCommand;
                DbDataReader dr = excelCommand.ExecuteReader();

                dt.Load(dr);

                string CS = data.conString;
                SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                bulkInsert.DestinationTableName = "[dbo].[tbl_AllProduct]";
                bulkInsert.ColumnMappings.Add("ReferenceCode", "[ReferenceCode]");
                bulkInsert.ColumnMappings.Add("Name", "[Name]");
                bulkInsert.ColumnMappings.Add("Condition", "[Condition]");
                bulkInsert.ColumnMappings.Add("RetailPrice", "[RetailPrice]");
                bulkInsert.ColumnMappings.Add("PriceUnit", "[PriceUnit]");
                bulkInsert.ColumnMappings.Add("DisountValue", "[DisountValue]");
                bulkInsert.ColumnMappings.Add("DiscountType", "[DiscountType]");
                bulkInsert.ColumnMappings.Add("DefaultCategory", "[DefaultCategory]");
                bulkInsert.ColumnMappings.Add("Category1", "[Category1]");
                bulkInsert.ColumnMappings.Add("Category2", "[Category2]");
                bulkInsert.ColumnMappings.Add("Category3", "[Category3]");
                bulkInsert.ColumnMappings.Add("Category4", "[Category4]");
                bulkInsert.ColumnMappings.Add("Category5", "[Category5]");
                bulkInsert.ColumnMappings.Add("IsParent", "[IsParent]");
                bulkInsert.ColumnMappings.Add("DefaultCombination", "[DefaultCombination]");
                bulkInsert.ColumnMappings.Add("ChildSKU", "[ChildSKU]");
                bulkInsert.ColumnMappings.Add("CSize", "[Size]");
                bulkInsert.ColumnMappings.Add("Ccolor", "[color]");
                bulkInsert.ColumnMappings.Add("DifferencePrice", "[DifferencePrice]");
                bulkInsert.ColumnMappings.Add("PriceImpact", "[PriceImpact]");
                bulkInsert.ColumnMappings.Add("DifferenceWeight", "[DifferenceWeight]");
                bulkInsert.ColumnMappings.Add("WeightImpact", "[WeightImpact]");
                bulkInsert.ColumnMappings.Add("MinQty", "[MinQty]");
                bulkInsert.ColumnMappings.Add("AvailabilityText", "[AvailabilityText]");
                bulkInsert.ColumnMappings.Add("StockQty", "[StockQty]");
                bulkInsert.ColumnMappings.Add("AllowStockOrder", "[AllowStockOrder]");
                bulkInsert.ColumnMappings.Add("HotDealFromDate", "[HotDealFromDate]");
                bulkInsert.ColumnMappings.Add("HotDealToDate", "[HotDealToDate]");
                bulkInsert.ColumnMappings.Add("HotDealFromTime", "[HotDealFromTime]");
                bulkInsert.ColumnMappings.Add("HotDealToTime", "[HotDealToTime]");
                bulkInsert.ColumnMappings.Add("VideoHeading", "[VideoHeading]");
                bulkInsert.ColumnMappings.Add("VideoLink", "[VideoLink]");
                bulkInsert.ColumnMappings.Add("MetaTitle", "[MetaTitle]");
                bulkInsert.ColumnMappings.Add("MetaDescription", "[MetaDescription]");
                bulkInsert.ColumnMappings.Add("FriendlyURL", "[FriendlyURL]");
                bulkInsert.ColumnMappings.Add("Description", "[Description]");
                bulkInsert.ColumnMappings.Add("Enabled", "[Enabled]");
                bulkInsert.ColumnMappings.Add("Update", "[Update]");
                bulkInsert.ColumnMappings.Add("id_product", "[id_product]");
                bulkInsert.ColumnMappings.Add("id_product_attribute", "[id_product_attribute]");
                bulkInsert.ColumnMappings.Add("IsDeleted", "[IsDeleted]");
                bulkInsert.ColumnMappings.Add("ImgURL1", "[ImgURL1]");
                bulkInsert.ColumnMappings.Add("ImgURL2", "[ImgURL2]");
                bulkInsert.ColumnMappings.Add("ImgURL3", "[ImgURL3]");
                bulkInsert.ColumnMappings.Add("ImgURL4", "[ImgURL4]");
                bulkInsert.ColumnMappings.Add("ImgURL5", "[ImgURL5]");
                bulkInsert.ColumnMappings.Add("ImgURL6", "[ImgURL6]");
                int res = UpdateProduct(dt);
                excelConn.Close();
                if (res == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                    string path = Server.MapPath("../SaveUpload/" + filename);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not  
                    {
                        file.Delete();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error')", true);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.StackTrace.ToString() + "')", true);
            gdate.LogError(ex.Message.ToLower(), "Update Sheet", "Product", ex.StackTrace.ToString());
            string path = Server.MapPath("../SaveUpload/" + filename);
            FileInfo file = new FileInfo(path);
            if (file.Exists)//check file exsit or not  
            {
                file.Delete();
            }
        }

    }

    public int SaveProduct(DataTable dtOrder)
    {
        int ss = 1;
        SqlCommand cmd = new SqlCommand();
        DataTable dtt = dtOrder;
        foreach (DataRow drExcel in dtt.Rows)
        {
            try
            {
                cmd.CommandText = "Sp_AllProductIns";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ReferenceCode", drExcel["ReferenceCode"]);
                cmd.Parameters.AddWithValue("@Name", drExcel["Name"]);
                cmd.Parameters.AddWithValue("@Condition", drExcel["Condition"]);
                cmd.Parameters.AddWithValue("@RetailPrice", drExcel["RetailPrice"]);
                cmd.Parameters.AddWithValue("@PriceUnit", drExcel["PriceUnit"]);
                cmd.Parameters.AddWithValue("@DisountValue", drExcel["DisountValue"]);
                cmd.Parameters.AddWithValue("@DiscountType", DBNull.Value);
                cmd.Parameters.AddWithValue("@DefaultCategory", drExcel["DefaultCategory"]);
                cmd.Parameters.AddWithValue("@Category1", drExcel["Category1"]);
                cmd.Parameters.AddWithValue("@Category2", drExcel["Category2"]);
                cmd.Parameters.AddWithValue("@Category3", drExcel["Category3"]);
                cmd.Parameters.AddWithValue("@Category4", drExcel["Category4"]);
                cmd.Parameters.AddWithValue("@Category5", drExcel["Category5"]);
                cmd.Parameters.AddWithValue("@IsParent", drExcel["IsParent"]);
                cmd.Parameters.AddWithValue("@ChildSKU", drExcel["ChildSKU"]);
                cmd.Parameters.AddWithValue("@DefaultCombination", drExcel["DefaultCombination"]);
                cmd.Parameters.AddWithValue("@Ccolour", drExcel["color"]);
                cmd.Parameters.AddWithValue("@CSize", drExcel["Size"]);
                cmd.Parameters.AddWithValue("@DifferencePrice", drExcel["DifferencePrice"]);
                cmd.Parameters.AddWithValue("@PriceImpact", drExcel["PriceImpact"]);
                cmd.Parameters.AddWithValue("@DifferenceWeight", drExcel["DifferenceWeight"]);
                cmd.Parameters.AddWithValue("@WeightImpact", drExcel["WeightImpact"]);
                cmd.Parameters.AddWithValue("@MinQty", drExcel["MinQty"]);
                cmd.Parameters.AddWithValue("@AvailabilityText", drExcel["AvailabilityText"]);
                if (drExcel["StockQty"].ToString() != "")
                    cmd.Parameters.AddWithValue("@StockQty", drExcel["StockQty"]);
                else
                    cmd.Parameters.AddWithValue("@StockQty", "0");
                cmd.Parameters.AddWithValue("@AllowStockOrder", drExcel["AllowStockOrder"]);
                if (drExcel["HotDealFromDate"].ToString() != "" || drExcel["HotDealFromDate"].ToString() != "NULL" || drExcel["HotDealFromDate"].ToString() != null)
                    cmd.Parameters.AddWithValue("@HotDealFromDate", ConvertToDateTime(drExcel["HotDealFromDate"].ToString()));
                else
                    cmd.Parameters.AddWithValue("@HotDealFromDate", DBNull.Value);
                if (drExcel["HotDealToDate"].ToString() != "" || drExcel["HotDealToDate"].ToString() != "NULL" || drExcel["HotDealToDate"].ToString() != null)
                    cmd.Parameters.AddWithValue("@HotDealToDate", ConvertToDateTime(drExcel["HotDealToDate"].ToString()));
                else
                    cmd.Parameters.AddWithValue("@HotDealToDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@HotDealFromTime", drExcel["HotDealFromTime"]);
                cmd.Parameters.AddWithValue("@HotDealToTime", drExcel["HotDealToTime"]);
                cmd.Parameters.AddWithValue("@VideoHeading", drExcel["VideoHeading"]);
                cmd.Parameters.AddWithValue("@VideoLink", drExcel["VideoLink"]);
                cmd.Parameters.AddWithValue("@MetaTitle", drExcel["MetaTitle"]);
                cmd.Parameters.AddWithValue("@MetaDescription", drExcel["MetaDescription"]);
                cmd.Parameters.AddWithValue("@FriendlyURL", drExcel["FriendlyURL"]);
                cmd.Parameters.AddWithValue("@Description", drExcel["Description"]);
                cmd.Parameters.AddWithValue("@Enabled", drExcel["Enabled"]);
                cmd.Parameters.AddWithValue("@Action", "Add");
                cmd.Parameters.AddWithValue("@ID", "0");
                cmd.Parameters.AddWithValue("@PrdID", drExcel["id_product"]);
                cmd.Parameters.AddWithValue("@PrdAttID", drExcel["id_product_attribute"]);
                cmd.Parameters.AddWithValue("@IsDeleted", drExcel["IsDeleted"]);
                cmd.Parameters.AddWithValue("@ImgURL1", drExcel["ImgURL1"]);
                cmd.Parameters.AddWithValue("@ImgURL2", drExcel["ImgURL2"]);
                cmd.Parameters.AddWithValue("@ImgURL3", drExcel["ImgURL3"]);
                cmd.Parameters.AddWithValue("@ImgURL4", drExcel["ImgURL4"]);
                cmd.Parameters.AddWithValue("@ImgURL5", drExcel["ImgURL5"]);
                cmd.Parameters.AddWithValue("@ImgURL6", drExcel["ImgURL6"]);
                ss = data.executeCommandP(cmd);
            }
            catch (Exception ee)
            {
                gdate.LogError(ee.Message.ToLower(), "Save Sheet", "Product", ee.StackTrace.ToString());
            }
        }
        return ss;
    }

    private string ConvertToDateTime(string strDateTime)
    {
        if (strDateTime != "")
        {
            string sDateTime;
            string[] sDate;
            if (strDateTime.Contains("/"))
            {
                sDate = strDateTime.Split('/');
            }
            else if (strDateTime.Contains("-"))
            {
                sDate = strDateTime.Split('-');
            }
            else
            {
                sDate = strDateTime.Split('-');
            }
            //sDateTime = sDate[2].Substring(0, 4) + '-' + sDate[1] + '-' + sDate[0];
            sDateTime = sDate[0] + '-' + sDate[1] + '-' + sDate[2].Substring(0, 4);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + sDateTime + "')", true);
            return sDateTime;
        }
        else
            return strDateTime;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (FlpExcelUpdate.HasFile)
        {
            uploadUpdate();
            this.FillData(pageNo);
        }
    }

    public int UpdateProduct(DataTable dtOrder)
    {
        int ss = 1;
        SqlCommand cmd = new SqlCommand();
        DataTable dtt = dtOrder;
        foreach (DataRow drExcel in dtt.Rows)
        {
            try
            {
                cmd.CommandText = "Sp_AllProductIns";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ReferenceCode", drExcel["ReferenceCode"]);
                cmd.Parameters.AddWithValue("@Name", drExcel["Name"]);
                cmd.Parameters.AddWithValue("@Condition", drExcel["Condition"]);
                cmd.Parameters.AddWithValue("@RetailPrice", (drExcel["RetailPrice"].ToString() != "") ? drExcel["RetailPrice"].ToString() : "0");
                cmd.Parameters.AddWithValue("@PriceUnit", drExcel["PriceUnit"]);
                cmd.Parameters.AddWithValue("@DisountValue", drExcel["DisountValue"]);
                cmd.Parameters.AddWithValue("@DiscountType", drExcel["DiscountType"]);
                cmd.Parameters.AddWithValue("@DefaultCategory", drExcel["DefaultCategory"]);
                cmd.Parameters.AddWithValue("@Category1", drExcel["Category1"]);
                cmd.Parameters.AddWithValue("@Category2", drExcel["Category2"]);
                cmd.Parameters.AddWithValue("@Category3", drExcel["Category3"]);
                cmd.Parameters.AddWithValue("@Category4", drExcel["Category4"]);
                cmd.Parameters.AddWithValue("@Category5", drExcel["Category5"]);
                cmd.Parameters.AddWithValue("@IsParent", drExcel["IsParent"]);
                cmd.Parameters.AddWithValue("@DefaultCombination", drExcel["DefaultCombination"]);
                cmd.Parameters.AddWithValue("@ChildSKU", drExcel["ChildSKU"]);
                cmd.Parameters.AddWithValue("@CSize", drExcel["Size"]);
                cmd.Parameters.AddWithValue("@Ccolour", drExcel["color"]);
                cmd.Parameters.AddWithValue("@DifferencePrice", drExcel["DifferencePrice"]);
                cmd.Parameters.AddWithValue("@PriceImpact", drExcel["PriceImpact"]);
                cmd.Parameters.AddWithValue("@DifferenceWeight", drExcel["DifferenceWeight"]);
                cmd.Parameters.AddWithValue("@WeightImpact", drExcel["WeightImpact"]);
                cmd.Parameters.AddWithValue("@MinQty", drExcel["MinQty"]);
                cmd.Parameters.AddWithValue("@AvailabilityText", drExcel["AvailabilityText"]);
                cmd.Parameters.AddWithValue("@StockQty", (drExcel["StockQty"].ToString() != "") ? drExcel["StockQty"].ToString() : "0");

                cmd.Parameters.AddWithValue("@AllowStockOrder", drExcel["AllowStockOrder"]);
                if (drExcel["HotDealFromDate"].ToString() != "" || drExcel["HotDealFromDate"].ToString() != "NULL" || drExcel["HotDealFromDate"].ToString() != null)
                    cmd.Parameters.AddWithValue("@HotDealFromDate", ConvertToDateTime(drExcel["HotDealFromDate"].ToString()));
                else
                    cmd.Parameters.AddWithValue("@HotDealFromDate", DBNull.Value);
                if (drExcel["HotDealToDate"].ToString() != "" || drExcel["HotDealToDate"].ToString() != "NULL" || drExcel["HotDealToDate"].ToString() != null)
                    cmd.Parameters.AddWithValue("@HotDealToDate", ConvertToDateTime(drExcel["HotDealToDate"].ToString()));
                else
                    cmd.Parameters.AddWithValue("@HotDealToDate", DBNull.Value);

                cmd.Parameters.AddWithValue("@HotDealFromTime", drExcel["HotDealFromTime"]);
                cmd.Parameters.AddWithValue("@HotDealToTime", drExcel["HotDealToTime"]);
                cmd.Parameters.AddWithValue("@VideoHeading", drExcel["VideoHeading"]);
                cmd.Parameters.AddWithValue("@VideoLink", drExcel["VideoLink"]);
                cmd.Parameters.AddWithValue("@MetaTitle", drExcel["MetaTitle"]);
                cmd.Parameters.AddWithValue("@MetaDescription", drExcel["MetaDescription"]);
                cmd.Parameters.AddWithValue("@FriendlyURL", drExcel["FriendlyURL"]);
                cmd.Parameters.AddWithValue("@Description", drExcel["Description"]);
                cmd.Parameters.AddWithValue("@Enabled", drExcel["Enabled"]);
                cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@ID", drExcel["Update"]);
                cmd.Parameters.AddWithValue("@PrdID", drExcel["id_product"]);
                cmd.Parameters.AddWithValue("@PrdAttID", drExcel["id_product_attribute"]); 
                cmd.Parameters.AddWithValue("@IsDeleted", drExcel["IsDeleted"]);
                ss = data.executeCommandP(cmd);
            }
            catch (Exception ee)
            {
                gdate.LogError(ee.Message.ToLower(), "Update Sheet", "Product", ee.StackTrace.ToString());
            }
        }
        return ss;
    }

    protected void btnTagSave_Click(object sender, EventArgs e)
    {
        if (flapTagSave.HasFile)
        {
            uploadTag();
        }
    }

    protected void btnTagUpdate_Click(object sender, EventArgs e)
    {

    }

    protected void btnTagDownload_Click(object sender, EventArgs e)
    {

        string sp = "0";
        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                sp += "," + lblid.Text;
            }
        }


        string ss = "[Usp_DownloadTagExcel] '" + sp + "'";
        ds = data.getDataSet(ss);
        if (ds.Tables[0].Rows.Count > 0)
        {

            ExcelTag(ds);
        }
        string name = "C:/HostingSpaces/admin/sniggle.in/wwwroot/ExcelDownload/TagFormat.xlsx";
        //string name = "F:\\Arvind\\MyEarthBackoffice\\ExcelDownload\\TagFormat.xlsx";
        workbook.SaveToFile(name);
        string ff = "TagFormat.xlsx";
        string filePath = "../ExcelDownload/TagFormat.xlsx";
        Response.ContentType = "application/excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + ff + "\"");
        Response.TransmitFile(Server.MapPath(filePath));
        Response.End();

    }

    private void ExcelTag(DataSet dsexcel)
    {
        try
        {
            //workbook.LoadFromFile("F:\\Arvind\\MyEarthBackoffice\\Excel\\TagFormat.xlsx");
            workbook.LoadFromFile("C:/HostingSpaces/admin/sniggle.in/wwwroot/Excel/TagFormat.xlsx");
            Worksheet worksheet = workbook.Worksheets[0];
            #region FillGridDetails
            DataView dv = dsexcel.Tables[0].DefaultView;
            int i = 0;
            int m = 0;
            foreach (DataRow dr in dv.ToTable().Rows)
            {
                m = 2 + i;
                worksheet.Range[m, 1].Style.Font.IsBold = true;
                worksheet.Range[m, 1].Text = dr["ReferenceCode"].ToString();
                worksheet.Range[m, 2].Text = dr["id_product"].ToString();
                worksheet.Range[m, 3].Text = dr["name"].ToString();
                worksheet.Range[m, 4].Text = dr["tag1"].ToString();
                worksheet.Range[m, 5].Text = dr["tag2"].ToString();
                worksheet.Range[m, 6].Text = dr["tag3"].ToString();
                worksheet.Range[m, 7].Text = dr["tag4"].ToString();
                worksheet.Range[m, 8].Text = dr["tag5"].ToString();
                worksheet.Range[m, 9].Text = dr["tag6"].ToString();
                worksheet.Range[m, 10].Text = dr["tag7"].ToString();
                worksheet.Range[m, 11].Text = dr["tag8"].ToString();
                worksheet.Range[m, 12].Text = dr["tag9"].ToString();
                worksheet.Range[m, 13].Text = dr["tag10"].ToString();
                worksheet.Range[m, 14].Text = dr["tag11"].ToString();
                worksheet.Range[m, 15].Text = dr["tag12"].ToString();
                worksheet.Range[m, 16].Text = dr["tag13"].ToString();
                worksheet.Range[m, 17].Text = dr["tag14"].ToString();
                worksheet.Range[m, 18].Text = dr["tag15"].ToString();
                worksheet.Range[m, 19].Text = dr["tag16"].ToString();
                worksheet.Range[m, 20].Text = dr["tag17"].ToString();
                worksheet.Range[m, 21].Text = dr["tag18"].ToString();
                worksheet.Range[m, 22].Text = dr["tag19"].ToString();
                worksheet.Range[m, 23].Text = dr["tag20"].ToString();
                worksheet.Range[m, 24].Text = dr["tag21"].ToString();
                worksheet.Range[m, 25].Text = dr["tag22"].ToString();
                worksheet.Range[m, 26].Text = dr["tag23"].ToString();
                worksheet.Range[m, 27].Text = dr["tag24"].ToString();
                worksheet.Range[m, 28].Text = dr["tag25"].ToString();
                worksheet.Range[m, 29].Text = dr["tag26"].ToString();
                worksheet.Range[m, 30].Text = dr["tag27"].ToString();
                worksheet.Range[m, 31].Text = dr["tag28"].ToString();
                worksheet.Range[m, 32].Text = dr["tag29"].ToString();
                worksheet.Range[m, 33].Text = dr["tag30"].ToString();

                worksheet.Range[m, 12, m, 15].HorizontalAlignment = HorizontalAlignType.Right;
                worksheet.Range[m, 7, m, 15].HorizontalAlignment = HorizontalAlignType.Center;
                worksheet.Range[m, 7, m, 15].VerticalAlignment = VerticalAlignType.Center;

                i++;
            }
            #endregion

        }
        catch (Exception ex)
        {
            //Myclass.filewrite(ex.StackTrace);
        }
    }

    private void ExcelDocViewer1(string fileName)
    {
        try
        {
            System.Diagnostics.Process.Start(fileName);
        }
        catch (Exception ex)
        {
            //Myclass.filewrite(ex.StackTrace);
        }

    }

    public void uploadTag()
    {

        filename = "";
        string id = "";
        if (Request.QueryString["id"] != null)
        {
            id = Request.QueryString["id"].ToString();
        }
        try
        {

            if (flapTagSave.HasFile)
            {
                filename = Path.GetFileName(flapTagSave.PostedFile.FileName);
                fileExtention = Path.GetExtension(flapTagSave.PostedFile.FileName);
                flapTagSave.PostedFile.SaveAs(Server.MapPath("../SaveUpload/" + filename));


                OleDbCommand excelCommand = new OleDbCommand();
                OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();
                if ((fileExtention == ".xlsx") || (fileExtention == ".XLSX"))
                {
                    excelConnStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath("../SaveUpload/" + filename) + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                }
                else
                {
                    excelConnStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath("../SaveUpload/" + filename) + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                }
                excelConn = new OleDbConnection(excelConnStr);
                excelConn.Close();
                excelConn.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();//Sheet1
                string sheetName = "Sheet1$";//
                string query = "SELECT  * From [" + sheetName + "] ";
                excelCommand = new OleDbCommand(query, excelConn);
                excelDataAdapter.SelectCommand = excelCommand;
                DbDataReader dr = excelCommand.ExecuteReader();

                dt.Load(dr);

                string CS = data.conString;
                SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);


                bulkInsert.DestinationTableName = "[dbo].[Sp_InsTagExcel]";
                bulkInsert.ColumnMappings.Add("ReferenceCode", "[ReferenceCode]");
                bulkInsert.ColumnMappings.Add("id_product", "[id_product]");
                bulkInsert.ColumnMappings.Add("tag1", "[tag1]");

                int res = SaveTag(dt);
                //bulkInsert.WriteToServer(dt);
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);


                excelConn.Close();
                if (res == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    string path = Server.MapPath("../SaveUpload/" + filename);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not  
                    {
                        file.Delete();
                    }
                }


            }

        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted UnSuccessful')", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.StackTrace.ToString() + "')", true);
            gdate.LogError(ex.Message.ToLower(), "Save Sheet", "Product", ex.StackTrace.ToString());
            string path = Server.MapPath("../SaveUpload/" + filename);
            FileInfo file = new FileInfo(path);
            if (file.Exists)//check file exsit or not  
            {
                file.Delete();
            }
        }

    }

    public int SaveTag(DataTable dtOrder)
    {

        int ss = 1;
        SqlCommand cmd = new SqlCommand();
        DataTable dtt = dtOrder;
        foreach (DataRow drExcel in dtt.Rows)
        {
            try
            {
                string tag = "0";
                for (int i = 1; i <= 30; i++)
                {
                    if (drExcel["Tag" + i].ToString() != null && drExcel["Tag" + i].ToString() != "")
                        tag += "," + drExcel["Tag" + i].ToString();
                }

                string t = tag;
                cmd.CommandText = "Sp_InsTagExcel";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                //cmd.parameters.addwithvalue("@referencecode", drexcel["referencecode"]);
                cmd.Parameters.AddWithValue("@id_product", drExcel["id_product"]);
                cmd.Parameters.AddWithValue("@tag1", tag);
                ss = data.executeCommandP(cmd);
            }
            catch (Exception ee)
            {
                gdate.LogError(ee.Message.ToLower(), "Save Sheet", "Product", ee.StackTrace.ToString());
            }
        }
        return ss;
    }

    protected void btnEnableHome_Click(object sender, EventArgs e)
    {
        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_product set IsHome = 1 where id_product=" + lblid.Text + "");
            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Disable Successfully......')", true);
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnDesableHome_Click(object sender, EventArgs e)
    {
        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_product set IsHome = 0 where id_product=" + lblid.Text + "");
            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Disable Successfully......')", true);
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnEnableStock_Click(object sender, EventArgs e)
    {
        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_product set StockForBarCode = 1 where id_product=" + lblid.Text + "");
            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Disable Successfully......')", true);
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnDesableStock_Click(object sender, EventArgs e)
    {
        Label lblid;
        for (int i = 0; i < rep.Items.Count; i++)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)rep.Items[i].FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)rep.Items[i].FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_product set StockForBarCode = 0 where id_product=" + lblid.Text + "");
            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Disable Successfully......')", true);
        if (Request.QueryString["PageNo"] != null)
            pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        else
            pageNo = 1;

        Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }
}


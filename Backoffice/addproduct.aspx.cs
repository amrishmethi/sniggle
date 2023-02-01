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

public partial class Backoffice_addproduct : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdata = new AdminGetData();
    DataTable dtlist = new DataTable();
    string query;
    SqlCommand cmd = new SqlCommand();
    // string smallUpload_dir = "G:/Project/Earthstone/myearthstoneNew/img/";
    // string siteurl = ConfigurationManager.AppSettings["siteurl"].ToString();
    string smallUpload_dir = ConfigurationManager.AppSettings["smallUpload_dir"].ToString();
    imgKit imgkt = new imgKit();
    public string FolderPath = ConfigurationManager.AppSettings["smallUpload_dir"].ToString();
    public string onlinePath = ConfigurationManager.AppSettings["smallUpload_dir"].ToString();
    string PageNo = "1";
    string PageSize = "50";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                // this.txtAvlDate = DateTime.Now.ToString();
                HttpContext.Current.Session["Cat"] = null;
                BindTag();
                FillParentCat();
                fillDropdown();
                fillTaxRule();
                fillImage();
                fillAttributeGroup();
                fillAttributeValue("");
                BindCountry();
                BindFeatureByProduct("");
                lblPName.Text = "Add New";
                txtDealFromTime.Text = DateTime.Now.ToString("h:mm:ss tt");
                txtDealToTime.Text = DateTime.Now.ToString("h:mm:ss tt");
                // btnGenerate.Visible = false;
                // ViewState["PID"] = "1748";
                //txtName.Text = System.Web.Hosting.HostingEnvironment.MapPath("~/img/hide.gif");
                //   Session["PName"] = "Sky Blue Topaz 16mm Round Cabochon - Color - Sky Blue , Quality - AA, Stone Name - Sky Blue Topaz, Shape - Round";
                if (Request.QueryString["id"] != null)
                {
                    ViewState["PID"] = Request.QueryString["id"].ToString();

                    //btnAddAtr.Text = "Update";
                    //btnAssociateSave.Text= "Update";
                    //btnAssociateSaveAnd.Text= "Update and Stay";
                    //btnCombSave.Text = "Update";
                    //btnCombSaveAnd.Text= "Update and Stay";
                    //btnFeatureSave.Text = "Update";
                    //btnFeatureSaveAnd.Text= "Update and Stay";

                }
                if (ViewState["PID"] != null)
                {
                    // Sp_GenerateProUrl

                    fillImage();
                    BindCombination();
                    BindQuantities();

                    hddid.Value = ViewState["PID"].ToString();
                    BindFeatureByProduct(ViewState["PID"].ToString());
                    FillSPecificPrice(ViewState["PID"].ToString());
                    FillPriority(ViewState["PID"].ToString());
                    // lblProductName.Text = Session["PName"].ToString();

                    FillDeatil();
                    BindVideo();
                    BindHot();
                }
            }
            else
            {
                //specific.Visible = true;
            }
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
    public void BindTag()
    {
        ds = data.getDataSet("select * from ps_tag  WITH (NOLOCK) where IsDeleted=0");
        drpTag.DataSource = ds;
        drpTag.DataValueField = "id_tag";
        drpTag.DataTextField = "name";
        drpTag.DataBind();
        //drpTag.Items.Insert(0, new ListItem("Select", "0"));
    }
    public void FillDeatil()
    {
        btnAdddTag.Visible = true;
        tag.Visible = true;
        string sq = "select ISNULL(a.SizeChartCatId, 0) as SizeChartCatId, REPLACE(REPLACE(b.link_rewrite,'(',''),')','') as link_rewrite,b.*,a.* , case when active='True' then 1 else 0 end as activeN  ";
        sq += " FROM ps_product a WITH (NOLOCK) inner JOIN ps_product_lang b WITH (NOLOCK) ON b.id_product = a.id_product AND b.id_lang = 1 AND b.id_shop = 1 ";
        sq += " where a.IsDeleted = 0 and b.IsDeletd = 0 and b.id_product='" + ViewState["PID"].ToString() + "'";
        ds = data.getDataSet(sq);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblPName.Text = "Edit : " + ds.Tables[0].Rows[0]["name"].ToString();
            txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
            txtGroupID.Text = ds.Tables[0].Rows[0]["GroupId"].ToString();
            drpColor.SelectedValue = ds.Tables[0].Rows[0]["ColorCode"].ToString();
            txtReferenceCode.Text = ds.Tables[0].Rows[0]["reference"].ToString();
            drpStatus.SelectedValue = ds.Tables[0].Rows[0]["activeN"].ToString();
            // txtJanbarcode.Text = ds.Tables[0].Rows[0][""].ToString();
            // txtUpcbarcode.Text = ds.Tables[0].Rows[0][""].ToString();
            if (ds.Tables[0].Rows[0]["redirect_type"].ToString() != "" || ds.Tables[0].Rows[0]["redirect_type"] != null)
            {
                drpDisable.SelectedValue = ds.Tables[0].Rows[0]["redirect_type"].ToString();
            }
            if (ds.Tables[0].Rows[0]["visibility"].ToString() != "" || ds.Tables[0].Rows[0]["visibility"] != null)
            {
                drpVisibility.SelectedValue = ds.Tables[0].Rows[0]["visibility"].ToString();
            }
            if (ds.Tables[0].Rows[0]["condition"].ToString() != "" || ds.Tables[0].Rows[0]["condition"] != null)
            {
                drpCondition.SelectedValue = ds.Tables[0].Rows[0]["condition"].ToString();
            }
            // txtShortDes.Text = ds.Tables[0].Rows[0]["description_short"].ToString();
            txtDes.Text = ds.Tables[0].Rows[0]["description"].ToString();
            txtTerms.Text = ds.Tables[0].Rows[0]["TermsCondition"].ToString();
            //Price
            txtProductPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
            txtRetailprice.Text = ds.Tables[0].Rows[0]["price"].ToString();
            txtWholesaleprice.Text = ds.Tables[0].Rows[0]["wholesale_price"].ToString();
            txtUnit.Text = ds.Tables[0].Rows[0]["unity"].ToString();
            txtUnitPrice.Text = ds.Tables[0].Rows[0]["unit_price_ratio"].ToString();
            unitPrice.InnerText = ds.Tables[0].Rows[0]["unit_price_ratio"].ToString();
            unit.InnerText = ds.Tables[0].Rows[0]["unity"].ToString();
            RPrice.InnerText = ds.Tables[0].Rows[0]["price"].ToString();
            chkOnSale.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["on_sale"].ToString());
            txtavailable_now.Text = ds.Tables[0].Rows[0]["available_now"].ToString();
            txtavailable_later.Text = ds.Tables[0].Rows[0]["available_later"].ToString();
            if (ds.Tables[0].Rows[0]["IsPersonalized"].ToString() == "True")
            {
                drpPersonalized.SelectedValue = "1";
            }
            else
            {
                drpPersonalized.SelectedValue = "0";
            }
            if (ds.Tables[0].Rows[0]["SizeChartCatId"].ToString() != "" || ds.Tables[0].Rows[0]["SizeChartCatId"] != null)
            {
                drpSizeChart.SelectedValue = ds.Tables[0].Rows[0]["SizeChartCatId"].ToString();
            }



            //if(ds.Tables[0].Rows[0]["id_tax_rules_group"].ToString() !="" || ds.Tables[0].Rows[0]["id_tax_rules_group"] !=null)
            //{
            //    drpTaxrule.SelectedValue = ds.Tables[0].Rows[0]["id_tax_rules_group"].ToString();
            //}

            // ViewState["PID"] = ds.Tables[0].Rows[0]["id_product"].ToString();

            //Default Category
            string sqCat = "select *,L.NAME from ps_category_product as p WITH (NOLOCK) inner join ps_category_lang as l WITH (NOLOCK) ON P.id_category=L.id_category ";
            sqCat += " where P.IsDeleted=0 and id_lang=1 and P.id_product='" + ViewState["PID"].ToString() + "'";
            DataSet dsC = data.getDataSet(sqCat);
            if (dsC.Tables[0].Rows.Count > 0)
            {
                drpDefaultCat.Items.Clear();
            }
            DataTable dt = new DataTable();
            for (int i = 0; i < dsC.Tables[0].Rows.Count; i++)
            {
                if (dsC.Tables[0].Rows[i]["id_category"].ToString() == "2" || ds.Tables[0].Rows[0]["id_category_default"].ToString() == "2")
                {
                    hddHome.Value = "Active";
                }
                drpDefaultCat.Items.Add(new ListItem(dsC.Tables[0].Rows[i]["name"].ToString(), dsC.Tables[0].Rows[i]["id_category"].ToString()));
                if (HttpContext.Current.Session["Cat"] == null)
                {
                    dt.Columns.Add(new DataColumn("ID", typeof(string)));
                    dt.Columns.Add(new DataColumn("CatName", typeof(string)));
                    HttpContext.Current.Session["Cat"] = dt;
                }
                if (HttpContext.Current.Session["Cat"] != null)
                {
                    DataTable dtt = (DataTable)HttpContext.Current.Session["Cat"];
                    DataRow[] foundAuthors = dtt.Select("ID = '" + dsC.Tables[0].Rows[i]["id_category"].ToString() + "'");
                    if (foundAuthors.Length == 0)
                    {
                        DataRow dr = dtt.NewRow();
                        dr.SetField("ID", dsC.Tables[0].Rows[i]["id_category"].ToString());
                        dr.SetField("CatName", dsC.Tables[0].Rows[i]["name"].ToString());
                        dtt.Rows.Add(dr);
                        HttpContext.Current.Session["Cat"] = dtt;

                    }
                }
            }
            if (dsC.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id_category_default"] != null)
                {
                    drpDefaultCat.SelectedValue = ds.Tables[0].Rows[0]["id_category_default"].ToString();
                }
            }

            //SEO

            txtMetatitle.Text = ds.Tables[0].Rows[0]["meta_title"].ToString();
            txtMetadescription.Text = ds.Tables[0].Rows[0]["meta_description"].ToString();
            string sqq = "Sp_GenerateProUrl '" + ds.Tables[0].Rows[0]["id_product"].ToString() + "'";
            DataSet dsUrl = data.getDataSet(sqq);
            if (ds.Tables[0].Rows[0]["link_rewrite"].ToString() != "")
            {
                txtUrl.Text = ds.Tables[0].Rows[0]["link_rewrite"].ToString().ToLower();
                lblUrl.Text = dsUrl.Tables[0].Rows[0]["Url3"].ToString().ToLower();
            }
            else
            {
                txtUrl.Text = dsUrl.Tables[0].Rows[0][1].ToString().ToLower();
                lblUrl.Text = dsUrl.Tables[0].Rows[0][0].ToString().ToLower();
            }

            ancpreview.HRef = dsUrl.Tables[0].Rows[0][0].ToString();
            //Shiping
            txtPackegW.Text = ds.Tables[0].Rows[0]["width"].ToString();
            txtPackageH.Text = ds.Tables[0].Rows[0]["height"].ToString();
            txtPackagD.Text = ds.Tables[0].Rows[0]["depth"].ToString();
            txtPackageweight.Text = ds.Tables[0].Rows[0]["weight"].ToString();
            txtAddFee.Text = ds.Tables[0].Rows[0]["additional_shipping_cost"].ToString();
            //string Asso= "select id_category,id_product,position from ps_category_product where IsDeleted=0 id_product='" + ViewState["PID"].ToString() + "'";
            // DataSet dsAss = data.getDataSet(Asso);
            //            if(dsAss.Tables[0].Rows.Count>0)
            //            {
            ////for
            //            }

            txtCaption.Text = ds.Tables[0].Rows[0]["name"].ToString();
            //Bind Tag
            //string sTag = "Sp_GetTagInOneLine '" + ViewState["PID"].ToString() + "'";
            //DataSet dsTag = data.getDataSet(sTag);
            //if (dsTag.Tables[0].Rows.Count > 0)
            //{
            //    txtTag.Value = dsTag.Tables[0].Rows[0][0].ToString();
            //}
            DataSet newds = data.getDataSet("select id_tag from ps_product_tag WITH (NOLOCK) where IsDeleted=0 and id_product='" + ViewState["PID"].ToString() + "'");
            foreach (ListItem item in drpTag.Items)
            {
                string ss = item.Value.ToString();
                for (int i = 0; i < newds.Tables[0].Rows.Count; i++)
                {
                    string ssss = newds.Tables[0].Rows[i]["id_tag"].ToString();
                    if (ss == ssss)
                    {
                        item.Selected = true;
                    }
                }
            }

            //string sTagId = "Sp_GetTagIDInOneLine '" + ViewState["PID"].ToString() + "'";
            //DataSet dsTagId = data.getDataSet(sTagId);
            // hddTag.Value = dsTagId.Tables[0].Rows[0][0].ToString();

            //litTag.Text = " <script src='../plugins/jQuery/jQuery-2.1.4.min.js'></script><script type='text/javascript' language='javascript'>$(document).ready(function () {  var $exampleMulti = $('#ctl00_ContentPlaceHolder1_drpCenter').select2();$exampleMulti.val($('#ctl00_ContentPlaceHolder1_hddAllotedCenter').val().split(',')).trigger('change');});</script>";
        }
    }
    public void FillParentCat()
    {
        ds = gdata.GetCategory("", "", "", "", "");
        repCat.DataSource = ds;
        repCat.DataBind();
    }

    private DataTable FillChildTable()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dtnew = new DataTable();
        ds = gdata.GetSubCategory("");
        dt = ds.Tables[0];
        dtnew = dt.Copy();

        return dtnew;
    }




    public void fillDropdown()
    {
        // Category

        //  ds = gdata.GetCategory("", "", "", "", "");

        //drpCategory.DataSource = ds;
        //drpCategory.DataTextField = "name";
        //drpCategory.DataValueField = "id_category";
        //drpCategory.DataBind();
        //drpCategory.Items.Insert(0, "Parent Category");


        ds = data.getDataSet("select name,color from ps_attribute as a inner join ps_attribute_lang as b on a.id_attribute = b.id_attribute and b.id_lang = 1 where a.id_attribute_group = 12");

        drpColor.DataSource = ds;
        drpColor.DataTextField = "name";
        drpColor.DataValueField = "color";
        drpColor.DataBind();
        drpColor.Items.Insert(0, new ListItem("Select Color", ""));

        ds = data.getDataSet("select Name,id_category from ps_category_lang as l inner join tbl_SizeChart as S on S.CategoryId=l.id_category where L.isdeleted=0 and S.isdeleted=0");

        drpSizeChart.DataSource = ds;
        drpSizeChart.DataTextField = "Name";
        drpSizeChart.DataValueField = "id_category";
        drpSizeChart.DataBind();
        drpSizeChart.Items.Insert(0, new ListItem("Size Chart Category", "0"));



    }
    public void fillTaxRule()
    {
        // Category

        ds = gdata.GetTaxRul();
        drpTaxrule.DataSource = ds;
        drpTaxrule.DataTextField = "name";
        drpTaxrule.DataValueField = "id_tax";
        drpTaxrule.DataBind();
        drpTaxrule.Items.Insert(0, new ListItem("No Tax", "0"));
    }
    public void fillAttributeGroup()
    {
        ds = gdata.GetAttributeGroup();
        drpAttribute.DataSource = ds;
        drpAttribute.DataTextField = "name";
        drpAttribute.DataValueField = "id_attribute_group";
        drpAttribute.DataBind();
        drpAttribute.Items.Insert(0, "Select");
    }
    public void fillAttributeValue(string id)
    {
        DataSet dsV = gdata.GetAttributeValue(id);
        drpValue.DataSource = dsV;
        drpValue.DataTextField = "name";
        drpValue.DataValueField = "id_attribute";
        drpValue.DataBind();
        drpValue.Items.Insert(0, "---");
    }
    #region Information
    protected void btnSave_Click(object sender, EventArgs e)
    {

        ViewState["ff"] = "S";
        InfoSave();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    protected void btnInfoSaveAnd_Click(object sender, EventArgs e)
    {
        ViewState["ff"] = "F";
        InfoSave();
    }

    public void InfoSave()
    {

        Session["tab"] = hddTab.Value;
        string Action; string id_product = "0";
        if (ViewState["PID"] != null)
        {
            Action = "Update";
            id_product = ViewState["PID"].ToString();
        }
        else if (Request.QueryString["id"] != null)
        {
            Action = "Update";
            id_product = Request.QueryString["id"].ToString();
        }
        else
        {
            Action = "AddInformation";
            id_product = "0";
        }
        string name = txtName.Text.TrimStart().TrimEnd(); string Reference_code = txtReferenceCode.Text; string JAN_barcode = txtJanbarcode.Text;
        string UPC_barcode = txtUpcbarcode.Text; string one = Request.Form["one"]; string Enabled = drpStatus.SelectedValue; string Redirect = drpDisable.SelectedValue;
        string Visibility = drpVisibility.SelectedValue; string Options = "true"; string Condition = drpCondition.SelectedValue;
        string Short_description = txtDes.Text; string Description = txtDes.Text; string Tags = ""; string online_only; string GroupId = txtGroupID.Text;
        string ColorCode = drpColor.SelectedValue;
        string TermsCondition = txtTerms.Text;
        if (chkOnline.Checked == true)
            online_only = "true";
        else
            online_only = "false";

        if (txtReferenceCode.Text != "")
        {
            DataSet ds33 = gdata.AddProduct(Action, "0", online_only, "0", "0", "0", "", "0", Reference_code, "0", "0", "0", "0", "2", Enabled, Redirect, "1", Condition, "true", "1", Visibility, "0", "0", Description, Short_description, "", "", Tags, "", name, id_product, GroupId, ColorCode, TermsCondition);
            //string ss = txtTag.Value;
            if (ds33.Tables[0].Rows.Count > 0)
            {
                if (ds33.Tables[0].Rows[0][0].ToString() != "")
                {
                    gdata.AddStockNew(ds33.Tables[0].Rows[0][0].ToString(), "0", "0", "2");

                    //data.executeCommand("delete from ps_product_tag where id_product='" + ds33.Tables[0].Rows[0][0].ToString() + "'");
                    //data.executeCommand("delete from ps_tag where id_tag in (select id_tag from ps_product_tag where id_product='" + ds33.Tables[0].Rows[0][0].ToString() + "')");

                    //data.executeCommand("update ps_product_tag set IsDeleted=1 where id_product='" + ds33.Tables[0].Rows[0][0].ToString() + "'");
                    // data.executeCommand("update from ps_tag set IsDeleted=1 where id_tag in (select id_tag from ps_product_tag where id_product='" + ds33.Tables[0].Rows[0][0].ToString() + "')");
                    ViewState["PID"] = ds33.Tables[0].Rows[0][0].ToString();
                    hddid.Value = ds33.Tables[0].Rows[0][0].ToString();
                    //string ss = txtTag.Value;
                    //string[] authorsList = ss.Split(',');
                    //foreach (string author in authorsList)
                    //{
                    //    DataSet ds2 = gdata.AddTag(ds33.Tables[0].Rows[0][0].ToString(), author);
                    //}
                    hideDiv.Visible = true;
                    if (ViewState["ff"].ToString() == "F")
                    {
                        Response.Redirect("addproduct.aspx?id=" + ds33.Tables[0].Rows[0][0].ToString() + "");
                        FillDeatil();
                    }
                    else
                    {
                        if (Request.QueryString["PageNo"] != null)
                            PageNo = Request.QueryString["PageNo"].ToString();
                        if (Request.QueryString["PageSize"] != null)
                            PageSize = Request.QueryString["PageSize"].ToString();
                        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
                    }
                }
            }
        }
    }

    protected void btnAdddTag_Click(object sender, EventArgs e)
    {
        if (ViewState["PID"] != null)
        {
            string id_product = ViewState["PID"].ToString();
            if (id_product != "")
            {
                //data.executeCommand("delete from ps_product_tag where id_product='" + id_product + "'");
                //data.executeCommand("delete from ps_tag where id_tag in (select id_tag from ps_product_tag where id_product='" + id_product + "')");

                //data.executeCommand("update ps_product_tag set IsDeleted=1,DeleteDate=getdate(),DeletedFrom='addproduct' where id_product='" + id_product + "'");
                //  data.executeCommand("Update ps_tag set set IsDeleted=1,DeleteDate=getdate(),DeletedFrom='addproduct' where id_tag in (select id_tag from ps_product_tag where id_product='" + id_product + "')");

                //string ss = txtTag.Value;
                //string[] authorsList = ss.Split(',');
                //foreach (string author in authorsList)
                //{
                //    DataSet ds2 = gdata.AddTag(id_product, author);
                //}
                foreach (ListItem item in drpTag.Items)
                {
                    if (item.Selected)
                    {
                        gdata.AddProductTag(id_product, item.Value.ToString());
                    }

                }
            }
        }
    }
    #endregion
    #region Price
    public void BindCountry()
    {
        query = " select * from ps_country_lang where id_lang = 1 ";
        ds = data.getDataSet(query);
        drpCountry.DataSource = ds;
        drpCountry.DataTextField = "name";
        drpCountry.DataValueField = "id_country";
        drpCountry.DataBind();
        drpCountry.Items.Insert(0, new ListItem("All countries", "0"));

        query = " select id_customer,firstname+' '+lastname as name from ps_customer where deleted=0";
        ds = data.getDataSet(query);

        DrpCustomer.DataSource = ds;
        DrpCustomer.DataTextField = "name";
        DrpCustomer.DataValueField = "id_customer";
        DrpCustomer.DataBind();
        DrpCustomer.Items.Insert(0, new ListItem("All customers", "0"));
    }
    protected void btnPriceSaveAnd_Click(object sender, EventArgs e)
    {
        UpdatePrice();
    }

    protected void btnPriceSave_Click(object sender, EventArgs e)
    {
        UpdatePrice();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    public void UpdatePrice()
    {
        Session["tab"] = hddTab.Value;
        string price = txtRetailprice.Text; string wholesale_price = txtRetailprice.Text; string unity = txtUnit.Text;
        string unit_price_ratio = txtUnitPrice.Text; Boolean on_sale = Convert.ToBoolean(chkOnSale.Checked);
        string id_tax_rules_group = drpTaxrule.SelectedValue; string id_product = ViewState["PID"].ToString();
        if (id_product != "")
        {
            DataSet dsPrice = gdata.AddPrice(price, wholesale_price, unity, unit_price_ratio, on_sale, id_tax_rules_group, id_product);
        }
        hideDiv.Visible = true;
        FillDeatil();
    }

    protected void btnSpecificSaveAnd_Click(object sender, EventArgs e)
    {
        UpdateSpecificPrice();

    }

    protected void btnSpecificSave_Click(object sender, EventArgs e)
    {
        UpdateSpecificPrice();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    double p = 0; double d = 0; double tp = 0;
    public void UpdateSpecificPrice()
    {
        Session["tab"] = hddTab.Value;
        string Action = "Add"; string id_currency = drpCurrency.SelectedValue; string id_country = drpCountry.SelectedValue;
        string id_group = DrpGroup.SelectedValue; string id_customer = DrpCustomer.SelectedValue;
        string id_product_attribute = drpCombination.SelectedValue; string price = txtProductPrice.Text;
        string from_quantity = txtStarunit.Text; string reduction = txtDescount.Text;
        string reduction_tax = "1"; string reduction_type = drpDisType.SelectedValue;
        string from = txtFDate.Text; string to = txtTo.Text;
        if (reduction_type == "Dollar")
        {
            if (txtRetailprice.Text != "")
                p = Convert.ToDouble(txtRetailprice.Text);
            if (txtDescount.Text != "")
                d = Convert.ToDouble(txtDescount.Text);
            tp = (p - d);
            price = tp.ToString();
        }
        else
        {
            if (txtRetailprice.Text != "")
                p = Convert.ToDouble(txtRetailprice.Text);
            if (txtDescount.Text != "")
                d = Convert.ToDouble(txtDescount.Text);
            tp = (p - (p * d / 100));
            price = tp.ToString();
        }

        string id_tax_rules_group = drpTaxrule.SelectedValue; string id_product = ViewState["PID"].ToString();
        if (id_product != "")
        {
            int dsPrice = gdata.AddSpecificPrice(Action, id_product, id_currency, id_country, id_group, id_customer, id_product_attribute, price, from_quantity, reduction,
reduction_tax, reduction_type, from, to);
            Session["tab"] = "Prices";
            FillSPecificPrice(id_product);
            drpCurrency.SelectedIndex = drpCountry.SelectedIndex = DrpGroup.SelectedIndex = DrpCustomer.SelectedIndex = drpCombination.SelectedIndex = drpDisType.SelectedIndex = drpTaxrule.SelectedIndex = 0;
            txtStarunit.Text = "1";
            txtFDate.Text = txtTo.Text = "";
            txtDescount.Text = "0";
        }

        hideDiv.Visible = true;
        FillDeatil();
    }
    public void FillSPecificPrice(string id)
    {
        DataSet dsSP = gdata.GetSpecificPrice(id);
        rptSpecificPrice.DataSource = dsSP;
        rptSpecificPrice.DataBind();
        if (dsSP.Tables[0].Rows.Count > 0)
        {
            trNoData.Visible = false;
        }
        else
        {
            trNoData.Visible = true;
        }
    }

    protected void rptSpecificPrice_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "Delete")
        //{
        //    string qqq = " update ps_specific_price set IsDeleted = 1 where id_specific_price = '" + e.CommandArgument + "'";
        //    if (data.executeCommand(qqq) == 0)
        //    {
        //        FillSPecificPrice(ViewState["PID"].ToString());
        //    }
        //}
        if (e.CommandName == "Delete")
        {
            string qqq = " delete from  ps_specific_price  where id_specific_price = '" + e.CommandArgument + "'";
            if (data.executeCommand(qqq) == 0)
            {
                FillSPecificPrice(ViewState["PID"].ToString());
            }
        }
    }
    #endregion
    #region SEO
    protected void btnSEOSaveAnd_Click(object sender, EventArgs e)
    {
        UpdateSEO();
    }

    protected void btnSEOSave_Click(object sender, EventArgs e)
    {
        UpdateSEO();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    public void UpdateSEO()
    {
        Session["tab"] = hddTab.Value;
        string link_rewrite = txtUrl.Text; string meta_description = txtMetadescription.Text; string meta_title = txtMetatitle.Text;
        string id_product = "";
        if (ViewState["PID"] != null)
        {
            id_product = ViewState["PID"].ToString();
        }
        if (id_product != "")
        {
            DataSet dsPrice = gdata.AddSEO(link_rewrite, meta_description, meta_title, id_product);
        }
        hideDiv.Visible = true;
        FillDeatil();
    }
    #endregion
    #region Shipping
    protected void btnSpSaveAnd_Click(object sender, EventArgs e)
    {
        UpdateShipping();
    }

    protected void btnSpSave_Click(object sender, EventArgs e)
    {
        UpdateShipping();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    public void UpdateShipping()
    {
        Session["tab"] = hddTab.Value;
        string width = txtPackegW.Text; string height = txtPackageH.Text; string depth = txtPackagD.Text;
        string weight = txtPackageweight.Text; string additional_shipping_cost = txtAddFee.Text;
        string id_product = "";
        if (ViewState["PID"] != null)
        {
            id_product = ViewState["PID"].ToString();
        }
        if (id_product != "")
        {
            DataSet dsPrice = gdata.AddShipping(width, height, depth, weight, additional_shipping_cost, id_product);
        }
        FillDeatil();
    }
    #endregion
    #region Image
    public void fillImage()
    {
        string id_product = "";
        if (ViewState["PID"] != null)
        {
            id_product = ViewState["PID"].ToString();
        }
        if (id_product != "")
        {
            ds = gdata.GetImageOfProduct(id_product);
            // repImage.DataSource = ds;
            //repImage.DataBind();
            ItemsListView.DataSource = ds;
            ItemsListView.DataBind();

            repCombImage.DataSource = ds;
            repCombImage.DataBind();

            drpPosition.DataSource = ds;
            drpPosition.DataTextField = "positionN";
            drpPosition.DataValueField = "position";
            drpPosition.DataBind();
            drpPosition.Items.Insert(0, "All captions");

        }
    }
    public static IEnumerable<Item> FindItems(string id_product)
    {
        Collection<Item> items = new Collection<Item>();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(constr))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "Sp_GetImageOfProduct";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_product", id_product);
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    Item item;
                    while (dataReader.Read())
                    {
                        item = new Item();
                        item.id_image = Convert.ToInt32(dataReader["id_image"]);
                        item.ImageUrl = Convert.ToString(dataReader["ImageUrl"]);
                        item.legend = Convert.ToString(dataReader["legend"]);
                        item.position = Convert.ToInt32(dataReader["position"]);
                        item.cover = Convert.ToString(dataReader["cover"]);
                        items.Add(item);
                    }
                }
            }
        }
        return items;
    }
    protected void repImage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void ItemsListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        //if (e.CommandName == "Delete")
        //{
        //    Data data = new Data();
        //    string query = " update ps_image set IsDeleted = 1 where id_image=" + e.CommandArgument + "";
        //    data.executeCommand(query);
        //    fillImage();
        //    Session["tab"] = "Images";
        //}
        if (e.CommandName == "Cov")
        {
            Data data = new Data();
            if (ViewState["PID"] != null)
            {
                data.executeCommand(" update ps_image set cover = 0  where id_product='" + ViewState["PID"].ToString() + "'");
            }

            string query = " update ps_image set cover = (case when cover=1 then 0 else 1 end)  where id_image=" + e.CommandArgument + "";
            data.executeCommand(query);

            fillImage();
            Session["tab"] = "Images";
        }
    }
    protected void ItemsListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        ListViewItem item = ItemsListView.Items[e.ItemIndex];
        Label id = (Label)item.FindControl("lblId");
        Data data = new Data();
        string query = "update ps_image set IsDeleted = 1 where id_image=" + id.Text + "";
        data.executeCommand(query);
        fillImage();
        Session["tab"] = "Images";
    }
    protected void btnCaptionUpdate_Click(object sender, EventArgs e)
    {
        string id_product = "";
        if (ViewState["PID"] != null)
        {
            id_product = ViewState["PID"].ToString();
        }

        //if (id_product != "")
        //{
        //    string sqq = "update ps_image_lang set legend='" + txtCaption.Text + "' where id_image in(select id_image from ps_image where id_product='" + id_product + " and position='" + drpPosition.SelectedValue + "'')";
        //    data.executeCommand(sqq);
        //}
        if (drpPosition.SelectedIndex > 0)
        {
            string sqq = "update ps_image_lang set legend='" + txtCaption.Text + "' where id_image in(select id_image from ps_image where id_product='" + id_product + "' and position='" + drpPosition.SelectedValue + "')";
            data.executeCommand(sqq);
        }
        else
        {
            string sqq1 = "update ps_image_lang set legend='" + txtCaption.Text + "' where id_image in(select id_image from ps_image where id_product='" + id_product + " ')";
            data.executeCommand(sqq1);
        }

        Session["tab"] = "Images";
        Response.Redirect("addproduct.aspx?id=" + id_product + "#Images");
        //fillImage();
        //FillDeatil();
    }
    protected void btnAddFile_Click(object sender, EventArgs e)
    {
        Session["tab"] = hddTab.Value;
        string id_product = "";
        if (ViewState["PID"] != null)
        {
            id_product = ViewState["PID"].ToString();
        }

        if (id_product != "")
        {
            if (flpCover.HasFile)
            {
                string sq = "select distinct top(1) replace(cat.name,'/','-') as name from ps_product prod inner join ps_category_lang cat on prod.id_category_default = cat.id_category";
                sq += " where cat.id_lang = 1 and prod.id_product = " + id_product + "";
                DataSet dsCat = data.getDataSet(sq);
                if (dsCat.Tables[0].Rows.Count > 0)
                {
                    HttpFileCollection hfc = Request.Files;

                    for (int i = 1; i < Request.Files.Count - 1; i++)
                    {
                        HttpPostedFile postedFile = Request.Files[i];
                        //if (postedFile.ContentLength > 0)
                        //{
                        //string fileName = System.IO.Path.GetFileName(postedFile.FileName);
                        //postedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                        DataSet dsImg = gdata.AddImage(txtCaption.Text, i.ToString(), id_product);
                        if (dsImg.Tables[0].Rows.Count > 0)
                        {
                            ResizeImages(dsImg.Tables[0].Rows[0][0].ToString(), flpCover, dsCat.Tables[0].Rows[0]["name"].ToString(), i - 1);
                            ResizeThumbImages(dsImg.Tables[0].Rows[0][0].ToString(), flpCover, dsCat.Tables[0].Rows[0]["name"].ToString(), i - 1);
                        }
                        //}
                    }
                    //for (int i = 1; i < hfc.Count - 1; i++)
                    //{
                    //    HttpPostedFile hpf = hfc[i];
                    //    DataSet dsImg = gdata.AddImage(txtCaption.Text, i.ToString(), id_product);
                    //    if (dsImg.Tables[0].Rows.Count > 0)
                    //    {
                    //        ResizeImages(dsImg.Tables[0].Rows[0][0].ToString(), flpCover, dsCat.Tables[0].Rows[0]["name"].ToString(), i - 1);
                    //        ResizeThumbImages(dsImg.Tables[0].Rows[0][0].ToString(), flpCover, dsCat.Tables[0].Rows[0]["name"].ToString(), i - 1);
                    //    }

                    //}
                    flpCover.Dispose();
                }
            }
            else
            {
                if (txtImageLink.Text != "")
                {
                    gdata.AddImageLink(txtCaption.Text, id_product, txtImageLink.Text);
                }

            }
        }
        Session["tab"] = "Images";
        fillImage();
        FillDeatil();
    }
    public void ResizeThumbImages(string Filename, FileUpload FlpDownload, string folderName, int ii)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        string dir = smallUpload_dir + folderName + "/";

        int maxHeight = 0;
        int maxWidth = 0;
        // Resize Image Before Uploading to DataBase
        System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FlpDownload.PostedFiles[ii].InputStream);
        int imageHeight = imageToBeResized.Height;
        int imageWidth = imageToBeResized.Width;
        string fname = Filename;
        string sq = "select name,width,height from [ps_image_type] where products=1";
        DataSet dsimg = data.getDataSet(sq);
        for (int i = 0; i < dsimg.Tables[0].Rows.Count; i++)
        {
            maxHeight = Convert.ToInt32(dsimg.Tables[0].Rows[i]["height"]);
            maxWidth = Convert.ToInt32(dsimg.Tables[0].Rows[i]["width"]);
            Filename = fname + "-" + dsimg.Tables[0].Rows[i]["name"] + ".jpg";
            imageHeight = maxHeight;
            imageWidth = maxWidth;
            //  System.IO.MemoryStream stream = new System.IO.MemoryStream(FlpDownload.FileBytes);
            Bitmap source = new Bitmap(FlpDownload.PostedFiles[ii].InputStream);

            Bitmap target = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(target);

            EncoderParameters e;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.InterpolationMode = InterpolationMode.Low;

            Rectangle recCompression = new Rectangle(0, 0, imageWidth, imageHeight);
            g.DrawImage(source, recCompression);

            e = new EncoderParameters(2);
            e.Param[0] = new EncoderParameter(Encoder.Quality, 70);
            e.Param[1] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionLZW);
            if (Directory.Exists(@dir))
                target.Save(dir + Filename, ImageFormat.Jpeg);
            else
            {
                Directory.CreateDirectory(@dir);
                if (Directory.Exists(@dir))
                    target.Save(dir + Filename, ImageFormat.Jpeg);
            }
            DataSet dsF = data.getDataSet(" select [dbo].[fn_RmSpecialChar]('" + folderName + "')");
            string FName = dsF.Tables[0].Rows[0][0].ToString();
            string imgFullPath = onlinePath + folderName + "/" + Filename;
            imgkt.uploadImgKit(Filename, FName, imgFullPath);
            g.Dispose();
        }
    }
    public void ResizeImages(string Filename, FileUpload FlpDownload, string folderName, int ii)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        string dir = smallUpload_dir + folderName + "/";
        int maxHeight = 0;
        int maxWidth = 0;
        // Resize Image Before Uploading to DataBase
        System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FlpDownload.PostedFiles[ii].InputStream);
        int imageHeight = imageToBeResized.Height;
        int imageWidth = imageToBeResized.Width;

        Filename = Filename + ".jpg";
        maxHeight = 600;
        maxWidth = 600;
        imageHeight = maxHeight;
        imageWidth = maxWidth;
        // System.IO.MemoryStream stream = new System.IO.MemoryStream();
        Bitmap source = new Bitmap(FlpDownload.PostedFiles[ii].InputStream);

        Bitmap target = new Bitmap(imageWidth, imageHeight);
        Graphics g = Graphics.FromImage(target);

        EncoderParameters e;
        g.CompositingQuality = CompositingQuality.HighSpeed;
        g.InterpolationMode = InterpolationMode.Low;

        Rectangle recCompression = new Rectangle(0, 0, imageWidth, imageHeight);
        g.DrawImage(source, recCompression);

        e = new EncoderParameters(2);
        e.Param[0] = new EncoderParameter(Encoder.Quality, 70);
        e.Param[1] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionLZW);

        if (Directory.Exists(@dir))
            target.Save(dir + Filename, ImageFormat.Jpeg);
        else
        {
            Directory.CreateDirectory(@dir);
            if (Directory.Exists(@dir))
                target.Save(dir + Filename, ImageFormat.Jpeg);
        }
        DataSet dsF = data.getDataSet(" select [dbo].[fn_RmSpecialChar]('" + folderName + "')");
        string FName = dsF.Tables[0].Rows[0][0].ToString();
        string imgFullPath = onlinePath + folderName + "/" + Filename;
        imgkt.uploadImgKit(Filename, FName, imgFullPath);
        g.Dispose();

    }
    #endregion
    #region COMBINATIONS 
    public void BindCombination()
    {
        if (ViewState["PID"] != null)
        {
            string id_product = ViewState["PID"].ToString();
            ds = data.getDataSet("Sp_GetProductCombination " + id_product);
            repComb.DataSource = ds;
            repComb.DataBind();

            drpCombination.DataSource = ds;
            drpCombination.DataTextField = "pair";
            drpCombination.DataValueField = "id_product_attribute";
            drpCombination.DataBind();
            drpCombination.Items.Insert(0, new ListItem("Apply to all combinations", "0"));
        }

    }
    protected void drpAttribute_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillAttributeValue(drpAttribute.SelectedValue);
    }

    protected void btnAddAtr_Click(object sender, EventArgs e)
    {

        DataTable dtt = new DataTable();
        string id = drpAttribute.SelectedValue;
        string valId = drpValue.SelectedValue;
        string name = drpAttribute.SelectedItem.Text + " : " + drpValue.SelectedItem.Text;
        DataTable dt = new DataTable();
        if (ViewState["CombTbl"] == null)
        {
            dt.Clear();
            //dt.Columns.Add("Name");
            //dt.Columns.Add("ValueID");
            //dt.Columns.Add("ID");

            dt.Columns.Add("CombId");
            dt.Columns.Add("CombValue");
            dt.Columns.Add("AttId");
            ViewState["CombTbl"] = dt;
        }
        if (ViewState["CombTbl"] != null)
        {
            dtt = (DataTable)ViewState["CombTbl"];
            DataRow[] foundAuthors = dtt.Select("CombId = '" + valId + "'");
            if (foundAuthors.Length == 0)
            {
                DataRow dr = dtt.NewRow();
                dr.SetField("CombId", valId);
                dr.SetField("CombValue", name);
                dr.SetField("AttId", id);
                dtt.Rows.Add(dr);
                ViewState["CombTbl"] = dtt;
            }
            else
                RMG.Functions.MsgBox("You can only add one combination per attribute type.");
        }
        listValue.DataSource = dtt;
        listValue.DataTextField = "CombValue";
        listValue.DataValueField = "CombId";

        listValue.DataBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (ViewState["CombTbl"] != null)
        {
            DataTable dt = (DataTable)ViewState["CombTbl"];
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];
                if (dr["CombId"].ToString() == listValue.SelectedValue.ToString())
                    dr.Delete();
            }
            dt.AcceptChanges();
            listValue.DataSource = dt;
            //listValue.DataTextField = "Name";
            //listValue.DataValueField = "ID"; 
            listValue.DataValueField = "CombId";
            listValue.DataTextField = "CombValue";
            listValue.DataBind();

            ViewState["CombTbl"] = dt;
        }
    }

    protected void btnCombSave_Click(object sender, EventArgs e)
    {
        if (lblCombinationId.Text != "")
        {
            if (chkDefaultComb.Checked)
            {
                string cc = "update ps_product set cache_default_attribute =  '" + lblCombinationId.Text + "',minimal_quantity='" + txtMinumamQty.Text + "' where id_product = '" + Request.QueryString["id"].ToString() + "'";
                data.executeCommand(cc);
            }
            UpdateCombination();
        }
        else
        {
            SaveCombination();
        }
        lblCombinationId.Text = "";
        BindCombination();
        BindQuantities();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
    }
    double imp = 0; double imw = 0;
    public void SaveCombination()
    {

        Session["tab"] = hddTab.Value;
        string id_product;
        string ReferenceCode = txtRefCode.Text; string wholesale_price = txtWholesaleprice.Text;
        string Impacprice = txtImpactPrice.Text; string ImpactOrPrice = txtImpactOrPrice.Text;
        string Impweight = txtImpactW.Text; string ImpUnitunit = txtImpactUnitP.Text; string MinQty = txtMinumamQty.Text;
        string AvaiDate = txtAvlDate.Text; string Default = (Convert.ToBoolean(chkDefaultComb.Checked)).ToString();
        if (drpImpactPrice.SelectedItem.Text == "Decrease")
        {
            if (txtImpactPrice.Text != "")
            {
                imp = Convert.ToDouble(txtImpactPrice.Text);
            }
            Impacprice = (imp * (-1)).ToString();
            ImpactOrPrice = (imp * (-1)).ToString();
            ImpUnitunit = (imp * (-1)).ToString();
        }
        else
        {
            Impacprice = txtImpactPrice.Text;
            ImpactOrPrice = txtImpactPrice.Text;
            ImpUnitunit = txtImpactPrice.Text;
        }
        if (drpImpactWeight.SelectedItem.Text == "Decrease")
        {
            if (txtImpactW.Text != "")
            {
                imw = Convert.ToDouble(txtImpactW.Text);
            }
            Impweight = (imw * (-1)).ToString();

        }
        else
        {
            Impweight = txtImpactW.Text;

        }
        string attr = "";
        DataTable dt = new DataTable();
        if (ViewState["CombTbl"] != null)
        {
            dt = (DataTable)ViewState["CombTbl"];
            //DataView dv = dt.DefaultView;
            //dv.Sort = "AttId asc";
            //DataTable sortedDT = dv.ToTable();

            DataTable dtMarks1 = dt.Clone();
            dtMarks1.Columns["AttId"].DataType = Type.GetType("System.Int32");

            foreach (DataRow dr in dt.Rows)
            {
                dtMarks1.ImportRow(dr);
            }
            dtMarks1.AcceptChanges();


            DataView dv1 = dtMarks1.DefaultView;
            dv1.Sort = "AttId asc";
            DataTable sortedDT = dv1.ToTable();

            DataTable dtValue = dt.Clone();
            dtValue.Columns["CombId"].DataType = Type.GetType("System.Int32");

            foreach (DataRow dr in dt.Rows)
            {
                dtValue.ImportRow(dr);
            }
            dtValue.AcceptChanges();
            id_product = ViewState["PID"].ToString();

            DataView dval = dtMarks1.DefaultView;
            dval.Sort = "CombId asc";
            DataTable sortedDTVal = dval.ToTable();

            cmd = new SqlCommand("Insert_CombValue");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@tblComb", sortedDTVal);
            cmd.Parameters.AddWithValue("@id_product", id_product);
            DataSet dsvv = data.getDataSet(cmd);
            bool bb = false; bool bbb = false;
            string qq = "select distinct id_attribute_group from ps_attribute_impact as b ";
            qq += " inner join ps_attribute as aa on aa.id_attribute=b.id_attribute ";
            qq += " inner join ps_attribute_lang as a on a.id_attribute=b.id_attribute and a.id_lang=1";
            // qq += " inner join ps_product_attribute as att on att.id_product=b.id_product ";
            qq += " where  b.IsDeleted=0 and b.id_product='" + id_product + "' order by id_attribute_group asc ";
            DataSet dsAcount = data.getDataSet(qq);
            if (dsvv.Tables[0].Rows.Count > 0)
            {

                DataRow[] results = dsvv.Tables[0].Select("pair2='" + dsvv.Tables[1].Rows[0][0].ToString() + "'");
                if (results.Length > 0)
                {
                    bbb = false;
                }
                else
                {
                    bbb = true;
                }
            }
            else
            {
                bbb = true;
            }

            if (dsAcount.Tables[0].Rows.Count > 0)
            {
                if (sortedDT.Rows.Count == dsAcount.Tables[0].Rows.Count)
                {
                    for (int ii = 0; ii < sortedDT.Rows.Count; ii++)
                    {
                        //if (ii != sortedDT.Rows.Count - 1)
                        //    attr += sortedDT.Rows[ii]["AttId"].ToString() + ",";
                        //else
                        //    attr += sortedDT.Rows[ii]["AttId"].ToString();
                        if (sortedDT.Rows[ii]["AttId"].ToString() == dsAcount.Tables[0].Rows[ii]["id_attribute_group"].ToString())
                        {
                            bb = true;
                        }
                        else
                        {
                            bb = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                bb = true;

            }


            if (bb == true && bbb == true)
            {
                if (dt.Rows.Count > 0)
                {
                    if (ViewState["PID"] != null)
                    {
                        id_product = ViewState["PID"].ToString();
                        data.executeCommand("Delete from ps_product_attribute where  Self=1 and id_product=" + id_product + "");
                        data.executeCommand("Delete from tbl_AllProduct where  Self=1 and id_product=" + id_product + "");
                        ds = gdata.addProductCombination(id_product, ReferenceCode, wholesale_price, Impacprice, "0", "0", Impweight,
           ImpUnitunit, Default, MinQty, AvaiDate);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            data.executeCommand("delete from ps_product_attribute_image  where id_product_attribute=" + ds.Tables[0].Rows[0][0].ToString() + "");
                            for (int i = 0; i < repCombImage.Items.Count; i++)
                            {
                                Label lblImgId = (Label)repCombImage.Items[i].FindControl("lblImgId");
                                CheckBox chkCompImag = (CheckBox)repCombImage.Items[i].FindControl("chkCompImag");
                                if (chkCompImag.Checked == true)
                                {
                                    string sqd = "insert into ps_product_attribute_image (id_product_attribute,id_image) values('" + ds.Tables[0].Rows[0][0].ToString() + "','" + lblImgId.Text + "')";
                                    data.executeCommand(sqd);
                                }
                            }
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                gdata.addProductAttributeValue(id_product, dt.Rows[i]["CombId"].ToString(), Impweight, Impacprice);
                            }
                        }
                    }
                }
                hideDiv.Visible = true;
                txtRefCode.Text = ""; txtImpactPrice.Text = "0"; txtImpactOrPrice.Text = "0";
                txtImpactW.Text = "0"; txtImpactUnitP.Text = "0"; txtMinumamQty.Text = "1";
                txtAvlDate.Text = ""; chkDefaultComb.Checked = false;
                drpImpactPrice.SelectedIndex = drpImpactWeight.SelectedIndex = 0;
                listValue.Items.Clear();
                drpAttribute.SelectedIndex = 0;
                drpValue.SelectedIndex = 0;
                ViewState["CombTbl"] = null;
                FillDeatil();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Check Combination')", true);
            }



        }

    }

    public void UpdateCombination()
    {
        data.executeCommand("delete from ps_product_attribute_image  where id_product_attribute=" + lblCombinationId.Text + "");
        for (int i = 0; i < repCombImage.Items.Count; i++)
        {
            Label lblImgId = (Label)repCombImage.Items[i].FindControl("lblImgId");
            CheckBox chkCompImag = (CheckBox)repCombImage.Items[i].FindControl("chkCompImag");
            if (chkCompImag.Checked == true)
            {
                string sqd = "insert into ps_product_attribute_image (id_product_attribute,id_image) values('" + lblCombinationId.Text + "','" + lblImgId.Text + "')";
                data.executeCommand(sqd);
            }
        }

        Session["tab"] = hddTab.Value;
        string id_product;
        string ReferenceCode = txtRefCode.Text; string wholesale_price = txtHolsalePrice.Text;
        string Impacprice = txtImpactPrice.Text; string ImpactOrPrice = txtImpactOrPrice.Text;
        string Impweight = txtImpactW.Text; string ImpUnitunit = txtImpactUnitP.Text; string MinQty = txtMinumamQty.Text;
        string AvaiDate = txtAvlDate.Text; string Default = (Convert.ToBoolean(chkDefaultComb.Checked)).ToString();
        if (drpImpactPrice.SelectedItem.Text == "Decrease")
        {
            if (txtImpactPrice.Text != "")
            {
                imp = Convert.ToDouble(txtImpactPrice.Text);
            }
            Impacprice = (imp * (-1)).ToString();
            ImpactOrPrice = (imp * (-1)).ToString();
            ImpUnitunit = (imp * (-1)).ToString();
        }
        else
        {
            Impacprice = txtImpactPrice.Text;
            ImpactOrPrice = txtImpactPrice.Text;
            ImpUnitunit = txtImpactPrice.Text;
        }

        if (drpImpactWeight.SelectedItem.Text == "Decrease")
        {
            if (txtImpactW.Text != "")
            {
                imw = Convert.ToDouble(txtImpactW.Text);
            }
            Impweight = (imw * (-1)).ToString();

        }
        else
        {
            Impweight = txtImpactW.Text;

        }
        DataTable dt = new DataTable();
        if (ViewState["CombTbl"] != null)
        {
            dt = (DataTable)ViewState["CombTbl"];
            if (dt.Rows.Count > 0)
            {
                if (ViewState["PID"] != null)
                {
                    id_product = ViewState["PID"].ToString();
                    if (Default == "True")
                    {
                        data.executeCommand("update ps_product_attribute set default_on ='false',Excel='Yes' where id_product_attribute in(select id_product_attribute from ps_product_attribute where IsDeleted=0 and id_product = '" + id_product + "') ");
                    }

                    ds = gdata.UpdateProductCombination(lblCombinationId.Text, id_product, ReferenceCode, wholesale_price, Impacprice, "0", "0", Impweight,
       ImpUnitunit, Default, MinQty, AvaiDate);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string id_product_attribute = ds.Tables[0].Rows[0]["id_product_attribute"].ToString();


                        if (data.executeCommand("Delete from ps_product_attribute_combination where id_product_attribute = '" + id_product_attribute + "'") == 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                gdata.UpdateProductAttributeValue(id_product_attribute, id_product, dt.Rows[i]["CombId"].ToString(), Impweight, Impacprice);
                            }
                        }
                    }
                }
            }
        }
        txtRefCode.Text = ""; txtImpactPrice.Text = "0"; txtImpactOrPrice.Text = "0";
        txtImpactW.Text = "0"; txtImpactUnitP.Text = "0"; txtMinumamQty.Text = "1";
        txtAvlDate.Text = ""; chkDefaultComb.Checked = false;
        drpImpactPrice.SelectedIndex = drpImpactWeight.SelectedIndex = 0;
        if (ViewState["CombTbl"] != null)
        {
            DataTable dttt = (DataTable)ViewState["CombTbl"];
            for (int i = dttt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dttt.Rows[i];
                dr.Delete();
            }
            dttt.AcceptChanges();
            listValue.DataSource = dttt;
            listValue.DataValueField = "CombId";
            listValue.DataTextField = "CombValue";
            listValue.DataBind();

            ViewState["CombTbl"] = dt;
        }
        listValue.Items.Clear();
        drpAttribute.SelectedIndex = 0;
        drpValue.SelectedIndex = 0;
        hideDiv.Visible = true;
        ViewState["CombTbl"] = null;
        FillDeatil();
    }

    protected void btnCombSaveAnd_Click(object sender, EventArgs e)
    {
        if (lblCombinationId.Text != "")
        {
            if (chkDefaultComb.Checked)
            {
                data.executeCommand("update ps_product set cache_default_attribute =  '" + lblCombinationId.Text + "',minimal_quantity='" + txtMinumamQty.Text + "' where id_product = '" + Request.QueryString["id"].ToString() + "'");
            }
            UpdateCombination();
        }
        else
        {
            SaveCombination();
        }
        lblCombinationId.Text = "";
        BindCombination();
        BindQuantities();
        //Session["tab"] = "";
        //if (Request.QueryString["PageNo"] != null)
        //    PageNo = Request.QueryString["PageNo"].ToString();
        //if (Request.QueryString["PageSize"] != null)
        //    PageSize = Request.QueryString["PageSize"].ToString();
        //Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
    }

    protected void repComb_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblCompId = (Label)e.Item.FindControl("lblCompId");
            Label lblActiveID = (Label)e.Item.FindControl("lblActiveID");
            HtmlTableRow trActive = (HtmlTableRow)e.Item.FindControl("trActive");
            string dddd = lblActiveID.Text;
            if (dddd == "True")
                trActive.Attributes.Add("class", "activeshan");
            else
            { }
        }
    }
    double price = 0;
    double weight = 0;
    protected void repComb_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {

            Data data = new Data();
            string query = "update ps_product_attribute_combination set IsDeleted=1 where  id_product_attribute=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query2 = "update ps_product_attribute set IsDeleted=1  where  id_product_attribute=" + e.CommandArgument + "";
            data.executeCommand(query2);
            string query3 = " update ps_attribute_impact set IsDeleted = 1 where id_product=" + e.CommandArgument + "";
            data.executeCommand(query3);
            data.executeCommand(" update tbl_AllProduct set IsDeleted = 1 where id_product_attribute=" + e.CommandArgument + "");
            //this.FillData(1);
            Session["tab"] = "Combinations";
            BindCombination();
            BindQuantities();
        }
        if (e.CommandName == "Edit")
        {
            //btnCombSaveAnd.Text = "Update Combination";
            Session["tab"] = "Combinations1";
            DataSet dsCom = data.getDataSet("Sp_ProductAttr " + e.CommandArgument.ToString());
            txtRefCode.Text = dsCom.Tables[0].Rows[0]["reference"].ToString();
            txtWholesaleprice.Text = dsCom.Tables[0].Rows[0]["wholesale_price"].ToString();
            txtImpactPrice.Text = dsCom.Tables[0].Rows[0]["price"].ToString();//
            if (dsCom.Tables[0].Rows[0]["price"] != null)
                price = Convert.ToDouble(dsCom.Tables[0].Rows[0]["price"]);
            if (price < 0)
                drpImpactPrice.SelectedValue = "-1";
            else if (price > 0)
                drpImpactPrice.SelectedValue = "1";
            else
                drpImpactPrice.SelectedValue = "0";

            if (dsCom.Tables[0].Rows[0]["weight"] != null)
                weight = Convert.ToDouble(dsCom.Tables[0].Rows[0]["weight"]);
            if (weight < 0)
                drpImpactWeight.SelectedValue = "-1";
            else if (weight > 0)
                drpImpactWeight.SelectedValue = "1";
            else
                drpImpactWeight.SelectedValue = "0";
            txtImpactOrPrice.Text = "0";
            txtImpactW.Text = dsCom.Tables[0].Rows[0]["weight"].ToString();//
            txtImpactUnitP.Text = dsCom.Tables[0].Rows[0]["unit_price_impact"].ToString();
            txtMinumamQty.Text = dsCom.Tables[0].Rows[0]["minimal_quantity"].ToString();
            txtAvlDate.Text = dsCom.Tables[0].Rows[0]["available_date1"].ToString();
            string dddd = dsCom.Tables[0].Rows[0]["default_on"].ToString();
            if (dddd != "")
                chkDefaultComb.Checked = Convert.ToBoolean(dsCom.Tables[0].Rows[0]["default_on"].ToString());
            else
                chkDefaultComb.Checked = false;
            // drpAttribute.SelectedValue= dsCom.Tables[0].Rows[0]["id_attribute"].ToString();

            dtlist.Columns.Add("CombId");
            dtlist.Columns.Add("CombValue");
            dtlist.Columns.Add("AttId");

            string[] combi;
            if (dsCom.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsCom.Tables[0].Rows.Count; i++)
                {
                    string AttriId = dsCom.Tables[0].Rows[i]["id_attribute"].ToString();
                    DataSet dsss = data.getDataSet("sp_GetAttributeCombination  '" + AttriId + "'");

                    DataRow dr = dtlist.NewRow();
                    dr["AttId"] = dsss.Tables[0].Rows[0]["id_attribute_group"].ToString();
                    dr["CombId"] = dsss.Tables[1].Rows[0]["id_attribute"].ToString();
                    dr["CombValue"] = dsss.Tables[0].Rows[0]["name"].ToString() + " : " + dsss.Tables[1].Rows[0]["name"].ToString();
                    dtlist.Rows.Add(dr);
                }

                listValue.DataSource = dtlist;
                listValue.DataValueField = "CombId";
                listValue.DataTextField = "CombValue";
                listValue.DataBind();
                lblCombinationId.Text = e.CommandArgument.ToString();
                hddCombinationId.Value = e.CommandArgument.ToString();
                ViewState["CombTbl"] = dtlist;
                for (int i = 0; i < repCombImage.Items.Count; i++)
                {
                    Label lblImgId = (Label)repCombImage.Items[i].FindControl("lblImgId");
                    CheckBox chkCompImag = (CheckBox)repCombImage.Items[i].FindControl("chkCompImag");
                    string sq = "select * from ps_product_attribute_image where id_product_attribute='" + e.CommandArgument.ToString() + "' and id_image='" + lblImgId.Text + "'";
                    DataSet dsAtr = data.getDataSet(sq);
                    if (dsAtr.Tables[0].Rows.Count > 0)
                    {
                        chkCompImag.Checked = true;
                    }
                    else
                        chkCompImag.Checked = false;
                    //for(int j=0;j<dsAtr.Tables[0].Rows.Count;j++)
                    //{
                    //    if(lblImgId.Text== dsAtr.Tables[0].Rows[j]["id_image"].ToString())
                    //    {

                    //    }
                    //    //else
                    //    //    chkCompImag.Checked = false;
                    //}
                }
                //repCombImage.DataSource = ds;
                //repCombImage.DataBind();
            }
        }
    }
    #endregion
    #region Feature
    public void BindFeatureByProduct(string id)
    {
        DataSet dsV = data.getDataSet("Sp_GetFeatureByProduct '%','%'");
        repFeature.DataSource = dsV;
        repFeature.DataBind();
    }

    protected void repFeature_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlGenericControl AddPre_defined = (HtmlGenericControl)e.Item.FindControl("AddPre_defined");
            DropDownList drpPreValue = (DropDownList)e.Item.FindControl("drpPreValue");
            Label lblPreValue = (Label)e.Item.FindControl("lblPreValue");
            Label lblid_feature = (Label)e.Item.FindControl("lblid_feature");
            Label lblIsCustom = (Label)e.Item.FindControl("lblIsCustom");
            TextBox txtCustomeValue = (TextBox)e.Item.FindControl("txtCustomeValue");
            //if (lblIsCustom.Text == "True")
            //{
            //    AddPre_defined.Visible = true;
            //    drpPreValue.Visible = false;
            //}
            //else
            //{
            //    AddPre_defined.Visible = false;
            //    drpPreValue.Visible = true;
            //}
            DataSet dsf = data.getDataSet("Sp_Getfeature_value '" + lblid_feature.Text + "'");
            if (dsf.Tables[0].Rows.Count > 0)
            {
                drpPreValue.DataSource = dsf;
                drpPreValue.DataTextField = "value";
                drpPreValue.DataValueField = "id_feature_value";
                drpPreValue.DataBind();
                drpPreValue.Items.Insert(0, new ListItem("Select ", "0"));
                AddPre_defined.Visible = false;
                drpPreValue.Visible = true;
                if (ViewState["PID"] != null)
                {
                    DataSet dsI = data.getDataSet("Sp_GetFeatureByProduct '" + ViewState["PID"].ToString() + "','" + lblid_feature.Text + "'");
                    if (dsI.Tables[0].Rows.Count > 0)
                    {
                        if (dsI.Tables[0].Rows[0]["Value"].ToString() != "")
                        {
                            drpPreValue.SelectedValue = dsI.Tables[0].Rows[0]["id_feature_value"].ToString();
                        }
                        //else
                        //    drpPreValue.Items.Insert(0, new ListItem("Select ", "0"));
                    }
                    //else
                    //    drpPreValue.Items.Insert(0, new ListItem("Select ", "0"));
                }
            }
            else
            {
                AddPre_defined.Visible = true;
                drpPreValue.Visible = false;
            }
            if (ViewState["PID"] != null)
            {
                DataSet dsI = data.getDataSet("Sp_GetFeatureByProduct '" + ViewState["PID"].ToString() + "','" + lblid_feature.Text + "'");
                if (dsI.Tables[0].Rows.Count > 0)
                {
                    if (dsI.Tables[0].Rows[0]["Custmvalue"].ToString() != "")
                    {
                        txtCustomeValue.Text = dsI.Tables[0].Rows[0]["Custmvalue"].ToString();
                    }
                }
            }
            //if (lblPreValue.Text != "" && lblPreValue.Text != "0")
            //{
            //    drpPreValue.SelectedItem.Text = lblPreValue.Text;
            //    AddPre_defined.Visible = false;
            //    drpPreValue.Visible = true;
            //}
            //else
            //{
            //    AddPre_defined.Visible = true;
            //    drpPreValue.Visible = false;
            //}

        }
    }

    public void InsertProductFeature()
    {
        Session["tab"] = hddTab.Value;
        for (int i = 0; i < repFeature.Items.Count; i++)
        {
            Label lblid_feature = (Label)repFeature.Items[i].FindControl("lblid_feature");
            Label lblPreValue = (Label)repFeature.Items[i].FindControl("lblPreValue");
            TextBox txtCustomeValue = (TextBox)repFeature.Items[i].FindControl("txtCustomeValue");
            DropDownList drpPreValue = (DropDownList)repFeature.Items[i].FindControl("drpPreValue");
            if (drpPreValue.SelectedIndex > 0)
            {
                int status = gdata.AddProductFeature(lblid_feature.Text, ViewState["PID"].ToString(), drpPreValue.SelectedValue, txtCustomeValue.Text);
            }
            else if (txtCustomeValue.Text != "")
            {
                int status = gdata.AddProductFeature(lblid_feature.Text, ViewState["PID"].ToString(), "", txtCustomeValue.Text);
            }
            else
            {
                if (txtCustomeValue.Text == "")
                {
                    data.executeCommand("Sp_ClearFeature '" + ViewState["PID"].ToString() + "','" + lblid_feature.Text + "'");
                }
                if (drpPreValue.SelectedIndex == 0)
                {
                    data.executeCommand("Sp_ClearFeature '" + ViewState["PID"].ToString() + "','" + lblid_feature.Text + "'");
                }
            }
        }
        hideDiv.Visible = true;
        FillDeatil();
    }

    protected void btnFeatureSaveAnd_Click(object sender, EventArgs e)
    {
        InsertProductFeature();
    }

    protected void btnFeatureSave_Click(object sender, EventArgs e)
    {
        InsertProductFeature();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    protected void btnFeature_Click(object sender, EventArgs e)
    {
        if (ViewState["PID"] != null)
        {

            Response.Redirect("addfeature.aspx?prd=" + ViewState["PID"].ToString() + "");
        }
    }
    #endregion
    #region Related
    protected void btnRelatedSaveAnd_Click(object sender, EventArgs e)
    {

    }

    protected void btnRelatedSave_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            Response.Redirect("Products.aspx?PageNo=" + Request.QueryString["PageNo"].ToString());
        else
            Response.Redirect("Products.aspx");
    }
    public void SaveRelated()
    { }
    #endregion
    #region Quantities 
    public void BindQuantities()
    {
        if (ViewState["PID"] != null)
        {
            string id_product = ViewState["PID"].ToString();
            DataSet dsQt = data.getDataSet("Sp_GetProductQuantities " + id_product);
            repQuantity.DataSource = dsQt;
            repQuantity.DataBind();
            if (dsQt.Tables[0].Rows.Count > 0)
            {
                txtStockMinQty.Text = dsQt.Tables[0].Rows[0]["minimal_quantity"].ToString();
                if (dsQt.Tables[0].Rows[0]["Combo"].ToString() == "NO")
                {
                    minimum.Visible = true;
                }
                else
                    minimum.Visible = false;
                if (dsQt.Tables[0].Rows[0]["stockq"].ToString() == "0")
                {
                    out_of_stock.Checked = true;
                }
                if (dsQt.Tables[0].Rows[0]["stockq"].ToString() == "1")
                {
                    out_of_stock_2.Checked = true;
                }
                if (dsQt.Tables[0].Rows[0]["stockq"].ToString() == "2")
                {
                    out_of_stock_2.Checked = true;
                }
            }

        }

    }
    public void SaveQuantities()
    {
        Session["tab"] = hddTab.Value;
        if (ViewState["PID"] != null)
        {
            string onstock;
            string stock;
            if (depends_on_stock_1.Checked == true)
                onstock = (Convert.ToBoolean(depends_on_stock_1.Checked)).ToString();
            else if (depends_on_stock_0.Checked == true)
                onstock = (Convert.ToBoolean(depends_on_stock_0.Checked)).ToString();
            else
                onstock = "false";

            if (out_of_stock.Checked == true)
                stock = "0";
            else if (out_of_stock_2.Checked == true)
                stock = "1";
            else if (out_of_stock_3.Checked == true)
                stock = "2";
            else
                stock = "2";
            string id_product = ViewState["PID"].ToString();
            string sq = "update ps_product set advanced_stock_management='" + onstock + "' where id_product='" + id_product + "'";
            data.executeCommand(sq);
            for (int i = 0; i < repQuantity.Items.Count; i++)
            {
                TextBox txtQQty = (TextBox)repQuantity.Items[i].FindControl("txtQQty");
                Label lblQuantityid = (Label)repQuantity.Items[i].FindControl("lblQuantityid");
                if (txtQQty.Text != "")
                {
                    //string sqq = "update ps_product_attribute set quantity='" + txtQQty.Text + "' where id_product_attribute='" + lblQuantityid.Text + "'";
                    //data.executeCommand(sqq);
                }
                if (i == 0)
                {
                    string sqq = "update ps_stock_available set quantity='" + txtQQty.Text + "',out_of_stock='" + stock + "' where id_product='" + id_product + "' and id_product_attribute=0";
                    data.executeCommand(sqq);
                    //gdata.AddStock(id_product, "0", txtQQty.Text, stock);
                }
                gdata.AddStock(id_product, lblQuantityid.Text, txtQQty.Text, stock);
            }
        }
        hideDiv.Visible = true;
        FillDeatil();
    }
    protected void btnQSaveAnd_Click(object sender, EventArgs e)
    {
        SaveQuantities();
    }

    protected void btnQSave_Click(object sender, EventArgs e)
    {
        SaveQuantities();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnQASaveAnd_Click(object sender, EventArgs e)
    {
        SaveQuantitiesAvil();
    }

    public void SaveQuantitiesAvil()
    {
        Session["tab"] = hddTab.Value;
        if (ViewState["PID"] != null)
        {
            string id_product = ViewState["PID"].ToString();
            string sq = "update ps_product_lang set available_now='" + txtavailable_now.Text + "',available_later='" + txtavailable_later.Text + "' where id_lang=1 and id_product='" + id_product + "'";
            data.executeCommand(sq);
            string qal = "update tbl_AllProduct set AvailabilityText='" + txtavailable_now.Text + "' where IsParent='Yes' and id_product='" + id_product + "'";
            data.executeCommand(qal);
            if (txtStockMinQty.Text != "")
            {
                //string sqq = "update ps_product_attribute set minimal_quantity='" + txtStockMinQty.Text + "' where id_product='" + id_product + "'";
                //data.executeCommand(sqq);
                string sqqq = "update ps_product set minimal_quantity='" + txtStockMinQty.Text + "' where id_product='" + id_product + "'";
                data.executeCommand(sqqq);
                // data.executeCommand("update tbl_AllProduct set AvailabilityText='" + txtavailable_now.Text + "' where IsParent='Yes' id_product='" + id_product + "'");
            }

        }
        hideDiv.Visible = true;
        FillDeatil();
    }
    protected void btnQASave_Click(object sender, EventArgs e)
    {
        SaveQuantitiesAvil();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    #endregion
    #region Associate
    protected void repCat_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater repSub = (Repeater)e.Item.FindControl("repSub");
            Label lblID = (Label)e.Item.FindControl("lblID");
            Label lblCarname = (Label)e.Item.FindControl("lblCarname");
            DataSet dsS = gdata.GetSubCategory(lblID.Text);
            HtmlInputCheckBox lnkAnchorRejection = (HtmlInputCheckBox)e.Item.FindControl("chk1");
            if (ViewState["PID"] != null || Request.QueryString["id"] != null)
            {

                string sqCat = "select * from ps_category_product where IsDeleted=0 and id_category='" + lblID.Text + "' and id_product='" + Request.QueryString["id"].ToString() + "'";
                DataSet dsC = data.getDataSet(sqCat);
                if (dsC.Tables[0].Rows.Count > 0)
                {
                    lnkAnchorRejection.Checked = true;
                }
                else
                {
                    lnkAnchorRejection.Checked = false;
                }
            }
            repSub.DataSource = dsS;
            repSub.DataBind();
        }
    }
    protected void repSub_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblID = (Label)e.Item.FindControl("lblID");
            Label lblParentId = (Label)e.Item.FindControl("lblParentId");
            Label lblSubCatName = (Label)e.Item.FindControl("lblSubCatName");
            HtmlInputCheckBox lnkAnchorRejection = (HtmlInputCheckBox)e.Item.FindControl("chk1");
            if (ViewState["PID"] != null || Request.QueryString["id"] != null)
            {

                //string sqCat = "select * from ps_category_product where IsDeleted=0 and id_category='" + lblID.Text + "' and id_product='" + Request.QueryString["id"].ToString() + "'";
                string sqCat = "select PCP.*, PS.id_parent from ps_category_product as PCP Inner Join ps_category as PS on ps.id_category = PCP.id_category where PCP.IsDeleted = 0 and PCP.id_category ='" + lblID.Text + "' and PCP.id_product = '" + Request.QueryString["id"].ToString() + "' and PS.id_parent ='" + lblParentId.Text + "'";

                DataSet dsC = data.getDataSet(sqCat);
                if (dsC.Tables[0].Rows.Count > 0)
                {
                    lnkAnchorRejection.Checked = true;
                }
                else
                {
                    lnkAnchorRejection.Checked = false;
                }
            }
        }
    }
    //public string ProcessMyDataItem(object myValue)
    //{
    //    string ss = "false";
    //    if (ViewState["PID"] != null || Request.QueryString["id"].ToString() != null)
    //    {

    //        string sqCat = "select * from ps_category_product where IsDeleted=0 and id_category='" + myValue.ToString() + "' and id_product='" + Request.QueryString["id"].ToString() + "'";
    //        DataSet dsC = data.getDataSet(sqCat);
    //        if (dsC.Tables[0].Rows.Count > 0)
    //        {
    //            ss = "false";
    //        }
    //        else
    //        {
    //            ss = "false";
    //        }
    //    }
    //    return ss;
    //}
    protected void btnAssociateSaveAnd_Click(object sender, EventArgs e)
    {
        SaveAssociate();
    }
    [WebMethod(EnableSession = true)]
    public static string AddCat(string ID, string CatName)
    {
        string jsonstring1 = string.Empty;
        //  HttpContext.Current.Session["Cat"] = null;
        DataTable dt = new DataTable();
        if (HttpContext.Current.Session["Cat"] == null)
        {
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("CatName", typeof(string)));
            HttpContext.Current.Session["Cat"] = dt;
        }
        if (HttpContext.Current.Session["Cat"] != null)
        {
            DataTable dtt = (DataTable)HttpContext.Current.Session["Cat"];
            DataRow[] foundAuthors = dtt.Select("ID = '" + ID + "'");
            if (foundAuthors.Length == 0)
            {
                DataRow dr = dtt.NewRow();
                dr.SetField("ID", ID);
                dr.SetField("CatName", CatName);
                dtt.Rows.Add(dr);
                HttpContext.Current.Session["Cat"] = dtt;
                jsonstring1 = JsonConvert.SerializeObject(dtt);
            }
        }

        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public static string RemCat(string ID, string CatName)
    {
        if (HttpContext.Current.Session["Cat"] != null)
        {
            DataTable dt = (DataTable)HttpContext.Current.Session["Cat"];
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];
                if (dr["ID"].ToString() == ID)
                    dr.Delete();
            }
            dt.AcceptChanges();
            HttpContext.Current.Session["Cat"] = dt;
        }

        return "";
    }
    protected void btnAssociateSave_Click(object sender, EventArgs e)
    {

        SaveAssociate();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    public void SaveAssociate()
    {
        Session["tab"] = hddTab.Value;
        string id_product = "";
        if (ViewState["PID"] != null)
        {
            id_product = ViewState["PID"].ToString();
        }

        if (id_product != "")
        {
            string selectedValue = Request.Form[drpDefaultCat.UniqueID];
            string qqAss1 = "select * from ps_product where id_product='" + id_product + "'";
            DataSet ds3 = data.getDataSet(qqAss1);
            if (ds3.Tables[0].Rows.Count > 0)
            {
                if (ds3.Tables[0].Rows[0]["id_category_default"].ToString() == selectedValue)
                {

                }
                else
                {
                    DataSet dsi = gdata.GetImageOfProduct(id_product);

                    for (int j = 0; j < dsi.Tables[0].Rows.Count; j++)
                    {
                        string sf = "select [dbo].[fn_Trim]('" + selectedValue + "')";
                        DataSet dsf = data.getDataSet(sf);
                        string f1 = dsf.Tables[0].Rows[0][0].ToString();//folder
                        string dir = smallUpload_dir + f1 + "/";
                        DirectoryInfo sourceinfo = new DirectoryInfo(@smallUpload_dir + "/" + dsi.Tables[0].Rows[0]["folder"].ToString());
                        DirectoryInfo target = new DirectoryInfo(@smallUpload_dir + "/" + f1);
                        if (Directory.Exists(@dir))
                        { }
                        else
                        {
                            Directory.CreateDirectory(@dir);
                        }
                        //if (!Directory.Exists(target.FullName))
                        //{
                        //    Directory.CreateDirectory(target.FullName);
                        //}

                        DataSet dsF = data.getDataSet(" select [dbo].[fn_RmSpecialChar]('" + dsi.Tables[0].Rows[j]["folder"].ToString() + "')");
                        string FName = dsF.Tables[0].Rows[0][0].ToString();
                        DataSet dsD = data.getDataSet(" select [dbo].[fn_RmSpecialChar]('" + f1 + "')");
                        string F2Name = dsF.Tables[0].Rows[0][0].ToString();
                        string DFName = dsD.Tables[0].Rows[0][0].ToString();
                        string imgFullPath = F2Name + "/" + dsi.Tables[0].Rows[j]["imgg2"].ToString();
                        string sourceFilePath = "/img/" + imgFullPath;
                        string destinationPath = "/img/" + DFName;
                        imgkt.imgKitMove(sourceFilePath, destinationPath);

                        if (File.Exists(Server.MapPath("../img/" + dsi.Tables[0].Rows[j]["folder"].ToString() + "/" + dsi.Tables[0].Rows[j]["imgg2"].ToString())))
                        {
                            if (File.Exists(Server.MapPath("../img/" + f1 + "/" + dsi.Tables[0].Rows[j]["imgg2"].ToString())))
                            {

                            }
                            else
                            {
                                File.Copy(Server.MapPath("../img/" + dsi.Tables[0].Rows[j]["folder"].ToString() + "/" + dsi.Tables[0].Rows[j]["imgg2"].ToString()), Server.MapPath("../img/" + f1 + "/" + dsi.Tables[0].Rows[j]["imgg2"].ToString()));
                            }
                        }
                        string sq = "select name,width,height from [ps_image_type] where products=1";
                        DataSet dsimg = data.getDataSet(sq);
                        for (int i = 0; i < dsimg.Tables[0].Rows.Count; i++)
                        {
                            string Filename = dsi.Tables[0].Rows[j]["id_image"].ToString() + "-" + dsimg.Tables[0].Rows[i]["name"] + ".jpg";

                            DataSet dsF1 = data.getDataSet(" select [dbo].[fn_RmSpecialChar]('" + dsi.Tables[0].Rows[j]["folder"].ToString() + "')");
                            string FName1 = dsF1.Tables[0].Rows[0][0].ToString();
                            DataSet dsD1 = data.getDataSet(" select [dbo].[fn_RmSpecialChar]('" + f1 + "')");
                            string F2Name1 = dsF1.Tables[0].Rows[0][0].ToString();
                            string DFName1 = dsD1.Tables[0].Rows[0][0].ToString();
                            //string imgFullPath1 = F2Name1 + "/" + dsi.Tables[0].Rows[j]["imgg2"].ToString();
                            string imgFullPath1 = F2Name1 + "/" + Filename;
                            string sourceFilePath1 = "/img/" + imgFullPath1;
                            string destinationPath1 = "/img/" + DFName1;
                            imgkt.moveImgKit(sourceFilePath1, destinationPath1);
                            if (File.Exists(Server.MapPath("../img/" + dsi.Tables[0].Rows[j]["folder"].ToString() + "/" + Filename)))
                            {
                                if (File.Exists(Server.MapPath("../img/" + f1 + "/" + Filename)))
                                {

                                }
                                else
                                {
                                    // File.Copy(Server.MapPath("../img/" + dsi.Tables[0].Rows[j]["folder"].ToString() + "/" + Filename), Server.MapPath("../img/" + f1 + "/" + Filename));

                                    File.Copy(Server.MapPath("../img/" + dsi.Tables[0].Rows[j]["folder"].ToString() + "/" + Filename), Server.MapPath("../img/" + f1 + "/" + Filename));
                                }
                            }


                        }
                        //foreach (FileInfo fi in dsi.Tables[0].Rows[j]["imgg2"])
                        //{
                        //   // File.Copy(Server.MapPath(@sourceinfo + "/" + dsi.Tables[0].Rows[j]["imgg2"].ToString()), @target + "/" + dsi.Tables[0].Rows[j]["imgg2"].ToString());
                        //    if (fi.Length != 0)
                        //        fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
                        //}
                        //if (Directory.Exists(@dir))
                        //{

                        //}
                        //else
                        //{
                        //    Directory.CreateDirectory(@dir);//Ar

                        //}

                        //    if (File.Exists(Server.MapPath(dsi.Tables[0].Rows[j]["ImageUrl"].ToString())))
                        //{
                        //    File.Copy(Server.MapPath(smallUpload_dir+"/"+dsi.Tables[0].Rows[j]["img3"].ToString()), Server.MapPath(smallUpload_dir + f1+"/"+ dsi.Tables[0].Rows[j]["imgg2"].ToString()));
                        //}
                    }

                }
            }
            if (HttpContext.Current.Session["Cat"] != null)
            {
                string sq = "delete from ps_category_product where id_product='" + id_product + "'";
                data.executeCommand(sq);
                DataTable dtt = (DataTable)HttpContext.Current.Session["Cat"];

                string qqAss = "update  ps_product set id_category_default='" + selectedValue + "' ,SizeChartCatId='" + drpSizeChart.SelectedValue + "',IsPersonalized='" + drpPersonalized.SelectedValue + "' where id_product='" + id_product + "'";
                data.executeCommand(qqAss);

                string def = "update  tbl_AllProduct set DefaultCategory=(select top(1) name from ps_category_lang where  IsDeleted=0 and id_lang=1 and id_category='" + selectedValue + "') where IsParent='yes' and id_product='" + id_product + "'";
                data.executeCommand(def);
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    gdata.AddCategoryProduct(dtt.Rows[i][0].ToString(), id_product, (i + 1).ToString());
                }
            }
        }
        hideDiv.Visible = true;
        FillDeatil();
    }
    protected void btnAddcat_Click(object sender, EventArgs e)
    {
        if (ViewState["PID"] != null)
        {

            Response.Redirect("addcategory.aspx?prd=" + ViewState["PID"].ToString() + "");
        }

    }
    #endregion
    #region Video
    protected void btnVideoSaveAnd_Click(object sender, EventArgs e)
    {
        SaveVideo();
    }
    public void BindVideo()
    {
        string id_product = "";
        if (ViewState["PID"] != null)
        {
            id_product = ViewState["PID"].ToString();
            DataSet dsVideo = data.getDataSet("Sp_GetVideo '" + id_product + "'");
            repVideo.DataSource = dsVideo;
            repVideo.DataBind();
            if (dsVideo.Tables[0].Rows.Count > 0)
                video.Visible = true;
            else
                video.Visible = false;
            if (dsVideo.Tables[0].Rows.Count > 0)
            {
                txtVideHeading.Text = dsVideo.Tables[0].Rows[0]["name"].ToString();
                txtVideoDescription.Text = dsVideo.Tables[0].Rows[0]["description"].ToString();
                txtVideoLink.Text = dsVideo.Tables[0].Rows[0]["link"].ToString();
            }

        }
    }
    protected void btnVideoSave_Click(object sender, EventArgs e)
    {
        SaveVideo();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    public void SaveVideo()
    {
        string id_product; string link = txtVideoLink.Text; string name = txtVideHeading.Text;
        string description = txtVideoDescription.Text;

        if (ViewState["PID"] != null)
        {
            id_product = ViewState["PID"].ToString();
            if (link != "")
            {
                int res = gdata.AddVideo(id_product, link, name, description);
            }

        }
        hideDiv.Visible = true;
        BindVideo();
    }
    protected void repVideo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "delete from ps_product_video  where id_video=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "delete from ps_product_video_lang  where id_video=" + e.CommandArgument + "";
            data.executeCommand(query1);
            Session["tab"] = "TMProductVideos";
            BindVideo();

        }
    }
    #endregion
    #region PriorityManagement
    protected void btnPriorityMngSaveAdd_Click(object sender, EventArgs e)
    {
        SavePriority();
    }

    protected void btnPriorityMngSave_Click(object sender, EventArgs e)
    {
        SavePriority();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    protected void btnPriorityMngCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    public void SavePriority()
    {
        DataSet dsM = new DataSet();
        string id_product;
        string Priority = drpPriority1.SelectedValue + ";" + drpPriority2.SelectedValue + ";" + drpPriority3.SelectedValue + ";" + drpPriority4.SelectedValue;
        if (ViewState["PID"] != null)
        {
            id_product = ViewState["PID"].ToString();
            dsM = gdata.InsertPriority(id_product, Priority);
            FillPriority(id_product);
        }
        hideDiv.Visible = true;
        FillDeatil();
    }

    public void FillPriority(string ProdId)
    {
        DataSet dsM = new DataSet();
        query = " select * from ps_specific_price_priority where id_product = '" + ProdId + "' ";
        dsM = data.getDataSet(query);
        if (dsM.Tables[0].Rows.Count > 0)
        {
            string[] priority = dsM.Tables[0].Rows[0]["priority"].ToString().Split(';');
            drpPriority1.SelectedValue = priority[0];
            drpPriority2.SelectedValue = priority[1];
            drpPriority3.SelectedValue = priority[2];
            drpPriority4.SelectedValue = priority[3];
        }
    }
    #endregion


    protected void btnInfoCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }



    protected void btnSpecificCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }



    protected void btnCombCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnPriceCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnSCOCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnAssoCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnShippingCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnQueCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnAvalCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnImagCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnFeatureCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnVideoCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnGenerat_Click(object sender, EventArgs e)
    {
        if (ViewState["PID"] != null)
        {
            string id_product = ViewState["PID"].ToString();
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "if(confirm('You will lose all unsaved modifications. Are you sure that you want to proceed ? ')){window.location ='AttributeGenerator.aspx?id=" + id_product + "';}else{}", true);
        }
    }
    #region Hot

    protected void btnHotCancel_Click(object sender, EventArgs e)
    {
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }

    protected void btnHotSaveAnd_Click(object sender, EventArgs e)
    {
        SaveHotDeals();
    }

    protected void btnHotSave_Click(object sender, EventArgs e)
    {
        SaveHotDeals();
        Session["tab"] = "";
        if (Request.QueryString["PageNo"] != null)
            PageNo = Request.QueryString["PageNo"].ToString();
        if (Request.QueryString["PageSize"] != null)
            PageSize = Request.QueryString["PageSize"].ToString();
        Response.Redirect("Products.aspx?PageNo=" + PageNo + "&&PageSize=" + PageSize);
        //else
        //    Response.Redirect("Products.aspx");
    }
    public void BindHot()
    {
        if (ViewState["PID"] != null)
        {
            string id_product = ViewState["PID"].ToString();
            string sq = "select CONVERT(CHAR(11),FromDate,103) as FDate,CONVERT(CHAR(11),ToDate,103) as TDate,*  from tbl_HotDeals ";
            sq += " where IsDeleted=0 and id_product='" + id_product + "'";
            DataSet dss = data.getDataSet(sq);
            if (dss.Tables[0].Rows.Count > 0)
            {
                txtDealFromdate.Text = dss.Tables[0].Rows[0]["FDate"].ToString();
                txtDealToDate.Text = dss.Tables[0].Rows[0]["TDate"].ToString();
                txtDealFromTime.Text = dss.Tables[0].Rows[0]["FromTime"].ToString();
                txtDealToTime.Text = dss.Tables[0].Rows[0]["ToTime"].ToString();
                ViewState["HID"] = dss.Tables[0].Rows[0]["id_product"].ToString();
            }

        }
    }
    public void SaveHotDeals()
    {
        string id_product; string link = txtVideoLink.Text; string name = txtVideHeading.Text;
        // string description = txtVideoDescription.InnerText;
        string Action = "Add";
        if (ViewState["PID"] != null)
        {
            Action = "Update";
        }
        if (ViewState["PID"] != null)
        {
            id_product = ViewState["PID"].ToString();
            if (txtDealFromdate.Text != "")
            {
                gdata.AddHotDeal(Action, id_product, txtDealFromdate.Text, txtDealToDate.Text, txtDealFromTime.Text, txtDealToTime.Text);
                Session["tab"] = "Hot";
                txtDealFromdate.Text = txtDealToDate.Text = "";
                BindHot();
            }
            else
            {
                data.executeCommand("update tbl_HotDeals set IsDeleted =1 where id_product='" + id_product + "'");
                BindHot();
            }
            FillDeatil();
        }
    }
    #endregion









    protected void btnPosition_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.ToString() != null)
        {
            Response.Redirect("ProductImagePosition.aspx?" + Request.QueryString.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using System.Text;

/// <summary>
/// Summary description for products
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class products : System.Web.Services.WebService
{
    Data data = new Data();
    DataSet ds = new DataSet();
    GetData getData = new GetData();
    GData gData = new GData();
    HttpCookie myCookie;
    string query = "";
    string CustId = "0";
    public products()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public string getProducts(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = getData.getProducts(catid, "");
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
    }

    [WebMethod(EnableSession = true)]
    public string getAttributes(string Slug)
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = getData.getMainGroup(catid);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ds = getData.getAttribute(catid, dt.Rows[i]["id_attribute_group"].ToString());
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
        DataSet ds = getData.getSubCategory(catid);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(ds.Tables[0]);
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
        DataSet dsr = getData.getItemMainGroup(prodID, "radio");

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
                DataSet dsi = getData.getItemAttribute(prodID, dsr.Tables[0].Rows[i]["id_attribute_group"].ToString());
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
        dsr = getData.getItemMainGroup(prodID, "select");
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
                DataSet dsi = getData.getItemAttribute(prodID, dsr.Tables[0].Rows[i]["id_attribute_group"].ToString());
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
        string ddd = getData.BindStar(ds.Tables[0].Rows[0]["Rating"].ToString());
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
    public string getFilterProducts(string Slug, string TypeID, string OrderBy, string subType, string minDis ="0", string maxDis = "0")
    {
        string[] aa = Slug.Split('/');
        string catslug = aa[aa.Length - 1];
        string[] bb = catslug.Split('-');
        string catid = bb[0].ToString();
        DataSet ds = getData.getFilterProduct(catid, TypeID, OrderBy, subType, minDis, maxDis);
        DataTable dt = new DataTable();
        dt.Merge(ds.Tables[0]);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        return jsonstring1;
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

        string maxid = dat.getDataSet("select ISNULL(max(id_guest)+1,1) as maxid from ps_product_comment").Tables[0].Rows[0]["maxid"].ToString();
        if (HttpContext.Current.Request.Cookies["custSniggle"] != null)
        {
            myCookie = HttpContext.Current.Request.Cookies["custSniggle"];
            CustId = myCookie.Values["id_customer"].ToString();
            dat.executeCommand("insert into ps_product_comment(id_product, id_customer, id_guest, title, [content], customer_name, grade, validate, deleted, date_add, active) values(" + catid + ",'" + CustId + "'," + maxid + ",'" + Title + "','" + Comment + "','" + Name + "'," + Rating + ",1,0,'" + DateTime.Now + "', '1')");
        }
        else
        {
            str = "Login";
        }
        return str;
    }

}

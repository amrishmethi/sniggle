using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Backoffice_AddTag : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdata = new AdminGetData();
    string filename1;
    //G:\Project\Earthstone\myearthstone\upload\img\c
    //  string smallUpload_dir = "G:/Project/Earthstone/myearthstone/upload/img/c/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                FillProduct();
                if (Request.QueryString["id"] != null)
                {
                    FillData(Request.QueryString["id"].ToString());
                    btnSave.Text = "Update";
                    btnSaveAnd.Visible = false;
                }
            }
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }

    public void FillData(string id)
    {
        string sq = "select * from ps_tag where IsDeleted=0 and id_lang=1 and id_tag='" + id + "'";
        ds = data.getDataSet(sq);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
        }
        string sqq = "select * from ps_product_tag as t inner join ps_product_lang as p on t.id_product=p.id_product and t.id_lang=1 and p.id_lang=1 where t.IsDeleted=0 and t.id_lang=1 and p.id_lang=1 and id_tag='" + id + "' ";
        DataSet dsp = data.getDataSet(sqq);
        if (dsp.Tables[0].Rows.Count > 0)
        {
            lastAdd.DataSource = dsp;
            lastAdd.DataTextField = "name";
            lastAdd.DataValueField = "id_product";
            lastAdd.DataBind();
        }
    }
    public void FillProduct()
    {
        string sq = "select* from ps_product_lang as l inner join ps_product as p on p.id_product = l.id_product and l.id_lang = 1";
        sq += " where IsDeletd = 0 and IsDeleted = 0 and id_lang = 1 and active = 1 ";
      
        if (Request.QueryString["id"] != null)
        {
            sq += " and p.id_product not in(select distinct id_product from ps_tag as t inner join ps_product_tag ";
            sq += " as p on p.id_tag = t.id_tag and p.id_lang = 1 and t.id_lang = 1";
            sq += " and p.id_tag ='"+ Request.QueryString["id"] .ToString()+ "' ";
            sq += " and p.IsDeleted = 0 and t.IsDeleted = 0)";
        }
        sq +=" order by l.name asc";
        ds = data.getDataSet(sq);
        lstProduct.DataSource = ds;
        lstProduct.DataTextField = "name";
        lstProduct.DataValueField = "id_product";
        lstProduct.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        List<ListItem> removedItems = new List<ListItem>();

        //Loop and transfer the Items to Destination ListBox.
        //foreach (ListItem item in lstProduct.Items)
        //{
        //    if (item.Selected)
        //    { 
        //        lastAdd.Items.Add(item);
        //    }
        //}
        //lstProduct.Items.RemoveAt(lstProduct.Items.IndexOf(lstProduct.SelectedItem));
        for (int i = 0; i <lstProduct.Items.Count;i++)
        {
            if (lstProduct.Items[i].Selected)
            {
                lastAdd.Items.Add(lstProduct.Items[i]);
                removedItems.Add(lstProduct.Items[i]);
                //  lstProduct.Items.RemoveAt(i);
            }   
        }
        foreach (ListItem item in removedItems)
        {
            //lastAdd.Items.Add(item);
            lstProduct.Items.Remove(item);
        }
    }
    string r = "";
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        List<ListItem> removedItems = new List<ListItem>();
        if (ViewState["Remove"] != null)
        {
            r = ViewState["Remove"].ToString() + ",";
        }
        //Loop and transfer the Items to Destination ListBox.
        foreach (ListItem item in lastAdd.Items)
        {
            if (item.Selected)
            {
                removedItems.Add(item);
                r = r + item.Value + ",";
            }
        }
        if (r.Length > 0)
        {
            string rvalue = r.Remove(r.Length - 1, 1);
            ViewState["Remove"] = rvalue;
        }

        foreach (ListItem item in removedItems)
        {
            lstProduct.Items.Add(item);
            lastAdd.Items.Remove(item);
           
        }
    }

    protected void btnSaveAnd_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect("AddTag.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        //if (Request.QueryString["id"] != null)
        //{
        Response.Redirect("Tags.aspx");
        //}
    }
    public void Save()
    {

        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
        }

        string name = txtName.Text.TrimStart().TrimEnd();
        ds = gdata.AddTagAdmin(action, name, ID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ViewState["Remove"] != null)
            {
                string query = "Update ps_product_tag set IsDeleted=1,DeleteDate=getdate(),DeletedFrom='Tag' where id_product in(" + ViewState["Remove"] + ") and id_tag='" + ds.Tables[0].Rows[0][0].ToString() + "'";
                data.executeCommand(query);
            }
            foreach (ListItem item in lastAdd.Items)
            {
                gdata.AddTagProduct(item.Value, ds.Tables[0].Rows[0][0].ToString());

            }
            //
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class Backoffice_AttributesGroups : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {
            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                FillData();
                Session["AttVPageUrl"] = "AttributesGroups.aspx";
            }
        }
    }
    public void FillData()
    {
        // ds = gdate.GetAttGroupAdmin(txtID.Text, txtName.Text, txtPosition.Text);
        // rep.DataSource = ds;
        // rep.DataBind();
        ds = ds = gdate.GetAttGroupAdmin(txtID.Text, txtName.Text, txtPosition.Text);
        ItemsListView.DataSource = ds;
        ItemsListView.DataBind();
    }
    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            //Data data = new Data();
            //string query = "update tbl_Warehouse set IsDeleted = 1,UpdateLoginId=0,UpdateDate=getdate()  where ID=" + e.CommandArgument + "";
            //data.executeCommand(query);
            FillData();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillData();
    }

    protected void rep_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "New")
        //{

        //    data.executeCommand("update ps_category set NewArrival = (case when NewArrival=1 then 0 else 1 end) where id_category=" + e.CommandArgument + "");
        //    FillData();
        //}
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "delete from ps_attribute_group_lang  where id_attribute_group=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "delete from ps_attribute_group  where id_attribute_group=" + e.CommandArgument + "";
            data.executeCommand(query1);
            FillData();
        }
    }

    protected void ItemsListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        FillData(); 
    }
    protected void ItemsListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
       
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {

    }

    protected void btnReferesh_Click(object sender, EventArgs e)
    {
        Response.Redirect("AttributesGroups.aspx");
    }

    protected void ItemsListView_ItemDeleting1(object sender, ListViewDeleteEventArgs e)
    {
        ListViewItem item = ItemsListView.Items[e.ItemIndex];
        Label id = (Label)item.FindControl("lblId");
        Data data = new Data();
            string query = "delete from ps_attribute_group_lang  where id_attribute_group=" + id.Text + "";
            data.executeCommand(query);
            string query1 = "delete from ps_attribute_group  where id_attribute_group=" + id.Text + "";
            data.executeCommand(query1);
            FillData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        Label lblid;
        foreach (ListViewItem checkedItem in ItemsListView.Items)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)checkedItem.FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)checkedItem.FindControl("lblid");
            if (chk.Checked == true)
            {
                Data data = new Data();
                string query = "delete from ps_attribute_group_lang  where id_attribute_group=" + lblid.Text + "";
                data.executeCommand(query);
                string query1 = "delete from ps_attribute_group  where id_attribute_group=" + lblid.Text + "";
                data.executeCommand(query1);
                FillData();
            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Deleted Successfully......')", true);
        //if (Request.QueryString["PageNo"] != null)
        //    pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        //else
        //    pageNo = 1;

        //Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnEnable_Click(object sender, EventArgs e)
    {
        Label lblid;
        foreach (ListViewItem checkedItem in ItemsListView.Items)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)checkedItem.FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)checkedItem.FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_category set active = 1 where id_category=" + lblid.Text + "");
                FillData();
            }

        }

        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Enable Successfully......')", true);
    }

    protected void btnDisable_Click(object sender, EventArgs e)
    {
        Label lblid;
        foreach (ListViewItem checkedItem in ItemsListView.Items)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)checkedItem.FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            lblid = (Label)checkedItem.FindControl("lblid");
            if (chk.Checked == true)
            {
                data.executeCommand("update ps_category set active = 0 where id_category=" + lblid.Text + "");
                FillData();
            }

        }

        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Disable Successfully......')", true);
    }
}
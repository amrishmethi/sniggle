﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Backoffice_Categories : System.Web.UI.Page
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
            }
        }
    }
    public void FillData()
    {
        ds = gdate.GetCategory(txtID.Text, txtName.Text, txtDescription.Text, txtPosition.Text, drpisplayed.SelectedValue);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        ItemsListView.DataSource = ds;
        ItemsListView.DataBind();
        //}
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillData();
    }

    protected void rep_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "New")
        {

            data.executeCommand("update ps_category set NewArrival = (case when NewArrival=1 then 0 else 1 end),NewArrivalDate=getdata() where id_category=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "A")
        {

            data.executeCommand("update ps_category set active = (case when active=1 then 0 else 1 end) where id_category=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "update ps_category set IsDeleted = 1  where id_category=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "update ps_category_lang set IsDeleted = 1  where id_category=" + e.CommandArgument + "";
            data.executeCommand(query1);
            FillData();
        }
    }

    protected void ItemsListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "New")
        {

            data.executeCommand("update ps_category set NewArrival = (case when NewArrival=1 then 0 else 1 end),NewArrivalDate=getdate() where id_category=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "A")
        {

            data.executeCommand("update ps_category set active = (case when active=1 then 0 else 1 end) where id_category=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "H")
        {

            data.executeCommand("update ps_category set IsHome = (case when IsHome=1 then 0 else 1 end) where id_category=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "update ps_category set IsDeleted = 1  where id_category=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "update ps_category_lang set IsDeleted = 1  where id_category=" + e.CommandArgument + "";
            data.executeCommand(query1);
            FillData();
        }
    }

    protected void btnReferesh_Click(object sender, EventArgs e)
    {
        Response.Redirect("Categories.aspx");
    }

    protected void ItemsListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        //ListViewItem item = this.ItemsListView.Items[e.ItemIndex];
        //int id = Convert.ToInt32((item.FindControl("lblId") as Label).Text);
        ////ListViewItem item = ItemsListView.Items[e.ItemIndex];
        ////Label id = (Label)item.FindControl("lblId");
        //Data data = new Data();
        //string query = "update ps_category set IsDeleted = 1  where id_category=" + id + "";
        //data.executeCommand(query);
        //string query1 = "update ps_category_lang set IsDeleted = 1  where id_category=" + id+ "";
        //data.executeCommand(query1);
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
                string query = "update ps_category set IsDeleted = 1  where id_category=" + lblid.Text + "";
                data.executeCommand(query);
                string query1 = "update ps_category_lang set IsDeleted = 1  where id_category=" + lblid.Text + "";
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

    protected void ItemsListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)e.Item.FindControl("chk");
            // chk = (CheckBox)rep.Items[i].FindControl("chk");
            Label lblid = (Label)e.Item.FindControl("lblid");
            if (chk.Checked == true)
            {
                //data.executeCommand("update ps_category set active = 0 where id_category=" + lblid.Text + "");
                //FillData();
            }
        }
    }
}
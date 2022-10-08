using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Backoffice_AttributeValue : System.Web.UI.Page
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
                if (Request.QueryString["gid"] != null)
                    hrfval.HRef = "AttributeValue.aspx?gid=" + Request.QueryString["gid"].ToString();
                Session["AttVPageUrl"] = "AttributeValue.aspx?gid=" + Request.QueryString["gid"].ToString();

            }
        }
    }
    public void FillData()
    {
        string gid = "";
        if (Request.QueryString["gid"] != null)
            gid = Request.QueryString["gid"].ToString();
        ds = gdate.GetAttValueAdmin(txtID.Text, txtName.Text, txtPosition.Text, gid);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        ItemsListView.DataSource = ds;
        ItemsListView.DataBind();
        //}
    }
    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "delete from ps_attribute_lang  where id_attribute=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "delete from ps_attribute  where id_attribute=" + e.CommandArgument + "";
            data.executeCommand(query1);
            FillData();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillData();
    }

    protected void rep_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "New")
        {

            data.executeCommand("update ps_category set NewArrival = (case when NewArrival=1 then 0 else 1 end) where id_category=" + e.CommandArgument + "");
            FillData();
        }
    }
    protected void btnReferesh_Click(object sender, EventArgs e)
    {
        Response.Redirect("AttributeValue.aspx?gid=" + Request.QueryString["gid"]);
    }

    protected void ItemsListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "delete from ps_attribute_lang  where id_attribute=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "delete from ps_attribute  where id_attribute=" + e.CommandArgument + "";
            data.executeCommand(query1);
            FillData();
        }
    }

    protected void ItemsListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
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
                string query = "delete from ps_attribute_lang  where id_attribute=" + lblid.Text + "";
                data.executeCommand(query);
                string query1 = "delete from ps_attribute  where id_attribute=" + lblid.Text + "";
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
}
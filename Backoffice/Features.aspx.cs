using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Backoffice_Features : System.Web.UI.Page
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
                Session["AttFPageUrl"] = "Features.aspx";
            }
        }
    }
    public void FillData()
    {
        ds = gdate.GetFeaturesAdmin(txtID.Text, txtName.Text, txtPosition.Text);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        ItemsListView.DataSource = ds;
        ItemsListView.DataBind();
        lblCount.Text = ds.Tables[0].Rows.Count.ToString();
        //}
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
        if (e.CommandName == "New")
        {

            data.executeCommand("update ps_category set NewArrival = (case when NewArrival=1 then 0 else 1 end) where id_category=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "delete from ps_feature  where id_feature=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "delete from ps_feature_lang  where id_feature=" + e.CommandArgument + "";
            data.executeCommand(query1);
            FillData();
        }
    }
    protected void btnReferesh_Click(object sender, EventArgs e)
    {
        Response.Redirect("Features.aspx");
    }

    protected void ItemsListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "New")
        {

            data.executeCommand("update ps_category set NewArrival = (case when NewArrival=1 then 0 else 1 end) where id_category=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "delete from ps_feature  where id_feature=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "delete from ps_feature_lang  where id_feature=" + e.CommandArgument + "";
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
                string query = "delete from ps_feature_lang  where id_feature=" + lblid.Text + "";
                data.executeCommand(query);
                string query1 = "delete from ps_feature  where id_feature=" + lblid.Text + "";
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
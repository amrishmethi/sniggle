using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Backoffice_FeaturesValue : System.Web.UI.Page
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
                    Session["AttFPageUrl"] = "FeaturesValue.aspx?gid=" + Request.QueryString["gid"].ToString();
                hrfval.HRef = "FeaturesValue.aspx?gid=" + Request.QueryString["gid"].ToString();
            }
        }
    }
    public void FillData()
    {
        string gid = "";
        if (Request.QueryString["gid"] != null)
            gid = Request.QueryString["gid"].ToString();
        ds = gdate.GetFeaturesValueAdmin(txtID.Text, txtName.Text, gid);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        rep.DataSource = ds;
        rep.DataBind();
        //}
    }
   

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillData();
    }

    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        if (e.CommandName == "Delete")
        {
            Data data = new Data();
            string query = "delete from ps_feature_value  where id_feature_value=" + e.CommandArgument + "";
            data.executeCommand(query);
            string query1 = "delete from ps_feature_value_lang  where id_feature_value=" + e.CommandArgument + "";
            data.executeCommand(query1);
            FillData();
        }
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
                string query = "delete from ps_feature_value  where id_feature_value=" + lblid.Text + "";
                data.executeCommand(query);
                string query1 = "delete from ps_feature_value_lang  where id_feature_value=" + lblid.Text + "";
                data.executeCommand(query1);
            }
        }
        FillData(); 
        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Deleted Successfully......')", true);
        //if (Request.QueryString["PageNo"] != null)
        //    pageNo = Convert.ToInt32(Request.QueryString["PageNo"]);
        //else
        //    pageNo = 1;

        //Response.Redirect("Products.aspx?PageNo=" + pageNo.ToString() + "&&PageSize=" + drpPageSize.SelectedValue);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtID.Text = txtName.Text = "";
        FillData();
    }
}
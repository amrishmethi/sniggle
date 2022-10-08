using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Backoffice_FilterTemplate : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdata = new AdminGetData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {
            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                FillParentCat();
            }
        }
    }
    public void FillParentCat()
    {
        //ds = data.getDataSet("select * from ps_category_lang  where IsDeleted=0 and id_lang=1 and id_category !=1");
        ds = data.getDataSet("[dbo].[sp_GetSearchCategory]  ");
        drpCategory.DataSource = ds;
        drpCategory.DataTextField = "name";
        drpCategory.DataValueField = "id_category";
        drpCategory.DataBind();
        drpCategory.Items.Insert(0, new ListItem("Select category", "0"));

        DataSet ds2 = data.getDataSet("select AG.id_attribute_group,('Attribute group: '+name) as name,(select count(*) from ps_attribute " +
            " where AG.id_attribute_group=AG.id_attribute_group) as Value from ps_attribute_group_lang As AG inner join ps_attribute_group as  AGL on AGL.id_attribute_group=AG.id_attribute_group where id_lang=1 order by position");
        ItemsListView.DataSource = ds2;
        ItemsListView.DataBind();
    }

    protected void btnAssoCancel_Click(object sender, EventArgs e)
    {

    }

    protected void btnAssociateSaveAnd_Click(object sender, EventArgs e)
    {
        if(drpCategory.SelectedIndex > 0)
        {
            data.executeCommand("delete from tbl_FrontSideFilter where CatId='" + drpCategory.SelectedValue + "'");
            Label lblid;
            TextBox txtPosition;
            foreach (ListViewItem checkedItem in ItemsListView.Items)
            {
                CheckBox chk = (CheckBox)checkedItem.FindControl("chk");
                lblid = (Label)checkedItem.FindControl("lblID");
                txtPosition = (TextBox)checkedItem.FindControl("txtPosition");
                if (chk.Checked == true && drpCategory.SelectedIndex > 0)
                {
                    gdata.InsFilter(drpCategory.SelectedValue, lblid.Text, txtPosition.Text);
                }
            }
        }
        

        //FillParentCat();
    }

    protected void drpCategory_TextChanged(object sender, EventArgs e)
    {
        Label lblid;
        TextBox txtPosition;
        string sq = "";
        foreach (ListViewItem checkedItem in ItemsListView.Items)
        {
            CheckBox chk = (CheckBox)checkedItem.FindControl("chk");
            lblid = (Label)checkedItem.FindControl("lblID");
            txtPosition = (TextBox)checkedItem.FindControl("txtPosition");
            sq = "select Position from tbl_FrontSideFilter where CatId='" + drpCategory.SelectedValue + "' and AttrId='" + lblid.Text + "'";
            ds = data.getDataSet(sq);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPosition.Text = ds.Tables[0].Rows[0][0].ToString();
                chk.Checked = true;
            }
            else
                chk.Checked = false;

        }
    }
}
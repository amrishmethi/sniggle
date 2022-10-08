using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Backoffice_addMenu : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    HttpCookie AdminCookie;
    AdminGetData gdate = new AdminGetData();
    string filename1;
    //G:\Project\Earthstone\myearthstone\upload\img\c
    string smallUpload_dir = "G:/Project/Earthstone/myearthstone/upload/img/c/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {

            AdminCookie = Request.Cookies["Backoffice"];
            if (!IsPostBack)
            {
                FillParentCat();
                BindMenu();
                if (Request.QueryString["id"] != null)
                {
                    FillData();
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
    public void FillParentCat()
    {
        ds = gdate.GetCategory("", "", "", "", "");
        repCat.DataSource = ds;
        repCat.DataBind();
    }
    public void FillData()
    {
        string sq = "select * from tbl_Menu where id_Menu='" + Request.QueryString["id"].ToString() + "'";
        ds = data.getDataSet(sq);
        txtDis.Text = ds.Tables[0].Rows[0]["DisplayIndex"].ToString();
        txtName.Text = ds.Tables[0].Rows[0]["MenuName"].ToString();
        txtLink.Text= ds.Tables[0].Rows[0]["Link"].ToString();
        if (ds.Tables[0].Rows[0]["IsCMS"].ToString() == "True")
            radcms.Checked = true;
        else if (ds.Tables[0].Rows[0]["IsCMS"].ToString() == "False")
            radcat.Checked = true;
        hdd.Value = ds.Tables[0].Rows[0]["IsCMS"].ToString();
        if (ds.Tables[0].Rows[0]["IsCategory"].ToString() == "True")
            radIsCat.Checked = true;
        else
            radIsCat.Checked = false;
        txtBold.Text= ds.Tables[0].Rows[0]["TextBold"].ToString();
        txtColor.Text= ds.Tables[0].Rows[0]["ColorCode"].ToString();
    }
    public void BindMenu()
    {
        string qq = "select * from tbl_Menu where IsDeleted=0 and IsCMS=1";
        ds = data.getDataSet(qq);
        drpMenu.DataSource = ds;
        drpMenu.DataTextField = "MenuName";
        drpMenu.DataValueField = "id_Menu";
        drpMenu.DataBind();
        drpMenu.Items.Insert(0, new ListItem("Parent Menu", "0"));
    }
    public void Save()
    {
        ///var productText = Server.HtmlEncode("<p>example</p>");
        string action = "Add"; string ID = "0";
        string name = txtName.Text.Trim(); string DisIndex = txtDis.Text;
        string cms = "true"; string IsCat = "false";
        if (radIsCat.Checked == true)
            IsCat = "true";
        if (radcms.Checked == true)
            cms = "true";
        else if (radcat.Checked == true)
            cms = "false";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
        }
        if (gdate.chkMenu(txtName.Text) == 0)
        {
            ds = gdate.InsMenu(action, name, DisIndex, ID, cms, drpMenu.SelectedValue, txtLink.Text, IsCat,txtColor.Text,txtBold.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (radcat.Checked == true)
                {
                    insertCat(ds.Tables[0].Rows[0][0].ToString());
                }

                RMG.Functions.MsgBox("Record Added Successfully......");
                txtDis.Text = txtName.Text = "";
            }
        }
        // else
        //RMG.Functions.MsgBox("Already exist.");
    }
    public void insertCat(string id_Menu)
    {
        data.executeCommand("delete from tbl_Menu_category where id_Menu=" + id_Menu + "");
        if (repCat.Items.Count > 0)
        {
            for (int i = 0; i < repCat.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)repCat.Items[i].FindControl("chk1");
                if (chk.Checked == true)
                {
                    Label lblID = (Label)repCat.Items[i].FindControl("lblID");
                    gdate.InsMenuCat(lblID.Text, id_Menu);
                }
                Repeater repSub = (Repeater)repCat.Items[i].FindControl("repSub");
                if (repSub.Items.Count > 0)
                {
                    for (int j = 0; j < repSub.Items.Count; j++)
                    {
                        CheckBox chk2 = (CheckBox)repSub.Items[j].FindControl("chk2");
                        Label lblID1 = (Label)repSub.Items[j].FindControl("lblID1");
                        if (chk2.Checked == true)
                        {

                            gdate.InsMenuCat(lblID1.Text, id_Menu);
                        }
                    }
                }
            }
        }

    }
    public void Update()
    {
        ///var productText = Server.HtmlEncode("<p>example</p>");
        string action = "Add"; string ID = "0";
        string name = txtName.Text.Trim(); string DisIndex = txtDis.Text;
        string cms = "true"; string IsCat = "false";
        if (radIsCat.Checked == true)
            IsCat = "true";
        if (radcms.Checked == true)
            cms = "true";
        else if (radcat.Checked == true)
            cms = "false";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
        }
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
        }

        ds = gdate.InsMenu(action, name, DisIndex, ID, cms, drpMenu.SelectedValue, txtLink.Text, IsCat,txtColor.Text,txtBold.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (radcat.Checked == true)
            {
                insertCat(ds.Tables[0].Rows[0][0].ToString());
            }

            RMG.Functions.MsgBox("Record Added Successfully......");
            txtDis.Text = txtName.Text = "";
        }

    }

    protected void btnSaveAnd_Click(object sender, EventArgs e)
    {

        Save();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {
            Update();
            Response.Redirect("menu.aspx");
        }
        else
            Save();
    }

    protected void repCat_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater repSub = (Repeater)e.Item.FindControl("repSub");
            Label lblID = (Label)e.Item.FindControl("lblID");
            Label lblCarname = (Label)e.Item.FindControl("lblCarname");
            DataSet dsS = gdate.GetSubCategory(lblID.Text);
            CheckBox chk = (CheckBox)e.Item.FindControl("chk1");
            if (Request.QueryString["id"] != null)
            {

                string sqCat = "select * from tbl_Menu_category where IsDeleted=0 and id_category='" + lblID.Text + "' and id_Menu='" + Request.QueryString["id"].ToString() + "'";
                DataSet dsC = data.getDataSet(sqCat);
                if (dsC.Tables[0].Rows.Count > 0)
                {
                    chk.Checked = true;
                }
                else
                {
                    chk.Checked = false;
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
            Label lblID = (Label)e.Item.FindControl("lblID1");
            Label lblParentId = (Label)e.Item.FindControl("lblParentId");
            CheckBox chk = (CheckBox)e.Item.FindControl("chk2");
            if (Request.QueryString["id"] != null)
            {

                string sqCat = "select * from tbl_Menu_category where IsDeleted=0 and id_category='" + lblID.Text + "' and id_Menu='" + Request.QueryString["id"].ToString() + "'";
                DataSet dsC = data.getDataSet(sqCat);
                if (dsC.Tables[0].Rows.Count > 0)
                {
                    chk.Checked = true;
                }
                else
                {
                    chk.Checked = false;
                }
            }
        }
    }
}
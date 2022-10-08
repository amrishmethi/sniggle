using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Backoffice_AdminMasterPage : System.Web.UI.MasterPage
{
    HttpCookie AdminCookie;
    Data data = new Data();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Backoffice"] != null)
        {
            Notification();
            AdminCookie = Request.Cookies["Backoffice"];
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
    public void Notification()
    {
        DataSet dsEr = data.getDataSet("select count(*) as cc from tbl_LogError where  Notification=1 ");

        if (dsEr.Tables[0].Rows[0][0].ToString() != "0")
        {
            lblEror.Text = "Total Errors " + dsEr.Tables[0].Rows[0][0].ToString();
            spanerr.Visible = true;
        }
        else
        {
            spanerr.Visible = false;
        }


        ds = data.getDataSet("select convert(nvarchar(20),AddedDate,100) AS AddedDate,* from tbl_ContactUs where IsDeleted=0 and Notification=1");
        repContact.DataSource = ds;
        repContact.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {

            lblContact.Visible = false;
        }

        DataSet dsR = data.getDataSet("select * from tbl_CustomOrder where IsDeleted=0 and Notification=1 and EntryType='RAQ'");
        repRequest.DataSource = dsR;
        repRequest.DataBind();
        if (dsR.Tables[0].Rows.Count == 0)
        {
            lblRequest.Visible = false;
        }
        DataSet dsCustom = data.getDataSet("select * from tbl_CustomOrder where IsDeleted=0 and Notification=1 and EntryType='Custom'");
        repCustom.DataSource = dsCustom;
        repCustom.DataBind();
        if (dsCustom.Tables[0].Rows.Count == 0)
        {
            lblCustomOrder.Visible = false;
        }
        DataSet dsO = data.getDataSet("select * from ps_orders where  Notification=1 ");
        repOrder.DataSource = dsO;
        repOrder.DataBind();
        if (dsO.Tables[0].Rows.Count == 0)
        {
            Onn.Visible = false;
        }
        else
            Onn.Visible = true;

        DataSet dsenq = data.getDataSet("select * from tbl_ProductEnquiry where IsDeleted=0 and Notification=1 and Subject !='From Reorder'");
        repEnquire.DataSource = dsenq;
        repEnquire.DataBind();
        if (dsenq.Tables[0].Rows.Count == 0)
        {
            lblEnquire.Visible = false;
        }

        DataSet dsCuts = data.getDataSet("select * from tbl_CreativeCutsEnquiry where IsDeleted=0 and Notification=1 ");
        repCut.DataSource = dsCuts;
        repCut.DataBind();
        if (dsCuts.Tables[0].Rows.Count == 0)
        {
            lblCuts.Visible = false;
        }
        DataSet dsCus = data.getDataSet("select * from ps_customer where  Notification=1 ");
        repReg.DataSource = dsCus;
        repReg.DataBind();
        DataSet dsRe = data.getDataSet("select * from tbl_ProductEnquiry where  Notification=1 and Subject ='From Reorder'");
        repReOrder.DataSource = dsRe;
        repReOrder.DataBind();
        if (dsRe.Tables[0].Rows.Count == 0)
        {
            lblReOrder.Visible = false;
        }
        if (dsCus.Tables[0].Rows.Count == 0)
        {
            lblCuts.Visible = false;
            rn.Visible = false;
        }
        else
            rn.Visible = true;

        if (ds.Tables[0].Rows.Count != 0)
        {
            Alln.Visible = true;
            return;
        }
        else if (dsR.Tables[0].Rows.Count != 0)
        {
            Alln.Visible = true;
            return;
        }
        else if (dsCustom.Tables[0].Rows.Count != 0)
        {
            Alln.Visible = true;
            return;
        }
        else if (dsCuts.Tables[0].Rows.Count != 0)
        {
            Alln.Visible = true;
            return;
        }
        else if (dsenq.Tables[0].Rows.Count != 0)
        {
            Alln.Visible = true;
            return;
        }
        else if (dsRe.Tables[0].Rows.Count != 0)
        {
            Alln.Visible = true;
            return;
        }
        else
        {
            Alln.Visible = false;
        }

    }
}

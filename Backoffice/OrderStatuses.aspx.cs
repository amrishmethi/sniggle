using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Backoffice_OrderStatuses : System.Web.UI.Page
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
                FillDataR(); 
            }
        }
    }

    public void FillData()
    {
        ds = gdate.GetOrderStatus(txtID.Text, txtName.Text, drpSendMail.SelectedValue, drpDelivery.SelectedValue, drpInvoice.SelectedValue, txtEmailTemp.Text);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        rep.DataSource = ds;
        rep.DataBind();
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
        if (e.CommandName == "Mail")
        {
            data.executeCommand("update ps_order_state set send_email = (case when send_email=1 then 0 else 1 end) where id_order_state=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "Delever")
        {
            data.executeCommand("update ps_order_state set delivery = (case when delivery=1 then 0 else 1 end) where id_order_state=" + e.CommandArgument + "");
            FillData();
        }
        if (e.CommandName == "Inv")
        {
            data.executeCommand("update ps_order_state set invoice = (case when invoice=1 then 0 else 1 end) where id_order_state=" + e.CommandArgument + "");
            FillData();
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      txtName.Text = txtID.Text = txtEmailTemp.Text = "";
        drpDelivery.SelectedIndex = drpInvoice.SelectedIndex = drpSendMail.SelectedIndex = 0;
        FillData();
    }
    public void FillDataR()
    {
        ds = gdate.GetOrderReturnStatus(txtID.Text, txtName.Text);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        RepR.DataSource = ds;
        RepR.DataBind();
        lblR.Text = ds.Tables[0].Rows.Count.ToString();
        //}
    }
    protected void btnRSearch_Click(object sender, EventArgs e)
    {
        FillDataR();
    }

    protected void btnRReset_Click(object sender, EventArgs e)
    {
        txtRName.Text = txtRID.Text = "";
    }
    public string ProcessMyDataItem(object myValue)
    {
        string ss = "";
        if (File.Exists(Server.MapPath(myValue.ToString())))
            ss = myValue.ToString();
        else
            ss = "";
        return ss;
    }
}
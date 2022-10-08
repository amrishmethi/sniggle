using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Backoffice_AddPaymentMethod : System.Web.UI.Page
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

                if (Request.QueryString["id"] != null)
                {
                    FillData();
                    btnSave.Text = "Update";

                }
            }
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
    public void FillData()
    {
        string sq = " select * from tbl_PaymentMethod where IsDeleted=0 and ID= '" + Request.QueryString["id"].ToString() + "'";
        ds = data.getDataSet(sq);
        if (ds.Tables[0].Rows.Count > 0)
        {
            // Marchant_id,WorkingKeyIP,AccessCodeIP,WorkingKey,ActionUrl,AccessCode,CancelleUrl,EmailId,SuccessUrl
            txtAccessCode.Text = ds.Tables[0].Rows[0]["AccessCodeIP"].ToString();
            txtActionUrl.Text = ds.Tables[0].Rows[0]["ActionUrl"].ToString();
            txtCancelleUrl.Text = ds.Tables[0].Rows[0]["CancelleUrl"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
            txtMerchant.Text = ds.Tables[0].Rows[0]["Marchant_id"].ToString();
            txtSuccessUrl.Text = ds.Tables[0].Rows[0]["SuccessUrl"].ToString();
            txtWorkingKey.Text = ds.Tables[0].Rows[0]["WorkingKeyIP"].ToString();
        }
    }
    public void Save()
    {
        string action = "Add"; string ID = "0";
        if (Request.QueryString["id"] != null)
        {
            action = "Update";
            ID = Request.QueryString["id"].ToString();
        }

        string Marchant_id = txtMerchant.Text; string WorkingKeyIP = txtWorkingKey.Text;
        string AccessCodeIP = txtAccessCode.Text; string WorkingKey = txtWorkingKey.Text;
        string ActionUrl = txtActionUrl.Text; string AccessCode = txtAccessCode.Text;
        string CancelleUrl = txtCancelleUrl.Text; string EmailId = txtEmail.Text;
        string SuccessUrl = txtSuccessUrl.Text;
        ds = gdate.AddPaymentMethod(action, Marchant_id, WorkingKeyIP, AccessCodeIP, WorkingKey, ActionUrl, AccessCode, CancelleUrl, EmailId, SuccessUrl, ID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            RMG.Functions.MsgBox(ds.Tables[0].Rows[0][0].ToString());
            txtAccessCode.Text = txtActionUrl.Text = txtCancelleUrl.Text = txtEmail.Text = txtMerchant.Text = txtSuccessUrl.Text = txtWorkingKey.Text = "";
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("PaymentMethod.aspx");
        }
    }
}
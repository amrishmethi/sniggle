using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Reflection;

public partial class Backoffice_AttributeGenerator : System.Web.UI.Page
{
    Data data = new Data();
    DataSet ds = new DataSet();
    AdminGetData gdate = new AdminGetData();
    DataTable dtcom = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    DataTable dtEmployee = new DataTable();
    DataTable dt7 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                fillAttributeGroup();
                ds = data.getDataSet("sp_GetCombnationGroup '" + Request.QueryString["id"] + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ViewState["Value"] == null)
                    {
                        dtEmployee = new DataTable("Value");
                        dtEmployee.Columns.Add(new DataColumn("ID", typeof(int)));
                        dtEmployee.Columns.Add(new DataColumn("id_attribute_group", typeof(string)));
                        dtEmployee.Columns.Add(new DataColumn("name", typeof(string)));
                        dtEmployee.Columns.Add(new DataColumn("id_attribute", typeof(string)));
                        dtEmployee.Columns.Add(new DataColumn("Attname", typeof(string)));
                        ViewState["Value"] = dtEmployee;
                    }
                    else
                    {
                        dtEmployee = (DataTable)ViewState["Value"];
                    }
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataSet ds3 = data.getDataSet("sp_GetCombnationGroupValue '" + Request.QueryString["id"] + "','" + ds.Tables[0].Rows[i]["id_attribute_group"].ToString() + "'");
                        for (int ii = 0; ii < ds3.Tables[0].Rows.Count; ii++)
                        {
                            DataRow dtRow = dtEmployee.NewRow();

                            dtRow["ID"] = Convert.ToInt32(1);
                            dtRow["id_attribute_group"] = ds3.Tables[0].Rows[ii]["id_attribute_group"].ToString();
                            dtRow["name"] = ds3.Tables[0].Rows[ii]["name"].ToString();
                            dtRow["id_attribute"] = ds3.Tables[0].Rows[ii]["id_attribute"].ToString(); 
                            dtRow["Attname"] = ds3.Tables[0].Rows[ii]["Value"].ToString(); 

                            dtEmployee.Rows.Add(dtRow);

                            ViewState["Value"] = dtEmployee;
                        }
                        
                        // }

                    }
                    repAtt.DataSource = ds;
                    repAtt.DataBind();
                }
            }
            else
            {
                Session["tab"] = "";
                Response.Redirect("Products.aspx");
            }
        }
    }
    public void fillAttributeGroup()
    {
        ds = gdate.GetAttributeGroup();
        repCat.DataSource = ds;
        repCat.DataBind();
    }

    protected void repCat_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater repSub = (Repeater)e.Item.FindControl("repSub");
            Label lblID = (Label)e.Item.FindControl("lblID");
            DataSet dsS = gdate.GetAttributeValue(lblID.Text);
            //HtmlInputCheckBox lnkAnchorRejection = (HtmlInputCheckBox)e.Item.FindControl("chk1");

            repSub.DataSource = dsS;
            repSub.DataBind();
        }
    }
    protected void repSub_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblID = (Label)e.Item.FindControl("lblID");
            //HtmlInputCheckBox lnkAnchorRejection = (HtmlInputCheckBox)e.Item.FindControl("chk1");
            //if (ViewState["PID"] != null || Request.QueryString["id"] != null)
            //{

            //    string sqCat = "select * from ps_category_product where IsDeleted=0 and id_category='" + lblID.Text + "' and id_product='" + Request.QueryString["id"].ToString() + "'";
            //    DataSet dsC = data.getDataSet(sqCat);
            //    if (dsC.Tables[0].Rows.Count > 0)
            //    {
            //        lnkAnchorRejection.Checked = true;
            //    }
            //    else
            //    {
            //        lnkAnchorRejection.Checked = false;
            //    }
            //}
        }
    }

    protected void btnAssociateSaveAnd_Click(object sender, EventArgs e)
    {
        //  SaveCombination();
        Save();
        Response.Redirect("addproduct.aspx?id=" + Request.QueryString["id"].ToString() + "#Combinations");
    }
    public void SaveCombination()
    {

        string id_product = Request.QueryString["id"].ToString();
        string ReferenceCode = txtreference.Text; string wholesale_price = "0.00";
        string Impacprice; string ImpactOrPrice; string Impweight; string ImpUnitunit = "";
        string MinQty = "0"; string AvaiDate = ""; string Default = "false";
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        if (repAtt.Items.Count > 0)
        {
            for (int i = 0; i < repAtt.Items.Count; i++)
            {
                //Label lblPID = (Label)repCat.Items[i].FindControl("lblID");
                //Label lblName = (Label)repCat.Items[i].FindControl("lblName");

                Repeater GRDInner = (Repeater)repAtt.Items[i].FindControl("repCombination");
                if (GRDInner.Items.Count > 0)
                {
                    for (int j = 0; j < GRDInner.Items.Count; j++)
                    {
                        Label lblAttId = (Label)GRDInner.Items[j].FindControl("lblAttId");
                        Label lblValueId = (Label)GRDInner.Items[j].FindControl("lblValueId");
                        TextBox txtprdPrice = (TextBox)GRDInner.Items[j].FindControl("txtprdPrice");
                        TextBox txtPrice = (TextBox)GRDInner.Items[j].FindControl("txtPrice");
                        TextBox txtWeight = (TextBox)GRDInner.Items[j].FindControl("txtWeight");
                        //  chk1.Checked = true;
                        if (j == 0)
                            Default = "true";

                        //                     ds = gdate.addCombination(id_product, ReferenceCode, wholesale_price, txtprdPrice.Text, "0", "0", txtWeight.Text,
                        //ImpUnitunit, Default, MinQty, AvaiDate, lblValueId.Text);
                        //                     if (ds.Tables[0].Rows.Count > 0)
                        //                     {
                        //                         if (ViewState["Value"] != null)
                        //                         {
                        //                             DataTable dtt = (DataTable)ViewState["Value"];
                        //                             if (dtt.Rows.Count > 0)
                        //                             {
                        //                                 DataRow[] results;
                        //                                 results = dtt.Select("id_attribute_group ='1'");
                        //                                 DataRow[] results2;
                        //                                 results2 = dtt.Select("id_attribute_group ='4'");
                        //                                 int size = results.Length;
                        //                                 int Q = results2.Length;
                        //                                 if (results.Length > 0)
                        //                                 {
                        //                                     dt.Rows.Clear();
                        //                                     dt = results.CopyToDataTable();
                        //                                     for (int ii = 0; ii < results.Length; ii++)
                        //                                     {
                        //                                         if (results2.Length > 0)
                        //                                         {
                        //                                             dt2.Rows.Clear();
                        //                                             dt2 = results2.CopyToDataTable();
                        //                                             for (int jj = 0; jj < results.Length; jj++)
                        //                                             {
                        //                                                 dt3 = (DataTable)ViewState["Value"];
                        //                                                 DataView view = new DataView(dt3);
                        //                                                 DataTable distinctValues = view.ToTable(true, "id_attribute_group", "name");
                        //                                                 int G = distinctValues.Rows.Count;
                        //                                                 for (int k = 0; k < G; k++)
                        //                                                 {
                        //                                                     DataRow[] results3;
                        //                                                     results3 = dt3.Select("id_attribute_group ='" + distinctValues.Rows[k]["id_attribute_group"] + "'");
                        //                                                     if (results3.Length > 0)
                        //                                                     {
                        //                                                         dt4.Rows.Clear();
                        //                                                         dt4 = results3.CopyToDataTable();

                        //                                                         // gdate.AttCombo(ds.Tables[0].Rows[0]["MaxId"].ToString(), dt2.Rows[jj]);
                        //                                                     }
                        //                                                 }

                        //                                             }
                        //                                         }
                        //                                     }

                        //                                 }


                        //                             }
                        //                         }

                        //                     }
                    }

                }
            }
        }


    }

    public void Save()
    {

        string ss = "Sp_DeleteAllCombination '" + Request.QueryString["id"] + "'";
        data.executeCommand(ss);
        dtEmployee = (DataTable)ViewState["Value"];
        DataView view = new DataView(dtEmployee);
        DataTable distinctValues = view.ToTable(true, "id_attribute_group", "name");
        DataTable dt3 = (DataTable)ViewState["Value"];
        string id_product = Request.QueryString["id"].ToString();
        string ReferenceCode = txtreference.Text; string wholesale_price = "0.00";
        string Impacprice = "0.00"; string ImpactOrPrice = "0.00"; string Impweight = "0.00"; string ImpUnitunit = "";
        string MinQty = "0"; string AvaiDate = ""; string Default = "false";
        int G = distinctValues.Rows.Count;
        for (int k = 0; k < G; k++)
        {
            DataRow[] results3;
            results3 = distinctValues.Select("id_attribute_group ='" + distinctValues.Rows[k]["id_attribute_group"] + "'");
            if (results3.Length > 0)
            {
                dt4.Rows.Clear();
                dt4 = results3.CopyToDataTable();
                DataRow[] results4;
                results4 = dt3.Select("id_attribute_group ='" + distinctValues.Rows[k]["id_attribute_group"] + "'");
                if (results4.Length > 0)
                {
                    //dt5.Rows[kk].Clear();
                    dt5 = results4.CopyToDataTable();
                    //ViewState["'" + dt4.Rows[0]["name"] + "'"] = dt5;
                    dt5.TableName = dt4.Rows[0]["name"].ToString();
                    ds.Tables.Add(dt5);
                }

                // gdate.AttCombo(ds.Tables[0].Rows[0]["MaxId"].ToString(), dt2.Rows[jj]);
            }
        }

        DataTable dt = (DataTable)ViewState["Comb"];
        List<string> s1;
        List<string> s2;
        List<string> s3;
        List<string> s4;
        List<string> s5;
        List<string> s6;
        List<string> s7;
        List<string> s8;
        int cc = ds.Tables.Count;
        List<string> lstRes = new List<string>();
        if (cc == 1)
        {
            s1 = ds.Tables[0].AsEnumerable().Select(x => x[3].ToString()).ToList();
           // s2 = ds.Tables[1].AsEnumerable().Select(x => x[3].ToString()).ToList();
            foreach (var item1 in s1)
            {
                lstRes.Add(item1 );
            }
        }
        if (cc == 2)
        {
            s1 = ds.Tables[0].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s2 = ds.Tables[1].AsEnumerable().Select(x => x[3].ToString()).ToList();
            foreach (var item1 in s1)
            {
                foreach (var item2 in s2)
                {
                    lstRes.Add(item1 + "," + item2);
                }
            }
        }
        if (cc == 3)
        {
            s1 = ds.Tables[0].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s2 = ds.Tables[1].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s3 = ds.Tables[2].AsEnumerable().Select(x => x[3].ToString()).ToList();
            foreach (var item1 in s1)
            {
                foreach (var item2 in s2)
                {
                    foreach (var item3 in s3)
                    {
                        lstRes.Add(item1 + "," + item2 + "," + item3);
                    }
                }
            }
        }
        if (cc == 4)
        {
            s1 = ds.Tables[0].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s2 = ds.Tables[1].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s3 = ds.Tables[2].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s4 = ds.Tables[3].AsEnumerable().Select(x => x[3].ToString()).ToList();
            foreach (var item1 in s1)
            {
                foreach (var item2 in s2)
                {
                    foreach (var item3 in s3)
                    {
                        foreach (var item4 in s4)
                        {
                            lstRes.Add(item1 + "," + item2 + "," + item3 + "," + item4);
                        }
                    }
                }
            }
        }
        if (cc == 5)
        {
            s1 = ds.Tables[0].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s2 = ds.Tables[1].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s3 = ds.Tables[2].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s4 = ds.Tables[3].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s5 = ds.Tables[4].AsEnumerable().Select(x => x[3].ToString()).ToList();
            foreach (var item1 in s1)
            {
                foreach (var item2 in s2)
                {
                    foreach (var item3 in s3)
                    {
                        foreach (var item4 in s4)
                        {
                            foreach (var item5 in s5)
                            {
                                lstRes.Add(item1 + "," + item2 + "," + item3 + "," + item4 + "," + item5);
                            }
                        }
                    }
                }
            }
        }
        if (cc == 6)
        {
            s1 = ds.Tables[0].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s2 = ds.Tables[1].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s3 = ds.Tables[2].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s4 = ds.Tables[3].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s5 = ds.Tables[4].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s6 = ds.Tables[5].AsEnumerable().Select(x => x[3].ToString()).ToList();
            foreach (var item1 in s1)
            {
                foreach (var item2 in s2)
                {
                    foreach (var item3 in s3)
                    {
                        foreach (var item4 in s4)
                        {
                            foreach (var item5 in s5)
                            {
                                foreach (var item6 in s6)
                                {
                                    lstRes.Add(item1 + "," + item2 + "," + item3 + "," + item4 + "," + item5 + "," + item6);
                                }
                            }
                        }
                    }
                }
            }
        }
        if (cc == 7)
        {
            s1 = ds.Tables[0].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s2 = ds.Tables[1].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s3 = ds.Tables[2].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s4 = ds.Tables[3].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s5 = ds.Tables[4].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s6 = ds.Tables[5].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s7 = ds.Tables[6].AsEnumerable().Select(x => x[3].ToString()).ToList();
            foreach (var item1 in s1)
            {
                foreach (var item2 in s2)
                {
                    foreach (var item3 in s3)
                    {
                        foreach (var item4 in s4)
                        {
                            foreach (var item5 in s5)
                            {
                                foreach (var item6 in s6)
                                {
                                    foreach (var item7 in s7)
                                    {
                                        lstRes.Add(item1 + "," + item2 + "," + item3 + "," + item4 + "," + item5 + "," + item6 + "," + item7);
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
        if (cc == 8)
        {
            s1 = ds.Tables[0].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s2 = ds.Tables[1].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s3 = ds.Tables[2].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s4 = ds.Tables[3].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s5 = ds.Tables[4].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s6 = ds.Tables[5].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s7 = ds.Tables[6].AsEnumerable().Select(x => x[3].ToString()).ToList();
            s8 = ds.Tables[7].AsEnumerable().Select(x => x[3].ToString()).ToList();
            foreach (var item1 in s1)
            {
                foreach (var item2 in s2)
                {
                    foreach (var item3 in s3)
                    {
                        foreach (var item4 in s4)
                        {
                            foreach (var item5 in s5)
                            {
                                foreach (var item6 in s6)
                                {
                                    foreach (var item7 in s7)
                                    {
                                        foreach (var item8 in s8)
                                        {
                                            lstRes.Add(item1 + "," + item2 + "," + item3 + "," + item4 + "," + item5 + "," + item6 + "," + item7 + "," + item8);
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
        int lst = lstRes.Count;
        for (int aa = 0; aa < lst; aa++)
        {
            if (aa == 0)
                Default = "true";
            else
                Default = "false";
            ds = gdate.addCombination(id_product, ReferenceCode, wholesale_price, "0.00", "0", "0", "0.00",
            ImpUnitunit, Default, MinQty, AvaiDate);
            if (ds.Tables[0].Rows.Count > 0)
            {

                String t = lstRes.ElementAt(aa).Trim();
                string[] values = t.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    string saa = values[i].Trim();
                    gdate.AttCombo(ds.Tables[0].Rows[0]["MaxId"].ToString(), saa);
                }

            }

        }
        if (repAtt.Items.Count > 0)
        {
            for (int i = 0; i < repAtt.Items.Count; i++)
            {

                Repeater GRDInner = (Repeater)repAtt.Items[i].FindControl("repCombination");
                if (GRDInner.Items.Count > 0)
                {
                    for (int j = 0; j < GRDInner.Items.Count; j++)
                    {
                        Label lblAttId = (Label)GRDInner.Items[j].FindControl("lblAttId");
                        Label lblValueId = (Label)GRDInner.Items[j].FindControl("lblValueId");
                        TextBox txtprdPrice = (TextBox)GRDInner.Items[j].FindControl("txtprdPrice");
                        TextBox txtPrice = (TextBox)GRDInner.Items[j].FindControl("txtPrice");
                        TextBox txtWeight = (TextBox)GRDInner.Items[j].FindControl("txtWeight");
                        gdate.AddAttribute(id_product, lblValueId.Text, "0.0", "0.00");
                    }

                }
            }
        }

    }
    private DataTable GetEmployee()
    {
        DataTable dtEmployee = null;
        if (ViewState["ID"] != null)
        {
            int ID = Convert.ToInt32((ViewState["ID"]));
            ID++;
            ViewState["ID"] = ID;
        }
        else
        {
            ViewState["ID"] = 1;
        }

        if (ViewState["Value"] == null)
        {
            dtEmployee = new DataTable("Value");
            dtEmployee.Columns.Add(new DataColumn("ID", typeof(int)));
            dtEmployee.Columns.Add(new DataColumn("id_attribute_group", typeof(string)));
            dtEmployee.Columns.Add(new DataColumn("name", typeof(string)));
            dtEmployee.Columns.Add(new DataColumn("id_attribute", typeof(string)));
            dtEmployee.Columns.Add(new DataColumn("Attname", typeof(string)));
            ViewState["Value"] = dtEmployee;
        }
        else
        {
            dtEmployee = (DataTable)ViewState["Value"];
        }
        if (repCat.Items.Count > 0)
        {
            for (int i = 0; i < repCat.Items.Count; i++)
            {
                Label lblPID = (Label)repCat.Items[i].FindControl("lblID");
                Label lblName = (Label)repCat.Items[i].FindControl("lblName");

                Repeater GRDInner = (Repeater)repCat.Items[i].FindControl("repSub");
                if (GRDInner.Items.Count > 0)
                {
                    for (int j = 0; j < GRDInner.Items.Count; j++)
                    {
                        Label lblValID = (Label)GRDInner.Items[j].FindControl("lblValID");
                        CheckBox chk1 = (CheckBox)GRDInner.Items[j].FindControl("chk1");
                        Label lblValueName = (Label)GRDInner.Items[j].FindControl("lblValueName");
                        //  chk1.Checked = true;
                        if (chk1.Checked == true)
                        {
                            DataTable dt = (DataTable)ViewState["Value"];
                            DataRow[] drows = dt.Select("id_attribute ='" + lblValID.Text + "'");
                            if (drows.Length == 0)
                            {
                                DataRow dtRow = dtEmployee.NewRow();

                                dtRow["ID"] = Convert.ToInt32(ViewState["ID"]);
                                dtRow["id_attribute_group"] = lblPID.Text;
                                dtRow["name"] = lblName.Text;
                                dtRow["id_attribute"] = lblValID.Text;
                                dtRow["Attname"] = lblValueName.Text;

                                dtEmployee.Rows.Add(dtRow);

                                ViewState["Value"] = dtEmployee;
                            }
                            //  return dtEmployee;
                        }
                    }

                }
            }
        }
        return dtEmployee;
    }
    public class Student
    {
        public int id_attribute { get; set; }
        // public string name { get; set; }
    }
    private static List<T> ConvertDataTable<T>(DataTable dt)
    {
        List<T> data = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            T item = GetItem<T>(row);
            data.Add(item);
        }
        return data;
    }
    private static T GetItem<T>(DataRow dr)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in dr.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    pro.SetValue(obj, dr[column.ColumnName], null);
                else
                    continue;
            }
        }
        return obj;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        if (ViewState["Comb"] == null)
        {
            dtcom = new DataTable("Comb");
            dtcom.Columns.Add(new DataColumn("id_attribute", typeof(int)));
            ViewState["Comb"] = dtcom;
        }
        else
        {
            dtcom = (DataTable)ViewState["Comb"];
        }

        dtEmployee = GetEmployee();

        if (ViewState["Value"] != null)
        {
            dtEmployee = (DataTable)ViewState["Value"];
            DataView view = new DataView(dtEmployee);
            DataTable distinctValues = view.ToTable(true, "id_attribute_group", "name");
            repAtt.DataSource = distinctValues;
            repAtt.DataBind();
        }
        else
        {
            repAtt.DataSource = null;
            repAtt.DataBind();
        }

        fillAttributeGroup();
    }

    protected void repAtt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataTable dt = new DataTable();
            DataTable dtEmployee = new DataTable();
            Repeater repSub = (Repeater)e.Item.FindControl("repCombination");
            Label lblId = (Label)e.Item.FindControl("lblId");
            if (ViewState["Value"] != null)
            {
                dtEmployee = (DataTable)ViewState["Value"];
                if (dtEmployee.Rows.Count > 0)
                {
                    DataRow[] results;
                    results = dtEmployee.Select("id_attribute_group ='" + lblId.Text + "'");
                    if (results.Length > 0)
                    {
                        dt.Rows.Clear();
                        dt = results.CopyToDataTable();
                    }
                    repSub.DataSource = dt;
                    repSub.DataBind();
                }

            }
            else
            {
                repSub.DataSource = null;
                repSub.DataBind();
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (ViewState["Value"] != null)
        {


            if (repCat.Items.Count > 0)
            {
                for (int ii = 0; ii < repCat.Items.Count; ii++)
                {
                    Label lblPID = (Label)repCat.Items[ii].FindControl("lblID");
                    Label lblName = (Label)repCat.Items[ii].FindControl("lblName");

                    Repeater GRDInner = (Repeater)repCat.Items[ii].FindControl("repSub");
                    if (GRDInner.Items.Count > 0)
                    {
                        for (int j = 0; j < GRDInner.Items.Count; j++)
                        {
                            Label lblValID = (Label)GRDInner.Items[j].FindControl("lblValID");
                            CheckBox chk1 = (CheckBox)GRDInner.Items[j].FindControl("chk1");
                            Label lblValueName = (Label)GRDInner.Items[j].FindControl("lblValueName");
                            //  chk1.Checked = true;
                            if (chk1.Checked == true)
                            {
                                DataTable dt = (DataTable)ViewState["Value"];
                                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                                {
                                    DataRow dr = dt.Rows[i];
                                    if (dr["id_attribute"].ToString() == lblValID.Text)
                                        dr.Delete();
                                }
                                dt.AcceptChanges();
                                ViewState["Value"] = dt;
                                DataView view = new DataView(dt);
                                DataTable distinctValues = view.ToTable(true, "id_attribute_group", "name");
                                repAtt.DataSource = distinctValues;
                                repAtt.DataBind();
                            }
                        }
                    }
                }
            }

            // dt.AcceptChanges();
        }
        fillAttributeGroup();
    }
}


using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;

public partial class CS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindGrid();
        }
    }

    private void BindGrid()
    {
        string query = "SELECT ID, NAME, POSITION FROM TEST ORDER BY POSITION";
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvLocations.DataSource = dt;
                        gvLocations.DataBind();
                    }
                }
            }
        }
    }

    protected void UpdatePreference(object sender, EventArgs e)
    {
        int[] locationIds = (from p in Request.Form["ID"].Split(',')
                             select int.Parse(p)).ToArray();
        int preference = 1;
        foreach (int locationId in locationIds)
        {
            this.UpdatePreference(locationId, preference);
            preference += 1;
        }

        Response.Redirect(Request.Url.AbsoluteUri);
    }

    private void UpdatePreference(int locationId, int preference)
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE TEST SET POSITION = @POSITION WHERE ID = @ID"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", locationId);
                    cmd.Parameters.AddWithValue("@POSITION", preference);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
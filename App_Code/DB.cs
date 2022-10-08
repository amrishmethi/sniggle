using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DB
/// </summary>
public class DB
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter adp;
    public DB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string GetConnectionString()
    {
        string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        return str;
    }
    public bool Exist(string sql)
    {
        bool flag;
        con = new SqlConnection(GetConnectionString());
        con.Open();
        cmd = new SqlCommand(sql, con);
        adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
            flag = true;
        else
            flag = false;
        return flag;
    }
    public void ExecuteData(string sql)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public int ExecuteData(SqlCommand sqlCommand)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        sqlCommand.Connection = con;
        int res = sqlCommand.ExecuteNonQuery();
        con.Close();
        return res;
    }
    public void ExecuteData(string Sp, string param1, string value1)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        int i = cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, long value1)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        int i = cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, string value1, string param2, string value2)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        int i = cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, string value1, string param2, DateTime value2)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        int i = cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, int value1, string param2, string value2)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, string value1, string param2, string value2, string param3, string value3)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        cmd.Parameters.AddWithValue(param3, value3);
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, int value1, string param2, int value2, string param3, string value3)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        cmd.Parameters.AddWithValue(param3, value3);
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, int value1, string param2, string value2, string param3, string value3)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        cmd.Parameters.AddWithValue(param3, value3);
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, string value1, string param2, string value2, string param3, string value3, string param4, string value4)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        cmd.Parameters.AddWithValue(param3, value3);
        cmd.Parameters.AddWithValue(param4, value4);
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, string value1, string param2, string value2, string param3, string value3, string param4, string value4, string param5, string value5)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        cmd.Parameters.AddWithValue(param3, value3);
        cmd.Parameters.AddWithValue(param4, value4);
        cmd.Parameters.AddWithValue(param5, value5);
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, int value1, string param2, string value2, string param3, string value3, string param4, string value4, string param5, string value5)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        cmd.Parameters.AddWithValue(param3, value3);
        cmd.Parameters.AddWithValue(param4, value4);
        cmd.Parameters.AddWithValue(param5, value5);
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, string value1, string param2, string value2, string param3, string value3, string param4, string value4, string param5, string value5, string param6, string value6)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        cmd.Parameters.AddWithValue(param3, value3);
        cmd.Parameters.AddWithValue(param4, value4);
        cmd.Parameters.AddWithValue(param5, value5);
        cmd.Parameters.AddWithValue(param6, value6);
        int i = cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, int value1, string param2, string value2, string param3, string value3, string param4, string value4, string param5, string value5, string param6, string value6)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        cmd.Parameters.AddWithValue(param3, value3);
        cmd.Parameters.AddWithValue(param4, value4);
        cmd.Parameters.AddWithValue(param5, value5);
        cmd.Parameters.AddWithValue(param6, value6);
        int i = cmd.ExecuteNonQuery();
        con.Close();


    }
    public void ExecuteData(string Sp, string param1, string value1, string param2, string value2, string param3, string value3, string param4, string value4, string param5, string value5, string param6, string value6, string param7, decimal value7, string param8, decimal value8)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(Sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue(param1, value1);
        cmd.Parameters.AddWithValue(param2, value2);
        cmd.Parameters.AddWithValue(param3, value3);
        cmd.Parameters.AddWithValue(param4, value4);
        cmd.Parameters.AddWithValue(param5, value5);
        cmd.Parameters.AddWithValue(param6, value6);
        cmd.Parameters.AddWithValue(param7, value7);
        cmd.Parameters.AddWithValue(param8, value8);
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public DataSet GetData(string sql)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        cmd = new SqlCommand(sql, con);
        adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        con.Close();
        return ds;
    }
    public DataSet GetDataset(string Sp, string param1, string value1)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlDataAdapter ad = new SqlDataAdapter();
        ad.SelectCommand = new SqlCommand();
        ad.SelectCommand.CommandText = Sp;
        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
        ad.SelectCommand.Connection = con;
        ad.SelectCommand.Parameters.Add(param1, value1);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        con.Close();
        return ds;

    }
    public DataSet GetDataset(string Sp, string param1, Int64 value1)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlDataAdapter ad = new SqlDataAdapter();
        ad.SelectCommand = new SqlCommand();
        ad.SelectCommand.CommandText = Sp;
        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
        ad.SelectCommand.Connection = con;
        ad.SelectCommand.Parameters.Add(param1, value1);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        con.Close();
        return ds;

    }
    public DataSet GetDataset(string Sp, string param1, string value1, string param2, string value2)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlDataAdapter ad = new SqlDataAdapter();
        ad.SelectCommand = new SqlCommand();
        ad.SelectCommand.CommandText = Sp;
        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
        ad.SelectCommand.Connection = con;
        ad.SelectCommand.Parameters.Add(param1, value1);
        ad.SelectCommand.Parameters.Add(param2, value2);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        con.Close();
        return ds;

    }
    public DataSet GetDataset(string Sp, string param1, string value1, string param2, string value2, string param3, string value3, string param4, string value4)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlDataAdapter ad = new SqlDataAdapter();
        ad.SelectCommand = new SqlCommand();
        ad.SelectCommand.CommandText = Sp;
        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
        ad.SelectCommand.Connection = con;
        ad.SelectCommand.Parameters.Add(param1, value1);
        ad.SelectCommand.Parameters.Add(param2, value2);
        ad.SelectCommand.Parameters.Add(param3, value3);
        ad.SelectCommand.Parameters.Add(param4, value4);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        con.Close();
        return ds;

    }
    public DataSet GetDataset(string Sp, string param1, string value1, string param2, string value2, string param3, string value3, string param4, string value4, string param5, string value5, string param6, string value6)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlDataAdapter ad = new SqlDataAdapter();
        ad.SelectCommand = new SqlCommand();
        ad.SelectCommand.CommandText = Sp;
        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
        ad.SelectCommand.Connection = con;
        ad.SelectCommand.Parameters.Add(param1, value1);
        ad.SelectCommand.Parameters.Add(param2, value2);
        ad.SelectCommand.Parameters.Add(param3, value3);
        ad.SelectCommand.Parameters.Add(param4, value4);
        ad.SelectCommand.Parameters.Add(param5, value5);
        ad.SelectCommand.Parameters.Add(param6, value6);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        con.Close();
        return ds;

    }
    public DataTable GetDataTable(string sql)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        cmd = new SqlCommand(sql, con);
        adp = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();
        adp.Fill(ds);
        con.Close();
        return ds;
    }
    public string ExecuteScalar(string sql)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        cmd = new SqlCommand(sql, con);
        //string[] str = new string[10];
        string str = Convert.ToString(cmd.ExecuteScalar());
        con.Close();
        return str;
    }
    public SqlDataReader datareader(string sql)
    {
        con = new SqlConnection(GetConnectionString());
        con.Open();
        cmd = new SqlCommand(sql, con);
        SqlDataReader sd = cmd.ExecuteReader();
        //string[] sd1=new string[10];
        //sd1 = Convert.(sd);

        //string[] str = new string[10];
        // string str = Convert.ToString(cmd.ExecuteScalar());
        // con.Close();
        return sd;
    }
    private static int DBNullCheckI(object p)
    {
        throw new NotImplementedException();
    }


}


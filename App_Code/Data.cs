using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
/// <summary>
/// Summary description for Data
/// </summary>
public sealed class Data
{
    public string conString;
    public string storeid;
    public string parentcat;
    SqlConnection sqlCon;
    SqlDataAdapter sqlAdp;
    SqlDataReader dr;
    SqlCommand cmd = new SqlCommand();
    DataSet ds;
    protected string QuickCost;
    public Data()
    {
        this.conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        this.sqlCon = new SqlConnection(conString);
    }

    public string GetConnectionString()
    {
        string str = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        return str;
    }

    public SqlDataReader getDataReader(string commandString)
    {
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        if (sqlCon.State == ConnectionState.Closed)
            sqlCon.Open();
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }

    public bool Exist(string commandString)
    {
        bool flag;
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        sqlCon.Open();
        dr = cmd.ExecuteReader();
        dr.Read();

        if (dr.HasRows)
            flag = true;
        else
            flag = false;

        dr.Close();
        sqlCon.Close();
        return flag;
    }

    public DataSet getDataSet(string commandString)
    {
        ds = new DataSet();
        sqlAdp = new SqlDataAdapter(commandString, sqlCon);
        sqlAdp.Fill(ds);
        return ds;
    }

    public DataSet getDataSet(SqlCommand command)
    {
        command.Connection = sqlCon;
        ds = new DataSet();
        sqlAdp = new SqlDataAdapter(command);
        sqlAdp.Fill(ds);
        return ds;
    }

    public int executeCommand(string commandString)
    {
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        int errStatus = 0;
        try
        {
            sqlCon.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            errStatus = 1;

        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public int executeCommand(string commandString, out string str)
    {
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        str = "";
        int errStatus = 0;
        try
        {
            sqlCon.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            errStatus = 1;
            str = ex.Message;
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public int executeCommand(SqlCommand sqlCommand)
    {
        sqlCommand.Connection = sqlCon;
        int errStatus = 0;
        try
        {
            sqlCon.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            string aa = ex.ToString();
            errStatus = 1;
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public int executeCommand(SqlCommand sqlCommand, out string str)
    {
        sqlCommand.Connection = sqlCon;
        int errStatus = 0;
        str = "";
        try
        {
            sqlCon.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            errStatus = 1;
            str = ex.Message;
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public int executeCommandP(SqlCommand sqlCommand)
    {
        sqlCommand.Connection = sqlCon;
        int errStatus = 0;
        try
        {
            sqlCon.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            AdminGetData getData = new AdminGetData();
            string aa = ex.ToString();
            errStatus = 1;
            getData.LogError(ex.Message.ToLower(), "product", "Product", ex.StackTrace.ToString());
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    Random rand = new Random();
    public string RandomString(int Size)
    {
        string input = "0123456789ABCDEFGH@#$%&";
        StringBuilder builder = new StringBuilder();
        char ch;
        for (int i = 0; i < Size; i++)
        {
            ch = input[rand.Next(0, input.Length)];
            builder.Append(ch);
        }
        return builder.ToString();
    }

    public string RandomOTP(int Size)
    {
        string input = "0123456789";
        StringBuilder builder = new StringBuilder();
        char ch;
        for (int i = 0; i < Size; i++)
        {
            ch = input[rand.Next(0, input.Length)];
            builder.Append(ch);
        }
        return builder.ToString();
    }

    public string ConvertDateTime(string str)
    {
        string dat = "";
        if (str != "")
        {
            string[] aa = str.Split('/');
            dat = aa[1] + "/" + aa[0] + "/" + aa[2];
        }
        return dat;
    }

}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

/// <summary>
/// Summary description for Sortable
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class Sortable : System.Web.Services.WebService
{
    [WebMethod]
    public bool UpdateItemsOrder(string itemOrder)
    {
        Collection<Item> items = new Collection<Item>();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //string connectionString =
        //        "Data Source=AM5/AM5; user id=sa; password=123;Initial Catalog=myearth_db;";

        using (SqlConnection connection = new SqlConnection(constr))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UpdateImagePosition";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserName = new SqlParameter("@position", SqlDbType.VarChar, 255);
                paramUserName.Value = itemOrder;
                command.Parameters.Add(paramUserName);
                connection.Open();
                return (command.ExecuteNonQuery() > 0);

            }
        }

    }

    [WebMethod]
    public bool UpdateAttributesOrder(string itemOrder)
    {
        Collection<Item> items = new Collection<Item>();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //string connectionString =
        //        "Data Source=AM5/AM5; user id=sa; password=123;Initial Catalog=myearth_db;";

        using (SqlConnection connection = new SqlConnection(constr))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UpdateAttributesOrder";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserName = new SqlParameter("@position", SqlDbType.VarChar, 255);
                paramUserName.Value = itemOrder;
                command.Parameters.Add(paramUserName);


                connection.Open();
                return (command.ExecuteNonQuery() > 0);

            }
        }

    }

    [WebMethod]
    public bool UpdatefeatureOrder(string itemOrder)
    {
        Collection<Item> items = new Collection<Item>();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //string connectionString =
        //        "Data Source=AM5/AM5; user id=sa; password=123;Initial Catalog=myearth_db;";

        using (SqlConnection connection = new SqlConnection(constr))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UpdatefeatureOrder";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserName = new SqlParameter("@position", SqlDbType.VarChar, 255);
                paramUserName.Value = itemOrder;
                command.Parameters.Add(paramUserName);


                connection.Open();
                return (command.ExecuteNonQuery() > 0);

            }
        }

    }
    [WebMethod]
    public bool UpdateAttValueOrder(string itemOrder)
    {
        AdminGetData getData = new AdminGetData();
        getData.UpdateAttValuePosition(itemOrder);
        //Collection<Item> items = new Collection<Item>();
        //string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //using (SqlConnection connection = new SqlConnection(constr))
        //{
        //    using (SqlCommand command = new SqlCommand())
        //    {
        //        command.Connection = connection;
        //        command.CommandText = "UpdateAttValueOrder";
        //        command.CommandType = CommandType.StoredProcedure;

        //        SqlParameter paramUserName = new SqlParameter("@position", SqlDbType.NVarChar, 8000);
        //        paramUserName.Value = itemOrder;
        //        command.Parameters.Add(paramUserName);


        //        connection.Open();
        //        return (command.ExecuteNonQuery() > 0);

        //    }
        //}
        bool ss = true;
        return ss;
    }
    [WebMethod]
    public bool UpdateCategoryOrder(string itemOrder)
    {
        Collection<Item> items = new Collection<Item>();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //string connectionString =
        //        "Data Source=AM5/AM5; user id=sa; password=123;Initial Catalog=myearth_db;";

        using (SqlConnection connection = new SqlConnection(constr))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UpdateCategoryOrder";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserName = new SqlParameter("@position", SqlDbType.VarChar, 255);
                paramUserName.Value = itemOrder;
                command.Parameters.Add(paramUserName);


                connection.Open();
                return (command.ExecuteNonQuery() > 0);

            }
        }

    }
    [WebMethod]
    public bool UpdateCmsOrder(string itemOrder)
    {
        Collection<Item> items = new Collection<Item>();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //string connectionString =
        //        "Data Source=AM5/AM5; user id=sa; password=123;Initial Catalog=myearth_db;";

        using (SqlConnection connection = new SqlConnection(constr))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UpdateCmsOrder";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserName = new SqlParameter("@position", SqlDbType.VarChar, 255);
                paramUserName.Value = itemOrder;
                command.Parameters.Add(paramUserName);


                connection.Open();
                return (command.ExecuteNonQuery() > 0);

            }
        }

    }
    [WebMethod]
    public bool UpdateCreativeCut(string itemOrder)
    {
        Collection<Item> items = new Collection<Item>();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //string connectionString =
        //        "Data Source=AM5/AM5; user id=sa; password=123;Initial Catalog=myearth_db;";

        using (SqlConnection connection = new SqlConnection(constr))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UpdateCreativeCut";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserName = new SqlParameter("@position", SqlDbType.VarChar, 255);
                paramUserName.Value = itemOrder;
                command.Parameters.Add(paramUserName);
                connection.Open();
                return (command.ExecuteNonQuery() > 0);

            }
        }

    }
    [WebMethod]
    public bool UpdateFilterPosition(string itemOrder)
    {
        Collection<Item> items = new Collection<Item>();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //string connectionString =
        //        "Data Source=AM5/AM5; user id=sa; password=123;Initial Catalog=myearth_db;";

        using (SqlConnection connection = new SqlConnection(constr))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UpdateFilterPosition";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUserName = new SqlParameter("@position", SqlDbType.VarChar, 255);
                paramUserName.Value = itemOrder;
                command.Parameters.Add(paramUserName);


                connection.Open();
                return (command.ExecuteNonQuery() > 0);

            }
        }

    }
}

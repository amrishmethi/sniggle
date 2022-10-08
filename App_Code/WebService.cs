using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string  getProdDtl(string SKU)
    {
        NData nData = new NData();
        DataTable dt = new DataTable();
        dt = nData.GetProdDtlApi(SKU);
        string jsonstring1 = string.Empty;
        jsonstring1 = JsonConvert.SerializeObject(dt);
        //JArray JA = new JArray();
        //JA = JArray.Parse(jsonstring1);
        //return JA; 
        //JArray JA = new JArray();
        //JA = JArray.Parse(dt);
         return jsonstring1;
    }

    [WebMethod]
    public JArray getProdDtlN(string SKU)
    {
        NData nData = new NData();
        string dd = nData.GetProdDtlApiNew(SKU);
        JArray JA = new JArray();
        JA = JArray.Parse(dd);
        return JA;
    }

}

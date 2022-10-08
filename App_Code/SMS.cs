using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public class SMS
{

    public string SendSMS(string Mobile, string Msg)
    {
        try
        {
            string stringResult = null;

            string url = "http://prosms.sssms.co.in/sendsms.jsp?user=compusft&password=8d1257f5beXX&mobiles=" + Mobile + "&sms=" + Msg + "&senderid=SSCOMP";

          //  string url = "http://prosms.sssms.co.in/sendsms.jsp?user=compusft&password=8d1257f5beXX&&senderid=SABKAF&mobiles=" + Mobile + "&sms=" + Msg + "";

            WebRequest request = WebRequest.Create(
              url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
            return (stringResult);
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
        finally
        {


        }
    }

}







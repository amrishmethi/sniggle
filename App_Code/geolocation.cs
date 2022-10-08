using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for geolocation
/// </summary>
public class geolocation
{
	public geolocation()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private struct GeoIPResponse
    {
        //this is the response I get
        //{"IP":"127.0.0.1","continentCode":"Unknown","continentName":"Unknown",
        //"countryCode2":"Unknown","COUNTRY":"Unknown","countryCode3":"Unknown","countryName":"Unknown","regionName":"Unknown",
        //"cityName":"Unknown","cityLatitude":0,"cityLongitude":0,"countryLatitude":0,"countryLongitude":0,"localTimeZone":"Unknown",
        //"localTime":"0"}
        public string IP;
        public string continentCode;
        public string continentName;
        public string countryCode2;
        public string COUNTRY;
        public string countryCode3;
        public string countryName;
        public string regionName;
        public string cityName;
        public string cityLatitude;
        public string cityLongitude;
        public string countryLatitude;
        public string countryLongitude;
        public string localTimeZone;
        public string localTime;
    }
    /*
    then I defined some needful methods: 
    */

    /// <summary>
    /// Returns Client Ip Address
    /// </summary>
    static public string ClientIpAddress
    {
        get
        {
            string _clientIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(_clientIPAddress))
            {
                string[] ipRange = _clientIPAddress.Split(',');
                _clientIPAddress = ipRange[ipRange.Length - 1];
            }
            else
            {
                _clientIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return _clientIPAddress;
        }

    }

    public string _WebRequest(string strURL)
    {
        String strResult;
        WebResponse objResponse;
        WebRequest objRequest = HttpWebRequest.Create(strURL);
        objRequest.Method = "GET";

        objResponse = objRequest.GetResponse();
        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        {
            strResult = sr.ReadToEnd();
            sr.Close();
        }
        return strResult;

    }
}

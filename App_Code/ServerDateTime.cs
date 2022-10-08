using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ServerDateTime
/// </summary>
public static class ServerDateTime
{
    //public ServerDateTime()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public static string getTodayDateTimeStr()
    {
        string str;


        /////str = DateTime.Now.AddHours(11.51).ToString();

        str = GetDate.Now.ToString();

        return str;
    }
    public static string getTodayDate()
    {
        string strDt;

        //////DateTime todayDt = DateTime.Now.AddHours(11.51);
        DateTime todayDt = GetDate.Now;
        strDt = todayDt.ToShortDateString();
        return strDt;
    }

    public static string getCurrentTime()
    {

        string timestr;

        //////timestr = DateTime.Now.AddHours(11.51).ToShortTimeString();
        timestr = GetDate.Now.ToShortTimeString();
        return timestr;
    }
    public static DateTime getTodayDateTime()
    {
        DateTime todayDt;

        //////// todayDt = DateTime.Now.AddHours(11.51);
        todayDt = GetDate.Now;

        return todayDt;

    }

    public static class GetDate
    {
        public static DateTime Now
        {
            get
            {
                return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(System.DateTime.Now,
                    TimeZoneInfo.Local.Id, "India Standard Time");
            }
        }
    }
}
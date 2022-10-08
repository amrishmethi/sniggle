using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for user
/// </summary>
public class user
{
    string _userId;
    string _LoginId;
    string _userType;
    string _emailId;
    string _password;
	public user()
	{
	}

    public string UserId
    {
        get { return _userId; }
        set { _userId = value; }
    }

    public string LoginId
    {
        get { return _LoginId; }
        set { _LoginId = value; }
    }

    public string UserType
    {
        get { return _userType; }
        set { _userType = value; }
    }

    public string EmailId
    {
        get { return _emailId; }
        set { _emailId = value; }
    }

    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

}

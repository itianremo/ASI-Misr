using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for BaseClassWS
/// </summary>
public class BaseClassWS : System.Web.Services.WebService
{
	public BaseClassWS()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public bool IsAuthenticated
	{
		get
		{
            if (Session != null)
            {
                object state = Session["IsAuthenticated"];
                if (state != null)
                {
                    return (bool)state;
                } 
            }
			//Must be first request in session
			IsAuthenticated = false;
			return false;
		}
		set
		{
			Session["IsAuthenticated"] = value;
		}
	}

    internal enum ViewRole
    {
        ViewAccount,
        ViewContact
    }

	[WebMethod(EnableSession = true)]
    internal bool LogIn(string userName, string password, ViewRole viewRole)
	{
		bool authenticated = false;
		Office.DAL.SecurityUserLogin SUL = new Office.DAL.SecurityUserLogin();
		SUL.UserName = Cryption.Decrypt(userName);
		SUL.Password = Cryption.Decrypt(password);
		if (SUL.GetUserData())
		{
			if (SUL.Active == true)
			{
                switch (viewRole)
                {
                    case ViewRole.ViewAccount:
                        if (SUL.GetUserRoles().Contains("ViewAccount"))
                            authenticated = true;
                        break;
                    case ViewRole.ViewContact:
                        if (SUL.GetUserRoles().Contains("ViewContact"))
                            authenticated = true;
                        break;
                    default:
                        break;
                }
			}
		}
		
		IsAuthenticated = authenticated;
		return authenticated;
	}

    [WebMethod(EnableSession = true)]
    public bool LogIn(string userName, string password)
    {
        bool authenticated = false;
        Office.DAL.SecurityUserLogin SUL = new Office.DAL.SecurityUserLogin();
        SUL.UserName = Cryption.Decrypt(userName);
        SUL.Password = Cryption.Decrypt(password);
        if (SUL.GetUserData())
        {
            if (SUL.Active == true)
            {
                authenticated = true;
                Session["UserID"] = SUL.UserID;
            }
        }

        IsAuthenticated = authenticated;
        return authenticated;
    }

	[WebMethod(EnableSession = true)]
	public void LogOut()
	{
		IsAuthenticated = false;
	}

}
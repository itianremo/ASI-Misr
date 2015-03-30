using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

/// <summary>
/// Summary description for ASIIdentity
/// </summary>
public class ASIIdentity : IIdentity
{
	private System.Web.Security.FormsAuthenticationTicket ticket;

	public ASIIdentity(System.Web.Security.FormsAuthenticationTicket ticket)
	{
		this.ticket = ticket;
	}

	#region IIdentity Members

	string IIdentity.AuthenticationType
	{
		get { return "ASIAuthentication"; }
	}

	bool IIdentity.IsAuthenticated
	{
		get { return true; }
	}

	string IIdentity.Name
	{
		get { return ticket.Name; }
	}

	

	public int UserID
	{
		get
		{
			string[] data = ticket.UserData.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
			if (data.Length > 0)
				return int.Parse(data[0]);
			else
				return -1;
		}
	}

	public int AccountabilityID
	{
		get
		{
			string[] data = ticket.UserData.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
			if (data.Length > 0)
				return int.Parse(data[1]);
			else
				return -1;
		}
	}

	public string Email
	{
		get
		{
			string[] data = ticket.UserData.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
			if (data.Length > 0)
				return data[2];
			else
				return "";
		}
	}

	public string[] Roles
	{
		get
		{
			string[] data = ticket.UserData.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
			if (data.Length > 1)
			{
				string[] roles = data[3].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				return roles;
			}
			else
				return new string[] { "User" };
		}
	}


	#endregion
}
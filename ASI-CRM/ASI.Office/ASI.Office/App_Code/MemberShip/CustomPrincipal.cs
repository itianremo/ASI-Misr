using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Data;

/// <summary>
/// Summary description for CustomPrincipal
/// </summary>
public class CustomPrincipal : IPrincipal
{
	private IIdentity _identity;
	private string[] _roles;
	private bool _active;
	private Office.DAL.SecurityUserLogin _sul;
	private int _UserId;


	//public CustomPrincipal(IIdentity identity,int UserID,Office.DAL.SecurityUserLogin SUL, string[] roles)
		public CustomPrincipal(IIdentity identity, string[] roles)
	{
		_identity = identity;
		//_UserId = UserID;
		//_active = Active;
		//_sul = SUL;
		_roles = new string[roles.Length];
		roles.CopyTo(_roles, 0);
		Array.Sort(_roles);
	}


	#region IPrincipal Members

	IIdentity IPrincipal.Identity
	{
		get { return _identity; }
	}
	public bool Active { get { return _active; } }

	public int UserID { get {return _UserId ;} }

	public bool IsAdministrator { get { return IsInRole("Administrator"); } }

	public Office.DAL.SecurityUserLogin UserLogin { get { return _sul; } }

	public bool IsInRole(string role)
	{
		return Array.BinarySearch(_roles, role) >= 0 ? true : false;

	}
	// Checks whether a principal is in all of the specified set of roles
	public bool IsInAllRoles(params string[] roles)
	{
		foreach (string searchrole in roles)
		{
			if (Array.BinarySearch(_roles, searchrole) < 0)
				return false;
		}
		return true;
	}
	// Checks whether a principal is in any of the specified set of roles
	public bool IsInAnyRoles(params string[] roles)
	{
		foreach (string searchrole in roles)
		{
			if (Array.BinarySearch(_roles, searchrole) > 0)
				return true;
		}
		return false;
	}

    /// <summary>
    /// Check if this user is Account Manager or not
    /// Fill in the UserID property first before calling the function
    /// </summary>
    /// <returns>True if the user is account manager, false otherwise</returns>
    public bool IsAccountManagerUser()
    {
        return _sul.IsAccountManagerUser();
    }
	#endregion
}
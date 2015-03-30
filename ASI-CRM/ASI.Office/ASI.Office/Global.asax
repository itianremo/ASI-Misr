<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<script RunAt="server">
	
	protected void Application_AuthenticateRequest(object sender, EventArgs e)
	{
		HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
		if (authCookie != null)
		{
			string encTicket = authCookie.Value;
			if (!String.IsNullOrEmpty(encTicket))
			{
				FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encTicket);
				ASIIdentity id = new ASIIdentity(ticket);
				CustomPrincipal prin = new CustomPrincipal(id, id.Roles);
				HttpContext.Current.User = prin;
			}
		}
	}


	void Application_Start(object sender, EventArgs e)
	{
		// Code that runs on application startup		
	}

	void Application_End(object sender, EventArgs e)
	{
		//  Code that runs on application shutdown
	}

	void Application_Error(object sender, EventArgs e)
	{
		// Code that runs when an unhandled error occurs
	}

	void Session_Start(object sender, EventArgs e)
	{
		// Code that runs when a new session is started		
	}

	void Session_End(object sender, EventArgs e)
	{
		// Code that runs when a session ends. 
		// Note: The Session_End event is raised only when the sessionstate mode
		// is set to InProc in the Web.config file. If session mode is set to StateServer 
		// or SQLServer, the event is not raised.
	}
       
</script>

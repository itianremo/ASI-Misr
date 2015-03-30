<%@ Application Language="C#" %>

<script runat="server">

    static void DoDailyAction(object obj)
    {
        DeleteExpiredUsersBricksRels();
    }

    static void DeleteExpiredUsersBricksRels()
    {
        dsRel_Bricks_UsersTableAdapters.daRel_Bricks_Users da = new dsRel_Bricks_UsersTableAdapters.daRel_Bricks_Users();
        da.DeleteExpiredRelBricksUsers();
        da.Dispose();
    }
    
    void Application_Start(object sender, EventArgs e) 
    {
        //Do this function[on server] for the first load, then repeat it every day
        DoDailyAction(null);
        
        int h = (23 - DateTime.Now.Hour);
        int m = (60 - DateTime.Now.Minute);
        int s = (60 - DateTime.Now.Second);
        int DueTime = h * m * s * 1000;
        
        System.Threading.Timer t =
            new System.Threading.Timer(new System.Threading.TimerCallback(DoDailyAction), null, DueTime, 1000 * 60 * 60 * 24);
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

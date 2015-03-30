using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Global
/// </summary>
public partial class Global : System.Web.HttpApplication
{
	public Global()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static void DoDailyAction(object obj)
    {
        DeleteExpiredUsersBricksRels();
        ApplyAutomaticCommitForFMTPlans();
    }

    static void DeleteExpiredUsersBricksRels()
    {
        dsRel_Bricks_UsersTableAdapters.daRel_Bricks_Users da = new dsRel_Bricks_UsersTableAdapters.daRel_Bricks_Users();
        da.DeleteExpiredRelBricksUsers();
        da.Dispose();
    }

    static void ApplyAutomaticCommitForFMTPlans()
    {
        DateTime CheckDate = DateTime.Today.AddDays(-2);
        //DateTime CheckDate = new DateTime(2011, 4, 25).AddDays(-2);
        DateTime StartDateOfCurrentWeek = StartDayOfWeek(DateTime.Today, Pharma.BMD.BLL.MasterClass.ApplicationDayOfWeek.Saturday);
        if (StartDateOfCurrentWeek == CheckDate)
        {
            dsPlansTableAdapters.daPlans da = new dsPlansTableAdapters.daPlans();
            da.AutomaticCommittWeekPlan(StartDateOfCurrentWeek);
            da.Dispose();
        }
    }

    static DateTime StartDayOfWeek(DateTime date, Pharma.BMD.BLL.MasterClass.ApplicationDayOfWeek startDay)
    {

        if (date.DayOfWeek >= Pharma.BMD.BLL.MasterClass.ApplicationToSystemDay(startDay))

            return date.AddDays((int)Pharma.BMD.BLL.MasterClass.ApplicationDayOfWeek.Saturday - (int)Pharma.BMD.BLL.MasterClass.SystemToApplicationDay(date.DayOfWeek));

        else

            return date.AddDays(7 - (int)Pharma.BMD.BLL.MasterClass.ApplicationDayOfWeek.Saturday - (int)Pharma.BMD.BLL.MasterClass.SystemToApplicationDay(date.DayOfWeek));

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
}
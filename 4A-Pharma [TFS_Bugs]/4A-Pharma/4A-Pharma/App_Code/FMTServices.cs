using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;


/// <summary>
/// Summary description for FMTServices
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class FMTServices : System.Web.Services.WebService {

    public FMTServices () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    private enum ApplicationDayOfWeek
    {
        Saturday = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6
    }

    private DayOfWeek ApplicationToSystemDay(ApplicationDayOfWeek Day)
    {
        switch (Day)
        {
            case ApplicationDayOfWeek.Saturday:
                return DayOfWeek.Sunday;
            case ApplicationDayOfWeek.Sunday:
                return DayOfWeek.Monday;
            case ApplicationDayOfWeek.Monday:
                return DayOfWeek.Tuesday;
            case ApplicationDayOfWeek.Tuesday:
                return DayOfWeek.Wednesday;
            case ApplicationDayOfWeek.Wednesday:
                return DayOfWeek.Thursday;
            case ApplicationDayOfWeek.Thursday:
                return DayOfWeek.Friday;
            case ApplicationDayOfWeek.Friday:
                return DayOfWeek.Saturday;
            default:
                return DayOfWeek.Saturday;
        }
    }

    private ApplicationDayOfWeek SystemToApplicationDay(DayOfWeek Day)
    {
        switch (Day)
        {
            case DayOfWeek.Friday:
                return ApplicationDayOfWeek.Friday;
            case DayOfWeek.Monday:
                return ApplicationDayOfWeek.Monday;
            case DayOfWeek.Saturday:
                return ApplicationDayOfWeek.Saturday;
            case DayOfWeek.Sunday:
                return ApplicationDayOfWeek.Sunday;
            case DayOfWeek.Thursday:
                return ApplicationDayOfWeek.Thursday;
            case DayOfWeek.Tuesday:
                return ApplicationDayOfWeek.Tuesday;
            case DayOfWeek.Wednesday:
                return ApplicationDayOfWeek.Wednesday;
            default:
                return ApplicationDayOfWeek.Saturday;
        }
    }

    [WebMethod]
    public DataSet CallSpecificFunction(string FunctionData)
    {
        DataSet ds;
        //string FunctionData = "";
        string[] parameter = FunctionData.Split(',');
        string funName = parameter[0].Trim();

        try
        {
            switch (funName)
            {
                case "UserVisits":
                    parameter[1] = parameter[1].Trim();
                    IFormatProvider IFP = new System.Globalization.CultureInfo("en-us");
                    DateTime StartDate;

                    try
                    {
                        if (parameter[1].Length > 0)
                            StartDate = Convert.ToDateTime(parameter[1].Trim(), IFP);
                        else
                        {
                            StartDate = StartDayOfWeek(DateTime.Today, ApplicationDayOfWeek.Saturday);
                        }
                    }
                    catch
                    {
                        StartDate = StartDayOfWeek(DateTime.Today, ApplicationDayOfWeek.Saturday);
                    }


                    parameter[2] = parameter[2].Trim();
                    DateTime EndDate;

                    try
                    {
                        if (parameter[2].Length > 0)
                            EndDate = Convert.ToDateTime(parameter[2].Trim(), IFP);
                        else
                            EndDate = StartDate.AddDays(6);
                    }
                    catch
                    {
                        EndDate = StartDate.AddDays(6);
                    }


                    parameter[3] = parameter[3].Trim();
                    int EmpID;

                    try
                    {
                        if (parameter[3].Length > 0)
                            EmpID = Convert.ToInt32(parameter[3].Trim());
                        else
                            EmpID = new Pharma.BMD.BLL.ManageUsersBLL().SelectNormalUsers()[0].EmpID;
                    }
                    catch
                    {
                        EmpID = new Pharma.BMD.BLL.ManageUsersBLL().SelectNormalUsers()[0].EmpID;
                    }


                    ds = new Pharma.FMT.BLL.PlansBLL().GetUserVisits(StartDate.Date, EndDate.Date, EmpID);
                    break;

                case "VisitsAnnual":

                    DateTime YearStart = new DateTime(DateTime.Today.Year, 1, 1);
                    DateTime YearEnd = new DateTime(DateTime.Today.Year, 12, 31);

                    int EmpID1;

                    try
                    {
                        if (parameter[1].Length > 0)
                        {
                            EmpID1 = Convert.ToInt32(parameter[1].Trim());
                            if(EmpID1 <= 0)
                                EmpID1 = new Pharma.BMD.BLL.ManageUsersBLL().SelectNormalUsers()[0].EmpID;
                        }
                        else
                            EmpID1 = new Pharma.BMD.BLL.ManageUsersBLL().SelectNormalUsers()[0].EmpID;
                    }
                    catch
                    {
                        EmpID1 = new Pharma.BMD.BLL.ManageUsersBLL().SelectNormalUsers()[0].EmpID;
                    }
                    
                    dsEmployees.dtEmployeesDataTable dt = new Pharma.BMD.BLL.ManageUsersBLL().SelectEmployeeByID(EmpID1, false);
                    
                    string EmpName = dt[0].EmpName;
                    string UserName = dt[0].UserName;

                    ds = new Pharma.BMD.BLL.MasterClass().GetAnnualVisitsReport(EmpName, UserName, YearStart, YearEnd);
                    break;

                case "SamplesConsumed":
                    parameter[1] = parameter[1].Trim();
                    IFormatProvider IFP2 = new System.Globalization.CultureInfo("en-us");
                    DateTime StartDate2;

                    try
                    {
                        if (parameter[1].Length > 0)
                            StartDate2 = Convert.ToDateTime(parameter[1].Trim(), IFP2);
                        else
                        {
                            StartDate2 = StartDayOfWeek(DateTime.Today, ApplicationDayOfWeek.Saturday);
                        }
                    }
                    catch
                    {
                        StartDate2 = StartDayOfWeek(DateTime.Today, ApplicationDayOfWeek.Saturday);
                    }


                    parameter[2] = parameter[2].Trim();
                    DateTime EndDate2;

                    try
                    {
                        if (parameter[2].Length > 0)
                            EndDate2 = Convert.ToDateTime(parameter[2].Trim(), IFP2);
                        else
                            EndDate2 = StartDate2.AddDays(6);
                    }
                    catch
                    {
                        EndDate2 = StartDate2.AddDays(6);
                    }


                    parameter[3] = parameter[3].Trim();
                    int EmpID2;

                    try
                    {
                        if (parameter[3].Length > 0)
                        {
                            EmpID2 = Convert.ToInt32(parameter[3].Trim());
                            if (EmpID2 <= 0)
                                EmpID2 = new Pharma.BMD.BLL.ManageUsersBLL().SelectNormalUsers()[0].EmpID;
                        }
                        else
                            EmpID2 = new Pharma.BMD.BLL.ManageUsersBLL().SelectNormalUsers()[0].EmpID;
                    }
                    catch
                    {
                        EmpID2 = new Pharma.BMD.BLL.ManageUsersBLL().SelectNormalUsers()[0].EmpID;
                    }

                    string EmpName2 = (new Pharma.BMD.BLL.ManageUsersBLL().SelectEmployeeByID(EmpID2, false))[0].EmpName;

                    ds = new Pharma.BMD.BLL.MasterClass().GetSamplesConsumedReport(EmpName2, EmpID2, StartDate2.Date, EndDate2.Date);
                    break;

                case "AccompaniedVisits":
                    parameter[1] = parameter[1].Trim();
                    IFormatProvider IFP3 = new System.Globalization.CultureInfo("en-us");
                    DateTime StartDate3;

                    try
                    {
                        if (parameter[1].Length > 0)
                            StartDate3 = Convert.ToDateTime(parameter[1].Trim(), IFP3);
                        else
                        {
                            StartDate3 = StartDayOfWeek(DateTime.Today, ApplicationDayOfWeek.Saturday);
                        }
                    }
                    catch
                    {
                        StartDate3 = StartDayOfWeek(DateTime.Today, ApplicationDayOfWeek.Saturday);
                    }


                    parameter[2] = parameter[2].Trim();
                    DateTime EndDate3;

                    try
                    {
                        if (parameter[2].Length > 0)
                            EndDate3 = Convert.ToDateTime(parameter[2].Trim(), IFP3);
                        else
                            EndDate3 = StartDate3.AddDays(6);
                    }
                    catch
                    {
                        EndDate3 = StartDate3.AddDays(6);
                    }

                    ds = new Pharma.BMD.BLL.MasterClass().GetAccompaniedVisitsReport(StartDate3.Date, EndDate3.Date);
                    break;

                case "AvarageDailyCalls":

                    parameter[1] = parameter[1].Trim();
                    IFormatProvider IFP4 = new System.Globalization.CultureInfo("en-us");
                    DateTime StartDate4;

                    try
                    {
                        if (parameter[1].Length > 0)
                            StartDate4 = Convert.ToDateTime(parameter[1].Trim(), IFP4);
                        else
                        {
                            StartDate4 = StartDayOfWeek(DateTime.Today, ApplicationDayOfWeek.Saturday);
                        }
                    }
                    catch
                    {
                        StartDate4 = StartDayOfWeek(DateTime.Today, ApplicationDayOfWeek.Saturday);
                    }


                    parameter[2] = parameter[2].Trim();
                    DateTime EndDate4;

                    try
                    {
                        if (parameter[2].Length > 0)
                            EndDate4 = Convert.ToDateTime(parameter[2].Trim(), IFP4);
                        else
                            EndDate4 = StartDate4.AddDays(6);
                    }
                    catch
                    {
                        EndDate4 = StartDate4.AddDays(6);
                    }

                    ds = new Pharma.BMD.BLL.MasterClass().GetAvarageDailyCallsReport(StartDate4.Date, EndDate4.Date);
                    break;

                default:
                    ds = null;
                    break;
            }
        }
        catch
        {
            ds = null;
            //throw Ex;
        }

        //System.IO.File.WriteAllText(Server.MapPath("") + "/Params.txt", FunctionData);
        //ds.WriteXml(Server.MapPath("") + "/WsOutput.xml");

        return ds;
    }

    private DateTime StartDayOfWeek(DateTime date, ApplicationDayOfWeek startDay)
    {
        if (date.DayOfWeek >= ApplicationToSystemDay(startDay))
            return date.AddDays((int)ApplicationDayOfWeek.Saturday - (int)SystemToApplicationDay(date.DayOfWeek));
        else
            return date.AddDays(7 - (int)ApplicationDayOfWeek.Saturday - (int)SystemToApplicationDay(date.DayOfWeek));

    }

}


using System;
using System.Web.UI;
using System.Collections;
using System.Xml;
using System.Data;
using System.IO; 
using System.Xml.Serialization;

namespace ReportWriter
{
	/// <summary>
	/// Summary description for ReportHandler.
	/// </summary>
	public class ReportHandler
    {
        #region Variables
        public Hashtable ApplicationInfo = new Hashtable();
        string error;
        XmlDocument XmlDoc = new XmlDocument() ;
        ArrayList tablesNames = new ArrayList();

        #endregion 

        #region Constructor

        public ReportHandler()
		{
           
			//
			// TODO: Add constructor logic here
			//
        }
        #endregion 

        #region Methods

        #region LoadXMlFile

        private string LoadXMlFile(string FileName)
        {
            string xmlFile = "";

            try
            {
                XmlDoc.Load(FileName);
                xmlFile = XmlDoc.OuterXml;
              
            }
            catch (Exception ee)
            {
                error = ee.Message;
            }
            return xmlFile;
        }

        #endregion

        #region Load Drop DownList With Fields

        public bool LoadDropDownWithFields( System.Web.UI.WebControls.DropDownList drpDwnList , string fileName )
        {
            try
            {
                DataSet dsXmlData = new DataSet();
                string XML = LoadXMlFile(fileName);
                StringReader sr = new StringReader(XML);
                dsXmlData.ReadXml(sr);
                drpDwnList.Items.Clear();

                if (dsXmlData.Tables.Count != 0)
                {
                    foreach (DataRow row in dsXmlData.Tables[0].Rows)
                    {
                        drpDwnList.Items.Add(row.ItemArray[0].ToString());
                    }
                }
            }

            catch (Exception ee)
            {
                error = ee.Message;
            }

            return true;
        }
        #endregion

        #region Load Drop Down With Operator List

        public bool LoadDropDownWithOperatorList(System.Web.UI.WebControls.DropDownList drpDwnList, string columnType , Page page )
        {
            string operatorListName = "";
            XmlDocument XmlDoc = new XmlDocument();

            try
            {
                drpDwnList.Items.Clear();

                #region Check Field DataType For Determining Operator List Name

                switch (columnType)
                {
                    case "bigint":
                    case "int":
                    case "smallint":
                    case "tinyint":
                    case "decimal":
                    case "float":
                    case "money":
                    case "smallmoney":
                    case "real":
                        operatorListName = "datatype_numeric";
                        break;
                    case "bit":
                        operatorListName = "datatype_boolean";
                        break;
                    case "datetime":
                    case "smalldatetime":
                        operatorListName = "datatype_date";
                        break;
                    case "char":
                    case "nchar":
                    case "text":
                    case "ntext":
                    case "varchar":
                    case "nvarchar":
                        operatorListName = "datatype_text";
                        break;
                    default:
                        operatorListName = "";
                        break;

                }

                #endregion

                string path = page.MapPath("..\\Configuration\\SQLXMLFiles\\operatorLists.config");
                XmlDoc.Load(path);

                XmlNodeList List = XmlDoc.SelectNodes("//operatorList[@id= '" + operatorListName + "']//operator");

                foreach (XmlNode node in List)
                {
                    System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
                    item.Text = node.Attributes[1].Value;
                    item.Value = node.Attributes[0].Value + "@" + node.Attributes[2].Value;
                    drpDwnList.Items.Add(item);
                }

            }
            catch (Exception ee)
            {
                error = ee.Message;
                return false;
            }
            return true;
        }

        #endregion

        #region CreateCondition
        /// <summary>
        /// this function create a new condition fot the where control
        /// </summary>
        /// <param name="fieldName">selected field name</param>
        /// <param name="strOperator">selected operator name</param>
        /// <param name="strValueEntry">value entry name in XML file</param>
        /// <param name="value">first value </param>
        /// <param name="value2">second value</param>
        /// <returns>the created condition</returns>
        public string CreateCondition( string tableName , string fieldName , string strOperator , string strValueEntry , string value , string value2 )
        {
            string condition = "";

            try
            {
                switch (strOperator)
                {
                    case "Is":
                        condition = fieldName +  " = '" + value + "'";
                        break;
                    case "Is Not":
                        condition = fieldName + " != '" + value + "'";
                        break;
                    case "Contains":
                        condition = fieldName + " LIKE '%" + value + "%'";
                        break;
                    case "Does Not Contain":
                        condition = fieldName + " NOT LIKE '%" + value + "%'";
                        break;
                    case "Starts With":
                        condition = fieldName + " LIKE '" + value + "%'";
                        break;
                    case "Ends With":
                        condition = fieldName + " LIKE '%" + value + "'";
                        break;
                    case "Is Null":
                        condition = fieldName + " IS NULL";
                        break;
                    case "Is Not Null":
                        condition = fieldName + " IS NOT NULL";
                        break;
                    case "Equals":
                        condition = fieldName + " =" + value;
                        break;
                    case "Does Not Equal":
                        condition = fieldName + " !=" + value;
                        break;
                    case "Is Greater Than":
                        condition = fieldName + " >" + value;
                        break;
                    case "Is Less Than":
                        condition = fieldName + " <" + value;
                        break;
                    case "Is Between":
                        if (strValueEntry == "twotext")
                            condition = " (" + fieldName + ">" + value + ") AND ("+ fieldName + "< " + value2 + ")";

                        else if (strValueEntry == "betweendate")
                            condition = " ("+ fieldName + "> '" + value + "') AND ("+ fieldName + "< '" + value2 + "')";

                        break;

                    case "Is Not Between":
                        if (strValueEntry == "twotext")
                            condition = " NOT (" + fieldName + "> " + value + ") AND (" + fieldName +"< " + value2 + ")";

                        else if (strValueEntry == "betweendate")
                            condition = " NOT ("+ fieldName + "> '" + value + "') AND ("+ fieldName + "< '" + value2 + "')";
                        break;
                    case "Is On":
                        condition = " = '" + value + "'";
                        break;
                    case "Is Not On":
                        condition = " != '" + value + "'";
                        break;
                    case "Is On or After":
                        condition = " >= '" + value + "'";
                        break;
                    case "Is On or Before":
                        condition = " <= '" + value + "'";
                        break;
                    case "Is After":
                        condition = " > '" + value + "'";
                        break;
                    case "Is Before":
                        condition = " < '" + value + "'";
                        break;
                    case "Is True":
                        condition = " = 1";
                        break;
                    case "Is False":
                        condition = " = 0";
                        break;
                    case "Value From Menue":
                        condition = fieldName + " = " + value ;
                        break;
                        
                    default:
                        condition = "";
                        break;
                }
                condition = tableName + "." + condition;
            }
            catch (Exception ee)
            {
                error = ee.Message;
            }
            return condition;
        }
        #endregion

        #region GetApplicationInfo

        /// <summary>
        /// this functions gets the application information from the application.config file
        /// </summary>
        /// <returns></returns>

        public ReportWriter.ApplicationInfo GetApplicationInfo(string applicationID, Page page)
        {
            ApplicationInfo appInfo = new ApplicationInfo();

            try
            {
                string path = page.MapPath("..\\ReportWriter\\Configuration\\application.config");
                XmlDoc.Load(path);
                XmlNodeList List = XmlDoc.SelectNodes("configuration//CONNECTIONDATA[@id= '" + applicationID + "']");
                //appInfo.ApplicationName       = List[0].ChildNodes[0].InnerText; ;
                appInfo.ApplicationName       = List[0].Attributes[1].InnerText; ;
                appInfo.UsersQuery            = List[0].ChildNodes[1].InnerText; ;
                appInfo.UserDisplayedField    = List[0].ChildNodes[2].InnerText; ;
                appInfo.UserIDField           = List[0].ChildNodes[3].InnerText; ;
                appInfo.ApplicationConnection = List[0].ChildNodes[4].InnerText; ;
                appInfo.DModelPass= List[0].ChildNodes[5].InnerText; ;
                appInfo.MRTFileName = List[0].ChildNodes[6].InnerText; ;
                
            }
            catch (Exception ee)
            {
                error = ee.Message;
            }
            return appInfo;
        }

        #endregion

        #region GetAllApplicationsInfo

        /// <summary>
        /// this functions gets all applications informations from the application.config file
        /// </summary>
        /// <returns></returns>

        public ArrayList GetAllApplicationsInfo(Page page)
        {
            ArrayList allApp = new ArrayList();

            try
            {
                string path = page.MapPath("Configuration\\application.config");
                XmlDoc.Load(path);
                XmlNodeList List = XmlDoc.SelectNodes("configuration//CONNECTIONDATA");
                foreach (XmlNode node in List)
                {
                    ApplicationInfo appInfo = new ApplicationInfo();
                    appInfo.ApplicationID = node.Attributes[0].Value;
                    appInfo.ApplicationName = node.Attributes[1].Value;
                    //appInfo.ApplicationName       = node.ChildNodes[0].InnerText; 
                    appInfo.UsersQuery = node.ChildNodes[1].InnerText;
                    appInfo.UserDisplayedField = node.ChildNodes[2].InnerText;
                    appInfo.UserIDField = node.ChildNodes[3].InnerText;
                    appInfo.ApplicationConnection = node.ChildNodes[4].InnerText;
                    appInfo.DModelPass = node.ChildNodes[5].InnerText;
                    appInfo.MRTFileName = node.ChildNodes[6].InnerText;
                    appInfo.WSDSReportURL = node.ChildNodes[7].InnerText;
                    allApp.Add(appInfo);
                }
            }
            catch (Exception ee)
            {
                error = ee.Message;
            }
            return allApp;
        }

        #endregion

        #region ShowMessage
        public static void ShowMessage(string msg, System.Web.UI.Page page)
        {
            msg = msg.Replace("\n", " ");
            msg = msg.Replace("'", " ");
            page.Response.Write("<script language=javascript > alert ( '" + msg + "' ) </script>");
        }
        #endregion

        #endregion

        #region Properties

        ArrayList ReportTables
        {
            get
            {
                return tablesNames;
            }
        }


        public string Error
        {
            get
            {
                return error;
            }

        }

        #endregion 

    }

}


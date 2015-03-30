using System;
using System.Xml;
using System.Data;
using System.Runtime.InteropServices;

namespace TSN.ERP.XML
{
	
	//[ComVisible(true)]
    //[ClassInterface(ClassInterfaceType.AutoDual)]
	
	/// <summary>
	/// Handles and Creats SQL Connection String from an XML File
	/// </summary>
	/// 
	public class ConnFileLoader
	{
		
 		public string LoadFile(string FileName)
		{
			////////////////////////////////////
			// TODO: Add constructor logic here
			XmlDocument XmlDoc = new XmlDocument() ; 
			XmlDoc.Load(FileName) ;
			string ss = XmlDoc.OuterXml;
			return ss ;
		   /////////////////////////////////////
		}
	
				
		public void SetNewConn(string FileName, string ID, string NAME, string PASSWORD, string SERVER ,string DATABASE, string DBMS, string AUTHENTICATION)
		
		{
			try
			{
				DataSet dsXmlData = new DataSet() ; 
				dsXmlData.ReadXmlSchema(FileName+".xsd");
				dsXmlData.ReadXml(FileName);
			
				int tablesNumber=dsXmlData.Tables.Count;
				int columnsNumber=dsXmlData.Tables[1].Columns.Count;
				string[] arrValues=new string[]{ID,NAME,PASSWORD,SERVER,DATABASE,DBMS,AUTHENTICATION};
				DataRow drnewRow = dsXmlData.Tables[1].NewRow() ;
				
				for(int i=0;i<columnsNumber;i++)
				{
					drnewRow[i]=arrValues[i];
				}
				dsXmlData.Tables[1].Rows.Add(drnewRow);
				dsXmlData.WriteXml(FileName,XmlWriteMode.IgnoreSchema) ;
			
        		}
			catch (Exception e)
			{

				Console.WriteLine("Exception: {0}", e.ToString());

			}
	      
	
	}

		
		public string GetDefaultUserConn(string FileName)
		  {
			
			XmlDocument XmlDoc = new XmlDocument() ; 
			XmlDoc.Load(FileName) ;
			XmlNodeList elemList = XmlDoc.GetElementsByTagName("HEADER");
			string ss = (elemList[0].InnerText);
			string xmlValue = GetUserConn(FileName,ss); 
		    return xmlValue;
		
		}
		
			
		public string GetUserConn(string FileName, string ID)
		
		{
			string xmlValue="";
			XmlDocument XmlDoc = new XmlDocument() ; 
			XmlDoc.Load(FileName) ;
			XmlNodeList List = XmlDoc.SelectNodes("//CONNECTIONDATA[ID='" + ID + "']") ;
						
			foreach(XmlNode node in List)
			{
          
				if (node.ChildNodes[6].InnerXml.ToString()=="1") 
				{
					// Connect Via IP // Provider=sqloledb;Data Source=10.0.0.1,1433;Network Library=DBMSSOCN;Initial Catalog=pubs;User ID=sa;Password=aswwe;    
					xmlValue = "Provider=" + node.ChildNodes[5].InnerXml + ";Data Source="+ node.ChildNodes[3].InnerXml +",1433;Network Library=DBMSSOCN;Initial Catalog=";	
					xmlValue+= node.ChildNodes[4].InnerXml + ";User ID=" + node.ChildNodes[1].InnerXml + ";Password="+ node.ChildNodes[2].InnerXml +";" ;	
				}
				else if (node.ChildNodes[6].InnerXml.ToString()=="0")
				{
					// Trusted Connection // Provider=sqloledb;Data Source="server";Initial Catalog=pubs;Integrated Security=SSPI;"
					xmlValue = "Provider=" + node.ChildNodes[5].InnerXml + ";Persist Security Info=True;Data Source="+ node.ChildNodes[3].InnerXml +";Initial Catalog=";	
					xmlValue+= node.ChildNodes[4].InnerXml + ";User ID=" + node.ChildNodes[1].InnerXml + ";Password="+ node.ChildNodes[2].InnerXml +";" ;	
				}
				else if (node.ChildNodes[6].InnerXml.ToString()=="2") 
				
				{
					// Connect Via Sql Auth. //
					xmlValue = "Provider=SQLOLEDB;Persist Security Info=True;Data Source="+ node.ChildNodes[3].InnerXml +";Initial Catalog="+ node.ChildNodes[4].InnerXml +";Password='"+ node.ChildNodes[2].InnerXml +"';User ID="+ node.ChildNodes[1].InnerXml +";";
					//xmlValue = "Provider=SQLOLEDB;Persist Security Info=True;Data Source="+ node.ChildNodes[3].InnerXml +",1433;Network Library=DBMSSOCN;Initial Catalog="+ node.ChildNodes[4].InnerXml +";Password='"+ node.ChildNodes[2].InnerXml +"';User ID="+ node.ChildNodes[1].InnerXml +";";
				}
				
			}
			return xmlValue;
		}
		
	}
}

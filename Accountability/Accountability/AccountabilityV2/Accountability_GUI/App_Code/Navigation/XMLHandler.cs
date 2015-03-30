using System;
using System.Xml;
using System.Data;
using System.IO; 
using System.Xml.Serialization;

namespace TSN.ERP.WebGUI.Navigation
{
	/// <summary>
	/// Summary description for XMLHandler.
	/// </summary>
	public class XMLHandler
	{
		public XMLHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	
		public bool AddNewNode(string FileName, int ParentID, string ItemName, string ItemDesc,string ImageName)
		
		{
			try 
			{

				XmlDocument XmlDoc = new XmlDocument() ; 
				XmlDoc.Load(FileName) ;
			
				XmlElement newElem;
				XmlElement newChElem;

				XmlNodeList elemList = XmlDoc.GetElementsByTagName("ITEM_DATA");
				if (Convert.ToInt32(elemList[0].ChildNodes[0].InnerText) == 0)
				{
					EditNode(FileName, 0, ParentID, ItemName, ItemDesc ,ImageName);
				    return true;
				}
				int ItemCountIndex = (elemList.Count) + 1 ;
				// Creates root Element //
				newElem= XmlDoc.CreateElement("ITEM_DATA");
				XmlDoc.DocumentElement.ChildNodes[1].AppendChild(newElem);
				// 
				// Create SubChildes in this node //
				newChElem = XmlDoc.CreateElement("ITEMID");
				newChElem.InnerText = ItemCountIndex.ToString();
				newElem.AppendChild(newChElem);
				//
				newChElem = XmlDoc.CreateElement("ITEMPARENT");
				newChElem.InnerText = ParentID.ToString();
				newElem.AppendChild(newChElem);
				//
				newChElem = XmlDoc.CreateElement("ITEM_NAME");
				newChElem.InnerText = ItemName;
				newElem.AppendChild(newChElem);
				//
				newChElem = XmlDoc.CreateElement("ITEM_DESCRIPTION");
				newChElem.InnerText = ItemDesc;
				newElem.AppendChild(newChElem);
				//
				newChElem = XmlDoc.CreateElement("IMAGENAME");
				newChElem.InnerText = ImageName;
				newElem.AppendChild(newChElem);
				// Writes The XML File //
				XmlTextWriter writer  = new XmlTextWriter(FileName,System.Text.Encoding.UTF8);
				writer.Formatting = Formatting.Indented;
				XmlDoc.Save(writer);
				writer.Close();		
         	
				return true;
			}
			catch 
			{
				return false;
			}
		
		}
	   
		
		public void EditOverView(string FileName, string Content)
		{
			XmlDocument XmlDoc = new XmlDocument() ; 
			XmlDoc.Load(FileName) ;
			XmlDoc.DocumentElement.ChildNodes[0].InnerText = Content ;
			XmlDoc.Save(FileName);
		}
		
		
		private string LoadXMlFile (string FileName)
		{
			XmlDocument XmlDoc = new XmlDocument() ; 
			XmlDoc.Load(FileName) ;
			string ss = XmlDoc.OuterXml;
			return ss ;
		}
      
		
		public DataSet ReturnXMLds(string FileName)
		{
			DataSet dsXmlData = new DataSet() ; 
			string XML = LoadXMlFile(FileName);			
			StringReader sr = new StringReader(XML);					
			dsXmlData.ReadXml(sr);
			return dsXmlData ;
		}

		
		public bool EditNode(string FileName, int ItemID, int ParentID, string ItemName, string ItemDesc, string ImageName)
		{
			
			XmlDocument XmlDoc = new XmlDocument() ; 
			XmlDoc.Load(FileName) ;
			XmlNodeList List = XmlDoc.SelectNodes("//DATA//ITEM_DATA[ITEMID='" + ItemID + "']") ;
			
			foreach(XmlNode node in List)
			{
				if (ItemID == 0)
				{
					node.ChildNodes[0].InnerText = "1" ; // ITEMPARENT
				}
				node.ChildNodes[1].InnerText = ParentID.ToString(); // ITEMPARENT
				node.ChildNodes[2].InnerText = ItemName.ToString() ; //ITEM_NAME
				node.ChildNodes[3].InnerText = ItemDesc.ToString() ; //ITEM_DESCRIPTION
			    node.ChildNodes[4].InnerText = ImageName.ToString() ; //IMAGENAME
			}
			
			XmlDoc.Save(FileName);
			return true;
		   
		}
 
		
		public void RemoveNode(string FileName, int ItemID)
		{
			XmlDocument XmlDoc = new XmlDocument() ; 
			XmlDoc.Load(FileName) ;
			XmlNode node = XmlDoc.SelectSingleNode("//DATA//ITEM_DATA[ITEMID='" + ItemID + "']") ;
			node.ParentNode.RemoveChild(node);
			XmlDoc.Save(FileName);
			
		}	

		#region CreatXmlFile 
		
		public void CreateNewXMLFile(string FileName, string ModID, string LnkID, string FunID)
		{
			XmlDocument XmlDoc =new XmlDocument();
			FileInfo fileName= new FileInfo(FileName);
		
			if (!fileName.Exists)
			{
				string Content ="<?xml version='1.0' encoding='utf-8'?>";
				Content  += "<RETURNDATA xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:noNamespaceSchemaLocation='http://Schema-URL/Schema.xsd'>";
				Content  += "<OVERVIEW_CONTENT></OVERVIEW_CONTENT>";
				Content  += "<DATA MODULEID='" + ModID + "'";
				Content  += " LINKID='" + LnkID + "'";
                Content  += " FUNCTIONALITYID='" + FunID + "'>";
                Content  += "<ITEM_DATA>";
				Content  += "<ITEMID>0</ITEMID>";
				Content  += " <ITEMPARENT>0</ITEMPARENT>";
				Content  += "<ITEM_NAME>null</ITEM_NAME>";
				Content  += "<ITEM_DESCRIPTION>null</ITEM_DESCRIPTION>";
				Content  += "<IMAGENAME>null</IMAGENAME>";
				Content  += "</ITEM_DATA>";
				Content  += "</DATA>";
				Content  += "</RETURNDATA>";
				
				StreamWriter sw = new StreamWriter(FileName,true,System.Text.Encoding.UTF8);
				sw.WriteLine(Content);
				sw.Flush();
				sw.Close();
			  
			}
           
		}
		#endregion
	}

}


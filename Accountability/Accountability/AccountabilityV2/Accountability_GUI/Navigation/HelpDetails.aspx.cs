using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace TSN.ERP.WebGUI.Navigation
{
	/// <summary>
	/// Summary description for HelpDetails.
	/// </summary>
	public partial class HelpDetails : System.Web.UI.Page
	{
		
		static string fileName ="" ;
		XMLHandler xmlHnd = new XMLHandler();
		protected TSN.ERP.WebGUI.Data.dsXML dsXML1;
		Microsoft.Web.UI.WebControls.TreeView TreeView1;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Register this form as Ajax compliant
			Ajax.Utility.RegisterTypeForAjax(typeof(HelpDetails));

			// Put user code to initialize the page here
			if ( !IsPostBack )
			{
				TreeView1 = new Microsoft.Web.UI.WebControls.TreeView();
				GetHelpDetails( );
				testTable.InnerHtml = treeNode();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dsXML1 = new TSN.ERP.WebGUI.Data.dsXML();
			((System.ComponentModel.ISupportInitialize)(this.dsXML1)).BeginInit();
			// 
			// dsXML1
			// 
			this.dsXML1.DataSetName = "dsXML";
			this.dsXML1.EnforceConstraints = false;
			this.dsXML1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsXML1)).EndInit();

		}
		#endregion

		#region CreateFileName
		string CreateFileName()
		{
			string modStr = "" , linkStr = "" , funStr = ""  , fileName = "" ;

			try
			{
				
				switch( ((Navigation.BaseObject) Session[ "Navigation" ] ).Module.ToString().Length )
				{
					case 1 :
						modStr = "00" + ((Navigation.BaseObject) Session[ "Navigation" ] ).Module.ToString();
						break;
					case 2 :
						modStr = "0" + ((Navigation.BaseObject) Session[ "Navigation" ] ).Module.ToString();
						break;
					case 3 :
						modStr = ((Navigation.BaseObject) Session[ "Navigation" ] ).Module.ToString();
						break;
				}
				

				
				switch( ((Navigation.BaseObject) Session[ "Navigation" ] ).Link.ToString().Length )
				{
					case 1 :
						linkStr = "00" + ((Navigation.BaseObject) Session[ "Navigation" ] ).Link.ToString();
						break;
					case 2 :
						linkStr = "0" + ((Navigation.BaseObject) Session[ "Navigation" ] ).Link.ToString();
						break;
					case 3 :
						linkStr = ((Navigation.BaseObject) Session[ "Navigation" ] ).Link.ToString();
						break;
				}
				

				
				switch( ((Navigation.BaseObject) Session[ "Navigation" ] ).Function.ToString().Length )
				{
					case 1 :
						funStr = "00" + ((Navigation.BaseObject) Session[ "Navigation" ] ).Function .ToString();
						break;
					case 2 :
						funStr = "0" + ((Navigation.BaseObject) Session[ "Navigation" ] ).Function .ToString();
						break;
					case 3 :
						funStr = ((Navigation.BaseObject) Session[ "Navigation" ] ).Function .ToString();
						break;
				}
				
						
				// set file name
				fileName = modStr + "-"  + linkStr + "-" +  funStr ;

			}
			catch( Exception ee )
			{
				Response.Write(  ee.Message );
			}

			return fileName;
		}

		#endregion

		#region Get Help Details

		private void GetHelpDetails( )
		{
			//reset data
			fileName = "" ;
			dsXML1.Clear();

			// get file name
			string requiredFileName =  CreateFileName() ;
			string[] fileNameParts = requiredFileName.Split( '-' );
			
			//string filePath = "C://Inetpub//wwwroot//ERP//MainGUI//Navigation//XMLHelpFiles";
//			string filePath = Server.MapPath( "..//..//Navigation//XMLHelpFiles" );
			string filePath = AppDomain.CurrentDomain.BaseDirectory + "Navigation\\XMLHelpFiles";
			// get all directories in the main Directory XMLHelpFiles
			Directory.SetCurrentDirectory( filePath );
			
			// if module directory exists
			if ( Directory.Exists( fileNameParts[ 0 ] ) )
			{
				// get all files in the module directory	
				Directory.SetCurrentDirectory( filePath + "/" + fileNameParts[ 0 ] );

				string[] filesInDir = Directory.GetFiles( Directory.GetCurrentDirectory() );
				for( int i = 0 ; i < filesInDir.Length ; i++ )
				{
					string[] currentFile = filesInDir[ i ].Split( '\\' );
					if( currentFile[ currentFile.Length-1 ] == ( requiredFileName + ".xml" ) )
					{
						fileName = Directory.GetCurrentDirectory() + "\\" + currentFile[ currentFile.Length-1 ] ;

						// read XML file and load the data set
						dsXML1.Merge( xmlHnd.ReturnXMLds( Directory.GetCurrentDirectory() + "\\" + currentFile[ currentFile.Length-1 ] ) );
						ViewState[ "help" ] = dsXML1;
						Session[ "hh" ] = dsXML1;

						if ( dsXML1 != null )
						{
							// set over view
							if( dsXML1.RETURNDATA.Rows.Count != 0 )
							{
								LabelTitle.Text = "Over View ";
								div1.InnerText = dsXML1.RETURNDATA[ 0 ].OVERVIEW_CONTENT.ToString();
							}
							if( dsXML1.ITEM_DATA.Rows.Count != 0 )
							{
								FillTree();
							}
							break;
						}
					}
				}
			}
			
		}


		#endregion 

		#region Fill Tree

		void FillTree( )
		{
			
			if (dsXML1 !=null && dsXML1.Tables.Count>0)
			{
				TreeView1.Nodes.Clear();
				
				foreach ( Data.dsXML.ITEM_DATARow dr in dsXML1.ITEM_DATA.Rows)
				{
					if (dr.ITEMPARENT == "0")
					{
						Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
						treeNode.Text   = dr.ITEM_NAME;
						treeNode.ID     = dr.ITEMID.ToString();
						TreeView1.Nodes.Add ( treeNode );
						FillChildren(  dr.ITEMID , treeNode,  dsXML1);
					}
				}
			}
		}

		void FillChildren( string parentID,  Microsoft.Web.UI.WebControls.TreeNode tn,  Data.dsXML templist)
		{
			if (templist!=null && templist.Tables.Count>0)
			{
				foreach (Data.dsXML.ITEM_DATARow dr in templist.ITEM_DATA.Rows)
				{
					if (dr.ITEMPARENT == parentID)
					{
						Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
						treeNode.Text   = dr.ITEM_NAME;
						treeNode.ID     = dr.ITEMID.ToString();
						tn.Nodes.Add ( treeNode );
						FillChildren( treeNode.ID,  treeNode, templist);
					}	
				}
			}
		}

	
		#endregion 

		private void TreeView1_SelectedIndexChange(object sender, Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs e)
		{
			Microsoft.Web.UI.WebControls.TreeNode node = TreeView1.GetNodeFromIndex( TreeView1.SelectedNodeIndex );
			dsXML1  = ( Data.dsXML ) ViewState[ "help" ] ;

			foreach ( Data.dsXML.ITEM_DATARow row in dsXML1.ITEM_DATA.Rows )
				if( row.ITEMID == node.ID )
					div1.InnerText =  row.ITEM_DESCRIPTION;

			
			
		}


		#region returns Get Node Description
		

		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read)]
		public string GetNodeDescription( string nodeID )
		{
			dsXML1  = ( Data.dsXML ) Session[ "hh" ] ;
			string result = ""; // = new string[2];
			//string imgPath = "";
			

			foreach ( Data.dsXML.ITEM_DATARow row in dsXML1.ITEM_DATA.Rows )
				if( row.ITEMID == nodeID )
				{  
					result  =  row.ITEM_DESCRIPTION;
					if( ! row.IsIMAGENAMENull() ) 
						result +=  "$" + row.IMAGENAME;
				}

			return result;
		}
		#endregion

		#region Draw Tree

		string treeNode(  )
		{
			string html = " <TABLE cellSpacing='0' cellPadding='0' border='0'> <TBODY>";
			string imgID= "";
		
			foreach( Microsoft.Web.UI.WebControls.TreeNode treeNode in TreeView1.Nodes )
			{
				imgID = "IMG"+ treeNode.ID;
				if( treeNode.Nodes.Count == 0 )
					html += "<TR><TD width='15'></TD><TD><A id="+ treeNode.ID +" class='folder' onclick='toggle(this),changeimg("+imgID+")'><IMG id="+imgID+" src='contents2.gif' onclick='changeimg(this)'><h45>"+ treeNode.Text +"</A><DIV style='DISPLAY: none'></DIV></TD></TR>" ;
				else
				{
					html += "<TR><TD width='15'></TD><TD><A id="+ treeNode.ID  + " class='folder' onclick='toggle(this),changeimg("+imgID+")'><IMG id="+imgID+" src='contents2.gif' onclick='changeimg(this)'><h45>"+ treeNode.Text +"</A><DIV style='DISPLAY: none'>" ;
					html = childNode( treeNode , html , 1 );
					html += "</DIV></TD></TR>";
				}
			}
			
			html += "</TBODY></TABLE>";
			return html;
		}

		
		string childNode( Microsoft.Web.UI.WebControls.TreeNode node , string html , int tdNo )
		{
			
			string imgID= "";
			foreach( Microsoft.Web.UI.WebControls.TreeNode treeNode in node.Nodes )
			{
				imgID = "IMG"+ treeNode.ID;
				html += "<TABLE cellSpacing='0' cellPadding='0' border='0'> <TBODY> <TR> ";
				for( int i = 0 ; i< tdNo ; i++ )
					html += "<TD width='15'></TD>";

				if( treeNode.Nodes.Count == 0 )
					html += "<TD><A id="+ treeNode.ID +" class='folder' onclick='getDescription(id),changeimg("+imgID+")'><IMG id="+imgID+" src='contents2.gif' onclick='changeimg(this)'><h45>"+ treeNode.Text +"</A><DIV style='DISPLAY: none'></DIV></TD></TR></TBODY> </TABLE>" ;
					
				else
				{
					html +=	"<TD><A id="+ treeNode.ID +" class='leaf' onclick='toggle(this),changeimg("+imgID+")' ><IMG id="+imgID+" src='contents2.gif' onclick='changeimg(this)'><h45>"+ treeNode.Text +"</A><DIV style='DISPLAY: none'></DIV></TD></TR></TBODY> </TABLE>" ;
					html = childNode( treeNode , html , tdNo+1 );
				}
			}

			return html;
		}

		#endregion 
	}
}

// Global variables
var lastColor = -1;  // last selcted color, used to reset the ;
var task_index = -1;  // selected task ... ex. task31  , where 31 is the ID
var selectedRowColor = "selectedrow";  // Selcted row color, actually, it's not used
var selectedCellColor = "selectedcell"; // Selcted cell color
var respColor ="resp"; 			// Resposibility color  [Blue]
var projectColor = "project";			// Project color  [Green]
var offdayColor = "offday_offday";  			// Offday color  [Orange]
var taskColor_hour = "normaltask";			// Hour based task color [White] 
var taskColor_count = "counttask";  		// Count based task color
var taskColor_NC = "nctask"; 					//Non-Countable task color [White and red text]
var taskTextColor_completed = "completetask"; 		//Completed task color [violit]
var sheetLen = 0;  // number of records in the accounatbility sheet
var employeeID=-1; // ID of selected employee
var employeeName ="";  // Name of selected employee
var dateFormat = "MM/dd/yyyy";   //Date format
var MONTH_NAMES=new Array('January','February','March','April','May','June','July','August','September','October','November','December','Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'); //Array of months
var DAY_NAMES=new Array('Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sun','Mon','Tue','Wed','Thu','Fri','Sat'); //Days
var isFocused = true; // is accountability form is an active or not
var currentDay = -1;  // selected day
var currentCell = -1; // selected cell
var currentCellColor = -1; //selected cell color;
var isProject = false;     // Denotes whether the current row in accountability sheet is project or not
var canBeDeleted ;  // Denotes whether the current Assignment in accountability sheet can be deleted or not, any assignments coming below a specific project can't be delete, only assignment coming below responsibilities can be deleted
var selectedAssID = -1;  // selected Assignment ID;
var selectedIndex = -1;  // index of the seledted row in accountability sheet dataset
var lastSelectedCell = -1;    // used to get the last cell has been selected
var lastSelectedCellColor = -1;    // used to get the last cell has been selected
var showOffDays = false; // the default is not to view off Days;
var viewMode = 10;       // View mode of the accountability sheet, default is 10 [General view]
var isSheetInEditMode = false;   // Is accountability sheet in edit mode, is set to be true if user clicks on any cell in the accountability sheet
var respArray = new Array;       // Holds the responsibility name of each assignment.
var projectArray = new Array;	 // Holds the project name of each assignment .
var hourCount = new Array;       //Array of total working hours in each day, used to validate that total count of hours in each day is less than 24
var assIDsArray = new Array;   // array od all assignmenets IDs.
var assPriorityArray = new Array;   // array of corresponding periorities.
var taskDescArray = new Array;		// Comments entered for completed assignment
var TotalCellsColorsArray = new Array;		// Array of CSS [Cascading style sheet] for each cell in the total cells, coming above the accountability sheet
									// Used to set the color of these cells, if user registers any offdays hours in any day, it total cell is orange, else it's white
var isModified = false;             // used to check if the form has been modified
//window.onbeforeunload = DisplayMessage;		// call DisplayMessage function befor unload the page							
var lastSelectedDay = ""; 									
var FillAssignValue;
var NoteFlage = false;   //flage used to check if the Note text box have value or not
//var currentViewMode = 10; // the view mode after saving sheet
//var checkHoursCount = false; //This bool variable is used in checking that total hours in a day does not exceeds 24 
//var generalTasksHoursCount = new Array();
var putNotesIneditMode = false;
var popupIsDisplayed = false;
//var CalendarOldDate = null;
//var CalendarOldDateChanged = false;
var DateChanged = new Date();
var DateClicked = false;
var IsAdmin = false;
var IsNotesPopupOpened = false;
//---------------------------------------------------------------------------------------------------
// set version of IE
function SetIEVersion(version)
{
	//alert(version+"");
	var x=MasterForm.SetIEVersionSession(version);
	
}
//---------------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------------
// initialize the page [fill employees, job titles and departments lists] 
function initPage()
{
	
	document.getElementById('wait').style.visibility = "visible";
	//bindJobs();
	//bindDepts();
	//initialize hour count array
	for(i=0;i<7;i++)
		hourCount[i] = 0;
	
	bindEmployees();
	var date = new Date();
	document.getElementById('txtDate').value = date.getMonth() + 1 + "/" + date.getDate() + "/" + date.getFullYear();
	DateChanged = document.getElementById('txtDate').value;
	IsAdmin = frmAccountability.IsAdmin().value;
	if(IsAdmin)
	{
	    document.getElementById('ddlFilterEmployees').style.display = "inline";
	}
	else
	{
	    document.getElementById('ddlFilterEmployees').style.display = "none";
	}
}

//---------------------------------------------------------------------------------------------------
//Bind employee to the drop dow list
function bindEmployees()
{	
    var empFilter = document.getElementById('ddlFilterEmployees').options[document.getElementById('ddlFilterEmployees').selectedIndex].value;
	frmAccountability.BindEmployees(empFilter,bindEmployees_CallBack);  // the call back function is called after server responds with result set
}
function bindEmployees_CallBack(response)  // Responce is the data server has sent, in this case it contains a dataset for all employees.
{    
    var selectedEmp =frmAccountability.GetSelectedEmp().value;    // get last selected employee from the server session.
    var ContactIDExistsInList = false;
	var ds = response.value;  //Employee dataset
	if (ds != null && typeof(ds) =="object" && ds.Tables != null)   //If is not null or has no table
				{
                    document.getElementById('lstEmployee').options.length=0 // Clear the list first
                    addToList(document.getElementById('lstEmployee')," ",-1,'emp');
					for (var i=0;i<ds.Tables[0].Rows.length;i++)  // begin fill employee list box
						{
							addToList(document.getElementById('lstEmployee'),RTrim(ds.Tables[0].Rows[i].FirstName) + ' ' +RTrim(ds.Tables[0].Rows[i].MiddleName) + ' ' + RTrim(ds.Tables[0].Rows[i].LastName),ds.Tables[0].Rows[i].ContactID,'emp');			
							if(ds.Tables[0].Rows[i].ContactID == selectedEmp)
							{
							    ContactIDExistsInList = true;
							}
						}						
				}
	document.getElementById('wait').style.visibility = "hidden";  // Hide animated wait image 
//	var selectedEmp =frmAccountability.GetSelectedEmp().value;    // get last selected employee from the server session.
//	alert(selectedEmp);
	//Change selected Employee th the first one in the bound list if the filter type is terminated
	if(!ContactIDExistsInList)
	{
	    if(document.getElementById('lstEmployee').options.length > 1)
	    {
	        selectedEmp = document.getElementById('lstEmployee').options[1].value;
	    }
	    else
	    {
	        selectedEmp=-1;
	    }
	}
//	alert(selectedEmp);
//	//////////////////////////////////////////////////////////////////////////////////////////////
    if (selectedEmp!= -1)										  // If we have a one, select him/her and view his/her information	
		{
			employeeID =selectedEmp;                              // Set global variable [employeeID]
			selectEmp();										  // select employee	
			bindEmpInfo(selectedEmp);							  // get his/her information	
		}
		// added by Moawad 3-11-2009
		  var AccessRightWManager =frmAccountability.GetAccessRightForWeeklyManagerReport().value;    // get access right for weekly manager report
		  	     if(AccessRightWManager)//User has access right for weekly manager report
                	{
              		document.getElementById('btnMgrsWeeklyReport').disabled=false;
              	    }
               	else
                	{
                		document.getElementById('btnMgrsWeeklyReport').disabled=true;
               	    }
		// end 3-11-2009
		
		// commented by Sayed 3-11-2009	
                //	if(document.getElementById("lstEmployee").options.length > 2)//User is  manager, i.e, he has  employees in the dropdownlist to mange them
                //	{
                //		document.getElementById('btnMgrsWeeklyReport').disabled=false;
                //	}
                //	else
                //	{
                //		document.getElementById('btnMgrsWeeklyReport').disabled=true;
                //	}
        // end of commented
	}
//---------------------------------------------------------------------------------------------------
// used to add an item to a given drop down list
function addToList(listField, newText, newValue,entity) {
   if ( ( newValue == "" ) || ( newText == "" ) ) 
   {
   } 
   else 
   {
      var len = listField.length++; // Increase the size of list and return the size
      listField.options[len].value = newValue;
      listField.options[len].text = newText;	
	  listField.options[len].id = entity + newValue;
   } // Ends the check to see if the value entered on the form is empty
}
//---------------------------------------------------------------------------------------------------
// get the accountability sheet for the given employee
function bindAccSheet(empID,sheetDate)
{
	currentDay = -1;  //  selected day
	currentCell = -1; // selected cell
	currentCellColor = -1; //selected cell color;
	isProject = false;     // Initialize isProject global variable to false
	selectedAssID = -1;  // selected Task ID;
	selectedIndex = -1;  // index of the seledted row
	lastSelectedCell = -1;    // used to get the last cell has been selected
	lastSelectedCellColor = -1;    // used to get the last cell has been selected
	lastColor =-1;				   // reset last selcted color,	
	respArray = new Array;			
	projectArray = new Array;
	frmAccountability.BindSheet(empID,sheetDate,showOffDays,viewMode,bindSheet_CallBack);	// Get given employee accountability sheet in given day using given view mode
	
	}
function bindSheet_CallBack(response)
	{
		
		var ds = response.value;
		sheetLen = ds.Tables[0].Rows.length;   // Set global variable sheetLen to equals number of rows in accountability sheet 
		var color;							// Current row color	
		var fontColor;						// Current row font color
		if (ds != null && typeof(ds) =="object" && ds.Tables != null)
			{	
			        var lastResp = 0;
					var s = new Array();
					var sheetTable = new Array();
					// Header table
					s[s.length] = "<table border =1 id='taskTable' bordercolor='#000000'  cellpadding=0 cellspacing=0 style=border-collapse:collapse width=100%>";
					// Fill global array  , orange if day has offdays hours, else it's white
					for (x=0;x< 7;x++)
						{
						if (ds.Tables[3].Rows[x].HasDaysOff == true)
							TotalCellsColorsArray[x] = offdayColor;
						else
							TotalCellsColorsArray[x] = 'whitetd';
						}
					// Total cells, contains total number of working hours in each day
					s[s.length] = "<tr>";
					s[s.length] = "<td align='right' colspan=6  class=whitetd><b>Total</td>";
					s[s.length] = "<td width=53 align=center class=" + TotalCellsColorsArray[0] + " id=total0>" + ds.Tables[2].Rows[0].SunTotal + "</td>";
					s[s.length] = "<td width=52 align=center class=" + TotalCellsColorsArray[1] + " id=total1>" + ds.Tables[2].Rows[0].MonTotal + "</td>";
					s[s.length] = "<td width=60 align=center class=" + TotalCellsColorsArray[2] + " id=total2>" + ds.Tables[2].Rows[0].TuesTotal + "</td>";
					s[s.length] = "<td width=60 align=center class=" + TotalCellsColorsArray[3] + " id=total3>" + ds.Tables[2].Rows[0].WedTotal + "</td>";
					s[s.length] = "<td width=60 align=center class=" + TotalCellsColorsArray[4] + " id=total4>" + ds.Tables[2].Rows[0].ThurTotal + "</td>";
					s[s.length] = "<td width=60 align=center class=" + TotalCellsColorsArray[5] + " id=total5>" + ds.Tables[2].Rows[0].FriTotal + "</td>";
					s[s.length] = "<td width=60 align=center class=" + TotalCellsColorsArray[6] + " id=total6>" + ds.Tables[2].Rows[0].SatTotal + "</td>";
					s[s.length] = "<td width=78 align=center class=whitetd>" + ds.Tables[2].Rows[0].WeekTotal + "</td>";
					s[s.length] = "</tr>";
					// Dates cells, contains days names and dates
					s[s.length] = "<tr>";
					s[s.length] = "<td class=headertd width =18></td>";
					s[s.length] = "<td class=headertd width =15></td>";
					s[s.length] = "<td class=headertd width =15></td>";
					s[s.length] = "<td class=headertd width =16></td>";
					s[s.length] = "<td class=headertd >Task</td>";
					s[s.length] = "<td class=headertd width =50>Unit</td>";
					var sunDate = new Date(ds.Tables[2].Rows[0].SunDate);
					var monDate = new Date(ds.Tables[2].Rows[0].MonDate);
					var tueDate = new Date(ds.Tables[2].Rows[0].TueDate);
					var wenDate = new Date(ds.Tables[2].Rows[0].WedDate);
					var thrDate = new Date(ds.Tables[2].Rows[0].ThurDate);
					var friDate = new Date(ds.Tables[2].Rows[0].FriDate);
					var satDate = new Date(ds.Tables[2].Rows[0].SatDate);
				
					s[s.length] = "<td width=60  class=headertd align=center id=hdrsunday ><input type='hidden' id=sunday value='" + ds.Tables[3].Rows[0].NoteBody +  "' />Sun<br>" +  formatDate(sunDate,"MM-dd-yyyy") + "</td>";
					s[s.length] = "<td width=60  class=headertd align=center id=hdrmonday ><input type='hidden' id=monday value='" + ds.Tables[3].Rows[1].NoteBody +  "' />Mon<br>" +  formatDate(monDate,"MM-dd-yyyy") + "</td>";
					s[s.length] = "<td width=60  class=headertd align=center id=hdrtueday ><input type='hidden' id=tueday value='" + ds.Tables[3].Rows[2].NoteBody +  "' />Tue<br>" +  formatDate(tueDate,"MM-dd-yyyy") + "</td>";
					s[s.length] = "<td width=60  class=headertd align=center id=hdrwenday ><input type='hidden' id=wenday value='" + ds.Tables[3].Rows[3].NoteBody +  "' />Wed<br>" +  formatDate(wenDate,"MM-dd-yyyy") + "</td>";
					s[s.length] = "<td width=60  class=headertd align=center id=hdrthrday ><input type='hidden' id=thrday value='" + ds.Tables[3].Rows[4].NoteBody +  "' />Thur<br>" + formatDate(thrDate,"MM-dd-yyyy") + "</td>";
					s[s.length] = "<td width=60  class=headertd align=center id=hdrfriday ><input type='hidden' id=friday value='" + ds.Tables[3].Rows[5].NoteBody +  "' />Fri<br>" +  formatDate(friDate,"MM-dd-yyyy") + "</td>";
					s[s.length] = "<td width=60  class=headertd align=center id=hdrsatday ><input type='hidden' id=satday value='" + ds.Tables[3].Rows[6].NoteBody +  "' />Sat<br>" +  formatDate(satDate,"MM-dd-yyyy") + "</td>";
					s[s.length] = "<td width=60  class=headertd align=center>Week</td></tr></table>";
					// render header table
					document.getElementById('headerDiv').innerHTML = s.join("");
					// set weekly notes
					document.getElementById('txtHiddenWeeklyNotes').value="";
					
					if( ds.Tables[3].Rows[0].NoteBody!=null && ds.Tables[3].Rows[0].NoteBody!='null')
					document.getElementById('txtHiddenWeeklyNotes').value="<U>Sun " +  formatDate(sunDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[0].NoteBody+"<br><br>";
					if( ds.Tables[3].Rows[1].NoteBody!=null && ds.Tables[3].Rows[1].NoteBody!='null')
					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Mon " +  formatDate(monDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[1].NoteBody+"<br><br>";
					if(ds.Tables[3].Rows[2].NoteBody!=null && ds.Tables[3].Rows[2].NoteBody!='null')
					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Tue " +  formatDate(tueDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[2].NoteBody+"<br><br>";
					if(ds.Tables[3].Rows[3].NoteBody!=null && ds.Tables[3].Rows[3].NoteBody!='null')
					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Wed " +  formatDate(wenDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[3].NoteBody+"<br><br>";
					if(ds.Tables[3].Rows[4].NoteBody!=null && ds.Tables[3].Rows[4].NoteBody!='null')
					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Thur " +  formatDate(thrDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[4].NoteBody+"<br><br>";
					if(ds.Tables[3].Rows[5].NoteBody!=null &&  ds.Tables[3].Rows[5].NoteBody!='null')
					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Fri " +  formatDate(friDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[5].NoteBody+"<br><br>";
					if(ds.Tables[3].Rows[6].NoteBody!=null && ds.Tables[3].Rows[6].NoteBody!='null')
					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Sat " +  formatDate(satDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[6].NoteBody+"<br>";
					
					
					document.getElementById('txtHiddenWeeklyNotes').value=unescape(document.getElementById('txtHiddenWeeklyNotes').value.replace(/@@0937107@@/g,"&"));
					
//					document.getElementById('txtHiddenWeeklyNotes').value="<U>Sun " +  formatDate(sunDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[0].NoteBody+"<br><br>";
//					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Mon " +  formatDate(monDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[1].NoteBody+"<br><br>";
//					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Tue " +  formatDate(tueDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[2].NoteBody+"<br><br>";
//					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Wed " +  formatDate(wenDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[3].NoteBody+"<br><br>";
//					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Thur " +  formatDate(thrDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[4].NoteBody+"<br><br>";
//					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Fri " +  formatDate(friDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[5].NoteBody+"<br><br>";
//					document.getElementById('txtHiddenWeeklyNotes').value +="<U>Sat " +  formatDate(satDate,"MM-dd-yyyy") + "</U><br><br>"+ds.Tables[3].Rows[6].NoteBody+"<br>";
//					document.getElementById('txtHiddenWeeklyNotes').value=(unescape(document.getElementById('txtHiddenWeeklyNotes').value));

					
					
					
					
					//Employee accountability values
					sheetTable[sheetTable.length] = "<table align=center border =1 id='taskTable' bordercolor='#000000' cellpadding=0 cellspacing=0 style=border-collapse:collapse width=100%>"; 
					
					// For each row in accountability dataset
					var spcLength = "";
					for (var i=0;i<ds.Tables[0].Rows.length;i++)  
						{
							var project =  ds.Tables[0].Rows[i].descProject;
							var resp = ds.Tables[0].Rows[i].descReponse;
							respArray[i] = resp;
							projectArray[i] = project;
							taskDescArray[i] = ds.Tables[0].Rows[i].descNote;
							fontColor = "#000000";
							canBeDeleted = false;
							// Current row is an assignment. 
							if (ds.Tables[0].Rows[i].RecoredType == 10)
								{
									spcLength="&nbsp;&nbsp;&nbsp;";
									// Check if this assignment can be deleted on not, if it comes under a project, then it can't be deleted, else 
									// we can delete it.
									if (isProject == false)   
										canBeDeleted =true;
									else
										canBeDeleted = false;
										
										
										/*Added by Hamdy on 10-Dec-2007*/
										if( ds.Tables[0].Rows[i].descProject != "" )
										{
											canBeDeleted = false;
										}
										/*End of Added by Hamdy on 10-Dec-2007*/
										
										
									// determine row back and fore colors
									if (ds.Tables[0].Rows[i].AssStatus >= 3)
										{
											color = taskTextColor_completed;
											canBeDeleted = false;  // we can't delete completed task
											spcLength="   ";
										}
									else if (ds.Tables[0].Rows[i].unit == 10) // hour based task
										color = taskColor_hour;
									else if (ds.Tables[0].Rows[i].unit == 20) // count based task
										color = taskColor_count;
									else  if (ds.Tables[0].Rows[i].unit == 30)  // NC task
										color = taskColor_NC;
									else if (ds.Tables[0].Rows[i].unit == 40) // day off
										color = offdayColor;
								}
							// responsibility
							else if (ds.Tables[0].Rows[i].RecoredType == 20)
								{
								 isProject = false;
								 color = respColor;
								 spcLength="&nbsp;";
								 ds.Tables[0].Rows[i].taskname =  ds.Tables[0].Rows[i].taskname;
								 lastResp = i;
								}
							// project
							else if (ds.Tables[0].Rows[i].RecoredType == 30)
								{
									color = projectColor;
									spcLength="&nbsp;";
									isProject = true;  // set to be true, so any task come after it can't be deleted
								}
							//day off
							else if (ds.Tables[0].Rows[i].RecoredType == 40)
								color = dayoffColor;
								
							//--------------------------------------------------------
							// Draw accountability table
							if(document.all)
							{
							sheetTable[sheetTable.length] = "<tr id = task" + i +  " class = " +  color + "   onClick=selectRow(" + i + ",this.name) 		name ="+ ds.Tables[0].Rows[i].StrongID + "><div id=divCanBeDeleted" + i +" name=" +canBeDeleted + ">";
							}
							else if(document.getElementById)
							{
							sheetTable[sheetTable.length] = "<tr id = task" + i +  " class = " +  color + "   onClick=selectRow(" + i + ",this.name) 		name ="+ ds.Tables[0].Rows[i].StrongID + "><div id=divCanBeDeleted" + i +" name=" +canBeDeleted + ">";							
							}
							// insert task image--------------------------------------
							if (ds.Tables[0].Rows[i].RecoredType == 20)
								if(frmAccountability.IsRespClosed(ds.Tables[1].Rows[0].JobIndex,  ds.Tables[0].Rows[i].StrongID).value == true)
								{
								sheetTable[sheetTable.length] = "<td align=center width=17 class = " +  color + "></td>";
								}
								else
								{
								sheetTable[sheetTable.length] = "<td align=center width=17 class = " +  color + "><a href='#'><img src=images/AccAdd.png alt='Add Task' title='Add Task' onClick=newTask(" + i + ") border=0></a></td>";
								}
							else if (ds.Tables[0].Rows[i].RecoredType == 10 && color != taskTextColor_completed && canBeDeleted == true && color != offdayColor /*Added by Hamdy on 10-Dec-2007*//*&& ds.Tables[0].Rows[i].descProject == ""*//*End of Added by Hamdy on 10-Dec-2007*/)
								sheetTable[sheetTable.length] = "<td align=center width=17 class = " +  color + "><a href='#'><img border='0' src=images/AccEdit.png alt='Edit Task' title='Edit Task' onClick=editTask(" + lastResp + "," +  ds.Tables[0].Rows[i].StrongID + ") ></a></td>";
							else 
								sheetTable[sheetTable.length] = "<td width=17 class = " +  color + "></td>";
							//--------------------------------------------------------
							sheetTable[sheetTable.length] = "<td align=center width=15 class = " +  color + ">" + getValue(ds.Tables[0].Rows[i].ResponsPrioity) + "</td>";
							//written By Mostafa in 4 March 2007
							if(color == offdayColor)
							{
							sheetTable[sheetTable.length] = "<td align=center width=15   id=tdper" + i + " class = " +  color + "><div id=per" + i + ">" +getValue(ds.Tables[0].Rows[i].Taskpriority) + "</td>";
							}
							else
							{
							sheetTable[sheetTable.length] = "<td align=center width=15  onClick =selectCell('per" + i + "') id=tdper" + i + " class = " +  color + "><div id=per" + i + ">" +getValue(ds.Tables[0].Rows[i].Taskpriority) + "</td>";
							}
							//written By Basant 24-5-06
							if ((ds.Tables[0].Rows[i].RecoredType == 10 && color != taskTextColor_completed &&  color != offdayColor) && IsAdmin)
							  sheetTable[sheetTable.length] = "<td align=center width=16 class = " +  color + "><a href='#'><img border='0' src=images/Response.jpg alt='Change Responsibility' onClick=changeAssResponsibility(" + lastResp + "," +  ds.Tables[0].Rows[i].StrongID + ") ></a></td>";
							else
							  sheetTable[sheetTable.length] = "<td width=16 class = " +  color + "></td>";
							 //end basant
							sheetTable[sheetTable.length] = "<td  class = " +  color + "><div align=left id = divTask" + i + " name=" + ds.Tables[0].Rows[i].StrongID + " style='width=100%'>"+spcLength + ds.Tables[0].Rows[i].taskname+ "</div></td>";
							sheetTable[sheetTable.length] = "<td align=center width=51 class = " +  color + ">" + getUnitString(ds.Tables[0].Rows[i].unit) + "</td>";
 							sheetTable[sheetTable.length] = "<td width=58 align=center onClick =selectCell('sun" + i + "') id=tdsun" + i + " class = " +  color + "><div id=sun" + i + ">" + getValue(ds.Tables[0].Rows[i].sun) + "</td>";
							sheetTable[sheetTable.length] = "<td width=60 align=center onClick =selectCell('mon" + i + "') id=tdmon" + i + " class = " +  color + "><div id =mon" + i + ">" + getValue(ds.Tables[0].Rows[i].mon) + "</td>";
							sheetTable[sheetTable.length] = "<td width=60 align=center onClick =selectCell('tue" + i + "') id=tdtue" +  i + " class = " +  color + "><div id =tue" + i + ">" + getValue(ds.Tables[0].Rows[i].tue) + "</td>";
							sheetTable[sheetTable.length] = "<td width=60 align=center onClick =selectCell('wen" + i + "') id=tdwen" +  i + " class = " +  color + "><div id =wen" + i + ">" + getValue(ds.Tables[0].Rows[i].wen) + "</td>";
							sheetTable[sheetTable.length] = "<td width=60 align=center onClick =selectCell('thr" + i + "') id=tdthr" +  i + " class = " +  color + "><div id =thr" + i + ">" + getValue(ds.Tables[0].Rows[i].thr) + "</td>";
							sheetTable[sheetTable.length] = "<td width=60 align=center onClick =selectCell('fri" + i + "') id=tdfri" +  i + " class = " +  color + "><div id =fri" + i + ">" + getValue(ds.Tables[0].Rows[i].fri) + "</td>";
							sheetTable[sheetTable.length] = "<td width=60 align=center onClick =selectCell('sat" + i + "') id=tdsat" +  i + " class = " +  color + "><div id =sat" + i + ">" + getValue(ds.Tables[0].Rows[i].sat) + "</td>";
							sheetTable[sheetTable.length] = "<td width=60 align=center class = " +  color + ">" + getValue(ds.Tables[0].Rows[i].week) + "</td>";
							sheetTable[sheetTable.length] = "</tr>";	  	
						}
					sheetTable[sheetTable.length] = "</table>";
					// Render accountability table in sheet div
					document.getElementById('sheet').innerHTML = sheetTable.join("");	
			}
	// Hide animated wait image
	document.getElementById('wait').style.visibility = "hidden";
	}
//---------------------------------------------------------------------------------------------------
// bind jobs titles to listbox
function bindJobs()
{
	frmAccountability.BindJobs(bindJobs_CallBack);
}	
function bindJobs_CallBack(response)
{
	var ds = response.value;
	if (ds != null && typeof(ds) =="object" && ds.Tables != null)
				{
					for (var i=0;i<ds.Tables[0].Rows.length;i++)
						{
							addToList(document.getElementById('lstJob'),ds.Tables[0].Rows[i].JobName ,ds.Tables[0].Rows[i].JobTitleID,'job');			
						}
				}
	}
//---------------------------------------------------------------------------------------------------	
//bind departments to list box
function bindDepts()
{
	frmAccountability.BindDept(bindDepts_CallBack);
}
function bindDepts_CallBack(response)
{
	var ds = response.value;
	if (ds != null && typeof(ds) =="object" && ds.Tables != null)
				{
					for (var i=0;i<ds.Tables[0].Rows.length;i++)
						{
							addToList(document.getElementById('lstDept'),ds.Tables[0].Rows[i].CEName ,ds.Tables[0].Rows[i].CompElmentID,'dept');			
						}
				}
	}
//---------------------------------------------------------------------------------------------------
function bindTimingEmpData(value )
{
alert(value);
document.getElementById('txtDate').value=value;
//var x=ManageTiming.bindTimingEmpData(value);  // Get employee accountability sheet
}
// View given employee info
function bindEmpInfo(empID)
	{
	// added by Sayed 16/7/2009
	document.getElementById('DayNameAndDate').value="";
	// end
		if(DateClicked)
		{
			DisplayMessage();
			DateClicked = false;
		}
		//if(!checkHoursCount)
		//{
			//Added by Hamdy Ahmed on 26/07/2007
			//if(isModified)
			//{
			//	viewMode = currentViewMode;
			//	DisplayMessage();
			//	viewMode = document.getElementById('lstViewMode').value;
			//}
			//else
			//{
			//	if(CalendarOldDateChanged)
			//	{
			//		CalendarOldDate = document.getElementById('txtDate').value;
			//	}
			//}
		//}
		
		//End of Hamdy Modification
		//Added by Hamdy Ahmed on 06/09/2007
		//if(isModified)
		//{
		//	if(DisplayViewModeChangeMessage())
		//	{
		//		var saveIt = confirm("Sheet has been changed, save it or discard changed?");
		//		if(saveIt == true)
		//		{
		///			viewMode = currentViewMode;
		//			document.getElementById('lstViewMode').value = viewMode;
		//			return;
		//		}
		//		else if (saveIt == false)
		//		{
		//			isModified = false;
		//			//bindAccSheet(empID,document.getElementById('txtDate').value);  // Get employee accountability sheet
		//		}
		//	}
		//}
		//End of Hamdy Modification
		
		////Added by Hamdy Ahmed 0n 26/07/2007
		var DaysOffStatus ;// to enable and disable viewdaysoff checkbox
		if(document.getElementById('chkOffDays').checked)
		{
			DaysOffStatus = true;
		}
		else
		{
			DaysOffStatus = false;
		}
		////document.getElementById('lstViewMode').value
		////var DaysOffStatus;// = document.getElementById('chkOffDays').checked;
		
	if(viewMode == 30)
	{
		DaysOffStatus = document.getElementById('chkOffDays').checked;
		document.getElementById('chkOffDays').checked = false;
		document.getElementById('chkOffDays').disabled = true;
	}
	else
	{
			
		document.getElementById('chkOffDays').checked = DaysOffStatus;
		document.getElementById('chkOffDays').disabled = false;
	}
	//End of Hamdy
	
	
		document.getElementById('wait').innerHTML= "<font face='Arial, Helvetica, sans-serif' color=#FFFFFF size=1>Please wait</font><br><IMG height=7 src=images/loading.gif width=78>";
		document.getElementById('txtNote').value = "";  // reset note textbox
		try // to avoid problem of IE8 with freetextbox
		{
		setFreeTextBoxData("");
		}
		catch(error)
		{
		}
		// wrire employee id and name in global variables
		employeeID = empID;
		// hide resp, project and task text boxs
		showResp("hidden");
		showProject("hidden");	
		showTask("hidden");	
		
	if (empID != -1 && empID != 0 )   // If an employee is selected 
		{
		
		////Added by Hamdy Ahmed on 07_11_2007
		//for(int i=0; i<sheetLen; i++)
		//{
		//}
		//////////////////////////////////////
		
		employeeName = document.getElementById('lstEmployee').options[document.getElementById('lstEmployee').selectedIndex].text;
		document.getElementById('sheet').style.visibility = "visible";
		document.getElementById('headerDiv').style.visibility = "visible";
		// set sheet table height based on the screen resolution
		if(screen.height >= 1000)
			document.getElementById('tdSheet').height = 500;
		else if(screen.height >= 950)
			document.getElementById('tdSheet').height = 366;
		else if(screen.height >= 760)
			document.getElementById('tdSheet').height = 210;
		else if(screen.height == 800)
			document.getElementById('tdSheet').height = 100;
		document.getElementById('wait').style.visibility = "visible";  // Show animated wait image
		// firstly, get employee's job and department		
		bindEmpJobDept(empID);
		// secondly, load employee's accountability sheet
		showOffDays = document.getElementById('chkOffDays').checked;   // set showdaysoff variable
		bindAccSheet(empID,document.getElementById('txtDate').value);  // Get employee accountability sheet
		document.getElementById('btnSave').style.visibility = "visible";
		document.getElementById('btnDelete').style.visibility = "hidden";	
		document.getElementById('btnViewAssAcc').style.visibility = "hidden";	
		document.getElementById('btnCompleteTask').style.visibility = "hidden";	
		document.getElementById('btnPrint').style.visibility = "visible";
		//document.getElementById('legend').style.visibility = "visible";
		document.getElementById('txtResp').value = "";
		document.getElementById('txtProject').value= "";
		document.getElementById('txtTask').value= "";
	
		}
	else
		{
			document.getElementById('txtJob').value = "";
			document.getElementById('txtDept').value = "";
			document.getElementById('btnSave').style.visibility = "hidden";	
			document.getElementById('btnPrint').style.visibility = "hidden";	
			document.getElementById('legend').style.visibility = "hidden";
			sheet.style.visibility = "hidden";
			headerDiv.style.visibility = "hidden";
		}
		DisableNotes();
		DisableNotesEditingButton();
		//currentViewMode = document.getElementById('lstViewMode').value;
	}
//---------------------------------------------------------------------------------------------------
// get employee's job and department 
function bindEmpJobDept(empID)
{	
	var jobDept =  frmAccountability.BindEmpJobDept(empID).value;  // Get given employee dfepartment and job title as a string separated by comma
	var job = jobDept.substring(0,jobDept.indexOf(","));  // split job title
	var dept = jobDept.substring(jobDept.indexOf(",")+1 ,10);   // split department name	
	document.getElementById('txtJob').value =  document.getElementById('job' + job).text;
	document.getElementById('txtDept').value = document.getElementById('dept' + dept).text;		
	}
//---------------------------------------------------------------------------------------------------
// called when user select a row
function selectRow(indx,taskID,ID)
{
	if(IsNotesPopupOpened)// If the notes popup window is opened -----> return
			return;
	if(currentCellColor=="project" ||currentCellColor=="resp"||currentCellColor=="completetask")
	{
	//	DisableNotes();
		currentCell = -1;
	}
	else
	{
	//	EnableNotes();
		resetTextBox();
	}	
	
	if(putNotesIneditMode)
	{
		putNotesIneditMode = false;
		EnableNotes();
		EnableNotesEditingButton();
		//resetTextBox();
	}
	else
	{
		DisableNotes();
		DisableNotesEditingButton();
		//currentCell = -1;
	}
	
	// store given assignmentID in the global variable selectedAssID
	if(document.all)
	{
	selectedAssID = taskID; 
	}
	else if(document.getElementById)
	{
		selectedAssID = document.getElementById('task'+indx).attributes['name'].value;
	}
	//alert(selectedAssID);
	if (selectedIndex != indx)
   		{
			
			
			// reset text boxs
	
			document.getElementById('txtTask').value = "";
			document.getElementById('txtResp').value = "";
			document.getElementById('txtProject').value = "";
			//-----------
			selectedIndex = indx;
			if (lastColor != -1) 
				document.getElementById(task_index).className = lastColor;
			lastColor = document.getElementById("task" + indx).className;
			// Hide and show delete button based on the status of the selected aqssignment
			
			if(document.all)
			{
				if ( document.getElementById('divCanBeDeleted' + indx).name == "true" && lastColor !=offdayColor)
					{
					document.getElementById('btnDelete').style.visibility = "visible";
					}
				else
					{
					document.getElementById('btnDelete').style.visibility = "hidden";	
					}
			}
			else if(document.getElementById)
			{
				if (document.getElementById('divCanBeDeleted' + indx).attributes['name'].value == "true" && lastColor !=offdayColor)
					{
					document.getElementById('btnDelete').style.visibility = "visible";
					}
				else
					{
					document.getElementById('btnDelete').style.visibility = "hidden";	
					}
			}
			document.getElementById("task" + indx).bgColor =selectedRowColor;
			//document.getElementById("task" + indx).focus();
			task_index = "task"+indx;
			
			// the current selected row is for a task
			if (lastColor == taskColor_hour  || lastColor == taskColor_count || lastColor == taskColor_NC || lastColor ==taskTextColor_completed )
				{
				showTask("visible");	
				showResp("visible");
				document.getElementById('btnCompleteTask').style.visibility = "visible";
				document.getElementById('btnViewAssAcc').style.visibility = "visible"; // view assignment accountability
				
				document.getElementById('txtTask').value = document.getElementById('divTask' + indx).innerHTML.replace(/&nbsp;/g,"").replace('&amp;','&');
				if (respArray[indx] != "" && respArray[indx] != null)
				{
				document.getElementById('txtResp').value = respArray[indx].replace(/&nbsp;/g,"");
				}
				
				if (projectArray[indx] != "" &&projectArray[indx] != null)
					{
					showProject("visible");
					document.getElementById('txtProject').value = projectArray[indx].replace(/&nbsp;/g,"");
					}
				else // hide project textbox
					showProject("hidden");
				}
			else
				{
					// resposibility selected
					if (lastColor == respColor)
						{
							showResp("visible");
							showProject("hidden");	
							showTask("hidden");	
							document.getElementById('txtResp').value = document.getElementById('divTask' + indx).innerHTML.replace(/&nbsp;/g,"").replace(/&amp;/g,"&");
						}
					// Project selected
					if (lastColor == projectColor)
						{
							showResp("hidden");
							showProject("visible");	
							showTask("hidden");	
							document.getElementById('txtProject').value =document.getElementById('divTask' + indx).innerHTML.replace(/&nbsp;/g,"");
						}
				document.getElementById('btnCompleteTask').style.visibility = "hidden";
				document.getElementById('btnViewAssAcc').style.visibility = "hidden";
				}
			// if selcted task is completed ... don't show days note, rather show completed task note
			if (lastColor == taskTextColor_completed)
				{
				document.getElementById('txtNote').value = taskDescArray[indx];
				
				// added by Said to avoid peoblems of IE8 with freeTextBox
				try
				{
				setFreeTextBoxData(taskDescArray[indx]);
				}
                catch(err)
               {}
				//document.getElementById('txtNote').disabled = "true";
				//document.getElementById('btnCompleteTask').style.visibility = "hidden";
				}				
			// off day
			if (lastColor == offdayColor )
				{
				////////////document.getElementById('btnCompleteTask').style.visibility = "hidden";
				document.getElementById('btnViewAssAcc').style.visibility = "visible";

					showResp("hidden");
					showProject("hidden");	
					showTask("hidden");	
				}
   		}
   		
   		//If the task is closed, disable the day note textbox and hide the close task button:

   		if (lastColor == taskTextColor_completed)
			{
				document.getElementById('txtNote').disabled = "true";
				//document.getElementById('txtNote').value = "";
				//document.getElementById('btnCompleteTask').style.visibility = "hidden";
			}		
				
				
 	if (lastSelectedCell != -1)  // Reset the color of the last selected cell to its original value 
		{		
			// reset the color of selected cell
			document.getElementById('td' + lastSelectedCell).className = lastSelectedCellColor;
		}
	if (currentCell != -1)
		{
		document.getElementById('td' + currentCell).className = selectedCellColor;
		editCell();  // set cell in edit mode, view editable text box
		}
}
//---------------------------------------------------------------------------------------------------
// get the unit text corresponding to the given unitID
function getUnitString(unitID)
{
	if (unitID == 10||unitID == 40)
		return "<b>hrs.";
	else if (unitID == 20)
		return "<b>#";
	else
		return "";
	}
//---------------------------------------------------------------------------------------------------
// return empty string if the given variable is 0 or null, else return the number as it's
function getValue(accValue)
{
	if (accValue <= 0 || accValue ==null)
		return "  "
	else
		return accValue;
	}
//---------------------------------------------------------------------------------------------------
// save accountability sheet
function saveSheet(value)
{

     // Updated by :Sayed Moawad  Date:12/06/2008
			// value=0 mean last Date
			// value=1 mean current Date
			
	//var satDayAndDate = document.getElementById('hdrsatday').outerText;
	//var satDate = satDayAndDate.substring(3);
	//var xDate = Date.parse(satDate);
	//var yDate = Date.parse(document.getElementById('txtDate').value);
	//if(yDate > xDate)
	//{
	//	alert('date is bigger');		
	//	return;
	//}
	var sheet = new Array;
	var i;
	var arrItem;
	var notes = new Array;
	var totalCount=0;
	document.getElementById('wait').style.visibility = "visible";
	// Prepare days note array
	notes[0] = escape(unescape(document.getElementById('sunday').value.replace(/&/g,"@@0937107@@")));
	notes[1] = escape(unescape(document.getElementById('monday').value.replace(/&/g,"@@0937107@@")));
	notes[2] = escape(unescape(document.getElementById('tueday').value.replace(/&/g,"@@0937107@@")));
	notes[3] = escape(unescape(document.getElementById('wenday').value.replace(/&/g,"@@0937107@@")));
	notes[4] = escape(unescape(document.getElementById('thrday').value.replace(/&/g,"@@0937107@@")));
	notes[5] = escape(unescape(document.getElementById('friday').value.replace(/&/g,"@@0937107@@")));
	notes[6] = escape(unescape(document.getElementById('satday').value.replace(/&/g,"@@0937107@@")));

	
	resetTextBox();  // Reset last edited cell
	// reset all variable hloding current selected sell status
	lastSelectedCell = -1;
	currentDay = -1;  
	currentCell = -1;
		var msg = validateInputs();   // Validate sheet inputs
		if(msg == "")   // if msg is empty, this means that we have no trouble saving accountability sheet
		{
			for (i=0; i<sheetLen ;i++)
				{
					arrItem = document.getElementById('sun' + i ).innerHTML ;
					arrItem = arrItem + ',' +  document.getElementById('mon' + i ).innerHTML;
					arrItem = arrItem + ',' + document.getElementById('tue' + i ).innerHTML;
					arrItem = arrItem + ',' + document.getElementById('wen' + i ).innerHTML;
					arrItem = arrItem + ',' + document.getElementById('thr' + i ).innerHTML;
					arrItem = arrItem + ',' + document.getElementById('fri' + i ).innerHTML;
					arrItem = arrItem + ',' + document.getElementById('sat' + i ).innerHTML;
					sheet[i]  = arrItem;
					
				}
					
			//if(CalendarOldDateChanged)
			//{		
			//	frmAccountability.SaveSheet(sheet,employeeID,CalendarOldDate,notes,showOffDays,viewMode);
			//	CalendarOldDateChanged=false;
			//}
			//else
			//{
			
			
			// Get last Date before select calender
			var SaveDate;
			if(DateChanged != document.getElementById('txtDate').value)
			{
				SaveDate = DateChanged;
			}
			else
			{
				SaveDate = document.getElementById('txtDate').value;
			}
			// Updated by :Sayed Moawad  Date:12/06/2008
			// value=0 mean last Date
			// value=1 mean current Date
//			alert('About to save sheet ISA');
			if(value==0)
			{
			frmAccountability.SaveSheet(sheet,employeeID,SaveDate,notes,showOffDays,viewMode);
//			alert('Saved 1');
			}
			else
			{
			frmAccountability.SaveSheet(sheet,employeeID,document.getElementById('txtDate').value,notes,showOffDays,viewMode);
//			alert('Saved 2');
			}
			
			// end of Updated by: Sayed Moawad Date:12/06/2008
			
			
			//frmAccountability.SaveSheet(sheet,employeeID,document.getElementById('txtDate').value,notes,showOffDays,viewMode);
			//}
			//currentViewMode = viewMode = document.getElementById('lstViewMode').value;
			////// get all assignments IDs and periorities arrays and load them in [assIDsArray] and [assPriorityArray]
			getPrioritiesArrays();
//			alert('About to save periorities');
			frmAccountability.SavePriorities(assIDsArray,assPriorityArray);
//			alert('Periorities saved');
			isModified=false;
			NoteFlage = false;
		}
		else  // user inputs are invalid, show the error message
		{
			//Added by Hamdy Ahmed to show only one message 
			isModified = false;
			frmAccountability.ChangeSaveSession2();
			//End of Hamdy
			alert(msg);
		}
		// Rebind current employee accountability sheet
//		alert('About to load sheet');
		bindEmpInfo(document.getElementById('lstEmployee').options[document.getElementById('lstEmployee').selectedIndex].value);
				document.getElementById('wait').innerHTML= "<font face='Arial, Helvetica, sans-serif' color=#FFFFFF size=1>Saved, Please wait...</font><br><IMG height=7 		            src=images/loading.gif width=78>";
//				alert('Emp sheet loaded');
		DisableNotes();
//		alert('Finished');
}
//---------------------------------------------------------------------------------------------------
// Select previous employee in employee listbox
function nextEmp()
{
	if (document.getElementById('lstEmployee').selectedIndex != document.getElementById('lstEmployee').length -1)
		{
			document.getElementById('lstEmployee').selectedIndex = document.getElementById('lstEmployee').selectedIndex + 1;
			bindEmpInfo(document.getElementById('lstEmployee').options[document.getElementById('lstEmployee').selectedIndex].value);	
		}
	DisableNotes();
}
//---------------------------------------------------------------------------------------------------
// Select previous employee in employee listbox
function prevEmp()
{
	if (document.getElementById('lstEmployee').selectedIndex != 0)
		{
		document.getElementById('lstEmployee').selectedIndex = document.getElementById('lstEmployee').selectedIndex - 1;
		bindEmpInfo(document.getElementById('lstEmployee').options[document.getElementById('lstEmployee').selectedIndex].value);
		}
		DisableNotes();
}
//---------------------------------------------------------------------------------------------------
// Open task webform to add a new task 
function newTask(i)
{
	DisplayMessage();
	// close last pop-up if exists.
	if (wndHandle && wndHandle.open)
			wndHandle.close();
		
	var respID = document.getElementById('divTask' + i).attributes['name'].value;
	var respName = document.getElementById('divTask' + i).innerHTML.replace(/&nbsp;/g,"").replace('&amp;','_*_');
	wndHandle = window.open("frmPopup.aspx?type=addTask&vars=" + employeeID + "$" + employeeName + "$" + respID + "$" + respName ,"",
	"status,menubar=no,height=350,width=800,scrollbars=yes");
}
//---------------------------------------------------------------------------------------------------
// edit given task, where i is the index of the task in accountability table and taskID is the ID of this task
function editTask(i,taskID)
{
	DisplayMessage();
	// close last pop-up if exists.
	if (wndHandle && wndHandle.open)
			wndHandle.close();
			
	var respID = document.getElementById('divTask' + i).attributes['name'].value
	//alert(respID);
	var respName =document.getElementById('divTask' + i).innerHTML.replace(/&nbsp;/g,"").replace('&amp;','_*_');
	if(viewMode == 40)
	{
	    respName = -1;
	}
	//alert(respName);
	//alert("frmPopup.aspx?type=editTask&vars=" + employeeID + "$" + employeeName + "$" + respID + "$" + respName  + "$" + taskID,"",
	//"status,menubar,height=350,width=800,scrollbars=yes");
	wndHandle = window.open("frmPopup.aspx?type=editTask&vars=" + employeeID + "$" + employeeName + "$" + respID + "$" + respName  + "$" + taskID,"",
	"status,menubar=no,height=350,width=800,scrollbars=yes");
}
//---------------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------------
// change Assignmnet Responsibility given the responsibility and task ID where i is the task responsibility
function changeAssResponsibility(i,taskID)
{
	// close last pop-up if exists.
	if (wndHandle && wndHandle.open)
			wndHandle.close();
			
	var respID = document.getElementById('divTask' + i).attributes['name'].value
	var respName = document.getElementById('divTask' + i).innerHTML.replace(/&nbsp;/g,"").replace('&amp;','_*_');
	wndHandle = window.open("frmPopup.aspx?type=changeResp&vars=" + employeeID + "$" + employeeName + "$" + respID + "$" + respName  + "$" + taskID,"",
	"status,menubar=no,height=350,width=800,scrollbars=yes");
}
//---------------------------------------------------------------------------------------------------
// Open employee window as a pop-up, used to search for a particular employee
function openEmpWnd()
{
	// close last pop-up if exists.
	if (wndHandle && wndHandle.open)
			wndHandle.close();
	wndHandle = window.open("frmPopup.aspx?type=findemp","",
	'resizable=yes,scrollbars=yes,menubar=yes,height=600,width=800,top=30,left=100');
	}
//---------------------------------------------------------------------------------------------------
// Select employee in employee listbox whose ID is saved in the global variable [employeeID] 
function selectEmp()
{
	var j=0;
	if (employeeID != -1)
	{		
		for ( j=0;j<= document.getElementById('lstEmployee').length-1;j++)
			{
				if (document.getElementById('lstEmployee').options[j].value == employeeID)
					{
						document.getElementById('lstEmployee').selectedIndex = j;
						break;
					}
			}
	}
}
//---------------------------------------------------------------------------------------------------
// Refresh accountability form, called on focus on accountability form
function refreshForm()
	{
		if (isFocused == false)
			{
				selectEmp(employeeID);
				bindEmpInfo(employeeID);
				isFocused = true;
			}
	}
//---------------------------------------------------------------------------------------------------
// Save day note text, it's saved in the hidden field [currentDay]
function saveNote()
	{
		if (currentDay != -1)
			{
				//document.getElementById(currentDay).value = document.getElementById('txtNote').value;
				var val = FTB_API['FreeTextBox1'].GetHtml();
				document.getElementById(currentDay).value = val;
			}
	}
//---------------------------------------------------------------------------------------------------
// Delete selected assignment, current selected assignment is saved in global variable [selectedAssID]
function deleteAssignment()
	{
		var assID = selectedAssID;
		DisplayMessage();
		//frmAccountability.DeleteAss(assID,deleteAssignment_CallBack).value;	
		var x = frmAccountability.DeleteAss(assID,deleteAssignment_CallBack).value;	
		DisableNotes();
		
		isModified = false;
		isFocused = false;
		refreshForm();
	}
	
function deleteAssignment_CallBack(responce)
	{
		if ( responce.value == -1 ) 
		{
			alert( " Task has not been deleted because you have not access right or the task has previous entries ");
			
		}
		isModified = false;
		isFocused = false;
		refreshForm();
	}
//---------------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------------
// Complete assignment, current selected assignment is saved in global variable [selectedAssID]
function completeAssignment()
	{
		// close last pop-up if exists.
		if (wndHandle && wndHandle.open)
			wndHandle.close();
			
			var proj = document.getElementById('txtProject').value;
	if(proj == null || proj == "")
	{
	var Tname = document.getElementById('divTask' + selectedIndex).innerHTML.replace(/&nbsp;/g,"") ;
	//alert(req);
	wndHandle = window.open("frmPopup.aspx?type=completetask&vars=" + selectedAssID + "$" +Tname + "$" + document.getElementById('txtDate').value ,"",
	"scrollbars=yes,status=yes,height=200,width=800,top=30,left=100");
	}
	else
	{
	frmPopup.MComplete(selectedAssID, document.getElementById('txtDate').value, true);
	isFocused = false;
	refreshForm();
	}
	DisableNotes();
	}
function completeAssignment_CallBack(responce)
	{
		isFocused = false;
		refreshForm();
	}
//---------------------------------------------------------------------------------------------------
// Open report veiwer pop-up window
function openReportViewer(type)
	{
		// close last pop-up if exists.
		if (wndHandle && wndHandle.open)
			wndHandle.close();
			
		if (type == 1) //1 = single employee accountability sheet  
		{
			var dept = document.getElementById('lstDept').options[document.getElementById('lstDept').selectedIndex].text;
			var job = document.getElementById('lstJob').options[document.getElementById('lstJob').selectedIndex].text;
			wndHandle = window.open("frmReportViewer.aspx?type=1&vars=" + employeeID + "," + document.getElementById('txtDate').value + "," + employeeName + "," + dept + "," + job + "," + document.getElementById('chkOffDays').checked  + "," + viewMode ,"",
			"resizable=yes,scrollbars=yes,menubar=yes,status=yes,height=600,width=800,top=30,left=100");
		}
		else if (type == 2) // total accountability sheet
		{
			wndHandle = window.open("frmReportViewer.aspx?type=2&vars=" + document.getElementById('txtDate').value ,"",
			"resizable=yes,scrollbars=yes,menubar=yes,status=yes,height=600,width=800,top=30,left=100");
		}
			
			
		if (type == 3) // Get Task Summary for the selected employee within a period of time
		{
			var dept = document.getElementById('lstDept').options[document.getElementById('lstDept').selectedIndex].text;
			var job = document.getElementById('lstJob').options[document.getElementById('lstJob').selectedIndex].text;
			wndHandle = window.open("frmReportViewer.aspx?type=3&vars=" + employeeID + "," + document.getElementById('txtDate').value + "," + employeeName + "," + dept + "," + job + "," + document.getElementById('chkOffDays').checked  + "," + viewMode ,"",
	"resizable=yes,scrollbars=yes,menubar=yes,status=yes,height=600,width=800,top=30,left=100");
		}
	}
//---------------------------------------------------------------------------------------------------
// Set selection on given cell
function selectCell(cell)
	{	
		if(IsNotesPopupOpened)// If the notes popup window is opened -----> return
			return;
		if (currentCell != cell)  // If the given cell is not already selected
			{
				// sheet is in edit mode
				isSheetInEditMode = true;
				if (cell.substring(0,3) != "per" )
					currentDay =cell.substring(0,3) + 'day';  // get day name, ex: sunday,monday
				if (currentCell != -1)
					{
						
						lastSelectedCell	= currentCell;
						lastSelectedCellColor = currentCellColor;

					}
				resetTextBox(); // reset text box;
				currentCell = cell;
				currentCellColor = document.getElementById('td' + currentCell).className;
				
				if(currentCellColor == "normaltask" || currentCellColor == "nctask" || currentCellColor == "counttask" || currentCellColor == "offday_offday")
				{
					EnableNotes();
					//resetTextBox();
					putNotesIneditMode = true;
					EnableNotesEditingButton();
				}
				else
				{
					DisableNotes();
					putNotesIneditMode = false;
					DisableNotesEditingButton();
				}


				// begin basant 05-07-2006
				if ((cell.substring(0,3) != "per" ))
				{
					if (lastSelectedDay != "")
						document.getElementById('hdr' + lastSelectedDay ).className = "headertd";
					lastSelectedDay = currentDay;
					document.getElementById('hdr' + currentDay  ).className = "selectedheadertd";
				}
				// end basant
				
				
				// read the note body from the DIV element 
				
				if ((cell.substring(0,3) != "per" ) && (currentCellColor != taskTextColor_completed))
					{
						if ( document.getElementById(cell.substring(0,3) + 'day').value  != 'null')		
							{
							var dateValue= document.getElementById('hdr'+cell.substring(0,3)+'day').innerText;
							var dateValue1=dateValue.substring(0,3);
							var dateValue2=dateValue.substring(5,16);
							if(dateValue1=="Thu")
							{
							dateValue1="Thur ";
							dateValue2=dateValue.substring(6,16);
							
							}
							else dateValue1+=" ";
							//alert(dateValue1+dateValue2);
							document.getElementById('DayNameAndDate').value=dateValue1+" "+dateValue2;
							
							var NoteText = unescape(document.getElementById(cell.substring(0,3) + 'day').value.replace(/@@0937107@@/g,"&")) ;	
							document.getElementById('txtNote').value = NoteText;
							//setFreeTextBoxData(NoteText);
							
                              try  
                              {
                                  setFreeTextBoxData(NoteText);
                               }
                                catch(err)
                               {}

							}
						else
							{
							document.getElementById('txtNote').value = '';
							document.getElementById('DayNameAndDate').value= '';
							//setFreeTextBoxData('');
														
                              try  
                              {
                                  setFreeTextBoxData('');
                               }
                                catch(err)
                               {}
							}
					}
			}
			else
			{
				resetTextBox(); // reset text box;
				currentCell = cell;
			}

	}
//---------------------------------------------------------------------------------------------------
// Key press event handler
function onKeyDownHandler()
	{
		var indx;
		var curCell;
		try
		{		
		if(isSheetInEditMode == true)
		  {
			// up-arrow pressed
			indx = currentCell.substring(3,10);
			if (window.event.keyCode == 38)
				{
					if (indx > 0)
					{
						resetTextBox();
						indx = indx-1;
						selectCell(currentCell.substring(0,3) + indx);
						selectRow(indx,document.getElementById('task'+indx).attributes['name'].value);
						//document.getElementById('tasktable').focus();
						currentCell = currentCell.substring(0,3) + indx;
						setFocus();
					}
				}
			//Down arrow
			else if (window.event.keyCode == 40)
				{
					if (indx < sheetLen-1)
					{
						resetTextBox();
						indx = parseInt(indx) +1;
						selectCell(currentCell.substring(0,3) + indx);
						selectRow(indx,document.getElementById('task'+indx).attributes['name'].value);
						//document.getElementById('task' + indx).focus();
						currentCell = currentCell.substring(0,3) + indx;
						setFocus();
					}
				}
			//Right arrow
			else if (window.event.keyCode == 39)
				{
					resetTextBox();
					switch(currentCell.substring(0,3))
						{
							case "sun":
								curCell = "mon" +  currentCell.substring(3,10);
								break;
							case "mon":
								curCell = "tue" +  currentCell.substring(3,10);
								break;
							case "tue":
								curCell = "wen" +  currentCell.substring(3,10);
								break;
							case "wen":
								curCell = "thr" +  currentCell.substring(3,10);
								break;
							case "thr":
								curCell = "fri" +  currentCell.substring(3,10);
								break;
							case "fri":
								curCell = "sat" +  currentCell.substring(3,10);
								break;
							case "sat":
								curCell = currentCell;
								break;
							
						}
					selectCell(curCell);
					selectRow(indx,document.getElementById('task'+indx).attributes['name'].value);
					currentCell = curCell;
					setFocus();
				}
			//Left arrow
			else if (window.event.keyCode == 37)
				{
				resetTextBox();
				switch(currentCell.substring(0,3))
						{
							case "mon":
								curCell = "sun" +  currentCell.substring(3,10);
								break;
							case "tue":
								curCell = "mon" +  currentCell.substring(3,10);
								break;
							case "wen":
								curCell = "tue" +  currentCell.substring(3,10);
								break;
							case "thr":
								curCell = "wen" +  currentCell.substring(3,10);
								break;
							case "fri":
								curCell = "thr" +  currentCell.substring(3,10);
								break;
							case "sat":
								curCell = "fri" +  currentCell.substring(3,10);
								break;
							case "sun":
								curCell = currentCell;
								break;
							
						}
					selectCell(curCell);
					selectRow(indx,document.getElementById('task'+indx).attributes['name'].value);
					currentCell = curCell;
					setFocus();
				}
		  } // end if		  
		}
		catch(objectError)
			{}
	}
//---------------------------------------------------------------------------------------------------
// Reset editaable text box, and save its value in the underlying cell
function resetTextBox()
	{
		try
			{
				if (currentCell != -1)
						{
							
							if ( !isNaN(document.getElementById("txtEdit").value))
								{
									// Hour count must be a float number from 0 to 24
									if ( (document.getElementById("txtEdit").value > 24) && (lastColor==taskColor_count ||lastColor==taskColor_NC) )
										//document.getElementById(currentCell).innerHTML = "";
										document.getElementById(currentCell).innerHTML = document.getElementById("txtEdit").value;
									else if( (lastColor==taskColor_hour) && (currentCell.substring(0,3)=="per"))
										 document.getElementById(currentCell).innerHTML = document.getElementById("txtEdit").value;
									else if((document.getElementById("txtEdit").value > 24) ||  (document.getElementById("txtEdit").value <= 0 ) && (lastColor==taskColor_hour)  )
											document.getElementById(currentCell).innerHTML = "";
									else  // else, write empty
										document.getElementById(currentCell).innerHTML =  document.getElementById("txtEdit").value;
								}
							else
								document.getElementById(currentCell).innerHTML = "";
						}
			}
			catch(objectError)
			{}	
	}
//---------------------------------------------------------------------------------------------------
// The following functions used to format given date
function LZ(x) {return(x<0||x>9?"":"0")+x}
function formatDate(date,format) {
	format=format+"";
	var result="";
	var i_format=0;
	var c="";
	var token="";
	var y=date.getYear()+"";
	var M=date.getMonth()+1;
	var d=date.getDate();
	var E=date.getDay();
	var H=date.getHours();
	var m=date.getMinutes();
	var s=date.getSeconds();
	var yyyy,yy,MMM,MM,dd,hh,h,mm,ss,ampm,HH,H,KK,K,kk,k;
//	 Convert real date parts into formatted versions
	var value=new Object();
	if (y.length < 4) {y=""+(y-0+1900);}
	value["y"]=""+y;
	value["yyyy"]=y;
	value["yy"]=y.substring(2,4);
	value["M"]=M;
	value["MM"]=LZ(M);
	value["MMM"]=MONTH_NAMES[M-1];
	value["NNN"]=MONTH_NAMES[M+11];
	value["d"]=d;
	value["dd"]=LZ(d);
	value["E"]=DAY_NAMES[E+7];
	value["EE"]=DAY_NAMES[E];
	value["H"]=H;
	value["HH"]=LZ(H);
	if (H==0){value["h"]=12;}
	else if (H>12){value["h"]=H-12;}
	else {value["h"]=H;}
	value["hh"]=LZ(value["h"]);
	if (H>11){value["K"]=H-12;} else {value["K"]=H;}
	value["k"]=H+1;
	value["KK"]=LZ(value["K"]);
	value["kk"]=LZ(value["k"]);
	if (H > 11) { value["a"]="PM"; }
	else { value["a"]="AM"; }
	value["m"]=m;
	value["mm"]=LZ(m);
	value["s"]=s;
	value["ss"]=LZ(s);
	while (i_format < format.length) {
		c=format.charAt(i_format);
		token="";
		while ((format.charAt(i_format)==c) && (i_format < format.length)) {
			token += format.charAt(i_format++);
			}
		if (value[token] != null) { result=result + value[token]; }
		else { result=result + token; }
		}
	return result;
	}
//---------------------------------------------------------------------------------------------------
//Clear Forms, reset accountability table and header
function clearForm()
{
	if (employeeID == -1)
	{
		document.getElementById('sheet').innerHTML = "";
		document.getElementById('sheet').style.visibility = "hidden";
		document.getElementById('headerDiv').innerHTML = "";
		document.getElementById('headerDiv').style.visibility = "hidden";
	}
}
//---------------------------------------------------------------------------------------------------
//get day index
//0 sun. 1 mon ...... 6 sat
function getDayCode(day)
{
	if(day == 'sun')
		return 0;
	if(day == 'mon')
		return 1;
	if(day == 'tue')
		return 2;
	if(day == 'wen')
		return 3;
	if(day == 'thr')
		return 4;
	if(day == 'fri')
		return 5;
	if(day == 'sat')
		return 6;	
}
//---------------------------------------------------------------------------------------------------
// validate sheet input, be sure that total count of hours in each day is less than 24
function validateInputs()
{
	var msg="";
	var days = new Array;
	var daysout = new Array;
	var totalCount=0;
	daysout[0] = 'Sun';
	daysout[1] = 'Mon';
	daysout[2] = 'Tues';
	daysout[3] = 'Wednes';
	daysout[4] = 'Thurs';
	daysout[5] = 'Fri';
	daysout[6] = 'Satur';
	
	days[0] = 'sun';
	days[1] = 'mon';
	days[2] = 'tue';
	days[3] = 'wen';
	days[4] = 'thr';
	days[5] = 'fri';
	days[6] = 'sat';


	////Added By Hamdy Ahmed on 07_11_2007
	//var TempViewMode = viewMode;
	//viewMode = 10;
	//checkHoursCount = true;
	//var selectedEmp = frmAccountability.GetSelectedEmp().value;    // get last selected employee from the server session.
	//bindEmpInfo(selectedEmp);
	////End of Hamdy Ahmed////////////////
	
	
	if(!showOffDays)
		{
			var values = frmAccountability.CheckHoursCount(employeeID,document.getElementById('txtDate').value,showOffDays,10,viewMode).value;
		}
	var i= 0;
	for (j =0;j<7 ;j++)
	{
		for(i=0; i<sheetLen ;i++)
			{
				
				// only caculate total for hour based tasks
				var c = document.getElementById('tdsun' + i ).className;//
				if (parseFloat(document.getElementById(days[j] + i ).innerHTML) > 0.0   && ((c == taskColor_hour || c== selectedCellColor && lastColor== taskColor_hour) || (c == taskTextColor_completed || c== selectedCellColor && lastColor== taskColor_hour) || (c == offdayColor || c== selectedCellColor && lastColor== offdayColor)))
					
					totalCount = parseFloat(totalCount) +  parseFloat(document.getElementById(days[j] + i ).innerHTML);
			}
			//if(viewMode == 30)
			//{
			//	totalCount += values[j];
			//}
			if(!showOffDays)
			{
				totalCount += values[j];
			}
	if(totalCount > 24)
		{
				msg = msg + 'total tasks hours on ' + daysout[j]  + 'day should be less than 24 it is '+totalCount+' \n';
		}	
	totalCount  = 0;
	}
	
	////Added By Hamdy Ahmed on 07_11_2007
	//viewMode = TempViewMode;
	//var selectedEmp = frmAccountability.GetSelectedEmp().value;    // get last selected employee from the server session.
	//bindEmpInfo(selectedEmp);
	////End of Hamdy Ahmed////////////////
	
	return msg;
}
//---------------------------------------------------------------------------------------------------
// Set current cell in edit mode, the current editable cell name is save in the global variable [currentCell]
function editCell()
{
	
//if ((lastColor == taskColor_hour ||lastColor == taskColor_count ||lastColor == taskColor_NC || lastColor ==offdayColor)  & (lastSelectedCell != currentCell) )
if ((lastColor == taskColor_hour ||lastColor == taskColor_count ||lastColor == taskColor_NC || lastColor ==offdayColor) )
					{
						var theCell=document.getElementById(currentCell);
						var cellContent = "";
						var fieldValue=theCell.innerHTML;  
						if (currentCell.substring(0,3) == "per")  // User is editing assignment priority
							cellContent="<input class='btn' style='width:10;text-align:center;' id='txtEdit' type='text' onChange=ModifyDatagrid() >";
						else   // User is editing assignment accountability
							cellContent="<input class='btn' style='text-align:center;' size=4  id='txtEdit' type='text' onChange=ModifyDatagrid()>";
						theCell.innerHTML = cellContent;  
						document.getElementById('txtEdit').value = fieldValue;  
						document.getElementById('txtEdit').focus;
						document.getElementById('txtEdit').select();
						lastSelectedCell = currentCell;
					}	
}
//---------------------------------------------------------------------------------------------------
//Set focus on editable textbox in selected cell in accountability sheet
function setFocus()
{
document.getElementById('txtEdit').select();	
document.getElementById('txtEdit').focus;
}
//---------------------------------------------------------------------------------------------------
//Show/ Hide project textbox
function showProject(flag)
	{
		document.getElementById('divProject').style.visibility = flag;
		document.getElementById('txtProject').style.visibility = flag;
	}
//---------------------------------------------------------------------------------------------------
//Show/ Hide task textbox
function showTask(flag)
	{
		document.getElementById('divTask').style.visibility = flag;
		document.getElementById('txtTask').style.visibility = flag;
	}
//---------------------------------------------------------------------------------------------------
//Show/ Hide responsibility textbox
function showResp(flag)
	{
		document.getElementById('divResp').style.visibility = flag;
		document.getElementById('txtResp').style.visibility = flag;
	}
//---------------------------------------------------------------------------------------------------
// Set assignments IDs [assIDsArray] and corresponding periorities values [assPriorityArray].
function getPrioritiesArrays()
	{
		var j =0;
		var i=0;
		for (i=0;i<sheetLen ;i++)
			{
				var css = document.getElementById('task' + i).className;
				
				if ((css == taskColor_hour || css == taskColor_count || css == taskColor_NC || css ==offdayColor) )
					{
						assIDsArray[j] = document.getElementById('task' + i).attributes['name'].value;
						assPriorityArray[j] = document.getElementById('per' + i).innerHTML;		
						j++;
					}
			}
	}
//---------------------------------------------------------------------------------------------------

// written by basant 25-05-06
	function ModifyDatagrid()
	{
	   isModified=true
	   ChangeSaveSession();
	   DateChanged = document.getElementById("txtDate").value;
	}
	function DisplayMessage()
	{
		if(!popupIsDisplayed)
		{
			if(isModified==true)
			{
			answer = confirm("Unsaved data will be lost .. Do you want to save")

			if (answer !=0) 
			{ 
			// Updated by :Sayed Moawad  Date:12/06/2008
			// 0= last Date
		    		saveSheet(0);// will save with last Date
			}
			else if(answer == 0)
			{
					isModified = false;
					frmAccountability.ChangeSaveSession2();
			}
			}
			if(currentDay!=-1 && NoteFlage==true)
			{
				answer2 = confirm("Unsaved notes will be lost .. Do you want to save it");
				if(answer2!=0)
				{
				// Updated by :Sayed Moawad  Date:12/06/2008
		      	// 0= last Date
					saveSheet(0);
				}
			}
		}
	}
	
//---------------------------------------------------------------------------------------------------
//  change save session value
function ChangeSaveSession()
{
	frmAccountability.ChangeSaveSession();
}	

//---------------------------------------------------------------------------------------------------	
	
// end basant

function checknotelength()
{
	var txtNote = document.getElementById('txtNote');
	NoteFlage = true;
	ChangeSaveSession();
	return NoteFlage;
}     
function EnableNotes()
{
	document.getElementById('txtNote').disabled = false;
}
function DisableNotes()
{
	document.getElementById('txtNote').disabled = true;
}
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}


//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
function SendMail()
{
	var editorInstance = FCKeditorAPI.GetInstance('FCKeditor1') ;
	var notes = new Array;	
	var x = editorInstance.GetXHTML(true);
	notes[0] = escape(unescape(x));
	//var notes= editorInstance.GetXHTML(true);
	var from = document.getElementById('txtFrom').value;
	var to = document.getElementById('txtTo').value;
	var cc = document.getElementById('txtCC').value;
	var bcc = document.getElementById('txtBCC').value;
	var subject = document.getElementById('txtSubject').value;
	frmAccountability.SendMail(from,to,cc,bcc,subject,notes);
	Hide();
}

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
function setFreeTextBoxData(val)
{
	FTB_API['FreeTextBox1'].SetHtml(val);
}
function getFreeTextBoxData()
{
	var str = FTB_API['FreeTextBox1'].GetHtml();
	return str;
}
//function valueChanged()
//{
//	//alert('hi');
//	saveNote2();
//}
//function setTextChangedFunction()
//{
//	FTB_API['FreeTextBox1'].ClientSideTextChanged = valueChanged;
//}


function OpenNotes()
{
	// close last pop-up if exists.
		if (wndHandle && wndHandle.open)
			wndHandle.close();

	//var NoteText = document.getElementById("FreeTextBox1").value.replace(/=/g,'123!!!321');
	//NoteText =NoteText.replace(/#/g,"123!321");
	//wndHandle = window.open("frmNotes.aspx?NoteText="+NoteText,"","scrollbars=yes,status=yes,height=600,width=800,top=30,left=100");
	var empName = document.getElementById("lstEmployee").options[document.getElementById("lstEmployee").selectedIndex].text;
	var noteDate = getCurrentDate();// + " " + getCurrentTime();
	
	var NoteText = getFreeTextBoxData();
	//NoteText = NoteText.replace(/=/g,'123!!!321')
	//NoteText =NoteText.replace(/#/g,"123!321");
	document.getElementById('txtHiddenNotes').value=NoteText;//.replace(/</g,"123!321").replace(/>/g,'123!!!321');
	//frmAccountability.setNotesSession(NoteText);
	//wndHandle = window.open("frmNotes.aspx?NoteText="+NoteText,"","scrollbars=yes,status=yes,height=600,width=800,top=30,left=100");	
	////////////////////IsNotesPopupOpened=true;
	    wndHandle = window.open("frmNotes_test.aspx?empName="+empName+"&noteDate="+noteDate+"","","status=yes,height=800,width=800,top=30,left=100");
	//wndHandle = window.open("frmNotes_test.aspx?empName="+empName+"&noteDate="+noteDate+"","","status=yes,height=800,width=800,top=30,left=100");
		
	//wndHandle = window.showModalDialog("frmNotes.aspx","","scrollbars=yes,status=yes,height=800,width=800,top=30,left=100");
}

function OpenManagerNotes()
{
	// close last pop-up if exists.
		if (wndHandle && wndHandle.open)
			wndHandle.close();

	var empName = document.getElementById("lstEmployee").options[document.getElementById("lstEmployee").selectedIndex].text;
	var noteDate = document.getElementById('txtDate').value;//getCurrentDate();// + " " + getCurrentTime();
	////////////////////IsNotesPopupOpened=true;
	var NoteText = getFreeTextBoxData();
	document.getElementById('txtHiddenNotes').value=NoteText;
	var wndHandle = window.open("frmManagersNotes_test.aspx?empName="+empName+"&noteDate="+noteDate+"","","status=yes,height=800,width=800,top=30,left=100");
	//wndHandle.focus();
	//wndHandle = window.showModalDialog("frmNotes.aspx","","scrollbars=yes,status=yes,height=800,width=800,top=30,left=100");
}

function EnableNotesEditingButton()
{
	document.getElementById('imgEditNotes').disabled=false;	
	document.getElementById('imgZoomIn').disabled=false;
	
		//**************** For Testing *********************************************
	//if (FTB_Browser.isIE) 
	FTB_API['FreeTextBox1'].designEditor.document.body.contentEditable = true;
	//FTB_API['FreeTextBox1'].UpdateToolbars();	
	//FTB_API['FreeTextBox1'].SetToolbarItemsEnabledState();	
	//FTB_API['FreeTextBox1'].enableToolbars=true;
	//	// disable this html area
		//FTB_API['FreeTextBox1'].htmlEditor.disabled = 'true';
	//***************************************************************************
}

function DisableNotesEditingButton()
{
	document.getElementById('imgEditNotes').disabled=true;	
	document.getElementById('imgZoomIn').disabled=true;	
	
	//**************** For Testing *********************************************
	//if (FTB_Browser.isIE) 
	FTB_API['FreeTextBox1'].designEditor.document.body.contentEditable = false;
	//FTB_API['FreeTextBox1'].enableToolbars=false;
	//FTB_API['FreeTextBox1'].DisableAllToolbarItems();	
	//	// disable this html area
		//FTB_API['FreeTextBox1'].htmlEditor.disabled = 'true';
	//***************************************************************************
}

function getCurrentDate()
{
	var currentTime = new Date();
	var month = currentTime.getMonth() + 1;
	var day = currentTime.getDate();
	var year = currentTime.getFullYear();
	var noteDate = month+"/"+day+"/"+year;
	return noteDate;
}
function getCurrentTime()
{
	var currentTime = new Date();
	var hours = currentTime.getHours();
	var minutes = currentTime.getMinutes();
	var seconds = currentTime.getSeconds();
	var noteTime = hours +":"+minutes+":"+seconds;
	if(hours > 11)
	{
		noteTime += " PM";
	}
	else 
	{
		noteTime += " AM";
	}
	return noteTime;
}
function ZoomIn()
{
    alert("Zoom In...");
    document.getElementById("ftbTD").style.width="100%";
    document.getElementById("ftbTD").style.height="100%";
    document.getElementById("imgZoomIn").style.display="none";
    document.getElementById("imgZoomOut").style.display="inline";
}
function ZoomOut()
{
    document.getElementById("ftbTD").style.width="50%";
    document.getElementById("ftbTD").style.height="50%";
    alert("Zoom Out...");
    document.getElementById("imgZoomIn").style.display="inline";
    document.getElementById("imgZoomOut").style.display="none";
}
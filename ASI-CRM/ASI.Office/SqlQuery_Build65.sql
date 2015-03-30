set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- ALTER date:  24 Oct. 2011
-- Description:	Get branch order
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Branch_Order] 
(
	@ID int,
	@Notes nvarchar(100),
	@Order int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	Declare @RowsBeforeID AS int;

	
	--Search for account page no.
--	SELECT @RowsBeforeID = COUNT(BranchID) - 1
--	FROM Contact_Branches
--	WHERE BrnachName <= (SELECT BrnachName
--					FROM Contact_Branches
--					WHERE BranchID = @ID)

	if object_id('tempdb..#InnerT') is not null
		drop table #InnerT


	CREATE TABLE #InnerT(
		[BranchID] [int] NOT NULL,
		[BranchName] [nvarchar](255) NULL,
		[TypeID] [int] NULL,
		[BusSector] [int] NULL,
		[Fax] [nvarchar](25) NULL,
		[Phone] [nvarchar](25) NULL,
		[WebSite] [nvarchar](255) NULL,
		[IDStatus] [int] NULL,
		[Street1] [nvarchar](255) NULL,
		[City] [nvarchar](255) NULL,
		[ZipCode] [nvarchar](25) NULL,
		[CountryID] [int] NULL,
		[ReferedBy] [nvarchar](225) NULL,
		[EnterByID] [int] NULL,
		[EnterDate] [datetime] NULL,
		[EditByID] [int] NULL,
		[EditDate] [datetime] NULL,
		[Street2] [nvarchar](255) NULL,
		[BranchManagerID] [int] NULL,
		[BranchManagerEditDate] [datetime] NULL,
		[BranchManagerEditByID] [int] NULL,
		[BranchManagerAssignedDate] [datetime] NULL,
		[State] [nvarchar](100) NULL,
		[AccountID] [int] NULL,
		[MainOffice] [bit] NULL,
		[LastName] [nvarchar](255) NULL,
		[FirstName] [nvarchar](255) NULL,
		[ContactID] [int] NULL,
		[TypeName] [nvarchar](255) NULL,
		[CountryName] [nvarchar](255) NULL,
		[BussinessSectorName] [nvarchar](255) NULL,
		[StatusName] [nvarchar](255) NULL,
		[EnteredByName] [nvarchar](255) NULL,
		[EditByName] [nvarchar](255) NULL,
		[BranchManagerName] [nvarchar](255) NULL,
		[BranchManagerEditByName] [nvarchar](255) NULL,
		[AccountName] [nvarchar](255) NULL,
		[LastBranchNoteDate] [datetime] NULL,
		[RowNumber] [int] NULL,
		[PageNo] [int] NULL)


	INSERT INTO #InnerT ([BranchID],[BranchName],[TypeID],[BusSector],[Fax],[Phone],[WebSite],[IDStatus],[Street1],[City]
			,[ZipCode],[CountryID],[ReferedBy],[EnterByID],[EnterDate],[EditByID],[EditDate],[Street2]
			,[BranchManagerID],[BranchManagerEditDate],[BranchManagerEditByID],[BranchManagerAssignedDate]
			,[State],[AccountID],[MainOffice],[LastName],[FirstName],[ContactID],[TypeName],[CountryName]
			,[BussinessSectorName],[StatusName],[EnteredByName],[EditByName],[BranchManagerName]
			,[BranchManagerEditByName],[AccountName],[LastBranchNoteDate],[RowNumber],[PageNo])
	SELECT  [BranchID],[BranchName],[TypeID],[BusSector],[Fax],[Phone],[WebSite],[IDStatus],[Street1],[City]
			,[ZipCode],[CountryID],[ReferedBy],[EnterByID],[EnterDate],[EditByID],[EditDate],[Street2]
			,[BranchManagerID],[BranchManagerEditDate],[BranchManagerEditByID],[BranchManagerAssignedDate]
			,[State],[AccountID],[MainOffice],[LastName],[FirstName],[ContactID],[TypeName],[CountryName]
			,[BussinessSectorName],[StatusName],[EnteredByName],[EditByName],[BranchManagerName]
			,[BranchManagerEditByName],[AccountName],[LastBranchNoteDate],[RowNumber], ((RowNumber -1)/1) as PageNo
			FROM (SELECT  Contact_Branches.BranchID, Contact_Branches.BrnachName AS BranchName, Contact_Branches.TypeID, Contact_Branches.BusSector, 
			Contact_Branches.Fax, Contact_Branches.Phone, Contact_Branches.WebSite, Contact_Branches.IDStatus, Contact_Branches.Street1, Contact_Branches.City, 
			Contact_Branches.ZipCode, Contact_Branches.CountryID, Contact_Branches.ReferedBy, Contact_Branches.EnterByID, Contact_Branches.EnterDate, 
			Contact_Branches.EditByID, Contact_Branches.EditDate, Contact_Branches.Street2, Contact_Branches.BranchManagerID, 
			Contact_Branches.BranchManagerEditDate, Contact_Branches.BranchManagerEditByID, Contact_Branches.BranchManagerAssignedDate, 
			Contact_Branches.State, Contact_Branches.AccountID, Contact_Branches.MainOffice, Contact_ContactsInfo.LastName, 
			Contact_ContactsInfo.FirstName, Contact_ContactsInfo.ContactID, Main_SubCode_1.SCode AS TypeName, 
			Main_SubCode.SCode AS CountryName, Main_SubCode_2.SCode AS BussinessSectorName, Main_SubCode_3.SCode AS StatusName, 
			Sec_UserLogin_1.UserName AS EnteredByName, Sec_UserLogin_2.UserName AS EditByName, 
			Sec_UserLogin_3.UserName AS BranchManagerName, Sec_UserLogin.UserName AS BranchManagerEditByName, 
			Contact_Account.AName AS AccountName, (Select Max(NoteDate) from Contact_Notes where Contact_Notes.BranchID = Contact_Branches.BranchID) AS LastBranchNoteDate,
			ROW_NUMBER() OVER(ORDER BY Contact_Branches.BrnachName ASC) AS RowNumber
			
			FROM      Contact_Branches LEFT OUTER JOIN
					  Contact_Account ON Contact_Branches.AccountID = Contact_Account.AID LEFT OUTER JOIN
					  Sec_UserLogin ON Contact_Branches.BranchManagerEditByID = Sec_UserLogin.UID LEFT OUTER JOIN
					  Sec_UserLogin AS Sec_UserLogin_3 ON Contact_Branches.BranchManagerID = Sec_UserLogin_3.UID LEFT OUTER JOIN
					  Sec_UserLogin AS Sec_UserLogin_2 ON Contact_Branches.EditByID = Sec_UserLogin_2.UID LEFT OUTER JOIN
					  Sec_UserLogin AS Sec_UserLogin_1 ON Contact_Branches.EnterByID = Sec_UserLogin_1.UID LEFT OUTER JOIN
					  Main_SubCode AS Main_SubCode_3 ON Contact_Branches.IDStatus = Main_SubCode_3.SID LEFT OUTER JOIN
					  Contact_ContactsInfo ON Contact_Branches.BranchID = Contact_ContactsInfo.BranchID LEFT OUTER JOIN
					  Main_SubCode ON Contact_Branches.CountryID = Main_SubCode.SID LEFT OUTER JOIN
					  Main_SubCode AS Main_SubCode_2 ON Contact_Branches.BusSector = Main_SubCode_2.SID LEFT OUTER JOIN
					  Main_SubCode AS Main_SubCode_1 ON Contact_Branches.TypeID = Main_SubCode_1.SID
			WHERE 
				((((Select Max(NoteDate) from Contact_Notes where Contact_Notes.BranchID = Contact_Branches.BranchID) is Not NULL AND @Notes = '1'))
				OR (((Select Max(NoteDate) from Contact_Notes where Contact_Notes.BranchID = Contact_Branches.BranchID) is NULL OR @Notes = '2'))
				AND (@Notes <> '1' AND @Notes <> '2'))
			) temp
	--		WHERE    RowNumber > @StartRow
	--			AND RowNumber <= @StartRow + @PageSize
			ORDER BY [BranchName] ASC
		
	SELECT 	@RowsBeforeID = PageNo
	FROM #InnerT
	WHERE  [BranchID] = @ID

	SELECT 	*
	FROM #InnerT

	drop table #InnerT
	
	
	SET @Order = @RowsBeforeID - 1
		
	
END
Go


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

-- =============================================
-- Author:		Sayed Moawad
-- ALTER date:  15 Nov. 2011
-- Description:	create Customer support forword table
-- =============================================
CREATE TABLE [dbo].[ForwordTechnicalSupport](
	[ForwordID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RelatedToContact] [nvarchar](70) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Type] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EnterByID] [int] NOT NULL,
	[EnterDate] [datetime] NOT NULL,
	[ForwordToUserID] [int] NOT NULL,
	[Status] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TechnicalSupportID] [int] NOT NULL,
	[TechnicalSupportDate] [datetime] NULL,
	[Site] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ForwordTechnicalSupport] PRIMARY KEY CLUSTERED 
(
	[ForwordID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



-- =============================================
-- Author: Alsayed Moawad 
-- Create date: 15 Nov. 2011
-- Description:	insert record into ForwordTechnicalSupport table
-- =============================================


Create PROCEDURE [dbo].[ForwordTechnicalSupport_Insert]
(
	@Subject nvarchar (2000)  ,
	@RelatedToContact nvarchar (70)   ,
	@Type nvarchar (150),
  	@EnterById int   ,
	@EnterDate datetime   ,
	@ForwordToUserID int   ,
    @Status nvarchar (20),
    @TechnicalSupportID int   ,
	@TechnicalSupportDate datetime ,  
    @Site nvarchar (150)
   

)
AS
				
INSERT INTO [dbo].ForwordTechnicalSupport
	(
					
	[Subject],
	[RelatedToContact],
	[Type],
	[EnterByID],
	[EnterDate],
	[ForwordToUserID],
	[Status],
	[TechnicalSupportID],
	[TechnicalSupportDate],
	[Site]
					
	)
	VALUES
	(
	@Subject ,
	@RelatedToContact ,
	@Type,
  	@EnterById,
	@EnterDate  ,
	@ForwordToUserID    ,
    @Status  ,
    @TechnicalSupportID   ,
	@TechnicalSupportDate ,  
    @Site
					
    )
				
				
SELECT SCOPE_IDENTITY()
									
							
			






GO

Declare @GID as int
SELECT @GID = [GID]
  FROM [Main_GeneralCode]
WHERE  [GCode]= 'CallStatus'

INSERT INTO [Main_SubCode]
           ([SCode]
           ,[GID])
     VALUES
           ('Active'
           ,@GID)

GO


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 15 Nov. 2011
-- Description:	Get Open Tasks
-- =============================================
Create PROCEDURE [dbo].[OpenTasks_Get] 
(
	@UserID int,
	@TaskDate datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ForwordID]
      ,[Subject]
	  ,[TechnicalSupportID]
      ,[RelatedToContact]
	  ,[TechnicalSupportDate] as TaskDate
      ,[Type]
      ,EnterByID
	  ,Sec_UserLogin_1.UserName AS [From]
      ,[Status]
	  ,null as CallID
	FROM [ForwordTechnicalSupport] INNER JOIN 
		Sec_UserLogin AS Sec_UserLogin_1 ON EnterByID = Sec_UserLogin_1.UID
	WHERE [ForwordToUserID] = @UserID
	
	UNION

	SELECT  null as [ForwordID],
		Calls.Subject,
		Calls.ContactID as [TechnicalSupportID],
		(Contact_ContactsInfo.FirstName + ' ' + Contact_ContactsInfo.LastName) as [RelatedToContact],
		Calls.StartDate as TaskDate,
		'Call' as [Type],
		Calls.EnterByID,
		Sec_UserLogin_1.UserName AS [From], 
		'Active' as Status,
		Calls.CallID
	FROM    Calls INNER JOIN 
		Sec_UserLogin AS Sec_UserLogin_1 ON Calls.EnterByID = Sec_UserLogin_1.UID  
		LEFT OUTER JOIN Contact_ContactsInfo ON 
		Calls.ContactID = Contact_ContactsInfo.ContactID LEFT OUTER JOIN
        Main_SubCode AS Main_SubCode_1 ON Calls.Status = Main_SubCode_1.SID
	WHERE	Main_SubCode_1.SCode = 'Active' And 
			Calls.StartDate >= dateadd(dd, datediff(dd, 0, @TaskDate)+0, 0)
			And Calls.StartDate < dateadd(dd, datediff(dd, 0, @TaskDate)+1, 0)
END


Alter Table [Contact_Account]
Add [TopAccount] bit 
CONSTRAINT DF_Contact_Account_TopAccount DEFAULT 0 NOT NULL
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:        Ehab Hosny
-- ALTER  date: 26 March. 2008
-- Description:   Get all contacts from 'Contact_Account' according to the specified filter
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Accounts]
      (
             @AccountID int
            ,@StatusID int
            ,@AccountName nvarchar(255)
            ,@City nvarchar(255)
            ,@Phone nvarchar(255)
            ,@State nvarchar(255) 
            ,@BusSectorName nvarchar(255)
            ,@CountryName nvarchar(255)
            ,@Tag nvarchar(10) 
            ,@SortExp nvarchar(255)
            ,@FilterAccountNotes int
            
      )
AS
BEGIN
      SET NOCOUNT ON;
            Declare @Filter AS nvarchar(500)
            Declare @Query AS nvarchar(2000)
            Declare @FullQuery AS nvarchar(2500)
            SET @Filter = ''
            SET @Query = 
            'SELECT  Contact_Account.AID, Contact_Account.AName, Contact_Account.TypeID, Contact_Account.BusSector, Contact_Account.Fax, Contact_Account.Phone, 
			Contact_Account.WebSite, Contact_Account.IDStatus, Contact_Account.Street1, Contact_Account.City, Contact_Account.ZipCode, 
			Contact_Account.CountryID, Contact_Account.ReferedBy, Contact_Account.EnterByID, Contact_Account.EnterDate, Contact_Account.EditByID, 
			Contact_Account.EditDate, Contact_Account.Street2, Contact_Account.TopAccount,
			Contact_Account.AccountManagerID, Contact_Account.AccountManagerEditDate, 
			Contact_Account.AccountManagerEditByID, Contact_Account.AccoutnManagerAssignedDate, Contact_Account.Tag, Contact_Account.State, 
			Main_SubCode_1.SCode AS CountryName, Main_SubCode.SCode AS StatusName, Main_SubCode_2.SCode AS BusinessSectorName, 
			Sec_UserLogin_1.UserName AS EnterByName, Sec_UserLogin.UserName AS EditByName, Sec_UserLogin_3.UserName AS AccountManagerName, 
			Sec_UserLogin_2.UserName AS AccountManagerEditByName,Contact_Account.Profile,Contact_Account.Email, (Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) AS LastAccountNoteDate
            FROM      Contact_Account LEFT OUTER JOIN
			Sec_UserLogin AS Sec_UserLogin_1 ON Contact_Account.EnterByID = Sec_UserLogin_1.UID LEFT OUTER JOIN
			Main_SubCode ON Contact_Account.IDStatus = Main_SubCode.SID LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID LEFT OUTER JOIN
			Sec_UserLogin AS Sec_UserLogin_3 ON Contact_Account.AccountManagerID = Sec_UserLogin_3.UID LEFT OUTER JOIN
			Sec_UserLogin AS Sec_UserLogin_2 ON Contact_Account.AccountManagerEditByID = Sec_UserLogin_2.UID LEFT OUTER JOIN
			Sec_UserLogin ON Contact_Account.EditByID = Sec_UserLogin.UID LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_2 ON Contact_Account.BusSector = Main_SubCode_2.SID

            WHERE     (1 = 1) '

            IF @AccountID <> -1
                  SET @Filter = @Filter + ' AND Contact_Account.AID = ' + CONVERT(nvarchar(25),@AccountID)
            
            IF @StatusID <> -1
                  SET @Filter = @Filter + ' AND Contact_Account.IDStatus = ' + CONVERT(nvarchar(25), @StatusID)
 
            IF @AccountName <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Account.AName LIKE  ' + CHAR(39)  + @AccountName + '%' + CHAR(39)

            IF @City <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Account.City LIKE ' + CHAR(39) + @City + '%' + CHAR(39)

            IF @Phone <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Account.Phone LIKE ' + CHAR(39) + @Phone + '%' + CHAR(39)

            IF @State <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Account.State LIKE ' + CHAR(39) + @State + '%' + CHAR(39)

            IF @BusSectorName <> '-1'
                  SET @Filter = @Filter + ' AND Main_SubCode_2.SCode LIKE ' + CHAR(39) + @BusSectorName + '' + CHAR(39)
   	   
	        IF @CountryName <> '-1'
                  SET @Filter = @Filter + ' AND Main_SubCode_1.SCode LIKE ' + CHAR(39) + @CountryName + '%' + CHAR(39)

            IF @Tag <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Account.Tag = ' + CHAR(39) + @Tag + CHAR(39)
 
            IF @FilterAccountNotes = 1
                  SET @Filter = @Filter + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is Not NULL' 

            IF @FilterAccountNotes = 2
                  SET @Filter = @Filter + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is NULL' 

            IF @SortExp <> '-1'
                  SET @Filter = @Filter + ' ORDER BY ' +  @SortExp 
  
            SET @FullQuery = @Query + @Filter
            Execute(@FullQuery)
END





set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





-- =============================================
-- Author:        Yasser Abd Rab El-Rasol
-- Create date:   22 Dec. 2010
-- Description:   Get all contacts from 'Contact_Account' according to the specified filter
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Accounts_By_Page]
      (
            @PageSize int
			,@PageNum int
      )
AS
BEGIN
      SET NOCOUNT ON;
		DECLARE  @StartRow INT
		SELECT   @StartRow = @PageNum * @PageSize

		SELECT AID, AName, TypeID, BusSector, Fax, Phone, WebSite, IDStatus, Street1, TopAccount,
		City, ZipCode, CountryID, ReferedBy, EnterByID, EnterDate, EditByID, EditDate, Street2, 
		AccountManagerID, AccountManagerEditDate, AccountManagerEditByID, AccoutnManagerAssignedDate, 
		Tag, State, CountryName, StatusName, BusinessSectorName, EnterByName, EditByName, 
		AccountManagerName, AccountManagerEditByName, Profile, LastAccountNoteDate
		FROM (SELECT  Contact_Account.AID, Contact_Account.AName, Contact_Account.TypeID, 
		Contact_Account.BusSector, Contact_Account.Fax, Contact_Account.Phone, 
		Contact_Account.WebSite, Contact_Account.IDStatus, Contact_Account.Street1, Contact_Account.TopAccount,
		Contact_Account.City, Contact_Account.ZipCode, Contact_Account.CountryID, 
		Contact_Account.ReferedBy, Contact_Account.EnterByID, Contact_Account.EnterDate, 
		Contact_Account.EditByID, Contact_Account.EditDate, Contact_Account.Street2, 
		Contact_Account.AccountManagerID, Contact_Account.AccountManagerEditDate, 
		Contact_Account.AccountManagerEditByID, Contact_Account.AccoutnManagerAssignedDate, 
		Contact_Account.Tag, Contact_Account.State, Main_SubCode_1.SCode AS CountryName, 
		Main_SubCode.SCode AS StatusName, Main_SubCode_2.SCode AS BusinessSectorName, 
		Sec_UserLogin_1.UserName AS EnterByName, Sec_UserLogin.UserName AS EditByName, 
		Sec_UserLogin_3.UserName AS AccountManagerName, Sec_UserLogin_2.UserName AS AccountManagerEditByName,
		Contact_Account.Profile,Contact_Account.Email, 
		(Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) AS LastAccountNoteDate,
		ROW_NUMBER() OVER(ORDER BY AName ASC) AS RowNumber
		
		FROM      Contact_Account LEFT OUTER JOIN
		Sec_UserLogin AS Sec_UserLogin_1 ON Contact_Account.EnterByID = Sec_UserLogin_1.UID LEFT OUTER JOIN
		Main_SubCode ON Contact_Account.IDStatus = Main_SubCode.SID LEFT OUTER JOIN
		Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID LEFT OUTER JOIN
		Sec_UserLogin AS Sec_UserLogin_3 ON Contact_Account.AccountManagerID = Sec_UserLogin_3.UID LEFT OUTER JOIN
		Sec_UserLogin AS Sec_UserLogin_2 ON Contact_Account.AccountManagerEditByID = Sec_UserLogin_2.UID LEFT OUTER JOIN
		Sec_UserLogin ON Contact_Account.EditByID = Sec_UserLogin.UID LEFT OUTER JOIN
		Main_SubCode AS Main_SubCode_2 ON Contact_Account.BusSector = Main_SubCode_2.SID) temp
		WHERE    RowNumber > @StartRow
			AND RowNumber <= @StartRow + @PageSize
		ORDER BY AName ASC

            
END




set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 17 Nov. 2011
-- Description:	Get all calls related to properties
-- =============================================
Create PROCEDURE [dbo].[MyCalls_Get]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT TOP(5) Calls.CallID,
		Calls.Subject,
		Calls.ContactID,
		(Contact_ContactsInfo.FirstName + ' ' + Contact_ContactsInfo.LastName) as [RelatedTo],
		Calls.StartDate as [Date],
		Calls.EnterByID,
		'Active' as Status
	FROM    Calls INNER JOIN 
		Sec_UserLogin AS Sec_UserLogin_1 ON Calls.EnterByID = Sec_UserLogin_1.UID  
		LEFT OUTER JOIN Contact_ContactsInfo ON 
		Calls.ContactID = Contact_ContactsInfo.ContactID LEFT OUTER JOIN
        Main_SubCode AS Main_SubCode_1 ON Calls.Status = Main_SubCode_1.SID
	WHERE	Main_SubCode_1.SCode = 'Active'
	Order By Calls.StartDate Desc
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 17 Nov. 2011
-- Description:	Get all calls related to properties
-- =============================================
alter PROCEDURE [dbo].[MyCalls_Get]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT TOP(5) Calls.CallID,
		Calls.Subject,
		Calls.ContactID,
		(Contact_ContactsInfo.FirstName + ' ' + Contact_ContactsInfo.LastName) as [RelatedTo],
		Calls.StartDate as [Date],
		'Active' as Status
	FROM    Calls 
		LEFT OUTER JOIN Contact_ContactsInfo ON 
		Calls.ContactID = Contact_ContactsInfo.ContactID LEFT OUTER JOIN
        Main_SubCode AS Main_SubCode_1 ON Calls.Status = Main_SubCode_1.SID
	WHERE	Main_SubCode_1.SCode = 'Active' AND Calls.ContactID is not null
	Order By Calls.StartDate Desc
END






set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 15 Nov. 2011
-- Description:	Get Open Tasks
-- =============================================
ALTER PROCEDURE [dbo].[OpenTasks_Get] 
(
	@UserID int,
	@TaskDate datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ForwordID]
      ,[Subject]
	  ,[TechnicalSupportID]
      ,[RelatedToContact]
	  ,[TechnicalSupportDate] as TaskDate
      ,[Type]
      ,EnterByID
	  ,Sec_UserLogin_1.UserName AS [From]
      ,[Status]
	  ,null as CallID
	  ,Site
	FROM [ForwordTechnicalSupport] INNER JOIN 
		Sec_UserLogin AS Sec_UserLogin_1 ON EnterByID = Sec_UserLogin_1.UID
	WHERE [ForwordToUserID] = @UserID
	
	UNION

	SELECT  null as [ForwordID],
		Calls.Subject,
		Calls.ContactID as [TechnicalSupportID],
		(Contact_ContactsInfo.FirstName + ' ' + Contact_ContactsInfo.LastName) as [RelatedToContact],
		Calls.StartDate as TaskDate,
		'Call' as [Type],
		Calls.EnterByID,
		Sec_UserLogin_1.UserName AS [From], 
		'Active' as Status,
		Calls.CallID,
		null as Site
	FROM    Calls INNER JOIN 
		Sec_UserLogin AS Sec_UserLogin_1 ON Calls.EnterByID = Sec_UserLogin_1.UID  
		LEFT OUTER JOIN Contact_ContactsInfo ON 
		Calls.ContactID = Contact_ContactsInfo.ContactID LEFT OUTER JOIN
        Main_SubCode AS Main_SubCode_1 ON Calls.Status = Main_SubCode_1.SID
	WHERE	Main_SubCode_1.SCode = 'Active' And 
			Calls.StartDate >= dateadd(dd, datediff(dd, 0, @TaskDate)+0, 0)
			And Calls.StartDate < dateadd(dd, datediff(dd, 0, @TaskDate)+1, 0)
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		Ehab Hosny
-- ALTER  date: 24/3/2008
-- Description:	Insert new record in 'Contact_Account' table
-- =============================================
ALTER PROCEDURE [dbo].[SP_INSERT_INTO_Contact_Account]
	-- Add the parameters for the stored procedure here
	(
			@AName nvarchar(255)
           ,@TypeID int
           ,@BusSector int
           ,@Fax nvarchar(25)
           ,@Phone nvarchar(25)
           ,@WebSite nvarchar(255)
           ,@IDStatus int
           ,@Street1 nvarchar(255)
           ,@City nvarchar(255)
           ,@ZipCode nvarchar(25)
           ,@CountryID int
           ,@ReferedBy nvarchar(255)
           ,@EnterByID int
           ,@EnterDate datetime
           ,@EditByID int
           ,@EditDate datetime
           ,@Street2 nvarchar(255)
           ,@AccountManagerID int
           ,@AccountManagerEditDate datetime
           ,@AccountManagerEditByID int
           ,@AccoutnManagerAssignedDate datetime
		   ,@State nvarchar(100)
		   ,@Tag bit
		   ,@Profile text
           ,@Email nvarchar(255)
		   ,@TopAccount bit
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT	INTO Contact_Account
			(AName,TypeID,BusSector ,Fax ,Phone ,WebSite ,IDStatus ,Street1 
			,City ,ZipCode ,CountryID ,ReferedBy ,EnterByID ,EnterDate ,EditByID 
			,EditDate ,Street2 ,AccountManagerID ,AccountManagerEditDate 
			,AccountManagerEditByID ,AccoutnManagerAssignedDate ,State 
			,Tag,Profile,Email,TopAccount)
	VALUES	(@AName,@TypeID,@BusSector ,@Fax ,@Phone ,@WebSite ,@IDStatus ,@Street1 
			,@City ,@ZipCode ,@CountryID ,@ReferedBy ,@EnterByID ,@EnterDate ,@EditByID 
			,@EditDate ,@Street2 ,@AccountManagerID ,@AccountManagerEditDate 
			,@AccountManagerEditByID ,@AccoutnManagerAssignedDate,
			 @State ,@Tag ,@Profile,@Email,@TopAccount)
	SELECT SCOPE_IDENTITY()
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		Ehab Hosny 
-- Create date: 24 March. 2008
-- Description:	Update Existing record in 'Contact_Account' table
-- =============================================
ALTER PROCEDURE [dbo].[SP_UPDATE_Contact_Account]
	-- Add the parameters for the stored procedure here
	(
			@AID nvarchar(25)
		   ,@AName nvarchar(255)
		   ,@TypeID nvarchar(25)
		   ,@BusSector nvarchar(25)
		   ,@Fax nvarchar(25)
		   ,@Phone nvarchar(25)
		   ,@WebSite nvarchar(255)
           ,@IDStatus nvarchar(25)
		   ,@Street1 nvarchar(255)
		   ,@City nvarchar(255)
		   ,@ZipCode nvarchar(25)
		   ,@CountryID nvarchar(25)
		   ,@ReferedBy nvarchar(255)
		   ,@EnterByID nvarchar(25)
		   ,@EnterDate nvarchar(100)
		   ,@EditByID nvarchar(25)
		   ,@EditDate nvarchar(100)
		   ,@Street2 nvarchar(255)
		   ,@AccountManagerID nvarchar(25)
		   ,@AccountManagerEditDate nvarchar(100)
		   ,@AccountManagerEditByID nvarchar(25)
		   ,@AccoutnManagerAssignedDate nvarchar(100)
		   ,@State nvarchar(100)
		   ,@Tag	nvarchar(25)
		   ,@Profile nvarchar(4000)
           ,@Email nvarchar(255)
		   ,@TopAccount nvarchar(25)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @UpdateQuery AS nvarchar(4000)
	SET @UpdateQuery = 'UPDATE Contact_Account	SET  ' -- AName = ' + @AName
    -- Insert statements for procedure here 
	IF(@AName <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' AName = ' + CHAR(39) + @AName + CHAR(39) + ','
	IF(@TypeID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' TypeID = ' + @TypeID + ','
	IF(@BusSector <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' BusSector = ' +  @BusSector + ','
	IF(@Fax <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' Fax = ' + CHAR(39) + @Fax + CHAR(39) + ','
	IF(@Phone <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' Phone = ' + CHAR(39) + @Phone + CHAR(39) + ','
	IF(@WebSite <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' WebSite = ' + CHAR(39) + @WebSite + CHAR(39) + ','
      IF(@Email <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' Email = ' + CHAR(39) + @Email + CHAR(39) + ','
	IF(@IDStatus <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' IDStatus = ' + @IDStatus + ','
	IF(@Street1 <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' Street1 = ' + CHAR(39) + @Street1 + CHAR(39) + ','
	IF(@City <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' City = ' + CHAR(39) + @City + CHAR(39) + ','
	IF(@ZipCode <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' ZipCode = ' + CHAR(39) + @ZipCode + CHAR(39) + ','
	IF(@CountryID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' CountryID = ' +  @CountryID + ','
	IF(@ReferedBy <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' ReferedBy = ' + CHAR(39) + @ReferedBy + CHAR(39) + ','
	IF(@EnterByID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' EnterByID = ' + @EnterByID + ','
	IF(@EnterDate <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' EnterDate = ' + CHAR(39) + @EnterDate + CHAR(39) + ','
	IF(@EditByID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' EditByID = ' +  @EditByID + ','
	IF(@EditDate <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' EditDate = ' + CHAR(39) + @EditDate + CHAR(39) + ','
	IF(@Street2 <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' Street2 = ' + CHAR(39) + @Street2 + CHAR(39) + ','
	IF(@AccountManagerID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' AccountManagerID = ' + CHAR(39) + @AccountManagerID + CHAR(39) + ','
	IF(@AccountManagerEditDate <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' AccountManagerEditDate = ' + CHAR(39) + @AccountManagerEditDate + CHAR(39) + ','
	IF(@AccountManagerEditByID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' AccountManagerEditByID = ' +  @AccountManagerEditByID + ','
	IF(@AccoutnManagerAssignedDate <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' AccoutnManagerAssignedDate = ' + CHAR(39) + @AccoutnManagerAssignedDate + CHAR(39) + ','
	IF(@State <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' State = ' + CHAR(39) + @State + CHAR(39) + ','
	IF(@Tag <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' Tag = ' + CHAR(39) + @Tag + CHAR(39) + ','
	IF(@Profile <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' Profile = ' + CHAR(39) + @Profile + CHAR(39) + ','
	IF(@TopAccount <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' TopAccount = ' + CHAR(39) + @TopAccount + CHAR(39) + ','
	
	--Removes the last occurenece of the character ','
	Declare @StringLength AS int
	SET @StringLength = len(@UpdateQuery)
	SET @UpdateQuery = SUBSTRING(@UpdateQuery,1,@StringLength-1)	

	SET @UpdateQuery = @UpdateQuery + ' WHERE  AID = ' + @AID + ' 
	'
	Execute(@UpdateQuery)
	SELECT @@ROWCOUNT
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:        Yasser Abd Rab El-Rasol
-- Create date:   17 Nov. 2011
-- Description:   Get all TopAccounts
-- =============================================
alter PROCEDURE [dbo].[TopAccounts_Get]
	@SortExp nvarchar(255)
AS
BEGIN
      SET NOCOUNT ON;
            Declare @Query AS nvarchar(2000)
            Declare @FullQuery AS nvarchar(2500)
            SELECT @Query = 
            'SELECT  Contact_Account.AID, Contact_Account.AName As AccountName, Contact_Account.Phone, 
			Contact_Account.City, 
			Contact_Account.State, 
			Main_SubCode_1.SCode AS CountryName,
			Main_SubCode.SCode AS Status, Main_SubCode_2.SCode AS BusinessSector, 
			(Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) AS NoteDate
            FROM      Contact_Account LEFT OUTER JOIN
			Main_SubCode ON Contact_Account.IDStatus = Main_SubCode.SID LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID LEFT OUTER JOIN
			Sec_UserLogin ON Contact_Account.EditByID = Sec_UserLogin.UID LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_2 ON Contact_Account.BusSector = Main_SubCode_2.SID

            WHERE     (Contact_Account.TopAccount = 1) '

            SELECT @SortExp = ' ORDER BY ' +  @SortExp 
  
            SELECT @FullQuery = @Query + @SortExp

            Execute(@FullQuery)
END



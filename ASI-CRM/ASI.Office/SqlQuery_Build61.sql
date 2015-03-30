set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Alsayed Moawad 
-- Create date: 10 July. 2011
-- Description:	select Attachments by CompanyID
-- =============================================
-- exec Attachments_GetByContactID 1313
ALTER PROCEDURE [dbo].[Attachments_GetByBranchID]
   @BranchID  varchar (50)
-- Get Software By Contact
AS
select 
[AttachmentID]
      ,[FileName]
      ,[FileSize]
      ,[Attach]
      ,[Description]
      ,[AccountID]
      ,[ContactID]
	  ,BranchID
       ,[EnterBy]
      ,Sec_UserLogin.UserName AS EnterByName
      ,[EnterDate]
      ,[EditBy]
      ,Sec_UserLogin_1.UserName AS EditByName
      ,[EditDate]
  FROM Attachments,Sec_UserLogin,Sec_UserLogin as Sec_UserLogin_1 where Attachments.EnterBy=Sec_UserLogin.UID and Attachments.EditBy=Sec_UserLogin_1.UID and (BranchID=@BranchID OR ContactID in (select ContactID from Contact_ContactsInfo where BranchID=@BranchID))



---------------------------------------------------------------------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Alsayed Moawad 
-- Create date: 10 July. 2011
-- Description:	select Attachments by CompanyID
-- =============================================
-- exec Attachments_GetByCompanyID 1313

ALTER PROCEDURE [dbo].[Attachments_GetByCompanyID]
   @CompanyID  varchar (50)
-- Get Software By Contact
AS
select 
[AttachmentID]
      ,[FileName]
      ,[FileSize]
      ,[Attach]
      ,[Description]
      ,[AccountID]
      ,[ContactID]
      ,BranchID
      ,[EnterBy]
      ,Sec_UserLogin.UserName AS EnterByName
      ,[EnterDate]
      ,[EditBy]
      ,Sec_UserLogin_1.UserName AS EditByName
      ,[EditDate]
  FROM Attachments,Sec_UserLogin,Sec_UserLogin as Sec_UserLogin_1 where Attachments.EnterBy=Sec_UserLogin.UID and Attachments.EditBy=Sec_UserLogin_1.UID and (AccountID=@CompanyID OR  (BranchID IN (SELECT BranchID from Contact_Branches where  Contact_Branches.AccountID=@CompanyID)) OR (ContactID in (select ContactID from Contact_ContactsInfo where Contact_ContactsInfo.AccountID=@CompanyID )))



---------------------------------------------------------------------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON


-- =============================================
-- Author: Alsayed Moawad 
-- Create date: 10 July. 2011
-- Description:	select key by BranchID
-- =============================================

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[KeySoftWare_GetKeySoftwareByBranchID]
   @BranchID  varchar (50)
-- Get Software By Contact
AS

SELECT     SID, Software, IssueDate, Version, Build, ServiceBack, LicenseCode, LicenseKey, MachineCode, HardwareKey, VMWare, KeySuppliedID, 
                      LicenseServer, FileVersion, ContactID, CompanyID,BranchID, ExpireDate, EnterBy, EnterDate, EditBy, EditDate,KeyNote,KeyOption,Approvedby,LicenseType,LicensePeriod,MethodofPayment 
FROM         Key_Software where BranchID=@BranchID

union 
SELECT     SID, Software, IssueDate, Version, Build, ServiceBack, LicenseCode, LicenseKey, MachineCode, HardwareKey, VMWare, KeySuppliedID, 
                      LicenseServer, FileVersion, ContactID, CompanyID,BranchID, ExpireDate, EnterBy, EnterDate, EditBy, EditDate,KeyNote,KeyOption,Approvedby,LicenseType,LicensePeriod,MethodofPayment 

FROM         Key_Software where ContactID in (select ContactID from Contact_ContactsInfo where BranchID=@BranchID)



---------------------------------------------------------------------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON



-- =============================================
-- Author: Alsayed Moawad 
-- Create date: 10 July. 2011
-- Description:	select key by CompanyID
-- =============================================



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[KeySoftWare_GetKeySoftwareByCompanyID]
   @CompanyID  varchar (50)
-- Get Software By Contact
AS

SELECT     SID, Software, IssueDate, Version, Build, ServiceBack, LicenseCode, LicenseKey, MachineCode, HardwareKey, VMWare, KeySuppliedID, 
                      LicenseServer, FileVersion, ContactID, CompanyID,BranchID, ExpireDate, EnterBy, EnterDate, EditBy, EditDate,KeyNote,KeyOption,Approvedby,LicenseType,LicensePeriod,MethodofPayment 
FROM         Key_Software where CompanyID=@CompanyID

union

SELECT     SID, Software, IssueDate, Version, Build, ServiceBack, LicenseCode, LicenseKey, MachineCode, HardwareKey, VMWare, KeySuppliedID, 
                      LicenseServer, FileVersion, ContactID, CompanyID,BranchID, ExpireDate, EnterBy, EnterDate, EditBy, EditDate,KeyNote,KeyOption,Approvedby,LicenseType,LicensePeriod,MethodofPayment 
FROM         Key_Software where BranchID in ( select BranchID from Contact_Branches where AccountID= @CompanyID)

union

SELECT     SID, Software, IssueDate, Version, Build, ServiceBack, LicenseCode, LicenseKey, MachineCode, HardwareKey, VMWare, KeySuppliedID, 
                      LicenseServer, FileVersion, ContactID, CompanyID,BranchID, ExpireDate, EnterBy, EnterDate, EditBy, EditDate,KeyNote,KeyOption,Approvedby,LicenseType,LicensePeriod,MethodofPayment 
FROM         Key_Software where ContactID in (select ContactID from Contact_ContactsInfo where AccountID= @CompanyID)


---------------------------------------------------------------------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON





set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sayed Moawad
-- Create date: 6 July. 2011
-- Description:	Get History related to Account
-- =============================================
-- exec History_GetByBranchID 1313


ALTER PROCEDURE [dbo].[History_GetByBranchID]
(

	@BranchID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT     '' AS FName, '' AS LName, 'Note' AS Type,Contact_Notes.EditDate as Date,Sec_UserLogin.UserName AS EditBy, (CAST(Contact_Notes.Notes AS varchar(8000))) AS Details
                      
FROM         Contact_Notes INNER JOIN  
                      Contact_Branches ON Contact_Notes.BranchID = Contact_Branches.BranchID INNER JOIN
                      Sec_UserLogin ON Contact_Notes.EditByID = Sec_UserLogin.UID
WHERE     (Contact_Branches.BranchID = @BranchID) AND (Contact_Notes.EditDate =
                          (SELECT     MAX(EditDate) AS Expr1
                             FROM         Contact_Notes AS Contact_Notes_1
                             WHERE     (Contact_Notes_1.BranchID = @BranchID)))
--ORDER BY Contact_Account.AID

union

SELECT     c.FirstName AS FName, c.LastName AS LName, 'Call' AS Type, cal.StartDate AS Date, 
                      s.UserName AS EditBy, cal.Notes AS Details 
FROM         Contact_Branches b,Contact_ContactsInfo c,Calls cal ,Sec_UserLogin s where b.BranchID = @BranchID and
                      b.BranchID = c.BranchID and c.ContactID = cal.ContactID  
                    and cal.EditByID = s.UID and cal.EditDate in (select max(EditDate) from Calls where Calls.ContactID=c.ContactID)
--ORDER BY Contact_Account.AID
				
--				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			





set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sayed Moawad
-- Create date: 6 July. 2011
-- Description:	Get History related to Account
-- =============================================
-- exec History_GetByAccountId 1313


ALTER PROCEDURE [dbo].[History_GetByAccountId]
(

	@AccountId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT     '' AS FName, '' AS LName, 'Note' AS Type,Contact_Notes.EditDate as Date,Sec_UserLogin.UserName AS EditBy, (CAST(Contact_Notes.Notes AS varchar(8000))) AS Details
                      
FROM         Contact_Notes INNER JOIN  
                      Contact_Account ON Contact_Notes.AccountID = Contact_Account.AID INNER JOIN
                      Sec_UserLogin ON Contact_Notes.EditByID = Sec_UserLogin.UID
WHERE     (Contact_Account.AID = @AccountId) AND (Contact_Notes.EditDate =
                          (SELECT     MAX(EditDate) AS Expr1
                             FROM         Contact_Notes AS Contact_Notes_1
                             WHERE     (Contact_Account.AID = @AccountId)))
--ORDER BY Contact_Account.AID

union

SELECT     c.FirstName AS FName, c.LastName AS LName, 'Call' AS Type, cal.StartDate AS Date, 
                      s.UserName AS EditBy, cal.Notes AS Details 
FROM         Contact_Account a,Contact_ContactsInfo c,Calls cal ,Sec_UserLogin s where a.AID = @AccountId and
                       a.AID = c.AccountID and c.ContactID = cal.ContactID  
                    and cal.EditByID = s.UID and cal.EditDate in (select max(EditDate) from Calls where Calls.ContactID=c.ContactID)
--ORDER BY Contact_Account.AID
				
--				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:        Yasser Abd Rab El-Rasol
-- Create  date:  31 July. 2011
-- Description:   Get AccountID by BranchID
-- =============================================
Create PROCEDURE [dbo].[SP_Get_AccountID_By_BranchID] 
	(
		@BranchID int,
		@AccountID int output
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT     @AccountID = Contact_Branches.AccountID
	FROM         Contact_Branches 
	WHERE     (Contact_Branches.BranchID = @BranchID)
END


GO

-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 25 June. 2009
-- Description:	Get account or contact order
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Account_Or_Contact_Order] 
(
	@ID int,
	@IsAccount bit,
	@Order int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	Declare @RowsBeforeID AS int;

	IF @IsAccount = 1
	BEGIN
		--Search for account page no.
		SELECT @RowsBeforeID = COUNT(AID) - 1
		FROM Contact_Account
		WHERE AName <= (SELECT AName
						FROM Contact_Account
						WHERE AID = @ID)
	END
	ELSE
	BEGIN
		--Search for contact page no.
--		SELECT @RowsBeforeID = AccountID
--		FROM Contact_ContactsInfo
--		WHERE ContactID = @ID		
--
--		print @RowsBeforeID
--
--		IF @RowsBeforeID is NULL
--		BEGIN	
--			print 'NULL'
--			SELECT @RowsBeforeID = COUNT(ContactID) + 1
--			FROM Contact_ContactsInfo
--			WHERE AccountID is NULL AND (Email <> '') AND Email <= (SELECT Email
--												FROM Contact_ContactsInfo
--												WHERE ContactID = @ID)
--		END
--		ELSE
--		BEGIN
--			print 'NOT NULL'

--			SELECT @RowsBeforeID = COUNT(ContactID) + 1
--			FROM Contact_ContactsInfo LEFT OUTER JOIN
--			Contact_Account ON (AccountID = AID OR AccountID = NULL)
--			WHERE AName <= (SELECT AName
--							FROM Contact_ContactsInfo LEFT OUTER JOIN
--							Contact_Account ON (AccountID = AID OR AccountID is NULL)
--							WHERE ContactID = @ID)
--
--			print @RowsBeforeID
--
--			Declare @Temp AS int;
--
--			SELECT @Temp = COUNT(ContactID)
--			FROM Contact_ContactsInfo
--			WHERE AccountID is NULL		
--
--			print @Temp
--
--			SET @RowsBeforeID = @RowsBeforeID + @Temp

			if object_id('tempdb..#InnerT') is not null
				drop table #InnerT


			CREATE TABLE #InnerT(
				[ContactID] [int] NOT NULL,
				[Intial] [nvarchar](10) NULL,
				[FirstName] [nvarchar](255) NULL,
				[MiddleIntial] [nvarchar](50) NULL,
				[LastName] [nvarchar](255) NULL,
				[TitleID] [int] NULL,
				[DepartmentID] [int] NULL,
				[Phone] [nvarchar](25) NULL,
				[Ext] [nvarchar](50) NULL,
				[CellPhone] [nvarchar](25) NULL,
				[Fax] [nvarchar](25) NULL,
				[Email] [nvarchar](255) NULL,
				[AccountID] [int] NULL,
				[EnteredbyID] [int] NULL,
				[EnterDate] [datetime] NULL,
				[EditByID] [int] NULL,
				[EditeDate] [datetime] NULL,
				[Tag] [bit] NULL,
				[AName] [nvarchar](255) NULL,
				[EnteredByName] [nvarchar](255) NULL,
				[EditByName] [nvarchar](255) NULL,
				[Address] [nvarchar](1000) NULL,
				[City] [nvarchar](100) NULL,
				[State] [nvarchar](100) NULL,
				[CountryID] [int] NULL,
				[Url] [nvarchar](255) NULL,
				[BranchID] [int] NULL,
				[IDStatusName] [nvarchar](255) NULL,
				[CountryName] [nvarchar](255) NULL,
				[TitleName] [nvarchar](255) NULL,
				[DepartmentName] [nvarchar](255) NULL,
				[Probability] [decimal] NULL,
				[LastContactNoteDate] [datetime] NULL,
				[RowNumber] [int] NULL,
				[PageNo] [int] NULL)


			INSERT INTO #InnerT (ContactID, Intial, FirstName, MiddleIntial, LastName, TitleID, DepartmentID, Phone, 
					Ext, CellPhone, Fax, Email, AccountID, EnteredbyID, EnterDate, EditByID, EditeDate, 
					Tag, AName, EnteredByName, EditByName, Address, City, State, CountryID, Url, BranchID,
					IDStatusName, CountryName, TitleName, DepartmentName, Probability, LastContactNoteDate,
					RowNumber, PageNo)
			SELECT  ContactID, Intial, FirstName, MiddleIntial, LastName, TitleID, DepartmentID, Phone, 
					Ext, CellPhone, Fax, Email, AccountID, EnteredbyID, EnterDate, EditByID, EditeDate, 
					Tag, AName, EnteredByName, EditByName, Address, City, State, CountryID, Url, BranchID,
					IDStatusName, CountryName, TitleName, DepartmentName, Probability, LastContactNoteDate
					, RowNumber, ((RowNumber -1)/1) as PageNo
					FROM (SELECT  Contact_ContactsInfo.ContactID, Contact_ContactsInfo.Intial, 
					Contact_ContactsInfo.FirstName, Contact_ContactsInfo.MiddleIntial, Contact_ContactsInfo.LastName, 
					Contact_ContactsInfo.TitleID, Contact_ContactsInfo.DepartmentID, Contact_ContactsInfo.Phone, 
					Contact_ContactsInfo.Ext, Contact_ContactsInfo.CellPhone, Contact_ContactsInfo.Fax, 
					Contact_ContactsInfo.Email, Contact_ContactsInfo.AccountID, Contact_ContactsInfo.EnteredbyID, 
					Contact_ContactsInfo.EnterDate, Contact_ContactsInfo.EditByID, Contact_ContactsInfo.EditeDate, 
					Contact_ContactsInfo.Tag, Contact_Account.AName, Sec_UserLogin.UserName AS EnteredByName, 
					Sec_UserLogin_1.UserName AS EditByName, Contact_ContactsInfo.Address, Contact_ContactsInfo.City, 
					Contact_ContactsInfo.State, Contact_ContactsInfo.CountryID, Contact_ContactsInfo.Url, Contact_ContactsInfo.BranchID,
					Main_SubCode_3.SCode AS IDStatusName, Main_SubCode_4.SCode AS CountryName, 
					Main_SubCode_2.SCode AS TitleName, Main_SubCode_1.SCode AS DepartmentName, 
					Contact_ContactsInfo.Probability, 
					(Select Max(NoteDate) from Contact_Notes where Contact_Notes.ContactID = Contact_ContactsInfo.ContactID) AS LastContactNoteDate,
					ROW_NUMBER() OVER(ORDER BY Contact_Account.AName ASC) AS RowNumber
					
					FROM      Sec_UserLogin RIGHT OUTER JOIN
					Main_SubCode AS Main_SubCode_4 RIGHT OUTER JOIN
					Main_SubCode AS Main_SubCode_1 RIGHT OUTER JOIN
					Contact_ContactMiscellaneous RIGHT OUTER JOIN
					Contact_ContactsInfo ON Contact_ContactMiscellaneous.ContactID = Contact_ContactsInfo.ContactID ON 
					Main_SubCode_1.SID = Contact_ContactsInfo.DepartmentID ON Main_SubCode_4.SID = Contact_ContactsInfo.CountryID LEFT OUTER JOIN
					Main_SubCode AS Main_SubCode_2 ON Contact_ContactsInfo.TitleID = Main_SubCode_2.SID LEFT OUTER JOIN
					Contact_Account ON Contact_ContactsInfo.AccountID = Contact_Account.AID ON 
					Sec_UserLogin.UID = Contact_ContactsInfo.EnteredbyID LEFT OUTER JOIN
					Sec_UserLogin AS Sec_UserLogin_1 ON Contact_ContactsInfo.EditByID = Sec_UserLogin_1.UID LEFT OUTER JOIN
					Main_SubCode AS Main_SubCode_3 ON Contact_ContactMiscellaneous.IDStatus = Main_SubCode_3.SID) temp
			--		WHERE    RowNumber > @StartRow
			--			AND RowNumber <= @StartRow + @PageSize
					ORDER BY AName ASC
				
			SELECT 	@RowsBeforeID = PageNo
			FROM #InnerT
			WHERE  ContactID = @ID

			drop table #InnerT

			print @RowsBeforeID
--		END
	END
	
	SET @Order = @RowsBeforeID
		
	
print @RowsBeforeID
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



-- =============================================
-- Author:		Ehab Hosny
-- ALTER  date: 4 Augst. 2011
-- Description:	Get all contacts accoridng to specified filter
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Contacts]
	(
		 @ContactID nvarchar(225)
		,@FirstName nvarchar(225)
		,@LastName nvarchar(225)
		,@Phone nvarchar(25)
		,@Fax nvarchar(25)
		,@EMail nvarchar(225)
		,@AccountID int
		,@BranchID int
		,@AccountName nvarchar(225)
		,@IDStatusName nvarchar(225)
		,@Tag nvarchar(10)
		,@SortCriteria nvarchar(100)
        ,@FilterContactNotes int
	)
AS
BEGIN
	SET NOCOUNT ON;

	Declare @Query AS nvarchar(4000)
	SET @Query = 'SELECT     Contact_ContactsInfo.ContactID, Contact_ContactsInfo.Intial, Contact_ContactsInfo.FirstName, Contact_ContactsInfo.MiddleIntial, 
                      Contact_ContactsInfo.LastName, Contact_ContactsInfo.TitleID, Contact_ContactsInfo.DepartmentID, Contact_ContactsInfo.Phone, 
                      Contact_ContactsInfo.Ext, Contact_ContactsInfo.CellPhone, Contact_ContactsInfo.Fax, Contact_ContactsInfo.Email, Contact_ContactsInfo.AccountID, 
                      Contact_ContactsInfo.EnteredbyID, Contact_ContactsInfo.EnterDate, Contact_ContactsInfo.EditByID, Contact_ContactsInfo.EditeDate, 
                      Contact_ContactsInfo.Tag, Contact_Account.AName, Sec_UserLogin.UserName AS EnteredByName, Sec_UserLogin_1.UserName AS EditByName, 
                      Contact_ContactsInfo.Address, Contact_ContactsInfo.City, Contact_ContactsInfo.State, Contact_ContactsInfo.CountryID, Contact_ContactsInfo.Url, 
                      Main_SubCode_3.SCode AS IDStatusName, Main_SubCode_4.SCode AS CountryName, Main_SubCode_2.SCode AS TitleName, 
                      Main_SubCode_1.SCode AS DepartmentName, Contact_ContactsInfo.Probability, (Select Max(NoteDate) from Contact_Notes where Contact_Notes.ContactID = Contact_ContactsInfo.ContactID) AS LastContactNoteDate
			FROM         Sec_UserLogin RIGHT OUTER JOIN
                      Main_SubCode AS Main_SubCode_4 RIGHT OUTER JOIN
                      Main_SubCode AS Main_SubCode_1 RIGHT OUTER JOIN
                      Contact_ContactMiscellaneous RIGHT OUTER JOIN
                      Contact_ContactsInfo ON Contact_ContactMiscellaneous.ContactID = Contact_ContactsInfo.ContactID ON 
                      Main_SubCode_1.SID = Contact_ContactsInfo.DepartmentID ON Main_SubCode_4.SID = Contact_ContactsInfo.CountryID LEFT OUTER JOIN
                      Main_SubCode AS Main_SubCode_2 ON Contact_ContactsInfo.TitleID = Main_SubCode_2.SID LEFT OUTER JOIN
                      Contact_Account ON Contact_ContactsInfo.AccountID = Contact_Account.AID ON 
                      Sec_UserLogin.UID = Contact_ContactsInfo.EnteredbyID LEFT OUTER JOIN
                      Sec_UserLogin AS Sec_UserLogin_1 ON Contact_ContactsInfo.EditByID = Sec_UserLogin_1.UID LEFT OUTER JOIN
                      Main_SubCode AS Main_SubCode_3 ON Contact_ContactMiscellaneous.IDStatus = Main_SubCode_3.SID
			WHERE     (1 = 1)'

	IF @ContactID <> '-1'
		SET @Query = @Query + ' AND Contact_ContactsInfo.ContactID = ' + @ContactID 
	IF @FirstName <> '-1'
		SET @Query = @Query + ' AND Contact_ContactsInfo.FirstName LIKE ' + CHAR(39) + @FirstName + '%' + CHAR(39)
	IF @LastName <> '-1'
		SET @Query = @Query + ' AND Contact_ContactsInfo.LastName LIKE ' + CHAR(39) + @LastName + '%' + CHAR(39)
	IF @Phone <> '-1'
		SET @Query = @Query + ' AND Contact_ContactsInfo.Phone LIKE ' + CHAR(39) + @Phone + '%' + CHAR(39)
	IF @Fax <> '-1'
		SET @Query = @Query + ' AND Contact_ContactsInfo.Fax LIKE ' + CHAR(39) + @Fax + '%' + CHAR(39)
	IF @EMail <> '-1'
		SET @Query = @Query + ' AND Contact_ContactsInfo.Email LIKE ' + CHAR(39) + @EMail + '%' + CHAR(39)
	IF @AccountID <> -1
		SET @Query = @Query + ' AND Contact_ContactsInfo.AccountID = ' + CONVERT(nvarchar(25),@AccountID)

	IF @BranchID <> -1
		SET @Query = @Query + ' AND Contact_ContactsInfo.BranchID = ' + CONVERT(nvarchar(25),@BranchID)

	IF @AccountName <> '-1'
		SET @Query = @Query + ' AND Contact_Account.AName LIKE ' + CHAR(39) + @AccountName + '%' + CHAR(39)

	IF @Tag <> '-1'
		SET @Query = @Query + ' AND Contact_ContactsInfo.Tag = ' + CHAR(39) + @Tag + CHAR(39)

	IF @IDStatusName <> '-1'
		SET @Query = @Query + ' AND Main_SubCode_3.SCode LIKE ' + CHAR(39) + @IDStatusName + '%' + CHAR(39)

    IF @FilterContactNotes = 1
        SET @Query = @Query  + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.ContactID = Contact_ContactsInfo.ContactID) is Not NULL' 

    IF @FilterContactNotes = 2
        SET @Query = @Query  + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.ContactID = Contact_ContactsInfo.ContactID) is NULL' 

	IF @SortCriteria <> '-1'
		SET @Query = @Query + ' ORDER BY ' +  @SortCriteria 
	print @Query
	execute(@Query)
END




-------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------
-- Created By: Sayed 16-6-2011
-- Purpose: Delete  record from the Email Template table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[EmailTemplate_Delete]
(

	@TemplateID int   
)
AS


				DELETE FROM [dbo].EmailTemplates WITH (ROWLOCK) 
				WHERE
					[TemplateID] = @TemplateID

					------------------------------------------------------

set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Sayed 16-6-2011
-- Purpose: Get  record from the Email Template table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[EmailTemplate_GetByTemplateID]
(

	@TemplateID int   
)
AS


				SELECT
					TemplateID,
					TemplateName   ,
					TemplateContent    ,
					TemplateEmailSubject   ,
					DefaultTemplate ,
					EnterByID,
					EnterDate,
					EditByID,
					EditDate
					
				FROM
					[dbo].EmailTemplates
				WHERE
					TemplateID = @TemplateID
				SELECT @@ROWCOUNT
					
			

-------------------------------------------------------------------

set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Description:	insert record into the Email Template table
-- =============================================

ALTER PROCEDURE [dbo].[EmailTemplate_Insert]
(

	--@TemplateID int    OUTPUT,
	@TemplateName nvarchar (255)  ,
	@TemplateContent text   ,
	@TemplateEmailSubject nvarchar (25)  ,
    @DefaultTemplate bit,
	@EnterById int   ,
	@EnterDate datetime   ,
	@EditById int   ,
	@EditDate datetime   

	

	 

	
)
AS


				
				INSERT INTO [dbo].[EmailTemplates]
					(
					[TemplateName]
					,[TemplateContent]
					,[TemplateEmailSubject]
					,[DefaultTemplate]
					,[EnterByID]
					,[EnterDate]
					,[EditByID]
					,[EditDate]
					
					)
				VALUES
					(
					@TemplateName   ,
					@TemplateContent ,
					@TemplateEmailSubject ,
					@DefaultTemplate 
	     			,@EnterById
					,@EnterDate
					,@EditById
					,@EditDate
					
					)
				
				-- Get the identity value
				--SET @TemplateID = SCOPE_IDENTITY()
SELECT SCOPE_IDENTITY()
									
------------------------------------------------------
							
			

set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
--exec [EmailTemplate_SelectAll]
/*
----------------------------------------------------------------------------------------------------

-- Created By: Sayed 16-6-2011
-- Purpose: Get All records from the Email Template table

----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[EmailTemplate_SelectAll]

AS


				SELECT
					TemplateID,
					TemplateName   ,
					TemplateContent    ,
					TemplateEmailSubject   ,
					DefaultTemplate ,
					EnterByID,
					EnterDate,
					EditByID,
					EditDate
					
				FROM
					EmailTemplates order by TemplateName
				
				SELECT @@ROWCOUNT
					
			

-------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

--exec [EmailTemplate_SelectAll]
/*
----------------------------------------------------------------------------------------------------

-- Created By: Yasser 4-7-2011
-- Purpose: Get All Email Templates names

----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[EmailTemplate_SelectNames]

AS

				SELECT
					TemplateID,
					TemplateName
					
				FROM
					EmailTemplates order by TemplateName
				
-----------------------------------------------------
					
			
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Sayed 16-6-2011
-- Purpose: Update  record into the Email Template table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[EmailTemplate_Update]
(

	
	@TemplateID int    OUTPUT,
	@TemplateName nvarchar (255)  ,
	@TemplateContent text   ,
	@TemplateEmailSubject nvarchar (25)  ,
    @DefaultTemplate bit,
--	@EnterById int   ,
--	@EnterDate datetime   ,
	@EditById int   ,
	@EditDate datetime   

)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].EmailTemplates
				SET
					TemplateName=@TemplateName
					,TemplateContent=@TemplateContent
					,TemplateEmailSubject=@TemplateEmailSubject
					,DefaultTemplate=@DefaultTemplate
--					,[EnterByID] = @EnterById
--					,[EnterDate] = @EnterDate
					,[EditByID] = @EditById
					,[EditDate] = @EditDate
					
				WHERE
[TemplateID] = @TemplateID 
				
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- ALTER date:  7 Agust. 2011
-- Description:	Get branch order
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Branch_Order] 
(
	@ID int,
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
					  Main_SubCode AS Main_SubCode_1 ON Contact_Branches.TypeID = Main_SubCode_1.SID) temp
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

GO

USE [ASI-CRM]
GO
/****** Object:  Table [dbo].[WebsitesServices]    Script Date: 08/15/2011 09:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebsitesServices](
	[WSID] [int] IDENTITY(1,1) NOT NULL,
	[WSName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[WSURL] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[WSUsername] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[WSPassword] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_WebsitesServices] PRIMARY KEY CLUSTERED 
(
	[WSID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 15 Augst. 2011
-- Description:	Delete existing one record in 'WebsitesServices' table
-- =============================================
Create PROCEDURE [dbo].[WebsitesServices_Delete] 
(
	@WSID int,
	@Result int output 	
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM WebsitesServices
      WHERE [WSID] = @WSID

	SET @Result = @@Rowcount
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 15 Agust. 2011
-- Description:	Get all WebsitesServices related to properties
-- =============================================
Create PROCEDURE [dbo].[WebsitesServices_Get]
	-- Add the parameters for the stored procedure here
	(
		 @Filter nvarchar(2000)
		,@SortExp nvarchar(100)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--Declare @Filter AS nvarchar(500)
	Declare @Query AS nvarchar(2000)
	Declare @FullQuery AS nvarchar(4000)

    -- Insert statements for procedure here
	--SET @Filter = ''
	SET @Query = 
	'SELECT  WebsitesServices.WSID, WebsitesServices.WSName, WebsitesServices.WSURL, 
		WebsitesServices.WSUsername, WebsitesServices.WSPassword
	FROM    WebsitesServices 
	WHERE	1=1 '
	/*IF @AccountName <> '-1'
		SET @Filter = @Filter + ' AND Contact_Account.AName = ' + CHAR(39) + @AccountName + CHAR(39)
	IF @City <> '-1'
		SET @Filter = @Filter + ' AND Contact_Account.City = ' + CHAR(39) + @City + CHAR(39)
	IF @Phone <> '-1'
		SET @Filter = @Filter + ' AND Contact_Account.Phone = ' + CHAR(39) + @Phone + CHAR(39)
	IF @State <> '-1'
		SET @Filter = @Filter + ' AND Contact_Account.State = ' + CHAR(39) + @State + CHAR(39)*/
	IF @SortExp <> '-1'
			SET @Filter = @Filter + ' ORDER BY ' +  @SortExp 
	SET @FullQuery = @Query + @Filter
	Execute(@FullQuery)
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 15 Agust. 2011
-- Description:	Insert new record into 'WebsitesServices' table
-- =============================================
Create PROCEDURE [dbo].[WebsitesServices_Insert]
	-- Add the parameters for the stored procedure here
	(	 
		 @WSName varchar(256)
		,@WSURL varchar(4000)
		,@WSUsername varchar(256)
		,@WSPassword varchar(256)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT	INTO WebsitesServices
			(WSName
           ,WSURL
           ,WSUsername
           ,WSPassword)
	VALUES	(@WSName
           ,@WSURL
           ,@WSUsername
           ,@WSPassword)
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 15 Agust. 2011
-- Description:	Update existing record in 'WebsitesServices' table
-- =============================================
Create PROCEDURE [dbo].[WebsitesServices_Update]
	-- Add the parameters for the stored procedure here
	(
		 @WSID nvarchar(25)
		,@WSName nvarchar(256)
		,@WSURL nvarchar(4000)
		,@WSUsername nvarchar(256)
		,@WSPassword nvarchar(256)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @UpdateQuery AS nvarchar(4000)
	SET @UpdateQuery = 'UPDATE WebsitesServices	SET  '

    -- Insert statements for procedure here
	IF(@WSName <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' WSName = ' + CHAR(39) + @WSName + CHAR(39) + ','
	IF(@WSURL <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' WSURL = ' + CHAR(39) + @WSURL + CHAR(39) + ','
	IF(@WSUsername <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' WSUsername = ' + CHAR(39) + @WSUsername + CHAR(39) + ','
	IF(@WSPassword <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' WSPassword = ' + CHAR(39) + @WSPassword + CHAR(39) + ','

	Declare @StringLength AS int
	SET @StringLength = len(@UpdateQuery)
	SET @UpdateQuery = SUBSTRING(@UpdateQuery,1,@StringLength-1)	

	SET @UpdateQuery = @UpdateQuery + ' WHERE  WSID = ' + @WSID 
	Execute(@UpdateQuery)
END




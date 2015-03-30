USE [ASI-CRM]
GO

--------------------------------------------------------------------------------------------------------

ALTER TABLE Contact_Notes
ADD BranchID int
go
---------------------------------------------------
ALTER TABLE Contact_Account
ADD Email nvarchar(255)
go
/****** Object:  Table [dbo].[Attachments]    Script Date: 07/07/2011 18:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attachments](
	[AttachmentID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](250) COLLATE Arabic_CI_AS NOT NULL,
	[FileSize] [varchar](20) COLLATE Arabic_CI_AS NOT NULL,
	[Attach] [image] NOT NULL,
	[Description] [varchar](8000) COLLATE Arabic_CI_AS NULL,
	[AccountID] [int] NULL,
	[ContactID] [int] NULL,
	[BranchID] [int] NULL,
	[EnterBy] [int] NOT NULL,
	[EnterDate] [datetime] NOT NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime] NULL,
 CONSTRAINT [PK_ATTACHMENTS] PRIMARY KEY CLUSTERED 
(
	[AttachmentID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_PK_ATTACHMENTS_ATTACHME] UNIQUE NONCLUSTERED 
(
	[AttachmentID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

----------------------------------------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------
-- Created By: Sayed 10-7-2011
-- Purpose: Delete  record from the attachements
----------------------------------------------------------------------------------------------------
*/


Create PROCEDURE [dbo].[Attachments_Delete]
(

	@AttachmentID int   
)
AS


				DELETE FROM [dbo].Attachments WITH (ROWLOCK) 
				WHERE
					[AttachmentID] = @AttachmentID
					
----------------------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Alsayed Moawad 
-- Create date: 10 July. 2011
-- Description:	select Attachments by CompanyID
-- =============================================
-- exec Attachments_GetByContactID 1313
Create PROCEDURE [dbo].[Attachments_GetByBranchID]
   @ContactID  varchar (50)
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
  FROM Attachments,Sec_UserLogin,Sec_UserLogin as Sec_UserLogin_1 where Attachments.EnterBy=Sec_UserLogin.UID and Attachments.EditBy=Sec_UserLogin_1.UID and ContactID=@ContactID


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
-----------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Alsayed Moawad 
-- Create date: 10 July. 2011
-- Description:	select Attachments by CompanyID
-- =============================================
-- exec Attachments_GetByCompanyID 1313

Create PROCEDURE [dbo].[Attachments_GetByCompanyID]
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
  FROM Attachments,Sec_UserLogin,Sec_UserLogin as Sec_UserLogin_1 where Attachments.EnterBy=Sec_UserLogin.UID and Attachments.EditBy=Sec_UserLogin_1.UID and AccountID=@CompanyID


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
--------------------------------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Alsayed Moawad 
-- Create date: 10 July. 2011
-- Description:	select Attachments by CompanyID
-- =============================================
-- exec Attachments_GetByContactID 1313
Create PROCEDURE [dbo].[Attachments_GetByContactID]
   @ContactID  varchar (50)
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
  FROM Attachments,Sec_UserLogin,Sec_UserLogin as Sec_UserLogin_1 where Attachments.EnterBy=Sec_UserLogin.UID and Attachments.EditBy=Sec_UserLogin_1.UID and ContactID=@ContactID

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
---------------------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Alsayed Moawad 
-- Create date: 10 July. 2011
-- Description:	select Attachments by CompanyID
-- =============================================
-- exec [Attachments_GetByID] 13

Create PROCEDURE [dbo].[Attachments_GetByID]
   @AttachmentID  varchar (50)
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
  FROM Attachments,Sec_UserLogin,Sec_UserLogin as Sec_UserLogin_1 where Attachments.EnterBy=Sec_UserLogin.UID and Attachments.EditBy=Sec_UserLogin_1.UID and AttachmentID=@AttachmentID

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
-------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author: Alsayed Moawad 
-- Create date: 10 July. 2011
-- Description:	insert record into Attachments table
-- =============================================

Create PROCEDURE [dbo].[Attachments_Insert]
(
	@FileName varchar (250)  ,
	@FileSize varchar (20)   ,
	@Attach image   ,
    @Description varchar (8000),
    @AccountID int ,
	@ContactID int ,
    @BranchID int,
	@EnterById int   ,
	@EnterDate datetime   ,
	@EditById int   ,
	@EditDate datetime   

)
AS
				
INSERT INTO [dbo].Attachments
	(
					
	[FileName],
	[FileSize],
	[Attach],
	[Description],
	[AccountID],
	[ContactID],
    [BranchID],
	[EnterBy],
	[EnterDate],
	[EditBy],
	[EditDate]
					
	)
	VALUES
	(
	@FileName  ,
	@FileSize ,
	@Attach  ,
    @Description ,
    @AccountID,
	@ContactID ,
	@BranchID,
	@EnterById  ,
	@EnterDate  ,
	@EditById ,
	@EditDate   
					
    )
				
				
SELECT SCOPE_IDENTITY()
									
	------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailTemplates](
	[TemplateID] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TemplateContent] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TemplateEmailSubject] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DefaultTemplate] [bit] NOT NULL CONSTRAINT [DF_EmailTemplates_DefaultTemplate]  DEFAULT ((0)),
	[EnterByID] [int] NOT NULL,
	[EnterDate] [datetime] NOT NULL,
	[EditByID] [int] NULL,
	[EditDate] [datetime] NULL,
 CONSTRAINT [PK_EmailTemplates] PRIMARY KEY CLUSTERED 
(
	[TemplateID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

------------------------------------------------------


set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------
-- Created By: Sayed 16-6-2011
-- Purpose: Delete  record from the Email Template table
----------------------------------------------------------------------------------------------------
*/


Create PROCEDURE [dbo].[EmailTemplate_Delete]
(

	@TemplateID int   
)
AS


				DELETE FROM [dbo].[EmailTemplate] WITH (ROWLOCK) 
				WHERE
					[TemplateID] = @TemplateID
					
			


---------------------------------------------------------
						
	set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Sayed 16-6-2011
-- Purpose: Get  record from the Email Template table
----------------------------------------------------------------------------------------------------
*/


Create PROCEDURE [dbo].[EmailTemplate_GetByTemplateID]
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
					[dbo].[EmailTemplate]
				WHERE
					TemplateID = @TemplateID
				SELECT @@ROWCOUNT
					
			

------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Sayed 16-6-2011
-- Purpose: Inserts a record into the Email Template table
----------------------------------------------------------------------------------------------------
*/


Create PROCEDURE [dbo].[EmailTemplate_Insert]
(

	@TemplateID int    OUTPUT,
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
				SET @TemplateID = SCOPE_IDENTITY()
									
							
			


------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Sayed 16-6-2011
-- Purpose: Get All records from the Email Template table
----------------------------------------------------------------------------------------------------
*/


Create PROCEDURE [dbo].[EmailTemplate_SelectAll]

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
					[dbo].[EmailTemplate] order by TemplateName
				
				SELECT @@ROWCOUNT
					
			


--------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Sayed 16-6-2011
-- Purpose: Update  record into the Email Template table
----------------------------------------------------------------------------------------------------
*/


Create PROCEDURE [dbo].[EmailTemplate_Update]
(

	
	@TemplateID int    OUTPUT,
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


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[EmailTemplate]
				SET
					TemplateName=@TemplateName
					,TemplateContent=@TemplateContent
					,TemplateEmailSubject=@TemplateEmailSubject
					,DefaultTemplate=@DefaultTemplate
					,[EnterByID] = @EnterById
					,[EnterDate] = @EnterDate
					,[EditByID] = @EditById
					,[EditDate] = @EditDate
					
				WHERE
[TemplateID] = @TemplateID 
				
----------------------------------------------------
			
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Key_Software](
	[SID] [int] IDENTITY(1,1) NOT NULL,
	[Software] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IssueDate] [datetime] NULL,
	[Version] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Build] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ServiceBack] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LicenseCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LicenseKey] [nvarchar](80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MachineCode] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HardwareKey] [bit] NULL,
	[VMWare] [bit] NULL,
	[KeySuppliedID] [int] NULL,
	[LicenseServer] [bit] NULL,
	[FileVersion] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactID] [int] NULL,
	[CompanyID] [int] NULL,
	[BranchID] [int] NULL,
	[ExpireDate] [datetime] NULL,
	[EnterBy] [int] NULL,
	[EnterDate] [datetime] NULL,
	[EditBy] [int] NULL,
	[EditDate] [datetime] NULL,
	[KeyNote] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[KeyOption] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LicenseType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LicensePeriod] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Approvedby] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MethodofPayment] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Key_Software] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

------------------------------------------------------------------------------------


set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Description:	insert record into the Key_Software table
-- =============================================

Create PROCEDURE [dbo].[Key_Software_Insert]
(

            @Software nvarchar(255)
           ,@IssueDate datetime
           ,@Version nvarchar(255)
           ,@Build nvarchar(255)
           ,@ServiceBack nvarchar(255)
           ,@LicenseCode nvarchar(50)
           ,@LicenseKey nvarchar(80)
           ,@MachineCode nvarchar(4000)
           ,@HardwareKey bit
           ,@VMWare bit
           ,@KeySuppliedID int
           ,@LicenseServer bit
           ,@FileVersion nvarchar(255)
           ,@ContactID int
           ,@CompanyID int
           ,@BranchID int
           ,@ExpireDate datetime
           ,@EnterBy int
           ,@EnterDate datetime
           ,@EditBy int
           ,@EditDate datetime
           ,@KeyNote nvarchar(500)
           ,@KeyOption nvarchar(100)
           ,@LicenseType nvarchar(50)
           ,@LicensePeriod nvarchar(50)
           ,@Approvedby nvarchar(50)
           ,@MethodofPayment nvarchar(250)
	
)
AS


				
				INSERT INTO [dbo].Key_Software
					(
			Software
           ,IssueDate
           ,Version
           ,Build
           ,ServiceBack
           ,LicenseCode
           ,LicenseKey
           ,MachineCode
           ,HardwareKey
           ,VMWare
           ,KeySuppliedID
           ,LicenseServer
           ,FileVersion
           ,ContactID
           ,CompanyID
           ,BranchID
           ,ExpireDate
           ,EnterBy
           ,EnterDate
           ,EditBy
           ,EditDate
           ,KeyNote
           ,KeyOption
           ,LicenseType
           ,LicensePeriod
           ,Approvedby
           ,MethodofPayment
					
					)
				VALUES
					(
			@Software
           ,@IssueDate
           ,@Version
           ,@Build
           ,@ServiceBack
           ,@LicenseCode
           ,@LicenseKey
           ,@MachineCode
           ,@HardwareKey
           ,@VMWare
           ,@KeySuppliedID
           ,@LicenseServer
           ,@FileVersion
           ,@ContactID
           ,@CompanyID
           ,@BranchID
           ,@ExpireDate
           ,@EnterBy
           ,@EnterDate
           ,@EditBy
           ,@EditDate
           ,@KeyNote
           ,@KeyOption
           ,@LicenseType
           ,@LicensePeriod
           ,@Approvedby
           ,@MethodofPayment
					
					)
				
				-- Get the identity value
				--SET @TemplateID = SCOPE_IDENTITY()
SELECT SCOPE_IDENTITY()
									
							
			





------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[KeySoftWare_GetKeySoftwareByBranchID]
   @BranchID  varchar (50)
-- Get Software By Contact
AS

SELECT     SID, Software, IssueDate, Version, Build, ServiceBack, LicenseCode, LicenseKey, MachineCode, HardwareKey, VMWare, KeySuppliedID, 
                      LicenseServer, FileVersion, ContactID, CompanyID,BranchID, ExpireDate, EnterBy, EnterDate, EditBy, EditDate,KeyNote,KeyOption,Approvedby,LicenseType,LicensePeriod,MethodofPayment 
FROM         Key_Software where BranchID=@BranchID



---------------------------------------------------------------------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON





----------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[KeySoftWare_GetKeySoftwareByBranchID]
   @BranchID  varchar (50)
-- Get Software By Contact
AS

SELECT     SID, Software, IssueDate, Version, Build, ServiceBack, LicenseCode, LicenseKey, MachineCode, HardwareKey, VMWare, KeySuppliedID, 
                      LicenseServer, FileVersion, ContactID, CompanyID,BranchID, ExpireDate, EnterBy, EnterDate, EditBy, EditDate,KeyNote,KeyOption,Approvedby,LicenseType,LicensePeriod,MethodofPayment 
FROM         Key_Software where BranchID=@BranchID



---------------------------------------------------------------------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON



---------------------------------------------------------------------------------

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[KeySoftWare_GetKeySoftwareByCompanyID]
   @CompanyID  varchar (50)
-- Get Software By Contact
AS

SELECT     SID, Software, IssueDate, Version, Build, ServiceBack, LicenseCode, LicenseKey, MachineCode, HardwareKey, VMWare, KeySuppliedID, 
                      LicenseServer, FileVersion, ContactID, CompanyID,BranchID, ExpireDate, EnterBy, EnterDate, EditBy, EditDate,KeyNote,KeyOption,Approvedby,LicenseType,LicensePeriod,MethodofPayment 
FROM         Key_Software where CompanyID=@CompanyID



---------------------------------------------------------------------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

---------------------------------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[KeySoftWare_GetKeySoftwareByContactID]
   @ContactID  varchar (50)
-- Get Software By Contact
AS

SELECT     SID, Software, IssueDate, Version, Build, ServiceBack, LicenseCode, LicenseKey, MachineCode, HardwareKey, VMWare, KeySuppliedID, 
                      LicenseServer, FileVersion, ContactID, CompanyID,BranchID, ExpireDate, EnterBy, EnterDate, EditBy, EditDate,KeyNote,KeyOption,LicenseType,LicensePeriod
FROM         Key_Software where ContactID=@ContactID


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
----------------------------------------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



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
			Contact_Account.EditDate, Contact_Account.Street2, 
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





------------------------------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO




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

		SELECT AID, AName, TypeID, BusSector, Fax, Phone, WebSite, IDStatus, Street1, 
		City, ZipCode, CountryID, ReferedBy, EnterByID, EnterDate, EditByID, EditDate, Street2, 
		AccountManagerID, AccountManagerEditDate, AccountManagerEditByID, AccoutnManagerAssignedDate, 
		Tag, State, CountryName, StatusName, BusinessSectorName, EnterByName, EditByName, 
		AccountManagerName, AccountManagerEditByName, Profile, LastAccountNoteDate
		FROM (SELECT  Contact_Account.AID, Contact_Account.AName, Contact_Account.TypeID, 
		Contact_Account.BusSector, Contact_Account.Fax, Contact_Account.Phone, 
		Contact_Account.WebSite, Contact_Account.IDStatus, Contact_Account.Street1, 
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






------------------------------------------------

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ehab Hosny
-- Create date: 02 April. 2008
-- Description:	Get single contact account record sent paramter
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Single_Contact_Account]
	-- Add the parameters for the stored procedure here
	(
		@AID int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	Contact_Account.AID, Contact_Account.AName, Contact_Account.TypeID, 
			Contact_Account.BusSector, Contact_Account.Fax, Contact_Account.Phone, 
			Contact_Account.WebSite, Contact_Account.IDStatus, 
			Contact_Account.Street1, Contact_Account.City, Contact_Account.ZipCode, 
			Contact_Account.CountryID, Contact_Account.ReferedBy, 
			Contact_Account.EnterByID, Contact_Account.EnterDate, Contact_Account.EditByID, 
			Contact_Account.EditDate, Contact_Account.Street2, 
			Contact_Account.AccountManagerID, Contact_Account.AccountManagerEditDate, 
			Contact_Account.AccountManagerEditByID, Contact_Account.AccoutnManagerAssignedDate, Contact_Account.Tag, Contact_Account.State, 
			Main_SubCode_1.SCode AS CountryName, Main_SubCode.SCode AS StatusName, Main_SubCode_2.SCode AS BusinessSectorName, 
			Sec_UserLogin_1.UserName AS EnterByName, Sec_UserLogin.UserName AS EditByName, Sec_UserLogin_3.UserName AS AccountManagerName, 
			Sec_UserLogin_2.UserName AS AccountManagerEditByName,Contact_Account.Profile,Contact_Account.Email 
	FROM	Contact_Account LEFT OUTER JOIN
			Sec_UserLogin AS Sec_UserLogin_1 ON Contact_Account.EnterByID = Sec_UserLogin_1.UID LEFT OUTER JOIN
			Main_SubCode ON Contact_Account.IDStatus = Main_SubCode.SID LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID LEFT OUTER JOIN
			Sec_UserLogin AS Sec_UserLogin_3 ON Contact_Account.AccountManagerID = Sec_UserLogin_3.UID LEFT OUTER JOIN
			Sec_UserLogin AS Sec_UserLogin_2 ON Contact_Account.AccountManagerEditByID = Sec_UserLogin_2.UID LEFT OUTER JOIN
			Sec_UserLogin ON Contact_Account.EditByID = Sec_UserLogin.UID LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_2 ON Contact_Account.BusSector = Main_SubCode_2.SID
	WHERE	Contact_Account.AID = @AID
END



------------------------------------------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

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
			,Tag,Profile,Email)
	VALUES	(@AName,@TypeID,@BusSector ,@Fax ,@Phone ,@WebSite ,@IDStatus ,@Street1 
			,@City ,@ZipCode ,@CountryID ,@ReferedBy ,@EnterByID ,@EnterDate ,@EditByID 
			,@EditDate ,@Street2 ,@AccountManagerID ,@AccountManagerEditDate 
			,@AccountManagerEditByID ,@AccoutnManagerAssignedDate,
			 @State ,@Tag ,@Profile,@Email)
	SELECT SCOPE_IDENTITY()
END





-----------------------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

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
GO


-- =============================================
-- Author:        Yasser Abd Rab El-Rasol
-- ALTER  date:	  30 May 2011
-- Description:   Get all Branches from 'Contact_Branches' that has main contact
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Branches] 
      (
             @BranchID int
            ,@StatusID int
            ,@BranchName nvarchar(255)
            ,@City nvarchar(255)
            ,@Phone nvarchar(255)
            ,@State nvarchar(255) 
            ,@BussinessSectorName nvarchar(255)
            ,@CountryName nvarchar(255)
            ,@SortExp nvarchar(255)
            ,@FilterBranchNotes int
            
      )
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	---------------------------------------------------------------------------------------
			Declare @Filter AS nvarchar(500)
            Declare @Query AS nvarchar(3000)
            Declare @FullQuery AS nvarchar(3500)
            SET @Filter = ''
            SET @Query = 
            'SELECT     Contact_Branches.BranchID, Contact_Branches.BrnachName AS BranchName, Contact_Branches.TypeID, Contact_Branches.BusSector AS BussinessSectorID, 
					  Contact_Branches.Fax, Contact_Branches.Phone, Contact_Branches.WebSite, Contact_Branches.IDStatus, Contact_Branches.Street1, Contact_Branches.City, 
                      Contact_Branches.ZipCode, Contact_Branches.CountryID, Contact_Branches.ReferedBy, Contact_Branches.EnterByID, Contact_Branches.EnterDate, 
                      Contact_Branches.EditByID, Contact_Branches.EditDate, Contact_Branches.Street2, Contact_Branches.BranchManagerID, 
                      Contact_Branches.BranchManagerEditDate, Contact_Branches.BranchManagerEditByID, Contact_Branches.BranchManagerAssignedDate, 
                      Contact_Branches.State, Contact_Branches.AccountID, Contact_Branches.MainOffice, Contact_ContactsInfo.LastName, 
                      Contact_ContactsInfo.FirstName AS ContactFullName, Contact_ContactsInfo.ContactID, Main_SubCode_1.SCode AS TypeName, 
                      Main_SubCode.SCode AS CountryName, Main_SubCode_2.SCode AS BussinessSectorName, Main_SubCode_3.SCode AS StatusName, 
                      Sec_UserLogin_1.UserName AS EnteredByName, Sec_UserLogin_2.UserName AS EditByName, 
                      Sec_UserLogin_3.UserName AS BranchManagerName, Sec_UserLogin.UserName AS BranchManagerEditByName, 
                      Contact_Account.AName AS AccountName, (Select Max(NoteDate) from Contact_Notes where Contact_Notes.BranchID = Contact_Branches.BranchID) AS LastBranchNoteDate
			FROM		Contact_Branches LEFT OUTER JOIN
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

            WHERE     (1 = 1) '

            IF @BranchID <> -1
                  SET @Filter = @Filter + ' AND Contact_Branches.BranchID = ' + CONVERT(nvarchar(25),@BranchID)
            
            IF @StatusID <> -1
                  SET @Filter = @Filter + ' AND Contact_Branches.IDStatus = ' + CONVERT(nvarchar(25), @StatusID)
 
            IF @BranchName <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Branches.BrnachName LIKE  ' + CHAR(39)  + @BranchName + '%' + CHAR(39)

            IF @City <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Branches.City LIKE ' + CHAR(39) + @City + '%' + CHAR(39)

            IF @Phone <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Branches.Phone LIKE ' + CHAR(39) + @Phone + '%' + CHAR(39)

            IF @State <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Branches.State LIKE ' + CHAR(39) + @State + '%' + CHAR(39)

            IF @BussinessSectorName <> '-1'
                  SET @Filter = @Filter + ' AND Main_SubCode_2.SCode LIKE ' + CHAR(39) + @BussinessSectorName + '' + CHAR(39)
   	   
	        IF @CountryName <> '-1'
                  SET @Filter = @Filter + ' AND Main_SubCode.SCode LIKE ' + CHAR(39) + @CountryName + '%' + CHAR(39)

            IF @FilterBranchNotes = 1
                  SET @Filter = @Filter + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.BranchID = Contact_Branches.BranchID) is Not NULL' 

            IF @FilterBranchNotes = 2
                  SET @Filter = @Filter + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.BranchID = Contact_Branches.BranchID) is NULL' 

            IF @SortExp <> '-1'
                  SET @Filter = @Filter + ' ORDER BY ' +  @SortExp 
  
            SET @FullQuery = @Query + @Filter

            Execute(@FullQuery)
END






---------------------------------------------------------------------

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:        Yasser Abd Rab El-Rasol
-- Create date:   29 May. 2011
-- Description:   Get branches names or Business Sector names for incremental search purpose
-- =============================================
Create PROCEDURE [dbo].[SP_Get_All_Branches_Names]
      (
             @SearchCriteria nvarchar(100)
            ,@Pref nvarchar(100)
            ,@Country nvarchar(100)
            ,@State nvarchar(100)
			,@BusSect nvarchar(100)
            ,@Notes nvarchar(100)
            ,@Tag nvarchar(100)
      )
AS
BEGIN
    SET NOCOUNT ON;
    ------Declare Needed variables
    DECLARE @Query AS nvarchar(2000)
      ----Create SQL Query
      IF @SearchCriteria = 'BrnachName'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Branches 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Branches.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Branches.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE BrnachName' + ' LIKE ' + CHAR(39) 
                  + @Pref + '%' + CHAR(39)
      ELSE
            SET @Query = 'SELECT DISTINCT TOP 20   Main_SubCode_2.SCode AS BusinessSectorName
			  FROM	  Contact_Branches LEFT OUTER JOIN
				  Main_SubCode AS Main_SubCode_2 ON 
				  Contact_Branches.BusSector = Main_SubCode_2.SID
				LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Branches.CountryID = Main_SubCode_1.SID 
			  WHERE	  Main_SubCode_2.SCode  LIKE '  + CHAR(39) + @Pref + '%' + CHAR(39)
      IF @Country <> '-1'
		SET @Query = @Query + ' AND Main_SubCode_1.SCode = ' +  CHAR(39) + @Country +  CHAR(39)
      IF @State <> '-1'
		SET @Query = @Query + ' AND Contact_Branches.State = ' +  CHAR(39) + @State +  CHAR(39)
	  IF @BusSect <> '-1'
		SET @Query = @Query + ' AND Main_SubCode_2.SCode LIKE ' + CHAR(39) + @BusSect + CHAR(39) 
	  IF @Notes = '1'
          SET @Query = @Query + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.BranchID = Contact_Branches.BranchID) is Not NULL' 
	  IF @Notes = '2'
          SET @Query = @Query + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.BranchID = Contact_Branches.BranchID) is NULL' 

	  SET @Query = @Query + ' ORDER BY ' +  @SearchCriteria
      -------Execute Created Query	
      Execute(@Query)
		print @Query
END








-----------------------------------------------------------------------
		
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 12 June. 2011
-- Description:	Get branch order
-- =============================================
-- exec SP_Get_Branch_Order 34,0
Create PROCEDURE [dbo].[SP_Get_Branch_Order] 
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
	SELECT @RowsBeforeID = COUNT(BranchID) - 1
	FROM Contact_Branches
	WHERE BrnachName <= (SELECT BrnachName
					FROM Contact_Branches
					WHERE BranchID = @ID)
	
	
	SET @Order = @RowsBeforeID
		
	
print @RowsBeforeID
END

---------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ehab Hosny
-- Alter date:  14 June. 2011
-- Description:	Insert new record into 'Contact_Notes' table
-- =============================================
ALTER PROCEDURE [dbo].[SP_INSERT_INTO_Contact_Notes]
	-- Add the parameters for the stored procedure here
	(	 
		 @NoteDate datetime
		,@UserEnterDate datetime
		,@Notes text
		,@EnterdByID int
		,@EditByID int
		,@EditDate datetime
		,@ContactID int
		,@AccountID int
		,@BranchID int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT	INTO Contact_Notes
			(NoteDate,UserEnterDate,Notes,EnterdByID,EditByID,EditDate,ContactID,AccountID, BranchID)
	VALUES	(@NoteDate,@UserEnterDate,@Notes,@EnterdByID,@EditByID,@EditDate,@ContactID,@AccountID, @BranchID)
END
------------------------------------------------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ehab Hosny
-- Alter date:  15 June. 2011
-- Description:	Get all notes related to Conatact or account
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Notes]
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
	Declare @FullQuery AS nvarchar(2500)

    -- Insert statements for procedure here
	--SET @Filter = ''
	SET @Query = 
	'SELECT  Contact_Notes.NID, Contact_Notes.NoteDate, Contact_Notes.UserEnterDate, 
		Contact_Notes.NoteTime,Contact_Notes.Notes, Contact_Notes.EnterdByID, 
		Contact_Notes.EditByID, Contact_Notes.EditDate, Contact_Notes.ContactID, 
		Contact_Notes.AccountID, Contact_Notes.BranchID, Sec_UserLogin_1.UserName AS EnteredByName, 
		Sec_UserLogin.UserName AS EditByName, Contact_Account.AName AS AccountName, 
		Contact_Branches.BrnachName AS BranchName,
		Contact_ContactsInfo.FirstName AS ContactFirstName, 
		Contact_ContactsInfo.LastName AS ContactLastName
	FROM    Sec_UserLogin INNER JOIN
		Contact_Notes INNER JOIN
		Sec_UserLogin AS Sec_UserLogin_1 ON Contact_Notes.EnterdByID = Sec_UserLogin_1.UID ON 
		Sec_UserLogin.UID = Contact_Notes.EditByID LEFT OUTER JOIN Contact_Account ON 
		Contact_Notes.AccountID = Contact_Account.AID LEFT OUTER JOIN Contact_Branches ON 
		Contact_Notes.BranchID = Contact_Branches.BranchID LEFT OUTER JOIN Contact_ContactsInfo ON 
		Contact_Notes.ContactID = Contact_ContactsInfo.ContactID
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




-----------------------------------------------------------------------



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Calls](
	[CallID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[Status] [int] NULL,
	[ContactID] [int] NULL,
	[AccountID] [int] NULL,
	[EnterByID] [int] NOT NULL,
	[EnterDate] [datetime] NOT NULL,
	[EditByID] [int] NULL,
	[EditDate] [datetime] NULL,
	[Notes] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Calls] PRIMARY KEY CLUSTERED 
(
	[CallID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

-----------------------------------------------


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 15 June. 2011
-- Description:	Delete existing one record in 'Calls' table
-- =============================================
create PROCEDURE [dbo].[Calls_Delete] 
(
	@CallID int,
	@Result int output 	
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Calls
      WHERE CallID = @CallID

	SET @Result = @@Rowcount
END







----------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 15 June. 2011
-- Description:	Get all calls related to properties
-- =============================================
Create PROCEDURE [dbo].[Calls_Get]
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
	'SELECT  Calls.CallID, Calls.Subject, 
		Calls.StartDate, Calls.Status, Main_SubCode_1.SCode AS StatusName, Calls.ContactID, 
		Calls.AccountID, Contact_Account.AName AS AccountName, 
		Contact_ContactsInfo.FirstName AS ContactFirstName, 
		Contact_ContactsInfo.LastName AS ContactLastName,
		Calls.EnterByID, Sec_UserLogin_1.UserName AS EnterByName, 
		Calls.EnterDate, Calls.EditByID, Sec_UserLogin_2.UserName AS EditByName, Calls.EditDate, 
		Calls.Notes
	FROM    Calls INNER JOIN 
		Sec_UserLogin AS Sec_UserLogin_1 ON Calls.EnterByID = Sec_UserLogin_1.UID INNER JOIN  
		Sec_UserLogin AS Sec_UserLogin_2 ON Sec_UserLogin_2.UID = Calls.EditByID LEFT OUTER JOIN Contact_Account ON 
		Calls.AccountID = Contact_Account.AID LEFT OUTER JOIN Contact_ContactsInfo ON 
		Calls.ContactID = Contact_ContactsInfo.ContactID LEFT OUTER JOIN
        Main_SubCode AS Main_SubCode_1 ON Calls.Status = Main_SubCode_1.SID
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

---------------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 14 June. 2011
-- Description:	Insert new record into 'Calls' table
-- =============================================
Create PROCEDURE [dbo].[Calls_Insert]
	-- Add the parameters for the stored procedure here
	(	 
		 @Subject varchar(500)
		,@StartDate datetime
		,@Status int
		,@ContactID int
		,@AccountID int
		,@EnterByID int
		,@EnterDate datetime
		,@EditByID int
		,@EditDate datetime
		,@Notes nvarchar(4000)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT	INTO Calls
			([Subject]
           ,[StartDate]
           ,[Status]
           ,[ContactID]
           ,[AccountID]
           ,[EnterByID]
           ,[EnterDate]
           ,[EditByID]
           ,[EditDate]
           ,[Notes])
	VALUES	(@Subject
           ,@StartDate
           ,@Status
           ,@ContactID
           ,@AccountID
           ,@EnterByID
           ,@EnterDate
           ,@EditByID
           ,@EditDate
           ,@Notes)
END


--------------------------------------------------------------------------------------

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 15 June. 2011
-- Description:	Update existing record in 'Calls' table
-- =============================================
Create PROCEDURE [dbo].[Calls_Update]
	-- Add the parameters for the stored procedure here
	(
		 @CallID nvarchar(25)
		,@Subject varchar(500)
		,@StartDate nvarchar(100)
		,@Status nvarchar(25)
		,@ContactID nvarchar(25)
		,@AccountID nvarchar(25)
		,@EnterByID nvarchar(25)
		,@EnterDate nvarchar(100)
		,@EditByID nvarchar(25)
		,@EditDate nvarchar(100)
		,@Notes nvarchar(4000)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @UpdateQuery AS nvarchar(4000)
	SET @UpdateQuery = 'UPDATE Calls	SET  '

    -- Insert statements for procedure here
	IF(@Subject <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' Subject = ' + CHAR(39) + @Subject + CHAR(39) + ','
	IF(@StartDate <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' StartDate = ' + CHAR(39) + @StartDate + CHAR(39) + ','
	IF(@Status <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' Status = ' + @Status + ','
	IF(@ContactID <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' ContactID = ' + @ContactID + ','
	IF(@AccountID <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' AccountID = ' + @AccountID + ','
	IF(@EnterByID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' EnterByID = ' + @EnterByID + ','
	IF(@EnterDate <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' EnterDate = ' + CHAR(39) + @EnterDate + CHAR(39) + ','
	IF(@EditByID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' EditByID = ' + @EditByID + ','
	IF(@EditDate <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' EditDate = ' + CHAR(39) + @EditDate + CHAR(39) + ','
	IF(@Notes <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' Notes = ' + CHAR(39) + @Notes + CHAR(39) + ','

	Declare @StringLength AS int
	SET @StringLength = len(@UpdateQuery)
	SET @UpdateQuery = SUBSTRING(@UpdateQuery,1,@StringLength-1)	

	SET @UpdateQuery = @UpdateQuery + ' WHERE  CallID = ' + @CallID 
	Execute(@UpdateQuery)
END



-------------------------------------------------------------------------------------



INSERT INTO [Main_GeneralCode]
           ([GCode])
     VALUES
           ('CallStatus')

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-----------------------------------------------------


Declare @GID AS int

SELECT @GID = [GID]
                  FROM [Main_GeneralCode]
                  WHERE [GCode] = 'CallStatus'


      INSERT INTO [Main_SubCode]
           ([SCode]
           ,[GID])
     VALUES
           ('No Answer'
           ,@GID)

      INSERT INTO [ASI-CRM].[dbo].[Main_SubCode]
           ([SCode]
           ,[GID])
     VALUES
           ('Pending'
           ,@GID)

      INSERT INTO [ASI-CRM].[dbo].[Main_SubCode]
           ([SCode]
           ,[GID])
     VALUES
           ('Finish'
           ,@GID)

GO

INSERT INTO [Sec_Roles]
           ([RoleName]
           ,[GeneralRole])
     VALUES
           ('AddBranch'
           ,1)

INSERT INTO [Sec_Roles]
           ([RoleName]
           ,[GeneralRole])
     VALUES
           ('EditBranch'
           ,1)

INSERT INTO [Sec_Roles]
           ([RoleName]
           ,[GeneralRole])
     VALUES
           ('ViewBranch'
           ,1)

INSERT INTO [Sec_Roles]
           ([RoleName]
           ,[GeneralRole])
     VALUES
           ('AddNoteToBranch'
           ,1)

INSERT INTO [Sec_Roles]
           ([RoleName]
           ,[GeneralRole])
     VALUES
           ('DeleteBranch'
           ,1)

GO

Declare @PersonID as int
SELECT @PersonID = [GID]
  FROM [Sec_UserGroup]
WHERE  [GroupName] = 'SalesPerson'

Declare @ManagerID as int
SELECT @ManagerID = [GID]
  FROM [Sec_UserGroup]
WHERE  [GroupName] = 'SalesManager'

Declare @AddBranchID as int
SELECT @AddBranchID = [RID]
  FROM [Sec_Roles]
WHERE  [RoleName] = 'AddBranch'

Declare @EditBranchID as int
SELECT @EditBranchID = [RID]
  FROM [Sec_Roles]
WHERE  [RoleName] = 'EditBranch'

Declare @ViewBranchID as int
SELECT @ViewBranchID = [RID]
  FROM [Sec_Roles]
WHERE  [RoleName] = 'ViewBranch'

Declare @AddNoteToBranchID as int
SELECT @AddNoteToBranchID = [RID]
  FROM [Sec_Roles]
WHERE  [RoleName] = 'AddNoteToBranch'

Declare @DeleteBranchID as int
SELECT @DeleteBranchID = [RID]
  FROM [Sec_Roles]
WHERE  [RoleName] = 'DeleteBranch'

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@AddBranchID,@PersonID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@AddBranchID,@ManagerID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@EditBranchID,@PersonID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@EditBranchID,@ManagerID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@ViewBranchID,@PersonID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@ViewBranchID,@ManagerID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@AddNoteToBranchID,@PersonID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@AddNoteToBranchID,@ManagerID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@DeleteBranchID,@ManagerID,null,null)

GO

INSERT INTO [Sec_Roles]
           ([RoleName]
           ,[GeneralRole])
     VALUES
           ('AddCall'
           ,1)

INSERT INTO [Sec_Roles]
           ([RoleName]
           ,[GeneralRole])
     VALUES
           ('EditCall'
           ,1)

INSERT INTO [Sec_Roles]
           ([RoleName]
           ,[GeneralRole])
     VALUES
           ('ViewCall'
           ,1)

INSERT INTO [Sec_Roles]
           ([RoleName]
           ,[GeneralRole])
     VALUES
           ('DeleteCall'
           ,1)

GO


Declare @PersonID as int
SELECT @PersonID = [GID]   
  FROM [Sec_UserGroup]
WHERE  [GroupName] = 'SalesPerson'

Declare @ManagerID as int
SELECT @ManagerID = [GID]
  FROM [Sec_UserGroup]
WHERE  [GroupName] = 'SalesManager'

Declare @AddCallID as int
SELECT @AddCallID = [RID]
  FROM [Sec_Roles]
WHERE  [RoleName] = 'AddCall'

Declare @EditCallID as int
SELECT @EditCallID = [RID]
  FROM [Sec_Roles]
WHERE  [RoleName] = 'EditCall'

Declare @ViewCallID as int
SELECT @ViewCallID = [RID]
  FROM [Sec_Roles]
WHERE  [RoleName] = 'ViewCall'

Declare @DeleteCallID as int
SELECT @DeleteCallID = [RID]
  FROM [Sec_Roles]
WHERE  [RoleName] = 'DeleteCall'

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@AddCallID,@PersonID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@AddCallID,@ManagerID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@EditCallID,@PersonID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@EditCallID,@ManagerID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@ViewCallID,@PersonID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@ViewCallID,@ManagerID,null,null)

INSERT INTO [Sec_UserGroup_Role]
           ([RID],[GID],[RefID],[RefValue])
    VALUES (@DeleteCallID,@ManagerID,null,null)

GO

INSERT INTO [Main_GeneralCode]
           ([GCode])
     VALUES
           ('EmailCC')
GO
Declare @EmailCCID as int
SELECT @EmailCCID = [GID]     
  FROM [Main_GeneralCode]
WHERE  [GCode] = 'EmailCC'
INSERT INTO [Main_SubCode]
           ([SCode]
           ,[GID])
     VALUES
           ('yahmed@steelnetwork.com'
           ,@EmailCCID)
GO
-----------------------------------------------------------------------------------




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


Create PROCEDURE [dbo].[EmailTemplate_SelectNames]

AS

				SELECT
					TemplateID,
					TemplateName
					
				FROM
					EmailTemplates order by TemplateName
				
					
			



--------------------------------------------------------------------------


set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sayed Moawad
-- Create date: 6 July. 2011
-- Description:	Get History related to Account
-- =============================================
-- exec History_GetByAccountId 1313


create PROCEDURE [dbo].[History_GetByAccountId]
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
			


---------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sayed Moawad
-- Create date: 6 July. 2011
-- Description:	Get History related to Account
-- =============================================
-- exec History_GetByBranchID 1313


Create PROCEDURE [dbo].[History_GetByBranchID]
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
                             WHERE     (Contact_Branches.BranchID = @BranchID)))
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
			



-------------------------------------------------------------------------------

set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sayed Moawad
-- Create date: 6 July. 2011
-- Description:	Get History related to Account
-- =============================================
-- exec History_GetByContactID 1313


Create PROCEDURE [dbo].[History_GetByContactID]
(

	@ContactID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT     '' AS FName, '' AS LName, 'Note' AS Type,Contact_Notes.EditDate as Date,Sec_UserLogin.UserName AS EditBy, (CAST(Contact_Notes.Notes AS varchar(8000))) AS Details
                      
FROM         Contact_Notes INNER JOIN  
                      Contact_ContactsInfo ON Contact_Notes.ContactID = Contact_ContactsInfo.ContactID INNER JOIN
                      Sec_UserLogin ON Contact_Notes.EditByID = Sec_UserLogin.UID
WHERE     (Contact_ContactsInfo.ContactID = @ContactID) AND (Contact_Notes.EditDate =
                          (SELECT     MAX(EditDate) AS Expr1
                             FROM         Contact_Notes AS Contact_Notes_1
                             WHERE     (Contact_ContactsInfo.ContactID = @ContactID)))
--ORDER BY Contact_Account.AID

union

SELECT     c.FirstName AS FName, c.LastName AS LName, 'Call' AS Type, cal.StartDate AS Date, 
                      s.UserName AS EditBy, cal.Notes AS Details 
FROM         Contact_ContactsInfo c,Calls cal ,Sec_UserLogin s where 
                       c.ContactID = @ContactID and c.ContactID = cal.ContactID  
                    and cal.EditByID = s.UID and cal.EditDate in (select max(EditDate) from Calls where Calls.ContactID=c.ContactID)
--ORDER BY Contact_Account.AID
				
--				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			


--------------------------------------------------------------
GO
/****** Object:  Table [dbo].[SentEmails]    Script Date: 07/21/2011 22:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SentEmails](
	[SentEmailID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SentDate] [datetime] NOT NULL,
	[SentBY] [int] NOT NULL,
 CONSTRAINT [PK_Key_SentEmails] PRIMARY KEY CLUSTERED 
(
	[SentEmailID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

---------------------------------------------------------------------------



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        Yasser Abd Rab El-Rasol
-- Create date: 6 July. 2011
-- Description:   Insert new record into 'SentEmails' table
-- =============================================
Create PROCEDURE [dbo].[SentEmails_Insert]
      -- Add the parameters for the stored procedure here
      (     
             @Email varchar(255)
            ,@SentDate datetime
            ,@SentBY int
      )
AS
BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET NOCOUNT ON;

    -- Insert statements for procedure here
      INSERT      INTO SentEmails
                  ([Email]
           ,[SentDate]
           ,[SentBY])
      VALUES      (@Email
           ,@SentDate
           ,@SentBY)
END




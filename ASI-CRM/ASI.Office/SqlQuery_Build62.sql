

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 15 Agust. 2011
-- Description:	Check if this WSName exists before or not
-- =============================================
Create PROCEDURE [dbo].[WebsitesServices_Check_WSName_Existance]
	(
		 @WSName nvarchar(256),
		 @Count int output
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT	@Count = Count(WSID)
	FROM	WebsitesServices
	WHERE	WSName = @WSName
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 16 Agust. 2011
-- Description:	Check if this WSName exists before or not
-- =============================================
Create PROCEDURE [dbo].[WebsitesServices_Check_Updated_WSName_Existance]
	(
		 @WSID int,
		 @WSName nvarchar(256),
		 @Count int output
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT	@Count = Count(WSID)
	FROM	WebsitesServices
	WHERE	WSName = @WSName AND WSID <> @WSID
END



------------------------------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Description:	insert record into the Key_Software table
-- =============================================

ALTER PROCEDURE [dbo].[Key_Software_Insert]
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
									
							
			
------------------------------------------------------
------------------------------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Description:	get keySoftware by BranchID
-- =============================================





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


--------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Description:	get keySoftware by CompanyID
-- =============================================



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
-------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Description:	get keySoftware by ContactID
-- =============================================



ALTER PROCEDURE [dbo].[KeySoftWare_GetKeySoftwareByContactID]
   @ContactID  varchar (50)
-- Get Software By Contact
AS

SELECT     SID, Software, IssueDate, Version, Build, ServiceBack, LicenseCode, LicenseKey, MachineCode, HardwareKey, VMWare, KeySuppliedID, 
                      LicenseServer, FileVersion, ContactID, CompanyID,BranchID, ExpireDate, EnterBy, EnterDate, EditBy, EditDate,KeyNote,KeyOption,Approvedby,LicenseType,LicensePeriod,MethodofPayment 

FROM         Key_Software where ContactID=@ContactID


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON





----------------------------------------------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Description:	Create registration table
-- =============================================


CREATE TABLE [dbo].[Registration](
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CheckList] [bit] NULL CONSTRAINT [DF_Registration_CheckList]  DEFAULT (0),
	[Agrement] [bit] NULL CONSTRAINT [DF_Registration_Agrement]  DEFAULT (0),
	[Visible] [bit] NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

---------------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Description:	Create [Key_CheckListMainInfo] table
-- =============================================


CREATE TABLE [dbo].[Key_CheckListMainInfo](
	[TSNCompany] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Company] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[checkDate] [datetime] NULL,
	[ContactFirstName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactID] [int] NULL,
	[Email] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SSS6] [bit] NULL CONSTRAINT [DF_Key_CheckListMainInfo_SSS6]  DEFAULT (0),
	[LGD] [bit] NULL CONSTRAINT [DF_Key_CheckListMainInfo_LGD]  DEFAULT (0),
	[LDG] [bit] NULL CONSTRAINT [DF_Key_CheckListMainInfo_LDG]  DEFAULT (0),
	[sales_no] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactMName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactLastNAme] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FullName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TSNOffice] [bit] NULL,
	[UpdateBy] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[updateDate] [datetime] NULL,
	[Note] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Key_CheckListMainInfo] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

--------------------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Description:	Create CheckListQuestions table
-- =============================================

CREATE TABLE [dbo].[Key_CheckListQuestions](
	[QID] [int] NOT NULL,
	[QString] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Key_CheckListQuestions] PRIMARY KEY CLUSTERED 
(
	[QID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]



----------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Description:	Create CheckList Question answers table
-- =============================================

CREATE TABLE [dbo].[Key_CheckListQuestionAnswers](
	[YesCol] [bit] NULL CONSTRAINT [DF_Key_CheckListQuestionAnswers_YesCol]  DEFAULT (0),
	[NoCol] [bit] NULL CONSTRAINT [DF_Key_CheckListQuestionAnswers_NoCol]  DEFAULT (0),
	[NACol] [bit] NULL CONSTRAINT [DF_Key_CheckListQuestionAnswers_NACol]  DEFAULT (0),
	[Email] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[QID] [int] NOT NULL,
 CONSTRAINT [PK_Key_CheckListQuestionAnswers_1] PRIMARY KEY CLUSTERED 
(
	[Email] ASC,
	[QID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Key_CheckListQuestionAnswers]  WITH NOCHECK ADD  CONSTRAINT [FK_Key_CheckListQuestionAnswers_Key_CheckListMainInfo] FOREIGN KEY([Email])
REFERENCES [dbo].[Key_CheckListMainInfo] ([Email])
GO
ALTER TABLE [dbo].[Key_CheckListQuestionAnswers] CHECK CONSTRAINT [FK_Key_CheckListQuestionAnswers_Key_CheckListMainInfo]
GO
ALTER TABLE [dbo].[Key_CheckListQuestionAnswers]  WITH CHECK ADD  CONSTRAINT [FK_Key_CheckListQuestionAnswers_Key_CheckListQuestions] FOREIGN KEY([QID])
REFERENCES [dbo].[Key_CheckListQuestions] ([QID])
GO
ALTER TABLE [dbo].[Key_CheckListQuestionAnswers] CHECK CONSTRAINT [FK_Key_CheckListQuestionAnswers_Key_CheckListQuestions]

---------------------------------

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Sayed Moawad>
-- Create date: <21/8/2011>
-- Description:	<get registrations by email>
-- =============================================
create PROCEDURE [dbo].[SP_GetRegisterationByEmail]  
	@Email nvarchar(255)
	
AS
BEGIN

declare @countNo int

select @countNo=count(*) from Key_CheckListMainInfo where Email=@Email

if	@countNo > 0 
begin

update Registration
set CheckList= 1
where Email=@Email

end



SELECT top 1 Registration.Email,CheckList,Agrement,UpdateBy,updateDate,Note,Visible 
from Registration left outer join Key_CheckListMainInfo 
on Registration.Email= Key_CheckListMainInfo.Email  
where Registration.Email=@Email
order by Registration.Email

END

-------------------------------------------------------------------------------
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[SP_SetCheckList]  
	@Email nvarchar(255),@checklist int , @agreement int
	
AS
BEGIN

declare @countNo int

select @countNo=count(*) from Registration where Email=@Email

if	@countNo > 0 
begin

update Registration
set CheckList= @checklist ,Agrement=@agreement 
where Email=@Email

end
else
begin
insert into Registration(Email,CheckList,Agrement,Visible)values(@Email,@checklist,@agreement,1)
end





END





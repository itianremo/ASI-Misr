USE [ASI-CRM]
GO
/****** Object:  Table [dbo].[Contact_DueDiligance]    Script Date: 03/15/2012 19:59:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact_DueDiligance](
	[DueDil_ID] [int] IDENTITY(1,1) NOT NULL,
	[StracturalSoftware] [int] NULL,
	[ManunfactureCFS] [int] NULL,
	[CreditCheckStatus] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreditCheckFile] [image] NULL,
	[MasterPurchaseStatus] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MasterPurchaseFile] [image] NULL,
	[OutisdeUSA] [bit] NULL,
	[EntityListUrl] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EntityListAnswer] [int] NULL,
	[BlockedPersonListURL] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BlockedPersonListAnswer] [int] NULL,
	[UnverifiedListURL] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UnverifiedListAnswer] [int] NULL,
	[DeniedPersonsURL] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DeniedPersonsAnswer] [int] NULL,
	[DebarredListURL] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DebarredListAnswers] [int] NULL,
	[NonproliferationSanctionsURL] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NonproliferationSanctionsAnswers] [int] NULL,
	[AntiboycotComplianceURL] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AntiboycotComplianceAnswes] [int] NULL,
	[AID] [int] NULL,
	[TSNContact] [bit] NULL,
	[ASIContact] [bit] NULL,
	[EnterByID] [int] NULL,
	[EnterDate] [datetime] NULL,
	[EditByID] [int] NULL,
	[EditDate] [datetime] NULL,
	[CreditParentLink_AID] [int] NULL,
	[MasterParentLink_AID] [int] NULL,
	[CreditCheckFileName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MasterPurchaseFileName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreditCheckFileSize] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MasterPurchaseFileSize] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Contact_DueDiligance] PRIMARY KEY CLUSTERED 
(
	[DueDil_ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

----------------------------------------------------------

set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 06 February. 2012
-- Description:	Deletes a record in the DueDiligence 
-- =============================================

Create PROCEDURE [dbo].[DueDiligence_Delete]
(

	@DueDil_ID int   
)
AS


				DELETE FROM [dbo].Contact_DueDiligance WITH (ROWLOCK) 
				WHERE
					DueDil_ID = @DueDil_ID

--------------------------------------------------------

set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 06 February. 2012
-- Description:	Deletes a record in the DueDiligence 
-- =============================================
--exec DueDiligence_Update 4,1,0,'','',1,'www.bis.doc.gov/policiesandregulations/ear/744_supp4.pdf',1,'www.treasury.gov/resource-center/sanctions/SDN-List/Pages/default.aspx',1,'www.bis.doc.gov/enforcement/unverifiedlist/unverified_parties.html',1,'www.bis.doc.gov/dpl/default.shtm',1,'www.pmddtc.state.gov/compliance/debar.htm',1,'',1,'',1,0,0,1,26,'2/23/2012 7:51:09 PM'
--exec DueDiligence_Update '12','1','1','status1','Status20','0','http://www.bis.doc.gov/policiesandregulations/ear/744_supp4.pdf','1','http://www.treasury.gov/resource-center/sanctions/SDN-List/Pages/default.aspx','1','http://www.bis.doc.gov/enforcement/unverifiedlist/unverified_parties.html','1','http://www.bis.doc.gov/dpl/default.shtm','1','http://www.pmddtc.state.gov/compliance/debar.htm','1','','1','','1','0','0','1','26','3/5/2012 2:22:55 PM'
-- exec DueDiligence_Update '15','-1','-1','sent','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1'

CREATE PROCEDURE [dbo].[DueDiligence_Update]
(

	@DueDil_ID nvarchar(25) ,
    @StracturalSoftware nvarchar(25)   ,

	@ManunfactureCFS nvarchar(25)   ,

	@CreditCheckStatus nvarchar (150)  ,

	--@CreditCheckFile image   ,

	@MasterPurchaseStatus nvarchar (150)  ,

	--@MasterPurchaseFile image   ,

	@OutisdeUSA nvarchar(25)   ,

	@EntityListUrl nvarchar (150)  ,

	@EntityListAnswer nvarchar(25)   ,

	@BlockedPersonListURL nvarchar (150)   ,

	@BlockedPersonListAnswer nvarchar(25)  ,

	@UnverifiedListURL nvarchar (150)   ,

	@UnverifiedListAnswer nvarchar(25)   ,

	@DeniedPersonsURL nvarchar (150)   ,

	@DeniedPersonsAnswer nvarchar(25)   ,

	@DebarredListURL  nvarchar(150)   ,

	@DebarredListAnswers nvarchar(25)   ,

	@NonproliferationSanctionsURL nvarchar(150)   ,

	@NonproliferationSanctionsAnswers nvarchar(25)   ,

	@AntiboycotComplianceURL nvarchar (150)   ,

	@AntiboycotComplianceAnswes nvarchar(25)  ,

	@AID nvarchar(25),
    @TSNContact nvarchar(25)   ,
    @ASIContact nvarchar(25)   ,
    @EditByID nvarchar(25),
    @EditDate nvarchar(50) ,
    @CreditParentLink_AID nvarchar(25),
    @MasterParentLink_AID nvarchar(25)
)
AS
BEGIN


				-- Modify the updatable columns
SET NOCOUNT ON;
	Declare @UpdateQuery AS nvarchar(4000)
	SET @UpdateQuery = 'UPDATE Contact_DueDiligance	SET  '
    
	
IF(@StracturalSoftware <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' StracturalSoftware = ' + @StracturalSoftware + ','
IF(@ManunfactureCFS <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' ManunfactureCFS = ' + @ManunfactureCFS + ','
IF(@CreditCheckStatus <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' CreditCheckStatus = ' + CHAR(39) + @CreditCheckStatus + CHAR(39) + ','
					 
					--  ,[CreditCheckFile]=@CreditCheckFile
IF(@MasterPurchaseStatus <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' MasterPurchaseStatus = ' + CHAR(39) + @MasterPurchaseStatus + CHAR(39) + ','
					
					 
					--  ,[MasterPurchaseFile]=@MasterPurchaseFile
IF(@OutisdeUSA <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' OutisdeUSA = ' + CHAR(39) + @OutisdeUSA + CHAR(39) + ','
IF(@EntityListUrl <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' EntityListUrl = ' + CHAR(39) + @EntityListUrl + CHAR(39) + ','
					
					 
IF(@EntityListAnswer <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' EntityListAnswer = ' + @EntityListAnswer + ','
					 
IF(@BlockedPersonListURL <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' BlockedPersonListURL = ' + CHAR(39) + @BlockedPersonListURL + CHAR(39) + ','
					
					 
IF(@BlockedPersonListAnswer <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' BlockedPersonListAnswer = ' + @BlockedPersonListAnswer + ','
					 
IF(@UnverifiedListURL <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' UnverifiedListURL = ' + CHAR(39) + @UnverifiedListURL + CHAR(39) + ','
					
					 
IF(@UnverifiedListAnswer <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' UnverifiedListAnswer = ' + @UnverifiedListAnswer + ','
					  
IF(@DeniedPersonsURL <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' DeniedPersonsURL = ' + CHAR(39) + @DeniedPersonsURL + CHAR(39) + ','
		
IF(@DeniedPersonsAnswer <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' DeniedPersonsAnswer = ' + @DeniedPersonsAnswer + ','
					 
IF(@DebarredListURL <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' DebarredListURL = ' + CHAR(39) + @DebarredListURL + CHAR(39) + ','
					
					 
IF(@DebarredListAnswers <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' DebarredListAnswers = ' + @DebarredListAnswers + ','
					  
IF(@NonproliferationSanctionsURL <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' NonproliferationSanctionsURL = ' + CHAR(39) + @NonproliferationSanctionsURL + CHAR(39) + ','
					
					  
IF(@NonproliferationSanctionsAnswers <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' NonproliferationSanctionsAnswers = ' + @NonproliferationSanctionsAnswers + ','
------
					 
IF(@AntiboycotComplianceURL <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' AntiboycotComplianceURL = ' + CHAR(39) + @AntiboycotComplianceURL + CHAR(39) + ','
					
					  
IF(@AntiboycotComplianceAnswes<> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' AntiboycotComplianceAnswes = ' + @AntiboycotComplianceAnswes + ','
					  
IF(@AID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' AID = ' + @AID + ','
					  
IF(@TSNContact <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' TSNContact = ' + CHAR(39) + @TSNContact + CHAR(39) + ','
					
					 
IF(@ASIContact <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' ASIContact = ' + CHAR(39) + @ASIContact + CHAR(39) + ','
					
					
IF(@EditByID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' EditByID = ' + @EditByID + ','
					  
IF(@EditDate <> '-1')
		SET @UpdateQuery = @UpdateQuery + ' EditDate = ' + CHAR(39) + @EditDate + CHAR(39) + ','


IF(@CreditParentLink_AID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' CreditParentLink_AID = ' + @CreditParentLink_AID + ','
					  

IF(@MasterParentLink_AID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' MasterParentLink_AID = ' + @MasterParentLink_AID + ','
					  
					

--Removes the last occurenece of the character ','
	Declare @StringLength AS int
	SET @StringLength = len(@UpdateQuery)
--print @StringLength
	SET @UpdateQuery = SUBSTRING(@UpdateQuery,1,@StringLength-1)	

	SET @UpdateQuery = @UpdateQuery + ' WHERE  DueDil_ID = ' + @DueDil_ID 
print @UpdateQuery
	Execute(@UpdateQuery)
END
				

----------------------------------------------------------------------				
					
			
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Yasser Abd Rab El-Rasol 
-- Create date: 14 March. 2012
-- Description:	Upload a file in the DueDiligence 

CREATE PROCEDURE [dbo].[DueDiligence_Update_File]
(

	@DueDil_ID int ,
	@IsCredit bit,
	@CreditCheckStatus nvarchar (150)  ,
	@CreditCheckFile image  , 
	@FileName nvarchar(256),
	@FileSize nvarchar(20),
    @EditByID int,
    @EditDate datetime
)
AS
BEGIN

SET NOCOUNT ON;

		IF @IsCredit = 1
			BEGIN
				UPDATE
					[dbo].[Contact_DueDiligance]
				SET
					CreditCheckFileName = @FileName,
					CreditCheckFileSize = @FileSize,
					CreditCheckStatus = @CreditCheckStatus,
					CreditCheckFile = @CreditCheckFile,
					EditByID = @EditByID,
					EditDate = @EditDate
				WHERE
					DueDil_ID = @DueDil_ID 
			END
		ELSE
			BEGIN
				UPDATE
					[dbo].[Contact_DueDiligance]
				SET
					MasterPurchaseFileName = @FileName,
					MasterPurchaseFileSize = @FileSize,
					MasterPurchaseStatus = @CreditCheckStatus,
					MasterPurchaseFile = @CreditCheckFile,
					EditByID = @EditByID,
					EditDate = @EditDate
				WHERE
					DueDil_ID = @DueDil_ID 
			END
END

-------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 06 February. 2012
-- Description:	select All DueDiligence by AccountID
-- =============================================
 --exec DueDiligences_GetByAid 1313

CREATE PROCEDURE [dbo].[DueDiligences_GetByAid]

(

	@Aid int   
)
AS


				
				SELECT
					   DueDil_ID
					  ,[StracturalSoftware]
					  ,[ManunfactureCFS]
					  ,[CreditCheckStatus]
					  ,[CreditCheckFile]
					  ,[MasterPurchaseStatus]
					  ,[MasterPurchaseFile]
					  ,[OutisdeUSA]
					  ,[EntityListUrl]
					  ,[EntityListAnswer]
					  ,[BlockedPersonListURL]
					  ,[BlockedPersonListAnswer]
					  ,[UnverifiedListURL]
					  ,[UnverifiedListAnswer]
					  ,[DeniedPersonsURL]
					  ,[DeniedPersonsAnswer]
					  ,[DebarredListURL]
					  ,[DebarredListAnswers]
					  ,[NonproliferationSanctionsURL]
					  ,[NonproliferationSanctionsAnswers]
					  ,[AntiboycotComplianceURL]
					  ,[AntiboycotComplianceAnswes]
					  ,[AID]
					  ,[TSNContact]
					  ,[ASIContact]
					  ,[EnterByID]
					  ,[EnterDate]
					  ,[EditByID]
					  ,[EditDate]
					  ,CreditParentLink_AID
					  ,MasterParentLink_AID
				FROM
					[dbo].Contact_DueDiligance 
                WHERE
					[AID] = @Aid
				SELECT @@ROWCOUNT
			






-----------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 06 February. 2012
-- Description:	select All DueDiligence by DueDiliganceID
-- =============================================


CREATE PROCEDURE [dbo].[DueDiligences_GetByDueDil_ID]

(

	@DueDil_ID int   
)
AS


				
				SELECT
					   DueDil_ID
					  ,[StracturalSoftware]
					  ,[ManunfactureCFS]
					  ,[CreditCheckStatus]
					  ,[CreditCheckFile]
					  ,[MasterPurchaseStatus]
					  ,[MasterPurchaseFile]
					  ,[OutisdeUSA]
					  ,[EntityListUrl]
					  ,[EntityListAnswer]
					  ,[BlockedPersonListURL]
					  ,[BlockedPersonListAnswer]
					  ,[UnverifiedListURL]
					  ,[UnverifiedListAnswer]
					  ,[DeniedPersonsURL]
					  ,[DeniedPersonsAnswer]
					  ,[DebarredListURL]
					  ,[DebarredListAnswers]
					  ,[NonproliferationSanctionsURL]
					  ,[NonproliferationSanctionsAnswers]
					  ,[AntiboycotComplianceURL]
					  ,[AntiboycotComplianceAnswes]
					  ,[AID]
					  ,[TSNContact]
					  ,[ASIContact]
					  ,[EnterByID]
					  ,[EnterDate]
					  ,[EditByID]
					  ,[EditDate]
					  ,CreditParentLink_AID
					  ,MasterParentLink_AID
				FROM
					[dbo].Contact_DueDiligance 
                WHERE
					[DueDil_ID] = @DueDil_ID
				SELECT @@ROWCOUNT
			


------------------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 06 February. 2012
-- Description:	insert record into the DueDiligence table
-- =============================================

CREATE PROCEDURE [dbo].[DueDiligences_Insert]
(

	--@DueDil_ID int    OUTPUT,
	
	@StracturalSoftware int   ,

	@ManunfactureCFS int   ,

	@CreditCheckStatus nvarchar (250)  ,

	@CreditCheckFile image   ,

	@MasterPurchaseStatus nvarchar (250)  ,

	@MasterPurchaseFile image   ,

	@OutisdeUSA bit   ,

	@EntityListUrl nvarchar (250)  ,

	@EntityListAnswer int   ,

	@BlockedPersonListURL nvarchar (250)   ,

	@BlockedPersonListAnswer int  ,

	@UnverifiedListURL nvarchar (250)   ,

	@UnverifiedListAnswer int   ,

	@DeniedPersonsURL nvarchar (250)   ,

	@DeniedPersonsAnswer int   ,

	@DebarredListURL  nvarchar(250)   ,

	@DebarredListAnswers int   ,

	@NonproliferationSanctionsURL nvarchar(250)   ,

	@NonproliferationSanctionsAnswers int   ,

	@AntiboycotComplianceURL nvarchar (250)   ,

	@AntiboycotComplianceAnswes int  ,

	@AID int,
    @TSNContact bit   ,
    @ASIContact bit   ,
    @EnterByID int,
    @EnterDate datetime,
    @EditByID int,
    @EditDate datetime,
    @CreditParentLink_AID int,
    @MasterParentLink_AID int

)
AS


				
				INSERT INTO [dbo].Contact_DueDiligance
					(
					  [StracturalSoftware]
					  ,[ManunfactureCFS]
					  ,[CreditCheckStatus]
					  ,[CreditCheckFile]
					  ,[MasterPurchaseStatus]
					  ,[MasterPurchaseFile]
					  ,[OutisdeUSA]
					  ,[EntityListUrl]
					  ,[EntityListAnswer]
					  ,[BlockedPersonListURL]
					  ,[BlockedPersonListAnswer]
					  ,[UnverifiedListURL]
					  ,[UnverifiedListAnswer]
					  ,[DeniedPersonsURL]
					  ,[DeniedPersonsAnswer]
					  ,[DebarredListURL]
					  ,[DebarredListAnswers]
					  ,[NonproliferationSanctionsURL]
					  ,[NonproliferationSanctionsAnswers]
					  ,[AntiboycotComplianceURL]
					  ,[AntiboycotComplianceAnswes]
					  ,[AID]
					  ,[TSNContact]
					  ,[ASIContact]
					  ,[EnterByID]
					  ,[EnterDate]
					  ,[EditByID]
					  ,[EditDate]
					  ,CreditParentLink_AID
					  ,MasterParentLink_AID
					)
				VALUES
					(
					
					  @StracturalSoftware
					  ,@ManunfactureCFS
					  ,@CreditCheckStatus
					  ,@CreditCheckFile
					  ,@MasterPurchaseStatus
					  ,@MasterPurchaseFile
					  ,@OutisdeUSA
					  ,@EntityListUrl
					  ,@EntityListAnswer
					  ,@BlockedPersonListURL
					  ,@BlockedPersonListAnswer
					  ,@UnverifiedListURL
					  ,@UnverifiedListAnswer
					  ,@DeniedPersonsURL
					  ,@DeniedPersonsAnswer
					  ,@DebarredListURL 
					  ,@DebarredListAnswers 
					  ,@NonproliferationSanctionsURL 
					  ,@NonproliferationSanctionsAnswers 
					  ,@AntiboycotComplianceURL 
					  ,@AntiboycotComplianceAnswes 
					  ,@AID 
					  ,@TSNContact 
					  ,@ASIContact 
					  ,@EnterByID 
					  ,@EnterDate 
					  ,@EditByID 
					  ,@EditDate 
					  ,@CreditParentLink_AID
					  ,@MasterParentLink_AID
					)
				
				-- Get the identity value
				SELECT SCOPE_IDENTITY()
									
							
----------------------------------------------------------------
set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 06 February. 2012
-- Description:	select All DueDiligence
-- =============================================


CREATE PROCEDURE [dbo].[DueDiligencesGetData]

(

	@DueDil_ID int,
	@StracturalSoftware int,
	@ManunfactureCFS int,
	@CreditCheckStatus nvarchar(250),
	@MasterPurchaseStatus nvarchar(250),
	@OutisdeUSA nvarchar(10) ,
	@AID int,
	@TSNContact nvarchar(10),
	@ASIContact  nvarchar(10)


   
)
AS
BEGIN
      SET NOCOUNT ON;
            Declare @Filter AS nvarchar(1000)
            Declare @Query AS nvarchar(2000)
            Declare @FullQuery AS nvarchar(3000)
            SET @Filter = ''
            SET @Query = 
            '		SELECT
					   DueDil_ID
					  ,[StracturalSoftware]
					  ,[ManunfactureCFS]
					  ,[CreditCheckStatus]
					  ,[CreditCheckFile]
					  ,[MasterPurchaseStatus]
					  ,[MasterPurchaseFile]
					  ,[OutisdeUSA]
					  ,[EntityListUrl]
					  ,[EntityListAnswer]
					  ,[BlockedPersonListURL]
					  ,[BlockedPersonListAnswer]
					  ,[UnverifiedListURL]
					  ,[UnverifiedListAnswer]
					  ,[DeniedPersonsURL]
					  ,[DeniedPersonsAnswer]
					  ,[DebarredListURL]
					  ,[DebarredListAnswers]
					  ,[NonproliferationSanctionsURL]
					  ,[NonproliferationSanctionsAnswers]
					  ,[AntiboycotComplianceURL]
					  ,[AntiboycotComplianceAnswes]
					  ,[AID]
					  ,[TSNContact]
					  ,[ASIContact]
					  ,[EnterByID]
					  ,[EnterDate]
					  ,[EditByID]
					  ,[EditDate]
					  ,CreditParentLink_AID
					  ,MasterParentLink_AID  
				FROM
					[dbo].Contact_DueDiligance WHERE     (1 = 1) '

               
					
				IF @DueDil_ID <> -1
                  SET @Filter = @Filter + ' AND DueDil_ID = ' + CONVERT(nvarchar(25),@DueDil_ID)
            
            IF @StracturalSoftware <> -1
                  SET @Filter = @Filter + ' AND StracturalSoftware = ' + CONVERT(nvarchar(25), @StracturalSoftware)
 
            IF @ManunfactureCFS <> '-1'
                  SET @Filter = @Filter + ' AND ManunfactureCFS = ' + CONVERT(nvarchar(25), @ManunfactureCFS)
			

			IF @CreditCheckStatus <> '-1'
                  SET @Filter = @Filter + ' AND CreditCheckStatus LIKE  ' + CHAR(39)  + @CreditCheckStatus + '%' + CHAR(39)

			IF @MasterPurchaseStatus <> '-1'
                  SET @Filter = @Filter + ' AND MasterPurchaseStatus LIKE  ' + CHAR(39)  + @MasterPurchaseStatus + '%' + CHAR(39)

            IF @OutisdeUSA <> '-1'
           
                  SET @Filter = @Filter + ' AND OutisdeUSA = ' + CONVERT(nvarchar(25), @OutisdeUSA)
			
			IF @TSNContact <> '-1'
           
                  SET @Filter = @Filter + ' AND TSNContact = ' + CONVERT(nvarchar(25), @TSNContact)
			
			IF @ASIContact <> '-1'
           
                  SET @Filter = @Filter + ' AND ASIContact = ' + CONVERT(nvarchar(25), @ASIContact)
			IF @AID <> '-1'
           
                  SET @Filter = @Filter + ' AND AID = ' + CONVERT(nvarchar(25), @AID)
			
            
           
--            IF @SortExp <> '-1'
--                  SET @Filter = @Filter + ' ORDER BY ' +  @SortExp 
  
            SET @FullQuery = @Query + @Filter
            Execute(@FullQuery)
END
			






			

















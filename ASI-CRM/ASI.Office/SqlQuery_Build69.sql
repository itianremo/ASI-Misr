set ANSI_NULLS OFF
set QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Sayed 28-3-2012
-- Purpose: Get  record from the Email Template table
----------------------------------------------------------------------------------------------------
*/
--exec EmailTemplate_GetByDefaultTemplate


CREATE PROCEDURE [dbo].[EmailTemplate_GetByDefaultTemplate]

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
					DefaultTemplate =1;
				SELECT @@ROWCOUNT
					
			





GO
UPDATE
	[dbo].EmailTemplates
SET
	DefaultTemplate = 0
GO

Declare @TemplateID AS int
Select @TemplateID = MIN(TemplateID)
FROM EmailTemplates

UPDATE
	[dbo].EmailTemplates
SET
	DefaultTemplate = 1
WHERE TemplateID = @TemplateID

GO
USE [ASI-CRM]
GO
/****** Object:  StoredProcedure [dbo].[EmailTemplate_Update]    Script Date: 03/29/2012 18:08:35 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: Sayed 16-6-2011
-- Altered By: Yasser 29-3-2012
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


				IF @DefaultTemplate = 1
				BEGIN
					UPDATE
						[dbo].EmailTemplates
					SET
						DefaultTemplate = 0
				END
				
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
				
			
USE [ASI-CRM]
GO
/****** Object:  StoredProcedure [dbo].[EmailTemplate_Insert]    Script Date: 03/29/2012 18:08:27 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Alsayed Moawad 
-- Create date: 16 June. 2011
-- Altered By: Yasser 29-3-2012
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

				IF @DefaultTemplate = 1
				BEGIN
					UPDATE
						[dbo].EmailTemplates
					SET
						DefaultTemplate = 0
				END
				
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
									

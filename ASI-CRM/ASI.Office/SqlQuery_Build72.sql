USE [ASI-CRM]
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_Contact_ContactsInfo]    Script Date: 06/20/2012 15:16:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:        Yasser Abd Rab El-Rasol
-- Alter date:    20 June. 2012
-- Description:   Delete existing one record in 'Contact_ContactsInfo' table
-- =============================================
ALTER PROCEDURE [dbo].[SP_DELETE_Contact_ContactsInfo] 
(
      @ContactID int,
      @Result int output      
)
AS
BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET NOCOUNT ON;

    -- Insert statements for procedure here
      Declare @NoteCount AS int;

      SELECT @NoteCount = COUNT(NID) FROM Contact_Notes
            WHERE ContactID = @ContactID;
    
      IF @NoteCount = 0
      BEGIN
            DELETE FROM Contact_ContactMiscellaneous
                  WHERE ContactID = @ContactID
			DELETE FROM Contact_Connection
                  WHERE ContactID = @ContactID
            DELETE FROM Contact_ContactsInfo
                  WHERE ContactID = @ContactID
            SET @Result = @@Rowcount
      END
      ELSE
            SET @Result = -1
END


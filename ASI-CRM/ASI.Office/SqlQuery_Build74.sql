USE [ASI-CRM]
GO
/****** Object:  StoredProcedure [dbo].[History_GetByContactID]    Script Date: 08/29/2012 18:57:18 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Alter date:  29 Agust. 2012
-- Description:	Get History related to Account
-- =============================================
-- exec History_GetByContactID 1313


ALTER PROCEDURE [dbo].[History_GetByContactID]
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
                             WHERE     (Contact_Notes_1.ContactID = @ContactID)))
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
			




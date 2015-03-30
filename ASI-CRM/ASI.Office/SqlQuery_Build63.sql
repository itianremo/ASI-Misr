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
                             WHERE     (Contact_Notes_1.AccountID = @AccountId)))
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
			



----------------------------------------------------------

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ehab Hosny
-- Create date: 01 June. 2008
-- Modifed By Sayed Moawad 22/9/2011
-- Description:	Insert new record into Contact_Branchs Table
-- =============================================
ALTER PROCEDURE [dbo].[SP_INSERT_INTO_Contact_Branchs]
	(
		 @BrnachName	nvarchar(255)
		,@TypeID		int
		,@BusSector		int
		,@Fax			nvarchar(25)
		,@Phone			nvarchar(25)
		,@WebSite		nvarchar(255)
		,@IDStatus		int
		,@Street1		nvarchar(255)
		,@City			nvarchar(255)
		,@ZipCode		nvarchar(25)
		,@CountryID		int
		,@ReferedBy		nvarchar(225)
		,@EnterByID		int
		,@EnterDate		datetime
		,@EditByID		int
		,@EditDate		datetime
		,@Street2		nvarchar(255)
		,@BranchManagerID			int
		,@BranchManagerEditDate		datetime
		,@BranchManagerEditByID		int
		,@BranchManagerAssignedDate	datetime
		,@State			nvarchar(100)
		,@AccountID		int
		,@MainOffice	bit
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO Contact_Branches
				(BrnachName,TypeID,BusSector,Fax,Phone,WebSite,IDStatus,Street1,City
				,ZipCode,CountryID,ReferedBy,EnterByID,EnterDate,EditByID,EditDate
				,Street2,BranchManagerID,BranchManagerEditDate,BranchManagerEditByID
				,BranchManagerAssignedDate,State,AccountID,MainOffice)
	VALUES		(@BrnachName,@TypeID,@BusSector,@Fax,@Phone,@WebSite,@IDStatus,@Street1
				,@City,@ZipCode,@CountryID,@ReferedBy,@EnterByID,@EnterDate,@EditByID
				,@EditDate,@Street2,@BranchManagerID,@BranchManagerEditDate,@BranchManagerEditByID
				,@BranchManagerAssignedDate,@State,@AccountID,@MainOffice)

 SELECT SCOPE_IDENTITY()

END




--------------------------------------------------------------------------

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 22 Sept. 2011
-- Description:	Update all records in 'Contact_Notes' table that belong to certain Contact.
-- =============================================
Create PROCEDURE [dbo].[SP_UPDATE_All_Contact_Notes]
	-- Add the parameters for the stored procedure here
	(
		 @ContactID nvarchar(25)
		,@AccountID nvarchar(25)
		,@BranchID nvarchar(25)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @UpdateQuery AS nvarchar(4000)
	SET @UpdateQuery = 'UPDATE Contact_Notes	SET  '

    -- Insert statements for procedure here
	IF(@AccountID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' AccountID = ' + @AccountID + ','
	IF(@BranchID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' BranchID = ' + @BranchID + ','

	Declare @StringLength AS int
	SET @StringLength = len(@UpdateQuery)
	SET @UpdateQuery = SUBSTRING(@UpdateQuery,1,@StringLength-1)	

	SET @UpdateQuery = @UpdateQuery + ' WHERE  ContactID = ' + @ContactID 
	Execute(@UpdateQuery)
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 22 Sept. 2011
-- Description:	Update all records in 'Contact_Notes' table that belong to certain Branch.
-- =============================================
Create PROCEDURE [dbo].[SP_UPDATE_All_Branch_Notes]
	-- Add the parameters for the stored procedure here
	(
		 @BranchID nvarchar(25)
		,@AccountID nvarchar(25)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @UpdateQuery AS nvarchar(4000)
	SET @UpdateQuery = 'UPDATE Contact_Notes	SET  '

    -- Insert statements for procedure here
	IF(@AccountID <> '-1')
		SET @UpdateQuery = @UpdateQuery +  ' AccountID = ' + @AccountID + ','

	Declare @StringLength AS int
	SET @StringLength = len(@UpdateQuery)
	SET @UpdateQuery = SUBSTRING(@UpdateQuery,1,@StringLength-1)	

	SET @UpdateQuery = @UpdateQuery + ' WHERE  BranchID = ' + @BranchID 
	Execute(@UpdateQuery)
END









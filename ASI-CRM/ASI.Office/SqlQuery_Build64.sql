

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 9 Oct. 2011
-- Description:	Check if Miscellaneous exists
-- =============================================
Create PROCEDURE [dbo].[SP_Check_Miscellaneous_Existance]
	(
		 @ContactID int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT	Contact_ContactMiscellaneous.MID
	FROM	Contact_ContactMiscellaneous 
	WHERE	Contact_ContactMiscellaneous.ContactID = @ContactID
END



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- ALTER date:  10 Oct. 2011
-- Description:	Delete existing one record in 'Contact_Branches' table
-- =============================================
ALTER PROCEDURE [dbo].[SP_DELETE_Contact_Branches]
(
	@BranchID int,
	@Result int output 	
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Declare @NoteCount AS int;

	SELECT @NoteCount = COUNT(NID) FROM Contact_Notes
		WHERE BranchID = @BranchID;

	Declare @ContactCount AS int;

	SELECT @ContactCount = COUNT(ContactID) FROM Contact_ContactsInfo
		WHERE BranchID = @BranchID;

	IF ((@NoteCount = 0) and (@ContactCount = 0))
	BEGIN
		DELETE FROM Contact_Branches
			WHERE BranchID = @BranchID
		SELECT @Result = @@Rowcount
	END
	ELSE
		SELECT @Result = -1
END



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Alter date:  19 Oct. 2011
-- Description:	Get account or contact page
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Account_Or_Contact_Page]
(
	@ID int,
	@IsAccount bit,
	@PageRows int,
	@PageNo int output
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
		SELECT @RowsBeforeID = COUNT(AID)
		FROM Contact_Account
		WHERE AName <= (SELECT AName
						FROM Contact_Account
						WHERE AID = @ID)

		SELECT @PageNo = (@RowsBeforeID / @PageRows)
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
--			SELECT @RowsBeforeID = COUNT(ContactID)
--			FROM Contact_ContactsInfo
--			WHERE AccountID is NULL AND (Email <> '') AND Email <= (SELECT Email
--												FROM Contact_ContactsInfo
--												WHERE ContactID = @ID)
--		END
--		ELSE
--		BEGIN
--			print 'NOT NULL'
--
--			SELECT @RowsBeforeID = COUNT(ContactID)
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
--
--			print @RowsBeforeID
--		END
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
				Tag, AName, EnteredByName, EditByName, Address, City, State, CountryID, Url, 
				IDStatusName, CountryName, TitleName, DepartmentName, Probability, LastContactNoteDate,
				RowNumber, PageNo)
		SELECT  ContactID, Intial, FirstName, MiddleIntial, LastName, TitleID, DepartmentID, Phone, 
				Ext, CellPhone, Fax, Email, AccountID, EnteredbyID, EnterDate, EditByID, EditeDate, 
				Tag, AName, EnteredByName, EditByName, Address, City, State, CountryID, Url, 
				IDStatusName, CountryName, TitleName, DepartmentName, Probability, LastContactNoteDate
				, RowNumber, ((RowNumber -1)/@PageRows) as PageNo
				FROM (SELECT  Contact_ContactsInfo.ContactID, Contact_ContactsInfo.Intial, 
				Contact_ContactsInfo.FirstName, Contact_ContactsInfo.MiddleIntial, Contact_ContactsInfo.LastName, 
				Contact_ContactsInfo.TitleID, Contact_ContactsInfo.DepartmentID, Contact_ContactsInfo.Phone, 
				Contact_ContactsInfo.Ext, Contact_ContactsInfo.CellPhone, Contact_ContactsInfo.Fax, 
				Contact_ContactsInfo.Email, Contact_ContactsInfo.AccountID, Contact_ContactsInfo.EnteredbyID, 
				Contact_ContactsInfo.EnterDate, Contact_ContactsInfo.EditByID, Contact_ContactsInfo.EditeDate, 
				Contact_ContactsInfo.Tag, Contact_Account.AName, Sec_UserLogin.UserName AS EnteredByName, 
				Sec_UserLogin_1.UserName AS EditByName, Contact_ContactsInfo.Address, Contact_ContactsInfo.City, 
				Contact_ContactsInfo.State, Contact_ContactsInfo.CountryID, Contact_ContactsInfo.Url, 
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
			
		SELECT 	@PageNo = PageNo
		FROM #InnerT
		WHERE  ContactID = @ID

		drop table #InnerT
	END

--	IF @RowsBeforeID <= @PageRows
--		SELECT @PageNo = 0
--	ELSE
--		SELECT @PageNo = (@RowsBeforeID / @PageRows)
	
		
	
print @RowsBeforeID

print @PageNo
END



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		Yasser
-- Alter date:  19 Oct. 2011
-- Description:	Get all contact notes related to a specified account
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Account_Contacts_Notes]
(
	@AccountID int
	,@Filter nvarchar(2000)
	,@SortExp nvarchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	Declare @Query AS nvarchar(2500)

	SET @Query =
	'SELECT     Contact_Notes.NID, Contact_Notes.NoteDate, Contact_Notes.UserEnterDate, 
				Contact_Notes.NoteTime,Contact_Notes.Notes, Contact_Notes.EnterdByID, 
				Contact_Notes.EditByID, Contact_Notes.EditDate, Contact_Notes.ContactID, 
				Contact_Notes.AccountID, Sec_UserLogin_1.UserName AS EnteredByName, 
				Sec_UserLogin.UserName AS EditByName, Contact_Account.AName AS AccountName, 
				Contact_ContactsInfo.FirstName AS ContactFirstName, 
				Contact_ContactsInfo.LastName AS ContactLastName,
				Contact_Notes.BranchID,
				Contact_Branches.BrnachName AS BranchName
	FROM        Sec_UserLogin INNER JOIN
				Contact_Notes INNER JOIN
				Sec_UserLogin AS Sec_UserLogin_1 ON Contact_Notes.EnterdByID = Sec_UserLogin_1.UID ON 
				Sec_UserLogin.UID = Contact_Notes.EditByID LEFT OUTER JOIN Contact_Account ON 
				Contact_Notes.AccountID = Contact_Account.AID LEFT OUTER JOIN Contact_ContactsInfo ON 
				Contact_Notes.ContactID = Contact_ContactsInfo.ContactID LEFT OUTER JOIN Contact_Branches ON 
				Contact_Notes.BranchID = Contact_Branches.BranchID
	WHERE     ((Contact_ContactsInfo.AccountID = ' + CONVERT(nvarchar(25),@AccountID) + ') OR (Contact_Notes.AccountID = '
	+ CONVERT(nvarchar(25),@AccountID) + '))'

	IF @SortExp <> '-1'
			SET @Filter = @Filter + ' ORDER BY ' +  @SortExp 
	SET @Query = @Query + @Filter
	Execute(@Query)
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- =============================================
-- Author:		Ehab Hosny
-- Alter date:  19 Oct. 2011
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
		Contact_ContactsInfo.LastName AS ContactLastName,
		Contact_Notes.BranchID,
		Contact_Branches.BrnachName AS BranchName
	FROM    Sec_UserLogin INNER JOIN
		Contact_Notes INNER JOIN
		Sec_UserLogin AS Sec_UserLogin_1 ON Contact_Notes.EnterdByID = Sec_UserLogin_1.UID ON 
		Sec_UserLogin.UID = Contact_Notes.EditByID LEFT OUTER JOIN Contact_Account ON 
		Contact_Notes.AccountID = Contact_Account.AID LEFT OUTER JOIN Contact_Branches ON 
		Contact_Notes.BranchID = Contact_Branches.BranchID LEFT OUTER JOIN Contact_ContactsInfo ON 
		Contact_Notes.ContactID = Contact_ContactsInfo.ContactID LEFT OUTER JOIN Contact_Branches ON 
		Contact_Notes.BranchID = Contact_Branches.BranchID
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
-- Author:		Ehab Hosny
-- Alter date:  20 Oct. 2011
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
		Contact_ContactsInfo.LastName AS ContactLastName,
		Contact_Notes.BranchID
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





UPDATE [Contact_Notes]
   SET [AccountID] = (SELECT [AccountID]
						FROM [Contact_Branches] AS cb2
						WHERE cb2.[BranchID] = [Contact_Notes].[BranchID])
 WHERE (SELECT [AccountID]
		FROM [Contact_Branches] AS cb
		WHERE cb.[BranchID] = [Contact_Notes].[BranchID]) IS NOT NULL
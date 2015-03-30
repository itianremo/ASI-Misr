set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:        Ehab Hosny
-- ALTER  date:   27 March. 2008
-- Description:   Get accounts names or Business Sector names for incremental search purpose
-- Modification:  the sp modified to add new filters in auto complete search "email,website,company no,phone and fax" 
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_All_Accounts_Names]
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
      IF @SearchCriteria = 'AName'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE AName' + ' LIKE ' + CHAR(39) 
                  + @Pref + '%' + CHAR(39)
      ----------- added by Sayed Moawad 18-12-2011 to add phone in auto search
      ELSE IF @SearchCriteria = 'Telephone'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE Phone' + ' LIKE ' + CHAR(39) 
                  + @Pref + '%' + CHAR(39)
 ----------- added by Sayed Moawad 18-12-2011 to add phone in auto search
      ELSE IF @SearchCriteria = 'AID'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE AID=' 
                  + @Pref 
 ----------- added by Sayed Moawad 18-12-2011 to add Fax in auto search
      ELSE IF @SearchCriteria = 'Fax'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE Fax' + ' LIKE ' + CHAR(39) 
                  + @Pref + '%' + CHAR(39)
----------- added by Sayed Moawad 18-12-2011 to add website in auto search
      ELSE IF @SearchCriteria = 'Website'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE WebSite' + ' LIKE ' + CHAR(39) 
                  + @Pref + '%' + CHAR(39)
----------- added by Sayed Moawad 18-12-2011 to add Email in auto search
      ELSE IF @SearchCriteria = 'Email'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE Email' + ' LIKE ' + CHAR(39) 
                  + @Pref + '%' + CHAR(39)

	ELSE 
            SET @Query = 'SELECT DISTINCT TOP 20   Main_SubCode_2.SCode AS BusinessSectorName
			  FROM	  Contact_Account LEFT OUTER JOIN
				  Main_SubCode AS Main_SubCode_2 ON 
				  Contact_Account.BusSector = Main_SubCode_2.SID
				LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID 
			  WHERE	  Main_SubCode_2.SCode  LIKE '  + CHAR(39) + @Pref + '%' + CHAR(39)

      IF @Country <> '-1'
		SET @Query = @Query + ' AND Main_SubCode_1.SCode = ' +  CHAR(39) + @Country +  CHAR(39)
      IF @State <> '-1'
		SET @Query = @Query + ' AND Contact_Account.State = ' +  CHAR(39) + @State +  CHAR(39)
	  IF @BusSect <> '-1'
		SET @Query = @Query + ' AND Main_SubCode_2.SCode LIKE ' + CHAR(39) + @BusSect + CHAR(39)
	  IF @Tag = 'Tagged'
        SET @Query = @Query + ' AND Contact_Account.Tag = ' + CHAR(39) + 'true' + CHAR(39)
	  IF @Tag = 'Un-Tagged'
        SET @Query = @Query + ' AND Contact_Account.Tag = ' + CHAR(39) + 'false' + CHAR(39)
	  IF @Notes = '1'
          SET @Query = @Query + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is Not NULL' 
	  IF @Notes = '2'
          SET @Query = @Query + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is NULL' 

	  SET @Query = @Query + ' ORDER BY ' +  @SearchCriteria
      -------Execute Created Query	
      Execute(@Query)
		print @Query
END






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
            ,@Email nvarchar(255)
            ,@Website nvarchar(255)
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

----------- added by Yasser 19-12-2011 to add Email & WebSite
			IF @Email <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Account.Email LIKE  ' + CHAR(39)  + @Email + '%' + CHAR(39)

			IF @Website <> '-1'
                  SET @Filter = @Filter + ' AND Contact_Account.WebSite LIKE  ' + CHAR(39)  + @Website + '%' + CHAR(39)

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
-- Author:        Ehab Hosny
-- ALTER  date:   27 March. 2008
-- Description:   Get accounts names or Business Sector names for incremental search purpose
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_All_Accounts_Names]
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
      IF @SearchCriteria = 'AName'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE AName' + ' LIKE ' + CHAR(39) 
                  + @Pref + '%' + CHAR(39)
      ----------- added by Sayed Moawad 18-12-2011 to add phone in auto search
      ELSE IF @SearchCriteria = 'Telephone'
		BEGIN
			SELECT @SearchCriteria = 'Phone'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + ' as Telephone ' +
                  + ' FROM Contact_Account 
			LEFT OUTER JOIN
				Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
			LEFT OUTER JOIN
				  Main_SubCode AS Main_SubCode_2 ON 
				  Contact_Account.BusSector = Main_SubCode_2.SID' 
					  + ' WHERE Phone' + ' LIKE ' + CHAR(39) 
					  + @Pref + '%' + CHAR(39)
		END
 ----------- added by Sayed Moawad 18-12-2011 to add phone in auto search
      ELSE IF @SearchCriteria = 'AID'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE AID=' 
                  + @Pref 
 ----------- added by Sayed Moawad 18-12-2011 to add Fax in auto search
      ELSE IF @SearchCriteria = 'Fax'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE Fax' + ' LIKE ' + CHAR(39) 
                  + @Pref + '%' + CHAR(39)
----------- added by Sayed Moawad 18-12-2011 to add website in auto search
      ELSE IF @SearchCriteria = 'Website'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE WebSite' + ' LIKE ' + CHAR(39) 
                  + @Pref + '%' + CHAR(39)
----------- added by Sayed Moawad 18-12-2011 to add Email in auto search
      ELSE IF @SearchCriteria = 'Email'
            SET @Query = 'SELECT  DISTINCT TOP 20   ' + @SearchCriteria + 
                  + ' FROM Contact_Account 
		LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
		LEFT OUTER JOIN
			  Main_SubCode AS Main_SubCode_2 ON 
			  Contact_Account.BusSector = Main_SubCode_2.SID' 
                  + ' WHERE Email' + ' LIKE ' + CHAR(39) 
                  + @Pref + '%' + CHAR(39)

	ELSE 
            SET @Query = 'SELECT DISTINCT TOP 20   Main_SubCode_2.SCode AS BusinessSectorName
			  FROM	  Contact_Account LEFT OUTER JOIN
				  Main_SubCode AS Main_SubCode_2 ON 
				  Contact_Account.BusSector = Main_SubCode_2.SID
				LEFT OUTER JOIN
			Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID 
			  WHERE	  Main_SubCode_2.SCode  LIKE '  + CHAR(39) + @Pref + '%' + CHAR(39)

      IF @Country <> '-1'
		SET @Query = @Query + ' AND Main_SubCode_1.SCode = ' +  CHAR(39) + @Country +  CHAR(39)
      IF @State <> '-1'
		SET @Query = @Query + ' AND Contact_Account.State = ' +  CHAR(39) + @State +  CHAR(39)
	  IF @BusSect <> '-1'
		SET @Query = @Query + ' AND Main_SubCode_2.SCode LIKE ' + CHAR(39) + @BusSect + CHAR(39)
	  IF @Tag = 'Tagged'
        SET @Query = @Query + ' AND Contact_Account.Tag = ' + CHAR(39) + 'true' + CHAR(39)
	  IF @Tag = 'Un-Tagged'
        SET @Query = @Query + ' AND Contact_Account.Tag = ' + CHAR(39) + 'false' + CHAR(39)
	  IF @Notes = '1'
          SET @Query = @Query + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is Not NULL' 
	  IF @Notes = '2'
          SET @Query = @Query + ' AND (Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is NULL' 

	  SET @Query = @Query + ' ORDER BY ' +  @SearchCriteria
      -------Execute Created Query	
      Execute(@Query)
		print @Query
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 7 Mar. 2011
-- Description:	Get account or contact item page
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Account_Or_Contact_Item_Page]
(
	@ID int,
	@Country nvarchar(100),
	@State nvarchar(100),
	@BusSect nvarchar(100),
	@Tag nvarchar(100),
	@Notes nvarchar(100),
	@SearchCriteria nvarchar(100),
	@Pref nvarchar(100),
	@IsAccount bit,
	@Order int output
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Declare @RowsBeforeID AS int;

	IF @IsAccount = 1
	BEGIN
		--Search for account page no.
		IF @SearchCriteria = 'AName'
		BEGIN
			SELECT Contact_Account.AName
			FROM Contact_Account
				 LEFT OUTER JOIN Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
				 LEFT OUTER JOIN Main_SubCode AS Main_SubCode_2 ON Contact_Account.BusSector = Main_SubCode_2.SID
			WHERE (AName <= (SELECT AName
							FROM Contact_Account
							WHERE AID = @ID) OR @ID = -1)
			AND Contact_Account.AName LIKE @Pref + '%'
			AND (Main_SubCode_1.SCode = @Country OR @Country = '-1')
			AND (Contact_Account.State = @State OR @State = '-1')
			AND (Main_SubCode_2.SCode LIKE @BusSect OR @BusSect = '-1')
			AND (Contact_Account.Tag = 1 OR @Tag = '-1')
			AND (((Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is Not NULL AND @Notes = '1') OR (@Notes <> '1' AND @Notes <> '2'))
			AND (((Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is NULL OR @Notes = '2') OR (@Notes <> '1' AND @Notes <> '2'))
			ORDER BY Contact_Account.AName
		END
		ELSE
		BEGIN
			SELECT Contact_Account.BusSector
			FROM Contact_Account
				 LEFT OUTER JOIN Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
				 LEFT OUTER JOIN Main_SubCode AS Main_SubCode_2 ON Contact_Account.BusSector = Main_SubCode_2.SID
			WHERE (AName <= (SELECT AName
							FROM Contact_Account
							WHERE AID = @ID) OR @ID = -1)
			AND Contact_Account.BusSector LIKE @Pref + '%'
			AND (Main_SubCode_1.SCode = @Country OR @Country = '-1')
			AND (Contact_Account.State = @State OR @State = '-1')
			AND (Main_SubCode_2.SCode LIKE @BusSect OR @BusSect = '-1')
			AND (Contact_Account.Tag = 1 OR @Tag = '-1')
			AND (((Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is Not NULL AND @Notes = '1') OR (@Notes <> '1' AND @Notes <> '2'))
			AND (((Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is NULL OR @Notes = '2') OR (@Notes <> '1' AND @Notes <> '2'))
			ORDER BY Contact_Account.BusSector
		END
		
		SELECT @RowsBeforeID = @@Rowcount - 1
	END
	ELSE
	BEGIN
		--Search for contact page no.
		SELECT @RowsBeforeID = AccountID
		FROM Contact_ContactsInfo
		WHERE ContactID = @ID		

		print @RowsBeforeID

		IF @RowsBeforeID is NULL
		BEGIN	
			print 'NULL'
			SELECT @RowsBeforeID = COUNT(ContactID)
			FROM Contact_ContactsInfo
			WHERE AccountID is NULL AND (Email <> '') AND Email <= (SELECT Email
												FROM Contact_ContactsInfo
												WHERE ContactID = @ID)
		END
		ELSE
		BEGIN
			print 'NOT NULL'

			SELECT @RowsBeforeID = COUNT(ContactID) + 1
			FROM Contact_ContactsInfo LEFT OUTER JOIN
			Contact_Account ON (AccountID = AID OR AccountID = NULL)
			WHERE AName <= (SELECT AName
							FROM Contact_ContactsInfo LEFT OUTER JOIN
							Contact_Account ON (AccountID = AID OR AccountID is NULL)
							WHERE ContactID = @ID)

			print @RowsBeforeID

			Declare @Temp AS int;

			SELECT @Temp = COUNT(ContactID)
			FROM Contact_ContactsInfo
			WHERE AccountID is NULL		

			print @Temp

			SET @RowsBeforeID = @RowsBeforeID + @Temp

			print @RowsBeforeID
		END
	END

	SELECT @Order = @RowsBeforeID

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 25 June. 2009
-- Description:	Get account or contact order
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Account_Or_Contact_Order] 
(
	@ID int,
	@IsAccount bit,
	@SearchCriteria nvarchar(100),
	@Pref nvarchar(100),
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
					Main_SubCode AS Main_SubCode_3 ON Contact_ContactMiscellaneous.IDStatus = Main_SubCode_3.SID
					WHERE ((Contact_Account.AName LIKE @Pref + '%') OR (@SearchCriteria <> 'AName'))
					OR    ((Contact_ContactsInfo.FirstName LIKE @Pref + '%') OR (@SearchCriteria <> 'FirstName'))
					OR    ((Contact_ContactsInfo.LastName LIKE @Pref + '%') OR (@SearchCriteria <> 'LastName'))
					OR    ((Contact_ContactsInfo.Phone LIKE @Pref + '%') OR (@SearchCriteria <> 'Phone'))
					OR    ((Contact_ContactsInfo.Fax LIKE @Pref + '%') OR (@SearchCriteria <> 'Fax'))
					OR    ((Contact_ContactsInfo.Email LIKE @Pref + '%') OR (@SearchCriteria <> 'Email'))
					OR    ((Main_SubCode_3.SCode LIKE @Pref + '%') OR (@SearchCriteria <> 'IDStatus'))
					) temp
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
-- Author:		Yasser Abd Rab El-Rasol
-- ALTER date:  24 Oct. 2011
-- Description:	Get branch order
-- =============================================
ALTER PROCEDURE [dbo].[SP_Get_Branch_Order] 
(
	@ID int,
	@Notes nvarchar(100),
	@SearchCriteria nvarchar(100),
	@Pref nvarchar(100),
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
				(((((Select Max(NoteDate) from Contact_Notes where Contact_Notes.BranchID = Contact_Branches.BranchID) is Not NULL AND @Notes = '1'))
				OR (((Select Max(NoteDate) from Contact_Notes where Contact_Notes.BranchID = Contact_Branches.BranchID) is NULL OR @Notes = '2'))
				OR (@Notes <> '1' AND @Notes <> '2'))
				AND (((Contact_Branches.BrnachName LIKE @Pref + '%') OR (@SearchCriteria <> 'BranchName'))
				AND ((Contact_Branches.Phone LIKE @Pref + '%') OR (@SearchCriteria <> 'Phone'))
				AND ((Main_SubCode_2.SCode LIKE @Pref + '%') OR (@SearchCriteria <> 'BussinessSectorName'))))
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
	
	
	SELECT @Order = @RowsBeforeID - 1
		
	
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		Sayed Moawad
-- ALTER date:  4 january. 2012
-- Description:	create Contact_AccountHierarchy table
-- =============================================
CREATE TABLE [dbo].[Contact_AccountHierarchy](
	[ParentID] [int] NOT NULL,
	[AID] [int] NOT NULL,
	[Type] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Sayed Moawad
-- Create date: 4 January . 2012
-- Description:	update  record in Contact_AccountHierarchy table
-- =============================================

Create PROCEDURE [dbo].[Contact_AccountHierarchy_Update]
(

	@ParentID int   ,
    @AccountId int  ,
	@Type nvarchar (250)

	
)
AS

		
				-- Modify the updatable columns
				UPDATE
					[dbo].Contact_AccountHierarchy
				SET
					[Type] = @Type
					,ParentID = @ParentID
					
					
				WHERE
[AID] = @AccountId 
				

				set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Sayed Moawad
-- Create date: 4 January . 2012
-- Description:	delete  record from Contact_AccountHierarchy table
-- =============================================

Create PROCEDURE [dbo].[Contact_AccountHierarchy_Delete]
(

	@AccountID int   
)
AS


				DELETE FROM [dbo].Contact_AccountHierarchy WITH (ROWLOCK) 
				WHERE
					[AID] = @AccountID


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Sayed Moawad
-- Create date: 4 January . 2012
-- Description:	insert  record in Contact_AccountHierarchy table
-- =============================================

ALTER PROCEDURE [dbo].[Contact_AccountHierarchy_Insert]
(

	@ParentID int   ,
    @AccountId int  ,
	@Type nvarchar (250)

	
)
AS

		
				-- Modify the updatable columns
				INSERT INTO
					[dbo].Contact_AccountHierarchy
				(ParentID,AID ,Type)
					
					
				values (@ParentID,@AccountId ,@Type)


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 4 January . 2012
-- Description:	delete  record from Contact_AccountHierarchy table
-- =============================================

Create PROCEDURE [dbo].[Contact_AccountHierarchy_Get]
AS


				SELECT ParentID, AID, Type
				FROM [dbo].Contact_AccountHierarchy 
			




set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 11 January . 2012
-- Description:	delete  record from Contact_AccountHierarchy table
-- =============================================

ALTER PROCEDURE [dbo].[Contact_AccountHierarchy_Get_By_AID]
(
@AID int,
@ParentID int output
)
AS


				SELECT @ParentID = ParentID
				FROM [dbo].Contact_AccountHierarchy 
				WHERE AID = @AID
			


INSERT INTO [Main_GeneralCode]
           ([GCode])
     VALUES
           ('HierarchyType')

GO

Declare @GID AS int

SELECT @GID = GID
FROM [Main_GeneralCode]
WHERE [GCode] = 'HierarchyType'


INSERT INTO [Main_SubCode]
           ([SCode]
           ,[GID])
     VALUES
           ('Branch'
           ,@GID)

INSERT INTO [Main_SubCode]
           ([SCode]
           ,[GID])
     VALUES
           ('Regional Office'
           ,@GID)

GO

ALTER TABLE Contact_AccountHierarchy ALTER COLUMN Type int

GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- ALTER date:  18 January . 2012
-- Description:	delete  record from Contact_AccountHierarchy table
-- =============================================

ALTER PROCEDURE [dbo].[Contact_AccountHierarchy_Get]
AS


				SELECT ParentID, AID, Main_SubCode.SCode AS TypeName
				FROM [dbo].Contact_AccountHierarchy LEFT OUTER JOIN
				Main_SubCode ON Contact_AccountHierarchy.Type = Main_SubCode.SID
			
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





-- =============================================
-- Author:		Sayed Moawad
-- ALTER date:  18 January . 2012
-- Description:	insert  record in Contact_AccountHierarchy table
-- =============================================

ALTER PROCEDURE [dbo].[Contact_AccountHierarchy_Insert]
(

	@ParentID int   ,
    @AccountId int  ,
	@Type int

	
)
AS

		
				-- Modify the updatable columns
				INSERT INTO
					[dbo].Contact_AccountHierarchy
				(ParentID,AID ,Type)
					
					
				values (@ParentID,@AccountId ,@Type)
				

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		Sayed Moawad
-- ALTER date:  18 January . 2012
-- Description:	update  record in Contact_AccountHierarchy table
-- =============================================

ALTER PROCEDURE [dbo].[Contact_AccountHierarchy_Update]
(

	@ParentID int   ,
    @AccountId int  ,
	@Type int

	
)
AS

		
				-- Modify the updatable columns
				UPDATE
					[dbo].Contact_AccountHierarchy
				SET
					[Type] = @Type
					,ParentID = @ParentID
					
					
				WHERE
[AID] = @AccountId 
				

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- ALTER date:  18 January . 2012
-- Description:	delete  record from Contact_AccountHierarchy table
-- =============================================

ALTER PROCEDURE [dbo].[Contact_AccountHierarchy_Get]
AS


				SELECT ParentID, AID, Type, Main_SubCode.SCode AS TypeName
				FROM [dbo].Contact_AccountHierarchy LEFT OUTER JOIN
				Main_SubCode ON Contact_AccountHierarchy.Type = Main_SubCode.SID

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go





-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 19 January . 2012
-- Description:	delete  record from Contact_AccountHierarchy table
-- =============================================

Create PROCEDURE [dbo].[SubCompanies_Get]
	@ParentID int
AS

	SELECT Contact_AccountHierarchy.ParentID, Contact_AccountHierarchy.AID AS AccountID, 
			Contact_Account.AName AS AccountName,
			Contact_AccountHierarchy.Type,
			Main_SubCode_2.SCode AS TypeName,
			(Select Max(NoteDate) 
				from Contact_Notes 
				where Contact_Notes.AccountID = Contact_Account.AID) AS Notes, 
			Contact_Account.City,
			Contact_Account.State,
			Main_SubCode_1.SCode AS Country,
			Contact_Account.Phone
Type
	FROM Contact_AccountHierarchy LEFT OUTER JOIN
		Contact_Account ON Contact_Account.AID = Contact_AccountHierarchy.AID LEFT OUTER JOIN
		Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID LEFT OUTER JOIN
		Main_SubCode AS Main_SubCode_2 ON Contact_AccountHierarchy.Type = Main_SubCode_2.SID
	WHERE ParentID = @ParentID
			

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go






-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Alter date:  30 January . 2012
-- Description:	delete  record from Contact_AccountHierarchy table
-- =============================================

ALTER PROCEDURE [dbo].[SubCompanies_Get]
	@ParentID int
AS

	SELECT Contact_AccountHierarchy.ParentID, Contact_AccountHierarchy.AID AS AccountID, 
			Contact_Account.AName AS AccountName,
			Contact_AccountHierarchy.Type,
			Main_SubCode_2.SCode AS TypeName,
			(Select Max(NoteDate) 
				from Contact_Notes 
				where Contact_Notes.AccountID = Contact_Account.AID) AS Notes, 
			Contact_Account.City,
			Contact_Account.State,
			Main_SubCode_1.SCode AS Country,
			Contact_Account.Phone
	FROM Contact_AccountHierarchy LEFT OUTER JOIN
		Contact_Account ON Contact_Account.AID = Contact_AccountHierarchy.AID LEFT OUTER JOIN
		Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID LEFT OUTER JOIN
		Main_SubCode AS Main_SubCode_2 ON Contact_AccountHierarchy.Type = Main_SubCode_2.SID
	WHERE ParentID = @ParentID
	
			
-- Date:  30 January . 2012
ALTER TABLE Contact_AccountHierarchy ADD CONSTRAINT PK_AID
PRIMARY KEY CLUSTERED (AID);

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		Sayed Moawad
-- Alter date:  31 January . 2012
-- Description:	delete  record from Contact_AccountHierarchy table
-- =============================================

ALTER PROCEDURE [dbo].[Contact_AccountHierarchy_Delete]
(

	@AccountID int   
)
AS


				DELETE FROM [dbo].Contact_AccountHierarchy WITH (ROWLOCK) 
				WHERE
					[AID] = @AccountID

SELECT @@Rowcount
					

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Create date: 31 January . 2012
-- Description:	Get records from Contact_AccountHierarchy table
-- =============================================

Create PROCEDURE [dbo].[SubCompanies_Names_Get]
	@All bit
AS

	SELECT Contact_Account.AID AS AccountID, 
			Contact_Account.AName AS AccountName
	FROM Contact_Account
	WHERE ((Contact_Account.AID NOT IN (SELECT AID
									  FROM Contact_AccountHierarchy))
		   OR (@All = 1))
			

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Alter date:  1 Feb. 2012
-- Description:	Update all records in 'Contact_Notes' table that belong to certain Contact.
-- =============================================
ALTER PROCEDURE [dbo].[SP_UPDATE_All_Contact_Notes]
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

	IF((@AccountID <> '-1') OR (@BranchID <> '-1'))
	BEGIN
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
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[SP_Check_Miscellaneous_Existance]    Script Date: 02/01/2012 17:29:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Check_Miscellaneous_Existance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Check_Miscellaneous_Existance]
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

-- =============================================
-- Author:		Ehab Hosny
-- Alter date:  2 Feb. 2012
-- Description:	Check if user is account manager user or not
-- =============================================
ALTER PROCEDURE [dbo].[SP_Check_Account_Manager_User]
	-- Add the parameters for the stored procedure here
	(
		@UserID int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  DISTINCT Sec_UserLogin.UID
	FROM	Sec_UserGroup INNER JOIN
			Sec_User_UserGroup ON Sec_UserGroup.GID = Sec_User_UserGroup.GID INNER JOIN
			Sec_UserGroup_Role ON Sec_UserGroup.GID = Sec_UserGroup_Role.GID INNER JOIN
			Sec_Roles ON Sec_UserGroup_Role.RID = Sec_Roles.RID INNER JOIN
			Sec_UserLogin ON Sec_User_UserGroup.UID = Sec_UserLogin.UID
	WHERE	Sec_UserLogin.UID = @UserID AND Sec_Roles.RoleName = 'AssignAccountManager'
END



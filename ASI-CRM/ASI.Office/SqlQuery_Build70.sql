USE [ASI-CRM]
GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Account_Or_Contact_Item_Page]    Script Date: 05/10/2012 16:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Yasser Abd Rab El-Rasol
-- Alter date:  10 May. 2012
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
			SELECT Contact_Account.AName, Contact_Account.AID, Contact_Account.TypeID, Contact_Account.BusSector, Contact_Account.Fax, Contact_Account.Phone, 
					Contact_Account.WebSite, Contact_Account.IDStatus, Contact_Account.Street1, Contact_Account.City, Contact_Account.ZipCode, 
					Contact_Account.CountryID, Contact_Account.ReferedBy, Contact_Account.EnterByID, Contact_Account.EnterDate, Contact_Account.EditByID, 
					Contact_Account.EditDate, Contact_Account.Street2, Contact_Account.TopAccount,
					Contact_Account.AccountManagerID, Contact_Account.AccountManagerEditDate, 
					Contact_Account.AccountManagerEditByID, Contact_Account.AccoutnManagerAssignedDate, Contact_Account.Tag, Contact_Account.State, 
					Main_SubCode_1.SCode AS CountryName, Main_SubCode.SCode AS StatusName, Main_SubCode_2.SCode AS BusinessSectorName, 
					Sec_UserLogin_1.UserName AS EnterByName, Sec_UserLogin.UserName AS EditByName, Sec_UserLogin_3.UserName AS AccountManagerName, 
					Sec_UserLogin_2.UserName AS AccountManagerEditByName,Contact_Account.Profile,Contact_Account.Email, (Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) AS LastAccountNoteDate
			FROM Contact_Account
--				 LEFT OUTER JOIN Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID
--				 LEFT OUTER JOIN Main_SubCode AS Main_SubCode_2 ON Contact_Account.BusSector = Main_SubCode_2.SID
					LEFT OUTER JOIN Sec_UserLogin AS Sec_UserLogin_1 ON Contact_Account.EnterByID = Sec_UserLogin_1.UID LEFT OUTER JOIN
					Main_SubCode ON Contact_Account.IDStatus = Main_SubCode.SID LEFT OUTER JOIN
					Main_SubCode AS Main_SubCode_1 ON Contact_Account.CountryID = Main_SubCode_1.SID LEFT OUTER JOIN
					Sec_UserLogin AS Sec_UserLogin_3 ON Contact_Account.AccountManagerID = Sec_UserLogin_3.UID LEFT OUTER JOIN
					Sec_UserLogin AS Sec_UserLogin_2 ON Contact_Account.AccountManagerEditByID = Sec_UserLogin_2.UID LEFT OUTER JOIN
					Sec_UserLogin ON Contact_Account.EditByID = Sec_UserLogin.UID LEFT OUTER JOIN
					Main_SubCode AS Main_SubCode_2 ON Contact_Account.BusSector = Main_SubCode_2.SID
			WHERE (AName <= (SELECT AName
							FROM Contact_Account
							WHERE AID = @ID) OR @ID = -1)
--			AND Contact_Account.AName LIKE @Pref + '%'
			AND (Main_SubCode_1.SCode = @Country OR @Country = '-1')
--			AND (Contact_Account.State = @State OR @State = '-1')
--			AND (Main_SubCode_2.SCode LIKE @BusSect OR @BusSect = '-1')
--			AND (Contact_Account.Tag = 1 OR @Tag = '-1')
--			AND (((Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is Not NULL AND @Notes = '1') OR (@Notes <> '1' AND @Notes <> '2'))
--			AND (((Select Max(NoteDate) from Contact_Notes where Contact_Notes.AccountID = AID) is NULL OR @Notes = '2') OR (@Notes <> '1' AND @Notes <> '2'))
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









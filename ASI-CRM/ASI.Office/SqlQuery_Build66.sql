UPDATE [Contact_Branches]
   SET [BusSector] = (SELECT [BusSector]
						FROM [Contact_Account]
					 where [AID] = [Contact_Branches].[AccountID])

GO
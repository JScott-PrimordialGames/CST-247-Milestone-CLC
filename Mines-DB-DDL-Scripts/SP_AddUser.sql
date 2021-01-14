/****** Object:  StoredProcedure [dbo].[SP_AddUser]    Script Date: 1/13/2021 1:36:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_AddUser]
(
	@UserName nvarchar(40),
	@FirstName nvarchar(40),
	@LastName nvarchar(40),
	@EmailAddress nvarchar(100),
	@State char(2),
	@Age tinyint, 
	@AddSucceeded binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO [DBO].[USERS] ([USERNAME],[FIRSTNAME],[LASTNAME],[EMAILADDRESS],[STATE], [AGE])
			VALUES (@UserName, @FirstName, @LastName, @EmailAddress, @State, @AGE);

			SET @AddSucceeded = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @AddSucceeded = 0
	END CATCH
END
GO



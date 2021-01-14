/****** Object:  StoredProcedure [dbo].[SP_UpdateProfile_Admin]    Script Date: 1/14/2021 12:01:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_UpdateProfile_Admin]
(
	@Id int,
	@UserName nvarchar(40),
	@FirstName nvarchar(40),
	@LastName nvarchar(40),
	@EmailAddress nvarchar(40),
	@State char(2),
	@Age int,
	@UpdateSuccessful binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [DBO].[USERS]
			SET
				[UserName] = @UserName,
				[FirstName] = @FirstName,
				[LastName] = @LastName,
				[EmailAddress] = @EmailAddress,
				[State] = @State,
				[Age] = @Age
			WHERE [ID] = @Id

			SET @UpdateSuccessful = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		
		SET @UpdateSuccessful = 0
	END CATCH
END
GO



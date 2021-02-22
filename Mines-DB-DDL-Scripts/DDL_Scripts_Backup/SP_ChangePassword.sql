/****** Object:  StoredProcedure [dbo].[SP_ChangePassword]    Script Date: 2/14/2021 10:31:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ChangePassword]
(
	@UserName nvarchar(40),
	@Password nvarchar(400),
	@IsSuccessful binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [DBO].[Users]
			SET [Password] = @Password 
			WHERE [USERNAME] = @UserName
		
			SET @IsSuccessful = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		SET @IsSuccessful = 0
	END CATCH
END
GO



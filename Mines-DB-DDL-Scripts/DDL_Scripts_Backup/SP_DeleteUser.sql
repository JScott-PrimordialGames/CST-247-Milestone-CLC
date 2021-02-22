/****** Object:  StoredProcedure [dbo].[SP_DeleteUser]    Script Date: 2/14/2021 10:32:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DeleteUser]
(
	@Id int,
	@DeletionSuccessful binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE FROM [DBO].[USERS] WHERE ID = @Id

			SET @DeletionSuccessful = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		
		SET @DeletionSuccessful = 0
	END CATCH
END
GO



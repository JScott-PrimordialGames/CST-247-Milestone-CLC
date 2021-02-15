/****** Object:  StoredProcedure [dbo].[SP_SaveGame]    Script Date: 2/14/2021 10:38:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_SaveGame]
(
    -- Add the parameters for the stored procedure here
	@userId int,
    @GameString text,
	@DateCreated datetime,
	@AddSucceeded binary OUTPUT
)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO [DBO].[Games] ([userId], [GameString], [DateCreated])
			VALUES (@userId, @GameString, @DateCreated);

			SET @AddSucceeded = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @AddSucceeded = 0
	END CATCH
END

GO



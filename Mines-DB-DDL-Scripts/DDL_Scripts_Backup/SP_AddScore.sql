/****** Object:  StoredProcedure [dbo].[SP_AddScore]    Script Date: 2/14/2021 10:30:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[SP_AddScore](
	@UserId int,
	@Score float,
	@InsertSucceeded binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN Transaction
			INSERT INTO [DBO].[GAMESCORES] ([USERID], [SCORE]) VALUES (@UserId, @Score)
			SET @InsertSucceeded = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @InsertSucceeded = 0
		ROLLBACK TRANSACTION
	END CATCH
END
GO



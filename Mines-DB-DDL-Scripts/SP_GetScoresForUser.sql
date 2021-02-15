/****** Object:  StoredProcedure [dbo].[SP_GetScoresForUser]    Script Date: 2/14/2021 10:35:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[SP_GetScoresForUser](
	@UserId int
)
AS
BEGIN
	SELECT [SCORE] FROM [DBO].[GAMESCORES] WHERE [USERID] = @UserId
END
GO



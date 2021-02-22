/****** Object:  StoredProcedure [dbo].[SP_GetGameResultsForUser]    Script Date: 2/14/2021 10:34:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SP_GetGameResultsForUser](
	@UserId int
)
AS
BEGIN
	SELECT [SCORES].[USERID], [USERS].[USERNAME], [SCORES].[SCORE], [DIFF].[DIFFICULTY] from [DBO].[GAMESCORES] [SCORES]
	JOIN [DBO].[GameDifficulty] [DIFF] ON [DIFF].[Id] = [SCORES].[gameDifficulty]
	JOIN [DBO].[Users] ON [Users].[Id] = [SCORES].[userId]
	WHERE [USERS].[ID] = @UserId
	ORDER BY [SCORES].[gameDifficulty] DESC, [SCORES].[score]
END
GO



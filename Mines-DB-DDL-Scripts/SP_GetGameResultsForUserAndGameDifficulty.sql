/****** Object:  StoredProcedure [dbo].[SP_GetGameResultsForUserAndGameDifficulty]    Script Date: 2/14/2021 10:35:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[SP_GetGameResultsForUserAndGameDifficulty](
	@UserId int,
	@Difficulty int
)
AS
BEGIN
	SELECT [SCORES].[USERID], [USERS].[USERNAME], [SCORES].[SCORE], [DIFF].[DIFFICULTY] from [DBO].[GAMESCORES] [SCORES]
	JOIN [DBO].[GameDifficulty] [DIFF] ON [DIFF].[Id] = [SCORES].[gameDifficulty]
	JOIN [DBO].[Users] ON [Users].[Id] = [SCORES].[userId]
	WHERE [USERS].[ID] = @UserId and [DIFF].[Id] = @Difficulty
	ORDER BY [SCORES].[gameDifficulty] DESC, [SCORES].[score]
END
GO



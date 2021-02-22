/****** Object:  StoredProcedure [dbo].[SP_GetAllGameScores]    Script Date: 2/14/2021 10:34:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_GetAllGameScores]
(
	@RowsToReturn int = 0
)
AS
BEGIN
	if(@RowsToReturn = 0)
		SELECT [SCORES].[USERID], [USERS].[USERNAME], [SCORES].[SCORE], [DIFF].[DIFFICULTY] from [DBO].[GAMESCORES] [SCORES]
		JOIN [DBO].[GameDifficulty] [DIFF] ON [DIFF].[Id] = [SCORES].[gameDifficulty]
		JOIN [DBO].[Users] ON [Users].[Id] = [SCORES].[userId]
		ORDER BY [SCORES].[gameDifficulty] DESC, [SCORES].[score]
	else
		SELECT TOP (@RowsToReturn) [SCORES].[USERID], [USERS].[USERNAME], [SCORES].[SCORE], [DIFF].[DIFFICULTY] from [DBO].[GAMESCORES] [SCORES]
		JOIN [DBO].[GameDifficulty] [DIFF] ON [DIFF].[Id] = [SCORES].[gameDifficulty]
		JOIN [DBO].[Users] ON [Users].[Id] = [SCORES].[userId]
		ORDER BY [SCORES].[gameDifficulty] DESC, [SCORES].[score]
End
GO



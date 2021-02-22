/****** Object:  StoredProcedure [dbo].[SP_GetThreeSavedGamesByUserID]    Script Date: 2/14/2021 10:36:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetThreeSavedGamesByUserID]
(
	@userId int
)
AS
BEGIN
	SELECT TOP 3 [id], [DateCreated] FROM [DBO].[Games] WHERE [userId] = @userId
	ORDER BY [id] DESC
End
GO



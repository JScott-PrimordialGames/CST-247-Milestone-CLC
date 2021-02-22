/****** Object:  StoredProcedure [dbo].[SP_SearchUsers]    Script Date: 2/14/2021 10:39:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE    PROCEDURE [dbo].[SP_SearchUsers]
(
	@SearchString nvarchar(40)
)
AS
BEGIN
	SET @SearchString = '%' + @SearchString + '%'
	SELECT [Id], [UserName], [FirstName], [LastName], [EmailAddress], [State], [Age], [GENDER] FROM [dbo].[Users] 
	WHERE [UserName] LIKE @SearchString OR [FirstName] LIKE @SearchString OR [LastName] LIKE @SearchString OR [EmailAddress] LIKE @SearchString
END


GO



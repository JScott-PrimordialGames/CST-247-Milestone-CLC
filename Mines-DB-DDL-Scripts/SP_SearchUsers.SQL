/****** Object:  StoredProcedure [dbo].[SP_SearchUsers]    Script Date: 1/14/2021 1:52:20 AM ******/
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



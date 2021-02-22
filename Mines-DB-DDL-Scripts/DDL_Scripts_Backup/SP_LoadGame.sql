/****** Object:  StoredProcedure [dbo].[SP_LoadGame]    Script Date: 2/14/2021 10:37:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SP_LoadGame]
(
	@Id int
)
AS
BEGIN
	SELECT * FROM [DBO].[Games] WHERE [id] = @Id
End
GO



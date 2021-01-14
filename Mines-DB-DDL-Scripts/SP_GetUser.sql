/****** Object:  StoredProcedure [dbo].[SP_GetUser]    Script Date: 1/14/2021 12:51:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetUser]
(
	@Id int
)
AS
BEGIN
	SELECT [ID], [USERNAME], [FIRSTNAME], [LASTNAME], [EMAILADDRESS], [STATE], [AGE] FROM [DBO].[USERS] WHERE [ID] = @Id
End
GO



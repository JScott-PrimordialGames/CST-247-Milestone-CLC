/****** Object:  StoredProcedure [dbo].[SP_GetUser]    Script Date: 2/14/2021 10:37:16 PM ******/
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
	SELECT [ID], [USERNAME], [FIRSTNAME], [LASTNAME], [EMAILADDRESS], [STATE], [AGE], [Gender] FROM [DBO].[USERS] WHERE [ID] = @Id
End
GO



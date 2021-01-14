/****** Object:  StoredProcedure [dbo].[SP_GetUser]    Script Date: 1/14/2021 2:02:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SP_GetUser]
(
	@Id int
)
AS
BEGIN
	SELECT [ID], [USERNAME], [FIRSTNAME], [LASTNAME], [EMAILADDRESS], [STATE], [AGE], [Gender] FROM [DBO].[USERS] WHERE [ID] = @Id
End
GO



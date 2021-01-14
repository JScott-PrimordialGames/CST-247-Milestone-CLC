/****** Object:  StoredProcedure [dbo].[SP_GetUser]    Script Date: 1/14/2021 1:50:43 AM ******/
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
	SELECT [ID], [USERNAME], [FIRSTNAME], [LASTNAME], [EMAILADDRESS], [STATE], [AGE], [GENDER] FROM [DBO].[USERS] WHERE [ID] = @Id
End
GO



/****** Object:  StoredProcedure [dbo].[SP_VerifyLogon]    Script Date: 2/14/2021 10:41:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_VerifyLogon]
(
	@UserName nvarchar(40),
	@Password nvarchar(400)
)
AS
BEGIN
	SELECT [ID], [USERNAME], [FIRSTNAME], [LASTNAME], [EMAILADDRESS], [STATE], [AGE], [Gender] FROM [DBO].[USERS]
	WHERE USERNAME = @UserName and Password = @Password collate SQL_Latin1_General_CP1_CS_AS
	
END
GO



/****** Object:  StoredProcedure [dbo].[SP_EmailAddress_Unique_Check]    Script Date: 1/13/2021 1:48:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_EmailAddress_Unique_Check]
(
	@EmailAddress nvarchar(100),
	@IsUnique binary OUTPUT
)
AS
BEGIN
	IF EXISTS(SELECT * FROM [DBO].[USERS] WHERE EmailAddress = @EmailAddress)
		BEGIN
			SET @IsUnique = 0
		END
	ELSE
		BEGIN
			SET @IsUnique = 1
		END
END
GO



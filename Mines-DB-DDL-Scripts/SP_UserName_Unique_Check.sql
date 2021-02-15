/****** Object:  StoredProcedure [dbo].[SP_UserName_Unique_Check]    Script Date: 2/14/2021 10:40:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UserName_Unique_Check]
(
	@UserName nvarchar(40),
	@IsUnique binary OUTPUT
)
AS
BEGIN
	If Exists( select * from [DBO].[USERS] WHERE [USERNAME] = @UserName)
	BEGIN
		Set @IsUnique = 0
	End
	Else
	BEGIN
		Set @IsUnique = 1
	End
End
GO



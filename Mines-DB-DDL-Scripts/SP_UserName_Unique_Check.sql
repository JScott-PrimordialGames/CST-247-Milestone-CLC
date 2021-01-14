/****** Object:  StoredProcedure [dbo].[SP_UserName_Unique_Check]    Script Date: 1/13/2021 1:42:44 AM ******/
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



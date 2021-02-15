/****** Object:  StoredProcedure [dbo].[SP_DoesUserExist]    Script Date: 2/14/2021 10:32:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SP_DoesUserExist](
	@UserId int,
	@UserExists binary output
)
as
begin
	if Exists(select * from dbo.users where id = @Userid)
		set @UserExists = 1
	else
		set @UserExists = 0
end
GO

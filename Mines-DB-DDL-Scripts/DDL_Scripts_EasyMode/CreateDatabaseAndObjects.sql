/****** Object:  Database [Mines]    Script Date: 2/22/2021 1:21:31 PM ******/
CREATE DATABASE [Mines] 
go
use mines
go
/****** Object:  Table [dbo].[GameDifficulty]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameDifficulty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Difficulty] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_GameDifficulty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[GameString] [text] NULL,
	[userId] [int] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameScores]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameScores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[score] [float] NOT NULL,
	[gameDifficulty] [int] NOT NULL,
 CONSTRAINT [PK_GameScores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateCode] [char](2) NOT NULL,
	[State] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](40) NOT NULL,
	[FirstName] [nvarchar](40) NOT NULL,
	[LastName] [nvarchar](40) NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[State] [char](2) NULL,
	[Age] [tinyint] NOT NULL,
	[Gender] [char](1) NULL,
	[Password] [nvarchar](400) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_EMAILADDRESS] UNIQUE NONCLUSTERED 
(
	[EmailAddress] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_USERNAME] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GameScores]  WITH CHECK ADD  CONSTRAINT [FK_GameDifficulty_Id] FOREIGN KEY([gameDifficulty])
REFERENCES [dbo].[GameDifficulty] ([Id])
GO
ALTER TABLE [dbo].[GameScores] CHECK CONSTRAINT [FK_GameDifficulty_Id]
GO
ALTER TABLE [dbo].[GameScores]  WITH CHECK ADD  CONSTRAINT [FK_GameScores_GameScores] FOREIGN KEY([Id])
REFERENCES [dbo].[GameScores] ([Id])
GO
ALTER TABLE [dbo].[GameScores] CHECK CONSTRAINT [FK_GameScores_GameScores]
GO
ALTER TABLE [dbo].[GameScores]  WITH CHECK ADD  CONSTRAINT [FK_Users_Id] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[GameScores] CHECK CONSTRAINT [FK_Users_Id]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_StateCode] FOREIGN KEY([State])
REFERENCES [dbo].[States] ([StateCode])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_StateCode]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_AGE] CHECK  (([AGE]>(0) AND [AGE]<(130)))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_AGE]
GO
/****** Object:  StoredProcedure [dbo].[SP_AddScore]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[SP_AddScore](
	@UserId int,
	@Score float,
	@Difficulty int,
	@InsertSucceeded binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN Transaction
			INSERT INTO [DBO].[GAMESCORES] ([USERID], [SCORE], gameDifficulty) VALUES (@UserId, Round(@Score,3), @Difficulty)
			SET @InsertSucceeded = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @InsertSucceeded = 0
		ROLLBACK TRANSACTION
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddUser]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_AddUser]
(
	@UserName nvarchar(40),
	@FirstName nvarchar(40),
	@LastName nvarchar(40),
	@EmailAddress nvarchar(100),
	@State char(2),
	@Age tinyint, 
	@Gender char(1),
	@Password nvarchar(400),
	@AddSucceeded binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO [DBO].[USERS] ([USERNAME],[FIRSTNAME],[LASTNAME],[EMAILADDRESS],[STATE], [AGE], [Gender], [Password])
			VALUES (@UserName, @FirstName, @LastName, @EmailAddress, @State, @AGE, @Gender, @Password);

			SET @AddSucceeded = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @AddSucceeded = 0
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ChangePassword]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ChangePassword]
(
	@UserName nvarchar(40),
	@Password nvarchar(400),
	@IsSuccessful binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [DBO].[Users]
			SET [Password] = @Password 
			WHERE [USERNAME] = @UserName
		
			SET @IsSuccessful = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		SET @IsSuccessful = 0
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteUser]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteUser]
(
	@Id int,
	@DeletionSuccessful binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE FROM [DBO].[USERS] WHERE ID = @Id

			SET @DeletionSuccessful = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		
		SET @DeletionSuccessful = 0
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DoesUserExist]    Script Date: 2/22/2021 1:24:43 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_EmailAddress_Unique_Check]    Script Date: 2/22/2021 1:24:43 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GetAllGameScores]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_GetAllGameScores]
(
	@RowsToReturn int = 0
)
AS
BEGIN
	if(@RowsToReturn = 0)
		SELECT [SCORES].[USERID], [USERS].[USERNAME], [SCORES].[SCORE], [DIFF].[DIFFICULTY] from [DBO].[GAMESCORES] [SCORES]
		JOIN [DBO].[GameDifficulty] [DIFF] ON [DIFF].[Id] = [SCORES].[gameDifficulty]
		JOIN [DBO].[Users] ON [Users].[Id] = [SCORES].[userId]
		ORDER BY [SCORES].[gameDifficulty] DESC, [SCORES].[score]
	else
		SELECT TOP (@RowsToReturn) [SCORES].[USERID], [USERS].[USERNAME], [SCORES].[SCORE], [DIFF].[DIFFICULTY] from [DBO].[GAMESCORES] [SCORES]
		JOIN [DBO].[GameDifficulty] [DIFF] ON [DIFF].[Id] = [SCORES].[gameDifficulty]
		JOIN [DBO].[Users] ON [Users].[Id] = [SCORES].[userId]
		ORDER BY [SCORES].[gameDifficulty] DESC, [SCORES].[score]
End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllUsers]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[SP_GetAllUsers]
AS
BEGIN
	SELECT [ID], [USERNAME], [FIRSTNAME], [LASTNAME], [EMAILADDRESS], [STATE], [AGE], [GENDER] FROM [DBO].[USERS]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetGameResultsForUser]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_GetGameResultsForUser](
	@UserId int
)
AS
BEGIN
	SELECT [SCORES].[USERID], [USERS].[USERNAME], [SCORES].[SCORE], [DIFF].[DIFFICULTY] from [DBO].[GAMESCORES] [SCORES]
	JOIN [DBO].[GameDifficulty] [DIFF] ON [DIFF].[Id] = [SCORES].[gameDifficulty]
	JOIN [DBO].[Users] ON [Users].[Id] = [SCORES].[userId]
	WHERE [USERS].[ID] = @UserId
	ORDER BY [SCORES].[gameDifficulty] DESC, [SCORES].[score]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetGameResultsForUserAndGameDifficulty]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SP_GetGameResultsForUserAndGameDifficulty](
	@UserId int,
	@Difficulty int
)
AS
BEGIN
	SELECT [SCORES].[USERID], [USERS].[USERNAME], [SCORES].[SCORE], [DIFF].[DIFFICULTY] from [DBO].[GAMESCORES] [SCORES]
	JOIN [DBO].[GameDifficulty] [DIFF] ON [DIFF].[Id] = [SCORES].[gameDifficulty]
	JOIN [DBO].[Users] ON [Users].[Id] = [SCORES].[userId]
	WHERE [USERS].[ID] = @UserId and [DIFF].[Id] = @Difficulty
	ORDER BY [SCORES].[gameDifficulty] DESC, [SCORES].[score]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetGameScoresForDifficulty]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_GetGameScoresForDifficulty]
(
	@RowsToReturn int = 0,
	@Difficulty int
)
AS
BEGIN
	if(@RowsToReturn = 0)
		SELECT [SCORES].[USERID], [USERS].[USERNAME], [SCORES].[SCORE], [DIFF].[DIFFICULTY] from [DBO].[GAMESCORES] [SCORES]
		JOIN [DBO].[GameDifficulty] [DIFF] ON [DIFF].[Id] = [SCORES].[gameDifficulty]
		JOIN [DBO].[Users] ON [Users].[Id] = [SCORES].[userId]
		WHERE [DIFF].[ID] = @Difficulty
		ORDER BY [SCORES].[gameDifficulty] DESC, [SCORES].[score]
	else
		SELECT TOP (@RowsToReturn) [SCORES].[USERID], [USERS].[USERNAME], [SCORES].[SCORE], [DIFF].[DIFFICULTY] from [DBO].[GAMESCORES] [SCORES]
		JOIN [DBO].[GameDifficulty] [DIFF] ON [DIFF].[Id] = [SCORES].[gameDifficulty]
		JOIN [DBO].[Users] ON [Users].[Id] = [SCORES].[userId]
		WHERE [DIFF].[ID] = @Difficulty
		ORDER BY [SCORES].[gameDifficulty] DESC, [SCORES].[score]
End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetScoresForUser]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_GetScoresForUser](
	@UserId int
)
AS
BEGIN
	SELECT [SCORE] FROM [DBO].[GAMESCORES] WHERE [USERID] = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetStates]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetStates]
AS
BEGIN
	SELECT [STATECODE], [STATE] FROM [DBO].[STATES]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetThreeSavedGamesByUserID]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetThreeSavedGamesByUserID]
(
	@userId int
)
AS
BEGIN
	SELECT TOP 3 [id], [DateCreated] FROM [DBO].[Games] WHERE [userId] = @userId
	ORDER BY [id] DESC
End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetUser]    Script Date: 2/22/2021 1:24:43 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_LoadGame]    Script Date: 2/22/2021 1:24:43 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SaveGame]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_SaveGame]
(
    -- Add the parameters for the stored procedure here
	@userId int,
    @GameString text,
	@DateCreated datetime,
	@AddSucceeded binary OUTPUT
)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO [DBO].[Games] ([userId], [GameString], [DateCreated])
			VALUES (@userId, @GameString, @DateCreated);

			SET @AddSucceeded = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @AddSucceeded = 0
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[SP_SearchUsers]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE    PROCEDURE [dbo].[SP_SearchUsers]
(
	@SearchString nvarchar(40)
)
AS
BEGIN
	SET @SearchString = '%' + @SearchString + '%'
	SELECT [Id], [UserName], [FirstName], [LastName], [EmailAddress], [State], [Age], [GENDER] FROM [dbo].[Users] 
	WHERE [UserName] LIKE @SearchString OR [FirstName] LIKE @SearchString OR [LastName] LIKE @SearchString OR [EmailAddress] LIKE @SearchString
END


GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateProfile]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_UpdateProfile]
(
	@Id int,
	@FirstName nvarchar(40),
	@LastName nvarchar(40),
	@State char(2),
	@Age int,
	@Gender char(1),
	@UpdateSuccessful binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [DBO].[USERS]
			SET
				[FirstName] = @FirstName,
				[LastName] = @LastName,
				[State] = @State,
				[Age] = @Age, 
				[Gender] = @Gender
			WHERE [ID] = @Id

			SET @UpdateSuccessful = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		SET @UpdateSuccessful = 0
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateProfile_Admin]    Script Date: 2/22/2021 1:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_UpdateProfile_Admin]
(
	@Id int,
	@UserName nvarchar(40),
	@FirstName nvarchar(40),
	@LastName nvarchar(40),
	@EmailAddress nvarchar(40),
	@State char(2),
	@Age int,
	@Gender char(1),
	@UpdateSuccessful binary OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [DBO].[USERS]
			SET
				[UserName] = @UserName,
				[FirstName] = @FirstName,
				[LastName] = @LastName,
				[EmailAddress] = @EmailAddress,
				[State] = @State,
				[Age] = @Age,
				[Gender] = @Gender
			WHERE [ID] = @Id

			SET @UpdateSuccessful = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		
		SET @UpdateSuccessful = 0
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UserName_Unique_Check]    Script Date: 2/22/2021 1:24:43 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_VerifyLogon]    Script Date: 2/22/2021 1:24:43 PM ******/
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

/****** Object:  Table [dbo].[GameScores]    Script Date: 2/14/2021 10:28:38 PM ******/
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



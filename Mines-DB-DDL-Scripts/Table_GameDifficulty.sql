/****** Object:  Table [dbo].[GameDifficulty]    Script Date: 2/14/2021 10:26:03 PM ******/
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



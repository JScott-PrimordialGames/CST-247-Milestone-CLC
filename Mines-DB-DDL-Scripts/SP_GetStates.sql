/****** Object:  StoredProcedure [dbo].[SP_GetStates]    Script Date: 2/14/2021 10:36:17 PM ******/
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



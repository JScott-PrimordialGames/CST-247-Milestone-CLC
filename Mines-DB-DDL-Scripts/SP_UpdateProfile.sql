/****** Object:  StoredProcedure [dbo].[SP_UpdateProfile]    Script Date: 2/14/2021 10:39:42 PM ******/
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



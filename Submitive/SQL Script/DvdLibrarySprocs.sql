USE DvdLibrary
Go

--------------INSERT----------------
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'DvdInsert' AND type IN ( N'P', N'PC' )) 
	DROP PROCEDURE DvdInsert
GO

CREATE PROCEDURE DvdInsert (@Title NVARCHAR(250), @ReleaseYear INT, @DirectorId INT, @RateId INT, @Note NVARCHAR(250), @DvdId INT OUTPUT)
AS
	BEGIN
		INSERT INTO Dvd(Title, ReleaseYear, DirectorId, RateId, Note)
		VALUES(@Title, @ReleaseYear, @DirectorId, @RateId, @Note)

		SELECT @DvdId = DvdId FROM Dvd ORDER BY DvdId DESC
	
		RETURN @DvdID
	END
GO

--------------UPDATE----------------
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'DvdUpdate' AND type IN ( N'P', N'PC' )) 
	DROP PROCEDURE DvdUpdate
GO

CREATE PROCEDURE DvdUpdate (@DvdId INT, @Title NVARCHAR(250), @ReleaseYear INT, @DirectorId INT, @RateId INT, @Note NVARCHAR(250))
AS
	BEGIN
		UPDATE Dvd SET Title = @Title,
					ReleaseYear = @ReleaseYear,
					DirectorId = @DirectorId,
					RateId = @RateId, 
					Note = @Note
			WHERE DvdId = @DvdId
	END
GO

--------------DELETE----------------
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'DvdDelete' AND type IN ( N'P', N'PC' )) 
	DROP PROCEDURE DvdDelete
GO

CREATE PROCEDURE DvdDelete (@DvdId INT)
AS
	BEGIN
		DELETE FROM Dvd WHERE DvdId = @DvdId
	END
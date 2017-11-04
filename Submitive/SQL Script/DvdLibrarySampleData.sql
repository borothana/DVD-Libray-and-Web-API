USE DvdLibrary
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'SampleData' AND type IN ( N'P', N'PC' )) 
	DROP PROCEDURE SampleData
GO

CREATE PROCEDURE SampleData
AS
	BEGIN
		---------INSERT INTO RATE--------
		DELETE FROM Rate
		INSERT INTO Rate(Description) VALUES('G')
		INSERT INTO Rate(Description) VALUES('PG')
		INSERT INTO Rate(Description) VALUES('PG-13')
		INSERT INTO Rate(Description) VALUES('R')
		INSERT INTO Rate(Description) VALUES('X')

		---------INSERT INTO DIRECTOR----
		DELETE FROM Director
		INSERT INTO Director(Description) VALUES('Steven Spielberg')
		INSERT INTO Director(Description) VALUES('Martin Scorsese')
		INSERT INTO Director(Description) VALUES('Quentin Tarantino')
		INSERT INTO Director(Description) VALUES('Christopher Nolan')
		INSERT INTO Director(Description) VALUES('David Fincher')

		---------INSERT INTO DVD---------
		DELETE FROM Dvd
		INSERT INTO Dvd(Title, ReleaseYear, DirectorId, RateId, Note)
		VALUES('Saving Private Ryan', 2017, 1, 2, '')

		INSERT INTO Dvd(Title, ReleaseYear, DirectorId, RateId, Note)
		VALUES('The Wolf of Wall Street', 2017, 2, 3, '')

		INSERT INTO Dvd(Title, ReleaseYear, DirectorId, RateId, Note)
		VALUES('Pulp Fiction', 2017, 3, 3, '')

		INSERT INTO Dvd(Title, ReleaseYear, DirectorId, RateId, Note)
		VALUES('The Dark Knight', 2017, 4, 2, '')

		INSERT INTO Dvd(Title, ReleaseYear, DirectorId, RateId, Note)
		VALUES('Fight Club', 2017, 5, 3, '')
	END
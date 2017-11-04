USE master
GO

If Exists (SELECT loginname FROM master.dbo.syslogins WHERE name = 'DvdLibraryApp')
	DROP LOGIN DvdLibraryApp

CREATE LOGIN DvdLibraryApp WITH PASSWORD=N'testing123'

USE DvdLibrary
GO
 
If Exists (SELECT name FROM sys.database_principals WHERE name = 'DvdLibraryApp')
	DROP USER DvdLibraryApp
GO

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON DvdInsert TO DvdLibraryApp
GRANT EXECUTE ON DvdUpdate TO DvdLibraryApp
GRANT EXECUTE ON DvdDelete TO DvdLibraryApp
GRANT EXECUTE ON SampleData TO DvdLibraryApp

GRANT SELECT ON Director TO DvdLibraryApp
GRANT SELECT ON Rate TO DvdLibraryApp
GRANT SELECT ON Dvd TO DvdLibraryApp

GRANT INSERT ON Director TO DvdLibraryApp
GRANT INSERT ON Rate TO DvdLibraryApp
GRANT INSERT ON Dvd TO DvdLibraryApp

GRANT UPDATE ON Director TO DvdLibraryApp
GRANT UPDATE ON Rate TO DvdLibraryApp
GRANT UPDATE ON Dvd TO DvdLibraryApp

GRANT DELETE ON Director TO DvdLibraryApp
GRANT DELETE ON Rate TO DvdLibraryApp
GRANT DELETE ON Dvd TO DvdLibraryApp
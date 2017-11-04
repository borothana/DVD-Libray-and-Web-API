USE master
GO
if exists(SELECT * FROM sysdatabases where name = 'DvdLibrary')
			drop database DvdLibrary

create database DvdLibrary

USE DvdLibrary
Go

--1) Rating
Create Table Rate(
	RateId int identity(1, 1) primary key,
	[Description] varchar(250) not null,
)

--2) Director
Create Table Director(
	DirectorId int identity(1, 1) primary key,
	[Description] varchar(250) not null,
)

--3) DVD
Create Table Dvd(
	DvdId  int identity(1, 1) primary key,
	Title varchar(250) not null,
	ReleaseYear smallint not null,
	DirectorId int foreign key references Director(DirectorId) not null,
	RateId int foreign key references Rate(RateId) not null,
	Note nvarchar(250)
)
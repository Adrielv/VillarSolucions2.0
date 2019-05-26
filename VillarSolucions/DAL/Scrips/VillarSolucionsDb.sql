drop database VillarSolucionsDb


create database VillarSolucionsDb
go
use VillarSolucionsDb

create table Usuario1
(
	UsuarioId INT PRIMARY KEY identity,
	Nombres varchar(30),
	Email varchar(30),
	NivelUsuario varchar(30),
	Usuario varchar(30),
	Clave varchar(30),
	FechaIngreso dateTime,
	CargoId int,
	Descripcion varchar(200)

);

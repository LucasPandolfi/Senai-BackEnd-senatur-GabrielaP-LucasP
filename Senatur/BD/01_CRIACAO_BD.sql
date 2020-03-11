CREATE DATABASE Senatur_Tarde_;
USE Senatur_Tarde_;

CREATE TABLE Pacotes (
	IdPacote INT PRIMARY KEY IDENTITY,
	NomePacote VARCHAR (255) not null,
	Descricao VARCHAR (500) not null ,
	DataIda DATE not null,
	DataVolta DATE not null,
	Valor DECIMAL (18,2) not null,
	NomeCidade VARCHAR(255) not null
);

CREATE TABLE Usuarios (
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (255) not null,
	Senha VARCHAR (255) UNIQUE NOT NULL,
	IdTipoUsuario  INT FOREIGN KEY REFERENCES TiposUsuario (IdTipoUsuario)
);

CREATE TABLE TiposUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR (255) not null
);



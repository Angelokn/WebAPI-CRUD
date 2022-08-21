# WebAPI-CRUD / SQL Server

Código SQL para criação do banco de dados e tabelas:

CREATE DATABASE WebDB

USE WebDB

CREATE TABLE Usuario ( UsuarioId INT IDENTITY(1,1) PRIMARY KEY, Nome NVARCHAR(50) NOT NULL, Email NVARCHAR(50) NOT NULL, )

CREATE TABLE Postagem ( PostagemId INT IDENTITY(1,1) PRIMARY KEY, Titulo NVARCHAR(50) NOT NULL, Autor NVARCHAR(50) NOT NULL, DataPublicacao NVARCHAR(50) NOT NULL, Conteudo NVARCHAR(280) NOT NULL, )

INSERT INTO Usuario (Nome, Email) VALUES ('Angelo K', 'teste@gmail.com')

INSERT INTO Postagem (Titulo, Autor, DataPublicacao, Conteudo) VALUES ('Lorem Ipsum', 'Angelo K', '19/08/2022', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.')

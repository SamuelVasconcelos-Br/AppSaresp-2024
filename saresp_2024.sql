create database saresp_2024;
use saresp_2024;

create table professorAplicador(
IdProfessor int primary key auto_increment,
Nome varchar(100) not null,
CPF decimal(11,0) not null,
RG decimal(9,0) not null,
Telefone decimal(12,0) not null,
DataNasc date not null
);

create table aluno(
IdAluno int primary key auto_increment,
Nome varchar(100) not null,
Email varchar(200) not null,
Telefone decimal(12,0) not null,
Serie varchar(200) not null,
Turma varchar(50) not null,
DataNasc date not null
);

-- select * from professoraplicador;
-- select * from aluno;

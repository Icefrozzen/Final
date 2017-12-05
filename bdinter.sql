create database vidnu	
go 

use vidnu
go

create table pessoas
(
	id        int        not null	 primary key identity,
	nome      varchar(50)  not null,
	email     varchar(250) not null  unique,
	senha 	  varchar(50)  not null,
	dataNasc  date         not null
)
go

create table usuario
(
	id_pessoa   int not null primary key references pessoas,
	foto_perfil  varchar(max)
)
go

create table admim
(
	id_pessoa   int not null primary key references pessoas
)
go

create table video
(
	id        int        not null	 primary key identity,
	nome      varchar(50)  not null,
	data_video datetime not null
)
go

create table categoria
(
	id             int not null primary key identity,
	descricao	   varchar(50) not null	
)
go

create view v_pessoas
as
select p.id             idUsuario,
       p.nome           Nome,
       p.email          Email,
       p.senha          Senha,
       p.dataNas        Data_Nascimento,
	   a.foto_perfil    Foto
 
from pessoas p, usuario a
where p.id = a.id_pessoa
Go
 
 create view v_admin
as
select p.id             idUsuario,
       p.nome           Nome,
       p.email          Email,
       p.senha          Senha
 
from pessoas p
Go


create view v_video
as
select v.id             idVideo,
       v.nome           Nome,
       v.data_video     Data_Video
 
from video v
Go

create view v_categoria
as
select c.id             idCategoria,
select c.descricao      idCategoria
 
from categoria c
Go

Create Procedure CadUsuario
(
	@email       varchar(250),
	@nome        varchar(50),
	@dataNasc    date,
	@senha 	     varchar(50),
	@foto_perfil varchar(max)
)
as
begin
	insert into pessoas values (@email, @nome, @dataNasc, @senha)
	insert into usuario values (@foto_perfil)
end
go

Create Procedure CadAdmin
(
    @nome        varchar(50),
	@email       varchar(250),
    @senha       varchar(50)
)
as
begin
    insert into pessoas values (@nome, @email, @senha)
end
Go

create procedure Logar
(
	@email varchar(250),
	@senha varchar(50)
)
as
begin
	select * from pessoas where email = @email and senha = @senha
end
go

select * from v_pessoas
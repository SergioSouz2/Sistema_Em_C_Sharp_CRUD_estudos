create database dbfuncionarios
default character set utf8mb4
default collate utf8mb4_general_ci;

/*
create database -- comando create serve para criar uma banco desejado 
use  -- comando use serve prara utilizar o banco de dados desejado 
*/

use dbfuncionarios;

create table if not exists funcionarios(
	id int not null auto_increment primary key,
    nome varchar(100) not null,
    email varchar(100) not null,
    cpf varchar(22) not null,
    endereco varchar(200) not null
)default char set utf8mb4;

select * from funcionarios;
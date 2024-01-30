CREATE DATABASE Amigos;

USE Amigos;

if object_id('agenda') is not null
drop table agenda;

create table agenda(
apellido varchar(30),
nombre varchar(20),
domicilio varchar(30),
telefono varchar(11)
);

EXEC sp_tables @table_owner='dbo';

EXEC sp_columns @table_name='agenda';

EXEC sp_columns 'agenda';

DROP TABLE agenda;


insert into agenda (apellido, nombre, domicilio, telefono)
values ('Moreno','Alberto','Colon 123','4234567');

insert into agenda (apellido,nombre, domicilio, telefono)
values ('Torres','Juan','Avellaneda 135','4458787');


select * from agenda;


DROP TABLE agenda;


if object_id('agenda') is not null
drop table agenda;

create table agenda(
apellido varchar(30),
nombre varchar(20),
domicilio varchar(30),
telefono varchar(11)
);

EXEC sp_columns @table_name='agenda';

INSERT  INTO agenda values ('Acosta Hernández','Ana','C/ Luis de Ossuna 23','642364567'),
						('Pérez Pérez', 'Betina', 'Curva de Gracia 135', '664458787'),
						('Lopez Lopez', 'Hector', 'Salto del negro 45', '664887788'),
						('Lopez Lopez', 'Luis', 'Los Menceyes 33', '664545454'),
						('Lopez Lopez', 'Marisa', 'Los Menceyes 33', '664545454');


SELECT * FROM agenda;

SELECT * FROM agenda WHERE nombre LIKE 'Marisa';

SELECT nombre, domicilio FROM agenda WHERE apellido LIKE 'Lopez Lopez';

SELECT nombre Nombre FROM agenda WHERE telefono LIKE '664545454';
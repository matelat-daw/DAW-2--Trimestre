-- PRACTICA Nº 2 SQLS: PROCEDIMIENTOS ALMACENADOS
-- Un profesor guarda en una tabla llamada "alumnos" el nombre de los alumnos y su nota.
-- 1- Elimine la tabla si existe y créela:

if object_id('alumnos') is not null
drop table alumnos;

create table alumnos(
documento char(8),
nombre varchar(40),
nota decimal(4,2),
primary key(documento)
);

-- 2- Inserte algunos registros:

insert into alumnos values ('22222222','Javier López',5),
('23333333','Ana López',4),
('24444444','María Santana',8),
('25555555','Juan García',5.6),
('26666666','Carlos Torres',2),
('27777777','Noelia Torres',7.5),
('28888888','Mariano Herreros',3.5);

-- 3- Elimine la tabla "aprobados" si existe y créela con los mismos campos de la tabla "alumnos":

if object_id('aprobados') is not null
drop table aprobados;

create table aprobados(
documento char(8),
nombre varchar(40),
nota decimal(4,2)
);

-- 4- Elimine la tabla "suspendidos" si existe y créela con los siguientes campos:

if object_id('suspendidos') is not null
drop table suspendidos;

create table suspendidos(
documento char(8),
nombre varchar(40)
);

-- 5- Elimine el procedimiento llamado "pa_aprobados", si existe:

if object_id('pa_aprobados') is not null
drop procedure pa_aprobados;

-- 6- Cree el procedimiento para que seleccione todos los datos de los alumnos cuya nota es igual o superior a 5. SQL Server – pa2

CREATE PROC pa_aprobados
AS
SELECT *
FROM alumnos a WHERE a.nota >= 5;

-- 7- Inserte en la tabla "aprobados" el resultado devuelto por el procedimiento almacenado "pa_aprobados".

INSERT INTO aprobados exec pa_aprobados;

-- 8- Vea el contenido de "aprobados".

select * from aprobados; -- 4 Alumnos Aprobados.

select * from alumnos; -- 7 Alumnnos en Total.

-- 9- Elimine el procedimiento llamado "pa_suspendidos", si existe:

if object_id('pa_suspendidos') is not null
drop procedure pa_suspendidos;

-- 10- Cree el procedimiento para que seleccione el documento y nombre de los alumnos cuya nota es menor a 5.

CREATE PROC pa_suspendidos
AS
SELECT a.documento, a.nombre
FROM alumnos a WHERE a.nota < 5;

-- 11- Inserte en la tabla "suspendidos" el resultado devuelto por el procedimiento almacenado "pa_suspendidos".

INSERT INTO suspendidos exec pa_suspendidos;

-- 12- Vea el contenido de "suspendidos".

SELECT * from suspendidos;
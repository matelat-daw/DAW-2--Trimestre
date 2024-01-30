CREATE DATABASE Videoclub;

USE Videoclub;

CREATE TABLE peliculas (
	nombre varchar(20),
	actor varchar(20),
	duración int,
	cantidad_copias int
);

if object_id('peliculas') is not null
drop table peliculas;


CREATE TABLE peliculas (
	nombre varchar(40),
	actor varchar(20),
	duración int,
	cantidad_copias tinyint
);

EXEC sp_columns @table_name='peliculas';


INSERT INTO peliculas VALUES ('Avatar', 'Sam Worthington', 170, 3),
								('Avatar: The Way of Water', 'Sam Worthington', 192, 2),
								('The Mandalorian', 'Pedro Pascal', 50, 4),
								('Harry Potter y la piedra filosofal', 'Daniel Radcliffe', 159, 3);


SELECT * FROM peliculas;


SELECT nombre Título, actor Actor FROM peliculas;


SELECT nombre Título, duración Duración FROM peliculas;


SELECT nombre Título, cantidad_copias Cantidad FROM peliculas;
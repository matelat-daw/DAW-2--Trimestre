-- IS NULL
-- Trabajamos con la tabla "peliculas" de un video club que alquila películas en video.

-- 1- Elimine la tabla, si existe;

if object_id('peliculas') is not null
drop table peliculas;

-- 2- Créela con la siguiente estructura:
create table peliculas(
codigo int identity,
titulo varchar(40) not null,
actor varchar(20),
duracion tinyint,
primary key (codigo)
);
-- 3- Insertar algunos registros:
insert into peliculas
values	('Mision imposible','Tom Cruise',120),
		('Harry Potter y la piedra filosofal','Daniel R.',null),
		('Harry Potter y la cámara secreta','Daniel R.',190),
		('Mision imposible 2','Tom Cruise',120),
		('Mujer bonita',null,120),
		('Tootsie','D. Hoffman',90);
insert into peliculas (titulo) values('Un oso rojo');

SELECT * FROM peliculas;

-- 4- Recupere las películas cuyo actor sea nulo (2 registros):

SELECT titulo
FROM peliculas
WHERE actor IS null;

-- 5- Cambie la duración a 0, de las películas que tengan duración igual a "null" (2 registros):

UPDATE peliculas SET duracion = 0 WHERE duracion IS null;

-- 6- Borre todas las películas donde el actor sea "null" y cuya duración sea 0 (1 registro):

DELETE FROM peliculas WHERE actor IS null AND duracion = 0;
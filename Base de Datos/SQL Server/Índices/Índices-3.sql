-- ELIMINAR ÍNDICES:
-- Un profesor guarda algunos datos de sus alumnos en una tabla llamada "alumnos".
-- 1- Elimine la tabla si existe y créela con la siguiente estructura:

if object_id('alumnos') is not null
drop table alumnos;

create table alumnos(
cial char(5) not null,
documento char(8) not null,
apellido varchar(30),
nombre varchar(30),
notafinal decimal(4,2)
);

-- 2- Cree un índice no agrupado para el campo "apellido".

CREATE NONCLUSTERED INDEX i_apellido ON alumnos (apellido);

-- 3- Establezca una restricción "primary" para el campo "cial" y especifique que cree un índice "agrupado".

ALTER TABLE alumnos ADD CONSTRAINT PK_cial PRIMARY KEY (cial);

-- 4- Vea la información que muestra "sp_helpindex":

exec sp_helpindex alumnos;

-- 5- Intente eliminar el índice "PK_alumnos_cial" con "drop index":

drop index PK_cial

-- drop index PK_cial ON alumnos;

-- No se puede.

-- 6- Intente eliminar el índice "I_alumnos_apellido" sin especificar el nombre de la tabla:

drop index i_apellido;

-- Mensaje de error.
-- 7- Elimine el índice "I_alumnos_apellido" especificando el nombre de la tabla.

drop index i_apellido ON alumnos;

-- 8- Verifique que se eliminó:

sp_helpindex alumnos;

-- 9- Solicite que se elimine el índice "I_alumnos_apellido" si existe:

if exists (select name from sysindexes
where name = 'i_apellido')
drop index alumnos.i_apellido;

-- 10- Elimine el índice "PK_alumnos_cial" (quite la restricción).

DROP CONSTRAINT PK_cial ON alumnos;

-- 11- Verifique que el índice "PK_alumnos_cial" ya no existe:

sp_helpindex alumnos;
-- REGENERAR ÍNDICES:
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

CREATE NONCLUSTERED INDEX i_apellidosolo ON alumnos (apellido); -- Por Defecto se crean los índices no agrupados, se puede quitar NONCLUSTERED.

DROP INDEX i_apellidosolo ON alumnos;

-- 3- Vea la información de los índices de "alumnos".

exec sp_helpindex alumnos;

-- 4- Modifíquelo agregando el campo "nombre".

create nonclustered index i_apellido on alumnos(apellido, nombre)
with drop_existing;

-- 5- Verifique que se modificó:

exec sp_helpindex alumnos;

-- 6- Establezca una restricción "unique" para el campo "documento".

ALTER TABLE alumnos ADD UNIQUE (documento);

-- 7- Vea la información que muestra "sp_helpindex":

exec sp_helpindex alumnos;

-- 8- Intente modificar con "drop_existing" alguna característica del índice que se creó automáticamente al agregar la restricción "unique":

create clustered index UQ_alumnos_documento
on alumnos(documento)
with drop_existing;

-- No se puede emplear "drop_existing" con índices creados a partir de una Restricción.

-- 9- Cree un índice no agrupado para el campo "cial".

CREATE NONCLUSTERED INDEX i_cial ON alumnos (cial);

-- 10- Muestre todos los índices:

exec sp_helpindex alumnos;

-- 11- Convierta el índice creado en el punto 9 a agrupado conservando las demás características.

CREATE CLUSTERED INDEX i_cial ON alumnos (cial) WITH DROP_EXISTING;

-- 12- Verifique que se modificó:

exec sp_helpindex alumnos;

-- 13- Intente convertir el índice "I_alumnos_cial" a no agrupado:

create nonclustered index i_cial
on alumnos(cial)
with drop_existing;

-- No se puede convertir un índice agrupado en no agrupado.

-- 14- Modifique el índice "I_alumnos_apellido" quitándole el campo "nombre".

create nonclustered index i_apellido
on alumnos(apellido)
with drop_existing;

-- CIFP César Manrique
-- SQL Server - índices
-- 15- Intente convertir el índice "I_alumnos_apellido" en agrupado:

create clustered index i_apellido
on alumnos(apellido)
with drop_existing;

-- No lo permite porque ya existe un índice agrupado.

-- 16- Modifique el índice "I_alumnos_cial" para que sea único y conserve todas las otras características.

ALTER TABLE alumnos ADD UNIQUE (cial);

-- 17- Verifique la modificación:

exec sp_helpindex alumnos;

-- 18- Modifique nuevamente el índice "I_alumnos_cial" para que no sea único y conserve las demás características.

ALTER TABLE alumnos DROP CONSTRAINT UQ__alumnos__23BD07B91E7C6F2B;

-- 19- Verifique la modificación:

exec sp_helpindex alumnos;

SELECT * FROM  alumnos;
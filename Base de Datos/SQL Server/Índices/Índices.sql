-- CREACIÓN DE ÍNDICES:
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

-- 2- Ingresamos algunos registros:
insert into alumnos values ('A123','22222222','Pérez','Patricia',5.50),
('A234','23333333','López','Ana',9),
('A345','24444444','García','Carlos',8.5),
('A348','25555555','Pérez','Daniela',7.85),
('A457','26666666','Pérez','Fabián',3.2),
('A589','27777777','Gómez','Gerardo',6.90);

-- 3- Intente crear un índice agrupado único para el campo "apellido". No lo permite porque hay valores duplicados.

ALTER TABLE alumnos ADD UNIQUE (apellido);

-- 4- Cree un índice agrupado, no único, para el campo "apellido".

CREATE CLUSTERED INDEX i_apellido ON alumnos(apellido);

-- 5- Intente establecer una restricción "primary key" al campo "cial" especificando que cree un índice agrupado. No lo permite porque ya existe un índice agrupado y solamente puede haber uno por tabla.

ALTER TABLE alumnos ADD CONSTRAINT PK_1 PRIMARY KEY (cial);

CREATE CLUSTERED INDEX i_cial ON alumnos(cial);

-- 6- Establezca la restricción "primary key" al campo "cial" especificando que cree un índice NO agrupado.

ALTER TABLE alumnos ADD CONSTRAINT PK_1 PRIMARY KEY (cial);

-- 7- Vea los índices de "alumnos":
exec sp_helpindex alumnos;
-- 2 índices: uno "I_alumnos_apellido", agrupado, con "apellido" y otro "PK_alumnos_cial", no agrupado, unique, con "cial" que se creó automáticamente al crear la restricción "primary key".
-- 8- Analice la información que muestra "sp_helpconstraint":
exec sp_helpconstraint alumnos;
-- En la columna "constraint_type" aparece "PRIMARY KEY" y entre paréntesis, el tipo de índice creado.
-- 9- Cree un índice unique no agrupado para el campo "documento".

CREATE NONCLUSTERED INDEX i_documento ON alumnos(documento);


ALTER TABLE alumnos DROP INDEX i_documento;


SELECT * FROM alumnos;
-- 10- Intente ingresar un alumno con documento duplicado. No lo permite.

INSERT INTO alumnos VALUES ('A234','23333333','Matelat','Cesar', 10);

-- 11- Veamos los indices de "alumnos".

exec sp_helpindex alumnos;

-- 12- Cree un índice compuesto para el campo "apellido" y "nombre".

ALTER TABLE alumnos ADD UNIQUE (apellido, nombre);

--SQL Server - índices
-- Se creará uno no agrupado porque no especificamos el tipo, además, ya existe uno agrupado y solamente puede haber uno por tabla.
-- 13- Consulte la tabla "sysindexes", para ver los nombres de todos los índices creados para "alumnos":
select name from sysindexes
where name like '%alumnos%';
-- 14- Cree una restricción unique para el campo "documento".

ALTER TABLE alumnos ADD UNIQUE (documento);

-- 15- Vea la información de "sp_helpconstraint".

exec sp_helpconstraint alumnos;

-- 16- Vea los índices de "alumnos".

exec sp_helpindex alumnos;

-- 17- Consulte la tabla "sysindexes", para ver los nombres de todos los índices creados para "alumnos":

select name from sysindexes
where name like '%alumnos%';

-- 18- Consulte la tabla "sysindexes", para ver los nombres de todos los índices creados por usted:

select name from sysindexes
where name like 'I_%';

-- 3 índices. Recuerde que los índices que crea SQL Server automáticamente al agregarse una restricción "primary" o "unique" no comienzan con "I_".

Create CLUSTERED INDEX i_Ordenado ON alumnos(cial);
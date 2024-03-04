-- SQL Server - Totales
-- Un club imparte clases de distintos deportes. En una tabla llamada "socios" guarda los datos de los socios, en una tabla llamada "deportes" la información referente a los diferentes deportes que se dictan y en una tabla denominada "inscritos", las inscripciones de los socios a los distintos deportes. Un socio puede inscribirse en varios deportes el mismo año. Un socio no puede inscribirse en el mismo deporte el mismo año. Distintos socios se inscriben en un mismo deporte en el mismo año.
-- 1- Elimine las tablas si existen:

if object_id('socios') is not null
drop table socios;

if object_id('deportes') is not null
drop table deportes;

if object_id('inscritos') is not null
drop table inscritos;

-- 2- Cree las tablas con las siguientes estructuras:
create table socios(
documento char(8) not null,
nombre varchar(30),
domicilio varchar(30),
primary key(documento)
);

create table deportes(
codigo tinyint identity,
nombre varchar(20),
profesor varchar(15),
primary key(codigo)
);

create table inscritos(
documento char(8) not null,
codigodeporte tinyint not null,
anio char(4),
matricula char(1),--'s'=paga, 'n'=impaga
primary key(documento,codigodeporte,anio)
);

-- 3- Ingrese algunos registros en "socios":
insert into socios values('22222222','Ana Acosta','Tres de Mayo 111'),
('23333333','Betina Bustos','San Andrés 222'),
('24444444','Carlos Castro','Araya 333'),
('25555555','Daniel Duarte','Dinamarca 44');

-- 4- Ingrese algunos registros en "deportes":
insert into deportes values('basquet','Juan Juarez'),
('futbol','Pedro Perez'),
('natacion','Marina Morales'),
('tenis','Marina Morales');

-- 5- Inscriba a varios socios en el mismo deporte en el mismo año:
insert into inscritos values ('22222222',3,'2006','s'),
('23333333',3,'2006','s'),
('24444444',3,'2006','n');

-- 6- Inscriba a un mismo socio en el mismo deporte en distintos años:
insert into inscritos values ('22222222',3,'2005','s'),
('22222222',3,'2007','n');


-- CONSULTAS DE TOTALES
-- Trabaje con la tabla llamada "medicamentos" de una farmacia.
-- 1- Muestre la cantidad de registros empleando la función "count(*)" (6 registros)

SELECT COUNT(*)
FROM medicamentos;

-- 2- Cuente la cantidad de medicamentos que tienen laboratorio conocido count distinct (5 registros)

SELECT * from medicamentos;

SELECT COUNT(Distinct nombre)
FROM medicamentos;

-- 3- Cuente la cantidad de medicamentos que tienen precio distinto a "null" y que tienen cantidad distinto a "null", disponer alias para las columnas.

SELECT COUNT(*) Cantidad
FROM medicamentos m
WHERE m.precio IS NOT NULL AND m.cantidad IS NOT NULL;

-- 4- Cuente la cantidad de remedios con precio conocido, cuyo laboratorio comience con "B" (2 registros)

SELECT COUNT(*)
FROM medicamentos m
WHERE m.precio IS NOT NULL AND m.laboratorio LIKE 'B%';

-- 5- Cuente la cantidad de medicamentos con número de lote distinto de "null" (0 registros)

SELECT COUNT(*)
FROM medicamentos WHERE codigo IS NOT NULL;

-- 6- Muestre la cantidad de registros empleando la función "count_big(*)" (6 registros)

SELECT COUNT_BIG(*)
FROM medicamentos;

SELECT COUNT(*)
FROM medicamentos;

SELECT * FROM medicamentos;

-- 7- Cuente la cantidad de laboratorios distintos (3 registros)

SELECT COUNT(DISTINCT laboratorio)
FROM medicamentos;

-- 8- Cuente la cantidad de medicamentos que tienen precio y cantidad distinto de "null" (5 y 5)

SELECT COUNT(*) Cantidad, COUNT(*) PRECIO
FROM medicamentos m
WHERE m.precio IS NOT NULL AND m.cantidad IS NOT NULL;

-- CONSULTAS DE TOTALES
-- Trabaje con la tabla llamada "empleados"
-- 1- Muestre la cantidad de empleados usando "count" (9 empleados)

SELECT * FROM empleados;

SELECT COUNT(*)
from empleados;

-- 2- Muestre la cantidad de empleados con sueldo no nulo de la sección "Secretaria" (2 empleados)

SELECT * FROM empleados;


-- 3- Muestre el sueldo más alto y el más bajo colocando un alias (5000 y 2000)
-- 4- Muestre el valor mayor de "cantidadhijos" de los empleados "Perez" (3 hijos)
-- 5- Muestre el promedio de sueldos de todo los empleados (3400. Note que hay un sueldo nulo y no es tenido en cuenta)
-- 6- Muestre el promedio de sueldos de los empleados de la sección "Secretaría" (2100)
-- 7- Muestre el promedio de hijos de todos los empleados de "Sistemas" (2)
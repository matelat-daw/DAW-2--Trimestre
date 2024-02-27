-- QL - 7
-- Left Join:
-- Una empresa tiene registrados sus clientes en una tabla llamada "clientes", también tiene una tabla "provincias" donde registra los nombres de las provincias.
-- 1- Elimine las tablas "clientes" y "provincias", si existen:
if (object_id('clientes')) is not null
drop table clientes;
if (object_id('provincias')) is not null
drop table provincias;
-- 2- Créelas con las siguientes estructuras:
create table clientes (
codigo int identity,
nombre varchar(30),
domicilio varchar(30),
ciudad varchar(20),
codigoprovincia tinyint not null,
primary key(codigo)
);
create table provincias(
codigo tinyint identity,
nombre varchar(20),
primary key (codigo)
);
-- 3- Ingrese algunos registros para ambas tablas:
-- insert into provincias (nombre) values('Córdoba');
-- insert into provincias (nombre) values('S/C de Tenerife');
-- insert into provincias (nombre) values('Gran Canaria');

insert into provincias (nombre) values('Córdoba'), ('S/C de Tenerife'), ('Gran Canaria');


insert into clientes VALUES ('Lopez Marcos','C/ Peñón 111','Córdoba',1),
('Perez Ana','San Manuel 222','Córdoba',1),
('Garcia Juan','Rivadavia 333','Córdoba',1),
('Perez Luis','Sarmiento 444','El Rosario',2),
('Pereyra Lucas','San Manuel 555','Córdoba',1),
('Gomez Ines','San Manuel 666','S/C de Tenerife',2),
('Torres Fabiola','Alem 777','San Mateo',3);

-- 4- Muestre todos los datos de los clientes, incluido el nombre de la provincia:

SELECT c.nombre, c.domicilio, c.ciudad, c.codigo, c.codigoprovincia, p.nombre FROM clientes c
RIGHT JOIN provincias p ON p.codigo=c.codigoprovincia;

SELECT c.nombre, c.domicilio, c.ciudad, c.codigo, c.codigoprovincia, p.nombre FROM clientes c
LEFT JOIN provincias p ON p.codigo=c.codigoprovincia;

-- 5- Realice la misma consulta anterior pero alterando el orden de las tablas:

SELECT c.nombre, c.domicilio, c.ciudad, c.codigo, c.codigoprovincia, p.nombre FROM provincias p
RIGHT JOIN clientes c ON p.codigo=c.codigoprovincia;

SELECT c.nombre, c.domicilio, c.ciudad, c.codigo, c.codigoprovincia, p.nombre FROM provincias p
LEFT JOIN clientes c ON p.codigo=c.codigoprovincia;

-- 6- Muestre solamente los clientes de las provincias que existen en "provincias" (5 registros):

insert into clientes VALUES ('Uno Nueva','C/ Nueva 999','Córdoba', 5);

SELECT * FROM clientes c
LEFT JOIN provincias p ON c.codigoprovincia=p.codigo
WHERE p.nombre IS NOT NULL;

-- 7- Muestre todos los clientes cuyo código de provincia NO existe en "provincias" ordenados por nombre del cliente (2 registros):

SELECT * FROM clientes c
LEFT JOIN provincias p ON c.codigoprovincia=p.codigo
WHERE p.nombre IS NULL;

-- 8- Obtenga todos los datos de los clientes de "Córdoba" (3 registros):

SELECT * FROM clientes c
LEFT JOIN provincias p ON c.codigoprovincia=p.codigo
WHERE p.nombre='Córdoba';

-- Right Join: SQL Server – left join, right join
-- 1- Muestre todos los datos de los clientes, incluido el nombre de la provincia empleando un "right join".
-- 2- Obtenga la misma salida que la consulta anterior pero empleando un "left join".
-- 3- Empleando un "right join", muestre solamente los clientes de las provincias que existen en "provincias" (5 registros)
-- 4- Muestre todos los clientes cuyo código de provincia NO existe en "provincias" ordenados por ciudad (2 registros)

-- QL - 8

-- Full Join:
-- Un club imparte clases de distintos deportes. Almacena la información en una tabla llamada "deportes" en la cual incluye el nombre del deporte y el nombre del profesor y en otra tabla llamada "inscritos" que incluye el documento del socio que se inscribe, el deporte y si la matricula está paga o no.
-- 1- Elimine las tablas si existen y cree las tablas:
if (object_id('deportes')) is not null
drop table deportes;
if (object_id('inscritos')) is not null
drop table inscritos;
create table deportes(
codigo tinyint identity,
nombre varchar(30),
profesor varchar(30),
primary key (codigo)
);
create table inscritos(
documento char(8),
codigodeporte tinyint not null,
matricula char(1) --'s'=paga 'n'=impaga
);
-- 2- Insertar algunos registros para ambas tablas:
insert into deportes values('tenis','Marcelino Roca'),
('natacion','Marta Torres'),
('baloncesto','Luis Garcia'),
('futbol','Marcelino Roca');
insert into inscritos values('22222222',3,'s'),
('23333333',3,'s'),
('24444444',3,'n'),
('22222222',2,'s'),
('23333333',2,'s'),
('22222222',4,'n'),
('22222222',5,'n');
-- 3- Muestre todos la información de la tabla "inscritos", y consulte la tabla "deportes" para obtener el nombre de cada deporte (6 registros)

SELECT * FROM inscritos i
FULL JOIN deportes d ON i.codigodeporte=d.codigo;

-- 4- Empleando un "left join" con "deportes" obtenga todos los datos de los inscritos (7 registros)

SELECT * FROM inscritos i
LEFT JOIN deportes d ON d.codigo=i.codigodeporte;

-- 5- Obtenga la misma salida anterior empleando un "rigth join".

SELECT * FROM deportes d
RIGHT JOIN inscritos i ON d.codigo=i.codigodeporte;

-- 6- Muestre los deportes para los cuales no hay inscritos, empleando un "left join" (1 registro).

SELECT * FROM deportes d
LEFT JOIN inscritos i ON i.codigodeporte=d.codigo
WHERE i.matricula IS NULL;

-- 7- Muestre los documentos de los inscritos a deportes que no existen en la tabla "deportes" (1 registro)

SELECT i.codigodeporte FROM inscritos i
LEFT JOIN deportes d ON d.codigo=i.codigodeporte
WHERE d.codigo IS NULL;

-- SQL Server - Full Join
-- 8- Emplee un "full join" para obtener todos los datos de ambas tablas, incluyendo las inscripciones a deportes inexistentes en "deportes" y los deportes que no tienen inscritos (8 registros)

SELECT * FROM inscritos i
FULL JOIN deportes d ON d.codigo=i.codigodeporte;

-- QL - 9

-- CIFP César Manrique - SQL Server – outer join
-- Outer Join:
-- Una agencia matrimonial almacena la información de sus clientes de sexo femenino en una tabla llamada "mujeres" y en otra la de sus clientes de sexo masculino llamada "varones".
-- 1- Elimine las tablas si existen y créelas:
if object_id('mujeres') is not null
drop table mujeres;
if object_id('varones') is not null
drop table varones;
create table mujeres(
nombre varchar(30),
domicilio varchar(30),
edad int
);
create table varones(
nombre varchar(30),
domicilio varchar(30),
edad int
);
-- 2- Ingrese los siguientes registros:
insert into mujeres values('Maria Lopez','Los Menceyes 123',45),
('Liliana Garcia','El Rocío 46',35),
('Susana Lopez','Avda. La Cuesta 98',41);
insert into varones values('Juan Torres','La Candelaria 55',44),
('Marcelino Oliva','Los Majuelos 874',56),
('Federico Pereyra','La Trinidad 234',38),
('Juan Garcia','Los Menceyes 333',50);
-- 3- La agencia necesita la combinación de todas las personas de sexo femenino con las de sexo masculino. Use UNION.

SELECT *
FROM mujeres
UNION SELECT *
FROM varones;

-- 4- Realice la misma combinación pero considerando solamente las personas mayores de 40 años (6 registros).

SELECT *
FROM mujeres
UNION SELECT *
FROM varones
WHERE edad > 40;

-- 5- Forme las parejas pero teniendo en cuenta que no tengan una diferencia superior a 10 años (8 registros).

SELECT *
FROM mujeres m
INNER JOIN varones v ON m.edad >= v.edad - 10 AND m.edad <= v.edad + 10;

-- 6- Obtenga la misma salida que en la 3 pero realizando un "join".

SELECT *
FROM mujeres m
FULL JOIN varones v ON m.edad = v.edad;

-- 7- Realice la misma autocombinación que el punto 3 pero agregue la condición que las parejas no tengan una diferencia superior a 5 años (5 registros).

SELECT *
FROM mujeres m
INNER JOIN varones v ON m.edad >= v.edad - 5 AND m.edad <= v.edad + 5;

-- CIFP César Manrique SQL Server – outer join
-- Una empresa de seguridad almacena los datos de sus guardias de seguridad en una tabla llamada "guardias". También almacena los distintos sitios que solicitaron sus servicios en una tabla llamada "tareas".
-- 1- Elimine las tablas "guardias" y "tareas" si existen:
if object_id('guardias') is not null
drop table guardias;
if object_id('tareas') is not null
drop table tareas;
-- 2- Cree las tablas:
create table guardias(
documento char(8),
nombre varchar(30),
sexo char(1), /* 'f' o 'm' */
domicilio varchar(30),
primary key (documento)
);
create table tareas(
codigo tinyint identity,
domicilio varchar(30),
descripcion varchar(30),
horario char(2), /* 'AM' o 'PM'*/
primary key (codigo)
);
-- 3- Insertar los siguientes registros:
insert into guardias values('22333444','Juan Perez','m','La Candelaria 23'),
('24333444','Alberto Torres','m','La Trinidad 67'),
('25333444','Luis Ferreyra','m','Guachinche 25'),
('23333444','Lorena Viale','f','La Candelaria 98'),
('26333444','Irma Gonzalez','f','Los Menceyes 111');

insert into tareas values(' Los Menceyes 1111','vigilancia exterior','AM'),
(' La Candelaria 23','vigilancia exterior','PM'),
('Guachinche 25','vigilancia interior','AM'),
('La Trinidad 67','vigilancia interior','PM');
-- 4- La empresa quiere que todos sus empleados realicen todas las tareas. Realice una "cross join" (20 registros).

SELECT * FROM guardias g CROSS JOIN tareas t;

SELECT *
FROM guardias, tareas;

-- 5- En este caso, la empresa quiere que todos los guardias de sexo femenino realicen las tareas de "vigilancia interior" y los de sexo masculino de "vigilancia exterior". Realice una "cross join" con un "where" que controle tal requisito (10 registros).

SELECT * FROM guardias g CROSS JOIN tareas t WHERE g.sexo='m' AND t.descripcion='vigilancia exterior' OR g.sexo='f' AND t.descripcion='vigilancia interior';


SELECT * FROM mujeres;

SELECT * from varones;
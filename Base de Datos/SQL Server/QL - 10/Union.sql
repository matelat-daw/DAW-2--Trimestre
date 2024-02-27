-- UNION:
-- Un supermercado almacena en una tabla denominada "proveedores" los datos de las compañías que le proveen de mercancías; en una tabla llamada "clientes", los datos de los comercios que le compran y en otra tabla "empleados" los datos de los empleados.
-- 1- Elimine las tablas si existen:
if object_id('clientes') is not null
drop table clientes;

if object_id('proveedores') is not null
drop table proveedores;

if object_id('empleados') is not null
drop table empleados;

-- 2- Cree las tablas:
create table proveedores(
codigo int identity,
nombre varchar (30),
domicilio varchar(30),
primary key(codigo)
);

create table clientes(
codigo int identity,
nombre varchar (30),
domicilio varchar(30),
primary key(codigo)
);

create table empleados(
documento char(8) not null,
nombre varchar(20),
apellido varchar(20),
domicilio varchar(30),
primary key(documento)
);

-- 3- Ingrese algunos registros:
insert into proveedores values('Mencey cola','Colón 123'),
('Carnes Guanche','Canarias 222'),
('Lacteos Tagoror','San Martín 987');

insert into clientes values('Supermercado Chinguaro','La Milagrosa 34'),
('Almacen Acoran','Colón 987'),
('Garcia Juan','La Candelaria 345');

insert into empleados values('23333333','Federico','Lopez','Colón 987'),
('28888888','Ana','Marquez','La Candelaria 333'),
('30111111','Luis','Perez','Canarias 956');

-- 4- El supermercado quiere enviar una tarjeta de salutación a todos los proveedores, clientes y empleados y necesita el nombre y domicilio de todos ellos. Emplee el operador "union" para obtener dicha información de las tres tablas.

SELECT e.nombre FROM empleados e UNION SELECT c.nombre FROM clientes c UNION SELECT p.nombre FROM proveedores p;

-- 5- Agregue una columna con un literal para indicar si es un proveedor, un cliente o un empleado y ordene por dicha columna.

SELECT e.nombre, 1 AS Empleado
FROM empleados e
UNION
SELECT c.nombre, 2 AS Cliente
FROM clientes c
UNION
SELECT p.nombre, 3 AS Proveedor
FROM proveedores p
ORDER BY Empleado;


-- Combinación y agrupamiento:
-- Un comercio que tiene un stand en una feria registra en una tabla llamada "visitantes" algunos datos de las personas que visitan o compran en su stand para luego enviarle publicidad de sus productos y en otra tabla llamada "ciudades" los nombres de las ciudades.
-- 1- Elimine las tablas si existen:

if object_id('visitantes') is not null
drop table visitantes;

if object_id('ciudades') is not null
drop table ciudades;

-- 2- Cree las tablas:
create table visitantes(
nombre varchar(30),
edad tinyint,
sexo char(1) default 'f',
domicilio varchar(30),
codigociudad tinyint not null,
mail varchar(30),
montocompra decimal (6,2)
);

create table ciudades(
codigo tinyint identity,
nombre varchar(20)
);

-- 3- Ingrese algunos registros:
insert into ciudades values('Granadilla'),
('Fasnia'),
('Candelaria'),
('Cruz del Eje');

insert into visitantes values ('Susana Molina', 35,'f','Los Menceyes 123', 1, null,59.80),
('Marcos Torres', 29,'m','Las Candelaria 56', 1, 'marcostorres@hotmail.com', 150.50),
('Mariana Juarez', 45,'f','Los Majuelos 111',2,null,23.90),
('Fabian Perez',36,'m','Tres de Mayo 213', 3,'fabianperez@xaxamail.com', 0),
('Alejandra Garcia',28,'f',null,2,null,280.50),
('Gaston perez', 29, 'm', null, 5, 'gastonperez1@gmail.com', 95.40),
('Mariana Juarez',33,'f',null,2,null,90);

-- 4- Cuente la cantidad de visitas por ciudad mostrando el nombre de la ciudad (3 filas)

SELECT COUNT(v.edad), c.nombre
FROM ciudades c INNER JOIN visitantes v ON c.codigo=v.codigociudad GROUP BY c.codigo;

-- 5- Muestre el promedio de gastos de las visitas agrupados por ciudad y sexo (4 filas)
-- 6- Muestre la cantidad de visitantes con mail, agrupados por ciudad (3 filas)
-- 7- Obtenga el monto de compra más alto de cada ciudad (3 filas)


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
-- Test IN
-- Trabaje con la tabla llamada "medicamentos" de una farmacia.
-- 1- Recupere los nombres y precios de los medicamentos cuyo laboratorio sea "Bayer" o "Bago" empleando el operador "in" (4 registros)
-- 2- Seleccione los remedios cuya cantidad se encuentre entre 1 y 5 empleando el operador "between" y luego el operador "in" (2 registros):
-- Búsqueda LIKE y NOT LIKE
-- Una empresa almacena los datos de sus empleados en una tabla "empleados".
drop table empleados;
create table empleados(
code INTEGER PRIMARY KEY,
apellido VARCHAR(50) NOT NULL,
oficio VARCHAR(30),
dir INTEGER,
fecha_alt DATE,
fecha_nac DATE,
salario INTEGER,
comision INTEGER,
depto INTEGER,
numhijos VARCHAR(20));
drop table departamentos;
create table departamentos(
numdept INTEGER,
centro INTEGER,
director INTEGER,
presupuesto INTEGER,
dpto_jefe INTEGER,
dnombre VARCHAR(30),
loc VARCHAR(30));
drop table centros;
create table centros(
num INTEGER,
nombre VARCHAR(30),
direccion VARCHAR(30));
INSERT INTO empleados VALUES
(7369,'SÁNCHEZ','EMPLEADO',7902,'2020/12/17','1995/10/22',
1040,NULL,20,NULL);
INSERT INTO empleados VALUES
(7499,'ARIAS','VENDEDOR',7698,'2020/02/20','1975/01/22',
1500,390,30,'4');
CIFP César Manrique
SQL Server - IN
INSERT INTO empleados VALUES
(7521,'SALAS','VENDEDOR',7698,'2021/02/22','1975/10/22',
1625,650,30,'1');
INSERT INTO empleados VALUES
(7566,'JIMÉNEZ','DIRECTOR',7839,'2021/04/02','1981/10/22',
2900,NULL,20,NULL);
INSERT INTO empleados VALUES
(7654,'MARTÍN','VENDEDOR',7698,'2021/09/29','1990/10/22',
1600,1020,30,NULL);
INSERT INTO empleados VALUES
(7698,'NÚÑEZ','DIRECTOR',7839,'2021/05/01','1997/10/22',
3005,NULL,30,'2');
INSERT INTO empleados VALUES
(7782,'CASTRO','DIRECTOR',7839,'2021/06/09','1998/10/22',
2885,NULL,10,NULL);
INSERT INTO empleados VALUES (7788,'GIL
MEDINA','ANALISTA',7566,'2021/11/09','1996/10/22',
3000,NULL,20,'1');
INSERT INTO empleados VALUES
(7839,'REYES','PRESIDENTE',NULL,'2021/11/17','1992/10/22',
4100,NULL,10,'4');
INSERT INTO empleados VALUES
(7844,'TRUJILLO','VENDEDOR',7698,'2021/09/08','1991/10/22',
1350,0,30,NULL);
INSERT INTO empleados VALUES
(7876,'ALONSO','EMPLEADO',7788,'2021/09/23','1993/10/22',
1430,NULL,20,'2');
INSERT INTO empleados VALUES
(7900,'PÉREZ','EMPLEADO',7698,'2021/12/03','2000/10/22',
1335,NULL,30','3');
INSERT INTO empleados VALUES
(7902,'FERNÁNDEZ','ANALISTA',7566,'2021/12/03','1985/10/22',
3000,NULL,20,'1');
INSERT INTO emple VALUES
(7934,'MUÑOZ','EMPLEADO',7782,'2022/01/23','1990/10/22',
1690,NULL,10'NULL);
drop table departamentos;
create table departamentos(
numdept INTEGER,
centro INTEGER,
director INTEGER,
presupuesto INTEGER,
dpto_jefe INTEGER,
dnombre VARCHAR(30),
loc VARCHAR(30));
INSERT INTO departamentos VALUES (10,'1',7566,1200000,40,'CONTABILIDAD','La
Gomera');
INSERT INTO departamentos VALUES
(20,'2',7598,1000000,40,'INVESTIGACIÓN','La Palma');
INSERT INTO departamentos VALUES (30,'3',7782,5000000,40,'VENTAS','El
Hierro');
INSERT INTO departamentos VALUES
CIFP César Manrique
SQL Server - IN
(40,'4',7782,1200000,40,'PRODUCCIÓN','Tenerife');
create table clientes (
codigo int identity,
nombre varchar(30) not null,
domicilio varchar(30),
ciudad varchar(20),
provincia varchar (20),
pais varchar(20),
primary key(codigo)
);
insert into clientes
values ('Lopez Marcos','Colon 11', 'Cordoba','Cordoba','España');
insert into clientes
values ('Perez Ana','San Martin 22', 'Calahorra','Cordoba','España');
insert into clientes
values ('Garcia Juan','Primo de Rivera 33', 'Calahorra','Cordoba','España');
insert into clientes
values ('Perez Luis','Sacramento 4', 'El Rosario','Santa Cruz de Tenerife','España');
insert into clientes
values ('Gomez Ines', 'La Trinidad 87', 'San Cristobal de La Laguna','Santa Cruz de Tenerife','España');
insert into clientes
values ('Inés Gómez','La Trinidad 66', ' San Cristobal de La Laguna ','Santa Cruz de Tenerife','España');
insert into clientes
values ('Carlos López','Rayco 88', 'Cordoba','Cordoba','España');
insert into clientes
values ('Beatriz Ramos','San Martín 99', 'Cordoba','Cordoba','España');
insert into clientes
values ('Fernando Salas','Libertad 234', 'Setubal','Lisboa','Portugal');
insert into clientes
values ('Germán Rojas','Avda Marítima 345', 'Figueira da Foz','Oporto','Portugal');
insert into clientes
values ('Ricardo González','Pablo Peres 146', 'Braga','Coimbra','Portugal');
insert into clientes
values ('Joaquín Robles','Vicenzo Ferrari 147', 'Pompeya','Roma','Italia');
CIUDADES:
create table ciudades(
codigo tinyint identity,
nombre varchar(20)
);
insert into ciudades values('Granadilla');
insert into ciudades values('Fasnia');
insert into ciudades values('Candelaria');
insert into ciudades values('Cruz del Carmen');
-- CIFP César Manrique
-- SQL Server - IN
-- 1- Muestre todos los empleados con apellido "Pérez" empleando el operador "like"
-- 2- Muestre todos los empleados cuyo domicilio comience con "Co" y tengan un "8"
-- 3- Seleccione todos los empleados cuyo documento finalice en 0,2,4,6 u 8
-- 4- Seleccione todos los empleados cuyo documento NO comience con 1 ni 3 y cuyo nombre finalice en "ez"
-- 5- Recupere todos los nombres que tengan una "y" o una "j" en su nombre o apellido
-- 6- Muestre los nombres y sección de los empleados que pertenecen a secciones que comiencen con "S" o "G" y tengan 8 caracteres
-- 7- Muestre los nombres y sección de los empleados que pertenecen a secciones que NO comiencen con "S" o "G"
-- 8- Muestre todos los nombres y sueldos de los empleados cuyos sueldos incluyen céntimos
-- 9- Muestre los empleados que hayan entrado en "2020"
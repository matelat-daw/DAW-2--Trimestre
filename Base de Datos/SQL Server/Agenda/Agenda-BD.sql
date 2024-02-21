-- DML - 1

-- 1- Elimine la tabla si existe:
if object_id('agenda') is not null
drop table agenda;

-- 2- Cree la tabla:
create table agenda(
apellido varchar(30),
nombre varchar(20),
domicilio varchar(30),
telefono varchar(11)
);

-- 3- Insertar los siguientes registros (1 registro actualizado):
insert into agenda (apellido,nombre,domicilio,telefono)
values ('Acosta','Alberto','Colón 123','4234567'),
('Juarez','Juan','Los Majuelos 135','4458787'),
('Lopez','Maria','Los Menceyes 333','4545454'),
('Lopez','Jose',' Colón 333','4545454'),
('Suarez','Susana','Los Menceyes 234','4123456');

-- 4- Modifique el registro cuyo nombre sea "Juan" por "Juan Jose" (1 registro afectado)
Update agenda SET nombre='Juan Jose' WHERE nombre='Juan';

-- 5- Actualice los registros cuyo número telefónico sea igual a "4545454" por "4445566" (2 registros afectados)
UPDATE agenda SET telefono='4445566' WHERE telefono='445566';

-- 6- Actualice los registros que tengan en el campo "nombre" el valor "Juan" por "Juan José" (ningún registro afectado porque ninguno cumple con la condición del "where")
Update agenda SET nombre='Juan Jose' WHERE nombre='Juan';

-- 7 - Luego de cada actualización ejecute un select que muestre todos los registros de la tabla.

SELECT * FROM agenda;


-- DML - 2

-- 1- Elimine la tabla si existe:
if object_id('consultas') is not null
drop table consultas;

-- 2- La tabla contiene los siguientes datos:

CREATE TABLE consulta (
	fechayhora datetime not null,
	medico varchar(30) not null,
	documento char(8) not null,
	paciente varchar(30),
	obrasocial varchar(30)
);

DROP Table Consulta;

-- fecha y hora de la consulta, nombre del médico ('Perez López,Domingo'), documento del paciente, nombre del paciente, nombre de la obra social (IPAM,PAMI, etc.).

-- 3- Un médico sólo puede atender a un paciente en una fecha y hora determinada.
-- En una fecha y hora determinada, varios médicos atienden a distintos pacientes.
-- Cree la tabla definiendo una clave primaria compuesta:
create table consultas(
fechayhora datetime not null,
medico varchar(30) not null,
documento char(8) not null,
paciente varchar(30),
obrasocial varchar(30),
primary key(fechayhora,medico)
);

-- 4- Insertar los siguientes registros en consultas:
insert into consultas(fechayhora, medico, documento, paciente, obrasocial)
values ('2024-01-31 09:05','Alberto Sedano', '43654321','María José Mesa', 'SS'),
('2024-01-31 09:05','Tomás Hernández', '43654321','María José Mesa', 'SS'),
('2024-01-02 10:25','Alberto Sedano', '43123458','Margarita Mesa', 'Adeslas'),
('2024-01-02 11:30','Tomás Hernández', '43123458','Margarita Mesa', 'Adeslas'),
('2024-01-02 12:10','Alberto Sedano', '43654320','Carlos Lemes', 'SS'),
('2024-01-30 08:00','Alberto Sedano', '43654321','María José Mesa', 'SS');

-- 5- Mostrar varias consultas para un mismo médico en distintas horas el mismo día.

SELECT * FROM consultas WHERE (DATEPART(yy, fechayhora) = 2024 AND DATEPART(mm, fechayhora) = 01 AND DATEPART(dd, fechayhora) = 30) AND medico='Alberto Sedano';


-- 6- Mostrar varias consultas para diferentes médicos en la misma fecha y hora.

SELECT * FROM consultas WHERE 1 < (SELECT COUNT(fechayhora) FROM consultas WHERE 1 < (SELECT COUNT(medico) FROM consultas GROUP BY medico));

-- 7- Insertar una consulta para un mismo médico en la misma hora el mismo día.
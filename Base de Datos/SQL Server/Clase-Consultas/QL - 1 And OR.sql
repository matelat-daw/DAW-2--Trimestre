-- OPERADORES AND Y OR
-- Trabaje con la tabla llamada "medicamentos" de una farmacia.
-- 1- Elimine la tabla, si existe:
if object_id('medicamentos') is not null
drop table medicamentos;
-- 2- Cree la tabla con la siguiente estructura:
create table medicamentos(
codigo int identity,
nombre varchar(20),
laboratorio varchar(20),
precio decimal(5,2),
cantidad tinyint,
primary key(codigo)
);
-- 3- Insertar algunos registros:
insert into medicamentos
values	('Sertal','Roche',5.2,100),
		('Buscapina','Roche',4.10,200),
		('Amoxidal 500','Bayer',15.60,100),
		('Paracetamol 500','Bago',1.90,200),
		('Bayaspirina','Bayer',2.10,150),
		('Amoxidal jarabe','Bayer',5.10,250);
-- 4- Recupere los códigos y nombres de los medicamentos cuyo laboratorio sea 'Roche' y cuyo precio sea menor a 5 (1 registro cumple con ambas condiciones):

SELECT nombre 'Nombre de Medicamento'
FROM medicamentos
WHERE laboratorio = 'Roche' AND precio < 5;

-- 5- Recupere los medicamentos cuyo laboratorio sea 'Roche' o cuyo precio sea menor a 5 (4 registros):

SELECT nombre 'Nombre de Medicamento'
FROM medicamentos
WHERE laboratorio = 'Roche' OR precio < 5;

-- 6- Muestre todos los medicamentos cuyo laboratorio NO sea "Bayer" y cuya cantidad sea=100 (1 registro):

SELECT nombre 'Nombre de Medicamento'
FROM medicamentos
WHERE laboratorio != 'Bayer' AND cantidad=100;

-- 7- Muestre todos los medicamentos cuyo laboratorio sea "Bayer" y cuya cantidad NO sea=100 (2 registros):

SELECT nombre 'Nombre de Medicamento'
FROM medicamentos
WHERE laboratorio != 'Bayer' AND cantidad!=100;

-- 8- Elimine todos los registros cuyo laboratorio sea igual a "Bayer" y su precio sea mayor a 10 (1 registro eliminado):

SELECT *
FROM medicamentos
WHERE laboratorio = 'Bayer' AND precio > 10;

-- 9- Cambie la cantidad por 200, a todos los medicamentos de "Roche" cuyo precio sea mayor a 5 (1 registro afectado):

UPDATE medicamentos SET precio=100 WHERE laboratorio = 'Roche' AND precio > 5;

-- 10- Borre los medicamentos cuyo laboratorio sea "Bayer" o cuyo precio sea menor a 3 (3 registros borrados):

DELETE FROM medicamentos WHERE laboratorio = 'Bayer' AND precio < 3;
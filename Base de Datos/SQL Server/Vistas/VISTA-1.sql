-- VISTAS:
-- Un club dicta cursos de distintos deportes. Almacena la información en varias tablas. El director no quiere que los empleados de administración conozcan la
-- estructura de las tablas ni algunos datos de los profesores y socios, por ello se crean vistas a las cuales tendrán acceso.
-- 1- Elimine las tablas y créelas nuevamente:

if object_id('inscritos') is not null
drop table inscritos;

if object_id('socios') is not null
drop table socios;

if object_id('profesores') is not null
drop table profesores;

if object_id('cursos') is not null
drop table cursos;

create table socios(
documento char(8) not null,
nombre varchar(40),
domicilio varchar(30),
constraint PK_socios_documento
primary key (documento)
);

create table profesores(
documento char(8) not null,
nombre varchar(40),
domicilio varchar(30),
constraint PK_profesores_documento
primary key (documento)
);

create table cursos(
numero tinyint identity,
deporte varchar(20),
dia varchar(15),
constraint CK_inscritos_dia check (dia
in('lunes','martes','miercoles','jueves','viernes','sabado')),
documentoprofesor char(8),
constraint PK_cursos_numero
primary key (numero),
);

create table inscritos(
documentosocio char(8) not null,
numero tinyint not null,
matricula char(1),
constraint CK_inscritos_matricula check (matricula in('s','n')),
constraint PK_inscritos_documento_numero
primary key (documentosocio,numero)
);

-- 2- Inserte algunos registros para todas las tablas:
insert into socios values('30000000','Francisco Fuentes','La Graciosa 7'),
('31111111','Gerardo García','Lanzarote 65'),
('32222222','Héctor Hernández','Fuerteventura 74'),
('33333333','Inés Izquierdo','Gran Canaria 45');

insert into profesores values('22222222','Ana Acosta','Los Menceyes 31'),
('23333333','Carlos Castro','Mencey Bencomo 5'),
('24444444','Daniel Díaz','Mencey Acaymo 87'),
('25555555','Esteban López','C/ Méndez Nuñez 4');

insert into cursos values('tenis','lunes','22222222'),
('tenis','martes','22222222'),
('natacion','miercoles','22222222'),
('natacion','jueves','23333333'),
('natacion','viernes','23333333'),
('futbol','sabado','24444444'),
('futbol','lunes','24444444'),
('baloncesto','martes','24444444');

insert into inscritos values('30000000',1,'s'),
('30000000',3,'n'),
('30000000',6,null),
('31111111',1,'s'),
('31111111',4,'s'),
('32222222',8,'s');

-- 3- Elimine la vista "vista_club" si existe:

if object_id('vista_club') is not null drop view vista_club;

-- 4- Cree una vista en la que aparezca el nombre y documento del socio, el deporte, el día y el nombre del profesor.

CREATE VIEW vista_club
AS
SELECT s.nombre Socio, s.documento 'DNI Socio', c.deporte Deporte, c.dia Fecha, p.nombre Profesor
FROM socios s INNER JOIN inscritos i ON i.documentosocio=s.documento
INNER JOIN cursos c ON c.numero=i.numero
INNER JOIN profesores p ON p.documento=c.documentoprofesor;

DROP VIEW vista_club;


-- 5- Muestre la información contenida en la vista.

SELECT * FROM vista_club;

-- 6- Realice una consulta a la vista donde muestre la cantidad de socios inscritos en cada deporte ordenados por cantidad.

SELECT COUNT(*) FROM vista_club;

-- 7- Muestre (consultando la vista) los cursos (deporte y día) para los cuales no hay inscritos.
-- 8- Muestre los nombres de los socios que no se han inscripto en ningún curso (consultando la vista)
-- 9- Muestre (consultando la vista) los profesores que no tienen asignado ningún deporte aún.
-- 10- Muestre (consultando la vista) el nombre y documento de los socios que deben matrículas.
-- 11- Consulte la vista y muestre los nombres de los profesores y los días en que asisten al club para dictar sus clases.
-- 12- Muestre la misma información anterior pero ordenada por día.
-- 13- Muestre todos los socios que son compañeros en tenis los lunes.
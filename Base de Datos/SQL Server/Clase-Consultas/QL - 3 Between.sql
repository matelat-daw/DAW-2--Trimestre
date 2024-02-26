-- BETWEEN
-- En una página web se guardan los siguientes datos de las visitas: número de visita, nombre, mail, país, fechayhora de la visita.
-- 1- Elimine la tabla "visitas", si existe:
-- 2- Créela con la siguiente estructura:
create table visitas (
numero int identity,
nombre varchar(30) default 'Anonimo',
mail varchar(50),
provincia varchar (20),
fechayhora datetime,
primary key(numero)
);
-- 3- Insertar algunos registros:
insert into visitas values
('Ana María Lopez','AnaMaria@hotmail.com','Asturias','2016-10-10 10:10'),
('Gustavo Gonzalez','GustavoGGonzalez@gotmail.com','Cádiz','2016-10-10 21:30'),
('Juancito','JuanJosePerez@hotmail.com','Asturias','2016-10-11 15:45'),
('Fabiola Martinez','MartinezFabiola@hotmail.com','Madrid','2016-10-12 08:15'),
('Fabiola Martinez','MartinezFabiola@hotmail.com','Madrid','2016-09-12 20:45'),
('Juancito','JuanJosePerez@gmail.com','Asturias','2016-09-12 16:20'),
('Juancito','JuanJosePerez@hotmail.com','Asturias','2016-09-10 16:25');
insert into visitas (nombre,mail,provincia) values
('Federico1','federicogarcia@xaxamail.com','Asturias');
-- 4- Seleccione los usuarios que visitaron la página entre el '2016-09-12' y '2016-10-11' (5 registros):
-- Note que incluye los de fecha mayor o igual al valor mínimo y menores al valor máximo, y que los valores null no se incluyen.

SELECT nombre
FROM visitas
WHERE fechayhora BETWEEN '2016-09-12 00:00' AND '2016-10-11 23:59';

-- 5- Recupere las visitas cuyo número se encuentra entre 2 y 5 (4 registros):
-- Note que incluye los valores límites.

SELECT nombre, $identity
FROM visitas
WHERE numero BETWEEN 2 and 5;
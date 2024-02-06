CREATE database biblioteca;
GO
USE biblioteca;

CREATE TABLE autor (
  Id_Autor decimal(10,0) NOT NULL DEFAULT 0,
  Nombre text DEFAULT NULL,
  Nacionalidad text DEFAULT NULL,
  Edad char(5) DEFAULT NULL
);


INSERT INTO autor (Id_Autor, Nombre, Nacionalidad, Edad) VALUES
(16, 'Juan Rufol', 'mexicano', '45'),
(17, 'Willian Golding', 'Alemania', '50'),
(18, 'Barbara Gostmich', 'Francia', '33'),
(19, 'Mario Benedetti', 'USA', '47'),
(20, 'Altamirano', 'mexicano', '65'),
(21, 'Benito Pérez Galdós', 'Español', 'DEP'),
(22, 'Ana laura Delgado', 'mexicano', '48'),
(23, 'Og Mandino', 'Usa', '44'),
(24, 'thomas Huxley', 'japones', '60'),
(25, 'Leticia Lopez Juarez', 'Canadiense', '58'),
(26, 'Osar Palacios Ceballos', 'mexicano', '45'),
(27, 'Zamná Heredia', 'portugues', '62'),
(28, 'maria Bernaldez ', 'mexicano', '54'),
(29, 'Jhon y Rita Lang', 'italiano', '55'),
(30, 'Rafael Camacho', 'chileno', '62');


CREATE TABLE estudiante (
  Id_Lector decimal(10,0) NOT NULL DEFAULT 0,
  CI char(5) DEFAULT NULL,
  Nombre text DEFAULT NULL,
  Apellido text DEFAULT NULL,
  Direccion text DEFAULT NULL,
  Carrera text DEFAULT NULL,
  Edad char(5) DEFAULT NULL
);


INSERT INTO estudiante (Id_Lector, CI, Nombre, Apellido, Direccion, Carrera, Edad) VALUES
(31, '3498', 'Maria', 'crispin', 'noche triste', 'contabilidad', '17'),
(32, '3498', 'Jonathan', 'Garcia Lopez ', 'morelos no 7', 'alimentos', '17'),
(33, '6295', 'roberto', 'Sanchez Mejia', 'flor de azalia SN', 'agrobiotecnologia', '20'),
(34, '3452', 'Paola', 'Cervantes Castillo', 'Av. Zaragoza', 'contabilidad', '18'),
(35, '3792', 'mayra', 'Hernandez Sanchez', 'Allende No 3', 'alimentos', '22'),
(36, '6295', 'ivan', 'Trejo Aragon', 'Galeana No23', 'contabilidad', '19'),
(37, '2443', 'Alexander', 'Borregero Cerero', 'Guerrero No8', 'contabilidad', '18'),
(38, '3452', 'Erick', 'Diaz olalde', 'Puerta Norte No6', 'agrobiotecnologa', '18'),
(39, '2443', 'luis', 'Chaltel Gaspar', 'noche triste', 'paramedicos', '19'),
(40, '3452', 'Enrique', 'Aldama Leyte', 'ahuehuetes ', 'tic-si', '22'),
(41, '3498', 'raul', 'Valdez Alanes', 'noche triste No9', 'administrador', '17'),
(42, '1073', 'Sandra', 'Guzman Agurre', 'Hidalgo No12', 'contabilidad', '20');



CREATE TABLE libaut (
  Id_Autor decimal(10,0) DEFAULT NULL,
  Id_Libro decimal(10,0) DEFAULT NULL
);


INSERT INTO libaut (Id_Autor, Id_Libro) VALUES
(16, 1),
(17, 2),
(18, 3),
(19, 4),
(20, 5),
(21, 6),
(22, 7),
(23, 8),
(24, 9),
(25, 10),
(26, 11),
(27, 12),
(28, 13),
(29, 14),
(30, 15);



CREATE TABLE libro (
  Id_Libro decimal(10,0) NOT NULL DEFAULT 0,
  Titulo text DEFAULT NULL,
  Editorial text DEFAULT NULL,
  Area text DEFAULT NULL,
  fechacompra datetime DEFAULT NULL
);


INSERT INTO libro (Id_Libro, Titulo, Editorial, Area, fechacompra) VALUES
(1, 'El Señor de las Moscas', 'Anaya', 'Novela', '2011-01-11 10:37:08'),
(2, 'El Esclavo', 'Porrua', 'Narracion', '2013-01-11 10:37:08'),
(3, 'El Señor de los Anillos', 'FCE', 'Internet', '2012-01-11 10:37:08'),
(4, 'Don Quijote de la Mancha', 'Grijalva', 'Narracion', '2017-01-11 10:37:08'),
(5, 'visual Estudio Net', 'Alfa y Omega', 'informatica', '2011-01-18 10:37:08'),
(6, 'Base de Datos', 'Alfa y Omega', 'informatica', '2012-06-11 10:37:08'),
(7, 'Ingenieria de Software', 'Alfa y Omega', 'informatica', '2018-06-11 10:37:08'),
(8, 'Un Mexicano Mas', 'planeta', 'novela', '2021-11-11 10:37:08'),
(9, 'Entregame tu corazon', 'Anaya', 'Novela', '2012-01-11 10:37:08'),
(10, 'Harry Potter', 'edicciones prado', 'Internet', '2011-01-11 10:37:08'),
(11, 'Harry Potter:Las Reliquias de la Muerte ', 'edicciones prado', 'Internet', '2009-01-11 10:37:08'),
(12, 'Orgullo y Prejuicio', 'Anaya', 'Novela', '2020-12-16 10:37:08'),
(13, 'Romeo y Julienta', 'Anaya', 'Novela', '2014-01-11 10:37:08'),
(14, 'Navidad en las Montañas', 'Anaya', 'Narracion', '2013-12-31 10:37:08'),
(15, 'El Señor de los Anillos: Las Dos Torres', 'FCE', 'Internet', '2011-01-11 10:37:08');


CREATE TABLE prestamo (
  Id_Lector decimal(10,0) DEFAULT NULL,
  id_libro int NOT NULL,
  Fecha_Prestamo datetime DEFAULT NULL,
  Fecha_Devuelto datetime DEFAULT NULL,
  Devuelto date DEFAULT NULL
);


INSERT INTO prestamo (Id_Lector, id_libro, Fecha_Prestamo, Fecha_Devuelto, Devuelto) VALUES
(31, 1, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(31, 1, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(31, 1, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(32, 5, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(33, 6, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(34, 5, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(35, 4, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(36, 3, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(37, 1, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(38, 1, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(39, 6, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(40, 7, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(41, 8, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(42, 7, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(43, 10, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(44, 6, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01'),
(45, 2, '1970-01-01 00:00:00', '1970-01-01 00:00:00', '1970-01-01');


ALTER TABLE autor
  ADD PRIMARY KEY (Id_Autor);



ALTER TABLE estudiante
  ADD PRIMARY KEY (Id_Lector);



ALTER TABLE libro
  ADD PRIMARY KEY (Id_Libro);
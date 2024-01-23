-- Base de Datos Academia

-- 1-. Crear la Base de Datos.

CREATE DATABASE academia;


-- 2-. Usarla.

USE academia;


-- 3-. Crear la Tabla Alumnos con sexo tipo de dato enum("H", "M").

CREATE TABLE alumnos (
	Nombre varchar(20) NOT NULL,
    Apellido1 varchar(20) NOT NULL,
    Apellido2 varchar(20),
    dni varchar(9),
    Direccion varchar(128) NOT NULL,
    sexo enum("H", "M"),
    fecha_nacimiento date,
    curso int NOT NULL
);

-- sexo tipo de dato varchar(1).

CREATE TABLE alumnos (
	Nombre varchar(20) NOT NULL,
    Apellido1 varchar(20) NOT NULL,
    Apellido2 varchar(20),
    dni varchar(9),
    Direccion varchar(128) NOT NULL,
    sexo varchar(1),
    fecha_nacimiento date,
    curso int NOT NULL
);


-- 4-. Crear la Tabla Cursos

CREATE TABLE cursos (
	cod_curso int,
	Nombre_curso varchar(32) NOT NULL,
	dni_profesor varchar(9),
	maximo_alumnos tinyint(4),
	fecha_inicio date NOT NULL,
	fecha_fin date NOT NULL,
	numero_horas int NOT NULL
);


-- 5-. Crear la Tabla Profesores

CREATE TABLE profesores (
	Nombre_profe varchar(20) NOT NULL,
    Apellido1_profe varchar(20) NOT NULL,
    Apellido2_profe varchar(20),
    dni_profe varchar(9),
	Direccion varchar(128) NOT NULL,
	titulo varchar(48) NOT NULL,
	gana decimal(5,2) NOT NULL
);


ALTER TABLE cursos
  MODIFY cod_curso int AUTO_INCREMENT PRIMARY KEY,
  ADD UNIQUE KEY Nombre_curso (Nombre_curso),
  ADD KEY `Hace Referencia a dni_profe de la Tabla profesores` (dni_profesor);
  
  
ALTER TABLE alumnos
  ADD PRIMARY KEY (dni),
  ADD KEY `Hace Referencia a cod_curso de la Tabla cursos` (curso);
  
  
ALTER TABLE profesores
  ADD PRIMARY KEY (dni_profe);
  
  
ALTER TABLE alumnos
    ADD CONSTRAINT sex CHECK (sexo LIKE "H" OR sexo LIKE "M"),
	ADD CONSTRAINT FK_cod_curso FOREIGN KEY (curso) REFERENCES cursos (cod_curso);


ALTER TABLE cursos
	ADD CONSTRAINT fechas CHECK (fecha_inicio < fecha_fin),
	ADD CONSTRAINT FK_dni_profesor FOREIGN KEY (dni_profesor) REFERENCES profesores (dni_profe);
	
	
INSERT INTO profesores VALUES ("Juan", "Arch", "López", "32432455", "Puerta Negra 4", "Ing. Informática", 80.25),
								("María", "Oliva", "Rubio", "43215643", "Juan ALfonso 32", "Lda. Fil. Inglesa", 75.25);
								
								
INSERT INTO cursos VALUES (1, "Inglés Básico", "43215643", 15, "2000-11-01", "2000-12-22", 120),
							(2, "Administración Linux", "32432455", NULL, "2000-09-01", NULL, 80);
							
							
INSERT INTO alumnos VALUES ("Lucas", "Manilva", "López", "123523", "Alhamar 3", "H", "1979-11-01", 1),
							("Antonia", "López", "Alcántara", "2567567", "Maniquí 21", "M", NULL, 2),
							("Manuel", "Alcántara", "Pedrós", "3123689", "Julián 2", NULL, NULL, 2),
							("José", "Pérez", "Caballar", "4896765", "Jarcha 5", "H", "1977-02-03", 1);
							
							
INSERT INTO alumnos VALUES ("Sergio", "Navas", "Retal", "123523", NUll, "P", NULL, NULL);

-- ElPrimer Error que Sale es: La Columna dirección no Puede ser NULL.
-- Si Agrego una Dirección Sale: Entrada Duplicada "123523" para la clave 'Primary', El dni es Clave Primaria y ya Estaba Registrado para el Alumno Lucas Manilva López.
-- Si Cambio el dni a un Valor Valido Sale el Error: No se Cumple la Restricción "sex" para 'academia'.'alumnos'. Ya que se puso una Restrricción para que solo admita H, M o NULL.
	
	
ALTER TABLE profesores ADD edad tinyint(4);


ALTER TABLE profesores
	ADD CONSTRAINT edad CHECK (edad >= 24 AND edad <= 62);
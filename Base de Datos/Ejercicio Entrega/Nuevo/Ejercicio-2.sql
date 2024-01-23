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
	maximo_alumnos int NOT NULL,
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
	ADD Constraint fechas CHECK (fecha_inicio < fecha_fin),
	ADD CONSTRAINT FK_dni_profesor FOREIGN KEY (dni_profesor) REFERENCES profesores (dni_profe);
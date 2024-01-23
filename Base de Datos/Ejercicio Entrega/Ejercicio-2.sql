-- Base de Datos Academia

-- 1-. Crear la Base de Datos.

CREATE DATABASE academia;


-- 2-. Usarla.

USE academia;


-- 3-. Crear la Tabla Alumnos

CREATE TABLE alumnos (
	Nombre varchar(20) NOT NULL,
    Apellido1 varchar(20) NOT NULL,
    Apellido2 varchar(20),
    dni varchar(9),
    Direccion varchar(128) NOT NULL,
    sexo varchar(1),
    fecha_acimiento date,
    curso int
);


-- 4-. Crear la Tabla Cursos

CREATE TABLE cursos (
	cod_curso int,
	Nombre_curso varchar(32) NOT NULL,
	dni_profesor varchar(9),
	maximo_alumnos int NOT NULL,
	fecha_inicio date,
	fecha_fin date,
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
  ADD PRIMARY KEY (cod_curso),
  ADD UNIQUE KEY Nombre_curso (Nombre_curso),
  ADD KEY `Hace Referencia a dni_profe de la Tabla profesores` (dni_profesor) USING BTREE;
  
  
ALTER TABLE alumnos
  ADD PRIMARY KEY (dni),
  ADD KEY "Hace Referencia a cod_curso de la Tablas cursos" (curso) USING BTREE;
  
  
ALTER TABLE profesores
  ADD PRIMARY KEY (dni_profe);
  
  
ALTER TABLE alumnos
  ADD CONSTRAINT FK_cod_curso FOREIGN KEY (curso) REFERENCES cursos (cod_curso);


ALTER TABLE cursos
  ADD CONSTRAINT FK_dni_profesor FOREIGN KEY (dni_profesor) REFERENCES profesores (dni_profe);
COMMIT;
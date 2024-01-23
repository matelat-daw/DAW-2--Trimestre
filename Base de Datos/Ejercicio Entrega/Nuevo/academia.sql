--
-- Base de datos: `academia`
--
CREATE DATABASE academia;
USE academia;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `alumnos`
--

CREATE TABLE alumnos (
	Nombre varchar(20) NOT NULL,
	Apellido1 varchar(20) NOT NULL,
	Apellido2 varchar(20) DEFAULT NULL,
	dni varchar(9) NOT NULL,
	Direccion varchar(128) NOT NULL,
	sexo varchar(1) DEFAULT NULL,
	fecha_nacimiento date DEFAULT NULL,
	curso int(11) NOT NULL
) ;

--
-- Volcado de datos para la tabla `alumnos`
--

INSERT INTO alumnos (Nombre, Apellido1, Apellido2, dni, Direccion, sexo, fecha_nacimiento, curso) VALUES
('Lucas', 'Manilva', 'López', '123456', 'En su Casa.', 'H', '1970-01-01', 1),
('Antonia', 'López', 'Alcántara', '2567567', 'En Su Casa También.', 'M', NULL, 2),
('Manuel', 'Alcántara', 'Pedrós', '3123689', 'En un Derpa.', NULL, NULL, 2),
('José', 'Pérez', 'Caballar', '4896765', 'En su casilla.', 'H', '1977-02-03', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cursos`
--

CREATE TABLE cursos (
	cod_curso int(11) NOT NULL,
	Nombre_curso varchar(32) NOT NULL,
	dni_profesor varchar(9) DEFAULT NULL,
	maximo_alumnos int(11) DEFAULT NULL,
	fecha_inicio date NOT NULL,
	fecha_fin date DEFAULT NULL,
	numero_horas int(11) NOT NULL
) ;

--
-- Volcado de datos para la tabla `cursos`
--

INSERT INTO cursos (cod_curso, Nombre_curso, dni_profesor, maximo_alumnos, fecha_inicio, fecha_fin, numero_horas) VALUES
(1, 'Inglés Básico', '43215643', 15, '2000-11-01', '2000-12-22', 120),
(2, 'Administración Linux', '32432455', NULL, '2000-09-01', NULL, 80);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `profesores`
--

CREATE TABLE profesores (
	Nombre_profe varchar(20) NOT NULL,
	Apellido1_profe varchar(20) NOT NULL,
	Apellido2_profe varchar(20) DEFAULT NULL,
	dni_profe varchar(9) NOT NULL,
	Direccion varchar(128) NOT NULL,
	titulo varchar(48) NOT NULL,
	gana decimal(5,2) NOT NULL
);

--
-- Volcado de datos para la tabla `profesores`
--

INSERT INTO profesores (Nombre_profe, Apellido1_profe, Apellido2_profe, dni_profe, Direccion, titulo, gana) VALUES
('Juan', 'Arch', 'López', '32432455', 'Puerta Negra 4', 'Ing. Informática', 120.50),
('María', 'Oliva', 'Rubio', '43215643', 'Juan Alfonso 32', 'Lda. Fil. Inglesa', 95.50);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `alumnos`
--
ALTER TABLE alumnos
	ADD PRIMARY KEY (dni),
	ADD KEY `Hace Referencia a cod_curso de la Tabla cursos` (curso);

--
-- Indices de la tabla `cursos`
--
ALTER TABLE cursos
	MODIFY cod_curso int AUTO_INCREMENT PRIMARY KEY,
	ADD UNIQUE KEY Nombre_curso (Nombre_curso),
	ADD KEY `Hace Referencia a dni_profe de la Tabla profesores` (dni_profesor);

--
-- Indices de la tabla `profesores`
--
ALTER TABLE profesores
	ADD PRIMARY KEY (dni_profe);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `alumnos`
--
ALTER TABLE alumnos
	ADD CONSTRAINT sex CHECK (sexo LIKE "H" OR sexo LIKE "M"),
	ADD CONSTRAINT FK_cod_curso FOREIGN KEY (curso) REFERENCES cursos (cod_curso);

--
-- Filtros para la tabla `cursos`
--
ALTER TABLE cursos
	ADD Constraint fechas CHECK (fecha_inicio < fecha_fin),
	ADD CONSTRAINT FK_dni_profesor FOREIGN KEY (dni_profesor) REFERENCES profesores (dni_profe);
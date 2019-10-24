PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Adopciones
DROP TABLE IF EXISTS Adopciones;

CREATE TABLE Adopciones (
    IdAdopcion   INTEGER           PRIMARY KEY,
    IdUsuario    INTEGER           REFERENCES Usuarios (IdUsuario) 
                               NOT NULL,
    IdTipoAnimal INTEGER           REFERENCES TipoAnimal (IdTipoAnimal) 
                               NOT NULL,
    Nombre       VARCHAR (50),
    Detalle      VARCHAR (50),
    Ubicacion    VARCHAR (100),
    Sexo         VARCHAR (50),
    Edad         INT,
    Estado       VARCHAR (50) 
);


-- Table: Imagenes
DROP TABLE IF EXISTS Imagenes;

CREATE TABLE Imagenes (
    IdImagen INTEGER           PRIMARY KEY,
    Imagen   VARCHAR (100),
    Estado   VARCHAR (50) 
);


-- Table: ImagenXAdopcion
DROP TABLE IF EXISTS ImagenXAdopcion;

CREATE TABLE ImagenXAdopcion (
    IdImagen   INTEGER REFERENCES Imagenes (IdImagen) 
                   NOT NULL,
    IdAdopcion INTEGER REFERENCES Adopciones (IdAdopcion) 
                   NOT NULL
);


-- Table: Marcadores
DROP TABLE IF EXISTS Marcadores;

CREATE TABLE Marcadores (
    IdMarcador   INTEGER           PRIMARY KEY,
    IdUsuario                  REFERENCES Usuarios (IdUsuario) 
                               NOT NULL,
    IdTipoAnimal INTEGER           REFERENCES TipoAnimal (IdTipoAnimal) 
                               NOT NULL,
    IdImagen     INTEGER           NOT NULL
                               REFERENCES Imagenes (IdImagen),
    Ubicacion    VARCHAR (100),
    Descripcion  VARCHAR (100),
    Estado       VARCHAR (50) 
);


-- Table: Preguntas
DROP TABLE IF EXISTS Preguntas;

CREATE TABLE Preguntas (
    Pregunta  VARCHAR (100) PRIMARY KEY
                            NOT NULL,
    IdUsuario INTEGER           REFERENCES Usuarios (IdUsuario) 
                            NOT NULL,
    Respuesta VARCHAR (100) 
);


-- Table: Refugio
DROP TABLE IF EXISTS Refugio;

CREATE TABLE Refugio (
    IdRefugio     INTEGER           PRIMARY KEY,
    IdUsuario     INTEGER           REFERENCES Usuarios (IdUsuario) 
                                NOT NULL
                                UNIQUE,
    RazonSocial   VARCHAR (50)  NOT NULL,
    Localidad     VARCHAR (100),
    Direccion     VARCHAR (100),
    Ubicacion     VARCHAR (100),
    CodigoPostal  VARCHAR (50),
    Telefono      BIGINT,
    FechaCreacion DATETIME,
    Estado        VARCHAR (50) 
);


-- Table: Reportes
DROP TABLE IF EXISTS Reportes;

CREATE TABLE Reportes (
    IdReporte  INTEGER PRIMARY KEY,
    IdUsuario  INTEGER REFERENCES Usuarios (IdUsuario) 
                   NOT NULL,
    IdMarcador INTEGER REFERENCES Marcadores (IdMarcador) 
                   NOT NULL
);


-- Table: SolicitudAdopcion
DROP TABLE IF EXISTS SolicitudAdopcion;

CREATE TABLE SolicitudAdopcion (
    IdAdopcion           INTEGER           REFERENCES Adopciones (IdAdopcion) 
                                       NOT NULL,
    IdUsuarioSolicitante INTEGER           REFERENCES Usuarios (IdUsuario) 
                                       NOT NULL,
    Descripcion          VARCHAR (100),
    FechaCreacion        DATETIME,
    Estado               VARCHAR (50) 
);


-- Table: TipoAnimal
DROP TABLE IF EXISTS TipoAnimal;

CREATE TABLE TipoAnimal (
    IdTipoAnimal INTEGER          PRIMARY KEY,
    Descripcion  VARCHAR (50) 
);


-- Table: TipoUsuarios
DROP TABLE IF EXISTS TipoUsuario;

CREATE TABLE TipoUsuario(
    IdTipoUsuario INTEGER          PRIMARY KEY,
    Descripcion   VARCHAR (20) 
);


-- Table: Usuarios
DROP TABLE IF EXISTS Usuarios;

CREATE TABLE Usuarios (
    IdUsuario       INTEGER           PRIMARY KEY,
    Usuario         VARCHAR (50)  UNIQUE,
    IdTipoUsuario   INTEGER           REFERENCES TipoUsuario (IdTipoUsuario) 
                                  NOT NULL,
    Contraseña      VARCHAR (50),
    NombreYApellido VARCHAR (100),
    Telefono        BIGINT,
    Email           VARCHAR (50) 
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
 
INSERT INTO TipoAnimal (IdTipoAnimal,Descripcion) VALUES 
	(NULL,'Gato'),
	(NULL,'Perro');
	
INSERT INTO TipoUsuario (IdTipoUsuario,Descripcion) VALUES 
	(NULL,'Admin'),
	(NULL,'Usuario'),
	(NULL,'Refugio');

INSERT INTO Usuarios (IdUsuario, Usuario, IdTipoUsuario, Contraseña, NombreYApellido, Telefono, Email) VALUES
	(NULL,'LUCAS',1,'lucas123','Lucas Peña', 12345, 'lucas@lucas.com'),
	(NULL,'UsuarioComun',2,'usuario123','Usuario Comun', 12345, 'usuario@comun.com'),
	(NULL,'Refugio',2,'refugio123','Refugio Refugio', 12345, 'refugio@refugio.com');



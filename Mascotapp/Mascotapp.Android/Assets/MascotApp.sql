PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Adopciones
DROP TABLE IF EXISTS Adopciones;

CREATE TABLE Adopciones (
    IdAdopcion   INTEGER           PRIMARY KEY,
    IdUsuario    INTEGER           REFERENCES Usuario (IdUsuario) 
                               NOT NULL,
    IdTipoAnimal INTEGER           REFERENCES TipoAnimal (IdTipoAnimal) 
                               NOT NULL,
    Nombre       VARCHAR (50),
    Detalle      VARCHAR (250),
    Ubicacion    VARCHAR (100),
    Sexo         VARCHAR (50),
    Edad         INT,
    Estado       BOOLEAN
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
    IdUsuario                  REFERENCES Usuario (IdUsuario) 
                               NOT NULL,
    IdTipoAnimal INTEGER           REFERENCES TipoAnimal (IdTipoAnimal) 
                               NOT NULL,
    IdImagen     INTEGER           NOT NULL
                               REFERENCES Imagenes (IdImagen),
    Ubicacion    VARCHAR (100),
    Descripcion  VARCHAR (250),
    Estado       VARCHAR (50)
);


-- Table: Preguntas
DROP TABLE IF EXISTS Preguntas;

CREATE TABLE Preguntas (
    Pregunta  TEXT PRIMARY KEY
                            NOT NULL,
    IdUsuario INTEGER           REFERENCES Usuario (IdUsuario) 
                            NOT NULL,
    Respuesta TEXT 
);


-- Table: Refugio
DROP TABLE IF EXISTS Refugio;

CREATE TABLE Refugio (
    IdRefugio     INTEGER           PRIMARY KEY,
    IdUsuario     INTEGER           REFERENCES Usuario (IdUsuario) 
                                NOT NULL
                                UNIQUE,
    RazonSocial   VARCHAR (50)  NOT NULL,
    Localidad     VARCHAR (100),
    Direccion     VARCHAR (100),
    Ubicacion     VARCHAR (100),
    CodigoPostal  VARCHAR (50),
    Telefono      BIGINT,
    FechaCreacion DATETIME,
    Estado        BOOLEAN
);


-- Table: Reportes
DROP TABLE IF EXISTS Reportes;

CREATE TABLE Reportes (
    IdReporte  INTEGER PRIMARY KEY,
    IdUsuario  INTEGER REFERENCES Usuario (IdUsuario) 
                   NOT NULL,
    IdMarcador INTEGER REFERENCES Marcadores (IdMarcador) 
                   NOT NULL
);


-- Table: SolicitudAdopcion
DROP TABLE IF EXISTS SolicitudAdopcion;

CREATE TABLE SolicitudAdopcion (
    IdAdopcion           INTEGER           REFERENCES Adopciones (IdAdopcion) 
                                       NOT NULL,
    IdUsuarioSolicitante INTEGER           REFERENCES Usuario (IdUsuario) 
                                       NOT NULL,
    Descripcion          VARCHAR (250),
    FechaCreacion        DATETIME,
    Estado               BOOLEAN,
    PRIMARY KEY(IdAdopcion,IdUsuarioSolicitante)
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
DROP TABLE IF EXISTS Usuario;

CREATE TABLE Usuario (
    IdUsuario       INTEGER           PRIMARY KEY,
    NombreUsuario         VARCHAR (50)  UNIQUE,
    IdTipoUsuario   INTEGER           REFERENCES TipoUsuario (IdTipoUsuario) 
                                  NOT NULL,
    Contraseña      VARCHAR (50),
    Nombre VARCHAR (100),
    Apellido VARCHAR (100),
    Telefono        BIGINT,
    Email           VARCHAR (50) 
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Adopciones
DROP TABLE IF EXISTS Adopciones;

CREATE TABLE Adopciones (
    IdAdopcion   INT           PRIMARY KEY
                               NOT NULL,
    IdUsuario    INT           REFERENCES Usuarios (IdUsuario) 
                               NOT NULL,
    IdTipoAnimal INT           REFERENCES TipoAnimal (IdTipoAnimal) 
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
    IdImagen INT           PRIMARY KEY
                           NOT NULL,
    Imagen   VARCHAR (100),
    Estado   VARCHAR (50) 
);


-- Table: ImagenXAdopcion
DROP TABLE IF EXISTS ImagenXAdopcion;

CREATE TABLE ImagenXAdopcion (
    IdImagen   INT REFERENCES Imagenes (IdImagen) 
                   NOT NULL,
    IdAdopcion INT REFERENCES Adopciones (IdAdopcion) 
                   NOT NULL
);


-- Table: Marcadores
DROP TABLE IF EXISTS Marcadores;

CREATE TABLE Marcadores (
    IdMarcador   INT           PRIMARY KEY
                               NOT NULL,
    IdUsuario                  REFERENCES Usuarios (IdUsuario) 
                               NOT NULL,
    IdTipoAnimal INT           REFERENCES TipoAnimal (IdTipoAnimal) 
                               NOT NULL,
    IdImagen     INT           NOT NULL
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
    IdUsuario INT           REFERENCES Usuarios (IdUsuario) 
                            NOT NULL,
    Respuesta VARCHAR (100) 
);


-- Table: Refugio
DROP TABLE IF EXISTS Refugio;

CREATE TABLE Refugio (
    IdRefugio     INT           PRIMARY KEY
                                NOT NULL,
    IdUsuario     INT           REFERENCES Usuarios (IdUsuario) 
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
    IdReporte  INT PRIMARY KEY
                   NOT NULL,
    IdUsuario  INT REFERENCES Usuarios (IdUsuario) 
                   NOT NULL,
    IdMarcador INT REFERENCES Marcadores (IdMarcador) 
                   NOT NULL
);


-- Table: SolicitudAdopcion
DROP TABLE IF EXISTS SolicitudAdopcion;

CREATE TABLE SolicitudAdopcion (
    IdAdopcion           INT           REFERENCES Adopciones (IdAdopcion) 
                                       NOT NULL,
    IdUsuarioSolicitante INT           REFERENCES Usuarios (IdUsuario) 
                                       NOT NULL,
    Descripcion          VARCHAR (100),
    FechaCreacion        DATETIME,
    Estado               VARCHAR (50) 
);


-- Table: TipoAnimal
DROP TABLE IF EXISTS TipoAnimal;

CREATE TABLE TipoAnimal (
    IdTipoAnimal INT          PRIMARY KEY
                              NOT NULL,
    Descripcion  VARCHAR (50) 
);


-- Table: TipoUsuarios
DROP TABLE IF EXISTS TipoUsuario;

CREATE TABLE TipoUsuario(
    IdTipoUsuario INT          PRIMARY KEY
                               NOT NULL,
    Descripcion   VARCHAR (20) 
);


-- Table: Usuarios
DROP TABLE IF EXISTS Usuarios;

CREATE TABLE Usuarios (
    IdUsuario       INT           PRIMARY KEY
                                  NOT NULL,
    Usuario         VARCHAR (50)  UNIQUE,
    IdTipoUsuario   INT           REFERENCES TipoUsuario (IdTipoUsuario) 
                                  NOT NULL,
    Contraseña      VARCHAR (50),
    NombreYApellido VARCHAR (100),
    Telefono        BIGINT,
    Email           VARCHAR (50) 
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;

INSERT INTO TipoAnimal (IdTipoAnimal,Descripcion) VALUES 
                (1,'Gato'),
                (2,'Perro');
	
INSERT INTO TipoUsuario (IdTipoUsuario,Descripcion) VALUES 
	(1,'Admin'),
	(2,'Usuario'),
	(3,'Refugio');

INSERT INTO Usuario (IdUsuario, NombreUsuario, IdTipoUsuario, Contraseña, Nombre, Apellido, Telefono, Email) VALUES
	(NULL,'LUCAS',1,'lucas123','Lucas','Peña', 12345, 'lucas@lucas.com'),
	(NULL,'UsuarioComun',2,'usuario123','Pedro','Luis', 12345, 'usuario@comun.com'),
	(NULL,'Refugio',3,'refugio123','Jorge','Mendez', 12345, 'refugio@refugio.com'),
	(NULL,'Comun',2,'usuario2','Damian','Alvarez', 12345, 'comun@usuario.com'),
	(NULL,'Refugio2',3,'refugio123','Fernando','Gutierrez', 12345, 'refugio2@refugio.com'),
	(NULL,'Refugio3',3,'refugio123','Mariano','Lopez', 12345, 'refugio3@refugio.com');
	
INSERT INTO Adopciones(IdAdopcion,IdUsuario,IdTipoAnimal, Nombre,Detalle,Ubicacion,Sexo,Edad,Estado) VALUES
	(NULL,2,1,'Biscuit', 'Vacunado', '-34.4602262740955;-58.611957365647', 'Macho', 2, true),
	(NULL,2,2,'Nuget', 'Vacunado', '-34.452355;-58.635193', 'Hembra', 4, true),
	(NULL,2,1,'Oreo', 'Desparasitado', '-34.452877;-58.637864', 'Macho', 1, true),
	(NULL,2,2,'Chips', 'Recien nacido', '-34.453549;-58.638089', 'Hembra', 0, true),
	(NULL,2,1,'Roronoa', 'Vacunado', '-34.454929;-58.638872', 'Macho', 3, true);
	
INSERT INTO Imagenes (IdImagen, Imagen, Estado) VALUES
	(NULL, '/storage/emulated/0/Mascotapp/gato1.jpg',true ), 
	(NULL, '/storage/emulated/0/Mascotapp/gato2.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/gato3.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/perro1.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/gato4.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/perro2.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/perro3.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/gato5.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/gato6.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/gato7.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/perro4.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/gato8.jpg',true ),
	(NULL, '/storage/emulated/0/Mascotapp/gato9.jpg',true );
	
INSERT INTO ImagenXAdopcion (IdAdopcion,IdImagen) VALUES
	(1,1),
	(1,2),
	(1,3),
	(2,4),
	(3,5),
	(4,6),
	(4,7),
	(5,8),
	(5,9);

INSERT INTO Marcadores (IdMarcador, IdUsuario, IdTipoAnimal , IdImagen, Ubicacion, Descripcion, Estado) VALUES
	(NULL,2,1,10,'-34.450134;-58.638624','Gato perdido',true),
	(NULL,2,2,11,'-34.452417;-58.642508','Perro perdido',true),
	(NULL,2,1,12,'-34.456708;-58.639182','Gato abandonado',true),
	(NULL,2,2,13,'-34.458256;-58.641778','Gato abandonado',true);
	
INSERT INTO Preguntas (Pregunta, IdUsuario, Respuesta) VALUES 
	('Como puedo ver una publicacion?', 1, 'Se puede acceder a las publicaciones seleccionando en el mapa el marcador y luego ver detalle.');
	
INSERT INTO Refugio (IdRefugio, IdUsuario, RazonSocial, Localidad, Direccion, Ubicacion, CodigoPostal, Telefono, FechaCreacion, Estado) VALUES
	(NULL,3,'Campito','Cáceres','Cáceres, Esteban Echeverría, Buenos Aires','-34.454611;-58.635515','1800',123456789,'2019-11-02','Pendiente'),
	(NULL,5,'Adopteros Argentina','Recoleta','Las Heras, Buenos Aires','-34.5518341;-58.4320087','1900',01140893717,'2019-11-02','Pendiente'),
	(NULL,6,'Ayudacan','Salguero','Jerónimo Salguero, Buenos Aires','-34.609192;-58.419967','1700',123456789,'2019-11-02','Pendiente');
	
INSERT INTO Reportes (IdReporte, IdUsuario, IdMarcador) VALUES
	(NULL,4,1),
	(NULL,4,2);
	
INSERT INTO SolicitudAdopcion (IdAdopcion, IdUsuarioSolicitante, Descripcion, FechaCreacion, Estado) VALUES
	(1,4,'Tengo espacio para cuidarlo','2019-11-02','Pendiente'),
	(2,4,'Tengo espacio para cuidarlo','2019-11-02','Pendiente'),
	(3,4,'Estoy disponible a cuidarlo','2019-11-02','Pendiente'),
	(4,4,'Estoy disponible a cuidarlo','2019-11-02','Pendiente');

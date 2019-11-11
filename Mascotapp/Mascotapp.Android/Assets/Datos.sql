INSERT INTO TipoAnimal (IdTipoAnimal,Descripcion) VALUES 
                (1,'Gato'),
                (2,'Perro');
	
INSERT INTO TipoUsuario (IdTipoUsuario,Descripcion) VALUES 
	(1,'Admin'),
	(2,'Usuario'),
	(3,'Refugio');

INSERT INTO Usuario (IdUsuario, NombreUsuario, IdTipoUsuario, Contraseña, Nombre, Apellido, Telefono, Email) VALUES
	(NULL,'Admin',1,'admin123','Lucas','Peña', 1568515719, 'admin@mascotapp.com'),
	(NULL,'PedroL',2,'usuario123','Pedro','Luis', 1568615719, 'lucas_pena_88@hotmail.com'),
	(NULL,'Campito',3,'refugio123','Jorge','Mendez', 1578515719, 'ajaya_gabriel@hotmail.com'),
	(NULL,'DamianA',2,'usuario123','Damian','Alvarez', 1568525719, 'lucas_pena_88@hotmail.com'),
	(NULL,'AdopterosArg',3,'refugio123','Fernando','Gutierrez', 1563515719, 'ajaya_gabriel@hotmail.com'),
	(NULL,'Ayudacan',3,'refugio123','Mariano','Lopez', 1568575719, 'ajaya_gabriel@hotmail.com'),
	(NULL,'LeandroP',2,'usuario123','Leandro','Perez', 1568515718, 'lucas_pena_88@hotmail.com'),
	(NULL,'AlejandroA',2,'usuario123','Alejandro','Ajaya', 1568515729, 'lucas_pena_88@hotmail.com'),
	(NULL,'MiguelR',2,'usuario123','Miguel','Rodriguez', 1568515759, 'lucas_pena_88@hotmail.com'),
	(NULL,'GracielaG',2,'usuario123','Graciela','Gonzalez', 1568515749, 'lucas_pena_88@hotmail.com'),
	(NULL,'GabrielD',2,'usuario123','Gabriel','Dominguez', 1568515519, 'lucas_pena_88@hotmail.com'),
	(NULL,'VictoriaP',2,'usuario123','Victoria','Pignatta', 1568515619, 'lucas_pena_88@hotmail.com'),
	(NULL,'FedericoC',2,'usuario123','Federico','Clavijo', 1568515819, 'lucas_pena_88@hotmail.com'),
	(NULL,'MarkD',2,'usuario123','Mark','Dolling', 1568515919, 'lucas_pena_88@hotmail.com'),
	(NULL,'Apre',3,'refugio123','Rodrigo','Loiacono', 1568511719, 'ajaya_gabriel@hotmail.com'),
	(NULL,'DonCuarto',3,'refugio123','Belen','Ayala', 1568512719, 'ajaya_gabriel@hotmail.com'),
	(NULL,'SfaSA',3,'refugio123','Lautaro','Hernandez', 1568513719, 'ajaya_gabriel@hotmail.com'),
	(NULL,'Sams',3,'refugio123','Julieta','Liparotti', 1568514719, 'ajaya_gabriel@hotmail.com'),
	(NULL,'Renatas',3,'refugio123','Martin','Walther', 1568510719, 'ajaya_gabriel@hotmail.com'),
	(NULL,'SanRoque',3,'refugio123','Gonzalo','Hansen', 1568525719, 'ajaya_gabriel@hotmail.com'),
	(NULL,'Resistir',3,'refugio123','Agustina','Casado', 1568535719, 'ajaya_gabriel@hotmail.com');
	
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
	(NULL,3,'Campito','Cáceres','Cáceres, Esteban Echeverría, Buenos Aires','-34.454611;-58.635515','1800',123456789,'2019-11-02 00:00:00','Pendiente'),
	(NULL,5,'Adopteros Argentina','Recoleta','Las Heras, Buenos Aires','-34.5518341;-58.4320087','1900',01140893717,'2019-11-03 00:00:00','Pendiente'),
	(NULL,6,'Ayudacan','Salguero','Jerónimo Salguero, Buenos Aires','-34.609192;-58.419967','1700',123455559,'2019-11-8 00:00:00','Pendiente'),
	(NULL,15,'Apre','Gral Pacheco','Av. Constituyentes, Buenos Aires','-34.453331;-58.649052','1700',123456666,'2019-11-07 00:00:00','Pendiente'),
	(NULL,16,'DonCuarto','Gral Pacheco','Olegario Victor Andrade 292, Buenos Aires','-34.459981;-58.627144','1700',123456777,'2019-11-04 00:00:00','Pendiente'),
	(NULL,17,'SfaSA','Gral Pacheco','Gral. Pacheco, Buenos Aires','-34.460769;-58.630510','1700',123455789,'2019-11-6 00:00:00','Pendiente'),
	(NULL,18,'Sams','Gral Pacheco','Chaco 97, Buenos Aires','-34.460601;-58.632559','1700',123446789,'2019-11-5 00:00:00','Pendiente'),
	(NULL,19,'Renatas','Gral Pacheco','Buenos Aires 199, Buenos Aires','-34.455003;-58.627275','1700',121456789,'2019-11-01 00:00:00','Pendiente'),
	(NULL,20,'SanRoque','Los Troncos del Talar','Independencia 498, Buenos Aires','-34.452915;-58.614250','1700',123256789,'2019-11-12 00:00:00','Pendiente'),
	(NULL,21,'Resistir','Los Troncos del Talar','Cnel. Pringles 640, Buenos Aires','-34.450659;-58.615623','1700',123356789,'2019-11-10 00:00:00','Pendiente');
	
INSERT INTO Reportes (IdReporte, IdUsuario, IdMarcador) VALUES
	(NULL,4,1),
	(NULL,4,2);
	
INSERT INTO SolicitudAdopcion (IdAdopcion, IdUsuarioSolicitante, Descripcion, FechaCreacion, Estado) VALUES
	(1,4,'Tengo espacio para cuidarlo','2019-11-03 00:00:00','Pendiente'),
	(2,4,'Tengo espacio para cuidarlo','2019-11-04 00:00:00','Pendiente'),
	(3,4,'Estoy disponible a cuidarlo','2019-11-05 00:00:00','Pendiente'),
	(4,4,'Estoy disponible a cuidarlo','2019-11-06 00:00:00','Pendiente');

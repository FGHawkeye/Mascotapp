INSERT INTO TipoAnimal (IdTipoAnimal,Descripcion) VALUES 
                (1,'Gato'),
                (2,'Perro');
	
INSERT INTO TipoUsuario (IdTipoUsuario,Descripcion) VALUES 
	(1,'Admin'),
	(2,'Usuario'),
	(3,'Refugio');

INSERT INTO Usuario (IdUsuario, NombreUsuario, IdTipoUsuario, Contraseña, Nombre, Apellido, Telefono, Email) VALUES
	(NULL,'Admin',1,'admin123','Lucas','Peña', 1568515719, 'admin@mascotapp.com'),
	(NULL,'PedroL',2,'usuario123','Pedro','Luis', 1568615719, 'test@test.com'),
	(NULL,'Campito',3,'refugio123','Jorge','Mendez', 1578515719, 'test@test.com'),
	(NULL,'DamianA',2,'usuario123','Damian','Alvarez', 1568525719, 'test@test.com'),
	(NULL,'AdopterosArg',3,'refugio123','Fernando','Gutierrez', 1563515719, 'test@test.com'),
	(NULL,'Ayudacan',3,'refugio123','Mariano','Lopez', 1568575719, 'test@test.com'),
	(NULL,'LeandroP',2,'usuario123','Leandro','Perez', 1568515718, 'test@test.com'),
	(NULL,'AlejandroA',2,'usuario123','Alejandro','Ajaya', 1568515729, 'test@test.com'),
	(NULL,'MiguelR',2,'usuario123','Miguel','Rodriguez', 1568515759, 'test@test.com'),
	(NULL,'GracielaG',2,'usuario123','Graciela','Gonzalez', 1568515749, 'test@test.com'),
	(NULL,'GabrielD',2,'usuario123','Gabriel','Dominguez', 1568515519, 'test@test.com'),
	(NULL,'VictoriaP',2,'usuario123','Victoria','Pignatta', 1568515619, 'test@test.com'),
	(NULL,'FedericoC',2,'usuario123','Federico','Clavijo', 1568515819, 'test@test.com'),
	(NULL,'MarkD',2,'usuario123','Mark','Dolling', 1568515919, 'test@test.com'),
	(NULL,'Apre',3,'refugio123','Rodrigo','Loiacono', 1568511719, 'test@test.com'),
	(NULL,'DonCuarto',3,'refugio123','Belen','Ayala', 1568512719, 'test@test.com'),
	(NULL,'SfaSA',3,'refugio123','Lautaro','Hernandez', 1568513719, 'test@test.com'),
	(NULL,'Sams',3,'refugio123','Julieta','Liparotti', 1568514719, 'test@test.com'),
	(NULL,'Renatas',3,'refugio123','Martin','Walther', 1568510719, 'test@test.com'),
	(NULL,'SanRoque',3,'refugio123','Gonzalo','Hansen', 1568525719, 'test@test.com'),
	(NULL,'Resistir',3,'refugio123','Agustina','Casado', 1568535719, 'test@test.com');
	
INSERT INTO Adopciones(IdAdopcion,IdUsuario,IdTipoAnimal, Nombre,Detalle,Ubicacion,Sexo,Edad,Estado) VALUES
	(NULL,2,1,'Biscuit', 'Vacunado', '-34.4602262740955;-58.611957365647', 'Macho', 2, true),
	(NULL,2,2,'Nuget', 'Vacunado', '-34.452355;-58.635193', 'Hembra', 4, true),
	(NULL,2,1,'Oreo', 'Desparasitado', '-34.452877;-58.637864', 'Macho', 1, true),
	(NULL,2,2,'Chips', 'Recien nacido', '-34.453549;-58.638089', 'Hembra', 0, true),
	(NULL,2,1,'Roronoa', 'Vacunado', '-34.454929;-58.638872', 'Macho', 3, true),
	(NULL,3,2,'Max', 'Con vacunas, muy amigable', '-34.454929;-58.638872', 'Macho', 3, true),
	(NULL,4,1,'Linlin', 'Sin vacunas', '-34.454929;-58.638872', 'Hembra', 0, true),
	(NULL,5,1,'Tasmania', 'Tranquilo', '-34.454929;-58.638872', 'Macho', 2, true),
	(NULL,6,2,'Elin', 'Vacunada', '-34.454929;-58.638872', 'Hembra', 1, true),
	(NULL,7,2,'Ronin', 'Vacunado', '-34.454929;-58.638872', 'Macho', 1, true),
	(NULL,8,2,'Quimera', 'Nos mudamos y no podemos llevarla.', '-34.454929;-58.638872', 'Hembra', 1, true),
	(NULL,9,1,'Chip', 'Vacunado', '-34.454929;-58.638872', 'Macho', 1, true),
	(NULL,10,2,'Eureka', 'Desparasitada', '-34.454929;-58.638872', 'Hembra', 1, true),
	(NULL,11,1,'Heinze', 'Vacunado', '-34.454929;-58.638872', 'Macho', 1, true),
	(NULL,12,2,'Ain', 'Vacunado', '-34.454929;-58.638872', 'Hembra', 1, true),
	(NULL,13,2,'Enzo', 'Vacunado', '-34.454929;-58.638872', 'Macho', 1, true),
	(NULL,14,1,'Kat', 'Vacunado', '-34.454929;-58.638872', 'Hembra', 2, true),
	(NULL,15,1,'Sam', 'Vacunado', '-34.454929;-58.638872', 'Macho', 3, true),
	(NULL,16,2,'Sasha', 'Vacunado', '-34.454929;-58.638872', 'Hembra', 0, true),
	(NULL,17,1,'Eros', 'Vacunado', '-34.454929;-58.638872', 'Macho', 1, true),
	(NULL,18,2,'Lili', 'Vacunado', '-34.454929;-58.638872', 'Hembra', 4, true),
	(NULL,19,1,'Lennon', 'Vacunado', '-34.454929;-58.638872', 'Macho', 2, true),
	(NULL,20,1,'Selina', 'Vacunado', '-34.454929;-58.638872', 'Hembra', 7, true),
	
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
	(5,9),
	(6,9),
	(7,9),
	(8,9),
	(9,9),
	(10,9),
	(11,9),
	(12,9),
	(13,9),
	(14,9),
	(15,9),
	(16,9),
	(17,9),
	(18,9),
	(19,9),
	(20,9),
	(21,9),
	(22,9),
	(23,9),

INSERT INTO Marcadores (IdMarcador, IdUsuario, IdTipoAnimal , IdImagen, Ubicacion, Descripcion, Estado) VALUES
	(NULL,2,1,10,'-34.450134;-58.638624','Gato perdido',true),
	(NULL,2,2,11,'-34.452417;-58.642508','Perro perdido',true),
	(NULL,2,1,12,'-34.456708;-58.639182','Gato abandonado',true),
	(NULL,2,2,13,'-34.458256;-58.641778','Gato abandonado',true);
	
INSERT INTO Preguntas (Pregunta, IdUsuario, Respuesta) VALUES 
	('¿Como puedo ver una publicacion?', 1, 'Se puede acceder a las publicaciones seleccionando en el mapa el marcador y luego ver detalle.'),
	('¿La aplicación es gratis?', 1, 'Sí. La aplicación está disponible sólo en español y puede descargarse e instalarse sin coste alguno,'),
	('¿Tengo que registrarme?', 1, 'Si, para acceder a las funcionalidades totales de la app.'),
	('¿En qué dispositivos funciona?', 1, 'Solo disponible en los dispositivos con S.O.Android .'),
	('¿Cómo borro la aplicación?', 1, 'Manteniendo pulsado el icono hasta que empiece a moverse y pulsando la X que aparece en la esquina del icono, como con cualquier otra aplicación.'),
	('¿Está la aplicación disponible en todos los países?', 1,'La app solo está disponible en Argentina.'),
	('¿Qué hago si tengo problemas con la aplicación?', 1, 'Si la aplicación se cierra inesperadamente o tienes cualquier otro problema, comprueba en primer lugar que tienes instalada la última versión. Si el problema persiste, puedes ponerte en contacto con el administrador a la dirección de email: admin@mascotapp.com '),
	('¿Cómo accedo a la app?', 1, 'La app posee dos tipos de perfiles de accesos 1) Privado: usuario previamente registrado 2) Público: anónimo el cual tendrá acceso limitado a las prestaciones /funcionalidades.'),
	('¿Cómo Registrarme?', 1,'Para registrarse se deberá completar un formulario el cual solicitada datos personales, datos de contacto de quien suscribe. Se deberá seleccionar el nombre de usuario y password el cual permitirá loguearse a la app. En el caso de los refugios se procederá de igual forma, con la particularidad de la carga de los datos refieren al refugio declarado'),
	('¿Cómo realizar una Adopción?', 1, 'El usuario se deberá loguear y a posterior ingresar a la opción de Agregar Adopción, deberá proceder a sacarle a una foto al animal y puede proceder aceptar dicha foto o puede rechazarla para tomar nueva foto si lo desea. A posterior deberá completar el formulario con los datos del animal a publicar. Como paso final si está todo ok. procederá a presionar el botón agregar para publicar dicha adopción.'),
	('¿Cómo marcar un animal en situación de calle?', 1, 'Para reportar un animal en la calle, se deberá ingresar a la opción agregar marcador y se deberá proceder a cargar los datos de referencia del animal. Luego de aceptado el registro dicho marcador se visualizará en el mapa con el color Rojo. '),
	('¿Solicitar adopciones?', 1,'Al momento de querer realizar una solicitud de adopción, el usuario deberá previamente estar logueado. A través de la opción de solicitud de adopción se realizará una petición a quien publicó un animal.'),
	('¿Notificaciones?', 1, 'A través de notificaciones el usuario podrá disponer de todos los eventos recibidos como aquellos que genere el mismo usuario.'),
	('¿Cómo denunciar un marcador?', 1,'En el caso que un usuario detecte una marcadora indebida, que no cumple con las políticas de resguardo y publicación, podrá proceder a reportar dicho marcador. Cuando la app recibe tres eventos de reporte de marcador, el mismo se baja de la visualización (Mapa)'),
	('¿Cómo hago para visualizar Animales en Adopción o que se encuentran en la calle?', 1, 'Se ingresa al mapa y se debe aplicar filtro, sobre el cual podrá seleccionar Marcadores que se corresponde con los animales reportados en la calle o en su defecto podrá seleccionar aquellos animales que están en adopción.'),
	('¿Cómo hago para visualizar de Refugios de Animales?', 1, 'Se ingresa al mapa y se debe aplicar filtro, sobre el cual podrá seleccionar Refugios de animales disponibles.');

	
INSERT INTO Refugio (IdRefugio, IdUsuario, RazonSocial, Localidad, Direccion, Ubicacion, CodigoPostal, Telefono, FechaCreacion, Estado) VALUES
	(NULL,3,'Campito','Cáceres','Cáceres, Esteban Echeverría, Buenos Aires','-34.454611;-58.635515','1800',123456789,'02-11-2019','Pendiente'),
	(NULL,5,'Adopteros Argentina','Recoleta','Las Heras, Buenos Aires','-34.5518341;-58.4320087','1900',01140893717,'03-11-2019','Pendiente'),
	(NULL,6,'Ayudacan','Salguero','Jerónimo Salguero, Buenos Aires','-34.609192;-58.419967','1700',123455559,'04-11-2019','Pendiente'),
	(NULL,15,'Apre','Gral Pacheco','Av. Constituyentes, Buenos Aires','-34.453331;-58.649052','1700',123456666,'05-11-2019','Pendiente'),
	(NULL,16,'DonCuarto','Gral Pacheco','Olegario Victor Andrade 292, Buenos Aires','-34.459981;-58.627144','1700',123456777,'06-11-2019','Pendiente'),
	(NULL,17,'SfaSA','Gral Pacheco','Gral. Pacheco, Buenos Aires','-34.460769;-58.630510','1700',123455789,'07-11-2019','Pendiente'),
	(NULL,18,'Sams','Gral Pacheco','Chaco 97, Buenos Aires','-34.460601;-58.632559','1700',123446789,'08-11-2019','Pendiente'),
	(NULL,19,'Renatas','Gral Pacheco','Buenos Aires 199, Buenos Aires','-34.455003;-58.627275','1700',121456789,'09-11-2019','Pendiente'),
	(NULL,20,'SanRoque','Los Troncos del Talar','Independencia 498, Buenos Aires','-34.452915;-58.614250','1700',123256789,'10-11-2019','Pendiente'),
	(NULL,21,'Resistir','Los Troncos del Talar','Cnel. Pringles 640, Buenos Aires','-34.450659;-58.615623','1700',123356789,'11-11-2019','Pendiente');
	
INSERT INTO Reportes (IdReporte, IdUsuario, IdMarcador) VALUES
	(NULL,4,1),
	(NULL,4,2);
	
INSERT INTO SolicitudAdopcion (IdAdopcion, IdUsuarioSolicitante, Descripcion, FechaCreacion, Estado) VALUES
	(1,4,'Tengo espacio para cuidarlo','02-11-2019','Pendiente'),
	(2,4,'Tengo espacio para cuidarlo','03-11-2019','Pendiente'),
	(3,4,'Estoy disponible a cuidarlo','04-11-2019','Pendiente'),
	(4,4,'Estoy disponible a cuidarlo','05-11-2019','Pendiente');


/*
If its work, try set VerticalOptions="FillAndExpand" HorizontalOptions="FillAndExpand" on yout ContentView
<ContentPage Title="Map" Icon="IconMap.png" Style="{StaticResource PageStyle}"> 
	<StackLayout x:Name="StackMapLayout" Orientation="Vertical" VerticalOptions="FillAndExpand"> 
		<ActivityIndicator x:Name="ActivityMap" IsRunning="{Binding Busy}" IsVisible="{Binding Busy}" /> 
		<Label x:Name="LabelNoPos" VerticalOptions="Center" IsVisible="false" HorizontalOptions="Center" /> 
		<local:CustomMap x:Name="VesselMap" IsShowingUser="false" IsVisible="false" MapType="Hybrid" /> 
	</StackLayout> 
</ContentPage>

*/
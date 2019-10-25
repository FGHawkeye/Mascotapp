INSERT INTO TipoAnimal (IdTipoAnimal,Descripcion) VALUES 
                (0,'Gato'),
                (1,'Perro');
	
INSERT INTO TipoUsuario (IdTipoUsuario,Descripcion) VALUES 
	(0,'Admin'),
	(1,'Usuario'),
	(2,'Refugio');

INSERT INTO Usuarios (IdUsuario, Usuario, IdTipoUsuario, Contraseña, NombreYApellido, Telefono, Email) VALUES
	(NULL,'LUCAS',1,'lucas123','Lucas Peña', 12345, 'lucas@lucas.com'),
	(NULL,'UsuarioComun',2,'usuario123','Usuario Comun', 12345, 'usuario@comun.com'),
	(NULL,'Refugio',2,'refugio123','Refugio Refugio', 12345, 'refugio@refugio.com');
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int? IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Contraseña { get; set; }
        public string NombreYApellido { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return NombreYApellido;
        }
    }
}

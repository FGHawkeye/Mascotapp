using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class TipoUsuario
    {
        [PrimaryKey, AutoIncrement]
        public int? IdTipoUsuario { get; set; }
        public string Descripcion { get; set; }
    }
}

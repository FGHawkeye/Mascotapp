using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Reportes
    {
        [PrimaryKey, AutoIncrement]
        public int? IdReporte { get; set; }
        public int IdUsuario { get; set; }
        public int IdMarcador { get; set; }
    }
}

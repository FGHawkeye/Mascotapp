using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Domain.Entidades
{
    public class SolicitudAdopcion
    {
        [PrimaryKey]
        public int IdAdopcion { get; set; }
        [PrimaryKey]
        public int IdUsuarioSolicitante { get; set; }
        public string Descripcion { get; set; }
        public string FechaCreacion { get; set; }
        public string Estado { get; set; }

    }
}

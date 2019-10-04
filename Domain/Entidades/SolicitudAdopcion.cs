using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class SolicitudAdopcion
    {
        public int IdAdopcion { get; set; }
        public int IdUsuarioSolicitante { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }

    }
}

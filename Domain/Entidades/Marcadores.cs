using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Marcadores
    {
        public int IdMarcador { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoAnimal { get; set; }
        public int IdImagen { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}

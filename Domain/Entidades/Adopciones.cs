using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Adopciones
    {
        public int IdAdopcion { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoAnimal { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        //coordenadas google maps (latitud, longitud) ej: 110050,100020
        public string Ubicacion { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Estado { get; set; }
    }
}

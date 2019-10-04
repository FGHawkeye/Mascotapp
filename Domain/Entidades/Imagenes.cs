using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Imagenes
    {
        public int IdImagen { get; set; }
        //Path de la imagen ej: /mascotapp/images/imagen.jpg
        public string Imagen { get; set; }
        public string Estado { get; set; }
    }
}

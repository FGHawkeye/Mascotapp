using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class ImagenXAdopcion
    {
        [PrimaryKey]
        public int IdImagen { get; set; }
        public int IdAdopcion { get; set; }
    }
}

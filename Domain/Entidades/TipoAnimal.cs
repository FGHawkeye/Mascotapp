using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class TipoAnimal
    {
        [PrimaryKey, AutoIncrement]
        public int? IdTipoAnimal { get; set; }
        public string Descripcion { get; set; }
    }
}

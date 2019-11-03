using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Preguntas
    {
        [PrimaryKey, AutoIncrement]
        public string Pregunta { get; set; }
        public int IdUsuario { get; set; }
        public string Respuesta { get; set; }
    }
}

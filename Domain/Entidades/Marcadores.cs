using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Marcadores
    {
        [PrimaryKey, AutoIncrement]
        public int? IdMarcador { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoAnimal { get; set; }
        public int IdImagen { get; set; }
        /// <summary>
        /// SIEMPRE GUARDAR LATITUD ';' LONGITUD EN EL MISMO STRING PARA PODER REALIZAR EL .SPLIT() 
        /// </summary>
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public Boolean Estado { get; set; }
    }
}

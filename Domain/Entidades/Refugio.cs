using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entidades
{
    public class Refugio
    {
        [PrimaryKey, AutoIncrement]
        public int? IdRefugio { get; set; }
        public int IdUsuario { get; set; }
        public string RazonSocial { get; set; }
        public string Localidad { get; set; }
        public string Direccion { get; set; }
        //coordenadas google maps (latitud, longitud) ej: 110050,100020
        public string Ubicacion { get; set; }
        public string CodigoPostal { get; set; }
        public long Telefono { get; set; }
        public string FechaCreacion { get; set; }
        public string Estado { get; set; }
    }
}

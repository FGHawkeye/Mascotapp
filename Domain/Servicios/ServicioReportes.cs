using Domain.DB;
using Domain.Entidades;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace Domain.Servicios
{
    public class ServicioReportes
    {
        SQLiteConnection dbConnection;
        public ServicioReportes()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public int GuardarReporte(Reportes reporte)
        {
            return dbConnection.Insert(reporte);
        }

        public bool VerificarLimiteReportes(Marcadores marcador)
        {
            var contadorReportes = dbConnection.Query<Reportes>("SELECT * FROM ").Where(x => x.IdMarcador == marcador.IdMarcador).Count();
            return contadorReportes >= 3;
        }
    }
}

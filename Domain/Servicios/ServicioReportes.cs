using Domain.DB;
using Domain.Entidades;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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

    }
}

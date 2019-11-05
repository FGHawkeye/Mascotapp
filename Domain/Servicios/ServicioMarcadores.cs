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
    public class ServicioMarcadores
    {
        SQLiteConnection dbConnection;
        public ServicioMarcadores()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<Marcadores> ObtenerMarcadores()
        {
            return dbConnection.Query<Marcadores>("Select * From [Marcadores]");
        }

        public int GuardarMarcador(Marcadores marcador)
        {
                return dbConnection.Insert(marcador);
        }

        public Marcadores ObtenerMarcador(int id)
        {
            var query = string.Format("Select * From [Marcadores] where IdMarcador = {0} ", id);
            return dbConnection.Query<Marcadores>(query).FirstOrDefault();
        }

        public void ModificarMarcador(Marcadores marcador)
        {
            dbConnection.Update(marcador);
        }
    }
}

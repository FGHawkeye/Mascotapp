using Domain.DB;
using Domain.Entidades;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Domain.Servicios
{
    class ServicioTipoAnimales
    {
        SQLiteConnection dbConnection;

        public ServicioTipoAnimales()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<TipoAnimal> ObtenerUsuarios()
        {
            return dbConnection.Query<TipoAnimal>("Select * From [TipoAnimales]");
        }

        public int GuardarUsuario(TipoAnimal tipoAnimal)
        {
            return dbConnection.Insert(tipoAnimal);
        }
    }
}

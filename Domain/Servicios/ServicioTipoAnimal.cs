using Domain.DB;
using Domain.Entidades;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Domain.Servicios
{
    public class ServicioTipoAnimal
    {
        SQLiteConnection dbConnection;
        public ServicioTipoAnimal()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<TipoAnimal> ObtenerTipoAnimales()
        {
            return dbConnection.Query<TipoAnimal>("Select * From [TipoAnimal]");
        }

        public int GuardarTipoAnimal(TipoAnimal tipoAnimal)
        {
            dbConnection.Insert(tipoAnimal);
            int pk = dbConnection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            return pk;
        }
    }
}


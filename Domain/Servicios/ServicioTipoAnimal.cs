using Domain.DB;
using Domain.Entidades;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int GuardarModificarTipoAnimal(TipoAnimal tipoAnimal)
        {
            dbConnection.Update(tipoAnimal);
            int pk = tipoAnimal.IdTipoAnimal.Value;
            return pk;
        }

        public TipoAnimal ObtenerTipoAnimal(int id)
        {
            var query = string.Format("Select * From [TipoAnimal] where IdTipoAnimal = {0} ", id);
            return dbConnection.Query<TipoAnimal>(query).FirstOrDefault();
        }

    }
}


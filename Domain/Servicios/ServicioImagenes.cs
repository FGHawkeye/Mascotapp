using Domain.DB;
using Domain.Entidades;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Domain.Servicios
{
    public class ServicioImagenes
    {
        SQLiteConnection dbConnection;
        public ServicioImagenes()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }
        public List<Imagenes> ObtenerImagenes()
        {
            return dbConnection.Query<Imagenes>("Select * From [Imagenes]");
        }
        public int GuardarImagen(Imagenes imagen)
        {
            dbConnection.Insert(imagen);
            int pk = dbConnection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            return pk;
        }

    }
}

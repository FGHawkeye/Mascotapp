using Domain.DB;
using Domain.Entidades;
using SQLite;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Domain.Servicios
{
    public class ServicioImagenXAdopcion
    {   
        SQLiteConnection dbConnection;
        public ServicioImagenXAdopcion()
        {
            dbConnection=DependencyService.Get<IDBInterface>().CreateConnection();
        }
        public List<ImagenXAdopcion> ObtenerImagenXAdopcion(int id)
        {
            return dbConnection.Query<ImagenXAdopcion>("Select * From [ImagenXAdopcion]").Where(x=>x.IdAdopcion==id).ToList();
        }
        public int GuardarImagenXAdopcion(ImagenXAdopcion imagenXAdopcion)
        {
            dbConnection.Insert(imagenXAdopcion);
            int pk = dbConnection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            return pk;
        }
    }
}

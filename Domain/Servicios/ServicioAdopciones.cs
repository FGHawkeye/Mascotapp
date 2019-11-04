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
    public class ServicioAdopciones
    {
        SQLiteConnection dbConnection;
        public ServicioAdopciones()
        {
            dbConnection=DependencyService.Get<IDBInterface>().CreateConnection();
        }
        public List<Adopciones> ObtenerAdopciones()
        {
            return dbConnection.Query<Adopciones>("Select * From [Adopciones]");
        }
        public Adopciones ObtenerAdopcion(int id)
        {
            return dbConnection.Query<Adopciones>("Select * From [Adopciones]").Where(x => x.IdAdopcion== id).SingleOrDefault(); 
        }
        public int GuardarAdopcion(Adopciones adopcion)
        {
            dbConnection.Insert(adopcion);
            int pk = dbConnection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            return pk;
        }
        public int ModificarAdopcion(Adopciones adopcion)
        {
            dbConnection.Update(adopcion);
            int pk = adopcion.IdAdopcion.Value;
            return pk;
        }
    }
}

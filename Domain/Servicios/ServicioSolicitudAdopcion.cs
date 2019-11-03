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
    public class ServicioSolicitudAdopcion
    {
        SQLiteConnection dbConnection;
        public ServicioSolicitudAdopcion()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<Adopciones> ObtenerSolicitudesAdopciones()
        {
            return dbConnection.Query<Adopciones>("Select * From [Adopciones]");
        }

        public Adopciones ObtenerSolicitudAdopcion(int idA, int idU)
        {
            return dbConnection.Query<Adopciones>("Select * from [Adopciones]").Where(x => x.IdAdopcion == idA && x.IdUsuario == idU).FirstOrDefault();
        }
        public List<Adopciones> ObtenerSolicitudesAdopcionUsuario (int idU)
        {
            return dbConnection.Query<Adopciones>("Select * from [Adopciones]").Where(x => x.IdUsuario == idU).ToList();
        }
        public List<Adopciones> ObtenerSolicitudesAdopcion (int idA)
        {
            return dbConnection.Query<Adopciones>("Select * from [Adopciones]").Where(x => x.IdAdopcion== idA).ToList();
        }
        public int ModificarSolicitudAdopcion (Adopciones adopcion)
        {
            dbConnection.Update(adopcion);
            int pk = adopcion.IdAdopcion.Value;
            return pk;
        }
        public int GuardarTipoAnimal(Adopciones adopcion)
        {
            dbConnection.Insert(adopcion);
            int pk = dbConnection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            return pk;
        }
    }
}

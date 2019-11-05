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

        public List<SolicitudAdopcion> ObtenerSolicitudesAdopciones()
        {
            return dbConnection.Query<SolicitudAdopcion>("Select * From [SolicitudAdopcion]");
        }

        public SolicitudAdopcion ObtenerSolicitudAdopcion(int idA, int idU)
        {
            return dbConnection.Query<SolicitudAdopcion>("Select * from [SolicitudAdopcion]").Where(x => x.IdAdopcion == idA && x.IdUsuarioSolicitante == idU).FirstOrDefault();
        }
        public List<SolicitudAdopcion> ObtenerSolicitudesAdopcionUsuario (int idU)
        {
            return dbConnection.Query<SolicitudAdopcion>("Select * from [SolicitudAdopcion]").Where(x => x.IdUsuarioSolicitante== idU).ToList();
        }
        public List<SolicitudAdopcion> ObtenerSolicitudesAdopcion (int idA)
        {
            return dbConnection.Query<SolicitudAdopcion>("Select * from [SolicitudAdopcion]").Where(x => x.IdAdopcion== idA).ToList();
        }
        public int ModificarSolicitudAdopcion (SolicitudAdopcion adopcion)
        {
            dbConnection.Update(adopcion);
            int pk = adopcion.IdAdopcion;
            return pk;
        }
        public int GuardarSolicitudAdopcion(SolicitudAdopcion adopcion)
        {
            dbConnection.Insert(adopcion);
            int pk = dbConnection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            return pk;
        }
    }
}

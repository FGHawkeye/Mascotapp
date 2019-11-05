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
    public class ServicioRefugio
    {
        SQLiteConnection dbConnection;
        public ServicioRefugio()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<Refugio> ObtenerRefugios()
        {
            return dbConnection.Query<Refugio>("Select * From [Refugio]");
        }

        public int RegistrarRefugio(Refugio usuario)
        {
            return dbConnection.Insert(usuario);
        }

        public Refugio ObtenerRefugio(int id)
        {
            return dbConnection.Query<Refugio>("Select * From [Refugio]").Where(X=>X.IdRefugio==id).FirstOrDefault();
        }
        public Refugio ObtenerRefugioUsuario(int id)
        {
            return dbConnection.Query<Refugio>("Select * From [Refugio]").Where(X=>X.IdUsuario==id).FirstOrDefault();
        }
    }
}

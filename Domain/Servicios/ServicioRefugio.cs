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
            return dbConnection.Query<Refugio>("Select * From [Refugio]").Where(x => x.Estado == "Aceptado").ToList();
        }

        public List<Refugio> ObtenerRefugiosPendientes()
        {
            return dbConnection.Query<Refugio>("Select * From [Refugio]").Where(x => x.Estado == "Pendiente").ToList();

        }

        public int RegistrarRefugio(Refugio refugio)
        {
            dbConnection.Insert(refugio);
            int id = dbConnection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            return id;
        }
        public int ObtenerRazonSocial(string razon)
        {
            int i = -1;
            Refugio refugio= dbConnection.Query<Refugio>("Select * From [Refugio]").Where(x => x.RazonSocial == razon).FirstOrDefault();
            if (refugio != null) i = 1;
            return i;
        }
        public int ModificarRefugio(Refugio refugio)
        {
            dbConnection.Update(refugio);
            int pk = refugio.IdRefugio.Value;
            return pk;
        }
        public Refugio ObtenerRefugio(int id)
        {
            //Refugio refugio = dbConnection.Query<Refugio>("Select * From [Refugio]").Where(X => X.IdRefugio == id).FirstOrDefault();
            //string date = dbConnection.Query<Refugio>("Select * From [Refugio]").Where(X => X.IdRefugio == id).FirstOrDefault().FechaCreacion.ToString();
            return dbConnection.Query<Refugio>("Select * From [Refugio]").Where(X => X.IdRefugio == id).FirstOrDefault();
        }
        public Refugio ObtenerRefugioUsuario(int id)
        {
            return dbConnection.Query<Refugio>("Select * From [Refugio]").Where(X=>X.IdUsuario==id).FirstOrDefault();
        }
    }
}

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

        public int RegistrarRefugio(Refugio usuario)
        {
            return dbConnection.Insert(usuario);
        }
        public int ObtenerRazonSocial(string razon)
        {
            int i=-1;
            try{
                i=dbConnection.Query<Refugio>("Select * From [Refugio]").Where(x=>x.RazonSocial==razon).FirstOrDefault().IdRefugio.Value;
            }catch{
                i=-1;
            }
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
            return dbConnection.Query<Refugio>("Select * From [Refugio]").Where(X=>X.IdRefugio==id).FirstOrDefault();
        }
        public Refugio ObtenerRefugioUsuario(int id)
        {
            return dbConnection.Query<Refugio>("Select * From [Refugio]").Where(X=>X.IdUsuario==id).FirstOrDefault();
        }
    }
}

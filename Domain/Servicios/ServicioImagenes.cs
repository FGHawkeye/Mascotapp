using Domain.DB;
using Domain.Entidades;
using SQLite;
using System.Linq;
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
        public Imagenes ObtenerImagen(int id)
        {
            return dbConnection.Query<Imagenes>("Select * From [Imagenes]").Where(x=>x.IdImagen==id).FirstOrDefault();
        }
        public int GuardarImagen(Imagenes imagen)
        {
            dbConnection.Insert(imagen);
            int pk = dbConnection.ExecuteScalar<int>("select last_insert_rowid()");
            return pk;
        }

    }
}

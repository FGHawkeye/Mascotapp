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

        public Imagenes ObtenerImagenDeMarcador(int idMarcador)
        {
            //Reemplaza el "{0}" por el parametro idMarcador
            var query = string.Format(" select imagenes.* from imagenes inner join Marcadores on imagenes.IdImagen = Marcadores.IdImagen where Marcadores.IdMarcador = {0} ", idMarcador); 
            return dbConnection.Query<Imagenes>(query).FirstOrDefault();
        }

        public int GuardarImagen(Imagenes imagenes)
        {
            return dbConnection.Insert(imagenes);
        }

    }
}

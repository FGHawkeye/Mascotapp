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
        {
            //Reemplaza el "{0}" por el parametro idMarcador
            var query = string.Format(" select imagenes.* from imagenes inner join Marcadores on imagenes.IdImagen = Marcadores.IdImagen where Marcadores.IdMarcador = {0} ", idMarcador); 
            return dbConnection.Query<Imagenes>(query).FirstOrDefault();
        }
        public int GuardarImagen(Imagenes imagen)
        {
            dbConnection.Insert(imagen);
            int pk = dbConnection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            return pk;
        }

    }
}

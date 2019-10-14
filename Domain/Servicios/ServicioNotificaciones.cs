using Domain.DB;
using Domain.Entidades;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Domain.Servicios
{
    public class ServicioUsuarios
    {
        SQLiteConnection dbConnection;
        public ServicioUsuarios()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return dbConnection.Query<Usuario>("Select * From [Usuarios]");
        }

        public int GuardarUsuario(Usuario usuario)
        {
            return dbConnection.Insert(usuario);
        }
    }
}

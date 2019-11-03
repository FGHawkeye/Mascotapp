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
    public class ServicioUsuarios
    {
        SQLiteConnection dbConnection;
        public ServicioUsuarios()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return dbConnection.Query<Usuario>("Select * From [Usuario]");
        }

        public int RegistrarUsuario(Usuario usuario)
        {
            return dbConnection.Insert(usuario);
        }


        public Usuario ValidarUsuario (Usuario usuario)
        {
            return dbConnection.Query<Usuario>("Select * From [Usuario] where NombreUsuario ='" + usuario.NombreUsuario + "' and Contraseña ='" + usuario.Contraseña + "'").FirstOrDefault();

        }

        

    }
}

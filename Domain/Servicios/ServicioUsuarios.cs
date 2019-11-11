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
            dbConnection.Insert(usuario);
            int id= dbConnection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            return id;
        }

        public Usuario ObtenerUsuario(int id)
        {
            return dbConnection.Query<Usuario>("Select * From [Usuario]").Where(X=>X.IdUsuario==id).FirstOrDefault();
        }

        public Usuario ValidarUsuario (Usuario usuario)
        {
            return dbConnection.Query<Usuario>("Select * From [Usuario] where NombreUsuario ='" + usuario.NombreUsuario + "' and Contraseña ='" + usuario.Contraseña + "'").FirstOrDefault();

        }
        public int ValidarUsuarioExistente(string nomusuario)
        {
            int i = -1;

            Usuario usuario = dbConnection.Query<Usuario>("Select * From [Usuario]").Where(x => x.NombreUsuario == nomusuario).FirstOrDefault();
          
            if (usuario != null) i = 1;
            return i;
        }


    }
}

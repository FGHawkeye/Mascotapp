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
    public class ServicioPreguntasFrecuentes
    {
        SQLiteConnection dbConnection;
        public ServicioPreguntasFrecuentes()
        {
            dbConnection=DependencyService.Get<IDBInterface>().CreateConnection();
        }
        public List<Preguntas> ObtenerPreguntas()
        {
            return dbConnection.Query<Preguntas>("Select * From [Preguntas]").ToList();
        }
        public Preguntas ObtenerPregunta(string preg)
        {
            return dbConnection.Query<Preguntas>("Select * From [Preguntas]").Where(x => x.Pregunta== preg).SingleOrDefault(); 
        }
        public int GuardarPregunta(Preguntas pregunta)
        {
            dbConnection.Insert(pregunta);
            int pk = dbConnection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            return pk;
        }
        public string ModificarPregunta(Preguntas pregunta)
        {
            dbConnection.Update(pregunta);
            string pk = pregunta.Pregunta;
            return pk;
        }
    }
}

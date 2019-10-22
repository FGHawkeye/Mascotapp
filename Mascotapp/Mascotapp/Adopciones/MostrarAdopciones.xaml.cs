using System;
using Domain.Entidades;
using Domain.Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mascotapp.NavigationMenu;


namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarAdopciones : ContentPage
    {
        #region BindableObjects
        List<TipoAnimal> _lstTipoAnimal = new List<TipoAnimal>();
        #endregion

        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        private ServicioImagenes servicioImagenes = new ServicioImagenes();
        private ServicioImagenXAdopcion servicioImagenXAdopcion = new ServicioImagenXAdopcion();
        public MostrarAdopciones()
        {
            InitializeComponent();
            CargarElementos();
        }
        public void CargarElementos()
        {
            List<Adopciones> adopciones = servicioAdopciones.ObtenerAdopciones();
            foreach(Adopciones item in adopciones)
            {
                Entry entry = new Entry
                {
                    Text = item.Nombre,
                    ClassId = item.IdAdopcion.ToString(),
                };
                Mostrar.Children.Add(entry);
            }
        }
    }
}
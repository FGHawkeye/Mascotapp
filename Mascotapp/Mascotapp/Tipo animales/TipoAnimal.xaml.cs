using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotapp.Tipo_animales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoAnimales : ContentPage
    {
        #region BindableObjects
        List<TipoAnimal> _lstTipoAnimal = new List<TipoAnimal>();
        #endregion

        private ServicioTipoAnimales serviceTipoAnimal = new ServicioTipoAnimales();

        public TipoAnimales()
        {
            InitializeComponent();
            CargarControles();
            CargarEventos();
        }

        void CargarControles()
        {
            CargarTipoAnimales();
        }

        void CargarEventos()
        {
            //btnCamera.Clicked += btnCamera_Clicked;
            btnAgregar.Clicked += btnAgregar_Clicked;
        }
    }
}
using Domain.Entidades;
using Domain.Servicios;
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
    public partial class TipoDeAnimal : ContentPage
    {
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private List<Domain.Entidades.TipoAnimal> _lstTipoAnimal;

        public TipoDeAnimal()
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
            btnAgregar.Clicked += btnAgregar_Clicked;
            btnModificar.Clicked += btnModificar_Clicked;
        }

        void CargarTipoAnimales()
        {
            _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            pckTipoAnimal.ItemsSource = _lstTipoAnimal;
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
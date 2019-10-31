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
        private ServicioTipoAnimal servicieTipoAnimal = new ServicioTipoAnimal();
        private List<Domain.Entidades.TipoAnimal> _lstTipoAnimal;

        public TipoDeAnimal()
        {
            InitializeComponent();
            CargarControles();
            CargarElementos();
        }

        void CargarControles()
        {
            CargarTipoAnimales();
        }

        void CargarTipoAnimales()
        {
            _lstTipoAnimal = servicieTipoAnimal.ObtenerTipoAnimales();
            pckTipoDeAnimal.ItemsSource = _lstTipoAnimal;
        }

        void CargarElementos()
        {
            btnAgregar.Clicked += btnAgregar_Clicked;
            btnModificar.Clicked += btnModificar_Clicked;
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new NuevoTipoAnimal());
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ModificarTipo());
        }
    }
}
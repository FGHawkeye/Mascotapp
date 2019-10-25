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
    public partial class ModificarTipo : ContentPage
    {
        public ModificarTipo()
        {
            InitializeComponent();
            CargarEventos();
            CargarControles();
        }

        void CargarEventos()
        {
            btnGuardar.Clicked += Guardar_Clicked;
            btnCancelar.Clicked += Cancelar_Clicked;
        }

        void CargarControles()
        {
            CargarTipoAnimales();
        }

        void CargarTipoAnimales()
        {
            _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            pckTipoAnimal.ItemsSource = _lstTipoAnimal;
        }
    }
}
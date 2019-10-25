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
    public partial class TipoAnimal : ContentPage
    {
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();

        public NuevoTipo()
        {
            InitializeComponent();
            CargarEventos();
        }

        public void CargarEventos()
        {
            btnGuardar.Clicked += Guardar_Clicked;
            btnCancelar.Clicked += Cancelar_Clicked;
        }

        private void Guardar_Clicked(object sender, EventArgs e)
        {
            var tipoanimal = new TipoAnimales();
            tipoanimal.txtDescripcion = 1; //pckTipoAnimal.SelectedItem.
            tipoanimal.txtDescripcion = txtDescripcion.Text;
            serviceTipoAnimal.GuardarTipoAnimal(tipoanimal);
        }
    }
}
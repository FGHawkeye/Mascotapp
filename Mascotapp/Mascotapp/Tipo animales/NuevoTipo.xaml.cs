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

        public TipoAnimal()
        {
            InitializeComponent();
            CargarEvento();
        }

        void CargarEvento()
        {
            btnGuardar.Clicked += btnGuardar_Clicked;
            btnCancelar.Clicked += btnCancelar_Clicked;
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var tipoAnimal = new Domain.Entidades.TipoAnimal();
            tipoAnimal.IdTipoAnimal = 1;//pckTipoAnimal.SelectedItem.
            tipoAnimal.Descripcion = txtNuevaDescripcion.Text;
            serviceTipoAnimal.GuardarTipoAnimal(tipoAnimal);
        }

        public void btnCancelar_Clicked(object sender, EventArgs e)
        {
            ModificarTipo();
        }
    }
}
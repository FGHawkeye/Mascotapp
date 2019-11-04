using Domain.Entidades;
using Domain.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotapp.Tipo_animales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModificarTipo : ContentPage
    {
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private List<Domain.Entidades.TipoAnimal> _lstTipoAnimal;

        public ModificarTipo()
        {
            InitializeComponent();
            CargarControles();
            CargarEventos();
        }

        void CargarEventos()
        {
            btnGuardar.Clicked += btnGuardar_Clicked;
            btnCancelar.Clicked += btnCancelar_Clicked;
        }

        void CargarControles()
        {
            CargarTipoAnimales();
        }

        void CargarTipoAnimales()
        {
            /*_lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            pckTipoAnimal.ItemsSource = _lstTipoAnimal;*/

            _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            foreach (TipoAnimal tipo in _lstTipoAnimal)
            {
                pckTipoAnimal.Items.Add(tipo.Descripcion);
            }
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var tipoAniaml = new Domain.Entidades.TipoAnimal();
            tipoAniaml.IdTipoAnimal = 1;//pckTipoAnimal.SelectedItem.
            tipoAniaml.Descripcion = txtDescripcion.Text;
            serviceTipoAnimal.GuardarTipoAnimal(tipoAniaml);
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
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
            CargarEventos();
            CargarControles();
            
        }

        void CargarEventos()
        {
            btnGuardar.Clicked += btnGuardar_Clicked;
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
            txtTipoAnimal.Text = pckTipoAnimal.SelectedItem.ToString();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (ValidarForm())
                {
                    var tipoAniaml = new Domain.Entidades.TipoAnimal();
                    tipoAniaml.IdTipoAnimal = 1;//pckTipoAnimal.SelectedItem.
                    tipoAniaml.Descripcion = txtTipoAnimal.Text;
                    serviceTipoAnimal.GuardarModificarTipoAnimal(tipoAniaml);

                    await DisplayAlert("Tipo de Animal", "Se modifico el Tipo de Animal correctamente!", "OK");
                    await App.MasterD.Detail.Navigation.PopToRootAsync();
                }
                else
                {
                    await DisplayAlert("Tipo de Animal", "Falta completar datos.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Tipo de Animal", "Hubo un problema, vuelva a intentar mas tarde.", "OK");
                Console.WriteLine(ex);
            }
        }

        public bool ValidarForm()
        {
            bool validate = true;
            /*if (pckTipoAnimal.SelectedItem == null)
            {
                validate = false;
            }
            else */
            if (txtTipoAnimal.Text == "" || txtTipoAnimal.Text == null)
            {
                validate = false;
            }
            return validate;
        }
    }
}
using Domain.Entidades;
using Domain.Servicios;
using Mascotapp.NavigationMenu;
using Mascotapp.Visualizar_mapa;
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
    public partial class NuevoTipoAnimal : ContentPage
    {
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        //private List<TipoAnimal> _lstTipoAnimal;

        public NuevoTipoAnimal()
        {
            InitializeComponent();
            //CargarTipoAnimales();
            CargarEvento();
        }

        void CargarEvento()
        {
            btnGuardar.Clicked += btnGuardar_Clicked;
        }

        /*void CargarTipoAnimales()
        {
            _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            pckTipoAnimal.ItemsSource = _lstTipoAnimal;

            _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            foreach (TipoAnimal tipo in _lstTipoAnimal)
            {
                pckTipoAnimal.Items.Add(tipo.Descripcion);
            }
        }*/

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (ValidarForm())
                {
                    var tipoAnimal = new Domain.Entidades.TipoAnimal();
                    tipoAnimal.IdTipoAnimal = 1; // NUEVO TIPO, BUSCAR EN TODA LA BD Y AGREGAR UNOS MAS
                    if (txtNuevoTipoAnimal.Text == txtNuevoTipoAnimal2.Text)
                    {
                        tipoAnimal.Descripcion = txtNuevoTipoAnimal.Text;
                        serviceTipoAnimal.GuardarTipoAnimal(tipoAnimal);

                        await DisplayAlert("Tipo de Animal", "¡Se agrego el Tipo de Animal correctamente!", "OK");
                        await App.MasterD.Detail.Navigation.PopToRootAsync();
                    }
                    else
                    {
                        txtNuevoTipoAnimal2.Text = "";
                        await DisplayAlert("Tipo de Animal", "Los textos no son igual.", "OK");
                    }
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
            if (txtNuevoTipoAnimal.Text == "" || txtNuevoTipoAnimal.Text == null)
            {
                validate = false;
            }
            else if(txtNuevoTipoAnimal2.Text == "" || txtNuevoTipoAnimal2.Text == null)
            {
                validate = false;
            }
            return validate;
        }
    }
}
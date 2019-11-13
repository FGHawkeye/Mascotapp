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
using System.IO;
using Plugin.Geolocator;
using Plugin.Media.Abstractions;

namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerTipoAnimal : ContentPage
    {
        List<TipoAnimal> _lstTipoAnimal = new List<TipoAnimal>();
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        
        public VerTipoAnimal()
        {
            InitializeComponent();
            CargarEventos();
        }

        public void CargarTipoAnimal()
        {
            List<TipoAnimal> _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            pckAnimal.ItemsSource = _lstTipoAnimal;
            pckAnimal.ItemDisplayBinding = new Binding("Descripcion");
        }

        public void CargarEventos()
        {
            btnModificar.Clicked += Modificar_Clicked;
            btnAgregar.Clicked += Agregar_Clicked;
            CargarTipoAnimal();
            pckAnimal.SelectedIndexChanged += Pck_Clicked;
        }

        private async void Agregar_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new AgregarTipoAnimal());
        }

        private void Pck_Clicked(object sender, EventArgs e)
        {
            TipoAnimal tipoAnimal = (TipoAnimal)pckAnimal.ItemsSource[pckAnimal.SelectedIndex];
            txtTipoAnimal.Text=tipoAnimal.Descripcion;
        }

        private async void Modificar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string mensaje= ValidarForm();
                if (mensaje=="")
                {
                    TipoAnimal tipoAnimal = (TipoAnimal)pckAnimal.ItemsSource[pckAnimal.SelectedIndex];
                    tipoAnimal.Descripcion=txtTipoAnimal.Text;
                    serviceTipoAnimal.ModificarTipoAnimal(tipoAnimal);
                    await DisplayAlert("Tipo de animal", "Se modifico correctamente!", "OK");
                    await App.MasterD.Detail.Navigation.PopToRootAsync();
                }
                else
                {
                    await DisplayAlert("Tipo de animal", mensaje, "OK");
                }
            }catch(Exception ex)
            {
                await DisplayAlert("Tipo de animal", "Hubo un problema, vuelva a intentar mas tarde.", "OK");
                Console.WriteLine(ex);
            }
            
        }

        public string ValidarForm()
        {
            string msg = "";
            //agregar mensajes faltantes
            if (pckAnimal.SelectedItem == null)
            {
                msg = "Falta seleccionar el tipo de animal a modificar.";
            }
            else if (txtTipoAnimal.Text == "" || txtTipoAnimal.Text == null)
            {
                msg = "Falta ingresar una descripcion.";
            }
            else if(serviceTipoAnimal.ComprobarTipoAnimal(txtTipoAnimal.Text)>0)
            {
                msg="El tipo de animal ingresado ya existe.";
            }
            return msg;
        }
    }
}
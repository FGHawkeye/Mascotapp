using Domain.Entidades;
using Domain.MapRenderer;
using Domain.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Mascotapp.Visualizar_mapa
{
    public partial class Mapa : ContentPage
    {
        
        ServicioMarcadores servicioMarcadores = new ServicioMarcadores();
        ServicioAdopciones servicioAdopciones = new ServicioAdopciones();

        public Mapa()
        {
            InitializeComponent();
            CargarMapa();
            CargarMarcadores();
            CargarAdopciones();
            VerificaLogeado();

        }

        private void CargarAdopciones()
        {
            var adopciones = servicioAdopciones.ObtenerAdopciones();

            foreach (var adopcion in adopciones)
            {
                var pin = GenerarMarcador(adopcion.Nombre, adopcion.Ubicacion, "Adopcion");
                map_Mapa.Pins.Add(pin);
                map_Mapa.CustomPins.Add(pin);
            }
        }

        private void VerificaLogeado()
        {
            if (MainPage.UsuarioRegristrado == null)
            {
                Logeado.Text = "Ingresar";
            }
            else
            {
                Logeado.Text = MainPage.UsuarioRegristrado.NombreUsuario;
            }


     
        }

        private void CargarMarcadores()
        {
            var marcadores = servicioMarcadores.ObtenerMarcadores();
            foreach (var marcador in marcadores)
            {
                var pin = GenerarMarcador(marcador.Descripcion, marcador.Ubicacion, "Marcador");
                map_Mapa.CustomPins.Add(pin);
                map_Mapa.Pins.Add(pin);             
            }
        }

        private CustomPin GenerarMarcador(string descripcion, string ubicacion, string tipoMarcador)
        {
            //Primero siempre latitud
            var arrayUbicacion = ubicacion.Split(';');

            var pin = new CustomPin()
            {
                Position = new Position(Convert.ToDouble(arrayUbicacion[0]), Convert.ToDouble(arrayUbicacion[1])),
                Label = descripcion,
                Url = "http://xamarin.com/about/",
                MarkerType = tipoMarcador
            };
            return pin;
        }

        void CargarMapa()
        {
            map_Mapa.MoveToRegion(Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(
                    new Xamarin.Forms.Maps.Position(-34.456668, -58.624652),
                    Xamarin.Forms.Maps.Distance.FromKilometers(5)
                )
            );

            map_Mapa.IsShowingUser = true;
            map_Mapa.CustomPins = new List<CustomPin>();
        }
        private async void Logeado_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new Login.Login());
        }
    }
}
using Domain.Entidades;
using Domain.MapRenderer;
using Domain.Servicios;
using Plugin.Geolocator;
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

        private ServicioMarcadores servicioMarcadores = new ServicioMarcadores();
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        private ServicioRefugio servicioRefugio = new ServicioRefugio();
        private ServicioImagenes servicioImagenes = new ServicioImagenes();
        private ServicioImagenXAdopcion servicioImagenXAdopcion = new ServicioImagenXAdopcion();
        private string filtroSeleccionado = "";


        public Mapa()
        {
            InitializeComponent();
            CargarMapa();
            CargarEventos();
            VerificaLogeado();
        }

        private void CargarEventos()
        {
            btnFiltro.Clicked += btnFiltro_Clicked;
            btnQuitarFiltro.Clicked += btnQuitarFiltro_Clicked;
        }

        private void btnQuitarFiltro_Clicked(object sender, EventArgs e)
        {
            filtroSeleccionado = "";
            pckFiltro.SelectedItem = "";
            CargarPines();
        }

        private void btnFiltro_Clicked(object sender, EventArgs e)
        {
            if (pckFiltro.SelectedItem != null)
            {
                filtroSeleccionado = pckFiltro.SelectedItem.ToString();
                CargarPines();
            }
        }

        private void CargarPines()
        {
            map_Mapa.CustomPins.Clear();
            map_Mapa.Pins.Clear();
            CargarMarcadores();
            CargarAdopciones();
            CargarRefugios();
 
        }

        private void CargarAdopciones()
        {
            if (filtroSeleccionado == "Adopciones" || string.IsNullOrEmpty(filtroSeleccionado))
            {
                var adopciones = servicioAdopciones.ObtenerAdopciones();

                foreach (var adopcion in adopciones)
                {
                    var pin = GenerarMarcador(adopcion.Nombre, adopcion.Ubicacion, "Adopcion", adopcion.IdAdopcion.Value, ObtenerPathImagen(ObtenerImagenIdAdopcion(adopcion.IdAdopcion.Value)));
                    map_Mapa.Pins.Add(pin);
                    map_Mapa.CustomPins.Add(pin);
                }
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
            if (filtroSeleccionado == "Marcadores" || string.IsNullOrEmpty(filtroSeleccionado))
            {
                var marcadores = servicioMarcadores.ObtenerMarcadores();
                foreach (var marcador in marcadores)
                {
                    var pin = GenerarMarcador(marcador.Descripcion, marcador.Ubicacion, "Marcador", marcador.IdMarcador.Value, ObtenerPathImagen(marcador.IdImagen));
                    map_Mapa.CustomPins.Add(pin);
                    map_Mapa.Pins.Add(pin);
                }
            }

        }

        private void CargarRefugios()
        {
            if (filtroSeleccionado == "Refugios" || string.IsNullOrEmpty(filtroSeleccionado))
            {
                var refugios = servicioRefugio.ObtenerRefugios();
                foreach (var refugio in refugios)
                {
                    var pin = GenerarMarcador(refugio.RazonSocial, refugio.Ubicacion, "Refugio", refugio.IdRefugio.Value);
                    map_Mapa.CustomPins.Add(pin);
                    map_Mapa.Pins.Add(pin);
                }
            }
        }


        private CustomPin GenerarMarcador(string descripcion, string ubicacion, string tipoMarcador, int id, string iconPath = "")
        {
            //Primero siempre latitud
            var arrayUbicacion = ubicacion.Split(';');

            var pin = new CustomPin()
            {
                Position = new Position(Convert.ToDouble(arrayUbicacion[0]), Convert.ToDouble(arrayUbicacion[1])),
                Label = descripcion,
                MarkerType = tipoMarcador,
                IdPin = id,
                IconPath = iconPath
            };
            return pin;
        }

        async void CargarMapa()
        {
            //map_Mapa.MoveToRegion(Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(
            //        new Xamarin.Forms.Maps.Position(-34.456668, -58.624652),
            //        Xamarin.Forms.Maps.Distance.FromKilometers(5)
            //    )
            //);
            var currentPosition = await CrossGeolocator.Current.GetLastKnownLocationAsync();
            map_Mapa.MoveToRegion(Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(
                    new Position(currentPosition.Latitude, currentPosition.Longitude),
                    Xamarin.Forms.Maps.Distance.FromKilometers(5)
                )
            );
            map_Mapa.IsShowingUser = true;
            map_Mapa.CustomPins = new List<CustomPin>();
        }

        protected override void OnAppearing()
        {
            CargarPines();
        }

        private string ObtenerPathImagen(int idImagen)
        {
            var imagen = servicioImagenes.ObtenerImagen(idImagen);
            return imagen.Imagen;
        }

        private int ObtenerImagenIdAdopcion(int idAdopcion)
        {
            var imagenId = servicioImagenXAdopcion.ObtenerImagenXAdopcion(idAdopcion).FirstOrDefault().IdImagen;
            return imagenId;
        }
        private async void Logeado_Clicked(object sender, EventArgs e)
        {
            if (MainPage.UsuarioRegristrado == null)
            {
                App.MasterD.IsPresented = false; //isVisible = false
                await App.MasterD.Detail.Navigation.PushAsync(new Login.Login());
            }

        }

    }
}
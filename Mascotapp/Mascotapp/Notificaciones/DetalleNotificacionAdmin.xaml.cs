using System;
using Domain.Entidades;
using Domain.Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleNotificacionAdmin : ContentPage
    {
        private ServicioRefugio servicioRefugio = new ServicioRefugio();
        private ServicioUsuarios servicioUsuario = new ServicioUsuarios();
        private Refugio refugio;
        public DetalleNotificacionAdmin(int idRef)
        {
            InitializeComponent();
            CargarElementos(idRef);
        }

        public void CargarElementos(int idRef)
        {
            btnAceptar.Clicked+=btnAceptar_Clicked;
            btnRechazar.Clicked+=btnRechazar_Clicked;

            refugio = servicioRefugio.ObtenerRefugio(idRef);
            Usuario usuario = servicioUsuario.ObtenerUsuario(refugio.IdUsuario);
            txtApellido.Text = usuario.Apellido;
            txtNombre.Text = usuario.Nombre;
            txtRazonSocial.Text = refugio.RazonSocial;
            txtDireccion.Text = refugio.Direccion;
            txtCP.Text = refugio.CodigoPostal;
            txtLocalidad.Text = refugio.Localidad;
            //txtFecha.Text = refugio.FechaCreacion.ToString("YYYY-MM-DD HH:MM:SS.SSS");
            txtFecha.Text = refugio.FechaCreacion.ToString();
            txtTelefono.Text = usuario.Telefono.ToString();
            CargarMapa(refugio.Ubicacion);
            CargarRefugio(refugio);
        }

        public void btnAceptar_Clicked(object sender, EventArgs e)
        {
            ModificarSolicitudUsuario("Aceptado");
        }
        
        public void btnRechazar_Clicked(object sender, EventArgs e)
        {
            ModificarSolicitudUsuario("Rechazado");
        }

        private async void ModificarSolicitudUsuario(string estado)
        {
            refugio.Estado=estado;
            servicioRefugio.ModificarRefugio(refugio);
            await DisplayAlert("Solicitud Refugio", "Se a "+estado+" el refugio con exito", "OK");
            await App.MasterD.Detail.Navigation.PopToRootAsync();
        }

        private async void CargarMapa(string ubicacion)
        {
            //map_Mapa.MoveToRegion(Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(
            //        new Xamarin.Forms.Maps.Position(-34.456668, -58.624652),
            //        Xamarin.Forms.Maps.Distance.FromKilometers(5)
            //    )
            //);
            var arrayUbicacion = ubicacion.Split(';');
            map_Mapa.MoveToRegion(Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(
                    new Position(Convert.ToDouble(arrayUbicacion[0]), Convert.ToDouble(arrayUbicacion[1])),
                    Xamarin.Forms.Maps.Distance.FromKilometers(5)
                )
            );
            map_Mapa.IsShowingUser = true;
            map_Mapa.CustomPins = new List<CustomPin>();
        }

        private void CargarRefugio(Refugio refugio)
        {
            var pin = GenerarMarcador(refugio.RazonSocial, refugio.Ubicacion, "Refugio", refugio.IdRefugio.Value);
            map_Mapa.CustomPins.Add(pin);
            map_Mapa.Pins.Add(pin);
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
    }
}
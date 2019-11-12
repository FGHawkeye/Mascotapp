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
        private ServicioEmail servicioEmail = new ServicioEmail();
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
            txtFecha.Text = refugio.FechaCreacion.ToString(@"MM\/dd\/yyyy HH:mm");
            txtTelefono.Text = usuario.Telefono.ToString();
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

            try
            {
                var usuarioSolicitante = servicioUsuario.ObtenerUsuario(refugio.IdUsuario);
                var datosEmail = new DatosEmail("Actualizacion de estado, solicitud de refugio",
                    "La solicitud de refugio que usted realizo por el refugio " + refugio.RazonSocial + " se encuentra en estado " + estado.ToUpper(),
                    usuarioSolicitante.Email);

                servicioEmail.EnviarEmail(datosEmail);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }


            await DisplayAlert("Solicitud Refugio", "Se ha "+estado+" el refugio con exito", "OK");
            await App.MasterD.Detail.Navigation.PopToRootAsync();
        }
    }
}
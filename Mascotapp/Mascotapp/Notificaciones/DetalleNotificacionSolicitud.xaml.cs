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
    public partial class DetalleNotificacionSolicitud : ContentPage
    {
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        private ServicioSolicitudAdopcion servicioSolicitudAdopcion = new ServicioSolicitudAdopcion();
        private ServicioUsuarios servicioUsuario = new ServicioUsuarios();
        private ServicioEmail servicioEmail = new ServicioEmail();
        private SolicitudAdopcion solicitudAdopcion;
        private Adopciones adopciones;
        public DetalleNotificacionSolicitud(int idAd, int idSol)
        {
            InitializeComponent();
            CargarElementos(idSol,idAd);
        }

        public void CargarElementos(int idSol,int idAd){
            btnAceptar.Clicked+=btnAceptar_Clicked;
            btnRechazar.Clicked+=btnRechazar_Clicked;

            solicitudAdopcion=servicioSolicitudAdopcion.ObtenerSolicitudAdopcion(idAd,idSol);
            adopciones=servicioAdopciones.ObtenerAdopcion(idAd);
            Usuario usuario=servicioUsuario.ObtenerUsuario(idSol);
            txtApellido.Text=usuario.Apellido;
            txtNombre.Text= usuario.Nombre;
            txtUsuario.Text=usuario.NombreUsuario;
            txtTelefono.Text = usuario.Telefono.ToString();
            txtMascota.Text=adopciones.Nombre;
            txtDetalle.Text=solicitudAdopcion.Descripcion;
        }

        public void btnAceptar_Clicked(object sender, EventArgs e)
        {
            adopciones.Estado = false;
            servicioAdopciones.BajaAdopcion(adopciones);
            ModificarSolicitudUsuario("Aceptado");
        }
        
        public void btnRechazar_Clicked(object sender, EventArgs e)
        {
            ModificarSolicitudUsuario("Rechazado");
        }

        private async void ModificarSolicitudUsuario(string estado)
        {
            solicitudAdopcion.Estado=estado;
            
            servicioSolicitudAdopcion.ModificarSolicitudAdopcion(solicitudAdopcion);

            try
            {
                var usuarioSolicitante = servicioUsuario.ObtenerUsuario(solicitudAdopcion.IdUsuarioSolicitante);

                var datosEmail = new DatosEmail("Actualizacion de estado, solicitud de adopcion",
                    "La solicitud de adopcion que usted realizo por " + adopciones.Nombre + " se encuentra en estado " + estado.ToUpper(),
                    usuarioSolicitante.Email);

                servicioEmail.EnviarEmail(datosEmail);
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }

            await DisplayAlert("Adopciones", "Se "+estado+" la solicitud con exito", "OK");
            await App.MasterD.Detail.Navigation.PopToRootAsync();
        }
    }
}
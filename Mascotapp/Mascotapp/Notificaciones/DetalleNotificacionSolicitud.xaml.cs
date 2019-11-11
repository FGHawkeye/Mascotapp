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
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        private ServicioSolicitudAdopcion servicioSolicitudAdopcion = new ServicioSolicitudAdopcion();
        private ServicioUsuarios servicioUsuario = new ServicioUsuarios();
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
            await DisplayAlert("Adopciones", "Se "+estado+" la solicitud con exito", "OK");
            await App.MasterD.Detail.Navigation.PopToRootAsync();
        }
    }
}
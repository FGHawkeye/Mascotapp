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
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        private ServicioSolicitudAdopcion servicioSolicitudAdopcion = new ServicioSolicitudAdopcion();
        private ServicioUsuarios servicioUsuario = new ServicioUsuarios();
        private SolicitudAdopcion solicitudAdopcion;
        public DetalleNotificacionAdmin(int idRef)
        {
            InitializeComponent();
            CargarElementos(idRef);
        }

        public void CargarElementos(int idRef){
            btnAceptar.Clicked+=btnAceptar_Clicked;
            btnRechazar.Clicked+=btnRechazar_Clicked;
            /*//solicitudRefugio=servicioSolicitudRefugio.ObtenerSolicitudAdopcion(idAd,idSol);
            //Adopciones adopciones=servicioAdopciones.ObtenerAdopcion(idAd);
            //Usuario usuario=servicioUsuario.ObtenerUsuario(idSol);
            var apellidoN=usuario.NombreYApellido.Split(new char[0]);
            txtApellido.Text=apellidoN[0];
            txtNombre.Text=apellidoN[1];
            txtUsuario.Text=usuario.NombreUsuario;
            txtMascota.Text=adopciones.Nombre;
            txtDetalle.Text=solicitudAdopcion.Descripcion;*/
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
            solicitudAdopcion.Estado=estado;
            servicioSolicitudAdopcion.ModificarSolicitudAdopcion(solicitudAdopcion);
            await DisplayAlert("Adopciones", "Se "+estado+" la solicitud con exito", "OK");
            await App.MasterD.Detail.Navigation.PopToRootAsync();
        }
    }
}
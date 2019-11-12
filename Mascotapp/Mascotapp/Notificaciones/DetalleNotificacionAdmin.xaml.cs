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
            //YYYY-MM-DD HH:MM:SS.SSS
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
    }
}
using Mascotapp.Marcador_animales;
using Mascotapp.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotapp.NavigationMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private async void BtnAgregarMarcador_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new AltaMarcador());
        }

        private async void BtnAgregarAdopcion_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new AgregarAdopcion());
        }

        private async void BtnMostrarAdopciones_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new MostrarAdopciones());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new Login.Login());
        }

        private async void BtnRegistro_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new Registro.Registro());
        }

        //private async void BtnSolicitudAdopcion_Clicked(object sender, EventArgs e)
        //{
        //    App.MasterD.IsPresented = false; //isVisible = false
        //    await App.MasterD.Detail.Navigation.PushAsync(new VisualizarSolicitud(3));
        //}

        private async void BtnNotificaciones_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new Notificaciones());
        }

        private async void BtnPreguntasFrecuentes_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new PreguntasFrecuentes());
        }

        private async void BtnSolicitudAdopcionAdmin_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new NotificacionesAdmin());
        }
    }
}
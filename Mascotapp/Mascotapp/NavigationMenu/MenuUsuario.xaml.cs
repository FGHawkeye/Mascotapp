using Mascotapp.Marcador_animales;
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
    public partial class MenuUsuario : ContentPage
    {
        public MenuUsuario()
        {
            InitializeComponent();
        }

        private async void BtnAgregarMarcador_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new AltaMarcador());
        }

        private async void BtnMostrarAdopciones_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new MostrarAdopciones());
        }

        private async void BtnNotificaciones_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new Notificaciones());
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Cerrar sesion", "¿Esta seguro de cerrar sesion?", "Si", "No");
            if (rta)
            {
                MainPage.UsuarioRegristrado = null;
                App.MasterD.Master = new Master();
            }
        }
    }
}
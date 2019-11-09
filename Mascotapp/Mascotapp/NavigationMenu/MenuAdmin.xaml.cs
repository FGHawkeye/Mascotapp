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
    public partial class MenuAdmin : ContentPage
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }


        private async void BtnSolicitudRefugioAdmin_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new NotificacionesAdmin());
        }

        private async void BtnPreguntasFrecuentes_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new PreguntasFrecuentes());
        }

        private async void BtnTipoDeAnimal_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false; //isVisible = false
            await App.MasterD.Detail.Navigation.PushAsync(new Tipo_animales.TipoDeAnimal());
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Cerrar sesion", "¿Esta seguro de cerrar sesion?", "Si", "No");
            if (rta)
            {
                MainPage.UsuarioRegristrado = null;
                App.MasterD.IsPresented = false;
                App.MasterD.Master = new Master();
            }
        }
    }
}
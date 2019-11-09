using Mascotapp.Marcador_animales;
using System;

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

        #region Eventos
       

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

        #endregion
    }
}
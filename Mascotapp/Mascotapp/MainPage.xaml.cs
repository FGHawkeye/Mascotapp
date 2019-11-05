using Domain.Entidades;
using Mascotapp.NavigationMenu;
using Mascotapp.Visualizar_mapa;
using System;
using Xamarin.Forms;

namespace Mascotapp
{

   
    public partial class MainPage : MasterDetailPage
    {
        public static Usuario usuarioLogeado = null;
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Mapa());

            App.MasterD = this;
        }

    }
}

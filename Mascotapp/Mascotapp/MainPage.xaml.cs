using Domain.Entidades;
using Mascotapp.NavigationMenu;
using Mascotapp.Visualizar_mapa;
using System;
using Xamarin.Forms;

namespace Mascotapp
{

   
    public partial class MainPage : MasterDetailPage
    {

        public static Domain.Entidades.Usuario UsuarioRegristrado = null;

        public MainPage()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Mapa());
            App.MasterD = this;
        }
        public static void RecargarPrincipal()
        {
            App.MasterD.IsPresented = false; //isVisible = false
            App.MasterD.Detail = new NavigationPage(new Mapa());
        }

        public static void RecargarPrincipalLogout()
        {
            MainPage.UsuarioRegristrado = null;
            App.MasterD.IsPresented = false; //isVisible = false
            App.MasterD.Master = new Master();
            App.MasterD.Detail = new NavigationPage(new Mapa());
        }


        //void CargarUsuarios()
        //{
        //    lstUsuarios.ItemsSource = usuarios;
        //    ServicioUsuarios service = new ServicioUsuarios();
        //    var Usuarios = service.ObtenerUsuarios();
        //    foreach (var usuario in Usuarios)
        //    {
        //        usuarios.Add(usuario);
        //    }
        //}
    }
}

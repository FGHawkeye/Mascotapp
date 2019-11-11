using Mascotapp.NavigationMenu;
using Mascotapp.Visualizar_mapa;
using System;
using Xamarin.Forms;

namespace Mascotapp
{

   
    public partial class MainPage : MasterDetailPage
    {

        public static Domain.Entidades.Usuario UsuarioRegristrado = null;

        //ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();
        //public ObservableCollection<Usuario> Usuarios { get { return usuarios; } }


        public MainPage()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Mapa());

            App.MasterD = this;
            //CargarUsuarios();
        }
        public static void RecargarPrincipal ()
        {
            App.MasterD.IsPresented = false; //isVisible = false
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

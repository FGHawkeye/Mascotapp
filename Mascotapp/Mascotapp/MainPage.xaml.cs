using Mascotapp.NavigationMenu;
using Xamarin.Forms;

namespace Mascotapp
{
    public partial class MainPage : MasterDetailPage
    {
        //ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();
        //public ObservableCollection<Usuario> Usuarios { get { return usuarios; } }


        public MainPage()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());
            //CargarUsuarios();
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

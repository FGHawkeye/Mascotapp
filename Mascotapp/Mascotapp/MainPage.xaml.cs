using Domain.Entidades;
using Domain.Servicios;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Domain.DB;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace Mascotapp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();
        public ObservableCollection<Usuario> Usuarios { get { return usuarios; } }


        public MainPage()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        void CargarUsuarios()
        {
            lstUsuarios.ItemsSource = usuarios;
            ServicioUsuarios service = new ServicioUsuarios();
            var Usuarios = service.ObtenerUsuarios();
            foreach (var usuario in Usuarios)
            {
                usuarios.Add(usuario);
            }
        }
    }
}

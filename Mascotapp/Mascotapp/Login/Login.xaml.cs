using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Servicios;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Mascotapp.Login
{
    
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        private ServicioUsuarios servicioUsuarios = new ServicioUsuarios();

        public Login()
        {
           
           
            InitializeComponent();
            CargarEventos();
        }

        public void CargarEventos()
        {

            btnIngresar.Clicked += Ingresar_Clicked;
            txtContra.Completed += Ingresar_Clicked;
            btnCancelar.Clicked += Cancelar_Clicked;
        }


        private async void Ingresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                /* if (ValidarForm())+
                 {*/
                Usuario Usuario = new Usuario();
                Usuario UsuarioValidado = new Usuario();

                Usuario.NombreUsuario = txtNombre.Text;
                Usuario.Contraseña = txtContra.Text;

                UsuarioValidado = servicioUsuarios.ValidarUsuario(Usuario);

                MainPage.TipoUsuario = UsuarioValidado.IdTipoUsuario;
                MainPage.NombreYApellido = UsuarioValidado.Nombre;
                await Navigation.PopAsync(false);

                await DisplayAlert("Bienvenido " + MainPage.NombreYApellido , "Nos alegra que nos visites nuevamente.", "Continuar");
          
           

                /*}*/
            }
            catch
            {
  
                    await DisplayAlert("Error de autenticación", "Su cuenta o contraseña no se encuentran registradas", "Entendido");
                    txtContra.Text = "";
            }



        }


        private void Cancelar_Clicked(object sender, EventArgs e)
        {

           Navigation.PopAsync(false);


        }


    }
}
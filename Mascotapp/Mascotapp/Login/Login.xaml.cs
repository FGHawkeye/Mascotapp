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

        public Login(string nombreusuario = "", string contra = "")
        {
            
            InitializeComponent();
            CargarEventos();

            if (contra.Equals(""))
            { }
            else
            {
                txtNombre.Text = nombreusuario;
                txtContra.Text = contra;
                btnIngresar.Focus();
            }
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
                Usuario Usuario = new Usuario();
                Usuario UsuarioValidado = new Usuario();
                
                Usuario.NombreUsuario = txtNombre.Text.Trim();
                Usuario.Contraseña =  txtContra.Text.Trim();

                UsuarioValidado = servicioUsuarios.ValidarUsuario(Usuario);

                MainPage.UsuarioRegristrado = UsuarioValidado;

                await DisplayAlert("Bienvenido " + MainPage.UsuarioRegristrado.Nombre, "Nos alegra que nos visites nuevamente.", "Continuar");
                MainPage.RecargarPrincipal();
               
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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            Navigation.PopAsync(false);
            Navigation.PushAsync(new Registro.Registro());
        }

    }
}
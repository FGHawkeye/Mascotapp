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
using Mascotapp.NavigationMenu;


namespace Mascotapp.Login
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        private ServicioUsuarios servicioUsuarios = new ServicioUsuarios();
        private ServicioRefugio servicioRefugio = new ServicioRefugio();

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
                bool flagRefugioValido = true;
                Usuario Usuario = new Usuario();
                Usuario UsuarioValidado = new Usuario();

                Usuario.NombreUsuario = txtNombre.Text.Trim();
                Usuario.Contraseña = txtContra.Text.Trim();

                UsuarioValidado = servicioUsuarios.ValidarUsuario(Usuario);

                if (UsuarioValidado.IdTipoUsuario == 3)
                {
                    var refugio = servicioRefugio.ObtenerRefugioUsuario(UsuarioValidado.IdUsuario.Value);

                    if (refugio.Estado == "Pendiente")
                    {
                        await DisplayAlert("Error de autenticación", "Su cuenta de refugio esta en estado pendiente a revisar por un administrador, no puede utilizar momentaneamente esta cuenta", "Entendido");
                        await Navigation.PopAsync(false);
                        flagRefugioValido = false;
                    }
                    else if (refugio.Estado == "Rechazado")
                    {
                        await DisplayAlert("Error de autenticación", "Su cuenta de refugio fue rechazado por un administrador, su cuenta esta deshabilitada", "Entendido");
                        await Navigation.PopAsync(false);
                        flagRefugioValido = false;
                    }
                }
                if (flagRefugioValido)
                {
                    MainPage.UsuarioRegristrado = UsuarioValidado;

                    if (UsuarioValidado.IdTipoUsuario == 1)
                    {
                        App.MasterD.Master = new MenuAdmin();
                    }
                    else
                    {
                        App.MasterD.Master = new MenuUsuario();
                    }

                    await Navigation.PopAsync(false);

                    await DisplayAlert("Bienvenido " + MainPage.UsuarioRegristrado.Nombre, "Nos alegra que nos visites nuevamente.", "Continuar");
                    MainPage.RecargarPrincipal();
                }
                    


            }
            catch (Exception ex)
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
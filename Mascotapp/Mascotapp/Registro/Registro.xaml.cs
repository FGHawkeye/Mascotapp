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

namespace Mascotapp.Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {

        private ServicioUsuarios servicioUsuarios = new ServicioUsuarios();

        public Registro()
        {
            InitializeComponent();
            CargarEventos();
        }


        public void CargarEventos()
        {

            btnRegistrar.Clicked += Registrar_Clicked;
            txtContra2.Completed += Registrar_Clicked;
            btnCancelar.Clicked += Cancelar_Clicked;
        }

        private async void Registrar_Clicked(object sender, EventArgs e)
        {

            int Validacion;
            Validacion = ValidarForm();

           switch (Validacion)
            {
                case 0: /* Validaciones correctas */
                    try
                    {
                        int Registrado = 0;

                        Usuario Usuario = new Usuario
                        {
                            NombreUsuario = txtUsuario.Text,
                            IdTipoUsuario = 1,
                            NombreYApellido = txtNombre.Text,
                            Contraseña = txtContra.Text,
                            Email = txtEmail.Text,
                            Telefono = Convert.ToInt64(txtTel.Text),
                        };

                        Registrado = servicioUsuarios.RegistrarUsuario(Usuario);

                        if(Registrado == 1)
                        { 
                        await DisplayAlert("Registro Exitoso", "Su Nuevo Usuario fue creado correctamente", "Entendido");
                        SalirRegistrado();             
                        }    
                        
                    }
                    catch (Exception ex)
                    {           
                            await DisplayAlert("Error de Registro", "Fallo algo al registrar", "Entendido");
                            /*    sacar estooooo*/
                            txtNombre.Text = ex.ToString();
                    }
                    break;

                case 1:
                    await DisplayAlert("Email Invalido", "Por favor ingrese un email valido con el formato 'Ejemplo@email.com'.", "Entendido");
                    txtEmail.Text = "";
                    txtEmail.Focus();
                    break;

                case 2:
                    await DisplayAlert("Las Contraseñas son diferentes", "Vuelva a ingresar la contraseña y su confirmacion, ambas deben ser iguales", "Entendido");
                    txtContra.Text = "";
                    txtContra2.Text = "";
                    break;

                case 3:

                    break;



            }

        }


        private void Cancelar_Clicked(object sender, EventArgs e)
        {

            Navigation.PopAsync(false);


        }
        private int ValidarForm()
        {

            try { 
            var DireccionMail = new System.Net.Mail.MailAddress(txtEmail.Text);
            }
            catch (Exception)
            {
                return 1;
            }

            if (txtContra.Text != txtContra2.Text)
            {
                return 2;
            }

                return 0;
        }

        private void SalirRegistrado()
        {
            Navigation.PopAsync(false);
            Navigation.PushAsync(new Login.Login(txtUsuario.Text));
        }

    }
}
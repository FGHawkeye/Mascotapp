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
        }

        private async void Registrar_Clicked(object sender, EventArgs e)
        {

            int Validacion = 0;
            Validacion = ValidarForm();

           switch (Validacion)
            {
                case 0: /* Validaciones correctas */
                    try
                    {
                        int Registrado = 0;
                        Usuario Usuario = new Usuario();

                

                        Usuario.NombreUsuario = txtUsuario.Text;
                        Usuario.IdTipoUsuario = 1;
                        Usuario.NombreYApellido = txtNombre.Text;
                        Usuario.Contraseña = txtContra.Text;
                        Usuario.Email = txtEmail.Text;
                        Usuario.Telefono = Convert.ToInt64(txtTel.Text);






                        Registrado = servicioUsuarios.RegistrarUsuario(Usuario);


                        await Navigation.PopAsync(false);
                        if(Registrado == 1)
                        { 
                        await DisplayAlert("Registro Exitoso", "Su Nuevo Usuario fue creado correctamente", "Entendido");
                        txtContra.Text = "";
                        }

                    }
                    catch (Exception ex)
                    {
                        
            
                          
                            await DisplayAlert("Error de Registro", "Fallo algo al registrar", "Entendido");
                            txtNombre.Text = ex.ToString();
                    }

                    break;


                case 1:
                    await DisplayAlert("Las Contraseñas son diferentes", "Vuelva a ingresar la contraseña y su confirmacion, ambas deben ser iguales", "Entendido");
                    txtContra.Text = "";
                    txtContra2.Text = "";
                    break;

                case 2:

                    break;


            }




        }

        private int ValidarForm()
        {

            if (txtContra.Text != txtContra2.Text)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


    }
}
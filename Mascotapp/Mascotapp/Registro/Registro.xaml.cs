﻿using System;
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
            chkRefugio.CheckedChanged += Refugio_Clicked;
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
                            NombreUsuario = txtUsuario.Text.Trim(),
                            IdTipoUsuario = 1,
                            Nombre = txtNombre.Text.Trim(),
                            Apellido = txtApellido.Text.Trim(),
                            Contraseña = txtContra.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Telefono = Convert.ToInt64(txtTel.Text.Trim()),
                        };

                        Registrado = servicioUsuarios.RegistrarUsuario(Usuario);

                        if (Registrado == 1)
                        {
                            await DisplayAlert("Registro Exitoso", "Su Nuevo Usuario fue creado correctamente", "Entendido");
                            SalirRegistrado();
                        }

                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error de Registro", "Fallo algo al registrar", "Entendido");
                        txtNombre.Text = ex.ToString();
                    }
                    break;

                case 1:
                    await DisplayAlert("Campos Ingresados Vacios", "Asegurese de completar todos los datos solicitados antes de intentar registrarse.", "Entendido");
                    break;

                case 2:
                    await DisplayAlert("Email Ingresado Invalido", "Por favor ingrese un email valido con el formato 'Ejemplo@email.com'.", "Entendido");
                    txtEmail.Text = "";
                    txtEmail.Focus();
                    break;

                case 3:
                    await DisplayAlert("Contraseñas Ingresadas diferentes", "Vuelva a ingresar la contraseña y su confirmacion, ambas deben ser iguales", "Entendido");
                    txtContra.Text = "";
                    txtContra2.Text = "";
                    txtContra.Focus();
                    break;

                case 4:
                    await DisplayAlert("Teléfono Ingresado Invalido", "Vuelva a ingresar el Telefono, el campo solo acepta números, No ingrese espacios en blanco ni letras ni simbolos Por ejemplo: - , . $ Etc", "Entendido");
                    txtTel.Text = "";
                    txtTel.Focus();
                    break;



            }

        }


        private void Cancelar_Clicked(object sender, EventArgs e)
        {

            Navigation.PopAsync(false);


        }

        private void Refugio_Clicked(object sender, EventArgs e)
        {
            if (chkRefugio.IsChecked)
            {

            }

        }




        private int ValidarForm()
        {
            if (
               (String.IsNullOrWhiteSpace(txtUsuario.Text))
            || (String.IsNullOrWhiteSpace(txtNombre.Text))
            || (String.IsNullOrWhiteSpace(txtApellido.Text))
            || (String.IsNullOrWhiteSpace(txtContra.Text))
            || (String.IsNullOrWhiteSpace(txtContra2.Text))
            || (String.IsNullOrWhiteSpace(txtEmail.Text))
            || (String.IsNullOrWhiteSpace(txtTel.Text))
               )
            {
                return 1;
            }

            try
            {
                var DireccionMail = new System.Net.Mail.MailAddress(txtEmail.Text);
            }
            catch (Exception)
            {
                return 2;
            }


            if (txtContra.Text != txtContra2.Text)
            {
                return 3;
            }

            try
            {
                var Telefono = Convert.ToInt64(txtTel.Text.Trim());
            }
            catch (Exception)
            {
                return 4;
            }

            return 0;
        }

        private void SalirRegistrado()
        {
            Navigation.PopAsync(false);
            Navigation.PushAsync(new Login.Login(txtUsuario.Text, txtContra.Text));
        }

    }
}
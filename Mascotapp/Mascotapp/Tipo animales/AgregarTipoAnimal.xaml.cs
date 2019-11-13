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
using Plugin.Geolocator;

namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarTipoAnimal : ContentPage
    {
        private ServicioTipoAnimal servicioTipoAnimal=new ServicioTipoAnimal();
        public AgregarTipoAnimal()
        {
            InitializeComponent();
            CargarEventos();
        }

        public void CargarEventos()
        {
            btnAgregar.Clicked += Registrar_Clicked;
            btnCancelar.Clicked += BtnCancelar_Clicked;
        }

        private async void Registrar_Clicked(object sender, EventArgs e)
        {
           string validacion= ValidarForm();
           if(validacion==""){
               try{
                    TipoAnimal tipo= new TipoAnimal
                    {
                        IdTipoAnimal=null,
                        Descripcion=txtTipoAnimal.Text
                    };
                    servicioTipoAnimal.GuardarTipoAnimal(tipo);
                    validacion="Se genero el tipo de animal con exito.";
               }catch (Exception ex){
                   validacion="Se produjo un problema, vuelva a intentar.";
               }
           }
           await DisplayAlert("Tipo de Animal", validacion, "Ok");
           await App.MasterD.Detail.Navigation.PopToRootAsync();
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(false);
        }

        private string ValidarForm()
        {
            string msg="";
            if(txtTipoAnimal.Text==null|| txtTipoAnimal.Text==""){
                msg="Falta completar el tipo de animal";
            }else if(servicioTipoAnimal.ComprobarTipoAnimal(txtTipoAnimal.Text)>0){
                msg="El tipo de animal ingresado ya existe.";
            }
            return msg;
        }
    }
}
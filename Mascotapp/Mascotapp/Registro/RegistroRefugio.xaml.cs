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

namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroRefugio : ContentPage
    {

        private ServicioUsuarios servicioUsuarios = new ServicioUsuarios();
        private ServicioRefugio servicioRefugio=new ServicioRefugio();
        private Usuario usuario;
        public RegistroRefugio(Usuario usu)
        {
            usuario=usu;
            InitializeComponent();
            CargarEventos();
        }

        public void CargarEventos()
        {
            btnRegistrar.Clicked += Registrar_Clicked;
        }

        private async void Registrar_Clicked(object sender, EventArgs e)
        {
           string Validacion;
           Validacion = ValidarForm();
           if(Validacion==""){
               try{
                   Refugio refugio=new Refugio
                    {
                        RazonSocial=txtRazonSolial.Text,
                        CodigoPostal=txtCodigoP.Text,
                        Direccion=txtDireccion.Text,
                        FechaCreacion=DateTime.UtcNow,
                        IdRefugio=null,
                        IdUsuario=servicioUsuarios.RegistrarUsuario(usuario),
                        Localidad=txtLocalidad.Text,
                        Telefono=Int32.Parse(txtTel.Text),
                        Ubicacion="",
                        Estado="Pendiente"
                    };
                    servicioRefugio.RegistrarRefugio(refugio);
                    Validacion="Se realizo el registro con exito, la solicitud se encuentra en estado pendiente.";
               }catch{
                   Validacion="Se produjo un problema, vuelva a intentar.";
               }
               
           }
           await DisplayAlert("Registro Refugio", Validacion, "Ok");
        }


        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(false);
        }
        private string ValidarForm()
        {
            string msg="";
            if(txtRazonSolial.Text==null||txtRazonSolial.Text==""){
                msg="Falta completar la Razon Social";
            }else if(txtDireccion.Text==null||txtDireccion.Text==""){
                msg="Falta completar la direccion";
            }else if(txtLocalidad.Text==null||txtLocalidad.Text==""){
                msg="Falta completar la localidad";
            }else if(txtCodigoP.Text==null||txtCodigoP.Text==""){
                msg="Falta completar el codigo postal";
            }else if(txtTel.Text==null||txtTel.Text==""){
                msg="Falta completar el numero de contacto";
            }else if(servicioRefugio.ObtenerRazonSocial(txtRazonSolial.Text)<1){
                msg="La Razon Social seleccionada ya existe";
            }
            return msg;
        }
    }
}
using Domain.Entidades;
using Domain.Servicios;
using Plugin.Geolocator;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotapp.Marcador_animales
{
    public partial class AltaMarcador : ContentPage
    {
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioMarcadores serviceMarcadores = new ServicioMarcadores();
        private ServicioImagenes serviceImagenes = new ServicioImagenes();

        //private MediaFile _currentImg;
        private string _currentImg;

        public AltaMarcador()
        {
            InitializeComponent();
            CargarControles();
            CargarEventos();

        }

        void CargarEventos()
        {
            btnCamera.Clicked += btnCamera_Clicked;
            btnAgregar.Clicked += btnAgregar_Clicked;
        }

        void CargarControles()
        {
            CargarTipoAnimales();
        }

        void CargarTipoAnimales()
        {
            var _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            pckAnimal.ItemsSource = _lstTipoAnimal;
            pckAnimal.ItemDisplayBinding = new Binding("Descripcion");
        }

        private async void btnCamera_Clicked(object sender, EventArgs e)
        {
            string directoryPath = "/storage/emulated/0/Mascotapp/";
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 300,
                    CompressionQuality = 50
                });

            
            if (photo != null)
            {
                System.IO.File.Copy(photo.Path, directoryPath, true);
                TaskScheduler.FromCurrentSynchronizationContext();
                var trm = "/storage/emulated/0/Android/data/Mascotapp.Mascotapp/files/Pictures/";
                string name = photo.Path.Replace(trm, string.Empty);
                ImageSource image = ImageSource.FromFile(directoryPath + name);

                //imgCamara.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                imgCamara.Source = image;
                _currentImg = directoryPath + name;
                File.Delete(photo.Path);
            }
                
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            if (MainPage.UsuarioRegristrado == null)
            {
                await DisplayAlert("Error de autenticación", "Para agregar marcadores, tiene que estar logeado", "Entendido");
            }
            else
            {
                var mensaje = ValidarFormulario();
                if (mensaje == "")
                {
                    try
                    {
                        var idImagen = GuardarImagen();

                        var marcador = new Marcadores();
                        marcador.IdTipoAnimal = ((TipoAnimal)pckAnimal.ItemsSource[pckAnimal.SelectedIndex]).IdTipoAnimal.Value;
                        marcador.Descripcion = txtDescripcion.Text;
                        marcador.IdImagen = idImagen.HasValue ? idImagen.Value : 0;
                        marcador.IdUsuario = MainPage.UsuarioRegristrado.IdUsuario.Value;
                        marcador.Estado = true;

                        var currentPosition = await CrossGeolocator.Current.GetLastKnownLocationAsync();
                        marcador.Ubicacion = currentPosition.Latitude.ToString() + ";" + currentPosition.Longitude.ToString();

                        serviceMarcadores.GuardarMarcador(marcador);

                        await DisplayAlert("Agregar marcador", "Su marcador fue registrado con exito", "Entendido");
                        await Navigation.PopToRootAsync();
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Agregar marcador", "Hubo un problema, vuelva a intentar mas tarde.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error al guardar", mensaje, "Entendido");
                }
            }
           
        }

        private string ValidarFormulario()
        {
            string msg = "";

            if(_currentImg == null)
            {
                msg = "Falta cargar una imagen.";
            }
            else if (pckAnimal.SelectedItem == null)
            {
                msg = "Falta seleccionar un tipo de animal.";
            }
            else if (txtDescripcion.Text == "" || txtDescripcion.Text == null)
            {
                msg = "Falta ingresar una descripcion.";
            }
            return msg;
        }

        private int? GuardarImagen()
        {
            Imagenes img = new Imagenes();
            img.IdImagen = null;
            img.Imagen = _currentImg;
            img.Estado = true;
            var pk = serviceImagenes.GuardarImagen(img);
            return pk;
        }

    }
}
using Domain.Entidades;
using Domain.Servicios;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotapp.Marcador_animales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AltaMarcador : ContentPage
    {
        #region BindableObjects
        List<TipoAnimal> _lstTipoAnimal = new List<TipoAnimal>();
        #endregion

        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioMarcadores serviceMarcadores = new ServicioMarcadores();
        private ServicioImagenes serviceImagenes = new ServicioImagenes();

        private MediaFile _currentImg;

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
            _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            pckTipoAnimal.ItemsSource = _lstTipoAnimal;
        }

        private async void btnCamera_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
            {
                imgCamara.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                _currentImg = photo;
            }
                
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            var idImagen = GuardarImagen();

            var marcador = new Marcadores();
            marcador.IdTipoAnimal = 1;
            marcador.Descripcion = txtDescripcion.Text;
            marcador.IdImagen = idImagen;
            marcador.IdUsuario = 1; //Crear ApplicationSession
            marcador.IdMarcador = 1;
            marcador.Estado = "Activo";
            marcador.Ubicacion = "wea"; //Obtener ubicacion actual
            serviceMarcadores.GuardarMarcador(marcador);
        }

        private int GuardarImagen()
        {
            Imagenes img = new Imagenes();
            img.Imagen = _currentImg.Path;
            img.Estado = "Activo";
            serviceImagenes.GuardarImagen(img);
            return img.IdImagen;
        }

    }
}
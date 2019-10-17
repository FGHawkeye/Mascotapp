using Domain.Entidades;
using Domain.Servicios;
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
                imgCamara.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            var marcador = new Marcadores();
            marcador.IdTipoAnimal = 1;//pckTipoAnimal.SelectedItem.
            marcador.Descripcion = txtDescripcion.Text;
            marcador.IdImagen = 1;
            marcador.IdUsuario = 1;
            marcador.IdMarcador = 1;
            marcador.Estado = "wea";
            marcador.Ubicacion = "wea";
            serviceMarcadores.GuardarMarcador(marcador);
        }

    }
}
﻿using Domain.Entidades;
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
            var _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            pckAnimal.ItemsSource = _lstTipoAnimal;
            pckAnimal.ItemDisplayBinding = new Binding("Descripcion");
        }

        private async void btnCamera_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    CompressionQuality = 5
                });

            if (photo != null)
            {
                imgCamara.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                _currentImg = photo;
            }
                
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            if (MainPage.usuarioLogeado == null)
            {
                await DisplayAlert("Error de autenticación", "Para agregar marcadores, tiene que estar logeado", "Entendido");
            }
            else
            {
                if (_currentImg != null)
                {
                    try
                    {
                        var idImagen = GuardarImagen();

                        var marcador = new Marcadores();
                        marcador.IdTipoAnimal = pckAnimal.SelectedIndex;
                        marcador.Descripcion = txtDescripcion.Text;
                        marcador.IdImagen = idImagen.HasValue ? idImagen.Value : 0;
                        marcador.IdUsuario = MainPage.usuarioLogeado.IdUsuario.Value;
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
                    await DisplayAlert("Error al guardar", "Para agregar un marcador tiene que cargar una foto", "Entendido");
                }
            }
           
        }

        private int? GuardarImagen()
        {
            Imagenes img = new Imagenes();
            img.IdImagen = null;
            img.Imagen = Path.GetFileName(_currentImg.Path);
            img.Estado = true;
            var pk = serviceImagenes.GuardarImagen(img);
            return pk;
        }

    }
}
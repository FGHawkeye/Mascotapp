﻿using Domain.Entidades;
using Domain.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotapp.Visualizar_mapa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleMarcador : ContentPage
    {
        private int _idMarcador;
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioMarcadores serviceMarcadores = new ServicioMarcadores();
        private ServicioImagenes serviceImagenes = new ServicioImagenes();
        private ServicioReportes serviceReportes = new ServicioReportes();
        private Marcadores marcador;

        public DetalleMarcador(int idMarcador)
        {
            InitializeComponent();
            _idMarcador = idMarcador;
            CargarElementos();
            CargarEventos();
        }

        private void CargarEventos()
        {
            btnReportar.Clicked += btnReportar_Clicked;
        }

        private async void btnReportar_Clicked(object sender, EventArgs e)
        {
            if(MainPage.usuarioLogeado == null)
            {
                await DisplayAlert("Error de autenticación", "Para reportar marcadores, tiene que estar logeado", "Entendido");
            }
            else
            {
                try
                {
                    var reporte = new Reportes();
                    reporte.IdReporte = null;
                    reporte.IdMarcador = _idMarcador;
                    reporte.IdUsuario = MainPage.usuarioLogeado.IdUsuario.Value;

                    
                    serviceReportes.GuardarReporte(reporte);

                    await DisplayAlert("Reporte", "Su reporte fue registrado con exito", "Entendido");
                    await Navigation.PopToRootAsync();
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Reporte", "Hubo un problema, vuelva a intentar mas tarde.", "OK");
                }
                    
            }

        }

        private void CargarElementos()
        {
            marcador = serviceMarcadores.ObtenerMarcador(_idMarcador);
            var imagen = serviceImagenes.ObtenerImagen(marcador.IdImagen);
            var tipoAnimal = serviceTipoAnimal.ObtenerTipoAnimal(marcador.IdTipoAnimal);

            imgMarcador.Source = ImageSource.FromFile(imagen.Imagen);
            lblTipoAnimal.Text = tipoAnimal.Descripcion;
            txtDescripcion.Text = marcador.Descripcion;
        }
    }
}
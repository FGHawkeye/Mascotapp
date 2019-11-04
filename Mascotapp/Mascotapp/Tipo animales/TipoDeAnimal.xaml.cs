﻿using Domain.Entidades;
using Domain.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotapp.Tipo_animales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoDeAnimal : ContentPage
    {
        private ServicioTipoAnimal servicieTipoAnimal = new ServicioTipoAnimal();
        private List<Domain.Entidades.TipoAnimal> _lstTipoAnimal;

        public TipoDeAnimal()
        {
            InitializeComponent();
            CargarControles();
            CargarElementos();
        }

        void CargarControles()
        {
            CargarTipoAnimales();
        }

        void CargarTipoAnimales()
        {
            /*_lstTipoAnimal = servicieTipoAnimal.ObtenerTipoAnimales();
            pckTipoDeAnimal.ItemsSource = _lstTipoAnimal;*/

            _lstTipoAnimal = servicieTipoAnimal.ObtenerTipoAnimales();
            foreach (TipoAnimal tipo in _lstTipoAnimal)
            {
                pckTipoDeAnimal.Items.Add(tipo.Descripcion);
            }
        }

        void CargarElementos()
        {
            btnAgregar.Clicked += btnAgregar_Clicked;
            btnModificar.Clicked += btnModificar_Clicked;
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
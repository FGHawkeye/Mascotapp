using Domain.Entidades;
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

    public partial class TipoAnimales : ContentPage
    {
        #region BindableObjects
        List<TipoAnimal> _lstTipoAnimal = new List<TipoAnimal>();
        #endregion

        private ServicioTipoAnimal servicieTipoAnimal = new ServicioTipoAnimal();

        public TipoDeAnimales()
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
            _lstTipoAnimal = servicieTipoAnimal.ObtenerTipoAnimales();
            pckTipoAnimal.ItemsSource = _lstTipoAnimal;
        }

        void CargarElementos()
        {
            btnAgregar.Clicked += btnAgregar_Clicked;
            btnModificar.Clicked += btnModificara_Clicked;
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            NuevoTipo();
        }
    }
}
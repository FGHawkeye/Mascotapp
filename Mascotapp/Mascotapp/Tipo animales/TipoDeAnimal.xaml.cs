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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoDeAnimal : ContentPage
    {
        private int idTipo = 0;

        private ServicioTipoAnimal servicieTipoAnimal = new ServicioTipoAnimal();
        private List<Domain.Entidades.TipoAnimal> _lstTipoAnimal;

        public TipoDeAnimal(int id)
        {
            InitializeComponent();
            CargarControles(id);
            //CargarElementos(id);
        }

        void CargarControles(int id)
        {
            idTipo = id;
            TipoAnimal tipoAnimal = servicieTipoAnimal.ObtenerTipoAnimal(id);
            //List<TipoAnimal> tipoAnimals = servicieTipoAnimal.ObtenerTipoAnimales();
            /*foreach (ImagenXAdopcion item in imagenXAdopcions)
            {
                imagenes.Add(servicioImagenes.ObtenerImagen(item.IdImagen));
            }
            CargarImagenes();*/
            //CargarAdopcion(adopcion);
            CargarElementos();

            CargarTipoAnimales(tipoAnimal);
        }

        void CargarTipoAnimales(TipoAnimal tipoAnimal)
        {
            /*_lstTipoAnimal = servicieTipoAnimal.ObtenerTipoAnimales();
            pckTipoDeAnimal.ItemsSource = _lstTipoAnimal;*/

            /*_lstTipoAnimal = servicieTipoAnimal.ObtenerTipoAnimales();
            foreach (TipoAnimal tipo in _lstTipoAnimal)
            {
                pckTipoDeAnimal.Items.Add(tipo.Descripcion);
            }*/

            List<TipoAnimal> _lstTipoAnimal = servicieTipoAnimal.ObtenerTipoAnimales();
            lbAnimal.Text = _lstTipoAnimal.Where(X => X.IdTipoAnimal == tipoAnimal.IdTipoAnimal).Select(X => X.Descripcion).FirstOrDefault();
        }

        void CargarElementos()
        {
            btnAgregar.Clicked += btnAgregar_Clicked;
            btnModificar.Clicked += btnModificar_Clicked;
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new NuevoTipoAnimal());
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
           ((NavigationPage)this.Parent).PushAsync(new ModificarTipo());
            //await App.MasterD.Detail.Navigation.PushAsync(new ModificarTipo(IdTipoAnimal));
        }
    }
}
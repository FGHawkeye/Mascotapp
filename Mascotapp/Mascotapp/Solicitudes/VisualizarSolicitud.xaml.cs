using System;
using Domain.Entidades;
using Domain.Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mascotapp.NavigationMenu;

namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisualizarSolicitud : ContentPage
    {
        private int imgCount = 0;
        private int idAdop = 0;

        private List<Imagenes> imagenes = new List<Imagenes>();
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        private ServicioImagenes servicioImagenes = new ServicioImagenes();
        private ServicioImagenXAdopcion servicioImagenXAdopcion = new ServicioImagenXAdopcion();
        private ServicioSolicitudAdopcion servicioSolicitudAdopcion = new ServicioSolicitudAdopcion();

        public VisualizarSolicitud(int id)
        {
            InitializeComponent();
            CargarElementos(id);
        }

        public void CargarElementos(int id)
        {
            idAdop = id;
            Adopciones adopcion = servicioAdopciones.ObtenerAdopcion(id);
            List<ImagenXAdopcion> imagenXAdopcions = servicioImagenXAdopcion.ObtenerImagenXAdopcion(id);
            foreach (ImagenXAdopcion item in imagenXAdopcions)
            {
                imagenes.Add(servicioImagenes.ObtenerImagen(item.IdImagen));
            }
            CargarImagenes();
            CargarAdopcion(adopcion);
            btnGuardar.Clicked += Guardar_Clicked;
        }

        public void CargarAdopcion(Adopciones adopcion)
        {
            List<TipoAnimal> _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            txtEdad.Text = adopcion.Edad.ToString();
            txtDescripcion.Text = adopcion.Detalle;
            txtNombre.Text = adopcion.Nombre;
            lbSexo.Text = adopcion.Sexo;
            lbAnimal.Text=_lstTipoAnimal.Where(X=>X.IdTipoAnimal==adopcion.IdTipoAnimal).Select(X=>X.Descripcion).FirstOrDefault();
        }

        public void CargarImagenes()
        {
            imgCount = imagenes.Count;
            if (imgCount > 0)
            {
                if (imagenes[0].Estado)
                {
                    imgMin1.Source = ImageSource.FromFile(imagenes[0].Imagen);
                }
            }
            if (imgCount > 1)
            {
                if (imagenes[1].Estado)
                {
                    imgMin2.Source = ImageSource.FromFile(imagenes[1].Imagen);
                }
            }
            if (imgCount > 2)
            {
                if (imagenes[2].Estado)
                {
                    imgMin3.Source = ImageSource.FromFile(imagenes[2].Imagen);
                }
            }
        }

        private void Img_Clicked(object sender, EventArgs e)
        {
            ImageButton ia = (ImageButton)sender;
            if (ia.Source != null)
            {
                lbImage.Text = ia.Id.ToString();
                imgCamara.Source = ia.Source;
            }
        }


        public string ValidarForm()
        {
            string msg = "";

            if (txtDetalle.Text == "" || txtDescripcion.Text == null)
            {
                msg = "Falta completar el detalle.";
            }else if (MainPage.UsuarioRegristrado == null)
            {
                msg = "Para realizar una solicitud, debe estar registrado.";
            }
            return msg;
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string msg = ValidarForm();
                if (msg==""&& MainPage.UsuarioRegristrado!=null)
                {
                    SolicitudAdopcion solicitud = new SolicitudAdopcion
                    {
                        IdAdopcion = idAdop,
                        Descripcion = txtDetalle.Text,
                        Estado = "Pendiente",
                        FechaCreacion = DateTime.UtcNow,
                        IdUsuarioSolicitante = MainPage.UsuarioRegristrado.IdUsuario.Value
                    };
                    servicioSolicitudAdopcion.GuardarSolicitudAdopcion(solicitud);
                    await DisplayAlert("Adopciones", "Se modificó la publicación correctamente!", "OK");
                    await App.MasterD.Detail.Navigation.PopToRootAsync();
                }
                else
                {
                    await DisplayAlert("Adopciones", msg, "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Adopciones", "Hubo un problema, vuelva a intentar mas tarde.", "OK");
                Console.WriteLine(ex);
            }
        }
    }
}
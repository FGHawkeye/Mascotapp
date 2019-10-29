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
    public partial class ModificarAdopcion : ContentPage
    {
        #region BindableObjects
        List<TipoAnimal> _lstTipoAnimal = new List<TipoAnimal>();
        #endregion
        private string image1;
        private string image2;
        private string image3;
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        private ServicioImagenes servicioImagenes = new ServicioImagenes();
        private ServicioImagenXAdopcion servicioImagenXAdopcion = new ServicioImagenXAdopcion();
        public ModificarAdopcion(int id)
        {
            InitializeComponent();
            CargarElementos(id);
        }
        public void CargarElementos(int id)
        {
            Adopciones adopcion = servicioAdopciones.ObtenerAdopcion(id);
            List<ImagenXAdopcion> imagenXAdopcions = servicioImagenXAdopcion.ObtenerImagenXAdopcion(id);
            List<Imagenes> imagenes = new List<Imagenes>();// servicioImagenes.ObtenerImagenes().Where(x => x.IdImagen == imagenXAdopcions.;
            foreach(ImagenXAdopcion item in imagenXAdopcions)
            {
                imagenes.Add(servicioImagenes.ObtenerImagen(item.IdImagen));
            }
            CargarImagenes(imagenes);
            CargarTipoAnimal();
            CargarAdopcion(adopcion);
        }
        public void CargarTipoAnimal()
        {
            _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            foreach(TipoAnimal tipo in _lstTipoAnimal)
            {
                pckAnimal.Items.Add(tipo.Descripcion);
            }
        }
        public void CargarAdopcion(Adopciones adopcion)
        {
            txtEdad.Text = adopcion.Edad.ToString();
            txtDescripcion.Text = adopcion.Detalle;
            txtNombre.Text = adopcion.Nombre;
            if (adopcion.Sexo == "Macho")
            {
                pckSexo.SelectedIndex = 0;
            }
            else
            {
                pckSexo.SelectedIndex = 1;
            }
            pckAnimal.SelectedIndex = adopcion.IdTipoAnimal;
        }
        public void CargarImagenes(List<Imagenes> imagenes)
        {
            if (imagenes.Count>0)
            {
                imgMin1.Source = ImageSource.FromFile(imagenes[0].Imagen);
                image1 = imagenes[0].Imagen;
            }
            if (imagenes.Count > 1) { 
                imgMin2.Source = ImageSource.FromFile(imagenes[1].Imagen);
                image2 = imagenes[1].Imagen;
            }
            if (imagenes.Count>2)
            {
                imgMin3.Source = ImageSource.FromFile(imagenes[2].Imagen);
                image3 = imagenes[2].Imagen;
            }
            if (imagenes.Count == 3)
            {
                btnCamara.IsEnabled = false;
            }
        }
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    CompressionQuality = 5
                }
                );

            if (photo != null)
            {
                ImageSource imageSource = ImageSource.FromStream(() => { return photo.GetStream(); });
                AgregarFoto(imageSource, photo.Path);
            }
        }
        private void Img_Clicked(object sender, EventArgs e)
        {
            ImageButton ia = (ImageButton)sender;
            if (ia.Source != null)
            {
                lbImage.Text = ia.Id.ToString();
                btnQuitar.IsEnabled = true;
                imgCamara.Source = ia.Source;
            }
        }
        private void Quitar_Clicked(object sender, EventArgs e)
        {
            if (lbImage.Text != "")
            {
                if (lbImage.Text == imgMin1.Id.ToString())
                {
                    imgMin1.Source = imgMin2.Source;
                    imgMin2.Source = imgMin3.Source;
                    imgMin3.Source = null;
                    image1 = image2;
                    image2 = image3;
                    image3 = null;
                }
                if (lbImage.Text == imgMin2.Id.ToString())
                {
                    imgMin2.Source = imgMin3.Source;
                    imgMin3.Source = null;
                    image2 = image3;
                    image3 = null;
                }
                if (lbImage.Text == imgMin3.Id.ToString())
                {
                    imgMin3.Source = null;
                    image3 = null;
                }
                btnCamara.IsEnabled = true;
                imgCamara.Source = null;
                lbImage.Text = "";
                btnQuitar.IsEnabled = false;
            }
        }
        public bool ValidarForm()
        {
            //agregar mensajes faltantes
            bool validate = true;
            if (pckUnidad.SelectedItem == null)
            {
                validate = false;
            }
            else if (pckAnimal.SelectedItem == null)
            {
                validate = false;
            }
            else if (pckSexo.SelectedItem == null)
            {
                validate = false;
            }
            else if (txtDescripcion.Text == "" || txtDescripcion.Text == null)
            {
                validate = false;
            }
            else if (txtEdad.Text == "" || txtEdad.Text == null)
            {
                validate = false;
            }
            else if (imgMin1.Source == null && imgMin2.Source == null && imgMin3.Source == null)
            {
                validate = false;
            }
            return validate;
        }
        public void AgregarFoto(ImageSource img, string path)
        {
            bool estado = false;
            if (imgMin1.Source == null)
            {
                estado = true;
                lbImage.Text = imgMin1.Id.ToString();
                imgMin1.Source = img;
                image1 = path;
            }
            else if (imgMin2.Source == null)
            {
                lbImage.Text = imgMin2.Id.ToString();
                estado = true;
                imgMin2.Source = img;
                image2 = path;
            }
            else if (imgMin3.Source == null)
            {
                lbImage.Text = imgMin3.Id.ToString();
                estado = true;
                imgMin3.Source = img;
                image3 = path;
            }
            if (estado)
            {
                imgCamara.Source = img;
                btnQuitar.IsEnabled = true;
            }
            else
            {
                //agregar mensaje de limite de fotos
                btnCamara.IsEnabled = false;
                imgCamara.Source = null;
                btnQuitar.IsEnabled = false;
            }
        }
        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            /*try
            {
                if (ValidarForm())
                {
                    var adopcion = new Adopciones();
                    adopcion.IdUsuario = 2;
                    adopcion.IdAdopcion = null;
                    adopcion.IdTipoAnimal = 1;
                    adopcion.Detalle = txtDescripcion.Text;
                    adopcion.Edad = Int32.Parse(txtEdad.Text);//faltaria modificar la tabla para agregar edad meses y edad años
                    adopcion.Estado = "Activo";
                    adopcion.Nombre = txtNombre.Text;
                    adopcion.Sexo = pckSexo.SelectedItem.ToString();
                    adopcion.Ubicacion = "Prueba";
                    int idAd = servicioAdopciones.GuardarAdopcion(adopcion);

                    if (imgMin1.Source != null)
                    {
                        var imagen = new Imagenes();
                        imagen.IdImagen = null;
                        imagen.Imagen = image1;
                        imagen.Estado = "Activo";
                        int idImg = servicioImagenes.GuardarImagen(imagen);

                        var imgXad = new ImagenXAdopcion();
                        imgXad.IdAdopcion = idAd;
                        imgXad.IdImagen = idImg;
                        int idIXA = servicioImagenXAdopcion.GuardarImagenXAdopcion(imgXad);

                    }
                    if (imgMin2.Source != null)
                    {
                        var imagen = new Imagenes();
                        imagen.IdImagen = null;
                        imagen.Imagen = image2;
                        imagen.Estado = "Activo";
                        int idImg = servicioImagenes.GuardarImagen(imagen);

                        var imgXad = new ImagenXAdopcion();
                        imgXad.IdAdopcion = idAd;
                        imgXad.IdImagen = idImg;
                        int idIXA = servicioImagenXAdopcion.GuardarImagenXAdopcion(imgXad);
                    }
                    if (imgMin3.Source != null)
                    {
                        var imagen = new Imagenes();
                        imagen.IdImagen = null;
                        imagen.Imagen = image3;
                        imagen.Estado = "Activo";
                        int idImg = servicioImagenes.GuardarImagen(imagen);

                        var imgXad = new ImagenXAdopcion();
                        imgXad.IdAdopcion = idAd;
                        imgXad.IdImagen = idImg;
                        int idIXA = servicioImagenXAdopcion.GuardarImagenXAdopcion(imgXad);
                    }
                    await DisplayAlert("Adopciones", "Se modificó la publicación correctamente!", "OK");
                    await App.MasterD.Detail.Navigation.PopToRootAsync();
                }
                else
                {
                    await DisplayAlert("Adopciones", "Falta completar datos.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Adopciones", "Hubo un problema, vuelva a intentar mas tarde.", "OK");
                Console.WriteLine(ex);
            }*/
        }
    }
}
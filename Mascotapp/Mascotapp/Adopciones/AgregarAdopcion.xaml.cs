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
using System.IO;
using Plugin.Geolocator;
using Plugin.Media.Abstractions;

namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarAdopcion : ContentPage
    {

        List<TipoAnimal> _lstTipoAnimal = new List<TipoAnimal>();

        private string image1;
        private string image2;
        private string image3;
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        private ServicioImagenes servicioImagenes = new ServicioImagenes();
        private ServicioImagenXAdopcion servicioImagenXAdopcion = new ServicioImagenXAdopcion();
        public AgregarAdopcion()
        {
            InitializeComponent();
            CargarEventos();
        }

        public void CargarTipoAnimal()
        {
            List<TipoAnimal> _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            pckAnimal.ItemsSource = _lstTipoAnimal;
            pckAnimal.ItemDisplayBinding = new Binding("Descripcion");
        }
        public void CargarEventos()
        {
            btnCamara.Clicked += CameraButton_Clicked;
            btnQuitar.Clicked += Quitar_Clicked;
            btnGuardar.Clicked += Guardar_Clicked;
            CargarTipoAnimal();
        }
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            string directoryPath = "/storage/emulated/0/Mascotapp/";
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions() 
                {
                    PhotoSize=PhotoSize.MaxWidthHeight,
                    MaxWidthHeight=300,                    
                    CompressionQuality =50
                }
            );
            if (photo != null)
            {
                System.IO.File.Copy(photo.Path, directoryPath, true);
                TaskScheduler.FromCurrentSynchronizationContext();
                var trm = "/storage/emulated/0/Android/data/Mascotapp.Mascotapp/files/Pictures/";
                string name = photo.Path.Replace(trm, string.Empty);
                ImageSource image = ImageSource.FromFile(directoryPath + name);
                AgregarFoto(image, directoryPath + name);
                File.Delete(photo.Path);
            }       
        }
        private void Img_Clicked(object sender, EventArgs e)
        {
            ImageButton ia = (ImageButton)sender;
            if (ia.Source != null)
            {
                lbImage.Text = ia.Id.ToString();
                btnQuitar.IsEnabled = true;
                btnQuitar.BackgroundColor = Color.DarkRed;
                imgCamara.Source = ia.Source;
            }
        }
        private void Quitar_Clicked(object sender, EventArgs e)
        {
            if(lbImage.Text != "")
            {
                if (lbImage.Text == imgMin1.Id.ToString())
                {
                    imgMin1.Source = imgMin2.Source;
                    imgMin2.Source = imgMin3.Source;
                    imgMin3.Source = null;
                }
                if (lbImage.Text == imgMin2.Id.ToString())
                {
                    imgMin2.Source = imgMin3.Source;
                    imgMin3.Source = null;
                }
                if (lbImage.Text == imgMin3.Id.ToString()) imgMin3.Source = null;
                imgCamara.Source = null;
                lbImage.Text = "";
                btnQuitar.IsEnabled = false;
                btnQuitar.BackgroundColor = Color.Gray;
                btnCamara.IsEnabled = true;
                btnCamara.BackgroundColor = Color.DarkBlue;
            }
        }
        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var currentPosition = await CrossGeolocator.Current.GetLastKnownLocationAsync();
                string mensaje= ValidarForm();
                if (mensaje=="")
                {
                    var adopcion = new Adopciones();
                    adopcion.IdUsuario = MainPage.UsuarioRegristrado.IdUsuario.Value;
                    adopcion.IdAdopcion= null;
                    TipoAnimal tipoAnimal = (TipoAnimal)pckAnimal.ItemsSource[pckAnimal.SelectedIndex];
                    adopcion.IdTipoAnimal = tipoAnimal.IdTipoAnimal.Value;
                    adopcion.Detalle = txtDescripcion.Text;
                    adopcion.Edad = Int32.Parse(txtEdad.Text);//faltaria modificar la tabla para agregar edad meses y edad años
                    adopcion.Estado = true;
                    adopcion.Nombre = txtNombre.Text;
                    adopcion.Sexo = pckSexo.SelectedItem.ToString();
                    adopcion.Ubicacion = currentPosition.Latitude.ToString() + ";" + currentPosition.Longitude.ToString();
                    int idAd=servicioAdopciones.GuardarAdopcion(adopcion);
                    if (imgMin1.Source != null)
                    {
                        var imagen = new Imagenes();
                        imagen.IdImagen = null;
                        imagen.Imagen = image1;
                        imagen.Estado = true;
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
                        imagen.Estado = true;
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
                        imagen.Estado = true;
                        int idImg = servicioImagenes.GuardarImagen(imagen);

                        var imgXad = new ImagenXAdopcion();
                        imgXad.IdAdopcion = idAd;
                        imgXad.IdImagen = idImg;
                        int idIXA = servicioImagenXAdopcion.GuardarImagenXAdopcion(imgXad);
                    }
                    //mensaje = "Se publico correctamente!";
                    await DisplayAlert("Adopciones", "Se publico correctamente!", "OK");
                    await App.MasterD.Detail.Navigation.PopToRootAsync();
                }
                else
                {
                    await DisplayAlert("Adopciones", mensaje, "OK");
                }
            }catch(Exception ex)
            {
                await DisplayAlert("Adopciones", "Hubo un problema, vuelva a intentar mas tarde.", "OK");
                Console.WriteLine(ex);
            }
            
        }

        public string ValidarForm()
        {
            string msg = "";
            //agregar mensajes faltantes
            if (MainPage.UsuarioRegristrado == null)
            {
                msg = "Para ingresar una publicacion debe estar logueado.";
            }
            else if (pckAnimal.SelectedItem == null)
            {
                msg = "Falta seleccionar un tipo de animal.";
            }
            else if (pckSexo.SelectedItem == null)
            {
                msg = "Falta seleccionar el sexo.";
            }
            else if (txtDescripcion.Text == "" || txtDescripcion.Text == null)
            {
                msg = "Falta ingresar una descripcion.";
            }
            else if (txtEdad.Text == "" || txtEdad.Text == null)
            {
                msg = "Falta ingresar la edad del animal.";
            }
            else if (imgMin1.Source == null&& imgMin2.Source == null&& imgMin3.Source == null)
            {
                msg = "Falta ingresar al menos una foto.";
            }else if (long.Parse(txtEdad.Text) < 0 || long.Parse(txtEdad.Text) > 25)
            {
                msg = "Ingrese una edad valida.";
            }
            return msg;
        }
        public void AgregarFoto(ImageSource img,string path)
        {
            bool estado = false;
            if (imgMin1.Source == null)
            {
                estado = true;
                lbImage.Text = imgMin1.Id.ToString();
                imgMin1.Source = img;
                image1 = path;
            }else if (imgMin2.Source == null)
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
                btnCamara.IsEnabled = false;
                btnCamara.BackgroundColor = Color.Gray;
            }
            if (estado)
            {
                imgCamara.Source = img;
                btnQuitar.IsEnabled = true;
                btnQuitar.BackgroundColor = Color.DarkRed;
            }
            else
            {
                //agregar mensaje de limite de fotos
                imgCamara.Source = null;
                btnQuitar.IsEnabled = false;
                btnQuitar.BackgroundColor = Color.Gray;
            }
        }
    }
}
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
    public partial class AgregarAdopcion : ContentPage
    {
        #region BindableObjects
        List<TipoAnimal> _lstTipoAnimal = new List<TipoAnimal>();
        #endregion

        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        private ServicioImagenes servicioImagenes = new ServicioImagenes();
        private ServicioImagenXAdopcion servicioImagenXAdopcion = new ServicioImagenXAdopcion();
        public AgregarAdopcion()
        {
            InitializeComponent();
            CargarEventos();
        }

        public void CargarEventos()
        {
            btnCamara.Clicked += CameraButton_Clicked;
            imgMin1.Clicked += Img_Clicked;
            btnQuitar.Clicked += Quitar_Clicked;
            btnGuardar.Clicked += Guardar_Clicked;
        }
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions() 
                {
                    CompressionQuality=5
                }
                );

            if (photo != null)
            {
                ImageSource imageSource= ImageSource.FromStream(() => { return photo.GetStream(); });
                AgregarFoto(imageSource);
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
            }
        }
        private void Guardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (ValidarForm())
                {
                    var adopcion = new Adopciones();
                    adopcion.IdUsuario = 2;
                    adopcion.IdAdopcion= null;
                    adopcion.IdTipoAnimal =1;
                    adopcion.Detalle = txtDescripcion.Text;
                    adopcion.Edad = Int32.Parse(txtEdad.Text);//faltaria modificar la tabla para agregar edad meses y edad años
                    adopcion.Estado = "Prueba";
                    adopcion.Nombre = "Prueba";
                    adopcion.Sexo = pckSexo.SelectedItem.ToString();
                    adopcion.Ubicacion = "Prueba";
                    int idAd=servicioAdopciones.GuardarAdopcion(adopcion);

                    if (imgMin1.Source != null)
                    {
                        var imagen = new Imagenes();
                        imagen.IdImagen = null;
                        imagen.Imagen = imgMin1.Source.ToString();
                        imagen.Estado = "Prueba";
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
                        imagen.Imagen = imgMin2.Source.ToString();
                        imagen.Estado = "Prueba";
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
                        imagen.Imagen = imgMin3.Source.ToString();
                        imagen.Estado = "Prueba";
                        int idImg = servicioImagenes.GuardarImagen(imagen);

                        var imgXad = new ImagenXAdopcion();
                        imgXad.IdAdopcion = idAd;
                        imgXad.IdImagen = idImg;
                        int idIXA = servicioImagenXAdopcion.GuardarImagenXAdopcion(imgXad);
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
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
            else if (imgMin1.Source == null&& imgMin2.Source == null&& imgMin3.Source == null)
            {
                validate = false;
            }
            return validate;
        }
        public void AgregarFoto(ImageSource img)
        {
            bool estado = false;
            if (imgMin1.Source == null)
            {
                estado = true;
                lbImage.Text = imgMin1.Id.ToString();
                imgMin1.Source = img;
            }else if (imgMin2.Source == null)
            {
                lbImage.Text = imgMin2.Id.ToString();
                estado = true;
                imgMin2.Source = img;
            }else if (imgMin3.Source == null)
            {
                lbImage.Text = imgMin3.Id.ToString();
                estado = true;
                imgMin3.Source = img;
            }
            if (estado)
            {
                imgCamara.Source = img;
                btnQuitar.IsEnabled = true;
            }
            else
            {
                //agregar mensaje de limite de fotos
                imgCamara.Source = null;
                btnQuitar.IsEnabled = false;
            }
        }
    }
}
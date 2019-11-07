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

namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModificarAdopcion : ContentPage
    {
        private string image1;
        private string image2;
        private string image3;
        private int imgCount = 0;
        private int idAdop = 0;

        private List<Imagenes> imagenes = new List<Imagenes>();
        private List<Imagenes> imagenesAgregar = new List<Imagenes>();
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
            idAdop = id;
            Adopciones adopcion = servicioAdopciones.ObtenerAdopcion(id);
            List<ImagenXAdopcion> imagenXAdopcions = servicioImagenXAdopcion.ObtenerImagenXAdopcion(id);
            // servicioImagenes.ObtenerImagenes().Where(x => x.IdImagen == imagenXAdopcions.;
            foreach (ImagenXAdopcion item in imagenXAdopcions)
            {
                imagenes.Add(servicioImagenes.ObtenerImagen(item.IdImagen));
            }
            CargarImagenes();
            CargarTipoAnimal();
            CargarAdopcion(adopcion);
            btnCamara.Clicked += CameraButton_Clicked;
            btnQuitar.Clicked += Quitar_Clicked;
            btnGuardar.Clicked += Guardar_Clicked;
        }

        public void CargarTipoAnimal()
        {
            List<TipoAnimal> _lstTipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
            pckAnimal.ItemsSource = _lstTipoAnimal;
            pckAnimal.ItemDisplayBinding = new Binding("Descripcion");
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
            int index = 0;
            foreach(TipoAnimal tipoAnimal in pckAnimal.ItemsSource)
            {
                if (tipoAnimal.IdTipoAnimal == adopcion.IdTipoAnimal) pckAnimal.SelectedIndex = index;
                index++;
            }
            
        }

        public void CargarImagenes()
        {
            imgCount = imagenes.Count;
            Boolean full = true;
            if (imgCount > 0)
            {
                if (imagenes[0].Estado)
                {
                    imgMin1.Source = ImageSource.FromFile(imagenes[0].Imagen);
                    image1 = imagenes[0].Imagen;
                }
                else
                {
                    full = false;
                }
            }
            if (imgCount > 1)
            {
                if (imagenes[1].Estado)
                {
                    imgMin2.Source = ImageSource.FromFile(imagenes[1].Imagen);
                    image2 = imagenes[1].Imagen;
                }
                else
                {
                    full = false;
                }
            }
            if (imgCount > 2)
            {
                if (imagenes[2].Estado)
                {
                    imgMin3.Source = ImageSource.FromFile(imagenes[2].Imagen);
                    image3 = imagenes[2].Imagen;
                }
                else
                {
                    full = false;
                }
            }
            if (imgCount == 3&&full)
            {
                btnCamara.IsEnabled = false;
            }
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            string directoryPath = "/storage/emulated/0/Mascotapp/";
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    CompressionQuality = 5
                }
                );
            System.IO.File.Copy(photo.Path, directoryPath, true);
            TaskScheduler.FromCurrentSynchronizationContext();
            var trm = "/storage/emulated/0/Android/data/Mascotapp.Mascotapp/files/Pictures/";
            string name = photo.Path.Replace(trm, string.Empty);
            if (photo != null)
            {
                ImageSource image = ImageSource.FromFile(directoryPath + name);
                AgregarFoto(image, directoryPath + name);
                File.Delete(photo.Path);
            }
        }
        /*private async void CameraButton_Clicked(object sender, EventArgs e)
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
        }*/

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
                if (image1 == null && imgCount > 0) imagenes[0].Estado = false;
                if (image2 == null && imgCount > 1) imagenes[1].Estado = false;
                if (image3 == null && imgCount > 2) imagenes[2].Estado = false;
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
            if (pckAnimal.SelectedItem == null)
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
            bool existe = true;
            int id = 0;
            if (imgMin1.Source == null)
            {
                imagenes[0].Imagen = path;
                imagenes[0].Estado = true;
                estado = true;
                lbImage.Text = imgMin1.Id.ToString();
                imgMin1.Source = img;
            }
            else if (imgMin2.Source == null)
            {
                if (imgCount > 1)
                {
                    imagenes[1].Imagen = path;
                    imagenes[1].Estado = true;
                }
                else
                {
                    int index = 0;
                    foreach (Imagenes imgAdd in imagenesAgregar)
                    {
                        if (imgAdd.IdImagen == 2)
                        {
                            imagenesAgregar[index].IdImagen= index;
                            imagenesAgregar[index].Imagen = path;
                            imagenesAgregar[index].Estado= true;
                        }
                        index++;
                    }
                    if (index == 0)
                    {
                        existe = false;
                        id = 2;
                    }
                }
                lbImage.Text = imgMin2.Id.ToString();
                estado = true;
                imgMin2.Source = img;
            }
            else if (imgMin3.Source == null)
            {
                if (imgCount > 2)
                {
                    imagenes[2].Imagen = path;
                    imagenes[2].Estado = true;
                }
                else
                {
                    int index = 0;
                    foreach (Imagenes imgAdd in imagenesAgregar)
                    {
                        if (imgAdd.IdImagen == 3)
                        {
                            imagenesAgregar[index].IdImagen = index;
                            imagenesAgregar[index].Imagen = path;
                            imagenesAgregar[index].Estado = true;
                        }
                        index++;
                    }
                    if (index == 0)
                    {
                        existe = false;
                        id = 3;
                    }
                }
                lbImage.Text = imgMin3.Id.ToString();
                estado = true;
                imgMin3.Source = img;
            }
            if (!existe)
            {
                Imagenes imgAgregar = new Imagenes
                {
                    IdImagen = id,
                    Imagen = path,
                    Estado = true
                };
                imagenesAgregar.Add(imgAgregar);
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
            try
            {
                if (ValidarForm()&& MainPage.UsuarioRegristrado!=null)
                {
                    var adopcion = servicioAdopciones.ObtenerAdopcion(idAdop);
                    TipoAnimal tipoAnimal = (TipoAnimal)pckAnimal.ItemsSource[pckAnimal.SelectedIndex];
                    adopcion.IdTipoAnimal = tipoAnimal.IdTipoAnimal.Value;
                    adopcion.Detalle = txtDescripcion.Text;
                    adopcion.Edad = Int32.Parse(txtEdad.Text);//faltaria modificar la tabla para agregar edad meses y edad años
                    adopcion.Estado = true;
                    adopcion.Nombre = txtNombre.Text;
                    adopcion.Sexo = pckSexo.SelectedItem.ToString();

                    int idAd = servicioAdopciones.ModificarAdopcion(adopcion);
                    foreach (Imagenes imgAdd in imagenesAgregar)
                    {
                        int idImg = GuardarFoto(imgAdd);
                    }

                    if (imgCount > 0) ModificarFoto(imagenes[0]);
                    if (imgCount > 1)
                    {
                        ModificarFoto(imagenes[1]);
                    }
                    else if (imagenesAgregar.Count > 0) GuardarFoto(imagenesAgregar[0]);
                    if (imgCount > 2)
                    {
                        ModificarFoto(imagenes[2]);
                    }
                    else if (imagenesAgregar.Count > 1) GuardarFoto(imagenesAgregar[1]);

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
            }
        }
        public int GuardarFoto(Imagenes imageButton)
        {
            Boolean estado = false;
            if (imageButton.Imagen != null && imageButton.Imagen != "") estado = true;
            var imagen = new Imagenes
            {
                Imagen = imageButton.Imagen,
                Estado = estado,
                IdImagen = null
            };
            int idNew = servicioImagenes.GuardarImagen(imagen);
            var imgXAd = new ImagenXAdopcion
            {
                IdImagen = idNew,
                IdAdopcion = idAdop
            };
            return servicioImagenXAdopcion.GuardarImagenXAdopcion(imgXAd);
        }
        public void ModificarFoto(Imagenes imageButton)
        {
            //Boolean estado = false;
            //if (imageButton.Imagen != null && imageButton.Imagen != "") estado = true;
            var imagen = new Imagenes
            {
                Imagen = imageButton.Imagen,
                Estado = imageButton.Estado,
                IdImagen = imageButton.IdImagen
            };
            servicioImagenes.GuardarModificarImagen(imagen);
        }
    }
}
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
    public partial class MostrarAdopciones : ContentPage
    {
        private ServicioTipoAnimal serviceTipoAnimal = new ServicioTipoAnimal();
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        public MostrarAdopciones()
        {
            InitializeComponent();
            CargarElementos();
        }
        public async void CargarElementos()
        {
            if (MainPage.UsuarioRegristrado != null)
            {
                string directoryPath = "/storage/emulated/0/Mascotapp/";
                List<Adopciones> adopciones = servicioAdopciones.ObtenerAdopciones().Where(x=>x.IdUsuario== MainPage.UsuarioRegristrado.IdUsuario&&x.Estado).ToList();
                List<TipoAnimal> tipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
                Button btnAgregar = new Button
                {
                    Margin=10,
                    WidthRequest = 200,
                    Text = "Agregar Adopcion",
                    HorizontalOptions=LayoutOptions.Center
                };
                btnAgregar.Clicked += Agregar_Clicked;
                Mostrar.Children.Add(btnAgregar);
                if (adopciones.Count>0){
                    Frame frameGral = new Frame { };
                    FlexLayout flexGral = new FlexLayout {
                        Direction = FlexDirection.Column,
                        JustifyContent = FlexJustify.SpaceBetween,
                        AlignItems = FlexAlignItems.Center,
                    };
                    foreach (Adopciones item in adopciones)
                    {
                        FlexLayout flexLayout = new FlexLayout
                        {
                            Direction = FlexDirection.Row,
                            JustifyContent = FlexJustify.SpaceBetween,
                            AlignItems = FlexAlignItems.Center,
                        };
                        Frame frame = new Frame { };
                        Label lbNombre = new Label
                        {
                            Text = item.Nombre,
                            ClassId = item.IdAdopcion.ToString(),
                        };

                        Label lbTipoAnimal = new Label
                        {
                            Text = tipoAnimal.Where(x => x.IdTipoAnimal == item.IdTipoAnimal).FirstOrDefault().Descripcion,
                            ClassId = tipoAnimal.Where(x => x.IdTipoAnimal == item.IdTipoAnimal).FirstOrDefault().IdTipoAnimal.ToString(),
                        };

                        Button btnEliminar = new Button
                        {
                            ClassId = item.IdAdopcion.ToString(),
                            BindingContext = item.IdAdopcion.ToString(),
                            BackgroundColor = Color.DarkRed,
                            ImageSource = ImageSource.FromFile(directoryPath + "eliminar.png"),
                            HeightRequest = 50.0,
                            WidthRequest = 50.0,
                        };

                        Button btnModificar = new Button
                        {
                            ClassId = item.IdAdopcion.ToString(),
                            BindingContext = item.IdAdopcion.ToString(),
                            BackgroundColor = Color.DarkGreen,
                            ImageSource = ImageSource.FromFile(directoryPath + "editar.png"),
                            HeightRequest = 50.0,
                            WidthRequest = 50.0,
                        };

                        StackLayout btns = new StackLayout
                        {
                            Orientation= StackOrientation.Horizontal,
                            HorizontalOptions = LayoutOptions.EndAndExpand
                        };
                        
                        btns.Children.Add(btnModificar);
                        btns.Children.Add(btnEliminar);

                        btnModificar.Clicked += Modificar_Clicked;
                        btnEliminar.Clicked += Eliminar_Clicked;
                        flexLayout.Children.Add(lbNombre);
                        flexLayout.Children.Add(lbTipoAnimal);
                        flexLayout.Children.Add(btns);

                        frame.Content = flexLayout;
                        flexGral.Children.Add(frame);
                    }
                    frameGral.Content = flexGral;
                    Mostrar.Children.Add(frameGral);
                }
                else{
                    FlexLayout flexLayout = new FlexLayout
                    {
                        Direction = FlexDirection.Row,
                        JustifyContent = FlexJustify.SpaceBetween,
                        AlignItems = FlexAlignItems.Center,
                    };
                    Label label = new Label
                    {
                        Text = "No posee publicaciones!",
                    };
                    label.HorizontalTextAlignment = TextAlignment.Center;
                    flexLayout.Children.Add(label);
                    Frame frame = new Frame { };
                    frame.Content = flexLayout;
                    Mostrar.Children.Add(frame);
                    await DisplayAlert("Publicaciones de adopcion", "No posee publicaciones!", "OK");
                }
            }   
            else
            {
                await DisplayAlert("Acceso denegado", "Necesita estar logueado para ver las publicaciones!", "OK");
            }
        }
        private async void Modificar_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var id = Int32.Parse(btn.BindingContext.ToString());
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ModificarAdopcion(id));
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Borrar Pulicación", "¿Esta seguro que desea eliminar la publicación?", "Si", "No");
            if (rta)
            {
                Button btn = (Button)sender;
                var id = Int32.Parse(btn.BindingContext.ToString());
                Adopciones adopcion = new Adopciones
                {
                    IdAdopcion = id,
                    IdUsuario = MainPage.UsuarioRegristrado.IdUsuario.Value,
                    Estado = false
                };
                servicioAdopciones.BajaAdopcion(adopcion);
                App.MasterD.IsPresented = false;
                await DisplayAlert("Adopciones", "Se eliminó la publicación con exito", "OK");
                await App.MasterD.Detail.Navigation.PopToRootAsync();
            }
        }

        private async void Agregar_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new AgregarAdopcion());
        }
    }
}
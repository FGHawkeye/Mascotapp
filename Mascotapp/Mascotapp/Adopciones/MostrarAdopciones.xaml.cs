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
                List<Adopciones> adopciones = servicioAdopciones.ObtenerAdopciones().Where(x=>x.IdUsuario== MainPage.UsuarioRegristrado.IdUsuario).ToList();
                List<TipoAnimal> tipoAnimal = serviceTipoAnimal.ObtenerTipoAnimales();
                if(adopciones.Count>0){
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

                        Button btnModificar = new Button
                        {
                            Text = "Modificar",
                            ClassId = item.IdAdopcion.ToString(),
                            BindingContext = item.IdAdopcion.ToString(),
                        };
                        btnModificar.Clicked += Modificar_Clicked;
                        flexLayout.Children.Add(lbNombre);
                        flexLayout.Children.Add(lbTipoAnimal);
                        flexLayout.Children.Add(btnModificar);
                        frame.Content = flexLayout;
                        Mostrar.Children.Add(frame);
                    }
                }else{
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
    }
}
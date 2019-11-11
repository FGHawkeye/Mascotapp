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
    public partial class Notificaciones : ContentPage
    {
        private ServicioAdopciones servicioAdopciones = new ServicioAdopciones();
        private ServicioSolicitudAdopcion servicioSolicitudAdopcion = new ServicioSolicitudAdopcion();
        private ServicioUsuarios servicioUsuario = new ServicioUsuarios();

        public Notificaciones()
        {
            InitializeComponent();
            CargarElementos();
        }

        public async void CargarElementos()
        {
            if (MainPage.UsuarioRegristrado != null)
            {
                bool sinNot = true;
                List<Adopciones> adopciones = servicioAdopciones.ObtenerAdopcionesUsuario(MainPage.UsuarioRegristrado.IdUsuario.Value);
                if(adopciones.Count>0){
                    foreach (Adopciones adopciones1 in adopciones)
                    {
                        List<SolicitudAdopcion> solicitudAdopciones = servicioSolicitudAdopcion.ObtenerSolicitudesAdopcion(adopciones1.IdAdopcion.GetValueOrDefault()).Where(x => x.Estado == "Pendiente").ToList();

                        foreach (SolicitudAdopcion solicitudAdopcion in solicitudAdopciones)
                        {
                            sinNot = false;
                            Adopciones adopcion = servicioAdopciones.ObtenerAdopcion(solicitudAdopcion.IdAdopcion);
                            Usuario usuario = servicioUsuario.ObtenerUsuarios().Where(x => x.IdUsuario == solicitudAdopcion.IdUsuarioSolicitante).FirstOrDefault();

                            var grid = new Grid();

                            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                            Frame frame = new Frame { };
                            Label lbNombre = new Label
                            {
                                Text = "Mascota: " + adopcion.Nombre,
                                ClassId = solicitudAdopcion.IdAdopcion.ToString(),
                            };

                            Label lbUsuarioSolicitante = new Label
                            {
                                Text = "Usuario Solicitante: " + usuario.NombreUsuario,
                                ClassId = usuario.IdUsuario.ToString()
                            };

                            Button btnDetalle = new Button
                            {
                                Text = "Ver Detalle",
                                ClassId = solicitudAdopcion.IdAdopcion.ToString(),
                                BindingContext = solicitudAdopcion.IdAdopcion.ToString() + ";" + solicitudAdopcion.IdUsuarioSolicitante.ToString(),
                            };

                            btnDetalle.Clicked += Detalle_Clicked;
                            grid.Children.Add(lbNombre, 0, 0);
                            grid.Children.Add(btnDetalle, 1, 0);
                            grid.Children.Add(lbUsuarioSolicitante, 0, 1);
                            frame.Content = grid;
                            Mostrar.Children.Add(frame);
                        }
                    }
                }
                if(sinNot){
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
                    await DisplayAlert("Notificaciones", "No posee notificaciones!", "OK");
                }
            }else{
                await DisplayAlert("Acceso denegado", "No posee notificaciones!", "OK");
            }
        }
        private async void Detalle_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var id =btn.BindingContext.ToString().Split(';');
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new DetalleNotificacionSolicitud(Int32.Parse(id[0]),Int32.Parse(id[1])));
        }
    }
}
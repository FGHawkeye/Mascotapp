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
using System.Globalization;

namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificacionesAdmin : ContentPage
    {

        private ServicioRefugio servicioRefugio = new ServicioRefugio();
        private ServicioUsuarios servicioUsuario = new ServicioUsuarios();

        public NotificacionesAdmin()
        {
            InitializeComponent();
            CargarElementos();
        }

        public void CargarElementos()
        {
            List<Refugio> refugios = servicioRefugio.ObtenerRefugiosPendientes();
            if (refugios.Count > 0)
            {
                foreach (Refugio refugio in refugios)
                {
                    Usuario usuario = servicioUsuario.ObtenerUsuario(refugio.IdUsuario);

                    var grid = new Grid();

                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                    Frame frame = new Frame { };

                    Label lbUsuarioSolicitante = new Label
                    {
                        Text = "Usuario Solicitante: " + usuario.NombreUsuario,
                        ClassId = usuario.IdUsuario.ToString()
                    };

                    Label lbRazonSocial = new Label
                    {
                        Text = "Razon Social: " + refugio.RazonSocial,
                        ClassId = usuario.IdUsuario.ToString()
                    };

                    Label lbFecha = new Label
                    {
                        Text = "Fecha solicitud: " + refugio.FechaCreacion.ToString(),
                        //Text = "Fecha solicitud: " + refugio.FechaCreacion.ToString(@"MM\/dd\/yyyy HH:mm"),
                        ClassId = refugio.IdRefugio.ToString()
                    };

                    Button btnDetalle = new Button
                    {
                        Text = "Ver Detalle",
                        ClassId = refugio.IdRefugio.ToString(),
                        BindingContext = refugio.IdRefugio.ToString(),
                    };

                    btnDetalle.Clicked += Detalle_Clicked;
                    grid.Children.Add(lbRazonSocial, 0, 0);
                    grid.Children.Add(btnDetalle, 1, 0);
                    grid.Children.Add(lbUsuarioSolicitante, 0, 1);
                    grid.Children.Add(lbFecha, 1, 1);
                    frame.Content = grid;
                    Mostrar.Children.Add(frame);
                }
            }
            else
            {
                FlexLayout flexLayout = new FlexLayout
                {
                    Direction = FlexDirection.Row,
                    JustifyContent = FlexJustify.SpaceBetween,
                    AlignItems = FlexAlignItems.Center,
                };
                Label label = new Label
                {
                    Text = "No posee Notificaciones!",
                };
                label.HorizontalTextAlignment = TextAlignment.Center;
                flexLayout.Children.Add(label);
                Frame frame = new Frame { };
                frame.Content = flexLayout;
                Mostrar.Children.Add(frame);
            }
        }
        private async void Detalle_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new DetalleNotificacionAdmin(Int32.Parse(btn.BindingContext.ToString())));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotapp.Visualizar_mapa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        public Mapa()
        {
            InitializeComponent();
            CargarMapa();
        }

        void CargarMapa()
        {
            map_Mapa.MoveToRegion(Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(
                    new Xamarin.Forms.Maps.Position(-34.456668, -58.624652),
                    Xamarin.Forms.Maps.Distance.FromKilometers(10)
                )
            );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleNotificacionSolicitud : ContentPage
    {
        public DetalleNotificacionSolicitud(int idSol,int idAd)
        {
            InitializeComponent();
        }
    }
}
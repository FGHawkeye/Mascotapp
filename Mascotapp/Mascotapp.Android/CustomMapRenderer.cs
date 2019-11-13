using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Domain.MapRenderer;
using Mascotapp.Droid;
using Mascotapp.Visualizar_mapa;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using System.Linq;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace Mascotapp.Droid
{
    class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        List<CustomPin> customPins;

        public CustomMapRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            if (((CustomPin)pin).MarkerType == "Marcador")
            {
                marker.SetIcon(BitmapDescriptorFactory.DefaultMarker());
            }
            else if (((CustomPin)pin).MarkerType == "Adopcion")
            {
                marker.SetIcon(BitmapDescriptorFactory.DefaultMarker(hue: BitmapDescriptorFactory.HueViolet));
            }
            else
            {
                marker.SetIcon(BitmapDescriptorFactory.DefaultMarker(hue: BitmapDescriptorFactory.HueGreen));
            }

            return marker;
        }

        async void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }

            if (customPin.MarkerType == "Adopcion")
            {
                App.MasterD.IsPresented = false;
                await App.MasterD.Detail.Navigation.PushAsync(new VisualizarSolicitud(customPin.IdPin));
            }
            else if (customPin.MarkerType == "Marcador")
            {
                App.MasterD.IsPresented = false;
                await App.MasterD.Detail.Navigation.PushAsync(new DetalleMarcador(customPin.IdPin));
            }

        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            Android.Views.LayoutInflater inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);

                var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);
                var infoIcon = view.FindViewById<ImageView>(Resource.Id.icon);

                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                }
                if (infoSubtitle != null)
                {
                    //ObtenerDireccion(customPin.Position).ContinueWith((task) =>
                    //{
                    //    infoSubtitle.Text = task.Result;
                    //});
                    infoSubtitle.Text = customPin.Direccion;
                }
                if(infoIcon != null &&  !string.IsNullOrEmpty(customPin.IconPath))
                {
                    Bitmap myBitmap = BitmapFactory.DecodeFile(customPin.IconPath);
                    infoIcon.SetImageBitmap(myBitmap);
                }
                return view;
            }
            return null;
        }

        //private async Task<string> ObtenerDireccion(Position position)
        //{
        //    var geo = new Geocoder();
        //    var result = await geo.GetAddressesForPositionAsync(position);
        //    return result.FirstOrDefault();
        //}

        CustomPin GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (var pin in customPins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }
    }
}

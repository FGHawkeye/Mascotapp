﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
using Plugin.CurrentActivity;

namespace Mascotapp.Droid
{
    [Activity(Label = "Mascotapp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage }, 0);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadExternalStorage }, 0);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.Camera }, 0);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessCoarseLocation }, 0);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] {Manifest.Permission.AccessFineLocation}, 0);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessMockLocation) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessMockLocation}, 0);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessLocationExtraCommands) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessLocationExtraCommands }, 0);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Internet) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.Internet}, 0);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessNetworkState) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] {  Manifest.Permission.AccessNetworkState}, 0);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessWifiState) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] {Manifest.Permission.AccessWifiState}, 0);
            }

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Xamarin.FormsMaps.Init(this, savedInstanceState);

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
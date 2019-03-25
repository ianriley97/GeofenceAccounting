using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using geofence_accounting;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Android.Content;
using GeofenceAccounting;

namespace GeofenceAccounting.Droid
{
    [Activity(Label = "geofence_accounting", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private GeofenceServiceConnection serviceConnection;
        protected override void OnCreate(Bundle savedInstanceState)
        {






            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnStart()
        {
            base.OnStart();
            if(serviceConnection == null)
            {
                this.serviceConnection = new GeofenceServiceConnection(this);
            }
            Intent geofenceIntent = new Intent(this, typeof(GeofenceService));
            StartService(geofenceIntent);
            BindService(geofenceIntent, this.serviceConnection, Bind.AutoCreate);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
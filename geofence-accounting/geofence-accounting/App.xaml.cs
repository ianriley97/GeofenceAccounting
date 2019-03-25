using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace geofence_accounting
{
    public partial class App : Application
    {
        public App()
        {
            //Check every 3 minutes for location.
            //If the location is in a geofence
            //Create a time object, and add it, keep track of the time.
            //When leaving the geofence, stop the time tracking.

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

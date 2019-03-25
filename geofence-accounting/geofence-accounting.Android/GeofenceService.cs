using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Support;
using Android.Support.Compat;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Plugin.Geolocator;

namespace GeofenceAccounting.Droid
{
    [Service]
    class GeofenceService : Service
    {
        public const int geofenceServiceNotificationId = 1000;

        private readonly string NOTIFICATION_CHANNEL_ID = "geofenceAccounting";

        public override void OnCreate()
        {
            //Here we would instantiate any objects that we need.

            //This sections handles the service notification and foreground service creation.
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }
            var channelName = "Geofence Accounting";
            var channelDescription = "Background Location Service for Geofence Accounting App";
            var channel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, channelName, NotificationImportance.Default)
            {
                Description = channelDescription
            };
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);


            NotificationCompat.Builder builder = new NotificationCompat.Builder(this, NOTIFICATION_CHANNEL_ID);

            Notification test = builder.SetOngoing(true)
                .SetSmallIcon(Resource.Drawable.notification_icon_background)
                .SetContentTitle("Test Title")
                .SetPriority(2) //NotificationImportance.Low
                .SetCategory(Notification.CategoryService)
                .Build();


            // Enlist this instance of the service as a foreground service
            StartForeground(2, test);
            
        }

        private bool CheckAndGetPermissions()
        {
            return CrossGeolocator.Current.IsGeolocationAvailable;
        }


        private void CheckLocation()
        {
            
        }

        public override IBinder OnBind(Intent intent)
        {
            IBinder binder = new GeofenceBinder(this);
            return binder;
        }

        public void LocationCheck()
        {
            while(1 == 1)
            {
                CheckAndGetPermissions();
                Thread.Sleep(TimeSpan.FromMinutes(5));

            }
        }
    }
}
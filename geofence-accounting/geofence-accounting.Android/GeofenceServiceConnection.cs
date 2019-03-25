using System;
using System.Collections.Generic;
using System.Text;
using Android.Util;
using Android.OS;
using Android.Content;

namespace GeofenceAccounting.Droid
{
    class GeofenceServiceConnection : Java.Lang.Object, IServiceConnection
    {
        static readonly string TAG = typeof(GeofenceServiceConnection).FullName;

        public bool IsConnected { get; private set; }
        public GeofenceBinder Binder { get; private set; }

        private MainActivity mainActivity;
        public GeofenceServiceConnection(MainActivity activity)
        {
            IsConnected = false;
            Binder = null;
            mainActivity = null;
        }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            Binder = service as GeofenceBinder;
            IsConnected = this.Binder != null;
            Log.Debug(TAG, $"OnServiceConnected {name.ClassName}");

            if(IsConnected)
            {
                //TO DO
                //Display a message that the service has been started
                //Start the service?
                //Binder.Service;
            }
            else
            {
                //TO DO
                //Display a message that the service has failed
            }
            //TO DO 
            //Some other sort of output?
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            IsConnected = false;
            Binder = null;
            //TO DO
            //Say that the connection has been destroyed.
        }
    }
}

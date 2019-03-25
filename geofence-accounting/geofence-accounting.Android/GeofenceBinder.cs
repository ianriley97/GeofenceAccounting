using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GeofenceAccounting.Droid
{
    class GeofenceBinder : Binder
    {
        public GeofenceService Service
        {
            get; private set;
        }
        public GeofenceBinder(GeofenceService service)
        {
            this.Service = service;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Plugin.Geolocator;

namespace GeofenceAccounting
{
    class Geofence
    {
        //Latitude
        //Longitude
        //Radius
        //List<ClockIn>
        private string name;
        //The latitude and longitude of the geofence.
        private Location geofenceLocation;
        //The radius of the geofence in meters
        private int radius;
        //This holds the list of all of the clock ins for this geofence.
        private List<TimeKeeper> clockIns;

        private DistanceCalculator dC;

        private bool active;

        private TimeKeeper activeClockIn;
        public Geofence(string geofenceName, Location newGeofenceLocation, int newRadius)
        {
            name = geofenceName;
            geofenceLocation = newGeofenceLocation;
            radius = newRadius;
            clockIns = new List<TimeKeeper>();
            dC = new DistanceCalculator();
            active = false;
        }

        public bool CheckGeofenceBorders(Location deviceCurrentLocation)
        {
            //The struct for the distance calculator.
            Position devicePosition;
            devicePosition.Latitude = deviceCurrentLocation.Latitude;
            devicePosition.Longitude = deviceCurrentLocation.Longitude;

            Position geofencePosition;
            geofencePosition.Latitude = geofenceLocation.Latitude;
            geofencePosition.Longitude = geofenceLocation.Longitude;


            //Come back with the distance in kilometers.
            double distanceBetween = dC.Distance(devicePosition, geofencePosition, DistanceType.Kilometers);

            if ((distanceBetween / 1000) < radius)
            {
                //If the distance between in meters is less than the radius then it is within the geofence.
                //I may want to change this later depending on if we want a buffer zone for inaccurate GPS readings.
                return true;
            }
            else
            {
                //We are not within the geofence.
                return false;
            }
        }

        public void EnteredGeofenceBorders()
        {
            TimeKeeper newClockIn = new TimeKeeper("test");
            newClockIn.ClockIn();
            activeClockIn = newClockIn;
            active = true;
            //We don't want to add it now. We will add it when the geofence is left that way we can make sure that the geofence always has complete TimeKeeping data.
            //clockIns.Add(new TimeKeeper("test"));
        }

        public void ExitedGeofenceBorders()
        {
            active = false;
            activeClockIn.ClockOut();
            clockIns.Add(activeClockIn);
            activeClockIn = null;
        }
    }
}

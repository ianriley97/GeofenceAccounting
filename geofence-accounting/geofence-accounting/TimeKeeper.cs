using System;
using System.Collections.Generic;
using System.Text;

namespace GeofenceAccounting
{
    class TimeKeeper
    {
        //ClockIn
        //ClockOut
        //User
        //Duration
        private DateTime timeIn;
        private DateTime timeOut;
        //This will be a string until maybe I have user objects?
        private string user;

        public TimeKeeper(string newUser)
        {
            timeIn = new DateTime();
            timeOut = new DateTime();
            user = newUser;
        }

        public void ClockIn()
        {
            timeIn = DateTime.Now;
        }

        public void ClockOut()
        {
            timeOut = DateTime.Now;
        }

        public double Duration()
        {
            return (timeOut - timeIn).TotalHours;
        }
    }
}

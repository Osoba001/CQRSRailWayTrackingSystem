using RailWayModelLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Utility
{
    public static class Process
    {
        public static decimal GetUnitCost(Track track, int PickupIndex, int destionationIndex)
        {
            decimal cost = 0;
            if (destionationIndex > PickupIndex)
            {
                for (int i = PickupIndex; i < destionationIndex; i++)
                {
                    cost += track.Stations[i].Amount;
                }
            }
            else
            {
                for (int i = PickupIndex; i > destionationIndex; i--)
                {
                    cost += track.Stations[i].Amount;
                }
            }
            return cost;
        }

        public static DateTime ArriverTimeOnTripDay(DateTime tripDate, DateTime trainArriverTime)
        {
            return tripDate.Date.AddHours(trainArriverTime.Hour).AddMinutes(trainArriverTime.Minute).AddMilliseconds(trainArriverTime.Second);
        }
        public static string GetNestStation(Track track, int currentStationIndex)
        {
            if (currentStationIndex < track.Stations.Max(S => S.Index))
            {
                return track.Stations[currentStationIndex + 1].StationName;
            }
            else
            {
                return track.Stations[currentStationIndex].StationName;
            }
        }
    }
}

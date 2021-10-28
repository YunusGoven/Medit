using System.Collections.Generic;
using Geolocation;
using Medit1.Models;

namespace Medit1.Utils
{
    public static class DistanceCalculator
    {
        public static double GetDistance(Port depart, Port arrive, List<Port> transit)
        {
            double distance = 0;
            if (transit.Count == 0)
            {
                distance = GeoCalculator.GetDistance(depart.Latitude, depart.Longitude,
                    arrive.Latitude, arrive.Longitude);
            }
            else
            {
                var count = transit.Count;
                for (int i = 0; i < count; i++)
                {
                    if (i == 0) distance += GeoCalculator.GetDistance(depart.Latitude, depart.Longitude,
                        transit[i].Latitude, transit[i].Longitude);
                    else distance += GeoCalculator.GetDistance(transit[i - 1].Latitude, transit[i - 1].Longitude,
                        transit[i].Latitude, transit[i].Longitude);
                }
                distance += GeoCalculator.GetDistance(transit[count - 1].Latitude, transit[count - 1].Longitude,
                    arrive.Latitude, arrive.Longitude);
            }
            return distance;
        }

        public static float GetDistance(Port portDepart, Port arrivalPort, ICollection<CruisePort> transitPorts)
        {
           var transit = new List<Port>();
           foreach (var transitPort in transitPorts)
           {
               transit.Add(transitPort.Port);
           }
           return (float) GetDistance(portDepart,arrivalPort,transit);
        }
    }
}

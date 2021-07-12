using System.Collections.Generic;

namespace LoggingKata
{
    public struct Point
    {
        public IEnumerable<object> latitude;

        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
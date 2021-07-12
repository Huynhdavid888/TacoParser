using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
  public class TacoBell : ITrackable
    {
        public TacoBell(string name, double lat, double longitude)
        {
            Name = name;

            Location = new Point() { Latitude = lat, Longitude = longitude };
        }
    
        public string Name { get; set; }
        public Point Location { get; set; }
    
        
    }
}

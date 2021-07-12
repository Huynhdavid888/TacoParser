using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            if (lines.Length == 0)
            {
                logger.LogError("No lines to read");
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("Not enough lines to compare data");
            }



            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            ITrackable store1 = null;
            ITrackable store2 = null;

            double distance = 0;
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            logger.LogInfo("Begin comparison");

            for (int c = 0; c < locations.Length; c++)
            {
                var cordA = new GeoCoordinate(locations[c].Location.Latitude, locations[c].Location.Longitude);
               
                    for (int p = 0; p < locations.Length; p++)
                {
                    var cordB = new GeoCoordinate(locations[p].Location.Latitude, locations[p].Location.Longitude);

                    if (cordA.GetDistanceTo(cordB) > distance)
                    {
                        distance = cordA.GetDistanceTo(cordB);

                        store1 = locations[c];
                        store2 = locations[p];
                        logger.LogInfo("......................");
                        logger.LogInfo($"{store1.Name} is furthest from {store2.Name}");
                        logger.LogInfo($"current farthest distance is {distance}");
                    }

                }
            }

            Console.WriteLine($"the two furthest Taco Bells are {store1.Name} and {store2.Name} \n" + $"with a distance of {distance} meters");
            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.


            
        }
    }
}

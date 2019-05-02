using System.Collections.Generic;

namespace Challenge2.Model
{
    public class Planet
    {
        public string Name { get; set; }

        public List<Planet> ReachablePlanets { get; set; }
    }
}

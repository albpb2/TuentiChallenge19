using System.Collections.Generic;

namespace Challenge2.Model
{
    public class Planet
    {
        public Planet(string name)
        {
            Name = name;
            ReachablePlanets = new List<Planet>();
        }

        public string Name { get; set; }

        public List<Planet> ReachablePlanets { get; set; }
    }
}

using System.Collections.Generic;
using System.Linq;

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

        public int CountPaths()
        {
            if (!ReachablePlanets.Any())
            {
                return 1;
            }

            return ReachablePlanets.Sum(p => p.CountPaths());
        }
    }
}

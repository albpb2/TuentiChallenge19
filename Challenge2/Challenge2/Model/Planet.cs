using System.Collections.Generic;
using System.Linq;

namespace Challenge2.Model
{
    public class Planet
    {
        private const string FinalPlanetName = "New Earth";

        public Planet(string name)
        {
            Name = name;
            ReachablePlanets = new List<Planet>();
        }

        public string Name { get; set; }

        public List<Planet> ReachablePlanets { get; set; }

        public bool IsFinalPlanet => string.Equals(Name, FinalPlanetName);

        public int CountPaths()
        {
            if (!ReachablePlanets.Any())
            {
                return IsFinalPlanet ? 1 : 0;
            }

            return ReachablePlanets.Sum(p => p.CountPaths());
        }
    }
}

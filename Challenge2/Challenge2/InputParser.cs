using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Challenge2.Model;

namespace Challenge2
{
    public class InputParser : IInputParser
    {
        public IEnumerable<Case> ParseInput(string inputPath)
        {
            var lines = File.ReadAllLines(inputPath);

            var numberOfCases = ParseNumberOfCases(lines.First());

            var firstCaseLine = 1;
            var cases = new List<Case>();
            for(var i = 0; i < numberOfCases; i++)
            {
                var numberOfPlanets = ParseNumberOfPlanets(lines[firstCaseLine], firstCaseLine);
                var planets = new Dictionary<string, Planet>();

                for (var j = 1; j <= numberOfPlanets; j++)
                {
                    ParsePlanetData(lines[firstCaseLine + j], firstCaseLine + j, planets);
                }

                cases.Add(new Case
                {
                    Planets = planets.Values.ToList()
                });

                firstCaseLine += numberOfPlanets + 1;
            }

            return cases;
        }

        private int ParseNumberOfCases(string inputLine)
        {
            return int.TryParse(inputLine, out var numberOfCases) 
                ? numberOfCases 
                : throw new Exception("The number of cases could not be parsed");
        }

        private int ParseNumberOfPlanets(string inputLine, int lineNumber)
        {
            return int.TryParse(inputLine, out var numberOfCases)
                ? numberOfCases
                : throw new Exception($"The number of planets could not be parsed from line {lineNumber}");
        }

        private void ParsePlanetData(string inputLine, int lineNumber, Dictionary<string, Planet> planets)
        {
            var lineParts = inputLine.Split(":");
            if (lineParts.Length != 2)
            {
                throw new Exception("Wrong planet format in line {lineNumber}");
            }

            var planet = ParsePlanet(lineParts.First(), planets);

            var reachablePlanetsNames = lineParts[1].Split(",");
            foreach (var reachablePlanetName in reachablePlanetsNames)
            {
                var reachablePlanet = ParsePlanet(reachablePlanetName, planets);

                planet.ReachablePlanets.Add(reachablePlanet);
            }
        }

        private Planet ParsePlanet(string planetName, Dictionary<string, Planet> planets)
        {
            if (!planets.TryGetValue(planetName, out var planet))
            {
                planet = new Planet(planetName);
                planets.Add(planetName, planet);
            }

            return planet;
        }
    }
}

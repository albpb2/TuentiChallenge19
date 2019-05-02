using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Challenge4.Model;

namespace Challenge4
{
    public class InputParser : IInputParser
    {
        public IEnumerable<PartyList> ParseInput(string inputPath)
        {
            var lines = File.ReadAllLines(inputPath);

            var numberOfCases = ParseNumberOfCases(lines.First());

            var currentLine = 1;
            var cases = new List<PartyList>();

            for (var i = 0; i < numberOfCases; i++)
            {
                cases.Add(ParseCase(lines[currentLine], lines[currentLine + 1]));
                currentLine += 2;
            }

            return cases;
        }

        private int ParseNumberOfCases(string inputLine)
        {
            return int.TryParse(inputLine, out var numberOfCases)
                ? numberOfCases
                : throw new Exception("The number of cases could not be parsed");
        }

        private PartyList ParseCase(string numberOfElementsLine, string elementsLine)
        {
            var numberOfElements = int.Parse(numberOfElementsLine);
            var elements = elementsLine.Split(" ");

            if (elements.Length != numberOfElements)
            {
                throw new Exception("The specified number of elements does not mach the provided elements");
            }

            var parsedElements = elements.Select(int.Parse).ToList();
            return new PartyList
            {
                List = parsedElements
            };
        }
    }
}

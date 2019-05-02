using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Challenge3.Model;
using Challenge3.Model.Paper;

namespace Challenge3
{
    public class InputParser : IInputParser
    {
        private const int WidthHeaderPosition = 0;
        private const int HeightHeaderPosition = 1;
        private const int NumberOfFoldsHeaderPosition = 2;
        private const int NumberOfPunchesHeaderPosition = 3;

        private readonly Dictionary<string, Fold> _foldsPerCode = new Dictionary<string, Fold>
        {
            ["T"] = Fold.Top,
            ["B"] = Fold.Bottom,
            ["L"] = Fold.Left,
            ["R"] = Fold.Right,
        };

        public IEnumerable<Paper> ParseInput(string inputPath)
        {
            var lines = File.ReadAllLines(inputPath);

            var numberOfCases = ParseNumberOfCases(lines.First());

            var currentLine = 1;
            var cases = new List<Paper>();
            
            return ParseCases(lines, numberOfCases);
        }

        private List<Paper> ParseCases(string[] lines, int numberOfCases)
        {
            var currentLine = 1;
            var cases = new List<Paper>();

            for (var i = 0; i < numberOfCases; i++)
            {
                var caseHeader = ParseCaseHeader(lines[currentLine], currentLine);

                var folds = new List<Fold>();
                for (var j = 1; j <= caseHeader[NumberOfFoldsHeaderPosition]; j++)
                {
                    folds.Add(_foldsPerCode[lines[currentLine + j]]);
                }
                currentLine += caseHeader[NumberOfFoldsHeaderPosition];

                var punches = new List<Coordinate>();
                for (var j = 1; j <= caseHeader[NumberOfPunchesHeaderPosition]; j++)
                {
                    punches.Add(ParsePunchLine(lines[currentLine + j], currentLine + j));
                }
                currentLine += caseHeader[NumberOfPunchesHeaderPosition] + 1;

                cases.Add(new Paper()
                {
                    Width = caseHeader[WidthHeaderPosition],
                    Height = caseHeader[HeightHeaderPosition],
                    Folds = folds,
                    Punches = punches
                });
            }

            return cases;
        }

        private int ParseNumberOfCases(string inputLine)
        {
            return int.TryParse(inputLine, out var numberOfCases)
                ? numberOfCases
                : throw new Exception("The number of cases could not be parsed");
        }

        private int[] ParseCaseHeader(string inputLine, int lineIndex)
        {
            const string separator = " ";
            var headerParts = inputLine.Split(separator);

            const int HeaderLength = 4;
            if (headerParts.Length != HeaderLength)
            {
                throw new Exception($"Case header in line {lineIndex} contains an unexpected number of parts");
            }

            return headerParts.Select(int.Parse).ToArray();
        }

        private Coordinate ParsePunchLine(string inputLine, int lineIndex)
        {
            const string separator = " ";
            var punchParts = inputLine.Split(separator);

            const int PunchLength = 2;
            if (punchParts.Length != PunchLength)
            {
                throw new Exception($"Punch in line {lineIndex} contains an unexpected number of parts");
            }

            var parsedPunchParts = punchParts.Select(int.Parse).ToArray();

            return new Coordinate(parsedPunchParts[0], parsedPunchParts[1]);
        }
    }
}

using Challenge1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge1
{
    public class InputParser : IInputParser
    {
        public IEnumerable<Case> ParseInput(string inputPath)
        {
            string[] lines = new string[0];

            lines = File.ReadAllLines(inputPath);

            var numberOfCases = int.Parse(lines[0]);
            if (numberOfCases + 1 != lines.Length)
            {
                throw new Exception("The specified number of cases is incorrect");
            }
            
            for (var i = 1; i <= numberOfCases; i++)
            {
                yield return ParseCase(lines[i], i);
            }
        }

        private Case ParseCase(string inputLine, int caseNumber)
        {
            const string LinePartsSeparator = " ";
            var lineParts = inputLine.Split(LinePartsSeparator);

            const int ExpectedLineParts = 2;
            if (lineParts.Length != ExpectedLineParts)
            {
                throw new Exception($"The number of items in case {caseNumber} is incorrect");
            }

            var parsedLineParts = lineParts.Select(int.Parse).ToList();
            return new Case(parsedLineParts[0], parsedLineParts[1]);
        }
    }
}

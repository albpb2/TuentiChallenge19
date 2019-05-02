using System.Collections.Generic;
using System.IO;
using Challenge2.Model;

namespace Challenge2
{
    public class OutputWriter : IOutputWriter
    {
        public void WriteOutput(List<Case> cases, string outputPath)
        {
            var lines = BuildOutputLines(cases);
            File.WriteAllLines(outputPath, lines);
        }

        private IEnumerable<string> BuildOutputLines(List<Case> cases)
        {
            for (var i = 0; i < cases.Count; i++)
            {
                yield return $"Case #{i + 1}: {cases[i].SourcePlanet.CountPaths()}";
            }
        }
    }
}

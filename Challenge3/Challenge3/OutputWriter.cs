using System.Collections.Generic;
using System.IO;
using System.Linq;
using Challenge3.Model.Paper;

namespace Challenge3
{
    public class OutputWriter : IOutputWriter
    {
        public void WriteOutput(List<Paper> cases, string outputPath)
        {
            var lines = BuildOutputLines(cases).SelectMany(l => l);
            File.WriteAllLines(outputPath, lines);
        }

        private IEnumerable<List<string>> BuildOutputLines(List<Paper> cases)
        {
            for (var i = 0; i < cases.Count; i++)
            {
                var caseLines = new List<string>();
                caseLines.Add($"Case #{i + 1}:");

                foreach (var punch in cases[i].Punches.OrderBy(p => p.X).ThenBy(p => p.Y))
                {
                    caseLines.Add($"{punch.X} {punch.Y}");
                }

                yield return caseLines;
            }
        }
    }
}

using Challenge1.Model;
using System.Collections.Generic;
using System.IO;

namespace Challenge1
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
                yield return $"Case #{i + 1}: {cases[i].RequiredTortillas}";
            }
        }
    }
}

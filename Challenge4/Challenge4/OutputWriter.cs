using System.Collections.Generic;
using System.IO;

namespace Challenge4
{
    public class OutputWriter : IOutputWriter
    {
        public void WriteOutput(List<(int, int)> candiesAverages, string outputPath)
        {
            var lines = BuildOutputLines(candiesAverages);
            File.WriteAllLines(outputPath, lines);
        }

        private IEnumerable<string> BuildOutputLines(List<(int Candies, int People)> candiesAverages)
        {
            for (var i = 0; i < candiesAverages.Count; i++)
            {
                yield return $"Case #{i + 1}: {candiesAverages[i].Candies}/{candiesAverages[i].People}";
            }
        }
    }
}

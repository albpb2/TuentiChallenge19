using System.IO;
using System.Linq;

namespace Challenge4
{
    public class CandiesAveragesCalculator : ICandiesAveragesCalculator
    {
        private readonly IInputParser _inputParser;
        private readonly IOutputWriter _outputWriter;
        private readonly ICandiesCalculator _candiesCalculator;

        public CandiesAveragesCalculator(
            IInputParser inputParser,
            IOutputWriter outputWriter,
            ICandiesCalculator candiesCalculator)
        {
            _inputParser = inputParser;
            _outputWriter = outputWriter;
            _candiesCalculator = candiesCalculator;
        }

        public void CalculateCandiesAverages(string inputPath)
        {
            var partyLists = _inputParser.ParseInput(inputPath);

            var candiesAverages = partyLists.Select(l => _candiesCalculator.CalculateAverageCandies(l)).ToList();
            
            var outputPath = Path.Combine(
                Path.GetDirectoryName(inputPath),
                Path.GetFileNameWithoutExtension(inputPath) + "_out" + ".txt");

            _outputWriter.WriteOutput(candiesAverages, outputPath);
        }
    }
}

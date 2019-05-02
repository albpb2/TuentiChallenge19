using System.IO;
using System.Linq;

namespace Challenge1
{
    public class TortillasCalculator : ITortillasCalculator
    {
        private readonly IInputParser _inputParser;
        private readonly IOutputWriter _outputWriter;

        public TortillasCalculator(IInputParser inputParser, IOutputWriter outputWriter)
        {
            _inputParser = inputParser;
            _outputWriter = outputWriter;
        }

        public void CalculateTortillas(string inputPath)
        {
            var cases = _inputParser.ParseInput(inputPath).ToList();

            var outputPath = Path.Combine(
                Path.GetDirectoryName(inputPath),
                Path.GetFileNameWithoutExtension(inputPath) + "_out" + ".txt");

            _outputWriter.WriteOutput(cases, outputPath);
        }
    }
}

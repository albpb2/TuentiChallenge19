using System.IO;
using System.Linq;

namespace Challenge2
{
    public class PathCounter : IPathCounter
    {
        private readonly IInputParser _inputParser;
        private readonly IOutputWriter _outputWriter;

        public PathCounter(IInputParser inputParser, IOutputWriter outputWriter)
        {
            _inputParser = inputParser;
            _outputWriter = outputWriter;
        }

        public void CountPaths(string inputPath)
        {
            var cases = _inputParser.ParseInput(inputPath).ToList();

            var outputPath = Path.Combine(
                Path.GetDirectoryName(inputPath),
                Path.GetFileNameWithoutExtension(inputPath) + "_out" + ".txt");

            _outputWriter.WriteOutput(cases, outputPath);
        }
    }
}

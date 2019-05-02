using System.IO;
using System.Linq;

namespace Challenge3
{
    public class PapersUnfolder : IPapersUnfolder
    {
        private readonly IInputParser _inputParser;
        private readonly IOutputWriter _outputWriter;

        public PapersUnfolder(IInputParser inputParser, IOutputWriter outputWriter)
        {
            _inputParser = inputParser;
            _outputWriter = outputWriter;
        }

        public void UnfoldPapers(string inputPath)
        {
            var papers = _inputParser.ParseInput(inputPath).ToList();

            var outputPath = Path.Combine(
                Path.GetDirectoryName(inputPath),
                Path.GetFileNameWithoutExtension(inputPath) + "_out" + ".txt");

            papers.ForEach(p => p.UnfoldTotally());

            _outputWriter.WriteOutput(papers, outputPath);
        }
    }
}

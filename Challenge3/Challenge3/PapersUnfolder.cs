using Challenge3.Model;
using Challenge3.Model.Paper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge3
{
    public class PapersUnfolder : IPapersUnfolder
    {
        private readonly IInputParser _inputParser;
        private readonly IOutputWriter _outputWriter;

        private Dictionary<Fold, Func<Paper, Paper>> _statePerFoldDirection = new Dictionary<Fold, Func<Paper, Paper>>
        {
            { Fold.Top, (p) => new TopFoldedPaper(p) },
            { Fold.Bottom, (p) => new BottomFoldedPaper(p) },
            { Fold.Left, (p) => new LeftFoldedPaper(p) },
            { Fold.Right, (p) => new RightFoldedPaper(p) }
        };

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

            papers.ForEach(UnfoldPaper);

            _outputWriter.WriteOutput(papers, outputPath);
        }

        private void UnfoldPaper(Paper p)
        {
            while (p.IsFolded)
            {
                p = _statePerFoldDirection[p.Folds.First()](p);
                p.UnfoldOnce();
            }
        }
    }
}

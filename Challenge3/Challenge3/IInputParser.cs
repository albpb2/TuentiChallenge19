using Challenge3.Model.Paper;
using System.Collections.Generic;

namespace Challenge3
{
    public interface IInputParser
    {
        IEnumerable<Paper> ParseInput(string inputPath);
    }
}

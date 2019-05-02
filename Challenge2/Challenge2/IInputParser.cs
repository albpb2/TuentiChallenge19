using Challenge2.Model;
using System.Collections.Generic;

namespace Challenge2
{
    public interface IInputParser
    {
        IEnumerable<Case> ParseInput(string inputPath);
    }
}

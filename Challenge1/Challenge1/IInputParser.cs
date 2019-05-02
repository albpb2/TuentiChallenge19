using Challenge1.Model;
using System.Collections.Generic;

namespace Challenge1
{
    public interface IInputParser
    {
        IEnumerable<Case> ParseInput(string inputPath);
    }
}

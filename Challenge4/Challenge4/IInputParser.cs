using Challenge4.Model;
using System.Collections.Generic;

namespace Challenge4
{
    public interface IInputParser
    {
        IEnumerable<PartyList> ParseInput(string inputPath);
    }
}

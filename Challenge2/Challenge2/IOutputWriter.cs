using Challenge2.Model;
using System.Collections.Generic;

namespace Challenge2
{
    public interface IOutputWriter
    {
        void WriteOutput(List<Case> cases, string outputPath);
    }
}

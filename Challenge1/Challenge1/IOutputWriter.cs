using Challenge1.Model;
using System.Collections.Generic;

namespace Challenge1
{
    public interface IOutputWriter
    {
        void WriteOutput(List<Case> cases, string outputPath);
    }
}

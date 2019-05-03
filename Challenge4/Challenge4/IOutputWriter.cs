using System.Collections.Generic;

namespace Challenge4
{
    public interface IOutputWriter
    {
        void WriteOutput(List<(int, int)> candiesAverages, string outputPath);
    }
}

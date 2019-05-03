using System.Collections.Generic;

namespace Challenge4
{
    public interface IOutputWriter
    {
        void WriteOutput(List<(long, long)> candiesAverages, string outputPath);
    }
}

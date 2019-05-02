using Challenge3.Model.Paper;
using System.Collections.Generic;

namespace Challenge3
{
    public interface IOutputWriter
    {
        void WriteOutput(List<Paper> cases, string outputPath);
    }
}

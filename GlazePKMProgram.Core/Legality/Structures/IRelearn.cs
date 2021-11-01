using System.Collections.Generic;

namespace GlazePKMProgram.Core
{
    public interface IRelearn
    {
        IReadOnlyList<int> Relearn { get; }
    }
}
using System.Collections.Generic;

namespace GlazePKMProgram.Core
{
    public interface IPokeGroup
    {
        IEnumerable<PKM> Contents { get; }
    }
}

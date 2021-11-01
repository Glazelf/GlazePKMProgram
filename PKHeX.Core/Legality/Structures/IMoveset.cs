using System.Collections.Generic;

namespace GlazePKMProgram.Core
{
    /// <summary>
    /// Interface that exposes a Moveset for the object.
    /// </summary>
    public interface IMoveset
    {
        IReadOnlyList<int> Moves { get; }
    }
}

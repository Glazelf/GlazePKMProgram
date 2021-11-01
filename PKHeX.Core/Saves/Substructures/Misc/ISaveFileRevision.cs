namespace GlazePKMProgram.Core
{
    public interface ISaveFileRevision
    {
        int SaveRevision { get; }
        string SaveRevisionString { get; }
    }
}

using GlazePKMProgram.Core;

namespace GlazePKMProgram.WinForms.Controls
{
    public interface IMainEditor : IPKMView
    {
        void UpdateIVsGB(bool skipForm);
        PKM Entity { get; }
        SaveFile RequestSaveFile { get; }
    }
}
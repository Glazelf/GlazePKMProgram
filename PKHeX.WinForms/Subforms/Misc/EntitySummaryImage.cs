using System.Drawing;
using GlazePKMProgram.Core;
using GlazePKMProgram.Drawing;

namespace GlazePKMProgram.WinForms
{
    /// <summary>
    /// Bind-able summary object that can fetch sprite and strings that summarize a <see cref="PKM"/>.
    /// </summary>
    public sealed class EntitySummaryImage : EntitySummary
    {
        public Image Sprite => pkm.Sprite();
        public override string Position { get; }

        public EntitySummaryImage(PKM p, GameStrings strings, string position) : base(p, strings)
        {
            Position = position;
        }
    }
}

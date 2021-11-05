using FluentAssertions;
using GlazePKMProgram.Core;
using Xunit;

namespace GlazePKMProgram.Tests.Saves
{
    public class SwishCryptoTests
    {
        [Fact]
        public void SizeCheck()
        {
            SCTypeCode.Bool3.GetTypeSize().Should().Be(1);
        }

        [Fact]
        public void CanMakeBlankSAV8()
        {
            var sav = SaveUtil.GetBlankSAV(GameVersion.SW, "GlazePKMProgram");
            sav.Should().NotBeNull();
        }
    }
}
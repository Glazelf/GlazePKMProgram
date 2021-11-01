using System.IO;

namespace GlazePKMProgram.Core
{
    public static partial class Util
    {
        /// <summary>
        /// Cleans the local <see cref="fileName"/> by removing any invalid filename characters.
        /// </summary>
        /// <returns>New string without any invalid characters.</returns>
        public static string CleanFileName(string fileName)
        {
            return string.Concat(fileName.Split(Path.GetInvalidFileNameChars()));
        }
    }
}

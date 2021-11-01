using System;

namespace GlazePKMProgram.Core
{
    public static class UpdateUtil
    {
        /// <summary>
        /// Gets the latest version of GlazePKMProgram according to the Github API
        /// </summary>
        /// <returns>A version representing the latest available version of GlazePKMProgram, or null if the latest version could not be determined</returns>
        public static Version? GetLatestGlazePKMProgramVersion()
        {
            const string apiEndpoint = "https://api.github.com/repos/Glaze/GlazePKMProgram/releases/latest";
            var responseJson = NetUtil.GetStringFromURL(apiEndpoint);
            if (responseJson is null)
                return null;

            // Parse it manually; no need to parse the entire json to object.
            const string tag = "tag_name";
            var index = responseJson.IndexOf(tag, StringComparison.Ordinal);
            if (index == -1)
                return null;

            var first = responseJson.IndexOf('"', index + tag.Length + 1) + 1;
            if (first == 0)
                return null;
            var second = responseJson.IndexOf('"', first);
            if (second == -1)
                return null;

            var tagString = responseJson[first..second];
            return !Version.TryParse(tagString, out var latestVersion) ? null : latestVersion;
        }
    }
}

using System.IO;

namespace TelegramLib.Share.Utils.Extensions
{
    internal static class StringExtensions
    {
        public static string ReadStringFromatFromFile(this string path, params object[] args)
        {
            return string.Format(File.ReadAllText(path), args);
        }
    }
}

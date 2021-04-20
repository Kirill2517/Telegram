using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Utils.Extensions
{
    internal static class StringExtensions
    {
        public static string ReadStringFromatFromFile(this string path, params object[] args)
        {
            return string.Format(File.ReadAllText(path), args);
        }
    }
}

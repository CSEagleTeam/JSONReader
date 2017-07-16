using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace JsonReader.Classes
{
    public class ReplaceIllegalCharacters
    {
        public string fileName;
        public string filePath;

        private Regex illegalInFileName = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars()))), RegexOptions.Compiled);
        private Regex illegalInPathName = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidPathChars()))), RegexOptions.Compiled);

        public ReplaceIllegalCharacters(string fileName, string pathName)
        {
            this.fileName = illegalInFileName.Replace(fileName, string.Empty);
            this.filePath = illegalInPathName.Replace(pathName, string.Empty);
        }

    }
}

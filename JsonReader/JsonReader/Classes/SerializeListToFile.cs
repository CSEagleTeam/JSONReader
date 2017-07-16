using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace JsonReader.Classes
{
    public class SerializeListToFile
    {
        private string fileName;
        private string filePath;
        
        private List<OutputJson> outputList;
        public SerializeListToFile(string fileName, string filePath, List<OutputJson> outputList)
        {
            this.fileName = fileName;
            this.filePath = filePath;
            this.outputList = outputList;
        }

        public void SerializeToFile()
        {
            DirectoryInfo di = Directory.CreateDirectory(string.Format("{0}\\Output", filePath));
            using (StreamWriter file = File.CreateText(string.Format(@"{0}\{1}.json", di.FullName, fileName)))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                writer.WriteRawValue(SerializeListToJsonObject());
            }
        }
        private string SerializeListToJsonObject()
        {
            dynamic collectionWrapper = new
            {
                myroot = outputList
            };
            return JsonConvert.SerializeObject(collectionWrapper, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); ;
        }
    }
}

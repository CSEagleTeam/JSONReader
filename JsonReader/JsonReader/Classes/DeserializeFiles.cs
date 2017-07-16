using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace JsonReader.Classes
{
    public class DeserializeFiles
    {
        private string filePath;
        private string[] files;
        public DeserializeFiles(string filePath)
        {
            this.filePath = filePath;
        }

        private void GetFileList()
        {
            try
            {
                this.files = System.IO.Directory.GetFiles(string.Format(@"{0}", filePath), "*.json");

            }
            catch(DirectoryNotFoundException ex)
            {
                DisplayErrorMessageAndExit(ex.Message);
            }
            
        }
        public List<ResourceFile> GetDeserializedList()
        {
            GetFileList();
            if(files.Count() == 0)
                DisplayErrorMessageAndExit("No files found");

            ConcurrentBag<List<ResourceFile>> resourcesCollection = new ConcurrentBag<List<ResourceFile>>();
            Parallel.ForEach(this.files, (currentFile) => {
                JsonSerializerSettings settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
                resourcesCollection.Add(JsonConvert.DeserializeObject<List<ResourceFile>>(File.ReadAllText(currentFile), settings));
            });
            return resourcesCollection.SelectMany(x => x).ToList();
        }
        private void DisplayErrorMessageAndExit(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Environment.Exit(3);
        }
    }
}

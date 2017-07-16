using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonReader.Classes;
using System.Collections.Concurrent;

namespace JsonReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please specify path to sample files");
            string filePath = Console.ReadLine();
            Console.WriteLine("Please specify output file name");
            string outputFileName = Console.ReadLine();
            ReplaceIllegalCharacters clear = new ReplaceIllegalCharacters(outputFileName, filePath);
            DeserializeFiles files = new DeserializeFiles(clear.filePath);
            EvaluateAverageAgeByCountry averageAge = new EvaluateAverageAgeByCountry(files.GetDeserializedList());
            SerializeListToFile outputFile = new SerializeListToFile(clear.fileName, clear.filePath, averageAge.CreateOutputList());
            outputFile.SerializeToFile();
            Console.WriteLine("Processing complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}

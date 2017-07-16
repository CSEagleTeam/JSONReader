using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonReader.Classes
{
    public class EvaluateAverageAgeByCountry
    {
        List<ResourceFile> resources;
        public EvaluateAverageAgeByCountry(List<ResourceFile> resources)
        {
            this.resources = resources;
        }

        public List<OutputJson> CreateOutputList()
        {
            List<OutputJson> outputList = resources.GroupBy(c => new { Country = c.Country }).Select(a => new OutputJson { Country = a.Key.Country, AverageAge = a.Average(x => x.Age).HasValue ? (double?)Math.Round(a.Average(x => x.Age).Value, 2) : null }).Where(c => c.Country != null).OrderBy(x => x.Country).ToList();
            return outputList;
        }
    }
}

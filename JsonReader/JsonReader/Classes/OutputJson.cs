using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace JsonReader.Classes
{
    [DataContract()]
    [JsonObject]
    public class OutputJson
    {
        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "average_age")]
        public double? AverageAge { get; set; }
    }
}

using Newtonsoft.Json;
using System.Diagnostics;

namespace CompanyCalculationConfigurationRepository.Models
{
    [DebuggerDisplay("Name={Name}")]
    public class CompanyConfigurationModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("weight")]
        public WeightConfigurationModel Weight { get; set; }

        [JsonProperty("size")]
        public SizeConfigurationModel Size { get; set; }
    }
}
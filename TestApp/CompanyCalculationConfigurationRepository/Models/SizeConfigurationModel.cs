using Newtonsoft.Json;
using System.Collections.Generic;

namespace CompanyCalculationConfigurationRepository.Models
{
    public class SizeConfigurationModel
    {
        public ValidationConfigurationModel Validation { get; set; }

        [JsonProperty("bracket")]
        public IEnumerable<BracketConfigurationModel> Brackets { get; set; }
    }
}
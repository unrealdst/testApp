using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace CompanyCalculationConfigurationRepository.Models
{
    
    public class CompanyCalculationConfigurationModel
    {
        [JsonProperty("settings")]
        public IEnumerable<CompanyConfigurationModel> Companys;
    }
}

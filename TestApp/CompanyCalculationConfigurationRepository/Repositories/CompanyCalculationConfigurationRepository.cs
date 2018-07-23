using System;
using System.Collections.Generic;
using System.IO;
using CompanyCalculationConfigurationRepository.Interfaces;
using CompanyCalculationConfigurationRepository.Models;
using Newtonsoft.Json;

namespace CompanyCalculationConfigurationRepository
{
    public class CompanyCalculationConfigurationRepository : ICompanyCalculationConfigurationRepository
    {
        private readonly string SubPath = @"..\CompanyCalculationConfigurationRepository\Cofigs\CalculationConfiguration.json";
        private readonly string ConfigPath;

        public CompanyCalculationConfigurationRepository()
        {
            this.ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SubPath);
        }

        public CompanyCalculationConfigurationModel GetCofigs()
        {
            var config = new FileInfo(ConfigPath);
            if (config.Exists)
            {
                using (StreamReader sr = new StreamReader(config.FullName))
                {
                    String configText = sr.ReadToEnd();
                    CompanyCalculationConfigurationModel result = JsonConvert.DeserializeObject<CompanyCalculationConfigurationModel>(configText);
                    return result;
                }
            }

            return null;
        }
    }
}

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
        private readonly string ConfigPath = @"D:\repo\testApp\TestApp\CompanyCalculationConfigurationRepository\Cofigs\CalculationConfiguration.json";
    
        public CompanyCalculationConfigurationModel GetCofigs()
        {
            FileInfo config = new FileInfo(ConfigPath);
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

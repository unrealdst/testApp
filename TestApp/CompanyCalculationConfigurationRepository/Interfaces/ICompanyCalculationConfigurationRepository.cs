using CompanyCalculationConfigurationRepository.Models;

namespace CompanyCalculationConfigurationRepository.Interfaces
{
    public interface ICompanyCalculationConfigurationRepository
    {
        CompanyCalculationConfigurationModel GetCofigs();
    }
}

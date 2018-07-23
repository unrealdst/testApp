using CompanyCalculationConfigurationRepository.Interfaces;
using System.Diagnostics;

namespace CompanyCalculationConfigurationRepository.Models
{
    [DebuggerDisplay("Min={Min},Max={Max}")]
    public class ValidationConfigurationModel: IItIsInBracket
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }

        public bool ItIsInBracket(decimal number)
        {
            var result = ((Min >= 0 && Min < number) && (Max < 0 || Max > number));
            return result;
        }

    }
}
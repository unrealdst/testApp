using CompanyCalculationConfigurationRepository.Interfaces;
using System.Diagnostics;

namespace CompanyCalculationConfigurationRepository.Models
{
    [DebuggerDisplay("Mi={Min},Ma={Max},Pr={Price},Ov={OversizeCost}")]
    public class BracketConfigurationModel: IItIsInBracket
    {
        public decimal Min { get; set; }

        public decimal Max { get; set; }

        public decimal Price { get; set; }

        public decimal? OversizeCost { get; set; }

        public bool ItIsInBracket(decimal number)
        {
            var result = ((Min < 0 || Min < number) && (Max < 0 || Max > number));
            return result;
        }
    }
}
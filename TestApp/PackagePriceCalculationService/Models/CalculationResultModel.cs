using System.Collections.Generic;

namespace PackagePriceCalculationService.Models
{
    public class CalculationResultModel
    {
        public IEnumerable<SingleCompanyCost> SingleCompanyCosts { get; set; }
    }
}

using PackagePriceCalculationService.Models;

namespace PackagePriceCalculationService.Interfaces
{
    interface IPackagePriceCalculation
    {
        CalculationResultModel CalculateCost(CalculationCostParameters parameters);
    }
}

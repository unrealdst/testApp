using System.Diagnostics;

namespace PackagePriceCalculationService.Models
{
    [DebuggerDisplay("Weight={Weight}")]
    public class WeightParameters
    {
        public int Weight { get; set; }
    }
}
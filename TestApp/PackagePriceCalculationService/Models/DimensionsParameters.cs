using System.Diagnostics;

namespace PackagePriceCalculationService.Models
{
    [DebuggerDisplay("W={Width},H={Height},D={Depth}")]
    public class DimensionsParameters
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
    }
}